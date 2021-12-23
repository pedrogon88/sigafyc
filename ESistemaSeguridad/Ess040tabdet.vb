Public Class Ess040tabdet : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss040tabdet"

    Private msRequeridos As String = "ss010_codigo" & sString_ & sSF_ &
                                        "ss030_codigo" & sString_ & sSF_ &
                                        "codigo" & sString_ & sSF_ &
                                        "nombre" & sString_ & sSF_ &
                                        "detalle" & sString_

    Private msCampos_PK() As Integer = {0, 1, 2}
#End Region

#Region "Campos requeridos"
    Private msSS010_codigo As String
    Private msSS030_codigo As String
    Private msCodigo As String
    Private msNombre As String
    Private msDetalle As String
#End Region

    Public Property ss010_codigo As String
        Get
            Return msSS010_codigo
        End Get
        Set(value As String)
            msSS010_codigo = value
        End Set
    End Property

    Public Property ss030_codigo As String
        Get
            Return msSS030_codigo
        End Get
        Set(value As String)
            msSS030_codigo = value
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


    Public Property nombre As String
        Get
            Return msNombre
        End Get
        Set(value As String)
            msNombre = value
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
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Sub CerrarConexion()
        Desconectar(msTableName)
    End Sub

    Public Overloads Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
