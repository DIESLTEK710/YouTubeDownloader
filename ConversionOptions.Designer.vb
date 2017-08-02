<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConversionOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_Done = New System.Windows.Forms.Button()
        Me.CMP3 = New System.Windows.Forms.Button()
        Me.COPUS = New System.Windows.Forms.Button()
        Me.CDELETE = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Open Sans", 15.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Conversion Options"
        '
        'BTN_Done
        '
        Me.BTN_Done.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.BTN_Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Done.Font = New System.Drawing.Font("Open Sans", 10.0!)
        Me.BTN_Done.ForeColor = System.Drawing.Color.White
        Me.BTN_Done.Location = New System.Drawing.Point(12, 241)
        Me.BTN_Done.Name = "BTN_Done"
        Me.BTN_Done.Size = New System.Drawing.Size(204, 30)
        Me.BTN_Done.TabIndex = 4
        Me.BTN_Done.Text = "Done"
        Me.BTN_Done.UseVisualStyleBackColor = True
        '
        'CMP3
        '
        Me.CMP3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.CMP3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMP3.Font = New System.Drawing.Font("Open Sans", 10.0!)
        Me.CMP3.ForeColor = System.Drawing.Color.White
        Me.CMP3.Location = New System.Drawing.Point(12, 81)
        Me.CMP3.Name = "CMP3"
        Me.CMP3.Size = New System.Drawing.Size(204, 30)
        Me.CMP3.TabIndex = 5
        Me.CMP3.Text = "Convert to MP3"
        Me.CMP3.UseVisualStyleBackColor = True
        '
        'COPUS
        '
        Me.COPUS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.COPUS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.COPUS.Font = New System.Drawing.Font("Open Sans", 10.0!)
        Me.COPUS.ForeColor = System.Drawing.Color.White
        Me.COPUS.Location = New System.Drawing.Point(12, 117)
        Me.COPUS.Name = "COPUS"
        Me.COPUS.Size = New System.Drawing.Size(204, 30)
        Me.COPUS.TabIndex = 6
        Me.COPUS.Text = "Convert to Opus"
        Me.COPUS.UseVisualStyleBackColor = True
        '
        'CDELETE
        '
        Me.CDELETE.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.CDELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CDELETE.Font = New System.Drawing.Font("Open Sans", 10.0!)
        Me.CDELETE.ForeColor = System.Drawing.Color.White
        Me.CDELETE.Location = New System.Drawing.Point(12, 153)
        Me.CDELETE.Name = "CDELETE"
        Me.CDELETE.Size = New System.Drawing.Size(204, 48)
        Me.CDELETE.TabIndex = 7
        Me.CDELETE.Text = "Delete video post-conversion"
        Me.CDELETE.UseVisualStyleBackColor = True
        '
        'ConversionOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(228, 283)
        Me.Controls.Add(Me.CDELETE)
        Me.Controls.Add(Me.COPUS)
        Me.Controls.Add(Me.CMP3)
        Me.Controls.Add(Me.BTN_Done)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ConversionOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ConversionOptions"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents BTN_Done As System.Windows.Forms.Button
    Private WithEvents CMP3 As System.Windows.Forms.Button
    Private WithEvents COPUS As System.Windows.Forms.Button
    Private WithEvents CDELETE As System.Windows.Forms.Button
End Class
