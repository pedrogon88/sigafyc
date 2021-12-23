Module modGPActualizarEstado_SAP_ZOHO

    Public Sub GPActualizarEstadoSAP_ZOHO()
        GPBitacoraRegistrar(sENTRO_, "ActualizarEstadoSAP_ZOHO")

        Dim loConexion As New BaseDatos
        Dim loDataset As DataSet = Nothing
        Dim psTabla As String = "OITM"
        Dim lsRespuesta As String

        loConexion.SetearParametrosConexion(sRegistryTablasSAP_, psTabla)
        loConexion.Conectar(psTabla)

        Dim lsSQL As String = "SDKTimbo.dbo.spConsultasGenerales"

        Try
            'Obtenemos los datos de las facturas, del procedimiento spConsultasGenerales.
            loConexion.CrearComando(lsSQL, sStoreProc_)
            loDataset = loConexion.EjecutarConsultaDataSet(psTabla)


            Dim row As DataRow
            If loDataset.Tables("OITM").Rows.Count > 0 Then
                For Each row In loDataset.Tables("OITM").Rows
                    Dim loDatos As New List(Of BulkDatos)
                    Dim loBulkDatos As New BulkDatos

                    loBulkDatos.sFieldName = "Status"
                    loBulkDatos.sFieldValue = row.Item("Estado").ToString
                    loDatos.Add(loBulkDatos)

                    loBulkDatos = New BulkDatos
                    loBulkDatos.sFieldName = "Estado_de_Orden_de_Venta"
                    loBulkDatos.sFieldValue = row.Item("Estado").ToString
                    loDatos.Add(loBulkDatos)

                    loBulkDatos = New BulkDatos
                    loBulkDatos.sFieldName = "Description"
                    loBulkDatos.sFieldValue = row.Item("VendedorSAP").ToString
                    loDatos.Add(loBulkDatos)

                    lsRespuesta = GFsPutRecord("Sales_Orders", row.Item("ZohoId").ToString, "", loDatos)
                    'Si el estado fue actualizado en la OV de Zoho, se actualiza el estado de la tabla de OVFacturadas, a Migrado=SI
                    If InStr(1, lsRespuesta, sSUCCESS_) > 0 Then
                        lsSQL = "UPDATE SDKTimbo.dbo.ZIS_OVFacturadas SET Migrado = 'SI' WHERE DocEntry = " & CInt(row.Item("DocEntry"))

                        loConexion.CrearComando(lsSQL)
                        loConexion.EjecutarComando()
                    End If

                    GPBitacoraRegistrar(sMODIFICAR_, "ZohoId: " & row.Item("ZohoId").ToString & ", Resultado:" & lsRespuesta)
                    Application.DoEvents()
                Next
            End If

        Catch ex As Exception
            GFsAvisar("Error: " & ex.Message, sMENSAJE_)
        Finally
            loConexion.Desconectar()
            loConexion = Nothing
        End Try

        GPBitacoraRegistrar(sSALIO_, "ActualizarEstadoSAP_ZOHO")
    End Sub

End Module