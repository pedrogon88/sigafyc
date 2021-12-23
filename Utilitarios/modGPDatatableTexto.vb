Imports System.IO
Imports System.Data.Common

Module modGPDatatableTexto
    Private moDataTable As DataTable
    Private miCantidad As Integer = 1

    Public Sub GPDatatableTexto(ByVal psSQL As String, Optional psNombre As String = "", Optional psRama As String = sRegistryTablasPrincipal_)
        GPBitacoraRegistrar(sENTRO_, "Generar Archivo de Texto " & psNombre & ", Dependiente " & psRama)
        LPGeneraDataTable(psSQL, psRama)

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

        Dim lsUbicacion As String = loCarpetaDialogo.SelectedPath
        Dim lsFilename = lsUbicacion & "\" & lsNombreArchivo
        GPBitacoraRegistrar(sINFORMAR_, "Nombre archivo: " & lsNombreArchivo & ", Ubicación: " & lsUbicacion & ", con separador [" & lsSeparador & "]...")
        loFrmProcesamiento.lblTitulo.Text = "Generando Archivo Texto " & lsNombreArchivo & ", con separador [" & lsSeparador & "]..."

        Dim loDataWriter As New StreamWriter(lsFilename)
        Dim lsLinea As String = ""

        lsLinea = ""
        Dim loColumn As DataColumn

        For Each loColumn In moDataTable.Columns
            If lsLinea.Trim.Length = 0 Then
                lsLinea = loColumn.ColumnName
            Else
                lsLinea &= lsSeparador & loColumn.ColumnName
            End If
            loFrmProcesamiento.lblRegistroLeido.Text = "Leido -> " & lsLinea
        Next
        loDataWriter.WriteLine(lsLinea)
        loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando -> " & lsLinea

        Dim loRow As DataRow
        For Each loRow In moDataTable.Rows
            lsLinea = ""
            For Each loColumn In moDataTable.Columns
                loFrmProcesamiento.lblRegistroLeido.Text = "leido -> " & lsLinea
                If lsLinea.Trim.Length = 0 Then
                    lsLinea = loRow.Item(loColumn.ColumnName).ToString.Trim
                Else
                    lsLinea &= lsSeparador & loRow.Item(loColumn.ColumnName).ToString.Trim
                End If
            Next
            miCantidad += 1
            loDataWriter.WriteLine(lsLinea)
            loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando -> " & lsLinea
            loFrmProcesamiento.Refresh()
        Next
        loDataWriter.Close()
        loDataWriter.Dispose()
        loDataWriter = Nothing

        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        GPBitacoraRegistrar(sINFORMAR_, "Cantidad registros generados (incluyendo cabecera):" & miCantidad.ToString)
        GFsAvisar("El archivo [" & lsNombreArchivo & "] ha sido creado exitosamente!. ", sMENSAJE_, "Ubicacion: " & lsUbicacion)
        GPBitacoraRegistrar(sSALIO_, "Generar Archivo de Texto " & psNombre & ", Dependiente " & psRama)
    End Sub

    Private Sub LPGeneraDataTable(ByVal psSQL As String, ByVal psRama As String)
        Dim loCN As New BaseDatos
        loCN.SetearParametrosConexion(psRama)
        loCN.Conectar()
        Try
            loCN.CrearComando(psSQL)
            moDataTable = loCN.EjecutarConsultaTable
            GPBitacoraRegistrar(sSQL_, psSQL)
        Catch ex As DbException
            GFsAvisar("GPDatatableTexto.LPGeneraDataTable", sMENSAJE_, ex.Message)
        End Try

        loCN.Desconectar()
        loCN = Nothing
    End Sub
End Module
