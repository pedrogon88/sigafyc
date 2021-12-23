Imports System.IO
Module modGFsValidarAsientosAImportar
    Private moDato As Hashtable
    Private moDataWriter As StreamWriter
    Private miCantErrores As Integer = 0
    Private msNombreArchivo As String = ""
    Private msUbicacion As String = ""

    Public Function GFsValidarAsientosAImportar(ByVal psFileName As String, ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, Optional pcSeparador As Char = sSF_, Optional pbEnviarCorreo As Boolean = True) As String
        GPBitacoraRegistrar(sENTRO_, "Validar Archivo de Asientos [" & psFileName & "] para Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & piCodSucursal.ToString & ", Con separador: " & pcSeparador)
        Dim lsResultado As String = sOk_
        Dim lsFileName As String = psFileName

        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Validando Archivo Texto " & lsFileName & ", para importar asientos..."

        Dim loDataReader As StreamReader
        If InStr(lsFileName, sDS_) = 0 Then
            lsFileName = lsFileName.Replace("\", sDS_)
        End If

        LPSeparaUbicacionArchivo(lsFileName)

        loDataReader = My.Computer.FileSystem.OpenTextFileReader(lsFileName)
        Dim lsLogname As String = msUbicacion & sDS_ & msNombreArchivo & ".log"
        moDataWriter = New StreamWriter(lsLogname)

        moDato = New Hashtable

        Dim loEmpresa As New Ec001empresas
        Dim loDocumento As New Ec020documentos
        Dim loMoneda As New Ea010monedas
        Dim loConcepto As New Eb020conceptos
        Dim loCuentas As New Eb050plancuentas

        Dim lsFecha As String = ""
        Dim liCodDocumento As Integer = 0
        Dim liCodConcepto As Integer = 0
        Dim lsCodCuenta As String = ""
        Dim lsCodMoneda_o As String = ""
        Dim lsCodMoneda_b As String = ""

        Dim lsLinea As String = ""
        Dim lsMensajeError As String = ""
        Dim lsCabecera() As String = Nothing
        Dim lsValor() As String = Nothing

        loEmpresa.codEmpresa = piCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
        End If


        lsLinea = loDataReader.ReadLine()
        pcSeparador = GFcDeterminaSeparador(lsLinea, pcSeparador)

        lsCabecera = lsLinea.Split(pcSeparador)
        miCantErrores = 0
        While True
            lsLinea = loDataReader.ReadLine()
            If String.IsNullOrEmpty(lsLinea) Then Exit While

            loFrmProcesamiento.lblRegistroLeido.Text = "Procesando [" & lsLinea & "]"
            loFrmProcesamiento.Refresh()
            lsValor = lsLinea.Split(pcSeparador)

            If moDato IsNot Nothing Then moDato.Clear()
            For I As Integer = 0 To lsCabecera.Length - 1
                moDato(lsCabecera(I)) = lsValor(I)
            Next

            lsMensajeError = "Registro: " & lsLinea
            LPRegistraLog(lsMensajeError)
            lsMensajeError = " |"
            LPRegistraLog(lsMensajeError)

            liCodDocumento = Integer.Parse(moDato("coddocumento").ToString)
            loDocumento.codEmpresa = piCodEmpresa
            loDocumento.codDocumento = liCodDocumento
            If loDocumento.GetPK = sSinRegistros_ Then
                lsMensajeError = " +-> @numero CodDocumento: " & liCodDocumento.ToString & ", no esta definido para la Empresa: " & piCodEmpresa.ToString
                LPRegistraLog(lsMensajeError)
            Else
                lsCodMoneda_o = moDato("codmoneda_o").ToString
                If loDocumento.codMoneda <> lsCodMoneda_o Then
                    lsMensajeError = " +-> @numero CodMoneda_o: " & lsCodMoneda_o & ", no coincide con la moneda del CodDocumento:" & liCodDocumento.ToString & "de la Empresa: " & piCodEmpresa.ToString
                    LPRegistraLog(lsMensajeError)
                End If
            End If

            lsCodMoneda_o = moDato("codmoneda_o").ToString
            loMoneda.codMoneda = lsCodMoneda_o
            If loMoneda.GetPK = sSinRegistros_ Then
                lsMensajeError = " +-> @numero CodMoneda_o: " & lsCodMoneda_o & ", no esta definido para la Empresa: " & piCodEmpresa.ToString
                LPRegistraLog(lsMensajeError)
            End If

            lsCodMoneda_b = moDato("codmoneda_b").ToString
            loMoneda.codMoneda = lsCodMoneda_b
            If loMoneda.GetPK = sSinRegistros_ Then
                lsMensajeError = " +-> @numero CodMoneda_b: " & lsCodMoneda_b & ", no esta definido para la Empresa: " & piCodEmpresa.ToString
                LPRegistraLog(lsMensajeError)
            End If

            If loEmpresa.codMoneda <> lsCodMoneda_b Then
                lsMensajeError = " +-> @numero CodMoneda_b:" & lsCodMoneda_b & ", no es la moneda base de la Empresa: " & piCodEmpresa.ToString
                LPRegistraLog(lsMensajeError)
            End If

            lsFecha = moDato("fecha").ToString
            If Not (lsFecha >= loEmpresa.periodoInicio And lsFecha <= loEmpresa.periodoFinal) Then
                lsMensajeError = " +-> @numero La fecha del asiento:" & lsFecha & ", esta fuera del rango definido " & loEmpresa.periodoInicio & " - " & loEmpresa.periodoFinal
                LPRegistraLog(lsMensajeError)
            End If

            liCodConcepto = Integer.Parse(moDato("codconcepto").ToString)
            If liCodConcepto > 0 Then
                loConcepto.codEmpresa = piCodEmpresa
                loConcepto.codConcepto = liCodConcepto
                If loConcepto.GetPK = sSinRegistros_ Then
                    lsMensajeError = " +-> @numero CodConcepto (cabecera): " & liCodConcepto.ToString & ", no esta definido para la Empresa: " & piCodEmpresa.ToString
                    LPRegistraLog(lsMensajeError)
                End If
            End If

            lsCodCuenta = moDato("codcuenta").ToString
            loCuentas.codEmpresa = piCodEmpresa
            loCuentas.codCuenta = lsCodCuenta
            If loCuentas.GetPK = sSinRegistros_ Then
                lsMensajeError = " +-> @numero CodCuenta: " & lsCodCuenta & ", no esta en el plan de cuentas de la Empresa: " & piCodEmpresa.ToString
                LPRegistraLog(lsMensajeError)
            Else
                If loCuentas.codCuenta.Substring(0, 1) = sIngreso_ Or loCuentas.codCuenta.Substring(0, 1) = sEgreso_ Then
                    If loEmpresa.ctaResultado1.Trim.Length = 0 Then
                        lsMensajeError = " +-> @numero La Empresa: " & piCodEmpresa.ToString & ", no tiene definido aun la cuenta de resultado."
                        LPRegistraLog(lsMensajeError)
                    End If
                End If
            End If

            liCodConcepto = Integer.Parse(moDato("codconcepto_d").ToString)
            If liCodConcepto > 0 Then
                loConcepto.codEmpresa = piCodEmpresa
                loConcepto.codConcepto = liCodConcepto
                If loConcepto.GetPK = sSinRegistros_ Then
                    lsMensajeError = " +-> @numero CodConcepto (detalle): " & liCodConcepto.ToString & ", no esta definido para la Empresa: " & piCodEmpresa.ToString
                    LPRegistraLog(lsMensajeError)
                    lsMensajeError = ""
                    LPRegistraLog(lsMensajeError)
                End If
            End If
            loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando [" & lsLinea & "]"
            loFrmProcesamiento.Refresh()
        End While

        lsMensajeError = "Cantidad de Errores: " & miCantErrores.ToString
        GPBitacoraRegistrar(sINFORMAR_, lsMensajeError)
        loEmpresa.CerrarConexion()
        loEmpresa = Nothing
        loDocumento.CerrarConexion()
        loDocumento = Nothing
        loMoneda.CerrarConexion()
        loMoneda = Nothing
        loConcepto.CerrarConexion()
        loConcepto = Nothing
        loCuentas.CerrarConexion()
        loCuentas = Nothing
        moDataWriter.Close()
        moDataWriter.Dispose()
        moDataWriter = Nothing

        If miCantErrores > 0 Then
            GFsAvisar(lsMensajeError, sMENSAJE_, "La importación no podrá realizarse.")
            If pbEnviarCorreo = True Then LPEnviarCorreo(lsFileName, lsLogname, lsMensajeError)
            lsResultado = sError_
        End If

        loFrmProcesamiento.Close()
        loFrmProcesamiento = Nothing

        GPBitacoraRegistrar(sSALIO_, "Validar Archivo de Asientos [" & psFileName & "] para Empresa: " & piCodEmpresa.ToString & ", Sucursal: " & piCodSucursal.ToString & ", Con separador: " & pcSeparador)
        Return lsResultado
    End Function

    Private Sub LPEnviarCorreo(ByVal psFileName As String, ByVal psLogName As String, ByVal psMensajeError As String)
        Dim loCorreo As New Correo
        Dim lsArchivoLog As String = msNombreArchivo & ".log"
        Dim lsFileNameLog As String = msUbicacion & sDS_ & lsArchivoLog
        Dim loAdjunto As New ArrayList
        loAdjunto.Add(lsArchivoLog & sSF_ & lsFileNameLog)
        loCorreo.archivosAdjuntos = loAdjunto
        loCorreo.asunto = "Log de Errores - Importacion Asiento - Archivo " & psFileName
        loCorreo.body = "Archivo adjunto: " & psLogName & ControlChars.CrLf & psMensajeError
        loCorreo.Enviar()
        loCorreo = Nothing
    End Sub

    Private Sub LPRegistraLog(ByVal psMensaje As String)
        If InStr(psMensaje, "@numero") > 0 Then
            miCantErrores += 1
            psMensaje = psMensaje.Replace("@numero", "Error #" & miCantErrores.ToString("D4") & ":")
            moDataWriter.WriteLine(psMensaje)
        Else
            moDataWriter.WriteLine(psMensaje)
        End If
    End Sub

    Private Sub LPSeparaUbicacionArchivo(ByVal psFileName As String)
        Dim lsPartes() As String = psFileName.Split("\"c)
        msNombreArchivo = lsPartes(lsPartes.Length - 1)
        msUbicacion = ""
        For Each lsParte As String In lsPartes
            If lsParte <> "" Then
                If lsParte <> msNombreArchivo Then
                    If msUbicacion.Trim.Length = 0 Then
                        msUbicacion = lsParte
                    Else
                        msUbicacion &= sDS_ & lsParte
                    End If
                End If
            End If
        Next
    End Sub

End Module
