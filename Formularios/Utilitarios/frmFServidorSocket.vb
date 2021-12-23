Imports System.Net
Imports System.Net.Sockets
Imports System.Threading

Public Class frmFServidorSocket
    Private moTCPServer As Socket
    Private moTCPListener As TcpListener
    Private moContador As Integer = 0
    Private msZohoId As String = ""
    Private msModulo As String = ""
    Private loProcesoCabecera As Thread = Nothing

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timer1.Tick
        Dim lsPrefijoMSG As String = "TIMBO<--"
        Try
            Dim loRcvbytes(moTCPServer.ReceiveBufferSize) As Byte
            moTCPServer.Receive(loRcvbytes)
            TextBox2.Text = System.Text.Encoding.ASCII.GetString(loRcvbytes)
            Dim lsParametros() As String = TextBox2.Text.Split("|"c)
            Dim lsModulo() As String = lsParametros(0).Split(":"c)
            Dim lsAccion() As String = lsModulo(1).Split("-"c)
            Select Case lsAccion(0)
                Case "Accounts"
                    Dim lsZohoId() As String = lsParametros(1).Split(":"c)
                    Dim lsNombre() As String = lsParametros(2).Split(":"c)
                    Select Case lsAccion(1)
                        Case "OCRD"
                            TextBox2.Text = "Modulo:" & lsAccion(0) & ", Accion:" & lsAccion(1) & " / Nombre:" & lsNombre(1) & ", Zoho Id:" & lsZohoId(1)
                            GPBitacoraRegistrar(sWDATA_, TextBox2.Text)
                            msZohoId = lsZohoId(1)
                            msModulo = lsAccion(0)
                            Dim loIntegracion As Thread = New Thread(AddressOf LPIntegracionZoho_SAP_OCRD)
                            loIntegracion.Name = sZIS_ZOHOsap_ & "_" & msModulo & "_" & lsAccion(1)
                            loIntegracion.IsBackground = True
                            loIntegracion.Start()
                            Me.Refresh()
                            MultiThread.Agregar(loIntegracion)
                    End Select
                Case "Colaboradores"
                    Dim lsNombre() As String = lsParametros(1).Split(":"c)
                    Dim lsCI() As String = lsParametros(2).Split(":"c)
                    Select Case lsAccion(1)
                        Case "ADD"
                            TextBox2.Text = "Modulo:" & lsAccion(0) & ", Accion:" & lsAccion(1) & " / Nombre:" & lsNombre(1) & ", CI:" & lsCI(1)
                            GPBitacoraRegistrar(sWDATA_, TextBox2.Text)
                    End Select
                Case "Contacts"
                    Dim lsZohoId() As String = lsParametros(1).Split(":"c)
                    Dim lsNombre() As String = lsParametros(2).Split(":"c)
                    Select Case lsAccion(1)
                        Case "OCRD"
                            TextBox2.Text = "Modulo:" & lsAccion(0) & ", Accion:" & lsAccion(1) & " / Nombre:" & lsNombre(1) & ", Zoho Id:" & lsZohoId(1)
                            GPBitacoraRegistrar(sWDATA_, TextBox2.Text)
                            msZohoId = lsZohoId(1)
                            msModulo = lsAccion(0)
                            Dim loIntegracion As Thread = New Thread(AddressOf LPIntegracionZoho_SAP_OCRD)
                            loIntegracion.Name = sZIS_ZOHOsap_ & "_" & msModulo & "_" & lsAccion(1)
                            loIntegracion.IsBackground = True
                            loIntegracion.Start()
                            Me.Refresh()
                            MultiThread.Agregar(loIntegracion)
                        Case "OCPR"
                            TextBox2.Text = "Modulo:" & lsAccion(0) & ", Accion:" & lsAccion(1) & " / Nombre:" & lsNombre(1) & ", Zoho Id:" & lsZohoId(1)
                            GPBitacoraRegistrar(sWDATA_, TextBox2.Text)
                            msZohoId = lsZohoId(1)
                            msModulo = lsNombre(1)
                            Me.Refresh()
                            Dim loIntegracion As Thread = New Thread(AddressOf LPIntegracionZoho_SAP_OCPR)
                            loIntegracion.Name = sZIS_ZOHOsap_ & "_" & msModulo & "_" & lsAccion(1)
                            loIntegracion.IsBackground = True
                            loIntegracion.Start()
                            Me.Refresh()
                            MultiThread.Agregar(loIntegracion)
                    End Select
                Case "SalesOrders"
                    Dim lsZohoId() As String = lsParametros(1).Split(":"c)
                    TextBox2.Text = "Modulo:" & lsAccion(0) & ", Tabla:" & lsAccion(1) & " / Zoho Id:" & lsZohoId(1)
                    GPBitacoraRegistrar(sWDATA_, TextBox2.Text)
                    msZohoId = lsZohoId(1)
                    Me.Refresh()
                    Dim loIntegracion As Thread = New Thread(AddressOf LPIntegracionZoho_SAP_ORDR)
                    loIntegracion.Name = sZIS_ZOHOsap_ & "_" & msModulo & "_ZohoId" & msZohoId
                    loIntegracion.IsBackground = True
                    loIntegracion.Start()
                    Me.Refresh()
                    MultiThread.Agregar(loIntegracion)

                Case "SALIR"
                    Dim lsPassword() As String = lsParametros(1).Split(":"c)
                    Dim lsPasswordCorrecto As String = GFsParametroObtener(sGeneral_, "Servidor Socket - password")
                    If lsPassword(1).Substring(0, sPasswordSalir_.Length) = lsPasswordCorrecto Then
                        GPBitacoraRegistrar(sMENSAJE_, "Servidor Socket --> Cerrado normal!")
                        Me.Close()
                    Else
                        TextBox2.Text = "Accion: " & lsAccion(0) & ", " & sNOAUTORIZADO_
                    End If
                    GPSavRegistry(sSesion_, sServSocketFinal_, Now.ToString(sFormatoFechaHora1_))

            End Select
            Me.Refresh()
            If TextBox2.Text.Length > 0 Then
                TextBox1.Text = lsPrefijoMSG & TextBox2.Text
                Me.Refresh()
                Dim loSendbytes() As Byte = System.Text.Encoding.ASCII.GetBytes(TextBox1.Text)
                moTCPServer.Send(loSendbytes)
                moTCPServer.Shutdown(SocketShutdown.Send)
                moTCPServer.Close()
                moTCPListener.Start()
                moTCPServer = moTCPListener.AcceptSocket
                moTCPServer.Blocking = False
            End If
        Catch ex As SocketException
            Button1.BackColor = Drawing.Color.LightSeaGreen
            Button1.Text = "Servidor RE-ACTIVADO!!"
            Button1.Enabled = False
            Me.Refresh()

            moTCPListener = Nothing
            moTCPListener = New TcpListener(IPAddress.Any, 9777)
            moTCPListener.Start()
            moTCPServer = moTCPListener.AcceptSocket
            moTCPServer.Blocking = False
            ProgressBar1.Visible = True
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = 100
            Timer1.Enabled = True
            GPBitacoraRegistrar(sMENSAJE_, "Servidor Socket --> Re-Activado!")
            Me.Refresh()
        End Try

        If ProgressBar1.Value <= ProgressBar1.Maximum - 1 Then
            ProgressBar1.Value += 5
        Else
            ProgressBar1.Value = 0
        End If
        Me.Refresh()
    End Sub

    Private Sub frmFServerSide_Load(sender As Object, e As EventArgs) Handles Me.Load
        If GFsGetRegistry(sSesion_, sServSocketFinal_) = sRESERVADO_ Then
            MsgBox("Ya existe una instancia del Servidor Socker ejecutandose...",, "Mensaje del Sistema")
            Me.Close()
        End If
        CheckForIllegalCrossThreadCalls = False
        ProgressBar1.Visible = False
        Button1.Enabled = True
        GPSavRegistry(sSesion_, sServSocketInicio_, Now.ToString(sFormatoFechaHora1_))
        GPSavRegistry(sSesion_, sServSocketFinal_, sRESERVADO_)
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GPBitacoraRegistrar(sMENSAJE_, "Servidor Socket --> Activacion!")
        Button1.BackColor = Drawing.Color.LightGreen
        Button1.Text = "Servidor ACTIVO!!"
        Button1.Enabled = False
        Me.Refresh()
        moTCPListener = New TcpListener(IPAddress.Any, 9777)
        moTCPListener.Start()

        moTCPServer = moTCPListener.AcceptSocket
        moTCPServer.Blocking = False

        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        ProgressBar1.Maximum = 100
        Timer1.Enabled = True
        Me.Refresh()
    End Sub

    Private Sub LPIntegracionZoho_SAP_OCRD()
        GPIntegracionZoho_SAP_OCRD(msZohoId, msModulo)
    End Sub

    Private Sub LPIntegracionZoho_SAP_OCPR()
        GPIntegracionZoho_SAP_OCPR(msZohoId, 0)
    End Sub

    Private Sub LPIntegracionZoho_SAP_ORDR()
        GPIntegracionZoho_SAP_ORDR(msZohoId)
    End Sub
End Class