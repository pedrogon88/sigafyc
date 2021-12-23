Imports System.Reflection

Public Class frmBrowseSinGrid
    Private moEntidad As Object
    Private mbAgregar As Boolean = False
    Private mbBorrar As Boolean = False
    Private mbModificar As Boolean = False
    Private mbConsultar As Boolean = False
    Private mbAuditoria As Boolean = False
    Friend miCantidad As Integer = -9999
    Private miCantApertura As Integer = 0

    Public Property entidad As Object
        Get
            Return moEntidad
        End Get
        Set(value As Object)
            moEntidad = value
        End Set
    End Property

    Private Sub frmBrowse_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Me.Tag Is Nothing Then Me.Tag = ""

        mbAgregar = btnAgregar.Enabled
        mbBorrar = btnBorrar.Enabled
        mbModificar = btnModificar.Enabled
        mbConsultar = btnConsultar.Enabled
        mbAuditoria = btnAuditoria.Enabled

        'Me.BackColor = Color.FromArgb(98, 141, 158)
        'Me.BackColor = Color.FromArgb(252, 251, 249)
        'Me.BackColor = Color.FromArgb(112, 149, 167)
        AddHandler btnAgregar.MouseDown, AddressOf Imagen_Click
        AddHandler btnBorrar.MouseDown, AddressOf Imagen_Click
        AddHandler btnModificar.MouseDown, AddressOf Imagen_Click
        AddHandler btnConsultar.MouseDown, AddressOf Imagen_Click
        AddHandler btnAuditoria.MouseDown, AddressOf Imagen_Click
        AddHandler btnSalir.MouseDown, AddressOf Imagen_Click

        If Me.Tag.ToString = sELEGIR_ Then
            btnConsultar.Text = sPrefAccesoRapido_ & sELEGIR_.ToLower
            btnConsultar.Tag = btnConsultar.Text
            'Me.BackColor = Color.LightSteelBlue
            'Me.BackColor = Color.FromArgb(8, 35, 56) 'color original
            'Me.BackColor = Color.FromArgb(237, 65, 74) 'color de borrar
            'Me.BackColor = Color.FromArgb(236, 191, 57) 'color de consultar
            'Me.BackColor = Color.FromArgb(93, 182, 107) 'color de modificar
            Me.BackColor = Color.FromArgb(85, 130, 232) 'color de agregar
            Me.StartPosition = FormStartPosition.WindowsDefaultLocation
        End If
    End Sub

    Private Sub btnAgregar_MouseMove(sender As Object, e As EventArgs) Handles btnAgregar.MouseMove
        btnAgregar.Image = My.Resources.Resources.icons8_add_row_48
        btnAgregar.Text = ""
    End Sub

    Private Sub btnAgregar_MouseLeave(sender As Object, e As EventArgs) Handles btnAgregar.MouseLeave, btnAgregar.LostFocus
        btnAgregar.Image = My.Resources.Resources.icons8_add_row_32
        btnAgregar.Text = btnAgregar.Tag.ToString
    End Sub

    Private Sub btnModificar_MouseMove(sender As Object, e As EventArgs) Handles btnModificar.MouseMove
        btnModificar.Image = My.Resources.Resources.icons8_edit_row_48
        btnModificar.Text = ""
    End Sub

    Private Sub btnModificar_MouseLeave(sender As Object, e As EventArgs) Handles btnModificar.MouseLeave, btnModificar.LostFocus
        btnModificar.Image = My.Resources.Resources.icons8_edit_row_32
        btnModificar.Text = btnModificar.Tag.ToString
    End Sub

    Private Sub btnBorrar_MouseMove(sender As Object, e As EventArgs) Handles btnBorrar.MouseMove, btnBorrar.LostFocus
        btnBorrar.Image = My.Resources.Resources.icons8_delete_row_48
        btnBorrar.Text = ""
    End Sub

    Private Sub btnBorrar_MouseLeave(sender As Object, e As EventArgs) Handles btnBorrar.MouseLeave
        btnBorrar.Image = My.Resources.Resources.icons8_delete_row_32
        btnBorrar.Text = btnBorrar.Tag.ToString
    End Sub

    Private Sub btnConsultar_MouseMove(sender As Object, e As EventArgs) Handles btnConsultar.MouseMove
        btnConsultar.Image = My.Resources.Resources.icons8_eye_48
        btnConsultar.Text = ""
    End Sub

    Private Sub btnConsultar_MouseLeave(sender As Object, e As EventArgs) Handles btnConsultar.MouseLeave, btnConsultar.LostFocus
        btnConsultar.Image = My.Resources.Resources.icons8_eye_32
        btnConsultar.Text = btnConsultar.Tag.ToString
    End Sub

    Private Sub btnAuditoria_MouseMove(sender As Object, e As EventArgs) Handles btnAuditoria.MouseMove
        btnAuditoria.Image = My.Resources.Resources.icons8_survey_48
        btnAuditoria.Text = ""
    End Sub

    Private Sub btnAuditoria_MouseLeave(sender As Object, e As EventArgs) Handles btnAuditoria.MouseLeave, btnAuditoria.LostFocus
        btnAuditoria.Image = My.Resources.Resources.icons8_survey_32
        btnAuditoria.Text = btnAuditoria.Tag.ToString
    End Sub

    Private Sub btnSalir_MouseMove(sender As Object, e As EventArgs) Handles btnSalir.MouseMove
        btnSalir.Image = My.Resources.Resources.icons8_exit_48
        btnSalir.Text = ""
    End Sub

    Private Sub btnSalir_MouseLeave(sender As Object, e As EventArgs) Handles btnSalir.MouseLeave, btnSalir.LostFocus
        btnSalir.Image = My.Resources.Resources.icons8_exit_32
        btnSalir.Text = btnSalir.Tag.ToString
    End Sub

    Private Sub txtBuscar_Click(sender As Object, e As EventArgs) Handles txtBuscar.Click
        txtBuscar.SelectAll()
        txtBuscar.Text = ""
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

    Friend Sub DataGrid_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter And e.Shift Then
            SendKeys.Send("%(m)")
        End If
        Select Case e.KeyCode
            Case Keys.Insert
                SendKeys.Send("%(a)")
            Case Keys.Enter
                e.SuppressKeyPress = True
                If Me.Tag.ToString = sELEGIR_ Then
                    SendKeys.Send("%(e)")
                Else
                    SendKeys.Send("%(c)")
                End If
            Case Keys.Delete
                SendKeys.Send("%(b)")
            Case Keys.F10
                SendKeys.Send("%(u)")
        End Select
    End Sub

    Friend Sub DataGrid_DoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If Me.Tag.ToString = sELEGIR_ Then
            SendKeys.Send("%(e)")
        Else
            SendKeys.Send("%(m)")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        GPBitacoraRegistrar(sSALIO_, Me.Text)
        Me.Close()
    End Sub

    Friend Sub Imagen_Click(sender As Object, e As MouseEventArgs)
        Select Case CType(sender, Button).Name
            Case "btnAgregar"
                btnAgregar.Image = My.Resources.Resources.icons8_color_add_row_48
                btnAgregar.Text = ""
            Case "btnBorrar"
                btnBorrar.Image = My.Resources.Resources.icons8_color_delete_row_48
                btnBorrar.Text = ""
            Case "btnModificar"
                btnModificar.Image = My.Resources.Resources.icons8_color_edit_row_48
                btnModificar.Text = ""
            Case "btnConsultar"
                btnConsultar.Image = My.Resources.Resources.icons8_color_eye_48
                btnConsultar.Text = ""
            Case "btnAuditoria"
                btnAuditoria.Image = My.Resources.Resources.icons8_color_survey_48
                btnAuditoria.Text = ""
            Case "btnSalir"
                btnSalir.Image = My.Resources.Resources.icons8_color_exit_48
                btnSalir.Text = ""
        End Select
    End Sub

    Private Sub Browse_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        LPHabilitaControles()
    End Sub

    Friend Sub LPHabilitaControles()
        'If Tag.ToString = "SobreCargado" Then Exit Sub
        btnAgregar.Enabled = False
        btnBorrar.Enabled = False
        btnModificar.Enabled = False
        btnConsultar.Enabled = False
        btnAuditoria.Enabled = False
        If miCantidad <= 0 Then
            btnAgregar.Enabled = mbAgregar
        Else
            btnAgregar.Enabled = mbAgregar
            btnBorrar.Enabled = mbBorrar
            btnModificar.Enabled = mbModificar
            btnConsultar.Enabled = mbConsultar
            btnAuditoria.Enabled = mbAuditoria
        End If
    End Sub

    Public Shared Sub LPSetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub
End Class