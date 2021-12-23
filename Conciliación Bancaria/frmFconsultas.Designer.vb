<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFconsultas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.rdrExtractoBanco = New System.Windows.Forms.RadioButton()
        Me.rdrLibroMayor = New System.Windows.Forms.RadioButton()
        Me.rdrExtractoConciliado = New System.Windows.Forms.RadioButton()
        Me.rdrMayorConciliado = New System.Windows.Forms.RadioButton()
        Me.cmbFecha = New System.Windows.Forms.ComboBox()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.lblRegistro = New System.Windows.Forms.Label()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblConciliación = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Candara", 17.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(200, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(412, 28)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Seleccione la consulta que desea realizar"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "XLSX|*.xlsx|XLS|*.xls"
        Me.OpenFileDialog1.Title = "Planilla Excel"
        '
        'rdrExtractoBanco
        '
        Me.rdrExtractoBanco.AutoSize = True
        Me.rdrExtractoBanco.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdrExtractoBanco.ForeColor = System.Drawing.Color.Blue
        Me.rdrExtractoBanco.Location = New System.Drawing.Point(66, 110)
        Me.rdrExtractoBanco.Name = "rdrExtractoBanco"
        Me.rdrExtractoBanco.Size = New System.Drawing.Size(132, 22)
        Me.rdrExtractoBanco.TabIndex = 2
        Me.rdrExtractoBanco.TabStop = True
        Me.rdrExtractoBanco.Text = "Extracto Bancario"
        Me.rdrExtractoBanco.UseVisualStyleBackColor = True
        '
        'rdrLibroMayor
        '
        Me.rdrLibroMayor.AutoSize = True
        Me.rdrLibroMayor.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdrLibroMayor.ForeColor = System.Drawing.Color.Blue
        Me.rdrLibroMayor.Location = New System.Drawing.Point(249, 110)
        Me.rdrLibroMayor.Name = "rdrLibroMayor"
        Me.rdrLibroMayor.Size = New System.Drawing.Size(100, 22)
        Me.rdrLibroMayor.TabIndex = 3
        Me.rdrLibroMayor.TabStop = True
        Me.rdrLibroMayor.Text = "Libro Mayor"
        Me.rdrLibroMayor.UseVisualStyleBackColor = True
        '
        'rdrExtractoConciliado
        '
        Me.rdrExtractoConciliado.AutoSize = True
        Me.rdrExtractoConciliado.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdrExtractoConciliado.ForeColor = System.Drawing.Color.Blue
        Me.rdrExtractoConciliado.Location = New System.Drawing.Point(417, 110)
        Me.rdrExtractoConciliado.Name = "rdrExtractoConciliado"
        Me.rdrExtractoConciliado.Size = New System.Drawing.Size(144, 22)
        Me.rdrExtractoConciliado.TabIndex = 4
        Me.rdrExtractoConciliado.TabStop = True
        Me.rdrExtractoConciliado.Text = "Extracto Conciliado"
        Me.rdrExtractoConciliado.UseVisualStyleBackColor = True
        '
        'rdrMayorConciliado
        '
        Me.rdrMayorConciliado.AutoSize = True
        Me.rdrMayorConciliado.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdrMayorConciliado.ForeColor = System.Drawing.Color.Blue
        Me.rdrMayorConciliado.Location = New System.Drawing.Point(610, 110)
        Me.rdrMayorConciliado.Name = "rdrMayorConciliado"
        Me.rdrMayorConciliado.Size = New System.Drawing.Size(168, 22)
        Me.rdrMayorConciliado.TabIndex = 5
        Me.rdrMayorConciliado.TabStop = True
        Me.rdrMayorConciliado.Text = "Libro Mayor Conciliado"
        Me.rdrMayorConciliado.UseVisualStyleBackColor = True
        '
        'cmbFecha
        '
        Me.cmbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFecha.FormattingEnabled = True
        Me.cmbFecha.Location = New System.Drawing.Point(230, 202)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(121, 21)
        Me.cmbFecha.TabIndex = 6
        '
        'cmbBanco
        '
        Me.cmbBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBanco.FormattingEnabled = True
        Me.cmbBanco.Location = New System.Drawing.Point(503, 202)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(165, 21)
        Me.cmbBanco.TabIndex = 7
        '
        'lblRegistro
        '
        Me.lblRegistro.AutoSize = True
        Me.lblRegistro.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistro.ForeColor = System.Drawing.Color.Blue
        Me.lblRegistro.Location = New System.Drawing.Point(98, 203)
        Me.lblRegistro.Name = "lblRegistro"
        Me.lblRegistro.Size = New System.Drawing.Size(121, 18)
        Me.lblRegistro.TabIndex = 8
        Me.lblRegistro.Text = "Fecha de Registro:"
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBanco.ForeColor = System.Drawing.Color.Blue
        Me.lblBanco.Location = New System.Drawing.Point(440, 203)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(49, 18)
        Me.lblBanco.TabIndex = 9
        Me.lblBanco.Text = "Banco:"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.Blue
        Me.btnAceptar.Location = New System.Drawing.Point(220, 320)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 30)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.Blue
        Me.btnCancelar.Location = New System.Drawing.Point(516, 318)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 30)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'lblConciliación
        '
        Me.lblConciliación.AutoSize = True
        Me.lblConciliación.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConciliación.ForeColor = System.Drawing.Color.Blue
        Me.lblConciliación.Location = New System.Drawing.Point(76, 203)
        Me.lblConciliación.Name = "lblConciliación"
        Me.lblConciliación.Size = New System.Drawing.Size(145, 18)
        Me.lblConciliación.TabIndex = 12
        Me.lblConciliación.Text = "Fecha de Conciliación:"
        '
        'frmFconsultas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 447)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblConciliación)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblBanco)
        Me.Controls.Add(Me.lblRegistro)
        Me.Controls.Add(Me.cmbBanco)
        Me.Controls.Add(Me.cmbFecha)
        Me.Controls.Add(Me.rdrMayorConciliado)
        Me.Controls.Add(Me.rdrExtractoConciliado)
        Me.Controls.Add(Me.rdrLibroMayor)
        Me.Controls.Add(Me.rdrExtractoBanco)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmFconsultas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Tag = "    "
        Me.Text = "Consultas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents rdrExtractoBanco As RadioButton
    Friend WithEvents rdrLibroMayor As RadioButton
    Friend WithEvents rdrExtractoConciliado As RadioButton
    Friend WithEvents rdrMayorConciliado As RadioButton
    Friend WithEvents cmbFecha As ComboBox
    Friend WithEvents cmbBanco As ComboBox
    Friend WithEvents lblRegistro As Label
    Friend WithEvents lblBanco As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblConciliación As Label
End Class
