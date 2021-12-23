Imports System.ComponentModel
Imports System.Threading

Public Class frmFss100habilitaciones2
    Private msValidado As String = ""
    Private msExcluir As String = "txtBuscar"
    Private msRequeridos As String() = {"ss010_codigo", "tipo", "codigo", "ss080_codigo", "valido", "expira", "estado"}
    Private moRequeridos As New ArrayList(msRequeridos)
    Private msUltimoCodigo As String = ""

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Tag = sCancelar_
        GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en CANCELAR.")
        Me.Close()
    End Sub

    Private Sub txtBuscar_Click(sender As Object, e As EventArgs) Handles txtBuscar.Click
        txtBuscar.SelectAll()
        txtBuscar.Text = ""
    End Sub

    Private Sub BuscarClave(sender As Object, e As EventArgs)
        LPCargarDatos()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If InStr(sAGREGAR_, Me.Tag.ToString) > 0 Then
            msValidado = ""
            For Each loControl As Control In Me.TabPage1.Controls
                If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                    msValidado &= loControl.Tag.ToString
                End If
            Next

            If InStr(msValidado, sCancelar_) > 0 Then
                GFsAvisar("Validacion final", sMENSAJE_, "No han sido ingresado correctamente todos los datos")
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim lsAccionDetalle = "Usted esta a punto de agregar " & ListBox1.Items.Count & " restriccion(es), en el Sistema: " & txtSS010_codigo_AN.Text & ", Tipo: " & cmbTipo.Text & ", Codigo: " & txtCodigo_AN.Text & ", Valido:" & txtValido_FE.Text & ", Expira: " & txtExpira_FE.Text & ", Restriccion(" & LFsComponenteLista() & ")"
                        If GFsConfirmacion(Me.Tag.ToString, lsAccionDetalle) <> sOk_ Then
                            Exit Sub
                        End If
                        msUltimoCodigo = GFsHabilitarOpciones(Me, txtSS010_codigo_AN.Text, cmbTipo.Text, txtCodigo_AN.Text, txtValido_FE.Text, txtExpira_FE.Text, cmbEstado.Text, ListBox1)
                End Select
                Me.Tag = sOk_
                '-->  .AccesibleName envia al Browse la información del codigo que luego deberia 
                '-->  ser usado para la localización del registro en el DataGridView
                Me.AccessibleName = msUltimoCodigo
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ManejoEvento_Validating(sender As Object, e As CancelEventArgs)
        If CType(sender, Control).Text.Trim.Length = 0 Then
            If LFsExiste(CType(sender, Control).AccessibleName) = sNo_ Then Exit Sub
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).AccessibleName
                Case "valido"
                    lsValorInicial = Today.ToString(sFormatoFecha1_)
                Case "expira"
                    lsValorInicial = Today.AddYears(iYearsLimit_).ToString(sFormatoFecha1_)
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "valido"
                    If Not IsDate(txtValido_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtValido_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtValido_FE.Text.ToString)
                        txtValido_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                    If txtValido_FE.Text < Today.ToString("yyyy-MM-dd") Then
                        GFsAvisar("La validez no puede ser retroactivo", sMENSAJE_, "reintentelo de nuevo")
                        txtValido_FE.Text = Today.ToString("yyyy-MM-dd")
                        e.Cancel = True
                    End If
                Case "expira"
                    If Not IsDate(txtExpira_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtExpira_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtExpira_FE.Text.ToString)
                        txtExpira_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                    If txtExpira_FE.Text < txtValido_FE.Text Then
                        Dim lsAuxiliar As String = txtExpira_FE.Text
                        txtExpira_FE.Text = txtValido_FE.Text
                        txtValido_FE.Text = lsAuxiliar
                        txtValido_FE.Focus()
                    End If
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

    Private Sub LPDespliegaDescripciones()
        Dim msCodigo As String = sNODEFINIDO_
        lblNombreUsuario.Text = ""
        Select Case cmbTipo.Text
            Case sPerfil_
                Dim loFK As New Ess070perfiles
                msCodigo = sNODEFINIDO_
                If txtCodigo_AN.Text.Trim.Length > 0 Then msCodigo = txtCodigo_AN.Text
                loFK.codigo = msCodigo
                If loFK.GetPK = sOk_ Then
                    lblNombreUsuario.Text = loFK.nombre
                End If
                loFK.CerrarConexion()
                loFK = Nothing
            Case sUsuario_
                Dim loFK As New Ess050usuarios
                msCodigo = sNODEFINIDO_
                If txtCodigo_AN.Text.Trim.Length > 0 Then msCodigo = txtCodigo_AN.Text
                loFK.codigo = msCodigo
                If loFK.GetPK = sOk_ Then
                    lblNombreUsuario.Text = loFK.nombre
                End If
                loFK.CerrarConexion()
                loFK = Nothing
        End Select
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        DataGridView1.DefaultCellStyle.Font = New Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point)
        DataGridView1.AllowUserToResizeColumns = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = True
        DataGridView1.ReadOnly = True
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        ListBox1.Font = New Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Point)
        ListBox1.Sorted = True

        AddHandler txtBuscar.TextChanged, AddressOf BuscarClave
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls

        LPInicializaMaxLength()
        LPInicializaControles()
        ' Inicializa los controles de edición con los valores pertinentes
        msEntidad = "registro de habilitacion"
        DesplegarMensaje()

        txtValido_FE.Text = Today.ToString(sFormatoFecha1_)
        txtExpira_FE.Text = Today.AddYears(iYearsLimit_).ToString(sFormatoFecha1_)
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                txtSS010_codigo_AN.Text = CType(entidad, Ess100habilitaciones).ss010_codigo
                cmbTipo.Text = CType(entidad, Ess100habilitaciones).tipo
                txtCodigo_AN.Text = CType(entidad, Ess100habilitaciones).codigo
        End Select
        ' Habilita o deshabilita los controles de edición
        txtSS010_codigo_AN.Enabled = True
        cmbTipo.Enabled = True
        txtCodigo_AN.Enabled = True
        txtValido_FE.Enabled = True
        txtExpira_FE.Enabled = True
        cmbEstado.Enabled = True

        txtSS010_codigo_AN.AccessibleName = "ss010_codigo"
        cmbTipo.AccessibleName = "tipo"
        txtCodigo_AN.AccessibleName = "codigo"
        txtValido_FE.AccessibleName = "valido"
        txtExpira_FE.AccessibleName = "expira"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtSS010_codigo_AN.Enabled = False
                If cmbTipo.Text.Trim.Length > 0 Then cmbTipo.Enabled = False
                If txtCodigo_AN.Text.Trim.Length > 0 Then txtCodigo_AN.Enabled = False
                txtSS010_codigo_AN.Tag = sOk_
                cmbTipo.Tag = sOk_
                txtCodigo_AN.Tag = sOk_
                txtValido_FE.Tag = sOk_
                txtExpira_FE.Tag = sOk_
                txtValido_FE.Focus()
        End Select
        txtBuscar.Tag = txtBuscar.Text
        LPCargarDatos()
        LPDespliegaDescripciones()
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                cmbTipo.Focus()
        End Select
    End Sub

    Private Sub LPInicializaMaxLength()
        txtSS010_codigo_AN.MaxLength = 15
        cmbTipo.MaxLength = 15
        txtCodigo_AN.MaxLength = 15
        txtValido_FE.MaxLength = 10
        txtExpira_FE.MaxLength = 10
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

    Private Sub btnAdicionar_MouseMove(sender As Object, e As MouseEventArgs) Handles btnAdicionar.MouseMove
        btnAdicionar.Image = My.Resources.Resources.icons8_next_page_48
        btnAdicionar.Text = ""
    End Sub

    Private Sub btnAdicionar_MouseHover(sender As Object, e As EventArgs) Handles btnAdicionar.MouseHover
        btnAdicionar.Image = My.Resources.Resources.icons8_next_page_48
        btnAdicionar.Text = ""
    End Sub

    Private Sub btnAdicionar_MouseLeave(sender As Object, e As EventArgs) Handles btnAdicionar.MouseLeave
        btnAdicionar.Image = My.Resources.Resources.icons8_next_page_32
        btnAdicionar.Text = btnAdicionar.Tag.ToString
    End Sub

    Private Sub btnEliminar_MouseLeave(sender As Object, e As EventArgs) Handles btnEliminar.MouseLeave
        btnEliminar.Image = My.Resources.Resources.icons8_back_to_32
        btnEliminar.Text = btnEliminar.Tag.ToString
    End Sub

    Private Sub btnEliminar_MouseHover(sender As Object, e As EventArgs) Handles btnEliminar.MouseHover
        btnEliminar.Image = My.Resources.Resources.icons8_back_to_48
        btnEliminar.Text = ""
    End Sub

    Private Sub btnEliminar_MouseMove(sender As Object, e As MouseEventArgs) Handles btnEliminar.MouseMove
        btnEliminar.Image = My.Resources.Resources.icons8_back_to_48
        btnEliminar.Text = ""
    End Sub

    Private Sub LPCargarDatos()
        Dim lsTabla As String = ""
        Dim lsSQL As String
        Dim loDatos As New Ess080restricciones
        Dim loDataSet As DataSet
        Dim lsConcatFiltro As String = "codigo, nombre"
        lsSQL = GFsGeneraSQL("frmBss100habilitaciones2_disponibles")
        lsSQL = lsSQL.Replace("@ss010_codigo", txtSS010_codigo_AN.Text)
        lsSQL = lsSQL.Replace("@tipo", cmbTipo.Text)
        lsSQL = lsSQL.Replace("@codigo", txtCodigo_AN.Text)
        lsSQL = lsSQL.Replace("@componentesLista", LFsComponenteLista())
        lsSQL = lsSQL.Replace(sFiltroCampo_, lsConcatFiltro)
        If txtBuscar.Text.ToString = txtBuscar.Tag.ToString Then
            lsSQL = lsSQL.Replace(sFiltroValor_, "")
        Else
            lsSQL = lsSQL.Replace(sFiltroValor_, txtBuscar.Text)
        End If
        loDataSet = loDatos.RecuperarTabla(lsSQL)
        DataGridView1.DataSource = loDataSet
        DataGridView1.DataMember = loDatos.tableName

        lsTabla = loDatos.tableName

        loDataSet = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
        btnAceptar.Enabled = True
        If ListBox1.Items.Count = 0 Then btnAceptar.Enabled = False
    End Sub

    Private Function LFsComponenteLista() As String
        Dim lsResultado As String = ""
        If ListBox1.Items.Count = 0 Then
            lsResultado = Chr(39) & sNODEFINIDO_ & Chr(39)
            Return lsResultado
        End If

        For Each lsItem As String In ListBox1.Items
            If lsResultado.Trim.Length = 0 Then
                lsResultado = Chr(39) & lsItem & Chr(39)
            Else
                lsResultado &= "," & ControlChars.CrLf & Chr(39) & lsItem & Chr(39)
            End If
        Next
        Return lsResultado
    End Function

    Private Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        For Each loRow As DataGridViewRow In DataGridView1.SelectedRows
            ListBox1.Items.Add(loRow.Cells.Item("codigo").Value)
        Next
        LPCargarDatos()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim loSeleccion As ListBox.SelectedObjectCollection
        loSeleccion = ListBox1.SelectedItems
        For liNDX As Integer = loSeleccion.Count - 1 To 0 Step -1
            ListBox1.Items.Remove(loSeleccion.Item(liNDX))
        Next
        LPCargarDatos()
    End Sub
End Class