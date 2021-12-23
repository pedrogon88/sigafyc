Imports ADOX
Imports System.Data.Common

Module modGPCuentasSaldos
    Private Const sINGRESOS_ As String = "6"
    Private Const sEGRESOS_ As String = "7"
    Private Const sFormatoCuenta_ As String = "0.00.000.0000.00000.000000"

    Public Sub GPCuentaActualizaSaldo(ByVal piCodEmpresa As Integer, ByVal psCodCuenta As String, ByVal piCodSucursal As Integer, ByVal psFecha As String, ByVal psTipoMovimiento As String, ByVal pdImporte As Decimal, Optional psOperacion As String = sSumar_)
        '--> 12345678901234567890123456
        '--> 0.00.000.0000.00000.000000
        LPMayorizacionCuenta(piCodEmpresa, psCodCuenta, piCodSucursal, psFecha, psTipoMovimiento, pdImporte, psOperacion)

        Dim lsCuentaResultado As String = ""
        If Not (psCodCuenta.Substring(0, 1) = sINGRESOS_ Or psCodCuenta.Substring(0, 1) = sEGRESOS_) Then Exit Sub
        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK <> sOk_ Then
            GFsAvisar("La Empresa [" & piCodEmpresa.ToString(sFormatD_ & "6") & ", ha sido eliminado de la tabla de Empresas.", sMENSAJE_, "ESTO NO DEBERIA HABER OCURRIDO NUNCA!")
        Else
            Dim loCuentas As New Eb050plancuentas
            loCuentas.codEmpresa = loEmpresa.codEmpresa
            loCuentas.codCuenta = loEmpresa.ctaResultado1
            If loCuentas.GetPK <> sOk_ Then
                GFsAvisar("Para la Empresa [" & piCodEmpresa.ToString(sFormatD_ & "6") & ", no esta definido la cuenta de resultado [" & loEmpresa.ctaResultado1 & "].", sMENSAJE_, "ESTO NO DEBERIA HABER OCURRIDO NUNCA!")
            Else
                lsCuentaResultado = loCuentas.codCuenta
            End If
        End If
        If lsCuentaResultado.Trim.Length = 0 Then Exit Sub

        LPMayorizacionCuenta(piCodEmpresa, lsCuentaResultado, piCodSucursal, psFecha, psTipoMovimiento, pdImporte, psOperacion)
    End Sub

    Private Sub LPMayorizacionCuenta(ByVal piCodEmpresa As Integer, ByVal psCodCuenta As String, ByVal piCodSucursal As Integer, ByVal psFecha As String, ByVal psTipoMovimiento As String, ByVal pdImporte As Decimal, Optional psOperacion As String = sSumar_)
        Dim liTamano() As Integer = {1, 4, 8, 13, 19, 26}
        Dim lsCodCuenta As String = ""
        Dim liNivelInicial As Integer = LFiDeterminarNivelCuenta(psCodCuenta)

        For I As Integer = liNivelInicial To 1 Step -1
            lsCodCuenta = psCodCuenta.Substring(0, liTamano(I - 1))
            lsCodCuenta = LFsArmaCodigoCuenta(lsCodCuenta)
            LPCuentaActualizaSaldoFecha(piCodEmpresa, lsCodCuenta, piCodSucursal, psFecha, psTipoMovimiento, pdImporte, psOperacion)
            LPCuentaActualizaSaldoMensual(piCodEmpresa, lsCodCuenta, piCodSucursal, psFecha, psTipoMovimiento, pdImporte, psOperacion)
        Next
    End Sub

    Private Function LFiDeterminarNivelCuenta(ByVal psCodCuenta As String) As Integer
        '--> 01234567890123456789012345
        '--> 0.00.000.0000.00000.000000
        '
        Dim liResultado As Integer = 0
        Dim liNivel() As Integer = {0, 2, 5, 9, 14, 20}
        Dim liTamano() As Integer = {1, 2, 3, 4, 5, 6}
        For I As Integer = 5 To 0 Step -1
            Dim liNumero As Integer = Integer.Parse(psCodCuenta.Substring(liNivel(I), liTamano(I)).ToString)
            If liNumero > 0 Then
                liResultado = I + 1
                Exit For
            End If
        Next
        Return liResultado
    End Function

    Private Function LFsArmaCodigoCuenta(ByVal psCodCuenta As String) As String
        Dim lsResultado As String = psCodCuenta
        Dim liNivel As Integer = 0
        Dim liTamano() As Integer = {1, 4, 8, 13, 19, 26}
        Dim liDesde() As Integer = {1, 4, 8, 13, 19}
        '--> 12345678901234567890123456
        '--> 01234567890123456789012345
        '--> 0.00.000.0000.00000.000000
        For I As Integer = 1 To 6 Step 1
            If psCodCuenta.Trim.Length = liTamano(I - 1) Then
                liNivel = I
                Exit For
            End If
        Next
        If liNivel < 6 Then
            lsResultado = psCodCuenta & sFormatoCuenta_.Substring(liDesde(liNivel - 1), sFormatoCuenta_.Length - liDesde(liNivel - 1))
        End If

        Return lsResultado
    End Function

    Private Sub LPCuentaActualizaSaldoFecha(ByVal piCodEmpresa As Integer, ByVal psCodCuenta As String, ByVal piCodSucursal As Integer, ByVal psFecha As String, ByVal psTipoMovimiento As String, ByVal pdImporte As Decimal, Optional psOperacion As String = sSumar_)
        Dim loSaldo As New Eb090cuentassaldos
        loSaldo.tipoSaldo = sFecha_
        loSaldo.codEmpresa = piCodEmpresa
        loSaldo.codCuenta = psCodCuenta
        loSaldo.codSucursal = piCodSucursal
        loSaldo.periodo = psFecha
        If loSaldo.GetPK = sSinRegistros_ Then
            loSaldo.tipoSaldo = sFecha_
            loSaldo.codEmpresa = piCodEmpresa
            loSaldo.codCuenta = psCodCuenta
            loSaldo.codSucursal = piCodSucursal
            loSaldo.periodo = psFecha
            loSaldo.debito = 0.00D
            loSaldo.credito = 0.00D
            loSaldo.Add(sNo_, sNo_)
        End If
        Select Case psTipoMovimiento
            Case sDebito_.Substring(0, 1)
                Select Case psOperacion
                    Case sSumar_
                        loSaldo.debito += pdImporte
                    Case sRestar_
                        loSaldo.debito -= pdImporte
                End Select
            Case sCredito_.Substring(0, 1)
                Select Case psOperacion
                    Case sSumar_
                        loSaldo.credito += pdImporte
                    Case sRestar_
                        loSaldo.credito -= pdImporte
                End Select
        End Select
        loSaldo.Put(sNo_, sNo_)
        loSaldo.CerrarConexion()
        loSaldo = Nothing
    End Sub

    Private Sub LPCuentaActualizaSaldoMensual(ByVal piCodEmpresa As Integer, ByVal psCodCuenta As String, ByVal piCodSucursal As Integer, ByVal psFecha As String, ByVal psTipoMovimiento As String, ByVal pdImporte As Decimal, Optional psOperacion As String = sSumar_)
        Dim loSaldo As New Eb090cuentassaldos
        Dim loFecha As Date = Date.Parse(psFecha.ToString)

        loSaldo.tipoSaldo = sMensual_
        loSaldo.codEmpresa = piCodEmpresa
        loSaldo.codCuenta = psCodCuenta
        loSaldo.codSucursal = piCodSucursal
        loSaldo.periodo = loFecha.ToString("yyyy-MM")
        If loSaldo.GetPK = sSinRegistros_ Then
            loSaldo.tipoSaldo = sMensual_
            loSaldo.codEmpresa = piCodEmpresa
            loSaldo.codCuenta = psCodCuenta
            loSaldo.codSucursal = piCodSucursal
            loSaldo.periodo = loFecha.ToString("yyyy-MM")
            loSaldo.debito = 0.00D
            loSaldo.credito = 0.00D
            loSaldo.Add(sNo_, sNo_)
        End If
        Select Case psTipoMovimiento
            Case sDebito_.Substring(0, 1)
                Select Case psOperacion
                    Case sSumar_
                        loSaldo.debito += pdImporte
                    Case sRestar_
                        loSaldo.debito -= pdImporte
                End Select
            Case sCredito_.Substring(0, 1)
                Select Case psOperacion
                    Case sSumar_
                        loSaldo.credito += pdImporte
                    Case sRestar_
                        loSaldo.credito -= pdImporte
                End Select
        End Select
        loSaldo.Put(sNo_, sNo_)
        loSaldo.CerrarConexion()
        loSaldo = Nothing
    End Sub


    Public Function GFdCuentaSaldoObtener(ByVal piCodEmpresa As Integer, ByVal psCodCuenta As String, ByVal piCodSucursal As Integer, ByVal psFecha As String) As Decimal
        Dim ldResultado As Decimal = 0.00D
        Dim loFecha As Date = Date.Parse(psFecha)
        Dim lsPeriodoFinal As String = loFecha.AddMonths(-1).ToString("yyyy-MM-dd")
        Dim ldSaldoMensual As Decimal = LFdObtenerSaldo(sMensual_, piCodEmpresa, psCodCuenta, piCodSucursal, lsPeriodoFinal)
        Dim lsPeriodoInicial As String = loFecha.ToString("yyyy") & "-" & loFecha.ToString("MM") & "-01"
        Dim ldSaldoFecha As Decimal = LFdObtenerSaldo(sFecha_, piCodEmpresa, psCodCuenta, piCodSucursal, lsPeriodoInicial, psFecha)
        ldResultado = ldSaldoMensual + ldSaldoFecha
        Return ldResultado
    End Function

    Private Function LFdObtenerSaldo(ByVal psTipoSaldo As String, ByVal piCodEmpresa As Integer, ByVal psCodCuenta As String, ByVal piCodSucursal As Integer, ByVal psFecha1 As String, Optional ByVal psFecha2 As String = "") As Decimal
        Dim ldResultado As Decimal = 0.00D

        Dim lsSQL As String = "SELECT" & ControlChars.CrLf &
                              "  sum(b090.debito) - sum(b090.credito) as saldo" & ControlChars.CrLf &
                              "FROM" & ControlChars.CrLf &
                              "  b090cuentassaldos b090" & ControlChars.CrLf &
                              "WHERE" & ControlChars.CrLf &
                              "  b090.borrado <>" & Chr(39) & "*" & Chr(39) & ControlChars.CrLf &
                              "  AND b090.tiposaldo = " & Chr(39) & psTipoSaldo & Chr(39) & ControlChars.CrLf &
                              "  AND b090.codempresa = " & piCodEmpresa & ControlChars.CrLf &
                              "  AND b090.codcuenta = " & Chr(39) & psCodCuenta & Chr(39) & ControlChars.CrLf

        If piCodSucursal > 0 Then
            lsSQL &= "  AND b090.codsucursal = " & piCodSucursal & ControlChars.CrLf
        End If

        Select Case psTipoSaldo
            Case sMensual_
                lsSQL &= "  AND b090.periodo <= " & Chr(39) & psFecha1 & Chr(39) & ControlChars.CrLf
            Case sFecha_
                lsSQL &= "  AND b090.periodo >= " & Chr(39) & psFecha1 & Chr(39) & ControlChars.CrLf &
                         "  AND b090.periodo <= " & Chr(39) & psFecha2 & Chr(39) & ControlChars.CrLf
        End Select

        lsSQL &= "GROUP BY" & ControlChars.CrLf &
                 "  b090.borrado," & ControlChars.CrLf &
                 "  b090.tiposaldo," & ControlChars.CrLf &
                 "  b090.codempresa," & ControlChars.CrLf &
                 "  b090.codcuenta" & ControlChars.CrLf

        Dim loDatos As DbDataReader = Nothing
        Dim loB090 As New Eb090cuentassaldos

        loDatos = loB090.RecuperarConsulta(lsSQL)
        If loDatos IsNot Nothing Then
            If loDatos.Read() Then
                If loDatos.Item("saldo") IsNot Nothing Then
                    ldResultado = Decimal.Parse(loDatos.Item("saldo").ToString)
                End If
            End If
        End If
        Return ldResultado
    End Function
End Module
