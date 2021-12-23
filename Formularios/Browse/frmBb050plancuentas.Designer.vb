<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBb050plancuentas : Inherits frmBrowseSinGrid

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.txtCodEmpresa_NE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mnuExportar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItem_Exportar1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem_Exportar2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem_Importar1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnImprimir = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuExportar.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(13, 58)
        Me.txtBuscar.Margin = New System.Windows.Forms.Padding(5)
        Me.txtBuscar.TabIndex = 9
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(1541, 862)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSalir.Size = New System.Drawing.Size(153, 123)
        Me.btnSalir.TabIndex = 8
        '
        'btnAuditoria
        '
        Me.btnAuditoria.Location = New System.Drawing.Point(1156, 700)
        Me.btnAuditoria.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAuditoria.TabIndex = 7
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(1158, 388)
        Me.btnConsultar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnConsultar.TabIndex = 5
        '
        'btnBorrar
        '
        Me.btnBorrar.Location = New System.Drawing.Point(1158, 278)
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnBorrar.TabIndex = 4
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(1158, 168)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnModificar.TabIndex = 3
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(1158, 58)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAgregar.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 92)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1135, 708)
        Me.DataGridView1.TabIndex = 1
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
        'mnuExportar
        '
        Me.mnuExportar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuExportar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem_Exportar1, Me.MenuItem_Exportar2, Me.MenuItem_Importar1})
        Me.mnuExportar.Name = "nnuExportar"
        Me.mnuExportar.Size = New System.Drawing.Size(264, 76)
        '
        'MenuItem_Exportar1
        '
        Me.MenuItem_Exportar1.Name = "MenuItem_Exportar1"
        Me.MenuItem_Exportar1.Size = New System.Drawing.Size(263, 24)
        Me.MenuItem_Exportar1.Text = "Exportar a Excel"
        '
        'MenuItem_Exportar2
        '
        Me.MenuItem_Exportar2.Name = "MenuItem_Exportar2"
        Me.MenuItem_Exportar2.Size = New System.Drawing.Size(263, 24)
        Me.MenuItem_Exportar2.Text = "Exportar a Texto delimitado"
        '
        'MenuItem_Importar1
        '
        Me.MenuItem_Importar1.Name = "MenuItem_Importar1"
        Me.MenuItem_Importar1.Size = New System.Drawing.Size(263, 24)
        Me.MenuItem_Importar1.Text = "Importar Texto delimitado"
        '
        'btnImprimir
        '
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = Global.sigafyc.My.Resources.Resources.icons8_color_print_32
        Me.btnImprimir.Location = New System.Drawing.Point(1156, 497)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(115, 100)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.Tag = "Imprimir"
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'frmBb050plancuentas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1283, 811)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.lblNombreEmpresa)
        Me.Controls.Add(Me.txtCodEmpresa_NE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmBb050plancuentas"
        Me.Tag = ""
        Me.Text = "Browse de Cuenta contables"
        Me.Controls.SetChildIndex(Me.btnAgregar, 0)
        Me.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.Controls.SetChildIndex(Me.btnBorrar, 0)
        Me.Controls.SetChildIndex(Me.btnConsultar, 0)
        Me.Controls.SetChildIndex(Me.btnAuditoria, 0)
        Me.Controls.SetChildIndex(Me.btnSalir, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodEmpresa_NE, 0)
        Me.Controls.SetChildIndex(Me.lblNombreEmpresa, 0)
        Me.Controls.SetChildIndex(Me.btnImprimir, 0)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuExportar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents mnuExportar As ContextMenuStrip
    Friend WithEvents MenuItem_Exportar1 As ToolStripMenuItem
    Friend WithEvents MenuItem_Exportar2 As ToolStripMenuItem
    Friend WithEvents MenuItem_Importar1 As ToolStripMenuItem
    Friend WithEvents btnImprimir As Button
End Class
