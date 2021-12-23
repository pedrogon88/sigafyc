Imports System.IO
Imports System.Windows.Forms

Module modGPImportarAsientos
    Private miCodEmpresa As Integer = 0
    Private miCodSucursal As Integer = 0
    Private msFecha As String = ""
    Private miCodDocumento As Integer = 0
    Private msNroDocumento As String = ""
    Private msCodMoneda_o As String = ""
    Private msCodMoneda_b As String = ""
    Private miCodConcepto As Integer = 0
    Private msConcepto As String = ""
    Private msCotizacion As String = ""
    Private miCompra As Integer = 0
    Private miVenta As Integer = 0
    Private mdDebito_o As Decimal = 0.00D
    Private mdCredito_o As Decimal = 0.00D
    Private mdDebito_b As Decimal = 0.00D
    Private mdCredito_b As Decimal = 0.00D
    Private miAuxAsiento As Integer = 0
    Private miNroAsiento As Integer = 0
    Private miNroSecuencia As Integer = 0
    Private moCabAsiento As Ee010asientoscabeceras
    Private moDetAsiento As Ed010asientosdetalles
    Private moDato As Hashtable
    Private miCantAsientos As Integer = 0
    Private miCantMovimientos As Integer = 0

    Public Sub GPImportarAsientos(ByVal piCodEmpresa As Integer, Optional ByVal piCodSucursal As Integer = 1, Optional ByVal pbEnviarCorreo As Boolean = True)
        GPBitacoraRegistrar(sENTRO_, "Importar Asientos - Empresa:" & piCodEmpresa.ToString & ", Sucursal:" & piCodSucursal.ToString & ", Envio de Correo:" & pbEnviarCorreo.ToString)
        Dim loElegirArchivo As New OpenFileDialog
        Dim lsFileName As String = ""
        Dim lsUbicacion As String = ""

        Dim loResultado As DialogResult = loElegirArchivo.ShowDialog()
        If loResultado = DialogResult.OK Then
            lsFileName = loElegirArchivo.FileName
        Else
            GFsAvisar("Usted no ha seleccionado ningun archivo para la importación", sMENSAJE_, "Por lo cual este proceso será cancelado.")
            Exit Sub
        End If

        Dim lsSeparador As String = InputBox("Ingrese separador deseado", "Importación Asientos", sSF_)
        Dim lcSeparador() As Char = lsSeparador.Trim.ToArray

        If String.IsNullOrEmpty(lsSeparador) Then
            GFsAvisar("Usted no ha seleccionado un separador, de hecho cancelo", sMENSAJE_, "Por lo cual este proceso será cancelado.")
            Exit Sub
        End If

        If GFsValidarAsientosAImportar(lsFileName, piCodEmpresa, piCodSucursal, lcSeparador(0), pbEnviarCorreo) = sError_ Then
            GPBitacoraRegistrar(sINFORMAR_, "La validacion del archivo [" & lsFileName & "] tuvo errores. Por este motivo no pueden terminar de importarse los asientos")
            GPBitacoraRegistrar(sSALIO_, "Importar Asientos - Empresa:" & piCodEmpresa.ToString & ", Sucursal:" & piCodSucursal.ToString)
            Exit Sub
        End If

        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Importando Archivo Texto " & lsFileName & "..."

        Dim loDataReader As StreamReader
        If InStr(lsFileName, sDS_) = 0 Then
            lsFileName = lsFileName.Replace("\", sDS_)
        End If
        loDataReader = My.Computer.FileSystem.OpenTextFileReader(lsFileName)
        moDato = New Hashtable
        Dim lsLinea As String = ""
        Dim lsMensajeError As String = ""
        Dim lsCabecera() As String = Nothing
        Dim lsValor() As String = Nothing
        Dim lsNombre As String = ""
        Dim lbPrimero As Boolean = True

        lsLinea = loDataReader.ReadLine()
        lcSeparador(0) = GFcDeterminaSeparador(lsLinea, lcSeparador(0))

        lsCabecera = lsLinea.Split(lcSeparador(0))
        While True
            lsLinea = loDataReader.ReadLine()
            If String.IsNullOrEmpty(lsLinea) Then Exit While
            loFrmProcesamiento.lblRegistroLeido.Text = "Procesando [" & lsLinea & "]"
            loFrmProcesamiento.Refresh()

            lsValor = lsLinea.Split(lcSeparador(0))

            If moDato IsNot Nothing Then moDato.Clear()

            For I As Integer = 0 To lsCabecera.Length - 1
                moDato(lsCabecera(I)) = lsValor(I)
            Next
            If lbPrimero Then
                lbPrimero = False
                LPGuardarControl(piCodEmpresa, piCodSucursal)
            End If
            If miAuxAsiento <> Integer.Parse(moDato("nroasiento").ToString) Then
                LPCorteControl(piCodEmpresa, piCodSucursal)
                LPGuardarControl(piCodEmpresa, piCodSucursal)
            End If
            LPDetalle(piCodEmpresa, piCodSucursal)
            loFrmProcesamiento.lblRegistroProcesado.Text = "Procesando [" & lsLinea & "]"
        End While
        LPCorteControl(piCodEmpresa, piCodSucursal)

        loFrmProcesamiento.Close()
        loFrmProcesamiento = Nothing

        If lsMensajeError.Trim.Length > 0 Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(lsMensajeError)
            GFsAvisar(lsMensajeError, sMENSAJE_, "Tambien se ha copiado al Portapapeles.")
        Else
            Dim lsPeriodoInicio As String = ""
            Dim lsPeriodoFinal As String = ""
            Dim loEmpresa As New Ec001empresas
            loEmpresa.codEmpresa = piCodEmpresa
            If loEmpresa.GetPK = sOk_ Then
                lsPeriodoInicio = loEmpresa.periodoInicio
                lsPeriodoFinal = loEmpresa.periodoFinal
            End If
            loEmpresa.CerrarConexion()
            loEmpresa = Nothing
            GPReconstruccionCabAsiento(piCodEmpresa, piCodSucursal, lsPeriodoInicio, lsPeriodoFinal)
            GPReconstruccionSaldos(piCodEmpresa, piCodSucursal, lsPeriodoInicio, lsPeriodoFinal)
            GFsAvisar("La importacion del archivo " & lsFileName & " ha concluido exitosamente!", sMENSAJE_, "Acepte para continuar!")
        End If
        GPBitacoraRegistrar(sINFORMAR_, "Cantidad Asientos Importados: " & miCantAsientos.ToString)
        GPBitacoraRegistrar(sINFORMAR_, "Cantidad Movimientos Importados: " & miCantMovimientos.ToString)
        GPBitacoraRegistrar(sSALIO_, "Importar Asientos - Empresa:" & piCodEmpresa.ToString & ", Sucursal:" & piCodSucursal.ToString & ", Envio de Correo:" & pbEnviarCorreo.ToString)
    End Sub

    Private Sub LPGuardarControl(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer)
        miAuxAsiento = Integer.Parse(moDato("nroasiento").ToString)
        msFecha = moDato("fecha").ToString
        miCodDocumento = Integer.Parse(moDato("coddocumento").ToString)
        Dim loDocumento As New Ec020documentos
        loDocumento.codEmpresa = piCodEmpresa
        loDocumento.codDocumento = miCodDocumento
        If loDocumento.GetPK = sOk_ Then
            msCotizacion = loDocumento.cotizacion
        End If
        loDocumento.CerrarConexion()
        loDocumento = Nothing

        msNroDocumento = moDato("nrodocumento").ToString
        msCodMoneda_o = moDato("codmoneda_o").ToString
        msCodMoneda_b = moDato("codmoneda_b").ToString
        miCodConcepto = Integer.Parse(moDato("codconcepto").ToString)
        msConcepto = moDato("concepto").ToString
        msCotizacion = moDato("cotizacion").ToString
        miCompra = Integer.Parse(moDato("compra").ToString)
        miVenta = Integer.Parse(moDato("venta").ToString)
        mdDebito_o = 0.00D
        mdCredito_o = 0.00D
        mdDebito_b = 0.00D
        mdCredito_b = 0.00D

        moCabAsiento = New Ee010asientoscabeceras
        miNroAsiento = moCabAsiento.ReservarRegistro(piCodEmpresa)
    End Sub

    Private Sub LPCorteControl(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer)
        moCabAsiento.codEmpresa = piCodEmpresa
        moCabAsiento.nroAsiento = miNroAsiento
        If moCabAsiento.GetPK = sOk_ Then
            moCabAsiento.codEmpresa = piCodEmpresa
            moCabAsiento.nroAsiento = miNroAsiento
            moCabAsiento.codSucursal = piCodSucursal
            moCabAsiento.fecha = msFecha
            moCabAsiento.codDocumento = miCodDocumento
            moCabAsiento.nroDocumento = msNroDocumento
            moCabAsiento.codMoneda_o = msCodMoneda_o
            moCabAsiento.codMoneda_b = msCodMoneda_b
            moCabAsiento.codConcepto = miCodConcepto
            moCabAsiento.concepto = msConcepto
            moCabAsiento.cotizacion = msCotizacion
            moCabAsiento.compra = miCompra
            moCabAsiento.venta = miVenta
            moCabAsiento.debito_o = mdDebito_o
            moCabAsiento.credito_o = mdCredito_o
            moCabAsiento.debito_b = mdDebito_b
            moCabAsiento.credito_b = mdCredito_b
            moCabAsiento.estado = sImportado_
            Try
                moCabAsiento.Put(sNo_, sNo_, sAGREGAR_)
            Catch ex As Exception
                GFsAvisar("GPImportarAsientos.LPCorteControl", sMENSAJE_, ex.Message)
            End Try
        End If
        moCabAsiento.CerrarConexion()
        moCabAsiento = Nothing
        miCantAsientos += 1
    End Sub

    Private Sub LPDetalle(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer)
        moDetAsiento = New Ed010asientosdetalles
        moDetAsiento.codEmpresa = piCodEmpresa
        moDetAsiento.nroAsiento = miNroAsiento
        miNroSecuencia = moDetAsiento.ReservarRegistro(piCodEmpresa, miNroAsiento)
        moDetAsiento.nroSecuencia = miNroSecuencia
        moDetAsiento.codCuenta = moDato("codcuenta").ToString
        moDetAsiento.tipoMovimiento = moDato("tipomovimiento").ToString
        moDetAsiento.importe_mo = Decimal.Parse(moDato("importe_mo").ToString)
        moDetAsiento.importe_mb = Decimal.Parse(moDato("importe_mb").ToString)
        moDetAsiento.codConcepto = Integer.Parse(moDato("codconcepto_d").ToString)
        moDetAsiento.concepto = moDato("concepto_d").ToString
        moDetAsiento.estado = sImportado_
        Try
            moDetAsiento.Put(sNo_, sNo_, sAGREGAR_)
        Catch ex As Exception
            GFsAvisar("GPImportarAsientos.LPDetalle", sMENSAJE_, ex.Message)
        End Try
        Select Case moDato("tipomovimiento").ToString
            Case sDebito_
                mdDebito_o += Decimal.Parse(moDato("importe_mo").ToString)
                mdDebito_b += Decimal.Parse(moDato("importe_mb").ToString)
            Case sCredito_
                mdCredito_o += Decimal.Parse(moDato("importe_mo").ToString)
                mdCredito_b += Decimal.Parse(moDato("importe_mb").ToString)
        End Select
        miCantMovimientos += 1
        moDetAsiento.CerrarConexion()
        moDetAsiento = Nothing
    End Sub
End Module
