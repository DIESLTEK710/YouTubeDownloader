Public Class ConversionOptions

    Private Sub ConversionOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IIf(Main.ConvMP3, CMP3.BackColor = Color.FromArgb(100, 100, 100), CMP3.BackColor = Color.FromArgb(55, 55, 55))
        IIf(Main.ConvOpus, COPUS.BackColor = Color.FromArgb(100, 100, 100), COPUS.BackColor = Color.FromArgb(55, 55, 55))
        IIf(Main.DeleteVideo, CDELETE.BackColor = Color.FromArgb(100, 100, 100), CDELETE.BackColor = Color.FromArgb(55, 55, 55))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTN_Done.Click
        Me.Close()
    End Sub

    Private Sub CheckValues(sender As Object, e As EventArgs) Handles CMP3.Click, COPUS.Click, CDELETE.Click
        Dim checker As Button = DirectCast(sender, Button)

        If checker.Name = "CMP3" Then
            Main.ConvMP3 = Not Main.ConvMP3
            CMP3.BackColor = IIf(Main.ConvMP3, Color.FromArgb(100, 100, 100), Color.FromArgb(55, 55, 55))
        ElseIf checker.Name = "COPUS" Then
            Main.ConvOpus = Not Main.ConvOpus
            COPUS.BackColor = IIf(Main.ConvOpus, Color.FromArgb(100, 100, 100), Color.FromArgb(55, 55, 55))
        ElseIf checker.Name = "CDELETE" Then
            Main.DeleteVideo = Not Main.DeleteVideo
            CDELETE.BackColor = IIf(Main.DeleteVideo, Color.FromArgb(100, 100, 100), Color.FromArgb(55, 55, 55))
        End If

        If Not Main.ConvMP3 AndAlso Not Main.ConvOpus Then
            Main.DeleteVideo = False
            CDELETE.BackColor = Color.FromArgb(55, 55, 55)
        End If

        If Main.ConvMP3 And checker.Name = "CMP3" Then
            Main.ConvOpus = False
            COPUS.BackColor = Color.FromArgb(55, 55, 55)
        ElseIf Main.ConvOpus And checker.Name = "COPUS" Then
            Main.ConvMP3 = False
            CMP3.BackColor = Color.FromArgb(55, 55, 55)
        End If
    End Sub
End Class