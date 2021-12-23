<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFCambioPassword
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPasswordNuevo2_AN = New System.Windows.Forms.TextBox()
        Me.txtPasswordNuevo_AN = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPasswordActual_AN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Size = New System.Drawing.Size(588, 199)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtPasswordActual_AN)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtPasswordNuevo2_AN)
        Me.TabPage1.Controls.Add(Me.txtPasswordNuevo_AN)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Location = New System.Drawing.Point(4, 36)
        Me.TabPage1.Size = New System.Drawing.Size(580, 159)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(20, 263)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(423, 263)
        '
        'lblMensaje
        '
        Me.lblMensaje.Size = New System.Drawing.Size(584, 37)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(276, 24)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Reingrese la nueva contraseña:"
        '
        'txtPasswordNuevo2_AN
        '
        Me.txtPasswordNuevo2_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPasswordNuevo2_AN.Location = New System.Drawing.Point(316, 108)
        Me.txtPasswordNuevo2_AN.Name = "txtPasswordNuevo2_AN"
        Me.txtPasswordNuevo2_AN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordNuevo2_AN.Size = New System.Drawing.Size(230, 29)
        Me.txtPasswordNuevo2_AN.TabIndex = 2
        '
        'txtPasswordNuevo_AN
        '
        Me.txtPasswordNuevo_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPasswordNuevo_AN.Location = New System.Drawing.Point(316, 67)
        Me.txtPasswordNuevo_AN.Name = "txtPasswordNuevo_AN"
        Me.txtPasswordNuevo_AN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordNuevo_AN.Size = New System.Drawing.Size(230, 29)
        Me.txtPasswordNuevo_AN.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(233, 24)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Ingrese nueva contraseña:"
        '
        'txtPasswordActual_AN
        '
        Me.txtPasswordActual_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPasswordActual_AN.Location = New System.Drawing.Point(316, 22)
        Me.txtPasswordActual_AN.Name = "txtPasswordActual_AN"
        Me.txtPasswordActual_AN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordActual_AN.Size = New System.Drawing.Size(230, 29)
        Me.txtPasswordActual_AN.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 24)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Ingrese contraseña actual:"
        '
        'frmFCambioPassword
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(613, 368)
        Me.Name = "frmFCambioPassword"
        Me.Tag = ""
        Me.Text = "Formulario para Cambiar Contraseña"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtPasswordActual_AN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPasswordNuevo2_AN As TextBox
    Friend WithEvents txtPasswordNuevo_AN As TextBox
    Friend WithEvents Label8 As Label
End Class
