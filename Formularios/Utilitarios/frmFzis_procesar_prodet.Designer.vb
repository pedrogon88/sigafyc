<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFzis_procesar_prodet
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
        Me.cmbFormAct = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEnding = New System.Windows.Forms.TextBox()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.lblNomMod = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumMod_NE = New System.Windows.Forms.TextBox()
        Me.lblEnding = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.txtNumOrd_NE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumTra_NE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(16, 117)
        Me.TabControl1.Size = New System.Drawing.Size(747, 416)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmbFormAct)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtEnding)
        Me.TabPage1.Controls.Add(Me.txtStart)
        Me.TabPage1.Controls.Add(Me.lblNomMod)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtNumMod_NE)
        Me.TabPage1.Controls.Add(Me.lblEnding)
        Me.TabPage1.Controls.Add(Me.lblStart)
        Me.TabPage1.Controls.Add(Me.txtNumOrd_NE)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtNumTra_NE)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Size = New System.Drawing.Size(739, 371)
        Me.TabPage1.Text = "Parametros"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(20, 541)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(582, 541)
        '
        'lblMensaje
        '
        Me.lblMensaje.BackColor = System.Drawing.Color.IndianRed
        Me.lblMensaje.ForeColor = System.Drawing.Color.White
        Me.lblMensaje.Size = New System.Drawing.Size(743, 91)
        Me.lblMensaje.Text = "Atención!!!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Esta a punto de procesar una integración manualmente."
        '
        'cmbFormAct
        '
        Me.cmbFormAct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbFormAct.FormattingEnabled = True
        Me.cmbFormAct.Items.AddRange(New Object() {"BULK", "DEAUNO"})
        Me.cmbFormAct.Location = New System.Drawing.Point(332, 226)
        Me.cmbFormAct.Name = "cmbFormAct"
        Me.cmbFormAct.Size = New System.Drawing.Size(196, 37)
        Me.cmbFormAct.TabIndex = 102
        Me.cmbFormAct.Tag = "Ok"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(34, 229)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(245, 29)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Metodo actualización:"
        '
        'txtEnding
        '
        Me.txtEnding.Location = New System.Drawing.Point(332, 327)
        Me.txtEnding.Name = "txtEnding"
        Me.txtEnding.Size = New System.Drawing.Size(385, 34)
        Me.txtEnding.TabIndex = 104
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(332, 278)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(385, 34)
        Me.txtStart.TabIndex = 103
        '
        'lblNomMod
        '
        Me.lblNomMod.AutoSize = True
        Me.lblNomMod.Location = New System.Drawing.Point(34, 180)
        Me.lblNomMod.Name = "lblNomMod"
        Me.lblNomMod.Size = New System.Drawing.Size(86, 29)
        Me.lblNomMod.TabIndex = 110
        Me.lblNomMod.Text = "Label4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 132)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 29)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "Modelo No. "
        '
        'txtNumMod_NE
        '
        Me.txtNumMod_NE.Location = New System.Drawing.Point(332, 129)
        Me.txtNumMod_NE.Name = "txtNumMod_NE"
        Me.txtNumMod_NE.Size = New System.Drawing.Size(153, 34)
        Me.txtNumMod_NE.TabIndex = 101
        '
        'lblEnding
        '
        Me.lblEnding.AutoSize = True
        Me.lblEnding.Location = New System.Drawing.Point(34, 327)
        Me.lblEnding.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEnding.Name = "lblEnding"
        Me.lblEnding.Size = New System.Drawing.Size(291, 29)
        Me.lblEnding.TabIndex = 108
        Me.lblEnding.Text = "Fecha y hora culminación:"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(34, 278)
        Me.lblStart.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(220, 29)
        Me.lblStart.TabIndex = 107
        Me.lblStart.Text = "Fecha y hora inicio:"
        '
        'txtNumOrd_NE
        '
        Me.txtNumOrd_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumOrd_NE.Location = New System.Drawing.Point(332, 80)
        Me.txtNumOrd_NE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumOrd_NE.Name = "txtNumOrd_NE"
        Me.txtNumOrd_NE.Size = New System.Drawing.Size(153, 34)
        Me.txtNumOrd_NE.TabIndex = 100
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 83)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 29)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Linea No.:"
        '
        'txtNumTra_NE
        '
        Me.txtNumTra_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumTra_NE.Location = New System.Drawing.Point(332, 31)
        Me.txtNumTra_NE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumTra_NE.Name = "txtNumTra_NE"
        Me.txtNumTra_NE.Size = New System.Drawing.Size(153, 34)
        Me.txtNumTra_NE.TabIndex = 99
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 29)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Proceso No.:"
        '
        'frmFzis_procesar_prodet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(774, 644)
        Me.Name = "frmFzis_procesar_prodet"
        Me.Tag = ""
        Me.Text = "Procesar manualmente - integración detalle"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbFormAct As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtEnding As TextBox
    Friend WithEvents txtStart As TextBox
    Friend WithEvents lblNomMod As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNumMod_NE As TextBox
    Friend WithEvents lblEnding As Label
    Friend WithEvents lblStart As Label
    Friend WithEvents txtNumOrd_NE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNumTra_NE As TextBox
    Friend WithEvents Label1 As Label
End Class
