Imports System.ComponentModel

Public Class frmFEnviarMail

    Private msValidado As String = ""
    Private msRequeridos As String() = {"fromMail", "fromFullName", "to", "asunto", "mensaje"}
    Private moRequeridos As New ArrayList(msRequeridos)
    Private mbPrimeraVez As Boolean = True

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()

        txtMailFrom_AN.AccessibleName = "fromMail"
        txtFromFullName_AN.AccessibleName = "fromFullName"
        txtMailTo_AN.AccessibleName = "mailTo"
        txtMailCC_AN.AccessibleName = "mailCc"
        txtMailCCO_AN.AccessibleName = "mailCco"
        txtNameTo_AN.AccessibleName = "nameTo"
        txtNameCC_AN.AccessibleName = "nameCc"
        txtNameCCO_AN.AccessibleName = "nameCco"
        txtAsunto_AN.AccessibleName = "asunto"
        txtMensaje_AN.AccessibleName = "mensaje"

        lblMensaje.Visible = False
        LPInicializarPredeterminados()
    End Sub

    Private Sub Form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If mbPrimeraVez Then
            mbPrimeraVez = False
            txtMailFrom_AN.Focus()
        End If
    End Sub

    Private Sub LPDespliegaDescripciones()
    End Sub

    Private Sub LPInicializaMaxLength()
        txtMailFrom_AN.MaxLength = 128
        txtFromFullName_AN.MaxLength = 128
        txtMailTo_AN.MaxLength = 128
        txtMailCC_AN.MaxLength = 128
        txtMailCCO_AN.MaxLength = 128
        txtNameTo_AN.MaxLength = 128
        txtNameCC_AN.MaxLength = 128
        txtNameCCO_AN.MaxLength = 128
        txtAsunto_AN.MaxLength = 512
        txtMensaje_AN.MaxLength = 4192
    End Sub

    Private Sub LPInicializaControles()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            loControl.Tag = sCancelar_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                            AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                        Case sPrefijoComboBox_
                            loControl.Tag = sCancelar_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoRadioButton_
                            loControl.Tag = sCancelar_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        loControl1.Tag = sCancelar_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                        AddHandler loControl1.KeyPress, AddressOf ManejoEvento_KeyPress
                                    Case sPrefijoComboBox_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                    Case sPrefijoRadioButton_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                End Select
                            Next
                    End Select
                Next
            End If
        Next
    End Sub

    Private Sub ManejoEvento_Validating(sender As Object, e As CancelEventArgs)

        If CType(sender, Control).Text.Trim.Length = 0 Then
            If LFsExiste(CType(sender, Control).AccessibleName) = sNo_ Then Exit Sub
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).AccessibleName
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).Name.Substring(3, 4)
                Case "Mail"
                    If InStr(CType(sender, Control).Text.Trim, "@") = 0 Then
                        GFsAvisar("Lo ingresado no es una cuenta de correo valida", sMENSAJE_, "Favor verifique lo ingresado y corrijalo")
                        e.Cancel = True
                        CType(sender, Control).Tag = sCancelar_
                        Exit Sub
                    End If
                    If InStr(CType(sender, Control).Text.Trim, ".") = 0 Then
                        GFsAvisar("Lo ingresado no es una cuenta de correo valida", sMENSAJE_, "Favor verifique lo ingresado y corrijalo")
                        e.Cancel = True
                        CType(sender, Control).Tag = sCancelar_
                        Exit Sub
                    End If
            End Select
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoComboBox_ Then
                If CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) = False Then
                    e.Cancel = True
                    CType(sender, Control).Tag = sCancelar_
                End If
            End If
        End If
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        msValidado = ""
        For Each loControl As Control In Me.TabPage1.Controls
            If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                msValidado &= loControl.Tag.ToString
            End If
        Next
        If InStr(msValidado, sCancelar_) > 0 Then
            GFsAvisar("Validacion final", sMENSAJE_, "No han sido ingresado correctamente todos los datos")
            txtMailFrom_AN.Focus()
            Exit Sub
        End If

        btnAceptar.Enabled = False
        btnCancelar.Enabled = False
        If GFsConfirmacion(sEnviarMail_, "Usted esta a punto de enviar un mail a " & txtNameTo_AN.Text & ", sobre " & txtAsunto_AN.Text & ". Si esto lo que desea realizar confirme la operación. Gracias") = sOk_ Then
            LPProcesarParametros()
        End If
        LPGuardaValoresPredeterminados()
        GPBitacoraRegistrar(sSALIO_, Me.Text & ", dando click en [ACEPTAR]")
        Me.Close()
    End Sub

    Private Sub LPProcesarParametros()
        Dim loProcesamiento As New frmProcesamiento
        Dim loCorreo As New Correo
        Dim lsFrom As String = txtMailFrom_AN.Text & sSF_ & txtFromFullName_AN.Text
        loProcesamiento.Show()
        loProcesamiento.lblTitulo.Text = "Enviando correo..."

        loProcesamiento.lblRegistroLeido.Text = "Enviado por " & lsFrom
        loCorreo.Agregar_SourceAddressMail(lsFrom)
        loProcesamiento.lblRegistroProcesado.Text = "Enviado por " & lsFrom
        loProcesamiento.Refresh()

        Dim lsAddress As String = txtMailTo_AN.Text & sSF_ & txtNameTo_AN.Text
        loProcesamiento.lblRegistroLeido.Text = "Enviado a " & lsAddress
        loCorreo.Agregar_TargetAddressMail(sAddressTo_, lsAddress)
        loProcesamiento.lblRegistroProcesado.Text = "Enviado a " & lsAddress
        loProcesamiento.Refresh()

        If txtMailCC_AN.Text.Trim.Length > 0 Then
            lsAddress = txtMailCC_AN.Text & sSF_ & txtNameCC_AN.Text
            loProcesamiento.lblRegistroLeido.Text = "Enviado con copia a " & lsAddress
            loCorreo.Agregar_TargetAddressMail(sAddressCC_, lsAddress)
            loProcesamiento.lblRegistroProcesado.Text = "Enviado con copia a " & lsAddress
            loProcesamiento.Refresh()
        End If

        If txtMailCCO_AN.Text.Trim.Length > 0 Then
            lsAddress = txtMailCCO_AN.Text & sSF_ & txtNameCCO_AN.Text
            loProcesamiento.lblRegistroLeido.Text = "Enviado con copia oculta a " & lsAddress
            loCorreo.Agregar_TargetAddressMail(sAddressCCO_, lsAddress)
            loProcesamiento.lblRegistroProcesado.Text = "Enviado con copia oculta a " & lsAddress
            loProcesamiento.Refresh()
        End If
        If lstAdjuntos.Items.Count > 0 Then
            For I As Integer = 0 To lstAdjuntos.Items.Count - 1
                Dim lsFilename As String = lstAdjuntos.Items(I).ToString
                Dim lsArchivo() As String = lsFilename.Split("\"c)
                Dim lsAdjunto As String = lsArchivo(lsArchivo.Count - 1) & sSF_ & lsFilename
                loProcesamiento.lblRegistroLeido.Text = "Adjuntando: " & lsFilename
                loCorreo.Agregar_Adjunto(lsAdjunto)
                loProcesamiento.lblRegistroProcesado.Text = "Adjuntando: " & lsFilename
            Next
        End If
        Try
            loProcesamiento.lblRegistroLeido.Text = "Ahora se envia el correo...."
            loCorreo.Enviar(txtAsunto_AN.Text, txtMensaje_AN.Text)
            loProcesamiento.lblRegistroProcesado.Text = "Ya se envio el correo...."
        Catch ex As Exception
            GFsAvisar("Hubo inconvenientes con el envio del mail", sMENSAJE_, ex.Message)
        End Try
        loCorreo = Nothing
        loProcesamiento.Close()
        loProcesamiento = Nothing
    End Sub


    Private Sub LPGuardaValoresPredeterminados()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            GPParametroGuardar(sUsuario_, Me.Name & "_" & loControl.Name, loControl.Text)
                        Case sPrefijoComboBox_
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        GPParametroGuardar(sUsuario_, Me.Name & "_" & loControl1.Name, loControl1.Text)
                                End Select
                            Next
                    End Select
                Next
            End If
        Next
    End Sub

    Private Sub LPInicializarPredeterminados()
        Dim lsValor As String = ""
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            lsValor = GFsParametroObtener(sUsuario_, Me.Name & "_" & loControl.Name)
                            If lsValor <> sRESERVADO_ Then
                                loControl.Text = lsValor
                                loControl.Tag = sOk_
                            End If
                        Case sPrefijoComboBox_
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        lsValor = GFsParametroObtener(sUsuario_, Me.Name & "_" & loControl1.Name)
                                        If lsValor <> sRESERVADO_ Then
                                            loControl1.Text = lsValor
                                            loControl1.Tag = sOk_
                                        End If
                                End Select
                            Next
                    End Select
                Next
            End If
        Next
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        GPBitacoraRegistrar(sSALIO_, Me.Text & ", dando click en [CANCELAR]")
    End Sub

    Private Function LFsExiste(ByVal psCampo As String) As String
        Dim lsResultado As String = sNo_
        For Each lsCampo As String In moRequeridos
            If psCampo = lsCampo Then
                lsResultado = sSi_
                Exit For
            End If
        Next
        Return lsResultado
    End Function

    Private Sub btnAdjuntos_Click(sender As Object, e As EventArgs) Handles btnAdjuntos.Click
        Dim loElegirArchivo As New OpenFileDialog
        Dim lsFileName As String

        lstAdjuntos.Items.Clear()
        loElegirArchivo.Multiselect = True
        Dim loResultado As DialogResult = loElegirArchivo.ShowDialog()
        If loResultado = DialogResult.OK Then
            For Each lsFileName In loElegirArchivo.FileNames
                lstAdjuntos.Items.Add(lsFileName)
            Next
        Else
            GFsAvisar("Usted no ha seleccionado ningun archivo", sMENSAJE_, "Por lo cual nada será adjuntado.")
            Exit Sub
        End If
    End Sub
End Class