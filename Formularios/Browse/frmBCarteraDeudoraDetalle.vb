Public Class frmBCarteraDeudoraDetalle
    Private moFormulario As frmFCarteraDeudoraDetalle
    Private msItemCode As String = ""
    Private msCardCode As String = ""
    Private msTabla As String = ""
    Private msPk_Hash As String = ""
    Private msLocalizar As String = ""
    Private Shared mbabrirform As Boolean = False

    Public Property ItemCode As String
        Get
            Return msItemCode
        End Get
        Set(value As String)
            msItemCode = value
        End Set
    End Property

    Public Property CardCode As String
        Get
            Return msCardCode
        End Get
        Set(value As String)
            msCardCode = value
        End Set
    End Property

    Private Sub frmBrowse_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView1.AllowUserToResizeColumns = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = False
        LPSetDoubleBuffered(DataGridView1)

        btnAgregar.AccessibleName = sAGREGAR_
        btnModificar.AccessibleName = sMODIFICAR_
        btnBorrar.AccessibleName = sBORRAR_
        btnConsultar.AccessibleName = sCONSULTAR_

        AddHandler txtBuscar.TextChanged, AddressOf BuscarClave
        AddHandler btnAgregar.Click, AddressOf Botones_Click
        AddHandler btnModificar.Click, AddressOf Botones_Click
        AddHandler btnBorrar.Click, AddressOf Botones_Click
        AddHandler btnConsultar.Click, AddressOf Botones_Click

        AddHandler btnAgregar.MouseDown, AddressOf Imagen_Click
        AddHandler btnBorrar.MouseDown, AddressOf Imagen_Click
        AddHandler btnModificar.MouseDown, AddressOf Imagen_Click
        AddHandler btnConsultar.MouseDown, AddressOf Imagen_Click
        AddHandler btnAuditoria.MouseDown, AddressOf Imagen_Click
        AddHandler btnSalir.MouseDown, AddressOf Imagen_Click

        DataGridView1.ContextMenuStrip = mnuExportarExcel

        AddHandler MenuItem_ExportarExcel.Click, AddressOf ExportarExcel_Click
        AddHandler MenuItem_ExportarTexto.Click, AddressOf ExportarTexto_Click

        Dim loFk As New Eoitmc1
        loFk.ItemCode = msItemCode
        loFk.CardCode = msCardCode
        If loFk.GetPK = sOk_ Then
            Dim loFK1 As New Eocrd
            loFK1.GetPK(loFk.CardCode)
            lblNombreTabla.Text = "Stock: " & loFk.ItemCode & ", Cliente:" & loFk.CardCode & " " & loFK1.Atributo.CardName
        End If
        loFk = Nothing
        mbabrirform = False
        LPCargarDatos()
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub LPCargarDatos()
        Dim lsSQL As String
        Dim loDatos As New Eoitmc11
        Dim loDataSet As DataSet
        Dim lsWhere As String = "itemcode = @itemcode and cardcode = @cardcode"
        Dim lsCampos As String = "fechahora, comentario"
        Dim lsConcatFiltro As String = lsCampos
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        loDatos.ItemCode = msItemCode
        loDatos.CardCode = msCardCode
        lsSQL = loDatos.GenerarSQL(lsCampos, lsFiltro, lsWhere)
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView1.DataSource = loDataSet
        DataGridView1.DataMember = loDatos.tableName
        If msLocalizar IsNot Nothing Then LPLocalizaRegistro(msLocalizar)

        msTabla = loDatos.tableName
        miCantidad = loDataSet.Tables.Item(0).Rows.Count
        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
        LPSinRegistro_AbrirForm()
        LPHabilitaControles()
    End Sub

    Private Sub LPLocalizaRegistro(ByVal psCodigo As String)
        ' Este procedimiento realiza la busqueda del parametro
        ' a fin de ubicarlo dentro del DataGridView
        '--------------------------------------------------------------------
        If psCodigo.Trim.Length = 0 Then Exit Sub

        Dim liIndex As Integer = -1
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("fechahora").Value.ToString = psCodigo Then
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

    Private Sub Botones_Click(sender As Object, e As EventArgs)
        Dim loDatos As New Eoitmc11
        loDatos.ItemCode = msItemCode
        loDatos.CardCode = msCardCode
        Select Case CType(sender, Button).AccessibleName
            Case sAGREGAR_
                moFormulario = New frmFCarteraDeudoraDetalle
                moFormulario.Tag = CType(sender, Button).AccessibleName
                loDatos.FechaHora = Format(Now, "yyyy-MM-dd HH:mm")
                moFormulario.entidad = loDatos
                GPCargar(moFormulario)
                msLocalizar = moFormulario.AccessibleName
                moFormulario = Nothing
            Case Else
                If DataGridView1.CurrentRow Is Nothing Then Exit Sub
                '---------------------------------------------------------------------------------------------
                Dim lsCodigo As String = DataGridView1.Item("fechahora", DataGridView1.CurrentRow.Index).Value.ToString
                If lsCodigo.Trim.Length = 0 Then Exit Sub

                Dim lsTablaHash As String = LFsTablaHashPk(lsCodigo)
                If lsTablaHash.Trim.Length = 0 Then Exit Sub

                '---------------------------------------------------------------------------------------------
                Dim lsParte() As String = lsTablaHash.Split(sSF_)
                If GFbPuedeModificarBorrar(CType(sender, Button).AccessibleName, lsParte(0), lsParte(1), lsCodigo) = False Then Exit Sub
                Try
                    loDatos.FechaHora = lsCodigo
                    If loDatos.GetPK = sOk_ Then
                        moFormulario = New frmFCarteraDeudoraDetalle
                        moFormulario.AccessibleName = "Stock: " & loDatos.ItemCode & "/Cliente: " & loDatos.CardCode & "/Fecha-hora: " & loDatos.FechaHora
                        moFormulario.Tag = CType(sender, Button).AccessibleName
                        moFormulario.entidad = loDatos
                        GPCargar(moFormulario)
                        msLocalizar = moFormulario.AccessibleName
                        moFormulario = Nothing
                    End If
                Catch ex As Exception
                    GFsAvisar("Error en Browse", sError_, "No existe datos para el detalle [" & loDatos.FechaHora & "]" & ControlChars.CrLf & ex.Message)
                End Try
        End Select
        loDatos.CerrarConexion()
        loDatos = Nothing
        LPCargarDatos()
    End Sub

    Private Sub btnAuditoria_Click(sender As Object, e As EventArgs) Handles btnAuditoria.Click
        Dim lsCodigo As String = DataGridView1.Item("fechahora", DataGridView1.CurrentRow.Index).Value.ToString
        If lsCodigo.Trim.Length = 0 Then Exit Sub

        Dim lsTablaHash() As String = LFsTablaHashPk(lsCodigo).Split(sSF_)
        GPDespliegaBitacoraDatos(lsTablaHash(0), lsTablaHash(1))
    End Sub

    Private Function LFsTablaHashPk(ByVal psCodigo As String) As String
        Dim lsResultado As String = ""
        If psCodigo.Trim.Length > 0 Then
            Dim loDatos As New Eoitmc11
            loDatos.ItemCode = msItemCode
            loDatos.CardCode = msCardCode
            loDatos.FechaHora = psCodigo
            Try
                If loDatos.GetPK(sSi_) = sOk_ Then
                    lsResultado = loDatos.tableName & sSF_ & loDatos.hash_Pk
                End If
            Catch ex As Exception
                GFsAvisar("LFsTablaHashPk", sError_, ex.Message)
            End Try
        End If

        Return lsResultado
    End Function

    Private Sub Formulario_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter And e.Shift Then
            SendKeys.Send("%(m)")
        End If
        Select Case e.KeyCode
            Case Keys.Insert
                SendKeys.Send("%(a)")
            Case Keys.Enter
                SendKeys.Send("%(c)")
            Case Keys.Delete
                SendKeys.Send("%(b)")
            Case Keys.F10
                SendKeys.Send("%(u)")
        End Select
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

    Friend Sub LPSinRegistro_AbrirForm()
        If miCantidad = 0 Then
            If mbabrirform = False Then
                mbabrirform = True
                SendKeys.Send("%(a)")
            End If
        End If
    End Sub
End Class