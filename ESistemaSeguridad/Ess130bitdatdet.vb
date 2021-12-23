Public Class Ess130bitdatdet : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss130bitdatdet"

    Private msRequeridos As String = "ss120_codigo" & sString_ & sSF_ &
                                        "orden" & sString_ & sSF_ &
                                        "campo" & sString_ & sSF_ &
                                        "antes" & sString_ & sSF_ &
                                        "despues" & sString_

    Private miCampos_PK() As Integer = {0, 1, 2}
#End Region

#Region "Campos requeridos"
    Private msSS120_codigo As String
    Private miOrden As Integer
    Private msCampo As String
    Private msAntes As String
    Private msDespues As String
#End Region

    Public Property ss120_codigo As String
        Get
            Return msSS120_codigo
        End Get
        Set(value As String)
            msSS120_codigo = value
        End Set
    End Property

    Public Property orden As Integer
        Get
            Return miOrden
        End Get
        Set(value As Integer)
            miOrden = value
        End Set
    End Property

    Public Property campo As String
        Get
            Return msCampo
        End Get
        Set(value As String)
            msCampo = value
        End Set
    End Property

    Public Property antes As String
        Get
            Return msAntes
        End Get
        Set(value As String)
            msAntes = value
        End Set
    End Property

    Public Property despues As String
        Get
            Return msDespues
        End Get
        Set(value As String)
            msDespues = value
        End Set
    End Property

    Public Sub New()
        MyBase.New
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
