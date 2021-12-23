Imports Newtonsoft.Json.Linq

Module modGPIntegracionZoho_SAP_OCRD

    Public Sub GPIntegracionZoho_SAP_OCRD(ByVal psZohoId As String, Optional psModulo As String = "Accounts")
        GPBitacoraRegistrar(sENTRO_, "GPIntegracionZoho_SAP --> Zodo Id:" & psZohoId & ", Modulo: " & psModulo)
        Dim loLeerJSON As JObject = Nothing
        Dim loLeerJSON_VendedorSAP As JObject = Nothing
        Dim loLeerJSON_CR As JObject = Nothing
        Dim loDataRow As DataRow
        Dim lsRespuesta As String = "OK - MIGRACION SAP - "
        Dim lenActividad As Integer
        Dim liNuevo As Integer = 0

        '**************************************

        '**************************************
        Try
            Dim lsCOQL As String = GFsGeneraSQL("COQL - " & psModulo & " - Consulta " & psModulo, sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
            lsCOQL = lsCOQL.Replace("&zohoId", psZohoId.ToString)
            Dim lsDatosZoho As String = GFsGetCOQLRecords(lsCOQL)

            If lsDatosZoho.Trim.Length = 0 Then
                GFsAvisar("COQL: " & lsCOQL.Trim & ", Error no se recuperaron datos", sMENSAJE_)

                Exit Sub
            End If

            loLeerJSON = JObject.Parse(lsDatosZoho)

            Dim liCantidad As Integer = CInt(loLeerJSON("info")("count").ToString)
            If liCantidad > 0 Then
                Dim liNumtra As Integer
                Dim lsCampoNativoSAP As String
                Dim liCampoNativoSAP As Integer

                'SEGUN EL MODULO OBTENEMOS EL NRO DE TRANSACTION DEL MODELO
                liNumtra = CInt(GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP ->" & psModulo & " - Modelo Integracion"))

                Dim loModelo As DataTable = GFoRecuperaModelo(liNumtra)
                Dim loEocrd As New Eocrd
                Dim lsOrigen As String = ""
                Dim lsDestino As String = ""
                Dim lsDatos As String = ""

                'CORTAMOS A PARTIR DEL DIGITO VERIFICADOR, PARA CREAR EL CARDCODE PARA SAP.
                Dim lsRuc As String = If(psModulo = "Accounts", loLeerJSON("data")(0)("RUC").ToString(), loLeerJSON("data")(0)("Nro_RUC").ToString())
                Dim liPosicion As Integer = lsRuc.IndexOf("-")
                Dim lsCardCode As String = If(liPosicion < 0, lsRuc, lsRuc.Substring(0, liPosicion))
                Dim lsCardCode_SAP As String = loLeerJSON("data")(0)("Codigo_CardCode").ToString()


                'CONSULTAMOS SI EL SN YA ESTÁ CREADO EN SAP.
                If CInt(loEocrd.GetPK(lsCardCode_SAP)) = 0 Then
                    liNuevo = 1
                    'INSERTARMOS LOS DATOS EN SAP
                    For Each loDataRow In loModelo.Rows
                        If loDataRow.Item("origen").ToString.Trim.Length > 0 And loDataRow.Item("destino").ToString.Trim.Length > 0 Then
                            lsOrigen = loDataRow.Item("origen").ToString 'ZOHO
                            lsDestino = loDataRow.Item("destino").ToString 'SAP
                            'Verificamos si el campo es uno nativo de SAP, que no puede ir vacío ni 0
                            lsCampoNativoSAP = GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP-CAMPOS_NATIVOS")
                            liCampoNativoSAP = InStr(1, lsCampoNativoSAP, lsDestino)

                            If liCampoNativoSAP > 0 And (loLeerJSON("data")(0)(lsOrigen).ToString = "" Or loLeerJSON("data")(0)(lsOrigen).ToString Is Nothing) Then
                                loEocrd.SetAtributo(lsDestino, "-1")
                            Else
                                loEocrd.SetAtributo(lsDestino, loLeerJSON("data")(0)(lsOrigen).ToString)
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
                    'Cargamos el CardCode y el Ruc que obtuvimos mas arriba
                    loEocrd.SetAtributo("CardCode", lsCardCode)
                    loEocrd.SetAtributo("LicTradNum", lsRuc)
                    'ENVIAMOS EL VALOR PARA ShipType, Persona Fisico/Juridica, dependiendo del módulo. Accounts=Juridica, Contacts=Fisico
                    loEocrd.SetAtributo("ShipType", CType(IIf(psModulo = "Accounts", 2, 1), String))
                    'Enviamos por defecto el grupo ocasional para todos los clientes nuevos.
                    loEocrd.SetAtributo("GroupCode", GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP-GRUPO_PREDETERMINADO"))
                    'Enviamo el valor de la moneda como Monedas Todas.
                    loEocrd.SetAtributo("Currency", GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP-MONEDA_PREDETERMINADA"))
                    'Enviar Actividad Económica
                    liPosicion = loLeerJSON("data")(0)("Actividad").ToString.IndexOf("-") + 2 'Se le suma + 2 porque existe un espacio en cada nombre de actividad en Zoho
                    lenActividad = loLeerJSON("data")(0)("Actividad").ToString.Length - liPosicion
                    Dim Actividad_Zoho As String = If(loLeerJSON("data")(0)("Actividad").ToString() = "", "No definido", loLeerJSON("data")(0)("Actividad").ToString.Substring(liPosicion, lenActividad))
                    Dim Actividad_SAP As Integer = CInt(If(Actividad_Zoho = "No definido", "-1", loEocrd.ConsultaEscalar("SELECT Top 1 IndCode FROM OOND WHERE IndName = '" & Actividad_Zoho & "'", "IndCode")))
                    loEocrd.SetAtributo("IndustryC", CType(Actividad_SAP, String))

                    'Enviar Rubro
                    Dim CampoRubro_zoho As String = If(psModulo = "Accounts", "Industry", "Sector")
                    liPosicion = loLeerJSON("data")(0)(CampoRubro_zoho).ToString.IndexOf("-") + 2 'Se le suma + 2 porque existe un espacio en cada nombre de actividad en Zoho
                    lenActividad = loLeerJSON("data")(0)(CampoRubro_zoho).ToString.Length - liPosicion
                    Dim Rubro_Zoho As String = If(loLeerJSON("data")(0)(CampoRubro_zoho).ToString() = "", "No definido", loLeerJSON("data")(0)(CampoRubro_zoho).ToString.Substring(liPosicion, lenActividad))
                    Dim Rubro_SAP As Integer = CInt(If(Rubro_Zoho = "No definido", "0", loEocrd.ConsultaEscalar("SELECT Code FROM [@RUBROSN] WHERE Name = '" & Rubro_Zoho & "'", "Code")))
                    loEocrd.SetAtributo("U_rubrosn", CType(Rubro_SAP, String))

                    'Obtenemos el vendedor del propietario del documento zoho, para enviar a SAP.
                    Dim ZohoId_Propietario As String = loLeerJSON("data")(0)("Created_By")("id").ToString
                    Dim lsVendedorSAP As String = GFsGetRecord("users", ZohoId_Propietario, , "zohoid",, sZohoCRM_Users_ALL_)
                    Dim lsCodVendedorSAP As String

                    loLeerJSON_VendedorSAP = JObject.Parse(lsVendedorSAP)
                    lsCodVendedorSAP = loLeerJSON_VendedorSAP("users")(0)("Codigo_Vendedor_Sap").ToString()

                    loEocrd.SetAtributo("SlpCode", If(lsCodVendedorSAP = "" Or lsCodVendedorSAP Is Nothing, "-1", lsCodVendedorSAP))

                    lsRespuesta = loEocrd.Add()
                    GPBitacoraRegistrar(sAGREGAR_, "CardCode: " & loLeerJSON("data")(0)("Codigo_CardCode").ToString & ", Datos: " & lsDatos & ", Resultado:" & lsRespuesta)

                Else
                    liNuevo = 0
                    'ACTUALIZAMOS LOS DATOS EN SAP
                    For Each loDataRow In loModelo.Rows
                        If loDataRow.Item("origen").ToString.Trim.Length > 0 And loDataRow.Item("destino").ToString.Trim.Length > 0 Then
                            lsOrigen = loDataRow.Item("origen").ToString 'ZOHO
                            lsDestino = loDataRow.Item("destino").ToString 'SAP
                            'Verificamos si el campo es uno nativo de SAP, que no puede ir vacío ni 0
                            lsCampoNativoSAP = GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP-CAMPOS_NATIVOS")
                            liCampoNativoSAP = InStr(1, lsCampoNativoSAP, lsDestino)

                            If liCampoNativoSAP > 0 And (loLeerJSON("data")(0)(lsOrigen).ToString = "" Or loLeerJSON("data")(0)(lsOrigen).ToString Is Nothing) Then
                                loEocrd.SetAtributo(lsDestino, "-1")
                            Else
                                loEocrd.SetAtributo(lsDestino, loLeerJSON("data")(0)(lsOrigen).ToString)
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

                    'ENVIAMOS EL VALOR PARA ShipType, Persona Fisico/Juridica, dependiendo del módulo. Accounts=Juridica, Contacts=Fisico
                    loEocrd.SetAtributo("ShipType", CType(IIf(psModulo = "Accounts", 2, 1), String))
                    'Enviamos por defecto el grupo ocasional para todos los clientes nuevos.
                    loEocrd.SetAtributo("GroupCode", GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP-GRUPO_PREDETERMINADO"))
                    'Enviamo el valor de la moneda como Monedas Todas.
                    loEocrd.SetAtributo("Currency", GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP-MONEDA_PREDETERMINADA"))
                    'Enviar Actividad Económica
                    liPosicion = loLeerJSON("data")(0)("Actividad").ToString.IndexOf("-") + 2 'Se le suma + 2 porque existe un espacio en cada nombre de actividad en Zoho
                    lenActividad = loLeerJSON("data")(0)("Actividad").ToString.Length - liPosicion
                    Dim Actividad_Zoho As String = If(loLeerJSON("data")(0)("Actividad").ToString() = "", "No definido", loLeerJSON("data")(0)("Actividad").ToString.Substring(liPosicion, lenActividad))
                    Dim Actividad_SAP As Integer = CInt(If(Actividad_Zoho = "No definido", "-1", loEocrd.ConsultaEscalar("SELECT Top 1 IndCode FROM OOND WHERE IndName = '" & Actividad_Zoho & "'", "IndCode")))
                    loEocrd.SetAtributo("IndustryC", CType(Actividad_SAP, String))

                    'Enviar Rubro
                    Dim CampoRubro_zoho As String = If(psModulo = "Accounts", "Industry", "Sector")
                    liPosicion = loLeerJSON("data")(0)(CampoRubro_zoho).ToString.IndexOf("-") + 2 'Se le suma + 2 porque existe un espacio en cada nombre de actividad en Zoho
                    lenActividad = loLeerJSON("data")(0)(CampoRubro_zoho).ToString.Length - liPosicion
                    Dim Rubro_Zoho As String = If(loLeerJSON("data")(0)(CampoRubro_zoho).ToString() = "", "No definido", loLeerJSON("data")(0)(CampoRubro_zoho).ToString.Substring(liPosicion, lenActividad))
                    Dim Rubro_SAP As Integer = CInt(If(Rubro_Zoho = "No definido", "0", loEocrd.ConsultaEscalar("SELECT Code FROM [@RUBROSN] WHERE Name = '" & Rubro_Zoho & "'", "Code")))
                    loEocrd.SetAtributo("U_rubrosn", CType(Rubro_SAP, String))

                    'Obtenemos el vendedor del propietario del documento zoho, para enviar a SAP.
                    Dim ZohoId_Propietario As String = loLeerJSON("data")(0)("Created_By")("id").ToString
                    Dim lsVendedorSAP As String = GFsGetRecord("users", ZohoId_Propietario, , "zohoid",, sZohoCRM_Users_ALL_)
                    Dim lsCodVendedorSAP As String

                    loLeerJSON_VendedorSAP = JObject.Parse(lsVendedorSAP)
                    lsCodVendedorSAP = loLeerJSON_VendedorSAP("users")(0)("Codigo_Vendedor_Sap").ToString()

                    loEocrd.SetAtributo("SlpCode", If(lsCodVendedorSAP = "" Or lsCodVendedorSAP Is Nothing, "-1", lsCodVendedorSAP))

                    lsRespuesta = loEocrd.Put()
                    GPBitacoraRegistrar(sMODIFICAR_, "CardCode: " & loLeerJSON("data")(0)("Codigo_CardCode").ToString & ", Datos: " & lsDatos & ", Resultado:" & lsRespuesta)

                End If

                'ACTUALIZAMOS EL EXTERNO CARDCODE Y DESCRIPCION EN ZOHO.
                Dim loDatos As New List(Of BulkDatos)
                Dim loBulkDatos As New BulkDatos

                If lsRespuesta = sOk_ And liNuevo = 1 Then
                    loBulkDatos.sFieldName = "Externo_CardCode"
                    loBulkDatos.sFieldValue = lsCardCode
                    loDatos.Add(loBulkDatos)

                    loBulkDatos = New BulkDatos
                    loBulkDatos.sFieldName = "Codigo_CardCode"
                    loBulkDatos.sFieldValue = lsCardCode
                    loDatos.Add(loBulkDatos)
                End If
                'Destildamos el campo Sincronizar SAP para la próxima modificación.
                loBulkDatos = New BulkDatos
                loBulkDatos.sFieldName = "Sincronizar_con_SAP"
                loBulkDatos.sFieldValue = "False"
                loBulkDatos.sTypeValue = "B"
                loDatos.Add(loBulkDatos)

                loBulkDatos = New BulkDatos
                loBulkDatos.sFieldName = "Description"
                loBulkDatos.sFieldValue = CType(IIf(lsRespuesta = sOk_, "OK - MIGRACION SAP - " & Now.ToString(sFormatoFechaHora1_), lsRespuesta), String)
                loDatos.Add(loBulkDatos)

                lsRespuesta = GFsPutRecord(psModulo, loLeerJSON("data")(0)("id").ToString, "", loDatos)

                '******************************INSERTAMOS LOS DATOS CORRESPONDIENTES EN LA PESTAÑA DE DIRECCIONES.*******************************************
                If CInt(loEocrd.GetPK(lsCardCode_SAP)) <> 0 Then
                    Dim liLinea As Integer = 0
                    'Si el cliente no tiene Dirección le restamos -1, para insertar el primer registro. A partir de ahí el count sigue normal.
                    If loEocrd.GetAtributoCRD1("Address", 0) = "" Then
                        liLinea = loEocrd.Atributo.Addresses.Count - 1
                    Else
                        liLinea = loEocrd.Atributo.Addresses.Count
                    End If

                    'OBTENEMOS EL NRO DE TRANSACTION DEL MODELO PARA DIRECCIONES
                    liNumtra = CInt(GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP ->DIREECCIONES " & psModulo & " - CRD1 - MODELO INTEGRACION"))
                    Dim loModelo_Direcciones As DataTable = GFoRecuperaModelo(liNumtra)

                    For Each loDataRow In loModelo_Direcciones.Rows
                        If loDataRow.Item("origen").ToString.Trim.Length > 0 And loDataRow.Item("destino").ToString.Trim.Length > 0 Then
                            If liLinea = 0 Then 'Si es 0 es porque se va a insertar, si no es porque se va a modificar, pero siempre se modifica el primero en SAP.
                                Call loEocrd.Atributo.Addresses.Add()
                            Else
                                liLinea = 0 'Se deja en 0 porque en Zoho hay solo una dirección, y si se modifica en zoho, se modifiará siempre el primero en SAP.
                            End If

                            Call loEocrd.Atributo.Addresses.SetCurrentLine(liLinea)

                            lsOrigen = loDataRow.Item("origen").ToString 'ZOHO
                            lsDestino = loDataRow.Item("destino").ToString 'SAP

                            'Verificamos si el campo es uno nativo de SAP, que no puede ir vacío ni 0
                            lsCampoNativoSAP = GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP-CAMPOS_NATIVOS")
                            liCampoNativoSAP = InStr(1, lsCampoNativoSAP, lsDestino)

                            If liCampoNativoSAP > 0 And (loLeerJSON("data")(0)(lsOrigen).ToString = "" Or loLeerJSON("data")(0)(lsOrigen).ToString Is Nothing) Then
                                loEocrd.SetAtributoCRD1(lsDestino, "-1")
                            Else
                                loEocrd.SetAtributoCRD1(lsDestino, loLeerJSON("data")(0)(lsOrigen).ToString)
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
                    'Armamos el código de la dirección dependiendo de la Linea que se va a insertar.
                    Dim lsNameOCPR As Integer = liLinea + 1

                    loEocrd.SetAtributoCRD1("Address", "D" + CType(lsNameOCPR, String))
                    loEocrd.SetAtributoCRD1("AdresType", "bo_BillTo")

                    lsRespuesta = loEocrd.Put()
                End If

                '****************************************INSERTAMOS LOS DATOS CORRESPONDIENTES A LA PESTAÑA DE PERSONA DE CONTACTO*********************************
                If liNuevo = 1 Then ' Solo si el cliente no existía en SAP y ya se le había asignado un contacto en Zoho.
                    Dim liCantidad_CR As Integer
                    Dim lsCOQLCR As String = GFsGeneraSQL("COQL - Contactos Relacionados - Search", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
                    lsCOQLCR = lsCOQLCR.Replace("&search", If(psModulo.ToString = "Accounts", "Cuenta_CardCode", "Contacto_CardCode"))
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
                            GPIntegracionZoho_SAP_OCPR(loLeerJSON_CR("data")(I)("id").ToString, 1)
                        Next
                    End If
                End If

                'SI ES UN CONTACTO ACTUALIZAMOS TAMBIÉN EN OCPR SI EXISTE.
                If psModulo = "Contacts" Then
                    GPIntegracionZoho_SAP_OCPR(psZohoId, 0)
                End If


                GPBitacoraRegistrar(sSALIO_, "GPIntegracionZoho_SAP --> Zodo Id:" & psZohoId & ", Modulo: " & psModulo)

            End If
        Catch ex As Exception
            lsRespuesta = ex.ToString

            'ACTUALIZAMOS EL ERROR EN LA DESCRIPCIÓN.
            Dim loDatos As New List(Of BulkDatos)
            Dim loBulkDatos As New BulkDatos

            loBulkDatos.sFieldName = "Description"
            loBulkDatos.sFieldValue = lsRespuesta
            loDatos.Add(loBulkDatos)

            'Destildamos el campo Sincronizar SAP para la próxima modificación.
            loBulkDatos = New BulkDatos
            loBulkDatos.sFieldName = "Sincronizar_con_SAP"
            loBulkDatos.sFieldValue = "False"
            loBulkDatos.sTypeValue = "B"
            loDatos.Add(loBulkDatos)

            lsRespuesta = GFsPutRecord(psModulo, loLeerJSON("data")(0)("id").ToString, "", loDatos)
        End Try
    End Sub

End Module
