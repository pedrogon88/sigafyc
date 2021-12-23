<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBSaldosCuentas : Inherits frmBrowseSinGrid


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
        Me.txtFecha_FE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblNombreSucursal = New System.Windows.Forms.Label()
        Me.txtCodSucursal_NE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.gbxGrupo = New System.Windows.Forms.GroupBox()
        Me.rbtNIvel6 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel5 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel4 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel3 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel2 = New System.Windows.Forms.RadioButton()
        Me.rbtNIvel1 = New System.Windows.Forms.RadioButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxGrupo.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(10, 160)
        Me.txtBuscar.TabIndex = 12
        '
        'btnSalir
        '
        Me.btnSalir.TabIndex = 11
        '
        'btnAuditoria
        '
        Me.btnAuditoria.TabIndex = 10
        '
        'btnConsultar
        '
        Me.btnConsultar.TabIndex = 8
        '
        'btnBorrar
        '
        Me.btnBorrar.TabIndex = 7
        '
        'btnModificar
        '
        Me.btnModificar.TabIndex = 6
        '
        'btnAgregar
        '
        Me.btnAgregar.TabIndex = 5
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(185, 9)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(216, 24)
        Me.lblNombreEmpresa.TabIndex = 42
        Me.lblNombreEmpresa.Text = "<nombre del usuario>"
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(105, 7)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(74, 29)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 24)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Empresa:"
        '
        'txtFecha_FE
        '
        Me.txtFecha_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha_FE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha_FE.Location = New System.Drawing.Point(676, 125)
        Me.txtFecha_FE.Name = "txtFecha_FE"
        Me.txtFecha_FE.Size = New System.Drawing.Size(185, 29)
        Me.txtFecha_FE.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(588, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 24)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Saldo al:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(10, 188)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(851, 462)
        Me.DataGridView1.TabIndex = 4
        '
        'lblNombreSucursal
        '
        Me.lblNombreSucursal.AutoSize = True
        Me.lblNombreSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSucursal.Location = New System.Drawing.Point(185, 44)
        Me.lblNombreSucursal.Name = "lblNombreSucursal"
        Me.lblNombreSucursal.Size = New System.Drawing.Size(195, 24)
        Me.lblNombreSucursal.TabIndex = 80
        Me.lblNombreSucursal.Text = "<nombre_sucursal>"
        '
        'txtCodSucursal_NE
        '
        Me.txtCodSucursal_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodSucursal_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodSucursal_NE.Location = New System.Drawing.Point(105, 42)
        Me.txtCodSucursal_NE.Name = "txtCodSucursal_NE"
        Me.txtCodSucursal_NE.Size = New System.Drawing.Size(74, 29)
        Me.txtCodSucursal_NE.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Sucursal:"
        '
        'btnImprimir
        '
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = Global.sigafyc.My.Resources.Resources.icons8_color_print_32
        Me.btnImprimir.Location = New System.Drawing.Point(867, 362)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(86, 81)
        Me.btnImprimir.TabIndex = 9
        Me.btnImprimir.Tag = "Imprimir"
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'gbxGrupo
        '
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel6)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel5)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel4)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel3)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel2)
        Me.gbxGrupo.Controls.Add(Me.rbtNIvel1)
        Me.gbxGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxGrupo.Location = New System.Drawing.Point(12, 86)
        Me.gbxGrupo.Name = "gbxGrupo"
        Me.gbxGrupo.Size = New System.Drawing.Size(517, 68)
        Me.gbxGrupo.TabIndex = 2
        Me.gbxGrupo.TabStop = False
        Me.gbxGrupo.Text = "nivel"
        '
        'rbtNIvel6
        '
        Me.rbtNIvel6.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel6.Location = New System.Drawing.Point(419, 25)
        Me.rbtNIvel6.Name = "rbtNIvel6"
        Me.rbtNIvel6.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel6.TabIndex = 5
        Me.rbtNIvel6.TabStop = True
        Me.rbtNIvel6.Text = "6"
        Me.rbtNIvel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel6.UseVisualStyleBackColor = True
        '
        'rbtNIvel5
        '
        Me.rbtNIvel5.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel5.Location = New System.Drawing.Point(341, 25)
        Me.rbtNIvel5.Name = "rbtNIvel5"
        Me.rbtNIvel5.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel5.TabIndex = 4
        Me.rbtNIvel5.TabStop = True
        Me.rbtNIvel5.Text = "5"
        Me.rbtNIvel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel5.UseVisualStyleBackColor = True
        '
        'rbtNIvel4
        '
        Me.rbtNIvel4.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel4.Location = New System.Drawing.Point(263, 25)
        Me.rbtNIvel4.Name = "rbtNIvel4"
        Me.rbtNIvel4.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel4.TabIndex = 3
        Me.rbtNIvel4.TabStop = True
        Me.rbtNIvel4.Text = "4"
        Me.rbtNIvel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel4.UseVisualStyleBackColor = True
        '
        'rbtNIvel3
        '
        Me.rbtNIvel3.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel3.Location = New System.Drawing.Point(185, 25)
        Me.rbtNIvel3.Name = "rbtNIvel3"
        Me.rbtNIvel3.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel3.TabIndex = 2
        Me.rbtNIvel3.TabStop = True
        Me.rbtNIvel3.Text = "3"
        Me.rbtNIvel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel3.UseVisualStyleBackColor = True
        '
        'rbtNIvel2
        '
        Me.rbtNIvel2.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel2.Location = New System.Drawing.Point(107, 25)
        Me.rbtNIvel2.Name = "rbtNIvel2"
        Me.rbtNIvel2.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel2.TabIndex = 1
        Me.rbtNIvel2.TabStop = True
        Me.rbtNIvel2.Text = "2"
        Me.rbtNIvel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel2.UseVisualStyleBackColor = True
        '
        'rbtNIvel1
        '
        Me.rbtNIvel1.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbtNIvel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rbtNIvel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtNIvel1.Location = New System.Drawing.Point(29, 25)
        Me.rbtNIvel1.Name = "rbtNIvel1"
        Me.rbtNIvel1.Size = New System.Drawing.Size(72, 30)
        Me.rbtNIvel1.TabIndex = 0
        Me.rbtNIvel1.TabStop = True
        Me.rbtNIvel1.Text = "1"
        Me.rbtNIvel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbtNIvel1.UseVisualStyleBackColor = True
        '
        'frmBSaldosCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 660)
        Me.Controls.Add(Me.gbxGrupo)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.lblNombreSucursal)
        Me.Controls.Add(Me.txtCodSucursal_NE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtFecha_FE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNombreEmpresa)
        Me.Controls.Add(Me.txtCodEmpresa_NE)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmBSaldosCuentas"
        Me.Tag = ""
        Me.Text = "Browse Saldos por Cuenta"
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
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtFecha_FE, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtCodSucursal_NE, 0)
        Me.Controls.SetChildIndex(Me.lblNombreSucursal, 0)
        Me.Controls.SetChildIndex(Me.btnImprimir, 0)
        Me.Controls.SetChildIndex(Me.gbxGrupo, 0)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxGrupo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFecha_FE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblNombreSucursal As Label
    Friend WithEvents txtCodSucursal_NE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnImprimir As Button
    Friend WithEvents gbxGrupo As GroupBox
    Friend WithEvents rbtNIvel6 As RadioButton
    Friend WithEvents rbtNIvel5 As RadioButton
    Friend WithEvents rbtNIvel4 As RadioButton
    Friend WithEvents rbtNIvel3 As RadioButton
    Friend WithEvents rbtNIvel2 As RadioButton
    Friend WithEvents rbtNIvel1 As RadioButton
End Class
