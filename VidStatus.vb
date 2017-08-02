Public Class VidStatus

    Public progValue As Integer = 0

    Private Sub VidStatus_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim brush As New SolidBrush(Color.FromArgb(60, 60, 60))
        e.Graphics.FillRectangle(brush, 0, 0, progValue, Me.Height)
    End Sub

End Class
