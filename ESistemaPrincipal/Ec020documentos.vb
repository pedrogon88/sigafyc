Public Class Ec020documentos : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "c020documentos"

    Private msRequeridos As String = "codempresa" & sInteger_ & sSF_ &
                                       "coddocumento" & sInteger_ & sSF_ &
                                       "tipo" & sString_ & sSF_ &
                                       "abreviado" & sString_ & sSF_ &
                                       "nombre" & sString_ & sSF_ &
                                       "timbrado" & sString_ & sSF_ &
                                       "codmoneda" & sString_ & sSF_ &
                                       "cotizacion" & sString_ & sSF_ &
                                       "lineas" & sInteger_

    Private msCampos_PK() As Integer = {0, 1}
    Private msAutonumerado As String = "coddocumento"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miCodEmpresa As Integer
    Private miCodDocumento As Integer
    Private msTipo As String
    Private msAbreviado As String
    Private msNombre As String
    Private msTimbrado As String
    Private msCodMoneda As String
    Private msCotizacion As String
    Private miLineas As Integer
#End Region

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
        End Set
    End Property

    Public Property codDocumento As Integer
        Get
            Return miCodDocumento
        End Get
        Set(value As Integer)
            miCodDocumento = value
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

    Public Property abreviado As String
        Get
            Return msAbreviado
        End Get
        Set(value As String)
            msAbreviado = value
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

    Public Property timbrado As String
        Get
            Return msTimbrado
        End Get
        Set(value As String)
            msTimbrado = value
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

    Public Property cotizacion As String
        Get
            Return msCotizacion
        End Get
        Set(value As String)
            msCotizacion = value
        End Set
    End Property

    Public Property lineas As Integer
        Get
            Return miLineas
        End Get
        Set(value As Integer)
            miLineas = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Function ReservarRegistro(Optional ByVal piCodEmpresa As Integer = 0) As Integer
        codEmpresa = piCodEmpresa
        Dim liNumero As Integer = SiguienteNumero(msAutonumerado, msTableName, msFiltroClave)
        codEmpresa = piCodEmpresa
        codDocumento = liNumero
        tipo = sRESERVADO_
        abreviado = sRESERVADO_
        nombre = sRESERVADO_
        timbrado = sCero2_
        codMoneda = sCero3_
        cotizacion = sCero6_
        lineas = 0
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
