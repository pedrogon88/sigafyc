Imports System.Data.Common

Module modGPReconstruccionSaldos

    Public Sub GPReconstruccionSaldos(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha1 As String, ByVal psFecha2 As String, Optional ByRef piError As Integer = 0)
        GPBitacoraRegistrar(sENTRO_, "Reconstruccion de Saldos Contables - Empresa:" & piCodEmpresa.ToString & ", Sucursal:" & piCodSucursal.ToString & ", Periodo:" & psFecha1 & "-" & psFecha2)
        LPCerarSaldos(piCodEmpresa, piCodSucursal, psFecha1, psFecha2, piError)
        If piError = 1 Then Exit Sub

        Dim loProcesamiento As New frmProcesamiento
        Dim lsSQL As String = GFsGeneraSQL("GPReconstruccionSaldos_Movimientos")
        Dim loDataReader As DbDataReader
        Dim loCN As New BaseDatos
        Dim lsSucursal As String = ""

        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        If piCodSucursal > 0 Then
            lsSucursal = "AND e010.codsucursal = " & piCodSucursal.ToString
        End If
        lsSQL = lsSQL.Replace("@sucursal", lsSucursal)

        lsSQL = lsSQL.Replace("@fecha1", psFecha1)
        lsSQL = lsSQL.Replace("@fecha2", psFecha2)

        Dim liCodEmpresa As Integer = 0
        Dim lsCodCuenta As String = ""
        Dim liCodSucursal As Integer = 0
        Dim lsFecha As String = ""
        Dim lsTipoMovimiento As String = ""
        Dim ldImporte As Decimal = 0.00D
        Dim lsOperacion As String = ""

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_, "TablaGenerica")
        loCN.Conectar("TablaGenerica")

        loCN.CrearComando(lsSQL)
        loDataReader = loCN.EjecutarConsulta()

        loProcesamiento.Show()
        loProcesamiento.lblTitulo.Text = "Reconstruyendo los saldos..."
        While (loDataReader.Read)
            loProcesamiento.lblRegistroLeido.Text = "Empresa: " & loDataReader.Item("codempresa").ToString & " - Cuenta: " & loDataReader.Item("codcuenta").ToString & " - Fecha: " & loDataReader.Item("fecha").ToString & " - Tipo: " & loDataReader.Item("tipomovimiento").ToString & " - Importe: " & loDataReader.Item("importe_mb").ToString
            liCodEmpresa = Integer.Parse(loDataReader.Item("codempresa").ToString)
            lsCodCuenta = loDataReader.Item("codcuenta").ToString
            liCodSucursal = Integer.Parse(loDataReader.Item("codsucursal").ToString)
            lsFecha = loDataReader.Item("fecha").ToString
            lsTipoMovimiento = loDataReader.Item("tipomovimiento").ToString
            ldImporte = Decimal.Parse(loDataReader.Item("importe_mb").ToString)
            lsOperacion = loDataReader.Item("operacion").ToString
            GPCuentaActualizaSaldo(liCodEmpresa, lsCodCuenta, liCodSucursal, lsFecha, lsTipoMovimiento, ldImporte, lsOperacion)
            loProcesamiento.lblRegistroProcesado.Text = "Empresa: " & loDataReader.Item("codempresa").ToString & " - Cuenta: " & loDataReader.Item("codcuenta").ToString & " - Fecha: " & loDataReader.Item("fecha").ToString & " - Tipo: " & loDataReader.Item("tipomovimiento").ToString & " - Importe: " & loDataReader.Item("importe_mb").ToString
            loProcesamiento.Refresh()
        End While
        loProcesamiento.Close()
        loProcesamiento = Nothing
        loDataReader.Close()
        loDataReader = Nothing
        loCN.Desconectar()
        loCN = Nothing
        GPBitacoraRegistrar(sSALIO_, "Reconstruccion de Saldos Contables - Empresa:" & piCodEmpresa.ToString & ", Sucursal:" & piCodSucursal.ToString & ", Periodo:" & psFecha1 & "-" & psFecha2)
    End Sub

    Private Sub LPCerarSaldos(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha1 As String, ByVal psFecha2 As String, Optional ByRef piError As Integer = 0)
        GPBitacoraRegistrar(sENTRO_, "Reconstruccion de Saldos Contables / CERADO DE SALDOS - Empresa:" & piCodEmpresa.ToString & ", Sucursal:" & piCodSucursal.ToString & ", Periodo:" & psFecha1 & "-" & psFecha2)
        Dim loProcesamiento As New frmProcesamiento
        Dim loDataReader As DbDataReader
        Dim loCN As New BaseDatos
        Dim loCtaSaldos As New Eb090cuentassaldos
        Dim lsSQL As String = ""
        Dim lsSucursal As String = ""

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_, "TablaGenerica")
        loCN.Conectar("TablaGenerica")

        lsSQL = GFsGeneraSQL("GPReconstruccionSaldos")
        lsSQL = lsSQL.Replace("@tiposaldo", sFecha_)
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        lsSucursal = ""
        If piCodSucursal > 0 Then
            lsSucursal = "AND codsucursal = " & piCodSucursal.ToString
        End If
        lsSQL = lsSQL.Replace("@sucursal", lsSucursal)

        lsSQL = lsSQL.Replace("@fecha1", psFecha1)
        lsSQL = lsSQL.Replace("@fecha2", psFecha2)

        loCN.CrearComando(lsSQL)
        loDataReader = loCN.EjecutarConsulta()

        loProcesamiento.Show()
        loProcesamiento.lblTitulo.Text = "Cerando los saldos por fecha"
        While (loDataReader.Read)
            loProcesamiento.lblRegistroLeido.Text = loDataReader.Item("tiposaldo").ToString & "- Empresa: " & loDataReader.Item("codempresa").ToString & " - Cuenta: " & loDataReader.Item("codcuenta").ToString & " - Debitos: " & loDataReader.Item("debito").ToString & " - Creditos: " & loDataReader.Item("credito").ToString
            loCtaSaldos.tipoSaldo = loDataReader.Item("tiposaldo").ToString
            loCtaSaldos.codEmpresa = Integer.Parse(loDataReader.Item("codempresa").ToString)
            loCtaSaldos.codCuenta = loDataReader.Item("codcuenta").ToString
            loCtaSaldos.codSucursal = Integer.Parse(loDataReader.Item("codsucursal").ToString)
            loCtaSaldos.periodo = loDataReader.Item("periodo").ToString
            loCtaSaldos.debito = 0.00D
            loCtaSaldos.credito = 0.00D
            Try
                loCtaSaldos.Put(sNo_)
            Catch ex As Exception
                piError = 1
                GFsAvisar("GPReconstruccionSaldos.LPCerarSaldos.Fechas", sMENSAJE_, ex.Message)
            End Try
            loProcesamiento.lblRegistroProcesado.Text = loDataReader.Item("tiposaldo").ToString & "- Empresa: " & loDataReader.Item("codempresa").ToString & " - Cuenta: " & loDataReader.Item("codcuenta").ToString & " - Debitos: " & loDataReader.Item("debito").ToString & " - Creditos: " & loDataReader.Item("credito").ToString
            loProcesamiento.Refresh()
        End While
        loCN.Desconectar()
        loCN = Nothing

        Dim loCN1 As New BaseDatos
        loCN1.SetearParametrosConexion(sRegistryTablasPrincipal_, "TablaGenerica")
        loCN1.Conectar("TablaGenerica")

        lsSQL = GFsGeneraSQL("GPReconstruccionSaldos")
        lsSQL = lsSQL.Replace("@tiposaldo", sMensual_)
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        lsSucursal = ""
        If piCodSucursal > 0 Then
            lsSucursal = "AND codsucursal = " & piCodSucursal.ToString
        End If
        lsSQL = lsSQL.Replace("@sucursal", lsSucursal)

        lsSQL = lsSQL.Replace("@fecha1", psFecha1.Substring(0, 7))
        lsSQL = lsSQL.Replace("@fecha2", psFecha2.Substring(0, 7))

        loCN1.CrearComando(lsSQL)
        loDataReader = loCN1.EjecutarConsulta()

        loProcesamiento.lblTitulo.Text = "Cerando los saldos por Mes"
        While (loDataReader.Read)
            loProcesamiento.lblRegistroLeido.Text = loDataReader.Item("tiposaldo").ToString & "- Empresa: " & loDataReader.Item("codempresa").ToString & " - Cuenta: " & loDataReader.Item("codcuenta").ToString & " - Debitos: " & loDataReader.Item("debito").ToString & " - Creditos: " & loDataReader.Item("credito").ToString
            loCtaSaldos.tipoSaldo = loDataReader.Item("tiposaldo").ToString
            loCtaSaldos.codEmpresa = Integer.Parse(loDataReader.Item("codempresa").ToString)
            loCtaSaldos.codCuenta = loDataReader.Item("codcuenta").ToString
            loCtaSaldos.codSucursal = Integer.Parse(loDataReader.Item("codsucursal").ToString)
            loCtaSaldos.periodo = loDataReader.Item("periodo").ToString
            loCtaSaldos.debito = 0.00D
            loCtaSaldos.credito = 0.00D
            Try
                loCtaSaldos.Put(sNo_)
            Catch ex As Exception
                piError = 1
                GFsAvisar("GPReconstruccionSaldos.LPCerarSaldos.Mes", sMENSAJE_, ex.Message)
            End Try
            loProcesamiento.lblRegistroProcesado.Text = loDataReader.Item("tiposaldo").ToString & "- Empresa: " & loDataReader.Item("codempresa").ToString & " - Cuenta: " & loDataReader.Item("codcuenta").ToString & " - Debitos: " & loDataReader.Item("debito").ToString & " - Creditos: " & loDataReader.Item("credito").ToString
            loProcesamiento.Refresh()
        End While
        loProcesamiento.Close()
        loProcesamiento = Nothing
        loDataReader.Close()
        loDataReader = Nothing
        loCtaSaldos.CerrarConexion()
        loCtaSaldos = Nothing
        loCN1.Desconectar()
        loCN1 = Nothing
        GPBitacoraRegistrar(sSALIO_, "Reconstruccion de Saldos Contables / CERADO DE SALDOS - Empresa:" & piCodEmpresa.ToString & ", Sucursal:" & piCodSucursal.ToString & ", Periodo:" & psFecha1 & "-" & psFecha2)
    End Sub

End Module
