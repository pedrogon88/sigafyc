Imports System.Deployment.Application
Imports System.IO
Public Class frmMenuPrincipal
    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point
    Private Const iNivel1_ As Integer = 1
    Private Const iNivel2_ As Integer = 2
    Private Const iNivel3_ As Integer = 3
    Private Const iNivel4_ As Integer = 4
    Private Const iNivel5_ As Integer = 5


#Region "Mueve el Formulario Menu"
    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseDown ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseMove ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = New Point(Me.Location.X + (e.Location.X - MoveForm_MousePosition.X), Me.Location.Y + (e.Location.Y - MoveForm_MousePosition.Y))
        End If

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseUp ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If

    End Sub
#End Region

    Private Sub MenuPrincipal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = SesionActiva.datosControl(sRazonSocial_).ToString & " - Menu Principal | " & My.Application.Info.ProductName.ToString & " - Version:" & My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Revision.ToString

        Dim liX As Integer = Integer.Parse(GFsGetRegistry(sSesion_, "MenuPrincipal_X"))
        Dim liY As Integer = Integer.Parse(GFsGetRegistry(sSesion_, "MenuPrincipal_Y"))
        Timer1.Enabled = True

        Me.Location = New Point(liX, liY)
        Me.lblStatusUsuario.Text = sUsuario_.ToLower & ": " & SesionActiva.usuario

        Dim loFk As New Ess050usuarios
        loFk.codigo = SesionActiva.usuario
        If loFk.GetPK = sOk_ Then
            Me.lblStatusUsuario.ToolTipText = loFk.nombre
            If SesionActiva.usuario <> sManagerName_ Then
                Me.lblStatusUsuario.ToolTipText = loFk.nombre & ControlChars.CrLf & "Haga click aqui para cambiar su contraseña"
            Else
                Me.lblStatusUsuario.ToolTipText = "Administrador General del Sistema"
            End If
        End If
        loFk.CerrarConexion()
        loFk = Nothing

        Me.lblStatusEquipo.Text = "equipo: " & SesionActiva.equipo
        Me.lblStatusEquipo.ToolTipText = "HDD Serial Number: " & SesionActiva.serialHDD
        Me.lblStatusIp.Text = "ip: " & SesionActiva.ip
        Me.lblStatusIp.ToolTipText = "MAC Address: " & SesionActiva.mac
        Me.lblStatusLoginAcceso.Text = "login: " & SesionActiva.loginAcceso

        LPRecuperaArchivoMenu()
        GPBitacoraRegistrar(sENTRO_, Me.Text)
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        GPBitacoraRegistrar(sSALIO_, Me.Text)
        GPSavRegistry(sSesion_, "MenuPrincipal_X", Me.Location.X.ToString)
        GPSavRegistry(sSesion_, "MenuPrincipal_Y", Me.Location.Y.ToString)
        Me.Close()
    End Sub

    Private Sub lblStatusUsuario_Click(sender As Object, e As EventArgs) Handles lblStatusUsuario.Click
        If SesionActiva.usuario = SesionActiva.datosControl(sUsuarioSupervisor_).ToString Then
            GFsAvisar("Usuario activo es [" & SesionActiva.usuario & "]", sMENSAJE_, "No es posible cambiar su contraseña por este medio.")
            Exit Sub
        End If
        Dim loFormulario As New frmFCambioPassword
        loFormulario.Tag = sMODIFICAR_
        GPCargar(loFormulario)
        loFormulario = Nothing
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblStatusFechaHora.Text = Now.ToString(sFormatoFechaHora4_)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) 
        Dim lsClave As String = "Desarrollador sistema - sitio web"
        Dim lsValor As String = GFsParametroObtener(sGeneral_, lsClave)
        Process.Start(lsValor)
    End Sub

    Private Sub LPRecuperaArchivoMenu()
        Dim lsClave As String = ""
        lsClave = "Ubicacion - Archivo menu"
        Dim lsUbicacion As String = GFsParametroObtener(sGeneral_, lsClave)
        lsClave = "Archivo menu"
        Dim lsArchivo As String = GFsParametroObtener(sUsuario_, lsClave)
        Dim lsFileName As String = lsUbicacion & sDS_ & lsArchivo
        If Not File.Exists(lsFileName) Then
            GFsAvisar("El archivo menu [" & lsArchivo & "] no esta definido", sViolacion_, "Consulte con el Dpto. de Informatica.")
            Exit Sub
        End If

        Dim loStreamReader As StreamReader = New StreamReader(lsFileName)
        Dim loMenuAnterior As New ToolStripMenuItem
        Dim loNivel1 As New ToolStripMenuItem
        Dim loNivel2 As New ToolStripMenuItem
        Dim loNivel3 As New ToolStripMenuItem
        Dim loNivel4 As New ToolStripMenuItem
        Dim lsLinea As String = ""
        Do
            lsLinea = loStreamReader.ReadLine()
            If lsLinea Is Nothing Then Exit Do

            Dim lsOpcionMenu() As String = lsLinea.Split(sSF_)
            Select Case Val(lsOpcionMenu(0).Trim)
                Case iNivel1_
                    Dim loMenuItem As New ToolStripMenuItem
                    loMenuItem.Name = lsOpcionMenu(1)
                    loMenuItem.Size = New System.Drawing.Size(115, 25)
                    loMenuItem.Text = lsOpcionMenu(2)
                    loMenuItem.ToolTipText = lsOpcionMenu(4)
                    If lsOpcionMenu(3) = sMenu_ Then
                        loMenuAnterior = loMenuItem
                    Else
                        AddHandler loMenuItem.Click, AddressOf Menu_Click
                        AddHandler loMenuItem.MouseEnter, AddressOf Menu_Encima
                        AddHandler loMenuItem.MouseLeave, AddressOf Menu_Sale
                    End If
                    MenuStrip1.Items.Add(loMenuItem)
                    loNivel1 = loMenuItem
                Case iNivel2_
                    Dim loMenuItem As New ToolStripMenuItem
                    loMenuItem.Name = lsOpcionMenu(1)
                    loMenuItem.Size = New System.Drawing.Size(115, 25)
                    loMenuItem.Text = lsOpcionMenu(2)
                    loMenuItem.ToolTipText = lsOpcionMenu(4)
                    If lsOpcionMenu(3) = sMenu_ Then
                        loMenuAnterior = loMenuItem
                        loNivel1.DropDownItems.Add(loMenuItem)
                    Else
                        loMenuItem.AccessibleName = lsOpcionMenu(3)
                        AddHandler loMenuItem.Click, AddressOf Menu_Click
                        AddHandler loMenuItem.MouseEnter, AddressOf Menu_Encima
                        AddHandler loMenuItem.MouseLeave, AddressOf Menu_Sale
                        loMenuAnterior.DropDownItems.Add(loMenuItem)
                    End If
                    loNivel2 = loMenuItem
                Case iNivel3_
                    Dim loMenuItem As New ToolStripMenuItem
                    loMenuItem.Name = lsOpcionMenu(1)
                    loMenuItem.Size = New System.Drawing.Size(115, 25)
                    loMenuItem.Text = lsOpcionMenu(2)
                    loMenuItem.ToolTipText = lsOpcionMenu(4)
                    If lsOpcionMenu(3) = sMenu_ Then
                        loMenuAnterior = loMenuItem
                        loNivel2.DropDownItems.Add(loMenuItem)
                    Else
                        loMenuItem.AccessibleName = lsOpcionMenu(3)
                        AddHandler loMenuItem.Click, AddressOf Menu_Click
                        AddHandler loMenuItem.MouseEnter, AddressOf Menu_Encima
                        AddHandler loMenuItem.MouseLeave, AddressOf Menu_Sale
                        loMenuAnterior.DropDownItems.Add(loMenuItem)
                    End If
                    loNivel3 = loMenuItem
                Case iNivel4_
                    Dim loMenuItem As New ToolStripMenuItem
                    loMenuItem.Name = lsOpcionMenu(1)
                    loMenuItem.Size = New System.Drawing.Size(115, 25)
                    loMenuItem.Text = lsOpcionMenu(2)
                    loMenuItem.ToolTipText = lsOpcionMenu(4)
                    If lsOpcionMenu(3) = sMenu_ Then
                        loMenuAnterior = loMenuItem
                        loNivel3.DropDownItems.Add(loMenuItem)
                    Else
                        loMenuItem.AccessibleName = lsOpcionMenu(3)
                        AddHandler loMenuItem.Click, AddressOf Menu_Click
                        AddHandler loMenuItem.MouseEnter, AddressOf Menu_Encima
                        AddHandler loMenuItem.MouseLeave, AddressOf Menu_Sale
                        loMenuAnterior.DropDownItems.Add(loMenuItem)
                    End If
                    loNivel4 = loMenuItem
                Case iNivel5_
                    Dim loMenuItem As New ToolStripMenuItem
                    loMenuItem.Name = lsOpcionMenu(1)
                    loMenuItem.Size = New System.Drawing.Size(115, 25)
                    loMenuItem.Text = lsOpcionMenu(2)
                    loMenuItem.ToolTipText = lsOpcionMenu(4)
                    If lsOpcionMenu(3) = sMenu_ Then
                        loMenuAnterior = loMenuItem
                        loNivel4.DropDownItems.Add(loMenuItem)
                    Else
                        loMenuItem.AccessibleName = lsOpcionMenu(3)
                        AddHandler loMenuItem.Click, AddressOf Menu_Click
                        AddHandler loMenuItem.MouseEnter, AddressOf Menu_Encima
                        AddHandler loMenuItem.MouseLeave, AddressOf Menu_Sale
                        loMenuAnterior.DropDownItems.Add(loMenuItem)
                    End If
            End Select
        Loop
        loStreamReader.Close()
        loStreamReader = Nothing
    End Sub

    Private Sub Menu_Click(sender As Object, e As EventArgs)

        If CType(sender, ToolStripMenuItem).AccessibleName IsNot Nothing Then
            If CType(sender, ToolStripMenuItem).AccessibleName <> sRESERVADO_ Then
                Dim loFormulario As Form = CType(Reflection.Assembly.GetExecutingAssembly().CreateInstance(CType(sender, ToolStripMenuItem).AccessibleName), Form)
                GPCargar(loFormulario)
                loFormulario = Nothing
            Else
                GFsAvisar("Menu item: " & CType(sender, ToolStripMenuItem).Text.Replace("&", ""), sMENSAJE_, "Opcion aun no implementada")
            End If
        Else
            GFsAvisar("Menu item: " & CType(sender, ToolStripMenuItem).Text.Replace("&", ""), sMENSAJE_, "Opcion aun no implementada")
        End If
    End Sub

    Private Sub Menu_Encima(sender As Object, e As EventArgs)
        lblDescripcionMenu.Text = CType(sender, ToolStripMenuItem).ToolTipText
    End Sub
    Private Sub Menu_Sale(sender As Object, e As EventArgs)
        lblDescripcionMenu.Text = ""
    End Sub

End Class