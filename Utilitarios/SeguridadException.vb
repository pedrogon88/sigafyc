
Public Class SeguridadException : Inherits Exception
    ''' <summary>
    ''' Construye una instancia en base a un mensaje de error.
    ''' </summary>
    ''' <param name="mensaje">El mensaje de error.</param>
    Public Sub New(ByVal mensaje As String)
        MyBase.New(mensaje)
        Console.WriteLine("Violacion Seguridad: {0}", mensaje)
    End Sub

End Class
