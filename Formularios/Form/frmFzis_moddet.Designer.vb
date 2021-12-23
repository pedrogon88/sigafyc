<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFzis_moddet
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
        Me.cmbDestino = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNumOrd_NE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumTra_NE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Size = New System.Drawing.Size(625, 219)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmbOrigen)
        Me.TabPage1.Controls.Add(Me.cmbDestino)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtNumOrd_NE)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtNumTra_NE)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 37)
        Me.TabPage1.Size = New System.Drawing.Size(617, 178)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(21, 283)
        Me.btnCancelar.Size = New System.Drawing.Size(150, 97)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(487, 283)
        Me.btnAceptar.Size = New System.Drawing.Size(150, 97)
        '
        'lblMensaje
        '
        Me.lblMensaje.Size = New System.Drawing.Size(621, 46)
        '
        'cmbDestino
        '
        Me.cmbDestino.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Items.AddRange(New Object() {"SAP->zoho", "Zoho->SAP"})
        Me.cmbDestino.Location = New System.Drawing.Point(130, 136)
        Me.cmbDestino.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(465, 33)
        Me.cmbDestino.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 140)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 25)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Destino:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 102)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 25)
        Me.Label13.TabIndex = 79
        Me.Label13.Text = "Origen"
        '
        'txtNumOrd_NE
        '
        Me.txtNumOrd_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumOrd_NE.Location = New System.Drawing.Point(129, 60)
        Me.txtNumOrd_NE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumOrd_NE.Name = "txtNumOrd_NE"
        Me.txtNumOrd_NE.Size = New System.Drawing.Size(153, 30)
        Me.txtNumOrd_NE.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 25)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Linea No.:"
        '
        'txtNumTra_NE
        '
        Me.txtNumTra_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumTra_NE.Location = New System.Drawing.Point(129, 23)
        Me.txtNumTra_NE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumTra_NE.Name = "txtNumTra_NE"
        Me.txtNumTra_NE.Size = New System.Drawing.Size(153, 30)
        Me.txtNumTra_NE.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 25)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Modelo No.:"
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleName = "Activo"
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1187, 596)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Complementario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(158, 16)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(260, 33)
        Me.cmbEstado.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 20)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 25)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Estado operativo:"
        '
        'cmbOrigen
        '
        Me.cmbOrigen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Items.AddRange(New Object() {"SAP->zoho", "Zoho->SAP"})
        Me.cmbOrigen.Location = New System.Drawing.Point(130, 97)
        Me.cmbOrigen.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(465, 33)
        Me.cmbOrigen.TabIndex = 2
        '
        'frmFzis_moddet
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(647, 393)
        Me.Name = "frmFzis_moddet"
        Me.Tag = ""
        Me.Text = "Formulario Modelo Integración - Detalle"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbDestino As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtNumOrd_NE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNumTra_NE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbOrigen As ComboBox
End Class
