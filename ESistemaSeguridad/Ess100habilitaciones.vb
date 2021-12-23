Public Class Ess100habilitaciones : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss100habilitaciones"

    Private msRequeridos As String = "ss010_codigo" & sString_ & sSF_ &
                                        "tipo" & sString_ & sSF_ &
                                        "codigo" & sString_ & sSF_ &
                                        "ss080_codigo" & sString_ & sSF_ &
                                        "valido" & sString_ & sSF_ &
                                        "expira" & sString_

    Private miCampos_PK() As Integer = {0, 1, 2, 3}
#End Region

#Region "Campos requeridos"
    Private msSS010_codigo As String
    Private msTipo As String
    Private msCodigo As String
    Private msSS080_codigo As String
    Private msValido As String
    Private msExpira As String
#End Region

    Public Property ss010_codigo As String
        Get
            Return msSS010_codigo
        End Get
        Set(value As String)
            msSS010_codigo = value
        End Set
    End Property

    Public Property tipo As String
        Get
            Return msTipo
        End Get
        Set(value As String)
            msTipo = value
        End Set
    End Property

    Public Property codigo As String
        Get
            Return msCodigo
        End Get
        Set(value As String)
            msCodigo = value
        End Set
    End Property

    Public Property ss080_codigo As String
        Get
            Return msSS080_codigo
        End Get
        Set(value As String)
            msSS080_codigo = value
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
