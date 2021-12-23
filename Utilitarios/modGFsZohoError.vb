Module modGFsZohoError

    Public Function GFsZohoError(ByVal psCadena As String) As String
        Dim lsResultado As String = sOk_

        If psCadena.Trim.Length > 0 Then
            For Each lsError As String In LFoListaErrores()
                If InStr(psCadena, lsError, CompareMethod.Text) > 0 Then
                    lsResultado = "Error ->" & psCadena.Trim & ", Msg:" & lsError
                    Exit For
                End If
            Next
        Else
            lsResultado = "Error: Parametro de entrada cadena vacia."
        End If

        Return lsResultado
    End Function

#Region "Area Privada"
    Private Function LFoListaErrores() As String()
        Dim lsZohoErrores() As String = {"invalid_code", "invalid_client", "invalid_redirect_uri", "INVALID_URL_PATTERN", "OAUTH_SCOPE_MISMATCH", "NO_PERMISSION", "INTERNAL_ERROR", "INVALID_REQUEST_METHOD", "AUTHORIZATION_FAILED", "INVALID_MODULE", "REQUIRED_PARAM_MISSING", "NOT_SUPPORTED", "PATTERN_NOT_MATCHED", "INVALID_DATA", "SYNTAX_ERROR", "LIMIT_EXCEEDED", "INVALID_QUERY", "DUPLICATE_DATA", "INVALID_FIELD_NAME", "Our service is temporarily unavailable"}
        Return lsZohoErrores
    End Function
#End Region
End Module
