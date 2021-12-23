<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFLoginAcceso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFLoginAcceso))
        Me.DatosSysAdmin = New System.Windows.Forms.GroupBox()
        Me.txtPassword_AN = New System.Windows.Forms.TextBox()
        Me.txtUsuario_AB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.DatosSysAdmin.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DatosSysAdmin
        '
        Me.DatosSysAdmin.BackColor = System.Drawing.Color.Transparent
        Me.DatosSysAdmin.Controls.Add(Me.txtPassword_AN)
        Me.DatosSysAdmin.Controls.Add(Me.txtUsuario_AB)
        Me.DatosSysAdmin.Controls.Add(Me.Label1)
        Me.DatosSysAdmin.Controls.Add(Me.Label2)
        Me.DatosSysAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DatosSysAdmin.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatosSysAdmin.Location = New System.Drawing.Point(19, 110)
        Me.DatosSysAdmin.Margin = New System.Windows.Forms.Padding(4)
        Me.DatosSysAdmin.Name = "DatosSysAdmin"
        Me.DatosSysAdmin.Padding = New System.Windows.Forms.Padding(4)
        Me.DatosSysAdmin.Size = New System.Drawing.Size(359, 126)
        Me.DatosSysAdmin.TabIndex = 9
        Me.DatosSysAdmin.TabStop = False
        Me.DatosSysAdmin.Text = "datos para ingresar"
        '
        'txtPassword_AN
        '
        Me.txtPassword_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword_AN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword_AN.Location = New System.Drawing.Point(118, 76)
        Me.txtPassword_AN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword_AN.Name = "txtPassword_AN"
        Me.txtPassword_AN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword_AN.Size = New System.Drawing.Size(219, 26)
        Me.txtPassword_AN.TabIndex = 1
        '
        'txtUsuario_AB
        '
        Me.txtUsuario_AB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuario_AB.CausesValidation = False
        Me.txtUsuario_AB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario_AB.Location = New System.Drawing.Point(118, 36)
        Me.txtUsuario_AB.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsuario_AB.Name = "txtUsuario_AB"
        Me.txtUsuario_AB.Size = New System.Drawing.Size(219, 26)
        Me.txtUsuario_AB.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 78)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Password:"
        '
        'btnCancelar
        '
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.sigafyc.My.Resources.Resources.icons8_blue_cancel_32
        Me.btnCancelar.Location = New System.Drawing.Point(19, 244)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(135, 74)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Tag = "Cancelar"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.sigafyc.My.Resources.Resources.timbo_2273x22711
        Me.PictureBox1.Location = New System.Drawing.Point(151, 13)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(93, 89)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.sigafyc.My.Resources.Resources.icons8_blue_ok_32
        Me.btnAceptar.Location = New System.Drawing.Point(243, 244)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(135, 74)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Tag = "Aceptar"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmFLoginAcceso
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(394, 336)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.DatosSysAdmin)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmFLoginAcceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso al Sistema"
        Me.DatosSysAdmin.ResumeLayout(False)
        Me.DatosSysAdmin.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents btnCancelar As Button
    Public WithEvents btnAceptar As Button
    Friend WithEvents DatosSysAdmin As GroupBox
    Friend WithEvents txtPassword_AN As TextBox
    Friend WithEvents txtUsuario_AB As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
