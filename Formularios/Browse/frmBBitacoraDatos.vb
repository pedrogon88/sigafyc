Imports System.Reflection

Public Class frmBBitacoraDatos
    Private msTabla As String
    Private msPk_Hash As String
    Private msSS120_codigo As String

    Public Property tabla As String
        Get
            Return msTabla
        End Get
        Set(value As String)
            msTabla = value
        End Set
    End Property

    Public Property pk_Hash As String
        Get
            Return msPk_Hash
        End Get
        Set(value As String)
            msPk_Hash = value
        End Set
    End Property

    Private Sub btnSalir_MouseMove(sender As Object, e As EventArgs) Handles btnSalir.MouseMove
        btnSalir.Image = My.Resources.Resources.icons8_exit_48
        btnSalir.Text = ""
    End Sub

    Private Sub btnSalir_MouseLeave(sender As Object, e As EventArgs) Handles btnSalir.MouseLeave, btnSalir.LostFocus
        btnSalir.Image = My.Resources.Resources.icons8_exit_32
        btnSalir.Text = btnSalir.Tag.ToString
    End Sub

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

        AddHandler txtBuscar.TextChanged, AddressOf BuscarClave
        AddHandler btnSalir.MouseDown, AddressOf Imagen_Click

        AddHandler MenuItem_ExportarExcel.Click, AddressOf ExportarExcel_Click
        AddHandler MenuItem_ExportarTexto.Click, AddressOf ExportarTexto_Click
        LPCargarDatosCabecera()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Imagen_Click(sender, e)
        GPBitacoraRegistrar(sSALIO_, Me.Text.Trim)
        Me.Close()
    End Sub

    Private Sub LPCargarDatosCabecera()
        Dim lsSQL As String
        Dim loDatos As New Ess120bitdatcab
        Dim loDataSet As DataSet
        Dim lsWhere As String = "tabla = @tabla and pk_hash = @pk_hash"
        Dim lsCampos As String = "fechahora, operacion, ss050_codigo as usuario, loginacceso as login, ss060_codigo as equipo, ss010_codigo as sistema, ip, mac, dbms, server, hashid"
        Dim lsFiltroConcat As String = "fechahora, ss050_codigo, ss010_codigo, ss060_codigo, operacion, hashid"
        Dim lsConcatFiltro As String = lsFiltroConcat
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        loDatos.tabla = tabla
        loDatos.pk_hash = pk_Hash
        lsSQL = loDatos.GenerarSQL(lsCampos, lsFiltro, lsWhere)
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView1.DataSource = loDataSet
        DataGridView1.DataMember = loDatos.tableName
        DataGridView1.Columns.Item("hashid").Visible = False
        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub LPCargarDatosDetalle()
        Dim lsSQL As String
        Dim loDatos As New Ess130bitdatdet
        Dim loDataSet As DataSet
        Dim lsWhere As String = "ss120_codigo = @ss120_codigo" & ControlChars.CrLf &
                                "and campo <> " & Chr(39) & sHashidField_ & Chr(39) & ControlChars.CrLf &
                                "and campo <> " & Chr(39) & sBorradoField_ & Chr(39)
        Dim lsCampos As String = "orden, campo, antes, despues"
        Dim lsConcatFiltro As String = lsCampos
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        msSS120_codigo = DataGridView1.Item("hashid", DataGridView1.CurrentRow.Index).Value.ToString
        loDatos.ss120_codigo = msSS120_codigo
        lsSQL = loDatos.GenerarSQL(lsCampos, lsFiltro, lsWhere)
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView2.DataSource = loDataSet
        DataGridView2.DataMember = loDatos.tableName
        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatosCabecera()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        msSS120_codigo = DataGridView1.Item("hashid", DataGridView1.CurrentRow.Index).Value.ToString
        If msSS120_codigo.Trim.Length > 0 Then
            TabControl1.TabPages.Item(1).Visible = True
            LPCargarDatosDetalle()
        End If
    End Sub

    Private Sub txtBuscar_Click(sender As Object, e As EventArgs) Handles txtBuscar.Click
        txtBuscar.SelectAll()
        txtBuscar.Text = ""
    End Sub

    Private Sub frmBBitacoraDatos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If TabControl1.SelectedTab.TabIndex = 0 Then
            If DataGridView1.CurrentRow Is Nothing Then Exit Sub

            msSS120_codigo = DataGridView1.Item("hashid", DataGridView1.CurrentRow.Index).Value.ToString
            If msSS120_codigo.Trim.Length > 0 Then
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