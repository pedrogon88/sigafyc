<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFREconstruccionSaldos : Inherits frmFormulario

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFREconstruccionSaldos))
        Me.txtFecha1_FE = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblNombreSucursal = New System.Windows.Forms.Label()
        Me.txtCodSucursal_NE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.txtCodEmpresa_NE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFecha2_FE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkCabecera = New System.Windows.Forms.CheckBox()
        Me.chkSaldos = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(16, 283)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.TabControl1.Size = New System.Drawing.Size(725, 437)
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.chkSaldos)
        Me.TabPage1.Controls.Add(Me.chkCabecera)
        Me.TabPage1.Controls.Add(Me.txtFecha2_FE)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtFecha1_FE)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.lblNombreSucursal)
        Me.TabPage1.Controls.Add(Me.txtCodSucursal_NE)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.lblNombreEmpresa)
        Me.TabPage1.Controls.Add(Me.txtCodEmpresa_NE)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.TabPage1.Size = New System.Drawing.Size(717, 392)
        Me.TabPage1.Text = "Parametros"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(20, 726)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnCancelar.Size = New System.Drawing.Size(178, 91)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(559, 726)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.btnAceptar.Size = New System.Drawing.Size(178, 91)
        '
        'lblMensaje
        '
        Me.lblMensaje.BackColor = System.Drawing.Color.IndianRed
        Me.lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensaje.ForeColor = System.Drawing.Color.White
        Me.lblMensaje.Location = New System.Drawing.Point(21, 14)
        Me.lblMensaje.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblMensaje.Size = New System.Drawing.Size(720, 265)
        Me.lblMensaje.Text = resources.GetString("lblMensaje.Text")
        '
        'txtFecha1_FE
        '
        Me.txtFecha1_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha1_FE.Location = New System.Drawing.Point(237, 159)
        Me.txtFecha1_FE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFecha1_FE.Name = "txtFecha1_FE"
        Me.txtFecha1_FE.Size = New System.Drawing.Size(153, 34)
        Me.txtFecha1_FE.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(23, 161)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(160, 29)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Fecha desde:"
        '
        'lblNombreSucursal
        '
        Me.lblNombreSucursal.AutoSize = True
        Me.lblNombreSucursal.Location = New System.Drawing.Point(331, 97)
        Me.lblNombreSucursal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreSucursal.Name = "lblNombreSucursal"
        Me.lblNombreSucursal.Size = New System.Drawing.Size(226, 29)
        Me.lblNombreSucursal.TabIndex = 59
        Me.lblNombreSucursal.Text = "<nombre_sucursal>"
        '
        'txtCodSucursal_NE
        '
        Me.txtCodSucursal_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodSucursal_NE.Location = New System.Drawing.Point(237, 95)
        Me.txtCodSucursal_NE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodSucursal_NE.Name = "txtCodSucursal_NE"
        Me.txtCodSucursal_NE.Size = New System.Drawing.Size(85, 34)
        Me.txtCodSucursal_NE.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 97)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 29)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Sucursal:"
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(399, 33)
        Me.lblNombreEmpresa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(273, 29)
        Me.lblNombreEmpresa.TabIndex = 56
        Me.lblNombreEmpresa.Text = "<nombre_de_empresa>"
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(237, 31)
        Me.txtCodEmpresa_NE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(153, 34)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 33)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 29)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Empresa:"
        '
        'txtFecha2_FE
        '
        Me.txtFecha2_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha2_FE.Location = New System.Drawing.Point(237, 223)
        Me.txtFecha2_FE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFecha2_FE.Name = "txtFecha2_FE"
        Me.txtFecha2_FE.Size = New System.Drawing.Size(153, 34)
        Me.txtFecha2_FE.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 225)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 29)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Fecha hasta:"
        '
        'chkCabecera
        '
        Me.chkCabecera.AutoSize = True
        Me.chkCabecera.Location = New System.Drawing.Point(144, 286)
        Me.chkCabecera.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkCabecera.Name = "chkCabecera"
        Me.chkCabecera.Size = New System.Drawing.Size(403, 33)
        Me.chkCabecera.TabIndex = 4
        Me.chkCabecera.Text = "Reconstrucción cabecera asientos"
        Me.chkCabecera.UseVisualStyleBackColor = True
        '
        'chkSaldos
        '
        Me.chkSaldos.AutoSize = True
        Me.chkSaldos.Location = New System.Drawing.Point(143, 327)
        Me.chkSaldos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkSaldos.Name = "chkSaldos"
        Me.chkSaldos.Size = New System.Drawing.Size(401, 33)
        Me.chkSaldos.TabIndex = 5
        Me.chkSaldos.Text = "Reconstrucción saldos de cuentas"
        Me.chkSaldos.UseVisualStyleBackColor = True
        '
        'frmFREconstruccionSaldos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(753, 827)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "frmFREconstruccionSaldos"
        Me.Tag = ""
        Me.Text = "Parametro Reconstruccion de Saldos Contables"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtFecha2_FE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFecha1_FE As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents lblNombreSucursal As Label
    Friend WithEvents txtCodSucursal_NE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkCabecera As CheckBox
    Friend WithEvents chkSaldos As CheckBox
End Class
