Imports Newtonsoft.Json
Imports System.ComponentModel

Public Class Form1

    Dim ConvMP3 As Boolean = False
    Dim ConvOpus As Boolean = False
    Dim DeleteVideo As Boolean = False
    Dim saveLocation As String = ""

    Public filepath As String
    Public filename As String
    Public fileext As String

    Dim startPos
    Dim endPos

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Form.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ConvMP3 = Not ConvMP3
        If ConvMP3 Then
            ConvOpus = False
            Button2.BackColor = Color.FromArgb(70, 70, 70)
            Button3.BackColor = Color.FromArgb(100, 100, 100)
        Else
            Button3.BackColor = Color.FromArgb(70, 70, 70)
            DeleteVideo = False
            Button4.BackColor = Color.FromArgb(70, 70, 70)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ConvMP3 Or ConvOpus Then
            DeleteVideo = Not DeleteVideo
            If DeleteVideo Then
                Button4.BackColor = Color.FromArgb(100, 100, 100)
            Else
                Button4.BackColor = Color.FromArgb(70, 70, 70)
            End If
        End If
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        If TextBox1.Text = "Paste video URL here" Then
            TextBox1.Clear()
        End If
    End Sub

    'Private Sub ListView1_MouseClick(sender As Object, e As MouseEventArgs)
    '    If Not ListView1.FocusedItem Is Nothing Then
    '        If ListView1.FocusedItem.Tag = ".mp3" Then
    '            Panel4.Visible = True
    '            Dim objShell As Object
    '            Dim objFolder As Object
    '            Dim strDimensions As Object
    '            objShell = CreateObject("Shell.Application")
    '            objFolder = objShell.Namespace(saveLocation.ToString)
    '            strDimensions = objFolder.GetDetailsOf(objFolder.ParseName(ListView1.FocusedItem.Text & ListView1.FocusedItem.Tag), 27)
    '            Dim ts As TimeSpan = TimeSpan.Parse(strDimensions)
    '            Dim totalSecs As Integer = ts.TotalSeconds
    '            TrackBar1.Maximum = totalSecs
    '            TrackBar1.Value = 0
    '            TrackBar2.Value = 0
    '            TrackBar2.Maximum = totalSecs
    '            filepath = saveLocation
    '            filename = ListView1.FocusedItem.Text
    '            fileext = ListView1.FocusedItem.Tag
    '        Else
    '            Panel4.Visible = False
    '        End If
    '    Else
    '        Panel4.Visible = False
    '    End If
    'End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll, TrackBar1.ValueChanged
        Dim ts As TimeSpan = TimeSpan.FromSeconds(TrackBar1.Value)
        startPos = ts.Hours.ToString("D2") & ":" & ts.Minutes.ToString("D2") & ":" & ts.Seconds.ToString("D2")
        Label2.Text = "Trim (Start: " & startPos & ")"
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll, TrackBar2.ValueChanged
        Dim ts As TimeSpan = TimeSpan.FromSeconds(TrackBar2.Value)
        endPos = ts.Hours.ToString("D2") & ":" & ts.Minutes.ToString("D2") & ":" & ts.Seconds.ToString("D2")
        Label3.Text = "Trim (End: " & endPos & ")"
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        My.Computer.FileSystem.RenameFile(filepath & filename & fileext, filename & "old" & fileext)
        Do Until IO.File.Exists(filepath & filename & "old" & fileext)
            System.Threading.Thread.Sleep(100)
            Application.DoEvents()
        Loop

        Process.Start(New ProcessStartInfo With {
                      .FileName = "ffmpeg",
                      .Arguments = "-ss " & startPos & " -i """ & filepath & filename & "old" & fileext & """ -acodec copy """ & filepath & filename & fileext & """",
                      .CreateNoWindow = True
                      }).WaitForExit()

        Kill(filepath & filename & "old" & fileext)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        My.Computer.FileSystem.RenameFile(filepath & filename & fileext, filename & "old" & fileext)
        Do Until IO.File.Exists(filepath & filename & "old" & fileext)
            System.Threading.Thread.Sleep(100)
            Application.DoEvents()
        Loop

        Dim q = Chr(34)
        Dim fileold = filepath & filename & "old" & fileext
        Dim filenew = filepath & filename & fileext

        Process.Start(New ProcessStartInfo With {
                      .FileName = "ffmpeg",
                      .Arguments = "-ss " & startPos & " -i " & q & fileold & q & " -acodec copy -to " & endPos & " " & q & filenew & q,
                      .CreateNoWindow = True
                  }).WaitForExit()

        Kill(filepath & filename & "old" & fileext)
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            If TextBox1.Text.Contains("youtube") AndAlso TextBox1.Text.Contains("v=") Then

                If (saveLocation = "" Or My.Computer.Keyboard.ShiftKeyDown) Then
                    Dim sfd As New FolderBrowserDialog
                    If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                        saveLocation = sfd.SelectedPath & "\"
                    End If
                End If

                If Not saveLocation = "" Then
                    Dim download As New VidStatus
                    With download
                        .Label1.Text = TextBox1.Text
                        .Label2.Text = "Resolving..."
                        .Dock = DockStyle.Top
                    End With

                    DownloadStatuses.Controls.Add(download)

                    Dim c As New VidDownload With {
                        .dStatus = download,
                        .vidUrl = TextBox1.Text,
                        .savePath = saveLocation,
                        .MP3Format = ConvMP3,
                        .OpusFormat = ConvOpus,
                        .DeleteVideo = DeleteVideo
                    }

                    Dim bg As New BackgroundWorker
                    AddHandler bg.DoWork, AddressOf c.DownloadVideo
                    bg.RunWorkerAsync()
                    TextBox1.Clear()
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ConvOpus = Not ConvOpus
        If ConvOpus Then
            ConvMP3 = False
            Button3.BackColor = Color.FromArgb(70, 70, 70)
            Button2.BackColor = Color.FromArgb(100, 100, 100)
        Else
            Button2.BackColor = Color.FromArgb(70, 70, 70)
            DeleteVideo = False
            Button4.BackColor = Color.FromArgb(70, 70, 70)
        End If
    End Sub
End Class
