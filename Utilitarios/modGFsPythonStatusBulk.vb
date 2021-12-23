Imports Newtonsoft.Json.Linq

Module modGFsPythonStatusBulk

    Public Function GFsPythonStatusBulk(ByVal psNombreScript As String, ByVal psId As String, Optional ByVal psComando As String = "C:\Python396\Python.exe", Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        Dim lsScript As String = GFsGeneraSQL(psNombreScript, sGeneral_, sZIS_TablaScriptPython_, sUbicacionScriptPython_)
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoCRM_bulk_ALL_)
        lsScript = lsScript.Replace("&access_token", lsAccessToken)
        lsScript = lsScript.Replace("&id", psId)
        lsScript = GFsGrabaScriptToFile(lsScript)
        lsScript = GFsEjecutaProceso(psComando, lsScript)
        Dim loScript() As String = lsScript.Split("|"c)
        If InStr(sZIS_Http200_, loScript(0), CompareMethod.Text) > 0 Then
            loScript(1) = loScript(1).Replace(Chr(39), Chr(34))
            loScript(1) = loScript(1).Replace("None", Chr(34) & "None" & Chr(34))
            Dim loLeerJSON As JObject = JObject.Parse(loScript(1))
            If loLeerJSON("status").ToString = "COMPLETED" Then
                lsScript = loLeerJSON("status").ToString & "|" & loLeerJSON("result")("download_url").ToString
            End If
        End If
        If lsScript.Substring(0, 9) = "COMPLETED" Then
            Dim lsScript2 As String = lsScript
            lsScript = lsScript2
        End If
        Return lsScript
    End Function

End Module
