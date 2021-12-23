<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFCarteraDeudoraDetalle
    Inherits frmFormulario

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
        Me.txtComentario_AN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaHora_FE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtItemCode_AN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCardCode_AN = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabControl1.Size = New System.Drawing.Size(901, 519)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtCardCode_AN)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtComentario_AN)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtFechaHora_FE)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtItemCode_AN)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Size = New System.Drawing.Size(893, 474)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(16, 587)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(5)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(735, 587)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(5)
        '
        'lblMensaje
        '
        Me.lblMensaje.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblMensaje.Size = New System.Drawing.Size(896, 46)
        '
        'txtComentario_AN
        '
        Me.txtComentario_AN.AccessibleDescription = "comentario"
        Me.txtComentario_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario_AN.Location = New System.Drawing.Point(207, 247)
        Me.txtComentario_AN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtComentario_AN.Multiline = True
        Me.txtComentario_AN.Name = "txtComentario_AN"
        Me.txtComentario_AN.Size = New System.Drawing.Size(646, 195)
        Me.txtComentario_AN.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 247)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 29)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Comentarios"
        '
        'txtFechaHora_FE
        '
        Me.txtFechaHora_FE.AccessibleDescription = "fechahora"
        Me.txtFechaHora_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaHora_FE.Location = New System.Drawing.Point(207, 137)
        Me.txtFechaHora_FE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaHora_FE.Name = "txtFechaHora_FE"
        Me.txtFechaHora_FE.Size = New System.Drawing.Size(299, 34)
        Me.txtFechaHora_FE.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 140)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 29)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Fecha y hora:"
        '
        'txtItemCode_AN
        '
        Me.txtItemCode_AN.AccessibleDescription = "ItemCode"
        Me.txtItemCode_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItemCode_AN.Location = New System.Drawing.Point(207, 22)
        Me.txtItemCode_AN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtItemCode_AN.Name = "txtItemCode_AN"
        Me.txtItemCode_AN.Size = New System.Drawing.Size(299, 34)
        Me.txtItemCode_AN.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 29)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Stock:"
        '
        'txtCardCode_AN
        '
        Me.txtCardCode_AN.AccessibleDescription = "CardCode"
        Me.txtCardCode_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCardCode_AN.Location = New System.Drawing.Point(207, 81)
        Me.txtCardCode_AN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCardCode_AN.Name = "txtCardCode_AN"
        Me.txtCardCode_AN.Size = New System.Drawing.Size(299, 34)
        Me.txtCardCode_AN.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 85)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 29)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Cliente:"
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleName = "Activo"
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(893, 474)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Complementario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(324, 21)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(260, 37)
        Me.cmbEstado.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 25)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 29)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Estado operativo:"
        '
        'frmFCarteraDeudoraDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(931, 690)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmFCarteraDeudoraDetalle"
        Me.Tag = ""
        Me.Text = "Formulario Cartera Deudora Detalle"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtCardCode_AN As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtComentario_AN As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFechaHora_FE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtItemCode_AN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
End Class
