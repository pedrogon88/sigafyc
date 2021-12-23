Imports System.ComponentModel

Public Class frmBss100habilitaciones
    Private moFormulario As frmFormulario
    Private msSS010_codigo As String = ""
    Private msCodigo As String = ""
    Private msTabla As String = ""
    Private msPk_Hash As String = ""
    Private msTipo As String = ""
    Private msRestriccion As String = ""
    Private msLocalizar As String = ""
    Private Shared mbabrirform As Boolean = False

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
        LPSetDoubleBuffered(DataGridView1)

        lblNombre.Text = ""
        cmbTipo.Tag = cmbTipo.Text

        btnAgregar.AccessibleName = sAGREGAR_
        btnModificar.AccessibleName = sMODIFICAR_
        btnBorrar.AccessibleName = sBORRAR_
        btnConsultar.AccessibleName = sCONSULTAR_
        msSS010_codigo = My.Application.Info.AssemblyName.ToUpper

        AddHandler txtBuscar.TextChanged, AddressOf BuscarClave
        AddHandler btnAgregar.Click, AddressOf Botones_Click
        AddHandler btnModificar.Click, AddressOf Botones_Click
        AddHandler btnBorrar.Click, AddressOf Botones_Click
        AddHandler btnConsultar.Click, AddressOf Botones_Click

        AddHandler cmbTipo.KeyDown, AddressOf ManejoEvento_KeyDown
        AddHandler txtCodigo_AN.KeyPress, AddressOf ManejoEvento_KeyPress
        AddHandler txtCodigo_AN.KeyDown, AddressOf ManejoEvento_KeyDown
        AddHandler DataGridView1.KeyDown, AddressOf DataGrid_KeyDown
        AddHandler DataGridView1.CellContentDoubleClick, AddressOf DataGrid_DoubleClick

        DataGridView1.ContextMenuStrip = mnuExportarExcel

        AddHandler MenuItem_ExportarExcel.Click, AddressOf ExportarExcel_Click
        AddHandler MenuItem_ExportarTexto.Click, AddressOf ExportarTexto_Click
        mbAbrirForm = False
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub LPCargarDatos()
        If cmbTipo.Text = cmbTipo.Tag.ToString Then Exit Sub
        If txtCodigo_AN.Text.Trim.Length = 0 Then Exit Sub

        Dim lsSQL As String
        Dim loDatos As New Ess100habilitaciones
        Dim loDataSet As DataSet
        Dim lsConcatFiltro As String = "s100.ss080_codigo, s080.nombre"
        lsSQL = GFsGeneraSQL("frmBss100habilitaciones")
        lsSQL = lsSQL.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsSQL = lsSQL.Replace(sFiltroValor_, "")
        Else
            lsSQL = lsSQL.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        msSS010_codigo = msSS010_codigo.ToUpper
        loDatos.ss010_codigo = msSS010_codigo
        loDatos.tipo = cmbTipo.Text
        loDatos.codigo = txtCodigo_AN.Text
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView1.DataSource = loDataSet
        DataGridView1.DataMember = loDatos.tableName

        DataGridView1.Columns.Item("ss010_codigo").Visible = False
        DataGridView1.Columns.Item("tipo").Visible = False
        DataGridView1.Columns.Item("codigo").Visible = False
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
            If row.Cells("restriccion").Value.ToString = psCodigo Then
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

    Private Sub txtCodigo_AB_Validating(sender As Object, e As CancelEventArgs) Handles txtCodigo_AN.Validating
        Dim lsCodigo As String = txtCodigo_AN.Text

        If txtCodigo_AN.Text.Trim.Length = 0 Then
            GFsAvisar("Debe ingresar codigo de " & cmbTipo.Text & " valido", sMENSAJE_, "Por favor intentelo de nuevo.")
            btnSalir.Focus()
            Exit Sub
        End If
        Select Case cmbTipo.Text
            Case sUsuario_
                Dim loFK As New Ess050usuarios

                loFK.codigo = lsCodigo
                If loFK.GetPK = sSinRegistros_ Then
                    Dim loLookUp As New frmBss050usuarios
                    loLookUp.Tag = sELEGIR_
                    GPCargar(loLookUp)
                    If loLookUp.entidad IsNot Nothing Then
                        txtCodigo_AN.Text = CType(loLookUp.entidad, Ess050usuarios).codigo
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                    loLookUp = Nothing
                End If
                loFK.CerrarConexion()
                loFK = Nothing

            Case sPerfil_
                Dim loFK As New Ess070perfiles
                loFK.codigo = lsCodigo
                If loFK.GetPK = sSinRegistros_ Then
                    Dim loLookUp As New frmBss070perfiles
                    loLookUp.Tag = sELEGIR_
                    GPCargar(loLookUp)
                    If loLookUp.entidad IsNot Nothing Then
                        txtCodigo_AN.Text = CType(loLookUp.entidad, Ess070perfiles).codigo
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                    loLookUp = Nothing
                End If
                loFK.CerrarConexion()
                loFK = Nothing
        End Select

        LPDespliegaDescripciones()
        LPCargarDatos()
        btnAgregar.Focus()
    End Sub

    Private Sub LPInicializaMaxLength()
        cmbTipo.MaxLength = 15
        txtCodigo_AN.MaxLength = 15
    End Sub

    Private Sub LPDespliegaDescripciones()
        Dim lsCodigo As String = txtCodigo_AN.Text

        lblNombre.Text = ""
        If txtCodigo_AN.Text.Trim.Length > 0 Then
            Select Case cmbTipo.Text
                Case sPerfil_
                    Dim loFK As New Ess070perfiles
                    loFK.codigo = lsCodigo
                    If loFK.GetPK = sOk_ Then
                        lblNombre.Text = loFK.nombre
                    End If
                    loFK.CerrarConexion()
                    loFK = Nothing
                Case sUsuario_
                    Dim loFK As New Ess050usuarios
                    loFK.codigo = lsCodigo
                    If loFK.GetPK = sOk_ Then
                        lblNombre.Text = loFK.nombre
                    End If
                    loFK.CerrarConexion()
                    loFK = Nothing
            End Select
        End If

    End Sub

    Private Sub Botones_Click(sender As Object, e As EventArgs)
        If cmbTipo.Text = cmbTipo.Tag.ToString Then Exit Sub
        If txtCodigo_AN.Text.Trim.Length = 0 Then Exit Sub

        Dim loDatos As New Ess100habilitaciones
        loDatos.ss010_codigo = msSS010_codigo
        Select Case CType(sender, Button).AccessibleName
            Case sAGREGAR_

                moFormulario = New frmFss100habilitaciones2
                moFormulario.Tag = CType(sender, Button).AccessibleName
                loDatos.tipo = cmbTipo.Text
                loDatos.codigo = txtCodigo_AN.Text
                moFormulario.entidad = loDatos
                GPCargar(moFormulario)
                msLocalizar = moFormulario.AccessibleName
                moFormulario = Nothing
            Case Else
                If DataGridView1.CurrentRow Is Nothing Then Exit Sub
                '---------------------------------------------------------------------------------------------
                msTipo = DataGridView1.Item("tipo", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsCodigo As String = DataGridView1.Item("codigo", DataGridView1.CurrentRow.Index).Value.ToString
                msRestriccion = DataGridView1.Item("restriccion", DataGridView1.CurrentRow.Index).Value.ToString
                If lsCodigo.Trim.Length = 0 Then Exit Sub

                Dim lsTablaHash As String = LFsTablaHashPk(lsCodigo)
                If lsTablaHash.Trim.Length = 0 Then Exit Sub

                '---------------------------------------------------------------------------------------------
                Dim lsParte() As String = lsTablaHash.Split(sSF_)
                If GFbPuedeModificarBorrar(CType(sender, Button).AccessibleName, lsParte(0), lsParte(1), lsCodigo) = False Then Exit Sub
                Try
                    loDatos.tipo = msTipo
                    loDatos.codigo = lsCodigo
                    loDatos.ss080_codigo = msRestriccion
                    If loDatos.GetPK = sOk_ Then
                        If Me.Tag.ToString = sELEGIR_ And CType(sender, Button).AccessibleName = sCONSULTAR_ Then
                            entidad = loDatos
                            SendKeys.Send("%(s)")
                            Exit Sub
                        End If
                        moFormulario = New frmFss100habilitaciones
                        moFormulario.AccessibleName = "sistema: " & loDatos.ss010_codigo & "/tipo: " & loDatos.tipo & "/codigo:" & loDatos.codigo & "/restriccion:" & loDatos.ss080_codigo
                        moFormulario.Tag = CType(sender, Button).AccessibleName
                        moFormulario.entidad = loDatos
                        GPCargar(moFormulario)
                        msLocalizar = moFormulario.AccessibleName
                        moFormulario = Nothing
                    End If
                Catch ex As Exception
                    GFsAvisar("Error en Browse", sError_, "No existe datos para la clave [" & loDatos.ss010_codigo & "/" & loDatos.tipo & "/" & loDatos.codigo & "/" & loDatos.ss080_codigo & "]" & ControlChars.CrLf & ex.Message)
                End Try
        End Select
        loDatos.CerrarConexion()
        loDatos = Nothing
        LPCargarDatos()
    End Sub

    Private Sub btnAuditoria_Click(sender As Object, e As EventArgs) Handles btnAuditoria.Click
        msTipo = DataGridView1.Item("tipo", DataGridView1.CurrentRow.Index).Value.ToString
        Dim lsCodigo As String = DataGridView1.Item("codigo", DataGridView1.CurrentRow.Index).Value.ToString
        msRestriccion = DataGridView1.Item("restriccion", DataGridView1.CurrentRow.Index).Value.ToString
        If lsCodigo.Trim.Length = 0 Then Exit Sub

        Dim lsTablaHash() As String = LFsTablaHashPk(lsCodigo).Split(sSF_)
        GPDespliegaBitacoraDatos(lsTablaHash(0), lsTablaHash(1))
    End Sub

    Private Function LFsTablaHashPk(ByVal psCodigo As String) As String
        Dim lsResultado As String = ""
        If psCodigo.Trim.Length > 0 Then
            Dim loDatos As New Ess100habilitaciones
            loDatos.ss010_codigo = msSS010_codigo
            loDatos.tipo = msTipo
            loDatos.codigo = psCodigo
            loDatos.ss080_codigo = msRestriccion
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
            If mbAbrirForm = False Then
                mbAbrirForm = True
                SendKeys.Send("%(a)")
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

    End Sub
End Class