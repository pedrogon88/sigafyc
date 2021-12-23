Public Class Ea010monedas : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "a010monedas"

    Private msRequeridos As String = "codmoneda" & sString_ & sSF_ &
                                       "nombre" & sString_ & sSF_ &
                                       "decimales" & sInteger_ & sSF_ &
                                       "culture" & sString_

    Private msCampos_PK() As Integer = {0}
#End Region

#Region "Campos requeridos"
    Private msCodMoneda As String
    Private msNombre As String
    Private miDecimales As Integer
    Private msCulture As String
#End Region

    Public Property codMoneda As String
        Get
            Return msCodMoneda
        End Get
        Set(value As String)
            msCodMoneda = value
        End Set
    End Property

    Public Property nombre As String
        Get
            Return msNombre
        End Get
        Set(value As String)
            msNombre = value
        End Set
    End Property

    Public Property decimales As Integer
        Get
            Return miDecimales
        End Get
        Set(value As Integer)
            miDecimales = value
        End Set
    End Property

    Public Property culture As String
        Get
            Return msCulture
        End Get
        Set(value As String)
            msCulture = value
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
