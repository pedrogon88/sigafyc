Public Class frmBss110parametros
    Private moFormulario As frmFss110parametros
    Private msSS010_codigo As String = ""
    Private msTipo As String = ""
    Private msPrefijo As String = ""
    Private msTabla As String = ""
    Private msPk_Hash As String = ""
    Private msLocalizar As String = ""

    Private Sub Browse_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnAgregar.AccessibleName = sAGREGAR_
        btnModificar.AccessibleName = sMODIFICAR_
        btnBorrar.AccessibleName = sBORRAR_
        btnConsultar.AccessibleName = sCONSULTAR_
        msSS010_codigo = My.Application.Info.AssemblyName.ToUpper

        AddHandler txtBuscar.Validating, AddressOf BuscarClave
        AddHandler btnAgregar.Click, AddressOf Botones_Click
        AddHandler btnModificar.Click, AddressOf Botones_Click
        AddHandler btnBorrar.Click, AddressOf Botones_Click
        AddHandler btnConsultar.Click, AddressOf Botones_Click
        LPCargarDatos()
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub LPCargarDatos()
        Dim lsSQL As String
        Dim loDatos As New Ess110parametros
        Dim loDataSet As DataSet
        Dim lsWhere As String = "ss010_codigo = @ss010_codigo"
        Dim lsCampos As String = "tipo, prefijo, clave, case when right(clave,1) = '_' then '***ENCRIPTADO***' else valor end as valor"
        Dim lsConcatFiltro As String = "tipo, prefijo, clave, valor"
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        msSS010_codigo = msSS010_codigo.ToUpper
        loDatos.ss010_codigo = msSS010_codigo
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
            If row.Cells("clave").Value.ToString = psCodigo Then
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
        Dim loDatos As New Ess110parametros
        loDatos.ss010_codigo = msSS010_codigo
        Select Case CType(sender, Button).AccessibleName
            Case sAGREGAR_
                moFormulario = New frmFss110parametros
                moFormulario.Tag = CType(sender, Button).AccessibleName
                moFormulario.entidad = loDatos
                GPCargar(moFormulario)
                msLocalizar = moFormulario.AccessibleName
                moFormulario = Nothing
            Case Else
                If DataGridView1.CurrentRow Is Nothing Then Exit Sub
                '---------------------------------------------------------------------------------------------
                msTipo = DataGridView1.Item("tipo", DataGridView1.CurrentRow.Index).Value.ToString
                msPrefijo = DataGridView1.Item("prefijo", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsCodigo As String = DataGridView1.Item("clave", DataGridView1.CurrentRow.Index).Value.ToString
                If lsCodigo.Trim.Length = 0 Then Exit Sub

                Dim lsTablaHash As String = LFsTablaHashPk(lsCodigo)
                If lsTablaHash.Trim.Length = 0 Then Exit Sub

                '---------------------------------------------------------------------------------------------
                Dim lsParte() As String = lsTablaHash.Split(sSF_)
                If GFbPuedeModificarBorrar(CType(sender, Button).AccessibleName, lsParte(0), lsParte(1), lsCodigo) = False Then Exit Sub
                Try
                    loDatos.tipo = msTipo
                    loDatos.prefijo = msPrefijo
                    loDatos.clave = lsCodigo
                    If loDatos.GetPK = sOk_ Then
                        If Me.Tag.ToString = sELEGIR_ And CType(sender, Button).AccessibleName = sCONSULTAR_ Then
                            entidad = loDatos
                            SendKeys.Send("%(s)")
                            Exit Sub
                        End If
                        moFormulario = New frmFss110parametros
                        moFormulario.AccessibleName = "sistema: " & loDatos.ss010_codigo & "/tipo: " & loDatos.tipo & "/prefijo:" & loDatos.prefijo & "/clave:" & loDatos.clave
                        moFormulario.Tag = CType(sender, Button).AccessibleName
                        moFormulario.entidad = loDatos
                        GPCargar(moFormulario)
                        msLocalizar = moFormulario.AccessibleName
                        moFormulario = Nothing
                    End If
                Catch ex As Exception
                    GFsAvisar("Error en Browse", sError_, "No existe datos para la clave [" & loDatos.clave & "]" & ControlChars.CrLf & ex.Message)
                End Try
        End Select
        loDatos.CerrarConexion()
        loDatos = Nothing
        LPCargarDatos()
    End Sub


    Private Sub btnAuditoria_Click(sender As Object, e As EventArgs) Handles btnAuditoria.Click
        msTipo = DataGridView1.Item("tipo", DataGridView1.CurrentRow.Index).Value.ToString
        msPrefijo = DataGridView1.Item("prefijo", DataGridView1.CurrentRow.Index).Value.ToString
        Dim lsCodigo As String = DataGridView1.Item("clave", DataGridView1.CurrentRow.Index).Value.ToString
        If lsCodigo.Trim.Length = 0 Then Exit Sub

        Dim lsTablaHash() As String = LFsTablaHashPk(lsCodigo).Split(sSF_)
        GPDespliegaBitacoraDatos(lsTablaHash(0), lsTablaHash(1))
    End Sub

    Private Function LFsTablaHashPk(ByVal psCodigo As String) As String
        Dim lsResultado As String = ""
        If psCodigo.Trim.Length > 0 Then
            Dim loDatos As New Ess110parametros
            loDatos.ss010_codigo = msSS010_codigo
            loDatos.tipo = msTipo
            loDatos.prefijo = msPrefijo
            loDatos.clave = psCodigo
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

End Class