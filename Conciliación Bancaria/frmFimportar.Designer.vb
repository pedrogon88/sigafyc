<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFimportar
    Inherits System.Windows.Forms.Form

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
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.txtExaminar = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rdbExtracto = New System.Windows.Forms.RadioButton()
        Me.rdbMayor = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnExaminar
        '
        Me.btnExaminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExaminar.FlatAppearance.BorderSize = 3
        Me.btnExaminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue
        Me.btnExaminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExaminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExaminar.ForeColor = System.Drawing.Color.Blue
        Me.btnExaminar.Location = New System.Drawing.Point(561, 78)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(81, 31)
        Me.btnExaminar.TabIndex = 0
        Me.btnExaminar.Text = "Examinar"
        Me.btnExaminar.UseVisualStyleBackColor = False
        '
        'txtExaminar
        '
        Me.txtExaminar.Location = New System.Drawing.Point(211, 83)
        Me.txtExaminar.Name = "txtExaminar"
        Me.txtExaminar.Size = New System.Drawing.Size(329, 20)
        Me.txtExaminar.TabIndex = 1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "XLSX|*.xlsx|XLS|*.xls"
        Me.OpenFileDialog1.Title = "Excel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(73, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ubicación del archivo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(74, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(376, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Seleccione el botón ""Examinar"" para importar el archivo Excel"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.Blue
        Me.btnGuardar.Location = New System.Drawing.Point(198, 305)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(108, 31)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Blue
        Me.btnCancelar.Location = New System.Drawing.Point(472, 305)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(101, 31)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'rdbExtracto
        '
        Me.rdbExtracto.AutoSize = True
        Me.rdbExtracto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbExtracto.ForeColor = System.Drawing.Color.Blue
        Me.rdbExtracto.Location = New System.Drawing.Point(77, 171)
        Me.rdbExtracto.Name = "rdbExtracto"
        Me.rdbExtracto.Size = New System.Drawing.Size(74, 20)
        Me.rdbExtracto.TabIndex = 6
        Me.rdbExtracto.TabStop = True
        Me.rdbExtracto.Text = "Extracto"
        Me.rdbExtracto.UseVisualStyleBackColor = True
        '
        'rdbMayor
        '
        Me.rdbMayor.AutoSize = True
        Me.rdbMayor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbMayor.ForeColor = System.Drawing.Color.Blue
        Me.rdbMayor.Location = New System.Drawing.Point(75, 208)
        Me.rdbMayor.Name = "rdbMayor"
        Me.rdbMayor.Size = New System.Drawing.Size(97, 20)
        Me.rdbMayor.TabIndex = 7
        Me.rdbMayor.TabStop = True
        Me.rdbMayor.Text = "Libro Mayor"
        Me.rdbMayor.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(73, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Tipo de Planilla"
        '
        'frmFimportar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rdbMayor)
        Me.Controls.Add(Me.rdbExtracto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtExaminar)
        Me.Controls.Add(Me.btnExaminar)
        Me.ForeColor = System.Drawing.Color.Blue
        Me.Name = "frmFimportar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = " "
        Me.Text = "Importar Excel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExaminar As Button
    Friend WithEvents txtExaminar As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents rdbExtracto As RadioButton
    Friend WithEvents rdbMayor As RadioButton
    Friend WithEvents Label3 As Label
End Class
