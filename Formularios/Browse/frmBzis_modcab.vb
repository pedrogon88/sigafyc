Public Class frmBzis_modcab
    Private moFormulario As frmFzis_modcab
    Private msTabla As String = ""
    Private msPk_Hash As String = ""
    Private msLocalizar As String = ""

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        AddHandler btnDetalle.MouseDown, AddressOf Imagen_Click
        AddHandler btnAuditoria.MouseDown, AddressOf Imagen_Click
        AddHandler btnSalir.MouseDown, AddressOf Imagen_Click

        LPCargarDatos()
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub LPCargarDatos()
        Dim lsSQL As String
        Dim loDatos As New Ezis_modcab
        Dim loDataSet As DataSet
        Dim lsWhere As String = ""
        Dim lsCampos As String = "numtra, abreviado, sentido, script, tipodato, destino, findby, campopk"
        Dim lsConcatFiltro As String = lsCampos
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
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
            If row.Cells("numtra").Value.ToString = psCodigo Then
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
        Dim loDatos As New Ezis_modcab
        Select Case CType(sender, Button).AccessibleName
            Case sAGREGAR_
                moFormulario = New frmFzis_modcab
                moFormulario.Tag = CType(sender, Button).AccessibleName
                moFormulario.entidad = loDatos
                GPCargar(moFormulario)
                msLocalizar = moFormulario.AccessibleName
                moFormulario = Nothing
            Case Else
                If DataGridView1.CurrentRow Is Nothing Then Exit Sub
                '---------------------------------------------------------------------------------------------
                Dim lsCodigo As String = DataGridView1.Item("numtra", DataGridView1.CurrentRow.Index).Value.ToString
                If lsCodigo.Trim.Length = 0 Then Exit Sub

                Dim lsTablaHash As String = LFsTablaHashPk(lsCodigo)
                If lsTablaHash.Trim.Length = 0 Then Exit Sub

                '---------------------------------------------------------------------------------------------
                Dim lsParte() As String = lsTablaHash.Split(sSF_)
                If GFbPuedeModificarBorrar(CType(sender, Button).AccessibleName, lsParte(0), lsParte(1), lsCodigo) = False Then Exit Sub
                Try
                    loDatos.numtra = CInt(lsCodigo)
                    If loDatos.GetPK = sOk_ Then
                        If Me.Tag.ToString = sELEGIR_ And CType(sender, Button).AccessibleName = sCONSULTAR_ Then
                            entidad = loDatos
                            SendKeys.Send("%(s)")
                            Exit Sub
                        End If
                        moFormulario = New frmFzis_modcab
                        moFormulario.AccessibleName = "Transaccion: " & loDatos.numtra
                        moFormulario.Tag = CType(sender, Button).AccessibleName
                        moFormulario.entidad = loDatos
                        GPCargar(moFormulario)
                        msLocalizar = moFormulario.AccessibleName
                        moFormulario = Nothing
                    End If
                Catch ex As Exception
                    GFsAvisar("Error en Browse", sError_, "No existe datos para el codigo menu [" & loDatos.numtra & "]" & ControlChars.CrLf & ex.Message)
                End Try
        End Select
        loDatos.CerrarConexion()
        loDatos = Nothing
        Imagen_Click(sender)
        LPCargarDatos()
    End Sub

    Private Sub btnAuditoria_Click(sender As Object, e As EventArgs) Handles btnAuditoria.Click
        Dim lsCodigo As String = DataGridView1.Item("numtra", DataGridView1.CurrentRow.Index).Value.ToString
        If lsCodigo.Trim.Length = 0 Then Exit Sub

        Dim lsTablaHash() As String = LFsTablaHashPk(lsCodigo).Split(sSF_)
        GPDespliegaBitacoraDatos(lsTablaHash(0), lsTablaHash(1))
    End Sub

    Private Function LFsTablaHashPk(ByVal psCodigo As String) As String
        Dim lsResultado As String = ""
        If psCodigo.Trim.Length > 0 Then
            Dim loDatos As New Ezis_modcab
            loDatos.numtra = CInt(psCodigo)
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

        If e.KeyCode = Keys.D And e.Control Then
            SendKeys.Send("%(d)")
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

    Private Sub btnDetalle_MouseMove(sender As Object, e As EventArgs) Handles btnDetalle.MouseMove
        btnDetalle.Image = My.Resources.Resources.icons8_details_48
        btnDetalle.Text = ""
    End Sub

    Private Sub btnDetalle_MouseLeave(sender As Object, e As EventArgs) Handles btnDetalle.MouseLeave, btnDetalle.LostFocus
        btnDetalle.Image = My.Resources.Resources.icons8_details_32
        btnDetalle.Text = btnDetalle.Tag.ToString
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Dim loBrowseDetalle As New frmBzis_moddet
        loBrowseDetalle.numtra = CInt(DataGridView1.Item("numtra", DataGridView1.CurrentRow.Index).Value.ToString)
        GPCargar(loBrowseDetalle)
        loBrowseDetalle = Nothing
    End Sub

    Overloads Sub Imagen_Click(sender As Object, Optional e As MouseEventArgs = Nothing)
        Select Case CType(sender, Button).Name
            Case "btnAgregar"
                btnAgregar.Image = My.Resources.Resources.icons8_color_add_row_48
                btnAgregar.Text = ""
            Case "btnBorrar"
                btnBorrar.Image = My.Resources.Resources.icons8_color_delete_row_48
                btnBorrar.Text = ""
            Case "btnModificar"
                btnModificar.Image = My.Resources.Resources.icons8_color_edit_row_48
                btnModificar.Text = ""
            Case "btnConsultar"
                btnConsultar.Image = My.Resources.Resources.icons8_color_eye_48
                btnConsultar.Text = ""
            Case "btnDetalle"
                btnDetalle.Image = My.Resources.Resources.icons8_color_details_48
                btnDetalle.Text = ""
            Case "btnAuditoria"
                btnAuditoria.Image = My.Resources.Resources.icons8_color_survey_48
                btnAuditoria.Text = ""
            Case "btnSalir"
                btnSalir.Image = My.Resources.Resources.icons8_color_exit_48
                btnSalir.Text = ""
        End Select
    End Sub
End Class