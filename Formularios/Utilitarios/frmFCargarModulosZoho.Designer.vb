<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFCargarModulosZoho
    Inherits frmFormulario

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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtNO = New System.Windows.Forms.RadioButton()
        Me.rbtSI = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtModulosPermitidos_AN = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(10, 61)
        Me.TabControl1.Size = New System.Drawing.Size(1195, 371)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Size = New System.Drawing.Size(1187, 326)
        Me.TabPage1.Text = "Parametros"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(14, 436)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(1024, 436)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbtNO)
        Me.GroupBox2.Controls.Add(Me.rbtSI)
        Me.GroupBox2.Location = New System.Drawing.Point(39, 178)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(511, 125)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "desea eliminar el detalle campos existente"
        '
        'rbtNO
        '
        Me.rbtNO.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNO.Location = New System.Drawing.Point(268, 42)
        Me.rbtNO.Name = "rbtNO"
        Me.rbtNO.Size = New System.Drawing.Size(115, 58)
        Me.rbtNO.TabIndex = 1
        Me.rbtNO.TabStop = True
        Me.rbtNO.Text = "NO"
        Me.rbtNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNO.UseVisualStyleBackColor = True
        '
        'rbtSI
        '
        Me.rbtSI.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtSI.Location = New System.Drawing.Point(127, 42)
        Me.rbtSI.Name = "rbtSI"
        Me.rbtSI.Size = New System.Drawing.Size(115, 58)
        Me.rbtSI.TabIndex = 0
        Me.rbtSI.TabStop = True
        Me.rbtSI.Text = "SI"
        Me.rbtSI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtSI.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtModulosPermitidos_AN)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1103, 107)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "parametros de modulos permitidos"
        '
        'txtModulosPermitidos_AN
        '
        Me.txtModulosPermitidos_AN.Location = New System.Drawing.Point(19, 54)
        Me.txtModulosPermitidos_AN.Name = "txtModulosPermitidos_AN"
        Me.txtModulosPermitidos_AN.Size = New System.Drawing.Size(1064, 34)
        Me.txtModulosPermitidos_AN.TabIndex = 0
        '
        'frmFCargarModulosZoho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(1216, 538)
        Me.Name = "frmFCargarModulosZoho"
        Me.Tag = ""
        Me.Text = "Modulos de Zoho - inicializaciones"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbtNO As RadioButton
    Friend WithEvents rbtSI As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtModulosPermitidos_AN As TextBox
End Class
