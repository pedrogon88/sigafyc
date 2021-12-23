<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRCuadroPatrimonial : Inherits frmFormulario

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
        Me.lblNombreSucursal = New System.Windows.Forms.Label()
        Me.txtCodSucursal_NE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.txtCodEmpresa_NE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecha1_FE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Size = New System.Drawing.Size(714, 298)
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.gbxGrupo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lblNombreSucursal)
        Me.TabPage1.Controls.Add(Me.txtCodSucursal_NE)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.lblNombreEmpresa)
        Me.TabPage1.Controls.Add(Me.txtCodEmpresa_NE)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtFecha1_FE)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Size = New System.Drawing.Size(706, 258)
        Me.TabPage1.Text = "Parametros requeridos"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(16, 312)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(589, 312)
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(16, 9)
        Me.lblMensaje.Size = New System.Drawing.Size(706, 37)
        '
        'lblNombreSucursal
        '
        Me.lblNombreSucursal.AutoSize = True
        Me.lblNombreSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSucursal.Location = New System.Drawing.Point(257, 67)
        Me.lblNombreSucursal.Name = "lblNombreSucursal"
        Me.lblNombreSucursal.Size = New System.Drawing.Size(195, 24)
        Me.lblNombreSucursal.TabIndex = 105
        Me.lblNombreSucursal.Text = "<nombre_sucursal>"
        '
        'txtCodSucursal_NE
        '
        Me.txtCodSucursal_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodSucursal_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodSucursal_NE.Location = New System.Drawing.Point(136, 65)
        Me.txtCodSucursal_NE.Name = "txtCodSucursal_NE"
        Me.txtCodSucursal_NE.Size = New System.Drawing.Size(74, 29)
        Me.txtCodSucursal_NE.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Sucursal:"
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(257, 23)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(233, 24)
        Me.lblNombreEmpresa.TabIndex = 102
        Me.lblNombreEmpresa.Text = "<nombre_de_empresa>"
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(136, 21)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 24)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Empresa:"
        '
        'txtFecha1_FE
        '
        Me.txtFecha1_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha1_FE.Location = New System.Drawing.Point(136, 113)
        Me.txtFecha1_FE.Name = "txtFecha1_FE"
        Me.txtFecha1_FE.Size = New System.Drawing.Size(162, 29)
        Me.txtFecha1_FE.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(181, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 24)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "Desde:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 24)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Saldo al:"
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
        Me.gbxGrupo.Location = New System.Drawing.Point(95, 160)
        Me.gbxGrupo.Name = "gbxGrupo"
        Me.gbxGrupo.Size = New System.Drawing.Size(517, 68)
        Me.gbxGrupo.TabIndex = 109
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
        'frmRCuadroPatrimonial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(735, 394)
        Me.Name = "frmRCuadroPatrimonial"
        Me.Tag = ""
        Me.Text = "Parametro Impresion Cuadro Patrimonial"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbxGrupo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreSucursal As Label
    Friend WithEvents txtCodSucursal_NE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFecha1_FE As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents gbxGrupo As GroupBox
    Friend WithEvents rbtNIvel6 As RadioButton
    Friend WithEvents rbtNIvel5 As RadioButton
    Friend WithEvents rbtNIvel4 As RadioButton
    Friend WithEvents rbtNIvel3 As RadioButton
    Friend WithEvents rbtNIvel2 As RadioButton
    Friend WithEvents rbtNIvel1 As RadioButton
End Class
