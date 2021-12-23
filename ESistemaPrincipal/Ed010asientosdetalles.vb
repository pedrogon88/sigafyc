Imports System.Data.Common

Public Class Ed010asientosdetalles : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "d010asientosdetalles"

    Private msRequeridos As String = "codempresa" & sInteger_ & sSF_ &
                                       "ejercicio" & sString_ & sSF_ &
                                       "nroasiento" & sInteger_ & sSF_ &
                                       "nrosecuencia" & sInteger_ & sSF_ &
                                       "codcuenta" & sString_ & sSF_ &
                                       "tipomovimiento" & sString_ & sSF_ &
                                       "importe_mo" & sDecimal_ & sSF_ &
                                       "importe_mb" & sDecimal_ & sSF_ &
                                       "codconcepto" & sInteger_ & sSF_ &
                                       "concepto" & sString_

    Private msCampos_PK() As Integer = {0, 1, 2, 3}
    Private msAutonumerado As String = "nrosecuencia"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miCodEmpresa As Integer
    Private msEjercicio As String
    Private miNroAsiento As Integer
    Private miNroSecuencia As Integer
    Private msCodCuenta As String
    Private msTipoMovimiento As String
    Private mdImporte_mo As Decimal
    Private mdImporte_mb As Decimal
    Private miCodConcepto As Integer
    Private msConcepto As String
