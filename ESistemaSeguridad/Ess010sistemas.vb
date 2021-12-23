Public Class Ess010sistemas : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss010sistemas"

    Private msRequeridos As String = "codigo" & sString_ & sSF_ &
                                       "nombre" & sString_
    Private msCampos_PK() As Integer = {0}
#End Region

#Region "Campos requeridos"
    Private msCodigo As String
    Private msNombre As String
#End Region

    Public Property codigo As String
        Get
            Return msCodigo
        End Get
        Set(value As String)
            msCodigo = value
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
