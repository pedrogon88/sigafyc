<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcesamiento
    Inherits System.Windows.Forms.Form

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
        Me.gbxLeidos = New System.Windows.Forms.GroupBox()
        Me.lblRegistroLeido = New System.Windows.Forms.TextBox()
        Me.gbxProcesados = New System.Windows.Forms.GroupBox()
        Me.lblRegistroProcesado = New System.Windows.Forms.TextBox()
        Me.lblTitulo = New System.Windows.Forms.TextBox()
        Me.gbxLeidos.SuspendLayout()
        Me.gbxProcesados.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxLeidos
        '
        Me.gbxLeidos.Controls.Add(Me.lblRegistroLeido)
        Me.gbxLeidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxLeidos.Location = New System.Drawing.Point(16, 66)
        Me.gbxLeidos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbxLeidos.Name = "gbxLeidos"
        Me.gbxLeidos.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbxLeidos.Size = New System.Drawing.Size(991, 64)
        Me.gbxLeidos.TabIndex = 1
        Me.gbxLeidos.TabStop = False
        Me.gbxLeidos.Text = "registro leido"
        '
        'lblRegistroLeido
        '
        Me.lblRegistroLeido.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblRegistroLeido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistroLeido.Location = New System.Drawing.Point(9, 23)
        Me.lblRegistroLeido.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblRegistroLeido.Name = "lblRegistroLeido"
        Me.lblRegistroLeido.ReadOnly = True
        Me.lblRegistroLeido.Size = New System.Drawing.Size(971, 22)
        Me.lblRegistroLeido.TabIndex = 5
        Me.lblRegistroLeido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gbxProcesados
        '
        Me.gbxProcesados.Controls.Add(Me.lblRegistroProcesado)
        Me.gbxProcesados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxProcesados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxProcesados.Location = New System.Drawing.Point(16, 138)
        Me.gbxProcesados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbxProcesados.Name = "gbxProcesados"
        Me.gbxProcesados.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.gbxProcesados.Size = New System.Drawing.Size(991, 64)
        Me.gbxProcesados.TabIndex = 2
        Me.gbxProcesados.TabStop = False
        Me.gbxProcesados.Text = "regiro procsado"
        '
        'lblRegistroProcesado
        '
        Me.lblRegistroProcesado.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblRegistroProcesado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistroProcesado.Location = New System.Drawing.Point(8, 23)
        Me.lblRegistroProcesado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblRegistroProcesado.Name = "lblRegistroProcesado"
        Me.lblRegistroProcesado.ReadOnly = True
        Me.lblRegistroProcesado.Size = New System.Drawing.Size(971, 22)
        Me.lblRegistroProcesado.TabIndex = 5
        Me.lblRegistroProcesado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTitulo
        '
        Me.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(16, 15)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.ReadOnly = True
        Me.lblTitulo.Size = New System.Drawing.Size(991, 23)
        Me.lblTitulo.TabIndex = 3
        Me.lblTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmProcesamiento
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1023, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.gbxProcesados)
        Me.Controls.Add(Me.gbxLeidos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmProcesamiento"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.gbxLeidos.ResumeLayout(False)
        Me.gbxLeidos.PerformLayout()
        Me.gbxProcesados.ResumeLayout(False)
        Me.gbxProcesados.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbxLeidos As GroupBox
    Friend WithEvents gbxProcesados As GroupBox
    Friend WithEvents lblRegistroLeido As TextBox
    Friend WithEvents lblRegistroProcesado As TextBox
    Friend WithEvents lblTitulo As TextBox
End Class
