Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.Common

Module modGRCuadroResultado
    Private moDataTable As DataTable

    Public Sub GRCuadroResultado(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha1 As String, Optional ByVal psNivel As String = sNivel6_)
        Dim lsDetalle As String = "Impresión Cuadro Resultado - Empresa: @codempresa, Sucursal: @codsucursal, Saldo Al: @fecha1, Nivel: @nivel"
        lsDetalle = lsDetalle.Replace("@codempresa", piCodEmpresa.ToString)
        lsDetalle = lsDetalle.Replace("@codsucursal", piCodSucursal.ToString)
        lsDetalle = lsDetalle.Replace("@fecha1", psFecha1)
        lsDetalle = lsDetalle.Replace("@nivel", psNivel)
        GPBitacoraRegistrar(sENTRO_, lsDetalle)
        Dim loProcesamiento As New frmProcesamiento
        loProcesamiento.Show()
        loProcesamiento.lblTitulo.Text = "Procesando datos con formato de informe"

        If GFbVerificaMovimientos(piCodEmpresa, piCodSucursal, psFecha1) = False Then
            GFsAvisar("Atención! los totales de debitos y creditos relacionados no coinciden, lo mas probable que existan Asientos que no cuadran", sMENSAJE_, "Por favor verifique y corrija para poder realizar este informe.")
            loProcesamiento.Close()
            loProcesamiento = Nothing
            GPBitacoraRegistrar(sSALIO_, lsDetalle)
            Exit Sub
        End If

        LPCargarDatos(piCodEmpresa, piCodSucursal, psFecha1, psNivel)
        Dim lsUbicacion As String = "Informes\rptBalanceGeneral.rpt"
        Dim loReporte As ReportDocument = New ReportDocument()
        loReporte.Load(lsUbicacion)

        loProcesamiento.lblRegistroLeido.Text = "Configurando salida impresion"
        'loReporte.PrintOptions.NoPrinter = True
        loReporte.Database.Tables(0).SetDataSource(moDataTable)

        Dim loParametro As New ParameterDiscreteValue()
        Dim loCamposParametros As ParameterFields = loReporte.ParameterFields
        Dim loCampoParametro As ParameterField
        loProcesamiento.lblRegistroProcesado.Text = "Configurando salida impresion"

        loProcesamiento.lblRegistroLeido.Text = "Configurando parametros del informe"
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
        loParametro.Value = "CUADRO DE RESULTADOS"
        loCampoParametro.CurrentValues.Clear()
        loCampoParametro.CurrentValues.Add(loParametro)
        loProcesamiento.lblRegistroProcesado.Text = "Configurando parametros del informe"

        loProcesamiento.Close()
        loProcesamiento = Nothing

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
        Dim loProcesamiento As New frmProcesamiento
        Dim lsEstructura As String = "codagrupar" & sString_ & sSeparador_ & "60" & sSF_ &
                                        "codcuenta" & sString_ & sSeparador_ & "26" & sSF_ &
                                        "nombre" & sString_ & sSeparador_ & "128" & sSF_ &
                                        "nivel" & sString_ & sSeparador_ & "1" & sSF_ &
                                        "saldo" & sDecimal_ & sSeparador_
        Dim loDataSet As DataSet = GFsCrearTablaTemporal("Balance1", lsEstructura)
        Dim lsSQL As String = GFsGeneraSQL("RCuadroResultado")
        Dim loDataTable As DataTable = loDataSet.Tables.Item(0)
        Dim loDataRow As DataRow = Nothing
        Dim lsSucursal As String = ""
        loProcesamiento.Show()
        loProcesamiento.lblTitulo.Text = "Recopilando los datos para el informe..."
        If piCodSucursal > 0 Then
            lsSucursal = "AND b090.codsucursal = " & piCodSucursal
        Else
            lsSucursal = ""
        End If
        loProcesamiento.lblRegistroLeido.Text = "Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & lsSucursal & ", Fecha: " & psFecha1
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        lsSQL = lsSQL.Replace("@fecha1", psFecha1)
        lsSQL = lsSQL.Replace("@sucursal", lsSucursal)
        lsSQL = lsSQL.Replace("@nivel", psNivel)
        loProcesamiento.lblRegistroProcesado.Text = "Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & lsSucursal & ", Fecha: " & psFecha1
        loProcesamiento.Refresh()

        loProcesamiento.lblTitulo.Text = "Recopilando los datos para el informe..."
        Dim loDataReader As DbDataReader
        Dim loCuentaSaldos As New Eb090cuentassaldos
        loDataReader = loCuentaSaldos.RecuperarConsulta(lsSQL)
        While loDataReader.Read()
            loProcesamiento.lblRegistroLeido.Text = "Recopilando los Datos de Saldos..." & loDataReader.Item("codcuenta").ToString
            loDataRow = loDataTable.NewRow()
            loDataRow("codagrupar") = loDataReader.Item("codagrupar")
            loDataRow("codcuenta") = loDataReader.Item("codcuenta").ToString
            loDataRow("nombre") = loDataReader.Item("nombre")
            loDataRow("nivel") = loDataReader.Item("nivel")
            loDataRow("saldo") = loDataReader.Item("saldo")
            loDataTable.Rows.Add(loDataRow)
            loProcesamiento.lblRegistroProcesado.Text = "Recopilando Datos Saldos... Cuenta:" & loDataReader.Item("codcuenta").ToString & " -> Saldo: " & loDataReader.Item("saldo").ToString
            loProcesamiento.Refresh()
        End While
        loDataReader.Close()
        loCuentaSaldos.CerrarConexion()
        loCuentaSaldos = Nothing

        Dim lsNombreCuenta As String = ""
        Dim ldSaldo As Decimal = 0.00D
        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            ldSaldo = GFdCuentaSaldoObtener(piCodEmpresa, loEmpresa.ctaResultado1, piCodSucursal, psFecha1)
            Dim loCuentas As New Eb050plancuentas
            loCuentas.codEmpresa = loEmpresa.codEmpresa
            loCuentas.codCuenta = loEmpresa.ctaResultado1
            If loCuentas.GetPK = sOk_ Then
                lsNombreCuenta = loCuentas.nombre
            End If
        End If
        loEmpresa.CerrarConexion()
        loEmpresa = Nothing
        Dim lsCodCuenta As String = ""
        If ldSaldo < 0 Then
            lsCodCuenta = "7.99.000.0000.00000.000000"
        Else
            If ldSaldo > 0 Then
                lsCodCuenta = "6.99.000.0000.00000.000000"
            End If
        End If
        If ldSaldo <> 0 Then
            loDataRow = loDataTable.NewRow()
            If lsCodCuenta.Substring(0, 1) = "6" Then
                loDataRow("codagrupar") = "6.INGRESOS"
            Else
                If lsCodCuenta.Substring(0, 1) = "7" Then
                    loDataRow("codagrupar") = "7.EGRESOS"
                End If
            End If
            loDataRow("codcuenta") = lsCodCuenta
            loDataRow("nombre") = lsNombreCuenta
            loDataRow("nivel") = sNivel2_
            loDataRow("saldo") = ldSaldo * -1
            loDataTable.Rows.Add(loDataRow)
        End If
        loProcesamiento.lblRegistroProcesado.Text = "Incluyendo la cuenta de Resultado..."
        loProcesamiento.Refresh()
        loProcesamiento.Close()
        loProcesamiento = Nothing
        moDataTable = loDataTable
        loDataReader.Close()
    End Sub

End Module
