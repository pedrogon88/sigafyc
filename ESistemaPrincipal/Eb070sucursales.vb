Public Class Eb070sucursales : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "b070sucursales"

    Private msRequeridos As String = "codempresa" & sInteger_ & sSF_ &
                                       "codsucursal" & sInteger_ & sSF_ &
                                       "nombre" & sString_ & sSF_ &
                                       "abreviado" & sString_ & sSF_ &
                                       "direccion" & sString_ & sSF_ &
                                       "ciudad" & sString_ & sSF_ &
                                       "telefono" & sString_

    Private msCampos_PK() As Integer = {0, 1}
    Private msAutonumerado As String = "codsucursal"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miCodEmpresa As Integer
    Private miCodSucursal As Integer
    Private msNombre As String
    Private msAbreviado As String
    Private msDireccion As String
    Private msCiudad As String
    Private msTelefono As String
#End Region

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
        End Set
    End Property

    Public Property codSucursal As Integer
        Get
            Return miCodSucursal
        End Get
        Set(value As Integer)
            miCodSucursal = value
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

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Function ReservarRegistro(Optional ByVal piCodEmpresa As Integer = 0) As Integer
        codEmpresa = piCodEmpresa
        Dim liNumero As Integer = SiguienteNumero(msAutonumerado, msTableName, msFiltroClave)
        codEmpresa = piCodEmpresa
        codSucursal = liNumero
        nombre = sRESERVADO_
        abreviado = sRESERVADO_
        direccion = sRESERVADO_
        ciudad = sRESERVADO_
        telefono = sRESERVADO_
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
