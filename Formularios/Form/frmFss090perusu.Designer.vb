<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFss090perusu
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
        Me.txtSS070_codigo_AN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSS050_codigo_AB = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNombreUsuario = New System.Windows.Forms.Label()
        Me.lblNombrePerfil = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(21, 74)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.TabControl1.Size = New System.Drawing.Size(908, 298)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblNombrePerfil)
        Me.TabPage1.Controls.Add(Me.lblNombreUsuario)
        Me.TabPage1.Controls.Add(Me.txtSS050_codigo_AB)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtSS070_codigo_AN)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 37)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.TabPage1.Size = New System.Drawing.Size(900, 257)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(26, 378)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnCancelar.Size = New System.Drawing.Size(150, 97)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(774, 378)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnAceptar.Size = New System.Drawing.Size(150, 97)
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(21, 14)
        Me.lblMensaje.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblMensaje.Size = New System.Drawing.Size(903, 46)
        '
        'txtSS070_codigo_AN
        '
        Me.txtSS070_codigo_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSS070_codigo_AN.Location = New System.Drawing.Point(229, 135)
        Me.txtSS070_codigo_AN.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSS070_codigo_AN.Name = "txtSS070_codigo_AN"
        Me.txtSS070_codigo_AN.Size = New System.Drawing.Size(313, 30)
        Me.txtSS070_codigo_AN.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 139)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 25)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Codigo perfil:"
        '
        'txtSS050_codigo_AB
        '
        Me.txtSS050_codigo_AB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSS050_codigo_AB.Location = New System.Drawing.Point(229, 21)
        Me.txtSS050_codigo_AB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSS050_codigo_AB.Name = "txtSS050_codigo_AB"
        Me.txtSS050_codigo_AB.Size = New System.Drawing.Size(313, 30)
        Me.txtSS050_codigo_AB.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 25)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Codigo usuario:"
        '
        'lblNombreUsuario
        '
        Me.lblNombreUsuario.AutoSize = True
        Me.lblNombreUsuario.Location = New System.Drawing.Point(224, 60)
        Me.lblNombreUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreUsuario.Name = "lblNombreUsuario"
        Me.lblNombreUsuario.Size = New System.Drawing.Size(171, 25)
        Me.lblNombreUsuario.TabIndex = 18
        Me.lblNombreUsuario.Text = "<nombre usuario>"
        '
        'lblNombrePerfil
        '
        Me.lblNombrePerfil.AutoSize = True
        Me.lblNombrePerfil.Location = New System.Drawing.Point(224, 175)
        Me.lblNombrePerfil.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombrePerfil.Name = "lblNombrePerfil"
        Me.lblNombrePerfil.Size = New System.Drawing.Size(148, 25)
        Me.lblNombrePerfil.TabIndex = 19
        Me.lblNombrePerfil.Text = "<nombre perfil>"
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleName = "Activo"
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(900, 253)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Complementario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(312, 26)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(260, 33)
        Me.cmbEstado.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 30)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 25)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Estado operativo:"
        '
        'frmFss090perusu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(933, 484)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "frmFss090perusu"
        Me.Tag = ""
        Me.Text = "Formulario Perfiles por Usuario"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtSS070_codigo_AN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSS050_codigo_AB As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNombrePerfil As Label
    Friend WithEvents lblNombreUsuario As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
End Class
