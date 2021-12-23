Public Class Ezis_moddet : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "ZIS_MODDET"

    Private msRequeridos As String = "numtra" & sInteger_ & sSF_ &
                                       "numord" & sInteger_ & sSF_ &
                                       "origen" & sString_ & sSF_ &
                                       "destino" & sString_

    Private msCampos_PK() As Integer = {0, 1}
    Private msAutonumerado As String = "numord"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miNumtra As Integer
    Private miNumOrd As Integer
    Private msOrigen As String
    Private msDestino As String

#End Region

    Public Property numtra As Integer
        Get
            Return miNumtra
        End Get
        Set(value As Integer)
            miNumtra = value
        End Set
    End Property

    Public Property numord As Integer
        Get
            Return miNumOrd
        End Get
        Set(value As Integer)
            miNumOrd = value
        End Set
    End Property

    Public Property origen As String
        Get
            Return msOrigen
        End Get
        Set(value As String)
            msOrigen = value
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

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Function ReservarRegistro(ByVal piNumTra As Integer) As Integer
        numtra = piNumTra
        Dim liNumero As Integer = SiguienteNumero(msAutonumerado, msTableName, msFiltroClave)
        numord = liNumero
        origen = "origen_" & liNumero.ToString("000000")
        destino = "destino_" & liNumero.ToString("000000")
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
