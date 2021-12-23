Imports Newtonsoft
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Module modGPIntegracionZoho_SAP_ORDR

    Public Sub GPIntegracionZoho_SAP_ORDR(ByVal psZohoId As String)
        GPBitacoraRegistrar(sENTRO_, "GPIntegracionZoho_SAP --> Zodo Id:" & psZohoId)
        Dim loLeerJSON As JObject = Nothing
        Dim loLeerJSON_VendedorSAP As JObject = Nothing
        Dim loLeerJSON_PR As JObject = Nothing
        Dim lsRespuesta As String = "OK - MIGRACION SAP - "
        Dim lsExisteItemCode As Integer = 0
        Dim Contador As Integer = 0
        Dim lsMensaje As String
        Dim CondicionVenta As String

        Dim lsDatosZoho As String = GFsGetRecord("Sales_Orders", psZohoId, , "zohoid")
        If lsDatosZoho.Trim.Length = 0 Then
            GFsAvisar("Error no se recuperaron datos", sMENSAJE_)

            Exit Sub
        End If
        loLeerJSON = JObject.Parse(lsDatosZoho)
        Dim liCantidad As Integer = CInt(loLeerJSON("data").Count)

        'Obtenemos los datos del presupuesto, para consultar el total.
        Dim lsDatosZoho_PR As String = GFsPythonGetRecord("Quotes", loLeerJSON("data")(0)("Quote_Name")("id").ToString, "", "zohoid")
        loLeerJSON_PR = JObject.Parse(lsDatosZoho_PR)
        Dim liPresupuestos As Integer = CInt(loLeerJSON_PR("data")(0)("Product_Details").Count)

        If liCantidad > 0 Then
            Try
                'Obtenemos el CardCode del Contacto o Cuenta de Zoho.
                Dim loLeerJSON_CC As JObject = Nothing
                Dim psModulo As String = If(loLeerJSON("data")(0)("Account_Name").ToString = "", "Contacts", "Accounts")
                Dim psZohoId_Cliente As String = If(loLeerJSON("data")(0)("Account_Name").ToString = "", loLeerJSON("data")(0)("Contact_Name")("id").ToString, loLeerJSON("data")(0)("Account_Name")("id").ToString)
                Dim lsCOQL_CC As String = GFsGeneraSQL("COQL - OBTENER CARDCODE", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                lsCOQL_CC = lsCOQL_CC.Replace("&Modulo", psModulo.ToString)
                lsCOQL_CC = lsCOQL_CC.Replace("&zohoId", psZohoId_Cliente.ToString)
                Dim lsDatosZoho_CC As String = GFsGetCOQLRecords(lsCOQL_CC)
                If lsDatosZoho_CC.Trim.Length = 0 Then
                    GFsAvisar("COQL: " & lsCOQL_CC.Trim & ", Error no se recuperaron datos", sMENSAJE_)

                    Exit Sub
                End If
                loLeerJSON_CC = JObject.Parse(lsDatosZoho_CC)

                Dim loEordr As New Eordr
                'Obtenemos el ZohoId de la OV, para saber si ya existe en SAP.
                Dim lsZohoId_OV As String = loEordr.ConsultaEscalar("SELECT U_ZohoId FROM ORDR WHERE U_ZohoId = " & psZohoId, "U_ZohoId")

                If lsZohoId_OV = "" Or lsZohoId_OV Is Nothing Then
                    Dim lsMoneda As String = loLeerJSON("data")(0)("Currency").ToString
                    CondicionVenta = If(loLeerJSON("data")(0)("Condici_n_de_Vnetna").ToString = "10- Contado", "54", "-1")

                    'INSERTARMOS DATOS DE LA CABECERA EN SAP
                    loEordr.SetAtributo_ORDR("BPLId", GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP -> Branch CATHAY"))
                    loEordr.SetAtributo_ORDR("CardCode", loLeerJSON_CC("data")(0)("Codigo_CardCode").ToString)
                    loEordr.SetAtributo_ORDR("DocDate", Now.ToString(sFormatoFechaHora1_))
                    loEordr.SetAtributo_ORDR("GroupNum", CondicionVenta)
                    loEordr.SetAtributo_ORDR("DocCur", lsMoneda)
                    loEordr.SetAtributo_ORDR("DocDueDate", Now.ToString(sFormatoFechaHora1_))
                    loEordr.SetAtributo_ORDR("U_ZohoId", loLeerJSON("data")(0)("id").ToString)
                    loEordr.SetAtributo_ORDR("U_plazo", loLeerJSON("data")(0)("Plazo_meses").ToString)
                    loEordr.SetAtributo_ORDR("U_Entrega", If(loLeerJSON("data")(0)("Entrega_inicial").ToString = "", "0", loLeerJSON("data")(0)("Entrega_inicial").ToString))
                    loEordr.SetAtributo_ORDR("U_trueque", If(loLeerJSON("data")(0)("Trueque_Recibido").ToString = "", "0", loLeerJSON("data")(0)("Trueque_Recibido").ToString))
                    'Obtenemos el vendedor del propietario del documento zoho, para enviar a SAP.
                    Dim ZohoId_Propietario As String = loLeerJSON("data")(0)("Created_By")("id").ToString
                    Dim lsVendedorSAP As String = GFsGetRecord("users", ZohoId_Propietario, , "zohoid",, sZohoCRM_Users_ALL_)

                    loLeerJSON_VendedorSAP = JObject.Parse(lsVendedorSAP)

                    loEordr.SetAtributo_ORDR("SlpCode", loLeerJSON_VendedorSAP("users")(0)("Codigo_Vendedor_Sap").ToString())

                    'Obtener datos de Seguro
                    'Dim lsSeguroJson As String = GFsGetRecord("Seguros", loLeerJSON("data")(0)("Deal_Name")("id").ToString, "Oportunidad", "search")
                    'Dim loLeerJSON_Seguro = JObject.Parse(lsSeguroJson)
                    'Dim liContarSeguro As Integer = CInt(loLeerJSON_Seguro("data").Count)
                    'Dim lsSeguro As String
                    'Obtener datos de Garantía
                    Dim lsGarantiaJson As String = GFsGetRecord("Garantias", loLeerJSON("data")(0)("Deal_Name")("id").ToString, "Oportunidad", "search")
                    Dim liContarGarantia As Integer
                    Dim loLeerJSON_Garantia As JObject = Nothing

                    If lsGarantiaJson Is Nothing Or lsGarantiaJson = "" Then
                        liContarGarantia = 0
                    Else
                        loLeerJSON_Garantia = JObject.Parse(lsGarantiaJson)
                        liContarGarantia = CInt(loLeerJSON_Garantia("data").Count)
                    End If

                    Dim lsGarantia As String


                    'INSERTAR DETALLE
                    Dim liOrdenDetalle As Integer = loLeerJSON("data")(0)("Product_Details").Count

                    For I As Integer = 0 To liOrdenDetalle - 1
                        Dim lsItemCode As String = loLeerJSON("data")(0)("Product_Details")(I)("product")("Product_Code").ToString
                        lsExisteItemCode = CInt(loEordr.ConsultaEscalar("SELECT COUNT(*)as Count FROM OITM WHERE ItemCode = '" & lsItemCode & "'", "Count"))
                        If lsExisteItemCode > 0 Then
                            Dim ldCosto As Double = CDbl(loEordr.ConsultaEscalar("SELECT AvgPrice FROM OITM WHERE ItemCode = '" & lsItemCode & "'", "AvgPrice"))
                            Dim ldCotizacion As Double = CDbl(loEordr.ConsultaEscalar("SELECT dbo.F_ObtenerCotizacion(LastPurDat,'" & lsMoneda & "') as Cotizacion FROM OITM WHERE ItemCode = '" & lsItemCode & "'", "Cotizacion"))
                            Dim ldMargen As Double = LFdCalcular_Margen(loLeerJSON("data")(0)("Product_Details")(I)("product")("Product_Code").ToString, lsMoneda, ldCosto, CDbl(loLeerJSON("data")(0)("Product_Details")(I)("total_after_discount").ToString), ldCotizacion)

                            loEordr.SetAtributo_RDR1("ItemCode", lsItemCode)
                            loEordr.SetAtributo_RDR1("Quantiy", loLeerJSON("data")(0)("Product_Details")(I)("quantity").ToString)
                            loEordr.SetAtributo_RDR1("PriceAfVAT", loLeerJSON("data")(0)("Product_Details")(I)("total_after_discount").ToString)
                            loEordr.SetAtributo_RDR1("TaxCode", "IVA_10")
                            loEordr.SetAtributo_RDR1("U_cost", CType(ldCosto, String))
                            loEordr.SetAtributo_RDR1("U_marg", CType(ldMargen, String))

                            'Cargamos el Seguro
                            'If liContarSeguro > 0 Then
                            '    For S As Integer = 0 To liContarSeguro - 1
                            '        If loLeerJSON("data")(0)("Product_Details")(I)("product")("id").ToString = loLeerJSON_Seguro("data")(S)("Producto")("id").ToString Then
                            '            lsSeguro = loLeerJSON_Seguro("data")(S)("Seguro").ToString
                            '            loEordr.SetAtributo_RDR1("U_Seguro", lsSeguro)
                            '            Exit For
                            '        End If
                            '    Next
                            'End If

                            'Cargamos la Garantía
                            If liContarGarantia > 0 Then
                                For G As Integer = 0 To liContarGarantia - 1
                                    If loLeerJSON("data")(0)("Product_Details")(I)("product")("id").ToString = loLeerJSON_Garantia("data")(G)("Producto")("id").ToString Then
                                        lsGarantia = loLeerJSON_Garantia("data")(G)("Meses_de_garantia").ToString
                                        loEordr.SetAtributo_RDR1("U_Garantia", lsGarantia)
                                        Exit For
                                    End If
                                Next
                            End If

                            'Validar que el total de la OV no supere al total del presupuesto
                            For P As Integer = 0 To liPresupuestos - 1
                                If CDbl(loLeerJSON("data")(0)("Grand_Total").ToString) > CDbl(loLeerJSON_PR("data")(0)("Grand_Total").ToString) Then
                                    If loLeerJSON("data")(0)("Product_Details")(I)("product")("id").ToString = loLeerJSON_PR("data")(0)("Product_Details")(P)("product")("id").ToString Then
                                        If CDbl(loLeerJSON("data")(0)("Product_Details")(I)("total_after_discount").ToString) > CDbl(loLeerJSON_PR("data")(0)("Product_Details")(P)("total_after_discount").ToString) Then
                                            Contador = Contador + 1 'Enviamos valor 1 para que no cree el artículo de interes que se inserta fuera del For/Next
                                            lsMensaje = lsMensaje + ", " + loLeerJSON("data")(0)("Product_Details")(I)("product")("Product_Code").ToString
                                            lsRespuesta = "Existen artículos de la OV con Precio mayor al del Presupuesto" + lsMensaje
                                        End If
                                    End If
                                End If
                            Next

                            loEordr.Atributo.Lines.Add()
                            loEordr.Atributo.Lines.SetCurrentLine(loEordr.Atributo.Lines.LineNum)
                        Else
                            Contador = Contador + 1
                            lsRespuesta = "NO SE PUEDE CREAR LA OV EN SAP, PORQUE LA MISMA CUENTA CON ARTÍCULO GENÉRICO"
                            Exit For
                        End If
                        Application.DoEvents()
                    Next
                    If Contador = 0 Then
                        If CondicionVenta <> "54" Then
                            'Agregamos el artículo de interes.
                            Dim lsArticuloInteres As String = If(lsMoneda = "USD", GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP -> ARTICULO PARA FINANCIAMIENTO EN USD"), GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP -> ARTICULO PARA FINANCIAMIENTO EN GS"))

                            loEordr.SetAtributo_RDR1("ItemCode", lsArticuloInteres)
                            loEordr.SetAtributo_RDR1("Quantiy", "1")
                            loEordr.SetAtributo_RDR1("PriceAfVAT", loLeerJSON("data")(0)("Interes").ToString)
                            loEordr.SetAtributo_RDR1("TaxCode", "IVA_10")

                            loEordr.Atributo.Lines.Add()
                            loEordr.Atributo.Lines.SetCurrentLine(loEordr.Atributo.Lines.LineNum)
                        End If

                        lsRespuesta = loEordr.Add()
                        GPBitacoraRegistrar(sAGREGAR_, "Sales_Orders: " & loLeerJSON_CC("data")(0)("Codigo_CardCode").ToString & ", Resultado:" & lsRespuesta)
                    End If
                Else
                    lsRespuesta = "LA ORDEN DE VENTA CON ZOHO ID NRO. " & psZohoId & " YA EXISTE EN SAP"
                End If
            Catch ex As Exception
                lsRespuesta = ex.ToString
            End Try


            'ACTUALIZAMOS EL EXTERNO CARDCODE Y DESCRIPCION EN ZOHO.
            Dim loDatos As New List(Of BulkDatos)
            Dim loBulkDatos As New BulkDatos

            loBulkDatos.sFieldName = "Description"
            loBulkDatos.sFieldValue = CType(IIf(lsRespuesta = sOk_, "OK - MIGRACION SAP - " & Now.ToString(sFormatoFechaHora1_), lsRespuesta), String)
            loDatos.Add(loBulkDatos)

            'If Contador > 0 Then
            loBulkDatos = New BulkDatos
            loBulkDatos.sFieldName = "Sincronizar_con_SAP"
            loBulkDatos.sFieldValue = "False"
            loBulkDatos.sTypeValue = "B"
            loDatos.Add(loBulkDatos)
            'End If

            lsRespuesta = GFsPutRecord("Sales_Orders", loLeerJSON("data")(0)("id").ToString, "", loDatos)
        End If

        GPBitacoraRegistrar(sSALIO_, "GPIntegracionZoho_SAP --> Zodo Id:" & psZohoId)

    End Sub

    Private Function LFdCalcular_Margen(ByVal lsItemCode As String, ByVal lsMoneda As String, ByVal ldCosto As Double, ByVal ldPrecio As Double, ByVal ldCotizacion As Double) As Double
        Dim ldMargen As Double

        If lsMoneda = "USD" Then
            ldMargen = Math.Round(((ldPrecio - (ldCosto / ldCotizacion)) / ldPrecio) * 100, 2)
        Else
            ldMargen = Math.Round(((ldPrecio - ldCosto) / ldPrecio) * 100, 2)
        End If

        Return ldMargen
    End Function

    Class RootObject(Of T)
        Public Property Table As T
    End Class
End Module
