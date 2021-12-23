Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.Common

Module modGRCuadroPatrimonial
    Private moDataSet As DataSet
    Private moProcesamiento As frmProcesamiento

    Public Sub GRCuadroPatrimonial(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha1 As String, Optional ByVal psNivel As String = sNivel6_)
        Dim lsDetalle As String = "Impresión Cuadro Patrimonial - Empresa: @codempresa, Sucursal: @codsucursal, Saldo Al: @fecha1, Nivel: @nivel"
        lsDetalle = lsDetalle.Replace("@codempresa", piCodEmpresa.ToString)
        lsDetalle = lsDetalle.Replace("@codsucursal", piCodSucursal.ToString)
        lsDetalle = lsDetalle.Replace("@fecha1", psFecha1)
        lsDetalle = lsDetalle.Replace("@nivel", psNivel)
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

        LPCargarDatos(piCodEmpresa, piCodSucursal, psFecha1, psNivel)
        Dim lsUbicacion As String = "Informes\rptBalanceGeneral.rpt"
        Dim loReporte As ReportDocument = New ReportDocument()
        moProcesamiento.lblTitulo.Text = "Procesando datos con formato de informe"
        loReporte.Load(lsUbicacion)

        moProcesamiento.lblRegistroLeido.Text = "Configurando salida impresion"
        'loReporte.PrintOptions.NoPrinter = True
        loReporte.Database.Tables(0).SetDataSource(moDataSet.Tables.Item(0))

        Dim loParametro As New ParameterDiscreteValue()
        Dim loCamposParametros As ParameterFields = loReporte.ParameterFields
        Dim loCampoParametro As ParameterField
        moProcesamiento.lblRegistroProcesado.Text = "Configurando salida impresion"

        moProcesamiento.lblRegistroLeido.Text = "Configurando parametros del informe"
        loCampoParametro = loCamposParametros("CODUSR")
        loParametro.Value = SesionActiva.usuario
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)

        loCampoParametro = loCamposParametros("STATION")
        loParametro.Value = SesionActiva.equipo
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)

        Dim ldFecha As Date = Date.Parse(psFecha1)

        loCampoParametro = loCamposParametros("PERIODO")
        loParametro.Value = "Saldo al " & ldFecha.ToString("dd/MM/yyyy")
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

        loCampoParametro = loCamposParametros("TITULO")
        loParametro.Value = lsNombreSucursal
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)

        Dim lsMoneda As String = ""
        Dim liDecimales As Integer = 0
        Dim lsNombreEmpresa As String = "<nombre_empresa>"
        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            lsNombreEmpresa = loEmpresa.nombre
            lsMoneda = loEmpresa.codMoneda
            Dim loMoneda As New Ea010monedas
            loMoneda.codMoneda = loEmpresa.codMoneda
            If loMoneda.GetPK = sOk_ Then
                lsMoneda = loMoneda.nombre
                liDecimales = loMoneda.decimales
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

        loCampoParametro = loCamposParametros("MONEDA")
        loParametro.Value = lsMoneda
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)

        loCampoParametro = loCamposParametros("DECIMALES")
        loParametro.Value = liDecimales
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)

        loCampoParametro = loCamposParametros("TITULO_INFORME")
        loParametro.Value = "CUADRO PATRIMONIAL"
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Configurando parametros del informe"

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

    Private Sub LPCargarDatos(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha1 As String, ByVal psNivel As String)
        Dim lsSQL As String = GFsGeneraSQL("RCuadroPatrimonial")
        Dim loDatos As New Eb090cuentassaldos
        Dim lsSucursal As String = ""

        moProcesamiento.lblTitulo.Text = "Recopilando los datos para el informe..."
        If piCodSucursal > 0 Then
            lsSucursal = "AND b090.codsucursal = " & piCodSucursal
        Else
            lsSucursal = ""
        End If
        moProcesamiento.lblRegistroLeido.Text = "Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & lsSucursal & ", Fecha: " & psFecha1
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@fecha1", psFecha1)
        lsSQL = lsSQL.Replace("@sucursal", lsSucursal)
        lsSQL = lsSQL.Replace("@nivel", psNivel)
        moDataSet = loDatos.RecuperarTabla(lsSQL)
        moProcesamiento.lblRegistroProcesado.Text = "Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & lsSucursal & ", Fecha: " & psFecha1
        moProcesamiento.Refresh()
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub
End Module
