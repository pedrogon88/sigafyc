Imports System.Data.Common

Module Module1
    Sub Main()
        Dim table As DataTable = DbProviderFactories.GetFactoryClasses()
        ' Display each row and column value.
        Dim row As DataRow
        Dim column As DataColumn
        For Each row In table.Rows
            For Each column In table.Columns
                Console.WriteLine(row(column))
            Next
        Next
        Console.WriteLine("--------------------------------------------------")
        Console.WriteLine("presione <ENTER> para continuar")
        Console.ReadLine()

        Dim connection As DbConnection = Nothing

        ' Create the DbProviderFactory and DbConnection.
        Try
            Dim lsProveedor As String = "MySql.Data.MySqlClient"
            'Dim lsProveedor As String = "Npgsql"
            'Dim lsProveedor As String = "System.Data.SqlClient"

            Dim factory As DbProviderFactory = DbProviderFactories.GetFactory(lsProveedor)

            connection = factory.CreateConnection()

            connection.ConnectionString = "Server=127.0.0.1;Port=3306;Database=sigafyc_ss;uid=root;pwd=Hig0c0t3#19650518"
            'connection.ConnectionString = "Server=127.0.0.1;Port=5432;Database=sigafyc_ss;uid=postgres;pwd=tekopire864222"
            'connection.ConnectionString = "Server=(local);Database=sigafyc_ss;uid=sa;pwd=tekopire864222"

            connection.Open()
            Console.WriteLine("Conexion con {0} exitosa!!", lsProveedor)

        Catch ex As Exception
            ' Set the connection to Nothing if it was created.
            If Not connection Is Nothing Then
                connection = Nothing
            End If
            Console.WriteLine(ex.Message)
        End Try
        Console.WriteLine("--------------------------------------------------")
        Console.WriteLine("presione <ENTER> para continuar")
        Console.ReadLine()

        Dim loEncriptacion As New Encriptacion()

        Console.WriteLine("Ingrese una palabra:")

        Dim lsPalabra As String
        lsPalabra = Console.ReadLine()
        Console.WriteLine("La palabra ingresa fue [{0}]", lsPalabra)

        Dim lsEncriptado As String
        lsEncriptado = loEncriptacion.Encriptar(lsPalabra)
        Console.WriteLine("La palabra encriptada es [{0}]", lsEncriptado)

        Dim lsDesEncriptado As String
        lsDesEncriptado = loEncriptacion.DesEncriptar(lsEncriptado)
        Console.WriteLine("La palabra descriptada [{0}]", lsDesEncriptado)

        Console.WriteLine("--------------------------------------------------")
        Console.WriteLine("presione <ENTER> para continuar")
        Console.ReadLine()
    End Sub
End Module
