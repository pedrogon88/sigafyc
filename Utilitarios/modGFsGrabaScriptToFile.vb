Imports System.IO

Module modGFsGrabaScriptToFile

    Public Function GFsGrabaScriptToFile(ByVal psCadena As String, Optional ByVal psArchivo As String = sRESERVADO_, Optional ByVal psUbicacion As String = sRESERVADO_) As String
        GPBitacoraRegistrar(sENTRO_, "GFsGrabaScriptToFile -> Archivo:" & psArchivo & ", Ubicación:" & psUbicacion)
        Dim lsFileName As String = ""
        Dim lsArchivo As String = psArchivo
        Dim lsUbicacion As String = psUbicacion

        If psArchivo = sRESERVADO_ Then
            lsArchivo = SesionActiva.usuario & "_" & SesionActiva.equipo & "_" & Now.ToString(sFormatoFechaHora3_) & sExtensionPython_
        End If
        If psUbicacion = sRESERVADO_ Then
            lsUbicacion = ""
        End If
        If lsUbicacion.Trim.Length > 0 Then
            lsFileName = lsUbicacion & "\" & lsArchivo
        Else
            lsFileName = lsArchivo
        End If
        Dim loStreamWriter As New StreamWriter(lsFileName)
        loStreamWriter.WriteLine(psCadena)
        loStreamWriter.Close()
        loStreamWriter = Nothing
        GPBitacoraRegistrar(sSALIO_, "GFsGrabaScriptToFile -> Script:" & psCadena)
        GPBitacoraRegistrar(sSALIO_, "GFsGrabaScriptToFile -> Archivo:" & psArchivo & ", Ubicación:" & psUbicacion)
        Return lsFileName
    End Function

End Module
