Module modGFdImporte_mb
    Public Function GFdImporte_mb(ByVal piCodEmpresa As Integer, ByVal pdImporte As Decimal, ByVal psCodMoneda As String, ByVal psFecha As String, ByVal psCotizacion As String) As Decimal
        Dim ldResultado As Decimal = 0.00D
        Dim lsCodMoneda_b As String = ""
        Dim liDecimal As Integer = 0
        Dim loC001 As New Ec001empresas
        loC001.codEmpresa = piCodEmpresa
        If loC001.GetPK = sOk_ Then
            lsCodMoneda_b = loC001.codMoneda
        End If
        loC001.CerrarConexion()
        loC001 = Nothing

        Dim loA010 As New Ea010monedas
        loA010.codMoneda = lsCodMoneda_b
        If loA010.GetPK = sOk_ Then
            liDecimal = loA010.decimales
        End If
        loA010.CerrarConexion()
        loA010 = Nothing

        Dim liCotizacion() As Integer = GFiCotizacion(psCodMoneda, lsCodMoneda_b, psFecha)
        Dim ldImporte As Decimal = 0.00D
        Select Case psCotizacion
            Case sCompra_
                ldImporte = pdImporte * liCotizacion(0)
            Case sVenta_
                ldImporte = pdImporte * liCotizacion(1)
            Case sSemisuma_
                ldImporte = pdImporte * ((liCotizacion(0) + liCotizacion(1)) \ 2)
        End Select
        ldResultado = Math.Round(ldImporte, liDecimal)
        Return ldResultado
    End Function
End Module
