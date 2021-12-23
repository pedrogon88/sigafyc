Imports System.ComponentModel
Public Class frmFormulario

    Private moEntidad As Object = Nothing
    Friend msEntidad As String = ""

    Public Property entidad As Object
        Get
            Return moEntidad
        End Get
        Set(value As Object)
            moEntidad = value
        End Set
    End Property

    Private Sub btnAceptar_MouseMove(sender As Object, e As EventArgs) Handles btnAceptar.MouseMove
        btnAceptar.Image = My.Resources.Resources.icons8_ok_48
        btnAceptar.Text = ""
    End Sub

    Private Sub btnAceptar_MouseLeave(sender As Object, e As EventArgs) Handles btnAceptar.MouseLeave, btnAceptar.LostFocus
        btnAceptar.Image = My.Resources.Resources.icons8_ok_32
        btnAceptar.Text = btnAceptar.Tag.ToString
    End Sub

    Private Sub btnCancelar_MouseMove(sender As Object, e As EventArgs) Handles btnCancelar.MouseMove
        btnCancelar.Image = My.Resources.Resources.icons8_cancel_48
        btnCancelar.Text = ""
    End Sub

    Private Sub btnCancelar_MouseLeave(sender As Object, e As EventArgs) Handles btnCancelar.MouseLeave, btnCancelar.LostFocus
        btnCancelar.Image = My.Resources.Resources.icons8_cancel_32
        btnCancelar.Text = btnCancelar.Tag.ToString
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub ManejoEvento_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim loValidaEntrada As New ValidacionDataEntry
        Select Case CType(sender, Control).Name.Substring(CType(sender, Control).Name.Length - 3, 3)
            Case sDEAB_
                loValidaEntrada.tipoValor = eTipoValor.Alfabetico
            Case sDEAN_
                loValidaEntrada.tipoValor = eTipoValor.AlfaNumerico
            Case sDENE_
                loValidaEntrada.tipoValor = eTipoValor.NumeroEntero
            Case sDEND_
                loValidaEntrada.tipoValor = eTipoValor.NumeroDecimal
            Case sDEFE_
                loValidaEntrada.tipoValor = eTipoValor.Fecha
            Case sDESR_
                loValidaEntrada.tipoValor = eTipoValor.Ruc
            Case Else
                loValidaEntrada.tipoValor = eTipoValor.AlfaNumerico
        End Select
        e.KeyChar = ChrW(loValidaEntrada.TeclaPresionada(Asc(e.KeyChar), sender))
        loValidaEntrada = Nothing
    End Sub

    Public Sub ManejoEvento_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub frmFormulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.Tag Is Nothing Then
            Me.Tag = ""
        End If
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                lblMensaje.BackColor = Color.FromArgb(85, 130, 232)
            Case sMODIFICAR_
                lblMensaje.BackColor = Color.FromArgb(93, 182, 107)
            Case sBORRAR_
                lblMensaje.BackColor = Color.FromArgb(237, 65, 74)
            Case sCONSULTAR_
                lblMensaje.BackColor = Color.FromArgb(236, 191, 57)
        End Select

        Me.CancelButton = Nothing
        Me.AcceptButton = Nothing
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                Me.CancelButton = btnCancelar
            Case sMODIFICAR_
                Me.CancelButton = btnCancelar
            Case sBORRAR_
                Me.CancelButton = btnCancelar
                Me.AcceptButton = btnAceptar
            Case sCONSULTAR_
                Me.CancelButton = btnCancelar
                Me.AcceptButton = btnAceptar
        End Select
        AddHandler btnAceptar.MouseDown, AddressOf Imagen_Click
        AddHandler btnCancelar.MouseDown, AddressOf Imagen_Click
    End Sub

    Friend Sub Imagen_Click(sender As Object, e As MouseEventArgs)
        Select Case CType(sender, Button).Name
            Case "btnAceptar"
                btnAceptar.Image = My.Resources.Resources.icons8_color_ok_48
                btnAceptar.Text = ""
            Case "btnCancelar"
                btnCancelar.Image = My.Resources.Resources.icons8_color_cancel_48
                btnCancelar.Text = ""
        End Select
    End Sub

    Friend Sub DesplegarMensaje()
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                lblMensaje.Text = "agregar nuevo " & msEntidad
            Case sMODIFICAR_
                lblMensaje.Text = "modificar " & msEntidad
            Case sBORRAR_
                lblMensaje.Text = "haga click en [ACEPTAR] para borrar"
            Case sCONSULTAR_
                lblMensaje.Text = "solo para consultar"
        End Select
    End Sub
    Friend Sub LPTruncaSegunLongitud()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            Dim lsValores As String = sDENE_ & sSF_ & sDEND_
                            If InStr(lsValores, loControl.Name.Substring(loControl.Name.Length - 2, 2)) = 0 Then
                                If CType(loControl, TextBox).Text.Trim.Length > CType(loControl, TextBox).MaxLength Then
                                    CType(loControl, TextBox).Text = CType(loControl, TextBox).Text.Substring(0, CType(loControl, TextBox).MaxLength)
                                End If
                            End If
                    End Select
                Next
            End If
        Next
    End Sub
End Class
