<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFc020documentos : Inherits frmFormulario

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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigo_NE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.cmbTimbrado = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCodMoneda_AN = New System.Windows.Forms.TextBox()
        Me.lblNombreMoneda = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLineas_NE = New System.Windows.Forms.TextBox()
        Me.txtAbreviado_AN = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNombre_AN = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbxCotizacion = New System.Windows.Forms.GroupBox()
        Me.optSemisuma = New System.Windows.Forms.RadioButton()
        Me.optVenta = New System.Windows.Forms.RadioButton()
        Me.optCompra = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.gbxCotizacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Size = New System.Drawing.Size(852, 441)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage2, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TabPage1, 0)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gbxCotizacion)
        Me.TabPage1.Controls.Add(Me.txtAbreviado_AN)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtNombre_AN)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtLineas_NE)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.lblNombreMoneda)
        Me.TabPage1.Controls.Add(Me.txtCodMoneda_AN)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cmbTimbrado)
        Me.TabPage1.Controls.Add(Me.lblNombreEmpresa)
        Me.TabPage1.Controls.Add(Me.cmbTipo)
        Me.TabPage1.Controls.Add(Me.txtCodEmpresa_NE)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtCodigo_NE)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Size = New System.Drawing.Size(844, 401)
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(16, 496)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(727, 492)
        '
        'lblMensaje
        '
        Me.lblMensaje.Size = New System.Drawing.Size(848, 37)
        '
        'TabPage2
        '
        Me.TabPage2.AccessibleName = "Activo"
        Me.TabPage2.Controls.Add(Me.cmbEstado)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 36)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(844, 401)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Complementario"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Activo", "Bloqueado"})
        Me.cmbEstado.Location = New System.Drawing.Point(101, 22)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(196, 32)
        Me.cmbEstado.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 25)
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
        Me.cmbTipo.Items.AddRange(New Object() {"Propio", "Tercero"})
        Me.cmbTipo.Location = New System.Drawing.Point(180, 113)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(225, 32)
        Me.cmbTipo.TabIndex = 2
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(180, 19)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 24)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Empresa:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 261)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 24)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Maneja timbrado:"
        '
        'txtCodigo_NE
        '
        Me.txtCodigo_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo_NE.Location = New System.Drawing.Point(180, 66)
        Me.txtCodigo_NE.Name = "txtCodigo_NE"
        Me.txtCodigo_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtCodigo_NE.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 24)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Tipo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 24)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Documento:"
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(301, 21)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(214, 24)
        Me.lblNombreEmpresa.TabIndex = 43
        Me.lblNombreEmpresa.Text = "<nombre_de_empresa>"
        '
        'cmbTimbrado
        '
        Me.cmbTimbrado.AccessibleDescription = "tipo"
        Me.cmbTimbrado.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbTimbrado.FormattingEnabled = True
        Me.cmbTimbrado.Items.AddRange(New Object() {"No", "Si"})
        Me.cmbTimbrado.Location = New System.Drawing.Point(180, 257)
        Me.cmbTimbrado.Name = "cmbTimbrado"
        Me.cmbTimbrado.Size = New System.Drawing.Size(67, 32)
        Me.cmbTimbrado.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 309)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 24)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Moneda:"
        '
        'txtCodMoneda_AN
        '
        Me.txtCodMoneda_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodMoneda_AN.Location = New System.Drawing.Point(180, 307)
        Me.txtCodMoneda_AN.Name = "txtCodMoneda_AN"
        Me.txtCodMoneda_AN.Size = New System.Drawing.Size(67, 29)
        Me.txtCodMoneda_AN.TabIndex = 6
        '
        'lblNombreMoneda
        '
        Me.lblNombreMoneda.AutoSize = True
        Me.lblNombreMoneda.Location = New System.Drawing.Point(253, 309)
        Me.lblNombreMoneda.Name = "lblNombreMoneda"
        Me.lblNombreMoneda.Size = New System.Drawing.Size(178, 24)
        Me.lblNombreMoneda.TabIndex = 47
        Me.lblNombreMoneda.Text = "<nombre_moneda>"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(19, 357)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 24)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Lineas:"
        '
        'txtLineas_NE
        '
        Me.txtLineas_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineas_NE.Location = New System.Drawing.Point(180, 354)
        Me.txtLineas_NE.Name = "txtLineas_NE"
        Me.txtLineas_NE.Size = New System.Drawing.Size(67, 29)
        Me.txtLineas_NE.TabIndex = 7
        '
        'txtAbreviado_AN
        '
        Me.txtAbreviado_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAbreviado_AN.Location = New System.Drawing.Point(180, 163)
        Me.txtAbreviado_AN.Name = "txtAbreviado_AN"
        Me.txtAbreviado_AN.Size = New System.Drawing.Size(329, 29)
        Me.txtAbreviado_AN.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 24)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Abreviado:"
        '
        'txtNombre_AN
        '
        Me.txtNombre_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre_AN.Location = New System.Drawing.Point(180, 210)
        Me.txtNombre_AN.Name = "txtNombre_AN"
        Me.txtNombre_AN.Size = New System.Drawing.Size(644, 29)
        Me.txtNombre_AN.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(19, 213)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 24)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Nombre "
        '
        'gbxCotizacion
        '
        Me.gbxCotizacion.Controls.Add(Me.optSemisuma)
        Me.gbxCotizacion.Controls.Add(Me.optVenta)
        Me.gbxCotizacion.Controls.Add(Me.optCompra)
        Me.gbxCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxCotizacion.Location = New System.Drawing.Point(500, 307)
        Me.gbxCotizacion.Name = "gbxCotizacion"
        Me.gbxCotizacion.Size = New System.Drawing.Size(324, 76)
        Me.gbxCotizacion.TabIndex = 8
        Me.gbxCotizacion.TabStop = False
        Me.gbxCotizacion.Text = "tipo cotización vinculada"
        '
        'optSemisuma
        '
        Me.optSemisuma.Appearance = System.Windows.Forms.Appearance.Button
        Me.optSemisuma.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optSemisuma.Location = New System.Drawing.Point(228, 26)
        Me.optSemisuma.Name = "optSemisuma"
        Me.optSemisuma.Size = New System.Drawing.Size(73, 24)
        Me.optSemisuma.TabIndex = 2
        Me.optSemisuma.TabStop = True
        Me.optSemisuma.Text = "Semisuma"
        Me.optSemisuma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optSemisuma.UseVisualStyleBackColor = True
        '
        'optVenta
        '
        Me.optVenta.Appearance = System.Windows.Forms.Appearance.Button
        Me.optVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optVenta.Location = New System.Drawing.Point(126, 26)
        Me.optVenta.Name = "optVenta"
        Me.optVenta.Size = New System.Drawing.Size(73, 24)
        Me.optVenta.TabIndex = 1
        Me.optVenta.TabStop = True
        Me.optVenta.Text = "Venta"
        Me.optVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optVenta.UseVisualStyleBackColor = True
        '
        'optCompra
        '
        Me.optCompra.Appearance = System.Windows.Forms.Appearance.Button
        Me.optCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.optCompra.Location = New System.Drawing.Point(24, 26)
        Me.optCompra.Name = "optCompra"
        Me.optCompra.Size = New System.Drawing.Size(73, 24)
        Me.optCompra.TabIndex = 0
        Me.optCompra.TabStop = True
        Me.optCompra.Text = "Compra"
        Me.optCompra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.optCompra.UseVisualStyleBackColor = True
        '
        'frmFc020documentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(872, 576)
        Me.Name = "frmFc020documentos"
        Me.Tag = ""
        Me.Text = "Formulario de Documento"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.gbxCotizacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCodigo_NE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtLineas_NE As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblNombreMoneda As Label
    Friend WithEvents txtCodMoneda_AN As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbTimbrado As ComboBox
    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtAbreviado_AN As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNombre_AN As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents gbxCotizacion As GroupBox
    Friend WithEvents optVenta As RadioButton
    Friend WithEvents optCompra As RadioButton
    Friend WithEvents optSemisuma As RadioButton
End Class
