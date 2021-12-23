Module modGFsCuentaFormat

    Public Function GFsCuentaFormat(ByVal psCodCuenta As String) As String
        ' 12345678901234567890123456 -> longitud
        ' 01234567890123456789012345 -> posicion
        ' 1.01.001.0001.00001.000001 -> pattern
        Dim lsResultado As String = psCodCuenta

        If Integer.Parse(lsResultado.Substring(20, 6)) = 0 Then
            lsResultado = lsResultado.Substring(0, 19)
        End If
        If Integer.Parse(lsResultado.Substring(14, 5)) = 0 Then
            lsResultado = lsResultado.Substring(0, 13)
        End If
        If Integer.Parse(lsResultado.Substring(9, 4)) = 0 Then
            lsResultado = lsResultado.Substring(0, 8)
        End If
        If Integer.Parse(lsResultado.Substring(5, 3)) = 0 Then
            lsResultado = lsResultado.Substring(0, 4)
        End If
        If Integer.Parse(lsResultado.Substring(2, 2)) = 0 Then
            lsResultado = lsResultado.Substring(0, 1)
        End If

        Return lsResultado
    End Function


End Module
