Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Module modGRPlanCuentas

    Private moDataSet As DataSet
    Private moProcesamiento As frmProcesamiento

    Public Sub GRPlanCuentas(ByVal piCodEmpresa As Integer, Optional ByVal psNivel As String = sNivel6_)
        moProcesamiento = New frmProcesamiento
        Dim lsDetalle As String = "Impresión Plan de Cuentas - Empresa: @codempresa, Nivel: @nivel"
        lsDetalle = lsDetalle.Replace("@codempresa", piCodEmpresa.ToString)
        lsDetalle = lsDetalle.Replace("@nivel", psNivel)
        GPBitacoraRegistrar(sENTRO_, lsDetalle)
        moProcesamiento.Show()
        LPCargarDatos(piCodEmpresa, psNivel)

        moProcesamiento.lblTitulo.Text = "Procesando datos con formato de informe"

        Dim lsUbicacion As String = "Informes\rptPlanCuentas.rpt"
        Dim loReporte As ReportDocument = New ReportDocument()
        loReporte.Load(lsUbicacion)

        'loReporte.PrintOptions.NoPrinter = True
        loReporte.Database.Tables(0).SetDataSource(moDataSet.Tables.Item(0))

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

        Dim lsNivel As String = "TODAS LAS CUENTAS"
        If psNivel < sNivel6_ Then
            lsNivel = "HASTA NIVEL " & psNivel & "º"
        End If

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - PERIODO"
        loCampoParametro = loCamposParametros("PERIODO")
        loParametro.Value = lsNivel
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - PERIODO"

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - TITULO"
        loCampoParametro = loCamposParametros("TITULO")
        loParametro.Value = "Plan de Cuentas"
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - TITULO"

        Dim lsNombreEmpresa As String = "<nombre_empresa>"
        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            lsNombreEmpresa = loEmpresa.nombre
        End If
        loEmpresa.CerrarConexion()
        loEmpresa = Nothing

        moProcesamiento.lblRegistroLeido.Text = "Cargando Parametro - HEADER"
        loCampoParametro = loCamposParametros("HEADER")
        loParametro.Value = lsNombreEmpresa
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        moProcesamiento.lblRegistroProcesado.Text = "Cargando Parametro - HEADER"

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

    Private Sub LPCargarDatos(ByVal piCodEmpresa As Integer, ByVal psNivel As String)
        moProcesamiento.lblTitulo.Text = "Recopilando los datos para el informe..."
        moProcesamiento.lblRegistroLeido.Text = "Empresa: " & piCodEmpresa.ToString & ", Nivel: " & psNivel
        Dim lsSQL As String = GFsGeneraSQL("Eb050plancuentas_Imprimir")
        Dim loDatos As New Eb050plancuentas
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@nivel", psNivel)
        moDataSet = loDatos.RecuperarTabla(lsSQL)
        loDatos.CerrarConexion()
        loDatos = Nothing
        moProcesamiento.lblRegistroProcesado.Text = "Empresa: " & piCodEmpresa.ToString & ", Nivel: " & psNivel
    End Sub

End Module
