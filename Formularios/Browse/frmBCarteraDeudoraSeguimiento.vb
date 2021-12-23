Imports System.Globalization

Public Class frmBCarteraDeudoraSeguimiento
    Private msLocalizar As String = ""
    Private msTabla As String = ""

    Private Sub Browse_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        DataGridView1.MultiSelect = False
        DataGridView1.ContextMenuStrip = mnuExportarExcel
        LPSetDoubleBuffered(DataGridView1)
        PictureBox1.Visible = False

        AddHandler btnBuscar.Click, AddressOf BuscarClave
        AddHandler DataGridView1.CellFormatting, AddressOf DataGridView1_CellFormatting

        AddHandler MenuItem_ExportarExcel.Click, AddressOf ExportarExcel_Click
        AddHandler MenuItem_ExportarTexto.Click, AddressOf ExportarTexto_Click

        btnAgregar.AccessibleName = sAGREGAR_
        btnModificar.AccessibleName = sMODIFICAR_
        btnBorrar.AccessibleName = sBORRAR_
        btnConsultar.AccessibleName = sCONSULTAR_

        btnAgregar.Visible = False
        btnModificar.Visible = False
        btnBorrar.Visible = False
        btnConsultar.Visible = False
        LPCargarDatos()
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub LPCargarDatos()
        PictureBox1.Visible = True
        PictureBox1.Refresh()
        Dim loDataFunc As DataSet = Nothing
        Dim loFuncEscalar As New Eoitmc1
        Dim lsSQL As String = GFsGeneraSQL("frmBCarteraPeriodoVigente")
        Dim lsPeriodo As String = ""
        loDataFunc = loFuncEscalar.RecuperarTabla(lsSQL)
        lsPeriodo = loDataFunc.Tables(0).Rows(0).Item(0).ToString
        lsSQL = GFsGeneraSQL("frmBCarteraDeudoraSeguimiento")
        Dim loDatos As New Eoitmc1
        Dim loDataSet As DataSet
        Dim lsWhere As String = ""
        Dim lsCampos As String = "empresa, abogado, inicialesabog, codcliente, nomcliente, stock, sucursal, marca, modelo, periodofac, ventausd, pagosusd, saldousd, comentario, fechademanda, fechaordensecuestro, fechasecuestro, valortasacion, fecharemate, gastoventa, precioventa"
        Dim lsConcatFiltro As String = "empresa, abogado, inicialesabog, codcliente, nomcliente, stock, U_marca, U_modelo, sucursal, periodofac"
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        PictureBox1.Refresh()
        lsSQL = lsSQL.Replace("@periodo", lsPeriodo)
        lsSQL = lsSQL.Replace("@filtro", lsFiltro)
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView1.DataSource = loDataSet
        DataGridView1.DataMember = loDatos.tableName
        PictureBox1.Refresh()

        msTabla = loDatos.tableName
        miCantidad = loDataSet.Tables.Item(0).Rows.Count
        PictureBox1.Refresh()
        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
        loDataFunc = Nothing
        loFuncEscalar.Desconectar()
        PictureBox1.Visible = False
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.Value Is Nothing Then Exit Sub
        If e.Value.ToString = "" Then Exit Sub 

        'ventausd, pagosusd, saldousd, valortasacion, gastoventa, precioventa"
        Dim loRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim loVentaUSD As DataGridViewColumn = DataGridView1.Columns.Item("ventausd")
        Dim loPagosUSD As DataGridViewColumn = DataGridView1.Columns.Item("pagosusd")
        Dim loSaldoUSD As DataGridViewColumn = DataGridView1.Columns.Item("saldousd")
        Dim loValorTasacion As DataGridViewColumn = DataGridView1.Columns.Item("valortasacion")
        Dim loGastoVenta As DataGridViewColumn = DataGridView1.Columns.Item("gastoventa")
        Dim loPrecioVenta As DataGridViewColumn = DataGridView1.Columns.Item("precioventa")

        If e.ColumnIndex = loVentaUSD.Index Then
            If Double.Parse(e.Value.ToString) = 0 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString("0.00")
            End If
            e.FormattingApplied = True
        End If

        If e.ColumnIndex = loPagosUSD.Index Then
            If Double.Parse(e.Value.ToString) = 0 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString("0.00")
            End If
            e.FormattingApplied = True
        End If

        If e.ColumnIndex = loSaldoUSD.Index Then
            If Double.Parse(e.Value.ToString) = 0 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString("0.00")
            End If
            e.FormattingApplied = True
        End If

        If e.ColumnIndex = loValorTasacion.Index Then
            If Double.Parse(e.Value.ToString) = 0 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString("0.00")
            End If
            e.FormattingApplied = True
        End If

        If e.ColumnIndex = loGastoVenta.Index Then
            If Double.Parse(e.Value.ToString) = 0 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString("0.00")
            End If
            e.FormattingApplied = True
        End If

        If e.ColumnIndex = loPrecioVenta.Index Then
            If Double.Parse(e.Value.ToString) = 0 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString("0.00")
            End If
            e.FormattingApplied = True
        End If
    End Sub

    Private Sub txtBuscar_Validating(sender As Object, e As EventArgs) Handles txtBuscar.Validating
        BuscarClave(sender, e)
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown
        If e.KeyCode = 13 Then SendKeys.Send("{TAB}")
    End Sub

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

End Class