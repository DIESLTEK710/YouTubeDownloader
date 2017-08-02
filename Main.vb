Imports Newtonsoft.Json
Imports System.ComponentModel

Public Class Main

    Public ConvMP3 As Boolean = False
    Public ConvOpus As Boolean = False
    Public DeleteVideo As Boolean = False

    Public filepath, filename, fileext As String

    Dim saveLocation As String = ""
    Dim startPos, endPos

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Form.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub URLEntry_Click(sender As Object, e As EventArgs) Handles URLEntry.Click
        If URLEntry.Text = "YouTube Video URL" Then
            URLEntry.Clear()
        End If
    End Sub

    Private Sub URLEntry_KeyPress(sender As Object, e As KeyPressEventArgs) Handles URLEntry.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If URLEntry.Text.Contains("youtube") AndAlso URLEntry.Text.Contains("v=") Then

                If (saveLocation = "" Or My.Computer.Keyboard.ShiftKeyDown) Then
                    Dim sfd As New FolderBrowserDialog
                    If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                        saveLocation = sfd.SelectedPath & "\"
                    End If
                End If

                If Not saveLocation = "" Then
                    Dim download As New VidStatus
                    With download
                        .Label1.Text = URLEntry.Text
                        .Label2.Text = "Resolving..."
                        .Dock = DockStyle.Top
                    End With

                    DownloadStatuses.Controls.Add(download)

                    Dim c As New VidDownload With {
                        .dStatus = download,
                        .vidUrl = URLEntry.Text,
                        .savePath = saveLocation,
                        .MP3Format = ConvMP3,
                        .OpusFormat = ConvOpus,
                        .DeleteVideo = DeleteVideo
                    }

                    Dim bg As New BackgroundWorker
                    AddHandler bg.DoWork, AddressOf c.DownloadVideo
                    bg.RunWorkerAsync()
                    URLEntry.Clear()
                End If
            Else
                MsgBox("That's not a valid YouTube URL")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ofd As New OpenFileDialog
        With ofd
            .Title = "Select TXT"
            .Filter = "txt files|*.txt"
        End With
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

            If (saveLocation = "") Then
                Dim sfd As New FolderBrowserDialog
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    saveLocation = sfd.SelectedPath & "\"
                End If
            End If

            Dim tfile = My.Computer.FileSystem.ReadAllText(ofd.FileName)
            Dim tfiles = tfile.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

            For Each line In tfiles
                If line.Contains("youtube") AndAlso line.Contains("v=") Then
                    Dim download As New VidStatus
                    With download
                        .Label1.Text = line
                        .Label2.Text = "Resolving..."
                        .Dock = DockStyle.Top
                    End With

                    DownloadStatuses.Controls.Add(download)

                    Dim c As New VidDownload With {
                        .dStatus = download,
                        .vidUrl = line,
                        .savePath = saveLocation,
                        .MP3Format = ConvMP3,
                        .OpusFormat = ConvOpus,
                        .DeleteVideo = DeleteVideo
                    }

                    Dim bg As New BackgroundWorker
                    AddHandler bg.DoWork, AddressOf c.DownloadVideo
                    bg.RunWorkerAsync()
                    Application.DoEvents()
                End If
            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ConversionOptions.ShowDialog()
    End Sub
End Class
