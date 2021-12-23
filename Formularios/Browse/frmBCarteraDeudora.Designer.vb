<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBCarteraDeudora
    Inherits frmBrowseSinGrid

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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblMarcaModelo = New System.Windows.Forms.Label()
        Me.txtStock_AN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(13, 57)
        Me.txtBuscar.Size = New System.Drawing.Size(1433, 27)
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(1454, 700)
        '
        'btnAuditoria
        '
        Me.btnAuditoria.Location = New System.Drawing.Point(1454, 593)
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(1454, 378)
        '
        'btnBorrar
        '
        Me.btnBorrar.Location = New System.Drawing.Point(1454, 271)
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(1454, 164)
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(1454, 56)
        '
        'DataGridView1
        '
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView1.Location = New System.Drawing.Point(13, 92)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1433, 708)
        Me.DataGridView1.TabIndex = 25
        '
        'lblMarcaModelo
        '
        Me.lblMarcaModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarcaModelo.Location = New System.Drawing.Point(505, 17)
        Me.lblMarcaModelo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMarcaModelo.Name = "lblMarcaModelo"
        Me.lblMarcaModelo.Size = New System.Drawing.Size(941, 30)
        Me.lblMarcaModelo.TabIndex = 30
        Me.lblMarcaModelo.Text = "<marca-modelo>"
        '
        'txtStock_AN
        '
        Me.txtStock_AN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStock_AN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStock_AN.Location = New System.Drawing.Point(184, 15)
        Me.txtStock_AN.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStock_AN.Name = "txtStock_AN"
        Me.txtStock_AN.Size = New System.Drawing.Size(313, 34)
        Me.txtStock_AN.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 29)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Codigo Stock:"
        '
        'btnDetalle
        '
        Me.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetalle.Image = Global.sigafyc.My.Resources.Resources.icons8_details_32
        Me.btnDetalle.Location = New System.Drawing.Point(1454, 485)
        Me.btnDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(115, 100)
        Me.btnDetalle.TabIndex = 31
        Me.btnDetalle.Tag = "&detalle"
        Me.btnDetalle.Text = "&detalle"
        Me.btnDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDetalle.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.sigafyc.My.Resources.Resources.procesando1
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(459, 164)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(487, 134)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        '
        'frmBCarteraDeudora
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1582, 805)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnDetalle)
        Me.Controls.Add(Me.lblMarcaModelo)
        Me.Controls.Add(Me.txtStock_AN)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmBCarteraDeudora"
        Me.Tag = "SobreCargado"
        Me.Text = "Browse Cartera Deudora - Para seguimiento"
        Me.Controls.SetChildIndex(Me.btnAgregar, 0)
        Me.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.Controls.SetChildIndex(Me.btnBorrar, 0)
        Me.Controls.SetChildIndex(Me.btnConsultar, 0)
        Me.Controls.SetChildIndex(Me.btnAuditoria, 0)
        Me.Controls.SetChildIndex(Me.btnSalir, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.txtStock_AN, 0)
        Me.Controls.SetChildIndex(Me.lblMarcaModelo, 0)
        Me.Controls.SetChildIndex(Me.btnDetalle, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblMarcaModelo As Label
    Friend WithEvents txtStock_AN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDetalle As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
