Imports System.Data.Common

Public Class Eb090cuentassaldos : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "b090cuentassaldos"

    Private msRequeridos As String = "tiposaldo" & sString_ & sSF_ &
                                       "codempresa" & sInteger_ & sSF_ &
                                       "codcuenta" & sString_ & sSF_ &
                                       "codsucursal" & sInteger_ & sSF_ &
                                       "periodo" & sString_ & sSF_ &
                                       "debito" & sDecimal_ & sSF_ &
                                       "credito" & sDecimal_

    Private msCampos_PK() As Integer = {0, 1, 2, 3, 4}
#End Region

#Region "Campos requeridos"
    Private msTipoSaldo As String
    Private miCodEmpresa As Integer
    Private msCodCuenta As String
    Private miCodSucursal As Integer
    Private msPeriodo As String
    Private mdDebito As Decimal
    Private mdCredito As Decimal
#End Region
    Public Property tipoSaldo As String
        Get
            Return msTipoSaldo
        End Get
        Set(value As String)
            msTipoSaldo = value
        End Set
    End Property

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
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

    Public Property codSucursal As Integer
        Get
            Return miCodSucursal
        End Get
        Set(value As Integer)
            miCodSucursal = value
        End Set
    End Property

    Public Property periodo As String
        Get
            Return msPeriodo
        End Get
        Set(value As String)
            msPeriodo = value
        End Set
    End Property

    Public Property debito As Decimal
        Get
            Return mdDebito
        End Get
        Set(value As Decimal)
            mdDebito = value
        End Set
    End Property

    Public Property credito As Decimal
        Get
            Return mdCredito
        End Get
        Set(value As Decimal)
            mdCredito = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Sub CerrarConexion()
        Desconectar(msTableName)
    End Sub

    Protected Overloads Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
