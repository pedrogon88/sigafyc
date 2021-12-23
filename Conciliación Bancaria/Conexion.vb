Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Module Conexion
    Public cn As SqlConnection
    Public cmd As SqlCommand
    Private dr As SqlDataReader

    Function Conectar() As String
        Try
            cn = New SqlConnection("Data Source=192.168.10.49;Initial Catalog=SDKTimbo;Integrated Security=False;Persist Security Info=True;User ID=sa;Password=sa2019*;Connect Timeout=0")
            cn.Open()
            'MessageBox.Show("Conectado")
        Catch ex As Exception
            MessageBox.Show("No se conecto con la base de datos: " & ex.ToString())
        End Try
    End Function


    Public Function insertarExtracto(ByVal item As Integer, ByVal cuentabancosap As String, ByVal fechamovimiento As String, ByVal descripcion As String, ByVal nromovimi As String, ByVal importe As Double) As String
        Dim salida As String = "Se inserto"
        Dim fecharegistro As Date = Now
        Dim existeExtracto As Integer = 0
        Dim credito As Double = 0
        Dim debito As Double = 0
        Dim banco As Object
        Dim nombrebanco As String = ""
        Conectar()
        Try

            cmd = New SqlCommand("select nombrebanco FROM SDKTimbo.dbo.RB_BANCOS WHERE cuentabancosap = '" & cuentabancosap & "'", cn)
            banco = cmd.ExecuteScalar()
            nombrebanco = Convert.ToString(banco)
        Catch ex As Exception
            salida = "No se conecto: " & ex.ToString()
            cn.Close()
        End Try

        If importe > 0 Then
            credito = importe
            debito = 0
        Else
            credito = 0
            debito = Convert.ToDouble(importe) * -1
        End If
        'existeExtracto = ExtractoRegistrado(cuentabancosap, nromovimi, debito, credito)
        If existeExtracto > 0 Then
            salida = "Ya existe"
        Else
            Try
                'cmd = New SqlCommand("Insert into RB_EXTRACTO(fecharegistro, cuentabancosap, banco, fechamovimiento, descripcion, nromovimiento, debito, credito) 
                '                     values('" & fecharegistro & "','" & cuentabancosap & "', '" & nombrebanco & "','" & fechamovimiento & "','" & descripcion & "','" & nromovimi & "'," & Convert.ToDecimal(debito) & "," & credito & ")", cn)
                cmd = New SqlCommand("INSERT INTO RB_EXTRACTO(item, fecharegistro, cuentabancosap, banco, fechamovimiento, descripcion, nromovimiento, debito, credito)
                                                        VALUES (@item, @fecharegistro, @cuentabancosap, @nombrebanco, @fechamovimiento, @descripcion, @nromovimi, @debito, @credito)", cn)
                cmd.Parameters.Add(New SqlParameter("@item", item))
                cmd.Parameters.Add(New SqlParameter("@fecharegistro", fecharegistro))
                cmd.Parameters.Add(New SqlParameter("@cuentabancosap", cuentabancosap))
                cmd.Parameters.Add(New SqlParameter("@nombrebanco", nombrebanco))
                cmd.Parameters.Add(New SqlParameter("@fechamovimiento", fechamovimiento))
                cmd.Parameters.Add(New SqlParameter("@descripcion", descripcion))
                cmd.Parameters.Add(New SqlParameter("@nromovimi", nromovimi))
                cmd.Parameters.Add(New SqlParameter("@debito", Convert.ToDecimal(debito)))
                cmd.Parameters.Add(New SqlParameter("@credito", Convert.ToDecimal(credito)))

                cmd.ExecuteNonQuery()
            Catch ex As Exception
                salida = "No se conecto: " & ex.ToString()
                cn.Close()
            End Try
        End If
        cn.Close()
        Return salida
    End Function

    Public Function insertarMayorSAP(ByVal item As Integer, ByVal cuentabancosap As String, ByVal fechacontalizacion As String, ByVal nrodocumento As String, ByVal nrotransaccion As String, ByVal comentarios As String, ByVal importe As Double, ByVal referencia1 As String, ByVal referencia2 As String, ByVal referencia3 As String) As String
        Dim salida As String = "Se inserto"
        Dim fecharegistro As Date = Now
        Dim existeMayor As Integer = 0
        Dim cargo As Double = 0
        Dim abono As Double = 0
        Dim banco As Object
        Conectar()
        If importe > 0 Then
            cargo = importe
            abono = 0
        Else
            cargo = 0
            abono = importe * -1
        End If
        Dim nombrebanco As String = ""
        Try

            cmd = New SqlCommand("select nombrebanco FROM SDKTimbo.dbo.RB_BANCOS WHERE cuentabancosap = '" & cuentabancosap & "'", cn)
            banco = cmd.ExecuteScalar()
            nombrebanco = Convert.ToString(banco)
        Catch ex As Exception
            salida = "No se conecto: " & ex.ToString()
            cn.Close()
        End Try
        'existeMayor = MayorSapRegistrado(cuentabancosap, nrodocumento, nrotransaccion, cargo, abono)
        If existeMayor > 0 Then
            salida = "Ya existe"
        Else
            Try
                'cmd = New SqlCommand("Insert into RB_LIBROMAYORSAP(fecharegistro, cuentabancosap,fechacontalizacion,nrodocumento, nrotransaccion, comentarios, cargo, abono, referencia1, referencia2, referencia3) values('" & fecharegistro & "'," & cuentabancosap & ",'" & fechacontalizacion & "','" & nrodocumento & "','" & nrotransaccion & "','" & comentarios & "','" & cargo & "','" & abono & "','" & referencia1 & "','" & referencia2 & "','" & referencia3 & "')", cn)
                cmd = New SqlCommand("INSERT INTO RB_LIBROMAYORSAP(item, fecharegistro, cuentabancosap, banco, fechacontalizacion, nrodocumento, nrotransaccion, comentarios, cargo, abono, referencia1, referencia2, referencia3)
                                                        VALUES (@item, @fecharegistro, @cuentabancosap, @nombrebanco, @fechacontalizacion, @nrodocumento, @nrotransaccion, @comentarios, @cargo, @abono, @referencia1, @referencia2, @referencia3)", cn)
                cmd.Parameters.Add(New SqlParameter("@item", item))
                cmd.Parameters.Add(New SqlParameter("@fecharegistro", fecharegistro))
                cmd.Parameters.Add(New SqlParameter("@cuentabancosap", cuentabancosap))
                cmd.Parameters.Add(New SqlParameter("@nombrebanco", nombrebanco))
                cmd.Parameters.Add(New SqlParameter("@fechacontalizacion", fechacontalizacion))
                cmd.Parameters.Add(New SqlParameter("@nrodocumento", nrodocumento))
                cmd.Parameters.Add(New SqlParameter("@nrotransaccion", nrotransaccion))
                cmd.Parameters.Add(New SqlParameter("@comentarios", comentarios))
                cmd.Parameters.Add(New SqlParameter("@cargo", Convert.ToDecimal(cargo)))
                cmd.Parameters.Add(New SqlParameter("@abono", Convert.ToDecimal(abono)))
                cmd.Parameters.Add(New SqlParameter("@referencia1", referencia1))
                cmd.Parameters.Add(New SqlParameter("@referencia2", referencia2))
                cmd.Parameters.Add(New SqlParameter("@referencia3", referencia3))
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                salida = "No se conecto: " & ex.ToString()
                cn.Close()
            End Try
        End If
        cn.Close()
        Return salida
    End Function

    Public Function ExtractoRegistrado(ByVal cuenta As String, ByVal nromovimiento As String, ByVal debito As String, ByVal credito As String) As Integer
        Dim contador As Integer = 0

        Try
            cmd = New SqlCommand("select * from SDKTimbo.dbo.RB_EXTRACTO where cuentabancosap = " & cuenta & " and nromovimiento = " & nromovimiento & " and debito = " & debito & " and credito = " & credito & "", cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                contador += 1
            End While

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("No se pudo consultar bien: " & ex.ToString())
            cn.Close()
        End Try

        Return contador
    End Function

    Public Function MayorSapRegistrado(ByVal cuenta As String, ByVal nrodocumento As String, ByVal nrotransaccion As String, ByVal cargo As String, ByVal abono As String) As Integer
        Dim contador As Integer = 0

        Try
            cmd = New SqlCommand("select * from SDKTimbo.dbo.RB_LIBROMAYORSAP where cuentabancosap = " & cuenta & " and nrodocumento = '" & nrodocumento & "' and nrotransaccion = '" & nrotransaccion & "' and cargo = '" & cargo & "' and abono = '" & abono & "'", cn)
            dr = cmd.ExecuteReader()

            While dr.Read()
                contador += 1
            End While

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("No se pudo consultar bien: " & ex.ToString())
            cn.Close()
        End Try

        Return contador
    End Function

    Public Function ConciliacionBancaria() As Boolean
        Try
            Conectar()
            cmd = New SqlCommand("SDKTimbo.dbo.spConciliacionBancaria", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandTimeout = 0
            If CBool(cmd.ExecuteNonQuery()) Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            cn.Close()
        End Try

    End Function
End Module
