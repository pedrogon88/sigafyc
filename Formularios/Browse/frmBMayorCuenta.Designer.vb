<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBMayorCuenta : Inherits frmBrowseSinGrid

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
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.txtCodEmpresa_NE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombreCuenta = New System.Windows.Forms.Label()
        Me.txtCuenta6_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta5_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta4_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta3_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta2_NE = New System.Windows.Forms.TextBox()
        Me.txtCuenta1_NE = New System.Windows.Forms.TextBox()
        Me.txtCodCuenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFecha2_FE = New System.Windows.Forms.TextBox()
        Me.lblSaldoAnterior = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtFecha1_FE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalCreditos = New System.Windows.Forms.Label()
        Me.lblTotalDebitos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSaldoFinal = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblNombreSucursal = New System.Windows.Forms.Label()
        Me.txtCodSucursal_NE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(9, 171)
        Me.txtBuscar.Size = New System.Drawing.Size(1095, 22)
        Me.txtBuscar.TabIndex = 18
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(1110, 571)
        Me.btnSalir.TabIndex = 17
        '
        'btnAuditoria
        '
        Me.btnAuditoria.Location = New System.Drawing.Point(1110, 484)
        Me.btnAuditoria.TabIndex = 16
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(1110, 273)
        Me.btnConsultar.TabIndex = 14
        '
        'btnBorrar
        '
        Me.btnBorrar.Location = New System.Drawing.Point(1110, 186)
        Me.btnBorrar.TabIndex = 13
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(1110, 99)
        Me.btnModificar.TabIndex = 12
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(1110, 12)
        Me.btnAgregar.TabIndex = 11
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(251, 14)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(216, 24)
        Me.lblNombreEmpresa.TabIndex = 39
        Me.lblNombreEmpresa.Text = "<nombre del usuario>"
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(171, 12)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(74, 29)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 24)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Empresa:"
        '
        'lblNombreCuenta
        '
        Me.lblNombreCuenta.AutoSize = True
        Me.lblNombreCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCuenta.Location = New System.Drawing.Point(6, 114)
        Me.lblNombreCuenta.Name = "lblNombreCuenta"
        Me.lblNombreCuenta.Size = New System.Drawing.Size(271, 24)
        Me.lblNombreCuenta.TabIndex = 73
        Me.lblNombreCuenta.Text = "<nombre_cuenta_contable>"
        '
        'txtCuenta6_NE
        '
        Me.txtCuenta6_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta6_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta6_NE.Location = New System.Drawing.Point(440, 82)
        Me.txtCuenta6_NE.Name = "txtCuenta6_NE"
        Me.txtCuenta6_NE.Size = New System.Drawing.Size(75, 29)
        Me.txtCuenta6_NE.TabIndex = 7
        Me.txtCuenta6_NE.Text = "000000"
        '
        'txtCuenta5_NE
        '
        Me.txtCuenta5_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta5_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta5_NE.Location = New System.Drawing.Point(369, 82)
        Me.txtCuenta5_NE.Name = "txtCuenta5_NE"
        Me.txtCuenta5_NE.Size = New System.Drawing.Size(65, 29)
        Me.txtCuenta5_NE.TabIndex = 6
        Me.txtCuenta5_NE.Text = "00000"
        '
        'txtCuenta4_NE
        '
        Me.txtCuenta4_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta4_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta4_NE.Location = New System.Drawing.Point(305, 82)
        Me.txtCuenta4_NE.Name = "txtCuenta4_NE"
        Me.txtCuenta4_NE.Size = New System.Drawing.Size(58, 29)
        Me.txtCuenta4_NE.TabIndex = 5
        Me.txtCuenta4_NE.Text = "0000"
        '
        'txtCuenta3_NE
        '
        Me.txtCuenta3_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta3_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta3_NE.Location = New System.Drawing.Point(251, 82)
        Me.txtCuenta3_NE.Name = "txtCuenta3_NE"
        Me.txtCuenta3_NE.Size = New System.Drawing.Size(48, 29)
        Me.txtCuenta3_NE.TabIndex = 4
        Me.txtCuenta3_NE.Text = "000"
        '
        'txtCuenta2_NE
        '
        Me.txtCuenta2_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta2_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta2_NE.Location = New System.Drawing.Point(206, 82)
        Me.txtCuenta2_NE.Name = "txtCuenta2_NE"
        Me.txtCuenta2_NE.Size = New System.Drawing.Size(39, 29)
        Me.txtCuenta2_NE.TabIndex = 3
        Me.txtCuenta2_NE.Text = "00"
        '
        'txtCuenta1_NE
        '
        Me.txtCuenta1_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta1_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta1_NE.Location = New System.Drawing.Point(172, 82)
        Me.txtCuenta1_NE.Name = "txtCuenta1_NE"
        Me.txtCuenta1_NE.Size = New System.Drawing.Size(28, 29)
        Me.txtCuenta1_NE.TabIndex = 2
        Me.txtCuenta1_NE.Text = "0"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuenta.Location = New System.Drawing.Point(522, 82)
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.ReadOnly = True
        Me.txtCodCuenta.Size = New System.Drawing.Size(339, 29)
        Me.txtCodCuenta.TabIndex = 71
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 24)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Cuenta contable:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(851, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 24)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Hasta:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFecha2_FE
        '
        Me.txtFecha2_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha2_FE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha2_FE.Location = New System.Drawing.Point(919, 136)
        Me.txtFecha2_FE.Name = "txtFecha2_FE"
        Me.txtFecha2_FE.Size = New System.Drawing.Size(185, 29)
        Me.txtFecha2_FE.TabIndex = 9
        '
        'lblSaldoAnterior
        '
        Me.lblSaldoAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoAnterior.Location = New System.Drawing.Point(683, 197)
        Me.lblSaldoAnterior.Name = "lblSaldoAnterior"
        Me.lblSaldoAnterior.Size = New System.Drawing.Size(421, 24)
        Me.lblSaldoAnterior.TabIndex = 76
        Me.lblSaldoAnterior.Text = "<nombre_cuenta_contable>"
        Me.lblSaldoAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(9, 224)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1095, 401)
        Me.DataGridView1.TabIndex = 10
        '
        'txtFecha1_FE
        '
        Me.txtFecha1_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha1_FE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha1_FE.Location = New System.Drawing.Point(660, 136)
        Me.txtFecha1_FE.Name = "txtFecha1_FE"
        Me.txtFecha1_FE.Size = New System.Drawing.Size(185, 29)
        Me.txtFecha1_FE.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(592, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 24)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Desde:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalCreditos
        '
        Me.lblTotalCreditos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCreditos.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTotalCreditos.Location = New System.Drawing.Point(918, 628)
        Me.lblTotalCreditos.Name = "lblTotalCreditos"
        Me.lblTotalCreditos.Size = New System.Drawing.Size(186, 24)
        Me.lblTotalCreditos.TabIndex = 82
        Me.lblTotalCreditos.Text = "Totales:"
        Me.lblTotalCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalDebitos
        '
        Me.lblTotalDebitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDebitos.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTotalDebitos.Location = New System.Drawing.Point(726, 628)
        Me.lblTotalDebitos.Name = "lblTotalDebitos"
        Me.lblTotalDebitos.Size = New System.Drawing.Size(186, 24)
        Me.lblTotalDebitos.TabIndex = 81
        Me.lblTotalDebitos.Text = "Totales:"
        Me.lblTotalDebitos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(630, 628)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 24)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Totales:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSaldoFinal
        '
        Me.lblSaldoFinal.AutoSize = True
        Me.lblSaldoFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoFinal.Location = New System.Drawing.Point(5, 628)
        Me.lblSaldoFinal.Name = "lblSaldoFinal"
        Me.lblSaldoFinal.Size = New System.Drawing.Size(84, 24)
        Me.lblSaldoFinal.TabIndex = 83
        Me.lblSaldoFinal.Text = "Totales:"
        Me.lblSaldoFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnImprimir
        '
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = Global.sigafyc.My.Resources.Resources.icons8_color_print_32
        Me.btnImprimir.Location = New System.Drawing.Point(1110, 360)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(86, 81)
        Me.btnImprimir.TabIndex = 15
        Me.btnImprimir.Tag = "Imprimir"
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblNombreSucursal
        '
        Me.lblNombreSucursal.AutoSize = True
        Me.lblNombreSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSucursal.Location = New System.Drawing.Point(251, 49)
        Me.lblNombreSucursal.Name = "lblNombreSucursal"
        Me.lblNombreSucursal.Size = New System.Drawing.Size(195, 24)
        Me.lblNombreSucursal.TabIndex = 87
        Me.lblNombreSucursal.Text = "<nombre_sucursal>"
        '
        'txtCodSucursal_NE
        '
        Me.txtCodSucursal_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodSucursal_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodSucursal_NE.Location = New System.Drawing.Point(171, 47)
        Me.txtCodSucursal_NE.Name = "txtCodSucursal_NE"
        Me.txtCodSucursal_NE.Size = New System.Drawing.Size(74, 29)
        Me.txtCodSucursal_NE.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 24)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Sucursal:"
        '
        'frmBMayorCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1208, 664)
        Me.Controls.Add(Me.lblNombreSucursal)
        Me.Controls.Add(Me.txtCodSucursal_NE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.lblSaldoFinal)
        Me.Controls.Add(Me.lblTotalCreditos)
        Me.Controls.Add(Me.lblTotalDebitos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtFecha1_FE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblSaldoAnterior)
        Me.Controls.Add(Me.txtFecha2_FE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNombreCuenta)
        Me.Controls.Add(Me.txtCuenta6_NE)
        Me.Controls.Add(Me.txtCuenta5_NE)
        Me.Controls.Add(Me.txtCuenta4_NE)
        Me.Controls.Add(Me.txtCuenta3_NE)
        Me.Controls.Add(Me.txtCuenta2_NE)
        Me.Controls.Add(Me.txtCuenta1_NE)
        Me.Controls.Add(Me.txtCodCuenta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNombreEmpresa)
        Me.Controls.Add(Me.txtCodEmpresa_NE)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmBMayorCuenta"
        Me.Tag = ""
        Me.Text = "Browse Mayor de Cuenta"
        Me.Controls.SetChildIndex(Me.btnAgregar, 0)
        Me.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.Controls.SetChildIndex(Me.btnBorrar, 0)
        Me.Controls.SetChildIndex(Me.btnConsultar, 0)
        Me.Controls.SetChildIndex(Me.btnAuditoria, 0)
        Me.Controls.SetChildIndex(Me.btnSalir, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtCodEmpresa_NE, 0)
        Me.Controls.SetChildIndex(Me.lblNombreEmpresa, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtCodCuenta, 0)
        Me.Controls.SetChildIndex(Me.txtCuenta1_NE, 0)
        Me.Controls.SetChildIndex(Me.txtCuenta2_NE, 0)
        Me.Controls.SetChildIndex(Me.txtCuenta3_NE, 0)
        Me.Controls.SetChildIndex(Me.txtCuenta4_NE, 0)
        Me.Controls.SetChildIndex(Me.txtCuenta5_NE, 0)
        Me.Controls.SetChildIndex(Me.txtCuenta6_NE, 0)
        Me.Controls.SetChildIndex(Me.lblNombreCuenta, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtFecha2_FE, 0)
        Me.Controls.SetChildIndex(Me.lblSaldoAnterior, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtFecha1_FE, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.lblTotalDebitos, 0)
        Me.Controls.SetChildIndex(Me.lblTotalCreditos, 0)
        Me.Controls.SetChildIndex(Me.lblSaldoFinal, 0)
        Me.Controls.SetChildIndex(Me.btnImprimir, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtCodSucursal_NE, 0)
        Me.Controls.SetChildIndex(Me.lblNombreSucursal, 0)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNombreCuenta As Label
    Friend WithEvents txtCuenta6_NE As TextBox
    Friend WithEvents txtCuenta5_NE As TextBox
    Friend WithEvents txtCuenta4_NE As TextBox
    Friend WithEvents txtCuenta3_NE As TextBox
    Friend WithEvents txtCuenta2_NE As TextBox
    Friend WithEvents txtCuenta1_NE As TextBox
    Friend WithEvents txtCodCuenta As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFecha2_FE As TextBox
    Friend WithEvents lblSaldoAnterior As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtFecha1_FE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotalCreditos As Label
    Friend WithEvents lblTotalDebitos As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblSaldoFinal As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents lblNombreSucursal As Label
    Friend WithEvents txtCodSucursal_NE As TextBox
    Friend WithEvents Label6 As Label
End Class
