Module modGFcDeterminaSeparador

    Public Function GFcDeterminaSeparador(ByVal psLinea As String, ByVal pcSeparador As Char) As Char
        Dim lcSeparadores() As Char = {"|"c, ";"c}
        Dim lcResultado As Char = pcSeparador

        If InStr(psLinea, pcSeparador) = 0 Then
            For I As Integer = 0 To lcSeparadores.Length - 1
                If InStr(psLinea, lcSeparadores(I)) > 0 Then
                    lcResultado = lcSeparadores(I)
                    Exit For
                End If
            Next
        End If
        Return lcResultado
    End Function

End Module
