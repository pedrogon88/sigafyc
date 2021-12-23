Public Class Ess070perfiles : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss070perfiles"

    Private msRequeridos As String = "codigo" & sString_ & sSF_ &
                                        "nombre" & sString_ & sSF_ &
                                        "valido" & sString_ & sSF_ &
                                        "expira" & sString_

    Private miCampos_PK() As Integer = {0}
#End Region

#Region "Campos requeridos"
    Private msCodigo As String
    Private msNombre As String
    Private msValido As String
    Private msExpira As String
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

    Public Property valido As String
        Get
            Return msValido
        End Get
        Set(value As String)
            msValido = value
        End Set
    End Property

    Public Property expira As String
        Get
            Return msExpira
        End Get
        Set(value As String)
            msExpira = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, miCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Sub CerrarConexion()
        Desconectar(msTableName)
    End Sub

    Public Overloads Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
