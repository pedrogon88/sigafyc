Imports System.Data.Common

Module modGFiVerificaCantidadMovimientos

    Public Function GFiVerificaCantidadMovimientos(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, Optional psFecha1 As String = "", Optional psFecha2 As String = "") As Integer
        Dim liResultado As Integer = 0
        Dim lsCtaResultado1 As String = ""
        Dim lsEjercicio As String = ""
        Dim lsFecha1 As String = psFecha1
        Dim lsFecha2 As String = psFecha2
        If lsFecha1.Trim.Length + lsFecha2.Trim.Length = 0 Then
            Dim loEmpresa As New Ec001empresas
            loEmpresa.codEmpresa = piCodEmpresa
            If loEmpresa.GetPK = sOk_ Then
                lsFecha1 = loEmpresa.periodoInicio
                lsFecha2 = loEmpresa.periodoFinal
                lsCtaResultado1 = loEmpresa.ctaResultado1
                lsEjercicio = loEmpresa.periodoInicio.Substring(0, 4)
            End If
        End If
        Dim lsSQL As String = GFsGeneraSQL("GFiVerificaCantidadMovimientos")
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        Dim lsSucursal As String = ""
        If piCodSucursal > 0 Then
            lsSucursal = "AND b090.codsucursal = " & piCodSucursal
        End If
        lsSQL = lsSQL.Replace("@Sucursal", lsSucursal)
        lsSQL = lsSQL.Replace("@fecha1", lsFecha1)
        lsSQL = lsSQL.Replace("@fecha2", lsFecha2)
        lsSQL = lsSQL.Replace("@ctaresultado1", lsCtaResultado1)

        Dim loDataReader As DbDataReader = Nothing
        Dim loCN As New BaseDatos

        loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
        Try
            loCN.Conectar()
        Catch ex As Exception
            GFsAvisar("GPVerificaCantidadMovimientos -> Conectando a base de datos", sMENSAJE_, ex.Message)
        End Try

        loCN.CrearComando(lsSQL)
        Try
            loDataReader = loCN.EjecutarConsulta
        Catch ex As Exception
            GFsAvisar("GPVerificaCantidadMovimientos -> Recuperar datos", sMENSAJE_, ex.Message)
        End Try

        If loDataReader.Read Then
            liResultado = Integer.Parse(loDataReader("cantidad").ToString)
        End If
        loDataReader.Close()
        loDataReader = Nothing
        loCN.Desconectar()
        loCN = Nothing

        Return liResultado
    End Function

End Module