#End Region

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
            msEjercicio = GFsEjercicioContable(miCodEmpresa)
        End Set
    End Property

    Public Property ejercicio As String
        Get
            Return msEjercicio
        End Get
        Set(value As String)
            msEjercicio = value
        End Set
    End Property

    Public Property nroAsiento As Integer
        Get
            Return miNroAsiento
        End Get
        Set(value As Integer)
            miNroAsiento = value
        End Set
    End Property

    Public Property nroSecuencia As Integer
        Get
            Return miNroSecuencia
        End Get
        Set(value As Integer)
            miNroSecuencia = value
        End Set
    End Property

    Public Property codCuenta As String
        Get
            Return msCodCuenta
        End Get
        Set(value As String)
            msCodCuenta = value
        End Set
    End Property

    Public Property tipoMovimiento As String
        Get
            Return msTipoMovimiento
        End Get
        Set(value As String)
            msTipoMovimiento = value
        End Set
    End Property

    Public Property importe_mo As Decimal
        Get
            Return mdImporte_mo
        End Get
        Set(value As Decimal)
            mdImporte_mo = value
        End Set
    End Property

    Public Property importe_mb As Decimal
        Get
            Return mdImporte_mb
        End Get
        Set(value As Decimal)
            mdImporte_mb = value
        End Set
    End Property
    Public Property codConcepto As Integer
        Get
            Return miCodConcepto
        End Get
        Set(value As Integer)
            miCodConcepto = value
        End Set
    End Property

    Public Property concepto As String
        Get
            Return msConcepto
        End Get
        Set(value As String)
            msConcepto = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Function ReservarRegistro(ByVal piCodEmpresa As Integer, ByVal piNroAsiento As Integer) As Integer
        codEmpresa = piCodEmpresa
        nroAsiento = piNroAsiento
        Dim liNumero As Integer = SiguienteNumero(msAutonumerado, msTableName, msFiltroClave)
        codEmpresa = piCodEmpresa
        nroAsiento = piNroAsiento
        nroSecuencia = liNumero
        codCuenta = sRESERVADO_
        tipoMovimiento = sCero1_
        importe_mo = 0.00D
        importe_mb = 0.00D
        codConcepto = 0
        concepto = sRESERVADO_
        Add(sNo_, sNo_)
        Return liNumero
    End Function

    Public Overloads Sub Add(Optional ByVal psConfirmar As String = sSi_, Optional ByVal psBitacora As String = sSi_, Optional psDesplegarRegistro As String = sNo_, Optional psMensaje As String = "", Optional psActualizar As String = sNo_)
        MyBase.Add(psConfirmar, psBitacora, psDesplegarRegistro, psMensaje)
        If psActualizar = sSi_ Then
            Call ComenzarTransaccion()
            Dim loCabecera As New Ee010asientoscabeceras
            loCabecera.codEmpresa = miCodEmpresa
            loCabecera.ejercicio = msEjercicio
            loCabecera.nroAsiento = miNroAsiento
            If loCabecera.GetPK = sOk_ Then
                GPCuentaActualizaSaldo(miCodEmpresa, msCodCuenta, loCabecera.codSucursal, loCabecera.fecha, msTipoMovimiento, mdImporte_mb, sSumar_)
                Select Case msTipoMovimiento
                    Case sDebito_.Substring(0, msTipoMovimiento.Trim.Length)
                        loCabecera.debito_o += mdImporte_mo
                        loCabecera.debito_b += mdImporte_mb
                    Case sCredito_.Substring(0, msTipoMovimiento.Trim.Length)
                        loCabecera.credito_o += mdImporte_mo
                        loCabecera.credito_b += mdImporte_mb
                End Select
                loCabecera.Put(sNo_, sNo_)
            End If
            loCabecera.CerrarConexion()
            loCabecera = Nothing
            Call ConfirmarTransaccion()
        End If
    End Sub

    Public Overloads Sub Del(Optional ByVal psConfirmar As String = sSi_, Optional ByVal psBitacora As String = sSi_, Optional psActualizar As String = sNo_)
        Dim liCodEmpresa As Integer = miCodEmpresa
        Dim lsEjercicio As String = msEjercicio
        Dim lsCodCuenta As String = msCodCuenta
        Dim liNroAsiento As Integer = miNroAsiento
        Dim lsTipoMovimiento As String = msTipoMovimiento
        Dim ldImporte_mb As Decimal = mdImporte_mb
        MyBase.Del(psConfirmar, psBitacora)
        If psActualizar = sSi_ Then
            Call ComenzarTransaccion()
            Dim loCabecera As New Ee010asientoscabeceras
            loCabecera.codEmpresa = liCodEmpresa
            loCabecera.ejercicio = lsEjercicio
            loCabecera.nroAsiento = liNroAsiento
            If loCabecera.GetPK = sOk_ Then
                GPCuentaActualizaSaldo(liCodEmpresa, lsCodCuenta, loCabecera.codSucursal, loCabecera.fecha, lsTipoMovimiento, ldImporte_mb, sRestar_)
                Select Case msTipoMovimiento
                    Case sDebito_.Substring(0, msTipoMovimiento.Trim.Length)
                        loCabecera.debito_o -= mdImporte_mo
                        loCabecera.debito_b -= mdImporte_mb
                    Case sCredito_.Substring(0, msTipoMovimiento.Trim.Length)
                        loCabecera.credito_o -= mdImporte_mo
                        loCabecera.credito_b -= mdImporte_mb
                End Select
                loCabecera.Put(sNo_, sNo_)
            End If
            loCabecera.CerrarConexion()
            loCabecera = Nothing
            Call ConfirmarTransaccion()
        End If
    End Sub

    Public Overloads Sub Put(Optional ByVal psConfirmar As String = sSi_, Optional ByVal psBitacora As String = sSi_, Optional ByVal psAccion As String = "", Optional ByVal psActualizar As String = sNo_, Optional ByVal poAnterior As Dd010asientosdetalles = Nothing)
        Dim liCodEmpresa As Integer = miCodEmpresa
        Dim lsEjercicio As String = msEjercicio
        Dim liNroAsiento As Integer = miNroAsiento
        Call ComenzarTransaccion()
        MyBase.Put(psConfirmar, psBitacora, psAccion)
        If psActualizar = sSi_ Then
            Dim loCabecera As New Ee010asientoscabeceras
            loCabecera.codEmpresa = liCodEmpresa
            loCabecera.ejercicio = lsEjercicio
            loCabecera.nroAsiento = liNroAsiento
            If loCabecera.GetPK = sOk_ Then
                If psAccion <> sAGREGAR_ Then
                    GPCuentaActualizaSaldo(liCodEmpresa, poAnterior.codCuenta, loCabecera.codSucursal, loCabecera.fecha, poAnterior.tipoMovimiento, poAnterior.importe_mb, sRestar_)
                    Select Case poAnterior.tipoMovimiento
                        Case sDebito_.Substring(0, poAnterior.tipoMovimiento.Trim.Length)
                            loCabecera.debito_o -= poAnterior.importe_mo
                            loCabecera.debito_b -= poAnterior.importe_mb
                        Case sCredito_.Substring(0, poAnterior.tipoMovimiento.Trim.Length)
                            loCabecera.credito_o -= poAnterior.importe_mo
                            loCabecera.credito_b -= poAnterior.importe_mb
                    End Select
                    loCabecera.Put(sNo_, sNo_)
                End If
                GPCuentaActualizaSaldo(miCodEmpresa, msCodCuenta, loCabecera.codSucursal, loCabecera.fecha, msTipoMovimiento, mdImporte_mb, sSumar_)
                Select Case msTipoMovimiento
                    Case sDebito_.Substring(0, msTipoMovimiento.Trim.Length)
                        loCabecera.debito_o += mdImporte_mo
                        loCabecera.debito_b += mdImporte_mb
                    Case sCredito_.Substring(0, msTipoMovimiento.Trim.Length)
                        loCabecera.credito_o += mdImporte_mo
                        loCabecera.credito_b += mdImporte_mb
                End Select
                loCabecera.Put(sNo_, sNo_)
            End If
            loCabecera.CerrarConexion()
            loCabecera = Nothing
        End If
        Call ConfirmarTransaccion()
    End Sub
    Public Sub CerrarConexion()
        Desconectar(msTableName)
    End Sub

    Protected Overloads Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
