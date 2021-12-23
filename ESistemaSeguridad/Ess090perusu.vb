Public Class Ess090perusu : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss090perusu"

    Private msRequeridos As String = "ss070_codigo" & sString_ & sSF_ &
                                        "ss050_codigo" & sString_

    Private miCampos_PK() As Integer = {1, 0}
#End Region

#Region "Campos requeridos"
    Private msSS070_codigo As String
    Private msSS050_codigo As String
#End Region

    Public Property ss070_codigo As String
        Get
            Return msSS070_codigo
        End Get
        Set(value As String)
            msSS070_codigo = value
        End Set
    End Property

    Public Property ss050_codigo As String
        Get
            Return msSS050_codigo
        End Get
        Set(value As String)
            msSS050_codigo = value
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
