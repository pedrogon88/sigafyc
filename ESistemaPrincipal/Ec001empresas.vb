Public Class Ec001empresas : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "c001empresas"

    Private msRequeridos As String = "codempresa" & sInteger_ & sSF_ &
                                       "nombre" & sString_ & sSF_ &
                                       "abreviado" & sString_ & sSF_ &
                                       "codmoneda" & sString_ & sSF_ &
                                       "ruc" & sString_ & sSF_ &
                                       "direccion" & sString_ & sSF_ &
                                       "ciudad" & sString_ & sSF_ &
                                       "telefono" & sString_ & sSF_ &
                                       "ctaresultado1" & sString_ & sSF_ &
                                       "ctaresultado2" & sString_ & sSF_ &
                                       "ctaresultado3" & sString_ & sSF_ &
                                       "periodoinicio" & sString_ & sSF_ &
                                       "periodofinal" & sString_

    Private msCampos_PK() As Integer = {0}
    Private msAutonumerado As String = "codempresa"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miCodEmpresa As Integer
    Private msNombre As String
    Private msAbreviado As String
    Private msCodMoneda As String
    Private msRuc As String
    Private msDireccion As String
    Private msCiudad As String
    Private msTelefono As String
    Private msCtaResultado1 As String
    Private msCtaResultado2 As String
    Private msCtaResultado3 As String
    Private msPeriodoInicio As String
    Private msPeriodoFinal As String
#End Region

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
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

    Public Property abreviado As String
        Get
            Return msAbreviado
        End Get
        Set(value As String)
            msAbreviado = value
        End Set
    End Property

    Public Property codMoneda As String
        Get
            Return msCodMoneda
        End Get
        Set(value As String)
            msCodMoneda = value
        End Set
    End Property

    Public Property ruc As String
        Get
            Return msRuc
        End Get
        Set(value As String)
            msRuc = value
        End Set
    End Property

    Public Property direccion As String
        Get
            Return msDireccion
        End Get
        Set(value As String)
            msDireccion = value
        End Set
    End Property

    Public Property ciudad As String
        Get
            Return msCiudad
        End Get
        Set(value As String)
            msCiudad = value
        End Set
    End Property

    Public Property telefono As String
        Get
            Return msTelefono
        End Get
        Set(value As String)
            msTelefono = value
        End Set
    End Property

    Public Property ctaResultado1 As String
        Get
            Return msCtaResultado1
        End Get
        Set(value As String)
            msCtaResultado1 = value
        End Set
    End Property

    Public Property ctaResultado2 As String
        Get
            Return msCtaResultado2
        End Get
        Set(value As String)
            msCtaResultado2 = value
        End Set
    End Property

    Public Property ctaResultado3 As String
        Get
            Return msCtaResultado3
        End Get
        Set(value As String)
            msCtaResultado3 = value
        End Set
    End Property

    Public Property periodoInicio As String
        Get
            Return msPeriodoInicio
        End Get
        Set(value As String)
            msPeriodoInicio = value
        End Set
    End Property

    Public Property periodoFinal As String
        Get
            Return msPeriodoFinal
        End Get
        Set(value As String)
            msPeriodoFinal = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Function ReservarRegistro() As Integer
        Dim liNumero As Integer = SiguienteNumero(msAutonumerado, msTableName, msFiltroClave)
        codEmpresa = liNumero
        nombre = sRESERVADO_
        abreviado = sRESERVADO_
        codMoneda = sCero3_
        ruc = sRESERVADO_
        direccion = sRESERVADO_
        ciudad = sRESERVADO_
        telefono = sRESERVADO_
        ctaResultado1 = sRESERVADO_
        ctaResultado2 = sRESERVADO_
        ctaResultado3 = sRESERVADO_
        periodoInicio = sCero6_ & sCero4_
        periodoFinal = sCero6_ & sCero4_
        Add(sNo_, sNo_)
        Return liNumero
    End Function

    Public Sub CerrarConexion()
        Desconectar(msTableName)
    End Sub

    Protected Overloads Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class
