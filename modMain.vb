Imports System.Data.Common
Imports System.Threading
Imports Newtonsoft.Json.Linq
'23/12/2021
Module modMain
    Private moSesionActiva As SesionActiva
    Private moBitacoraProceso As BitacoraProceso
    Private moSocket As Thread
    Private moFrecProgramada As Thread

    Sub Main()
        LPInicializaRegistry()
        LPAbreSesionInicializaBitacora()
        LPInicializaTablaGeneral()

        Dim lsControl = moSesionActiva.VerificaControl2
        If lsControl <> sOk_ Then
            Dim lsParte() As String = lsControl.Split(sSF_)
            GFsAvisar(lsParte(0), sViolacion_, lsParte(1))
        Else
            LPInicializaParametros()
            If GFsGetRegistry(sSesion_, "TipoEjecución") = sAutomatico_ Then
                LPProcesosMultiHilos()
            Else
                Dim loLoginAcceso As New frmFLoginAcceso
                loLoginAcceso.ShowDialog()
                If loLoginAcceso.Tag Is Nothing Then loLoginAcceso.Tag = sCancelar_

                If loLoginAcceso.Tag.ToString = sOk_ Then
                    LPParametrosUsuarios()
                    GPAgregaZohoScope()

                    'GPIntegracionZoho_SAP_OCPR("4818926000004313220")
                    '-------------ACTUALIZAR UN REGISTRO DE OCPR ESTANDO EN OCRD------------------------------------------------
                    'Dim loOCRD As New Eocrd
                    'If loOCRD.GetPK("TCTB-926140W") Then
                    '    Dim lsName As String = loOCRD.GetAtributoOCPR("Name", 1)
                    '    loOCRD.SetCurrentLineOCPR(1)
                    '    loOCRD.SetAtributoOCPR("Name", "GANE!!")
                    'End If
                    'Try
                    '    loOCRD.Put()
                    'Catch ex As Exception
                    '    GFsAvisar("Error: " & ex.Message, sMENSAJE_)
                    'End Try
                    '-------------ACTUALIZAR UN REGISTRO DE OCPR ESTANDO EN OCRD------------------------------------------------
                    '-------------RECUPERA UN REGISTRO QUE TIENE SUBFORM---------------------------------------------------------
                    'Dim lsResultado1 As String = GFsPythonGetRecord("Quotes", "4818926000004199031", "Quote_Number", "search")
                    'Dim lsResultado2 As String = GFsPythonGetRecord("Quotes", "4818926000004199027", "id", "zohoid")
                    'Dim lsResultado3 As String = GFsPythonGetRecord("Contacts", "PE091213", "Externo_CardCode", "external")
                    'lsResultado1 = lsResultado1.Replace(Chr(39), Chr(34))
                    'Dim loCodigoProducto As JObject = JObject.Parse(lsResultado1)
                    'Dim lsCodigoProducto As String = loCodigoProducto("data")(0)("Product_Details")(0)("product")("Product_Code").ToString
                    '-------------RECUPERA UN REGISTRO QUE TIENE SUBFORM---------------------------------------------------------
                    '-------------CREA UNA RELACION CONTACTO/CUENTAS---------------------------------------------------------
                    'Dim loResultado1 As JObject = JObject.Parse(lsResultado1)
                    'Dim lsResultado2 As String = GFsGetRecord("Accounts", "1387987", "Codigo_CardCode", "search")
                    'Dim loResultado2 As JObject = JObject.Parse(lsResultado2)
                    'lsResultado1 = loResultado1("data")(0)("Externo_CardCode").ToString
                    'lsResultado2 = loResultado2("data")(0)("Account_Name").ToString
                    'Dim lsResultado3 As String = GFsUpdateRelatedRecord("Contacts", lsResultado1, "Externo_CardCode", "Account_Name", lsResultado2, "update_related_record2")
                    '-------------CREA UNA RELACION CONTACTO/CUENTAS---------------------------------------------------------
                    '-------------CREA UNA RELACION CONTACTO/CONTACTO---------------------------------------------------------
                    'Dim lsResultado1 As String = GFsPythonGetUsers()
                    'Dim loResultado1 As JObject = JObject.Parse(lsResultado1)
                    'Dim lsResultado2 As String = GFsGetRecord("Contacts", "1656015-9", "Nro_RUC", "search")
                    'Dim loResultado2 As JObject = JObject.Parse(lsResultado2)
                    'lsResultado1 = loResultado1("users")(38)("id").ToString
                    'lsResultado2 = loResultado2("data")(0)("id").ToString
                    'Dim loDatos As New List(Of BulkDatos)
                    'Dim loBulkDatos As New BulkDatos
                    'loBulkDatos.sFieldName = "Owner"
                    'loBulkDatos.sFieldValue = lsResultado1
                    'loDatos.Add(loBulkDatos)
                    'Dim lsResultado3 As String = GFsPutRecord("Contacts", lsResultado2, "id", loDatos,,)
                    '-------------CREA UNA RELACION CONTACTO/CONTACTO---------------------------------------------------------
                    '-------------CREA UNA RELACION CONTACTO/CONTACTO-----------------------------------------------------------
                    'Dim lsResultado1 As String = GFsGetRecord("Contacts", "997963GS", "Nro_RUC", "search") '997605
                    'Dim loResultado1 As JObject = JObject.Parse(lsResultado1)
                    'Dim lsResultado2 As String = GFsGetRecord("Contacts", "997605", "Nro_RUC", "search") '997605
                    'Dim loResultado2 As JObject = JObject.Parse(lsResultado2)
                    'Dim loDatos As New List(Of BulkDatos)
                    'Dim loBulkDatos As New BulkDatos
                    'loBulkDatos.sFieldName = "Contacto_Relacionado"
                    'loBulkDatos.sFieldValue = loResultado2("data")(0)("id").ToString
                    'loDatos.Add(loBulkDatos)
                    'Dim lsResultadoF As String = GFsPutRecord("Contacts", loResultado1("data")(0)("Externo_CardCode").ToString, "Externo_CardCode", loDatos, sZIS_External_)
                    '-------------CREA UNA RELACION CONTACTO/CONTACTO-----------------------------------------------------------
                    '-------------OBTENER META-DATA POR MODULO Y POR CAMPOS POR MODULO------------------------------------------
                    'Dim lsResultado2 As String = GFsGetModules("module=Sales_Orders")
                    'Dim lsResultado3 As String = GFsGetModules("fields?module=Users")
                    '-------------OBTENER META-DATA POR MODULO Y POR CAMPOS POR MODULO------------------------------------------
                    '-------------OBTENER TODOS LOS DATOS DE UN DETERMINADO MODULO----------------------------------------------
                    'Dim lsResultado As String = GFsGetRecord("Contacts", "0",, "Todos")
                    '-------------OBTENER TODOS LOS DATOS DE UN DETERMINADO MODULO----------------------------------------------
                    '-------------OBTENER EL ACCESS TOKEN A PARTIR DE UN REFRESH TOKEN------------------------------------------
                    'Dim lsAccessToken As String = GFsGetAccessToken("ZohoCRM.settings.ALL", "1000.1b099548b659356b919e69f54dbc1b2b.f1be3f27c526a008dbb840baecd5de31")                    
                    '-------------OBTENER EL ACCESS TOKEN A PARTIR DE UN REFRESH TOKEN------------------------------------------
                    '-------------EJECUTA EL PROCESO DE INTEGRACION - CABECERA--------------------------------------------------
                    'GPProcesoCabecera()
                    '-------------EJECUTA EL PROCESO DE INTEGRACION - CABECERA--------------------------------------------------
                    'Dim lsResultado1 As String = GFsGetModules("fields?module=Accounts")
                    'Dim loDataTable As DataTable = GFoJsonToDataTable(lsResultado, "Accounts")

                    'Dim lsDatos As String = GFsGetRecord("Sales_Orders", "4818926000003454048", "SO_Number", "search")
                    'Dim loRegistroOperativo As RegistrosOperativos = New RegistrosOperativos("PROBANDO_")
                    'GPProcesoDetalle(1, 3, loRegistroOperativo)
                    'loRegistroOperativo.Cerrar()

                    'Dim lsResultado4 As String = GFsGetCOQLRecords("SELECT id, First_Name, Last_Name, Codigo_Vendedor_Sap, status FROM Users WHERE id = '4855427000012837001'")
                    'Dim lsResultado2 As String = GFsCOQLExtraeCampos("SELECT id, First_Name + ' ' + Last_Name As FullName, Codigo_CardCode + '_' + RUC_CI As Identity, Email + '_' + Phone + '_' + TELEFONO_MOVIL_Cellular As ComoContactar, CIUDAD_City, RUBRO_U_rubrosn, OCUPACION_IndustryC, SUCURSAL_Origen_U_sucori, VENDEDOR_SlpCode, DIRECCION_Notes	 FROM Contacts WHERE id = &zohoId")
                    'Dim lsModulos As String = GFsGetModules()
                    'GPProcesarBulk()
                    'GPCargarTablasSAP()
                    'Dim lsFile_id As String = GFsUploadFile("C:\sigafyc\Exportados\COLABORADORES_20210805_1004.zip")
                    'GPActualizarExternoCardCode("Contacts",,, "COQL - Contacts - Update Externo_CardCode")
                    'GPActualizarExternoCardCode()
                    'GPCrearScriptPython()
                    'Dim lsResult As String = GFsEjecutaProceso("C:\Program Files\IronPython 2.7\ipy.exe", "C:\Basura\B89A760EA168B47B9368F8FF5E9DB71312354397C0707FABA452A40730B8760C.py")
                    'GPUploadFile("C:\sigafyc\Exportados\COLABORADORES_20210706_1400.zip")

                    Dim loMenuPrincipal As New frmMenuPrincipal
                    Application.Run(loMenuPrincipal)
                    LPReseteaRegistry()
                End If
            End If
        End If
        LPControlesFinales()
    End Sub

    Private Sub LPProcesosMultiHilos()
        Dim lsTipoAutomatico As String = ""
        If GFsGetRegistry(sSesion_, "Socket_Final") <> sRESERVADO_ Then
            lsTipoAutomatico = "1"
        Else
            If GFsGetRegistry(sSesion_, "Automatico1_Final") <> sRESERVADO_ Then
                lsTipoAutomatico = "2"
            Else
                If GFsGetRegistry(sSesion_, "Automatico2_Final") <> sRESERVADO_ Then
                    lsTipoAutomatico = "3"
                End If
            End If
        End If
        Select Case lsTipoAutomatico
            Case "1"
                moSocket = New Thread(AddressOf LPEjecutaServidorSocket)
                moSocket.Name = sAutomatico_ & "_ServidorSocket"
            Case "2"
                moSocket = New Thread(AddressOf LPEjecutaAutomatico1)
                moSocket.Name = sAutomatico_ & "_Automatico1"
            Case "3"
                moSocket = New Thread(AddressOf LPEjecutaAutomatico2)
                moSocket.Name = sAutomatico_ & "_Automatico2"
        End Select
        If lsTipoAutomatico <> "" Then
            moSocket.Start()
            MultiThread.Agregar(moSocket)
            Do While True
                If MultiThread.listThread IsNot Nothing Then
                    If MultiThread.Cantidad(sAutomatico_) = MultiThread.Culminados(sAutomatico_) Then
                        LPReseteaRegistry()
                        Exit Do
                    End If
                End If
                Application.DoEvents()
            Loop
        End If
    End Sub

    Private Sub LPEjecutaServidorSocket()
        Dim loFrmServidor As New frmFServidorSocket
        Application.Run(loFrmServidor)
    End Sub

    Private Sub LPEjecutaAutomatico1()
        Dim loFrmServidor As New frmFEjecutarAutomatico1
        Application.Run(loFrmServidor)
    End Sub

    Private Sub LPEjecutaAutomatico2()
        Dim loFrmServidor As New frmFEjecutarAutomatico2
        Application.Run(loFrmServidor)
    End Sub

    Private Sub LPInicializaRegistry()
        '------------------------------------------------------------------------------------
        '    INCLUIR EN ESTE PROCEDIMIENTO TODAS LAS INICIALIZACIONES QUE SEAN NECESARIAS
        '    TENER PARA QUE EL SISTEMA PUEDA FUNCIONAR.
        '------------------------------------------------------------------------------------
        If GFsGetRegistry(sSeguridad_, sPasswordReset_) = sNOAUTORIZADO_ Then
            GPSavRegistry(sSeguridad_, sPasswordReset_, sRESERVADO_)
        End If

        If GFsGetRegistry(sSeguridad_, sForcedSalt_) = sNOAUTORIZADO_ Then
            GPSavRegistry(sSeguridad_, sForcedSalt_, sRESERVADO_)
        End If

        If GFsGetRegistry(sSeguridad_, sUbicacionBitacora_) = sRESERVADO_ Then
            GPSavRegistry(sSeguridad_, sUbicacionBitacora_, My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "Bitacoras")
        End If

        If GFsGetRegistry(sSesion_, "MenuPrincipal_X") = sRESERVADO_ Then
            GPSavRegistry(sSesion_, "MenuPrincipal_X", "100")
        End If

        If GFsGetRegistry(sSesion_, "MenuPrincipal_Y") = sRESERVADO_ Then
            GPSavRegistry(sSesion_, "MenuPrincipal_Y", "100")
        End If

        If GFsGetRegistry(sSesion_, "TipoEjecución") = sRESERVADO_ Then
            GPSavRegistry(sSesion_, "TipoEjecución", sManual_)
        End If
    End Sub

    Private Sub LPInicializaTablaGeneral()
        Dim lsTipo As String = ""
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsCodigo As String = ""
        lsTipo = sGeneral_

        lsClave = "Zoho API V2 - Tabla de Tokens"
        lsValor = "ZohoAPIV2_Tokens"
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        lsClave = "Tabla general - SQL del sistema"
        lsValor = "SQLGeneral"
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        lsClave = "Mail - Address - To"
        lsValor = "MailBitacora_AddressTo"
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        lsClave = "Mail - Address - CC"
        lsValor = "MailBitacora_AddressCC"
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        lsClave = "Mail - Address - CCO"
        lsValor = "MailBitacora_AddressCCO"
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        lsClave = "Mail - Enable SSL"
        lsValor = sNo_
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        lsClave = sZIS_TablaScriptPython_
        lsValor = "Scripts Python"
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)

        lsClave = sZIS_TablaScriptCOQL_
        lsValor = "Query COQL"
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)
    End Sub

    Private Sub LPAbreSesionInicializaBitacora()
        moSesionActiva = New SesionActiva
        moSesionActiva.CargaParametros()
        moBitacoraProceso = New BitacoraProceso
        moBitacoraProceso.Inicializa()
    End Sub

    Private Sub LPReseteaRegistry()
        Dim liCantidad As Integer = 0
        Dim liCulminados As Integer = 0
        Do While True
            If GFsGetRegistry(sSesion_, "TipoEjecución") = sAutomatico_ Then
                liCantidad = MultiThread.Cantidad(sAutomatico_)
                If liCantidad > 0 Then
                    liCulminados = MultiThread.Culminados(sAutomatico_)
                    If liCulminados = liCantidad Then
                        Exit Do
                    End If
                Else
                    Exit Do
                End If
            Else
                liCantidad = MultiThread.Cantidad
                If liCantidad = 0 Then
                    Exit Do
                Else
                    liCulminados = MultiThread.Culminados
                    If liCulminados = liCantidad Then
                        Exit Do
                    End If
                End If
            End If
        Loop
        GPSavRegistry(sSeguridad_, sPasswordReset_, sRESERVADO_)
    End Sub

    Private Function LFsConexionDBMS() As String
        Dim lsRama As String
        Dim lsTitulo As String = ""
        Dim lsResultado As String = ""

        lsRama = sRegistryTablasSeguridad_ & sGeneral_ & sDS_
        lsTitulo = sSeguridad_
        lsResultado &= LFsEstableceConexion(lsRama, lsTitulo)

        lsRama = sRegistryTablasPrincipal_ & sGeneral_ & sDS_
        lsTitulo = sPrincipal_
        lsResultado &= LFsEstableceConexion(lsRama, lsTitulo)

        lsRama = sRegistryTablasBasura_ & sGeneral_ & sDS_
        lsTitulo = sBasura_
        lsResultado &= LFsEstableceConexion(lsRama, lsTitulo)

        If InStr(lsResultado, sError_) > 0 Then
            lsResultado = sError_
        Else
            lsResultado = sOk_
        End If

        Return lsResultado
    End Function

    Private Sub LPInicializaParametros()
        LPParametrosGenerales()
        LPParametrosLocales()
        LPParametrosFechas()
        LPParametrosModulos()
    End Sub

    Private Sub LPParametrosGenerales()
        Dim lsProcedureName As String = "Parametros Generales"
        Dim lsTipo As String = sGeneral_
        Dim lsClave As String
        Dim lsValor As String

        lsClave = "Ubicacion - Imagen"
        lsValor = My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "Imagenes"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If

        lsClave = "Ubicacion - Audio"
        lsValor = My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "Audios"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If

        lsClave = "Ubicacion - PDF"
        lsValor = My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "PDF"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If

        lsClave = "Ubicacion - Archivos exportados"
        lsValor = My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "Exportados"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If

        lsClave = "Separador - Archivos exportados"
        lsValor = sSCSV_
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Ubicacion - Archivo menu"
        lsValor = My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "Menues"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If

        lsClave = "Archivo menu"
        lsValor = My.Application.Info.AssemblyName & "_v" & My.Application.Info.Version.Major.ToString & My.Application.Info.Version.Minor.ToString & My.Application.Info.Version.Revision.ToString & "_menues.mnu"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Version Actual Sistema - Indicador de salida"
        lsValor = "1"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Informe - Titulo Complemento"
        lsValor = "<<*** //\\ ***>>"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Desarrollador sistema - email"
        lsValor = "jorge_antonio_cabrera@msn.com"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Desarrollador sistema - telefono"
        lsValor = "+595971519445"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Desarrollador sistema - sitio web"
        lsValor = "https://www.linkedin.com/in/jorge-antonio-cabrera-gonzalez-28319312"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Generar Archivos - Texto - Separador"
        lsValor = ";"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Confirmacion - Desplegar"
        lsValor = sSi_
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Envio de Mail - Max Tamaño en byte adjunto"
        lsValor = "1048576"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Mail - Servidor SMTP"
        lsValor = "smtp.gmail.com"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Mail - Servidor SMTP Port"
        lsValor = "587"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Mail - Username"
        lsValor = SesionActiva.sistema.ToLower & ".main"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Mail - Password"
        lsValor = "t3k0p1r3#864222"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Mail - Address - From Cuenta"
        lsValor = SesionActiva.sistema.ToLower & ".main@gmail.com"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Mail - Address - From Nombre Completo"
        Dim loSS010 As New Ess010sistemas
        loSS010.codigo = SesionActiva.sistema
        If loSS010.GetPK = sOk_ Then
            lsValor = loSS010.nombre
        Else
            lsValor = "Sistema de Auditoria y Seguridad"
        End If
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Mail - Address - To"
        lsValor = "MailBitacora_AddressTo"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Mail - Address - CC"
        lsValor = "MailBitacora_AddressCC"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Mail - Address - CCO"
        lsValor = "MailBitacora_AddressCCO"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = sPK_AccessTokenValidez_
        lsValor = "5"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = sZIS_TablaScriptPython_
        lsValor = "Scripts Python"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = sZIS_TablaScriptCOQL_
        lsValor = "Query COQL"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "ZohoAPI V2 - Modulos Permitidos"
        lsValor = "Accounts,Contacts,Colaboradores,Price_Books,Products,Funcionarios,Sales_Orders"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "ZohoAPI V2 - Tablas SAP Permitidas"
        lsValor = "OCRD|OCRG|OITM|OITB|OINV|INV1|INV6"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "ZohoAPI V2 - Modelo - Detalle"
        lsValor = "ZohoV2API - Modelo - Detalle"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = sZIS_Bulk_creditos_
        lsValor = "500"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPIntegracionZoho_SAP ->Accounts - Modelo Integracion"
        lsValor = "5"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPIntegracionZoho_SAP ->Contacts - Modelo Integracion"
        lsValor = "6"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Proceso BULK - optimizando creditos"
        lsValor = sNo_
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPIntegracionZoho_SAP-MONEDA_PREDETERMINADA"
        lsValor = "##"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPIntegracionZoho_SAP ->Contacts - OCPR - Modelo Integracion"
        lsValor = "10"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPIntegracionZoho_SAP-GRUPO_PREDETERMINADO"
        lsValor = "100"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPProcesarBulk - Control Watchdog"
        lsValor = "100"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPProcesarBulk - Tiempo de espera"
        lsValor = "100"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPIntegracionZoho_SAP ->DIREECCIONES ACCOUNTS - CRD1 - MODELO INTEGRACION"
        lsValor = "11"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPIntegracionZoho_SAP ->DIREECCIONES CONTACTS - CRD1 - MODELO INTEGRACION"
        lsValor = "13"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GFsGeneralSQL_TipoParametro"
        lsValor = sLocal_
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPIntegracionZoho_SAP -> ARTICULO PARA FINANCIAMIENTO EN USD"
        lsValor = "IM00011"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "GPIntegracionZoho_SAP -> ARTICULO PARA FINANCIAMIENTO EN GS"
        lsValor = "IM00012"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Servidor Socket - password"
        lsValor = sPasswordSalir_
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
    End Sub

    Private Sub LPParametrosLocales()
        Dim lsProcedureName As String = "Parametros Locales"
        Dim lsTipo As String = sLocal_
        Dim lsClave As String
        Dim lsValor As String

        lsClave = "Version Actual Sistema"
        lsValor = My.Application.Info.Version.ToString
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Version Actual Sistema - Diferencia permitida"
        lsValor = "5"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Informe - Tamaño pagina"
        lsValor = eTipoHoja.A4.ToString
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Informe - Orientacion pagina"
        lsValor = eOrientacion.Vertical.ToString
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Sesion - Fecha/Hora ultimo acceso_"
        lsValor = Now.ToString(sFormatoFechaHora1_)
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor, sNo_)
        End If

        lsClave = sUbicacionQuerySQL_
        lsValor = My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "SQL"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If

        lsClave = sUbicacionScriptPython_
        lsValor = My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "Python"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If

        lsClave = sUbicacionQueryCOQL_
        lsValor = My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "COQL"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If

        lsClave = sUbicacionBitacora_
        lsValor = My.Application.Info.DirectoryPath.Substring(0, 2) & sDS_ & My.Application.Info.AssemblyName & sDS_ & "LogsIntegración"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If

        lsClave = "UbicacionDownload"
        lsValor = "\" & My.Application.Info.AssemblyName & "\Download"
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
            GPDirectoryCheck(lsValor)
        End If
    End Sub

    Private Sub LPParametrosUsuarios()
        Dim lsProcedureName As String = "Parametros Usuarios"
        Dim lsTipo As String = sUsuario_
        Dim lsClave As String
        Dim lsValor As String

        lsClave = "Zoho - Archivo Scope"
        lsValor = sRESERVADO_
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Zoho - Ubicacion - Archivo Scope"
        lsValor = sRESERVADO_
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Informe - Borrar Archivos temporales"
        lsValor = sSi_
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Bitacora proceso - Eliminar despues enviar mail"
        lsValor = sSi_
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

        lsClave = "Archivo menu"
        lsValor = GFsParametroObtener(sGeneral_, lsClave)
        If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If

    End Sub

    Private Sub LPParametrosFechas()
        'Dim lsProcedureName As String = "Parametros Fechas"
        'Dim lsTipo As String = sFecha_
        'Dim lsClave As String = ""
        'Dim lsValor As String = ""
        ' GPBitacoraRegistrar(sENTRO_, lsProcedureName)

        'lsClave = "Caja - Hora de cierre"
        'lsValor = "15:59:59"
        'If GFsParametroObtener(lsTipo, lsClave) = sRESERVADO_ Then
        '    GPParametroGuardar(lsTipo, lsClave, lsValor)
        'End If

        ' GPBitacoraRegistrar(sSALIO_, lsProcedureName)
    End Sub

    Private Sub LPParametrosModulos()
        '---------------------------------------------------------------------------
        'TODO: AQUI DEBEN INDICARSE LAS INICIALIZACIONES DE PARAMETROS PARA
        '      UN MODULO ESPECIFICO.
        '---------------------------------------------------------------------------
        'Dim loParametroSistema As New ParametroSistema
        'Dim lsProcedureName As String = "Parametros Modulos"
        'Dim lsTipo As String = sModulo_
        'Dim lsClave As String
        'Dim lsValor As String
        'BitacoraProceso.Registrar(sENTRO_, lsProcedureName)

        'lsClave = "Caja - Hora de cierre"
        'lsValor = "15:59:59"
        'If loParametroSistema.Obtener(lsTipo, lsClave) = sRESERVADO_ Then
        '    loParametroSistema.Guardar(lsTipo, lsClave, lsValor)
        'End If

        'BitacoraProceso.Registrar(sSALIO_, lsProcedureName)
    End Sub

    Private Function LFsEstableceConexion(ByVal psRama As String, ByVal psTitulo As String) As String
        Dim lsResultado As String = sOk_
        Dim loParametroConexion As New ParametrosConexion
        Dim loConexion As BaseDatos
        loParametroConexion.dbms = LFsRecuperaParametroConexion(psRama, loParametroConexion.claveDbms)
        loParametroConexion.server = LFsRecuperaParametroConexion(psRama, loParametroConexion.claveServer)
        loParametroConexion.port = LFsRecuperaParametroConexion(psRama, loParametroConexion.clavePort)
        loParametroConexion.database = LFsRecuperaParametroConexion(psRama, loParametroConexion.claveDatabase)
        loParametroConexion.user = LFsRecuperaParametroConexion(psRama, loParametroConexion.claveUser)
        loParametroConexion.password = LFsRecuperaParametroConexion(psRama, loParametroConexion.clavePassword)
        loConexion = New BaseDatos
        Try
            loConexion.Configurar(loParametroConexion)
            loConexion.Conectar("ConexionDB")
        Catch ex As BaseDatosException
            Dim loParametroAviso As New ParametrosAviso
            loParametroAviso.titulo = psTitulo
            loParametroAviso.parametroConexion = loParametroConexion
            loParametroAviso.mensajeError = ex.Message
            GFsAvisar(loParametroAviso)
            lsResultado = sError_
        Catch ex As DbException
            Dim loParametroAviso As New ParametrosAviso
            loParametroAviso.titulo = psTitulo
            loParametroAviso.parametroConexion = loParametroConexion
            loParametroAviso.codigoError = ex.ErrorCode.ToString
            loParametroAviso.mensajeError = ex.Message
            GFsAvisar(loParametroAviso)
            lsResultado = sError_
        Finally
            loConexion.Desconectar("ConexionDB")
        End Try
        loConexion = Nothing

        Return lsResultado
    End Function

    Private Function LFsRecuperaParametroConexion(ByVal psRama As String, ByVal psClave As String) As String
        Dim lsRama As String = psRama & sResetear_ & sDS_
        Dim lsClave As String = psClave.Substring(0, psClave.Length - 1)
        Dim lsResultado As String

        lsResultado = GFsGetRegistry(lsRama, lsClave)
        If lsResultado <> sRESERVADO_ Then
            If SesionActiva.AutorizadoResetear(lsRama, lsClave, lsResultado) = sSi_ Then
                GPSavRegistry(psRama, psClave, lsResultado)
                GPSavRegistry(lsRama, lsClave, sRESERVADO_)
            End If
        End If

        lsResultado = GFsGetRegistry(psRama, psClave)
        Return lsResultado
    End Function

    Private Sub LPControlesFinales()
        If GFsGetRegistry(sSesion_, "TipoEjecución") = sAutomatico_ Then
            Dim liSleep As Integer = CInt(GFsParametroObtener(sGeneral_, "GPProcesarBulk - Tiempo de espera"))
            Do While True
                If GFsGetAccessToken(sSesion_, sServSocketFinal_) <> sRESERVADO_ Then
                    Exit Do
                End If
                Threading.Thread.Sleep(liSleep)
            Loop
        End If
        Dim lsFilename As String = ""
        Dim lsArchivoBitacora As String = ""
        '-------------------------------------------------------------------------------------------
        'TODO: Incluir los Controles Finales antes de salir del sistema
        '-------------------------------------------------------------------------------------------
        GPActualizaUltimoAcceso()
        moBitacoraProceso.Cerrar()
        lsFilename = BitacoraProceso.fileName
        lsArchivoBitacora = BitacoraProceso.archivoBitacora
        moBitacoraProceso = Nothing
        moSesionActiva.EnviarBitacoraCorreo(lsFilename, lsArchivoBitacora)
        moSesionActiva = Nothing
    End Sub
End Module
