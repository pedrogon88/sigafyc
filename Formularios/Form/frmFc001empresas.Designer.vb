<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFc001empresas
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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNombre_AN = New System.Windows.Forms.TextBox()
        Me.txtCodigo_NE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAbreviado_AN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodMoneda_AN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRuc_AN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNombreMoneda = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblNombreResultado3 = New System.Windows.Forms.Label()
        Me.lblNombreResultado2 = New System.Windows.Forms.Label()
        Me.lblNombreResultado1 = New System.Windows.Forms.Label()
        Me.txtCtaResultado3_AN = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCtaResultado2__AN = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCtaResultado1_AN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtTelefono_AN = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCiudad_AN = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDireccion_AN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPeriodoInicio_FE = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPeriodoFinal_FE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Size = New System.Drawing.Size(896, 406)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage3, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage4, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtPeriodoFinal_FE)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.txtPeriodoInicio_FE)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.lblNombreMoneda)
        Me.TabPage1.Controls.Add(Me.txtRuc_AN)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtCodMoneda_AN)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtAbreviado_AN)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtNombre_AN)
        Me.TabPage1.Controls.Add(Me.txtCodigo_NE)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Size = New System.Drawing.Size(888, 366)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(16, 461)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(771, 461)
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleName = "Activo"
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 36)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(888, 366)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Complementario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(90, 14)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(196, 32)
        Me.cmbEstado.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 24)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Estado:"
        '
        'txtNombre_AN
        '
        Me.txtNombre_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre_AN.Location = New System.Drawing.Point(153, 66)
        Me.txtNombre_AN.Name = "txtNombre_AN"
        Me.txtNombre_AN.Size = New System.Drawing.Size(644, 29)
        Me.txtNombre_AN.TabIndex = 14
        '
        'txtCodigo_NE
        '
        Me.txtCodigo_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo_NE.Location = New System.Drawing.Point(153, 19)
        Me.txtCodigo_NE.Name = "txtCodigo_NE"
        Me.txtCodigo_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtCodigo_NE.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 24)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Nombre "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 24)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Codigo:"
        '
        'txtAbreviado_AN
        '
        Me.txtAbreviado_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAbreviado_AN.Location = New System.Drawing.Point(153, 113)
        Me.txtAbreviado_AN.Name = "txtAbreviado_AN"
        Me.txtAbreviado_AN.Size = New System.Drawing.Size(329, 29)
        Me.txtAbreviado_AN.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 24)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Abreviado:"
        '
        'txtCodMoneda_AN
        '
        Me.txtCodMoneda_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodMoneda_AN.Location = New System.Drawing.Point(153, 160)
        Me.txtCodMoneda_AN.Name = "txtCodMoneda_AN"
        Me.txtCodMoneda_AN.Size = New System.Drawing.Size(64, 29)
        Me.txtCodMoneda_AN.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 24)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Moneda:"
        '
        'txtRuc_AN
        '
        Me.txtRuc_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc_AN.Location = New System.Drawing.Point(153, 207)
        Me.txtRuc_AN.Name = "txtRuc_AN"
        Me.txtRuc_AN.Size = New System.Drawing.Size(329, 29)
        Me.txtRuc_AN.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 24)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "R.U.C.:"
        '
        'lblNombreMoneda
        '
        Me.lblNombreMoneda.Location = New System.Drawing.Point(223, 162)
        Me.lblNombreMoneda.Name = "lblNombreMoneda"
        Me.lblNombreMoneda.Size = New System.Drawing.Size(259, 24)
        Me.lblNombreMoneda.TabIndex = 23
        '
        'TabPage3
        '
        Me.TabPage3.AccessibleName = "Activo"
        Me.TabPage3.Controls.Add(Me.lblNombreResultado3)
        Me.TabPage3.Controls.Add(Me.lblNombreResultado2)
        Me.TabPage3.Controls.Add(Me.lblNombreResultado1)
        Me.TabPage3.Controls.Add(Me.txtCtaResultado3_AN)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.txtCtaResultado2__AN)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.txtCtaResultado1_AN)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Location = New System.Drawing.Point(4, 36)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(888, 366)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Cuentas resultado"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lblNombreResultado3
        '
        Me.lblNombreResultado3.Location = New System.Drawing.Point(132, 205)
        Me.lblNombreResultado3.Name = "lblNombreResultado3"
        Me.lblNombreResultado3.Size = New System.Drawing.Size(718, 24)
        Me.lblNombreResultado3.TabIndex = 36
        '
        'lblNombreResultado2
        '
        Me.lblNombreResultado2.Location = New System.Drawing.Point(132, 130)
        Me.lblNombreResultado2.Name = "lblNombreResultado2"
        Me.lblNombreResultado2.Size = New System.Drawing.Size(718, 24)
        Me.lblNombreResultado2.TabIndex = 35
        '
        'lblNombreResultado1
        '
        Me.lblNombreResultado1.Location = New System.Drawing.Point(132, 56)
        Me.lblNombreResultado1.Name = "lblNombreResultado1"
        Me.lblNombreResultado1.Size = New System.Drawing.Size(718, 24)
        Me.lblNombreResultado1.TabIndex = 34
        '
        'txtCtaResultado3_AN
        '
        Me.txtCtaResultado3_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCtaResultado3_AN.Location = New System.Drawing.Point(136, 172)
        Me.txtCtaResultado3_AN.Name = "txtCtaResultado3_AN"
        Me.txtCtaResultado3_AN.Size = New System.Drawing.Size(249, 29)
        Me.txtCtaResultado3_AN.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 177)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 24)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Acumulado:"
        '
        'txtCtaResultado2__AN
        '
        Me.txtCtaResultado2__AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCtaResultado2__AN.Location = New System.Drawing.Point(136, 98)
        Me.txtCtaResultado2__AN.Name = "txtCtaResultado2__AN"
        Me.txtCtaResultado2__AN.Size = New System.Drawing.Size(249, 29)
        Me.txtCtaResultado2__AN.TabIndex = 30
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 24)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Anterior:"
        '
        'txtCtaResultado1_AN
        '
        Me.txtCtaResultado1_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCtaResultado1_AN.Location = New System.Drawing.Point(136, 24)
        Me.txtCtaResultado1_AN.Name = "txtCtaResultado1_AN"
        Me.txtCtaResultado1_AN.Size = New System.Drawing.Size(249, 29)
        Me.txtCtaResultado1_AN.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 24)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Actual:"
        '
        'TabPage4
        '
        Me.TabPage4.AccessibleName = "Activo"
        Me.TabPage4.Controls.Add(Me.txtTelefono_AN)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.txtCiudad_AN)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.txtDireccion_AN)
        Me.TabPage4.Controls.Add(Me.Label6)
        Me.TabPage4.Location = New System.Drawing.Point(4, 36)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(888, 366)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Ubicacion"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtTelefono_AN
        '
        Me.txtTelefono_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelefono_AN.Location = New System.Drawing.Point(121, 115)
        Me.txtTelefono_AN.Name = "txtTelefono_AN"
        Me.txtTelefono_AN.Size = New System.Drawing.Size(519, 29)
        Me.txtTelefono_AN.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 24)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Telefonos:"
        '
        'txtCiudad_AN
        '
        Me.txtCiudad_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCiudad_AN.Location = New System.Drawing.Point(121, 66)
        Me.txtCiudad_AN.Name = "txtCiudad_AN"
        Me.txtCiudad_AN.Size = New System.Drawing.Size(519, 29)
        Me.txtCiudad_AN.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 24)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Ciudad:"
        '
        'txtDireccion_AN
        '
        Me.txtDireccion_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion_AN.Location = New System.Drawing.Point(121, 19)
        Me.txtDireccion_AN.Name = "txtDireccion_AN"
        Me.txtDireccion_AN.Size = New System.Drawing.Size(744, 29)
        Me.txtDireccion_AN.TabIndex = 30
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 24)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Direccion:"
        '
        'txtPeriodoInicio_FE
        '
        Me.txtPeriodoInicio_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodoInicio_FE.Location = New System.Drawing.Point(153, 254)
        Me.txtPeriodoInicio_FE.Name = "txtPeriodoInicio_FE"
        Me.txtPeriodoInicio_FE.Size = New System.Drawing.Size(192, 29)
        Me.txtPeriodoInicio_FE.TabIndex = 24
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 256)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(133, 24)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Periodo inicial:"
        '
        'txtPeriodoFinal_FE
        '
        Me.txtPeriodoFinal_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodoFinal_FE.Location = New System.Drawing.Point(153, 301)
        Me.txtPeriodoFinal_FE.Name = "txtPeriodoFinal_FE"
        Me.txtPeriodoFinal_FE.Size = New System.Drawing.Size(192, 29)
        Me.txtPeriodoFinal_FE.TabIndex = 26
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 303)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(119, 24)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Periodo final:"
        '
        'frmFc001empresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(916, 547)
        Me.Name = "frmFc001empresas"
        Me.Tag = ""
        Me.Text = "Formulario de Empresa"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtAbreviado_AN As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNombre_AN As TextBox
    Friend WithEvents txtCodigo_NE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCodMoneda_AN As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNombreMoneda As Label
    Friend WithEvents txtRuc_AN As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents txtTelefono_AN As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCiudad_AN As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDireccion_AN As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblNombreResultado3 As Label
    Friend WithEvents lblNombreResultado2 As Label
    Friend WithEvents lblNombreResultado1 As Label
    Friend WithEvents txtCtaResultado3_AN As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCtaResultado2__AN As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCtaResultado1_AN As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPeriodoFinal_FE As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtPeriodoInicio_FE As TextBox
    Friend WithEvents Label13 As Label
End Class
