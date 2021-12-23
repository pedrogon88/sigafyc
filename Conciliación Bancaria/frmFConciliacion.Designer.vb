<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFconciliacion
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
        Me.btnConciliacion = New System.Windows.Forms.Button()
        Me.btnDesExtracto = New System.Windows.Forms.Button()
        Me.btnDescMayor = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnConciliacion
        '
        Me.btnConciliacion.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnConciliacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConciliacion.Font = New System.Drawing.Font("Malgun Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConciliacion.ForeColor = System.Drawing.Color.Blue
        Me.btnConciliacion.Location = New System.Drawing.Point(206, 76)
        Me.btnConciliacion.Name = "btnConciliacion"
        Me.btnConciliacion.Size = New System.Drawing.Size(358, 64)
        Me.btnConciliacion.TabIndex = 0
        Me.btnConciliacion.Text = "Iniciar Conciliación"
        Me.btnConciliacion.UseVisualStyleBackColor = False
        '
        'btnDesExtracto
        '
        Me.btnDesExtracto.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDesExtracto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesExtracto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesExtracto.ForeColor = System.Drawing.Color.Blue
        Me.btnDesExtracto.Location = New System.Drawing.Point(89, 308)
        Me.btnDesExtracto.Name = "btnDesExtracto"
        Me.btnDesExtracto.Size = New System.Drawing.Size(143, 35)
        Me.btnDesExtracto.TabIndex = 1
        Me.btnDesExtracto.Text = "Extracto Conciliado"
        Me.btnDesExtracto.UseVisualStyleBackColor = False
        Me.btnDesExtracto.Visible = False
        '
        'btnDescMayor
        '
        Me.btnDescMayor.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDescMayor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDescMayor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescMayor.ForeColor = System.Drawing.Color.Blue
        Me.btnDescMayor.Location = New System.Drawing.Point(490, 309)
        Me.btnDescMayor.Name = "btnDescMayor"
        Me.btnDescMayor.Size = New System.Drawing.Size(149, 35)
        Me.btnDescMayor.TabIndex = 2
        Me.btnDescMayor.Text = "Libro Mayor Conciliado"
        Me.btnDescMayor.UseVisualStyleBackColor = False
        Me.btnDescMayor.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Blue
        Me.btnCancelar.Location = New System.Drawing.Point(696, 421)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Salir"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'frmFconciliacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(791, 456)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnDescMayor)
        Me.Controls.Add(Me.btnDesExtracto)
        Me.Controls.Add(Me.btnConciliacion)
        Me.Name = "frmFconciliacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = " "
        Me.Text = "Conciliación Bancaria"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnConciliacion As Button
    Friend WithEvents btnDesExtracto As Button
    Friend WithEvents btnDescMayor As Button
    Friend WithEvents btnCancelar As Button
End Class
