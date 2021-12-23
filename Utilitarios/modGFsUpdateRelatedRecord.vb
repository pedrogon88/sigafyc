Imports Newtonsoft.Json.Linq

Module modGFsUpdateRelatedRecord

    Public Function GFsUpdateRelatedRecord(ByVal psRone As String, ByVal psRone_pk As String, ByVal psRoneCampoPK As String, ByVal psRmany_field As String, ByVal psRmany_value As String, Optional ByVal psNombreScript As String = "update_related_record", Optional ByVal psComando As String = "C:\Python396\Python.exe", Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        If poRegistroOperativo Is Nothing Then
            GPBitacoraRegistrar(sENTRO_, "GFsUpdateRelatedRecord --> Modulo1->" & psRone & "[" & psRone_pk & "], Campo actualizacion->" & psRmany_field & "[" & psRmany_value & "], NombreScript: " & psNombreScript & ", Comando: " & psComando)
        Else
            GPBitacoraRegistrar(sENTRO_, "GFsUpdateRelatedRecord --> Modulo1->" & psRone & "[" & psRone_pk & "], Campo actualizacion->" & psRmany_field & "[" & psRmany_value & "], NombreScript: " & psNombreScript & ", Comando: " & psComando & ", RegistroOperativo:" & poRegistroOperativo.FileName)
        End If
        Dim lsScript As String = GFsGeneraSQL(psNombreScript, sGeneral_, sZIS_TablaScriptPython_, sUbicacionScriptPython_)
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoCRM_Modules_ALL_)
        lsScript = lsScript.Replace("&access_token", lsAccessToken)
        lsScript = lsScript.Replace("&rone1", psRone)
        lsScript = lsScript.Replace("&rone_pk", psRone_pk)
        lsScript = lsScript.Replace("&ROneCampoPK", psRone & "." & psRoneCampoPK)

        lsScript = lsScript.Replace("&rmany_field", psRmany_field)
        lsScript = lsScript.Replace("&rmany_value", psRmany_value)

        lsScript = GFsGrabaScriptToFile(lsScript)
        lsScript = GFsEjecutaProceso(psComando, lsScript)
        Dim loScript() As String = lsScript.Split("|"c)
        Dim lsMsgError As String = GFsZohoError(loScript(1).ToString)
        If lsMsgError = sOk_ Then
            Dim loLeerJSON As JObject = JObject.Parse(loScript(1))
            If loLeerJSON("data")(0)("code").ToString = sSUCCESS_ Then
                lsScript = loLeerJSON("data")(0)("code").ToString
            End If
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If
        GPBitacoraRegistrar(sINFORMAR_, "GFsUpdateRelatedRecord --> Valor a retornar: " & lsScript)
        If poRegistroOperativo Is Nothing Then
            GPBitacoraRegistrar(sSALIO_, "GFsUpdateRelatedRecord --> Modulo1->" & psRone & "[" & psRone_pk & "], campo actualizable->" & psRmany_field & "[" & psRmany_value & "], NombreScript: " & psNombreScript & ", Comando: " & psComando)
        Else
            GPBitacoraRegistrar(sSALIO_, "GFsUpdateRelatedRecord --> Modulo1->" & psRone & "[" & psRone_pk & "], campo actualizable->" & psRmany_field & "[" & psRmany_value & "], NombreScript: " & psNombreScript & ", Comando: " & psComando & ", RegistroOperativo:" & poRegistroOperativo.FileName)
        End If
        Return lsScript
    End Function

End Module
