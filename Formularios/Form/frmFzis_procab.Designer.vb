<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFzis_procab
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
        Me.txtEnding = New System.Windows.Forms.TextBox()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.lblEnding = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.cmbUndTmp = New System.Windows.Forms.ComboBox()
        Me.lblFrecuencia = New System.Windows.Forms.Label()
        Me.txtTiempo_NE = New System.Windows.Forms.TextBox()
        Me.cmbFormProc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 49)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3)
        Me.TabControl1.Size = New System.Drawing.Size(774, 389)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmbFormProc)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtTiempo_NE)
        Me.TabPage1.Controls.Add(Me.lblFrecuencia)
        Me.TabPage1.Controls.Add(Me.cmbUndTmp)
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
        Me.TabPage1.Location = New System.Drawing.Point(4, 37)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(766, 348)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(17, 440)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(3)
        Me.btnCancelar.Size = New System.Drawing.Size(150, 97)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(632, 440)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(3)
        Me.btnAceptar.Size = New System.Drawing.Size(150, 97)
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(12, 9)
        Me.lblMensaje.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblMensaje.Size = New System.Drawing.Size(770, 37)
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleName = "Activo"
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(2)
        Me.TabPage2.Name = "TabPage2"
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
        Me.cmbEstado.Location = New System.Drawing.Point(169, 15)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(196, 33)
        Me.cmbEstado.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 25)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Estado operativo:"
        '
        'cmbTipAct
        '
        Me.cmbTipAct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbTipAct.FormattingEnabled = True
        Me.cmbTipAct.Items.AddRange(New Object() {"insert", "update", "upsert"})
        Me.cmbTipAct.Location = New System.Drawing.Point(251, 196)
        Me.cmbTipAct.Name = "cmbTipAct"
        Me.cmbTipAct.Size = New System.Drawing.Size(196, 33)
        Me.cmbTipAct.TabIndex = 5
        Me.cmbTipAct.Tag = "Ok"
        '
        'cmbTipExec
        '
        Me.cmbTipExec.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbTipExec.FormattingEnabled = True
        Me.cmbTipExec.Items.AddRange(New Object() {"Secuencial", "MultiHilo"})
        Me.cmbTipExec.Location = New System.Drawing.Point(251, 159)
        Me.cmbTipExec.Name = "cmbTipExec"
        Me.cmbTipExec.Size = New System.Drawing.Size(196, 33)
        Me.cmbTipExec.TabIndex = 4
        Me.cmbTipExec.Tag = "Ok"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 25)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "Tipo Actualización:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 25)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Tipo ejecución:"
        '
        'txtAbreviado_AN
        '
        Me.txtAbreviado_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAbreviado_AN.Location = New System.Drawing.Point(251, 88)
        Me.txtAbreviado_AN.Name = "txtAbreviado_AN"
        Me.txtAbreviado_AN.Size = New System.Drawing.Size(239, 30)
        Me.txtAbreviado_AN.TabIndex = 2
        Me.txtAbreviado_AN.Tag = "Ok"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(28, 92)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 25)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "Abreviado:"
        '
        'txtNombre_AN
        '
        Me.txtNombre_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre_AN.Location = New System.Drawing.Point(251, 54)
        Me.txtNombre_AN.Name = "txtNombre_AN"
        Me.txtNombre_AN.Size = New System.Drawing.Size(502, 30)
        Me.txtNombre_AN.TabIndex = 1
        Me.txtNombre_AN.Tag = "Ok"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 25)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Descripción:"
        '
        'txtNumTra_NE
        '
        Me.txtNumTra_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumTra_NE.Location = New System.Drawing.Point(251, 20)
        Me.txtNumTra_NE.Name = "txtNumTra_NE"
        Me.txtNumTra_NE.Size = New System.Drawing.Size(115, 30)
        Me.txtNumTra_NE.TabIndex = 0
        Me.txtNumTra_NE.Tag = "Ok"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 25)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Proceso No.:"
        '
        'txtEnding
        '
        Me.txtEnding.Location = New System.Drawing.Point(251, 304)
        Me.txtEnding.Margin = New System.Windows.Forms.Padding(2)
        Me.txtEnding.Name = "txtEnding"
        Me.txtEnding.Size = New System.Drawing.Size(290, 30)
        Me.txtEnding.TabIndex = 9
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(251, 270)
        Me.txtStart.Margin = New System.Windows.Forms.Padding(2)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(290, 30)
        Me.txtStart.TabIndex = 8
        '
        'lblEnding
        '
        Me.lblEnding.AutoSize = True
        Me.lblEnding.Location = New System.Drawing.Point(28, 302)
        Me.lblEnding.Name = "lblEnding"
        Me.lblEnding.Size = New System.Drawing.Size(226, 25)
        Me.lblEnding.TabIndex = 92
        Me.lblEnding.Text = "Fecha/hora culminación:"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(28, 267)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(167, 25)
        Me.lblStart.TabIndex = 91
        Me.lblStart.Text = "Fecha/hora inicio:"
        '
        'cmbUndTmp
        '
        Me.cmbUndTmp.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbUndTmp.FormattingEnabled = True
        Me.cmbUndTmp.Items.AddRange(New Object() {"segundos", "minutos", "horas", "dias"})
        Me.cmbUndTmp.Location = New System.Drawing.Point(251, 233)
        Me.cmbUndTmp.Name = "cmbUndTmp"
        Me.cmbUndTmp.Size = New System.Drawing.Size(94, 33)
        Me.cmbUndTmp.TabIndex = 6
        Me.cmbUndTmp.Tag = "Ok"
        '
        'lblFrecuencia
        '
        Me.lblFrecuencia.AutoSize = True
        Me.lblFrecuencia.Location = New System.Drawing.Point(28, 232)
        Me.lblFrecuencia.Name = "lblFrecuencia"
        Me.lblFrecuencia.Size = New System.Drawing.Size(192, 25)
        Me.lblFrecuencia.TabIndex = 94
        Me.lblFrecuencia.Text = "Frecuecia ejecución:"
        '
        'txtTiempo_NE
        '
        Me.txtTiempo_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTiempo_NE.Location = New System.Drawing.Point(356, 235)
        Me.txtTiempo_NE.Name = "txtTiempo_NE"
        Me.txtTiempo_NE.Size = New System.Drawing.Size(115, 30)
        Me.txtTiempo_NE.TabIndex = 7
        Me.txtTiempo_NE.Tag = "Ok"
        '
        'cmbFormProc
        '
        Me.cmbFormProc.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbFormProc.FormattingEnabled = True
        Me.cmbFormProc.Items.AddRange(New Object() {"Manual", "Automatico"})
        Me.cmbFormProc.Location = New System.Drawing.Point(251, 122)
        Me.cmbFormProc.Name = "cmbFormProc"
        Me.cmbFormProc.Size = New System.Drawing.Size(196, 33)
        Me.cmbFormProc.TabIndex = 3
        Me.cmbFormProc.Tag = "Ok"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 25)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Forma de procesar:"
        '
        'frmFzis_procab
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(792, 544)
        Me.Margin = New System.Windows.Forms.Padding(3)
        Me.Name = "frmFzis_procab"
        Me.Tag = ""
        Me.Text = "Formulario Proceso Integración - Cabecera"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
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
    Friend WithEvents txtEnding As TextBox
    Friend WithEvents txtStart As TextBox
    Friend WithEvents lblEnding As Label
    Friend WithEvents lblStart As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTiempo_NE As TextBox
    Friend WithEvents lblFrecuencia As Label
    Friend WithEvents cmbUndTmp As ComboBox
    Friend WithEvents cmbFormProc As ComboBox
    Friend WithEvents Label2 As Label
End Class
