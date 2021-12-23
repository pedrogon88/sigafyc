Public Class Ess150bitsesdet : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss150bitsesdet"

    Private msRequeridos As String = "ss140_codigo" & sString_ & sSF_ &
                                        "fechahora" & sString_ & sSF_ &
                                        "operacion" & sString_ & sSF_ &
                                        "detalle" & sString_

    Private miCampos_PK() As Integer = {0, 1}
#End Region

#Region "Campos requeridos"
    Private msSS140_codigo As String
    Private msFechaHora As String
    Private msOperacion As String
    Private msDetalle As String
#End Region

    Public Property ss140_codigo As String
        Get
            Return msSS140_codigo
        End Get
        Set(value As String)
            msSS140_codigo = value
        End Set
    End Property

    Public Property fechaHora As String
        Get
            Return msFechaHora
        End Get
        Set(value As String)
            msFechaHora = value
        End Set
    End Property

    Public Property operacion As String
        Get
            Return msOperacion
        End Get
        Set(value As String)
            msOperacion = value
        End Set
    End Property

    Public Property detalle As String
        Get
            Return msDetalle
        End Get
        Set(value As String)
            msDetalle = value
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
