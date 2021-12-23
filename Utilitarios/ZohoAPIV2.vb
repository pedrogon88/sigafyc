Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports System.Text

Module ZohoAPIV2

    Public Sub GPGetRefreshToken(ByVal psScope As String, Optional ByVal psCode As String = sRESERVADO_, Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing)
        Dim lsCode As String = ""
        If psCode = sRESERVADO_ Then
            Dim lsRama As String = sRegistryZohoAPICode_ & psScope & sDS_
            Dim lsRamaGeneral As String = sRegistryZohoAPICode_ & sGeneral_ & sDS_
            lsCode = LFsObtieneParametro("Code_", lsRama, lsRamaGeneral)
            If lsCode = sRESERVADO_ Then Exit Sub
        Else
            lsCode = psCode
        End If

        Dim loRequest As HttpWebRequest = CType(WebRequest.Create("https://accounts.zoho.com/oauth/v2/token?grant_type=authorization_code&client_id=" & sZohoClientId_ & "&client_secret=" & sZohoClientSecret_ & "&code=" & lsCode), HttpWebRequest)
        loRequest.Method = "POST"
        loRequest.ContentType = "application/x-www-form-urlencoded"
        loRequest.KeepAlive = True
        Dim loResponse As HttpWebResponse

        Try
            loResponse = CType(loRequest.GetResponse(), HttpWebResponse)
        Catch e As WebException

            If e.Response Is Nothing Then
                Throw
            End If

            loResponse = CType(e.Response, HttpWebResponse)
        End Try

        Dim loResponseEntity As HttpWebResponse = loResponse
        GPBitacoraRegistrar(sWRESPONSE_, "HTTP Status Code : " & CInt(loResponse.StatusCode))
        Dim lsResponsestring As String = New StreamReader(loResponseEntity.GetResponseStream()).ReadToEnd()
        GPBitacoraRegistrar(sWDATA_, lsResponsestring)
        loResponseEntity.Close()

        Dim loLeerJSON As JObject = JObject.Parse(lsResponsestring)
        Dim lsError As String = CStr(loLeerJSON("error"))
        Dim lsMsgError As String = GFsZohoError(lsResponsestring)
        If lsMsgError = sOk_ Then
            Dim lsAccessToken As String = CStr(loLeerJSON("access_token"))
            Dim lsRefreshToken As String = CStr(loLeerJSON("refresh_token"))
            GPTokenGuardar(psScope, lsRefreshToken, lsAccessToken)
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If
    End Sub

    Public Function GFsGetAccessToken(ByVal psScope As String, ByVal psRefreshToken As String, Optional ByVal psGrantType As String = "refresh_token", Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        Dim lsResultado As String = ""
        Dim loRequest As HttpWebRequest = CType(WebRequest.Create("https://accounts.zoho.com/oauth/v2/token?refresh_token=" & psRefreshToken & "&client_id=" & sZohoClientId_ & "&client_secret=" & sZohoClientSecret_ & "&grant_type=" & psGrantType), HttpWebRequest)
        loRequest.Method = "POST"
        loRequest.KeepAlive = True
        Dim loResponse As HttpWebResponse

        Try
            loResponse = CType(loRequest.GetResponse(), HttpWebResponse)
        Catch e As WebException

            If e.Response Is Nothing Then
                Throw
            End If

            loResponse = CType(e.Response, HttpWebResponse)
        End Try

        Dim loResponseEntity As HttpWebResponse = loResponse
        GPBitacoraRegistrar(sWRESPONSE_, "HTTP Status Code : " & CInt(loResponse.StatusCode))

        Dim lsResponsestring As String = New StreamReader(loResponseEntity.GetResponseStream()).ReadToEnd()
        GPBitacoraRegistrar(sWDATA_, lsResponsestring)
        loResponseEntity.Close()

        Dim lsMsgError As String = GFsZohoError(lsResponsestring)
        If lsMsgError = sOk_ Then
            Dim loLeerJSON As JObject = JObject.Parse(lsResponsestring)
            Dim lsAccessToken As String = CStr(loLeerJSON("access_token"))
            GPTokenGuardar(psScope, psRefreshToken, lsAccessToken)
            lsResultado = lsAccessToken
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If
        Return lsResultado
    End Function

    Public Sub GPTokenGuardar(ByVal psScope As String, ByVal psRefreshToken As String, ByVal psAccessToken As String, Optional ByVal psTipo As String = sGeneral_)
        Dim lsResultado As String = ""
        Dim lsClave As String = "Zoho API V2 - Tabla de Tokens"
        Dim lsSS030_codigo As String = GFsParametroObtener(psTipo, lsClave)

        Dim loDatos As New Ess040tabdet
        loDatos.ss010_codigo = SesionActiva.sistema
        loDatos.ss030_codigo = lsSS030_codigo
        loDatos.codigo = psScope
        If loDatos.GetPK = sSinRegistros_ Then
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsSS030_codigo
            loDatos.codigo = psScope
            loDatos.nombre = psRefreshToken
            loDatos.detalle = psAccessToken & "|" & Now.ToString(sFormatoFechaHora1_)
            Try
                loDatos.Add(sNo_, sNo_)
            Catch ex As Exception
                GFsAvisar("ZohoAPIV2.GFsTokenGuardar.Add()", sMENSAJE_, ex.Message)
            End Try
        Else
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsSS030_codigo
            loDatos.codigo = psScope
            loDatos.nombre = psRefreshToken
            loDatos.detalle = psAccessToken & "|" & Now.ToString(sFormatoFechaHora1_)
            Try
                loDatos.Put(sNo_, sNo_)
            Catch ex As Exception
                GFsAvisar("ZohoAPIV2.GFsTokenGuardar.Put()", sMENSAJE_, ex.Message)
            End Try
        End If

        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Public Function GFsAccessTokenGet(ByVal psScope As String, Optional ByVal psTipo As String = sGeneral_) As String
        Dim lsResultado As String = ""
        Dim lsClave As String = "Zoho API V2 - Tabla de Tokens"
        Dim lsSS030_codigo As String = GFsParametroObtener(psTipo, lsClave)

        Dim loDatos As New Ess040tabdet
        loDatos.ss010_codigo = SesionActiva.sistema
        loDatos.ss030_codigo = lsSS030_codigo
        loDatos.codigo = psScope
        If loDatos.GetPK = sOk_ Then
            Dim loResultado() As String = loDatos.detalle.Split(sSF_)
            Dim loTiempoRestante As TimeSpan = Now.Subtract(Date.Parse(loResultado(1).ToString))
            Dim ldTiempoLimite As Double = Double.Parse(GFsParametroObtener(sGeneral_, sPK_AccessTokenValidez_))
            If 3600 - loTiempoRestante.TotalSeconds > Double.Parse(GFsParametroObtener(sGeneral_, sPK_AccessTokenValidez_)) Then
                lsResultado = loResultado(0)
            Else
                lsResultado = GFsGetAccessToken(psScope, loDatos.nombre)
            End If
        Else
            lsResultado = sError_ & ": GFsAccessTokenGet --> SCOPE aun no definido!"
            GPBitacoraRegistrar(sError_, lsResultado)
        End If

        loDatos.CerrarConexion()
        loDatos = Nothing
        GPBitacoraRegistrar(sINFORMAR_, "GFsAccessTokenGet --> Valor a retornar: " & lsResultado)
        Return lsResultado
    End Function

    Public Sub GPAgregaZohoScope()
        Dim lsClave As String = ""
        lsClave = "Zoho - Ubicacion - Archivo Scope"
        Dim lsUbicacion As String = GFsParametroObtener(sUsuario_, lsClave, sNo_)
        If lsUbicacion = sRESERVADO_ Then Exit Sub

        lsClave = "Zoho - Archivo Scope"
        Dim lsArchivo As String = GFsParametroObtener(sUsuario_, lsClave, sNo_)
        If lsArchivo = sRESERVADO_ Then Exit Sub
        GPBitacoraRegistrar(sENTRO_, "GPAgregaZohoScope - Procesar archivo: " & lsArchivo & ", Ubicado en:" & lsUbicacion)

        Dim lsFileName As String = lsUbicacion & sDS_ & lsArchivo
        If Not File.Exists(lsFileName) Then
            GFsAvisar("El archivo menu [" & lsArchivo & "] no esta definido", sViolacion_, "Consulte con el Dpto. de Informatica.")
            Exit Sub
        End If

        Dim loStreamReader As StreamReader = New StreamReader(lsFileName)
        Dim lsLinea As String = ""
        Dim loLinea() As String
        Do
            lsLinea = loStreamReader.ReadLine()
            If lsLinea Is Nothing Then Exit Do

            loLinea = lsLinea.Split(sSF_)
            GPGetRefreshToken(loLinea(0), loLinea(1))
            GPBitacoraRegistrar(sAGREGAR_, lsLinea)
        Loop
        loStreamReader.Close()
        loStreamReader = Nothing

        lsClave = "Zoho - Ubicacion - Archivo Scope"
        GPParametroGuardar(sUsuario_, lsClave, sRESERVADO_, sNo_)

        lsClave = "Zoho - Archivo Scope"
        GPParametroGuardar(sUsuario_, lsClave, sRESERVADO_, sNo_)
        GPBitacoraRegistrar(sSALIO_, "GPAgregaZohoScope - Procesar archivo: " & lsArchivo & ", Ubicado en:" & lsUbicacion)
    End Sub

    Public Function GFsGetOrganization(Optional ByVal psCampo As String = "zgid", Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        Dim loRequest As HttpWebRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/org"), HttpWebRequest)
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoCRM_Organization_ALL_)
        If lsAccessToken.Trim.Length = 0 Then
            lsAccessToken = "ERROR: NO SE OBTUVO ACCESS TOKEN"
        End If
        If lsAccessToken.Substring(0, sError_.Length) = sError_ Then
            Return lsAccessToken
            Exit Function
        End If
        Dim lsResultado As String = ""
        loRequest.Method = "GET"
        loRequest.Headers("Authorization") = "Zoho-oauthtoken " & lsAccessToken
        loRequest.KeepAlive = True
        Dim loResponse As HttpWebResponse

        Try
            loResponse = CType(loRequest.GetResponse(), HttpWebResponse)
        Catch e As WebException

            If e.Response Is Nothing Then
                Throw
            End If

            loResponse = CType(e.Response, HttpWebResponse)
        End Try

        Dim loResponseEntity As HttpWebResponse = loResponse
        GPBitacoraRegistrar(sWRESPONSE_, "HTTP Status Code : " & CInt(loResponse.StatusCode))
        Dim lsResponsestring As String = New StreamReader(loResponseEntity.GetResponseStream()).ReadToEnd()
        GPBitacoraRegistrar(sWDATA_, lsResponsestring)

        Dim lsMsgError As String = GFsZohoError(lsResponsestring)
        If lsMsgError = sOk_ Then
            Dim loLeerJSON As JObject = JObject.Parse(lsResponsestring)
            Dim lsOrgCode As String = CStr(loLeerJSON("org")(0)(psCampo))
            lsResultado = lsOrgCode
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If
        loResponseEntity.Close()
        Return lsResultado
    End Function

    Public Function GFsGetModules(Optional ByVal psModulo As String = "modules/Colaboradores", Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        Dim lsScope As String = sZohoCRM_Settings_ALL_
        If psModulo.Substring(0, 6) = "module" Then
            lsScope = sZohoCRM_Settings_Modules_ALL_
        Else
            If psModulo.Substring(0, 6) = "fields" Then
                lsScope = sZohoCRM_Settings_Fields_ALL_
            End If
        End If
        Dim lsAccessToken As String = GFsAccessTokenGet(lsScope)
        If lsAccessToken.Substring(0, sError_.Length) = sError_ Then
            Return lsAccessToken
            Exit Function
        End If
        Dim lsResultado As String = ""

        Dim loRequest As HttpWebRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/settings/" & psModulo), HttpWebRequest)
        loRequest.Method = "GET"
        loRequest.Headers("Authorization") = "Zoho-oauthtoken " & lsAccessToken
        loRequest.KeepAlive = True
        Dim loResponse As HttpWebResponse
        Try
            loResponse = CType(loRequest.GetResponse, HttpWebResponse)
        Catch e As WebException
            If (e.Response Is Nothing) Then
                Throw
            End If

            loResponse = CType(e.Response, HttpWebResponse)
        End Try

        Dim loResponseEntity As HttpWebResponse = loResponse
        GPBitacoraRegistrar(sWRESPONSE_, "HTTP Status Code : " + CType(loResponse.StatusCode, Integer).ToString)
        Dim lsResponsestring As String = (New StreamReader(loResponseEntity.GetResponseStream).ReadToEnd)
        loResponseEntity.Close()
        GPBitacoraRegistrar(sWDATA_, lsResponsestring)

        Dim lsMsgError As String = GFsZohoError(lsResponsestring)
        If lsMsgError = sOk_ Then
            lsResultado = lsResponsestring
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If

        Return lsResultado
    End Function

    Public Sub GPCargarTablasSettingsZoho(Optional psPermitidas As String = "", Optional psEliminarDetalle As String = sNo_)
        Dim lsApiNamePermitidos As String = psPermitidas
        If lsApiNamePermitidos.Trim.Length = 0 Then
            lsApiNamePermitidos = GFsParametroObtener(sGeneral_, "ZohoAPI V2 - Modulos Permitidos")
        End If
        Dim lsTipo As String = ""
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsCodigo As String = ""

        lsTipo = sGeneral_
        lsClave = "Zoho API V2 - Tabla Modulos"
        lsValor = "ZohoAPIV2_Tabla_Modulos"
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        Dim lsModulos As String = GFsGetModules("modules")

        Dim loLeerJSON As JObject = JObject.Parse(lsModulos)
        Dim liCantidad As Integer = loLeerJSON("modules").Count

        '-------Encabezado para iniciar despliegue de formulario---------------
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Procesando Metada del Zoho [Modulo]"

        Dim loDatos As New Ess040tabdet
        For liPos = 0 To liCantidad - 1
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsCodigo
            loDatos.codigo = loLeerJSON("modules")(liPos)("api_name").ToString
            '-------Despliega registros leidos---------------
            loFrmProcesamiento.lblRegistroLeido.Text = "Leyendo [" & loDatos.codigo & "]"
            loFrmProcesamiento.Refresh()

            If InStr(lsApiNamePermitidos, loDatos.codigo, CompareMethod.Text) > 0 Then
                If loDatos.GetPK = sSinRegistros_ Then
                    loDatos.ss010_codigo = SesionActiva.sistema
                    loDatos.ss030_codigo = lsCodigo
                    loDatos.codigo = loLeerJSON("modules")(liPos)("api_name").ToString
                    loDatos.nombre = "ZohoAPIV2_Tabla_Camposx" & loLeerJSON("modules")(liPos)("api_name").ToString
                    loDatos.detalle = loLeerJSON.ToString
                    Try
                        loDatos.Add(sNo_, sNo_)
                    Catch ex As Exception
                        GFsAvisar("GPCargarTablasSettingsZoho.Add()", sMENSAJE_, ex.Message)
                    End Try
                    '-------Despliega registros procesados---------------
                    loFrmProcesamiento.lblRegistroProcesado.Text = "Agregando [" & loDatos.codigo & "]"
                    loFrmProcesamiento.Refresh()
                Else
                    loDatos.ss010_codigo = SesionActiva.sistema
                    loDatos.ss030_codigo = lsCodigo
                    loDatos.codigo = loLeerJSON("modules")(liPos)("api_name").ToString
                    loDatos.nombre = "ZohoAPIV2_Tabla_Camposx" & loLeerJSON("modules")(liPos)("api_name").ToString
                    loDatos.detalle = loLeerJSON.ToString
                    Try
                        loDatos.Put(sNo_, sNo_)
                    Catch ex As Exception
                        GFsAvisar("GPCargarTablasSettingsZoho.Put()", sMENSAJE_, ex.Message)
                    End Try
                    loFrmProcesamiento.lblRegistroProcesado.Text = "Actualizando [" & loDatos.codigo & "]"
                    loFrmProcesamiento.Refresh()
                End If
                Dim lsApiName As String = loLeerJSON("modules")(liPos)("api_name").ToString
                If psEliminarDetalle = sSi_ Then
                    GPEliminarTablasSettingsFieldsZoho(lsApiName)
                End If
                GPCargarTablasSettingsFieldsZoho(lsApiName)
            End If
        Next
        '-------Encabezado para iniciar despliegue de formulario---------------
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Public Sub GPCargarTablasSettingsFieldsZoho(ByVal psCodigo As String)
        Dim lsTipo As String = ""
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsCodigo As String = ""

        lsTipo = sGeneral_
        lsClave = "Zoho API V2 - Tabla Campos X " & psCodigo
        lsValor = "ZohoAPIV2_Tabla_Camposx" & psCodigo
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        Dim lsModulos As String = GFsGetModules("fields?module=" & psCodigo)

        Dim loLeerJSON As JObject = JObject.Parse(lsModulos)
        Dim liCantidad As Integer = loLeerJSON("fields").Count

        '-------Encabezado para iniciar despliegue de formulario---------------
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Procesando Metada/Campos Zoho Modulo [" & psCodigo & "]"

        Dim loDatos As New Ess040tabdet
        For liPos = 0 To liCantidad - 1
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsCodigo
            loDatos.codigo = loLeerJSON("fields")(liPos)("api_name").ToString
            '-------Despliega registros leidos---------------
            loFrmProcesamiento.lblRegistroLeido.Text = "Leyendo [Modulo:" & lsCodigo & ", Campo:" & loDatos.codigo & "]"
            loFrmProcesamiento.Refresh()
            If loDatos.GetPK = sSinRegistros_ Then
                loDatos.ss010_codigo = SesionActiva.sistema
                loDatos.ss030_codigo = lsCodigo
                loDatos.codigo = loLeerJSON("fields")(liPos)("api_name").ToString
                loDatos.nombre = loLeerJSON("fields")(liPos)("field_label").ToString
                loDatos.detalle = loLeerJSON.ToString
                Try
                    loDatos.Add(sNo_, sNo_)
                Catch ex As Exception
                    GFsAvisar("GPCargarTablasSettingsZoho.Add()", sMENSAJE_, ex.Message)
                End Try
                loFrmProcesamiento.lblRegistroProcesado.Text = "Agregando [Modulo:" & lsCodigo & ", Campo:" & loDatos.codigo & "]"
                loFrmProcesamiento.Refresh()
            Else
                loDatos.ss010_codigo = SesionActiva.sistema
                loDatos.ss030_codigo = lsCodigo
                loDatos.codigo = loLeerJSON("fields")(liPos)("api_name").ToString
                loDatos.nombre = loLeerJSON("fields")(liPos)("field_label").ToString
                loDatos.detalle = loLeerJSON.ToString
                Try
                    loDatos.Put(sNo_, sNo_)
                Catch ex As Exception
                    GFsAvisar("GPCargarTablasSettingsZoho.Put()", sMENSAJE_, ex.Message)
                End Try
                loFrmProcesamiento.lblRegistroProcesado.Text = "Actualizando [Modulo:" & lsCodigo & ", Campo:" & loDatos.codigo & "]"
                loFrmProcesamiento.Refresh()
            End If
        Next
        '-------Encabezado para iniciar despliegue de formulario---------------
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Public Sub GPEliminarTablasSettingsFieldsZoho(ByVal psCodigo As String)
        Dim lsTipo As String = ""
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsCodigo As String = ""

        lsTipo = sGeneral_
        lsClave = "Zoho API V2 - Tabla Campos X " & psCodigo
        lsValor = "ZohoAPIV2_Tabla_Camposx" & psCodigo
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        Dim lsModulos As String = GFsGetModules("fields?module=" & psCodigo)

        Dim loLeerJSON As JObject = JObject.Parse(lsModulos)
        Dim liCantidad As Integer = loLeerJSON("fields").Count

        '-------Encabezado para iniciar despliegue de formulario---------------
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Eliminando Metada/Campos Zoho Modulo [" & psCodigo & "]"

        Dim loDatos As New Ess040tabdet
        For liPos = 0 To liCantidad - 1
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsCodigo
            loDatos.codigo = loLeerJSON("fields")(liPos)("api_name").ToString
            '-------Despliega registros leidos---------------
            loFrmProcesamiento.lblRegistroLeido.Text = "Leyendo [Modulo:" & lsCodigo & ", Campo:" & loDatos.codigo & "]"
            loFrmProcesamiento.Refresh()
            If loDatos.GetPK = sOk_ Then
                loDatos.ss010_codigo = SesionActiva.sistema
                loDatos.ss030_codigo = lsCodigo
                loDatos.codigo = loLeerJSON("fields")(liPos)("api_name").ToString
                Try
                    loDatos.Del(sNo_, sNo_)
                Catch ex As Exception
                    GFsAvisar("GPEliminarTablasSettingsFieldsZoho.Del()", sMENSAJE_, ex.Message)
                End Try
                loFrmProcesamiento.lblRegistroProcesado.Text = "Eliminando [Modulo:" & lsCodigo & ", Campo:" & loDatos.codigo & "]"
                loFrmProcesamiento.Refresh()
            End If
        Next
        '-------Encabezado para iniciar despliegue de formulario---------------
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Public Sub GPCargarTablasSAP(Optional psPermitidas As String = "", Optional psEliminarDetalle As String = sNo_)
        Dim lsTablasPermitidas As String = psPermitidas
        If psPermitidas.Trim.Length = 0 Then
            lsTablasPermitidas = GFsParametroObtener(sGeneral_, "ZohoAPI V2 - Tablas SAP Permitidas")
        End If
        Dim lsNombre As String = "ZohoAPIV2_TablaSAP_Camposx"
        Dim lsTipo As String = ""
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsCodigo As String = ""

        lsTipo = sGeneral_
        lsClave = "Zoho API V2 - Tabla SAP"
        lsValor = "ZohoAPIV2_Tabla_SAP"
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)
        Dim lsTablaPermitida() As String = lsTablasPermitidas.Split(sSF_)

        Dim liCantidad As Integer = lsTablaPermitida.Count
        '-------Encabezado para iniciar despliegue de formulario---------------
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Procesamiento [Modulo:" & lsCodigo & "]"

        Dim loDatos As New Ess040tabdet
        For liPos = 0 To liCantidad - 1
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsCodigo
            loDatos.codigo = lsTablaPermitida(liPos)
            '-------Despliega registros leidos---------------
            loFrmProcesamiento.lblRegistroLeido.Text = "Leyendo [Modulo:" & lsCodigo & ", " & loDatos.codigo & "]"
            loFrmProcesamiento.Refresh()
            If loDatos.GetPK = sSinRegistros_ Then
                loDatos.ss010_codigo = SesionActiva.sistema
                loDatos.ss030_codigo = lsCodigo
                loDatos.codigo = lsTablaPermitida(liPos)
                loDatos.nombre = lsNombre & lsTablaPermitida(liPos)
                loDatos.detalle = sRESERVADO_
                Try
                    loDatos.Add(sNo_, sNo_)
                Catch ex As Exception
                    GFsAvisar("GPCargarTablasSAP.Add()", sMENSAJE_, ex.Message)
                End Try
                '-------Despliega registros leidos---------------
                loFrmProcesamiento.lblRegistroProcesado.Text = "Agregando [Modulo:" & lsCodigo & ", " & loDatos.codigo & "]"
                loFrmProcesamiento.Refresh()
            Else
                loDatos.ss010_codigo = SesionActiva.sistema
                loDatos.ss030_codigo = lsCodigo
                loDatos.codigo = lsTablaPermitida(liPos)
                loDatos.nombre = lsNombre & lsTablaPermitida(liPos)
                loDatos.detalle = sRESERVADO_
                Try
                    loDatos.Put(sNo_, sNo_)
                Catch ex As Exception
                    GFsAvisar("GPCargarTablasSAP.Put()", sMENSAJE_, ex.Message)
                End Try
                '-------Despliega registros leidos---------------
                loFrmProcesamiento.lblRegistroProcesado.Text = "Actualizando [Modulo:" & lsCodigo & ", " & loDatos.codigo & "]"
                loFrmProcesamiento.Refresh()
            End If
            Dim lsTablaSAP As String = lsTablaPermitida(liPos)
            If psEliminarDetalle = sSi_ Then
                GPTablaGralEliminarDetalle(lsTablaSAP, loDatos.nombre)
            End If
            GPCargarTablasSAPFields(lsTablaSAP, loDatos.nombre)
        Next
        '-------Encabezado para iniciar despliegue de formulario---------------
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Public Sub GPCargarTablasSAPFields(ByVal psCodigo As String, ByVal psValor As String, Optional psEliminarDetalle As String = sNo_)
        Dim lsTipo As String = ""
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsCodigo As String = ""

        lsTipo = sGeneral_
        lsClave = "Zoho API V2 - Tabla SAP Campos X " & psCodigo
        lsValor = psValor
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        '-------Encabezado para iniciar despliegue de formulario---------------
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Procesamiento [Tabla:" & psCodigo & "," & psValor & "]"

        Dim loDatos As New Ess040tabdet
        Dim loConexion As New BaseDatos
        loConexion.SetearParametrosConexion(sRegistryTablasSAP_, psCodigo)
        loConexion.Conectar(psCodigo)
        Dim lsSQL As String = GFsGeneraSQL("ZohoV2API - Tabla SAP - " & psCodigo.ToUpper)
        loConexion.CrearComando(lsSQL)
        Dim loDataTable As DataTable = loConexion.EjecutarConsultaTable()
        Dim loDataColumns As DataColumnCollection = loDataTable.Rows.Item(0).Table.Columns
        For Each loDataColumn As DataColumn In loDataColumns
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsCodigo
            loDatos.codigo = loDataColumn.ColumnName
            '-------Despliega registros leidos---------------
            loFrmProcesamiento.lblRegistroLeido.Text = "Leyendo [Modulo:" & lsCodigo & ", " & loDatos.codigo & "]"
            loFrmProcesamiento.Refresh()
            If loDatos.GetPK = sSinRegistros_ Then
                loDatos.ss010_codigo = SesionActiva.sistema
                loDatos.ss030_codigo = lsCodigo
                loDatos.codigo = loDataColumn.ColumnName
                loDatos.nombre = loDataColumn.Caption
                loDatos.detalle = "Tipo:" & loDataColumn.DataType.ToString & ", Length:" & loDataColumn.MaxLength
                Try
                    loDatos.Add(sNo_, sNo_)
                Catch ex As Exception
                    GPBitacoraRegistrar(sError_, "GPCargarTablasSAPFields.Add() --> " & ex.Message)
                End Try
                '-------Despliega registros leidos---------------
                loFrmProcesamiento.lblRegistroProcesado.Text = "Agregando [Modulo:" & lsCodigo & ", " & loDatos.codigo & "]"
                loFrmProcesamiento.Refresh()
            Else
                loDatos.ss010_codigo = SesionActiva.sistema
                loDatos.ss030_codigo = lsCodigo
                loDatos.codigo = loDataColumn.ColumnName
                loDatos.nombre = loDataColumn.Caption
                loDatos.detalle = "Tipo:" & loDataColumn.DataType.ToString & ", Length:" & loDataColumn.MaxLength
                Try
                    loDatos.Put(sNo_, sNo_)
                Catch ex As Exception
                    GPBitacoraRegistrar(sError_, "GPCargarTablasSAPFields.Put() --> " & ex.Message)
                End Try
                '-------Despliega registros leidos---------------
                loFrmProcesamiento.lblRegistroProcesado.Text = "Actualizando [Modulo:" & lsCodigo & ", " & loDatos.codigo & "]"
                loFrmProcesamiento.Refresh()
            End If
        Next
        '-------Encabezado para iniciar despliegue de formulario---------------
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Public Function GFsGetCOQLRecords(ByVal psCOQL As String, Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoCRM_coql_READ_)
        If lsAccessToken.Substring(0, sError_.Length) = sError_ Then
            Return lsAccessToken
            Exit Function
        End If
        Dim lsResultado As String = ""

        Dim loRequest As HttpWebRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/coql"), HttpWebRequest)
        loRequest.Method = "POST"
        loRequest.Headers("Authorization") = "Zoho-oauthtoken " & lsAccessToken
        Dim loRequestBody As JObject = New JObject
        loRequestBody.Add("select_query", psCOQL)
        Dim loDataString As String = loRequestBody.ToString
        Dim loData = Encoding.UTF8.GetBytes(loDataString)
        Dim liDataLength As Integer = loData.Length
        loRequest.ContentLength = liDataLength
        Dim loWriter = loRequest.GetRequestStream
        loWriter.Write(loData, 0, liDataLength)
        loRequest.KeepAlive = True
        Dim loResponse As HttpWebResponse
        Try
            loResponse = CType(loRequest.GetResponse, HttpWebResponse)
        Catch e As WebException
            If (e.Response Is Nothing) Then
                Throw
            End If

            loResponse = CType(e.Response, HttpWebResponse)
        End Try

        Dim loResponseEntity As HttpWebResponse = loResponse
        GPBitacoraRegistrar(sWRESPONSE_, "HTTP Status Code : " + CType(loResponse.StatusCode, Integer).ToString)
        Dim lsResponsestring As String = New StreamReader(loResponseEntity.GetResponseStream).ReadToEnd
        loResponseEntity.Close()
        GPBitacoraRegistrar(sWDATA_, lsResponsestring)

        Dim lsMsgError As String = GFsZohoError(lsResponsestring)
        If lsMsgError = sOk_ Then
            lsResultado = lsResponsestring
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If

        Return lsResultado
    End Function

    Public Function GFsGetRecord(ByVal psModulo As String, ByVal psPK As String, Optional ByVal psCampoPK As String = sNo_, Optional ByVal psFindMethod As String = sZIS_Search_, Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing, Optional ByVal psScope As String = sZohoCRM_Modules_ALL_) As String
        Dim lsAccessToken As String = GFsAccessTokenGet(psScope)
        If lsAccessToken.Substring(0, sError_.Length) = sError_ Then
            Return lsAccessToken
            Exit Function
        End If
        Dim lsResultado As String = ""
        Dim loRequest As HttpWebRequest = Nothing
        Select Case psFindMethod
            Case sZIS_Search_
                loRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/" & psModulo & "/search?criteria=(" & psCampoPK & ":equals:" & psPK & ")"), HttpWebRequest)
            Case sZIS_ZohoId_
                loRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/" & psModulo & "/" & psPK), HttpWebRequest)
            Case sZIS_External_
                loRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/" & psModulo & "/" & psPK), HttpWebRequest)
            Case "Todos"
                loRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/" & psModulo), HttpWebRequest)
        End Select
        loRequest.Method = "GET"
        loRequest.Headers("Authorization") = "Zoho-oauthtoken " & lsAccessToken
        If psFindMethod = sZIS_External_ Then
            loRequest.Headers("X-EXTERNAL") = psCampoPK       '---> esto es teniendo actualizado el External ID
        End If
        loRequest.KeepAlive = True
        Dim loResponse As HttpWebResponse
        Application.DoEvents()

        Try
            loResponse = CType(loRequest.GetResponse, HttpWebResponse)
        Catch e As WebException
            If (e.Response Is Nothing) Then
                Throw
            End If

            loResponse = CType(e.Response, HttpWebResponse)
        End Try

        Dim loResponseEntity As HttpWebResponse = loResponse
        GPBitacoraRegistrar(sWRESPONSE_, "HTTP Status Code : " + CType(loResponse.StatusCode, Integer).ToString)
        Dim lsResponsestring As String = (New StreamReader(loResponseEntity.GetResponseStream).ReadToEnd)
        loResponseEntity.Close()
        GPBitacoraRegistrar(sWDATA_, lsResponsestring)

        Dim lsMsgError As String = GFsZohoError(lsResponsestring)
        If lsMsgError = sOk_ Then
            lsResultado = lsResponsestring
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If
        If lsResultado = "" Then
            Return Nothing
        Else
            Return lsResultado
        End If
    End Function

    Public Function GFsInsertRecords(ByVal psModulo As String, ByVal poDatos As List(Of BulkDatos), Optional psCampoPK As String = sNo_, Optional psFindMethod As String = sZIS_ZohoId_, Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        GPBitacoraRegistrar(sENTRO_, "GFsInsertRecords --> Modulo:" & psModulo & ", CampoPK:" & psCampoPK & ", Find Method:" & psFindMethod)
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoCRM_Modules_ALL_)
        If lsAccessToken.Substring(0, sError_.Length) = sError_ Then
            Return lsAccessToken
            Exit Function
        End If
        Dim lsResultado As String = ""
        Dim loRequest As HttpWebRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/" & psModulo), HttpWebRequest)
        loRequest.Method = "POST"
        loRequest.Headers("Authorization") = "Zoho-oauthtoken " & lsAccessToken
        If psCampoPK <> sNo_ Then
            loRequest.Headers("X-EXTERNAL") = psModulo & "." & psCampoPK       '---> esto es teniendo actualizado el External ID
        End If
        Dim loRequestBody As JObject = New JObject
        Dim loRecordArray As JArray = New JArray
        Dim loRecordObject As JObject = New JObject
        Dim loDatos As BulkDatos
        For Each loDatos In poDatos
            loRecordObject.Add(loDatos.sFieldName, loDatos.sFieldValue)
        Next
        loRecordArray.Add(loRecordObject)
        loRequestBody.Add("data", loRecordArray)
        Dim loTrigger As JArray = New JArray
        loTrigger.Add("approval")
        loTrigger.Add("workflow")
        loTrigger.Add("blueprint")
        loRequestBody.Add("trigger", loTrigger)
        Dim loDataString As String = loRequestBody.ToString
        Dim loData = Encoding.UTF8.GetBytes(loDataString)
        Dim loDataLength As Integer = loData.Length
        loRequest.ContentLength = loDataLength
        Dim loWriter = loRequest.GetRequestStream
        loWriter.Write(loData, 0, loDataLength)
        loRequest.KeepAlive = True
        Dim loResponse As HttpWebResponse
        Try
            loResponse = CType(loRequest.GetResponse, HttpWebResponse)
            Application.DoEvents()

        Catch e As WebException
            If (e.Response Is Nothing) Then
                Throw
            End If

            loResponse = CType(e.Response, HttpWebResponse)
        End Try

        Dim loResponseEntity As HttpWebResponse = loResponse
        GPBitacoraRegistrar(sWRESPONSE_, "HTTP Status Code : " + CType(loResponse.StatusCode, Integer).ToString)
        Dim lsResponsestring As String = (New StreamReader(loResponseEntity.GetResponseStream).ReadToEnd)
        loResponseEntity.Close()
        GPBitacoraRegistrar(sWDATA_, lsResponsestring)

        Dim lsMsgError As String = GFsZohoError(lsResponsestring)
        If lsMsgError = sOk_ Then
            lsResultado = lsResponsestring
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If
        GPBitacoraRegistrar(sSALIO_, "GFsInsertRecords --> Modulo:" & psModulo & ", CampoPK:" & psCampoPK & ", Find Method:" & psFindMethod & ", Resultado:" & lsResultado)
        Return lsResultado
    End Function

    Public Function GFsUpsertRecord(ByVal psModulo As String, ByVal psPK As String, ByVal poDatos As List(Of BulkDatos), Optional psFindMethod As String = sZIS_ZohoId_, Optional psDuplicate As String = "", Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing) As String
        GPBitacoraRegistrar(sENTRO_, "GFsUpsertRecord --> Modulo:" & psModulo & ", PK:" & psPK & ", Find Method:" & psFindMethod)
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoCRM_Modules_ALL_)
        If lsAccessToken.Substring(0, sError_.Length) = sError_ Then
            Return lsAccessToken
            Exit Function
        End If
        Dim lsResultado As String = ""
        Dim loRequest As HttpWebRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/" & psModulo & "/upsert"), HttpWebRequest)
        loRequest.Method = "POST"
        loRequest.Headers("Authorization") = "Zoho-oauthtoken " & lsAccessToken
        Dim loRequestBody As JObject = New JObject
        Dim loRecordArray As JArray = New JArray
        Dim loRecordObject As JObject = New JObject
        Dim loDatos As BulkDatos
        For Each loDatos In poDatos
            loRecordObject.Add(loDatos.sFieldName, loDatos.sFieldValue)
        Next
        loRecordArray.Add(loRecordObject)
        loRequestBody.Add("data", loRecordArray)
        Dim loDuplicateCheckFields As JArray = New JArray
        If psDuplicate.Trim.Length > 0 Then
            Dim poDuplicate() As String = psDuplicate.Split("|"c)
            For liPos As Integer = 0 To poDuplicate.Count - 1
                loDuplicateCheckFields.Add(poDuplicate(liPos))
            Next
            loRequestBody.Add("duplicate_check_fields", loDuplicateCheckFields)
        End If
        Dim loTrigger As JArray = New JArray
        loTrigger.Add("approval")
        loTrigger.Add("workflow")
        loTrigger.Add("blueprint")
        loRequestBody.Add("trigger", loTrigger)
        Dim loDataString As String = loRequestBody.ToString
        Dim loData = Encoding.UTF8.GetBytes(loDataString)
        Dim loDataLength As Integer = loData.Length
        loRequest.ContentLength = loDataLength
        Dim loWriter = loRequest.GetRequestStream
        loWriter.Write(loData, 0, loDataLength)
        loRequest.KeepAlive = True
        Dim loResponse As HttpWebResponse
        Try
            loResponse = CType(loRequest.GetResponse, HttpWebResponse)
            Application.DoEvents()

        Catch e As WebException
            If (e.Response Is Nothing) Then
                Throw
            End If

            loResponse = CType(e.Response, HttpWebResponse)
        End Try

        Dim loResponseEntity As HttpWebResponse = loResponse
        GPBitacoraRegistrar(sWRESPONSE_, "HTTP Status Code : " + CType(loResponse.StatusCode, Integer).ToString)
        Dim lsResponsestring As String = (New StreamReader(loResponseEntity.GetResponseStream).ReadToEnd)
        loResponseEntity.Close()
        GPBitacoraRegistrar(sWDATA_, lsResponsestring)

        Dim lsMsgError As String = GFsZohoError(lsResponsestring)
        If lsMsgError = sOk_ Then
            lsResultado = lsResponsestring
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If

        GPBitacoraRegistrar(sSALIO_, "GFsUpsertRecord --> Modulo:" & psModulo & ", PK:" & psPK & ", Find Method:" & psFindMethod & ", Resultado:" & lsResultado)
        Return lsResultado
    End Function

    Public Function GFsPutRecord(ByVal psModulo As String, ByVal psPK As String, ByVal psCampoPK As String, ByVal poDatos As List(Of BulkDatos), Optional psFindMethod As String = sZIS_ZohoId_, Optional poRegistroOperativo As RegistrosOperativos = Nothing) As String
        GPBitacoraRegistrar(sENTRO_, "GFsPutRecord --> Modulo:" & psModulo & ", PK:" & psPK & ", CampoPK:" & psCampoPK)
        Dim lsAccessToken As String = GFsAccessTokenGet(sZohoCRM_Modules_ALL_)
        If lsAccessToken.Substring(0, sError_.Length) = sError_ Then
            Return lsAccessToken
            Exit Function
        End If
        Dim lsResultado As String = ""

        Dim loRequest As HttpWebRequest = CType(WebRequest.Create("https://www.zohoapis.com/crm/v2/" & psModulo & "/" & psPK), HttpWebRequest)
        loRequest.Method = "PUT"
        loRequest.Headers("Authorization") = "Zoho-oauthtoken " & lsAccessToken
        If psFindMethod = sZIS_External_ Then
            loRequest.Headers("X-EXTERNAL") = psModulo & "." & psCampoPK       '---> esto es teniendo actualizado el External ID
        End If

        loRequest.ContentType = "application/json"
        Dim loRequestBody As JObject = New JObject()
        Dim loRecordArray As JArray = New JArray()
        Dim loRecordObject As JObject = New JObject()

        Dim loDatos As BulkDatos
        For Each loDatos In poDatos
            Select Case loDatos.sTypeValue
                Case "S"
                    loRecordObject.Add(loDatos.sFieldName, loDatos.sFieldValue)
                Case "B"
                    loRecordObject.Add(loDatos.sFieldName, CBool(loDatos.sFieldValue))
                Case "I"
                    loRecordObject.Add(loDatos.sFieldName, CInt(loDatos.sFieldValue))
            End Select
        Next
        loRecordArray.Add(loRecordObject)
        loRequestBody.Add("data", loRecordArray)
        Dim lsDataString As String = loRequestBody.ToString()
        Dim loData = Encoding.UTF8.GetBytes(lsDataString)
        Dim liDataLength As Integer = loData.Length
        loRequest.ContentLength = liDataLength

        Using loWriter = loRequest.GetRequestStream()
            loWriter.Write(loData, 0, liDataLength)
        End Using

        loRequest.KeepAlive = True
        Dim loResponse As HttpWebResponse

        Try
            loResponse = CType(loRequest.GetResponse(), HttpWebResponse)
            Application.DoEvents()

        Catch e As WebException

            If e.Response Is Nothing Then
                Throw
            End If

            loResponse = CType(e.Response, HttpWebResponse)
        End Try

        Dim loResponseEntity As HttpWebResponse = loResponse
        GPBitacoraRegistrar(sWRESPONSE_, "HTTP Status Code : " & CInt(loResponse.StatusCode).ToString)

        Dim lsResponsestring As String = New StreamReader(loResponseEntity.GetResponseStream()).ReadToEnd()
        loResponseEntity.Close()
        GPBitacoraRegistrar(sWDATA_, lsResponsestring)

        Dim lsMsgError As String = GFsZohoError(lsResponsestring)
        If lsMsgError = sOk_ Then
            Dim loLeerJSON As JObject = JObject.Parse(lsResponsestring)
            If loLeerJSON("data")(0)("code").ToString <> sSUCCESS_ Then
                GPBitacoraRegistrar(sMENSAJE_, lsResponsestring)
            End If
            lsResultado = lsResponsestring
        Else
            If poRegistroOperativo IsNot Nothing Then poRegistroOperativo.Registrar(sError_, lsMsgError)
        End If
        GPBitacoraRegistrar(sSALIO_, "GFsPutRecord --> Modulo:" & psModulo & ", PK:" & psPK & ", CampoPK:" & psCampoPK & ", Resultado:" & lsResultado)
        Return lsResultado
    End Function

    Public Sub GPProcesarBulk(Optional poDataTable As DataTable = Nothing, Optional ByVal psScript As String = "", Optional ByVal psModulo As String = "Colaboradores", Optional ByVal piNumMod As Integer = -1, Optional ByVal psTipAct As String = sBulkUpsert_, Optional ByRef poRegistroOperativo As RegistrosOperativos = Nothing, Optional ByVal psCampoPK As String = "")
        GPBitacoraRegistrar(sENTRO_, "GPProcesarBulk - Datatable: " & poDataTable.TableName & ", Script: " & psScript & ", Modulo:" & psModulo & ", Modelo: " & piNumMod.ToString & ", TipActualización:" & psTipAct & ", Bitacora:" & poRegistroOperativo.FileName)
        Dim lsUbicacion As String = Application.StartupPath()
        Dim lsScript As String = psScript
        Dim loDataTable As DataTable = poDataTable
        If loDataTable Is Nothing Then
            If psScript.Trim.Length > 0 Then
                loDataTable = GFoRecuperaDataTable(psScript,, piNumMod)
                Application.DoEvents()
            Else
                GPBitacoraRegistrar(sError_, "GPProcesarBulk --> Este proceso espera un DATATABLE o Codigo SQL para gestionar")
                Exit Sub
            End If
        End If
        Dim lsFileSource() As String = GFsExportaRecordSetToTexto(loDataTable,,, piNumMod).Split(sSF_)
        Application.DoEvents()
        Dim lsFile() As String = lsFileSource(0).Split("\"c)
        Dim lsFileTarget As String = lsUbicacion & sDS_.Substring(0, 1) & lsFile(lsFile.Count - 1)
        My.Computer.FileSystem.CopyFile(lsFileSource(0), lsFileTarget)
        Application.DoEvents()
        lsFile = lsFileTarget.Split("\"c)
        Dim lsFileArchive As String = lsFile(lsFile.Length - 1) & ".zip"
        Dim lsProceso As String = GFsEjecutaProceso("7z", "a " & lsFileArchive & " " & lsFile(lsFile.Length - 1))
        Application.DoEvents()
        Dim lsFileId() As String = GFsPythonFileUpload(lsFileArchive,,, poRegistroOperativo).Split("|"c)
        Application.DoEvents()
        Dim lsId() As String = GFsPythonCreateBulk("Zoho_CreateBulkWriteJob", lsFileId(lsFileId.Length - 1), psModulo, piNumMod, psTipAct,, poRegistroOperativo, psCampoPK).Split("|"c)
        GPBitacoraRegistrar(sINFORMAR_, "GPProcesarBulk --> GFsPythonCreateBulk se ejecuta")
        Application.DoEvents()
        Dim loLeerJSON As JObject = Nothing
        If lsId.Count > 1 Then
            loLeerJSON = JObject.Parse(lsId(1))
        Else
            Dim liSleep As Integer = CInt(GFsParametroObtener(sGeneral_, "GPProcesarBulk - Tiempo de espera"))
            Dim liWatchDogControl As Integer = CInt(GFsParametroObtener(sGeneral_, "GPProcesarBulk - Control Watchdog"))
            Dim liWatchDog As Integer = 0
            Do While True
                liWatchDog += 1
                Dim lsURL() As String = GFsPythonStatusBulk("Zoho_GetBulkWriteJobDetails", lsId(lsId.Length - 1),, poRegistroOperativo).Split("|"c)
                If lsURL(0) = "COMPLETED" Then
                    GPBitacoraRegistrar(sINFORMAR_, "GPProcesarBulk --> GFsPythonStatusBulk se ejecuta, Resultado URL:" & lsURL(1))
                    Exit Do
                Else
                    GPBitacoraRegistrar(sINFORMAR_, "GPProcesarBulk --> GFsPythonStatusBulk se ejecuta" & lsURL(1))
                End If
                If liWatchDog = liWatchDogControl Then Exit Do
                Threading.Thread.Sleep(liSleep)
            Loop
        End If

        Application.DoEvents()
        GPBitacoraRegistrar(sSALIO_, "GPProcesarBulk - Datatable: " & poDataTable.TableName & ", Script: " & psScript & ", Modulo:" & psModulo & ", Modelo: " & piNumMod.ToString & ", TipActualización:" & psTipAct & ", Bitacora:" & poRegistroOperativo.FileName)
    End Sub

#Region "Funciones Privadas"
    Private Function LFsObtieneParametro(ByVal psClave As String, ByVal psRama As String, ByVal psRamaGeneral As String) As String
        Dim lsRama As String = psRama & sResetear_ & sDS_
        Dim lsRamaGeneral As String = psRamaGeneral & sResetear_ & sDS_
        Dim lsClave As String = psClave.Substring(0, psClave.Length - 1)
        Dim lsResultado As String = ""

        lsResultado = GFsGetRegistry(lsRamaGeneral, lsClave)
        If lsResultado <> sRESERVADO_ Then
            If SesionActiva.AutorizadoResetear(lsRamaGeneral, lsClave, lsResultado) = sSi_ Then
                GPSavRegistry(psRamaGeneral, psClave, lsResultado)
                GPSavRegistry(lsRamaGeneral, lsClave, sRESERVADO_)
            End If
        End If

        lsResultado = GFsGetRegistry(lsRama, lsClave)
        If lsResultado <> sRESERVADO_ Then
            If SesionActiva.AutorizadoResetear(lsRama, lsClave, lsResultado) = sSi_ Then
                GPSavRegistry(psRama, psClave, lsResultado)
                GPSavRegistry(lsRama, lsClave, sRESERVADO_)
            End If
        End If

        lsResultado = GFsGetRegistry(psRama, psClave)
        If lsResultado = sRESERVADO_ Then
            lsResultado = GFsGetRegistry(psRamaGeneral, psClave)
            If lsResultado <> sRESERVADO_ Then
                GPSavRegistry(psRama, psClave, lsResultado)
            End If
        End If
        Return lsResultado
    End Function

#End Region
End Module

Public Class BulkMapeo
    Public Property sApiName As String
    Public Property iOrder As Integer
End Class

Public Class BulkDatos
    Public Property sFieldName As String
    Public Property sTypeValue As String = "S"
    Public Property sFieldValue As String
End Class