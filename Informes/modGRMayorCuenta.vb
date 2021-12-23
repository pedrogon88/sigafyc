Imports System.Globalization
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module modGRMayorCuenta

    Private moDataTable1 As DataTable
    Private moDataTable2 As DataTable
    Private moProcesamiento As frmProcesamiento

    Public Sub GRMayorCuenta(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psCuentas As String, ByVal psFecha1 As String, ByVal psFecha2 As String)
        Dim lsDetalle As String = "Impresión Mayor Cuenta - Empresa: @codempresa, Sucursal: @codsucursal, Cuenta: @codcuenta, Desde: @fecha1, Hasta: @fecha2"
        lsDetalle = lsDetalle.Replace("@codempresa", piCodEmpresa.ToString)
        lsDetalle = lsDetalle.Replace("@codsucursal", piCodSucursal.ToString)
        lsDetalle = lsDetalle.Replace("@codcuenta", psCuentas)
        lsDetalle = lsDetalle.Replace("@fecha1", psFecha1)
        lsDetalle = lsDetalle.Replace("@fecha2", psFecha2)
        GPBitacoraRegistrar(sENTRO_, lsDetalle)

        moProcesamiento = New frmProcesamiento
        moProcesamiento.Show()

        LPCargarDatos(piCodEmpresa, piCodSucursal, psCuentas, psFecha1, psFecha2)

        moProcesamiento.lblTitulo.Text = "Procesando datos con formato de informe"
        Dim lsUbicacion As String = "Informes\rptMayorCuentaCompleto.rpt"
        Dim loReporte As ReportDocument = New ReportDocument()
        loReporte.Load(lsUbicacion)

        'loReporte.PrintOptions.NoPrinter = True
        loReporte.Database.Tables(0).SetDataSource(moDataTable1)
        loReporte.Database.Tables(1).SetDataSource(moDataTable2)

        Dim loParametro As New ParameterDiscreteValue()
        Dim loCamposParametros As ParameterFields = loReporte.ParameterFields
        Dim loCampoParametro As ParameterField

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - USUARIO"
        loCampoParametro = loCamposParametros("CODUSR")
        loParametro.Value = SesionActiva.usuario
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - USUARIO"

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - STATION"
        loCampoParametro = loCamposParametros("STATION")
        loParametro.Value = SesionActiva.equipo
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - STATION"

        Dim ldDesde As Date = Date.Parse(psFecha1)
        Dim ldHasta As Date = Date.Parse(psFecha2)

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - PERIODO"
        loCampoParametro = loCamposParametros("PERIODO")
        loParametro.Value = "Periodo: " & ldDesde.ToString("dd/MM/yyyy") & " - " & ldHasta.ToString("dd/MM/yyyy")
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)

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
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - PERIODO"

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - TITULO"
        loCampoParametro = loCamposParametros("TITULO")
        loParametro.Value = lsNombreSucursal
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - TITULO"

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - HEADER"
        Dim lsNombreEmpresa As String = "<nombre_empresa>"
        Dim lsMoneda As String = ""
        Dim lsCodMoneda As String = ""
        Dim liDecimales As Integer = 0
        Dim lsCulture As String = ""
        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            lsNombreEmpresa = loEmpresa.nombre
            lsCodMoneda = loEmpresa.codMoneda
            Dim loMoneda As New Ea010monedas
            loMoneda.codMoneda = lsCodMoneda
            If loMoneda.GetPK = sOk_ Then
                lsMoneda = loMoneda.nombre
                liDecimales = loMoneda.decimales
                lsCulture = loMoneda.culture
            End If
            loMoneda.CerrarConexion()
            loMoneda = Nothing
        End If
        loEmpresa.CerrarConexion()
        loEmpresa = Nothing

        loCampoParametro = loCamposParametros("HEADER")
        loParametro.Value = lsNombreEmpresa
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - HEADER"

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - DECIMALES"
        loCampoParametro = loCamposParametros("DECIMALES")
        loParametro.Value = liDecimales
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - DECIMALES"

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - MONEDA"
        loCampoParametro = loCamposParametros("MONEDA")
        loParametro.Value = lsMoneda
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - DECIMALES"

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

    Private Sub LPCargarDatos(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psCuentas As String, ByVal psFecha1 As String, ByVal psFecha2 As String)
        moProcesamiento.lblTitulo.Text = "Recopilando los datos para el informe..."
        moProcesamiento.lblRegistroLeido.Text = "Empresa: " & piCodEmpresa.ToString & ", Sucursal:" & piCodSucursal.ToString & " Cuenta: " & psCuentas & ", Periodo: " & psFecha1 & " - " & psFecha2

        Dim lsSQL As String = GFsGeneraSQL("frmRMayorCuentaCompleto")
        Dim loCN As New BaseDatos
        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        loCN.Conectar()
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        Dim lsSucursal As String = ""
        If piCodSucursal > 0 Then
            lsSucursal = "AND e010.codsucursal = " & piCodSucursal.ToString
        End If
        lsSQL = lsSQL.Replace("@Sucursal", lsSucursal)
        lsSQL = lsSQL.Replace("@fecha1", psFecha1)
        lsSQL = lsSQL.Replace("@fecha2", psFecha2)
        lsSQL = lsSQL.Replace("@cuentas", psCuentas)

        loCN.CrearComando(lsSQL)
        moDataTable1 = loCN.EjecutarConsultaTable
        loCN.Desconectar()
        loCN = Nothing

        lsSQL = GFsGeneraSQL("frmRMayorCuentaCompleto_Saldos")
        Dim loCN1 As New BaseDatos
        loCN1.SetearParametrosConexion(sRegistryTablasPrincipal_)
        loCN1.Conectar()
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        lsSucursal = ""
        If piCodSucursal > 0 Then
            lsSucursal = "AND e010.codsucursal = " & piCodSucursal.ToString
        End If
        lsSQL = lsSQL.Replace("@Sucursal", lsSucursal)
        lsSQL = lsSQL.Replace("@periodo", psFecha1)
        lsSQL = lsSQL.Replace("@cuentas", psCuentas)

        loCN1.CrearComando(lsSQL)
        moDataTable2 = loCN1.EjecutarConsultaTable
        loCN1.Desconectar()
        loCN1 = Nothing

        moProcesamiento.lblRegistroProcesado.Text = "Empresa: " & piCodEmpresa.ToString & ", Sucursal:" & piCodSucursal.ToString & " Cuenta: " & psCuentas & ", Periodo: " & psFecha1 & " - " & psFecha2
    End Sub

End Module
