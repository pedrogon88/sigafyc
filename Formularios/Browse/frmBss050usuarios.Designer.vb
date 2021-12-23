<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBss050usuarios
    Inherits frmBrowse

    'Form invalida a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
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
        Me.btnAgregar.Size = New System.Drawing.Size(128, 97)
        '
        'frmBss050usuarios
        '
        Me.ClientSize = New System.Drawing.Size(1297, 812)
        Me.Name = "frmBss050usuarios"
        Me.Tag = ""
        Me.Text = "Browse de Usuarios"
        Me.Controls.SetChildIndex(Me.btnAgregar, 0)
        Me.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.Controls.SetChildIndex(Me.btnBorrar, 0)
        Me.Controls.SetChildIndex(Me.btnConsultar, 0)
        Me.Controls.SetChildIndex(Me.btnAuditoria, 0)
        Me.Controls.SetChildIndex(Me.btnSalir, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
