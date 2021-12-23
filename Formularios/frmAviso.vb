Public Class frmAviso

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
        If InStr(sSalirSistema_, Me.Tag.ToString) > 0 Then
            GPBitacoraRegistrar(sViolacion_, txtMensaje.Text)
            If System.Windows.Forms.Application.MessageLoop Then
                System.Windows.Forms.Application.Exit()
            Else
                System.Environment.Exit(1)
            End If
        Else
            GPBitacoraRegistrar(sMENSAJE_, txtMensaje.Text)
            Me.Close()
        End If
    End Sub

    Private Sub frmAviso_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.Tag.ToString = sErrorHashid_ Then
            Me.Text = "Violación de Seguridad!"
            PictureBox1.Image = My.Resources.Resources.icons8_high_priority_100
            txtMensaje.ForeColor = Drawing.Color.Red
        Else
            Me.Text = "Mensaje del Sistema"
            PictureBox1.Image = My.Resources.Resources.icons8_info_100
            txtMensaje.ForeColor = Drawing.Color.Black
        End If
    End Sub
End Class