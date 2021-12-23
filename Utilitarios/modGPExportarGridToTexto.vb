Imports System.IO
Module modGPExportarGridToTexto

    Public Sub GPExportarGridToTexto(ByVal poDataGridView As DataGridView, Optional ByVal psNombre As String = "")
        Dim loCarpetaDialogo As New FolderBrowserDialog
        loCarpetaDialogo.Description = "Seleccione ubicacion para archivo de Texto, datos de " & psNombre
        loCarpetaDialogo.RootFolder = Environment.SpecialFolder.MyComputer
        loCarpetaDialogo.SelectedPath = GFsParametroObtener(sGeneral_, "Ubicacion - Archivos exportados").Replace(sDS_, sDS_.Substring(0, 1))
        If loCarpetaDialogo.ShowDialog() = DialogResult.Cancel Then
            GFsAvisar("Usted ha cancelado la Exportacion", sMENSAJE_, psNombre)
            Exit Sub
        End If
        Dim lsSeparador As String = InputBox("Ingrese separador deseado", "Exportacion Texto delimitado", sSF_)
        If String.IsNullOrEmpty(lsSeparador) Then
            GFsAvisar("Usted no ha seleccionado un separador, de hecho cancelo", sMENSAJE_, "Por lo cual este proceso será cancelado.")
            Exit Sub
        End If

        Dim lsNombreArchivo = SesionActiva.usuario & "_" & Now.ToString(sFormatoFechaHora3_) & ".txt"
        If psNombre.Trim.Length > 0 Then lsNombreArchivo = psNombre & "_" & lsNombreArchivo


        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Generando Archivo Texto " & lsNombreArchivo & "..."

        Dim lsUbicacion As String = loCarpetaDialogo.SelectedPath
        Dim lsFilename = lsUbicacion & "\" & lsNombreArchivo

        Dim i As Integer
        Dim j As Integer

        Dim loDataWriter As New StreamWriter(lsFilename)
        Dim lsLinea As String = ""

        lsLinea = ""
        For j = 0 To poDataGridView.ColumnCount - 1
            loFrmProcesamiento.lblRegistroLeido.Text = "Procesando Columna [" & j + 1 & "] = " & poDataGridView.Columns(j).HeaderText
            If lsLinea.Trim.Length = 0 Then
                lsLinea = poDataGridView.Columns(j).HeaderText.Trim
            Else
                lsLinea &= lsSeparador & poDataGridView.Columns(j).HeaderText.Trim
            End If
            loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando Columna [" & j + 1 & "] = " & poDataGridView.Columns(j).HeaderText
            loFrmProcesamiento.Refresh()
        Next
        loDataWriter.WriteLine(lsLinea)

        Dim loRow As DataGridViewRow
        For i = 0 To poDataGridView.RowCount - 1
            lsLinea = ""
            loRow = poDataGridView.Rows(i)
            For j = 0 To poDataGridView.ColumnCount - 1
                loFrmProcesamiento.lblRegistroLeido.Text = "Procesando Celda [" & i + 1 & "," & j + 1 & "] = " & poDataGridView(j, i).Value.ToString()
                If loRow.Visible = True Then
                    If lsLinea.Trim.Length = 0 Then
                        lsLinea = poDataGridView(j, i).Value.ToString().Trim
                    Else
                        lsLinea &= lsSeparador & poDataGridView(j, i).Value.ToString().Trim
                    End If
                    loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando Celda [" & i + 1 & "," & j + 1 & "] = " & poDataGridView(j, i).Value.ToString()
                    loFrmProcesamiento.Refresh()
                End If
            Next
            If loRow.Visible = True Then loDataWriter.WriteLine(lsLinea)
        Next
        loDataWriter.Close()
        loDataWriter.Dispose()
        loDataWriter = Nothing

        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        GFsAvisar("El archivo excel [" & lsNombreArchivo & "] ha sido creado exitosamente!. ", sMENSAJE_, "Ubicacion: " & lsUbicacion)
    End Sub

End Module
