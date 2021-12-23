Imports Newtonsoft.Json.Linq

Module modGPIntegracionZohoSAP_COQL
    Public Sub GPIntegracionZohoSAP_COQL(ByVal piNumTra As Integer, ByRef poRegistroOperativo As RegistrosOperativos)
        GPBitacoraRegistrar(sENTRO_, "GPIntegracionZohoSAP_COQL-> Modelo No.:" & piNumTra)

        Dim loModelo As Ezis_modcab = New Ezis_modcab
        loModelo.numtra = piNumTra
        If loModelo.GetPK <> sOk_ Then
            GFsAvisar("No existe el Modelo No. " & piNumTra & ", ESTO NO DEBERIA HABER PASADO!!!", sMENSAJE_)
            Exit Sub
        End If
        Dim lsTablasSapPermitidas As String = GFsParametroObtener(sGeneral_, "ZohoAPI V2 - Tablas SAP Permitidas")
        If InStr(1, lsTablasSapPermitidas, loModelo.destino) = 0 Then
            GFsAvisar("Tabla de Destino [" & loModelo.destino & "] no esta entre las tablas permitidas [" & lsTablasSapPermitidas & "], ESTO NO DEBERIA HABER PASADO!!!", sMENSAJE_)
            Exit Sub
        End If

        Dim loMapeo As DataTable = GFoRecuperaModelo(loModelo.numtra)
        If loMapeo.Rows.Count = 0 Then
            GFsAvisar("Modelo No. " & piNumTra & ", no tiene definido ningun mapeo. ESTO NO DEBERIA HABER PASADO!!!", sMENSAJE_)
            Exit Sub
        End If

        Dim lsLIMIT As String = ""
        Dim lsResultado As String = ""
        Dim liDesde As Integer = 0
        Dim loLeerJSON As JObject = Nothing
        '-------Encabezado para iniciar despliegue de formulario---------------
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "GPIntegracionZohoSAP_COQL [Script:" & loModelo.nombre & "]"
        Do While True
            Dim lsClaveTablaCOQL As String = GFsParametroObtener(sGeneral_, sZIS_TablaScriptCOQL_)
            Dim lsCOQL As String = GFsGeneraSQL(loModelo.script,, lsClaveTablaCOQL, sUbicacionQueryCOQL_, sSi_)
            lsCOQL = lsCOQL.Replace("&Offset", liDesde.ToString)
            Dim lsDatosZoho As String = GFsGetCOQLRecords(lsCOQL, poRegistroOperativo)
            If lsDatosZoho.Trim.Length = 0 Then
                GFsAvisar("COQL: " & lsCOQL.Trim & ", Error no se recuperaron datos", sMENSAJE_)
                Exit Sub
            End If
            loLeerJSON = JObject.Parse(lsDatosZoho)
            Dim liCantidad As Integer = CInt(loLeerJSON("info")("count").ToString)
            For liPos = 0 To liCantidad - 1
                '-------Despliega registros leidos---------------
                loFrmProcesamiento.lblRegistroLeido.Text = "Leyendo [" & CStr(liDesde + liPos) & "/" & CStr(liDesde + liCantidad) & ", " & loModelo.campopk & "=" & loLeerJSON("data")(liPos)(loModelo.campopk).ToString & "]"
                loFrmProcesamiento.Refresh()
                Select Case loModelo.destino
                    Case sOCRD_
                        LPIntegraOCRD(loMapeo, loLeerJSON, liPos, loModelo.campopk)
                    Case sOCRG_
                        LPIntegraOCRG(loMapeo, loLeerJSON, liPos, loModelo.campopk)
                    Case sOCPR_
                        LPIntegraOCPR(loMapeo, loLeerJSON, liPos, loModelo.campopk)
                    Case sCRD1_
                        LPIntegraCRD1(loMapeo, loLeerJSON, liPos, loModelo.campopk)
                    Case sOITM_
                        LPIntegraOITM(loMapeo, loLeerJSON, liPos, loModelo.campopk)
                    Case sOITB_
                        LPIntegraOITB(loMapeo, loLeerJSON, liPos, loModelo.campopk)
                    Case sOSLP_
                        LPIntegraOSLP(loMapeo, loLeerJSON, liPos, loModelo.campopk)
                End Select
                '-------Despliega registros procesados---------------
                loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando [" & CStr(liDesde + liPos) & "/" & CStr(liDesde + liCantidad) & ", " & loModelo.campopk & "=" & loLeerJSON("data")(liPos)(loModelo.campopk).ToString & "]"
                loFrmProcesamiento.Refresh()
            Next
            If CBool(loLeerJSON("info")("more_records").ToString) = True Then
                liDesde += 200
            Else
                Exit Do
            End If
        Loop
        '-------Encabezado para iniciar despliegue de formulario---------------
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing
        GPBitacoraRegistrar(sSALIO_, "GPIntegracionZohoSAP_COQL-> Modelo No.:" & piNumTra)
    End Sub

    Private Sub LPIntegraOCRD(ByVal poModelo As DataTable, ByVal poLeerJSON As JObject, ByVal piPos As Integer, ByVal psCampoPK As String)
        Dim loOBJETO As New Eocrd
        Dim loRow As DataRow = Nothing

        If loOBJETO.GetPK(poLeerJSON("data")(piPos)(psCampoPK).ToString) Then
            For Each loRow In poModelo.Rows
                loOBJETO.SetAtributo(loRow.Item("destino").ToString, poLeerJSON("data")(piPos)(loRow.Item("origen").ToString).ToString)
            Next
            Try
                loOBJETO.Put()
            Catch ex As Exception
                GFsAvisar("LPIntegraOCRD - Error durante actualizacion: " & ex.Message, sMENSAJE_)
            End Try
        End If
    End Sub

    Private Sub LPIntegraOCRG(ByVal poModelo As DataTable, ByVal poLeerJSON As JObject, ByVal piPos As Integer, ByVal psCampoPK As String)
        Dim loOBJETO As New Eocrg
        Dim loRow As DataRow = Nothing

        If loOBJETO.GetPK(CInt(poLeerJSON("data")(piPos)(psCampoPK).ToString)) Then
            For Each loRow In poModelo.Rows
                loOBJETO.SetAtributo(loRow.Item("destino").ToString, poLeerJSON("data")(piPos)(loRow.Item("origen").ToString).ToString)
            Next
            Try
                loOBJETO.Put()
            Catch ex As Exception
                GFsAvisar("LPIntegraOCRG - Error durante actualizacion: " & ex.Message, sMENSAJE_)
            End Try
        End If
    End Sub

    Private Sub LPIntegraOITM(ByVal poModelo As DataTable, ByVal poLeerJSON As JObject, ByVal piPos As Integer, ByVal psCampoPK As String)
        Dim loOBJETO As New Eoitm
        Dim loRow As DataRow = Nothing

        If loOBJETO.GetPK(poLeerJSON("data")(piPos)(psCampoPK).ToString) Then
            For Each loRow In poModelo.Rows
                loOBJETO.SetAtributo(loRow.Item("destino").ToString, poLeerJSON("data")(piPos)(loRow.Item("origen").ToString).ToString)
            Next
            Try
                loOBJETO.Put()
            Catch ex As Exception
                GFsAvisar("LPIntegraOITM - Error durante actualizacion: " & ex.Message, sMENSAJE_)
            End Try
        End If
    End Sub

    Private Sub LPIntegraOITB(ByVal poModelo As DataTable, ByVal poLeerJSON As JObject, ByVal piPos As Integer, ByVal psCampoPK As String)
        Dim loOBJETO As New Eoitb
        Dim loRow As DataRow = Nothing

        If loOBJETO.GetPK(CInt(poLeerJSON("data")(piPos)(psCampoPK).ToString)) Then
            For Each loRow In poModelo.Rows
                loOBJETO.SetAtributo(loRow.Item("destino").ToString, poLeerJSON("data")(piPos)(loRow.Item("origen").ToString).ToString)
            Next
            Try
                loOBJETO.Put()
            Catch ex As Exception
                GFsAvisar("LPIntegraOITB - Error durante actualizacion: " & ex.Message, sMENSAJE_)
            End Try
        End If
    End Sub

    Private Sub LPIntegraOCPR(ByVal poModelo As DataTable, ByVal poLeerJSON As JObject, ByVal piPos As Integer, ByVal psCampoPK As String)
        Dim loOBJETO As New Eocrd
        Dim loRow As DataRow = Nothing
        Dim liPos As Integer = loOBJETO.GetCurrentLineName_OCPR(poLeerJSON("data")(piPos)("Name").ToString)
        If liPos > -1 Then
            If loOBJETO.GetPK(poLeerJSON("data")(piPos)(psCampoPK).ToString) Then
                loOBJETO.SetCurrentLineOCPR(liPos)
                For Each loRow In poModelo.Rows
                    loOBJETO.SetAtributoOCPR(loRow.Item("destino").ToString, poLeerJSON("data")(piPos)(loRow.Item("origen").ToString).ToString)
                Next
                Try
                    loOBJETO.Put()
                Catch ex As Exception
                    GFsAvisar("LPIntegraOCRD - Error durante actualizacion: " & ex.Message, sMENSAJE_)
                End Try
            End If
        End If
    End Sub

    Private Sub LPIntegraCRD1(ByVal poModelo As DataTable, ByVal poLeerJSON As JObject, ByVal piPos As Integer, ByVal psCampoPK As String)
        Dim loOBJETO As New Eocrd
        Dim loRow As DataRow = Nothing
        Dim liPos As Integer = loOBJETO.GetCurrentLineName_CRD1(poLeerJSON("data")(piPos)("AddressName").ToString)
        If liPos > -1 Then
            If loOBJETO.GetPK(poLeerJSON("data")(piPos)(psCampoPK).ToString) Then
                loOBJETO.SetCurrentLineCRD1(liPos)
                For Each loRow In poModelo.Rows
                    loOBJETO.SetAtributoCRD1(loRow.Item("destino").ToString, poLeerJSON("data")(piPos)(loRow.Item("origen").ToString).ToString)
                Next
                Try
                    loOBJETO.Put()
                Catch ex As Exception
                    GFsAvisar("LPIntegraCRD1 - Error durante actualizacion: " & ex.Message, sMENSAJE_)
                End Try
            End If
        End If
    End Sub

    Private Sub LPIntegraOSLP(ByVal poModelo As DataTable, ByVal poLeerJSON As JObject, ByVal piPos As Integer, ByVal psCampoPK As String)
        Dim loOBJETO As New Eoslp
        Dim loRow As DataRow = Nothing

        If loOBJETO.GetPK(CInt(poLeerJSON("data")(piPos)(psCampoPK).ToString)) Then
            For Each loRow In poModelo.Rows
                loOBJETO.SetAtributo(loRow.Item("destino").ToString, poLeerJSON("data")(piPos)(loRow.Item("origen").ToString).ToString)
            Next
            Try
                loOBJETO.Put()
            Catch ex As Exception
                GFsAvisar("LPIntegraOSLP - Error durante actualizacion: " & ex.Message, sMENSAJE_)
            End Try
        End If
    End Sub
End Module
