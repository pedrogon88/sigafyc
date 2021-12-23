Imports Newtonsoft.Json.Linq

Module modGFsPythonCreateBulk

    Public Function GFsPythonCreateBulk(ByVal psNombreScript As String, ByVal psFileId As String, ByVal psModulo As String, Optional piNumMod As Integer = 0, Optional ByVal psTipAct As String = sBulkUpsert_, Optional ByVal psComando As String = "C:\Python396\Python.exe", Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing, Optional ByVal psCampoPK As String = "") As String
        Dim lsScript As String = GFsGeneraSQL(psNombreScript, sGeneral_, sZIS_TablaScriptPython_, sUbicacionScriptPython_)
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoCRM_bulk_ALL2_)
        lsScript = lsScript.Replace("&access_token", lsAccessToken)
        lsScript = lsScript.Replace("&tipo_operacion", psTipAct)
        lsScript = lsScript.Replace("&file_id", psFileId)
        lsScript = lsScript.Replace("&modulo", psModulo)
        lsScript = lsScript.Replace("&field_pk", psCampoPK)

        Dim liNumOrd As Integer = 0
        Dim lsMapping As String = ""
        Dim loDataRow As DataRow = Nothing
        Dim loMapeo As DataTable = GFoRecuperaModelo(piNumMod)
        For Each loDataRow In loMapeo.Rows
            liNumOrd += 1
            Dim lsLinea As String = "    " & "field_mapping_" & liNumOrd.ToString & " = {" & vbCrLf
            Dim lsDatos As String = ""
            lsDatos = "        " & Chr(39) & "api_name" & Chr(39) & ": " & Chr(39) & loDataRow.Item("destino").ToString.Trim & Chr(39) & "," & vbCrLf
            lsDatos &= "        " & Chr(39) & "index" & Chr(39) & ": " & CStr(liNumOrd - 1) & vbCrLf
            lsLinea &= lsDatos
            If lsMapping.Trim.Length = 0 Then
                lsMapping = lsLinea
            Else
                lsMapping &= lsLinea
            End If
            lsMapping &= "    }" & vbCrLf
            Application.DoEvents()
        Next
        lsScript = lsScript.Replace("&field_mapping", lsMapping)

        Dim lsMappings As String = "    " & "field_mappings = [" & vbCrLf
        For liPos As Integer = 1 To liNumOrd
            If liPos < liNumOrd Then
                If lsMappings.Trim.Length = 0 Then
                    lsMappings = "        " & "field_mapping_" & liPos.ToString & "," & vbCrLf
                Else
                    lsMappings &= "        " & "field_mapping_" & liPos.ToString & "," & vbCrLf
                End If
            Else
                lsMappings &= "        " & "field_mapping_" & liPos.ToString & vbCrLf
            End If
            Application.DoEvents()
        Next
        lsMappings &= "    ]"
        lsScript = lsScript.Replace("&resumen_mapping", lsMappings)

        lsScript = GFsGrabaScriptToFile(lsScript)
        lsScript = GFsEjecutaProceso(psComando, lsScript)
        Dim loScript() As String = lsScript.Split("|"c)
        Dim lsMsgError As String = GFsZohoError(loScript(1).ToString)
        If lsMsgError = sOk_ Then
            Dim loLeerJSON As JObject = JObject.Parse(loScript(1))
            If loLeerJSON("code").ToString = sSUCCESS_ Then
                lsScript = loLeerJSON("details")("id").ToString
            End If
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If
        Return lsScript
    End Function

End Module
