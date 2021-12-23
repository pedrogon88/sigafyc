<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFzis_prodet
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
        Me.lblEnding = New System.Windows.Forms.Label()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.txtNumOrd_NE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumTra_NE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNumMod_NE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNomMod = New System.Windows.Forms.Label()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.txtEnding = New System.Windows.Forms.TextBox()
        Me.cmbFormAct = New System.Windows.Forms.ComboBox()
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
        Me.TabControl1.Size = New System.Drawing.Size(1015, 364)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
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
        Me.TabPage1.Location = New System.Drawing.Point(4, 37)
        Me.TabPage1.Size = New System.Drawing.Size(1007, 323)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(21, 428)
        Me.btnCancelar.Size = New System.Drawing.Size(150, 97)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(877, 428)
        Me.btnAceptar.Size = New System.Drawing.Size(150, 97)
        '
        'lblMensaje
        '
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.Size = New System.Drawing.Size(1011, 46)
        '
        'lblEnding
        '
        Me.lblEnding.AutoSize = True
        Me.lblEnding.Location = New System.Drawing.Point(24, 270)
        Me.lblEnding.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEnding.Name = "lblEnding"
        Me.lblEnding.Size = New System.Drawing.Size(240, 25)
        Me.lblEnding.TabIndex = 88
        Me.lblEnding.Text = "Fecha y hora culminación:"
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(24, 221)
        Me.lblStart.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(181, 25)
        Me.lblStart.TabIndex = 87
        Me.lblStart.Text = "Fecha y hora inicio:"
        '
        'txtNumOrd_NE
        '
        Me.txtNumOrd_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumOrd_NE.Location = New System.Drawing.Point(322, 71)
        Me.txtNumOrd_NE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumOrd_NE.Name = "txtNumOrd_NE"
        Me.txtNumOrd_NE.Size = New System.Drawing.Size(153, 30)
        Me.txtNumOrd_NE.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 74)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 25)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Linea No.:"
        '
        'txtNumTra_NE
        '
        Me.txtNumTra_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumTra_NE.Location = New System.Drawing.Point(322, 22)
        Me.txtNumTra_NE.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumTra_NE.Name = "txtNumTra_NE"
        Me.txtNumTra_NE.Size = New System.Drawing.Size(153, 30)
        Me.txtNumTra_NE.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 25)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Proceso No.:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 37)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1007, 323)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Complementario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(225, 18)
        Me.cmbEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(260, 33)
        Me.cmbEstado.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 22)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(164, 25)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Estado operativo:"
        '
        'txtNumMod_NE
        '
        Me.txtNumMod_NE.Location = New System.Drawing.Point(322, 120)
        Me.txtNumMod_NE.Name = "txtNumMod_NE"
        Me.txtNumMod_NE.Size = New System.Drawing.Size(153, 30)
        Me.txtNumMod_NE.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 123)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 25)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Modelo No. "
        '
        'lblNomMod
        '
        Me.lblNomMod.AutoSize = True
        Me.lblNomMod.Location = New System.Drawing.Point(491, 123)
        Me.lblNomMod.Name = "lblNomMod"
        Me.lblNomMod.Size = New System.Drawing.Size(71, 25)
        Me.lblNomMod.TabIndex = 91
        Me.lblNomMod.Text = "Label4"
        '
        'txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(322, 221)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(385, 30)
        Me.txtStart.TabIndex = 4
        '
        'txtEnding
        '
        Me.txtEnding.Location = New System.Drawing.Point(322, 270)
        Me.txtEnding.Name = "txtEnding"
        Me.txtEnding.Size = New System.Drawing.Size(385, 30)
        Me.txtEnding.TabIndex = 5
        '
        'cmbFormAct
        '
        Me.cmbFormAct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbFormAct.FormattingEnabled = True
        Me.cmbFormAct.Items.AddRange(New Object() {"BULK", "DEAUNO"})
        Me.cmbFormAct.Location = New System.Drawing.Point(322, 169)
        Me.cmbFormAct.Name = "cmbFormAct"
        Me.cmbFormAct.Size = New System.Drawing.Size(196, 33)
        Me.cmbFormAct.TabIndex = 3
        Me.cmbFormAct.Tag = "Ok"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(202, 25)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Metodo actualización:"
        '
        'frmFzis_prodet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(1036, 538)
        Me.Name = "frmFzis_prodet"
        Me.Tag = ""
        Me.Text = "Formulario Proceso Integración - Detalle"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblEnding As Label
    Friend WithEvents lblStart As Label
    Friend WithEvents txtNumOrd_NE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNumTra_NE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNumMod_NE As TextBox
    Friend WithEvents lblNomMod As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEnding As TextBox
    Friend WithEvents txtStart As TextBox
    Friend WithEvents cmbFormAct As ComboBox
    Friend WithEvents Label4 As Label
End Class
