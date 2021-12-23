Public Class Ess140bitsescab : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss140bitsescab"

    Private msRequeridos As String = "codigo" & sString_ & sSF_ &
                                        "fechahora" & sString_ & sSF_ &
                                        "ss010_codigo" & sString_ & sSF_ &
                                        "ss050_codigo" & sString_ & sSF_ &
                                        "ss060_codigo" & sString_ & sSF_ &
                                        "login" & sString_ & sSF_ &
                                        "mac" & sString_ & sSF_ &
                                        "ip" & sString_ & sSF_ &
                                        "dbms" & sString_ & sSF_ &
                                        "server" & sString_ & sSF_ &
                                        "operacion" & sString_

    Private miCampos_PK() As Integer = {0, 1}
#End Region

#Region "Campos requeridos"
    Private msCodigo As String
    Private msFechaHora As String
    Private msSS010_codigo As String
    Private msSS050_codigo As String
    Private msSS060_codigo As String
    Private msLogin As String
    Private msMac As String
    Private msIp As String
    Private msOperacion As String
#End Region

    Public Property codigo As String
        Get
            Return msCodigo
        End Get
        Set(value As String)
            msCodigo = value
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

    Public Property ss010_codigo As String
        Get
            Return msSS010_codigo
        End Get
        Set(value As String)
            msSS010_codigo = value
        End Set
    End Property

    Public Property ss050_codigo As String
        Get
            Return msSS050_codigo
        End Get
        Set(value As String)
            msSS050_codigo = value '.Substring(0, 15)
        End Set
    End Property

    Public Property ss060_codigo As String
        Get
            Return msSS060_codigo
        End Get
        Set(value As String)
            msSS060_codigo = value
        End Set
    End Property

    Public Property login As String
        Get
            Return msLogin
        End Get
        Set(value As String)
            msLogin = value
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

    Public Property ip As String
        Get
            Return msIp
        End Get
        Set(value As String)
            msIp = value
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
