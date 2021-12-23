Imports System.Data.Common

Module modGPReaperturaEjercicio
    Private mbPrimero As Boolean = True
    Private msClave As String = ""
    Private msValor As String = ""
    Private miCodEmpresa As Integer = 0
    Private msEjercicio As String = ""
    Private miCodSucursal As Integer = 0
    Private msAsientos As String = ""
    Private miNroAsientos() As Integer = {}
    Private miNroAsiento As Integer = 0
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
    Private mdTADebitos_o As Decimal = 0.00D
    Private mdTACreditos_o As Decimal = 0.00D
    Private mdTADebitos_b As Decimal = 0.00D
    Private mdTACreditos_b As Decimal = 0.00D
    Private Const sConcepto_ As String = "NUESTRO ASIENTO DE REAPERTURA DEL EJERCICIO - "

    Public Sub GPReaperturaEjercicio(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal piCodDocumento As Integer)
        GPBitacoraRegistrar(sENTRO_, "Proceso REAPERTURA DE EJERCICIO - Empresa:" & piCodEmpresa & ", Sucursal:" & piCodSucursal & ", Cod.Documento reapertura:" & piCodDocumento)
        miCodEmpresa = piCodEmpresa
        miCodSucursal = piCodSucursal
        miCodDocumento = piCodDocumento

        Dim liError As Integer = 0
        LPInicializaValores(liError)
        If liError = 1 Then
            GFsAvisar("El proceso CIERRE DE EJERCICIO, para Empresa:" & miCodEmpresa.ToString & ", Sucursal:" & miCodSucursal & ", ya ha sido realizado. Registro[" & msValor & "]", sMENSAJE_, "Este proceso para esta empresa y sucursal se aborta.")
            Exit Sub
        End If

        LPVerificaMovimientos(liError)
        If liError = 1 Then
            GPBitacoraRegistrar(sINFORMAR_, "Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & piCodSucursal.ToString & ", NO TIENE REGISTRADO MOVIMIENTOS DE CIERRES ANTERIORES.")
            GPParametroGuardar(sGeneral_, msClave, "Usuario: " & SesionActiva.usuario & ", Fecha/Hora:" & Now.ToString("yyyy-MM-dd hh:mm:ss") & " - ***SIN MOVIMIENTOS***")
            Exit Sub
        End If

        LPGeneraAsiento(liError)
        If liError = 1 Then Exit Sub

        LPVerificacionFinal(liError)
        If liError = 1 Then
            For I As Integer = 0 To miNroAsientos.Length - 1
                LPEliminaDetalle(miCodEmpresa, miNroAsientos(I))
                LPEliminaCabecera(miCodEmpresa, miNroAsientos(I))
            Next
            GPReconstruccionSaldos(miCodEmpresa, miCodSucursal, msPeriodoInicio, msPeriodoFinal, liError)
            Exit Sub
        Else
            GFsAvisar("Empresa:" & miCodEmpresa.ToString & ", Sucursal:" & miCodSucursal.ToString & ", Periodo:" & msPeriodoInicio & " - " & msPeriodoFinal, sMENSAJE_, "Ha Concluido exitosamente la REAPERTURA del Ejercicio")
            GRBalance8Columnas(miCodEmpresa, 0, msPeriodoInicio)
        End If

        GPParametroGuardar(sGeneral_, msClave, "Usuario: " & SesionActiva.usuario & ", Fecha/Hora:" & Now.ToString("yyyy-MM-dd hh:mm:ss"))
        GPBitacoraRegistrar(sSALIO_, "Proceso REAPERTURA DE EJERCICIO - Empresa:" & piCodEmpresa & ", Sucursal:" & piCodSucursal & ", Cod.Documento reapertura:" & piCodDocumento)
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
            Dim lsTipoCuenta As String = "Activos"
            Dim lsClave As String = "ULTIMO CIERRE - Empresa:" & miCodEmpresa.ToString & ", Sucursal:" & miCodSucursal.ToString & " - [" & lsTipoCuenta & "]"
            Dim lsValores As String = GFsParametroObtener(sGeneral_, lsClave)
            Dim lsValor() As String = lsValores.Split(sSF_)
            msEjercicio = lsValor(0)
            msAsientos = lsValor(1)
            lsTipoCuenta = "Pasivos"
            lsClave = "ULTIMO CIERRE - Empresa:" & miCodEmpresa.ToString & ", Sucursal:" & miCodSucursal.ToString & " - [" & lsTipoCuenta & "]"
            lsValores = GFsParametroObtener(sGeneral_, lsClave)
            lsValor = lsValores.Split(sSF_)
            If lsValor(0) <> sRESERVADO_ Then
                If msAsientos.Trim.Length > 0 Then
                    msAsientos &= "," & lsValor(1)
                Else
                    msAsientos = lsValor(1)
                End If
            End If
            msClave = "REAPERTURA EJERCICIO - Periodo:" & msPeriodoInicio & "/" & msPeriodoFinal & " - Empresa:" & miCodEmpresa.ToString & " - Sucursal:" & miCodSucursal.ToString
            msValor = GFsParametroObtener(sGeneral_, msClave)
            If msValor <> sRESERVADO_ Then
                piError = 1
            End If
        Else
            piError = 1
        End If
    End Sub

    Private Sub LPGeneraAsiento(ByRef piError As Integer)
        Dim loProcesamiento As New frmProcesamiento
        Dim liError As Integer = 0

        loProcesamiento.Show()
        loProcesamiento.lblTitulo.Text = "Asiento Reapertura de Ejericio - Empresa:" & miCodEmpresa.ToString & ", Sucursal:" & miCodSucursal.ToString
        LPGeneraCabecera(piError)
        If piError = 1 Then Exit Sub

        Dim lsSQL As String = GFsGeneraSQL("GPReaperturaEjercicio")
        lsSQL = lsSQL.Replace("@codempresa", miCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@ejercicio", msEjercicio)
        lsSQL = lsSQL.Replace("@nroasientos", msAsientos)
        lsSQL = lsSQL.Replace("@codsucursal", miCodSucursal.ToString)
        lsSQL = lsSQL.Replace("@ctaresultado1", msCtaResultado1)

        Dim loCN As New BaseDatos

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        Try
            loCN.Conectar()
        Catch ex As Exception
            GFsAvisar("GPReaperturaEjercicio -> Conectando a base de datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try

        loCN.CrearComando(lsSQL)
        Try
            moDataReader = loCN.EjecutarConsulta
        Catch ex As Exception
            GFsAvisar("GPReaperturaEjercicio -> Recuperar datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try

        Dim ldImporte_o As Decimal = 0.00D
        Dim ldImporte_b As Decimal = 0.00D
        While moDataReader.Read
            loProcesamiento.lblRegistroLeido.Text = moDataReader("codcuenta").ToString & " - " & moDataReader("tipomovimiento").ToString & " - " & moDataReader("importe_mo").ToString & " - " & moDataReader("concepto").ToString
            loProcesamiento.Refresh()
            If moDataReader.Item("tipomovimiento").ToString = sDebito_.Substring(0, 1) Then
                ldImporte_o = Decimal.Parse(moDataReader.Item("importe_mo").ToString)
                ldImporte_b = Decimal.Parse(moDataReader.Item("importe_mb").ToString)
                LPGeneraDetalle(moDataReader.Item("codcuenta").ToString, sCredito_, ldImporte_o, ldImporte_b, liError)
                If liError = 1 Then Exit Sub
            End If
            If moDataReader.Item("tipomovimiento").ToString = sCredito_.Substring(0, 1) Then
                ldImporte_o = Decimal.Parse(moDataReader.Item("importe_mo").ToString)
                ldImporte_b = Decimal.Parse(moDataReader.Item("importe_mb").ToString)
                LPGeneraDetalle(moDataReader.Item("codcuenta").ToString, sDebito_, ldImporte_o, ldImporte_b, liError)
                If liError = 1 Then Exit Sub
            End If
            loProcesamiento.lblRegistroProcesado.Text = moDataReader("codcuenta").ToString & " - " & moDataReader("tipomovimiento").ToString & " - " & moDataReader("importe_mo").ToString & " - " & moDataReader("concepto").ToString
            loProcesamiento.Refresh()
        End While
        loProcesamiento.lblRegistroLeido.Text = "Movimiento Cta-Resultado: " & msCtaResultado1 & " - " & mdTADebitos_o.ToString & " - " & mdTACreditos_o.ToString
        loProcesamiento.Refresh()

        LPGeneraResultado(liError)
        If liError = 1 Then Exit Sub

        loProcesamiento.lblRegistroProcesado.Text = "Movimiento Cta-Resultado: " & msCtaResultado1 & " - " & mdTADebitos_o.ToString & " - " & mdTACreditos_o.ToString
        loProcesamiento.Refresh()

        loProcesamiento.Close()
        loProcesamiento = Nothing

        moDataReader.Close()
        moDataReader = Nothing

        loCN.Desconectar()
        loCN = Nothing
    End Sub

    Private Sub LPGeneraCabecera(ByRef piError As Integer)
        Dim lsTipoCuenta As String = ""
        Dim loDocumento As New Ec020documentos
        Dim loCabecera As New Ee010asientoscabeceras
        loCabecera.codEmpresa = miCodEmpresa
        miNroAsiento = loCabecera.ReservarRegistro(miCodEmpresa)
        loCabecera.codSucursal = miCodSucursal
        loCabecera.fecha = msPeriodoInicio
        loDocumento.codEmpresa = miCodEmpresa
        loDocumento.codDocumento = miCodDocumento
        If loDocumento.GetPK = sOk_ Then
            msCodMoneda_o = loDocumento.codMoneda
            msCotizacion = loDocumento.cotizacion
        End If
        loDocumento.CerrarConexion()
        loDocumento = Nothing
        Dim liFactor() As Integer = GFiCotizacion(msCodMoneda_o, msCodMoneda_b, msPeriodoInicio)
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
            mdTADebitos_o = 0.00D
            mdTACreditos_o = 0.00D
            mdTADebitos_b = 0.00D
            mdTACreditos_b = 0.00D
            Dim liTamano As Integer = miNroAsientos.Length
            ReDim miNroAsientos(liTamano + 1)
            miNroAsientos(miNroAsientos.Length - 1) = miNroAsiento
        Catch ex As DbException
            piError = 1
            GFsAvisar("GPReaperturaEjercicio.LPGeneraCabecera", sMENSAJE_, ex.Message)
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
            GFsAvisar("GPReaperturaEjercicio.LPGeneraDetalle", sMENSAJE_, ex.Message)
        End Try
        loDetalle.CerrarConexion()
        loDetalle = Nothing

        If psActualizar = sSi_ Then
            Select Case psTipoMovimiento
                Case sDebito_
                    mdTADebitos_o += pdImporte_o
                    mdTADebitos_b += pdImporte_b
                Case sCredito_
                    mdTACreditos_o += pdImporte_o
                    mdTACreditos_b += pdImporte_b
            End Select
        End If
    End Sub

    Private Sub LPGeneraResultado(ByRef piError As Integer)
        Dim lsTipoMovimiento As String = ""
        Dim ldImporte_o As Decimal = 0.00D
        Dim ldImporte_b As Decimal = 0.00D
        Dim lsCodCuenta As String = msCtaResultado1
        Dim ldCtaResultado2Saldo As Decimal = GFdCuentaSaldoObtener(miCodEmpresa, msCtaResultado2, miCodSucursal, msPeriodoInicio)
        Dim ldSaldoResultado_o As Decimal = mdTADebitos_o - mdTACreditos_o
        Dim ldSaldoResultado_b As Decimal = mdTADebitos_b - mdTACreditos_b
        If ldSaldoResultado_o > 0 Then
            lsTipoMovimiento = sCredito_
            ldImporte_o = ldSaldoResultado_o
            ldImporte_b = ldSaldoResultado_b
            LPGeneraDetalle(lsCodCuenta, lsTipoMovimiento, ldImporte_o, ldImporte_b, piError, sNo_)
            lsTipoMovimiento = sDebito_
            LPGeneraDetalle(lsCodCuenta, lsTipoMovimiento, ldImporte_o, ldImporte_b, piError, sNo_)
            lsTipoMovimiento = sCredito_
            LPGeneraDetalle(msCtaResultado2, lsTipoMovimiento, ldImporte_o, ldImporte_b, piError, sNo_)
        Else
            If ldSaldoResultado_o < 0 Then
                ldImporte_o = ldSaldoResultado_o * -1
                ldImporte_b = ldSaldoResultado_b * -1
                lsTipoMovimiento = sDebito_
                LPGeneraDetalle(lsCodCuenta, lsTipoMovimiento, ldImporte_o, ldImporte_b, piError, sNo_)
                lsTipoMovimiento = sCredito_
                LPGeneraDetalle(lsCodCuenta, lsTipoMovimiento, ldImporte_o, ldImporte_b, piError, sNo_)
                lsTipoMovimiento = sDebito_
                LPGeneraDetalle(msCtaResultado2, lsTipoMovimiento, ldImporte_o, ldImporte_b, piError, sNo_)
            End If
        End If
        If ldCtaResultado2Saldo > 0 Then
            lsTipoMovimiento = sCredito_
            LPGeneraDetalle(msCtaResultado2, lsTipoMovimiento, ldCtaResultado2Saldo, ldCtaResultado2Saldo, piError, sNo_)
            lsTipoMovimiento = sDebito_
            LPGeneraDetalle(msCtaResultado3, lsTipoMovimiento, ldCtaResultado2Saldo, ldCtaResultado2Saldo, piError, sNo_)
        Else
            If ldCtaResultado2Saldo < 0 Then
                ldCtaResultado2Saldo = ldCtaResultado2Saldo * -1
                lsTipoMovimiento = sDebito_
                LPGeneraDetalle(msCtaResultado2, lsTipoMovimiento, ldCtaResultado2Saldo, ldCtaResultado2Saldo, piError, sNo_)
                lsTipoMovimiento = sCredito_
                LPGeneraDetalle(msCtaResultado3, lsTipoMovimiento, ldCtaResultado2Saldo, ldCtaResultado2Saldo, piError, sNo_)
            End If
        End If

    End Sub

    Private Sub LPVerificaMovimientos(ByRef piError As Integer)
        Dim lsSQL As String = GFsGeneraSQL("GPReapertura_VerificaMovimientos")
        lsSQL = lsSQL.Replace("@codempresa", miCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@ejercicio", msEjercicio)
        lsSQL = lsSQL.Replace("@nroasientos", msAsientos)
        lsSQL = lsSQL.Replace("@codsucursal", miCodSucursal.ToString)
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
            GFsAvisar("GPReaperturaEjercicio -> Recuperar datos", sMENSAJE_, ex.Message)
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

    Private Sub LPVerificacionFinal(ByRef piError As Integer)
        Dim lsSQL As String = GFsGeneraSQL("GPReapertura_VerificacionFinal")
        lsSQL = lsSQL.Replace("@codempresa", miCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@codsucursal", miCodSucursal.ToString)
        lsSQL = lsSQL.Replace("@fecha1", msPeriodoInicio)
        lsSQL = lsSQL.Replace("@ctaresultado1", msCtaResultado1)

        Dim loDataReader As DbDataReader
        Dim loCN As New BaseDatos

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        Try
            loCN.Conectar("TablaGenerica")
        Catch ex As Exception
            GFsAvisar("GPReaperturaEjercicio -> Conectando a base de datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try

        loCN.CrearComando(lsSQL)
        Try
            loDataReader = loCN.EjecutarConsulta
        Catch ex As Exception
            GFsAvisar("GPReaperturaEjercicio -> Recuperar datos", sMENSAJE_, ex.Message)
            piError = 1
            Exit Sub
        End Try
        If loDataReader.Read Then
            miCantidad = Integer.Parse(loDataReader("cantidad").ToString)
            If miCantidad > 0 Then
                Dim ldTotalDebitos As Decimal = 0.00D
                Dim ldTotalCreditos As Decimal = 0.00D
                ldTotalDebitos = Decimal.Parse(loDataReader("debitos").ToString)
                ldTotalCreditos = Decimal.Parse(loDataReader("creditos").ToString)
                If ldTotalDebitos <> ldTotalCreditos Then
                    piError = 1
                    GFsAvisar("Los movimientos de REAPERTURA no quedaron correctamente consistente.", sMENSAJE_, "El proceso de cierre será revertido.")
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
        Dim lsSQL As String = GFsGeneraSQL("GPReapertura_LPEliminaDetalle")
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
            GFsAvisar("GPReaperturaEjercicio_LPEliminaDetalle -> Conectando a base de datos", sMENSAJE_, ex.Message)
            Exit Sub
        End Try

        loCN.CrearComando(lsSQL)
        Try
            loDataReader = loCN.EjecutarConsulta
        Catch ex As DbException
            GFsAvisar("GPReaperturaEjercicio_EliminaDetalle -> Recuperar datos", sMENSAJE_, ex.Message)
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
