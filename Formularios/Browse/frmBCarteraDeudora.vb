Imports System.ComponentModel
Imports System.Globalization

Public Class frmBCarteraDeudora
    Private moFormulario As frmFoitmc1
    Private msStock As String = ""
    Private msTabla As String = ""
    Private msPk_Hash As String = ""
    Private mbAgregar As Boolean
    Private mbModificar As Boolean
    Private mbBorrar As Boolean
    Private mbConsultar As Boolean
    Private mbDetalle As Boolean
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
        PictureBox1.Visible = False

        LPInicializaMaxLength()

        mbAgregar = btnAgregar.Enabled
        mbModificar = btnModificar.Enabled
        mbBorrar = btnBorrar.Enabled
        mbConsultar = btnConsultar.Enabled
        mbDetalle = btnDetalle.Enabled
        mbAuditoria = btnAuditoria.Enabled

        LPHabilitaControles()

        btnAgregar.AccessibleName = sAGREGAR_
        btnModificar.AccessibleName = sMODIFICAR_
        btnBorrar.AccessibleName = sBORRAR_
        btnDetalle.AccessibleName = "Ver Detalle"
        btnAuditoria.AccessibleName = "Ver Auditoria"
        btnConsultar.AccessibleName = sCONSULTAR_

        AddHandler txtBuscar.TextChanged, AddressOf BuscarClave
        AddHandler btnAgregar.Click, AddressOf Botones_Click
        AddHandler btnModificar.Click, AddressOf Botones_Click
        AddHandler btnBorrar.Click, AddressOf Botones_Click
        AddHandler btnConsultar.Click, AddressOf Botones_Click
        AddHandler txtStock_AN.KeyPress, AddressOf ManejoEvento_KeyPress
        AddHandler txtStock_AN.KeyDown, AddressOf ManejoEvento_KeyDown
        AddHandler DataGridView1.KeyDown, AddressOf DataGrid_KeyDown
        AddHandler DataGridView1.CellContentDoubleClick, AddressOf DataGrid_DoubleClick

        DataGridView1.ContextMenuStrip = mnuExportarExcel

        AddHandler MenuItem_ExportarExcel.Click, AddressOf ExportarExcel_Click
        AddHandler MenuItem_ExportarTexto.Click, AddressOf ExportarTexto_Click

        lblMarcaModelo.Text = ""
        mbabrirform = False
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub LPCargarDatos()
        Dim loDataFunc As DataSet = Nothing
        Dim loFuncEscalar As New Eoitmc1
        Dim lsSQL As String = GFsGeneraSQL("frmBCarteraPeriodoVigente")
        Dim lsPeriodo As String = ""
        loDataFunc = loFuncEscalar.RecuperarTabla(lsSQL)
        lsPeriodo = loDataFunc.Tables(0).Rows(0).Item(0).ToString
        Dim loDatos As New Eoitmc1
        Dim loDataSet As DataSet
        lsSQL = GFsGeneraSQL("frmBCarteraDeudora")
        Dim lsConcatFiltro As String = "codcliente, nomcliente, abogado, empresa, sucursal, periodofac"
        Dim lsFiltro As String = sFiltroSentencia_
        lsFiltro = lsFiltro.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text = txtBuscar.Tag.ToString Then
            lsFiltro = lsFiltro.Replace(sFiltroValor_, "")
        Else
            lsFiltro = lsFiltro.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        lsSQL = lsSQL.Replace("@periodo", lsPeriodo)
        lsSQL = lsSQL.Replace("@stock", msStock)
        lsSQL = lsSQL.Replace("@filtro", lsFiltro)
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView1.DataSource = loDataSet
        DataGridView1.DataMember = loDatos.tableName
        If msLocalizar IsNot Nothing Then LPLocalizaRegistro(msLocalizar)

        msTabla = loDatos.tableName
        miCantidad = loDataSet.Tables.Item(0).Rows.Count
        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
        loDataFunc = Nothing
        loFuncEscalar.Desconectar()

        LPSinRegistro_AbrirForm()
        LPHabilitaControles()
    End Sub

    Private Overloads Sub LPHabilitaControles()
        If miCantidad <= 0 Then
            If miCantidad = -9999 Then
                btnAgregar.Enabled = False
                btnBorrar.Enabled = False
                btnModificar.Enabled = False
                btnConsultar.Enabled = False
                btnDetalle.Enabled = False
                btnAuditoria.Enabled = False
            Else
                btnAgregar.Enabled = mbAgregar
            End If
        Else
            btnAgregar.Enabled = mbAgregar
            btnBorrar.Enabled = mbBorrar
            btnModificar.Enabled = mbModificar
            btnConsultar.Enabled = mbConsultar
            btnDetalle.Enabled = mbDetalle
            btnAuditoria.Enabled = mbAuditoria
        End If
        PictureBox1.Visible = False
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If GFsGeneraSQL("frmBCarteraDeudora") = sRESERVADO_ Then
            GFsAvisar("El query SQL para este Browse", sMENSAJE_, "aun no ha sido definido. Consulte con el Dpto. Informatica")
            Me.Close()
        Else
            txtStock_AN.Focus()
        End If
    End Sub

    Private Sub LPLocalizaRegistro(ByVal psCodigo As String)
        ' Este procedimiento realiza la busqueda del parametro
        ' a fin de ubicarlo dentro del DataGridView
        '--------------------------------------------------------------------
        If psCodigo.Trim.Length = 0 Then Exit Sub

        Dim liIndex As Integer = -1
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("codcliente").Value.ToString = psCodigo Then
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

    Private Sub txtStock_AN_Validating(sender As Object, e As CancelEventArgs) Handles txtStock_AN.Validating
        Try
            PictureBox1.Visible = True
            Me.Refresh()
            Dim loFK As New Eoitm
            Me.Refresh()
            txtStock_AN.Text = txtStock_AN.Text.ToUpper
            msStock = txtStock_AN.Text.ToUpper
            If msStock.Trim.Length = 0 Then
                GFsAvisar("No puede dejar de especificar el codigo STOCK", sMENSAJE_, "Por favor intentelo de nuevo.")
                btnSalir.Focus()
                Exit Sub
            End If

            Me.Refresh()
            If Not loFK.GetPK(msStock) Then
                PictureBox1.Visible = False
                GFsAvisar("El codigo de STOCK ingresado no es valido", sMENSAJE_, "Por favor intentelo de nuevo.")
                'e.Cancel = True
                'Exit Sub
            End If
            Me.Refresh()
            loFK.Desconectar()
            Me.Refresh()
            LPDespliegaDescripciones()
            Me.Refresh()
            LPCargarDatos()

        Catch ex As Exception
            PictureBox1.Visible = False
            e.Cancel = True

        End Try
    End Sub

    Private Sub Botones_Click(sender As Object, e As EventArgs)
        Dim loDatos As New Eoitmc1
        loDatos.ItemCode = msStock
        Select Case CType(sender, Button).AccessibleName
            Case sAGREGAR_
                If DataGridView1.CurrentRow Is Nothing Then Exit Sub
                '---------------------------------------------------------------------------------------------
                Dim lsConSeguimiento As String = DataGridView1.Item("conseguimiento", DataGridView1.CurrentRow.Index).Value.ToString
                If lsConSeguimiento.Trim.Length = 0 Then Exit Sub
                If lsConSeguimiento = "SI" Then Exit Sub

                Dim lsCodigo As String = DataGridView1.Item("codcliente", DataGridView1.CurrentRow.Index).Value.ToString
                If lsCodigo.Trim.Length = 0 Then Exit Sub
                Dim lsDesStock As String = DataGridView1.Item("desstock", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsAbogado As String = DataGridView1.Item("abogado", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsInicialesAbog As String = DataGridView1.Item("inicialesabog", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsEmpresa As String = DataGridView1.Item("empresa", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsSucursal As String = DataGridView1.Item("sucursal", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsPeriodoFac As String = DataGridView1.Item("periodofac", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsSaldoUSD As String = DataGridView1.Item("saldousd", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsVentaUSD As String = DataGridView1.Item("ventausd", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsPagosUSD As String = DataGridView1.Item("pagosusd", DataGridView1.CurrentRow.Index).Value.ToString
                moFormulario = New frmFoitmc1
                moFormulario.Tag = CType(sender, Button).AccessibleName
                moFormulario.desStock = lsDesStock
                loDatos.ItemCode = txtStock_AN.Text
                loDatos.CardCode = lsCodigo
                loDatos.U_Abogado = lsAbogado
                loDatos.U_InicialesAbog = lsInicialesAbog
                loDatos.Empresa = lsEmpresa
                loDatos.Sucursal = lsSucursal
                loDatos.PeriodoFac = lsPeriodoFac
                loDatos.SaldoUSD = Decimal.Parse(lsSaldoUSD)
                loDatos.VentaUSD = Decimal.Parse(lsVentaUSD)
                loDatos.PagosUSD = Decimal.Parse(lsPagosUSD)
                moFormulario.entidad = loDatos
                GPCargar(moFormulario)
                msLocalizar = moFormulario.AccessibleName
                moFormulario = Nothing
            Case Else
                If DataGridView1.CurrentRow Is Nothing Then Exit Sub
                '---------------------------------------------------------------------------------------------
                Dim lsConSeguimiento As String = DataGridView1.Item("conseguimiento", DataGridView1.CurrentRow.Index).Value.ToString
                If lsConSeguimiento.Trim.Length = 0 Then Exit Sub
                If lsConSeguimiento = "NO" Then
                    GFsAvisar("No puede [" & CType(sender, Button).AccessibleName & "] cuando No tiene seguimiento", sMENSAJE_, "intentelo de nuevo..")
                    Exit Sub
                End If
                '----------------------------------------------------------------------------------------------
                If CType(sender, Button).AccessibleName = sBORRAR_ Then
                    Dim lsComentario As String = DataGridView1.Item("comentario", DataGridView1.CurrentRow.Index).Value.ToString
                    If lsComentario <> "*** SIN COMENTARIO ***" Then
                        GFsAvisar("No puede [" & CType(sender, Button).AccessibleName & "] cuando ya tiene comentarios asociados", sMENSAJE_, "intentelo de nuevo..")
                        Exit Sub
                    End If
                End If
                '----------------------------------------------------------------------------------------------
                Dim lsCodigo As String = DataGridView1.Item("codcliente", DataGridView1.CurrentRow.Index).Value.ToString
                If lsCodigo.Trim.Length = 0 Then Exit Sub
                Dim lsDesStock As String = DataGridView1.Item("desstock", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsAbogado As String = DataGridView1.Item("abogado", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsInicialesAbog As String = DataGridView1.Item("inicialesabog", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsEmpresa As String = DataGridView1.Item("empresa", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsSucursal As String = DataGridView1.Item("sucursal", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsPeriodoFac As String = DataGridView1.Item("periodofac", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsSaldoUSD As String = DataGridView1.Item("saldousd", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsVentaUSD As String = DataGridView1.Item("ventausd", DataGridView1.CurrentRow.Index).Value.ToString
                Dim lsPagosUSD As String = DataGridView1.Item("pagosusd", DataGridView1.CurrentRow.Index).Value.ToString

                Dim lsTablaHash As String = LFsTablaHashPk(lsCodigo)
                If lsTablaHash.Trim.Length = 0 Then Exit Sub

                '---------------------------------------------------------------------------------------------
                Dim lsParte() As String = lsTablaHash.Split(sSF_)
                If GFbPuedeModificarBorrar(CType(sender, Button).AccessibleName, lsParte(0), lsParte(1), lsCodigo) = False Then Exit Sub
                Try
                    loDatos.ItemCode = txtStock_AN.Text
                    loDatos.CardCode = lsCodigo
                    If loDatos.GetPK = sOk_ Then
                        loDatos.U_Abogado = lsAbogado
                        loDatos.U_InicialesAbog = lsInicialesAbog
                        loDatos.Empresa = lsEmpresa
                        loDatos.Sucursal = lsSucursal
                        loDatos.PeriodoFac = lsPeriodoFac
                        loDatos.SaldoUSD = Decimal.Parse(lsSaldoUSD)
                        loDatos.VentaUSD = Decimal.Parse(lsVentaUSD)
                        loDatos.PagosUSD = Decimal.Parse(lsPagosUSD)

                        If Me.Tag.ToString = sELEGIR_ And CType(sender, Button).AccessibleName = sCONSULTAR_ Then
                            entidad = loDatos
                            SendKeys.Send("%(s)")
                            Exit Sub
                        End If

                        moFormulario = New frmFoitmc1
                        moFormulario.AccessibleName = "stock: " & loDatos.ItemCode & "/cod.cliente: " & loDatos.CardCode
                        moFormulario.Tag = CType(sender, Button).AccessibleName
                        moFormulario.desStock = lsDesStock
                        moFormulario.entidad = loDatos
                        GPCargar(moFormulario)
                        msLocalizar = moFormulario.AccessibleName
                        moFormulario = Nothing
                    End If
                Catch ex As Exception
                    GFsAvisar("Error en Browse", sError_, "No existe datos para el codigo menu [" & loDatos.ItemCode & "]" & ControlChars.CrLf & ex.Message)
                End Try
        End Select
        loDatos.CerrarConexion()
        loDatos = Nothing
        LPCargarDatos()
    End Sub

    Private Sub LPInicializaMaxLength()
        txtStock_AN.MaxLength = 15
    End Sub

    Private Sub LPDespliegaDescripciones()
        lblMarcaModelo.Text = ""
        If txtStock_AN.Text.Trim.Length > 0 Then
            Dim loFK As New Eoitm
            Dim msCadena As String

            If loFK.GetPK(txtStock_AN.Text) Then
                lblMarcaModelo.Text = ""
                msCadena = loFK.GetAtributo("U_marca")
                If msCadena.Trim.Length > 0 Then
                    lblMarcaModelo.Text = "Marca:" & msCadena
                End If
                msCadena = loFK.GetAtributo("U_modelo")
                If msCadena.Trim.Length > 0 Then
                    If lblMarcaModelo.Text.Trim.Length = 0 Then
                        lblMarcaModelo.Text = "Modelo:" & msCadena
                    Else
                        lblMarcaModelo.Text &= ", Modelo:" & msCadena
                    End If
                End If
                msCadena = loFK.GetAtributo("U_anh0")
                If msCadena.Trim.Length > 0 Then
                    If lblMarcaModelo.Text.Trim.Length = 0 Then
                        lblMarcaModelo.Text = "Año:" & msCadena
                    Else
                        lblMarcaModelo.Text &= ", Año:" & msCadena
                    End If
                End If
            End If
            loFK.Desconectar()
        End If
    End Sub

    Private Sub btnAuditoria_Click(sender As Object, e As EventArgs) Handles btnAuditoria.Click
        Dim lsConSeguimiento As String = DataGridView1.Item("conseguimiento", DataGridView1.CurrentRow.Index).Value.ToString
        If lsConSeguimiento.Trim.Length = 0 Then Exit Sub
        If lsConSeguimiento = "NO" Then
            GFsAvisar("No puede [" & CType(sender, Button).AccessibleName & "] cuando No tiene seguimiento", sMENSAJE_, "intentelo de nuevo..")
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------------
        Dim lsCodigo As String = DataGridView1.Item("codcliente", DataGridView1.CurrentRow.Index).Value.ToString
        If lsCodigo.Trim.Length = 0 Then Exit Sub

        Dim lsTablaHash() As String = LFsTablaHashPk(lsCodigo).Split(sSF_)
        GPDespliegaBitacoraDatos(lsTablaHash(0), lsTablaHash(1))
    End Sub

    Private Function LFsTablaHashPk(ByVal psCodigo As String) As String
        Dim lsResultado As String = ""
        If psCodigo.Trim.Length > 0 Then
            Dim loDatos As New Eoitmc1
            loDatos.ItemCode = txtStock_AN.Text
            loDatos.CardCode = psCodigo
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
            If mbabrirform = False Then
                mbabrirform = True
                SendKeys.Send("%(a)")
            End If
        End If
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Dim lsConSeguimiento As String = DataGridView1.Item("conseguimiento", DataGridView1.CurrentRow.Index).Value.ToString
        If lsConSeguimiento.Trim.Length = 0 Then Exit Sub
        If lsConSeguimiento = "NO" Then
            GFsAvisar("No puede [" & CType(sender, Button).AccessibleName & "] cuando No tiene seguimiento", sMENSAJE_, "intentelo de nuevo..")
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------------
        Dim loBrowseDetalle As New frmBCarteraDeudoraDetalle
        loBrowseDetalle.ItemCode = msStock
        loBrowseDetalle.CardCode = DataGridView1.Item("codcliente", DataGridView1.CurrentRow.Index).Value.ToString
        GPCargar(loBrowseDetalle)
        loBrowseDetalle = Nothing
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        Dim loRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim loSaldoUSD As DataGridViewColumn = DataGridView1.Columns.Item("saldousd")
        Dim loVentaUSD As DataGridViewColumn = DataGridView1.Columns.Item("ventausd")
        Dim loPagosUSD As DataGridViewColumn = DataGridView1.Columns.Item("pagosusd")

        If e.ColumnIndex = loSaldoUSD.Index Then
            If Double.Parse(e.Value.ToString) = 0 Then
                e.Value = ""
            Else
                e.Value = CDec(e.Value).ToString("0.00")
            End If
            e.FormattingApplied = True
        End If

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
    End Sub
End Class