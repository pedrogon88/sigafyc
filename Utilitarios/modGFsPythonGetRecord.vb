Module modGFsPythonGetRecord

    Public Function GFsPythonGetRecord(ByVal psModulo As String, ByVal psPK As String, ByVal psCampoPK As String, ByVal psFindMethod As String, Optional ByVal psNombreScript As String = "get_record", Optional ByVal psComando As String = "C:\Python396\Python.exe", Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        Dim lsScript As String = GFsGeneraSQL(psNombreScript, sGeneral_, sZIS_TablaScriptPython_, sUbicacionScriptPython_)
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoCRM_Modules_ALL_)
        lsScript = lsScript.Replace("&modulo", psModulo)
        lsScript = lsScript.Replace("&access_token", lsAccessToken)
        Select Case psFindMethod
            Case sZIS_Search_
                lsScript = lsScript.Replace("&pk", sZIS_Search_)
                lsScript = lsScript.Replace("&criteria", Chr(39) & "criteria" & Chr(39) & ": " & Chr(39) & psCampoPK & ":equals:" & psPK & Chr(39) & ",")
                lsScript = lsScript.Replace("&external", "")
            Case sZIS_ZohoId_
                lsScript = lsScript.Replace("&pk", psPK)
                lsScript = lsScript.Replace("&criteria", "")
                lsScript = lsScript.Replace("&external", "")
            Case sZIS_External_
                lsScript = lsScript.Replace("&pk", psPK)
                lsScript = lsScript.Replace("&criteria", "")
                lsScript = lsScript.Replace("&external", ", " & Chr(39) & "X-EXTERNAL" & Chr(39) & ": " & Chr(39) & psModulo & "." & psCampoPK & Chr(39) & ",")
        End Select
        lsScript = GFsGrabaScriptToFile(lsScript)
        Dim lsResultado As String = GFsEjecutaProceso(psComando, lsScript)
        Dim loResultado() As String = lsResultado.Split("|"c)

        GPBitacoraRegistrar(sWRESPONSE_, lsScript & ", Modulo:" & psModulo & ", PK:" & psPK & ", CampoPK:" & psCampoPK & ", FindMethod:" & psFindMethod & ", _Resultado:" & lsResultado)
        If InStr(sZIS_Http200_, loResultado(0), CompareMethod.Text) > 0 Then
            Dim lsResultadoJson As String = loResultado(1).Replace("None", Chr(34) & "Null" & Chr(34))
            lsResultadoJson = lsResultadoJson.Replace("True", Chr(34) & "True" & Chr(34))
            lsResultadoJson = lsResultadoJson.Replace("False", Chr(34) & "False" & Chr(34))
            Return lsResultadoJson
        Else
            Return lsResultado
        End If
    End Function

End Module
