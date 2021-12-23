Imports System.Reflection

Public Class frmBBitacoraSesion
    Private msSS010_codigo As String = My.Application.Info.AssemblyName.ToUpper
    Private msSS140_codigo As String = ""
    Private msSS140_codigo_anterior As String = ""

    Private Sub frmFormulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.Tag Is Nothing Then Me.Tag = ""
        DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView1.AllowUserToResizeColumns = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView2.DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView2.AllowUserToResizeColumns = True
        DataGridView2.RowHeadersVisible = False
        DataGridView2.AllowUserToResizeRows = False
        LPSetDoubleBuffered(DataGridView1)

        AddHandler txtBuscar.TextChanged, AddressOf BuscarCabecera
        AddHandler txtBuscarDetalle.TextChanged, AddressOf BuscarDetalle

        AddHandler MenuItem_ExportarExcel.Click, AddressOf ExportarExcel_Click
        AddHandler MenuItem_ExportarTexto.Click, AddressOf ExportarTexto_Click
        LPCargarDatosCabecera()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Imagen_Click(sender, e)
        GPBitacoraRegistrar(sSALIO_, Me.Text.Trim)
        Me.Close()
    End Sub

    Private Sub LPCargarDatosCabecera()
        Dim lsSQL As String
        Dim loDatos As New Ess140bitsescab
        Dim loDataSet As DataSet
        Dim lsWhere As String = "ss010_codigo = @ss010_codigo"
        Dim lsCampos As String = "fechahora, ss050_codigo as usuario, ss060_codigo as equipo, login, ip, mac, dbms, server, codigo"
        Dim lsFiltroConcat As String = "fechahora, ss050_codigo, ss060_codigo, login, ip, mac, dbms, server"
        Dim lsConcatFiltro As String = lsFiltroConcat
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        loDatos.ss010_codigo = msSS010_codigo.ToUpper
        lsSQL = loDatos.GenerarSQL(lsCampos, lsFiltro, lsWhere)
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView1.DataSource = loDataSet
        DataGridView1.DataMember = loDatos.tableName
        DataGridView1.Columns.Item("codigo").Visible = False
        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub LPCargarDatosDetalle()
        Dim lsSQL As String
        Dim loDatos As New Ess150bitsesdet
        Dim loDataSet As DataSet
        Dim lsWhere As String = "ss140_codigo = @ss140_codigo" & ControlChars.CrLf
        Dim lsCampos As String = "fechahora, operacion, detalle"
        Dim lsConcatFiltro As String = lsCampos
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscarDetalle.Text = txtBuscarDetalle.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscarDetalle.Text)
        End If
        msSS140_codigo = DataGridView1.Item("codigo", DataGridView1.CurrentRow.Index).Value.ToString
        loDatos.ss140_codigo = msSS140_codigo
        lsSQL = loDatos.GenerarSQL(lsCampos, lsFiltro, lsWhere)
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView2.DataSource = loDataSet
        DataGridView2.DataMember = loDatos.tableName
        msSS140_codigo_anterior = msSS140_codigo
        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub txtBuscar_Click(sender As Object, e As EventArgs) _
        Handles txtBuscar.Click,
                txtBuscarDetalle.Click

        CType(sender, TextBox).SelectAll()
        CType(sender, TextBox).Text = ""
    End Sub

    Private Sub BuscarCabecera(sender As Object, e As EventArgs)
        LPCargarDatosCabecera()
    End Sub

    Private Sub BuscarDetalle(sender As Object, e As EventArgs)
        LPCargarDatosDetalle()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        msSS140_codigo = DataGridView1.Item("codigo", DataGridView1.CurrentRow.Index).Value.ToString
        If msSS140_codigo.Trim.Length > 0 Then
            TabControl1.TabPages.Item(1).Visible = True
            LPCargarDatosDetalle()
        End If
    End Sub


    Private Sub frmBBitacoraDatos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If TabControl1.SelectedTab.TabIndex = 0 Then
            msSS140_codigo = DataGridView1.Item("codigo", DataGridView1.CurrentRow.Index).Value.ToString
            If msSS140_codigo.Trim.Length > 0 Then
                TabControl1.TabPages.Item(1).Visible = False
                LPCargarDatosDetalle()
            End If
        End If
    End Sub

    Friend Sub Imagen_Click(sender As Object, e As EventArgs)
        Select Case CType(sender, Button).Name
            Case "btnSalir"
                btnSalir.Image = My.Resources.Resources.icons8_color_exit_48
                btnSalir.Text = ""
        End Select
    End Sub

    Private Sub btnSalir_MouseMove(sender As Object, e As EventArgs) Handles btnSalir.MouseMove
        btnSalir.Image = My.Resources.Resources.icons8_exit_48
        btnSalir.Text = ""
    End Sub

    Private Sub btnSalir_MouseLeave(sender As Object, e As EventArgs) Handles btnSalir.MouseLeave, btnSalir.LostFocus
        btnSalir.Image = My.Resources.Resources.icons8_exit_32
        btnSalir.Text = ""
    End Sub

    Private Sub ExportarExcel_Click(sender As Object, e As EventArgs)
        If GFsPuedeUsar(Me.Name & ":Exportar->Excel", "Permite exportar el contenido de " & Me.Name & " a un archivo Excel") = sSi_ Then
            If TabControl1.TabPages.Item(TabControl1.SelectedIndex).Name = "TabPage1" Then
                GPExportarGridToExcel(DataGridView1, Me.Name & "_" & TabControl1.TabPages.Item(TabControl1.SelectedIndex).Tag.ToString)
            Else
                GPExportarGridToExcel(DataGridView2, Me.Name & "_" & TabControl1.TabPages.Item(TabControl1.SelectedIndex).Tag.ToString)
            End If
        End If
    End Sub

    Private Sub ExportarTexto_Click(sender As Object, e As EventArgs)
        If GFsPuedeUsar(Me.Name & ":Exportar->Texto delimitado", "Permite exportar el contenido de " & Me.Name & " a un archivo de texto delimitado") = sSi_ Then
            If TabControl1.TabPages.Item(TabControl1.SelectedIndex).Name = "TabPage1" Then
                GPExportarGridToTexto(DataGridView1, Me.Name & "_" & TabControl1.TabPages.Item(TabControl1.SelectedIndex).Tag.ToString)
            Else
                GPExportarGridToTexto(DataGridView2, Me.Name & "_" & TabControl1.TabPages.Item(TabControl1.SelectedIndex).Tag.ToString)
            End If
        End If
    End Sub

    Public Shared Sub LPSetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub
End Class