<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFb030cotizaciones : Inherits frmFormulario

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
        Me.lblNombreMoneda1 = New System.Windows.Forms.Label()
        Me.txtCodMoneda1_AN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNombreMoneda2 = New System.Windows.Forms.Label()
        Me.txtCodMoneda2_AN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtValido_FE = New System.Windows.Forms.TextBox()
        Me.gbxGrupo = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVenta_ND = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCompra_ND = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbxGrupo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Size = New System.Drawing.Size(708, 243)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gbxGrupo)
        Me.TabPage1.Controls.Add(Me.txtValido_FE)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.lblNombreMoneda2)
        Me.TabPage1.Controls.Add(Me.txtCodMoneda2_AN)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.lblNombreMoneda1)
        Me.TabPage1.Controls.Add(Me.txtCodMoneda1_AN)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Size = New System.Drawing.Size(700, 203)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(16, 294)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(583, 294)
        '
        'lblMensaje
        '
        Me.lblMensaje.Size = New System.Drawing.Size(704, 37)
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleName = "Activo"
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 36)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(700, 203)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Complementario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(94, 15)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(196, 32)
        Me.cmbEstado.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 24)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Estado:"
        '
        'lblNombreMoneda1
        '
        Me.lblNombreMoneda1.Location = New System.Drawing.Point(217, 84)
        Me.lblNombreMoneda1.Name = "lblNombreMoneda1"
        Me.lblNombreMoneda1.Size = New System.Drawing.Size(187, 24)
        Me.lblNombreMoneda1.TabIndex = 26
        Me.lblNombreMoneda1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodMoneda1_AN
        '
        Me.txtCodMoneda1_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodMoneda1_AN.Location = New System.Drawing.Point(62, 20)
        Me.txtCodMoneda1_AN.Name = "txtCodMoneda1_AN"
        Me.txtCodMoneda1_AN.Size = New System.Drawing.Size(64, 29)
        Me.txtCodMoneda1_AN.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 24)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "De:"
        '
        'lblNombreMoneda2
        '
        Me.lblNombreMoneda2.Location = New System.Drawing.Point(494, 89)
        Me.lblNombreMoneda2.Name = "lblNombreMoneda2"
        Me.lblNombreMoneda2.Size = New System.Drawing.Size(187, 24)
        Me.lblNombreMoneda2.TabIndex = 29
        Me.lblNombreMoneda2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodMoneda2_AN
        '
        Me.txtCodMoneda2_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodMoneda2_AN.Location = New System.Drawing.Point(184, 20)
        Me.txtCodMoneda2_AN.Name = "txtCodMoneda2_AN"
        Me.txtCodMoneda2_AN.Size = New System.Drawing.Size(64, 29)
        Me.txtCodMoneda2_AN.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(150, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 24)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "A:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(399, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 24)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Vigencia:"
        '
        'txtValido_FE
        '
        Me.txtValido_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValido_FE.Location = New System.Drawing.Point(494, 18)
        Me.txtValido_FE.Name = "txtValido_FE"
        Me.txtValido_FE.Size = New System.Drawing.Size(187, 29)
        Me.txtValido_FE.TabIndex = 2
        '
        'gbxGrupo
        '
        Me.gbxGrupo.Controls.Add(Me.Label6)
        Me.gbxGrupo.Controls.Add(Me.txtVenta_ND)
        Me.gbxGrupo.Controls.Add(Me.Label3)
        Me.gbxGrupo.Controls.Add(Me.txtCompra_ND)
        Me.gbxGrupo.Location = New System.Drawing.Point(21, 69)
        Me.gbxGrupo.Name = "gbxGrupo"
        Me.gbxGrupo.Size = New System.Drawing.Size(660, 115)
        Me.gbxGrupo.TabIndex = 3
        Me.gbxGrupo.TabStop = False
        Me.gbxGrupo.Text = "factor de conversión"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(360, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 24)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Venta:"
        '
        'txtVenta_ND
        '
        Me.txtVenta_ND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta_ND.Location = New System.Drawing.Point(430, 44)
        Me.txtVenta_ND.Name = "txtVenta_ND"
        Me.txtVenta_ND.Size = New System.Drawing.Size(187, 29)
        Me.txtVenta_ND.TabIndex = 1
        Me.txtVenta_ND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 24)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Compra:"
        '
        'txtCompra_ND
        '
        Me.txtCompra_ND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCompra_ND.Location = New System.Drawing.Point(132, 42)
        Me.txtCompra_ND.Name = "txtCompra_ND"
        Me.txtCompra_ND.Size = New System.Drawing.Size(187, 29)
        Me.txtCompra_ND.TabIndex = 0
        Me.txtCompra_ND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmFb030cotizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(726, 377)
        Me.Name = "frmFb030cotizaciones"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Tag = ""
        Me.Text = "Formulario de Cotización"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.gbxGrupo.ResumeLayout(False)
        Me.gbxGrupo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtValido_FE As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblNombreMoneda2 As Label
    Friend WithEvents txtCodMoneda2_AN As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNombreMoneda1 As Label
    Friend WithEvents txtCodMoneda1_AN As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents gbxGrupo As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVenta_ND As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCompra_ND As TextBox
End Class
