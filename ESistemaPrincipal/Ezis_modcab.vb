Public Class Ezis_modcab : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "ZIS_MODCAB"

    Private msRequeridos As String = "numtra" & sInteger_ & sSF_ &
                                       "nombre" & sString_ & sSF_ &
                                       "abreviado" & sString_ & sSF_ &
                                       "sentido" & sString_ & sSF_ &
                                       "script" & sString_ & sSF_ &
                                       "tipodato" & sString_ & sSF_ &
                                       "destino" & sString_ & sSF_ &
                                       "findby" & sString_ & sSF_ &
                                       "campopk" & sString_

    Private msCampos_PK() As Integer = {0}
    Private msAutonumerado As String = "numtra"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miNumtra As Integer
    Private msNombre As String
    Private msAbreviado As String
    Private msSentido As String
    Private msScript As String
    Private msTipoDato As String
    Private msDestino As String
    Private msFindBy As String
    Private msCampoPK As String

#End Region

    Public Property numtra As Integer
        Get
            Return miNumtra
        End Get
        Set(value As Integer)
            miNumtra = value
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

    Public Property sentido As String
        Get
            Return msSentido
        End Get
        Set(value As String)
            msSentido = value
        End Set
    End Property

    Public Property script As String
        Get
            Return msScript
        End Get
        Set(value As String)
            msScript = value
        End Set
    End Property

    Public Property tipodato As String
        Get
            Return msTipoDato
        End Get
        Set(value As String)
            msTipoDato = value
        End Set
    End Property

    Public Property destino As String
        Get
            Return msDestino
        End Get
        Set(value As String)
            msDestino = value
        End Set
    End Property

    Public Property findby As String
        Get
            Return msFindBy
        End Get
        Set(value As String)
            msFindBy = value
        End Set
    End Property

    Public Property campopk As String
        Get
            Return msCampoPK
        End Get
        Set(value As String)
            msCampoPK = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Function ReservarRegistro() As Integer
        Dim liNumero As Integer = SiguienteNumero(msAutonumerado, msTableName, msFiltroClave)
        numtra = liNumero
        nombre = "nombre numtra [" & liNumero.ToString("000000") & "]"
        abreviado = "abr [" & liNumero.ToString("000000") & "]"
        sentido = sZIS_sapZOHO_
        script = "script_" & liNumero.ToString("000000")
        destino = "destino_" & liNumero.ToString("000000")
        findby = sNo_
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
