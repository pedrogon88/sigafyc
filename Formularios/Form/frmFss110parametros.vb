Imports System.ComponentModel

Public Class frmFss110parametros
    Private msValidado As String = ""
    Private msRequeridos As String() = {"ss010_codigo", "tipo", "prefijo", "clave", "valor"}
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
                txtClave_AN.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim loDatos As New Ess110parametros
                        loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                        loDatos.tipo = cmbTipo.Text
                        loDatos.prefijo = txtPrefijo_AN.Text
                        loDatos.clave = txtClave_AN.Text
                        If loDatos.clave.Substring(loDatos.clave.Length - 1, 1) = sMarcaEncriptado_ Then
                            Dim loEncriptacion As New Encriptacion
                            loDatos.valor = loEncriptacion.Encriptar(txtValor_AN.Text)
                            loEncriptacion = Nothing
                        Else
                            loDatos.valor = txtValor_AN.Text
                        End If
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Add()
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim loDatos As New Ess110parametros
                        loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                        loDatos.tipo = cmbTipo.Text
                        loDatos.prefijo = txtPrefijo_AN.Text
                        loDatos.clave = txtClave_AN.Text
                        If loDatos.GetPK = sOk_ Then
                            loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                            loDatos.tipo = cmbTipo.Text
                            loDatos.prefijo = txtPrefijo_AN.Text
                            loDatos.clave = txtClave_AN.Text
                            If loDatos.clave.Substring(loDatos.clave.Length - 1, 1) = sMarcaEncriptado_ Then
                                Dim loEncriptacion As New Encriptacion
                                loDatos.valor = loEncriptacion.Encriptar(txtValor_AN.Text)
                                loEncriptacion = Nothing
                            Else
                                loDatos.valor = txtValor_AN.Text
                            End If
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
                Me.AccessibleName = txtClave_AN.Text
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        Else
            If Me.Tag.ToString = sBORRAR_ Then
                Dim loDatos As New Ess110parametros
                loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                loDatos.tipo = cmbTipo.Text
                loDatos.prefijo = txtPrefijo_AN.Text
                loDatos.clave = txtClave_AN.Text
                If loDatos.GetPK = sOk_ Then
                    loDatos.ss010_codigo = txtSS010_codigo_AN.Text
                    loDatos.tipo = cmbTipo.Text
                    loDatos.prefijo = txtPrefijo_AN.Text
                    loDatos.clave = txtClave_AN.Text
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
                Case "prefijo"
                    Select Case cmbTipo.Text
                        Case sLocal_
                            lsValorInicial = SesionActiva.equipo
                        Case sUsuario_
                            lsValorInicial = SesionActiva.usuario
                        Case sFecha_
                            lsValorInicial = Today.ToString(sFormatoFecha1_)
                        Case sModulo_
                            lsValorInicial = SesionActiva.sistema
                    End Select
                    e.Cancel = True
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "codigo"
                    Dim loPk As New Ess110parametros
                    loPk.ss010_codigo = txtSS010_codigo_AN.Text
                    loPk.tipo = cmbTipo.Text
                    loPk.prefijo = txtPrefijo_AN.Text
                    loPk.clave = txtClave_AN.Text
                    If loPk.GetPK = sOk_ Then
                        GFsAvisar("Codigo [" & txtClave_AN.Text & "]", sMENSAJE_, "ya existe! Y no puede duplicarse.")
                        e.Cancel = True
                    End If
                    loPk = Nothing
                Case "tipo"
                    If cmbTipo.Text = sGeneral_ Then
                        txtPrefijo_AN.Text = sGeneral_
                        txtPrefijo_AN.Enabled = False
                    Else
                        txtPrefijo_AN.Enabled = True
                    End If
                Case "prefijo"
                    Select Case cmbTipo.Text
                        Case sModulo_
                            Dim loFk As New Ess020modulos
                            loFk.ss010_codigo = txtSS010_codigo_AN.Text
                            loFk.codigo = txtPrefijo_AN.Text
                            If loFk.GetPK = sSinRegistros_ Then
                                Dim loLookUp As New frmBss020modulos
                                loLookUp.Tag = sELEGIR_
                                GPCargar(loLookUp)
                                If loLookUp.entidad IsNot Nothing Then
                                    txtPrefijo_AN.Text = CType(loLookUp.entidad, Ess020modulos).codigo
                                End If
                                e.Cancel = True
                                loLookUp = Nothing
                            End If
                            loFk.CerrarConexion()
                            loFk = Nothing
                        Case sLocal_
                            Dim loFk As New Ess060equipos
                            loFk.codigo = txtPrefijo_AN.Text
                            If loFk.GetPK = sSinRegistros_ Then
                                Dim loLookUp As New frmBss060equipos
                                loLookUp.Tag = sELEGIR_
                                GPCargar(loLookUp)
                                If loLookUp.entidad IsNot Nothing Then
                                    txtPrefijo_AN.Text = CType(loLookUp.entidad, Ess060equipos).codigo
                                End If
                                e.Cancel = True
                                loLookUp = Nothing
                            End If
                            loFk.CerrarConexion()
                            loFk = Nothing
                        Case sUsuario_
                            Dim loFk As New Ess050usuarios
                            loFk.codigo = txtPrefijo_AN.Text
                            If loFk.GetPK = sSinRegistros_ Then
                                Dim loLookUp As New frmBss050usuarios
                                loLookUp.Tag = sELEGIR_
                                GPCargar(loLookUp)
                                If loLookUp.entidad IsNot Nothing Then
                                    txtPrefijo_AN.Text = CType(loLookUp.entidad, Ess050usuarios).codigo
                                End If
                                e.Cancel = True
                                loLookUp = Nothing
                            End If
                            loFk.CerrarConexion()
                            loFk = Nothing
                        Case sFecha_
                            If Not IsDate(txtPrefijo_AN.Text) Then
                                GFsAvisar("La fecha [" & txtPrefijo_AN.Text & "] ingresada", sMENSAJE_, "no es una fecha valida")
                                e.Cancel = True
                            Else
                                Dim ldFecha As Date = Date.Parse(txtPrefijo_AN.Text.ToString)
                                txtPrefijo_AN.Text = ldFecha.ToString("yyyy-MM-dd")
                            End If
                    End Select
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

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()
        ' Inicializa los controles de edición con los valores pertinentes
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls

        msEntidad = "registro de parametro"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                txtSS010_codigo_AN.Text = CType(entidad, Ess110parametros).ss010_codigo
                cmbTipo.Text = CType(entidad, Ess110parametros).tipo
                txtPrefijo_AN.Text = CType(entidad, Ess110parametros).prefijo
            Case Else
                Dim loDatos As New Ess110parametros
                loDatos.ss010_codigo = CType(entidad, Ess110parametros).ss010_codigo
                loDatos.tipo = CType(entidad, Ess110parametros).tipo
                loDatos.prefijo = CType(entidad, Ess110parametros).prefijo
                loDatos.clave = CType(entidad, Ess110parametros).clave
                If loDatos.GetPK() = sOk_ Then
                    txtSS010_codigo_AN.Text = loDatos.ss010_codigo
                    cmbTipo.Text = loDatos.tipo
                    txtPrefijo_AN.Text = loDatos.prefijo
                    txtClave_AN.Text = loDatos.clave
                    If loDatos.clave.Substring(loDatos.clave.Length - 1, 1) = sMarcaEncriptado_ Then
                        Dim loEncriptacion As New Encriptacion
                        txtValor_AN.Text = loEncriptacion.DesEncriptar(loDatos.valor)
                        loEncriptacion = Nothing
                    Else
                        txtValor_AN.Text = loDatos.valor
                    End If
                    cmbEstado.Text = loDatos.estado
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
        End Select
        ' Habilita o deshabilita los controles de edición
        txtSS010_codigo_AN.Enabled = True
        cmbTipo.Enabled = True
        txtPrefijo_AN.Enabled = True
        txtClave_AN.Enabled = True
        txtValor_AN.Enabled = True
        cmbEstado.Enabled = True

        txtSS010_codigo_AN.AccessibleName = "ss010_codigo"
        cmbTipo.AccessibleName = "tipo"
        txtPrefijo_AN.AccessibleName = "prefijo"
        txtClave_AN.AccessibleName = "clave"
        txtValor_AN.AccessibleName = "valor"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtSS010_codigo_AN.Enabled = False

            Case sMODIFICAR_
                txtSS010_codigo_AN.Enabled = False
                cmbTipo.Enabled = False
                txtPrefijo_AN.Enabled = False
                txtClave_AN.Enabled = False

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
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                cmbTipo.Focus()
            Case sMODIFICAR_
                txtClave_AN.Focus()
        End Select
    End Sub

    Private Sub LPInicializaMaxLength()
        txtSS010_codigo_AN.MaxLength = 15
        cmbTipo.MaxLength = 15
        txtPrefijo_AN.MaxLength = 30
        txtClave_AN.MaxLength = 256
        txtValor_AN.MaxLength = 64000
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