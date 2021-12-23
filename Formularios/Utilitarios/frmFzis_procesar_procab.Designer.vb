<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFzis_procesar_procab
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
        Me.cmbFormProc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEnding = New System.Windows.Forms.TextBox()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.lblEnding = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.cmbTipAct = New System.Windows.Forms.ComboBox()
        Me.cmbTipExec = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAbreviado_AN = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNombre_AN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumTra_NE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(16, 105)
        Me.TabControl1.Size = New System.Drawing.Size(841, 410)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmbFormProc)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtEnding)
        Me.TabPage1.Controls.Add(Me.txtStart)
        Me.TabPage1.Controls.Add(Me.lblEnding)
        Me.TabPage1.Controls.Add(Me.lblStart)
        Me.TabPage1.Controls.Add(Me.cmbTipAct)
        Me.TabPage1.Controls.Add(Me.cmbTipExec)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtAbreviado_AN)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtNombre_AN)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtNumTra_NE)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Size = New System.Drawing.Size(833, 365)
        Me.TabPage1.Text = "Parametros"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(19, 519)
        Me.btnCancelar.Size = New System.Drawing.Size(178, 91)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(675, 519)
        Me.btnAceptar.Size = New System.Drawing.Size(178, 91)
        '
        'lblMensaje
        '
        Me.lblMensaje.BackColor = System.Drawing.Color.IndianRed
        Me.lblMensaje.ForeColor = System.Drawing.Color.White
        Me.lblMensaje.Location = New System.Drawing.Point(14, 11)
        Me.lblMensaje.Size = New System.Drawing.Size(839, 90)
        Me.lblMensaje.Text = "Atención!!!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Esta a punto de procesar una integración manualmente."
        '
        'cmbFormProc
        '
        Me.cmbFormProc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbFormProc.FormattingEnabled = True
        Me.cmbFormProc.Items.AddRange(New Object() {"Manual", "Automatico"})
        Me.cmbFormProc.Location = New System.Drawing.Point(321, 135)
        Me.cmbFormProc.Name = "cmbFormProc"
        Me.cmbFormProc.Size = New System.Drawing.Size(196, 37)
        Me.cmbFormProc.TabIndex = 100
        Me.cmbFormProc.Tag = "Ok"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(224, 29)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Forma de procesar:"
        '
        'txtEnding
        '
        Me.txtEnding.Location = New System.Drawing.Point(321, 317)
        Me.txtEnding.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEnding.Name = "txtEnding"
        Me.txtEnding.Size = New System.Drawing.Size(290, 34)
        Me.txtEnding.TabIndex = 106
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(321, 283)
        Me.txtStart.Margin = New System.Windows.Forms.Padding(2)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(290, 34)
        Me.txtStart.TabIndex = 105
        '
        'lblEnding
        '
        Me.lblEnding.AutoSize = True
        Me.lblEnding.Location = New System.Drawing.Point(33, 315)
        Me.lblEnding.Name = "lblEnding"
        Me.lblEnding.Size = New System.Drawing.Size(291, 29)
        Me.lblEnding.TabIndex = 113
        Me.lblEnding.Text = "Fecha y hora culminación:"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(33, 280)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(220, 29)
        Me.lblStart.TabIndex = 112
        Me.lblStart.Text = "Fecha y hora inicio:"
        '
        'cmbTipAct
        '
        Me.cmbTipAct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbTipAct.FormattingEnabled = True
        Me.cmbTipAct.Items.AddRange(New Object() {"insert", "update", "upsert"})
        Me.cmbTipAct.Location = New System.Drawing.Point(321, 209)
        Me.cmbTipAct.Name = "cmbTipAct"
        Me.cmbTipAct.Size = New System.Drawing.Size(196, 37)
        Me.cmbTipAct.TabIndex = 102
        Me.cmbTipAct.Tag = "Ok"
        '
        'cmbTipExec
        '
        Me.cmbTipExec.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbTipExec.FormattingEnabled = True
        Me.cmbTipExec.Items.AddRange(New Object() {"Secuencial", "MultiHilo"})
        Me.cmbTipExec.Location = New System.Drawing.Point(321, 172)
        Me.cmbTipExec.Name = "cmbTipExec"
        Me.cmbTipExec.Size = New System.Drawing.Size(196, 37)
        Me.cmbTipExec.TabIndex = 101
        Me.cmbTipExec.Tag = "Ok"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(215, 29)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "Tipo Actualización:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(33, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 29)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "Tipo ejecución:"
        '
        'txtAbreviado_AN
        '
        Me.txtAbreviado_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAbreviado_AN.Location = New System.Drawing.Point(321, 101)
        Me.txtAbreviado_AN.Name = "txtAbreviado_AN"
        Me.txtAbreviado_AN.Size = New System.Drawing.Size(239, 34)
        Me.txtAbreviado_AN.TabIndex = 99
        Me.txtAbreviado_AN.Tag = "Ok"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(33, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 29)
        Me.Label13.TabIndex = 109
        Me.Label13.Text = "Abreviado:"
        '
        'txtNombre_AN
        '
        Me.txtNombre_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre_AN.Location = New System.Drawing.Point(321, 67)
        Me.txtNombre_AN.Name = "txtNombre_AN"
        Me.txtNombre_AN.Size = New System.Drawing.Size(502, 34)
        Me.txtNombre_AN.TabIndex = 98
        Me.txtNombre_AN.Tag = "Ok"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 29)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Descripción:"
        '
        'txtNumTra_NE
        '
        Me.txtNumTra_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumTra_NE.Location = New System.Drawing.Point(321, 33)
        Me.txtNumTra_NE.Name = "txtNumTra_NE"
        Me.txtNumTra_NE.Size = New System.Drawing.Size(115, 34)
        Me.txtNumTra_NE.TabIndex = 97
        Me.txtNumTra_NE.Tag = "Ok"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 29)
        Me.Label1.TabIndex = 107
        Me.Label1.Text = "Proceso No.:"
        '
        'frmFzis_procesar_procab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(868, 621)
        Me.Name = "frmFzis_procesar_procab"
        Me.Tag = ""
        Me.Text = "Procesar Manualmente - integración Cabecera"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbFormProc As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEnding As TextBox
    Friend WithEvents txtStart As TextBox
    Friend WithEvents lblEnding As Label
    Friend WithEvents lblStart As Label
    Friend WithEvents cmbTipAct As ComboBox
    Friend WithEvents cmbTipExec As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAbreviado_AN As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtNombre_AN As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNumTra_NE As TextBox
    Friend WithEvents Label1 As Label
End Class
