Imports System.Data.Common

Module Module3

    Sub Main()
        Dim lsTableName As String = "ss010sistemas"
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
        loCommand.Connection = loConnection
        loCommand.CommandType = CommandType.Text
        loCommand.CommandText = "SELECT * FROM " & lsTableName

        Try
            loConnection.Open()
            Dim loDataAdapter As DbDataAdapter
            loDataAdapter = loFactory.CreateDataAdapter()
            loDataAdapter.SelectCommand = loCommand

            Dim loDataSet As New DataSet
            loDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
            loDataAdapter.Fill(loDataSet, lsTableName)
            loConnection.Close()

            Dim loDataRow As DataRow
            Dim loColumn As DataColumn

            loDataRow = loDataSet.Tables(lsTableName).Rows.Item(0)
            For Each loColumn In loDataRow.Table.Columns
                If loColumn.ColumnName <> "hashid" Then
                    Console.WriteLine(loColumn.Ordinal & " " & loColumn.ColumnName & " = " & loDataRow(loColumn.ToString).ToString)
                End If
            Next
            Console.WriteLine("------------------------------------------------------------------------")

            'For Each loDataRow In loDataSet.Tables(lsTableName).Rows
            '    For Each loColumn In loDataRow.Table.Columns
            '        If loColumn.ColumnName <> "hashid" Then
            '            Console.WriteLine(loColumn.Ordinal & " " & loColumn.ColumnName & " = " & loDataRow(loColumn.ToString).ToString)
            '        End If
            '    Next
            '    Console.WriteLine("------------------------------------------------------------------------")
            'Next
            Dim loDataTable As DataTable = loDataSet.Tables.Item(lsTableName)
            Call LPObtienePrimaryKey(loDataTable)

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Console.WriteLine("------------------------------------------------------------------------")
        Console.WriteLine("{0} / presione <ENTER> para continuar", loFactory.GetType.ToString)
        Console.ReadLine()

    End Sub

    Private Sub LPObtienePrimaryKey(ByVal poDataTable As DataTable)
        Dim loColumns() As DataColumn
        loColumns = poDataTable.PrimaryKey

        Console.WriteLine("Componentes PrimaryKey")
        Console.WriteLine("------------------------------------------------------------------------")
        Dim liNDX As Integer
        For liNDX = 0 To loColumns.Length - 1
            Console.WriteLine(loColumns(liNDX).Ordinal.ToString & " -> " & loColumns(liNDX).ColumnName & "(" & loColumns(liNDX).DataType.ToString & ") = " & poDataTable.Rows(0).Item(loColumns(liNDX).ColumnName))
        Next
    End Sub

End Module
