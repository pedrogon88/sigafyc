Imports System.IO

Module modGPImportarDocumentos

    Public Sub GPImportarDocumentos(ByVal piCodEmpresa As Integer)
        Dim loElegirArchivo As New OpenFileDialog
        Dim lsFileName As String = ""

        Dim loResultado As DialogResult = loElegirArchivo.ShowDialog()
        If loResultado = DialogResult.OK Then
            lsFileName = loElegirArchivo.FileName
        Else
            GFsAvisar("Usted no ha seleccionado ningun archivo para la importación", sMENSAJE_, "Por lo cual este proceso será cancelado.")
            Exit Sub
        End If

        Dim lsSeparador As String = InputBox("Ingrese separador deseado", "Importación Plan de Cuentas", sSF_)
        Dim lcSeparador() As Char = lsSeparador.Trim.ToArray

        If String.IsNullOrEmpty(lsSeparador) Then
            GFsAvisar("Usted no ha seleccionado un separador, de hecho cancelo", sMENSAJE_, "Por lo cual este proceso será cancelado.")
            Exit Sub
        End If

        GPBitacoraRegistrar(sENTRO_, "Importacion de Documentos. Empresa: " & piCodEmpresa.ToString & ", Archivo:" & lsFileName & ", Separador:" & lsSeparador)
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Importando Archivo Texto " & lsFileName & "..."

        Dim loDataReader As StreamReader
        If InStr(lsFileName, sDS_) = 0 Then
            lsFileName = lsFileName.Replace("\", sDS_)
        End If
        loDataReader = My.Computer.FileSystem.OpenTextFileReader(lsFileName)

        Dim loTabla As New Ec020documentos
        Dim lsLinea As String = ""
        Dim lsMensajeError As String = ""
        Dim lsCabecera() As String = Nothing
        Dim lsValor() As String = Nothing
        Dim lsNombre As String = ""
        Dim loDato As New Hashtable

        lsLinea = loDataReader.ReadLine()
        lcSeparador(0) = GFcDeterminaSeparador(lsLinea, lcSeparador(0))

        lsCabecera = lsLinea.Split(lcSeparador(0))
        While True
            lsLinea = loDataReader.ReadLine()
            If String.IsNullOrEmpty(lsLinea) Then Exit While
            loFrmProcesamiento.lblRegistroLeido.Text = "Procesando [" & lsLinea & "]"

            lsValor = lsLinea.Split(lcSeparador(0))
            If loDato IsNot Nothing Then loDato.Clear()

            For I As Integer = 0 To lsCabecera.Length - 1
                loDato(lsCabecera(I)) = lsValor(I)
            Next
            loTabla.codEmpresa = piCodEmpresa
            loTabla.codDocumento = Integer.Parse(loDato.Item("codigo").ToString)
            If loTabla.GetPK = sSinRegistros_ Then
                loTabla.codEmpresa = piCodEmpresa
                loTabla.codDocumento = Integer.Parse(loDato.Item("codigo").ToString)
                loTabla.tipo = loDato.Item("tipo").ToString
                loTabla.abreviado = loDato.Item("abreviado").ToString
                loTabla.nombre = loDato.Item("nombre").ToString
                loTabla.timbrado = loDato.Item("timbrado").ToString
                Dim loMoneda As New Ea010monedas
                loMoneda.codMoneda = loDato.Item("codmoneda").ToString
                If loMoneda.GetPK = sOk_ Then
                    loTabla.codMoneda = loDato.Item("codmoneda").ToString
                    loTabla.cotizacion = loDato.Item("cotizacion").ToString
                    loTabla.lineas = Integer.Parse(loDato.Item("lineas").ToString)
                    loTabla.estado = sImportado_
                    loTabla.Add(sNo_)
                Else
                    lsMensajeError &= Now.ToString(sFormatoFechaHora2_) & ": Moneda --> " & loDato.Item("codmoneda").ToString & ", no existe en la Empresa: " & piCodEmpresa & ControlChars.CrLf
                End If
                loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando [" & lsLinea & "]"
                loFrmProcesamiento.Refresh()
            Else
                If lsMensajeError.Trim.Length = 0 Then
                    lsMensajeError = "Log de Importacion Archivo: " & lsFileName & ControlChars.CrLf
                    lsMensajeError &= "Fecha/hora proceso: " & Now.ToString(sFormatoFechaHora1_) & ControlChars.CrLf
                    lsMensajeError &= "Usuario: " & SesionActiva.usuario & " - " & SesionActiva.loginAcceso & ControlChars.CrLf
                    lsMensajeError &= "Equipo: " & SesionActiva.equipo & " - " & SesionActiva.ip & " - " & SesionActiva.mac & ControlChars.CrLf
                    lsMensajeError &= "------------------------------------------------------------------------------------------" & ControlChars.CrLf
                End If
                lsMensajeError &= Now.ToString(sFormatoFechaHora2_) & ": Codigo existente --> Codigo: " & loDato.Item("codigo").ToString & ", Nombre: " & loDato.Item("nombre").ToString & ", Tipo: " & loDato.Item("tipo").ToString & ", Estado: " & loDato.Item("estado").ToString & ControlChars.CrLf
            End If
        End While
        loTabla.CerrarConexion()
        loTabla = Nothing

        loFrmProcesamiento.Close()
        loFrmProcesamiento = Nothing

        If lsMensajeError.Trim.Length > 0 Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(lsMensajeError)
            GFsAvisar(lsMensajeError, sMENSAJE_, "Tambien se ha copiado al Portapapeles.")
        Else
            GFsAvisar("La importacion del archivo " & lsFileName & " ha concluido exitosamente!", sMENSAJE_, "Acepte para continuar!")
        End If
        GPBitacoraRegistrar(sSALIO_, "Importacion de Documentos. Empresa: " & piCodEmpresa.ToString & ", Archivo:" & lsFileName & ", Separador:" & lsSeparador)
    End Sub

End Module
