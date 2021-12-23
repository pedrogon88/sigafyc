Imports System.Data.Common

Module modGFbVerificaMovimientos

    Public Function GFbVerificaMovimientos(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha As String) As Boolean
        Dim lbResultado As Boolean = False
        Dim lsCtaResultado1 As String = ""
        Dim lsSucursal As String = ""

        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            lsCtaResultado1 = loEmpresa.ctaResultado1
        End If
        loEmpresa.CerrarConexion()
        loEmpresa = Nothing

        Dim lsSQL As String = GFsGeneraSQL("GFbVerificaMovimientos")
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)

        lsSucursal = ""
        If piCodSucursal > 0 Then
            lsSucursal = "AND b090.codsucursal = " & piCodSucursal.ToString
        End If
        lsSQL = lsSQL.Replace("@sucursal", lsSucursal)
        lsSQL = lsSQL.Replace("@fecha", psFecha)
        lsSQL = lsSQL.Replace("@ctaresultado1", lsCtaResultado1)

        Dim loDataReader As DbDataReader
        Dim loCN As New BaseDatos

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        Try
            loCN.Conectar()
        Catch ex As Exception
            GFsAvisar("GFbVerificaMovimientos -> Conectando a base de datos", sMENSAJE_, ex.Message)
            Return lbResultado
        End Try

        loCN.CrearComando(lsSQL)
        Try
            loDataReader = loCN.EjecutarConsulta
        Catch ex As Exception
            GFsAvisar("GFbVerificaMovimientos -> Recuperar datos", sMENSAJE_, ex.Message)
            Return lbResultado
        End Try
        If loDataReader.Read Then
            Dim liCantidad As Integer = Integer.Parse(loDataReader("cantidad").ToString)
            If liCantidad > 0 Then
                Dim ldDebitos As Decimal = Decimal.Parse(loDataReader("debitos").ToString)
                Dim ldCreditos As Decimal = Decimal.Parse(loDataReader("creditos").ToString)
                If ldDebitos = ldCreditos Then
                    lbResultado = True
                End If
            End If
        End If
        loDataReader.Close()
        loDataReader = Nothing
        loCN.Desconectar()
        loCN = Nothing

        Return lbResultado
    End Function

End Module
