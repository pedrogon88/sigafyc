Imports System.ComponentModel

Public Class frmFGeneraArchivoControl
    Private msValidado As String = ""

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
        Me.Tag = sCancelar_
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        msValidado = ""
        For Each loControl As Control In Me.DatosControl.Controls
            If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                msValidado &= loControl.Tag.ToString
            End If
        Next
        If InStr(msValidado, sCancelar_) > 0 Then
            MessageBox.Show("No han sido ingresado correctamente todos los datos", "Validacion final")
            txtFechaExpiracion_FE.Focus()
        End If
        Me.Tag = sOk_
        Me.Close()
    End Sub

    Private Sub ManejoEvento_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim loValidaEntrada As New ValidacionDataEntry
        Select Case CType(sender, Control).Name.Substring(CType(sender, Control).Name.Length - 3, 3)
            Case sDEAB_
                loValidaEntrada.tipoValor = eTipoValor.Alfabetico
            Case sDEAN_
                loValidaEntrada.tipoValor = eTipoValor.AlfaNumerico
            Case sDENE_
                loValidaEntrada.tipoValor = eTipoValor.NumeroEntero
            Case sDEND_
                loValidaEntrada.tipoValor = eTipoValor.NumeroDecimal
            Case sDEFE_
                loValidaEntrada.tipoValor = eTipoValor.Fecha
            Case sDESR_
                loValidaEntrada.tipoValor = eTipoValor.Ruc
            Case Else
                loValidaEntrada.tipoValor = eTipoValor.AlfaNumerico
        End Select
        e.KeyChar = ChrW(loValidaEntrada.TeclaPresionada(Asc(e.KeyChar), sender))
        loValidaEntrada = Nothing
    End Sub

    Private Sub ManejoEvento_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub ManejoEvento_Validating(sender As Object, e As CancelEventArgs)
        If CType(sender, Control).Text.Trim.Length = 0 Then
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).Name
                Case "txtFechaExpiracion_FE"
                    lsValorInicial = Today.ToString(sFormatoFecha1_)
                Case "txtRazonSocial_AN"
                    lsValorInicial = "[****Nombre empresa****]"
                Case "txtSerialHDD_AN"
                    lsValorInicial = SesionActiva.serialHDD
                Case "txtUltimoAcceso_FE"
                    lsValorInicial = Now.ToString(sFormatoFechaHora1_)
                Case "txtUsuarioSupervisor_AB"
                    lsValorInicial = sManagerName_
                Case "txtPasswordSupervisor_AN"
                    lsValorInicial = sManagerPassword_
                Case "txtPasswordSupervisor2_AN"
                    lsValorInicial = sManagerPassword_
            End Select

            CType(sender, Control).Text = lsValorInicial
            e.Cancel = True
        Else
            Select Case CType(sender, Control).Name
                Case "txtSysAdminPassword_AN"
                    If txtSysAdminUsuario_AB.Text.Trim.Length = 0 Then
                        MessageBox.Show("Debe ingresar el usuario del SysAdmin", "Error de Autenticacion")
                        e.Cancel = True
                        txtSysAdminUsuario_AB.Focus()
                    End If
                    If Not (txtSysAdminUsuario_AB.Text.ToUpper = sManagerName_.ToUpper And txtSysAdminPassword_AN.Text.ToUpper = sManagerPassword_.ToUpper) Then
                        MessageBox.Show("El usuario o la contraseña del SysAdmin no es valido", "Error de Autenticacion")
                        e.Cancel = True
                    End If
                Case "txtPasswordSupervisor2_AN"
                    If txtPasswordSupervisor_AN.Text <> txtPasswordSupervisor2_AN.Text Then
                        MessageBox.Show("Los passwords introducidos no coinciden", "Error en password Supervisor")
                        e.Cancel = True
                    End If
            End Select
        End If
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
            Case "txtSysAdminPassword_AN"
                DatosControl.Visible = True
                txtFechaExpiracion_FE.Focus()
            Case "txtPasswordSupervisor_AN"
                Label9.Visible = True
                txtPasswordSupervisor2_AN.Visible = True
                txtPasswordSupervisor2_AN.Focus()
        End Select
    End Sub

    Private Sub frmFGeneraArchivoControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = My.Application.Info.AssemblyName.ToUpper & " - Version:" & My.Application.Info.Version.ToString & " - Generacion Archivo de Control"
        For Each loControl As Control In Me.DatosControl.Controls
            If loControl.Name.Substring(0, 3) = sPrefijoTextBox_ Then
                loControl.Tag = sCancelar_
                AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
            End If
        Next
        For Each loControl As Control In Me.DatosSysAdmin.Controls
            If loControl.Name.Substring(0, 3) = sPrefijoTextBox_ Then
                loControl.Tag = sCancelar_
                AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
            End If
        Next
        Label9.Visible = False
        txtPasswordSupervisor2_AN.Visible = False
    End Sub

    Private Sub frmFGeneraArchivoControl_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.Focus()
        txtSysAdminUsuario_AB.Focus()
    End Sub
End Class