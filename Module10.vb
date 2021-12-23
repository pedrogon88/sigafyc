Module Module10

    Sub Main()

        Dim lsSQL As String
        Dim ss050 As New Ess050usuarios
        Dim loDataSet As DataSet

        Dim lsCampos As String = "codigo, nombre, login, valido"
        Dim lsFiltro As String = "concat(@filtrocampos) like '%@filtrovalor%'"
        lsFiltro = lsFiltro.Replace("@filtrocampos", "codigo,nombre,login,valido,expira")
        lsFiltro = lsFiltro.Replace("@filtrovalor", "yeicipi")
        lsSQL = ss050.GenerarSQL(lsCampos, lsFiltro)

        loDataSet = ss050.RecuperarTabla(lsSQL)
        Dim loDataTable As DataTable = loDataSet.Tables(ss050.TableName)
        Dim loDataRow As DataRow

        Console.WriteLine("Tabla: " & ss050.TableName & ", Registros: " & loDataTable.Rows.Count)
        Dim loCampos() As String = lsCampos.Split(",")
        Dim liNDX As Integer = 0
        For Each loDataRow In loDataTable.Rows
            Dim lsSalida As String = ""
            For liNDX = 0 To loCampos.Length - 1
                If liNDX = 0 Then
                    lsSalida = loDataRow(loCampos(liNDX).Trim)
                Else
                    lsSalida &= ", " & loDataRow(loCampos(liNDX).Trim)
                End If
            Next
            Console.WriteLine(lsSalida)
        Next
        Console.WriteLine("-----------------------------------------------------------------------------------------------")
        Console.WriteLine("presione <ENTER> para continuar")
        Console.ReadLine()
        ss050.CerrarConexion()
        ss050 = Nothing
    End Sub

End Module
