Imports Newtonsoft.Json.Linq
Imports System.Threading

Module modGPActualizarExternoCardCode

    Public Sub GPActualizarExternoCardCode(Optional ByVal psModulo As String = "Accounts", Optional ByVal psCampoPK As String = "Codigo_CardCode", Optional ByVal psExternal As String = "Externo_CardCode", Optional ByVal psCODIGO As String = "COQL - Accounts - Update Externo_CardCode", Optional ByVal psCampoMarca As String = "", Optional ByVal psMarcacion As String = "", Optional ByVal psTablaSAP As String = "", Optional ByVal psCampoSAP_ZID As String = "")
        GPBitacoraRegistrar(sENTRO_, "GPActualizarExternoCardCode-> Modulo:" & psModulo & ", CampoPK:" & psCampoPK & ", External:" & psExternal & ", Script:" & psCODIGO)
        Dim lsResultado As String
        Dim liDesde As Integer = 0
        Dim loLeerJSON As JObject = Nothing
        Dim loObjetoSAP As Object = Nothing
        If psTablaSAP.Trim.Length > 0 Then
            Select Case psTablaSAP
                Case sOCRD_
                    loObjetoSAP = New Eocrd
                Case sOCRG_
                    loObjetoSAP = New Eocrg
                Case sOITM_
                    loObjetoSAP = New Eoitm
                Case sOITB_
                    loObjetoSAP = New Eoitb
            End Select
        End If
        '-------Encabezado para iniciar despliegue de formulario---------------
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "GPActualizarExternoCardCode [Modulo:" & psModulo & "] -> Campo: " & psCampoPK & ", External: " & psExternal
        Do While True
            Dim lsCOQL As String = GFsGeneraSQL(psCODIGO.ToUpper, sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
            lsCOQL = lsCOQL.Replace("&Offset", liDesde.ToString)
            Dim lsDatosZoho As String = GFsGetCOQLRecords(lsCOQL)
            If lsDatosZoho.Trim.Length = 0 Then
                GFsAvisar("COQL: " & lsCOQL.Trim & ", Error no se recuperaron datos", sMENSAJE_)
                Exit Sub
            End If
            loLeerJSON = JObject.Parse(lsDatosZoho)
            Dim liCantidad As Integer = CInt(loLeerJSON("info")("count").ToString)
            For liPos = 0 To liCantidad - 1
                '-------Despliega registros leidos---------------
                loFrmProcesamiento.lblRegistroLeido.Text = "Leyendo [" & CStr(liDesde + liPos) & "/" & CStr(liDesde + liCantidad) & ", " & psExternal & "=" & loLeerJSON("data")(liPos)(psCampoPK).ToString & "]"
                loFrmProcesamiento.Refresh()
                Dim lsOK As Boolean = False
                lsOK = CType(loObjetoSAP, Eocrd).GetPK(loLeerJSON("data")(liPos)(psCampoPK).ToString)
                If lsOK Then
                    Dim loDatos As New List(Of BulkDatos)
                    Dim loBulkDatos As New BulkDatos
                    loBulkDatos.sFieldName = psExternal
                    loBulkDatos.sFieldValue = loLeerJSON("data")(liPos)(psCampoPK).ToString
                    loDatos.Add(loBulkDatos)
                    If psCampoMarca.Trim.Length > 0 And psMarcacion.Trim.Length > 0 Then
                        loBulkDatos = New BulkDatos
                        loBulkDatos.sFieldName = psCampoMarca
                        loBulkDatos.sFieldValue = psMarcacion
                        loDatos.Add(loBulkDatos)
                    End If
                    lsResultado = GFsPutRecord(psModulo, loLeerJSON("data")(liPos)("id").ToString, "", loDatos)
                    If psTablaSAP.Trim.Length > 0 Then
                        Select Case psTablaSAP
                            Case sOCRD_
                                lsOK = CType(loObjetoSAP, Eocrd).GetPK(loLeerJSON("data")(liPos)(psCampoPK).ToString)
                                If lsOK Then
                                    CType(loObjetoSAP, Eocrd).SetAtributo(psCampoSAP_ZID, loLeerJSON("data")(liPos)("id").ToString)
                                    CType(loObjetoSAP, Eocrd).Put()
                                End If
                            Case sOCRG_
                                lsOK = CType(loObjetoSAP, Eocrg).GetPK(CInt(loLeerJSON("data")(liPos)(psCampoPK).ToString))
                                If lsOK Then
                                    CType(loObjetoSAP, Eocrg).SetAtributo(psCampoSAP_ZID, loLeerJSON("data")(liPos)("id").ToString)
                                    CType(loObjetoSAP, Eocrg).Put()
                                End If
                            Case sOITM_
                                lsOK = CType(loObjetoSAP, Eoitm).GetPK(loLeerJSON("data")(liPos)(psCampoPK).ToString)
                                If lsOK Then
                                    CType(loObjetoSAP, Eoitm).SetAtributo(psCampoSAP_ZID, loLeerJSON("data")(liPos)("id").ToString)
                                    CType(loObjetoSAP, Eoitm).Put()
                                End If
                            Case sOITB_
                                lsOK = CType(loObjetoSAP, Eoitb).GetPK(CInt(loLeerJSON("data")(liPos)(psCampoPK).ToString))
                                If lsOK Then
                                    CType(loObjetoSAP, Eoitb).SetAtributo(psCampoSAP_ZID, loLeerJSON("data")(liPos)("id").ToString)
                                    CType(loObjetoSAP, Eoitb).Put()
                                End If
                        End Select
                    End If
                    '-------Despliega registros procesados---------------
                    loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando [" & CStr(liDesde + liPos) & "/" & CStr(liDesde + liCantidad) & ", " & psExternal & "=" & loLeerJSON("data")(liPos)(psCampoPK).ToString & "]"
                    loFrmProcesamiento.Refresh()
                End If
            Next
            If CBool(loLeerJSON("info")("more_records").ToString) = True Then
                liDesde += 200
            Else
                Exit Do
            End If
        Loop
        '-------Encabezado para iniciar despliegue de formulario---------------
        loObjetoSAP = Nothing
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing
        GPBitacoraRegistrar(sSALIO_, "GPActualizarExternoCardCode-> Modulo:" & psModulo & ", CampoPK:" & psCampoPK & ", External:" & psExternal & ", Script:" & psCODIGO)
    End Sub

End Module
