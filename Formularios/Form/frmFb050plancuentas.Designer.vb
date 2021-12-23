<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFb050plancuentas : Inherits frmFormulario

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
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.txtCodEmpresa_NE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombre_AN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo_NE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.txtCuenta1_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta2_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta3_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta4_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta5_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta6_NE = New System.Windows.Forms.TextBox()
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Size = New System.Drawing.Size(896, 291)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblNombreEmpresa)
        Me.TabPage1.Controls.Add(Me.txtCuenta6_NE)
        Me.TabPage1.Controls.Add(Me.txtCuenta5_NE)
        Me.TabPage1.Controls.Add(Me.txtCuenta4_NE)
        Me.TabPage1.Controls.Add(Me.txtCuenta3_NE)
        Me.TabPage1.Controls.Add(Me.txtCuenta2_NE)
        Me.TabPage1.Controls.Add(Me.txtCuenta1_NE)
        Me.TabPage1.Controls.Add(Me.cmbNivel)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cmbTipo)
        Me.TabPage1.Controls.Add(Me.txtCodEmpresa_NE)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtNombre_AN)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtCodigo_NE)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Size = New System.Drawing.Size(888, 251)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(16, 346)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(771, 346)
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleName = "Activo"
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 36)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(888, 251)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Complementario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(92, 15)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(196, 32)
        Me.cmbEstado.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 24)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Estado:"
        '
        'cmbTipo
        '
        Me.cmbTipo.AccessibleDescription = "tipo"
        Me.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"Totales", "Imputable"})
        Me.cmbTipo.Location = New System.Drawing.Point(171, 148)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(185, 32)
        Me.cmbTipo.TabIndex = 8
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(173, 19)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 24)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Empresa:"
        '
        'txtNombre_AN
        '
        Me.txtNombre_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre_AN.Location = New System.Drawing.Point(171, 104)
        Me.txtNombre_AN.Name = "txtNombre_AN"
        Me.txtNombre_AN.Size = New System.Drawing.Size(709, 29)
        Me.txtNombre_AN.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 24)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Denominación:"
        '
        'txtCodigo_NE
        '
        Me.txtCodigo_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo_NE.Location = New System.Drawing.Point(534, 59)
        Me.txtCodigo_NE.Name = "txtCodigo_NE"
        Me.txtCodigo_NE.ReadOnly = True
        Me.txtCodigo_NE.Size = New System.Drawing.Size(348, 29)
        Me.txtCodigo_NE.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 24)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Tipo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 24)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Cuenta contable:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 199)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 24)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Nivel:"
        '
        'cmbNivel
        '
        Me.cmbNivel.AccessibleDescription = "tipo"
        Me.cmbNivel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbNivel.FormattingEnabled = True
        Me.cmbNivel.Items.AddRange(New Object() {"2", "3", "4", "5", "6"})
        Me.cmbNivel.Location = New System.Drawing.Point(171, 196)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(73, 32)
        Me.cmbNivel.TabIndex = 9
        '
        'txtCuenta1_NE
        '
        Me.txtCuenta1_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta1_NE.Location = New System.Drawing.Point(171, 59)
        Me.txtCuenta1_NE.Name = "txtCuenta1_NE"
        Me.txtCuenta1_NE.Size = New System.Drawing.Size(28, 29)
        Me.txtCuenta1_NE.TabIndex = 1
        Me.txtCuenta1_NE.Text = "0"
        '
        'txtCuenta2_NE
        '
        Me.txtCuenta2_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta2_NE.Location = New System.Drawing.Point(205, 59)
        Me.txtCuenta2_NE.Name = "txtCuenta2_NE"
        Me.txtCuenta2_NE.Size = New System.Drawing.Size(39, 29)
        Me.txtCuenta2_NE.TabIndex = 2
        Me.txtCuenta2_NE.Text = "00"
        '
        'txtCuenta3_NE
        '
        Me.txtCuenta3_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta3_NE.Location = New System.Drawing.Point(250, 59)
        Me.txtCuenta3_NE.Name = "txtCuenta3_NE"
        Me.txtCuenta3_NE.Size = New System.Drawing.Size(48, 29)
        Me.txtCuenta3_NE.TabIndex = 3
        Me.txtCuenta3_NE.Text = "000"
        '
        'txtCuenta4_NE
        '
        Me.txtCuenta4_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta4_NE.Location = New System.Drawing.Point(304, 59)
        Me.txtCuenta4_NE.Name = "txtCuenta4_NE"
        Me.txtCuenta4_NE.Size = New System.Drawing.Size(58, 29)
        Me.txtCuenta4_NE.TabIndex = 4
        Me.txtCuenta4_NE.Text = "0000"
        '
        'txtCuenta5_NE
        '
        Me.txtCuenta5_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta5_NE.Location = New System.Drawing.Point(368, 59)
        Me.txtCuenta5_NE.Name = "txtCuenta5_NE"
        Me.txtCuenta5_NE.Size = New System.Drawing.Size(65, 29)
        Me.txtCuenta5_NE.TabIndex = 5
        Me.txtCuenta5_NE.Text = "00000"
        '
        'txtCuenta6_NE
        '
        Me.txtCuenta6_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta6_NE.Location = New System.Drawing.Point(439, 59)
        Me.txtCuenta6_NE.Name = "txtCuenta6_NE"
        Me.txtCuenta6_NE.Size = New System.Drawing.Size(75, 29)
        Me.txtCuenta6_NE.TabIndex = 6
        Me.txtCuenta6_NE.Text = "000000"
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(294, 21)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(152, 24)
        Me.lblNombreEmpresa.TabIndex = 52
        Me.lblNombreEmpresa.Text = "Cuenta contable:"
        '
        'frmFb050plancuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(919, 433)
        Me.Name = "frmFb050plancuentas"
        Me.Tag = ""
        Me.Text = "Formulario Cuenta Contable"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNombre_AN As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCodigo_NE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCuenta6_NE As TextBox
    Friend WithEvents txtCuenta5_NE As TextBox
    Friend WithEvents txtCuenta4_NE As TextBox
    Friend WithEvents txtCuenta3_NE As TextBox
    Friend WithEvents txtCuenta2_NE As TextBox
    Friend WithEvents txtCuenta1_NE As TextBox
    Friend WithEvents cmbNivel As ComboBox
    Friend WithEvents Label5 As Label
End Class
