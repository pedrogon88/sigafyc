Imports System.Data.Common

Module modGFsTieneMovimientos

    Public Function GFsTieneMovimientos(ByVal piCodEmpresa As Integer, ByVal piNroAsiento As Integer) As String
        Dim lsResultado As String = sNo_
        Dim loD010 As New Ed010asientosdetalles
        Dim loDatos As DbDataReader
        Dim lsSQL As String = GFsGeneraSQL("GFsTieneMovimientos_Asiento")

        loD010.codEmpresa = piCodEmpresa
        loD010.ejercicio = GFsEjercicioContable(piCodEmpresa)
        loD010.nroAsiento = piNroAsiento

        loDatos = loD010.RecuperarConsulta(lsSQL)

        If loDatos.Read Then
            If Not loDatos.Item("cantidad") Is DBNull.Value Then
                If Integer.Parse(loDatos.Item("cantidad").ToString) > 0 Then
                    lsResultado = sSi_
                End If
            End If
        End If
        loD010.CerrarConexion()
        loD010 = Nothing

        loDatos = Nothing
        Return lsResultado
    End Function

    Public Function GFsTieneMovimientos(ByVal piCodEmpresa As Integer, ByVal psCodCuenta As String) As String
        Dim lsResultado As String = sNo_
        Dim loD010 As New Ed010asientosdetalles
        Dim loDatos As DbDataReader
        Dim lsSQL As String = GFsGeneraSQL("GFsTieneMovimientos_Cuenta")

        loD010.codEmpresa = piCodEmpresa
        loD010.ejercicio = GFsEjercicioContable(piCodEmpresa)
        loD010.codCuenta = psCodCuenta

        loDatos = loD010.RecuperarConsulta(lsSQL)

        If loDatos.Read Then
            If Not loDatos.Item("cantidad") Is DBNull.Value Then
                If Integer.Parse(loDatos.Item("cantidad").ToString) > 0 Then
                    lsResultado = sSi_
                End If
            End If
        End If
        loD010.CerrarConexion()
        loD010 = Nothing

        loDatos = Nothing
        Return lsResultado
    End Function
End Module
