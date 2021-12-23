Public Class Ess020modulos : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss020modulos"

    Private msRequeridos As String = "ss010_codigo" & sString_ & sSF_ &
                                        "codigo" & sString_ & sSF_ &
                                        "nombre" & sString_ & sSF_ &
                                        "descripcion" & sString_

    Private msCampos_PK() As Integer = {0, 1}
#End Region

#Region "Campos requeridos"
    Private msSS010_codigo As String
    Private msCodigo As String
    Private msNombre As String
    Private msDescripcion As String
#End Region

    Public Property ss010_codigo As String
        Get
            Return msSS010_codigo
        End Get
        Set(value As String)
            msSS010_codigo = value
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

    Public Property descripcion As String
        Get
            Return msDescripcion
        End Get
        Set(value As String)
            msDescripcion = value
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
