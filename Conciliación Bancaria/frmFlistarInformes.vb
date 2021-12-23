Imports System.Data.SqlClient
Imports System.Data
'Imports ExportarExcel

Public Class frmFlistarInformes
    Private Sub frmListarInformes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dt As New DataTable
        ds.Tables.Add(dt)
        If ban = 1 Then
            Try
                Conectar()
                Dim da As New SqlDataAdapter("SELECT fecharegistro, cuentabancosap, banco, fechamovimiento, descripcion, nromovimiento, debito, credito, saldo, refmayorsap, fechaconciliacion FROM SDKTimbo.dbo.RB_ReporteExtracto WHERE cast(fechaconciliacion as date) = (
                                    SELECT MAX(CAST(fechaconciliacion AS date)) FROM SDKTimbo.dbo.RB_ReporteExtracto) order by saldo", cn)
                da.Fill(ds, "ListaExtracto")

                dt = ds.Tables("ListaExtracto")
                dgvListarInformes.DataSource = dt
            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try

        ElseIf ban = 2 Then
            Try
                Conectar()
                Dim da As New SqlDataAdapter("SELECT fecharegistro, cuentabancosap, banco, fechacontalizacion, nrodocumento, nrotransaccion, comentarios, cargo, abono, referencia1, referencia2, referencia3, saldo, refnromovimiento, fechaconciliacion FROM SDKTimbo.dbo.RB_ReporteMayorSAP WHERE cast(fechaconciliacion as date) = (
                                            SELECT MAX(CAST(fechaconciliacion AS date)) FROM SDKTimbo.dbo.RB_ReporteMayorSAP) order by saldo, nrodocumento", cn)
                da.Fill(ds, "ListaMayor")

                dt = ds.Tables("ListaMayor")
                dgvListarInformes.DataSource = dt
            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try


        ElseIf ban = 3 Then
            Try
                Conectar()
                Dim da As New SqlDataAdapter("select item, fecharegistro, cuentabancosap, banco, fechamovimiento, descripcion, nromovimiento, debito, credito from SDKTimbo.dbo.RB_EXTRACTO where cast(fecharegistro as date) = cast(GETDATE() as date) and 
                                                cuentabancosap = (select cuentabancosap from SDKTimbo.dbo.RB_EXTRACTO where id = (select MAX(id) from SDKTimbo.dbo.RB_EXTRACTO)) order by item", cn)
                da.Fill(ds, "ExtractoInsertado")

                dt = ds.Tables("ExtractoInsertado")
                dgvListarInformes.DataSource = dt

                MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")

            Catch ex As Exception
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
                cn.Close()
            End Try

        ElseIf ban = 4 Then
            Try
                Conectar()
                Dim da As New SqlDataAdapter("select item, fecharegistro, cuentabancosap, banco, fechacontalizacion, nrodocumento, nrotransaccion, comentarios, cargo, abono, referencia1, referencia2, referencia3 from SDKTimbo.dbo.RB_LIBROMAYORSAP where cast(fecharegistro as date) = cast(GETDATE() as date) 
                                                and cuentabancosap = (select cuentabancosap from SDKTimbo.dbo.RB_LIBROMAYORSAP where id = (select MAX(id) from SDKTimbo.dbo.RB_LIBROMAYORSAP)) order by item", cn)
                da.Fill(ds, "MayorInsertado")

                dt = ds.Tables("MayorInsertado")
                dgvListarInformes.DataSource = dt

                MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")

            Catch ex As Exception
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
                cn.Close()
            End Try

        ElseIf ban = 5 Then
            Try
                dt = ds.Tables("Extracto")
                dgvListarInformes.DataSource = dt
                MsgBox("Algunos campos están vacíos. Complete los registros y vuelva a intentarlo.")
            Catch ex As Exception
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
                cn.Close()
            End Try

        ElseIf ban = 6 Then
            Try
                dt = ds.Tables("LibroMayor")
                dgvListarInformes.DataSource = dt
                MsgBox("Algunos campos están vacíos. Complete los registros y vuelva a intentarlo.")
            Catch ex As Exception
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
                cn.Close()
            End Try

        ElseIf ban = 7 Then
            Try
                dt = ds.Tables("ExtractoBancario")
                dgvListarInformes.DataSource = dt
                'MsgBox("Algunos campos están vacíos. Complete los registros y vuelva a intentarlo.")
            Catch ex As Exception
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
                cn.Close()
            End Try

        ElseIf ban = 8 Then
            Try
                dt = ds.Tables("libroMayorSAP")
                dgvListarInformes.DataSource = dt
                'MsgBox("Algunos campos están vacíos. Complete los registros y vuelva a intentarlo.")
            Catch ex As Exception
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
                cn.Close()
            End Try

        ElseIf ban = 9 Then
            Try
                dt = ds.Tables("ExtractoConciliado")
                dgvListarInformes.DataSource = dt
                'MsgBox("Algunos campos están vacíos. Complete los registros y vuelva a intentarlo.")
            Catch ex As Exception
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
                cn.Close()
            End Try

        ElseIf ban = 10 Then
            Try
                dt = ds.Tables("MayorConciliado")
                dgvListarInformes.DataSource = dt
                'MsgBox("Algunos campos están vacíos. Complete los registros y vuelva a intentarlo.")
            Catch ex As Exception
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
                cn.Close()
            End Try

        End If

        cn.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim frm As New CuadrodeProceso
        frm.Show("Exportando...")
        llenarExcel(dgvListarInformes)
        frm.Close()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    'Public Sub listarExtracto(ByVal tabla As DataGridView)


    'End Sub
End Class