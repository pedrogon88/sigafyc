Imports System.Data.Common
Module Module5

    Sub Main()

        Dim loFactory As DbProviderFactory
        loFactory = DbProviderFactories.GetFactory("Npgsql")

        Dim loConexion As DbConnection = loFactory.CreateConnection
        loConexion.ConnectionString = "Server=127.0.0.1;Port=5432;Database=sigafyc_ss;uid=postgres;pwd=tekopire864222"

        With loConexion
            Dim lsSQL As String = "SELECT * FROM @tablename" & ControlChars.CrLf &
                                    "WHERE" & ControlChars.CrLf &
                                    "codigo = '@codigo'"

            lsSQL = lsSQL.Replace("@tablename", "ss010sistemas")
            lsSQL = lsSQL.Replace("@codigo", "sigafyc_ss")
            Dim loComando As DbCommand = loFactory.CreateCommand
            loComando.CommandType = CommandType.Text
            loComando.CommandText = lsSQL
            loComando.Connection = loConexion

            Dim loDataAdapter As DbDataAdapter = loFactory.CreateDataAdapter
            loDataAdapter.SelectCommand = loComando

            Dim loCommandBuilder As DbCommandBuilder = loFactory.CreateCommandBuilder
            loCommandBuilder.DataAdapter = loDataAdapter

            loDataAdapter.InsertCommand = loCommandBuilder.GetInsertCommand
            loDataAdapter.UpdateCommand = loCommandBuilder.GetUpdateCommand
            loDataAdapter.DeleteCommand = loCommandBuilder.GetDeleteCommand

            Console.WriteLine("Select Command: {0}", loDataAdapter.SelectCommand.CommandText)
            Console.WriteLine("Insert Command: {0}", loDataAdapter.InsertCommand.CommandText)
            Console.WriteLine("Update Command: {0}", loDataAdapter.UpdateCommand.CommandText)
            Console.WriteLine("Delete Command: {0}", loDataAdapter.DeleteCommand.CommandText)

            Console.WriteLine("-----------------------------------------------------------------------------")
            Console.WriteLine("presione <ENTER> para continuar")
            Console.ReadLine()

            Dim loDataTable As New DataTable
            loDataAdapter.Fill(loDataTable)

            Dim loNewDataRow As DataRow = loDataTable.NewRow
            loNewDataRow.Item("codigo") = "stock"
            loNewDataRow.Item("nombre") = "Sistema de Control de Stock"
            loNewDataRow.Item("estado") = "Activo"
            loNewDataRow.Item("hashid") = "45622B6EF8ACF72596B130CBA8402454B3FB10E36E15AF85C5561A8045F54041"
            loDataTable.Rows.Add(loNewDataRow)
            loDataAdapter.Update(loDataTable)
        End With



    End Sub

End Module
