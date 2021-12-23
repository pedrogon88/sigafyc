Imports System.Data.Common
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Management
Imports System.Threading

Public Class SesionActiva
    Private Const sTiposRed_ As String = "Ethernet" & sSF_ & "Wi-Fi"

    Shared mbLoggeado As Boolean = False
    Shared mbCargado As Boolean = False
    Shared msSessionId As String = ""
    Shared msSerialHDD As String = ""
    Shared msSistema As String = ""
    Shared msIp As String = ""
    Shared msMac As String = ""
    Shared msUsuario As String = ""
    Shared msNombreUsuario As String = ""
    Shared msLoginAcceso As String = ""
    Shared msEquipo As String = ""
    Shared moLogRegistro As New ArrayList
    Shared moDatosControl As New Hashtable
    Shared moPuedeUsar As New Hashtable
    Shared moEjercicios As New Hashtable
    Shared msResetPassword As String = ""
    Shared moListThread As List(Of Thread) = Nothing

    Public Shared ReadOnly Property sessionId As String
        Get
            Return msSessionId.ToUpper
        End Get
    End Property

    Public Shared ReadOnly Property serialHDD As String
        Get
            Return msSerialHDD.ToUpper
        End Get
    End Property

    Public Shared ReadOnly Property sistema As String
        Get
            Return msSistema.ToUpper
        End Get
    End Property

    Public Shared ReadOnly Property ip As String
        Get
            Return msIp
        End Get
    End Property

    Public Shared Property usuario As String
        Get
            Return msUsuario.ToUpper
        End Get
        Set(value As String)
            msUsuario = value '.Substring(0, 15)
        End Set
    End Property

    Public Property nombreUsuario As String
        Get
            Return msNombreUsuario.ToUpper
        End Get
        Set(value As String)
            msNombreUsuario = value
        End Set
    End Property

    Public Shared Property loginAcceso As String
        Get
            Return msLoginAcceso.ToUpper
        End Get
        Set(value As String)
            msLoginAcceso = value
        End Set
    End Property

    Public Shared ReadOnly Property equipo As String
        Get
            Return msEquipo.ToUpper
        End Get
    End Property

    Public Shared ReadOnly Property mac As String
        Get
            Return msMac.ToUpper
        End Get
    End Property

    Public Shared ReadOnly Property logRegistro As ArrayList
        Get
            Return moLogRegistro
        End Get
    End Property

    Public Shared ReadOnly Property datosControl As Hashtable
        Get
            Return moDatosControl
        End Get
    End Property

    Public Shared Property loggeado As Boolean
        Get
            Return mbLoggeado
        End Get
        Set(value As Boolean)
            mbLoggeado = value
        End Set
    End Property

    Public Shared Property resetPassword As String
        Get
            Return msResetPassword
        End Get
        Set(value As String)
            msResetPassword = value
        End Set
    End Property

    Public Shared Property listThread As List(Of Thread)
        Get
            Return moListThread
        End Get
        Set(value As List(Of Thread))
            moListThread = value
        End Set
    End Property

    Public Sub CargaParametros()
        If mbCargado = False Then
            mbCargado = True
            msSistema = My.Application.Info.AssemblyName.ToUpper
            msEquipo = LFsObtenerHostName()
            msLoginAcceso = My.Application.GetEnvironmentVariable("USERNAME").ToUpper
            msIp = LFsObtenerIP()
            msMac = LFsObtenerMAC()
            msSerialHDD = LFsObtenerHDDSerial()
            msResetPassword = GFsGetRegistry(sSeguridad_, sPasswordReset_)

            LPInicializaRegistry()

            If msUsuario.Trim.Length = 0 Then msUsuario = msLoginAcceso
            msSessionId = GFsSHA256(msSistema & msUsuario & msLoginAcceso & msIp & msEquipo & Now.ToString("yyyyMMddHHmmssfff"))
            If GFsGetRegistry(sSeguridad_, sArchivoControlCrear_) = sManagerPassword_ Then
                Dim loDControl As New ArchivoControl
                loDControl.Genera()
                loDControl = Nothing
            End If
            GPSavRegistry(sSeguridad_, sArchivoControlCrear_, sRESERVADO_)

            Dim loDatosControl As New ArchivoControl
            moDatosControl = loDatosControl.Recupera
            loDatosControl = Nothing
        End If
    End Sub

    Public Function VerificaControl() As String
        Dim lsFooter As String = ControlChars.CrLf & ControlChars.CrLf & "Esto impedira su acceso al sistema, " & ControlChars.CrLf & "favor Consulte con el Dpto. de Informatica."
        Dim lsResultado As String = sOk_
        If msSerialHDD <> moDatosControl(sSerialHDD_).ToString Then
            lsResultado = sViolacion_ & sSF_ & "El serial del disco [" & msSerialHDD & "],  no corresponde con el autorizado" & lsFooter
        Else
            If Now.ToString(sFormatoFechaHora1_) < moDatosControl(sUltimoAcceso_).ToString Then
                lsResultado = sViolacion_ & sSF_ & "Ha sido modificada la fecha u hora del sistema" & lsFooter
            Else
                If Now.ToString(sFormatoFecha1_) > moDatosControl(sFechaExpiracion_).ToString Then
                    lsResultado = sViolacion_ & sSF_ & "El sistema tenia fecha expiración [" & moDatosControl(sFechaExpiracion_).ToString & "]" & lsFooter
                Else
                    GPActualizaUltimoAcceso()
                End If
            End If
        End If
        Return lsResultado
    End Function

    Public Function VerificaControl2() As String
        Dim lsFooter As String = ControlChars.CrLf & ControlChars.CrLf & "Esto impedira su acceso al sistema, " & ControlChars.CrLf & "favor Consulte con el Dpto. de Informatica."
        Dim lsResultado As String = sOk_
        If Now.ToString(sFormatoFechaHora1_) < moDatosControl(sUltimoAcceso_).ToString Then
            lsResultado = sViolacion_ & sSF_ & "Ha sido modificada la fecha u hora del sistema" & lsFooter
        Else
            If Now.ToString(sFormatoFecha1_) > moDatosControl(sFechaExpiracion_).ToString Then
                lsResultado = sViolacion_ & sSF_ & "El sistema tenia fecha expiración [" & moDatosControl(sFechaExpiracion_).ToString & "]" & lsFooter
            Else
                GPActualizaUltimoAcceso()
            End If
        End If
        Return lsResultado
    End Function

    Private Sub LPInicializaRegistry()
        If GFsGetRegistry(sEncriptacion_, sSetupSalt_) = sRESERVADO_ Then
            GPSavRegistry(sEncriptacion_, sSetupSalt_, sSaltDefault_)
        End If
        If GFsGetRegistry(sEncriptacion_, sResetPassword_) = sRESERVADO_ Then
            GPSavRegistry(sEncriptacion_, sResetPassword_, sManagerPassword_)
        End If
    End Sub

    Public Shared Sub AgregarLogRegistro(ByVal mensaje As String)
        If mensaje.Trim.Length = 0 Then Exit Sub
        moLogRegistro.Add(mensaje)
    End Sub

    Shared Function AutorizadoResetear(ByVal psRama As String, ByVal psClave As String, ByVal psValor As String) As String
        Dim lsResultado As String = sNo_
        Dim lsValor1 As String = GFsGetRegistry(sEncriptacion_, sResetPassword_)
        Dim lsValor2 As String = SesionActiva.resetPassword
        If lsValor1 = lsValor2 Then
            lsResultado = sSi_
        Else
            GPSavRegistry(psRama, psClave, sNOAUTORIZADO_)
        End If
        Return lsResultado
    End Function

    Public Shared Sub LimpiarLogRegistro()
        moLogRegistro.Clear()
    End Sub

    Private Function LFsObtenerHostName() As String
        Return Dns.GetHostName
    End Function

    Private Function LFsObtenerIP() As String
        Dim lsHostName = Dns.GetHostName
        Dim lsIP, lsGateway, lsDNS1, lsDNS2 As String
        lsIP = ""
        lsGateway = ""
        lsDNS1 = ""
        lsDNS2 = ""
        For Each loIp In System.Net.Dns.GetHostEntry(lsHostName).AddressList
            If loIp.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                'IPv4 Adress
                lsIP = loIp.ToString

                For Each adapter As NetworkInterface In Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                    For Each unicastIPAddressInformation As Net.NetworkInformation.UnicastIPAddressInformation In adapter.GetIPProperties().UnicastAddresses
                        If unicastIPAddressInformation.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                            If ip.Equals(unicastIPAddressInformation.Address) Then
                                'Subnet Mask
                                Dim adapterProperties As Net.NetworkInformation.IPInterfaceProperties = adapter.GetIPProperties()
                                For Each gateway As Net.NetworkInformation.GatewayIPAddressInformation In adapterProperties.GatewayAddresses
                                    'Default Gateway
                                    lsGateway = gateway.Address.ToString()
                                Next

                                'DNS1
                                If adapterProperties.DnsAddresses.Count > 0 Then
                                    lsDNS1 = adapterProperties.DnsAddresses(0).ToString()
                                End If
                            End If
                        End If
                    Next
                Next
            End If
            If lsGateway.Trim.Length > 0 And lsDNS1.Trim.Length > 0 Then
                If lsGateway = lsDNS1 Then
                    Exit For
                End If
            End If
        Next
        Return lsIP
    End Function

    Private Function LFsObtenerMAC() As String
        Dim lsResultado As String = ""
        For Each loRed As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces
            If loRed.OperationalStatus = OperationalStatus.Up Then
                If InStr(sTiposRed_, loRed.Name) > 0 Then
                    lsResultado = loRed.GetPhysicalAddress.ToString
                    Exit For
                End If
            End If
        Next
        Return lsResultado
    End Function

    Private Function LFsObtenerHDDSerial() As String
        Dim lsResultado As String = ""
        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
        For Each wmi_HD As ManagementObject In searcher.Get()
            If InStr(wmi_HD("DeviceId").ToString, "PHYSICALDRIVE0") > 0 Then
                lsResultado = wmi_HD("SerialNumber").ToString.Trim
                Exit For
            End If
        Next wmi_HD
        Return lsResultado
    End Function

    Shared Function ControlaReloj() As String
        Dim lsResultado As String = ""
        Dim lsFechaHora As String = Now.ToString(sFormatoFechaHora1_)
        Dim lsUltimoAcceso As String = ""

        lsUltimoAcceso = datosControl(sUltimoAcceso_).ToString
        If lsFechaHora < lsUltimoAcceso Then
            lsResultado = "Ha sido modificada la fecha u hora del sistema, Fecha/hora actual [" & lsFechaHora & "]"
        Else
            moDatosControl(sUltimoAcceso_) = lsFechaHora
        End If
        Return lsResultado
    End Function

    Shared Sub ActualizaDatosControl(ByVal psClave As String, ByVal psValor As String)
        moDatosControl(psClave) = psValor
    End Sub

    Public Sub EnviarBitacoraCorreo(ByVal psFileName As String, ByVal psArchivoBitacora As String)
        Dim lsEnviarMail As String = GFsParametroObtener(sUsuario_, "Enviar bitacora de proceso")
        lsEnviarMail = lsEnviarMail.Replace(ControlChars.CrLf, "")
        If lsEnviarMail.Trim = sRESERVADO_ Then
            lsEnviarMail = sSi_
            GPParametroGuardar(sUsuario_, "Enviar bitacora de proceso", lsEnviarMail)
        End If
        If lsEnviarMail = sNo_ Then Exit Sub

        Dim loAdjuntos As New ArrayList
        Dim loCorreo As Correo

        ' Envia la Bitacora de la sesion en curso que se esta cerrando
        loCorreo = New Correo
        loCorreo.asunto = SesionActiva.datosControl("RazonSocial").ToString & " - Bitacora proceso - " & SesionActiva.sistema & " - " & SesionActiva.usuario & " - " & SesionActiva.ip
        loCorreo.body = "Bitacora de Procesos - " & Now.ToString(sFormatoFechaHora1_) & ControlChars.CrLf

        loAdjuntos.Clear()
        loAdjuntos.Add(psFileName & sSF_ & psArchivoBitacora)
        loCorreo.archivosAdjuntos = loAdjuntos
        Try
            loCorreo.Enviar(sNo_)
        Catch ex As Exception
            MessageBox.Show("Envio de Bitacora" & ControlChars.CrLf & loCorreo.asunto & ControlChars.CrLf & "Archivo bitacora: " & psFileName & ControlChars.CrLf & "Error durante envio de mail " & ex.Message)
        End Try
        loCorreo = Nothing

        ' Envia las Bitacoras que no pudieron enviarse 
        loCorreo = New Correo
        loCorreo.asunto = SesionActiva.datosControl("RazonSocial").ToString & " - Bitacora proceso - " & SesionActiva.sistema & " - " & SesionActiva.usuario & " - " & SesionActiva.ip
        loCorreo.body = "Bitacora de Procesos (*** NO ENVIADAS ****) - " & Now.ToString(sFormatoFechaHora1_) & ControlChars.CrLf

        loAdjuntos.Clear()
        loCorreo.archivosAdjuntos = LFoBitacorasNoEnviadas()
        Try
            If loCorreo.archivosAdjuntos.Count > 0 Then
                loCorreo.Enviar(sNo_)
            End If
        Catch ex As Exception
            MessageBox.Show("Envio de Bitacora" & ControlChars.CrLf & loCorreo.asunto & ControlChars.CrLf & "Archivo bitacora no enviadas" & ControlChars.CrLf & "Error durante envio de mail " & ex.Message)
        End Try
        loCorreo = Nothing

    End Sub

    Shared Sub ListThread_Agregar(ByVal poThread As Thread)
        moListThread.Add(poThread)
        For liPos As Integer = 0 To moListThread.Count - 1
            Select Case moListThread(liPos).ThreadState
                Case ThreadState.Unstarted
                    moListThread(liPos).Start()
            End Select
        Next
    End Sub

    Shared Function ListThread_Count(Optional psName As String = "") As Integer
        Dim liCount As Integer = 0
        For liPos As Integer = 0 To moListThread.Count - 1
            If psName.Trim.Length > 0 Then
                If moListThread(liPos).Name.Substring(0, psName.Length) = psName Then
                    liCount += 1
                End If
            Else
                liCount += 1
            End If
        Next
        Return liCount
    End Function

    Shared Function ListThread_Alive(Optional psName As String = "") As Integer
        Dim liCount As Integer = 0
        For liPos As Integer = 0 To moListThread.Count - 1
            If psName.Trim.Length > 0 Then
                If moListThread(liPos).Name.Substring(0, psName.Length) = psName Then
                    If moListThread(liPos).IsAlive = True Then
                        liCount += 1
                    End If
                End If
            Else
                If moListThread(liPos).IsAlive = True Then
                    liCount += 1
                End If
            End If
        Next
        Return liCount
    End Function

    Private Function LFoBitacorasNoEnviadas() As ArrayList
        Dim loBitacoras As New ArrayList
        Dim lsSS030_codigo As String = GFsParametroObtener(sLocal_, "Tabla general - Registro Envio Bitacora", sNo_)
        Dim loDataReader As DbDataReader = Nothing
        Dim loDatos As New Ess040tabdet
        Dim lsSQL As String = GFsGeneraSQL("Ess040tabdet_SinEnviar")
        If lsSQL = sRESERVADO_ Then
            MessageBox.Show("Ess040tabdet_SinEnviar" & ControlChars.CrLf & "Aun no ha sido definido.")
            LFoBitacorasNoEnviadas = Nothing
            Exit Function
        End If
        loBitacoras.Clear()
        lsSQL = lsSQL.Replace("@nombre", sEnviarMail_)
        loDatos.ss010_codigo = SesionActiva.sistema
        loDatos.ss030_codigo = lsSS030_codigo
        loDataReader = loDatos.RecuperarConsulta(lsSQL)
        While loDataReader.Read()
            loBitacoras.Add(loDataReader("codigo").ToString & sSF_ & loDataReader("detalle").ToString)
        End While

        loDataReader.Close()
        loDatos.CerrarConexion()
        loDatos = Nothing
        Return loBitacoras
    End Function

    Shared Sub PuedeUsar_Save(ByVal psCodigo As String, ByVal psValor As String)
        If moPuedeUsar.ContainsKey(psCodigo) = False Then
            moPuedeUsar.Add(psCodigo, psValor)
        Else
            moPuedeUsar(psCodigo) = psValor
        End If
    End Sub

    Shared Function PuedeUsar(ByVal psCodigo As String) As String
        Dim lsResultado As String = sNODEFINIDO_

        If moPuedeUsar.ContainsKey(psCodigo) = True Then
            lsResultado = moPuedeUsar(psCodigo).ToString
        End If

        Return lsResultado
    End Function

    Shared Sub Ejercicios_Save(ByVal psCodigo As String, ByVal psValor As String)
        If moEjercicios.ContainsKey(psCodigo) = False Then
            moEjercicios.Add(psCodigo, psValor)
        Else
            moEjercicios(psCodigo) = psValor
        End If
    End Sub

    Shared Function Ejercicios(ByVal psCodigo As String) As String
        Dim lsResultado As String = sNODEFINIDO_

        If moEjercicios.ContainsKey(psCodigo) = True Then
            lsResultado = moEjercicios(psCodigo).ToString
        End If

        Return lsResultado
    End Function

End Class
