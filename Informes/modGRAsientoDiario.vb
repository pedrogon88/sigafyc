Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module modGRAsientoDiario

    Private moDataTable As DataTable
    Private moProcesamiento As frmProcesamiento

    Public Sub GRAsientoDiario(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal piAsiento1 As Integer, ByVal piAsiento2 As Integer)
        moProcesamiento = New frmProcesamiento
        Dim lsDetalle As String = "Impresión Asiento Diario - Empresa: @codempresa, Sucursal: @codsucursal, Desde: @asiento1, Hasta: @asiento2"
        lsDetalle = lsDetalle.Replace("@codempresa", piCodEmpresa.ToString)
        Dim lsSucursal As String = "TODAS LAS SUCURSALES"
        If piCodSucursal > 0 Then
            Dim loSucursal As New Eb070sucursales
            loSucursal.codEmpresa = piCodEmpresa
            loSucursal.codSucursal = piCodSucursal
            If loSucursal.GetPK = sOk_ Then
                lsSucursal = loSucursal.nombre
            End If
            loSucursal.CerrarConexion()
            loSucursal = Nothing
        End If
        lsDetalle = lsDetalle.Replace("@codsucursal", lsSucursal)
        lsDetalle = lsDetalle.Replace("@asiento1", piAsiento1.ToString)
        lsDetalle = lsDetalle.Replace("@asiento2", piAsiento2.ToString)
        GPBitacoraRegistrar(sENTRO_, lsDetalle)
        moProcesamiento.Show()
        LPCargarDatos(piCodEmpresa, piCodSucursal, piAsiento1, piAsiento2)

        moProcesamiento.lblTitulo.Text = "Procesando datos con formato de informe"
        Dim lsUbicacion As String = "Informes\rptAsientoDiario.rpt"
        Dim loReporte As ReportDocument = New ReportDocument()
        loReporte.Load(lsUbicacion)

        'loReporte.PrintOptions.NoPrinter = True
        loReporte.Database.Tables(0).SetDataSource(moDataTable)

        Dim loParametro As New ParameterDiscreteValue()
        Dim loCamposParametros As ParameterFields = loReporte.ParameterFields
        Dim loCampoParametro As ParameterField

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - USUARIO"
        loCampoParametro = loCamposParametros("CODUSR")
        loParametro.Value = SesionActiva.usuario
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - USUARIO"

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - ASIENTOS A PROCESAR"
        loCampoParametro = loCamposParametros("STATION")
        loParametro.Value = SesionActiva.equipo
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        Dim lsRangoAsiento As String = ""
        If piAsiento1 = piAsiento2 Then
            lsRangoAsiento = "Asiento No.: " & piAsiento1.ToString(sFormatD_ & "6")
        Else
            lsRangoAsiento = "Rango Asiento: " & piAsiento1.ToString(sFormatD_ & "6") & " - " & piAsiento2.ToString(sFormatD_ & "6")
        End If

        loCampoParametro = loCamposParametros("PERIODO")
        loParametro.Value = lsRangoAsiento
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - ASIENTOS A PROCESAR"

        Dim lsNombreEmpresa As String = "<nombre_empresa>"
        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            lsNombreEmpresa = loEmpresa.nombre
        End If
        loEmpresa.CerrarConexion()
        loEmpresa = Nothing

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - TITULO"
        loCampoParametro = loCamposParametros("TITULO")
        loParametro.Value = lsSucursal
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - TITULO"

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - HEADER"
        loCampoParametro = loCamposParametros("HEADER")
        loParametro.Value = lsNombreEmpresa
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - HEADER"

        moProcesamiento.Close()
        moProcesamiento = Nothing

        loReporte.ExportToDisk(ExportFormatType.PortableDocFormat, lsUbicacion)

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

    Private Sub LPCargarDatos(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal piAsiento1 As Integer, ByVal piAsiento2 As Integer)
        moProcesamiento.lblTitulo.Text = "Recopilando los datos para el informe..."
        moProcesamiento.lblRegistroLeido.Text = "Empresa: " & piCodEmpresa.ToString & ", Asiento desde: " & piAsiento1.ToString & " hasta: " & piAsiento2.ToString
        Dim lsSQL As String = GFsGeneraSQL("frmRAsientoDiario")
        Dim loCN As New BaseDatos
        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        loCN.Conectar()
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        Dim lsSucursal As String = ""
        If piCodSucursal > 0 Then
            lsSucursal = "AND e010.codsucursal = " & piCodSucursal
        End If
        lsSQL = lsSQL.Replace("@ejercicio", GFsEjercicioContable(piCodEmpresa))
        lsSQL = lsSQL.Replace("@asiento1", piAsiento1.ToString)
        lsSQL = lsSQL.Replace("@asiento2", piAsiento2.ToString)
        loCN.CrearComando(lsSQL)
        moDataTable = loCN.EjecutarConsultaTable
        loCN.Desconectar()
        loCN = Nothing
        moProcesamiento.lblRegistroProcesado.Text = "Empresa: " & piCodEmpresa.ToString & ", Asiento desde: " & piAsiento1.ToString & " hasta: " & piAsiento2.ToString
    End Sub

End Module
