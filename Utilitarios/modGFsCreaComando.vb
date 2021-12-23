Imports System.IO

Module modGFsCreaComando
    Public Function GFsCreaComando(ByVal psArchivo() As String, Optional ByVal psTipoComando As String = sCompactar_) As String
        Dim lsResultado As String = ""
        lsResultado = SesionActiva.usuario & "_" & SesionActiva.mac & "_" & Now.ToString(sFormatoFechaHora3_) & ".bat"
        lsResultado = LFsCreaScript(lsResultado, psArchivo(0), psArchivo(1), psTipoComando)
        Return lsResultado
    End Function

    Private Function LFsCreaScript(ByVal psArchivoBatch As String, ByVal psArchivo As String, ByVal psFilename As String, ByVal psTipoComando As String) As String
        Dim lsResultado As String = ""
        Dim loArchivoBatch As New StreamWriter(psArchivoBatch)
        loArchivoBatch.WriteLine("ECHO OFF")
        loArchivoBatch.WriteLine("CLS")
        Select Case psTipoComando
            Case sCompactar_
                Dim lsFilenameCompactado As String = ""
                Dim lsArchivoCompactado As String = ""
                Dim lsFechaHora As String = Now.ToString(sFormatoFechaHora3_)
                Dim lsConPassword As String = GFsParametroObtener(sGeneral_, "Archivos compactados - tiene password")
                If lsConPassword = sRESERVADO_ Then
                    lsConPassword = sSi_
                    GPParametroGuardar(sGeneral_, "Archivos compactados - tiene password", lsConPassword)
                End If
                If lsConPassword = sSi_ Then
                    Dim lsPassword As String = GFiAleatorio(1000).ToString("0000")
                    lsArchivoCompactado = psArchivo & "_" & lsFechaHora & lsPassword & ".7z "
                    lsFilenameCompactado = psFilename & "_" & lsFechaHora & lsPassword & ".7z "
                    loArchivoBatch.WriteLine("7z a -r -p" & lsPassword & " -ssw -mx5 " & lsFilenameCompactado & " " & psFilename)
                Else
                    lsArchivoCompactado = psArchivo & "_" & lsFechaHora & ".7z "
                    lsFilenameCompactado = psFilename & "_" & lsFechaHora & ".7z"
                    loArchivoBatch.WriteLine("7z a -r -ssw -mx5 " & lsFilenameCompactado & " " & psFilename)
                End If
                lsResultado = psArchivoBatch & sSF_ & lsArchivoCompactado & sSF_ & lsFilenameCompactado
        End Select
        loArchivoBatch.WriteLine("EXIT")
        loArchivoBatch.Close()
        loArchivoBatch.Dispose()
        loArchivoBatch = Nothing
        Return lsResultado
    End Function

End Module
