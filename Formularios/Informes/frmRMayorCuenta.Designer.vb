<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRMayorCuenta : Inherits frmFormulario

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
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.txtCodEmpresa_NE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNombreSucursal = New System.Windows.Forms.Label()
        Me.txtCodSucursal_NE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbxGrupo = New System.Windows.Forms.GroupBox()
        Me.txtFecha2_FE = New System.Windows.Forms.TextBox()
        Me.txtFecha1_FE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Buscar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAdicionar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbxGrupo.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(9, 12)
        Me.TabControl1.Size = New System.Drawing.Size(1262, 527)
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.ListBox1)
        Me.TabPage1.Controls.Add(Me.Buscar)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.btnEliminar)
        Me.TabPage1.Controls.Add(Me.btnAdicionar)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.gbxGrupo)
        Me.TabPage1.Controls.Add(Me.lblNombreSucursal)
        Me.TabPage1.Controls.Add(Me.txtCodSucursal_NE)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.lblNombreEmpresa)
        Me.TabPage1.Controls.Add(Me.txtCodEmpresa_NE)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Size = New System.Drawing.Size(1254, 487)
        Me.TabPage1.Text = "Parametros requeridos"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(13, 541)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(1134, 541)
        '
        'lblMensaje
        '
        Me.lblMensaje.Size = New System.Drawing.Size(1256, 37)
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(240, 21)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(233, 24)
        Me.lblNombreEmpresa.TabIndex = 65
        Me.lblNombreEmpresa.Text = "<nombre_de_empresa>"
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(119, 19)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 24)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Empresa:"
        '
        'lblNombreSucursal
        '
        Me.lblNombreSucursal.AutoSize = True
        Me.lblNombreSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSucursal.Location = New System.Drawing.Point(240, 65)
        Me.lblNombreSucursal.Name = "lblNombreSucursal"
        Me.lblNombreSucursal.Size = New System.Drawing.Size(195, 24)
        Me.lblNombreSucursal.TabIndex = 83
        Me.lblNombreSucursal.Text = "<nombre_sucursal>"
        '
        'txtCodSucursal_NE
        '
        Me.txtCodSucursal_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodSucursal_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodSucursal_NE.Location = New System.Drawing.Point(119, 63)
        Me.txtCodSucursal_NE.Name = "txtCodSucursal_NE"
        Me.txtCodSucursal_NE.Size = New System.Drawing.Size(74, 29)
        Me.txtCodSucursal_NE.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Sucursal:"
        '
        'gbxGrupo
        '
        Me.gbxGrupo.Controls.Add(Me.txtFecha2_FE)
        Me.gbxGrupo.Controls.Add(Me.txtFecha1_FE)
        Me.gbxGrupo.Controls.Add(Me.Label8)
        Me.gbxGrupo.Controls.Add(Me.Label7)
        Me.gbxGrupo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gbxGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxGrupo.Location = New System.Drawing.Point(754, 19)
        Me.gbxGrupo.Name = "gbxGrupo"
        Me.gbxGrupo.Size = New System.Drawing.Size(482, 99)
        Me.gbxGrupo.TabIndex = 2
        Me.gbxGrupo.TabStop = False
        Me.gbxGrupo.Text = "rango de fecha"
        '
        'txtFecha2_FE
        '
        Me.txtFecha2_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha2_FE.Location = New System.Drawing.Point(215, 57)
        Me.txtFecha2_FE.Name = "txtFecha2_FE"
        Me.txtFecha2_FE.Size = New System.Drawing.Size(162, 26)
        Me.txtFecha2_FE.TabIndex = 1
        '
        'txtFecha1_FE
        '
        Me.txtFecha1_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha1_FE.Location = New System.Drawing.Point(215, 25)
        Me.txtFecha1_FE.Name = "txtFecha1_FE"
        Me.txtFecha1_FE.Size = New System.Drawing.Size(162, 26)
        Me.txtFecha1_FE.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(105, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 20)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Hasta:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(105, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Desde:"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 24
        Me.ListBox1.Location = New System.Drawing.Point(754, 166)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBox1.Size = New System.Drawing.Size(482, 292)
        Me.ListBox1.TabIndex = 4
        '
        'Buscar
        '
        Me.Buscar.AccessibleDescription = "codigo"
        Me.Buscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Buscar.Location = New System.Drawing.Point(20, 111)
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Size = New System.Drawing.Size(625, 29)
        Me.Buscar.TabIndex = 5
        Me.Buscar.Tag = "ingrese su busqueda"
        Me.Buscar.Text = "ingrese su busqueda"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(750, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(202, 24)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "cuentas seleccionadas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(177, 24)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "cuentas disponibles"
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = Global.sigafyc.My.Resources.Resources.icons8_back_to_32
        Me.btnEliminar.Location = New System.Drawing.Point(663, 319)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 61)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.Tag = "qutiar"
        Me.btnEliminar.Text = "qutiar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdicionar.Image = Global.sigafyc.My.Resources.Resources.icons8_next_page_32
        Me.btnAdicionar.Location = New System.Drawing.Point(663, 241)
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(75, 61)
        Me.btnAdicionar.TabIndex = 4
        Me.btnAdicionar.Tag = "agregar"
        Me.btnAdicionar.Text = "agregar"
        Me.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdicionar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(20, 166)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(625, 292)
        Me.DataGridView1.TabIndex = 3
        '
        'frmRMayorCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(1280, 625)
        Me.Name = "frmRMayorCuenta"
        Me.Tag = ""
        Me.Text = "Parametross Impresion Mayor Cuenta"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbxGrupo.ResumeLayout(False)
        Me.gbxGrupo.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNombreSucursal As Label
    Friend WithEvents txtCodSucursal_NE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents gbxGrupo As GroupBox
    Friend WithEvents txtFecha2_FE As TextBox
    Friend WithEvents txtFecha1_FE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Buscar As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnAdicionar As Button
    Friend WithEvents DataGridView1 As DataGridView
End Class
