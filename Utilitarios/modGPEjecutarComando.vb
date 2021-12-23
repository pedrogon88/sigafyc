Imports System.IO

Module modGPEjecutarComando

    Public Sub GPEjecutarComando(ByVal psComando As String)
        Dim loProcessInfo As New ProcessStartInfo(psComando)
        loProcessInfo.RedirectStandardError = True
        loProcessInfo.RedirectStandardOutput = True
        loProcessInfo.CreateNoWindow = False
        loProcessInfo.WindowStyle = ProcessWindowStyle.Hidden
        loProcessInfo.UseShellExecute = False

        Dim loProcess As Process = Process.Start(loProcessInfo)
        loProcess.WaitForExit()
        Dim lsErrores = loProcess.StandardError.ReadToEnd()
        Dim lsSalida = loProcess.StandardOutput.ReadToEnd()
        GPBitacoraRegistrar(sEjecutar_, "Archivo batch [" & psComando & "]" & ControlChars.CrLf & lsSalida & ControlChars.CrLf & lsErrores)

        loProcess.Dispose()
        loProcess = Nothing
        loProcessInfo = Nothing
        If File.Exists(psComando) Then
            My.Computer.FileSystem.DeleteFile(psComando)
            If File.Exists(psComando) Then
                File.Delete(psComando)
            End If
        End If
    End Sub

End Module
