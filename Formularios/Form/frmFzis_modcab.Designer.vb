<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFzis_modcab
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtScript_AN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAbreviado_AN = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNombre_AN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumTra_NE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.cmbSentido = New System.Windows.Forms.ComboBox()
        Me.cmbDestino = New System.Windows.Forms.ComboBox()
        Me.cmbFindBy = New System.Windows.Forms.ComboBox()
        Me.lblFindBy = New System.Windows.Forms.Label()
        Me.cmbTipoDato = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCampoPK = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Size = New System.Drawing.Size(1012, 338)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cmbCampoPK)
        Me.TabPage1.Controls.Add(Me.cmbTipoDato)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cmbFindBy)
        Me.TabPage1.Controls.Add(Me.lblFindBy)
        Me.TabPage1.Controls.Add(Me.cmbDestino)
        Me.TabPage1.Controls.Add(Me.cmbSentido)
        Me.TabPage1.Controls.Add(Me.lblDestino)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtScript_AN)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtAbreviado_AN)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtNombre_AN)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtNumTra_NE)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 37)
        Me.TabPage1.Size = New System.Drawing.Size(1004, 297)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(20, 402)
        Me.btnCancelar.Size = New System.Drawing.Size(150, 97)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(874, 402)
        Me.btnAceptar.Size = New System.Drawing.Size(150, 97)
        '
        'lblMensaje
        '
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Size = New System.Drawing.Size(1008, 46)
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
        Me.cmbEstado.Location = New System.Drawing.Point(234, 24)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(260, 33)
        Me.cmbEstado.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(24, 28)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 25)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Estado operativo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 177)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 25)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "Codigo Script:"
        '
        'txtScript_AN
        '
        Me.txtScript_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtScript_AN.Location = New System.Drawing.Point(173, 173)
        Me.txtScript_AN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtScript_AN.Name = "txtScript_AN"
        Me.txtScript_AN.Size = New System.Drawing.Size(611, 30)
        Me.txtScript_AN.TabIndex = 4
        Me.txtScript_AN.Tag = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 140)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 25)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Sentido:"
        '
        'txtAbreviado_AN
        '
        Me.txtAbreviado_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAbreviado_AN.Location = New System.Drawing.Point(173, 97)
        Me.txtAbreviado_AN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAbreviado_AN.Name = "txtAbreviado_AN"
        Me.txtAbreviado_AN.Size = New System.Drawing.Size(318, 30)
        Me.txtAbreviado_AN.TabIndex = 2
        Me.txtAbreviado_AN.Tag = "Ok"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(21, 102)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 25)
        Me.Label13.TabIndex = 64
        Me.Label13.Text = "Abreviado:"
        '
        'txtNombre_AN
        '
        Me.txtNombre_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre_AN.Location = New System.Drawing.Point(173, 60)
        Me.txtNombre_AN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNombre_AN.Name = "txtNombre_AN"
        Me.txtNombre_AN.Size = New System.Drawing.Size(815, 30)
        Me.txtNombre_AN.TabIndex = 1
        Me.txtNombre_AN.Tag = "Ok"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 64)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 25)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Descripción:"
        '
        'txtNumTra_NE
        '
        Me.txtNumTra_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumTra_NE.Location = New System.Drawing.Point(173, 24)
        Me.txtNumTra_NE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumTra_NE.Name = "txtNumTra_NE"
        Me.txtNumTra_NE.Size = New System.Drawing.Size(153, 30)
        Me.txtNumTra_NE.TabIndex = 0
        Me.txtNumTra_NE.Tag = "Ok"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 25)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Modelo No.:"
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Location = New System.Drawing.Point(469, 218)
        Me.lblDestino.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(136, 25)
        Me.lblDestino.TabIndex = 70
        Me.lblDestino.Text = "Tabla destino:"
        '
        'cmbSentido
        '
        Me.cmbSentido.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbSentido.FormattingEnabled = True
        Me.cmbSentido.Items.AddRange(New Object() {"SAP->zoho", "Zoho->SAP"})
        Me.cmbSentido.Location = New System.Drawing.Point(173, 134)
        Me.cmbSentido.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSentido.Name = "cmbSentido"
        Me.cmbSentido.Size = New System.Drawing.Size(260, 33)
        Me.cmbSentido.TabIndex = 3
        Me.cmbSentido.Tag = ""
        '
        'cmbDestino
        '
        Me.cmbDestino.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Items.AddRange(New Object() {"SAP->zoho", "Zoho->SAP"})
        Me.cmbDestino.Location = New System.Drawing.Point(606, 213)
        Me.cmbDestino.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(382, 33)
        Me.cmbDestino.TabIndex = 6
        Me.cmbDestino.Tag = "Ok"
        '
        'cmbFindBy
        '
        Me.cmbFindBy.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbFindBy.FormattingEnabled = True
        Me.cmbFindBy.Items.AddRange(New Object() {"search", "zohoid", "external"})
        Me.cmbFindBy.Location = New System.Drawing.Point(173, 256)
        Me.cmbFindBy.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFindBy.Name = "cmbFindBy"
        Me.cmbFindBy.Size = New System.Drawing.Size(272, 33)
        Me.cmbFindBy.TabIndex = 7
        Me.cmbFindBy.Tag = ""
        '
        'lblFindBy
        '
        Me.lblFindBy.AutoSize = True
        Me.lblFindBy.Location = New System.Drawing.Point(21, 259)
        Me.lblFindBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFindBy.Name = "lblFindBy"
        Me.lblFindBy.Size = New System.Drawing.Size(129, 25)
        Me.lblFindBy.TabIndex = 75
        Me.lblFindBy.Text = "Localizar por:"
        '
        'cmbTipoDato
        '
        Me.cmbTipoDato.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbTipoDato.FormattingEnabled = True
        Me.cmbTipoDato.Items.AddRange(New Object() {"SAP->zoho", "Zoho->SAP"})
        Me.cmbTipoDato.Location = New System.Drawing.Point(173, 213)
        Me.cmbTipoDato.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTipoDato.Name = "cmbTipoDato"
        Me.cmbTipoDato.Size = New System.Drawing.Size(272, 33)
        Me.cmbTipoDato.TabIndex = 5
        Me.cmbTipoDato.Tag = "Ok"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 218)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 25)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Tipo dato destino:"
        '
        'cmbCampoPK
        '
        Me.cmbCampoPK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbCampoPK.FormattingEnabled = True
        Me.cmbCampoPK.Items.AddRange(New Object() {"SAP->zoho", "Zoho->SAP"})
        Me.cmbCampoPK.Location = New System.Drawing.Point(606, 256)
        Me.cmbCampoPK.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCampoPK.Name = "cmbCampoPK"
        Me.cmbCampoPK.Size = New System.Drawing.Size(382, 33)
        Me.cmbCampoPK.TabIndex = 8
        Me.cmbCampoPK.Tag = "Ok"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(469, 259)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 25)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Campo PK:"
        '
        'frmFzis_modcab
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(1035, 511)
        Me.Name = "frmFzis_modcab"
        Me.Tag = ""
        Me.Text = "Formulario Modelo de Integración - Cabecera"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtScript_AN As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAbreviado_AN As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtNombre_AN As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNumTra_NE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblDestino As Label
    Friend WithEvents cmbSentido As ComboBox
    Friend WithEvents cmbDestino As ComboBox
    Friend WithEvents cmbFindBy As ComboBox
    Friend WithEvents lblFindBy As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCampoPK As ComboBox
    Friend WithEvents cmbTipoDato As ComboBox
    Friend WithEvents Label2 As Label
End Class
