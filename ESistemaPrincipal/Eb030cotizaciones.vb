Public Class Eb030cotizaciones : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "b030cotizaciones"

    Private msRequeridos As String = "codmoneda1" & sString_ & sSF_ &
                                       "codmoneda2" & sString_ & sSF_ &
                                       "valido" & sString_ & sSF_ &
                                       "compra" & sInteger_ & sSF_ &
                                       "venta" & sInteger_

    Private msCampos_PK() As Integer = {0, 1, 2}
#End Region

#Region "Campos requeridos"
    Private msCodMoneda1 As String
    Private msCodMoneda2 As String
    Private msValido As String
    Private miCompra As Integer
    Private miVenta As Integer
#End Region

    Public Property codMoneda1 As String
        Get
            Return msCodMoneda1
        End Get
        Set(value As String)
            msCodMoneda1 = value
        End Set
    End Property

    Public Property codMoneda2 As String
        Get
            Return msCodMoneda2
        End Get
        Set(value As String)
            msCodMoneda2 = value
        End Set
    End Property

    Public Property valido As String
        Get
            Return msValido
        End Get
        Set(value As String)
            msValido = value
        End Set
    End Property

    Public Property compra As Integer
        Get
            Return miCompra
        End Get
        Set(value As Integer)
            miCompra = value
        End Set
    End Property

    Public Property venta As Integer
        Get
            Return miVenta
        End Get
        Set(value As Integer)
            miVenta = value
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
