<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBc020documentos : Inherits frmBrowseSinGrid

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
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.txtCodEmpresa_NE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.mnuContextual = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextualItem_ExportarExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextualItem_ExportarTexto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextualItem_ImportarTexto = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuContextual.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(17, 58)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(5)
        Me.txtBuscar.Size = New System.Drawing.Size(1131, 27)
        Me.txtBuscar.TabIndex = 8
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(1157, 703)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSalir.Size = New System.Drawing.Size(128, 97)
        Me.btnSalir.TabIndex = 7
        '
        'btnAuditoria
        '
        Me.btnAuditoria.Location = New System.Drawing.Point(1157, 596)
        Me.btnAuditoria.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAuditoria.Size = New System.Drawing.Size(128, 97)
        Me.btnAuditoria.TabIndex = 6
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(1157, 379)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnConsultar.Size = New System.Drawing.Size(128, 97)
        Me.btnConsultar.TabIndex = 5
        '
        'btnBorrar
        '
        Me.btnBorrar.Location = New System.Drawing.Point(1157, 272)
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnBorrar.Size = New System.Drawing.Size(128, 97)
        Me.btnBorrar.TabIndex = 4
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(1157, 165)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnModificar.Size = New System.Drawing.Size(128, 97)
        Me.btnModificar.TabIndex = 3
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(1157, 58)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAgregar.Size = New System.Drawing.Size(128, 97)
        Me.btnAgregar.TabIndex = 2
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(236, 17)
        Me.lblNombreEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(249, 29)
        Me.lblNombreEmpresa.TabIndex = 36
        Me.lblNombreEmpresa.Text = "<nombre del usuario>"
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(129, 15)
        Me.txtCodEmpresa_NE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(98, 34)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 29)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Empresa:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 92)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1132, 708)
        Me.DataGridView1.TabIndex = 1
        '
        'mnuContextual
        '
        Me.mnuContextual.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuContextual.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextualItem_ExportarExcel, Me.ContextualItem_ExportarTexto, Me.ContextualItem_ImportarTexto})
        Me.mnuContextual.Name = "mnuContextual"
        Me.mnuContextual.Size = New System.Drawing.Size(298, 76)
        '
        'ContextualItem_ExportarExcel
        '
        Me.ContextualItem_ExportarExcel.Name = "ContextualItem_ExportarExcel"
        Me.ContextualItem_ExportarExcel.Size = New System.Drawing.Size(297, 24)
        Me.ContextualItem_ExportarExcel.Text = "Exportar a Excel"
        '
        'ContextualItem_ExportarTexto
        '
        Me.ContextualItem_ExportarTexto.Name = "ContextualItem_ExportarTexto"
        Me.ContextualItem_ExportarTexto.Size = New System.Drawing.Size(297, 24)
        Me.ContextualItem_ExportarTexto.Text = "Exportar a Texto delimitado"
        '
        'ContextualItem_ImportarTexto
        '
        Me.ContextualItem_ImportarTexto.Name = "ContextualItem_ImportarTexto"
        Me.ContextualItem_ImportarTexto.Size = New System.Drawing.Size(297, 24)
        Me.ContextualItem_ImportarTexto.Text = "Importar desde Texto delimitado"
        '
        'frmBc020documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1295, 811)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblNombreEmpresa)
        Me.Controls.Add(Me.txtCodEmpresa_NE)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmBc020documentos"
        Me.Tag = ""
        Me.Text = "Browse de Documentos"
        Me.Controls.SetChildIndex(Me.btnAgregar, 0)
        Me.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.Controls.SetChildIndex(Me.btnBorrar, 0)
        Me.Controls.SetChildIndex(Me.btnConsultar, 0)
        Me.Controls.SetChildIndex(Me.btnAuditoria, 0)
        Me.Controls.SetChildIndex(Me.btnSalir, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodEmpresa_NE, 0)
        Me.Controls.SetChildIndex(Me.lblNombreEmpresa, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuContextual.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents mnuContextual As ContextMenuStrip
    Friend WithEvents ContextualItem_ExportarExcel As ToolStripMenuItem
    Friend WithEvents ContextualItem_ExportarTexto As ToolStripMenuItem
    Friend WithEvents ContextualItem_ImportarTexto As ToolStripMenuItem
End Class
