Imports Newtonsoft.Json.Linq

Module modGFsPythonFileUpload

    Public Function GFsPythonFileUpload(ByVal psFilename As String, Optional ByVal psNombreScript As String = "Zoho_UploadFile", Optional ByVal psComando As String = "C:\Python396\Python.exe", Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        GPBitacoraRegistrar(sENTRO_, "GFsPythonFileUpload --> Filename:" & psFilename & ", NombreScript: " & psNombreScript & ", Comando: " & psComando & ", RegistroOperativo:" & poRegistroOperativo.FileName)
        Dim lsScript As String = GFsGeneraSQL(psNombreScript, sGeneral_, sZIS_TablaScriptPython_, sUbicacionScriptPython_)
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoFiles_Files_ALL_)
        Dim lsOrgId As String = GFsGetOrganization()
        lsScript = lsScript.Replace("&access_token", lsAccessToken)
        lsScript = lsScript.Replace("&org_code", lsOrgId)
        lsScript = lsScript.Replace("&filename", psFilename)
        lsScript = GFsGrabaScriptToFile(lsScript)
        lsScript = GFsEjecutaProceso(psComando, lsScript)
        Dim loScript() As String = lsScript.Split("|"c)
        Dim lsMsgError As String = GFsZohoError(loScript(0).ToString)
        If lsMsgError = sOk_ Then
            Dim loLeerJSON As JObject = JObject.Parse(loScript(1))
            If loLeerJSON("code").ToString = sZIS_FileUploadSuccess_ Then
                lsScript = loLeerJSON("details")("file_id").ToString
            End If
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If
        GPBitacoraRegistrar(sINFORMAR_, "GFsPythonFileUpload --> Valor a retornar: " & lsScript)
        GPBitacoraRegistrar(sSALIO_, "GFsPythonFileUpload --> Filename:" & psFilename & ", NombreScript: " & psNombreScript & ", Comando: " & psComando & ", RegistroOperativo:" & poRegistroOperativo.FileName)
        Return lsScript
    End Function

End Module
