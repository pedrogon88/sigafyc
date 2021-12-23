Imports System.Data.Common

Public Class Eoitmc1 : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "oitmc1"

    Private msRequeridos As String = "itemcode" & sString_ & sSF_ &
                                       "cardcode" & sString_ & sSF_ &
                                       "u_abogado" & sString_ & sSF_ &
                                       "u_inicialesabog" & sString_ & sSF_ &
                                       "fechademanda" & sString_ & sSF_ &
                                       "fechaordensecuestro" & sString_ & sSF_ &
                                       "fechasecuestro" & sString_ & sSF_ &
                                       "valortasacion" & sDecimal_ & sSF_ &
                                       "fecharemate" & sString_ & sSF_ &
                                       "gastoventa" & sDecimal_ & sSF_ &
                                       "precioventa" & sDecimal_

    Private msCampos_PK() As Integer = {0, 1}
#End Region

#Region "Campos requeridos"
    Private msItemCode As String
    Private msCardCode As String
    Private msAbogado As String
    Private msInicialesAbog As String
    Private msFechaDemanda As String
    Private msFechaOrdenSecuestro As String
    Private msFechaSecuestro As String
    Private mdValorTasacion As Decimal
    Private msFechaRemate As String
    Private mdGastoVenta As Decimal
    Private mdPrecioVenta As Decimal
#End Region

#Region "Propiedades"
    Public Property Empresa As String
    Public Property Sucursal As String
    Public Property PeriodoFac As String
    Public Property SaldoUSD As Decimal
    Public Property VentaUSD As Decimal
    Public Property PagosUSD As Decimal
#End Region


    Public Property ItemCode As String
        Get
            Return msItemCode
        End Get
        Set(value As String)
            msItemCode = value
        End Set
    End Property

    Public Property CardCode As String
        Get
            Return msCardCode
        End Get
        Set(value As String)
            msCardCode = value
        End Set
    End Property

    Public Property U_Abogado As String
        Get
            Return msAbogado
        End Get
        Set(value As String)
            msAbogado = value
        End Set
    End Property

    Public Property U_InicialesAbog As String
        Get
            Return msInicialesAbog
        End Get
        Set(value As String)
            msInicialesAbog = value
        End Set
    End Property

    Public Property FechaDemanda As String
        Get
            Return msFechaDemanda
        End Get
        Set(value As String)
            msFechaDemanda = value
        End Set
    End Property

    Public Property FechaOrdenSecuestro As String
        Get
            Return msFechaOrdenSecuestro
        End Get
        Set(value As String)
            msFechaOrdenSecuestro = value
        End Set
    End Property

    Public Property FechaSecuestro As String
        Get
            Return msFechaSecuestro
        End Get
        Set(value As String)
            msFechaSecuestro = value
        End Set
    End Property

    Public Property ValorTasacion As Decimal
        Get
            Return mdValorTasacion
        End Get
        Set(value As Decimal)
            mdValorTasacion = value
        End Set
    End Property

    Public Property FechaRemate As String
        Get
            Return msFechaRemate
        End Get
        Set(value As String)
            msFechaRemate = value
        End Set
    End Property

    Public Property GastoVenta As Decimal
        Get
            Return mdGastoVenta
        End Get
        Set(value As Decimal)
            mdGastoVenta = value
        End Set
    End Property

    Public Property PrecioVenta As Decimal
        Get
            Return mdPrecioVenta
        End Get
        Set(value As Decimal)
            mdPrecioVenta = value
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
