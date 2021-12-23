Imports System.Data.SqlClient
Imports System.Data

Public Class frmFconsultas
    'Public ban As Integer = 0
    'Public ds As New DataSet
    Private Sub frmFconsultas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblConciliación.Visible = False
        lblRegistro.Visible = True

    End Sub

    Private Sub rdrExtractoBanco_CheckedChanged(sender As Object, e As EventArgs) Handles rdrExtractoBanco.CheckedChanged
        If rdrExtractoBanco.Checked = True Then
            lblConciliación.Visible = False
            lblRegistro.Visible = True
            Dim tablaExtracto As New DataTable
            Try
                Conectar()
                Dim da As New SqlDataAdapter("SELECT distinct cast(fecharegistro as date) as fecharegistro FROM SDKTimbo.dbo.RB_Extracto order by cast(fecharegistro as date) desc", cn)
                da.Fill(tablaExtracto)

                cmbFecha.DataSource = tablaExtracto
                cmbFecha.DisplayMember = "fecharegistro"
                cmbFecha.ValueMember = "fecharegistro"

            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try

            cn.Close()
        End If
    End Sub

    Private Sub rdrLibroMayor_CheckedChanged(sender As Object, e As EventArgs) Handles rdrLibroMayor.CheckedChanged
        If rdrLibroMayor.Checked = True Then
            lblConciliación.Visible = False
            lblRegistro.Visible = True
            Dim tablaMayor As New DataTable
            Try
                Conectar()
                Dim da As New SqlDataAdapter("SELECT distinct cast(fecharegistro as date) as fecharegistro FROM SDKTimbo.dbo.RB_LIBROMAYORSAP order by cast(fecharegistro as date) desc", cn)
                da.Fill(tablaMayor)

                cmbFecha.DataSource = tablaMayor
                cmbFecha.DisplayMember = "fecharegistro"
                cmbFecha.ValueMember = "fecharegistro"

            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try
            cn.Close()

        End If
    End Sub

    Private Sub rdrConciliado_CheckedChanged(sender As Object, e As EventArgs) Handles rdrExtractoConciliado.CheckedChanged
        If rdrExtractoConciliado.Checked = True Then
            lblConciliación.Visible = True
            lblRegistro.Visible = False
            Dim tablaExtractoConciliado As New DataTable
            Try
                Conectar()
                Dim da As New SqlDataAdapter("SELECT distinct cast(fechaconciliacion as date) as fechaconciliacion FROM SDKTimbo.dbo.RB_ReporteExtracto order by cast(fechaconciliacion as date) desc", cn)
                da.Fill(tablaExtractoConciliado)

                cmbFecha.DataSource = tablaExtractoConciliado
                cmbFecha.DisplayMember = "fechaconciliacion"
                cmbFecha.ValueMember = "fechaconciliacion"

            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try
            cn.Close()

        End If
    End Sub

    Private Sub rdrMayorConciliado_CheckedChanged(sender As Object, e As EventArgs) Handles rdrMayorConciliado.CheckedChanged
        If rdrMayorConciliado.Checked = True Then
            lblConciliación.Visible = True
            lblRegistro.Visible = False
            Dim tablaMayorConciliado As New DataTable
            Try
                Conectar()
                Dim da As New SqlDataAdapter("SELECT distinct cast(fechaconciliacion as date) as fechaconciliacion FROM SDKTimbo.dbo.RB_ReporteMayorSAP order by cast(fechaconciliacion as date) desc", cn)
                da.Fill(tablaMayorConciliado)

                cmbFecha.DataSource = tablaMayorConciliado
                cmbFecha.DisplayMember = "fechaconciliacion"
                cmbFecha.ValueMember = "fechaconciliacion"

            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try
            cn.Close()
        End If
    End Sub

    Private Sub cmbFecha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFecha.SelectedIndexChanged
        If rdrExtractoBanco.Checked = True Then
            Dim fecha As String
            Dim tipodato As String = cmbFecha.SelectedValue.GetType().ToString()
            If tipodato = "System.Data.DataRowView" Then
                Dim row As DataRowView = DirectCast(cmbFecha.SelectedValue, DataRowView)
                fecha = CStr(row("fecharegistro"))
            Else
                fecha = CStr(cmbFecha.SelectedValue)
            End If
            Dim tablaExtracto As New DataTable
            Try
                Conectar()
                Dim da As New SqlDataAdapter("select 'TODAS' AS banco union all SELECT distinct banco FROM SDKTimbo.dbo.RB_Extracto where cast(fecharegistro as date) = '" & fecha & "' order by banco desc", cn)
                da.Fill(tablaExtracto)

                cmbBanco.DataSource = tablaExtracto
                cmbBanco.DisplayMember = "banco"
                cmbBanco.ValueMember = "banco"

            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try
            cn.Close()
        End If

        If rdrLibroMayor.Checked = True Then
            Dim fecha As String
            Dim tipodato As String = cmbFecha.SelectedValue.GetType().ToString()
            If tipodato = "System.Data.DataRowView" Then
                Dim row As DataRowView = DirectCast(cmbFecha.SelectedValue, DataRowView)
                fecha = CStr(row("fecharegistro"))
            Else
                fecha = CStr(cmbFecha.SelectedValue)
            End If
            Dim tablaMayor As New DataTable
            Try
                Conectar()
                Dim da As New SqlDataAdapter("select 'TODAS' AS banco union all SELECT distinct banco FROM SDKTimbo.dbo.RB_LIBROMAYORSAP where cast(fecharegistro as date) = '" & fecha & "' order by banco desc", cn)
                da.Fill(tablaMayor)

                cmbBanco.DataSource = tablaMayor
                cmbBanco.DisplayMember = "banco"
                cmbBanco.ValueMember = "banco"

            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try
            cn.Close()
        End If

        If rdrExtractoConciliado.Checked = True Then
            Dim fecha As String
            Dim tipodato As String = cmbFecha.SelectedValue.GetType().ToString()
            If tipodato = "System.Data.DataRowView" Then
                Dim row As DataRowView = DirectCast(cmbFecha.SelectedValue, DataRowView)
                fecha = CStr(row("fechaconciliacion"))
            Else
                fecha = CStr(cmbFecha.SelectedValue)
            End If
            Dim tablaExtractoConciliado As New DataTable
            Try
                Conectar()
                Dim da As New SqlDataAdapter("select 'TODAS' AS banco union all SELECT distinct banco FROM SDKTimbo.dbo.RB_ReporteExtracto where cast(fechaconciliacion as date) = '" & fecha & "' order by banco desc", cn)
                da.Fill(tablaExtractoConciliado)

                cmbBanco.DataSource = tablaExtractoConciliado
                cmbBanco.DisplayMember = "banco"
                cmbBanco.ValueMember = "banco"

            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try
            cn.Close()
        End If

        If rdrMayorConciliado.Checked = True Then
            Dim fecha As String
            Dim tipodato As String = cmbFecha.SelectedValue.GetType().ToString()
            If tipodato = "System.Data.DataRowView" Then
                Dim row As DataRowView = DirectCast(cmbFecha.SelectedValue, DataRowView)
                fecha = CStr(row("fechaconciliacion"))
            Else
                fecha = CStr(cmbFecha.SelectedValue)
            End If
            Dim tablaMayorConciliado As New DataTable
            Try
                Conectar()
                Dim da As New SqlDataAdapter("select 'TODAS' AS banco union all SELECT distinct banco FROM SDKTimbo.dbo.RB_ReporteMayorSAP where cast(fechaconciliacion as date) = '" & fecha & "' order by banco desc", cn)
                da.Fill(tablaMayorConciliado)

                cmbBanco.DataSource = tablaMayorConciliado
                cmbBanco.DisplayMember = "banco"
                cmbBanco.ValueMember = "banco"

            Catch ex As Exception
                cn.Close()
                MessageBox.Show("No se pudo consultar: " & ex.ToString())
            End Try
            cn.Close()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If rdrExtractoBanco.Checked = True Then
            ban = 7
            Dim sql As String
            Dim fecha As String
            If cmbFecha.SelectedValue IsNot Nothing Then
                Dim tipodato As String = cmbFecha.SelectedValue.GetType().ToString()
                If tipodato = "System.Data.DataRowView" Then
                    Dim row As DataRowView = DirectCast(cmbFecha.SelectedValue, DataRowView)
                    fecha = Format(row("fecharegistro"), "dd-MM-yyyy")
                Else
                    fecha = Format(cmbFecha.SelectedValue, "dd-MM-yyyy")
                End If
                Dim banco As String = CStr(cmbBanco.SelectedValue)
                Try
                    Conectar()
                    If banco = "TODAS" Then
                        sql = "SELECT item, fecharegistro, cuentabancosap, banco, fechamovimiento, descripcion, nromovimiento, debito, credito, saldo, refmayorsap, fechaconciliacion from SDKTimbo.dbo.RB_EXTRACTO
                            where cast(fecharegistro As Date) = '" & fecha & "' order by id"
                    Else
                        sql = "SELECT item, fecharegistro, cuentabancosap, banco, fechamovimiento, descripcion, nromovimiento, debito, credito, saldo, refmayorsap, fechaconciliacion from SDKTimbo.dbo.RB_EXTRACTO 
                                                  where cast(fecharegistro as date) = '" & fecha & "' and banco = '" & banco & "' order by id"
                    End If
                    Dim da As New SqlDataAdapter(sql, cn)

                    If ds.Tables("ExtractoBancario") IsNot Nothing Then
                        ds.Tables("ExtractoBancario").Clear()
                    End If
                    da.Fill(ds, "ExtractoBancario")
                    Dim frm As New frmFlistarInformes
                    frm.ShowDialog()
                    ds.Clear()
                    ds.Dispose()
                Catch ex As Exception
                    cn.Close()
                    MessageBox.Show("No se pudo consultar: " & ex.ToString())
                End Try
            Else
                MsgBox("Debe seleccionar una fecha")
            End If

            cn.Close()
        End If

        If rdrLibroMayor.Checked = True Then
            ban = 8
            'Dim libroMayorSAP As New DataTable
            Dim sql As String
            Dim fecha As String
            If cmbFecha.SelectedValue IsNot Nothing Then
                Dim tipodato As String = cmbFecha.SelectedValue.GetType().ToString()
                If tipodato = "System.Data.DataRowView" Then
                    Dim row As DataRowView = DirectCast(cmbFecha.SelectedValue, DataRowView)
                    fecha = CStr(row("fecharegistro"))
                Else
                    fecha = CStr(cmbFecha.SelectedValue)
                End If
                Dim banco As String = CStr(cmbBanco.SelectedValue)
                Try
                    Conectar()
                    If banco = "TODAS" Then
                        sql = "SELECT item, fecharegistro, cuentabancosap, banco, fechacontalizacion, nrodocumento, nrotransaccion, comentarios, cargo, abono, referencia1, referencia2, referencia3, saldo, refnromovimiento, fechaconciliacion from SDKTimbo.dbo.RB_LIBROMAYORSAP
                                                  where cast(fecharegistro as date) = '" & fecha & "' order by id"
                    Else
                        sql = "SELECT item, fecharegistro, cuentabancosap, banco, fechacontalizacion, nrodocumento, nrotransaccion, comentarios, cargo, abono, referencia1, referencia2, referencia3, saldo, refnromovimiento, fechaconciliacion from SDKTimbo.dbo.RB_LIBROMAYORSAP
                                                  where cast(fecharegistro as date) = '" & fecha & "' and banco = '" & banco & "' order by id"

                    End If
                    Dim da As New SqlDataAdapter(sql, cn)
                    If ds.Tables("libroMayorSAP") IsNot Nothing Then
                        ds.Tables("libroMayorSAP").Clear()
                    End If
                    da.Fill(ds, "libroMayorSAP")
                    Dim frm As New frmFlistarInformes
                    frm.ShowDialog()
                    ds.Clear()
                    ds.Dispose()
                Catch ex As Exception
                    cn.Close()
                    MessageBox.Show("No se pudo consultar: " & ex.ToString())
                End Try
            Else
                MsgBox("Debe seleccionar una fecha")
            End If

            cn.Close()
        End If

        If rdrExtractoConciliado.Checked = True Then
            ban = 9
            'Dim ExtractoConciliado As New DataTable
            Dim sql As String
            Dim fecha As String
            If cmbFecha.SelectedValue IsNot Nothing Then
                Dim tipodato As String = cmbFecha.SelectedValue.GetType().ToString()
                If tipodato = "System.Data.DataRowView" Then
                    Dim row As DataRowView = DirectCast(cmbFecha.SelectedValue, DataRowView)
                    fecha = CStr(row("fecharegistro"))
                Else
                    fecha = CStr(cmbFecha.SelectedValue)
                End If
                Dim banco As String = CStr(cmbBanco.SelectedValue)
                Try
                    Conectar()
                    If banco = "TODAS" Then
                        sql = "SELECT fecharegistro, cuentabancosap, banco, fechamovimiento, descripcion, nromovimiento, debito, credito, saldo, refmayorsap, fechaconciliacion FROM SDKTimbo.dbo.RB_ReporteExtracto
                                                  where cast(fechaconciliacion as date) = '" & fecha & "' order by id"

                    Else
                        sql = "SELECT fecharegistro, cuentabancosap, banco, fechamovimiento, descripcion, nromovimiento, debito, credito, saldo, refmayorsap, fechaconciliacion FROM SDKTimbo.dbo.RB_ReporteExtracto
                                                  where cast(fechaconciliacion as date) = '" & fecha & "' and banco = '" & banco & "' order by id"

                    End If
                    Dim da As New SqlDataAdapter(sql, cn)
                    If ds.Tables("ExtractoConciliado") IsNot Nothing Then
                        ds.Tables("ExtractoConciliado").Clear()
                    End If
                    da.Fill(ds, "ExtractoConciliado")
                    Dim frm As New frmFlistarInformes
                    frm.ShowDialog()
                    ds.Clear()
                    ds.Dispose()
                Catch ex As Exception
                    cn.Close()
                    MessageBox.Show("No se pudo consultar: " & ex.ToString())
                End Try
            Else
                MsgBox("Debe seleccionar una fecha")
            End If

            cn.Close()
        End If

        If rdrMayorConciliado.Checked = True Then
            ban = 10
            'Dim MayorConciliado As New DataTable
            Dim sql As String
            Dim fecha As String
            If cmbFecha.SelectedValue IsNot Nothing Then
                Dim tipodato As String = cmbFecha.SelectedValue.GetType().ToString()
                If tipodato = "System.Data.DataRowView" Then
                    Dim row As DataRowView = DirectCast(cmbFecha.SelectedValue, DataRowView)
                    fecha = CStr(row("fecharegistro"))
                Else
                    fecha = CStr(cmbFecha.SelectedValue)
                End If
                Dim banco As String = CStr(cmbBanco.SelectedValue)
                Try
                    Conectar()
                    If banco = "TODAS" Then
                        sql = "SELECT fecharegistro, cuentabancosap, banco, fechacontalizacion, nrodocumento, nrotransaccion, comentarios, cargo, abono, referencia1, referencia2, referencia3, saldo, refnromovimiento, fechaconciliacion FROM SDKTimbo.dbo.RB_ReporteMayorSAP
                                                  where cast(fechaconciliacion as date) = '" & fecha & "' order by id"
                    Else
                        sql = "SELECT fecharegistro, cuentabancosap, banco, fechacontalizacion, nrodocumento, nrotransaccion, comentarios, cargo, abono, referencia1, referencia2, referencia3, saldo, refnromovimiento, fechaconciliacion FROM SDKTimbo.dbo.RB_ReporteMayorSAP
                                                  where cast(fechaconciliacion as date) = '" & fecha & "' and banco = '" & banco & "' order by id"
                    End If
                    Dim da As New SqlDataAdapter(sql, cn)
                    If ds.Tables("MayorConciliado") IsNot Nothing Then
                        ds.Tables("MayorConciliado").Clear()
                    End If
                    da.Fill(ds, "MayorConciliado")
                    Dim frm As New frmFlistarInformes
                    frm.ShowDialog()
                    ds.Clear()
                    ds.Dispose()
                Catch ex As Exception
                    cn.Close()
                    MessageBox.Show("No se pudo consultar: " & ex.ToString())
                End Try
            Else
                MsgBox("Debe seleccionar una fecha")
            End If

            cn.Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class