Imports System.ComponentModel

Public Class frmFss060equipos
    Private msValidado As String = ""
    Private msRequeridos As String() = {"codigo", "ubicacion", "ip", "mac", "valido", "expira"}
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
                txtCodigo_AN.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim loDatos As New Ess060equipos
                        loDatos.codigo = txtCodigo_AN.Text
                        loDatos.ubicacion = txtUbicacion_AN.Text
                        loDatos.ip = txtIp_AN.Text
                        loDatos.mac = GFsSHA256(txtMac_AN.Text)
                        loDatos.valido = txtValido_FE.Text
                        loDatos.expira = txtExpira_FE.Text
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Add()
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim loDatos As New Ess060equipos
                        loDatos.codigo = txtCodigo_AN.Text
                        If loDatos.GetPK = sOk_ Then
                            loDatos.codigo = txtCodigo_AN.Text
                            loDatos.ubicacion = txtUbicacion_AN.Text
                            loDatos.ip = txtIp_AN.Text
                            loDatos.mac = txtMac_AN.Text
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
                Dim loDatos As New Ess060equipos
                loDatos.codigo = txtCodigo_AN.Text
                If loDatos.GetPK = sOk_ Then
                    loDatos.codigo = txtCodigo_AN.Text
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
                Case "valido"
                    lsValorInicial = Today.ToString("yyyy-MM-dd")
                Case "expira"
                    lsValorInicial = Today.AddYears(iYearsLimit_).ToString("yyyy-MM-dd")
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "codigo"
                    Dim loValidaPk As New Ess060equipos
                    loValidaPk.codigo = txtCodigo_AN.Text
                    If loValidaPk.GetPK = sOk_ Then
                        GFsAvisar("Codigo equipo [" & txtCodigo_AN.Text & "]", sMENSAJE_, "Ya ha sido habilitado, favor verifique el codigo.")
                        e.Cancel = True
                    End If
                    loValidaPk.CerrarConexion()
                    loValidaPk = Nothing
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
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls

        ' Inicializa los controles de edición con los valores pertinentes
        msEntidad = "registro de equipo"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
            Case Else
                Dim loDatos As New Ess060equipos
                loDatos.codigo = CType(entidad, Ess060equipos).codigo
                If loDatos.GetPK() = sOk_ Then
                    txtCodigo_AN.Text = loDatos.codigo
                    txtUbicacion_AN.Text = loDatos.ubicacion
                    txtIp_AN.Text = loDatos.ip
                    txtMac_AN.Text = loDatos.mac
                    txtValido_FE.Text = loDatos.valido
                    txtExpira_FE.Text = loDatos.expira
                    cmbEstado.Text = loDatos.estado
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
        End Select
        ' Habilita o deshabilita los controles de edición
        txtCodigo_AN.Enabled = True
        txtUbicacion_AN.Enabled = True
        txtIp_AN.Enabled = True
        txtMac_AN.Enabled = True
        txtValido_FE.Enabled = True
        txtExpira_FE.Enabled = True
        cmbEstado.Enabled = True

        txtCodigo_AN.AccessibleName = "codigo"
        txtUbicacion_AN.AccessibleName = "nombre"
        txtIp_AN.AccessibleName = "ip"
        txtMac_AN.AccessibleName = "mac"
        txtValido_FE.AccessibleName = "valido"
        txtExpira_FE.AccessibleName = "expira"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_

            Case sMODIFICAR_
                txtCodigo_AN.Enabled = False

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
                txtCodigo_AN.Focus()
            Case sMODIFICAR_
                txtUbicacion_AN.Focus()
        End Select

    End Sub

    Private Sub LPInicializaMaxLength()
        txtCodigo_AN.MaxLength = 15
        txtUbicacion_AN.MaxLength = 128
        txtIp_AN.MaxLength = 45
        txtMac_AN.MaxLength = 64
        txtValido_FE.MaxLength = 20
        txtExpira_FE.MaxLength = 20
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