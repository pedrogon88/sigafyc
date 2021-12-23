Imports System.Data.Common

Module modGPCierreEjercicio
    Private mbPrimero As Boolean = True
    Private msClave As String = ""
    Private msValor As String = ""
    Private miCodEmpresa As Integer = 0
    Private miCodSucursal As Integer = 0
    Private miNroAsientos() As Integer = {}
    Private miNroAsiento As Integer = 0
    Private msFechaCierre As String = ""
    Private miCodDocumento As Integer = 0
    Private msCotizacion As String = ""
    Private msCtaResultado1 As String = ""
    Private msCodMoneda_o As String = ""
    Private msCodMoneda_b As String = ""
    Private miFactor1 As Integer = 0
    Private miFactor2 As Integer = 0
    Private msConcepto As String = ""
    Private msCtaResultado2 As String = ""
    Private msCtaResultado3 As String = ""
    Private msPeriodoInicio As String = ""
    Private msPeriodoFinal As String = ""
    Private moDataReader As DbDataReader
    Private miCantidad As Integer = 0
    Private mdTotalDebitos As Decimal = 0.00D
    Private mdTotalCreditos As Decimal = 0.00D
    Private mdTotalActivo As Decimal = 0.00D
    Private mdTotalPasivo As Decimal = 0.00D
    Private mdTotalIngreso As Decimal = 0.00D
    Private mdTotalEgreso As Decimal = 0.00D
    Private mdTADebitos As Decimal = 0.00D
    Private mdTACreditos As Decimal = 0.00D
    Private Const sTipoActivo_ As String = "'1','4'"
    Private Const sTipoPasivo_ As String = "'2','3','5'"
    Private Const sTipoIngresos_ As String = "'6','6'"
    Private Const sTipoEgresos_ As String = "'7','7'"
    Private Const sConcepto_ As String = "NUESTRO ASIENTO CIERRE DE EJERCICIO - "

    Public Sub GPCierreEjercicio(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal piCodDocumento As Integer, Optional ByVal psFecha As String = "", Optional ByVal pbRecSaldos As Boolean = True, Optional ByVal pbRecCabeceras As Boolean = True)
        GPBitacoraRegistrar(sENTRO_, "Proceso CIERRE DE EJERCICIO - Empresa:" & piCodEmpresa & ", Sucursal:" & piCodSucursal & ", Cod.Documento cierre:" & piCodDocumento & ", Fecha de Cierre:" & psFecha & ", Reconstruccion Saldos:" & pbRecSaldos.ToString & ", Reconstruccion CabAsientos:" & pbRecCabeceras.ToString)
        miCodEmpresa = piCodEmpresa
        miCodSucursal = piCodSucursal
        miCodDocumento = piCodDocumento
        msFechaCierre = psFecha

        Dim liError As Integer = 0
        LPInicializaValores(liError)
        If liError = 1 Then
            GFsAvisar("El proceso CIERRE DE EJERCICIO, para Empresa:" & miCodEmpresa.ToString & ", Sucursal:" & miCodSucursal & ", ya ha sido realizado. Registro[" & msValor & "]", sMENSAJE_, "Este proceso para esta empresa y sucursal se aborta.")
            Exit Sub
        End If

        LPVerificaMovimientos(liError)
        If liError = 1 Then
            GPBitacoraRegistrar(sINFORMAR_, "Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & piCodSucursal.ToString & ", NO TIENE REGISTRADO NINGUN MOVIMIENTO.")
            GPParametroGuardar(sGeneral_, msClave, "Usuario: " & SesionActiva.usuario & ", Fecha/Hora:" & Now.ToString("yyyy-MM-dd hh:mm:ss") & " - ***SIN MOVIMIENTOS***")
            Exit Sub
        End If

        If pbRecCabeceras = True Then
            GPReconstruccionCabAsiento(miCodEmpresa, miCodSucursal, msPeriodoInicio, msPeriodoFinal, liError)
            If liError = 1 Then
                GFsAvisar("Se han encontrado errores durante el proceso de Reconstruccion de CABECERA DE ASIENTOS", sMENSAJE_, "No podrá concluirse el Asiento de Cierre de Ejericico.")
                Exit Sub
            End If
        End If
        If pbRecSaldos = True Then
            GPReconstruccionSaldos(miCodEmpresa, miCodSucursal, msPeriodoInicio, msPeriodoFinal, liError)
            If liError = 1 Then
                GFsAvisar("Se han encontrado errores durante el proceso de Reconstruccion de SALDOS DE CUENTAS", sMENSAJE_, "No podrá concluirse el Asiento de Cierre de Ejericico.")
                Exit Sub
            End If
        End If

        LPGeneraAsiento(sTipoActivo_, liError)
        If liError = 1 Then Exit Sub
        LPGeneraAsiento(sTipoPasivo_, liError)
        If liError = 1 Then Exit Sub
        LPGeneraAsiento(sTipoIngresos_, liError)
        If liError = 1 Then Exit Sub
        LPGeneraAsiento(sTipoEgresos_, liError)
        If liError = 1 Then Exit Sub
        LPVerificaCierre(liError)
        If liError = 1 Then
            For I As Integer = 0 To miNroAsientos.Length - 1
                LPEliminaDetalle(miCodEmpresa, miNroAsientos(I))
                LPEliminaCabecera(miCodEmpresa, miNroAsientos(I))
            Next
            GPReconstruccionSaldos(miCodEmpresa, miCodSucursal, msPeriodoInicio, msPeriodoFinal, liError)
            Exit Sub
        Else
            GFsAvisar("Empresa:" & miCodEmpresa.ToString & ", Sucursal:" & miCodSucursal.ToString & ", Periodo:" & msPeriodoInicio & " - " & msPeriodoFinal, sMENSAJE_, "Ha Concluido exitosamente el Cierre del Ejercicio")
            GRBalance8Columnas(miCodEmpresa, 0, msFechaCierre)
        End If

        GPParametroGuardar(sGeneral_, msClave, "Usuario: " & SesionActiva.usuario & ", Fecha/Hora:" & Now.ToString("yyyy-MM-dd hh:mm:ss"))
        GPBitacoraRegistrar(sSALIO_, "Proceso CIERRE DE EJERCICIO - Empresa:" & piCodEmpresa & ", Sucursal:" & piCodSucursal & ", Cod.Documento cierre:" & piCodDocumento & ", Fecha de Cierre:" & psFecha & ", Reconstruccion Saldos:" & pbRecSaldos.ToString & ", Reconstruccion CabAsientos:" & pbRecCabeceras.ToString)
    End Sub

    Public Sub LPInicializaValores(ByRef piError As Integer)
        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = miCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            msCtaResultado1 = loEmpresa.ctaResultado1
            msCtaResultado2 = loEmpresa.ctaResultado2
            msCtaResultado3 = loEmpresa.ctaResultado3
            msPeriodoInicio = loEmpresa.periodoInicio
            msPeriodoFinal = loEmpresa.periodoFinal
            msCodMoneda_b = loEmpresa.codMoneda
            If msFechaCierre.Trim.Length = 0 Then
                If Today.ToString("yyyy-MM-dd") > loEmpresa.periodoFinal Then
                    msFechaCierre = loEmpresa.periodoFinal
                Else
                    msFechaCierre = Today.ToString("yyyy-MM-dd")
                End If
            Else
                If msFechaCierre > loEmpresa.periodoFinal Then
                    msFechaCierre = loEmpresa.periodoFinal
                End If
            End If
        End If
        msClave = "CIERRE CONTABLE - Periodo:" & msPeriodoInicio & "/" & msPeriodoFinal & " - Empresa:" & miCodEmpresa.ToString & " - Sucursal:" & miCodSucursal.ToString
        msValor = GFsParametroObtener(sGeneral_, msClave)
        If msValor <> sRESERVADO_ Then
            piError = 1
        End If
    End Sub

    Private Sub LPGuardarTotales(ByRef piError As Integer)
        If Not mbPrimero Then Exit Sub

        mbPrimero = False
        If moDataReader.Item("codcuenta").ToString = sRESERVADO_ Then
            mdTotalDebitos = Decimal.Parse(moDataReader.Item("debitos").ToString)
            mdTotalCreditos = Decimal.Parse(moDataReader.Item("creditos").ToString)
            mdTotalActivo = Decimal.Parse(moDataReader.Item("activo").ToString)
            mdTotalPasivo = Decimal.Parse(moDataReader.Item("pasivo").ToString)
            mdTotalIngreso = Decimal.Parse(moDataReader.Item("ingresos").ToString)
            mdTotalEgreso = Decimal.Parse(moDataReader.Item("egresos").ToString)
            If mdTotalDebitos + mdTotalCreditos = 0 Then
                GFsAvisar("Atención! Empresa: " & miCodEmpresa.ToString & ", Sucursal: " & miCodSucursal.ToString & " - No tiene movimientos", sMENSAJE_, "El proceso de Cierre no será realizado.")
                piError = 1
                Exit Sub
            End If
            If mdTotalDebitos <> mdTotalCreditos Then
                piError = 1
                GFsAvisar("Atención! Existe algun asiento que no cuadra, Favor verifique para poder proseguir con este proceso.", sMENSAJE_, "El proceso de Cierre será interrumpido.")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub LPGeneraAsiento(ByVal psTipoCuenta As String, ByRef piError As Integer)
        Dim loProcesamiento As New frmProcesamiento
        Dim liError As Integer = 0

        LPVerificaCantMovimientos(psTipoCuenta, liError)
        If liError = 1 Then
            GPBitacoraRegistrar(sINFORMAR_, "Las Cuentas que inician sus codigo con [" & psTipoCuenta & "] no tienen movimientos.")
            Exit Sub
        End If

        loProcesamiento.Show()
        loProcesamiento.lblTitulo.Text = "Asiento Cierre de Ejericio - Empresa:" & miCodEmpresa.ToString & ", Sucursal:" & miCodSucursal.ToString
        LPGeneraCabecera(psTipoCuenta, piError)
        If piError = 1 Then Exit Sub

        Dim lsSQL As String = GFsGeneraSQL("GPCierreEjercicio")
        lsSQL = lsSQL.Replace("@codempresa", miCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@codsucursal", miCodSucursal.ToString)
        lsSQL = lsSQL.Replace("@fecha1", msFechaCierre)
        lsSQL = lsSQL.Replace("@ctaresultado1", msCtaResultado1)
        lsSQL = lsSQL.Replace("@tipocuenta", psTipoCuenta)

        Dim loCN As New BaseDatos

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        Try
            loCN.Conectar()
        Catch ex As Exception
            GFsAvisar("GPCierreEjercicio -> Conectando a base de datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try

        loCN.CrearComando(lsSQL)
        Try
            moDataReader = loCN.EjecutarConsulta
        Catch ex As Exception
            GFsAvisar("GPCierreEjercicio -> Recuperar datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try

        Dim ldImporte_o As Decimal = 0.00D
        Dim ldImporte_b As Decimal = 0.00D
        If moDataReader.Read Then
            LPGuardarTotales(liError)
            If liError = 1 Then Exit Sub
        End If

        While moDataReader.Read
            loProcesamiento.lblRegistroLeido.Text = moDataReader("codcuenta").ToString & " - " & moDataReader("nombre").ToString & " - " & moDataReader("debitos").ToString & " - " & moDataReader("creditos").ToString
            loProcesamiento.Refresh()
            If Decimal.Parse(moDataReader.Item("deudor").ToString) > 0.00D Then
                ldImporte_o = Decimal.Parse(moDataReader.Item("deudor").ToString)
                ldImporte_b = GFdImporte_mb(miCodEmpresa, ldImporte_o, msCodMoneda_o, msFechaCierre, msCotizacion)
                LPGeneraDetalle(moDataReader.Item("codcuenta").ToString, sCredito_, ldImporte_o, ldImporte_b, liError)
                If liError = 1 Then Exit Sub
            End If
            If Decimal.Parse(moDataReader.Item("acreedor").ToString) < 0.00D Then
                ldImporte_o = Decimal.Parse(moDataReader.Item("acreedor").ToString) * -1
                ldImporte_b = GFdImporte_mb(miCodEmpresa, ldImporte_o, msCodMoneda_o, msFechaCierre, msCotizacion)
                LPGeneraDetalle(moDataReader.Item("codcuenta").ToString, sDebito_, ldImporte_o, ldImporte_b, liError)
                If liError = 1 Then Exit Sub
            End If
            loProcesamiento.lblRegistroProcesado.Text = "Movimiento: " & moDataReader("codcuenta").ToString & " - " & moDataReader("nombre").ToString & " - " & moDataReader("debitos").ToString & " - " & moDataReader("creditos").ToString
            loProcesamiento.Refresh()
        End While
        loProcesamiento.lblRegistroLeido.Text = msCtaResultado1 & " - " & mdTotalDebitos.ToString & " - " & mdTotalCreditos.ToString
        loProcesamiento.Refresh()

        LPGeneraResultado(liError)
        If liError = 1 Then Exit Sub

        loProcesamiento.lblRegistroProcesado.Text = "Movimiento: " & msCtaResultado1 & " - " & mdTotalDebitos.ToString & " - " & mdTotalCreditos.ToString
        loProcesamiento.Refresh()

        loProcesamiento.Close()
        loProcesamiento = Nothing

        moDataReader.Close()
        moDataReader = Nothing

        loCN.Desconectar()
        loCN = Nothing
    End Sub

    Private Sub LPGeneraCabecera(ByVal psTipoCuenta As String, ByRef piError As Integer)
        Dim lsTipoCuenta As String = ""
        Dim loDocumento As New Ec020documentos
        Dim loCabecera As New Ee010asientoscabeceras
        Select Case psTipoCuenta
            Case sTipoActivo_
                lsTipoCuenta = "Activos"
            Case sTipoPasivo_
                lsTipoCuenta = "Pasivos"
            Case sTipoIngresos_
                lsTipoCuenta = "Ingresos"
            Case sTipoEgresos_
                lsTipoCuenta = "Egresos"
        End Select
        loCabecera.codEmpresa = miCodEmpresa
        miNroAsiento = loCabecera.ReservarRegistro(miCodEmpresa)
        loCabecera.codSucursal = miCodSucursal
        loCabecera.fecha = msFechaCierre
        loDocumento.codEmpresa = miCodEmpresa
        loDocumento.codDocumento = miCodDocumento
        If loDocumento.GetPK = sOk_ Then
            msCodMoneda_o = loDocumento.codMoneda
            msCotizacion = loDocumento.cotizacion
        End If
        loDocumento.CerrarConexion()
        loDocumento = Nothing
        Dim liFactor() As Integer = GFiCotizacion(msCodMoneda_o, msCodMoneda_b, msFechaCierre)
        miFactor1 = liFactor(0)
        miFactor2 = liFactor(1)
        loCabecera.codDocumento = miCodDocumento
        loCabecera.nroDocumento = Today.ToString("yyyyMMddHHmmss")
        loCabecera.codMoneda_o = msCodMoneda_o
        loCabecera.codMoneda_b = msCodMoneda_b
        loCabecera.codConcepto = 0
        msConcepto = sConcepto_ & msPeriodoInicio & " / " & msPeriodoFinal
        loCabecera.concepto = msConcepto
        loCabecera.cotizacion = msCotizacion
        loCabecera.compra = miFactor1
        loCabecera.venta = miFactor2
        Try
            loCabecera.Put(sNo_, sSi_, sAGREGAR_)
            mdTADebitos = 0.00D
            mdTACreditos = 0.00D
            Dim lsClave As String = "ULTIMO CIERRE - Empresa:" & miCodEmpresa.ToString & ", Sucursal:" & miCodSucursal.ToString & " - [" & lsTipoCuenta & "]"
            GPParametroGuardar(sGeneral_, lsClave, loCabecera.ejercicio & sSF_ & loCabecera.nroAsiento.ToString)
            Dim liTamano As Integer = miNroAsientos.Length
            ReDim miNroAsientos(liTamano + 1)
            miNroAsientos(miNroAsientos.Length - 1) = miNroAsiento
        Catch ex As DbException
            piError = 1
            GFsAvisar("GPCierreEjercicio.LPGeneraCabecera", sMENSAJE_, ex.Message)
        End Try
    End Sub

    Private Sub LPGeneraDetalle(ByVal psCodCuenta As String, ByVal psTipoMovimiento As String, ByVal pdImporte_o As Decimal, ByVal pdImporte_b As Decimal, ByRef piError As Integer, Optional ByVal psActualizar As String = sSi_)
        Dim liNroSecuencia As Integer = 0
        Dim loDetalle As New Ed010asientosdetalles
        loDetalle.codEmpresa = miCodEmpresa
        loDetalle.nroAsiento = miNroAsiento
        liNroSecuencia = loDetalle.ReservarRegistro(miCodEmpresa, miNroAsiento)
        loDetalle.codCuenta = psCodCuenta
        loDetalle.tipoMovimiento = psTipoMovimiento.Substring(0, 1)
        loDetalle.importe_mo = pdImporte_o
        loDetalle.importe_mb = pdImporte_b
        loDetalle.codConcepto = 0
        loDetalle.concepto = msConcepto
        Try
            loDetalle.Put(sNo_, sSi_, sAGREGAR_, sSi_)
        Catch ex As DbException
            GFsAvisar("GPCierreEjercicio.LPGeneraDetalle", sMENSAJE_, ex.Message)
        End Try
        loDetalle.CerrarConexion()
        loDetalle = Nothing

        If psActualizar = sSi_ Then
            Select Case psTipoMovimiento
                Case sDebito_
                    mdTADebitos += pdImporte_o
                Case sCredito_
                    mdTACreditos += pdImporte_o
            End Select
        End If
    End Sub

    Private Sub LPGeneraResultado(ByRef piError As Integer)
        Dim lsTipoMovimiento As String = ""
        Dim ldImporte_o As Decimal = 0.00D
        Dim ldImporte_b As Decimal = 0.00D
        Dim lsCodCuenta As String = msCtaResultado1
        Dim ldSaldoResultado As Decimal = mdTADebitos - mdTACreditos
        If ldSaldoResultado > 0 Then
            lsTipoMovimiento = sCredito_
            ldImporte_o = ldSaldoResultado
            ldImporte_b = GFdImporte_mb(miCodEmpresa, ldImporte_o, msCodMoneda_o, msFechaCierre, msCotizacion)
            LPGeneraDetalle(lsCodCuenta, lsTipoMovimiento, ldImporte_o, ldImporte_b, piError, sNo_)
        Else
            If ldSaldoResultado < 0 Then
                lsTipoMovimiento = sDebito_
                ldImporte_o = ldSaldoResultado * -1
                ldImporte_b = GFdImporte_mb(miCodEmpresa, ldImporte_o, msCodMoneda_o, msFechaCierre, msCotizacion)
                LPGeneraDetalle(lsCodCuenta, lsTipoMovimiento, ldImporte_o, ldImporte_b, piError, sNo_)
            End If
        End If
    End Sub

    Private Sub LPVerificaCantMovimientos(ByVal psTipoCuenta As String, ByRef piError As Integer)
        Dim lsSQL As String = GFsGeneraSQL("GPCierreEjercicio_CantMovimiento")
        lsSQL = lsSQL.Replace("@codempresa", miCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@codsucursal", miCodSucursal.ToString)
        lsSQL = lsSQL.Replace("@fecha1", msFechaCierre)
        lsSQL = lsSQL.Replace("@ctaresultado1", msCtaResultado1)
        lsSQL = lsSQL.Replace("@tipocuenta", psTipoCuenta)

        Dim loDataReader As DbDataReader
        Dim loCN As New BaseDatos

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        Try
            loCN.Conectar("TablaGenerica")
        Catch ex As Exception
            GFsAvisar("GPCierreEjercicio -> Conectando a base de datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try

        loCN.CrearComando(lsSQL)
        Try
            loDataReader = loCN.EjecutarConsulta
        Catch ex As Exception
            GFsAvisar("GPCierreEjercicio -> Recuperar datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try
        If loDataReader.Read Then
            miCantidad = Integer.Parse(loDataReader("cantidad").ToString)
            If miCantidad = 0 Then
                piError = 1
            End If
        End If
        loDataReader.Close()
        loDataReader = Nothing
        loCN.Desconectar()
        loCN = Nothing
    End Sub

    Private Sub LPVerificaMovimientos(ByRef piError As Integer)
        Dim lsSQL As String = GFsGeneraSQL("GPCierreEjercicio_LPVerificaCierre")
        lsSQL = lsSQL.Replace("@codempresa", miCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@codsucursal", miCodSucursal.ToString)
        lsSQL = lsSQL.Replace("@fecha1", msFechaCierre)
        lsSQL = lsSQL.Replace("@ctaresultado1", msCtaResultado1)

        Dim loDataReader As DbDataReader
        Dim loCN As New BaseDatos

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        Try
            loCN.Conectar("TablaGenerica")
        Catch ex As Exception
            GFsAvisar("GPCierreEjercicio -> Conectando a base de datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try

        loCN.CrearComando(lsSQL)
        Try
            loDataReader = loCN.EjecutarConsulta
        Catch ex As Exception
            GFsAvisar("GPCierreEjercicio -> Recuperar datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try
        If loDataReader.Read Then
            miCantidad = Integer.Parse(loDataReader("cantidad").ToString)
            If miCantidad = 0 Then
                piError = 1
            End If
        End If
        loDataReader.Close()
        loDataReader = Nothing
        loCN.Desconectar()
        loCN = Nothing
    End Sub

    Private Sub LPVerificaCierre(ByRef piError As Integer)
        Dim lsSQL As String = GFsGeneraSQL("GPCierreEjercicio_LPVerificaCierre")
        lsSQL = lsSQL.Replace("@codempresa", miCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@codsucursal", miCodSucursal.ToString)
        lsSQL = lsSQL.Replace("@fecha1", msFechaCierre)
        lsSQL = lsSQL.Replace("@ctaresultado1", msCtaResultado1)

        Dim loDataReader As DbDataReader
        Dim loCN As New BaseDatos

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        Try
            loCN.Conectar("TablaGenerica")
        Catch ex As Exception
            GFsAvisar("GPCierreEjercicio -> Conectando a base de datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try

        loCN.CrearComando(lsSQL)
        Try
            loDataReader = loCN.EjecutarConsulta
        Catch ex As Exception
            GFsAvisar("GPCierreEjercicio -> Recuperar datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try
        If loDataReader.Read Then
            miCantidad = Integer.Parse(loDataReader("cantidad").ToString)
            If miCantidad > 0 Then
                mdTotalDebitos = Decimal.Parse(loDataReader("debitos").ToString)
                mdTotalCreditos = Decimal.Parse(loDataReader("creditos").ToString)
                If mdTotalDebitos <> mdTotalCreditos Then
                    piError = 1
                    GFsAvisar("Los movimientos de cierre no quedaron correctamente consistente.", sMENSAJE_, "El proceso de cierre será revertido.")
                End If
            End If
        End If
        loDataReader.Close()
        loDataReader = Nothing
        loCN.Desconectar()
        loCN = Nothing
    End Sub

    Private Sub LPEliminaDetalle(ByVal piCodEmpresa As Integer, ByVal piNroAsiento As Integer)
        Dim loProcesamiento As New frmProcesamiento
        Dim lsSQL As String = GFsGeneraSQL("GPCierreEjercicio_LPEliminaDetalle")
        loProcesamiento.Show()
        loProcesamiento.lblTitulo.Text = "Revirtiendo los movimientos realizados.... Asiento No." & piNroAsiento.ToString
        Dim lsEjercicio As String = GFsEjercicioContable(piCodEmpresa)
        lsSQL = lsSQL.Replace("@codempresa", miCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@ejercicio", lsEjercicio)
        lsSQL = lsSQL.Replace("@nroasiento", miNroAsiento.ToString)

        Dim loCN As New BaseDatos
        Dim loDataReader As DbDataReader

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        Try
            loCN.Conectar("TablaGenerica")
        Catch ex As Exception
            GFsAvisar("GPCierreEjercicio_LPEliminaDetalle -> Conectando a base de datos", sMENSAJE_, ex.Message)
            Exit Sub
        End Try

        loCN.CrearComando(lsSQL)
        Try
            loDataReader = loCN.EjecutarConsulta
        Catch ex As DbException
            GFsAvisar("GPCierreEjercicio_EliminaDetalle -> Recuperar datos", sMENSAJE_, ex.Message)
            Exit Sub
        End Try

        Dim loDetalle As New Ed010asientosdetalles
        While loDataReader.Read
            loProcesamiento.lblRegistroLeido.Text = "Asiento: " & loDataReader.Item("nroasiento").ToString & ", Secuencia: " & loDataReader.Item("nrosecuencia").ToString & ", Movimiento:" & loDataReader.Item("tipomovimiento").ToString & ", Importe:" & loDataReader.Item("importe_mb").ToString
            loDetalle.codEmpresa = Integer.Parse(loDataReader.Item("codempresa").ToString)
            loDetalle.ejercicio = loDataReader.Item("ejercicio").ToString
            loDetalle.nroAsiento = Integer.Parse(loDataReader.Item("nroasiento").ToString)
            If loDetalle.GetPK = sOk_ Then
                loDetalle.Del(sNo_, sSi_, sSi_)
                loProcesamiento.lblRegistroProcesado.Text = "Asiento: " & loDataReader.Item("nroasiento").ToString & ", Secuencia: " & loDataReader.Item("nrosecuencia").ToString & ", Movimiento:" & loDataReader.Item("tipomovimiento").ToString & ", Importe:" & loDataReader.Item("importe_mb").ToString
            End If
            loProcesamiento.Refresh()
        End While
        loProcesamiento.Close()
        loProcesamiento = Nothing
        loDetalle.CerrarConexion()
        loDetalle = Nothing
        loDataReader.Close()
        loDataReader = Nothing
        loCN.Desconectar()
        loCN = Nothing
    End Sub

    Private Sub LPEliminaCabecera(ByVal piCodEmpresa As Integer, ByVal piNroAsiento As Integer)
        Dim loCabecera As New Ee010asientoscabeceras
        Dim lsEjercicio As String = GFsEjercicioContable(piCodEmpresa)
        loCabecera.codEmpresa = piCodEmpresa
        loCabecera.ejercicio = lsEjercicio
        loCabecera.nroAsiento = piNroAsiento
        If loCabecera.GetPK = sOk_ Then
            loCabecera.Del(sNo_, sSi_)
        End If
    End Sub
End Module
