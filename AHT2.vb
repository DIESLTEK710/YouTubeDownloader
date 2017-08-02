Imports System.ComponentModel

Public Class SizeableTextBox
    Inherits TextBox

    <Browsable(True)> _
    <EditorBrowsable(EditorBrowsableState.Always)> _
    <DefaultValue(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Overrides Property AutoSize() As Boolean
        Get
            Return MyBase.AutoSize
        End Get
        Set(ByVal value As Boolean)
            MyBase.AutoSize = value
        End Set
    End Property

End Class