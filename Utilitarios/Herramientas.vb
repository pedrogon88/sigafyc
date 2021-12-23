Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports SAPbobsCOM

Public Module Herramientas
    Public Function GFsSHA256(ByVal psValue As String, Optional ByVal pbConSal As Boolean = True) As String
        Dim loSha256 As SHA256 = SHA256Managed.Create()
        Dim lsSalt As String = ""
        Dim lbBytes As Byte()
        If pbConSal Then
            Dim lsSetupSalt = GFsGetRegistry(sEncriptacion_, sSetupSalt_)
            Dim lsForcedSalt = GFsGetRegistry(sSeguridad_, sForcedSalt_)

            lsSalt = lsSetupSalt
            If lsForcedSalt <> sRESERVADO_ Then
                If SesionActiva.AutorizadoResetear(sSeguridad_, sForcedSalt_, lsForcedSalt) = sSi_ Then
                    lsSalt = lsForcedSalt
                    GPSavRegistry(sEncriptacion_, sSetupSalt_, lsSalt)
                    GPSavRegistry(sSeguridad_, sForcedSalt_, sRESERVADO_)
                End If
            End If
            lbBytes = Encoding.UTF8.GetBytes(psValue & lsSalt)
        Else
            lbBytes = Encoding.UTF8.GetBytes(psValue)
        End If
        Dim lbHash As Byte() = loSha256.ComputeHash(lbBytes)
        Dim loStringBuilder As New StringBuilder()

        For i As Integer = 0 To lbHash.Length - 1
            loStringBuilder.Append(lbHash(i).ToString("X2"))
        Next

        Return loStringBuilder.ToString()
    End Function

    Public Function GFsSHA512(ByVal psValue As String, Optional ByVal pbConSal As Boolean = True) As String
        Dim loSha512 As SHA512 = SHA512Managed.Create()
        Dim lbBytes As Byte()
        Dim lsSalt As String = ""
        If pbConSal Then
            Dim lsSetupSalt = GFsGetRegistry(sEncriptacion_, sSetupSalt_)
            Dim lsForcedSalt = GFsGetRegistry(sSeguridad_, sForcedSalt_)

            lsSalt = lsSetupSalt
            If lsForcedSalt <> sRESERVADO_ Then
                If SesionActiva.AutorizadoResetear(sSeguridad_, sForcedSalt_, lsForcedSalt) = sSi_ Then
                    lsSalt = lsForcedSalt
                    GPSavRegistry(sEncriptacion_, sSetupSalt_, lsSalt)
                    GPSavRegistry(sSeguridad_, sForcedSalt_, sRESERVADO_)
                End If
            End If
            lbBytes = Encoding.UTF8.GetBytes(psValue & lsSalt)
        Else
            lbBytes = Encoding.UTF8.GetBytes(psValue)
        End If
        Dim lbHash As Byte() = loSha512.ComputeHash(lbBytes)
        Dim loStringBuilder As New StringBuilder()

        For i As Integer = 0 To lbHash.Length - 1
            loStringBuilder.Append(lbHash(i).ToString("X2"))
        Next

        Return loStringBuilder.ToString()
    End Function

    Public Function GFiAleatorio(Optional ByVal piDesde As Integer = 1, Optional ByVal piHasta As Integer = 9999) As Integer
        Dim liNumero As Integer
        Dim liWatchDog As Integer = 0
        Randomize()
        Do
            liWatchDog += 1
            liNumero = CInt(Math.Ceiling(Rnd() * piHasta)) + piDesde
            If liWatchDog = 100 Then Exit Do
        Loop Until liNumero >= piDesde And liNumero <= piHasta
        Return liNumero
    End Function

    Public Sub GPBitacoraRegistrar(ByVal psAccion As String, ByVal psAccionDetalle As String)
        Dim loBitacoraProceso As New BitacoraProceso
        loBitacoraProceso.Registrar(psAccion, psAccionDetalle)
        loBitacoraProceso = Nothing
    End Sub

    Public Function GFsGetRegistry(ByVal psRama As String, ByVal psClave As String) As String
        Dim lsResultado As String = ""
        Dim loRegistry As New Registry
        lsResultado = loRegistry.GetRegistry(psRama, psClave)
        loRegistry = Nothing
        Return lsResultado
    End Function

    Public Sub GPSavRegistry(ByVal psRama As String, ByVal psClave As String, ByVal psValor As String)
        Dim loRegistry As New Registry
        loRegistry.SavRegistry(psRama, psClave, psValor)
        loRegistry = Nothing
    End Sub

    Public Function GFsParametroObtener(ByVal psTipo As String, ByVal psClave As String, Optional ByVal psEscalando As String = sSi_) As String
        Dim lsResultado As String = ""
        Dim loParametroSistema As New ParametroSistema
        lsResultado = loParametroSistema.Obtener(psTipo, psClave, psEscalando)
        If lsResultado.Trim.Length > 0 Then
            If lsResultado.Last = ControlChars.CrLf Then lsResultado.Substring(0, lsResultado.Length - 1)
        End If
        loParametroSistema = Nothing
        Return lsResultado
    End Function

    Public Sub GPParametroGuardar(ByVal psTipo As String, ByVal psClave As String, ByVal psValor As String, Optional ByVal psEscalando As String = sSi_)
        Dim loParametroSistema As New ParametroSistema
        loParametroSistema.Guardar(psTipo, psClave, psValor, psEscalando)
        loParametroSistema = Nothing
    End Sub

    Public Function GFsGeneraSQL(ByVal psCodigo As String, Optional ByVal psTipo As String = sGeneral_, Optional ByVal psTablaGeneral As String = "Tabla general - SQL del sistema", Optional ByVal psUbicacion As String = "Ubicacion - SQL", Optional ByVal psDefaultParametro As String = "") As String
        Dim lsResultado As String = ""
        Dim lsSS030_codigo As String = GFsParametroObtener(psTipo, psTablaGeneral)

        Dim loDatos As New Ess040tabdet
        loDatos.ss010_codigo = SesionActiva.sistema
        loDatos.ss030_codigo = lsSS030_codigo
        loDatos.codigo = psCodigo
        If loDatos.GetPK = sSinRegistros_ Then
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsSS030_codigo
            loDatos.codigo = psCodigo
            loDatos.nombre = "Descripcion " & psCodigo
            loDatos.detalle = GFsRecuperaSQLArchivo(psCodigo, psUbicacion)
            Try
                loDatos.Add(sNo_, sNo_)
            Catch ex As Exception
                GFsAvisar("Herramientas.GfsGeneraSQL", sMENSAJE_, ex.Message)
            End Try
        End If
        lsResultado = loDatos.detalle
        Dim lsParametros As String = ""
        If psDefaultParametro.Trim.Length > 0 Then
            lsParametros = psDefaultParametro
        Else
            Dim lsTipo As String = GFsParametroObtener(sGeneral_, "GFsGeneralSQL_TipoParametro")
            Dim lsTipoParametro As String = GFsParametroObtener(sGeneral_, "Parametro_predeterminado_TipoParametro_" & psCodigo)
            If lsTipoParametro = sRESERVADO_ Then
                lsTipoParametro = lsTipo
                GPParametroGuardar(sGeneral_, "Parametro_predeterminado_TipoParametro_" & psCodigo, lsTipoParametro)
            End If
            lsParametros = GFsParametroObtener(lsTipoParametro, "Parametro_predeterminado_" & psCodigo, sNo_)
        End If
        Dim loParametros() As String = Nothing
        Dim loParametro() As String = Nothing
        If lsParametros <> "" And lsParametros <> sRESERVADO_ Then
            loParametros = lsParametros.Split(sSF_)
            If loParametros.Count > 0 Then
                For liPos As Integer = 0 To loParametros.Count - 1
                    loParametro = loParametros(liPos).Split("="c)
                    lsResultado = lsResultado.Replace(loParametro(0), loParametro(1))
                Next
            End If
        End If
        loDatos.CerrarConexion()
        loDatos = Nothing
        Return lsResultado
    End Function

    Public Sub GPTablaGeneralObtener(ByVal psCodigo As String, Optional ByVal psSS010_codigo As String = "")
        Dim lsResultado As String = ""
        Dim loSS030 As New Ess030tabcab
        Dim lsSS010_codigo As String = psSS010_codigo
        If lsSS010_codigo.Trim.Length = 0 Then
            lsSS010_codigo = SesionActiva.sistema
        End If

        loSS030.ss010_codigo = lsSS010_codigo
        loSS030.codigo = psCodigo
        If loSS030.GetPK = sSinRegistros_ Then
            loSS030.ss010_codigo = lsSS010_codigo
            loSS030.codigo = psCodigo
            loSS030.nombre = "Descripcion " & psCodigo
            Try
                loSS030.Add(sNo_, sNo_)
            Catch ex As Exception
                GFsAvisar("Herramientas.GFsTablaGeneralObtener", sMENSAJE_, ex.Message)
            End Try
        End If
        loSS030.CerrarConexion()
        loSS030 = Nothing
    End Sub

    Public Function GFsRecuperaSQLArchivo(ByVal psFileName As String, Optional psUbicacion As String = "Ubicacion - SQL") As String
        Dim lsResultado As String = sRESERVADO_
        Dim lsUbicacion As String = GFsParametroObtener(sLocal_, psUbicacion)
        Dim lsExtension() As String = sExtensionesTipicas_.Split("|"c)
        Dim liCantidad As Integer = lsExtension.Count
        Dim lsFile As String = ""
        GPDirectoryCheck(lsUbicacion)

        For liPos As Integer = 0 To liCantidad - 1
            lsFile = lsUbicacion & sDS_ & psFileName & lsExtension(liPos)
            Try
                If System.IO.File.Exists(lsFile) Then
                    lsResultado = System.IO.File.ReadAllText(lsFile)
                    Exit For
                End If
            Catch ex As Exception
                GFsAvisar("Herramientas.GFsRecuperaSQLArchivo", sMENSAJE_, ex.Message)
            End Try
        Next
        Return lsResultado
    End Function

    Public Sub GPDirectoryCheck(ByVal psUbicacion As String)
        If psUbicacion.Trim.Length = 0 Then Exit Sub

        If Not System.IO.Directory.Exists(psUbicacion) Then
            System.IO.Directory.CreateDirectory(psUbicacion)
        End If
    End Sub

    Public Sub GPActualizaUltimoAcceso()
        Dim loArchivoControl As New ArchivoControl
        loArchivoControl.Actualizar()
        loArchivoControl = Nothing
        Dim lsClave As String = "Sesion - Fecha/Hora ultimo acceso_"
        Dim lsValor As String = Now.ToString(sFormatoFechaHora1_)
        GPParametroGuardar(sLocal_, lsClave, lsValor, sNo_)
    End Sub

    Public Function GFsEjecutaProceso(ByVal psComando As String, ByVal psArgumentos As String, Optional ByVal psConBitacora As String = sSi_) As String
        If psConBitacora = sSi_ Then
            GPBitacoraRegistrar(sENTRO_, "GFsEjecutarProceso --> Comando:" & psComando & ", Argumentos:" & psArgumentos)
        End If
        Dim lsResultado As String = ""
        Dim loProceso As New Process()
        Dim loProcesoInfo As ProcessStartInfo = Nothing
        If psArgumentos.Trim.Length = 0 Then
            loProcesoInfo = New ProcessStartInfo(psComando)
        Else
            loProcesoInfo = New ProcessStartInfo(psComando, psArgumentos)
        End If
        loProcesoInfo.UseShellExecute = False
        loProcesoInfo.RedirectStandardOutput = True
        loProcesoInfo.RedirectStandardError = True
        'loProcesoInfo.CreateNoWindow = True
        loProceso.StartInfo = loProcesoInfo
        loProceso.Start()

        Dim lsStandardOutput As String = ""
        Dim lsStandardError As String = ""

        Dim loStreamReader As StreamReader = loProceso.StandardOutput
        lsStandardOutput = loStreamReader.ReadToEnd()
        Dim lsStandardOutput2 As String = lsStandardOutput.Replace(vbCrLf, "|")
        If psConBitacora = sSi_ Then
            GPBitacoraRegistrar(sMENSAJE_, "Salida standard:" & lsStandardOutput)
        End If

        loStreamReader = loProceso.StandardError
        lsStandardError = loStreamReader.ReadToEnd()
        Dim lsStandardError2 = lsStandardError.Replace(vbCrLf, "|")
        If psConBitacora = sSi_ Then
            GPBitacoraRegistrar(sMENSAJE_, "Salida Error:" & lsStandardError)
        End If

        If lsStandardOutput.Length > 0 Then
            lsResultado = lsStandardOutput2
        Else
            If lsStandardError.Length > 0 Then
                lsResultado = lsStandardError2
            End If
        End If
        Return lsResultado
    End Function

    Public Function GFsCOQLExtraeCampos(ByVal psCOQL As String) As String
        Dim lsResultado As String = ""
        If psCOQL = sRESERVADO_ Then
            Return lsResultado
            Exit Function
        End If

        Dim lsCampos As String = "SELECT "
        lsCampos = psCOQL.Substring(psCOQL.IndexOf(lsCampos) + lsCampos.Length, psCOQL.IndexOf(" FROM") - lsCampos.Length)
        Dim loCampos() As String = lsCampos.Split(","c)
        Dim liCantidad As Integer = loCampos.Count
        For liPos As Integer = 0 To liCantidad - 1
            Dim lsCampo As String = loCampos(liPos).ToString.Trim
            Dim liNDX As Integer = InStr(loCampos(liPos).ToLower, " as ", CompareMethod.Text)
            If liNDX > 0 Then
                lsCampo = loCampos(liPos).Substring(liNDX - 1 + " as ".Length, loCampos(liPos).Length - (liNDX - 1 + " as ".Length))
            End If
            If lsResultado.Trim.Length = 0 Then
                lsResultado = lsCampo
            Else
                lsResultado &= "," & lsCampo
            End If
        Next
        Return lsResultado
    End Function

    Public Function GFoRecuperaModelo(ByVal piNumtra As Integer, Optional psTabla As String = "OITM") As DataTable
        Dim lsCodigo As String = GFsParametroObtener(sGeneral_, "ZohoAPI V2 - Modelo - Detalle")
        Dim loConexion As New BaseDatos
        Dim loResultado As DataTable = Nothing

        loConexion.SetearParametrosConexion(sRegistryTablasSAP_, psTabla)
        loConexion.Conectar(psTabla)
        Dim lsSQL As String = GFsGeneraSQL(lsCodigo)
        lsSQL = lsSQL.Replace("&numtra", piNumtra.ToString)
        loConexion.CrearComando(lsSQL)
        loResultado = loConexion.EjecutarConsultaTable()
        loConexion.Desconectar()
        loConexion = Nothing
        Return loResultado
    End Function

    Public Function GFoRecuperaDataTable(ByVal psCodigo As String, Optional ByVal psTabla As String = "OITM", Optional ByVal piNumMod As Integer = -1, Optional ByVal psDefaultParametro As String = "") As DataTable
        GPBitacoraRegistrar(sENTRO_, "GFoRecuperaDataTable --> Script:" & psCodigo & ", Tabla: " & psTabla & ", Modelo:" & piNumMod.ToString)
        Dim loConexion As BaseDatos = New BaseDatos
        Dim loResultado As DataTable = Nothing

        loConexion.SetearParametrosConexion(sRegistryTablasSAP_, psTabla)
        loConexion.Conectar(psTabla)
        Dim lsSQL As String = GFsGeneraSQL(psCodigo,,,, psDefaultParametro)
        GPBitacoraRegistrar(sSQL_, lsSQL)
        If piNumMod <> -1 Then
            lsSQL = GFsSQLRefinado(lsSQL, piNumMod)
            GPBitacoraRegistrar(sSQL_ & " refinado", lsSQL)
        End If
        loConexion.CrearComando(lsSQL)
        loResultado = loConexion.EjecutarConsultaTable()
        loResultado.TableName = psCodigo
        loConexion.Desconectar()
        loConexion = Nothing
        GPBitacoraRegistrar(sMENSAJE_, "DataTable: cantidad registro(s): " & loResultado.Rows.Count)
        GPBitacoraRegistrar(sSALIO_, "GFoRecuperaDataTable --> Script:" & psCodigo & ", Tabla: " & psTabla & ", Modelo:" & piNumMod.ToString)
        Return loResultado
    End Function

    Public Function GFoVerificaFrecuencia(ByVal psFechaInicio As String, Optional ByVal psTipoFrec As String = sFrecSegundos_, Optional ByVal psFormatoFecha As String = "yyyy-MM-dd HH:mm:ss") As Double
        GPBitacoraRegistrar(sENTRO_, "GFoVerificaFrecuencia --> Desde:" & psFechaInicio & ", Tipo Frec.: " & psTipoFrec & ", Formato fecha:" & psFormatoFecha)
        Dim lsResultado As String = ""
        Dim lsInicio As String = psFechaInicio
        Dim lsAhora As String = Now.ToString(psFormatoFecha)
        Dim ldTiempo As Double = 0

        Select Case psTipoFrec.ToLower
            Case sFrecSegundos_.ToLower
                ldTiempo = (DateTime.Parse(lsAhora) - DateTime.Parse(lsInicio)).TotalSeconds
            Case sFrecMinutos_.ToLower
                ldTiempo = (DateTime.Parse(lsAhora) - DateTime.Parse(lsInicio)).TotalMinutes
            Case sFrecHoras_.ToLower
                ldTiempo = (DateTime.Parse(lsAhora) - DateTime.Parse(lsInicio)).TotalHours
            Case sFrecDias_.ToLower
                ldTiempo = (DateTime.Parse(lsAhora) - DateTime.Parse(lsInicio)).TotalDays
        End Select
        lsResultado = "GFoVerificaFrecuencia -> Resultado: " & ldTiempo.ToString & "-->" & psTipoFrec
        GPBitacoraRegistrar(sMENSAJE_, lsResultado)
        GPBitacoraRegistrar(sSALIO_, "GFoVerificaFrecuencia --> Desde:" & psFechaInicio & ", Tipo Frec.: " & psTipoFrec & ", Formato fecha:" & psFormatoFecha)
        Return ldTiempo
    End Function

    Public Function GFsSQLRefinado(ByVal psSQL As String, ByVal piNumMod As Integer) As String
        Dim lsSQLRefinado As String = "SELECT" & vbCrLf
        Dim loModelo As DataTable = GFoRecuperaModelo(piNumMod)
        Dim loDataRow As DataRow
        Dim liContador As Integer = 0
        For Each loDataRow In loModelo.Rows
            liContador += 1
            lsSQLRefinado &= "X." & loDataRow.Item("origen").ToString & " As " & loDataRow.Item("destino").ToString
            If liContador < loModelo.Rows.Count Then
                lsSQLRefinado &= ","
            End If
            lsSQLRefinado &= vbCrLf
        Next
        lsSQLRefinado &= "FROM" & vbCrLf & "(" & vbCrLf
        lsSQLRefinado &= psSQL & vbCrLf
        lsSQLRefinado &= ") X" & vbCrLf
        Return lsSQLRefinado
    End Function
End Module