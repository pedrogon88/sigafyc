Imports System.ComponentModel

Public Class frmFzis_moddet
    Private msValidado As String = ""
    Private msRequeridos As String() = {"numord", "origen", "destino", "estado"}
    Private moRequeridos As New ArrayList(msRequeridos)
    Private miNumtra As Integer = 0

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LPBorrarAlCancelar()
        Me.Tag = sCancelar_
        GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en CANCELAR.")
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If InStr(sAGREGAR_ & sMODIFICAR_, Me.Tag.ToString) > 0 Then
            msValidado = ""
            For Each loControl As Control In Me.TabPage1.Controls
                If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                    msValidado &= loControl.Tag.ToString
                End If
            Next

            If InStr(msValidado, sCancelar_) > 0 Then
                GFsAvisar("Validacion final", sMENSAJE_, "No han sido ingresado correctamente todos los datos")
                txtNumTra_NE.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim loDatos As New Ezis_moddet
                        LPTruncaSegunLongitud()
                        loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                        loDatos.numord = Integer.Parse(txtnumord_NE.Text.ToString)
                        loDatos.origen = cmbOrigen.Text
                        loDatos.destino = cmbDestino.Text
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        Try
                            loDatos.Put(sSi_, sSi_, sAGREGAR_)
                            If loDatos.cancelado = sSi_ Then btnCancelar_Click(sender, e)
                        Catch ex As Exception
                            btnCancelar_Click(sender, e)
                            GFsAvisar("Error durante Alta", sMENSAJE_, ex.Message)
                        End Try
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim loDatos As New Ezis_moddet
                        loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                        loDatos.numord = Integer.Parse(txtNumOrd_NE.Text.ToString)
                        If loDatos.GetPK = sOk_ Then
                            LPTruncaSegunLongitud()
                            loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                            loDatos.numord = Integer.Parse(txtNumOrd_NE.Text.ToString)
                            loDatos.origen = cmbOrigen.Text
                            loDatos.destino = cmbDestino.Text
                            If cmbEstado.Text.Trim.Length > 0 Then
                                loDatos.estado = cmbEstado.Text
                            End If
                            loDatos.Put()
                        End If
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                End Select
                Me.Tag = sOk_
                '-->  .AccesibleName envia al Browse la información del codigo que luego deberia 
                '-->  ser usado para la localización del registro en el DataGridView
                Me.AccessibleName = txtNumOrd_NE.Text
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        Else
            If Me.Tag.ToString = sBORRAR_ Then
                Dim loDatos As New Ezis_moddet
                loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                loDatos.numord = Integer.Parse(txtNumOrd_NE.Text.ToString)
                If loDatos.GetPK = sOk_ Then
                    loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                    loDatos.numord = Integer.Parse(txtNumOrd_NE.Text.ToString)
                    loDatos.Del()
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
            End If
            Me.Tag = sOk_
            GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
            Me.Close()
        End If
    End Sub

    Private Sub ManejoEvento_Validating(sender As Object, e As CancelEventArgs)
        If CType(sender, Control).Text.Trim.Length = 0 Then
            If LFsExiste(CType(sender, Control).AccessibleName) = sNo_ Then Exit Sub
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).AccessibleName
                Case "origen"
                    lsValorInicial = ""
                Case "destino"
                    lsValorInicial = ""
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "codmoneda"
            End Select
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoComboBox_ Then
                If CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) = False Then
                    e.Cancel = True
                    CType(sender, Control).Tag = sCancelar_
                End If
            End If
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()

        ' Inicializa los controles de edición con los valores pertinentes
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls
        msEntidad = "Detalle el Modelo de Integración"
        DesplegarMensaje()
        miNumtra = CType(entidad, Ezis_moddet).numtra
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                Dim loDetalle As New Ezis_moddet
                txtNumTra_NE.Text = miNumtra.ToString
                txtNumOrd_NE.Text = loDetalle.ReservarRegistro(miNumtra).ToString
                loDetalle.CerrarConexion()
                loDetalle = Nothing
            Case Else
                txtNumTra_NE.Text = miNumtra.ToString
                txtNumOrd_NE.Text = CType(entidad, Ezis_moddet).numord.ToString
                cmbOrigen.Text = CType(entidad, Ezis_moddet).origen
                cmbDestino.Text = CType(entidad, Ezis_moddet).destino
                cmbEstado.Text = CType(entidad, Ezis_moddet).estado
        End Select
        ' Habilita o deshabilita los controles de edición
        txtNumTra_NE.Enabled = True
        txtNumOrd_NE.Enabled = True
        cmbOrigen.Enabled = True
        cmbDestino.Enabled = True
        cmbEstado.Enabled = True

        txtNumTra_NE.AccessibleName = "numtra"
        txtNumOrd_NE.AccessibleName = "numord"
        cmbOrigen.AccessibleName = "origen"
        cmbDestino.AccessibleName = "destino"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtNumTra_NE.Enabled = False
                txtNumOrd_NE.Enabled = False

            Case sMODIFICAR_
                txtNumTra_NE.Enabled = False
                txtNumOrd_NE.Enabled = False

            Case sCONSULTAR_, sBORRAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb|gbx", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
                loControls = Me.TabPage2.Controls
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb|gbx", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
        End Select

        Dim loDatos As New Ezis_modcab
        loDatos.numtra = miNumtra
        If loDatos.GetPK = sOk_ Then
            If Me.Tag.ToString = sAGREGAR_ Or Me.Tag.ToString = sMODIFICAR_ Then
                LPCargarTablaModulo(loDatos.sentido)
            End If
        End If

    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtNumOrd_NE.Focus()
            Case sMODIFICAR_
                txtNumOrd_NE.Focus()
        End Select
        LPDespliegaDescripciones()
    End Sub

    Private Sub LPDespliegaDescripciones()
    End Sub

    Private Sub LPInicializaMaxLength()
        txtNumTra_NE.MaxLength = 6
        txtNumOrd_NE.MaxLength = 3
        cmbDestino.MaxLength = 64
        cmbDestino.MaxLength = 64
        cmbEstado.MaxLength = 15
    End Sub

    Private Sub LPInicializaControles()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                            AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                        Case sPrefijoComboBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoRadioButton_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                        AddHandler loControl1.KeyPress, AddressOf ManejoEvento_KeyPress
                                    Case sPrefijoComboBox_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                    Case sPrefijoRadioButton_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                End Select
                            Next
                    End Select
                Next
            End If
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

    Private Sub LPBorrarAlCancelar()
        If Me.Tag.ToString <> sAGREGAR_ Then Exit Sub

        Dim loDatos As New Ezis_moddet
        Dim liNumTra As Integer = miNumtra
        Dim liNumORD As Integer = CInt(txtNumOrd_NE.Text.ToString)
        loDatos.numtra = liNumTra
        loDatos.numord = liNumORD
        If loDatos.GetPK = sOk_ Then
            loDatos.numtra = liNumTra
            loDatos.numord = liNumORD
            loDatos.Del(sNo_, sNo_)
        End If
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub LPCargarTablaModulo(Optional ByVal psSentido As String = sZIS_SAPzoho_)
        Dim lsScript As String = ""
        Dim loCabecera As New Ezis_modcab

        loCabecera.numtra = miNumtra
        If loCabecera.GetPK() = sOk_ Then
            lsScript = loCabecera.script
        End If

        Dim loOrigen() As String = Nothing
        Select Case psSentido.ToLower
            Case sZIS_SAPzoho_.ToLower
                lsScript = GFsGeneraSQL(lsScript)
                Dim loConexion As New BaseDatos
                loConexion.SetearParametrosConexion(sRegistryTablasPrincipal_, "OITM")
                loConexion.Conectar("OITM")
                loConexion.CrearComando(lsScript)
                Dim loDataTable As DataTable = loConexion.EjecutarConsultaTable
                Dim loDataColumns As DataColumnCollection = loDataTable.Rows.Item(0).Table.Columns
                cmbOrigen.Items.Clear()
                For Each loDataColumn As DataColumn In loDataColumns
                    cmbOrigen.Items.Add(loDataColumn.ColumnName.ToString)
                Next
            Case sZIS_ZOHOsap_.ToLower
                lsScript = GFsGeneraSQL(lsScript, sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                loOrigen = GFsCOQLExtraeCampos(lsScript).Split(","c)
                Dim liCantidad As Integer = loOrigen.Count
                cmbOrigen.Items.Clear()
                For liPos = 0 To liCantidad - 1
                    cmbOrigen.Items.Add(loOrigen(liPos).ToString.Trim)
                Next
        End Select

        Dim loDato As New Ess040tabdet
        Dim lsCodigo As String = ""

        Select Case psSentido.ToLower
            Case sZIS_SAPzoho_.ToLower
                lsCodigo = GFsParametroObtener(sGeneral_, "Zoho API V2 - Tabla Modulos")
            Case sZIS_ZOHOsap_.ToLower
                lsCodigo = GFsParametroObtener(sGeneral_, "Zoho API V2 - Tabla SAP")
        End Select

        Dim loDestino() As String = Nothing
        loDato.ss010_codigo = SesionActiva.sistema
        loDato.ss030_codigo = lsCodigo
        loDato.codigo = loCabecera.destino
        If loDato.GetPK = sOk_ Then
            Dim loDatos As New Ess040tabdet
            Dim loDataSet As DataSet
            Dim lsWhere As String = "ss010_codigo = '@ss010_codigo' and ss030_codigo = '@ss030_codigo'"
            lsWhere = lsWhere.Replace("@ss010_codigo", SesionActiva.sistema)
            lsWhere = lsWhere.Replace("@ss030_codigo", loDato.nombre)
            Dim lsCampos As String = "codigo, nombre, detalle"
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsCodigo
            Dim lsSQL As String = loDatos.GenerarSQL(lsCampos, "1=1", lsWhere)
            loDataSet = loDatos.RecuperarTabla(lsSQL)
            Dim loDataTableReader As DataTableReader = loDataSet.Tables.Item(0).CreateDataReader()
            cmbDestino.Items.Clear()
            Do While loDataTableReader.Read()
                cmbDestino.Items.Add(loDataTableReader.Item("codigo").ToString.Trim)
            Loop
        End If
    End Sub

End Class