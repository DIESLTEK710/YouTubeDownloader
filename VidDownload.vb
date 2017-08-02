Imports YoutubeExtractor

Public Class VidDownload

    Public dStatus As VidStatus
    Public vidUrl, savePath, videoPath, videoName As String
    Public MP3Format, OpusFormat, DeleteVideo As Boolean

    Dim lastPercentage As Integer = 0

    Private Sub ConvertVideo(sender, args)
        If MP3Format Then
            dStatus.Label2.Text = "Converting..."
            Process.Start(New ProcessStartInfo With {
                          .FileName = "ffmpeg",
                          .Arguments = "-i """ & videoPath + videoName & """ -q:a 0 -map a """ & videoPath + videoName.ToString.Substring(0, videoName.ToString.Length - 4) & """.mp3",
                          .CreateNoWindow = True,
                          .UseShellExecute = False
                      }).WaitForExit()
        ElseIf OpusFormat Then
            dStatus.Label2.Text = "Converting..."
            Process.Start(New ProcessStartInfo With {
                          .FileName = "ffmpeg",
                          .Arguments = "-i """ & videoPath + videoName & """ -map 0:a -codec:a opus -b:a 100k -vbr on """ & videoPath + videoName.ToString.Substring(0, videoName.ToString.Length - 4) & """.opus",
                          .CreateNoWindow = True,
                          .UseShellExecute = False
                      }).WaitForExit()
        End If
        'listIndex.Tag = ".mp3"
        If DeleteVideo Then
            Kill(videoPath + videoName)
        End If
        dStatus.Label2.Text = "Completed"
    End Sub

    Private Sub DownloadProgressChanged(sender, args)
        Dim x As Integer = args.ProgressPercentage
        If lastPercentage < x Then

            dStatus.Label2.Text = "Downloading (" & x & "%)"
            dStatus.progValue = x * (dStatus.Width / 100)
            dStatus.Invalidate()

            lastPercentage = x
        End If
    End Sub

    Public Sub DownloadVideo()
        Try
            Dim link As String = vidUrl
            Dim videoInfos As IEnumerable(Of VideoInfo) = DownloadUrlResolver.GetDownloadUrls(link)
            Dim video As VideoInfo = videoInfos.First(Function(info) info.VideoType = VideoType.Mp4 AndAlso info.Resolution)
            If (video.RequiresDecryption) Then
                DownloadUrlResolver.DecryptDownloadUrl(video)
            End If
            dStatus.Label2.Text = "Connecting..."
            Dim videoDnldr = New VideoDownloader(video, savePath & video.Title + video.VideoExtension)
            dStatus.Label1.Text = video.Title
            Application.DoEvents()
            videoName = video.Title + video.VideoExtension
            videoPath = savePath
            'listIndex.Tag = ".mp4"
            AddHandler videoDnldr.DownloadFinished, AddressOf ConvertVideo
            AddHandler videoDnldr.DownloadProgressChanged, AddressOf DownloadProgressChanged
            videoDnldr.Execute()
        Catch ex As Exception
            dStatus.Label2.Text = "Failed: " + ex.Message
        End Try
    End Sub
End Class
