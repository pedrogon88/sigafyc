Imports System.ComponentModel

Public Class frmConfirmacion

    Private miCodigo As Integer

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
    Private Sub btnCancelar_MouseHover(sender As Object, e As EventArgs) Handles btnCancelar.MouseHover, btnCancelar.GotFocus
        btnCancelar.Image = My.Resources.Resources.icons8_color_cancel_48
        btnCancelar.Text = ""
    End Sub

    Private Sub btnCancelar_MouseMove(sender As Object, e As EventArgs) Handles btnCancelar.MouseMove
        btnCancelar.Image = My.Resources.Resources.icons8_cancel_48
        btnCancelar.Text = ""
    End Sub

    Private Sub btnCancelar_MouseLeave(sender As Object, e As EventArgs) Handles btnCancelar.MouseLeave, btnCancelar.LostFocus
        btnCancelar.Image = My.Resources.Resources.icons8_cancel_32
        btnCancelar.Text = btnCancelar.Tag.ToString
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        GPBitacoraRegistrar(sMENSAJE_, Me.Text & ", " & txtMensaje.Text & ", Abandono la operación haciendo click CANCELAR")
        Me.Tag = sCancelar_
        Me.Close()
    End Sub

    Private Sub frmConfirmar_Load(sender As Object, e As EventArgs) Handles Me.Load
        miCodigo = GFiAleatorio(1000, 9999)
        txtMensaje.BackColor = Drawing.Color.LightYellow
        lblCodigo.Text = miCodigo.ToString("0000")
        txtCodigo.MaxLength = lblCodigo.Text.Length
        txtCodigo.Text = ""
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtCodigo.Text.Trim.Length = 0 Then
            GFsAvisar("Debe ingresar el codigo indicado para continuar o haga click para cancelar", sMENSAJE_)
            txtCodigo.Focus()
        End If

        If IsNumeric(txtCodigo.Text) Then
            If Integer.Parse(txtCodigo.Text.ToString) = miCodigo Then
                Dim lsMensaje As String = txtMensaje.Text
                GPBitacoraRegistrar(sMENSAJE_, Me.Text & ", " & lsMensaje.Replace(ControlChars.CrLf, sBlanco_) & ", Confirmo introduciendo codigo [" & lblCodigo.Text & "] y luego click en ACEPTAR")
                Me.Tag = sOk_
                Me.Close()
            Else
                GFsAvisar("Codigo ingresado [" & txtCodigo.Text & "] no es correcto el codigo es [" & miCodigo.ToString & "]", sMENSAJE_)
                txtCodigo.Text = ""
                txtCodigo.BackColor = Drawing.Color.LightPink
                txtCodigo.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text = miCodigo.ToString Then
            txtCodigo.BackColor = Color.FromArgb(93, 209, 172)
        Else
            txtCodigo.BackColor = Color.LightPink
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim loValidaEntrada As New ValidacionDataEntry
        e.KeyChar = ChrW(loValidaEntrada.TeclaPresionada(Asc(e.KeyChar)))
    End Sub

    Private Sub frmConfirmacion_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtCodigo.Focus()
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = 13 Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub txtCodigo_Validating(sender As Object, e As CancelEventArgs) Handles txtCodigo.Validating
        If txtCodigo.Text.Trim.Length = 0 Then
            GFsAvisar("Debe ingresar un codigo o hacer click en CANCELAR", sMENSAJE_)
            e.Cancel = True
        End If
    End Sub
End Class