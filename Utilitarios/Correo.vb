Imports System.Net.Mail
Imports System.Data.Common
Imports System.IO

Public Class Correo
    Private moMailMessage As MailMessage
    Private moSmtpServer As SmtpClient
    Private msBody As String = ""
    Private msAsunto As String = ""
    Private moArchivosAdjuntos As New ArrayList
    Private msArchivoAdjunto As String = ""
    Private msAdjuntoFilename As String = ""
    Private msBitacoraMsg As String = ""
    Private msListaAdjunto As String = ""

    Public Property body As String
        Get
            Return msBody
        End Get
        Set(value As String)
            msBody = value
        End Set
    End Property

    Public Property asunto As String
        Get
            Return msAsunto
        End Get
        Set(value As String)
            msAsunto = value
        End Set
    End Property

    Public Property archivosAdjuntos As ArrayList
        Get
            Return moArchivosAdjuntos
        End Get
        Set(value As ArrayList)
            moArchivosAdjuntos = value
        End Set
    End Property

    Public Sub New()
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsValor2 As String = ""
        msBitacoraMsg = ""

        lsClave = "Mail - Servidor SMTP"
        lsValor = GFsParametroObtener(sGeneral_, lsClave)
        moMailMessage = New MailMessage
        moSmtpServer = New SmtpClient(lsValor)
        lsClave = "Mail - Enable SSL"
        lsValor = GFsParametroObtener(sGeneral_, lsClave)
        moSmtpServer.EnableSsl = Convert.ToBoolean(IIf(lsValor = sSi_, True, False))
        lsClave = "Mail - Servidor SMTP Port"
        lsValor = GFsParametroObtener(sGeneral_, lsClave)
        moSmtpServer.Port = Integer.Parse(lsValor)
        lsClave = "Mail - Username"
        lsValor = GFsParametroObtener(sGeneral_, lsClave)
        lsClave = "Mail - Password"
        lsValor2 = GFsParametroObtener(sGeneral_, lsClave)
        moSmtpServer.Credentials = New Net.NetworkCredential(lsValor, lsValor2)
    End Sub

    Public Sub Enviar(Optional psBitacora As String = sSi_)
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsValor2 As String = ""
        Dim lsBody As String = ""

        moMailMessage.Subject = asunto
        lsClave = "Mail - Address - From Cuenta"
        lsValor = GFsParametroObtener(sGeneral_, lsClave)
        msBitacoraMsg = lsClave & ": " & lsValor & ControlChars.CrLf
        lsClave = "Mail - Address - From Nombre Completo"
        lsValor2 = GFsParametroObtener(sGeneral_, lsClave)
        msBitacoraMsg &= lsClave & ": " & lsValor2 & ControlChars.CrLf
        moMailMessage.From = New MailAddress(lsValor, lsValor2 & " (Auditoria y Seguridad)")
        LPAgregaAddress(sAddressTo_)
        LPAgregaAddress(sAddressCC_)
        LPAgregaAddress(sAddressCCO_)

        lsBody = body
        msBitacoraMsg &= "Asunto: " & asunto & ControlChars.CrLf
        msBitacoraMsg &= "Body:" & ControlChars.CrLf
        msBitacoraMsg &= lsBody & ControlChars.CrLf

        LPArchivosAdjuntos()

        moMailMessage.Body = lsBody
        If psBitacora = sSi_ Then GPBitacoraRegistrar(sEnviarMail_, msBitacoraMsg)
        Try
            moSmtpServer.Send(moMailMessage)
            moMailMessage.Dispose()
            moSmtpServer.Dispose()
            LPProcesaAdjuntosEnviados()
        Catch ex As Exception
            MessageBox.Show("Error durante el envio de mail" & ControlChars.CrLf & "Error:" & ex.Message)
        End Try
    End Sub

    Public Sub Enviar(ByVal psAsunto As String, ByVal psBody As String)
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsValor2 As String = ""
        Dim lsSeparador As String = "----------------------------------------------------------------------------------"

        moMailMessage.Subject = psAsunto
        msBitacoraMsg &= "Asunto: " & psAsunto & ControlChars.CrLf
        Dim lsBody As String = psBody
        If msListaAdjunto.Trim.Length > 0 Then
            lsBody &= ControlChars.CrLf & lsSeparador & ControlChars.CrLf & msListaAdjunto & ControlChars.Cr & lsSeparador
        End If
        moMailMessage.Body = lsBody
        msBitacoraMsg &= "Body: " & ControlChars.CrLf
        msBitacoraMsg &= lsBody & ControlChars.CrLf

        LPArchivosAdjuntos()

        GPBitacoraRegistrar(sEnviarMail_, msBitacoraMsg)
        Try
            moSmtpServer.Send(moMailMessage)
            moMailMessage.Dispose()
            moSmtpServer.Dispose()
            LPProcesaAdjuntosEnviados()
        Catch ex As Exception
            MessageBox.Show("Error durante el envio de mail" & ControlChars.CrLf & "Error:" & ex.Message)
        End Try
    End Sub

    Private Sub LPAgregaAddress(ByVal psTipo As String)
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsValor2 As String = ""
        Select Case psTipo
            Case sAddressTo_
                lsClave = "Mail - Address - To"
            Case sAddressCC_
                lsClave = "Mail - Address - CC"
            Case sAddressCCO_
                lsClave = "Mail - Address - CCO"
        End Select
        Dim lsSS030_codigo As String = GFsParametroObtener(sGeneral_, lsClave)
        Dim loDataReader As DbDataReader = Nothing
        Dim loDatos As New Ess040tabdet
        Dim lsSQL As String = GFsGeneraSQL("Ess040tabdet_MailAddress")
        If lsSQL = sRESERVADO_ Then
            MessageBox.Show("Ess040tabdet_MailAddress" & ControlChars.CrLf & "Aun no ha sido definido.")
            Exit Sub
        End If
        loDatos.ss010_codigo = SesionActiva.sistema
        loDatos.ss030_codigo = lsSS030_codigo
        loDataReader = loDatos.RecuperarConsulta(lsSQL)
        While loDataReader.Read()
            Select Case psTipo
                Case sAddressTo_
                    moMailMessage.To.Add(New MailAddress(loDataReader("codigo").ToString, loDataReader("nombre").ToString))
                Case sAddressCC_
                    moMailMessage.CC.Add(New MailAddress(loDataReader("codigo").ToString, loDataReader("nombre").ToString))
                Case sAddressCCO_
                    moMailMessage.Bcc.Add(New MailAddress(loDataReader("codigo").ToString, loDataReader("nombre").ToString))
            End Select
            msBitacoraMsg &= psTipo & ": " & loDataReader("codigo").ToString & " - " & loDataReader("nombre").ToString & ControlChars.CrLf
        End While
        loDataReader.Close()
        loDatos.CerrarConexion()
        loDatos = Nothing
        If moMailMessage.To.Count = 0 Then
            lsClave = "Mail - Address - From Cuenta"
            lsValor = GFsParametroObtener(sGeneral_, lsClave)
            lsClave = "Mail - Address - From Nombre Completo"
            lsValor2 = GFsParametroObtener(sGeneral_, lsClave)
            moMailMessage.To.Add(New MailAddress(lsValor, lsValor2))
        End If
    End Sub

    Private Sub LPArchivosAdjuntos()
        Dim loAdjunto As Attachment
        If moArchivosAdjuntos.Count = 0 Then Exit Sub

        Dim lsMaxLength As String = GFsParametroObtener(sGeneral_, "Enviar correo - Archivo adjuntos - maximo tamaño")
        If lsMaxLength = sRESERVADO_ Then
            lsMaxLength = "512000"
            GPParametroGuardar(sGeneral_, "Enviar correo - Archivo adjuntos - maximo tamaño", lsMaxLength)
        Else
            If Not IsNumeric(lsMaxLength) Then
                lsMaxLength = "512000"
                GPParametroGuardar(sGeneral_, "Enviar correo - Archivo adjuntos - maximo tamaño", lsMaxLength)
            End If
        End If

        For liNDX As Integer = 0 To moArchivosAdjuntos.Count - 1
            Dim lsArchivo() As String = moArchivosAdjuntos.Item(liNDX).ToString.Split(sSF_)
            Dim loArchivoAdjunto As New FileInfo(lsArchivo(1))
            If loArchivoAdjunto.Length > Val(lsMaxLength) Then
                Dim lsArchivoCompactado() As String = LFsCompactaAdjunto(lsArchivo).ToString.Split(sSF_)
                Dim lsProceso As String = GFsEjecutaProceso(lsArchivoCompactado(0), "", sNo_)
                lsArchivo(0) = lsArchivoCompactado(1)
                lsArchivo(1) = lsArchivoCompactado(2)
            End If
            msBody &= "Archivo adjunto: " & lsArchivo(0)
            loAdjunto = New Attachment(lsArchivo(1))
            moMailMessage.Attachments.Add(loAdjunto)
            msBitacoraMsg &= "Adjunto: " & lsArchivo(0) & ControlChars.CrLf
        Next
    End Sub

    Private Function LFsCompactaAdjunto(ByVal psArchivo() As String) As String
        Dim lsResultado As String = GFsCreaComando(psArchivo, sCompactar_)
        Return lsResultado
    End Function

    Private Sub LPProcesaAdjuntosEnviados()
        If moArchivosAdjuntos.Count = 0 Then Exit Sub

        Dim lsBitacoraEliminar As String = GFsParametroObtener(sUsuario_, "Bitacora proceso - Eliminar despues enviar mail")
        Dim lsSS030_codigo As String = GFsParametroObtener(sLocal_, "Tabla general - Registro Envio Bitacora", sNo_)
        Dim loSS040 As New Ess040tabdet
        For liNDX As Integer = 0 To moArchivosAdjuntos.Count - 1
            Dim lsArchivo() As String = moArchivosAdjuntos.Item(liNDX).ToString.Split(sSF_)
            loSS040.ss010_codigo = SesionActiva.sistema
            loSS040.ss030_codigo = lsSS030_codigo
            loSS040.codigo = lsArchivo(0)
            Try
                If loSS040.GetPK = sOk_ Then
                    loSS040.ss010_codigo = SesionActiva.sistema
                    loSS040.ss030_codigo = lsSS030_codigo
                    loSS040.codigo = lsArchivo(0)
                    loSS040.nombre = sMailEnviado_
                    Try
                        loSS040.Put(sNo_, sNo_)
                    Catch ex As Exception
                        MessageBox.Show("Correo / ProcesaAdjuntosEnviados / Marca Enviado -> Error: " & ex.Message)
                    End Try
                    Try
                        If lsBitacoraEliminar = sSi_ Then
                            If File.Exists(lsArchivo(1)) Then
                                File.SetAttributes(lsArchivo(1), FileAttributes.Normal)
                                File.Delete(lsArchivo(1))
                            End If
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Correo / ProcesaAdjuntosEnviados / Borrado Archivo -> Error: " & ex.Message)
                    End Try
                End If
            Catch ex As Exception
                MessageBox.Show("Correo / ProcesaAdjuntosEnviados / Lectura tabla -> Error: " & ex.Message)
            End Try
        Next
        loSS040.CerrarConexion()
        loSS040 = Nothing
    End Sub

    Public Sub Agregar_Adjunto(ByVal psAdjunto As String)
        If msListaAdjunto.Trim.Length = 0 Then
            msListaAdjunto = "Archivo(s) adjunto(s):" & ControlChars.CrLf
        End If
        Dim msParte() As String = psAdjunto.Split(sSF_)
        msListaAdjunto &= "+-->" & msParte(0) & ControlChars.CrLf
        moArchivosAdjuntos.Add(psAdjunto)
    End Sub

    Public Sub Agregar_SourceAddressMail(ByVal psCuentaCorreo As String)
        Dim lsCuentaCorreo() As String = psCuentaCorreo.Split(sSF_)
        moMailMessage.From = New MailAddress(lsCuentaCorreo(0), lsCuentaCorreo(1))
        msBitacoraMsg &= "From: " & lsCuentaCorreo(0) & " - " & lsCuentaCorreo(1) & ControlChars.CrLf
    End Sub

    Public Sub Agregar_TargetAddressMail(ByVal psTipo As String, ByVal psCuentaCorreo As String)
        Dim lsCuentaCorreo() As String = psCuentaCorreo.Split(sSF_)
        Select Case psTipo
            Case sAddressTo_
                moMailMessage.To.Add(New MailAddress(lsCuentaCorreo(0), lsCuentaCorreo(1)))
            Case sAddressCC_
                moMailMessage.CC.Add(New MailAddress(lsCuentaCorreo(0), lsCuentaCorreo(1)))
            Case sAddressCCO_
                moMailMessage.Bcc.Add(New MailAddress(lsCuentaCorreo(0), lsCuentaCorreo(1)))
        End Select
        msBitacoraMsg &= psTipo & ": " & lsCuentaCorreo(0) & " - " & lsCuentaCorreo(1) & ControlChars.CrLf
    End Sub
End Class