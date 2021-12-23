Imports System.IO
Module modGPImportarPlanCuenta

    Public Sub GPImportarPlanCuenta(ByVal piCodEmpresa As Integer)
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

        GPBitacoraRegistrar(sENTRO_, "Importacion de Plan de Cuentas. Empresa: " & piCodEmpresa.ToString & ", Archivo:" & lsFileName & ", Separador:" & lsSeparador)

        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Importando Archivo Texto " & lsFileName & "..."

        Dim loDataReader As StreamReader
        If InStr(lsFileName, sDS_) = 0 Then
            lsFileName = lsFileName.Replace("\", sDS_)
        End If
        loDataReader = My.Computer.FileSystem.OpenTextFileReader(lsFileName)

        Dim loB050 As New Eb050plancuentas
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
            loB050.codEmpresa = piCodEmpresa
            loB050.codCuenta = loDato.Item("codigo").ToString
            If loB050.GetPK = sSinRegistros_ Then
                loB050.codEmpresa = piCodEmpresa
                loB050.codCuenta = loDato.Item("codigo").ToString
                lsNombre = loDato.Item("nombre").ToString
                loB050.nombre = lsNombre.Trim
                loB050.nivel = loDato.Item("nivel").ToString
                loB050.tipo = loDato.Item("tipo").ToString
                loB050.estado = sImportado_
                loB050.Add(sNo_)
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
                lsMensajeError &= Now.ToString(sFormatoFechaHora2_) & ": Cuenta existente --> Codigo: " & loDato.Item("codigo").ToString & ", Nombre: " & loDato.Item("nombre").ToString & ", Tipo: " & loDato.Item("tipo").ToString & ", Nivel: " & loDato.Item("nivel").ToString & ", Estado: " & loDato.Item("estado").ToString & ControlChars.CrLf
            End If
        End While
        loB050.CerrarConexion()
        loB050 = Nothing

        loFrmProcesamiento.Close()
        loFrmProcesamiento = Nothing

        If lsMensajeError.Trim.Length > 0 Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(lsMensajeError)
            GFsAvisar(lsMensajeError, sMENSAJE_, "Tambien se ha copiado al Portapapeles.")
        Else
            GFsAvisar("La importacion del archivo " & lsFileName & " ha concluido exitosamente!", sMENSAJE_, "Acepte para continuar!")
        End If
        GPBitacoraRegistrar(sSALIO_, "Importacion de Plan de Cuentas. Empresa: " & piCodEmpresa.ToString & ", Archivo:" & lsFileName & ", Separador:" & lsSeparador)
    End Sub

End Module
