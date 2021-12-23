Public Class Ezis_procab : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "ZIS_PROCAB"

    Private msRequeridos As String = "numtra" & sInteger_ & sSF_ &
                                       "nombre" & sString_ & sSF_ &
                                       "abreviado" & sString_ & sSF_ &
                                       "formproc" & sString_ & sSF_ &
                                       "tipexec" & sString_ & sSF_ &
                                       "tipact" & sString_ & sSF_ &
                                       "undtmp" & sString_ & sSF_ &
                                       "tiempo" & sInteger_ & sSF_ &
                                       "start" & sString_ & sSF_ &
                                       "ending" & sString_

    Private msCampos_PK() As Integer = {0}
    Private msAutonumerado As String = "numtra"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miNumtra As Integer
    Private msNombre As String
    Private msAbreviado As String
    Private msFormProc As String
    Private msTipExec As String
    Private msTipAct As String
    Private msUndTmp As String
    Private miTiempo As Integer
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

    Public Property formproc As String
        Get
            Return msFormProc
        End Get
        Set(value As String)
            msFormProc = value
        End Set
    End Property

    Public Property tipexec As String
        Get
            Return msTipExec
        End Get
        Set(value As String)
            msTipExec = value
        End Set
    End Property

    Public Property tipact As String
        Get
            Return msTipAct
        End Get
        Set(value As String)
            msTipAct = value
        End Set
    End Property

    Public Property undtmp As String
        Get
            Return msUndTmp
        End Get
        Set(value As String)
            msUndTmp = value
        End Set
    End Property

    Public Property tiempo As Integer
        Get
            Return miTiempo
        End Get
        Set(value As Integer)
            miTiempo = value
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

    Public Function ReservarRegistro() As Integer
        Dim liNumero As Integer = SiguienteNumero(msAutonumerado, msTableName, msFiltroClave)
        numtra = liNumero
        nombre = "nombre numtra [" & liNumero.ToString("000000") & "]"
        abreviado = "abr [" & liNumero.ToString("000000") & "]"
        formproc = sManual_
        tipexec = sZIS_Secuencial_
        tipact = sBulkUpsert_
        undtmp = sZIS_Minuto_
        tiempo = 1
        start = ""
        ending = ""
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
