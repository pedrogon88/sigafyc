Public Class BitacoraRegistrar : Inherits Exception

    Private moAntesRow As DataTable
    Private moDespuesRow As DataTable
    Private msAccion As String
    Private moParametroConexion As ParametrosConexion

    Public ReadOnly Property antes As DataTable
        Get
            Return moAntesRow
        End Get
    End Property

    Public ReadOnly Property despues As DataTable
        Get
            Return moDespuesRow
        End Get
    End Property

    Public ReadOnly Property accion As String
        Get
            Return msAccion
        End Get

    End Property

    Public ReadOnly Property parametroConexion As ParametrosConexion
        Get
            Return moParametroConexion
        End Get
    End Property

    Public Sub New(ByVal psAccion As String, ByVal poDespuesRow As DataTable, Optional ByVal poAntesRow As DataTable = Nothing, Optional ByVal poParametroConexion As ParametrosConexion = Nothing)
        MyBase.New()
        moAntesRow = poAntesRow
        moDespuesRow = poDespuesRow
        msAccion = psAccion
        moParametroConexion = poParametroConexion
    End Sub

End Class
