Public Class Ess060equipos : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss060equipos"

    Private msRequeridos As String = "codigo" & sString_ & sSF_ &
                                        "ubicacion" & sString_ & sSF_ &
                                        "mac" & sString_ & sSF_ &
                                        "ip" & sString_ & sSF_ &
                                        "valido" & sString_ & sSF_ &
                                        "expira" & sString_
    Private miCampos_PK() As Integer = {0}
#End Region

#Region "Campos requeridos"
    Private msCodigo As String
    Private msUbicacion As String
    Private msIp As String
    Private msMac As String
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

    Public Property ubicacion As String
        Get
            Return msUbicacion
        End Get
        Set(value As String)
            msUbicacion = value
        End Set
    End Property

    Public Property ip As String
        Get
            Return msIp
        End Get
        Set(value As String)
            msIp = value
        End Set
    End Property

    Public Property mac As String
        Get
            Return msMac
        End Get
        Set(value As String)
            msMac = value
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
