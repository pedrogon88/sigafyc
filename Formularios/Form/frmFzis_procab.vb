Imports System.ComponentModel

Public Class frmFzis_procab
    Private msValidado As String = ""
    Private msRequeridos As String() = {"numtra", "nombre", "abreviado", "formproc", "tipexec", "tipact", "undtmp", "tiempo"}
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
                        Dim loDatos As New Ezis_procab
                        LPTruncaSegunLongitud()
                        loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                        loDatos.nombre = txtNombre_AN.Text
                        loDatos.abreviado = txtAbreviado_AN.Text
                        loDatos.formproc = cmbFormProc.Text
                        loDatos.tipexec = cmbTipExec.Text
                        loDatos.tipact = cmbTipAct.Text
                        loDatos.undtmp = cmbUndTmp.Text
                        loDatos.tiempo = CInt(txtTiempo_NE.Text)
                        loDatos.start = Now.ToString(sFormatoFechaHora1_)
                        loDatos.ending = loDatos.start
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
                        Dim loDatos As New Ezis_procab
                        loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                        If loDatos.GetPK = sOk_ Then
                            LPTruncaSegunLongitud()
                            loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                            loDatos.nombre = txtNombre_AN.Text
                            loDatos.abreviado = txtAbreviado_AN.Text
                            loDatos.formproc = cmbFormProc.Text
                            loDatos.tipexec = cmbTipExec.Text
                            loDatos.tipact = cmbTipAct.Text
                            loDatos.undtmp = cmbUndTmp.Text
                            loDatos.tiempo = CInt(txtTiempo_NE.Text)
                            loDatos.start = txtStart.Text
                            loDatos.ending = txtEnding.Text
                            If cmbEstado.Text.Trim.Length > 0 Then
                                loDatos.estado = cmbEstado.Text
                            End If
                            Try
                                loDatos.Put()
                            Catch ex As Exception
                                GFsAvisar("Error: " & ex.Message, sMENSAJE_)
                            End Try
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
                Dim loDatos As New Ezis_procab
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
        Dim lsValorInicial As String = ""
        If CType(sender, Control).Text.Trim.Length = 0 Then
            If LFsExiste(CType(sender, Control).AccessibleName) = sNo_ Then Exit Sub
            CType(sender, Control).Tag = sCancelar_
            Select Case CType(sender, Control).AccessibleName
                Case "nombre"
                    lsValorInicial = "Descripcion Proceso No. " & txtNumTra_NE.Text
                    CType(sender, Control).Tag = sOk_
                Case "abreviado"
                    lsValorInicial = "Abrev. Proc.No. " & txtNumTra_NE.Text
                    CType(sender, Control).Tag = sOk_
                Case "formproc"
                    lsValorInicial = cmbFormProc.Items(0).ToString
                    CType(sender, Control).Tag = sOk_
                Case "tipexec"
                    lsValorInicial = cmbTipExec.Items(0).ToString
                    CType(sender, Control).Tag = sOk_
                Case "tipact"
                    lsValorInicial = cmbTipAct.Items(0).ToString
                    CType(sender, Control).Tag = sOk_
                Case "undtmp"
                    lsValorInicial = cmbUndTmp.Items(0).ToString
                    CType(sender, Control).Tag = sOk_
                Case "tiempo"
                    lsValorInicial = "1"
                    CType(sender, Control).Tag = sOk_
            End Select
            CType(sender, Control).Text = lsValorInicial
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "tiempo"
                    If CType(sender, TextBox).Text = "0" Then
                        CType(sender, TextBox).Text = "1"
                        e.Cancel = True
                    End If
                Case "formproc"
                    If cmbFormProc.Text = sManual_ Then
                        cmbUndTmp.Items.Add(sManual_)
                        cmbUndTmp.Text = sManual_
                        txtTiempo_NE.Text = "0"
                        lblFrecuencia.Visible = False
                        cmbUndTmp.Visible = False
                        txtTiempo_NE.Visible = False
                    Else
                        If cmbUndTmp.Items.Contains(sManual_) = True Then
                            cmbUndTmp.Items.Remove(sManual_)
                        End If
                        lblFrecuencia.Visible = True
                        cmbUndTmp.Visible = True
                        txtTiempo_NE.Visible = True
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
        msEntidad = "Cabecera Proceso Integración"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                Dim loDatos As New Ezis_procab
                txtNumTra_NE.Text = loDatos.ReservarRegistro().ToString
                loDatos.CerrarConexion()
                loDatos = Nothing
            Case Else
                txtNumTra_NE.Text = CType(entidad, Ezis_procab).numtra.ToString
                txtNombre_AN.Text = CType(entidad, Ezis_procab).nombre
                txtAbreviado_AN.Text = CType(entidad, Ezis_procab).abreviado
                cmbFormProc.Text = CType(entidad, Ezis_procab).formproc
                cmbTipExec.Text = CType(entidad, Ezis_procab).tipexec
                cmbTipAct.Text = CType(entidad, Ezis_procab).tipact
                cmbUndTmp.Text = CType(entidad, Ezis_procab).undtmp
                txtTiempo_NE.Text = CType(entidad, Ezis_procab).tiempo.ToString
                txtStart.Text = CType(entidad, Ezis_procab).start
                txtEnding.Text = CType(entidad, Ezis_procab).ending
                cmbEstado.Text = CType(entidad, Ezis_procab).estado
        End Select
        ' Habilita o deshabilita los controles de edición
        txtNumTra_NE.Enabled = True
        txtNombre_AN.Enabled = True
        txtAbreviado_AN.Enabled = True
        cmbFormProc.Enabled = True
        cmbTipExec.Enabled = True
        cmbTipAct.Enabled = True
        cmbUndTmp.Enabled = True
        txtTiempo_NE.Enabled = True
        cmbEstado.Enabled = True

        txtNumTra_NE.AccessibleName = "numtra"
        txtNombre_AN.AccessibleName = "nombre"
        txtAbreviado_AN.AccessibleName = "abreviado"
        cmbFormProc.AccessibleName = "formproc"
        cmbTipExec.AccessibleName = "tipexec"
        cmbTipAct.AccessibleName = "tipact"
        cmbUndTmp.AccessibleName = "undtmp"
        txtTiempo_NE.AccessibleName = "tiempo"
        cmbEstado.AccessibleName = "estado"

        If cmbFormProc.Text = sManual_ Then
            lblFrecuencia.Visible = False
            cmbUndTmp.Visible = False
            txtTiempo_NE.Visible = False
        Else
            lblFrecuencia.Visible = True
            cmbUndTmp.Visible = True
            txtTiempo_NE.Visible = True
        End If

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
        If txtStart.Text.Trim.Length = 0 Then
            txtStart.Visible = False
        Else
            txtStart.Visible = True
        End If
        txtEnding.Visible = txtStart.Visible
        lblStart.Visible = txtStart.Visible
        lblEnding.Visible = txtEnding.Visible
    End Sub

    Private Sub LPInicializaMaxLength()
        txtNumTra_NE.MaxLength = 6
        txtNombre_AN.MaxLength = 120
        txtAbreviado_AN.MaxLength = 30
        cmbFormProc.MaxLength = 15
        cmbTipExec.MaxLength = 15
        cmbTipAct.MaxLength = 15
        cmbUndTmp.MaxLength = 15
        txtTiempo_NE.MaxLength = 4
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

        Dim loDatos As New Ezis_procab
        Dim liNumTra As Integer = CInt(txtNumTra_NE.Text.ToString)
        loDatos.numtra = liNumTra
        If loDatos.GetPK = sOk_ Then
            loDatos.numtra = liNumTra
            loDatos.Del(sNo_, sNo_)
        End If
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub
End Class