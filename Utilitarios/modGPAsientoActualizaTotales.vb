Imports System.Data.Common

Module modGPAsientoActualizaTotales

    Public Sub GPAsientosActualizaTotales(ByVal piCodEmpresa As Integer, ByVal piNroAsiento As Integer)
        Dim ldDebito_mo As Decimal = 0.00D
        Dim ldDebito_mb As Decimal = 0.00D
        Dim ldCredito_mo As Decimal = 0.00D
        Dim ldCredito_mb As Decimal = 0.00D
        Dim lsSQL As String = GFsGeneraSQL("Ed010asientosdetalles_Totales")

        Try
            Dim loD010 As New Ed010asientosdetalles
            loD010.codEmpresa = piCodEmpresa
            loD010.nroAsiento = piNroAsiento
            Dim loDatos As DbDataReader = loD010.RecuperarConsulta(lsSQL)
            If loDatos.Read Then
                If Not loDatos.Item("debito_mo") Is DBNull.Value Then
                    ldDebito_mo = Decimal.Parse(loDatos.Item("debito_mo").ToString)
                End If
                If Not loDatos.Item("debito_mb") Is DBNull.Value Then
                    ldDebito_mb = Decimal.Parse(loDatos.Item("debito_mb").ToString)
                End If
                If Not loDatos.Item("credito_mo") Is DBNull.Value Then
                    ldCredito_mo = Decimal.Parse(loDatos.Item("credito_mo").ToString)
                End If
                If Not loDatos.Item("credito_mb") Is DBNull.Value Then
                    ldCredito_mb = Decimal.Parse(loDatos.Item("credito_mb").ToString)
                End If
            End If
            loDatos = Nothing
        Catch ex As Exception
            GFsAvisar("Ed010asientosdetalles ActualizaTotales Sumatoria", sMENSAJE_, ex.Message)
        End Try

        Try
            Dim loE010 As New Ee010asientoscabeceras
            loE010.codEmpresa = piCodEmpresa
            loE010.nroAsiento = piNroAsiento
            If loE010.GetPK = sOk_ Then
                loE010.codEmpresa = piCodEmpresa
                loE010.nroAsiento = piNroAsiento
                loE010.debito_o = Decimal.Parse(ldDebito_mo.ToString(sFormatF_))
                loE010.debito_b = Decimal.Parse(ldDebito_mb.ToString(sFormatF_))
                loE010.credito_o = Decimal.Parse(ldCredito_mo.ToString(sFormatF_))
                loE010.credito_b = Decimal.Parse(ldCredito_mb.ToString(sFormatF_))
                Try
                    loE010.Put(sNo_, sNo_)
                Catch ex As Exception
                    GFsAvisar("Ed010asientosdetalles ActualizaTotales GuardaTotales", sMENSAJE_, ex.Message)
                End Try
            End If
            loE010.CerrarConexion()
            loE010 = Nothing
        Catch ex As Exception
            GFsAvisar("Ed010asientosdetalles ActualizaTotales Recupera Asiento", sMENSAJE_, ex.Message)
        End Try
    End Sub
End Module
