Imports Newtonsoft.Json.Linq

Module modGPProcesarDeAUno

    Public Sub GPProcesarDeAUno(ByVal psSQL As String, ByVal psModulo As String, ByVal piNumMod As Integer, Optional ByVal psTabla As String = "OITM", Optional ByVal psFindMethod As String = sZIS_Search_, Optional ByVal psTipAct As String = sBulkUpdate_, Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing, Optional ByVal psFechaHoraAnterior As String = "")
        GPBitacoraRegistrar(sENTRO_, "GPProcesarDeAUno --> Script:" & psSQL & ", Modulo:" & psModulo & ", Modelo:" & piNumMod.ToString & ", Tabla: " & psTabla & ", Find: " & psFindMethod & ", TipActualización: " & psTipAct & ", Bitacora:" & poRegistroOperativo.FileName)
        Dim loMapeo As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim loModelo As DataTable = GFoRecuperaModelo(piNumMod)
        Dim loDataTable As DataTable = GFoRecuperaDataTable(psSQL,, piNumMod, psFechaHoraAnterior)
        Dim loDataRow As DataRow = Nothing
        Dim loBulkData As BulkDatos = Nothing
        Dim lsModeloFields As String = ""
        Dim loColumns As DataColumnCollection = loModelo.Columns
        Dim loColumn As DataColumn
        For Each loDataRow In loModelo.Rows
            loMapeo.Add(loDataRow.Item("destino").ToString, loDataRow.Item("origen").ToString)
        Next
        Dim lsModelo As String = ""
        Dim lsFindBy As String = ""
        Dim lsCampoPK As String = ""
        Dim loZis_ModCab As Ezis_modcab = New Ezis_modcab
        loZis_ModCab.numtra = piNumMod
        If loZis_ModCab.GetPK = sOk_ Then
            lsModelo = loZis_ModCab.destino
            lsFindBy = loZis_ModCab.findby
            lsCampoPK = loZis_ModCab.campopk
        End If
        loZis_ModCab.CerrarConexion()

        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Procesamiento DE A UNO [Modulo:" & psModulo & "] -> Script: " & psSQL & ", Modelo: " & piNumMod.ToString & ", Find Methodo:" & psFindMethod & ", Tipo Act.:" & psTipAct

        loColumns = Nothing
        loColumns = loDataTable.Columns
        For Each loDataRow In loDataTable.Rows
            Dim loListData As List(Of BulkDatos) = New List(Of BulkDatos)
            Dim lsZohoId As JObject = Nothing
            If psFindMethod = sZIS_ZohoId_ And (psTipAct = sBulkUpdate_ Or psTipAct = sBulkUpdate_) Then
                lsZohoId = JObject.Parse(GFsGetRecord(psModulo, loDataRow.Item(lsCampoPK).ToString, lsCampoPK)) 'GFsGetModules
            Else
                lsZohoId = JObject.Parse(GFsGetModules("fields?module=" & psModulo, poRegistroOperativo))
            End If

            loFrmProcesamiento.lblRegistroLeido.Text = "Procesando [" & loDataRow.Item(0).ToString & ", " & loDataRow.Item(1).ToString & "]"
            loFrmProcesamiento.Refresh()

            For Each loColumn In loColumns
                If loMapeo.ContainsKey(loColumn.ColumnName) Then
                    loBulkData = New BulkDatos
                    Dim lbArray As Boolean = False
                    For liPos As Integer = 0 To lsZohoId("fields").Count - 1
                        If lsZohoId("fields")(liPos)("field_label").ToString = loColumn.ColumnName Then
                            If lsZohoId("fields")(liPos)("json_type").ToString = "jsonarray" Then
                                lbArray = True
                                Exit For
                            End If
                        End If
                    Next
                    If lbArray Then
                        loBulkData.sFieldName = loColumn.ColumnName & "[0]"
                    Else
                        loBulkData.sFieldName = loColumn.ColumnName
                    End If
                    loBulkData.sFieldValue = loDataRow.Item(loColumn.ColumnName).ToString
                    loListData.Add(loBulkData)
                End If
            Next
            Dim lsResultado As String = ""
            Select Case psFindMethod
                Case sZIS_ZohoId_
                    Select Case psTipAct
                        Case sBulkInsert_
                            lsResultado = GFsInsertRecords(psModulo, loListData, lsCampoPK, lsFindBy, poRegistroOperativo)
                        Case sBulkUpdate_
                            lsResultado = GFsPutRecord(psModulo, lsZohoId("data")(0)("id").ToString, sNo_, loListData, lsFindBy, poRegistroOperativo)
                        Case sBulkUpsert_
                            lsResultado = GFsUpsertRecord(psModulo, lsZohoId("data")(0)("id").ToString, loListData, lsFindBy,, poRegistroOperativo)
                    End Select
                Case sZIS_Search_
                    Select Case psTipAct
                        Case sBulkInsert_
                            lsResultado = GFsInsertRecords(psModulo, loListData, lsCampoPK, lsFindBy, poRegistroOperativo)
                        Case sBulkUpdate_
                            lsResultado = GFsPutRecord(psModulo, loDataRow.Item(lsCampoPK).ToString, lsCampoPK, loListData, lsFindBy, poRegistroOperativo)
                        Case sBulkUpsert_
                            lsResultado = GFsUpsertRecord(psModulo, loDataRow.Item(lsCampoPK).ToString, loListData, lsFindBy,, poRegistroOperativo)
                    End Select
                Case sZIS_External_
                    Select Case psTipAct
                        Case sBulkInsert_
                            lsResultado = GFsInsertRecords(psModulo, loListData, lsCampoPK, lsFindBy, poRegistroOperativo)
                        Case sBulkUpdate_
                            lsResultado = GFsPutRecord(psModulo, loDataRow.Item(lsCampoPK).ToString, lsCampoPK, loListData,, poRegistroOperativo)
                        Case sBulkUpsert_
                            lsResultado = GFsUpsertRecord(psModulo, loDataRow.Item(lsCampoPK).ToString, loListData, lsFindBy,, poRegistroOperativo)
                    End Select
            End Select
            loListData = Nothing
            Application.DoEvents()
            loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando [" & loDataRow.Item(0).ToString & ", " & loDataRow.Item(1).ToString & "]"
            loFrmProcesamiento.Refresh()
        Next
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        GPBitacoraRegistrar(sSALIO_, "GPProcesarDeAUno --> Script:" & psSQL & ", Modulo:" & psModulo & ", Modelo:" & piNumMod.ToString & ", Tabla: " & psTabla & ", Find: " & psFindMethod & ", TipActualización: " & psTipAct & ", Bitacora:" & poRegistroOperativo.FileName)
    End Sub

End Module
