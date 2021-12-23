Public Class ParametrosConexion
    Private msDbms As String
    Private msServer As String
    Private msPort As String
    Private msDatabase As String
    Private msUser As String
    Private msPassword As String

    Public Property dbms As String
        Get
            Return msDbms
        End Get
        Set(value As String)
            msDbms = value
        End Set
    End Property

    Public Property server As String
        Get
            Return msServer
        End Get
        Set(value As String)
            msServer = value
        End Set
    End Property

    Public Property port As String
        Get
            Return msPort
        End Get
        Set(value As String)
            msPort = value
        End Set
    End Property

    Public Property database As String
        Get
            Return msDatabase
        End Get
        Set(value As String)
            msDatabase = value
        End Set
    End Property

    Public Property user As String
        Get
            Return msUser
        End Get
        Set(value As String)
            msUser = value
        End Set
    End Property

    Public Property password As String
        Get
            Return msPassword
        End Get
        Set(value As String)
            msPassword = value
        End Set
    End Property

    Public ReadOnly Property claveDbms As String
        Get
            Return "Dbms_"
        End Get
    End Property

    Public ReadOnly Property claveServer As String
        Get
            Return "Server_"
        End Get
    End Property

    Public ReadOnly Property clavePort As String
        Get
            Return "Port_"
        End Get
    End Property

    Public ReadOnly Property claveDatabase As String
        Get
            Return "Database_"
        End Get
    End Property

    Public ReadOnly Property claveUser As String
        Get
            Return "User_"
        End Get
    End Property

    Public ReadOnly Property clavePassword As String
        Get
            Return "Password_"
        End Get
    End Property

    Public Sub New()
        msDbms = ""
        msServer = ""
        msPort = ""
        msDatabase = ""
        msUser = ""
        msPassword = ""
    End Sub
End Class
