Imports System.ComponentModel

Public Class frmFss090perusu
    Private msValidado As String = ""
    Private msRequeridos As String() = {"ss050_codigo", "ss070_codigo"}
    Private moRequeridos As New ArrayList(msRequeridos)

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Tag = sCancelar_
        GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en CANCELAR.")
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If InStr(sAGREGAR_ & sMODIFICAR_, Me.Tag.ToString) > 0 Then
            msValidado = ""
            For Each loControl As Control In Me.TabPage1.Controls
                If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                    msValidado &= loControl.Tag.ToString
                End If
            Next
            If InStr(msValidado, sCancelar_) > 0 Then
                GFsAvisar("Validacion final", sMENSAJE_, "No han sido ingresado correctamente todos los datos")
                txtSS070_codigo_AN.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim loDatos As New Ess090perusu
                        loDatos.ss050_codigo = txtSS050_codigo_AB.Text
                        loDatos.ss070_codigo = txtSS070_codigo_AN.Text
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Add()
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim loDatos As New Ess090perusu
                        loDatos.ss050_codigo = txtSS050_codigo_AB.Text
                        If loDatos.GetPK = sOk_ Then
                            loDatos.ss050_codigo = txtSS050_codigo_AB.Text
                            loDatos.ss070_codigo = txtSS070_codigo_AN.Text
                            If cmbEstado.Text.Trim.Length > 0 Then
                                loDatos.estado = cmbEstado.Text
                            End If
                            loDatos.Put()
                        End If
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                End Select
                Me.Tag = sOk_
                '-->  .AccesibleName envia al Browse la información del codigo que luego deberia 
                '-->  ser usado para la localización del registro en el DataGridView
                Me.AccessibleName = txtSS050_codigo_AB.Text
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        Else
            If Me.Tag.ToString = sBORRAR_ Then
                Dim loDatos As New Ess090perusu
                loDatos.ss050_codigo = txtSS050_codigo_AB.Text
                loDatos.ss070_codigo = txtSS070_codigo_AN.Text
                If loDatos.GetPK = sOk_ Then
                    loDatos.ss050_codigo = txtSS050_codigo_AB.Text
                    loDatos.ss070_codigo = txtSS070_codigo_AN.Text
                    loDatos.Del()
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
            End If
            Me.Tag = sOk_
            GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
            Me.Close()
        End If
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
            Select Case CType(sender, Control).AccessibleName
                Case "ss070_codigo"
                    Dim loPk As New Ess090perusu
                    loPk.ss050_codigo = txtSS050_codigo_AB.Text
                    loPk.ss070_codigo = txtSS070_codigo_AN.Text
                    If loPk.GetPK = sOk_ Then
                        GFsAvisar("Codigo de perfil [" & txtSS070_codigo_AN.Text & "]", sMENSAJE_, "ya fue habilitado! Y no puede duplicarse.")
                        e.Cancel = True
                    Else
                        Dim loFK As New Ess070perfiles
                        Dim lsResultado As String = ""
                        loFK.codigo = txtSS070_codigo_AN.Text
                        lsResultado = loFK.GetPK
                        loFK.CerrarConexion()
                        loFK = Nothing
                        If lsResultado = sSinRegistros_ Then
                            Dim loLookUp As New frmBss070perfiles
                            loLookUp.Tag = sELEGIR_
                            GPCargar(loLookUp)
                            If loLookUp.entidad IsNot Nothing Then
                                txtSS070_codigo_AN.Text = CType(loLookUp.entidad, Ess070perfiles).codigo
                            End If
                            e.Cancel = True
                            loLookUp = Nothing
                        End If
                    End If
                    loPk = Nothing
            End Select
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoComboBox_ Then
                If CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) = False Then
                    e.Cancel = True
                    CType(sender, Control).Tag = sCancelar_
                End If
            End If
        End If
        LPDespiegaDescripcion()
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub LPDespiegaDescripcion()
        lblNombreUsuario.Text = ""
        Dim loFK1 As New Ess050usuarios
        If txtSS050_codigo_AB.Text.Trim.Length = 0 Then
            loFK1.codigo = sNODEFINIDO_
        Else
            loFK1.codigo = txtSS050_codigo_AB.Text
        End If
        If loFK1.GetPK = sOk_ Then
            lblNombreUsuario.Text = loFK1.nombre
        End If
        loFK1.CerrarConexion()
        loFK1 = Nothing

        lblNombrePerfil.Text = ""
        Dim loFK2 = New Ess070perfiles
        If txtSS070_codigo_AN.Text.Trim.Length = 0 Then
            loFK2.codigo = sNODEFINIDO_
        Else
            loFK2.codigo = txtSS070_codigo_AN.Text
        End If
        If loFK2.GetPK = sOk_ Then
            lblNombrePerfil.Text = loFK2.nombre
        End If
        loFK2.CerrarConexion()
        loFK2 = Nothing

    End Sub
    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls

        ' Inicializa los controles de edición con los valores pertinentes
        msEntidad = "registro perfil por usuario"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                txtSS050_codigo_AB.Text = CType(entidad, Ess090perusu).ss050_codigo

            Case Else
                Dim loDatos As New Ess090perusu
                loDatos.ss050_codigo = CType(entidad, Ess090perusu).ss050_codigo
                loDatos.ss070_codigo = CType(entidad, Ess090perusu).ss070_codigo
                If loDatos.GetPK() = sOk_ Then
                    txtSS050_codigo_AB.Text = loDatos.ss050_codigo
                    txtSS070_codigo_AN.Text = loDatos.ss070_codigo
                    cmbEstado.Text = loDatos.estado
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
        End Select
        ' Habilita o deshabilita los controles de edición
        txtSS050_codigo_AB.Enabled = True
        txtSS070_codigo_AN.Enabled = True
        cmbEstado.Enabled = True

        txtSS050_codigo_AB.AccessibleName = "ss050_codigo"
        txtSS070_codigo_AN.AccessibleName = "ss070_codigo"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtSS050_codigo_AB.Enabled = False

            Case sMODIFICAR_
                txtSS050_codigo_AB.Enabled = False

            Case sCONSULTAR_, sBORRAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
                loControls = Me.TabPage2.Controls
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
        End Select
        LPDespiegaDescripcion()
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtSS070_codigo_AN.Focus()
            Case sMODIFICAR_
        End Select

    End Sub

    Private Sub LPInicializaMaxLength()
        txtSS050_codigo_AB.MaxLength = 15
        txtSS070_codigo_AN.MaxLength = 15
        cmbEstado.MaxLength = 15
    End Sub

    Private Sub LPInicializaControles()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                            AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                        Case sPrefijoComboBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                    End Select
                Next
            End If
        Next
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

End Class