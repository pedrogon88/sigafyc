Imports System.ComponentModel

Public Class frmFLoginAcceso
    Private msValidado As String = ""
    Private msMayusculas As String = "txtUsuario_AB"
    Private msUsuario As String = ""

    Private Sub btnAceptar_MouseMove(sender As Object, e As EventArgs) Handles btnAceptar.MouseMove
        btnAceptar.Image = My.Resources.Resources.icons8_blue_ok_48
        btnAceptar.Text = ""
    End Sub

    Private Sub btnAceptar_MouseLeave(sender As Object, e As EventArgs) Handles btnAceptar.MouseLeave, btnAceptar.LostFocus
        btnAceptar.Image = My.Resources.Resources.icons8_blue_ok_32
        btnAceptar.Text = btnAceptar.Tag.ToString
    End Sub

    Private Sub btnCancelar_MouseMove(sender As Object, e As EventArgs) Handles btnCancelar.MouseMove
        btnCancelar.Image = My.Resources.Resources.icons8_blue_cancel_48
        btnCancelar.Text = ""
    End Sub

    Private Sub btnCancelar_MouseLeave(sender As Object, e As EventArgs) Handles btnCancelar.MouseLeave, btnCancelar.LostFocus
        btnCancelar.Image = My.Resources.Resources.icons8_blue_cancel_32
        btnCancelar.Text = btnCancelar.Tag.ToString
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        btnCancelar.Image = My.Resources.Resources.icons8_color_cancel_48
        btnCancelar.Text = ""
        Me.Tag = sCancelar_
        GPBitacoraRegistrar(sSALIO_, Me.Text & ", dando click CANCELAR")
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        btnAceptar.Image = My.Resources.Resources.icons8_color_ok_48
        btnAceptar.Text = ""
        msValidado = ""
        For Each loControl As Control In Me.DatosSysAdmin.Controls
            If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                msValidado &= loControl.Tag.ToString
            End If
        Next

        If InStr(msValidado, sCancelar_) > 0 Then
            GFsAvisar("Validacion final", sMENSAJE_, "No han sido ingresado correctamente todos los datos")
            txtUsuario_AB.Focus()
        Else
            SesionActiva.usuario = txtUsuario_AB.Text
            SesionActiva.loggeado = True
            GPSavRegistry(sSesion_, "UltimoUsuario", txtUsuario_AB.Text)
            GPBitacoraRegistrar(sSALIO_, Me.Text & ", dando click ACEPTAR")
            Me.Tag = sOk_
            Me.Close()
        End If
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
        If InStr(msMayusculas.ToLower, CType(sender, Control).Name.ToLower) > 0 Then
            loValidaEntrada.mayuscula = sSi_
        End If
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
                Case "txtUsuario_AB"
                    lsValorInicial = msUsuario
            End Select
            CType(sender, Control).Text = lsValorInicial
            e.Cancel = True
            Exit Sub
        End If
        Select Case CType(sender, Control).Name
            Case "txtPassword_AN"
                If txtUsuario_AB.Text.Trim.Length = 0 Then
                    GFsAvisar("Error de Autenticacion", sMENSAJE_, "Debe ingresar el codigo de usuario")
                    e.Cancel = True
                    txtUsuario_AB.Tag = sCancelar_
                    txtUsuario_AB.Focus()
                End If

                If Not (txtUsuario_AB.Text.ToUpper = SesionActiva.datosControl(sUsuarioSupervisor_).ToString And txtPassword_AN.Text = SesionActiva.datosControl(sPasswordSupervisor_).ToString) Then
                    Dim loDatos As New Ess050usuarios
                    loDatos.codigo = txtUsuario_AB.Text
                    If Not (loDatos.GetPK = sOk_) Then
                        GFsAvisar("Error de Autenticacion", sMENSAJE_, "El usuario no es valido")
                        e.Cancel = True
                    Else
                        SesionActiva.usuario = txtUsuario_AB.Text
                        Dim lsPasswordIngresado As String = GFsSHA256(txtPassword_AN.Text)
                        Dim lsPasswordRegistrado As String = loDatos.password
                        If lsPasswordIngresado <> lsPasswordRegistrado Then
                            GFsAvisar("Error de Autenticacion", sMENSAJE_, "La contraseña ingresada [" & txtPassword_AN.Text & "] no es correcta")
                            Dim liCantidadEquivocacion As Integer = loDatos.CantidadEquivocacionPassword
                            Dim liMaximaCantidadEquivocacion As Integer = loDatos.MaxCantidadEquivocacionPassword
                            liCantidadEquivocacion += 1
                            loDatos.SaveCantidadEquivocacionPassword(liCantidadEquivocacion.ToString)
                            If liCantidadEquivocacion >= liMaximaCantidadEquivocacion Then
                                loDatos.Bloquear()
                                GFsAvisar("Usuario " & txtUsuario_AB.Text.ToUpper & " ha sido bloqueado", sBloqueado_, "Bloqueado por alcanzar limite de equivocaciones permitida [Max =" & liMaximaCantidadEquivocacion.ToString & "]")
                            End If
                            e.Cancel = True
                        Else
                            If loDatos.estado = sBloqueado_ Then
                                GFsAvisar("Usuario " & txtUsuario_AB.Text.ToUpper & " esta bloqueado!!", sViolacion_, "Consulte con el Dpto. Informatica")
                                e.Cancel = True
                            End If
                            If loDatos.valido.Trim.Length > 0 Then
                                If Today.ToString("yyyy-MM-dd") < loDatos.valido Then
                                    GFsAvisar("Esta cuenta tiene fecha validez a partir de [" & loDatos.valido & "]", sMENSAJE_)
                                    e.Cancel = True
                                End If
                            End If
                            If loDatos.expira.Trim.Length > 0 Then
                                If Today.ToString("yyyy-MM-dd") > loDatos.expira Then
                                    GFsAvisar("Esta cuenta tiene fecha expiración [" & loDatos.expira & "]", sMENSAJE_)
                                    e.Cancel = True
                                End If
                            End If
                            If loDatos.login.Trim.Length > 0 Then
                                If loDatos.login <> SesionActiva.loginAcceso Then
                                    GFsAvisar("Esta cuenta tiene restriccion puede utilizar el sistema desde el LoginName [" & loDatos.login & "]", sMENSAJE_, "Y usted se ha conectando con el LoginName [" & SesionActiva.loginAcceso & "]")
                                    e.Cancel = True
                                End If
                            End If
                            If loDatos.ss060_codigo.Trim.Length > 0 Then
                                If SesionActiva.equipo <> loDatos.ss060_codigo Then
                                    GFsAvisar("Esta cuenta solo puede utilizar el sistema desde [" & loDatos.ss060_codigo & "]", sMENSAJE_, "Y usted se esta conectando desde [" & SesionActiva.equipo & "]")
                                    e.Cancel = True
                                End If
                            Else
                                txtUsuario_AB.Tag = sOk_
                            End If
                        End If
                    End If
                    loDatos.CerrarConexion()
                    loDatos = Nothing
                Else
                    txtUsuario_AB.Tag = sOk_
                End If
        End Select
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = SesionActiva.datosControl(sRazonSocial_).ToString & " - Acceso al Sistema | " & My.Application.Info.ProductName.ToUpper & " - Version:" & My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Revision.ToString
        msUsuario = GFsGetRegistry(sSesion_, "UltimoUsuario")
        If msUsuario <> sRESERVADO_ Then txtUsuario_AB.Text = msUsuario

        For Each loControl As Control In Me.DatosSysAdmin.Controls
            If loControl.Name.Substring(0, 3) = sPrefijoTextBox_ Then
                loControl.Tag = sCancelar_
                AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
            End If
        Next
        AddHandler btnAceptar.MouseDown, AddressOf Imagen_Click
        AddHandler btnCancelar.MouseDown, AddressOf Imagen_Click
        'Me.BackColor = Color.FromArgb(45, 44, 49)
        'Me.ForeColor = Color.FromArgb(221, 221, 223)
        'Me.ForeColor = Color.FromArgb(150, 202, 244)
        Me.BackColor = Color.FromArgb(53, 86, 103)
        Me.ForeColor = Color.FromArgb(215, 238, 242)
        GPBitacoraRegistrar(sENTRO_, Me.Text)
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.Focus()
        txtUsuario_AB.Focus()
    End Sub
    Friend Sub Imagen_Click(sender As Object, e As MouseEventArgs)
        Select Case CType(sender, Button).Name
            Case "btnAceptar"
                btnAceptar.Image = My.Resources.Resources.icons8_color_ok_48
                btnAceptar.Text = ""
            Case "btnCancelar"
                btnCancelar.Image = My.Resources.Resources.icons8_color_cancel_48
                btnCancelar.Text = ""
        End Select
    End Sub

    Private Sub btnCancelar_MouseMove(sender As Object, e As MouseEventArgs) Handles btnCancelar.MouseMove

    End Sub

    Private Sub btnAceptar_MouseMove(sender As Object, e As MouseEventArgs) Handles btnAceptar.MouseMove

    End Sub
End Class
