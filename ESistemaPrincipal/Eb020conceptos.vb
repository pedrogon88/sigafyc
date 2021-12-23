Public Class Eb020conceptos : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "b020conceptos"

    Private msRequeridos As String = "codempresa" & sInteger_ & sSF_ &
                                       "codconcepto" & sInteger_ & sSF_ &
                                       "tipo" & sString_ & sSF_ &
                                       "descripcion" & sString_

    Private msCampos_PK() As Integer = {0, 1}
    Private msAutonumerado As String = "codconcepto"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miCodEmpresa As Integer
    Private miCodConcepto As Integer
    Private msTipo As String
    Private msDescripcion As String
#End Region

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
        End Set
    End Property

    Public Property codConcepto As Integer
        Get
            Return miCodConcepto
        End Get
        Set(value As Integer)
            miCodConcepto = value
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

    Public Function ReservarRegistro(Optional ByVal piCodEmpresa As Integer = 0) As Integer
        codEmpresa = piCodEmpresa
        Dim liNumero As Integer = SiguienteNumero(msAutonumerado, msTableName, msFiltroClave)
        codEmpresa = piCodEmpresa
        codConcepto = liNumero
        tipo = sRESERVADO_
        descripcion = sRESERVADO_
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
