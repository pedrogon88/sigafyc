Imports System.ComponentModel

Public Class frmFzis_prodet
    Private msValidado As String = ""
    Private msRequeridos As String() = {"numord", "nummod", "formact", "start", "ending"}
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
                        Dim loDatos As New Ezis_prodet
                        LPTruncaSegunLongitud()
                        loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                        loDatos.numord = Integer.Parse(txtNumOrd_NE.Text.ToString)
                        loDatos.nummod = Integer.Parse(txtNumMod_NE.Text.ToString)
                        loDatos.start = txtStart.Text
                        loDatos.ending = loDatos.start
                        loDatos.formact = cmbFormAct.Text
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
                        Dim loDatos As New Ezis_prodet
                        loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                        loDatos.numord = Integer.Parse(txtNumOrd_NE.Text.ToString)
                        If loDatos.GetPK = sOk_ Then
                            LPTruncaSegunLongitud()
                            loDatos.numtra = Integer.Parse(txtNumTra_NE.Text.ToString)
                            loDatos.numord = Integer.Parse(txtNumOrd_NE.Text.ToString)
                            loDatos.nummod = Integer.Parse(txtNumMod_NE.Text.ToString)
                            loDatos.formact = cmbFormAct.Text
                            loDatos.start = txtStart.Text
                            loDatos.ending = txtEnding.Text
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
                Dim loDatos As New Ezis_prodet
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
                Case "formact"
                    lsValorInicial = cmbFormAct.Items(0).ToString
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "nummod"
                    If Not IsNumeric(txtNumMod_NE.Text) Then Exit Sub
                    Dim liNumMod As Integer = Integer.Parse(txtNumMod_NE.Text.ToString)
                    If liNumMod = 0 Then Exit Sub

                    Dim loFK As New Ezis_modcab
                    Dim lsResultado As String = ""
                    loFK.numtra = liNumMod
                    lsResultado = loFK.GetPK
                    If lsResultado = sSinRegistros_ Then
                        Dim loLookUp As New frmBzis_modcab
                        loLookUp.Tag = sELEGIR_
                        GPCargar(loLookUp)
                        If loLookUp.entidad IsNot Nothing Then
                            txtNumMod_NE.Text = CType(loLookUp.entidad, Ezis_modcab).numtra.ToString
                        Else
                            e.Cancel = True
                            Exit Sub
                        End If
                        loLookUp = Nothing
                    End If
                    loFK.CerrarConexion()
                    loFK = Nothing
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
        msEntidad = "Detalle Proceso de Integración"
        DesplegarMensaje()
        miNumtra = CType(entidad, Ezis_prodet).numtra
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                Dim loDetalle As New Ezis_prodet
                txtNumTra_NE.Text = miNumtra.ToString
                txtNumOrd_NE.Text = loDetalle.ReservarRegistro(miNumtra).ToString
                cmbFormAct.Text = sDeAUno_
                txtStart.Text = Now.ToString(sFormatoFechaHora1_)
                txtEnding.Text = txtStart.Text
                loDetalle.CerrarConexion()
                loDetalle = Nothing
            Case Else
                txtNumTra_NE.Text = miNumtra.ToString
                txtNumOrd_NE.Text = CType(entidad, Ezis_prodet).numord.ToString
                txtNumMod_NE.Text = CType(entidad, Ezis_prodet).nummod.ToString
                If CType(entidad, Ezis_prodet).formact IsNot Nothing Then
                    cmbFormAct.Text = CType(entidad, Ezis_prodet).formact.ToString
                Else
                    cmbFormAct.Text = cmbFormAct.Items(0).ToString
                End If
                If CType(entidad, Ezis_prodet).start Is Nothing Then
                    txtStart.Text = ""
                Else
                    txtStart.Text = CType(entidad, Ezis_prodet).start.ToString
                End If
                If CType(entidad, Ezis_prodet).ending Is Nothing Then
                    txtEnding.Text = ""
                Else
                    txtEnding.Text = CType(entidad, Ezis_prodet).ending.ToString
                End If
                cmbEstado.Text = CType(entidad, Ezis_prodet).estado
        End Select
        ' Habilita o deshabilita los controles de edición
        txtNumTra_NE.Enabled = True
        txtNumOrd_NE.Enabled = True
        txtNumOrd_NE.Enabled = True
        cmbFormAct.Enabled = True

        txtNumTra_NE.AccessibleName = "numtra"
        txtNumOrd_NE.AccessibleName = "numord"
        txtNumMod_NE.AccessibleName = "nummod"
        cmbFormAct.AccessibleName = "formact"
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
        Dim liNumMod As Integer = 0

        lblNomMod.Text = ""
        If txtNumMod_NE.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtNumMod_NE.Text) Then Exit Sub
            liNumMod = Integer.Parse(txtNumMod_NE.Text.ToString)

            Dim loFK As New Ezis_modcab
            loFK.numtra = liNumMod
            If loFK.GetPK = sOk_ Then
                lblNomMod.Text = loFK.nombre
            End If
            loFK.CerrarConexion()
            loFK = Nothing
        End If
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
        txtNumOrd_NE.MaxLength = 3
        txtNumMod_NE.MaxLength = 6
        cmbFormAct.MaxLength = 15
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

        Dim loDatos As New Ezis_prodet
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
End Class