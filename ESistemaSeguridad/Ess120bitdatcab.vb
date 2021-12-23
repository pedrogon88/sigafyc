Public Class Ess120bitdatcab : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss120bitdatcab"

    Private msRequeridos As String = "tabla" & sString_ & sSF_ &
                                        "pk_hash" & sString_ & sSF_ &
                                        "fechahora" & sString_ & sSF_ &
                                        "ss050_codigo" & sString_ & sSF_ &
                                        "ss010_codigo" & sString_ & sSF_ &
                                        "ss060_codigo" & sString_ & sSF_ &
                                        "loginacceso" & sString_ & sSF_ &
                                        "mac" & sString_ & sSF_ &
                                        "ip" & sString_ & sSF_ &
                                        "dbms" & sString_ & sSF_ &
                                        "server" & sString_ & sSF_ &
                                        "operacion" & sString_

    Private miCampos_PK() As Integer = {0, 1, 2}
#End Region

#Region "Campos requeridos"
    Private msTabla As String
    Private msPk_hash As String
    Private msFechaHora As String
    Private msSS050_codigo As String
    Private msSS010_codigo As String
    Private msSS060_codigo As String
    Private msLoginAcceso As String
    Private msMac As String
    Private msIp As String
    Private msOperacion As String
#End Region

    Public Property tabla As String
        Get
            Return msTabla
        End Get
        Set(value As String)
            msTabla = value
        End Set
    End Property

    Public Property pk_hash As String
        Get
            Return msPk_hash
        End Get
        Set(value As String)
            msPk_hash = value
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

    Public Property ss050_codigo As String
        Get
            Return msSS050_codigo
        End Get
        Set(value As String)
            msSS050_codigo = value
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

    Public Property ss060_codigo As String
        Get
            Return msSS060_codigo
        End Get
        Set(value As String)
            msSS060_codigo = value
        End Set
    End Property

    Public Property loginAcceso As String
        Get
            Return msLoginAcceso
        End Get
        Set(value As String)
            msLoginAcceso = value
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

    Public Property operacion As String
        Get
            Return msOperacion
        End Get
        Set(value As String)
            msOperacion = value
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
