<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRPlanCuentas : Inherits frmFormulario

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
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.txtCodEmpresa_NE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbxGrupo = New System.Windows.Forms.GroupBox()
        Me.rbtNIvel6 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel5 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel4 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel3 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel2 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel1 = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbxGrupo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(8, 12)
        Me.TabControl1.Size = New System.Drawing.Size(568, 206)
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.gbxGrupo)
        Me.TabPage1.Controls.Add(Me.lblNombreEmpresa)
        Me.TabPage1.Controls.Add(Me.txtCodEmpresa_NE)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Size = New System.Drawing.Size(560, 166)
        Me.TabPage1.Text = "Parametros requeridos"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(12, 220)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(439, 220)
        '
        'lblMensaje
        '
        Me.lblMensaje.Size = New System.Drawing.Size(564, 37)
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(244, 25)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(214, 24)
        Me.lblNombreEmpresa.TabIndex = 59
        Me.lblNombreEmpresa.Text = "<nombre_de_empresa>"
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(113, 23)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 24)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Empresa:"
        '
        'gbxGrupo
        '
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel6)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel5)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel4)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel3)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel2)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel1)
        Me.gbxGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxGrupo.Location = New System.Drawing.Point(20, 72)
        Me.gbxGrupo.Name = "gbxGrupo"
        Me.gbxGrupo.Size = New System.Drawing.Size(517, 68)
        Me.gbxGrupo.TabIndex = 60
        Me.gbxGrupo.TabStop = False
        Me.gbxGrupo.Text = "nivel"
        '
        'rbtNIvel6
        '
        Me.rbtNIvel6.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel6.Location = New System.Drawing.Point(419, 25)
        Me.rbtNIvel6.Name = "rbtNIvel6"
        Me.rbtNIvel6.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel6.TabIndex = 5
        Me.rbtNIvel6.TabStop = True
        Me.rbtNIvel6.Text = "6"
        Me.rbtNIvel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel6.UseVisualStyleBackColor = True
        '
        'rbtNIvel5
        '
        Me.rbtNIvel5.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel5.Location = New System.Drawing.Point(341, 25)
        Me.rbtNIvel5.Name = "rbtNIvel5"
        Me.rbtNIvel5.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel5.TabIndex = 4
        Me.rbtNIvel5.TabStop = True
        Me.rbtNIvel5.Text = "5"
        Me.rbtNIvel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel5.UseVisualStyleBackColor = True
        '
        'rbtNIvel4
        '
        Me.rbtNIvel4.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel4.Location = New System.Drawing.Point(263, 25)
        Me.rbtNIvel4.Name = "rbtNIvel4"
        Me.rbtNIvel4.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel4.TabIndex = 3
        Me.rbtNIvel4.TabStop = True
        Me.rbtNIvel4.Text = "4"
        Me.rbtNIvel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel4.UseVisualStyleBackColor = True
        '
        'rbtNIvel3
        '
        Me.rbtNIvel3.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel3.Location = New System.Drawing.Point(185, 25)
        Me.rbtNIvel3.Name = "rbtNIvel3"
        Me.rbtNIvel3.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel3.TabIndex = 2
        Me.rbtNIvel3.TabStop = True
        Me.rbtNIvel3.Text = "3"
        Me.rbtNIvel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel3.UseVisualStyleBackColor = True
        '
        'rbtNIvel2
        '
        Me.rbtNIvel2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel2.Location = New System.Drawing.Point(107, 25)
        Me.rbtNIvel2.Name = "rbtNIvel2"
        Me.rbtNIvel2.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel2.TabIndex = 1
        Me.rbtNIvel2.TabStop = True
        Me.rbtNIvel2.Text = "2"
        Me.rbtNIvel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel2.UseVisualStyleBackColor = True
        '
        'rbtNIvel1
        '
        Me.rbtNIvel1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel1.Location = New System.Drawing.Point(29, 25)
        Me.rbtNIvel1.Name = "rbtNIvel1"
        Me.rbtNIvel1.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel1.TabIndex = 0
        Me.rbtNIvel1.TabStop = True
        Me.rbtNIvel1.Text = "1"
        Me.rbtNIvel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel1.UseVisualStyleBackColor = True
        '
        'frmRPlanCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(584, 306)
        Me.Name = "frmRPlanCuentas"
        Me.Tag = ""
        Me.Text = "Parametros Impresion Plan de Cuentas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbxGrupo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents gbxGrupo As GroupBox
    Friend WithEvents rbtNIvel6 As RadioButton
    Friend WithEvents rbtNIvel5 As RadioButton
    Friend WithEvents rbtNIvel4 As RadioButton
    Friend WithEvents rbtNIvel3 As RadioButton
    Friend WithEvents rbtNIvel2 As RadioButton
    Friend WithEvents rbtNIvel1 As RadioButton
End Class
