Public Class Ezis_prodet : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "ZIS_PRODET"

    Private msRequeridos As String = "numtra" & sInteger_ & sSF_ &
                                       "numord" & sInteger_ & sSF_ &
                                       "nummod" & sInteger_ & sSF_ &
                                       "formact" & sString_ & sSF_ &
                                       "start" & sString_ & sSF_ &
                                       "ending" & sString_

    Private msCampos_PK() As Integer = {0, 1}
    Private msAutonumerado As String = "numord"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miNumtra As Integer
    Private miNumOrd As Integer
    Private miNumMod As Integer
    Private msFormAct As String
    Private msStart As String
    Private msEnding As String

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

    Public Property nummod As Integer
        Get
            Return miNumMod
        End Get
        Set(value As Integer)
            miNumMod = value
        End Set
    End Property

    Public Property formact As String
        Get
            Return msFormAct
        End Get
        Set(value As String)
            msFormAct = value
        End Set
    End Property

    Public Property start As String
        Get
            Return msStart
        End Get
        Set(value As String)
            msStart = value
        End Set
    End Property

    Public Property ending As String
        Get
            Return msEnding
        End Get
        Set(value As String)
            msEnding = value
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
        nummod = -1
        formact = sBulk_
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
