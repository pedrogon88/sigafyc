Module modGFsDefinidoCuentaResultado

    Public Function GFsDefinidoCuentaResultado(ByVal piCodEmpresa As Integer) As String
        Dim lsResultado = sNo_
        Dim loC001 As New Ec001empresas

        loC001.codEmpresa = piCodEmpresa
        If loC001.GetPK = sOk_ Then
            Dim lsCuentas As String = loC001.ctaResultado1 & loC001.ctaResultado2 & loC001.ctaResultado3
            If lsCuentas.Trim.Length > 0 Then
                lsResultado = sSi_
            End If
        End If
        loC001.CerrarConexion()
        loC001 = Nothing
        Return lsResultado
    End Function

End Module
