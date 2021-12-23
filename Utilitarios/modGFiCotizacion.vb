Imports System.Data.Common

Module modGFiCotizacion

    Public Function GFiCotizacion(ByVal psCodMoneda1 As String, ByVal psCodMoneda2 As String, ByVal psVigencia As String) As Integer()
        Dim liResultado() As Integer = {0, 0}
        Dim loB030 As New Eb030cotizaciones
        Dim loDatos As DbDataReader = Nothing
        Dim ldVigencia As Date = Nothing
        Dim lsSQLoriginal As String = GFsGeneraSQL("Cotizaciones")
        Dim lsSQL As String = lsSQLoriginal

        If IsDate(psVigencia) Then
            ldVigencia = Date.Parse(psVigencia)
            psVigencia = ldVigencia.ToString(sFormatoFecha1_)
        Else
            psVigencia = Today.ToString(sFormatoFecha1_)
            GFsAvisar("Fecha vigencia [" & psVigencia & "] no es valido", sMENSAJE_, "Se asumira fecha del sistema [" & psVigencia & "]")
        End If

        loB030.codMoneda1 = psCodMoneda1
        loB030.codMoneda2 = psCodMoneda2
        loDatos = loB030.RecuperarConsulta(lsSQL)

        While loDatos.Read
            If loDatos.Item("valido").ToString <= psVigencia Then
                liResultado(0) = Integer.Parse(loDatos.Item("compra").ToString)
                liResultado(1) = Integer.Parse(loDatos.Item("venta").ToString)
                Exit While
            End If
        End While
        loB030.CerrarConexion()
        loB030 = Nothing
        loDatos = Nothing

        loB030 = New Eb030cotizaciones
        If liResultado(0) + liResultado(1) = 0 Then
            lsSQL = lsSQLoriginal
            loB030.codMoneda1 = psCodMoneda2
            loB030.codMoneda2 = psCodMoneda1
            loDatos = loB030.RecuperarConsulta(lsSQL)

            While loDatos.Read
                If loDatos.Item("valido").ToString <= psVigencia Then
                    liResultado(0) = Integer.Parse(loDatos.Item("compra").ToString)
                    liResultado(1) = Integer.Parse(loDatos.Item("venta").ToString)
                    Exit While
                End If
            End While
        End If

        Return liResultado
    End Function

End Module
