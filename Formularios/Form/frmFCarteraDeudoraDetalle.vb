Imports System.ComponentModel

Public Class frmFCarteraDeudoraDetalle
    Private msValidado As String = ""
    Private msRequeridos As String() = {"fechahora", "comentario"}
    Private moRequeridos As New ArrayList(msRequeridos)

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
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
                txtFechaHora_FE.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim loDatos As New Eoitmc11
                        loDatos.ItemCode = txtItemCode_AN.Text
                        loDatos.CardCode = txtCardCode_AN.Text
                        loDatos.FechaHora = txtFechaHora_FE.Text
                        loDatos.Comentario = txtComentario_AN.Text
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Add()
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim loDatos As New Eoitmc11
                        loDatos.ItemCode = txtItemCode_AN.Text
                        loDatos.CardCode = txtCardCode_AN.Text
                        loDatos.FechaHora = txtFechaHora_FE.Text
                        If loDatos.GetPK = sOk_ Then
                            loDatos.ItemCode = txtItemCode_AN.Text
                            loDatos.CardCode = txtCardCode_AN.Text
                            loDatos.FechaHora = txtFechaHora_FE.Text
                            loDatos.Comentario = txtComentario_AN.Text
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
                Me.AccessibleName = txtFechaHora_FE.Text
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        Else
            If Me.Tag.ToString = sBORRAR_ Then
                Dim loDatos As New Eoitmc11
                loDatos.ItemCode = txtItemCode_AN.Text
                loDatos.CardCode = txtCardCode_AN.Text
                loDatos.FechaHora = txtFechaHora_FE.Text
                If loDatos.GetPK = sOk_ Then
                    loDatos.ItemCode = txtItemCode_AN.Text
                    loDatos.CardCode = txtCardCode_AN.Text
                    loDatos.FechaHora = txtFechaHora_FE.Text
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
                Case "comentario"
                    lsValorInicial = sSINCOMENTARIO_
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "fechahora"
                    Dim loPk As New Eoitmc11
                    loPk.ItemCode = txtItemCode_AN.Text
                    loPk.CardCode = txtCardCode_AN.Text
                    loPk.FechaHora = txtFechaHora_FE.Text
                    If loPk.GetPK = sOk_ Then
                        GFsAvisar("Fecha y hora [" & txtFechaHora_FE.Text & "]", sMENSAJE_, "ya existe! Y no puede duplicarse.")
                        e.Cancel = True
                    End If
                    loPk = Nothing
            End Select
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoComboBox_ Then
                If CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) = False Then
                    e.Cancel = True
                    CType(sender, Control).Tag = sCancelar_
                End If
            End If
        End If
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls

        ' Inicializa los controles de edición con los valores pertinentes
        msEntidad = "registro detalle unidades seguimiento"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                txtItemCode_AN.Text = CType(entidad, Eoitmc11).ItemCode
                txtCardCode_AN.Text = CType(entidad, Eoitmc11).CardCode
                txtFechaHora_FE.Text = CType(entidad, Eoitmc11).FechaHora
            Case Else
                Dim loDatos As New Eoitmc11
                loDatos.ItemCode = CType(entidad, Eoitmc11).ItemCode
                loDatos.CardCode = CType(entidad, Eoitmc11).CardCode
                loDatos.FechaHora = CType(entidad, Eoitmc11).FechaHora
                If loDatos.GetPK() = sOk_ Then
                    txtItemCode_AN.Text = loDatos.ItemCode
                    txtCardCode_AN.Text = loDatos.CardCode
                    txtFechaHora_FE.Text = loDatos.FechaHora
                    txtComentario_AN.Text = loDatos.Comentario
                    cmbEstado.Text = loDatos.estado
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
        End Select
        ' Habilita o deshabilita los controles de edición
        txtItemCode_AN.Enabled = True
        txtCardCode_AN.Enabled = True
        txtFechaHora_FE.Enabled = True
        txtComentario_AN.Enabled = True
        cmbEstado.Enabled = True

        txtItemCode_AN.AccessibleName = "itemcode"
        txtCardCode_AN.AccessibleName = "cardcode"
        txtFechaHora_FE.AccessibleName = "fechahora"
        txtComentario_AN.AccessibleName = "comentario"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtItemCode_AN.Enabled = False
                txtCardCode_AN.Enabled = False
                txtFechaHora_FE.Enabled = False

            Case sMODIFICAR_
                txtItemCode_AN.Enabled = False
                txtCardCode_AN.Enabled = False
                txtFechaHora_FE.Enabled = False

            Case sCONSULTAR_, sBORRAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
                loControls = Me.TabPage2.Controls
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
        End Select
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtFechaHora_FE.Focus()
            Case sMODIFICAR_
                txtComentario_AN.Focus()
        End Select

    End Sub

    Private Sub LPInicializaMaxLength()
        txtItemCode_AN.MaxLength = 15
        txtItemCode_AN.MaxLength = 128
        txtFechaHora_FE.MaxLength = 128
        txtComentario_AN.MaxLength = 32000
    End Sub
    Private Sub LPInicializaControles()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                            AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                        Case sPrefijoComboBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
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
End Class