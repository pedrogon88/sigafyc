Imports System.IO
Imports System.Text

Public Class RegistrosOperativos
    Private msUbicacion As String = ""
    Private msFechaHoraEntrada As String = ""

    Public ReadOnly Property ArchivoBitacora As String
    Public ReadOnly Property FileName As String

    Public Sub New(Optional ByVal psNombreBitacora As String = "Log_")
        If psNombreBitacora.Trim.Length = 0 Then Exit Sub

        Dim lsFechaHora As String = Now.ToString(sFormatoFechaHora3_)
        msUbicacion = GFsParametroObtener(sLocal_, sUbicacionBitacora_, sNo_)
        FileName = psNombreBitacora & lsFechaHora & sExtensionBitacora_
        ArchivoBitacora = msUbicacion & sDS_ & FileName

        If Not Directory.Exists(msUbicacion) Then
            Directory.CreateDirectory(msUbicacion)
        End If
        If Not File.Exists(ArchivoBitacora) Then
            Dim loEncoding As Encoding = New UTF8Encoding(False)
            Dim loArchivoBitacora As New StreamWriter(ArchivoBitacora, True, loEncoding)
            Try
                msFechaHoraEntrada = Now.ToString(sFormatoFechaHora1_)
                loArchivoBitacora.WriteLine("-CABECERA INICIO----------------------------------------------------------------------------------------")
            Catch ex As Exception
                MessageBox.Show("RegistrosOperativos / Cabecera -> Error:" & ex.Message)
            End Try
            loArchivoBitacora.Close()
            loEncoding = Nothing
            loArchivoBitacora = Nothing

            LPGeneraBitacoraCabecera()
        End If
    End Sub

    Public Sub Registrar(ByVal psAccion As String, ByVal psAccionDetalle As String)
        LPGeneraBitacoraDetalle(psAccion, psAccionDetalle)
    End Sub

    Public Sub Cerrar()
        LPCierreBitacora()
    End Sub

    Private Sub LPGeneraBitacoraCabecera()
        Dim loEncoding As Encoding = New UTF8Encoding(False)
        Dim loArchivoBitacora As New StreamWriter(ArchivoBitacora, True, loEncoding)
        loArchivoBitacora.WriteLine("Id Sesion...: " & SesionActiva.sessionId)
        loArchivoBitacora.WriteLine("Sistema.....: " & SesionActiva.sistema)
        loArchivoBitacora.WriteLine("Fecha/hora..: " & msFechaHoraEntrada)
        loArchivoBitacora.WriteLine("Usuario.....: " & SesionActiva.usuario)
        loArchivoBitacora.WriteLine("Login acceso: " & SesionActiva.loginAcceso)
        loArchivoBitacora.WriteLine("Equipo......: " & SesionActiva.equipo)
        loArchivoBitacora.WriteLine("HDD serial..: " & SesionActiva.serialHDD)
        loArchivoBitacora.WriteLine("IpV4........: " & SesionActiva.ip)
        loArchivoBitacora.WriteLine("-CABECERA FINAL-----------------------------------------------------------------------------------------")
        loArchivoBitacora.WriteLine("-DETALLE INICIO-----------------------------------------------------------------------------------------")
        loArchivoBitacora.Close()
        loEncoding = Nothing
        loArchivoBitacora = Nothing
    End Sub

    Private Sub LPGeneraBitacoraDetalle(ByVal psAccion As String, ByVal psAccionDetalle As String, Optional psFechaHora As String = "")
        Dim lsFechaHora As String = ""
        If psFechaHora.Trim.Length > 0 Then
            lsFechaHora = psFechaHora
        Else
            lsFechaHora = Now.ToString(sFormatoFechaHora2_)
        End If
        Dim lsLinea As String = lsFechaHora & sBS_ & psAccion & sBS_ & psAccionDetalle
        Dim loEncoding As Encoding = New UTF8Encoding(False)
        Dim loArchivoBitacora As New StreamWriter(ArchivoBitacora, True, loEncoding)
        loArchivoBitacora.WriteLine(lsLinea)
        loArchivoBitacora.Close()
        loArchivoBitacora = Nothing
    End Sub

    Private Sub LPCierreBitacora()
        Dim loEncoding As Encoding = New UTF8Encoding(False)
        Dim loArchivoBitacora As New StreamWriter(ArchivoBitacora, True, loEncoding)
        loArchivoBitacora.WriteLine("-DETALLE FINAL------------------------------------------------------------------------------------------")
        loArchivoBitacora.Flush()
        loArchivoBitacora.Close()
        loArchivoBitacora.Dispose()
        loArchivoBitacora = Nothing
        loEncoding = Nothing
    End Sub

End Class
