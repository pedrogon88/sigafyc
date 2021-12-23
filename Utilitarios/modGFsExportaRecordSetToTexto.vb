Imports System.IO

Module modGFsExportaRecordSetToTexto

    Public Function GFsExportaRecordSetToTexto(ByVal poDatos As DataTable, Optional ByVal psNombre As String = "", Optional psExtension As String = ".csv", Optional ByVal piNumMod As Integer = -1) As String
        GPBitacoraRegistrar(sENTRO_, "GFsExportaRecordSetToTexto --> Datatable:" & poDatos.TableName & ", Nombre:" & psNombre & ", Extension: " & psExtension & ", Modelo:" & piNumMod.ToString)
        Dim lsCabecera As String = ""
        Dim lsCabecera2 As String = ""
        Dim lsUbicacion As String = GFsParametroObtener(sLocal_, "Ubicacion - Archivos exportados")
        Dim lsSeparador As String = GFsParametroObtener(sGeneral_, "Separador - Archivos exportados")

        Dim lsNombreArchivo = SesionActiva.usuario & sMarcaEncriptado_ & Now.ToString(sFormatoFechaHora3_) & psExtension
        If psNombre.Trim.Length > 0 Then lsNombreArchivo = psNombre & sMarcaEncriptado_ & lsNombreArchivo

        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Generando Archivo [" & psExtension & "] -> " & lsNombreArchivo & "..."

        Dim lsFilename = lsUbicacion & sDS_ & lsNombreArchivo
        Dim loDataWriter As New StreamWriter(lsFilename)

        Dim loColumna As DataColumn
        Dim loDataRow As DataRow
        Dim lsLinea As String = ""
        Dim lsLinea2 As String = ""

        lsLinea = ""
        lsLinea2 = ""
        If piNumMod = -1 Then
            For Each loColumna In poDatos.Columns
                loFrmProcesamiento.lblRegistroLeido.Text = "Procesando Columna [" & loColumna.Ordinal & "] = " & loColumna.ColumnName
                loFrmProcesamiento.Refresh()
                If lsLinea.Trim.Length = 0 Then
                    lsLinea = loColumna.ColumnName
                Else
                    lsLinea &= lsSeparador & loColumna.ColumnName
                End If
                loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando Columna [" & loColumna.Ordinal & "] = " & loColumna.ColumnName
                loFrmProcesamiento.Refresh()
                Application.DoEvents()
            Next
        Else
            Dim loMapeo As DataTable = GFoRecuperaModelo(piNumMod)
            For Each loDataRow In loMapeo.Rows
                loFrmProcesamiento.lblRegistroLeido.Text = "Procesando Columna [" & loDataRow.Item("destino").ToString & "]"
                loFrmProcesamiento.Refresh()
                If lsLinea.Trim.Length = 0 Then
                    lsLinea = loDataRow.Item("destino").ToString
                    lsLinea2 = loDataRow.Item("origen").ToString
                Else
                    lsLinea &= lsSeparador & loDataRow.Item("destino").ToString
                    lsLinea2 &= lsSeparador & loDataRow.Item("origen").ToString
                End If
                loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando Columna [" & loDataRow.Item("destino").ToString & "]"
                loFrmProcesamiento.Refresh()
                Application.DoEvents()
            Next
        End If

        loDataWriter.WriteLine(lsLinea)
        GPBitacoraRegistrar(sMENSAJE_, "GFsExportaRecordSetToTexto --> Cabecera 1: " & lsLinea & vbCrLf & "Cabecera 2:" & lsLinea2)
        lsCabecera = lsLinea
        lsCabecera2 = lsLinea2

        For Each loDataRow In poDatos.Rows
            lsLinea = ""
            For Each loItem As DataColumn In loDataRow.Table.Columns
                loFrmProcesamiento.lblRegistroLeido.Text = "Leyendo Dato [" & loItem.Ordinal & "]->" & loItem.ColumnName & " = " & loDataRow.Item(loItem.ColumnName).ToString
                If InStr(lsCabecera, loItem.ColumnName, CompareMethod.Text) > 0 Then
                    If lsLinea.Trim.Length = 0 Then
                        lsLinea = loDataRow.Item(loItem.ColumnName).ToString.Trim
                    Else
                        lsLinea &= lsSeparador & loDataRow.Item(loItem.ColumnName).ToString.Trim
                    End If
                    loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando Dato [" & loItem.Ordinal & "]->" & loItem.ColumnName & " = " & loDataRow.Item(loItem.ColumnName).ToString
                    loFrmProcesamiento.Refresh()
                End If
                Application.DoEvents()
            Next
            loDataWriter.WriteLine(lsLinea)
            Application.DoEvents()
        Next
        loDataWriter.Close()
        loDataWriter.Dispose()
        loDataWriter = Nothing

        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing
        Application.DoEvents()

        GPBitacoraRegistrar(sMENSAJE_, "El archivo [" & psExtension.ToUpper & "] --> [" & lsNombreArchivo & "] ha sido creado exitosamente!. Su ubicacion: " & lsUbicacion)
        GPBitacoraRegistrar(sSALIO_, "GFsExportaRecordSetToTexto --> Datatable:" & poDatos.TableName & ", Nombre:" & psNombre & ", Extension: " & psExtension & ", Modelo:" & piNumMod.ToString)
        Application.DoEvents()
        Return lsFilename & sSF_ & lsCabecera
    End Function

End Module
