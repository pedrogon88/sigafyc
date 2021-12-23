Imports System.Net
Imports System.Data.Common

Module Module2

    Sub Main()
        Dim ip As String = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(Function(a As IPAddress) Not a.IsIPv6LinkLocal AndAlso Not a.IsIPv6Multicast AndAlso Not a.IsIPv6SiteLocal).First().ToString()
        Console.WriteLine("ip: " & ip)
        Console.WriteLine("----------------------------------------------------------------------------")
        Console.WriteLine("presione <ENTER> para continuar")
        Console.ReadLine()

        Dim loConnection As DbConnection

        'Dim loFactory As DbProviderFactory = DbProviderFactories.GetFactory("Npgsql")
        'Dim loFactory As DbProviderFactory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient")
        Dim loFactory As DbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient")

        loConnection = loFactory.CreateConnection

        'loConnection.ConnectionString = "Server=127.0.0.1;Port=5432;Database=sigafyc_ss;uid=postgres;pwd=tekopire864222;"
        'loConnection.ConnectionString = "Server=127.0.0.1;Port=3306;Database=sigafyc_ss;uid=root;pwd=tekopire864222;"
        loConnection.ConnectionString = "Server=DESKTOP-E6NKCDT\SQLEXPRESS;Database=sigafyc_ss;uid=sa;pwd=tekopire864222;"

        Dim loCommand As DbCommand
        loCommand = loFactory.CreateCommand
        loCommand.CommandType = CommandType.Text
        loCommand.CommandText = "SELECT * FROM ss010sistemas"
        loCommand.Connection = loConnection

        Try
            loConnection.Open()
            Dim loDataReader As DbDataReader = loCommand.ExecuteReader()
            loDataReader.Read()

            Dim loDataTable As DataTable = loDataReader.GetSchemaTable
            Dim loDataRow As DataRow
            For Each loDataRow In loDataTable.Rows
                Dim loDataColumn As DataColumn
                For Each loDataColumn In loDataTable.Columns
                    If loDataColumn.ColumnName = "ColumnName" Then
                        Console.WriteLine("{0} = {1}", loDataRow(loDataColumn).ToString, loDataReader(loDataRow(loDataColumn).ToString))
                    End If
                    ' Console.WriteLine(loDataColumn.ColumnName & " = " & loDataRow(loDataColumn).ToString)
                Next
                Console.WriteLine("----------------------------------------------------------------------------")
            Next
            loDataReader.Close()
        Catch ex As DbException
            Console.WriteLine("Error:   {0}", ex.Message)
        End Try
        Console.WriteLine("presione <ENTER> para continuar")
        Console.ReadLine()
        loConnection.Close()
    End Sub

End Module
