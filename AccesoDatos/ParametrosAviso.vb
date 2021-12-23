Public Class ParametrosAviso
    Private moParametroConexion As ParametrosConexion
    Private msTitulo As String
    Private msCodigoError As String
    Private msMensajeError As String

    Public Property parametroConexion As ParametrosConexion
        Get
            Return moParametroConexion
        End Get
        Set(value As ParametrosConexion)
            moParametroConexion = value
        End Set
    End Property

    Public Property titulo As String
        Get
            Return msTitulo
        End Get
        Set(value As String)
            msTitulo = value
        End Set
    End Property

    Public Property codigoError As String
        Get
            Return msCodigoError
        End Get
        Set(value As String)
            msCodigoError = value
        End Set
    End Property

    Public Property mensajeError As String
        Get
            Return msMensajeError
        End Get
        Set(value As String)
            msMensajeError = value
        End Set
    End Property

    Public Sub New()
        moParametroConexion = Nothing
        msTitulo = ""
        msCodigoError = ""
        msMensajeError = ""
    End Sub
End Class
