Imports System.ComponentModel

Public Class frmBb030cotizaciones
    Private moFormulario As frmFb030cotizaciones
    Private msTabla As String = ""
    Private msPk_Hash As String = ""
    Private mbAgregar As Boolean
    Private mbModificar As Boolean
    Private mbBorrar As Boolean
    Private mbConsultar As Boolean
    Private mbAuditoria As Boolean
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

        LPInicializaMaxLength()

        mbAgregar = btnAgregar.Enabled
        mbModificar = btnModificar.Enabled
        mbBorrar = btnBorrar.Enabled
        mbConsultar = btnConsultar.Enabled
        mbAuditoria = btnAuditoria.Enabled

        btnAgregar.AccessibleName = sAGREGAR_
        btnModificar.AccessibleName = sMODIFICAR_
        btnBorrar.AccessibleName = sBORRAR_
        btnConsultar.AccessibleName = sCONSULTAR_

        AddHandler txtBuscar.TextChanged, AddressOf BuscarClave
        AddHandler btnAgregar.Click, AddressOf Botones_Click
        AddHandler btnModificar.Click, AddressOf Botones_Click
        AddHandler btnBorrar.Click, AddressOf Botones_Click
        AddHandler btnConsultar.Click, AddressOf Botones_Click
        AddHandler txtCodMoneda1_AN.KeyPress, AddressOf ManejoEvento_KeyPress
        AddHandler txtCodMoneda1_AN.KeyDown, AddressOf ManejoEvento_KeyDown
        AddHandler txtCodMoneda2_AN.KeyPress, AddressOf ManejoEvento_KeyPress
        AddHandler txtCodMoneda2_AN.KeyDown, AddressOf ManejoEvento_KeyDown
        AddHandler DataGridView1.KeyDown, AddressOf DataGrid_KeyDown
        AddHandler DataGridView1.CellContentDoubleClick, AddressOf DataGrid_DoubleClick

        DataGridView1.ContextMenuStrip = mnuExportarExcel

        AddHandler MenuItem_ExportarExcel.Click, AddressOf ExportarExcel_Click
        AddHandler MenuItem_ExportarTexto.Click, AddressOf ExportarTexto_Click

        lblNombreMoneda1.Text = ""
        lblNombreMoneda2.Text = ""
        mbAbrirForm = False
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub LPCargarDatos()
        Dim lsSQL As String
        Dim loDatos As New Eb030cotizaciones
        Dim loDataSet As DataSet
        Dim lsWhere As String = "codmoneda1 = @codmoneda1 and codmoneda2 = @codmoneda2"
        Dim lsCampos As String = "valido, compra, venta, estado"
        Dim lsCamposConcat As String = "valido, compra, venta, estado"
        Dim lsConcatFiltro As String = lsCamposConcat
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        lsSQL = loDatos.GenerarSQL(lsCampos, lsFiltro, lsWhere)
        loDatos.codMoneda1 = txtCodMoneda1_AN.Text
        loDatos.codMoneda2 = txtCodMoneda2_AN.Text
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

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        txtCodMoneda1_AN.Focus()
    End Sub

    Private Sub LPDespliegaDescripciones()
        lblNombreMoneda1.Text = ""
        If txtCodMoneda1_AN.Text.Trim.Length > 0 Then
            Dim loFK1 As New Ea010monedas
            loFK1.codMoneda = txtCodMoneda1_AN.Text
            If loFK1.GetPK = sOk_ Then
                lblNombreMoneda1.Text = loFK1.nombre
            End If
            loFK1.CerrarConexion()
            loFK1 = Nothing
        End If

        lblNombreMoneda2.Text = ""
        If txtCodMoneda2_AN.Text.Trim.Length > 0 Then
            Dim loFK1 As New Ea010monedas
            loFK1.codMoneda = txtCodMoneda2_AN.Text
            If loFK1.GetPK = sOk_ Then
                lblNombreMoneda2.Text = loFK1.nombre
            End If
            loFK1.CerrarConexion()
            loFK1 = Nothing
        End If
    End Sub

    Private Sub LPLocalizaRegistro(ByVal psCodigo As String)
        ' Este procedimiento realiza la busqueda del parametro
        ' a fin de ubicarlo dentro del DataGridView
        '--------------------------------------------------------------------
        If psCodigo.Trim.Length = 0 Then Exit Sub

        Dim liIndex As Integer = -1
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("valido").Value.ToString = psCodigo Then
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

    Private Sub txtCodMoneda1_AN_Validating(sender As Object, e As CancelEventArgs) Handles txtCodMoneda1_AN.Validating
        Dim loFK As New Ea010monedas
        If txtCodMoneda1_AN.Text.Trim.Length = 0 Then
            GFsAvisar("Debe ingresar codigo de moneda valido", sMENSAJE_, "Por favor intentelo de nuevo.")
            btnSalir.Focus()
            Exit Sub
        End If

        loFK.codMoneda = txtCodMoneda1_AN.Text
        If loFK.GetPK = sSinRegistros_ Then
            Dim loLookUp As New frmBa010monedas
            loLookUp.Tag = sELEGIR_
            GPCargar(loLookUp)
            If loLookUp.entidad IsNot Nothing Then
                txtCodMoneda1_AN.Text = CType(loLookUp.entidad, Ea010monedas).codMoneda
            End If
            e.Cancel = True
            loLookUp = Nothing
        End If
        loFK.CerrarConexion()
        loFK = Nothing
        LPDespliegaDescripciones()
    End Sub

    Private Sub txtCodMoneda2_AN_Validating(sender As Object, e As CancelEventArgs) Handles txtCodMoneda2_AN.Validating
        Dim loFK As New Ea010monedas
        If txtCodMoneda2_AN.Text.Trim.Length = 0 Then
            GFsAvisar("Debe ingresar codigo de moneda valido", sMENSAJE_, "Por favor intentelo de nuevo.")
            btnSalir.Focus()
            Exit Sub
        End If

        loFK.codMoneda = txtCodMoneda2_AN.Text
        If loFK.GetPK = sSinRegistros_ Then
            Dim loLookUp As New frmBa010monedas
            loLookUp.Tag = sELEGIR_
            GPCargar(loLookUp)
            If loLookUp.entidad IsNot Nothing Then
                txtCodMoneda2_AN.Text = CType(loLookUp.entidad, Ea010monedas).codMoneda
            End If
            e.Cancel = True
            loLookUp = Nothing
        End If
        loFK.CerrarConexion()
        loFK = Nothing

        LPDespliegaDescripciones()
        LPCargarDatos()
    End Sub

    Private Sub Botones_Click(sender As Object, e As EventArgs)
        Dim loDatos As New Eb030cotizaciones
        Select Case CType(sender, Button).AccessibleName
            Case sAGREGAR_
                moFormulario = New frmFb030cotizaciones
                moFormulario.Tag = CType(sender, Button).AccessibleName
                loDatos.codMoneda1 = txtCodMoneda1_AN.Text
                loDatos.codMoneda2 = txtCodMoneda2_AN.Text
                moFormulario.entidad = loDatos
                GPCargar(moFormulario)
                msLocalizar = moFormulario.AccessibleName
                moFormulario = Nothing
            Case Else
                If DataGridView1.CurrentRow Is Nothing Then Exit Sub
                '---------------------------------------------------------------------------------------------
                Dim lsCodigo As String = DataGridView1.Item("valido", DataGridView1.CurrentRow.Index).Value.ToString
                If lsCodigo.Trim.Length = 0 Then Exit Sub

                Dim lsTablaHash As String = LFsTablaHashPk(lsCodigo)
                If lsTablaHash.Trim.Length = 0 Then Exit Sub

                '---------------------------------------------------------------------------------------------
                Dim lsParte() As String = lsTablaHash.Split(sSF_)
                If GFbPuedeModificarBorrar(CType(sender, Button).AccessibleName, lsParte(0), lsParte(1), lsCodigo) = False Then Exit Sub
                Try
                    loDatos.codMoneda1 = txtCodMoneda1_AN.Text
                    loDatos.codMoneda2 = txtCodMoneda2_AN.Text
                    loDatos.valido = lsCodigo
                    If loDatos.GetPK = sOk_ Then
                        If Me.Tag.ToString = sELEGIR_ And CType(sender, Button).AccessibleName = sCONSULTAR_ Then
                            entidad = loDatos
                            SendKeys.Send("%(s)")
                            Exit Sub
                        End If
                        moFormulario = New frmFb030cotizaciones
                        moFormulario.AccessibleName = "Moneda De: " & loDatos.codMoneda1 & " - A: " & loDatos.codMoneda2 & " - Valido:" & loDatos.valido
                        moFormulario.Tag = CType(sender, Button).AccessibleName
                        moFormulario.entidad = loDatos
                        GPCargar(moFormulario)
                        msLocalizar = moFormulario.AccessibleName
                        moFormulario = Nothing
                    End If
                Catch ex As Exception
                    GFsAvisar("Error en Browse", sError_, "No existe datos para Validez [" & loDatos.valido & "] Moneda De: " & loDatos.codMoneda1 & " - A:" & loDatos.codMoneda2 & ControlChars.CrLf & ex.Message)
                End Try
        End Select
        loDatos.CerrarConexion()
        loDatos = Nothing
        LPCargarDatos()
    End Sub

    Private Sub LPInicializaMaxLength()
        txtCodMoneda1_AN.MaxLength = 3
        txtCodMoneda2_AN.MaxLength = 3
    End Sub

    Private Sub btnAuditoria_Click(sender As Object, e As EventArgs) Handles btnAuditoria.Click
        Dim lsCodigo As String = DataGridView1.Item("valido", DataGridView1.CurrentRow.Index).Value.ToString
        If lsCodigo.Trim.Length = 0 Then Exit Sub

        Dim lsTablaHash() As String = LFsTablaHashPk(lsCodigo).Split(sSF_)
        GPDespliegaBitacoraDatos(lsTablaHash(0), lsTablaHash(1))
    End Sub

    Private Function LFsTablaHashPk(ByVal psCodigo As String) As String
        Dim lsResultado As String = ""
        If psCodigo.Trim.Length > 0 Then
            Dim loDatos As New Eb030cotizaciones
            loDatos.codMoneda1 = txtCodMoneda1_AN.Text
            loDatos.codMoneda2 = txtCodMoneda2_AN.Text
            loDatos.valido = psCodigo
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

End Class