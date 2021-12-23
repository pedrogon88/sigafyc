Imports System.ComponentModel
Imports System.Globalization
Imports System.Data.Common

Public Class frmBMayorCuenta
    Private moFormulario As frmFd010asientosdetalles

    Private msTabla As String = ""
    Private msPk_Hash As String = ""

    Private msValidado As String = ""
    Private msRequeridos As String() = {"codempresa", "codsucursal", "cuenta1", "cuenta2", "cuenta3", "cuenta4", "cuenta5", "cuenta6", "fecha1", "fecha2"}
    Private moRequeridos As New ArrayList(msRequeridos)
    Private miCodEmpresa As Integer = 0
    Private miCodSucursal As Integer = 0
    Private msCodCuenta As String = ""
    Private msFechaHasta As String = ""
    Private msFechaDesde As String = ""
    Private miCuenta1 As Integer = 0
    Private miCuenta2 As Integer = 0
    Private miCuenta3 As Integer = 0
    Private miCuenta4 As Integer = 0
    Private miCuenta5 As Integer = 0
    Private miCuenta6 As Integer = 0
    Private msNivel As String = ""
    Private msDecimales_b As String = ""
    Private msCulture_b As String = ""
    Private mdSaldoInicial As Decimal = 0.00D
    Private mdSaldoFinal As Decimal = 0.00D
    Private mdTotDebito As Decimal = 0.00D
    Private mdTotCredito As Decimal = 0.00D
    Private msLocalizar As String = ""
    Private mbEntro As Boolean = True
    Private mbConsultar As Boolean
    Private mbImprimir As Boolean = False
    Private mbAuditoria As Boolean

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
            txtCodEmpresa_NE.Text = miCodEmpresa.ToString
        End Set
    End Property

    Public Property codSucursal As Integer
        Get
            Return miCodSucursal
        End Get
        Set(value As Integer)
            miCodSucursal = value
            txtCodSucursal_NE.Text = miCodSucursal.ToString
        End Set
    End Property

    Public Property codCuenta As String
        Get
            Return msCodCuenta
        End Get
        Set(value As String)
            msCodCuenta = value
            txtCodCuenta.Text = msCodCuenta
            LPParseaPartesCuenta()
        End Set
    End Property

    Public Property fechaHasta As String
        Get
            Return msFechaHasta
        End Get
        Set(value As String)
            msFechaHasta = value
            Dim ldFecha As Date = Date.Parse(msFechaHasta)
            msFechaDesde = ldFecha.ToString("yyyy-MM") & "-01"
            msFechaHasta = ldFecha.ToString("yyyy-MM-dd")
            txtFecha1_FE.Text = msFechaDesde
            txtFecha2_FE.Text = msFechaHasta
        End Set
    End Property

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView1.AllowUserToResizeColumns = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.ReadOnly = True
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        LPSetDoubleBuffered(DataGridView1)

        LPInicializaMaxLength()
        LPInicializaControles()

        AddHandler txtBuscar.TextChanged, AddressOf BuscarClave
        AddHandler DataGridView1.KeyDown, AddressOf DataGrid_KeyDown
        AddHandler DataGridView1.CellContentDoubleClick, AddressOf DataGrid_DoubleClick

        DataGridView1.ContextMenuStrip = mnuExportarExcel

        AddHandler MenuItem_ExportarExcel.Click, AddressOf ExportarExcel_Click
        AddHandler MenuItem_ExportarTexto.Click, AddressOf ExportarTexto_Click

        mbConsultar = btnConsultar.Enabled
        mbImprimir = btnImprimir.Enabled
        mbAuditoria = btnAuditoria.Enabled

        btnAgregar.Visible = False
        btnModificar.Visible = False
        btnBorrar.Visible = False
        btnConsultar.Visible = True
        btnConsultar.Location = New Point(btnConsultar.Location.X, DataGridView1.Location.Y)
        btnImprimir.Location = New Point(btnConsultar.Location.X, btnConsultar.Location.Y + btnConsultar.Height + 5)

        lblNombreEmpresa.Text = ""
        lblNombreEmpresa.ForeColor = Color.DarkOliveGreen
        lblNombreSucursal.Text = ""
        lblNombreSucursal.ForeColor = Color.DarkOliveGreen
        lblNombreCuenta.Text = ""
        lblNombreCuenta.ForeColor = Color.DarkOliveGreen
        lblSaldoAnterior.Text = ""
        lblSaldoFinal.Text = ""

        txtCodEmpresa_NE.AccessibleName = "codempresa"
        txtCodSucursal_NE.AccessibleName = "codsucursal"
        txtCodCuenta.AccessibleName = "codcuenta"
        txtCuenta1_NE.AccessibleName = "cuenta1"
        txtCuenta2_NE.AccessibleName = "cuenta2"
        txtCuenta3_NE.AccessibleName = "cuenta3"
        txtCuenta4_NE.AccessibleName = "cuenta4"
        txtCuenta5_NE.AccessibleName = "cuenta5"
        txtCuenta6_NE.AccessibleName = "cuenta6"
        txtFecha1_FE.AccessibleName = "fecha1"
        txtFecha2_FE.AccessibleName = "fecha2"
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub LPCargarDatos()
        If txtCodEmpresa_NE.Text.Trim.Length = 0 Then Exit Sub
        If txtFecha1_FE.Text.Trim.Length = 0 Then Exit Sub
        If txtFecha2_FE.Text.Trim.Length = 0 Then Exit Sub

        Dim lsSQL As String = GFsGeneraSQL("frmBMayorCuentaDetalle")
        Dim loDatos As New Ed010asientosdetalles
        Dim loDataSet As DataSet
        Dim lsCamposConcat As String = "e010.fecha, d010.nroasiento, c020.abreviado, e010.nrodocumento, e010.codmoneda_o, d010.concepto"
        Dim lsConcatFiltro As String = lsCamposConcat
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        loDatos.codCuenta = txtCodCuenta.Text

        Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text)
        If liCodSucursal = 0 Then
            lsSQL = lsSQL.Replace("@Sucursal", "")
            lsSQL = lsSQL.Replace("@colsucursal", "e010.codsucursal as sucursal,")
        Else
            lsSQL = lsSQL.Replace("@Sucursal", "AND e010.codsucursal = " & liCodSucursal)
            lsSQL = lsSQL.Replace("@colsucursal", "")
        End If
        lsSQL = lsSQL.Replace("@filtro", lsFiltro)
        lsSQL = lsSQL.Replace("@fecha1", txtFecha1_FE.Text)
        lsSQL = lsSQL.Replace("@fecha2", txtFecha2_FE.Text)

        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView1.DataSource = loDataSet
        DataGridView1.DataMember = loDatos.tableName

        DataGridView1.Columns.Item("cotizacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Columns.Item("cotizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DataGridView1.Columns.Item("debito").HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Columns.Item("credito").HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight

        DataGridView1.Columns.Item("debito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns.Item("credito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        DataGridView1.Columns.Item("debito_o").HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight
        DataGridView1.Columns.Item("credito_o").HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight

        DataGridView1.Columns.Item("debito_o").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns.Item("credito_o").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        DataGridView1.Columns.Item("codempresa").Visible = False
        DataGridView1.Columns.Item("codcuenta").Visible = False
        DataGridView1.Columns.Item("decimales_o").Visible = False
        DataGridView1.Columns.Item("culture_o").Visible = False
        DataGridView1.Sort(DataGridView1.Columns("fecha"), ListSortDirection.Ascending)
        If msLocalizar IsNot Nothing Then LPLocalizaRegistro(msLocalizar)

        msTabla = loDatos.tableName
        miCantidad = loDataSet.Tables.Item(0).Rows.Count
        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
        LPTotalesSaldoFinal(lsSQL, {"debito", "credito"})
        LPHabilitaControles2()
    End Sub

    Private Sub LPTotalesSaldoFinal(ByVal psSQL As String, ByVal poCamposTotales() As String)
        Dim lsSQL As String = "SELECT" & ControlChars.CrLf

        For I As Integer = 0 To poCamposTotales.Length - 1
            If I = 0 Then
                lsSQL &= "  sum(x." & poCamposTotales(I) & ") as " & poCamposTotales(I)
            Else
                lsSQL &= "," & ControlChars.CrLf & "  sum(x." & poCamposTotales(I) & ") as " & poCamposTotales(I)
            End If
        Next

        lsSQL &= ControlChars.CrLf & "FROM" &
                ControlChars.CrLf & "(" & ControlChars.CrLf &
                psSQL & ControlChars.CrLf &
                ") x" & ControlChars.CrLf

        Dim loDatos As New Ed010asientosdetalles
        loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)

        loDatos.codCuenta = txtCodCuenta.Text
        Dim loDReader As DbDataReader = loDatos.RecuperarConsulta(lsSQL)

        If loDReader IsNot Nothing Then
            If loDReader.Read Then
                mdTotDebito = 0
                If loDReader(poCamposTotales(0)) IsNot DBNull.Value Then
                    mdTotDebito = Decimal.Parse(loDReader(poCamposTotales(0)).ToString)
                End If
                mdTotCredito = 0
                If loDReader(poCamposTotales(1)) IsNot DBNull.Value Then
                    mdTotCredito = Decimal.Parse(loDReader(poCamposTotales(1)).ToString)
                End If
            End If
        End If

        lblTotalDebitos.Text = mdTotDebito.ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
        lblTotalCreditos.Text = mdTotCredito.ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))


        mdSaldoFinal = mdSaldoInicial + (mdTotDebito - mdTotCredito)
        If mdSaldoFinal > 0 Then
            lblSaldoFinal.Text = "Saldo final DEUDOR -->" & mdSaldoFinal.ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
            lblSaldoFinal.ForeColor = Color.MidnightBlue
        Else
            If mdSaldoFinal < 0 Then
                Dim ldSaldoFinal As Decimal = mdSaldoFinal * -1
                lblSaldoFinal.Text = "Saldo final ACREEDOR -->" & ldSaldoFinal.ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
                lblSaldoFinal.ForeColor = Color.DarkRed
            Else
                lblSaldoFinal.Text = "Saldo final es ***CERO***"
                lblSaldoFinal.ForeColor = Color.DarkOliveGreen
            End If
        End If
    End Sub

    Private Sub LPCalculaSaldoAnterior()
        If txtCodEmpresa_NE.Text.Trim.Length = 0 Then Exit Sub
        If txtCodCuenta.Text.Trim = "0.00.000.0000.00000.000000" Then Exit Sub
        If txtFecha1_FE.Text.Trim.Length = 0 Then Exit Sub
        If txtFecha2_FE.Text.Trim.Length = 0 Then Exit Sub

        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim lsCodCuenta As String = txtCodCuenta.Text
        Dim ldFecha As Date = Date.Parse(txtFecha1_FE.Text.ToString)
        ldFecha = ldFecha.AddDays(-1)
        Dim ldSaldo As Decimal = GFdCuentaSaldoObtener(liCodEmpresa, lsCodCuenta, 0, ldFecha.ToString("yyyy-MM-dd"))
        Dim loC001 As New Ec001empresas
        loC001.codEmpresa = liCodEmpresa
        If loC001.GetPK = sOk_ Then
            Dim loA010 As New Ea010monedas
            loA010.codMoneda = loC001.codMoneda
            If loA010.GetPK = sOk_ Then
                msDecimales_b = loA010.decimales.ToString
                msCulture_b = loA010.culture
            End If
        End If

        lblSaldoAnterior.Text = ""
        mdSaldoInicial = ldSaldo
        If ldSaldo > 0 Then
            lblSaldoAnterior.Text = "Saldo anterior DEUDOR --> " & ldSaldo.ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
            lblSaldoAnterior.ForeColor = Color.MidnightBlue
        Else
            If ldSaldo < 0 Then
                ldSaldo = ldSaldo * -1
                lblSaldoAnterior.Text = "Saldo anterior ACREEDOR --> " & ldSaldo.ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
                lblSaldoAnterior.ForeColor = Color.DarkRed
            End If
        End If
    End Sub

    Private Sub LPInicializaMaxLength()
        txtCodEmpresa_NE.MaxLength = 6
        txtCodSucursal_NE.MaxLength = 3
        txtCodCuenta.MaxLength = 26
        txtCuenta1_NE.MaxLength = sCero1_.Trim.Length
        txtCuenta2_NE.MaxLength = sCero2_.Trim.Length
        txtCuenta3_NE.MaxLength = sCero3_.Trim.Length
        txtCuenta4_NE.MaxLength = sCero4_.Trim.Length
        txtCuenta5_NE.MaxLength = sCero5_.Trim.Length
        txtCuenta6_NE.MaxLength = sCero6_.Trim.Length
        txtFecha1_FE.MaxLength = 10
        txtFecha2_FE.MaxLength = 10
    End Sub

    Private Sub LPDespliegaDescripciones()
        Dim liCodEmpresa As Integer = 0
        Dim liCodSucursal As Integer = 0
        Dim lsCodCuenta As String = ""

        lblNombreEmpresa.Text = ""
        If txtCodEmpresa_NE.Text.Trim.Length > 0 Then
            Dim loFK As New Ec001empresas
            liCodEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
            loFK.codEmpresa = liCodEmpresa
            If loFK.GetPK = sOk_ Then
                lblNombreEmpresa.Text = loFK.nombre
                Dim loFK1 As New Ea010monedas
                loFK1.codMoneda = loFK.codMoneda
                If loFK1.GetPK = sOk_ Then
                    msDecimales_b = loFK1.decimales.ToString
                    msCulture_b = loFK1.culture
                End If
            End If
            loFK.CerrarConexion()
            loFK = Nothing
            txtCodEmpresa_NE.Text = liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength)
        End If

        lblNombreSucursal.Text = ""
        If txtCodEmpresa_NE.Text.Trim.Length > 0 Then
            If txtCodSucursal_NE.Text.Trim.Length > 0 Then
                If Not IsNumeric(txtCodSucursal_NE.Text) Then Exit Sub
                liCodSucursal = Integer.Parse(txtCodSucursal_NE.Text.ToString)

                If liCodSucursal = 0 Then
                    lblNombreSucursal.Text = "TODAS LAS SUCURSALES"
                Else
                    Dim loFK As New Eb070sucursales
                    loFK.codEmpresa = liCodEmpresa
                    loFK.codSucursal = liCodSucursal
                    If loFK.GetPK = sOk_ Then
                        lblNombreSucursal.Text = loFK.nombre
                    End If
                    loFK.CerrarConexion()
                    loFK = Nothing
                End If
            End If
            txtCodSucursal_NE.Text = liCodSucursal.ToString(sFormatD_ & txtCodSucursal_NE.MaxLength)
        End If

        lblNombreCuenta.Text = ""
        If txtCodCuenta.Text.Trim.Length > 0 Then
            Dim loFK1 As New Eb050plancuentas
            liCodEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
            lsCodCuenta = txtCodCuenta.Text.ToString
            loFK1.codEmpresa = liCodEmpresa
            loFK1.codCuenta = lsCodCuenta
            If loFK1.GetPK = sOk_ Then
                lblNombreCuenta.Text = loFK1.nombre
            End If
            loFK1.CerrarConexion()
            loFK1 = Nothing
        End If
    End Sub

    Private Sub ManejoEvento_Validating(sender As Object, e As CancelEventArgs)
        If CType(sender, Control).Text.Trim.Length = 0 Then
            If LFsExiste(CType(sender, Control).AccessibleName) = sNo_ Then Exit Sub
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).AccessibleName
            End Select
            CType(sender, Control).Text = lsValorInicial
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoTextBox_ Then
                Dim liLongitud As Integer = CType(sender, TextBox).Text.Length
                If liLongitud > 0 Then
                    CType(sender, TextBox).SelectionStart = CType(sender, TextBox).Text.Length - 1
                End If
            End If
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
            Exit Sub
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "cuenta1"
                    msNivel = "1"
                    If IsNumeric(txtCuenta1_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 1 - debe ser numerico", sMENSAJE_, "Valores de 1 - 7:" & ControlChars.CrLf & "1-Activo" & ControlChars.CrLf & "2-Pasivo" & ControlChars.CrLf & "3-Patrimonio neto" & ControlChars.CrLf & "4-Cuentas orden activas" & ControlChars.CrLf & "5-Cuentas orden pasivas" & ControlChars.CrLf & "6-Ingresos" & ControlChars.CrLf & "7-Egresos")
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta1 = Integer.Parse(txtCuenta1_NE.Text.ToString)
                    If Not (miCuenta1 >= 1 And miCuenta1 <= 7) Then
                        GFsAvisar("Codigo Nivel 1 - no valido", sMENSAJE_, "Valores de 1 - 7:" & ControlChars.CrLf & "1-Activo" & ControlChars.CrLf & "2-Pasivo" & ControlChars.CrLf & "3-Patrimonio neto" & ControlChars.CrLf & "4-Cuentas orden activas" & ControlChars.CrLf & "5-Cuentas orden pasivas" & ControlChars.CrLf & "6-Ingresos" & ControlChars.CrLf & "7-Egresos")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta1_NE.Text.ToString)
                        txtCuenta1_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta2"
                    msNivel = "2"
                    If IsNumeric(txtCuenta2_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 2 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta2 = Integer.Parse(txtCuenta2_NE.Text.ToString)
                    If Not (miCuenta2 >= 1 And miCuenta2 <= 99) Then
                        GFsAvisar("Codigo Nivel 2 - no valido", sMENSAJE_, "Valores de 1 - 99")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta2_NE.Text.ToString)
                        txtCuenta2_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta3"
                    msNivel = "3"
                    If IsNumeric(txtCuenta3_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 3 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta3 = Integer.Parse(txtCuenta3_NE.Text.ToString)
                    If Not (miCuenta3 >= 1 And miCuenta3 <= 999) Then
                        GFsAvisar("Codigo Nivel 3 - no valido", sMENSAJE_, "Valores de 1 - 999")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta3_NE.Text.ToString)
                        txtCuenta3_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta4"
                    msNivel = "4"
                    If IsNumeric(txtCuenta4_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 4 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta4 = Integer.Parse(txtCuenta4_NE.Text.ToString)
                    If Not (miCuenta4 >= 1 And miCuenta4 <= 9999) Then
                        GFsAvisar("Codigo Nivel 4 - no valido", sMENSAJE_, "Valores de 1 - 9999")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta4_NE.Text.ToString)
                        txtCuenta4_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & txtCuenta4_NE.Text & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta5"
                    msNivel = "5"
                    If IsNumeric(txtCuenta5_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 5 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta5 = Integer.Parse(txtCuenta5_NE.Text.ToString)
                    If Not (miCuenta5 >= 1 And miCuenta5 <= 99999) Then
                        GFsAvisar("Codigo Nivel 5 - no valido", sMENSAJE_, "Valores de 1 - 99999")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta5_NE.Text.ToString)
                        txtCuenta5_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & txtCuenta4_NE.Text & sSeparador_ & txtCuenta5_NE.Text & sSeparador_ & sCero6_
                Case "cuenta6"
                    msNivel = "6"
                    If IsNumeric(txtCuenta6_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 6 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta6 = Integer.Parse(txtCuenta6_NE.Text.ToString)
                    If Not (miCuenta6 >= 1 And miCuenta6 <= 999999) Then
                        GFsAvisar("Codigo Nivel 6 - no valido", sMENSAJE_, "Valores de 1 - 999999")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta6_NE.Text.ToString)
                        txtCuenta6_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & txtCuenta4_NE.Text & sSeparador_ & txtCuenta5_NE.Text & sSeparador_ & txtCuenta6_NE.Text
            End Select
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoComboBox_ Then
                If CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) = False Then
                    e.Cancel = True
                    CType(sender, Control).Tag = sCancelar_
                End If
            End If
            Dim lsTipoCuenta As String = ""
            If InStr(CType(sender, Control).AccessibleName, "cuenta") > 0 Then
                Dim loFK1 As New Eb050plancuentas
                Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                loFK1.codEmpresa = liCodEmpresa
                loFK1.codCuenta = txtCodCuenta.Text
                If loFK1.GetPK = sOk_ Then
                    lsTipoCuenta = loFK1.tipo
                    If loFK1.tipo = sImputable_.Substring(0, 1) Then
                        LPOcultaNivelesInferior(loFK1.nivel)
                        txtFecha1_FE.Focus()
                    End If
                Else
                    Dim loLookUp As New frmBb050plancuentas
                    loLookUp.Tag = sELEGIR_
                    GPCargar(loLookUp)
                    If loLookUp.entidad IsNot Nothing Then
                        txtCodCuenta.Text = CType(loLookUp.entidad, Eb050plancuentas).codCuenta
                        LPParseaPartesCuenta()
                        LPOcultaNivelesInferior(CType(loLookUp.entidad, Eb050plancuentas).nivel)
                        lsTipoCuenta = CType(loLookUp.entidad, Eb050plancuentas).tipo
                        If lsTipoCuenta = sTotales_.Substring(0, 1) Then
                            CType(sender, Control).Tag = sCancelar_
                            GFsAvisar("La Cuenta [" & txtCodCuenta.Text & "] no es IMPUTABLE", sMENSAJE_, "Los movimientos contable no puede realizarse con cuentas de TOTALES.")
                            e.Cancel = True
                        End If
                    End If
                    loLookUp = Nothing
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

    Private Sub btnAuditoria_Click(sender As Object, e As EventArgs) Handles btnAuditoria.Click
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim lsCodigo As String = DataGridView1.Item("orden", DataGridView1.CurrentRow.Index).Value.ToString
        If lsCodigo.Trim.Length = 0 Then Exit Sub

        Dim lsTablaHash() As String = LFsTablaHashPk(lsCodigo).Split(sSF_)
        GPDespliegaBitacoraDatos(lsTablaHash(0), lsTablaHash(1))
    End Sub

    Private Function LFsTablaHashPk(ByVal psCodigo As String) As String
        Dim lsResultado As String = ""

        If txtCodEmpresa_NE.Text.Trim.Length > 0 Then
            If IsNumeric(txtCodEmpresa_NE.Text) Then
                If psCodigo.Trim.Length > 0 Then
                    If IsNumeric(psCodigo) Then
                        Dim loDatos As New Ed010asientosdetalles
                        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.Trim.ToString)
                        Dim liNroAsiento As Integer = Integer.Parse(DataGridView1.Item("asiento", DataGridView1.CurrentRow.Index).Value.ToString)
                        Dim liNroSecuencia As Integer = Integer.Parse(psCodigo)
                        loDatos.codEmpresa = liCodEmpresa
                        loDatos.nroAsiento = liNroAsiento
                        loDatos.nroSecuencia = liNroSecuencia
                        Try
                            If loDatos.GetPK(sSi_) = sOk_ Then
                                lsResultado = loDatos.tableName & sSF_ & loDatos.hash_Pk
                            End If
                        Catch ex As Exception
                            GFsAvisar("LFsTablaHashPk", sError_, ex.Message)
                        End Try
                    End If
                End If
            End If
        End If
        Return lsResultado
    End Function

    Private Sub ExportarExcel_Click(sender As Object, e As EventArgs)
        If GFsPuedeUsar(Me.Name & ":Exportar->Excel", "Permite exportar el contenido de " & Me.Name & " a un archivo Excel") = sSi_ Then
            GPExportarGridToExcel(DataGridView1, Me.Name)
        End If
    End Sub

    Private Sub ExportarTexto_Click(sender As Object, e As EventArgs)
        If GFsPuedeUsar(Me.Name & ":Exportar->Texto delimitado", "Permite exportar el contenido de " & Me.Name & " a un archivo de texto delimitado") = sSi_ Then
            GPExportarGridToTexto(DataGridView1, Me.Name)
        End If
    End Sub

    Private Sub LPOcultaNivelesInferior(ByVal psNivel As String)
        txtCuenta1_NE.Visible = True
        txtCuenta2_NE.Visible = True
        txtCuenta3_NE.Visible = True
        txtCuenta4_NE.Visible = True
        txtCuenta5_NE.Visible = True
        txtCuenta6_NE.Visible = True
        Select Case psNivel
            Case "2"
                txtCuenta3_NE.Visible = False
                txtCuenta4_NE.Visible = False
                txtCuenta5_NE.Visible = False
                txtCuenta6_NE.Visible = False
                txtCuenta3_NE.Tag = sOk_
                txtCuenta4_NE.Tag = sOk_
                txtCuenta5_NE.Tag = sOk_
                txtCuenta6_NE.Tag = sOk_
            Case "3"
                txtCuenta4_NE.Visible = False
                txtCuenta5_NE.Visible = False
                txtCuenta6_NE.Visible = False
                txtCuenta4_NE.Tag = sOk_
                txtCuenta5_NE.Tag = sOk_
                txtCuenta6_NE.Tag = sOk_
            Case "4"
                txtCuenta5_NE.Visible = False
                txtCuenta6_NE.Visible = False
                txtCuenta5_NE.Tag = sOk_
                txtCuenta6_NE.Tag = sOk_
            Case "5"
                txtCuenta6_NE.Visible = False
                txtCuenta6_NE.Tag = sOk_
        End Select
        txtCodCuenta.Visible = False
        txtCodCuenta.Tag = sOk_
    End Sub

    Private Sub LPParseaPartesCuenta()
        txtCuenta1_NE.Text = txtCodCuenta.Text.Substring(0, sCero1_.Length)
        txtCuenta2_NE.Text = txtCodCuenta.Text.Substring(2, sCero2_.Length)
        txtCuenta3_NE.Text = txtCodCuenta.Text.Substring(5, sCero3_.Length)
        txtCuenta4_NE.Text = txtCodCuenta.Text.Substring(9, sCero4_.Length)
        txtCuenta5_NE.Text = txtCodCuenta.Text.Substring(14, sCero5_.Length)
        txtCuenta6_NE.Text = txtCodCuenta.Text.Substring(20, sCero6_.Length)
    End Sub

    Private Sub LPInicializaControles()
        For Each loControl As Control In Me.Controls
            If loControl.Name <> "txtBuscar" Then
                Select Case loControl.Name.Substring(0, 3)
                    Case sPrefijoTextBox_
                        AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                        AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                        If loControl.Name.Substring(3, 6) = "Cuenta" Then
                            loControl.Tag = sCancelar_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                        End If
                End Select
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

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Dim loRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim loColCotizacion As DataGridViewColumn = DataGridView1.Columns.Item("cotizacion")
        Dim loColDebito_o As DataGridViewColumn = DataGridView1.Columns.Item("debito_o")
        Dim loColCredito_o As DataGridViewColumn = DataGridView1.Columns.Item("credito_o")
        Dim loColDebito_b As DataGridViewColumn = DataGridView1.Columns.Item("debito")
        Dim loColCredito_b As DataGridViewColumn = DataGridView1.Columns.Item("credito")
        Dim lsCodMoneda As String = DataGridView1.Item("moneda", e.RowIndex).Value.ToString
        Dim lsDecimales_o As String = DataGridView1.Item("decimales_o", e.RowIndex).Value.ToString
        Dim lsCulture_o As String = DataGridView1.Item("culture_o", e.RowIndex).Value.ToString

        If e.ColumnIndex = loColDebito_o.Index Then
            If Decimal.Parse(e.Value.ToString) = 0 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString(sFormatC_ & lsDecimales_o, CultureInfo.CreateSpecificCulture(lsCulture_o))
            End If
            e.FormattingApplied = True
        End If
        If e.ColumnIndex = loColCredito_o.Index Then
            If Decimal.Parse(e.Value.ToString) = 0 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString(sFormatC_ & lsDecimales_o, CultureInfo.CreateSpecificCulture(lsCulture_o))
            End If
            e.FormattingApplied = True
        End If
        If e.ColumnIndex = loColCotizacion.Index Then
            If Decimal.Parse(e.Value.ToString) = 1 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
            End If
            e.FormattingApplied = True
        End If
        If e.ColumnIndex = loColDebito_b.Index Then
            If Decimal.Parse(e.Value.ToString) = 0.00D Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
                loRow.DefaultCellStyle.ForeColor = Color.RoyalBlue
            End If
            e.FormattingApplied = True
        End If
        If e.ColumnIndex = loColCredito_b.Index Then
            If Decimal.Parse(e.Value.ToString) = 0.00D Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
                loRow.DefaultCellStyle.ForeColor = Color.IndianRed
            End If
            e.FormattingApplied = True
        End If
    End Sub
    Private Sub LPLocalizaRegistro(ByVal psCodigo As String)
        ' Este procedimiento realiza la busqueda del parametro
        ' a fin de ubicarlo dentro del DataGridView
        '--------------------------------------------------------------------
        If psCodigo.Trim.Length = 0 Then Exit Sub

        Dim liIndex As Integer = -1
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("orden").Value.ToString = psCodigo Then
                DataGridView1.ClearSelection()
                ' Aqui se selecciona la fila que contiene el codigo buscado
                DataGridView1.Rows(row.Index).Selected = True
                liIndex = row.Index
                Exit For
            End If
        Next
        ' Aqui es donde se mueve el DataGridView para que se pueda visualizar 
        ' la fila seleccionada.
        If liIndex > -1 Then
            DataGridView1.CurrentCell = DataGridView1.Rows(liIndex).Cells(0)
        End If
    End Sub

    Private Sub txtCodEmpresa_NE_Validating(sender As Object, e As CancelEventArgs) Handles txtCodEmpresa_NE.Validating
        If txtCodEmpresa_NE.Text.Trim.Length = 0 Then
            GFsAvisar("Debe ingresar codigo de empresa valido", sMENSAJE_, "Por favor intentelo de nuevo.")
            txtCodEmpresa_NE.Text = "0"
            Exit Sub
        End If
        If Not IsNumeric(txtCodEmpresa_NE.Text) Then
            txtCodEmpresa_NE.Text = "0"
            e.Cancel = True
            Exit Sub
        End If
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)

        Dim loFK As New Ec001empresas
        loFK.codEmpresa = liCodEmpresa
        If loFK.GetPK = sSinRegistros_ Then
            Dim loLookUp As New frmBc001empresas
            loLookUp.Tag = sELEGIR_
            GPCargar(loLookUp)
            If loLookUp.entidad IsNot Nothing Then
                txtCodEmpresa_NE.Text = CType(loLookUp.entidad, Ec001empresas).codEmpresa.ToString
            End If
            loLookUp = Nothing
            e.Cancel = True
            Exit Sub
        End If
        loFK.CerrarConexion()
        loFK = Nothing

        If GFsPuedeUsar("Empresa No." & liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength), "Puede gestionar la Empresa No." & liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength)) <> sSi_ Then
            e.Cancel = True
            Exit Sub
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub txtCodSucursal_NE_Validating(sender As Object, e As CancelEventArgs) Handles txtCodSucursal_NE.Validating
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)

        If txtCodSucursal_NE.Text.Trim.Length = 0 Then
            txtCodSucursal_NE.Text = "0"
            e.Cancel = True
            Exit Sub
        End If

        If Not IsNumeric(txtCodSucursal_NE.Text) Then
            txtCodSucursal_NE.Text = "0"
            e.Cancel = True
            Exit Sub
        End If

        Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text.ToString)

        If liCodSucursal > 0 Then
            Dim loFK As New Eb070sucursales
            Dim lsResultado As String = ""
            loFK.codEmpresa = liCodEmpresa
            loFK.codSucursal = liCodSucursal
            lsResultado = loFK.GetPK
            If lsResultado = sSinRegistros_ Then
                Dim loLookUp As New frmBb070sucursales
                loLookUp.codEmpresa = liCodEmpresa
                loLookUp.Tag = sELEGIR_
                GPCargar(loLookUp)
                If loLookUp.entidad IsNot Nothing Then
                    txtCodSucursal_NE.Text = CType(loLookUp.entidad, Eb070sucursales).codSucursal.ToString
                End If
                e.Cancel = True
                loLookUp = Nothing
            End If
            loFK.CerrarConexion()
            loFK = Nothing
            If GFsPuedeUsar("Empresa No." & liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength) & "- Sucursal No." & liCodSucursal.ToString(sFormatD_ & txtCodSucursal_NE.MaxLength), "Puede gestionar Empresa No." & liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength) & "- Sucursal No." & liCodSucursal.ToString(sFormatD_ & txtCodSucursal_NE.MaxLength)) <> sSi_ Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub txtFecha1_FE_Validating(sender As Object, e As CancelEventArgs) Handles txtFecha1_FE.Validating
        If txtFecha1_FE.Text.Trim.Length = 0 Then
            txtFecha1_FE.Text = Today.ToString("yyyy-MM") & "-01"
            e.Cancel = True
            Exit Sub
        End If
        If Not IsDate(txtFecha1_FE.Text) Then
            GFsAvisar("El dato ingresado [" & txtFecha1_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
            e.Cancel = True
            Exit Sub
        Else
            Dim ldFecha As Date = Date.Parse(txtFecha1_FE.Text.ToString)
            txtFecha1_FE.Text = ldFecha.ToString("yyyy-MM-dd")
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub txtFecha2_FE_Validating(sender As Object, e As CancelEventArgs) Handles txtFecha2_FE.Validating
        If txtFecha2_FE.Text.Trim.Length = 0 Then
            txtFecha2_FE.Text = Today.ToString("yyyy-MM-dd")
            e.Cancel = True
            Exit Sub
        End If
        If Not IsDate(txtFecha2_FE.Text) Then
            GFsAvisar("El dato ingresado [" & txtFecha2_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
            e.Cancel = True
            Exit Sub
        Else
            Dim ldFecha As Date = Date.Parse(txtFecha2_FE.Text.ToString)
            txtFecha2_FE.Text = ldFecha.ToString("yyyy-MM-dd")
        End If
        If txtFecha2_FE.Text < txtFecha1_FE.Text Then
            Dim lsAuxiliar As String = txtFecha2_FE.Text
            txtFecha2_FE.Text = txtFecha1_FE.Text
            txtFecha1_FE.Text = lsAuxiliar
            txtFecha1_FE.Focus()
            Exit Sub
        Else
            txtFecha2_FE.Tag = sOk_
            msValidado = ""
            For Each loControl As Control In Me.Controls
                If loControl.Name <> "txtBuscar" Then
                    If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                        If loControl.Tag Is Nothing Then
                            loControl.Tag = sCancelar_
                        End If
                        msValidado &= loControl.Tag.ToString
                    End If
                End If
            Next
            If InStr(msValidado, sCancelar_) > 0 Then
                GFsAvisar("Validacion final", sMENSAJE_, "No han sido ingresado correctamente todos los datos")
                txtCodEmpresa_NE.Focus()
                Exit Sub
            End If
            LPCalculaSaldoAnterior()
            LPCargarDatos()
            LPCargaTitulos()
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub LPConsultarDetalle()
        If txtCodEmpresa_NE.Text.Trim.Length = 0 Then Exit Sub
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim liNroAsiento As Integer = Integer.Parse(DataGridView1.Item("asiento", DataGridView1.CurrentRow.Index).Value.ToString)
        Dim liNroSecuencia As Integer = Integer.Parse(DataGridView1.Item("orden", DataGridView1.CurrentRow.Index).Value.ToString)

        Dim loCabecera As New Ee010asientoscabeceras
        loCabecera.codEmpresa = liCodEmpresa
        loCabecera.nroAsiento = liNroAsiento
        If loCabecera.GetPK = sOk_ Then
            Dim loDetalle As New Ed010asientosdetalles
            loDetalle.codEmpresa = liCodEmpresa
            loDetalle.nroAsiento = liNroAsiento
            loDetalle.nroSecuencia = liNroSecuencia
            If loDetalle.GetPK = sOk_ Then
                Dim loFormulario As New frmFd010asientosdetalles
                loFormulario.entidadCabecera = loCabecera
                loFormulario.entidad = loDetalle
                loFormulario.AccessibleName = "Empresa: " & liCodEmpresa & ", Asiento No.: " & liNroAsiento & ", Secuencia: " & liNroSecuencia
                loFormulario.Tag = sCONSULTAR_
                GPCargar(loFormulario)
                '-->  moFormulario.AccesibleName debe asignarse con el codigo en el formulario de carga
                '-->  esto será usado para realizar la localización del registro en el DataGridView
                msLocalizar = loFormulario.AccessibleName
                loFormulario = Nothing
            End If
            loDetalle.CerrarConexion()
            loDetalle = Nothing
        End If
        loCabecera.CerrarConexion()
        loCabecera = Nothing
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        LPConsultarDetalle()
    End Sub

    Private Sub LPCargaTitulos()
        Dim lsTitulo As String = ""
        lsTitulo = "MAYOR DE CUENTA" & txtCodCuenta.Text & " - " & lblNombreCuenta.Text & sSF_
        lsTitulo &= "EMPRESA: " & txtCodEmpresa_NE.Text & " - " & lblNombreEmpresa.Text & sSF_
        lsTitulo &= "SUCURSAL: " & txtCodSucursal_NE.Text & " - " & lblNombreSucursal.Text & sSF_
        lsTitulo &= "PERIODO: " & txtFecha1_FE.Text & " - " & txtFecha2_FE.Text
        DataGridView1.AccessibleName = lsTitulo
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        SendKeys.Send("%(c)")
    End Sub

    Private Sub frmBMayorCuenta_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        LPHabilitaControles2()
        If mbEntro Then
            mbEntro = False
            If txtFecha2_FE.Text.Trim.Length > 0 Then
                txtCodEmpresa_NE.Focus()
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text.ToString)
        Dim lsCodCuenta As String = Chr(39) & txtCodCuenta.Text.Trim & Chr(39)
        Dim lsDesde As String = txtFecha1_FE.Text
        Dim lsHasta As String = txtFecha2_FE.Text

        GRMayorCuenta(liCodEmpresa, liCodSucursal, lsCodCuenta, lsDesde, lsHasta)
    End Sub

    Private Sub btnImprimir_MouseMove(sender As Object, e As EventArgs) Handles btnImprimir.MouseMove
        btnImprimir.Image = My.Resources.Resources.icons8_color_print_48
        btnImprimir.Text = ""
    End Sub

    Private Sub btnImprimir_MouseLeave(sender As Object, e As EventArgs) Handles btnImprimir.MouseLeave, btnImprimir.LostFocus
        btnImprimir.Image = My.Resources.Resources.icons8_color_print_32
        btnImprimir.Text = btnImprimir.Tag.ToString
    End Sub

    Private Sub LPHabilitaControles2()
        btnConsultar.Enabled = False
        btnImprimir.Enabled = False
        btnAuditoria.Enabled = False
        If miCantidad > 0 Then
            btnConsultar.Enabled = mbConsultar
            btnImprimir.Enabled = mbImprimir
            btnAuditoria.Enabled = mbAuditoria
        End If
    End Sub

End Class