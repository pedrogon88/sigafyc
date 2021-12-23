Imports System.IO 'esta libreria nos va a servir para poder activar el commandialog
Imports Microsoft.Office.Interop
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports Microsoft.VisualBasic
'Imports Conexion

Module Importar
    Public ban As Integer = 0
    Public ds As New DataSet

    'Public Sub importarExcelExtracto(ByRef ruta As String, ByVal tabla As DataGridView)
    Public Sub importarExcelExtracto(ByRef ruta As String)
        ds.Clear()
        ds.Dispose()
        ds.Reset()
        Dim proceso As New CuadrodeProceso
        proceso.Show("Importando..")

        'Dim ExcelFile As String = myFileDialog.FileName.ToString
        Dim ExcelFile As String = ruta
        Dim Hoja As String = "EXTRACTO"


        If ExcelFile <> "" Then
            'Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection

            'Hoja = InputBox("Digite el nombre de la Hoja que desea importar", "Complete")
            conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
                              "Data Source=" & ExcelFile & "; " &
                             "Extended Properties='Excel 12.0 Xml;HDR=Yes'"
                             )

            Try
                da = New OleDbDataAdapter("SELECT * FROM  [" & Hoja & "$]", conn)

                conn.Open()

                If ds.Tables("ExtractoBanco") IsNot Nothing Then
                    ds.Tables("ExtractoBanco").Clear()
                End If
                da.Fill(ds, "ExtractoBanco")
                dt = ds.Tables("ExtractoBanco")
                'tabla.DataSource = ds
                'tabla.DataMember = "ExtractoBanco"


                If ds.Tables("Extracto") IsNot Nothing Then
                    ds.Tables("Extracto").Clear()

                End If
                Dim dt2 As New DataTable("Extracto")
                ds.Tables.Add(dt2)
                dt2.Columns.Add("Item")
                dt2.Columns.Add("Cuenta")
                dt2.Columns.Add("Fecha")
                dt2.Columns.Add("Descripción")
                dt2.Columns.Add("Movimiento")
                dt2.Columns.Add("Importe")
                'dt2.Columns.Add("Creditos")
                Dim salida As String

                If ds.Tables("ExtractoBanco").Rows.Count > 0 Then
                    Dim RowDet As DataRow

                    For Each RowDet In ds.Tables("ExtractoBanco").Rows
                        If RowDet.Item("Item").ToString() = "" Or RowDet.Item("Cuenta").ToString() = "" Or RowDet.Item("Fecha").ToString() = "" Or RowDet.Item("Importe").ToString() = "" Then
                            Dim dr As DataRow = dt2.NewRow
                            dr("Item") = RowDet.Item("Item")
                            dr("Cuenta") = RowDet.Item("Cuenta").ToString()
                            dr("Fecha") = RowDet.Item("Fecha")
                            dr("Descripción") = RowDet.Item("Descripción").ToString()
                            dr("Movimiento") = RowDet.Item("Movimiento").ToString()
                            dr("Importe") = RowDet.Item("Importe")
                            'dr("Creditos") = RowDet.Item("Créditos").ToString()
                            dt2.Rows.Add(dr)
                        Else
                            salida = insertarExtracto(CInt(RowDet.Item("Item")), RowDet.Item("Cuenta").ToString(), RowDet.Item("Fecha").ToString(), RowDet.Item("Descripción").ToString(), RowDet.Item("Movimiento").ToString, CDec(RowDet.Item("Importe")))
                            If salida <> "Se inserto" Then
                                Dim dr As DataRow = dt2.NewRow
                                dr("Item") = RowDet.Item("Item")
                                dr("Cuenta") = RowDet.Item("Cuenta").ToString()
                                dr("Fecha") = RowDet.Item("Fecha")
                                dr("Descripción") = RowDet.Item("Descripción").ToString()
                                dr("Movimiento") = RowDet.Item("Movimiento").ToString()
                                dr("Importe") = RowDet.Item("Importe")
                                'dr("Creditos") = RowDet.Item("Créditos").ToString()
                                dt2.Rows.Add(dr)
                            End If
                        End If
                    Next
                End If

                If ds.Tables("Extracto").Rows.Count > 0 Then
                    proceso.Close()
                    ban = 5
                    Dim frm As New frmFlistarInformes
                    frm.ShowDialog()
                    ds.Clear()
                    ds.Dispose()


                    'tabla.DataSource = ds
                    'tabla.DataMember = "Extracto"
                    'MsgBox("Algunos campos están vacíos. Complete los registros y vuelva a intentarlo.")
                Else
                    proceso.Close()
                    ban = 3
                    Dim frm As New frmFlistarInformes
                    frm.ShowDialog()
                    ds.Clear()
                    ds.Dispose()

                End If
            Catch ex As Exception
                proceso.Close()
                'MsgBox("Inserte un nombre valido de la Hoja que desea importar", MsgBoxStyle.Information, "Informacion")
                MsgBox("No se pudo insertar: " & ex.ToString())
            Finally
                conn.Close()
            End Try
        End If
        'MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")
    End Sub

    'Public Sub importarExcelMayorSAP(ByRef ruta As String, ByVal tabla As DataGridView)
    Public Sub importarExcelMayorSAP(ByRef ruta As String)
        'Dim ExcelFile As String = myFileDialog.FileName.ToString
        Dim ExcelFile As String = ruta
        Dim Hoja As String = "MAYOR SAP"
        Dim proceso As New CuadrodeProceso
        proceso.Show("Importando...")

        If ExcelFile <> "" Then
            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection

            'Hoja = InputBox("Digite el nombre de la Hoja que desea importar", "Complete")
            conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" &
                              "Data Source=" & ExcelFile & "; " &
                             "Extended Properties='Excel 12.0 Xml;HDR=Yes'"
                             )

            Try
                da = New OleDbDataAdapter("SELECT * FROM  [" & Hoja & "$]", conn)

                conn.Open()

                da.Fill(ds, "LibroMayor")
                dt = ds.Tables("LibroMayor")
                'tabla.DataSource = ds
                'tabla.DataMember = "ExtractoBanco"



                Dim dt2 As New DataTable("MayorSAP")
                ds.Tables.Add(dt2)
                dt2.Columns.Add("Item")
                dt2.Columns.Add("Cuenta asociada")
                dt2.Columns.Add("Fecha de contabilización")
                dt2.Columns.Add("Nº documento")
                dt2.Columns.Add("Nº de transacción")
                dt2.Columns.Add("Comentarios")
                dt2.Columns.Add("Importe")
                dt2.Columns.Add("Referencia 1 (Fila)")
                dt2.Columns.Add("Referencia 2 (Fila)")
                dt2.Columns.Add("Referencia 3 (Fila)")

                If ds.Tables("LibroMayor").Rows.Count > 0 Then
                    Dim RowDet As DataRow
                    Dim salida As String = ""

                    For Each RowDet In ds.Tables("LibroMayor").Rows
                        If RowDet.Item("Item").ToString() = "" Or RowDet.Item("Cuenta asociada").ToString() = "" Or RowDet.Item("Fecha de contabilización").ToString() = "" Or RowDet.Item("Nº documento").ToString() = "" Or RowDet.Item("Importe").ToString() = "" Then
                            Dim dr As DataRow = dt2.NewRow
                            dr("Item") = RowDet.Item("Item")
                            dr("Cuenta asociada") = RowDet.Item("Cuenta asociada").ToString()
                            dr("Fecha de contabilización") = RowDet.Item("Fecha de contabilización").ToString()
                            dr("Nº documento") = RowDet.Item("Nº documento").ToString()
                            dr("Nº de transacción") = RowDet.Item("Nº de transacción").ToString()
                            dr("Comentarios") = RowDet.Item("Comentarios").ToString()
                            dr("Importe") = RowDet.Item("Importe").ToString()
                            dr("Referencia 1 (Fila)") = RowDet.Item("Referencia 1 (Fila)").ToString()
                            dr("Referencia 2 (Fila)") = RowDet.Item("Referencia 2 (Fila)").ToString()
                            dr("Referencia 3 (Fila)") = RowDet.Item("Referencia 3 (Fila)").ToString()
                            dt2.Rows.Add(dr)
                        Else
                            salida = insertarMayorSAP(CInt(RowDet.Item("Item")), RowDet.Item("Cuenta asociada").ToString(), RowDet.Item("Fecha de contabilización").ToString(), RowDet.Item("Nº documento").ToString(), RowDet.Item("Nº de transacción").ToString, RowDet.Item("Comentarios").ToString(), CDbl(RowDet.Item("Importe")), RowDet.Item("Referencia 1 (Fila)").ToString(), RowDet.Item("Referencia 2 (Fila)").ToString(), RowDet.Item("Referencia 3 (Fila)").ToString())
                            If salida <> "Se inserto" Then
                                Dim dr As DataRow = dt2.NewRow
                                dr("Item") = RowDet.Item("Item")
                                dr("Cuenta asociada") = RowDet.Item("Cuenta asociada").ToString()
                                dr("Fecha de contabilización") = RowDet.Item("Fecha de contabilización").ToString()
                                dr("Nº documento") = RowDet.Item("Nº documento").ToString()
                                dr("Nº de transacción") = RowDet.Item("Nº de transacción").ToString()
                                dr("Comentarios") = RowDet.Item("Comentarios").ToString()
                                dr("Importe") = RowDet.Item("Importe").ToString()
                                dr("Referencia 1 (Fila)") = RowDet.Item("Referencia 1 (Fila)").ToString()
                                dr("Referencia 2 (Fila)") = RowDet.Item("Referencia 2 (Fila)").ToString()
                                dr("Referencia 3 (Fila)") = RowDet.Item("Referencia 3 (Fila)").ToString()
                                dt2.Rows.Add(dr)
                            End If
                        End If
                    Next
                End If

                If ds.Tables("MayorSAP").Rows.Count > 0 Then
                    proceso.Close()
                    ban = 6
                    Dim frm As New frmFlistarInformes
                    frm.ShowDialog()
                    ds.Clear()
                    ds.Dispose()
                    'tabla.DataSource = ds
                    'tabla.DataMember = "MayorSAP"
                    'MsgBox("Algunos campos están vacíos. Complete los registros y vuelva a intentarlo.")
                Else
                    proceso.Close()
                    ban = 4
                    Dim frm As New frmFlistarInformes
                    frm.ShowDialog()
                    ds.Clear()
                    ds.Dispose()
                    'tabla.DataSource = ds
                    'tabla.DataMember = "LibroMayor"
                    'MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")

                End If
            Catch ex As Exception
                proceso.Close()
                MsgBox("Inserte un nombre valido de la Hoja que desea importar", MsgBoxStyle.Information, "Informacion")
            Finally
                conn.Close()
            End Try
        End If
        'MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")
    End Sub
End Module
