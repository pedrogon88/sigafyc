Imports System.Data.Common

Module modGFsTieneSubCuentas
    Public Function GFsTieneSubCuentas(ByVal psCodCuenta As String, ByVal psNivel As String) As String
        Dim lsResultado As String = sNo_
        Dim loDatos As DbDataReader
        Dim loB050 As New Eb050plancuentas
        Dim lsSQL As String = GFsGeneraSQL("Eb050plancuentas_ConSubCuentas")
        lsSQL = lsSQL.Replace("@codcuenta", LFsExtraeCodigo(psCodCuenta, psNivel))
        Try
            loDatos = loB050.RecuperarConsulta(lsSQL)
            If loDatos.Read Then
                If Not loDatos.Item("cantidad") Is DBNull.Value Then
                    If Integer.Parse(loDatos.Item("cantidad").ToString) > 0 Then
                        lsResultado = sSi_
                    End If
                End If
            End If
        Catch ex As Exception
            GFsAvisar("GFsTieneSubCuentas", sMENSAJE_, ex.Message)
        End Try

        Return lsResultado
    End Function

    Private Function LFsExtraeCodigo(ByVal psCuenta As String, ByVal psNivel As String) As String
        ' 12345678901234567890123456
        ' 0.00.000.0000.00000.000000
        Dim lsResultado As String = ""
        Select Case psNivel
            Case "2"
                lsResultado = psCuenta.Substring(0, 4)
            Case "3"
                lsResultado = psCuenta.Substring(0, 8)
            Case "4"
                lsResultado = psCuenta.Substring(0, 13)
            Case "5"
                lsResultado = psCuenta.Substring(0, 19)
            Case "6"
                lsResultado = psCuenta
        End Select

        Return lsResultado
    End Function

End Module
