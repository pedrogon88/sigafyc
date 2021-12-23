Imports System.ComponentModel
Imports System.Globalization
Imports System.Data.Common
Imports System.Reflection

Public Class frmBSaldosCuentas
    Private msTabla As String = ""
    Private msPk_Hash As String = ""

    Private msValidado As String = ""
    Private msRequeridos As String() = {"codempresa", "codsucursal", "nivel", "fecha"}
    Private moRequeridos As New ArrayList(msRequeridos)
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
    Private mbConsultar As Boolean
    Private mbImprimir As Boolean
    Private mbAuditoria As Boolean

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

        rbtNIvel6.Checked = True

        txtCodEmpresa_NE.AccessibleName = "codempresa"
        txtCodSucursal_NE.AccessibleName = "codsucursal"
        rbtNIvel1.AccessibleName = "nivel"
        rbtNIvel2.AccessibleName = "nivel"
        rbtNIvel3.AccessibleName = "nivel"
        rbtNIvel4.AccessibleName = "nivel"
        rbtNIvel5.AccessibleName = "nivel"
        rbtNIvel6.AccessibleName = "nivel"
        txtFecha_FE.AccessibleName = "fecha"
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub LPCargarDatos()
        If txtCodEmpresa_NE.Text.Trim.Length = 0 Then Exit Sub
        If txtFecha_FE.Text.Trim.Length = 0 Then Exit Sub

        Dim lsSQL As String = GFsGeneraSQL("frmBSaldosCuentas")
        Dim loDatos As New Eb050plancuentas
        Dim loDataSet As DataSet
        Dim lsCamposConcat As String = "x.codcuenta, y.nombre, y.tipo, y.nivel"
        Dim lsConcatFiltro As String = lsCamposConcat
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text.Trim = txtBuscar.Tag.ToString.Trim Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        lsSQL = lsSQL.Replace("@filtro", lsFiltro)
        lsSQL = lsSQL.Replace("@codempresa", txtCodEmpresa_NE.Text)
        Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text)
        If liCodSucursal = 0 Then
            lsSQL = lsSQL.Replace("@Sucursal", "")
        Else
            lsSQL = lsSQL.Replace("@Sucursal", "AND b090.codsucursal = " & liCodSucursal)
        End If
        lsSQL = lsSQL.Replace("@periodo", txtFecha_FE.Text)
        lsSQL = lsSQL.Replace("@nivel", LFsNivelSeleccionado())

        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView1.DataSource = loDataSet
        DataGridView1.DataMember = loDatos.tableName

        DataGridView1.Columns.Item("codempresa").Visible = False
        DataGridView1.Columns.Item("codigo").Visible = False
        DataGridView1.Sort(DataGridView1.Columns("codigo"), ListSortDirection.Ascending)
        If msLocalizar IsNot Nothing Then LPLocalizaRegistro(msLocalizar)

        msTabla = loDatos.tableName
        miCantidad = loDataSet.Tables.Item(0).Rows.Count
        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
        LPHabilitaControles2()
    End Sub

    Private Function LFsNivelSeleccionado() As String
        Dim lsResultado As String = ""
        If rbtNIvel1.Checked = True Then
            lsResultado = rbtNIvel1.Text
        End If
        If rbtNIvel2.Checked = True Then
            lsResultado = rbtNIvel2.Text
        End If
        If rbtNIvel3.Checked = True Then
            lsResultado = rbtNIvel3.Text
        End If
        If rbtNIvel4.Checked = True Then
            lsResultado = rbtNIvel4.Text
        End If
        If rbtNIvel5.Checked = True Then
            lsResultado = rbtNIvel5.Text
        End If
        If rbtNIvel6.Checked = True Then
            lsResultado = rbtNIvel6.Text
        End If
        Return lsResultado
    End Function

    Private Sub LPInicializaMaxLength()
        txtCodEmpresa_NE.MaxLength = 6
        txtCodSucursal_NE.MaxLength = 3
        txtFecha_FE.MaxLength = 10
    End Sub

    Private Sub LPDespliegaDescripciones()
        Dim liCodEmpresa As Integer = 0
        Dim liCodSucursal As Integer = 0

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

    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub btnAuditoria_Click(sender As Object, e As EventArgs) Handles btnAuditoria.Click
        If DataGridView1.CurrentRow Is Nothing Then Exit Sub

        Dim lsCodigo As String = DataGridView1.Item("codigo", DataGridView1.CurrentRow.Index).Value.ToString
        If lsCodigo.Trim.Length = 0 Then Exit Sub

        Dim lsTablaHash() As String = LFsTablaHashPk(lsCodigo).Split(sSF_)
        GPDespliegaBitacoraDatos(lsTablaHash(0), lsTablaHash(1))
    End Sub

    Private Function LFsTablaHashPk(ByVal psCodigo As String) As String
        Dim lsResultado As String = ""

        If txtCodEmpresa_NE.Text.Trim.Length > 0 Then
            If IsNumeric(txtCodEmpresa_NE.Text) Then
                If psCodigo.Trim.Length > 0 Then
                    Dim loDatos As New Eb050plancuentas
                    Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString.Trim)
                    loDatos.codEmpresa = liCodEmpresa
                    loDatos.codCuenta = psCodigo
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

    Private Sub LPInicializaControles()
        For Each loControl As Control In Me.Controls
            Select Case loControl.Name.Substring(0, 3)
                Case sPrefijoTextBox_
                    AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                    AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                    AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                Case sPrefijoGroupBox_
                    For Each loRadio As Control In gbxGrupo.Controls
                        AddHandler loRadio.KeyDown, AddressOf ManejoEvento_KeyDown
                        AddHandler loRadio.Validated, AddressOf ManejoEvento_Validated
                    Next
            End Select
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
        Dim loColSaldo As DataGridViewColumn = DataGridView1.Columns.Item("saldo")

        loColSaldo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        If e.ColumnIndex = loColSaldo.Index Then
            If Decimal.Parse(e.Value.ToString) > 0.00D Then
                e.Value = CDec(e.Value).ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
                loRow.DefaultCellStyle.ForeColor = Color.RoyalBlue
            Else
                If Decimal.Parse(e.Value.ToString) < 0.00D Then
                    e.Value = CDec(e.Value).ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
                    loRow.DefaultCellStyle.ForeColor = Color.IndianRed
                Else
                    e.Value = CDec(e.Value).ToString(sFormatC_ & msDecimales_b, CultureInfo.CreateSpecificCulture(msCulture_b))
                    loRow.DefaultCellStyle.ForeColor = Color.DarkOliveGreen
                End If
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
            txtCodEmpresa_NE.Text = "999999"
            Exit Sub
        End If
        If Not IsNumeric(txtCodEmpresa_NE.Text) Then
            e.Cancel = True
            Exit Sub
        End If
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        If liCodEmpresa = 0 Then
            e.Cancel = True
            Exit Sub
        End If

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

    Private Sub txtFecha_FE_Validating(sender As Object, e As CancelEventArgs) Handles txtFecha_FE.Validating
        Dim ldFecha As Date = Nothing

        If txtFecha_FE.Text.Trim.Length = 0 Then
            txtFecha_FE.Text = Today.ToString("yyyy-MM-dd")
            e.Cancel = True
            Exit Sub
        End If
        If Not IsDate(txtFecha_FE.Text) Then
            GFsAvisar("El dato ingresado [" & txtFecha_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
            e.Cancel = True
            Exit Sub
        Else
            ldFecha = Date.Parse(txtFecha_FE.Text.ToString)
            txtFecha_FE.Text = ldFecha.ToString("yyyy-MM-dd")
            txtFecha_FE.Tag = sOk_
        End If
        msValidado = ""
        For Each loControl As Control In Me.Controls
            If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                If loControl.Tag Is Nothing Then
                    loControl.Tag = sCancelar_
                End If
                msValidado &= loControl.Tag.ToString
            End If
        Next
        If InStr(msValidado, sCancelar_) > 0 Then
            GFsAvisar("Validacion final", sMENSAJE_, "No han sido ingresado correctamente todos los datos")
            txtCodEmpresa_NE.Focus()
            Exit Sub
        End If
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text.ToString)
        If GFbVerificaMovimientos(liCodEmpresa, liCodSucursal, ldFecha.ToString(sFormatoFecha1_)) = False Then
            GFsAvisar("Atención! los totales de debitos y creditos no coinciden, lo mas probable que existan Asientos que no cuadran", sMENSAJE_, "Por favor verifique y corrija para poder realizar esta consulta.")
            e.Cancel = True
            Exit Sub
        End If
        LPCargarDatos()
        LPDespliegaDescripciones()
        LPCargaTitulos()
    End Sub
    Private Sub LPCargaTitulos()
        Dim lsTitulo As String = ""
        lsTitulo = "SALDOS POR CUENTAS - AL " & txtFecha_FE.Text & sSF_
        lsTitulo &= "EMPRESA: " & txtCodEmpresa_NE.Text & " - " & lblNombreEmpresa.Text & sSF_
        lsTitulo &= "SUCURSAL: " & txtCodSucursal_NE.Text & " - " & lblNombreSucursal.Text & sSF_
        lsTitulo &= "HASTA NIVEL: " & LFsNivelSeleccionado()
        DataGridView1.AccessibleName = lsTitulo
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim lsTipo As String = DataGridView1.Item("tipo", DataGridView1.CurrentRow.Index).Value.ToString
        Dim lsCodCuenta As String = DataGridView1.Item("codigo", DataGridView1.CurrentRow.Index).Value.ToString
        If lsTipo = sTotales_.Substring(0, 1) Then
            GFsAvisar("La cuenta " & lsCodCuenta & " es de " & sTotales_ & " y no tiene mayor propiamente", sMENSAJE_, "La cuenta para ver su mayor debe ser " & sImputable_)
            Exit Sub
        End If

        Dim loMayorCuenta As New frmBMayorCuenta
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text.ToString)
        Dim lsFecha1 As String = txtFecha_FE.Text
        loMayorCuenta.codEmpresa = liCodEmpresa
        loMayorCuenta.codSucursal = liCodSucursal
        loMayorCuenta.codCuenta = lsCodCuenta
        loMayorCuenta.fechaHasta = lsFecha1
        GPCargar(loMayorCuenta)
        loMayorCuenta = Nothing
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        SendKeys.Send("%(c)")
    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text.ToString)
        Dim lsFecha1 As String = txtFecha_FE.Text

        Dim loMenuBalance As New frmMBalances
        loMenuBalance.codEmpresa = liCodEmpresa
        loMenuBalance.codSucursal = liCodSucursal
        loMenuBalance.fecha = lsFecha1
        loMenuBalance.nivel = LFsNivelSeleccionado()
        GPCargar(loMenuBalance)
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

    Private Sub frmBSaldosCuentas_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        LPHabilitaControles2()
    End Sub
End Class