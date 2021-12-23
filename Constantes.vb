Public Module Constantes
    Public Const sPOSTGRES_ As String = "POSTGRES"
    Public Const sSQLSERVER_ As String = "SQLSERVER"
    Public Const sMYSQL_ As String = "MYSQL"

    Public Const sNODEFINIDO_ As String = "***NO DEFINIDO***"
    Public Const sRESERVADO_ As String = "***RESERVADO***"
    Public Const sNOAUTORIZADO_ As String = "***NO AUTORIZADO***"
    Public Const sSINCOMENTARIO_ As String = "***NO DEJO COMENTARIO***"
    Public Const sNOASIGNADO_ As String = "*** NO ASIGNADO ***"
    Public Const sRegistryRoot_ As String = "Software" & sDS_
    Public Const sRegistryZohoAPICode_ As String = "ZohoAPI" & sDS_ & "Codes" & sDS_
    Public Const sRegistryTablasSeguridad_ As String = "Tablas" & sDS_ & sSeguridad_ & sDS_
    Public Const sRegistryTablasPrincipal_ As String = "Tablas" & sDS_ & sPrincipal_ & sDS_
    Public Const sRegistryObjetosSAP_ As String = "Objetos" & sDS_ & sSAP_ & sDS_
    Public Const sRegistryTablasSAP_ As String = "Tablas" & sDS_ & sSAP_ & sDS_
    Public Const sRegistryTablasBasura_ As String = "Tablas" & sDS_ & sBasura_ & sDS_

    Public Const sOk_ As String = "Ok"
    Public Const sCancelar_ As String = "Cancelado"
    Public Const sError_ As String = "Error"
    Public Const sSinRegistros_ As String = "Error"
    Public Const sErrorHashid_ As String = "Error HashId"
    Public Const sNo_ As String = "No"
    Public Const sSi_ As String = "Si"
    Public Const sGenerar_ As String = "Generar"
    Public Const sDS_ As String = "\\"
    Public Const sEnviarMail_ As String = "EnviarMail"
    Public Const sMailEnviado_ As String = "MailEnviado"
    Public Const sAuto_ As String = "**AUTO**"
    Public Const sAddressTo_ As String = "To"
    Public Const sAddressCC_ As String = "CC"
    Public Const sAddressCCO_ As String = "CCO"

    Public Const sSufijoSS_ As String = "_ss"
    Public Const sSufijoBasura_ As String = "_basura"

    Public Const sAGREGAR_ As String = "AGREGAR"
    Public Const sMODIFICAR_ As String = "MODIFICAR"
    Public Const sBORRAR_ As String = "ELIMINAR"
    Public Const sCONSULTAR_ As String = "CONSULTAR"
    Public Const sELEGIR_ As String = "ELEGIR"
    Public Const sMENSAJE_ As String = "MENSAJE"
    Public Const sENTRO_ As String = "ENTRO"
    Public Const sSALIO_ As String = "SALIO"
    Public Const sINFORMAR_ As String = "INFORMAR"
    Public Const sWRESPONSE_ As String = "WRESPONSE"
    Public Const sWDATA_ As String = "WDATA"
    Public Const sSUCCESS_ As String = "SUCCESS"
    Public Const sSQL_ As String = "SQL" & ControlChars.CrLf
    Public Const sPrefAccesoRapido_ As String = "&"
    Public Const sEjecutar_ As String = "EJECUTAR"
    Public Const sCompactar_ As String = "COMPACTAR"
    Public Const sSumar_ As String = "SUMAR"
    Public Const sRestar_ As String = "RESTAR"
    Public Const sCompra_ As String = "Compra"
    Public Const sVenta_ As String = "Venta"
    Public Const sSemisuma_ As String = "Semisuma"

    Public Const sBorrado_ As String = "*"
    Public Const sBlanco_ As String = " "
    Public Const sPrefijoParam_ As String = "@"
    Public Const sActivo_ As String = "Activo"
    Public Const sBloqueado_ As String = "Bloqueado"
    Public Const sImportado_ As String = "Importado"
    Public Const sBorradoField_ As String = "borrado"
    Public Const sHashidField_ As String = "hashid"
    Public Const sBS_ As String = " "
    Public Const sBulk_ As String = "BULK"
    Public Const sDeAUno_ As String = "DEAUNO"

    Public Const sSF_ As Char = "|"c
    Public Const sSCSV_ As Char = ";"c
    Public Const sString_ As String = ".String"
    Public Const sInteger_ As String = ".Integer"
    Public Const sDecimal_ As String = ".Decimal"
    Public Const sDouble_ As String = ".Double"

    Public Const iYearsLimit_ As Integer = 30
    Public Const sTipoMsgLargo_ As String = "Largo"

    Public Const sMenu_ As String = "Menu"
    Public Const sMenuOpcion As String = "O"

    Public Const sNivel_ As String = "3"

    Public Const sNivel1_ As String = "1"
    Public Const sNivel2_ As String = "2"
    Public Const sNivel3_ As String = "3"
    Public Const sNivel4_ As String = "4"
    Public Const sNivel5_ As String = "5"
    Public Const sNivel6_ As String = "6"

    Public Const sGeneral_ As String = "General"
    Public Const sLocal_ As String = "Local"
    Public Const sUsuario_ As String = "Usuario"
    Public Const sFecha_ As String = "Fecha"
    Public Const sModulo_ As String = "Modulo"
    Public Const sResetear_ As String = "Resetear"
    Public Const sPerfil_ As String = "Perfil"
    Public Const sMensual_ As String = "Mensual"

    Public Const sFiltroBorrado_ As String = ControlChars.CrLf & sBorradoField_ & " <> " & Chr(39) & sBorrado_ & Chr(39)
    Public Const sFiltroSentencia_ As String = "upper(concat(@filtrocampo)) Like upper('%@filtrovalor%')"
    Public Const sFiltroCampo_ As String = sPrefijoParam_ & "filtrocampo"
    Public Const sFiltroValor_ As String = sPrefijoParam_ & "filtrovalor"

    Public Const sCero1_ As String = "0"
    Public Const sCero2_ As String = "00"
    Public Const sCero3_ As String = "000"
    Public Const sCero4_ As String = "0000"
    Public Const sCero5_ As String = "00000"
    Public Const sCero6_ As String = "000000"
    Public Const sSeparador_ As Char = "."c

    Public Const sImputable_ As String = "Imputable"
    Public Const sTotales_ As String = "Totales"

    Public Const sBotonAuditoria_ As String = "btnAuditoria"
    Public Const sBotonesSinRestriccion_ As String = "btnAceptar" & sSF_ & "btnCancelar" & sSF_ & "btnSalir" & sSF_ & "btnConsultar" & sSF_ & "btnImprimir" & sSF_ & "btnBuscar" & sSF_ & sBotonAuditoria_
    Public Const sPrefijoControles_ As String = "btn" & sSF_ & "mnu"
    Public Const sForm_ As String = "frmF"
    Public Const sPrefijoTextBox_ As String = "txt"
    Public Const sPrefijoComboBox_ As String = "cmb"
    Public Const sPrefijoRadioButton_ As String = "rbt"
    Public Const sPrefijoCheckBox_ As String = "chk"
    Public Const sPrefijoGroupBox_ As String = "gbx"
    Public Const sPrefijoFormularios_ As String = "frmB" & sSF_ & sForm_ & sSF_ & "frmM"
    Public Const sExtensionBitacora_ As String = ".txt"
    Public Const sExtensionSQL_ As String = ".sql"
    Public Const sExtensionPython_ As String = ".py"
    Public Const sFormReporte_ As String = "frmR"
    Public Const sMarcaEncriptado_ As String = "_"
    Public Const sExtensionesTipicas_ As String = sExtensionBitacora_ & sSF_ & sExtensionPython_ & sSF_ & sExtensionSQL_

    Public Const sManagerName_ = "SUPERVISOR"   '--> En Desarrollo
    Public Const sManagerPassword_ = "t3k0p1r3#864222"  '--> En desarrollo
    'Public Const sManagerName_ = "MANAGER"  '--> En Produccion
    'Public Const sManagerPassword_ As String = "544a1de2fc5bee37f7f1ae4306c7c72dbe81dd58a756ab43e7f1d597f5fdb7ed"  '--> En Produccion

    Public Const iHojaA4_ As Integer = 9
    Public Const iHojaExecutive_ As Integer = 7
    Public Const iHojaLegal_ As Integer = 5
    Public Const iHojaLetter_ As Integer = 1

    Public Const sEncriptacion_ As String = "Encriptacion"
    Public Const sSesion_ As String = "Sesion"
    Public Const sZohoAPIV2_ As String = "ZohoAPIV2"
    Public Const sSeguridad_ As String = "Seguridad"
    Public Const sPrincipal_ As String = "Principal"
    Public Const sSAP_ As String = "Sap"
    Public Const sBasura_ As String = "Basura"
    Public Const sSetupSalt_ As String = "SetupSalt_"
    Public Const sForcedSalt_ As String = "ForcedSalt"
    Public Const sSaltDefault_ As String = "tekopire#864222"
    Public Const sResetPassword_ As String = "ResetPassword_"
    Public Const sPasswordReset_ As String = "ResetPassword"
    Public Const sPasswordSalir_ As String = "t3k0p1r3864222"
    Public Const sViolacion_ As String = "Violación Seguridad"
    Public Const sAvisoUsuario_ As String = "Aviso Usuario"
    Public Const sAvisoSupervisor_ As String = "Aviso Supervisor"
    Public Const sUbicacionBitacora_ As String = "UbicacionBitacora"

    Public Const sSalirSistema_ As String = sErrorHashid_ & sSF_ & sViolacion_ & sSF_ & sBloqueado_

    Public Const sFechaExpiracion_ As String = "FechaExpiracion"
    Public Const sSerialHDD_ As String = "SerialHDD"
    Public Const sRazonSocial_ As String = "RazonSocial"
    Public Const sUltimoAcceso_ As String = "UltimoAcceso"
    Public Const sUsuarioSupervisor_ As String = "UsuarioSupervisor"
    Public Const sPasswordSupervisor_ As String = "PasswordSupervisor"

    Public Const sDEAN_ As String = "_AN" '--> Alfanumerico
    Public Const sDEAB_ As String = "_AB" '--> Alfabetico
    Public Const sDENE_ As String = "_NE" '--> Numero Entero
    Public Const sDEND_ As String = "_ND" '--> Numero Decimal
    Public Const sDEFE_ As String = "_FE" '--> Fecha
    Public Const sDESR_ As String = "_SR" '--> Solo RUC

    Public Const sDEControles_ As String = sPrefijoTextBox_ & sSF_ & sPrefijoComboBox_
    Public Const sArchivoControlCrear_ As String = "CrearArchivoControl"
    Public Const sFechaHoraAnterior_ As String = "&FecHorAnterior"
    Public Const sFormatoFecha1_ As String = "yyyy-MM-dd"
    Public Const sFormatoFechaHora1_ As String = "yyyy-MM-dd HH:mm:ss"
    Public Const sFormatoFechaHora2_ As String = "yyyy-MM-dd HH:mm:ss.fff"
    Public Const sFormatoFechaHora3_ As String = "yyyyMMddHHmmssfff"
    Public Const sFormatoFechaHora4_ As String = "dd/MM/yyyy HH:mm:ss"

    Public Const sDocPropio_ As String = "Propio"
    Public Const sDocTerceros_ As String = "Tercero"
    Public Const sFijo_ As String = "Fijo"
    Public Const sModificable_ As String = "Modificable"
    Public Const sFormatD_ As String = "D"
    Public Const sFormatC_ As String = "C"
    Public Const sFormatF_ As String = "F2"
    Public Const sDebito_ As String = "1-Debito"
    Public Const sCredito_ As String = "2-Credito"
    Public Const sIngreso_ As String = "6"
    Public Const sEgreso_ As String = "7"

    Public Const sZohoClientId_ As String = "1000.8VV5N1B9HGTPEA9MEDU30MQZ1Z1G7D"
    Public Const sZohoClientSecret_ As String = "71a9a401c58b94ecb7aae3331aec15a3671bbbd973"

    Public Const sZohoCRM_Settings_ALL_ As String = "ZohoCRM.settings.ALL"
    Public Const sZohoCRM_Settings_Modules_ALL_ = "ZohoCRM.settings.modules.ALL"
    Public Const sZohoCRM_Settings_Fields_ALL_ = "ZohoCRM.settings.fields.ALL"
    Public Const sZohoCRM_Organization_ALL_ As String = "ZohoCRM.org.ALL"
    Public Const sZohoCRM_Users_ALL_ As String = "ZohoCRM.users.ALL"
    Public Const sZohoCRM_Modules_ALL_ As String = "ZohoCRM.modules.ALL"
    Public Const sZohoCRM_Modules_Leads_ALL_ As String = "ZohoCRM.modules.leads.ALL"
    Public Const sZohoCRM_Modules_Accounts_ALL_ As String = "ZohoCRM.modules.accounts.ALL"
    Public Const sZohoCRM_Modules_Contacts_ALL_ As String = "ZohoCRM.modules.contacts.ALL"
    Public Const sZohoCRM_Modules_Products_ALL_ As String = "ZohoCRM.modules.products.ALL"
    Public Const sZohoCRM_Modules_PriceBooks_ALL_ As String = "ZohoCRM.modules.pricebooks.ALL"
    Public Const sZohoCRM_Modules_SalesOrders_ALL_ As String = "ZohoCRM.modules.salesorders.ALL"
    Public Const sZohoFiles_Files_ALL_ As String = "ZohoFiles.files.ALL"
    Public Const sZohoCRM_bulk_ALL_ As String = "ZohoCRM.bulk.ALL"
    Public Const sZohoCRM_bulk_ALL2_ As String = "ZohoCRM.bulk.ALL,ZohoCRM.modules.ALL"
    Public Const sZohoCRM_coql_READ_ As String = "ZohoCRM.coql.READ,ZohoCRM.modules.ALL"
    Public Const sZohoCRM_notifications_ALL_ As String = "ZohoCRM.notifications.ALL"
    Public Const sZohoCRM_settings_tags_ALL_ As String = "ZohoCRM.settings.tags.ALL"
    Public Const sZohoCRM_settings_roles_ALL_ As String = "ZohoCRM.settings.roles.ALL"

    Public Const sZohoV2API_Clave_TablaModulosCampos_ As String = "Zoho API V2 - Tabla Campos X "
    Public Const sZohoV2API_Clave_TablaXModulos_ As String = "Zoho API V2 - Tabla Modulos"

    Public Const sPK_AccessTokenValidez_ As String = "Access_Token - Valides - En segundos"

    Public Const sBulkInsert_ As String = "insert"
    Public Const sBulkUpdate_ As String = "update"
    Public Const sBulkUpsert_ As String = "upsert"

    Public Const sUbicacionQuerySQL_ As String = "Ubicacion - SQL"
    Public Const sUbicacionScriptPython_ As String = "Ubicacion - Scripts Python"
    Public Const sUbicacionQueryCOQL_ As String = "Ubicacion - Query COQL"

    Public Const sZIS_ZOHOsap_ As String = "Zoho->SAP"
    Public Const sZIS_SAPzoho_ As String = "SAP->Zoho"
    Public Const sZIS_TablaScriptCOQL_ As String = "Tabla general - Query COQL"
    Public Const sZIS_TablaScriptPython_ As String = "Tabla general - Scripts Python"
    Public Const sZIS_Secuencial_ As String = "Secuencial"
    Public Const sZIS_Multihilo_ As String = "MultiHilo"
    Public Const sZIS_Minuto_ As String = "Minutos"
    Public Const sZIS_Hora_ As String = "Horas"
    Public Const sZIS_Dia_ As String = "Dias"
    Public Const sZIS_Bulk_creditos_ As String = "ZohoV2API - Bulk - creditos por transaccion"
    Public Const sZIS_Http200_ As String = "HTTP Status Code: 200|HTTP Status Code : 200"
    Public Const sZIS_Http201_ As String = "HTTP Status Code : 201"
    Public Const sZIS_FileUploadSuccess_ As String = "FILE_UPLOAD_SUCCESS"
    Public Const sZIS_Search_ As String = "search"
    Public Const sZIS_ZohoId_ As String = "zohoid"
    Public Const sZIS_External_ As String = "external"

    Public Const sManual_ As String = "Manual"
    Public Const sAutomatico_ As String = "Automatico"
    Public Const sAuto_Proceso_ As String = "PERMISO"
    Public Const sQuery_ As String = "Query"
    Public Const sStoreProc_ As String = "StoreProc"
    Public Const sServSocketInicio_ As String = "Socket_Inicio"
    Public Const sServSocketFinal_ As String = "Socket_Final"
    Public Const sAutomatico1Inicio_ As String = "Automatico1_Inicio"
    Public Const sAutomatico1Final_ As String = "Automatico1_Final"
    Public Const sAutomatico2Inicio_ As String = "Automatico2_Inicio"
    Public Const sAutomatico2Final_ As String = "Automatico2_Final"

    Public Const sFrecSegundos_ As String = "Segundos"
    Public Const sFrecMinutos_ As String = "Minutos"
    Public Const sFrecHoras_ As String = "Horas"
    Public Const sFrecDias_ As String = "Dias"
    Public Const sOCRD_ As String = "OCRD"
    Public Const sOITM_ As String = "OITM"
    Public Const sOSLP_ As String = "OSLP"
    Public Const sOCPR_ As String = "OCPR"
    Public Const sOCRG_ As String = "OCRG"
    Public Const sOITB_ As String = "OITB"
    Public Const sCRD1_ As String = "CRD1"

    Public Enum eTipoValor
        NumeroEntero
        NumeroDecimal
        Alfabetico
        AlfaNumerico
        Fecha
        Ruc
    End Enum

    Public Enum eTipoHoja
        A4 = 9
        Executive = 7
        Legal = 5
        Letter = 1
    End Enum

    Public Enum eOrientacion
        Horizontal = 2
        Vertical = 1
    End Enum

    Public Enum eZohoError
        invalid_code
        invalid_client
        invalid_redirect_uri
        INVALID_URL_PATTERN
        OAUTH_SCOPE_MISMATCH
        NO_PERMISSION
        INTERNAL_ERROR
        INVALID_REQUEST_METHOD
        AUTHORIZATION_FAILED
        INVALID_MODULE
        REQUIRED_PARAM_MISSING
        NOT_SUPPORTED
        PATTERN_NOT_MATCHED
        INVALID_DATA
    End Enum
End Module
