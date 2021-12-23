<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFoitmc1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCardCode_AN = New System.Windows.Forms.TextBox()
        Me.txtNombreCliente_AN = New System.Windows.Forms.TextBox()
        Me.txtEmpresa_AN = New System.Windows.Forms.TextBox()
        Me.txtAbogado_AN = New System.Windows.Forms.TextBox()
        Me.txtSucursal_AN = New System.Windows.Forms.TextBox()
        Me.txtMarcaModelo_AN = New System.Windows.Forms.TextBox()
        Me.txtPeriodoFac_FE = New System.Windows.Forms.TextBox()
        Me.txtVentaUSD_ND = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lblGV = New System.Windows.Forms.Label()
        Me.lblVT = New System.Windows.Forms.Label()
        Me.lblMensajeError = New System.Windows.Forms.Label()
        Me.txtFechaRemate_FE = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtValorTasacion_ND = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPrecioVenta_ND = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtGastoVenta_ND = New System.Windows.Forms.TextBox()
        Me.txtFechaSecuestro_FE = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFechaOrdenSecuestro_FE = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtFechaDemanda_FE = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPagosUSD_ND = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSaldoUSD_ND = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtStock_AN = New System.Windows.Forms.TextBox()
        Me.txtInicialesAbog_AN = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.AccessibleName = "Activo"
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 49)
        Me.TabControl1.Size = New System.Drawing.Size(646, 491)
        Me.TabControl1.Tag = ""
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage3, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.txtInicialesAbog_AN)
        Me.TabPage1.Controls.Add(Me.txtStock_AN)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.txtSaldoUSD_ND)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.txtPagosUSD_ND)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.txtVentaUSD_ND)
        Me.TabPage1.Controls.Add(Me.txtPeriodoFac_FE)
        Me.TabPage1.Controls.Add(Me.txtMarcaModelo_AN)
        Me.TabPage1.Controls.Add(Me.txtSucursal_AN)
        Me.TabPage1.Controls.Add(Me.txtAbogado_AN)
        Me.TabPage1.Controls.Add(Me.txtEmpresa_AN)
        Me.TabPage1.Controls.Add(Me.txtNombreCliente_AN)
        Me.TabPage1.Controls.Add(Me.txtCardCode_AN)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 36)
        Me.TabPage1.Size = New System.Drawing.Size(638, 451)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(16, 544)
        Me.btnCancelar.Size = New System.Drawing.Size(133, 73)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(521, 544)
        Me.btnAceptar.Size = New System.Drawing.Size(133, 73)
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(12, 9)
        Me.lblMensaje.Size = New System.Drawing.Size(642, 37)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 24)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Codigo Cliente:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 24)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Nombre del Cliente"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 24)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Empresa"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 24)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Abogado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 24)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Sucursal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 24)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Marca / Modelo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 286)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(171, 24)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Periodo Facturado:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 330)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 24)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Monto venta:"
        '
        'txtCardCode_AN
        '
        Me.txtCardCode_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCardCode_AN.Location = New System.Drawing.Point(201, 19)
        Me.txtCardCode_AN.Name = "txtCardCode_AN"
        Me.txtCardCode_AN.Size = New System.Drawing.Size(132, 29)
        Me.txtCardCode_AN.TabIndex = 0
        '
        'txtNombreCliente_AN
        '
        Me.txtNombreCliente_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreCliente_AN.Location = New System.Drawing.Point(204, 66)
        Me.txtNombreCliente_AN.Name = "txtNombreCliente_AN"
        Me.txtNombreCliente_AN.Size = New System.Drawing.Size(403, 29)
        Me.txtNombreCliente_AN.TabIndex = 2
        '
        'txtEmpresa_AN
        '
        Me.txtEmpresa_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpresa_AN.Location = New System.Drawing.Point(204, 107)
        Me.txtEmpresa_AN.Name = "txtEmpresa_AN"
        Me.txtEmpresa_AN.Size = New System.Drawing.Size(403, 29)
        Me.txtEmpresa_AN.TabIndex = 3
        '
        'txtAbogado_AN
        '
        Me.txtAbogado_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAbogado_AN.Location = New System.Drawing.Point(204, 151)
        Me.txtAbogado_AN.Name = "txtAbogado_AN"
        Me.txtAbogado_AN.Size = New System.Drawing.Size(280, 29)
        Me.txtAbogado_AN.TabIndex = 4
        '
        'txtSucursal_AN
        '
        Me.txtSucursal_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSucursal_AN.Location = New System.Drawing.Point(204, 198)
        Me.txtSucursal_AN.Name = "txtSucursal_AN"
        Me.txtSucursal_AN.Size = New System.Drawing.Size(403, 29)
        Me.txtSucursal_AN.TabIndex = 6
        '
        'txtMarcaModelo_AN
        '
        Me.txtMarcaModelo_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMarcaModelo_AN.Location = New System.Drawing.Point(204, 239)
        Me.txtMarcaModelo_AN.Name = "txtMarcaModelo_AN"
        Me.txtMarcaModelo_AN.Size = New System.Drawing.Size(403, 29)
        Me.txtMarcaModelo_AN.TabIndex = 7
        '
        'txtPeriodoFac_FE
        '
        Me.txtPeriodoFac_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodoFac_FE.Location = New System.Drawing.Point(204, 283)
        Me.txtPeriodoFac_FE.Name = "txtPeriodoFac_FE"
        Me.txtPeriodoFac_FE.Size = New System.Drawing.Size(235, 29)
        Me.txtPeriodoFac_FE.TabIndex = 8
        '
        'txtVentaUSD_ND
        '
        Me.txtVentaUSD_ND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVentaUSD_ND.Location = New System.Drawing.Point(204, 327)
        Me.txtVentaUSD_ND.Name = "txtVentaUSD_ND"
        Me.txtVentaUSD_ND.Size = New System.Drawing.Size(235, 29)
        Me.txtVentaUSD_ND.TabIndex = 9
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleName = "Activo"
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 36)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(638, 451)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Complementario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(240, 18)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(196, 32)
        Me.cmbEstado.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(155, 24)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Estado operativo:"
        '
        'TabPage3
        '
        Me.TabPage3.AccessibleName = "Activo"
        Me.TabPage3.Controls.Add(Me.lblGV)
        Me.TabPage3.Controls.Add(Me.lblVT)
        Me.TabPage3.Controls.Add(Me.lblMensajeError)
        Me.TabPage3.Controls.Add(Me.txtFechaRemate_FE)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.txtValorTasacion_ND)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.txtPrecioVenta_ND)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.txtGastoVenta_ND)
        Me.TabPage3.Controls.Add(Me.txtFechaSecuestro_FE)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.txtFechaOrdenSecuestro_FE)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.txtFechaDemanda_FE)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Location = New System.Drawing.Point(4, 36)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(638, 451)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Seguimiento"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lblGV
        '
        Me.lblGV.AutoSize = True
        Me.lblGV.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGV.ForeColor = System.Drawing.Color.Red
        Me.lblGV.Location = New System.Drawing.Point(477, 238)
        Me.lblGV.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblGV.Name = "lblGV"
        Me.lblGV.Size = New System.Drawing.Size(0, 24)
        Me.lblGV.TabIndex = 29
        '
        'lblVT
        '
        Me.lblVT.AutoSize = True
        Me.lblVT.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVT.ForeColor = System.Drawing.Color.Red
        Me.lblVT.Location = New System.Drawing.Point(477, 151)
        Me.lblVT.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblVT.Name = "lblVT"
        Me.lblVT.Size = New System.Drawing.Size(0, 24)
        Me.lblVT.TabIndex = 28
        '
        'lblMensajeError
        '
        Me.lblMensajeError.AutoSize = True
        Me.lblMensajeError.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeError.ForeColor = System.Drawing.Color.Red
        Me.lblMensajeError.Location = New System.Drawing.Point(233, 318)
        Me.lblMensajeError.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblMensajeError.Name = "lblMensajeError"
        Me.lblMensajeError.Size = New System.Drawing.Size(0, 24)
        Me.lblMensajeError.TabIndex = 27
        '
        'txtFechaRemate_FE
        '
        Me.txtFechaRemate_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaRemate_FE.Location = New System.Drawing.Point(237, 192)
        Me.txtFechaRemate_FE.Name = "txtFechaRemate_FE"
        Me.txtFechaRemate_FE.Size = New System.Drawing.Size(235, 29)
        Me.txtFechaRemate_FE.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(22, 193)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 24)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "Fecha remate"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(22, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(128, 24)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Valor tasación"
        '
        'txtValorTasacion_ND
        '
        Me.txtValorTasacion_ND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorTasacion_ND.Location = New System.Drawing.Point(237, 150)
        Me.txtValorTasacion_ND.Name = "txtValorTasacion_ND"
        Me.txtValorTasacion_ND.Size = New System.Drawing.Size(235, 29)
        Me.txtValorTasacion_ND.TabIndex = 3
        Me.txtValorTasacion_ND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(22, 278)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(145, 24)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Precio de Venta"
        '
        'txtPrecioVenta_ND
        '
        Me.txtPrecioVenta_ND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecioVenta_ND.Location = New System.Drawing.Point(237, 276)
        Me.txtPrecioVenta_ND.Name = "txtPrecioVenta_ND"
        Me.txtPrecioVenta_ND.Size = New System.Drawing.Size(235, 29)
        Me.txtPrecioVenta_ND.TabIndex = 6
        Me.txtPrecioVenta_ND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(22, 236)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(164, 24)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Gasto para vender"
        '
        'txtGastoVenta_ND
        '
        Me.txtGastoVenta_ND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGastoVenta_ND.Location = New System.Drawing.Point(237, 234)
        Me.txtGastoVenta_ND.Name = "txtGastoVenta_ND"
        Me.txtGastoVenta_ND.Size = New System.Drawing.Size(235, 29)
        Me.txtGastoVenta_ND.TabIndex = 5
        Me.txtGastoVenta_ND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFechaSecuestro_FE
        '
        Me.txtFechaSecuestro_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaSecuestro_FE.Location = New System.Drawing.Point(237, 107)
        Me.txtFechaSecuestro_FE.Name = "txtFechaSecuestro_FE"
        Me.txtFechaSecuestro_FE.Size = New System.Drawing.Size(235, 29)
        Me.txtFechaSecuestro_FE.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(22, 109)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(151, 24)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Fecha secuestro"
        '
        'txtFechaOrdenSecuestro_FE
        '
        Me.txtFechaOrdenSecuestro_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaOrdenSecuestro_FE.Location = New System.Drawing.Point(237, 65)
        Me.txtFechaOrdenSecuestro_FE.Name = "txtFechaOrdenSecuestro_FE"
        Me.txtFechaOrdenSecuestro_FE.Size = New System.Drawing.Size(235, 29)
        Me.txtFechaOrdenSecuestro_FE.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(22, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(206, 24)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Fecha orden secuestro"
        '
        'txtFechaDemanda_FE
        '
        Me.txtFechaDemanda_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaDemanda_FE.Location = New System.Drawing.Point(237, 23)
        Me.txtFechaDemanda_FE.Name = "txtFechaDemanda_FE"
        Me.txtFechaDemanda_FE.Size = New System.Drawing.Size(235, 29)
        Me.txtFechaDemanda_FE.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(22, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(149, 24)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Fecha demanda"
        '
        'txtPagosUSD_ND
        '
        Me.txtPagosUSD_ND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPagosUSD_ND.Location = New System.Drawing.Point(204, 369)
        Me.txtPagosUSD_ND.Name = "txtPagosUSD_ND"
        Me.txtPagosUSD_ND.Size = New System.Drawing.Size(235, 29)
        Me.txtPagosUSD_ND.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(22, 372)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(137, 24)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Monto pagado:"
        '
        'txtSaldoUSD_ND
        '
        Me.txtSaldoUSD_ND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldoUSD_ND.Location = New System.Drawing.Point(204, 410)
        Me.txtSaldoUSD_ND.Name = "txtSaldoUSD_ND"
        Me.txtSaldoUSD_ND.Size = New System.Drawing.Size(235, 29)
        Me.txtSaldoUSD_ND.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(22, 414)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 24)
        Me.Label18.TabIndex = 19
        Me.Label18.Text = "Deuda:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(368, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 24)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "Stock:"
        '
        'txtStock_AN
        '
        Me.txtStock_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStock_AN.Location = New System.Drawing.Point(426, 20)
        Me.txtStock_AN.Name = "txtStock_AN"
        Me.txtStock_AN.Size = New System.Drawing.Size(181, 29)
        Me.txtStock_AN.TabIndex = 1
        '
        'txtInicialesAbog_AN
        '
        Me.txtInicialesAbog_AN.AccessibleName = "inicialesabog"
        Me.txtInicialesAbog_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInicialesAbog_AN.Location = New System.Drawing.Point(490, 151)
        Me.txtInicialesAbog_AN.Name = "txtInicialesAbog_AN"
        Me.txtInicialesAbog_AN.Size = New System.Drawing.Size(118, 29)
        Me.txtInicialesAbog_AN.TabIndex = 5
        '
        'frmFoitmc1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(668, 629)
        Me.Name = "frmFoitmc1"
        Me.Tag = ""
        Me.Text = "Formulario Unidades - Gestión Juridica"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtVentaUSD_ND As TextBox
    Friend WithEvents txtPeriodoFac_FE As TextBox
    Friend WithEvents txtMarcaModelo_AN As TextBox
    Friend WithEvents txtSucursal_AN As TextBox
    Friend WithEvents txtAbogado_AN As TextBox
    Friend WithEvents txtEmpresa_AN As TextBox
    Friend WithEvents txtNombreCliente_AN As TextBox
    Friend WithEvents txtCardCode_AN As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents txtFechaDemanda_FE As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtFechaSecuestro_FE As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtFechaOrdenSecuestro_FE As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtPrecioVenta_ND As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtGastoVenta_ND As TextBox
    Friend WithEvents txtFechaRemate_FE As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtValorTasacion_ND As TextBox
    Friend WithEvents txtSaldoUSD_ND As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtPagosUSD_ND As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtStock_AN As TextBox
    Friend WithEvents txtInicialesAbog_AN As TextBox
    Friend WithEvents lblMensajeError As Label
    Friend WithEvents lblGV As Label
    Friend WithEvents lblVT As Label
End Class
