Imports Microsoft.Office.Interop

Module modGPExportarGridToExcel

    Public Sub GPExportarGridToExcel(ByVal poDataGridView As DataGridView, Optional psNombre As String = "", Optional psNombreHoja As String = "Hoja1")
        Dim loCarpetaDialogo As New FolderBrowserDialog
        loCarpetaDialogo.Description = "Seleccione ubicacion para archivo Excel, datos de " & psNombre
        loCarpetaDialogo.RootFolder = Environment.SpecialFolder.MyComputer
        loCarpetaDialogo.SelectedPath = GFsParametroObtener(sGeneral_, "Ubicacion - Archivos exportados").Replace(sDS_, sDS_.Substring(0, 1))
        If loCarpetaDialogo.ShowDialog() = DialogResult.Cancel Then
            GFsAvisar("Usted ha cancelado la Exportacion al Excel", sMENSAJE_, psNombre)
            Exit Sub
        End If
        Dim lsNombreArchivo = SesionActiva.usuario & "_" & Now.ToString(sFormatoFechaHora3_) & ".xlsx"
        If psNombre.Trim.Length > 0 Then lsNombreArchivo = psNombre & "_" & lsNombreArchivo


        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Generando Excel " & lsNombreArchivo & "..."

        Dim lsUbicacion As String = loCarpetaDialogo.SelectedPath
        Dim lsFilename = lsUbicacion & sDS_.Substring(0, 1) & lsNombreArchivo

        Dim loXlApp As Excel._Application = New Excel.Application
        Dim loXlWorkBook As Excel._Workbook = loXlApp.Workbooks.Add(Type.Missing)
        Dim loXlWorkSheet As Excel._Worksheet = Nothing
        loXlWorkSheet = CType(loXlWorkBook.Sheets(psNombreHoja), Excel._Worksheet)
        loXlWorkSheet = CType(loXlWorkBook.ActiveSheet, Excel._Worksheet)
        loXlApp.Visible = False

        Dim loXlCellRange As Excel.Range

        Dim i As Integer
        Dim j As Integer
        Dim lsParte() As String = Nothing

        If poDataGridView.AccessibleName IsNot Nothing Then
            lsParte = poDataGridView.AccessibleName.Split(sSF_)
            For i = 0 To lsParte.Length - 1
                loFrmProcesamiento.lblRegistroLeido.Text = "Recuperando Titulo [" & i & "] = " & lsParte(i)
                loXlWorkSheet.Cells(i + 1, 1) = lsParte(i)
                loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando Titulo [" & i & "] = " & lsParte(i)
            Next
        End If

        Dim liRow As Integer = 0
        If poDataGridView.AccessibleName IsNot Nothing Then
            liRow = lsParte.Length
        End If

        For j = 0 To poDataGridView.ColumnCount - 1
            loFrmProcesamiento.lblRegistroLeido.Text = "Procesando Columna [" & j + 1 & "] = " & poDataGridView.Columns(j).HeaderText
            loXlWorkSheet.Cells(liRow + 1, j + 1) = poDataGridView.Columns(j).HeaderText
            loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando Columna [" & j + 1 & "] = " & poDataGridView.Columns(j).HeaderText
        Next

        Dim loRow As DataGridViewRow
        liRow = 1
        If poDataGridView.AccessibleName IsNot Nothing Then
            liRow = 1 + lsParte.Length
        End If

        For i = 0 To poDataGridView.RowCount - 1
            loRow = poDataGridView.Rows(i)
            If loRow.Visible = True Then
                liRow += 1
                For j = 0 To poDataGridView.ColumnCount - 1
                    loFrmProcesamiento.lblRegistroLeido.Text = "Procesando Celda [" & i + 1 & "," & j + 1 & "] = " & poDataGridView(j, i).Value.ToString()
                    loXlWorkSheet.Cells(liRow, j + 1) = poDataGridView(j, i).Value.ToString()
                    loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando Celda [" & liRow & "," & j + 1 & "] = " & poDataGridView(j, i).Value.ToString()
                    loFrmProcesamiento.Refresh()
                Next
            End If
        Next

        loXlCellRange = loXlWorkSheet.Range(loXlWorkSheet.Cells(1, 1), loXlWorkSheet.Cells(1, poDataGridView.Columns.Count))
        loXlCellRange.Font.Bold = True
        loXlCellRange.Font.Color = Color.Blue
        loXlWorkBook.Activate()

        loXlWorkBook.SaveAs(lsFilename)

        loXlWorkBook.Close()
        loXlApp.Quit()

        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        releaseObject(loXlApp)
        releaseObject(loXlWorkBook)
        releaseObject(loXlWorkSheet)

        GFsAvisar("El archivo excel [" & lsNombreArchivo & "] ha sido creado exitosamente!. ", sMENSAJE_, "Ubicacion: " & lsUbicacion)
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Module
