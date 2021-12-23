Imports System.ComponentModel

Public Class frmFss100habilitaciones
    Private msValidado As String = ""
    Private msRequeridos As String() = {"ss010_codigo", "tipo", "codigo", "ss080_codigo", "valido", "expira", "estado"}
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
                txtSS080_codigo_AN.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim loDatos As New Ess100habilitaciones
                        loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                        loDatos.tipo = cmbTipo.Text
                        loDatos.codigo = txtCodigo_AN.Text
                        loDatos.ss080_codigo = txtSS080_codigo_AN.Text
                        loDatos.valido = txtValido_FE.Text
                        loDatos.expira = txtExpira_FE.Text
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Add()
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim loDatos As New Ess100habilitaciones
                        loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                        loDatos.tipo = cmbTipo.Text
                        loDatos.codigo = txtCodigo_AN.Text
                        loDatos.ss080_codigo = txtSS080_codigo_AN.Text
                        If loDatos.GetPK = sOk_ Then
                            loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                            loDatos.tipo = cmbTipo.Text
                            loDatos.codigo = txtCodigo_AN.Text
                            loDatos.ss080_codigo = txtSS080_codigo_AN.Text
                            loDatos.valido = txtValido_FE.Text
                            loDatos.expira = txtExpira_FE.Text
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
                Me.AccessibleName = txtCodigo_AN.Text
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        Else
            If Me.Tag.ToString = sBORRAR_ Then
                Dim loDatos As New Ess100habilitaciones
                loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                loDatos.tipo = cmbTipo.Text
                loDatos.codigo = txtCodigo_AN.Text
                loDatos.ss080_codigo = txtSS080_codigo_AN.Text
                If loDatos.GetPK = sOk_ Then
                    loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                    loDatos.tipo = cmbTipo.Text
                    loDatos.codigo = txtCodigo_AN.Text
                    loDatos.ss080_codigo = txtSS080_codigo_AN.Text
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
                Case "codigo"
                    Select Case cmbTipo.Text
                        Case sUsuario_
                            lsValorInicial = SesionActiva.usuario
                    End Select
                Case "valido"
                    lsValorInicial = Today.ToString(sFormatoFecha1_)
                Case "expira"
                    lsValorInicial = Today.AddYears(iYearsLimit_).ToString(sFormatoFecha1_)
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "codigo"
                    Select Case cmbTipo.Text
                        Case sPerfil_
                            Dim loFk As New Ess070perfiles
                            loFk.codigo = txtCodigo_AN.Text
                            If loFk.GetPK = sSinRegistros_ Then
                                Dim loLookUp As New frmBss070perfiles
                                loLookUp.Tag = sELEGIR_
                                GPCargar(loLookUp)
                                If loLookUp.entidad IsNot Nothing Then
                                    txtCodigo_AN.Text = CType(loLookUp.entidad, Ess070perfiles).codigo
                                Else
                                    e.Cancel = True
                                End If
                                loLookUp = Nothing
                            End If
                            loFk.CerrarConexion()
                            loFk = Nothing
                        Case sUsuario_
                            Dim loFk As New Ess050usuarios
                            loFk.codigo = txtCodigo_AN.Text
                            If loFk.GetPK = sSinRegistros_ Then
                                Dim loLookUp As New frmBss050usuarios
                                loLookUp.Tag = sELEGIR_
                                GPCargar(loLookUp)
                                If loLookUp.entidad IsNot Nothing Then
                                    txtCodigo_AN.Text = CType(loLookUp.entidad, Ess050usuarios).codigo
                                Else
                                    e.Cancel = True
                                End If
                                loLookUp = Nothing
                            End If
                            loFk.CerrarConexion()
                            loFk = Nothing
                    End Select
                Case "ss080_codigo"
                    Dim loFk As New Ess080restricciones
                    loFk.ss010_codigo = txtSS010_codigo_AN.Text
                    loFk.codigo = txtSS080_codigo_AN.Text
                    If loFk.GetPK = sSinRegistros_ Then
                        Dim loLookUp As New frmBss080restricciones
                        loLookUp.Tag = sELEGIR_
                        GPCargar(loLookUp)
                        If loLookUp.entidad IsNot Nothing Then
                            txtSS080_codigo_AN.Text = CType(loLookUp.entidad, Ess080restricciones).codigo
                        Else
                            e.Cancel = True
                        End If
                        loLookUp = Nothing
                    End If
                    loFk.CerrarConexion()
                    loFk = Nothing
                Case "valido"
                    If Not IsDate(txtValido_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtValido_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtValido_FE.Text.ToString)
                        txtValido_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                    If txtValido_FE.Text < Today.ToString("yyyy-MM-dd") Then
                        GFsAvisar("La validez no puede ser retroactivo", sMENSAJE_, "reintentelo de nuevo")
                        txtValido_FE.Text = Today.ToString("yyyy-MM-dd")
                        e.Cancel = True
                    End If
                Case "expira"
                    If Not IsDate(txtExpira_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtExpira_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtExpira_FE.Text.ToString)
                        txtExpira_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                    If txtExpira_FE.Text < txtValido_FE.Text Then
                        Dim lsAuxiliar As String = txtExpira_FE.Text
                        txtExpira_FE.Text = txtValido_FE.Text
                        txtValido_FE.Text = lsAuxiliar
                        txtValido_FE.Focus()
                    End If
            End Select
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoComboBox_ Then
                If CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) = False Then
                    e.Cancel = True
                    CType(sender, Control).Tag = sCancelar_
                End If
            End If
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub LPDespliegaDescripciones()
        Dim msCodigo As String = sNODEFINIDO_
        lblNombreUsuario.Text = ""
        lblNombreRestriccion.Text = ""
        Select Case cmbTipo.Text
            Case sPerfil_
                Dim loFK As New Ess070perfiles
                msCodigo = sNODEFINIDO_
                If txtCodigo_AN.Text.Trim.Length > 0 Then msCodigo = txtCodigo_AN.Text
                loFK.codigo = msCodigo
                If loFK.GetPK = sOk_ Then
                    lblNombreUsuario.Text = loFK.nombre
                End If
                loFK.CerrarConexion()
                loFK = Nothing
            Case sUsuario_
                Dim loFK As New Ess050usuarios
                msCodigo = sNODEFINIDO_
                If txtCodigo_AN.Text.Trim.Length > 0 Then msCodigo = txtCodigo_AN.Text
                loFK.codigo = msCodigo
                If loFK.GetPK = sOk_ Then
                    lblNombreUsuario.Text = loFK.nombre
                End If
                loFK.CerrarConexion()
                loFK = Nothing
        End Select
        Dim loFK1 As New Ess080restricciones
        msCodigo = sNODEFINIDO_
        If txtSS080_codigo_AN.Text.Trim.Length > 0 Then msCodigo = txtSS080_codigo_AN.Text
        loFK1.ss010_codigo = txtSS010_codigo_AN.Text
        loFK1.codigo = msCodigo
        If loFK1.GetPK = sOk_ Then
            lblNombreRestriccion.Text = loFK1.nombre
        End If
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls

        ' Inicializa los controles de edición con los valores pertinentes
        msEntidad = "registro de habilitacion"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                txtSS010_codigo_AN.Text = CType(entidad, Ess100habilitaciones).ss010_codigo
                cmbTipo.Text = CType(entidad, Ess100habilitaciones).tipo
                txtCodigo_AN.Text = CType(entidad, Ess100habilitaciones).codigo
                txtSS080_codigo_AN.Text = CType(entidad, Ess100habilitaciones).ss080_codigo
            Case Else
                Dim loDatos As New Ess100habilitaciones
                loDatos.ss010_codigo = CType(entidad, Ess100habilitaciones).ss010_codigo
                loDatos.tipo = CType(entidad, Ess100habilitaciones).tipo
                loDatos.codigo = CType(entidad, Ess100habilitaciones).codigo
                loDatos.ss080_codigo = CType(entidad, Ess100habilitaciones).ss080_codigo
                If loDatos.GetPK() = sOk_ Then
                    txtSS010_codigo_AN.Text = loDatos.ss010_codigo
                    cmbTipo.Text = loDatos.tipo
                    txtCodigo_AN.Text = loDatos.codigo
                    txtSS080_codigo_AN.Text = loDatos.ss080_codigo
                    txtValido_FE.Text = loDatos.valido
                    txtExpira_FE.Text = loDatos.expira
                    cmbEstado.Text = loDatos.estado
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
        End Select
        ' Habilita o deshabilita los controles de edición
        txtSS010_codigo_AN.Enabled = True
        cmbTipo.Enabled = True
        txtCodigo_AN.Enabled = True
        txtSS080_codigo_AN.Enabled = True
        txtValido_FE.Enabled = True
        txtExpira_FE.Enabled = True
        cmbEstado.Enabled = True

        txtSS010_codigo_AN.AccessibleName = "ss010_codigo"
        cmbTipo.AccessibleName = "tipo"
        txtCodigo_AN.AccessibleName = "codigo"
        txtSS080_codigo_AN.AccessibleName = "ss080_codigo"
        txtValido_FE.AccessibleName = "valido"
        txtExpira_FE.AccessibleName = "expira"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtSS010_codigo_AN.Enabled = False
                If cmbTipo.Text.Trim.Length > 0 Then cmbTipo.Enabled = False
                If txtCodigo_AN.Text.Trim.Length > 0 Then txtCodigo_AN.Enabled = False
                txtSS080_codigo_AN.Focus()

            Case sMODIFICAR_
                txtSS010_codigo_AN.Enabled = False
                cmbTipo.Enabled = False
                txtCodigo_AN.Enabled = False
                txtSS080_codigo_AN.Enabled = False
                txtValido_FE.Focus()

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
                btnAceptar.Focus()
        End Select
        LPDespliegaDescripciones()
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                cmbTipo.Focus()
            Case sMODIFICAR_
                txtSS080_codigo_AN.Focus()
        End Select
    End Sub

    Private Sub LPInicializaMaxLength()
        txtSS010_codigo_AN.MaxLength = 15
        cmbTipo.MaxLength = 15
        txtCodigo_AN.MaxLength = 15
        txtSS080_codigo_AN.MaxLength = 45
        txtValido_FE.MaxLength = 10
        txtExpira_FE.MaxLength = 10
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