Imports System.ComponentModel

Public Class frmConfirmar

    Private miCodigo As Integer
    Private msRespuesta As String

    Public ReadOnly Property respuesta As String
        Get
            Return msRespuesta
        End Get
    End Property

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
        msRespuesta = sCancelar_
        Me.Close()
    End Sub

    Private Sub frmConfirmar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.TopMost = True
        miCodigo = GFiAleatorio(1000, 9999)
        txtMensaje.BackColor = Drawing.Color.LightYellow
        msRespuesta = sOk_
        lblCodigo.Text = miCodigo.ToString("0000")
        txtCodigo.MaxLength = lblCodigo.Text.Length
        txtCodigo.Text = ""
        txtCodigo.Focus()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtCodigo.Text.Trim.Length = 0 Then
            MessageBox.Show("Debe ingresar el codigo indicado" & ControlChars.CrLf & "para continuar o haga click para cancelar", "Ventana confirmación")
            txtCodigo.Focus()

        End If

        If IsNumeric(txtCodigo.Text) Then
            If Integer.Parse(txtCodigo.Text) = miCodigo Then
                Me.Close()
            Else
                MessageBox.Show("Codigo ingresado [" & txtCodigo.Text & "] no es correcto" & ControlChars.CrLf & "el codigo es [" & miCodigo.ToString & "]", "Ventana confirmación")
                txtCodigo.Text = ""
                txtCodigo.BackColor = Drawing.Color.LightPink
                txtCodigo.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If txtCodigo.Text = miCodigo.ToString Then
            txtCodigo.BackColor = Drawing.Color.LightGreen
        Else
            txtCodigo.BackColor = Drawing.Color.LightPink
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim loValidaEntrada As New ValidacionDataEntry
        e.KeyChar = ChrW(loValidaEntrada.TeclaPresionada(Asc(e.KeyChar)))
    End Sub
End Class