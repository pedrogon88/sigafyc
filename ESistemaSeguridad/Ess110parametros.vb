Public Class Ess110parametros : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss110parametros"

    Private msRequeridos As String = "ss010_codigo" & sString_ & sSF_ &
                                        "tipo" & sString_ & sSF_ &
                                        "prefijo" & sString_ & sSF_ &
                                        "clave" & sString_ & sSF_ &
                                        "valor" & sString_

    Private miCampos_PK() As Integer = {0, 1, 2, 3}
#End Region

#Region "Campos requeridos"
    Private msSS010_codigo As String
    Private msTipo As String
    Private msPrefijo As String
    Private msClave As String
    Private msValor As String
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

    Public Property prefijo As String
        Get
            Return msPrefijo
        End Get
        Set(value As String)
            msPrefijo = value
        End Set
    End Property

    Public Property clave As String
        Get
            Return msClave
        End Get
        Set(value As String)
            msClave = value
        End Set
    End Property

    Public Property valor As String
        Get
            Return msValor
        End Get
        Set(value As String)
            msValor = value
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
