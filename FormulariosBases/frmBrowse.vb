Imports System.Reflection

Public Class frmBrowse
    Private moEntidad As Object
    Private mbAgregar As Boolean = False
    Private mbBorrar As Boolean = False
    Private mbModificar As Boolean = False
    Private mbConsultar As Boolean = False
    Private mbAuditoria As Boolean = False
    Friend miCantidad As Integer = 0
    Friend mbAbrirForm As Boolean = False
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

        DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView1.AllowUserToResizeColumns = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = False
        LPSetDoubleBuffered(DataGridView1)

        mbAgregar = btnAgregar.Enabled
        mbBorrar = btnBorrar.Enabled
        mbModificar = btnModificar.Enabled
        mbConsultar = btnConsultar.Enabled
        mbAuditoria = btnAuditoria.Enabled

        AddHandler btnAgregar.MouseDown, AddressOf Imagen_Click
        AddHandler btnBorrar.MouseDown, AddressOf Imagen_Click
        AddHandler btnModificar.MouseDown, AddressOf Imagen_Click
        AddHandler btnConsultar.MouseDown, AddressOf Imagen_Click
        AddHandler btnAuditoria.MouseDown, AddressOf Imagen_Click
        AddHandler btnSalir.MouseDown, AddressOf Imagen_Click

        AddHandler MenuItem_ExportarExcel.Click, AddressOf ExportarExcel_Click
        AddHandler MenuItem_ExportarTexto.Click, AddressOf ExportarTexto_Click

        'Me.BackColor = Color.FromArgb(98, 141, 158)
        'Me.BackColor = Color.FromArgb(252, 251, 249)
        'Me.BackColor = Color.FromArgb(112, 149, 167)
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
        If Me.Tag.ToString = sELEGIR_ Then
            If Me.Name <> "frmBa010monedas" Then
                Dim lofrmBase As New frmBa010monedas
                txtBuscar.Width = lofrmBase.txtBuscar.Width
                DataGridView1.Size = lofrmBase.DataGridView1.Size
                btnAgregar.Location = lofrmBase.btnAgregar.Location
                btnModificar.Location = lofrmBase.btnModificar.Location
                btnBorrar.Location = lofrmBase.btnBorrar.Location
                btnConsultar.Location = lofrmBase.btnConsultar.Location
                btnAuditoria.Location = lofrmBase.btnAuditoria.Location
                btnSalir.Location = lofrmBase.btnSalir.Location
                Me.Size = lofrmBase.Size
                lofrmBase = Nothing
            End If
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

    Private Sub DataGridView1_DoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If Me.Tag.ToString = sELEGIR_ Then
            SendKeys.Send("%(e)")
        Else
            SendKeys.Send("%(m)")
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
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

    Friend Sub LPSinRegistro_AbrirForm()
        If miCantidad = 0 Then
            If mbAbrirForm = False Then
                mbAbrirForm = True
                SendKeys.Send("%(a)")
            End If
        End If
    End Sub

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

    Public Shared Sub LPSetDoubleBuffered(ByVal control As Control)
        GetType(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, control, New Object() {True})
    End Sub
End Class