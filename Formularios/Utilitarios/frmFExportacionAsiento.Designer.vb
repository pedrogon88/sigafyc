<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFExportacionAsiento : Inherits frmFormulario

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
        Me.gbxGrupo = New System.Windows.Forms.GroupBox()
        Me.txtAsiento2_NE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAsiento1_NE = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombreEmpresa = New System.Windows.Forms.Label()
        Me.txtCodEmpresa_NE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbxGrupo2 = New System.Windows.Forms.GroupBox()
        Me.txtFecha2_FE = New System.Windows.Forms.TextBox()
        Me.txtFecha1_FE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNombreSucursal = New System.Windows.Forms.Label()
        Me.txtCodSucursal_NE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbxGrupo.SuspendLayout()
        Me.gbxGrupo2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(16, 12)
        Me.TabControl1.Size = New System.Drawing.Size(678, 334)
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.lblNombreSucursal)
        Me.TabPage1.Controls.Add(Me.txtCodSucursal_NE)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.gbxGrupo2)
        Me.TabPage1.Controls.Add(Me.gbxGrupo)
        Me.TabPage1.Controls.Add(Me.lblNombreEmpresa)
        Me.TabPage1.Controls.Add(Me.txtCodEmpresa_NE)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Size = New System.Drawing.Size(670, 294)
        Me.TabPage1.Text = "Parametro"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(20, 348)
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(557, 348)
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(16, 9)
        Me.lblMensaje.Size = New System.Drawing.Size(670, 37)
        '
        'gbxGrupo
        '
        Me.gbxGrupo.Controls.Add(Me.txtAsiento2_NE)
        Me.gbxGrupo.Controls.Add(Me.Label2)
        Me.gbxGrupo.Controls.Add(Me.txtAsiento1_NE)
        Me.gbxGrupo.Controls.Add(Me.Label1)
        Me.gbxGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxGrupo.Location = New System.Drawing.Point(22, 199)
        Me.gbxGrupo.Name = "gbxGrupo"
        Me.gbxGrupo.Size = New System.Drawing.Size(617, 68)
        Me.gbxGrupo.TabIndex = 3
        Me.gbxGrupo.TabStop = False
        Me.gbxGrupo.Text = "rango numero de asientos"
        '
        'txtAsiento2_NE
        '
        Me.txtAsiento2_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAsiento2_NE.Location = New System.Drawing.Point(422, 28)
        Me.txtAsiento2_NE.Name = "txtAsiento2_NE"
        Me.txtAsiento2_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtAsiento2_NE.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(325, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 24)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Hasta:"
        '
        'txtAsiento1_NE
        '
        Me.txtAsiento1_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAsiento1_NE.Location = New System.Drawing.Point(182, 28)
        Me.txtAsiento1_NE.Name = "txtAsiento1_NE"
        Me.txtAsiento1_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtAsiento1_NE.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(85, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 24)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Desde:"
        '
        'lblNombreEmpresa
        '
        Me.lblNombreEmpresa.AutoSize = True
        Me.lblNombreEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpresa.Location = New System.Drawing.Point(246, 21)
        Me.lblNombreEmpresa.Name = "lblNombreEmpresa"
        Me.lblNombreEmpresa.Size = New System.Drawing.Size(233, 24)
        Me.lblNombreEmpresa.TabIndex = 70
        Me.lblNombreEmpresa.Text = "<nombre_de_empresa>"
        '
        'txtCodEmpresa_NE
        '
        Me.txtCodEmpresa_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmpresa_NE.Location = New System.Drawing.Point(115, 19)
        Me.txtCodEmpresa_NE.Name = "txtCodEmpresa_NE"
        Me.txtCodEmpresa_NE.Size = New System.Drawing.Size(115, 29)
        Me.txtCodEmpresa_NE.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 24)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Empresa:"
        '
        'gbxGrupo2
        '
        Me.gbxGrupo2.Controls.Add(Me.txtFecha2_FE)
        Me.gbxGrupo2.Controls.Add(Me.txtFecha1_FE)
        Me.gbxGrupo2.Controls.Add(Me.Label8)
        Me.gbxGrupo2.Controls.Add(Me.Label7)
        Me.gbxGrupo2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gbxGrupo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxGrupo2.Location = New System.Drawing.Point(22, 112)
        Me.gbxGrupo2.Name = "gbxGrupo2"
        Me.gbxGrupo2.Size = New System.Drawing.Size(617, 68)
        Me.gbxGrupo2.TabIndex = 2
        Me.gbxGrupo2.TabStop = False
        Me.gbxGrupo2.Text = "rango de fecha"
        '
        'txtFecha2_FE
        '
        Me.txtFecha2_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha2_FE.Location = New System.Drawing.Point(399, 25)
        Me.txtFecha2_FE.Name = "txtFecha2_FE"
        Me.txtFecha2_FE.Size = New System.Drawing.Size(162, 26)
        Me.txtFecha2_FE.TabIndex = 1
        '
        'txtFecha1_FE
        '
        Me.txtFecha1_FE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha1_FE.Location = New System.Drawing.Point(131, 25)
        Me.txtFecha1_FE.Name = "txtFecha1_FE"
        Me.txtFecha1_FE.Size = New System.Drawing.Size(162, 26)
        Me.txtFecha1_FE.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(331, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 20)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Hasta:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(55, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 20)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Desde:"
        '
        'lblNombreSucursal
        '
        Me.lblNombreSucursal.AutoSize = True
        Me.lblNombreSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreSucursal.Location = New System.Drawing.Point(246, 71)
        Me.lblNombreSucursal.Name = "lblNombreSucursal"
        Me.lblNombreSucursal.Size = New System.Drawing.Size(195, 24)
        Me.lblNombreSucursal.TabIndex = 97
        Me.lblNombreSucursal.Text = "<nombre_sucursal>"
        '
        'txtCodSucursal_NE
        '
        Me.txtCodSucursal_NE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodSucursal_NE.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodSucursal_NE.Location = New System.Drawing.Point(115, 66)
        Me.txtCodSucursal_NE.Name = "txtCodSucursal_NE"
        Me.txtCodSucursal_NE.Size = New System.Drawing.Size(74, 29)
        Me.txtCodSucursal_NE.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Sucursal:"
        '
        'frmFExportacionAsiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Nothing
        Me.ClientSize = New System.Drawing.Size(710, 439)
        Me.Name = "frmFExportacionAsiento"
        Me.Tag = ""
        Me.Text = "Parametros Exportacion Asiento Diario"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbxGrupo.ResumeLayout(False)
        Me.gbxGrupo.PerformLayout()
        Me.gbxGrupo2.ResumeLayout(False)
        Me.gbxGrupo2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbxGrupo As GroupBox
    Friend WithEvents txtAsiento2_NE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAsiento1_NE As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNombreEmpresa As Label
    Friend WithEvents txtCodEmpresa_NE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents gbxGrupo2 As GroupBox
    Friend WithEvents txtFecha2_FE As TextBox
    Friend WithEvents txtFecha1_FE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblNombreSucursal As Label
    Friend WithEvents txtCodSucursal_NE As TextBox
    Friend WithEvents Label3 As Label
End Class
