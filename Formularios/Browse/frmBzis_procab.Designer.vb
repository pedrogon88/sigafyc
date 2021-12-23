<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBzis_procab
    Inherits frmBrowse

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBzis_procab))
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.mnuProcesamiento = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ProcesarManualmenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesarIntegraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProcesamiento.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(1159, 705)
        Me.btnSalir.Size = New System.Drawing.Size(128, 97)
        '
        'btnAuditoria
        '
        Me.btnAuditoria.Location = New System.Drawing.Point(1159, 600)
        Me.btnAuditoria.Size = New System.Drawing.Size(128, 97)
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(1159, 333)
        Me.btnConsultar.Size = New System.Drawing.Size(128, 97)
        '
        'btnBorrar
        '
        Me.btnBorrar.Location = New System.Drawing.Point(1159, 228)
        Me.btnBorrar.Size = New System.Drawing.Size(128, 97)
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(1159, 123)
        Me.btnModificar.Size = New System.Drawing.Size(128, 97)
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Size = New System.Drawing.Size(128, 97)
        '
        'btnDetalle
        '
        Me.btnDetalle.ContextMenuStrip = Me.mnuProcesamiento
        Me.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetalle.Image = Global.sigafyc.My.Resources.Resources.icons8_details_32
        Me.btnDetalle.Location = New System.Drawing.Point(1159, 438)
        Me.btnDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(128, 97)
        Me.btnDetalle.TabIndex = 18
        Me.btnDetalle.Tag = "&detalle"
        Me.btnDetalle.Text = "&detalle"
        Me.btnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDetalle.UseVisualStyleBackColor = True
        '
        'mnuProcesamiento
        '
        Me.mnuProcesamiento.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuProcesamiento.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProcesarManualmenteToolStripMenuItem})
        Me.mnuProcesamiento.Name = "mnuProcesamiento"
        Me.mnuProcesamiento.Size = New System.Drawing.Size(234, 30)
        '
        'ProcesarManualmenteToolStripMenuItem
        '
        Me.ProcesarManualmenteToolStripMenuItem.Image = Global.sigafyc.My.Resources.Resources.icons8_color_processing_48
        Me.ProcesarManualmenteToolStripMenuItem.Name = "ProcesarManualmenteToolStripMenuItem"
        Me.ProcesarManualmenteToolStripMenuItem.Size = New System.Drawing.Size(233, 26)
        Me.ProcesarManualmenteToolStripMenuItem.Text = "Procesar manualmente"
        '
        'ProcesarIntegraciónToolStripMenuItem
        '
        Me.ProcesarIntegraciónToolStripMenuItem.Name = "ProcesarIntegraciónToolStripMenuItem"
        Me.ProcesarIntegraciónToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.ProcesarIntegraciónToolStripMenuItem.Text = "Procesar integración"
        '
        'ProcesarToolStripMenuItem
        '
        Me.ProcesarToolStripMenuItem.Name = "ProcesarToolStripMenuItem"
        Me.ProcesarToolStripMenuItem.Size = New System.Drawing.Size(263, 24)
        Me.ProcesarToolStripMenuItem.Text = "Procesar"
        '
        'frmBzis_procab
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1296, 813)
        Me.Controls.Add(Me.btnDetalle)
        Me.Name = "frmBzis_procab"
        Me.Tag = ""
        Me.Text = "Browse Proceso Integracion - Cabecera"
        Me.Controls.SetChildIndex(Me.btnAgregar, 0)
        Me.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.Controls.SetChildIndex(Me.btnBorrar, 0)
        Me.Controls.SetChildIndex(Me.btnConsultar, 0)
        Me.Controls.SetChildIndex(Me.btnAuditoria, 0)
        Me.Controls.SetChildIndex(Me.btnSalir, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.Controls.SetChildIndex(Me.btnDetalle, 0)
        Me.mnuProcesamiento.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDetalle As Button
    Friend WithEvents ProcesarIntegraciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcesarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnuProcesamiento As ContextMenuStrip
    Friend WithEvents ProcesarManualmenteToolStripMenuItem As ToolStripMenuItem
End Class
