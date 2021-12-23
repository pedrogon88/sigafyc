Imports System.ComponentModel

Public Class frmFzis_modcab
    Private msValidado As String = ""
    Private msRequeridos As String() = {"numtra", "nombre", "abreviado", "sentido", "script", "tipodato", "destino", "findby", "campopk"}
    Private moRequeridos As New ArrayList(msRequeridos)
    Private msCodMoneda As String = ""
    Private moColor As Color

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
                        Dim loDatos As New Ezis_modcab
                        LPTruncaSegunLongitud()
                        loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                        loDatos.nombre = txtNombre_AN.Text
                        loDatos.abreviado = txtAbreviado_AN.Text
                        loDatos.sentido = cmbSentido.Text
                        loDatos.script = txtScript_AN.Text
                        loDatos.tipodato = cmbTipoDato.Text
                        loDatos.destino = cmbDestino.Text
                        loDatos.findby = cmbFindBy.Text
                        loDatos.campopk = cmbCampoPK.Text
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
                        Dim loDatos As New Ezis_modcab
                        loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                        If loDatos.GetPK = sOk_ Then
                            LPTruncaSegunLongitud()
                            loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                            loDatos.nombre = txtNombre_AN.Text
                            loDatos.abreviado = txtAbreviado_AN.Text
                            loDatos.sentido = cmbSentido.Text
                            loDatos.script = txtScript_AN.Text
                            loDatos.tipodato = cmbTipoDato.Text
                            loDatos.destino = cmbDestino.Text
                            loDatos.findby = cmbFindBy.Text
                            loDatos.campopk = cmbCampoPK.Text
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
                Me.AccessibleName = txtNumTra_NE.Text
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        Else
            If Me.Tag.ToString = sBORRAR_ Then
                Dim loDatos As New Ezis_modcab
                loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                If loDatos.GetPK = sOk_ Then
                    loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
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
            CType(sender, Control).Tag = sCancelar_
            Select Case CType(sender, Control).AccessibleName
                Case "nombre"
                    lsValorInicial = "Descripcion Modelo No. " & txtNumTra_NE.Text
                    CType(sender, Control).Tag = sOk_
                Case "abreviado"
                    lsValorInicial = "Abrev. Mod.No. " & txtNumTra_NE.Text
                    CType(sender, Control).Tag = sOk_
                Case "sentido"
                    lsValorInicial = sZIS_SAPzoho_
                Case "script"
                    lsValorInicial = ""
                Case "destino"
                    lsValorInicial = ""
            End Select
            CType(sender, Control).Text = lsValorInicial
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "script"
                    If cmbSentido.Text.ToLower = sZIS_SAPzoho_.ToLower Then
                        If GFsGeneraSQL(txtScript_AN.Text.Trim.ToUpper) = sRESERVADO_ Then
                            GFsAvisar("Query SQL [" & txtScript_AN.Text.Trim.ToUpper & "] aun no definido", sMENSAJE_, "Favor providencie esto para continuar")
                            e.Cancel = True
                        Else
                            CType(sender, Control).Tag = sOk_
                        End If
                    Else
                        If GFsGeneraSQL(txtScript_AN.Text.Trim.ToUpper, sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_) = sRESERVADO_ Then
                            GFsAvisar("Query COQL [" & txtScript_AN.Text.Trim.ToUpper & "] aun no definido", sMENSAJE_, "Favor providencie esto para continuar")
                            e.Cancel = True
                        Else
                            CType(sender, Control).Tag = sOk_
                        End If
                    End If
            End Select
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoComboBox_ Then
                If CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) = False Then
                    e.Cancel = True
                    CType(sender, Control).Tag = sCancelar_
                Else
                    CType(sender, Control).Tag = sOk_
                End If
            End If
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()

        ' Inicializa los controles de edición con los valores pertinentes
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls
        msEntidad = "Cabecera al Modelo Integración"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                Dim loDatos As New Ezis_modcab
                txtNumTra_NE.Text = loDatos.ReservarRegistro().ToString
                loDatos.CerrarConexion()
                loDatos = Nothing
            Case Else
                txtNumTra_NE.Text = CType(entidad, Ezis_modcab).numtra.ToString
                txtNombre_AN.Text = CType(entidad, Ezis_modcab).nombre
                txtAbreviado_AN.Text = CType(entidad, Ezis_modcab).abreviado
                cmbSentido.Text = CType(entidad, Ezis_modcab).sentido
                txtScript_AN.Text = CType(entidad, Ezis_modcab).script
                cmbTipoDato.Text = CType(entidad, Ezis_modcab).tipodato
                cmbDestino.Text = CType(entidad, Ezis_modcab).destino
                cmbFindBy.Text = CType(entidad, Ezis_modcab).findby
                cmbCampoPK.Text = CType(entidad, Ezis_modcab).campopk
                cmbEstado.Text = CType(entidad, Ezis_modcab).estado
        End Select
        ' Habilita o deshabilita los controles de edición
        txtNumTra_NE.Enabled = True
        txtNombre_AN.Enabled = True
        txtAbreviado_AN.Enabled = True
        cmbSentido.Enabled = True
        txtScript_AN.Enabled = True
        cmbTipoDato.Enabled = True
        cmbDestino.Enabled = True
        cmbFindBy.Enabled = True
        cmbCampoPK.Enabled = True
        cmbEstado.Enabled = True

        txtNumTra_NE.AccessibleName = "numtra"
        txtNombre_AN.AccessibleName = "nombre"
        txtAbreviado_AN.AccessibleName = "abreviado"
        cmbSentido.AccessibleName = "sentido"
        txtScript_AN.AccessibleName = "script"
        cmbTipoDato.AccessibleName = "tipodato"
        cmbDestino.AccessibleName = "destino"
        cmbFindBy.AccessibleName = "findby"
        cmbCampoPK.AccessibleName = "campopk"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtNumTra_NE.Enabled = False

            Case sMODIFICAR_
                txtNumTra_NE.Enabled = False

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
        If cmbDestino.Text.ToString.Trim.Length > 0 And cmbSentido.Text.ToString.Trim.Length > 0 Then
            LPCargarTablaModulo(cmbDestino.Text, cmbSentido.Text)
            LPCargarComboBox(cmbDestino.Text, cmbSentido.Text)
        End If

    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtNombre_AN.Focus()
            Case sMODIFICAR_
                txtNombre_AN.Focus()
        End Select
        LPDespliegaDescripciones()
    End Sub

    Private Sub LPDespliegaDescripciones()
    End Sub

    Private Sub LPInicializaMaxLength()
        txtNumTra_NE.MaxLength = 6
        txtNombre_AN.MaxLength = 120
        txtAbreviado_AN.MaxLength = 30
        cmbSentido.MaxLength = 15
        txtScript_AN.MaxLength = 128
        cmbTipoDato.MaxLength = 15
        cmbDestino.MaxLength = 128
        cmbFindBy.MaxLength = 15
        cmbCampoPK.MaxLength = 50
        cmbEstado.MaxLength = 15
    End Sub

    Private Sub LPInicializaControles()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                            AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                        Case sPrefijoComboBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoRadioButton_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        AddHandler loControl1.Validating, AddressOf ManejoEvento_Validating
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                        AddHandler loControl1.KeyPress, AddressOf ManejoEvento_KeyPress
                                    Case sPrefijoComboBox_
                                        AddHandler loControl1.Validating, AddressOf ManejoEvento_Validating
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                    Case sPrefijoRadioButton_
                                        AddHandler loControl1.Validating, AddressOf ManejoEvento_Validating
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

        Dim loDatos As New Ezis_modcab
        Dim liNumTra As Integer = CInt(txtNumTra_NE.Text.ToString)
        loDatos.numtra = liNumTra
        If loDatos.GetPK = sOk_ Then
            loDatos.numtra = liNumTra
            loDatos.Del(sNo_, sNo_)
        End If
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub cmbSentido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSentido.SelectedIndexChanged
        If cmbSentido.Text.ToLower = sZIS_SAPzoho_.ToLower Then
            lblDestino.Text = "Modulo destino:"
        Else
            lblDestino.Text = "Tabla destino:"
        End If
        LPCargarTablaModulo(cmbDestino.Text, cmbSentido.Text)
        LPCargarComboBox(cmbDestino.Text, cmbSentido.Text)
    End Sub

    Private Sub LPCargarTablaModulo(ByVal psModulo As String, ByVal psSentido As String)
        Dim lsTipo As String = sGeneral_
        Dim lsClave As String = ""
        Select Case psSentido.ToLower
            Case sZIS_SAPzoho_.ToLower
                lsClave = "Zoho API V2 - Tabla Modulos"
            Case sZIS_ZOHOsap_.ToLower
                lsClave = "Zoho API V2 - Tabla SAP"
        End Select
        Dim lsCodigo As String = GFsParametroObtener(lsTipo, lsClave)

        Dim loDatos As New Ess040tabdet
        Dim loDataSet As DataSet
        Dim lsWhere As String = "ss010_codigo = '@ss010_codigo' and ss030_codigo = '@ss030_codigo'"
        lsWhere = lsWhere.Replace("@ss010_codigo", SesionActiva.sistema)
        lsWhere = lsWhere.Replace("@ss030_codigo", lsCodigo)
        Dim lsCampos As String = "codigo, nombre, detalle"
        loDatos.ss010_codigo = SesionActiva.sistema
        loDatos.ss030_codigo = lsCodigo
        Dim lsSQL As String = loDatos.GenerarSQL(lsCampos, "1=1", lsWhere)
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        Dim loDataTableReader As DataTableReader = loDataSet.Tables.Item(0).CreateDataReader
        cmbDestino.Items.Clear()
        Do While loDataTableReader.Read()
            cmbDestino.Items.Add(loDataTableReader.Item("codigo"))
        Loop
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub LPCargarComboBox(ByVal psModulo As String, ByVal psSentido As String)

        Select Case psSentido.ToLower
            Case sZIS_SAPzoho_.ToLower
                cmbTipoDato.Items.Clear()
                cmbTipoDato.Items.Add("MAESTRO")
                cmbTipoDato.Items.Add("RELACION")
                cmbTipoDato.Items.Add("SUBFORM")

                cmbFindBy.Items.Clear()
                cmbFindBy.Items.Add(sZIS_Search_)
                cmbFindBy.Items.Add(sZIS_ZohoId_)
                cmbFindBy.Items.Add(sZIS_External_)

            Case sZIS_ZOHOsap_.ToLower
                cmbTipoDato.Items.Clear()
                cmbTipoDato.Items.Add("MAESTRO")
                cmbTipoDato.Items.Add("OPERACION")

                cmbFindBy.Items.Clear()
                cmbFindBy.Items.Add("PK")
        End Select
        LPCargarCampoPK(psModulo, psSentido)
    End Sub

    Private Sub LPCargarCampoPK(ByVal psModulo As String, Optional ByVal psSentido As String = sZIS_SAPzoho_)
        Dim lsTipo As String = sGeneral_
        Dim lsClave As String = ""
        Select Case psSentido.ToLower
            Case sZIS_SAPzoho_.ToLower
                lsClave = "Zoho API V2 - Tabla Campos X " & psModulo
            Case sZIS_ZOHOsap_.ToLower
                lsClave = "Zoho API V2 - Tabla SAP Campos X " & psModulo
        End Select
        Dim lsCodigo As String = GFsParametroObtener(lsTipo, lsClave)

        Dim loDatos As New Ess040tabdet
        Dim loDataSet As DataSet
        Dim lsWhere As String = "ss010_codigo = '@ss010_codigo' and ss030_codigo = '@ss030_codigo'"
        lsWhere = lsWhere.Replace("@ss010_codigo", SesionActiva.sistema)
        lsWhere = lsWhere.Replace("@ss030_codigo", lsCodigo)
        Dim lsCampos As String = "codigo, nombre, detalle"
        loDatos.ss010_codigo = SesionActiva.sistema
        loDatos.ss030_codigo = lsCodigo
        Dim lsSQL As String = loDatos.GenerarSQL(lsCampos, "1=1", lsWhere)
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        Dim loDataTableReader As DataTableReader = loDataSet.Tables.Item(0).CreateDataReader
        cmbCampoPK.Items.Clear()
        Do While loDataTableReader.Read()
            cmbCampoPK.Items.Add(loDataTableReader.Item("codigo"))
        Loop
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub cmbDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDestino.SelectedIndexChanged
        LPCargarCampoPK(cmbDestino.Text, cmbSentido.Text)
    End Sub

    Private Sub cmbFindBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFindBy.SelectedIndexChanged
        LPCargarCampoPK(cmbDestino.Text, cmbSentido.Text)
    End Sub
End Class