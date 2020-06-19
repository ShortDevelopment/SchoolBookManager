Public Class Transparent_Picturebox
    Inherits Control
    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)

    End Sub
    Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.Opaque, True)
        BackColor = Color.Transparent
    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Me.Invalidate()
        Me.Update()
        Me.Refresh()
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.DrawString(Me.Text, Me.Font, New SolidBrush(Me.BackColor), New Point(0, 0))
    End Sub
End Class
