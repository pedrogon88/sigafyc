Imports System.Data.Common

Module modGPReconstruccionCabAsiento

    Public Sub GPReconstruccionCabAsiento(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha1 As String, ByVal psFecha2 As String, Optional ByRef piError As Integer = 0)
        GPBitacoraRegistrar(sENTRO_, "Reconstruccion Cabecera Asientos - Empresa:" & piCodEmpresa.ToString & ", Sucursal:" & piCodEmpresa.ToString & ", Periodo:" & psFecha1 & "-" & psFecha2)
        Dim loProcesamiento As New frmProcesamiento
        Dim lsSQL As String = GFsGeneraSQL("GPReconstruccionCabAsiento")
        Dim loDataReader As DbDataReader
        Dim loCabecera As New Ee010asientoscabeceras
        Dim loCN As New BaseDatos
        Dim lsSucursal As String = ""

        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        If piCodSucursal > 0 Then
            lsSucursal = "AND codsucursal = " & piCodSucursal.ToString
        End If
        lsSQL = lsSQL.Replace("@Sucursal", lsSucursal)

        lsSQL = lsSQL.Replace("@fecha1", psFecha1)
        lsSQL = lsSQL.Replace("@fecha2", psFecha2)

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_, "TablaGenerica")
        loCN.Conectar("TablaGenerica")

        loCN.CrearComando(lsSQL)
        loDataReader = loCN.EjecutarConsulta()

        loProcesamiento.Show()
        loProcesamiento.lblTitulo.Text = "Reconstruyendo cabecera asientos..."
        Dim liCodEmpresa As Integer = 0
        Dim liNroAsiento As Integer = 0
        Dim ldDebito_o As Decimal = 0.00D
        Dim ldCredito_o As Decimal = 0.00D
        Dim ldDebito_b As Decimal = 0.00D
        Dim ldCredito_b As Decimal = 0.00D
        While (loDataReader.Read)
            loProcesamiento.lblRegistroLeido.Text = "Empresa: " & loDataReader.Item("codempresa").ToString & " - Nro.Asiento: " & loDataReader.Item("nroasiento").ToString & " - Debito: " & loDataReader.Item("debito_b").ToString & " - Credito: " & loDataReader.Item("credito_b").ToString
            liCodEmpresa = Integer.Parse(loDataReader.Item("codempresa").ToString)
            liNroAsiento = Integer.Parse(loDataReader.Item("nroasiento").ToString)
            ldDebito_o = Decimal.Parse(loDataReader.Item("debito_o").ToString)
            ldCredito_o = Decimal.Parse(loDataReader.Item("credito_o").ToString)
            ldDebito_b = Decimal.Parse(loDataReader.Item("debito_b").ToString)
            ldCredito_b = Decimal.Parse(loDataReader.Item("credito_b").ToString)
            loCabecera.codEmpresa = liCodEmpresa
            loCabecera.nroAsiento = liNroAsiento
            If loCabecera.GetPK = sOk_ Then
                loCabecera.debito_o = ldDebito_o
                loCabecera.credito_o = ldCredito_o
                loCabecera.debito_b = ldDebito_b
                loCabecera.credito_b = ldCredito_b
                Try
                    loCabecera.Put(sNo_, sNo_)
                Catch ex As DbException
                    piError = 1
                    GFsAvisar("Error durante actualizacio cabecera", sMENSAJE_, "Empresa:" & liCodEmpresa.ToString & ", NroAsiento:" & liNroAsiento.ToString & ", Debito_b: " & ldDebito_b.ToString & ", Credito_b: " & ldCredito_b.ToString)
                End Try
                loProcesamiento.lblRegistroProcesado.Text = "Empresa: " & loDataReader.Item("codempresa").ToString & " - Nro.Asiento: " & loDataReader.Item("nroasiento").ToString & " - Debito: " & loDataReader.Item("debito_b").ToString & " - Credito: " & loDataReader.Item("credito_b").ToString
                loProcesamiento.Refresh()
            End If
        End While
        loProcesamiento.Close()
        loProcesamiento = Nothing
        loCabecera.CerrarConexion()
        loCabecera = Nothing
        loDataReader.Close()
        loDataReader = Nothing
        loCN.Desconectar()
        loCN = Nothing
        GPBitacoraRegistrar(sSALIO_, "Reconstruccion Cabecera Asientos - Empresa:" & piCodEmpresa.ToString & ", Sucursal:" & piCodEmpresa.ToString & ", Periodo:" & psFecha1 & "-" & psFecha2)
    End Sub
End Module
