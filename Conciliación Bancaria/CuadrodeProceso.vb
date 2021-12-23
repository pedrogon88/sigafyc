Public Class CuadrodeProceso
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pic_Progreso As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_Mensaje As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CuadrodeProceso))
        Me.lbl_Mensaje = New System.Windows.Forms.Label()
        Me.pic_Progreso = New System.Windows.Forms.PictureBox()
        CType(Me.pic_Progreso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Mensaje
        '
        Me.lbl_Mensaje.Location = New System.Drawing.Point(0, 0)
        Me.lbl_Mensaje.Name = "lbl_Mensaje"
        Me.lbl_Mensaje.Size = New System.Drawing.Size(178, 72)
        Me.lbl_Mensaje.TabIndex = 0
        Me.lbl_Mensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pic_Progreso
        '
        Me.pic_Progreso.Image = CType(resources.GetObject("pic_Progreso.Image"), System.Drawing.Image)
        Me.pic_Progreso.Location = New System.Drawing.Point(8, 80)
        Me.pic_Progreso.Name = "pic_Progreso"
        Me.pic_Progreso.Size = New System.Drawing.Size(160, 8)
        Me.pic_Progreso.TabIndex = 1
        Me.pic_Progreso.TabStop = False
        '
        'CuadrodeProceso
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(178, 95)
        Me.ControlBox = False
        Me.Controls.Add(Me.pic_Progreso)
        Me.Controls.Add(Me.lbl_Mensaje)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "CuadrodeProceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procesando..."
        Me.TopMost = True
        CType(Me.pic_Progreso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Sobrecarga del Método Show"
    Public Overloads Sub Show(ByVal Message As String)
        Try
            lbl_Mensaje.Text = Message
            Me.Show()
            Application.DoEvents()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
#End Region

    Private Sub CuadrodeProceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
