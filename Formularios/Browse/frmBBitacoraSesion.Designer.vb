<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBBitacoraSesion
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.mnuExportarExcel = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItem_ExportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem_ExportarTexto = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtBuscarDetalle = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.mnuExportarExcel.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.ContextMenuStrip = Me.mnuExportarExcel
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(15, 15)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1512, 687)
        Me.TabControl1.TabIndex = 6
        '
        'mnuExportarExcel
        '
        Me.mnuExportarExcel.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuExportarExcel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem_ExportarExcel, Me.MenuItem_ExportarTexto})
        Me.mnuExportarExcel.Name = "mnuExportarExcel"
        Me.mnuExportarExcel.Size = New System.Drawing.Size(252, 52)
        '
        'MenuItem_ExportarExcel
        '
        Me.MenuItem_ExportarExcel.Name = "MenuItem_ExportarExcel"
        Me.MenuItem_ExportarExcel.Size = New System.Drawing.Size(251, 24)
        Me.MenuItem_ExportarExcel.Text = "Exportar a Excel"
        '
        'MenuItem_ExportarTexto
        '
        Me.MenuItem_ExportarTexto.Name = "MenuItem_ExportarTexto"
        Me.MenuItem_ExportarTexto.Size = New System.Drawing.Size(251, 24)
        Me.MenuItem_ExportarTexto.Text = "Exportar Texto delimitado"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtBuscar)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(1504, 642)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = "Sesiones"
        Me.TabPage1.Text = "Sesiones"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(8, 7)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(1485, 34)
        Me.txtBuscar.TabIndex = 16
        Me.txtBuscar.Tag = "ingrese su busqueda"
        Me.txtBuscar.Text = "ingrese su busqueda"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(8, 50)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1485, 583)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtBuscarDetalle)
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1504, 642)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Tag = "DetalleSesiones"
        Me.TabPage2.Text = "Detalle de lo realizado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtBuscarDetalle
        '
        Me.txtBuscarDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscarDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarDetalle.Location = New System.Drawing.Point(4, 4)
        Me.txtBuscarDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscarDetalle.Name = "txtBuscarDetalle"
        Me.txtBuscarDetalle.Size = New System.Drawing.Size(1493, 34)
        Me.txtBuscarDetalle.TabIndex = 17
        Me.txtBuscarDetalle.Tag = "ingrese su busqueda"
        Me.txtBuscarDetalle.Text = "ingrese su busqueda"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(4, 47)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(1493, 591)
        Me.DataGridView2.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.sigafyc.My.Resources.Resources.icons8_exit_32
        Me.btnSalir.Location = New System.Drawing.Point(1384, 706)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(128, 97)
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Tag = "&salir"
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmBBitacoraSesion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(1528, 811)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBBitacoraSesion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Browse Bitacora de Sesiones"
        Me.TabControl1.ResumeLayout(False)
        Me.mnuExportarExcel.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents TabControl1 As TabControl
    Public WithEvents TabPage1 As TabPage
    Public WithEvents txtBuscar As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DataGridView2 As DataGridView
    Public WithEvents btnSalir As Button
    Public WithEvents txtBuscarDetalle As TextBox
    Friend WithEvents mnuExportarExcel As ContextMenuStrip
    Friend WithEvents MenuItem_ExportarExcel As ToolStripMenuItem
    Friend WithEvents MenuItem_ExportarTexto As ToolStripMenuItem
End Class
