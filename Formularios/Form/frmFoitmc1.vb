Imports System.ComponentModel
Imports System.Globalization

Public Class frmFoitmc1
    Private msValidado As String = ""
    Private msRequeridos As String() = {"itemcode", "cardcode", "abogado", "inicialesabog", "fechademanda", "fechaordensecuestro", "fechasecuestro", "valortasacion", "fecharemate", "gastoventa", "precioventa", "estado"}
    Private moRequeridos As New ArrayList(msRequeridos)
    Private mdValorTasacion As Decimal = 0.00D
    Private mdGastoVenta As Decimal = 0.00D
    Private mdPrecioVenta As Decimal = 0.00D

    Public Property desStock As String

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
                txtCardCode_AN.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim loDatos As New Eoitmc1
                        loDatos.ItemCode = txtStock_AN.Text
                        loDatos.CardCode = txtCardCode_AN.Text
                        If txtAbogado_AN.Text <> sNOASIGNADO_ Then
                            loDatos.U_Abogado = txtAbogado_AN.Text
                            loDatos.U_InicialesAbog = txtInicialesAbog_AN.Text
                        End If
                        loDatos.FechaDemanda = txtFechaDemanda_FE.Text
                        loDatos.FechaOrdenSecuestro = txtFechaOrdenSecuestro_FE.Text
                        loDatos.FechaSecuestro = txtFechaSecuestro_FE.Text

                        If txtValorTasacion_ND.Text.Trim.Length = 0 Then
                            loDatos.ValorTasacion = 0.00D
                        Else
                            loDatos.ValorTasacion = CDec(Format(Decimal.Parse(txtValorTasacion_ND.Text), "0.00"))
                        End If

                        loDatos.FechaRemate = txtFechaRemate_FE.Text

                        If txtGastoVenta_ND.Text.Trim.Length = 0 Then
                            loDatos.GastoVenta = 0.00D
                        Else
                            loDatos.GastoVenta = CDec(Format(Decimal.Parse(txtGastoVenta_ND.Text), "0.00"))
                        End If
                        If txtPrecioVenta_ND.Text.Trim.Length = 0 Then
                            loDatos.PrecioVenta = 0.00D
                        Else
                            loDatos.PrecioVenta = CDec(Format(Decimal.Parse(txtPrecioVenta_ND.Text), "0.00"))
                        End If
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Add()
                        If loDatos.cancelado = sNo_ Then
                            If txtAbogado_AN.Text <> sNOASIGNADO_ Then
                                Dim lbModificado As Boolean = False
                                Dim moOCRD As New Eocrd
                                If moOCRD.GetPK(txtCardCode_AN.Text) Then
                                    If moOCRD.GetAtributo("U_Abogado") <> txtAbogado_AN.Text Then
                                        moOCRD.SetAtributo("U_Abogado", txtAbogado_AN.Text)
                                        lbModificado = True
                                    End If
                                    If moOCRD.GetAtributo("U_InicialesAbog") <> txtInicialesAbog_AN.Text Then
                                        moOCRD.SetAtributo("U_InicialesAbog", txtInicialesAbog_AN.Text)
                                        lbModificado = True
                                    End If
                                    If lbModificado Then moOCRD.Put()
                                End If
                                moOCRD.Desconectar()
                            End If
                        End If
                        loDatos.CerrarConexion()
                        loDatos = Nothing

                    Case sMODIFICAR_
                        Dim loDatos As New Eoitmc1
                        loDatos.ItemCode = txtStock_AN.Text
                        loDatos.CardCode = txtCardCode_AN.Text
                        If loDatos.GetPK = sOk_ Then
                            loDatos.ItemCode = txtStock_AN.Text
                            loDatos.CardCode = txtCardCode_AN.Text
                            If txtAbogado_AN.Text <> sNOASIGNADO_ Then
                                loDatos.U_Abogado = txtAbogado_AN.Text
                                loDatos.U_InicialesAbog = txtInicialesAbog_AN.Text
                            End If
                            loDatos.FechaDemanda = txtFechaDemanda_FE.Text
                            loDatos.FechaOrdenSecuestro = txtFechaOrdenSecuestro_FE.Text
                            loDatos.FechaSecuestro = txtFechaSecuestro_FE.Text

                            If txtValorTasacion_ND.Text.Trim.Length = 0 Then
                                loDatos.ValorTasacion = 0.00D
                            Else
                                loDatos.ValorTasacion = CDec(Format(Decimal.Parse(txtValorTasacion_ND.Text), "0.00"))
                            End If

                            loDatos.FechaRemate = txtFechaRemate_FE.Text

                            If txtGastoVenta_ND.Text.Trim.Length = 0 Then
                                loDatos.GastoVenta = 0.00D
                            Else
                                loDatos.GastoVenta = CDec(Format(Decimal.Parse(txtGastoVenta_ND.Text), "0.00"))
                            End If
                            If txtPrecioVenta_ND.Text.Trim.Length = 0 Then
                                loDatos.PrecioVenta = 0.00D
                            Else
                                loDatos.PrecioVenta = CDec(Format(Decimal.Parse(txtPrecioVenta_ND.Text), "0.00"))
                            End If
                            If cmbEstado.Text.Trim.Length > 0 Then
                                loDatos.estado = cmbEstado.Text
                            End If
                            loDatos.Put()
                            If loDatos.cancelado = sNo_ Then
                                If txtAbogado_AN.Text <> sNOASIGNADO_ Then
                                    Dim lbModificado As Boolean = False
                                    Dim moOCRD As New Eocrd
                                    If moOCRD.GetPK(txtCardCode_AN.Text) Then
                                        If moOCRD.GetAtributo("U_Abogado") <> txtAbogado_AN.Text Then
                                            moOCRD.SetAtributo("U_Abogado", txtAbogado_AN.Text)
                                            lbModificado = True
                                        End If
                                        If moOCRD.GetAtributo("U_InicialesAbog") <> txtInicialesAbog_AN.Text Then
                                            moOCRD.SetAtributo("U_InicialesAbog", txtInicialesAbog_AN.Text)
                                            lbModificado = True
                                        End If
                                        If lbModificado Then moOCRD.Put()
                                    End If
                                    moOCRD.Desconectar()
                                End If
                            End If
                        End If
                        loDatos.CerrarConexion()
                        loDatos = Nothing

                End Select
                Me.Tag = sOk_
                '-->  .AccesibleName envia al Browse la información del codigo que luego deberia 
                '-->  ser usado para la localización del registro en el DataGridView
                Me.AccessibleName = txtCardCode_AN.Text
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        Else
            If Me.Tag.ToString = sBORRAR_ Then
                Dim loDatos As New Eoitmc1
                loDatos.ItemCode = txtStock_AN.Text
                loDatos.CardCode = txtCardCode_AN.Text
                If loDatos.GetPK = sOk_ Then
                    loDatos.ItemCode = txtStock_AN.Text
                    loDatos.CardCode = txtCardCode_AN.Text
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
                Case "fechademanda"
                    lsValorInicial = Today.ToString("yyyy-MM-dd")
                Case "abogado"
                    lsValorInicial = sNOASIGNADO_
                Case "inicialesabog"
                    If txtAbogado_AN.Text.Trim <> sNOASIGNADO_ Then
                        Dim lsPartes() As String = txtAbogado_AN.Text.Split(" "c)
                        lsValorInicial = lsPartes(0).Substring(0, 1) & "." & lsPartes(1).Substring(0, 1)
                    End If
                Case "precioventa"
                    mdValorTasacion = Decimal.Parse(txtValorTasacion_ND.Text)
                    mdGastoVenta = Decimal.Parse(txtGastoVenta_ND.Text)
                    Dim ldPrecioVentaMinimo As Decimal = mdValorTasacion + mdGastoVenta
                    lsValorInicial = ldPrecioVentaMinimo.ToString
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "cardcode"
                    Dim loPk As New Eoitmc1
                    loPk.ItemCode = txtStock_AN.Text
                    loPk.CardCode = txtCardCode_AN.Text
                    If loPk.GetPK = sOk_ Then
                        GFsAvisar("Codigo de CLIENTE [" & txtCardCode_AN.Text & "], STOCK [" & txtStock_AN.Text & "] ", sMENSAJE_, "ya existe! Y no puede duplicarse.")
                        e.Cancel = True
                    End If
                    loPk = Nothing

                Case "abogado"
                    Dim lsPartes() As String = txtAbogado_AN.Text.Split(" "c)
                    txtInicialesAbog_AN.Text = lsPartes(0).Substring(0, 1) & "." & lsPartes(1).Substring(0, 1)

                Case "inicialesabog"
                    If txtInicialesAbog_AN.Text.Trim.Length = 0 Then
                        Dim lsPartes() As String = txtAbogado_AN.Text.Split(" "c)
                        txtInicialesAbog_AN.Text = lsPartes(0).Substring(0, 1) & "." & lsPartes(1).Substring(0, 1)
                        e.Cancel = True
                    End If

                Case "fechademanda"
                    If Not IsDate(txtFechaDemanda_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtFechaDemanda_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtFechaDemanda_FE.Text.ToString)
                        txtFechaDemanda_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                    If txtFechaDemanda_FE.Text > Today.ToString("yyyy-MM-dd") Then
                        GFsAvisar("Esta fecha no puede ser Diferida", sMENSAJE_, "reintentelo de nuevo")
                        txtFechaDemanda_FE.Text = Today.ToString("yyyy-MM-dd")
                        e.Cancel = True
                    End If

                Case "fechaordensecuestro"
                    If Not IsDate(txtFechaOrdenSecuestro_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtFechaOrdenSecuestro_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtFechaOrdenSecuestro_FE.Text.ToString)
                        txtFechaOrdenSecuestro_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                    If txtFechaOrdenSecuestro_FE.Text < txtFechaDemanda_FE.Text Then
                        GFsAvisar("Esta fecha no puede ser anterior a " & txtFechaDemanda_FE.Text, sMENSAJE_, "reintentelo de nuevo")
                        txtFechaOrdenSecuestro_FE.Text = txtFechaDemanda_FE.Text
                        e.Cancel = True
                    End If
                    If txtFechaOrdenSecuestro_FE.Text > Today.ToString("yyyy-MM-dd") Then
                        GFsAvisar("Esta fecha no puede ser Diferida", sMENSAJE_, "reintentelo de nuevo")
                        txtFechaOrdenSecuestro_FE.Text = Today.ToString("yyyy-MM-dd")
                        e.Cancel = True
                    End If

                Case "fechasecuestro"
                    If Not IsDate(txtFechaSecuestro_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtFechaSecuestro_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtFechaSecuestro_FE.Text.ToString)
                        txtFechaSecuestro_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                    If txtFechaSecuestro_FE.Text < txtFechaOrdenSecuestro_FE.Text Then
                        GFsAvisar("Esta fecha no puede ser anterior a " & txtFechaOrdenSecuestro_FE.Text, sMENSAJE_, "reintentelo de nuevo")
                        txtFechaSecuestro_FE.Text = txtFechaOrdenSecuestro_FE.Text
                        e.Cancel = True
                    End If
                    If txtFechaSecuestro_FE.Text > Today.ToString("yyyy-MM-dd") Then
                        GFsAvisar("Esta fecha no puede ser Diferida", sMENSAJE_, "reintentelo de nuevo")
                        txtFechaSecuestro_FE.Text = Today.ToString("yyyy-MM-dd")
                        e.Cancel = True
                    End If

                Case "fecharemate"
                    If Not IsDate(txtFechaRemate_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtFechaRemate_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtFechaRemate_FE.Text.ToString)
                        txtFechaRemate_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                    If txtFechaRemate_FE.Text < txtFechaSecuestro_FE.Text Then
                        GFsAvisar("Esta fecha no puede ser anterior a " & txtFechaSecuestro_FE.Text, sMENSAJE_, "reintentelo de nuevo")
                        txtFechaRemate_FE.Text = txtFechaSecuestro_FE.Text
                        e.Cancel = True
                    End If
                    If txtFechaRemate_FE.Text > Today.ToString("yyyy-MM-dd") Then
                        GFsAvisar("Esta fecha no puede ser Diferida", sMENSAJE_, "reintentelo de nuevo")
                        txtFechaRemate_FE.Text = Today.ToString("yyyy-MM-dd")
                        e.Cancel = True
                    End If

                Case "valortasacion"
                    mdValorTasacion = Decimal.Parse(txtValorTasacion_ND.Text)

                Case "gastoventa"
                    mdGastoVenta = Decimal.Parse(txtGastoVenta_ND.Text)

                Case "precioventa"
                    mdValorTasacion = Decimal.Parse(txtValorTasacion_ND.Text)
                    mdGastoVenta = Decimal.Parse(txtGastoVenta_ND.Text)
                    Dim ldPrecioVentaMinimo As Decimal = mdValorTasacion + mdGastoVenta
                    mdPrecioVenta = Decimal.Parse(txtPrecioVenta_ND.Text)
                    If mdPrecioVenta < ldPrecioVentaMinimo Then
                        GFsAvisar("Precio Venta no puede ser inferior a SUMA de Valor Tasacion y Gasto Venta [" & Format(ldPrecioVentaMinimo, "###,###,###.00") & "]", sMENSAJE_, "reintentelo de nuevo")
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

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls

        'Inicializa los controles de edición con los valores pertinentes
        msEntidad = "registro seguimiento juridico"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                txtStock_AN.Text = CType(entidad, Eoitmc1).ItemCode
                txtCardCode_AN.Text = CType(entidad, Eoitmc1).CardCode
                txtAbogado_AN.Text = CType(entidad, Eoitmc1).U_Abogado
                txtInicialesAbog_AN.Text = CType(entidad, Eoitmc1).U_InicialesAbog
                txtEmpresa_AN.Text = CType(entidad, Eoitmc1).Empresa
                txtSucursal_AN.Text = CType(entidad, Eoitmc1).Sucursal
                txtPeriodoFac_FE.Text = CType(entidad, Eoitmc1).PeriodoFac
                txtAbogado_AN.Enabled = True
                txtInicialesAbog_AN.Enabled = True
                txtVentaUSD_ND.Text = CType(entidad, Eoitmc1).VentaUSD.ToString("0.00")
                txtSaldoUSD_ND.Text = CType(entidad, Eoitmc1).SaldoUSD.ToString("0.00")
                txtPagosUSD_ND.Text = CType(entidad, Eoitmc1).PagosUSD.ToString("0.00")
            Case Else
                Dim loDatos As New Eoitmc1
                loDatos.ItemCode = CType(entidad, Eoitmc1).ItemCode
                loDatos.CardCode = CType(entidad, Eoitmc1).CardCode
                If loDatos.GetPK() = sOk_ Then
                    txtStock_AN.Text = loDatos.ItemCode
                    txtCardCode_AN.Text = loDatos.CardCode
                    txtAbogado_AN.Text = CType(entidad, Eoitmc1).U_Abogado
                    txtInicialesAbog_AN.Text = CType(entidad, Eoitmc1).U_InicialesAbog
                    txtEmpresa_AN.Text = CType(entidad, Eoitmc1).Empresa
                    txtSucursal_AN.Text = CType(entidad, Eoitmc1).Sucursal
                    txtPeriodoFac_FE.Text = CType(entidad, Eoitmc1).PeriodoFac
                    txtAbogado_AN.Enabled = True
                    txtInicialesAbog_AN.Enabled = True
                    txtVentaUSD_ND.Text = CType(entidad, Eoitmc1).VentaUSD.ToString("0.00")
                    txtSaldoUSD_ND.Text = CType(entidad, Eoitmc1).SaldoUSD.ToString("0.00")
                    txtPagosUSD_ND.Text = CType(entidad, Eoitmc1).PagosUSD.ToString("0.00")
                    txtFechaDemanda_FE.Text = loDatos.FechaDemanda
                    txtFechaOrdenSecuestro_FE.Text = loDatos.FechaOrdenSecuestro
                    txtFechaSecuestro_FE.Text = loDatos.FechaSecuestro
                    txtValorTasacion_ND.Text = loDatos.ValorTasacion.ToString("0.00")
                    txtFechaRemate_FE.Text = loDatos.FechaRemate
                    txtGastoVenta_ND.Text = loDatos.GastoVenta.ToString("0.00")
                    txtPrecioVenta_ND.Text = loDatos.PrecioVenta.ToString("0.00")
                    cmbEstado.Text = loDatos.estado
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
        End Select
        ' Habilita o deshabilita los controles de edición
        txtCardCode_AN.Enabled = False
        txtStock_AN.Enabled = False
        txtNombreCliente_AN.Enabled = False
        txtEmpresa_AN.Enabled = False
        txtSucursal_AN.Enabled = False
        txtMarcaModelo_AN.Enabled = False
        txtPeriodoFac_FE.Enabled = False
        txtVentaUSD_ND.Enabled = False
        txtPagosUSD_ND.Enabled = False
        txtSaldoUSD_ND.Enabled = False
        txtFechaDemanda_FE.Enabled = True
        txtFechaOrdenSecuestro_FE.Enabled = True
        txtFechaSecuestro_FE.Enabled = True
        txtValorTasacion_ND.Enabled = True
        txtFechaRemate_FE.Enabled = True
        txtGastoVenta_ND.Enabled = True
        txtPrecioVenta_ND.Enabled = True
        cmbEstado.Enabled = True

        txtCardCode_AN.AccessibleName = "itemcode"
        txtNombreCliente_AN.AccessibleName = "nombrecliente"
        txtEmpresa_AN.AccessibleName = "empresa"
        txtAbogado_AN.AccessibleName = "abogado"
        txtInicialesAbog_AN.AccessibleName = "inicialesabog"
        txtSucursal_AN.AccessibleName = "sucursal"
        txtMarcaModelo_AN.AccessibleName = "marcamodelo"
        txtPeriodoFac_FE.AccessibleName = "fechaventa"
        txtVentaUSD_ND.AccessibleName = "montoventa"
        txtPagosUSD_ND.AccessibleName = "montopagado"
        txtSaldoUSD_ND.AccessibleName = "deuda"
        txtFechaDemanda_FE.AccessibleName = "fechademanda"
        txtFechaOrdenSecuestro_FE.AccessibleName = "fechaordensecuestro"
        txtFechaSecuestro_FE.AccessibleName = "fechasecuestro"
        txtValorTasacion_ND.AccessibleName = "valortasacion"
        txtFechaRemate_FE.AccessibleName = "fecharemate"
        txtGastoVenta_ND.AccessibleName = "gastoventa"
        txtPrecioVenta_ND.AccessibleName = "precioventa"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtCardCode_AN.Enabled = False
                txtStock_AN.Enabled = False

            Case sMODIFICAR_
                txtStock_AN.Enabled = False
                txtCardCode_AN.Enabled = False

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
                loControls = Me.TabPage3.Controls
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
        End Select
        LPDespliegaDescripciones()
    End Sub

    Private Sub LPDespliegaDescripciones()
        txtMarcaModelo_AN.Text = desStock

        Dim loOCRD As New Eocrd
        If loOCRD.GetPK(txtCardCode_AN.Text) Then
            txtNombreCliente_AN.Text = loOCRD.GetAtributo("CardName")
        End If
        loOCRD.Desconectar()

        If txtPrecioVenta_ND.Text.Trim.Length > 0 Then
            Dim ldPrecioVenta As Decimal = Decimal.Parse(txtPrecioVenta_ND.Text)
            Dim ldValorTasacion As Decimal = Decimal.Parse(txtValorTasacion_ND.Text)
            Dim ldGastoVenta As Decimal = Decimal.Parse(txtGastoVenta_ND.Text)
            Dim ldDiferencia As Decimal = 0
            ldDiferencia = ldPrecioVenta - (ldValorTasacion + ldGastoVenta)
            lblMensajeError.Text = ""
            lblVT.Text = ""
            lblGV.Text = ""
            If ldDiferencia < 0 Then
                lblMensajeError.Text = "[" & ldPrecioVenta.ToString("0.00") & "] inferior [VT + GV] = " & ldDiferencia.ToString("0.00")
                lblVT.Text = "VT"
                lblGV.Text = "GV"
            End If
        End If
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtCardCode_AN.Focus()
        End Select

    End Sub

    Private Sub LPInicializaMaxLength()
        txtCardCode_AN.MaxLength = 15
        txtNombreCliente_AN.MaxLength = 50
        txtEmpresa_AN.MaxLength = 30
        txtAbogado_AN.MaxLength = 30
        txtInicialesAbog_AN.MaxLength = 4
        txtSucursal_AN.MaxLength = 50
        txtMarcaModelo_AN.MaxLength = 50
        txtPeriodoFac_FE.MaxLength = 10
        txtVentaUSD_ND.MaxLength = 15
        txtPagosUSD_ND.MaxLength = 15
        txtSaldoUSD_ND.MaxLength = 15
        txtFechaDemanda_FE.MaxLength = 10
        txtFechaOrdenSecuestro_FE.MaxLength = 10
        txtFechaSecuestro_FE.MaxLength = 10
        txtValorTasacion_ND.MaxLength = 15
        txtFechaRemate_FE.MaxLength = 10
        txtGastoVenta_ND.MaxLength = 15
        txtPrecioVenta_ND.MaxLength = 15
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
                            AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
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