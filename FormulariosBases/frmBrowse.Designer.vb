<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrowse
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrowse))
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.mnuExportarExcel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItem_ExportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem_ExportarTexto = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAuditoria = New System.Windows.Forms.Button()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuExportarExcel.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscar
        '
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(16, 18)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(1135, 27)
        Me.txtBuscar.TabIndex = 15
        Me.txtBuscar.Tag = "ingrese su busqueda"
        Me.txtBuscar.Text = "ingrese su busqueda"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.mnuExportarExcel
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(16, 62)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1135, 740)
        Me.DataGridView1.TabIndex = 8
        '
        'mnuExportarExcel
        '
        Me.mnuExportarExcel.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuExportarExcel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem_ExportarExcel, Me.MenuItem_ExportarTexto})
        Me.mnuExportarExcel.Name = "mnuExportarExcel"
        Me.mnuExportarExcel.Size = New System.Drawing.Size(264, 52)
        '
        'MenuItem_ExportarExcel
        '
        Me.MenuItem_ExportarExcel.Name = "MenuItem_ExportarExcel"
        Me.MenuItem_ExportarExcel.Size = New System.Drawing.Size(263, 24)
        Me.MenuItem_ExportarExcel.Text = "Exportar a Excel"
        '
        'MenuItem_ExportarTexto
        '
        Me.MenuItem_ExportarTexto.Name = "MenuItem_ExportarTexto"
        Me.MenuItem_ExportarTexto.Size = New System.Drawing.Size(263, 24)
        Me.MenuItem_ExportarTexto.Text = "Exportar a Texto delimitado"
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.SystemColors.Control
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.sigafyc.My.Resources.Resources.icons8_exit_32
        Me.btnSalir.Location = New System.Drawing.Point(1159, 702)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(115, 100)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Tag = "&salir"
        Me.btnSalir.Text = "&salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnAuditoria
        '
        Me.btnAuditoria.BackColor = System.Drawing.SystemColors.Control
        Me.btnAuditoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAuditoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAuditoria.Image = Global.sigafyc.My.Resources.Resources.icons8_survey_32
        Me.btnAuditoria.Location = New System.Drawing.Point(1159, 594)
        Me.btnAuditoria.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAuditoria.Name = "btnAuditoria"
        Me.btnAuditoria.Size = New System.Drawing.Size(115, 100)
        Me.btnAuditoria.TabIndex = 4
        Me.btnAuditoria.Tag = "a&uditoria"
        Me.btnAuditoria.Text = "a&uditoria"
        Me.btnAuditoria.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAuditoria.UseVisualStyleBackColor = False
        '
        'btnConsultar
        '
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Image = Global.sigafyc.My.Resources.Resources.icons8_eye_32
        Me.btnConsultar.Location = New System.Drawing.Point(1159, 340)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(115, 100)
        Me.btnConsultar.TabIndex = 3
        Me.btnConsultar.Tag = "&consultar"
        Me.btnConsultar.Text = "&consultar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConsultar.UseVisualStyleBackColor = False
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.sigafyc.My.Resources.Resources.icons8_delete_row_32
        Me.btnBorrar.Location = New System.Drawing.Point(1159, 233)
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(115, 100)
        Me.btnBorrar.TabIndex = 2
        Me.btnBorrar.Tag = "&borrar"
        Me.btnBorrar.Text = "&borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBorrar.UseVisualStyleBackColor = False
        '
        'btnModificar
        '
        Me.btnModificar.BackColor = System.Drawing.SystemColors.Control
        Me.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Image = Global.sigafyc.My.Resources.Resources.icons8_edit_row_32
        Me.btnModificar.Location = New System.Drawing.Point(1159, 126)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(115, 100)
        Me.btnModificar.TabIndex = 1
        Me.btnModificar.Tag = "&modificar"
        Me.btnModificar.Text = "&modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.sigafyc.My.Resources.Resources.icons8_add_row_32
        Me.btnAgregar.Location = New System.Drawing.Point(1159, 18)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(115, 100)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Tag = "&agregar"
        Me.btnAgregar.Text = "&agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'frmBrowse
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1285, 817)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAuditoria)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBrowse"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBrowse"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuExportarExcel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents txtBuscar As System.Windows.Forms.TextBox
    Public WithEvents btnSalir As System.Windows.Forms.Button
    Public WithEvents btnAuditoria As System.Windows.Forms.Button
    Public WithEvents btnConsultar As System.Windows.Forms.Button
    Public WithEvents btnBorrar As System.Windows.Forms.Button
    Public WithEvents btnModificar As System.Windows.Forms.Button
    Public WithEvents btnAgregar As System.Windows.Forms.Button
    Public WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Public WithEvents mnuExportarExcel As ContextMenuStrip
    Public WithEvents MenuItem_ExportarExcel As ToolStripMenuItem
    Friend WithEvents MenuItem_ExportarTexto As ToolStripMenuItem
End Class
