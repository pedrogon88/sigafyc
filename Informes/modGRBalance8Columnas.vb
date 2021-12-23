Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module modGRBalance8Columnas
    Private moDataSet As DataSet
    Private moProcesamiento As frmProcesamiento

    Public Sub GRBalance8Columnas(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha1 As String)
        Dim lsDetalle As String = "Impresión Balance a 8 Columnas - Empresa: @codempresa, Sucursal: @codsucursal, Saldo Al: @fecha1"
        lsDetalle = lsDetalle.Replace("@codempresa", piCodEmpresa.ToString)
        lsDetalle = lsDetalle.Replace("@codsucursal", piCodSucursal.ToString)
        lsDetalle = lsDetalle.Replace("@fecha1", psFecha1)
        GPBitacoraRegistrar(sENTRO_, lsDetalle)

        moProcesamiento = New frmProcesamiento
        moProcesamiento.Show()
        If GFbVerificaMovimientos(piCodEmpresa, piCodSucursal, psFecha1) = False Then
            GFsAvisar("Atención! los totales de debitos y creditos relacionados no coinciden, lo mas probable que existan Asientos que no cuadran", sMENSAJE_, "Por favor verifique y corrija para poder realizar este informe.")
            moProcesamiento.Close()
            moProcesamiento = Nothing
            GPBitacoraRegistrar(sSALIO_, lsDetalle)
            Exit Sub
        End If
        LPCargarDatos(piCodEmpresa, piCodSucursal, psFecha1)

        moProcesamiento.lblTitulo.Text = "Procesando datos con formato de informe"
        Dim lsUbicacion As String = "Informes\rptRBalance8Columnas.rpt"
        Dim loReporte As ReportDocument = New ReportDocument()
        loReporte.Load(lsUbicacion)

        moProcesamiento.lblRegistroLeido.Text = "Configurando salida impresion"
        'loReporte.PrintOptions.NoPrinter = True
        loReporte.Database.Tables(0).SetDataSource(moDataSet.Tables.Item(0))

        Dim loParametro As New ParameterDiscreteValue()
        Dim loCamposParametros As ParameterFields = loReporte.ParameterFields
        Dim loCampoParametro As ParameterField
        moProcesamiento.lblRegistroProcesado.Text = "Configurando salida impresion"

        moProcesamiento.lblRegistroLeido.Text = "Configurando parameteros - USUARIO"
        loCampoParametro = loCamposParametros("CODUSR")
        loParametro.Value = SesionActiva.usuario
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Configurando parameteros - USUARIO"

        moProcesamiento.lblRegistroLeido.Text = "Configurando parameteros - STATION"
        loCampoParametro = loCamposParametros("STATION")
        loParametro.Value = SesionActiva.equipo
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Configurando parameteros - STATION"

        Dim ldFecha As Date = Date.Parse(psFecha1)

        moProcesamiento.lblRegistroLeido.Text = "Configurando parameteros - PERIODO"
        loCampoParametro = loCamposParametros("PERIODO")
        loParametro.Value = "Saldo al " & ldFecha.ToString("dd/MM/yyyy")
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Configurando parameteros - PERIODO"

        moProcesamiento.lblRegistroLeido.Text = "Configurando parameteros - SUCURSALES"
        Dim lsNombreSucursal As String = "TODAS LAS SUCURSALES"
        If piCodSucursal > 0 Then
            Dim loSucursal As New Eb070sucursales
            loSucursal.codEmpresa = piCodEmpresa
            loSucursal.codSucursal = piCodSucursal
            If loSucursal.GetPK = sOk_ Then
                lsNombreSucursal = loSucursal.nombre
            End If
            loSucursal.CerrarConexion()
            loSucursal = Nothing
        End If

        loCampoParametro = loCamposParametros("TITULO")
        loParametro.Value = lsNombreSucursal
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Configurando parameteros - SUCURSALES"

        moProcesamiento.lblRegistroLeido.Text = "Configurando parameteros - EMPRESA"
        Dim lsCodCtaResultado As String = ""
        Dim lsCtaResultado1 As String = ""
        Dim lsMoneda As String = ""
        Dim liDecimales As Integer = 0
        Dim lsNombreEmpresa As String = "<nombre_empresa>"
        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            lsNombreEmpresa = loEmpresa.nombre
            lsMoneda = loEmpresa.codMoneda
            lsCodCtaResultado = loEmpresa.ctaResultado1
            Dim loMoneda As New Ea010monedas
            loMoneda.codMoneda = loEmpresa.codMoneda
            If loMoneda.GetPK = sOk_ Then
                liDecimales = loMoneda.decimales
            End If
            loMoneda.CerrarConexion()
            loMoneda = Nothing
            Dim loCuentas As New Eb050plancuentas
            loCuentas.codEmpresa = loEmpresa.codEmpresa
            loCuentas.codCuenta = lsCodCtaResultado
            If loCuentas.GetPK = sOk_ Then
                lsCtaResultado1 = loCuentas.nombre
            End If
            loCuentas.CerrarConexion()
            loCuentas = Nothing
        End If
        loEmpresa.CerrarConexion()
        loEmpresa = Nothing

        loCampoParametro = loCamposParametros("HEADER")
        loParametro.Value = lsNombreEmpresa
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Configurando parameteros - EMPRESA"

        moProcesamiento.lblRegistroLeido.Text = "Configurando parameteros - MONEDA"
        loCampoParametro = loCamposParametros("MONEDA")
        loParametro.Value = lsMoneda
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Configurando parameteros - MONEDA"

        moProcesamiento.lblRegistroLeido.Text = "Configurando parameteros - DECIMALES"
        loCampoParametro = loCamposParametros("DECIMALES")
        loParametro.Value = liDecimales
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Configurando parameteros - DECIMALES"

        moProcesamiento.lblRegistroLeido.Text = "Configurando parameteros - CUENTAS DE RESULTADO"
        loCampoParametro = loCamposParametros("CTARESULTADO1")
        loParametro.Value = lsCtaResultado1
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)

        Dim ldImpResultado As Decimal = GFdCuentaSaldoObtener(piCodEmpresa, lsCodCtaResultado, piCodSucursal, psFecha1)
        loCampoParametro = loCamposParametros("IMPRESULTADO")
        loParametro.Value = ldImpResultado
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Configurando parameteros - CUENTAS DE RESULTADO"

        moProcesamiento.Close()
        moProcesamiento = Nothing


        Dim loVistaPrevia As New frmFVisualizadorReporte
        loVistaPrevia.CrystalReportViewer1.ReportSource = loReporte
        loVistaPrevia.ShowDialog()
        loReporte.Close()
        loReporte.Dispose()
        loReporte = Nothing
        loVistaPrevia.Close()
        loVistaPrevia.Dispose()
        loVistaPrevia = Nothing
        GPBitacoraRegistrar(sSALIO_, lsDetalle)
    End Sub

    Private Sub LPCargarDatos(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha1 As String)
        Dim lsSQL As String = GFsGeneraSQL("RBalance8Columnas")
        Dim loDatos As New Eb090cuentassaldos
        Dim loEmpresa As New Ec001empresas
        Dim lsCtaResultado1 As String = ""
        moProcesamiento.lblTitulo.Text = "Recopilando los datos para el informe..."


        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            lsCtaResultado1 = loEmpresa.ctaResultado1
        End If
        loEmpresa.CerrarConexion()
        loEmpresa = Nothing

        Dim lsSucursal As String = ""
        If piCodSucursal > 0 Then
            lsSucursal = "AND b090.codsucursal = " & piCodSucursal
        Else
            lsSucursal = ""
        End If
        moProcesamiento.lblRegistroLeido.Text = "Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & lsSucursal & ", Fecha: " & psFecha1

        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@fecha1", psFecha1)
        lsSQL = lsSQL.Replace("@sucursal", lsSucursal)
        lsSQL = lsSQL.Replace("@ctaresultado1", lsCtaResultado1)

        moProcesamiento.lblRegistroProcesado.Text = "Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & lsSucursal & ", Fecha: " & psFecha1
        moProcesamiento.Refresh()

        moDataSet = loDatos.RecuperarTabla2(lsSQL)
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

End Module
