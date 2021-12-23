<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMBalances
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMBalances))
        Me.btnCuadroPatrimonial = New System.Windows.Forms.Button()
        Me.btnCuadroResultado = New System.Windows.Forms.Button()
        Me.btnBalance8Columnas = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCuadroPatrimonial
        '
        Me.btnCuadroPatrimonial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCuadroPatrimonial.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCuadroPatrimonial.Location = New System.Drawing.Point(32, 80)
        Me.btnCuadroPatrimonial.Name = "btnCuadroPatrimonial"
        Me.btnCuadroPatrimonial.Size = New System.Drawing.Size(183, 47)
        Me.btnCuadroPatrimonial.TabIndex = 1
        Me.btnCuadroPatrimonial.Text = "Cuadro Patrimonial"
        Me.btnCuadroPatrimonial.UseVisualStyleBackColor = True
        '
        'btnCuadroResultado
        '
        Me.btnCuadroResultado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCuadroResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCuadroResultado.Location = New System.Drawing.Point(32, 133)
        Me.btnCuadroResultado.Name = "btnCuadroResultado"
        Me.btnCuadroResultado.Size = New System.Drawing.Size(183, 47)
        Me.btnCuadroResultado.TabIndex = 2
        Me.btnCuadroResultado.Text = "Cuadro de Resultados"
        Me.btnCuadroResultado.UseVisualStyleBackColor = True
        '
        'btnBalance8Columnas
        '
        Me.btnBalance8Columnas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBalance8Columnas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBalance8Columnas.Location = New System.Drawing.Point(32, 27)
        Me.btnBalance8Columnas.Name = "btnBalance8Columnas"
        Me.btnBalance8Columnas.Size = New System.Drawing.Size(183, 47)
        Me.btnBalance8Columnas.TabIndex = 0
        Me.btnBalance8Columnas.Text = "Balance a 8 columnas"
        Me.btnBalance8Columnas.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(276, 315)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 27)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(68, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "presione <ESC> para salir"
        '
        'frmMBalances
        '
        Me.AcceptButton = Me.btnBalance8Columnas
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnSalir
        Me.ClientSize = New System.Drawing.Size(246, 207)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBalance8Columnas)
        Me.Controls.Add(Me.btnCuadroResultado)
        Me.Controls.Add(Me.btnCuadroPatrimonial)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMBalances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Balance General"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCuadroPatrimonial As Button
    Friend WithEvents btnCuadroResultado As Button
    Friend WithEvents btnBalance8Columnas As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label1 As Label
End Class
