Imports Newtonsoft.Json.Linq

Module modGPIntegracionZoho_SAP_OCPR

    'Cuando el proceso es llamado desde la regla de zoho, se recibe el ZohoId del módulo de Contacto Relacionado.
    'Cuando el proceso es llamado desde el proceso de OCRD, y se necesita actualizar un contacto, se recibe el ZohoId del propio contacto.
    Public Sub GPIntegracionZoho_SAP_OCPR(ByVal psZohoId As String, ByVal piNuevo As Integer)
        GPBitacoraRegistrar(sENTRO_, "GPIntegracionZoho_SAP --> Zodo Id:" & psZohoId & ", Modulo: Contacto Relacionado")
        Dim loLeerJSON As JObject = Nothing
        Dim loLeerJSON_CC As JObject = Nothing
        Dim loLeerJSON_CR As JObject = Nothing
        Dim loDataRow As DataRow
        Dim lsRespuesta As String = "OK - MIGRACION SAP - "
        Dim psModulo As String
        Dim psZohoId_Cliente As String
        Dim liCantidad As Integer

        Try
            If piNuevo = 1 Then
                'Obtenemos el zohoId del Contacto que impactara en OCPR
                Dim lsCOQLCR As String = GFsGeneraSQL("COQL - Contactos Relacionados - OCPR", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                lsCOQLCR = lsCOQLCR.Replace("&zohoId", psZohoId.ToString)
                Dim lsDatosZoho_CR As String = GFsGetCOQLRecords(lsCOQLCR)
                If lsDatosZoho_CR.Trim.Length = 0 Then
                    GFsAvisar("COQL: " & lsCOQLCR.Trim & ", Error no se recuperaron datos", sMENSAJE_)

                    Exit Sub
                End If
                loLeerJSON_CR = JObject.Parse(lsDatosZoho_CR)

                'Recuperamos los datos del contacto en Zoho, para enviar a OCPR
                Dim lsCOQL As String = GFsGeneraSQL("COQL - Consulta Contacts - OCPR", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                lsCOQL = lsCOQL.Replace("&zohoId", loLeerJSON_CR("data")(0)("Codigo_CardCode")("id").ToString)
                Dim lsDatosZoho As String = GFsGetCOQLRecords(lsCOQL)
                If lsDatosZoho.Trim.Length = 0 Then
                    GFsAvisar("COQL: " & lsCOQL.Trim & ", Error no se recuperaron datos", sMENSAJE_)

                    Exit Sub
                End If
                loLeerJSON = JObject.Parse(lsDatosZoho)
                liCantidad = CInt(loLeerJSON("info")("count").ToString)

                'Obtenemos el ZohoId de la cuenta o contacto para obtener su CardCode.
                psModulo = If(loLeerJSON_CR("data")(0)("Contacto_CardCode").ToString = "", "Accounts", "Contacts")

                If psModulo = "Contacts" Then
                    psZohoId_Cliente = loLeerJSON_CR("data")(0)("Contacto_CardCode")("id").ToString
                Else
                    psZohoId_Cliente = loLeerJSON_CR("data")(0)("Cuenta_CardCode")("id").ToString
                End If
                'Obtenemos el CardCode del Contacto o Cuenta de Zoho que sería el cliente en SAP al cual se insertará el contacto en OCPR.
                Dim lsCOQL_CC As String = GFsGeneraSQL("COQL - OBTENER CARDCODE", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                lsCOQL_CC = lsCOQL_CC.Replace("&Modulo", psModulo.ToString)
                lsCOQL_CC = lsCOQL_CC.Replace("&zohoId", psZohoId_Cliente.ToString)
                Dim lsDatosZoho_CC As String = GFsGetCOQLRecords(lsCOQL_CC)
                If lsDatosZoho_CC.Trim.Length = 0 Then
                    GFsAvisar("COQL: " & lsCOQL_CC.Trim & ", Error no se recuperaron datos", sMENSAJE_)
                    Exit Sub
                End If
                loLeerJSON_CC = JObject.Parse(lsDatosZoho_CC)


                If liCantidad > 0 Then
                    Dim liNumtra As Integer
                    Dim lsCampoNativoSAP As String
                    Dim liCampoNativoSAP As Integer

                    'SEGUN EL MODULO OBTENEMOS EL NRO DE TRANSACTION DEL MODELO
                    liNumtra = CInt(GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP ->Contacts - OCPR - Modelo Integracion"))

                    Dim loModelo As DataTable = GFoRecuperaModelo(liNumtra)
                    Dim loEocrd As New Eocrd
                    Dim lsOrigen As String = ""
                    Dim lsDestino As String = ""
                    Dim lsDatos As String = ""

                    'CONSULTAMOS SI EL CLIENTE EXISTE EN SAP PARA INSERTARLE EL CONTACTO
                    If CInt(loEocrd.GetPK(loLeerJSON_CC("data")(0)("Codigo_CardCode").ToString)) <> 0 Then
                        Dim liLinea As Integer
                        'Si el cliente no tiene contacto le restamos -1, para insertar el primer contacto. A partir de ahí el count sigue normal.
                        If loEocrd.GetAtributoOCPR("Name", 0) = "" Then
                            liLinea = loEocrd.Atributo.ContactEmployees.Count - 1
                        Else
                            liLinea = loEocrd.Atributo.ContactEmployees.Count
                        End If


                        'ACTUALIZAMOS DATOS DE CONTACTO EN OCPR SAP.
                        For Each loDataRow In loModelo.Rows
                            If loDataRow.Item("origen").ToString.Trim.Length > 0 And loDataRow.Item("destino").ToString.Trim.Length > 0 Then
                                Call loEocrd.Atributo.ContactEmployees.Add()
                                Call loEocrd.Atributo.ContactEmployees.SetCurrentLine(liLinea)

                                lsOrigen = loDataRow.Item("origen").ToString 'ZOHO
                                lsDestino = loDataRow.Item("destino").ToString 'SAP

                                'Verificamos si el campo es uno nativo de SAP, que no puede ir vacío ni 0
                                lsCampoNativoSAP = GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP-CAMPOS_NATIVOS")
                                liCampoNativoSAP = InStr(1, lsCampoNativoSAP, lsDestino)

                                If liCampoNativoSAP > 0 And (loLeerJSON("data")(0)(lsOrigen).ToString = "" Or loLeerJSON("data")(0)(lsOrigen).ToString Is Nothing) Then
                                    loEocrd.SetAtributoOCPR(lsDestino, "-1")
                                Else
                                    loEocrd.SetAtributoOCPR(lsDestino, loLeerJSON("data")(0)(lsOrigen).ToString)
                                End If

                                'Para registrar en la Bitacora de datos.
                                If lsDatos.Trim.Length = 0 Then
                                    lsDatos = lsOrigen & "-->" & lsDestino & "=" & loLeerJSON("data")(0)(lsOrigen).ToString
                                Else
                                    lsDatos &= ", " & lsOrigen & "-->" & lsDestino & "=" & loLeerJSON("data")(0)(lsOrigen).ToString
                                End If
                            End If
                            Application.DoEvents()
                        Next

                        Dim lsNameOCPR As Integer = liLinea + 1

                        loEocrd.SetAtributoOCPR("Name", "C" + CType(lsNameOCPR, String))

                        'Autonumeramos el valor del Firmante
                        If loLeerJSON_CR("data")(0)("Tipo_contacto").ToString = "FIRMANTE" Then
                            Dim liFirmante As Integer = CInt(loEocrd.ConsultaEscalar("SELECT COUNT(*) as Count FROM OCPR WHERE CardCode = '" & loLeerJSON_CC("data")(0)("Codigo_CardCode").ToString & "' AND ISNULL(LEFT(Fax, 8), 'CONTACTO') = 'FIRMANTE'", "Count")) + 1

                            loEocrd.SetAtributoOCPR("Fax", "FIRMANTE" + CType(liFirmante, String))
                        Else
                            loEocrd.SetAtributoOCPR("Fax", "CONTACTO")
                        End If

                        lsRespuesta = loEocrd.Put()
                        GPBitacoraRegistrar(sMODIFICAR_, "CardCode: " & loLeerJSON("data")(0)("Codigo_CardCode").ToString & ", Datos: " & lsDatos & ", Resultado:" & lsRespuesta)
                    End If

                End If
            ElseIf piNuevo = 0 Then

                'Recuperamos los datos del contacto en Zoho, para enviar a OCPR
                Dim lsCOQL As String = GFsGeneraSQL("COQL - Consulta Contacts - OCPR", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                lsCOQL = lsCOQL.Replace("&zohoId", psZohoId)
                Dim lsDatosZoho As String = GFsGetCOQLRecords(lsCOQL)
                If lsDatosZoho.Trim.Length = 0 Then
                    GFsAvisar("COQL: " & lsCOQL.Trim & ", Error no se recuperaron datos", sMENSAJE_)

                    Exit Sub
                End If
                loLeerJSON = JObject.Parse(lsDatosZoho)
                liCantidad = CInt(loLeerJSON("info")("count").ToString)

                'CONSULTAMOS SI EL CONTACTO TIENE UNA CUENTA O CONTACTO ASIGNADO
                Dim liCantidad_CR As Integer
                Dim lsCOQLCR As String = GFsGeneraSQL("COQL - Contactos Relacionados - Search", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                lsCOQLCR = lsCOQLCR.Replace("&search", "Codigo_CardCode")
                lsCOQLCR = lsCOQLCR.Replace("&zohoId", psZohoId.ToString)
                Dim lsDatosZoho_CR As String = GFsGetCOQLRecords(lsCOQLCR)

                If lsDatosZoho_CR.Trim.Length = 0 Then
                    liCantidad_CR = 0
                Else
                    loLeerJSON_CR = JObject.Parse(lsDatosZoho_CR)
                    liCantidad_CR = CInt(loLeerJSON_CR("info")("count").ToString)
                End If

                If liCantidad_CR > 0 Then
                    For I As Integer = 0 To liCantidad_CR - 1
                        'Obtenemos el ZohoId de la cuenta o contacto para obtener su CardCode.
                        psModulo = If(loLeerJSON_CR("data")(I)("Contacto_CardCode").ToString = "", "Accounts", "Contacts")

                        If psModulo = "Contacts" Then
                            psZohoId_Cliente = loLeerJSON_CR("data")(I)("Contacto_CardCode")("id").ToString
                        Else
                            psZohoId_Cliente = loLeerJSON_CR("data")(I)("Cuenta_CardCode")("id").ToString
                        End If

                        'Obtenemos el CardCode del Contacto o Cuenta de Zoho que sería el cliente en SAP al cual se insertará el contacto en OCPR.
                        Dim lsCOQL_CC As String = GFsGeneraSQL("COQL - OBTENER CARDCODE", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                        lsCOQL_CC = lsCOQL_CC.Replace("&Modulo", psModulo.ToString)
                        lsCOQL_CC = lsCOQL_CC.Replace("&zohoId", psZohoId_Cliente.ToString)
                        Dim lsDatosZoho_CC As String = GFsGetCOQLRecords(lsCOQL_CC)
                        If lsDatosZoho_CC.Trim.Length = 0 Then
                            GFsAvisar("COQL: " & lsCOQL_CC.Trim & ", Error no se recuperaron datos", sMENSAJE_)
                            Exit Sub
                        End If
                        loLeerJSON_CC = JObject.Parse(lsDatosZoho_CC)
                        Dim lsCardCode As String = loLeerJSON_CC("data")(0)("Codigo_CardCode").ToString()

                        If liCantidad > 0 Then
                            Dim liNumtra As Integer
                            Dim lsCampoNativoSAP As String
                            Dim liCampoNativoSAP As Integer

                            'SEGUN EL MODULO OBTENEMOS EL NRO DE TRANSACTION DEL MODELO
                            liNumtra = CInt(GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP ->Contacts - OCPR - Modelo Integracion"))

                            Dim loModelo As DataTable = GFoRecuperaModelo(liNumtra)
                            Dim loEocrd As New Eocrd
                            Dim lsOrigen As String = ""
                            Dim lsDestino As String = ""
                            Dim lsDatos As String = ""

                            'CONSULTAMOS SI EL CLIENTE EXISTE EN SAP PARA INSERTARLE EL CONTACTO
                            If CInt(loEocrd.GetPK(lsCardCode)) <> 0 Then
                                Dim liLinea As Integer
                                Dim liCantContactos As Integer = CInt(loEocrd.ConsultaEscalar("SELECT COUNT(*) as Cantidad FROM OCPR WHERE CardCode = '" & lsCardCode & "'", "Cantidad"))

                                For C As Integer = 0 To liCantContactos - 1
                                    If psZohoId = loEocrd.GetAtributoOCPR("Position", C) Then
                                        liLinea = C
                                    End If
                                Next
                                'ACTUALIZAMOS DATOS DE CONTACTO EN OCPR SAP.
                                For Each loDataRow In loModelo.Rows
                                    If loDataRow.Item("origen").ToString.Trim.Length > 0 And loDataRow.Item("destino").ToString.Trim.Length > 0 Then

                                        Call loEocrd.Atributo.ContactEmployees.SetCurrentLine(liLinea)

                                        lsOrigen = loDataRow.Item("origen").ToString 'ZOHO
                                        lsDestino = loDataRow.Item("destino").ToString 'SAP

                                        'Verificamos si el campo es uno nativo de SAP, que no puede ir vacío ni 0
                                        lsCampoNativoSAP = GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP-CAMPOS_NATIVOS")
                                        liCampoNativoSAP = InStr(1, lsCampoNativoSAP, lsDestino)

                                        If liCampoNativoSAP > 0 And (loLeerJSON("data")(0)(lsOrigen).ToString = "" Or loLeerJSON("data")(0)(lsOrigen).ToString Is Nothing) Then
                                            loEocrd.SetAtributoOCPR(lsDestino, "-1")
                                        Else
                                            loEocrd.SetAtributoOCPR(lsDestino, loLeerJSON("data")(0)(lsOrigen).ToString)
                                        End If

                                        'Para registrar en la Bitacora de datos.
                                        If lsDatos.Trim.Length = 0 Then
                                            lsDatos = lsOrigen & "-->" & lsDestino & "=" & loLeerJSON("data")(0)(lsOrigen).ToString
                                        Else
                                            lsDatos &= ", " & lsOrigen & "-->" & lsDestino & "=" & loLeerJSON("data")(0)(lsOrigen).ToString
                                        End If
                                    End If
                                    Application.DoEvents()
                                Next

                                lsRespuesta = loEocrd.Put()
                                GPBitacoraRegistrar(sMODIFICAR_, "CardCode: " & loLeerJSON("data")(0)("Codigo_CardCode").ToString & ", Datos: " & lsDatos & ", Resultado:" & lsRespuesta)
                            End If

                        End If
                    Next
                End If
            ElseIf piNuevo = 2 Then
                'Obtenemos datos del Contacto Relacionado.
                Dim lsCOQLCR As String = GFsGeneraSQL("COQL - Contactos Relacionados - OCPR", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                lsCOQLCR = lsCOQLCR.Replace("&zohoId", psZohoId.ToString)
                Dim lsDatosZoho_CR As String = GFsGetCOQLRecords(lsCOQLCR)
                If lsDatosZoho_CR.Trim.Length = 0 Then
                    GFsAvisar("COQL: " & lsCOQLCR.Trim & ", Error no se recuperaron datos", sMENSAJE_)

                    Exit Sub
                End If
                loLeerJSON_CR = JObject.Parse(lsDatosZoho_CR)

                'Obtenemos el ZohoId de la cuenta o contacto para obtener su CardCode.
                psModulo = If(loLeerJSON_CR("data")(0)("Contacto_CardCode").ToString = "", "Accounts", "Contacts")

                If psModulo = "Contacts" Then
                    psZohoId_Cliente = loLeerJSON_CR("data")(0)("Contacto_CardCode")("id").ToString
                Else
                    psZohoId_Cliente = loLeerJSON_CR("data")(0)("Cuenta_CardCode")("id").ToString
                End If
                'Obtenemos el CardCode del Contacto o Cuenta de Zoho que sería el cliente en SAP al cual se insertará el contacto en OCPR.
                Dim lsCOQL_CC As String = GFsGeneraSQL("COQL - OBTENER CARDCODE", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                lsCOQL_CC = lsCOQL_CC.Replace("&Modulo", psModulo.ToString)
                lsCOQL_CC = lsCOQL_CC.Replace("&zohoId", psZohoId_Cliente.ToString)
                Dim lsDatosZoho_CC As String = GFsGetCOQLRecords(lsCOQL_CC)
                If lsDatosZoho_CC.Trim.Length = 0 Then
                    GFsAvisar("COQL: " & lsCOQL_CC.Trim & ", Error no se recuperaron datos", sMENSAJE_)
                    Exit Sub
                End If
                loLeerJSON_CC = JObject.Parse(lsDatosZoho_CC)
                Dim lsCardCode As String = loLeerJSON_CC("data")(0)("Codigo_CardCode").ToString()
                'Conectamos con SAP
                Dim loEocrd As New Eocrd

                If CInt(loEocrd.GetPK(lsCardCode)) <> 0 Then
                    Dim liLinea As Integer
                    Dim liCantContactos As Integer = CInt(loEocrd.ConsultaEscalar("SELECT COUNT(*) as Cantidad FROM OCPR WHERE CardCode = '" & lsCardCode & "'", "Cantidad"))

                    For C As Integer = 0 To liCantContactos - 1
                        If loLeerJSON_CR("data")(0)("Codigo_CardCode")("id").ToString = loEocrd.GetAtributoOCPR("Position", C) Then
                            liLinea = C
                        End If
                    Next

                    Call loEocrd.Atributo.ContactEmployees.SetCurrentLine(liLinea)

                    'Autonumeramos el valor del Firmante
                    If loLeerJSON_CR("data")(0)("Tipo_contacto").ToString = "FIRMANTE" Then
                        If Left(loEocrd.GetAtributoOCPR("Fax", liLinea), 8) <> "FIRMANTE" Then
                            Dim liFirmante As Integer = CInt(loEocrd.ConsultaEscalar("SELECT COUNT(*) as Count FROM OCPR WHERE CardCode = '" & lsCardCode & "' AND ISNULL(LEFT(Fax, 8), 'CONTACTO') = 'FIRMANTE'", "Count")) + 1

                            loEocrd.SetAtributoOCPR("Fax", "FIRMANTE" + CType(liFirmante, String))
                        End If
                    Else
                        loEocrd.SetAtributoOCPR("Fax", "CONTACTO")
                    End If
                End If

                lsRespuesta = loEocrd.Put()
                GPBitacoraRegistrar(sMODIFICAR_, "CardCode: " & loLeerJSON("data")(0)("Codigo_CardCode").ToString & ", Resultado:" & lsRespuesta)
            End If
        Catch ex As Exception
            lsRespuesta = ex.ToString
        End Try


        'ACTUALIZAMOS LA DESCRIPCION EN ZOHO.
        Dim loDatos As New List(Of BulkDatos)
        Dim loBulkDatos As New BulkDatos

        'Si no inserta en SAP destildamos el campo Sincronizar con SAP.
        If lsRespuesta <> sOk_ Then
            loBulkDatos.sFieldName = "Sincronizar_con_SAP"
            loBulkDatos.sFieldValue = "False"
            loBulkDatos.sTypeValue = "B"
            loDatos.Add(loBulkDatos)

            loBulkDatos = New BulkDatos
            loBulkDatos.sFieldName = "Descripcion_alta"
            loBulkDatos.sFieldValue = lsRespuesta
            loDatos.Add(loBulkDatos)
        Else
            loBulkDatos = New BulkDatos
            loBulkDatos.sFieldName = "Descripcion_alta"
            loBulkDatos.sFieldValue = CType(IIf(lsRespuesta = sOk_, "OK - MIGRACION SAP - " & Now.ToString(sFormatoFechaHora1_), lsRespuesta), String)
            loDatos.Add(loBulkDatos)
        End If

        lsRespuesta = GFsPutRecord("Contactos_relacionados", psZohoId, "", loDatos)

        GPBitacoraRegistrar(sSALIO_, "GPIntegracionZoho_SAP --> Zodo Id:" & psZohoId & ", Modulo: Contacto Relacionado")
    End Sub

End Module
