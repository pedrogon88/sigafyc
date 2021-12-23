Imports System.ComponentModel

Public Class frmFb030cotizaciones
    Private msValidado As String = ""
    Private msRequeridos As String() = {"codmoneda1", "codmoneda2", "valido", "compra", "venta"}
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
                txtValido_FE.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim loDatos As New Eb030cotizaciones
                        loDatos.codMoneda1 = txtCodMoneda1_AN.Text
                        loDatos.codMoneda2 = txtCodMoneda2_AN.Text
                        loDatos.valido = txtValido_FE.Text
                        loDatos.compra = Integer.Parse(txtCompra_ND.Text.ToString)
                        loDatos.venta = Integer.Parse(txtVenta_ND.Text.ToString)
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Add()
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim loDatos As New Eb030cotizaciones
                        loDatos.codMoneda1 = txtCodMoneda1_AN.Text
                        loDatos.codMoneda2 = txtCodMoneda2_AN.Text
                        loDatos.valido = txtValido_FE.Text
                        If loDatos.GetPK = sOk_ Then
                            loDatos.codMoneda1 = txtCodMoneda1_AN.Text
                            loDatos.codMoneda2 = txtCodMoneda2_AN.Text
                            loDatos.valido = txtValido_FE.Text
                            loDatos.compra = Integer.Parse(txtCompra_ND.Text.ToString)
                            loDatos.venta = Integer.Parse(txtVenta_ND.Text.ToString)
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
                Me.AccessibleName = txtValido_FE.Text
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        Else
            If Me.Tag.ToString = sBORRAR_ Then
                Dim loDatos As New Eb030cotizaciones
                loDatos.codMoneda1 = txtCodMoneda1_AN.Text
                loDatos.codMoneda2 = txtCodMoneda2_AN.Text
                loDatos.valido = txtValido_FE.Text
                If loDatos.GetPK = sOk_ Then
                    loDatos.codMoneda1 = txtCodMoneda1_AN.Text
                    loDatos.codMoneda2 = txtCodMoneda2_AN.Text
                    loDatos.valido = txtValido_FE.Text
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
                    lsValorInicial = Today.ToString(sFormatoFecha1_)
                Case "compra"
                    lsValorInicial = "1"
                    e.Cancel = True
                Case "venta"
                    If txtCodMoneda1_AN.Text = txtCodMoneda2_AN.Text Then
                        lsValorInicial = txtCompra_ND.Text
                    End If
                    e.Cancel = True
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "valido"
                    If Not IsDate(txtValido_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtValido_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                        Exit Sub
                    End If
                    Dim ldFecha As Date = Date.Parse(txtValido_FE.Text.ToString)
                    txtValido_FE.Text = ldFecha.ToString("yyyy-MM-dd")

                    Dim loPk As New Eb030cotizaciones
                    loPk.codMoneda1 = txtCodMoneda1_AN.Text
                    loPk.codMoneda2 = txtCodMoneda2_AN.Text
                    loPk.valido = txtValido_FE.Text
                    If loPk.GetPK = sOk_ Then
                        GFsAvisar("Moneda A: [" & txtCodMoneda1_AN.Text & "] - De: [" & txtCodMoneda2_AN.Text & "] - Valido: [" & txtValido_FE.Text & "]", sMENSAJE_, "ya existe! Y no puede duplicarse.")
                        e.Cancel = True
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
        LPDespliegaDescripciones()
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls
        LPInicializaMaxLength()
        LPInicializaControles()
        ' Inicializa los controles de edición con los valores pertinentes
        msEntidad = "reg. cotizaciones"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                txtCodMoneda1_AN.Text = CType(entidad, Eb030cotizaciones).codMoneda1
                txtCodMoneda2_AN.Text = CType(entidad, Eb030cotizaciones).codMoneda2
                txtValido_FE.Text = Today.ToString(sFormatoFecha1_)
            Case Else
                txtCodMoneda1_AN.Text = CType(entidad, Eb030cotizaciones).codMoneda1
                txtCodMoneda2_AN.Text = CType(entidad, Eb030cotizaciones).codMoneda2
                txtValido_FE.Text = CType(entidad, Eb030cotizaciones).valido
                txtCompra_ND.Text = CType(entidad, Eb030cotizaciones).compra.ToString
                txtVenta_ND.Text = CType(entidad, Eb030cotizaciones).venta.ToString
                cmbEstado.Text = CType(entidad, Eb030cotizaciones).estado
        End Select
        ' Habilita o deshabilita los controles de edición
        txtCodMoneda1_AN.Enabled = True
        txtCodMoneda2_AN.Enabled = True
        txtValido_FE.Enabled = True
        txtCompra_ND.Enabled = True
        txtVenta_ND.Enabled = True
        cmbEstado.Enabled = True

        txtCodMoneda1_AN.AccessibleName = "codmoneda1"
        txtCodMoneda2_AN.AccessibleName = "codmoneda2"
        txtValido_FE.AccessibleName = "valido"
        txtCompra_ND.AccessibleName = "compra"
        txtVenta_ND.AccessibleName = "venta"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtCodMoneda1_AN.Enabled = False
                txtCodMoneda2_AN.Enabled = False

            Case sMODIFICAR_
                txtCodMoneda1_AN.Enabled = False
                txtCodMoneda2_AN.Enabled = False
                txtValido_FE.Enabled = False

            Case sCONSULTAR_, sBORRAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
                loControls = Me.TabPage2.Controls
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb|gbx", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
        End Select

    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtValido_FE.Focus()
            Case sMODIFICAR_
                txtCompra_ND.Focus()
        End Select
    End Sub

    Private Sub LPDespliegaDescripciones()
        lblNombreMoneda1.Text = ""
        If txtCodMoneda1_AN.Text.Trim.Length > 0 Then
            Dim loFK1 As New Ea010monedas
            loFK1.codMoneda = txtCodMoneda1_AN.Text
            If loFK1.GetPK = sOk_ Then
                lblNombreMoneda1.Text = loFK1.nombre
            End If
            loFK1.CerrarConexion()
            loFK1 = Nothing
        End If

        lblNombreMoneda2.Text = ""
        If txtCodMoneda2_AN.Text.Trim.Length > 0 Then
            Dim loFK1 As New Ea010monedas
            loFK1.codMoneda = txtCodMoneda2_AN.Text
            If loFK1.GetPK = sOk_ Then
                lblNombreMoneda2.Text = loFK1.nombre
            End If
            loFK1.CerrarConexion()
            loFK1 = Nothing
        End If
    End Sub

    Private Sub LPInicializaMaxLength()
        txtCodMoneda1_AN.MaxLength = 3
        txtCodMoneda2_AN.MaxLength = 3
        txtValido_FE.MaxLength = 10
        txtCompra_ND.MaxLength = 12
        txtVenta_ND.MaxLength = 12
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
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoRadioButton_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        AddHandler loControl1.Validating, AddressOf ManejoEvento_Validating
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