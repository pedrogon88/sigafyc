<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBCarteraDeudoraSeguimiento
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
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(13, 13)
        Me.txtBuscar.Size = New System.Drawing.Size(1516, 27)
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(1631, 700)
        Me.btnSalir.Size = New System.Drawing.Size(128, 97)
        '
        'btnAuditoria
        '
        Me.btnAuditoria.Location = New System.Drawing.Point(1631, 595)
        Me.btnAuditoria.Size = New System.Drawing.Size(128, 97)
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(1631, 328)
        Me.btnConsultar.Size = New System.Drawing.Size(128, 97)
        '
        'btnBorrar
        '
        Me.btnBorrar.Location = New System.Drawing.Point(1631, 223)
        Me.btnBorrar.Size = New System.Drawing.Size(128, 97)
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(1631, 118)
        Me.btnModificar.Size = New System.Drawing.Size(128, 97)
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(1631, 13)
        Me.btnAgregar.Size = New System.Drawing.Size(128, 97)
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(1536, 12)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(88, 37)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.sigafyc.My.Resources.Resources.procesando1
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(538, 132)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(487, 134)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 55)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(1612, 742)
        Me.DataGridView1.TabIndex = 34
        '
        'frmBCarteraDeudoraSeguimiento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1631, 804)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmBCarteraDeudoraSeguimiento"
        Me.Tag = ""
        Me.Text = "Browse Cartera deudora seguimiento judicial"
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.btnAgregar, 0)
        Me.Controls.SetChildIndex(Me.btnModificar, 0)
        Me.Controls.SetChildIndex(Me.btnBorrar, 0)
        Me.Controls.SetChildIndex(Me.btnConsultar, 0)
        Me.Controls.SetChildIndex(Me.btnAuditoria, 0)
        Me.Controls.SetChildIndex(Me.btnSalir, 0)
        Me.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.Controls.SetChildIndex(Me.btnBuscar, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBuscar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DataGridView1 As DataGridView
End Class
