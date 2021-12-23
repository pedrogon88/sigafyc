Public Class EBaseEventArgs : Inherits EventArgs

    Private msTitulo As String
    Private msMensaje As String
    Private msAccionRealizada As String

    Public Property titulo As String
        Get
            Return msTitulo
        End Get
        Set(value As String)
            msTitulo = value
        End Set
    End Property

    Public Property mensaje As String
        Get
            Return msMensaje
        End Get
        Set(value As String)
            msMensaje = value
        End Set
    End Property

    Public Property accionRealizada As String
        Get
            Return msAccionRealizada
        End Get
        Set(value As String)
            msAccionRealizada = value
        End Set
    End Property

End Class
