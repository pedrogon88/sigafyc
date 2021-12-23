Public Class frmMensaje
    Private Sub btnAceptar_MouseHover(sender As Object, e As EventArgs) Handles btnAceptar.MouseHover, btnAceptar.GotFocus
        btnAceptar.Image = My.Resources.Resources.icons8_color_ok_48
        btnAceptar.Text = ""
    End Sub

    Private Sub btnAceptar_MouseMove(sender As Object, e As EventArgs) Handles btnAceptar.MouseMove
        btnAceptar.Image = My.Resources.Resources.icons8_ok_48
        btnAceptar.Text = ""
    End Sub

    Private Sub btnAceptar_MouseLeave(sender As Object, e As EventArgs) Handles btnAceptar.MouseLeave, btnAceptar.LostFocus
        btnAceptar.Image = My.Resources.Resources.icons8_ok_32
        btnAceptar.Text = btnAceptar.Tag.ToString
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Close()
    End Sub

    Private Sub frmMensaje_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TopMost = True
    End Sub
End Class