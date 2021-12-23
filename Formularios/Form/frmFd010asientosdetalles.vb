Imports System.ComponentModel
Imports System.Data.Common
Imports System.Globalization

Public Class frmFd010asientosdetalles
    Private msValidado As String = ""
    Private msRequeridos As String() = {"codempresa", "nroasiento", "nrosecuencia", "codcuenta", "tipomovimiento", "importe_mo", "codconcepto", "concepto"}
    Private moRequeridos As New ArrayList(msRequeridos)
    Private miCuenta1 As Integer = 0
    Private miCuenta2 As Integer = 0
    Private miCuenta3 As Integer = 0
    Private miCuenta4 As Integer = 0
    Private miCuenta5 As Integer = 0
    Private miCuenta6 As Integer = 0
    Private msNivel As String
    Private msCodMoneda_mo As String = ""
    Private moEntidadCabecera As Object = Nothing

    Public Property entidadCabecera As Object
        Get
            Return moEntidadCabecera
        End Get
        Set(value As Object)
            moEntidadCabecera = value
        End Set
    End Property

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LPBorrarAlCancelar()
        Me.Tag = sCancelar_
        GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en CANCELAR.")
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim liNroAsiento As Integer = Integer.Parse(txtNroAsiento_NE.Text.ToString)
        Dim liCodigo As Integer = Integer.Parse(txtCodigo_NE.Text.ToString)
        If InStr(sCONSULTAR_ & sAGREGAR_ & sMODIFICAR_, Me.Tag.ToString) > 0 Then
            msValidado = ""
            For Each loControl As Control In Me.TabPage1.Controls
                If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                    msValidado &= loControl.Tag.ToString
                End If
            Next

            If InStr(msValidado, sCancelar_) > 0 Then
                GFsAvisar("Validacion final", sMENSAJE_, "No han sido ingresado correctamente todos los datos")
                txtCodigo_NE.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sAGREGAR_
                        Dim loDatos As New Ed010asientosdetalles
                        LPTruncaSegunLongitud()
                        loDatos.codEmpresa = liCodEmpresa
                        loDatos.nroAsiento = liNroAsiento
                        loDatos.nroSecuencia = liCodigo
                        loDatos.codCuenta = txtCodCuenta.Text
                        loDatos.tipoMovimiento = cmbTipo.Text.Substring(0, cmbTipo.MaxLength)
                        Dim ldImporte As Decimal = Decimal.Parse(txtImporte_mo_ND.AccessibleDescription.ToString)
                        loDatos.importe_mo = Decimal.Parse(ldImporte.ToString(sFormatF_))
                        Dim ldImporte_mb As Decimal = Decimal.Parse(txtImporte_mb_ND.AccessibleDescription.ToString)
                        loDatos.importe_mb = Decimal.Parse(ldImporte_mb.ToString(sFormatF_))
                        loDatos.codConcepto = Integer.Parse(txtCodConcepto_NE.Text.ToString)
                        loDatos.concepto = txtConcepto_AN.Text
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Put(sSi_, sSi_, sAGREGAR_, sSi_)
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim ldImporte_mb As Decimal = 0
                        Dim loDatos As New Ed010asientosdetalles
                        loDatos.codEmpresa = liCodEmpresa
                        loDatos.nroAsiento = liNroAsiento
                        loDatos.nroSecuencia = liCodigo
                        If loDatos.GetPK = sOk_ Then
                            Dim loAnterior As New Dd010asientosdetalles
                            loAnterior.codCuenta = loDatos.codCuenta
                            loAnterior.tipoMovimiento = loDatos.tipoMovimiento
                            loAnterior.importe_mb = loDatos.importe_mb
                            loAnterior.importe_mo = loDatos.importe_mo
                            LPTruncaSegunLongitud()
                            loDatos.codEmpresa = liCodEmpresa
                            loDatos.nroAsiento = liNroAsiento
                            loDatos.nroSecuencia = liCodigo
                            loDatos.codCuenta = txtCodCuenta.Text
                            loDatos.tipoMovimiento = cmbTipo.Text.Substring(0, cmbTipo.MaxLength)
                            Dim ldImporte As Decimal = Decimal.Parse(txtImporte_mo_ND.AccessibleDescription.ToString)
                            loDatos.importe_mo = Decimal.Parse(ldImporte.ToString(sFormatF_))
                            ldImporte_mb = Decimal.Parse(txtImporte_mb_ND.AccessibleDescription.ToString)
                            loDatos.importe_mb = Decimal.Parse(ldImporte_mb.ToString(sFormatF_))
                            loDatos.codConcepto = Integer.Parse(txtCodConcepto_NE.Text.ToString)
                            loDatos.concepto = txtConcepto_AN.Text
                            If cmbEstado.Text.Trim.Length > 0 Then
                                loDatos.estado = cmbEstado.Text
                            End If
                            loDatos.Put(sSi_, sSi_, "", sSi_, loAnterior)
                            loAnterior = Nothing
                        End If
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                End Select
                Me.Tag = sOk_
                '-->  .AccesibleName envia al Browse la información del codigo que luego deberia 
                '-->  ser usado para la localización del registro en el DataGridView
                Me.AccessibleName = txtCodigo_NE.Text
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        Else
            If Me.Tag.ToString = sBORRAR_ Then
                Dim loDatos As New Ed010asientosdetalles
                loDatos.codEmpresa = liCodEmpresa
                loDatos.nroAsiento = liNroAsiento
                loDatos.nroSecuencia = liCodigo
                If loDatos.GetPK = sOk_ Then
                    loDatos.codEmpresa = liCodEmpresa
                    loDatos.nroAsiento = liNroAsiento
                    loDatos.nroSecuencia = liCodigo
                    Dim lsCodCuenta As String = loDatos.codCuenta
                    Dim ldImporte_mb As Decimal = loDatos.importe_mb
                    loDatos.Del(sSi_, sSi_, sSi_)
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
            End If
            Me.Tag = sOk_
            GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
            Me.Close()
        End If
    End Sub

    Private Sub Cuentas_Validating(sender As Object, e As CancelEventArgs)
        If CType(sender, Control).Text.Trim.Length = 0 Then
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).AccessibleName
            End Select
            CType(sender, Control).Text = lsValorInicial
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoTextBox_ Then
                CType(sender, TextBox).SelectAll()
            End If
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "cuenta1"
                    msNivel = "1"
                    If IsNumeric(txtCuenta1_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 1 - debe ser numerico", sMENSAJE_, "Valores de 1 - 7:" & ControlChars.CrLf & "1-Activo" & ControlChars.CrLf & "2-Pasivo" & ControlChars.CrLf & "3-Patrimonio neto" & ControlChars.CrLf & "4-Cuentas orden activas" & ControlChars.CrLf & "5-Cuentas orden pasivas" & ControlChars.CrLf & "6-Ingresos" & ControlChars.CrLf & "7-Egresos")
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta1 = Integer.Parse(txtCuenta1_NE.Text.ToString)
                    If Not (miCuenta1 >= 1 And miCuenta1 <= 7) Then
                        GFsAvisar("Codigo Nivel 1 - no valido", sMENSAJE_, "Valores de 1 - 7:" & ControlChars.CrLf & "1-Activo" & ControlChars.CrLf & "2-Pasivo" & ControlChars.CrLf & "3-Patrimonio neto" & ControlChars.CrLf & "4-Cuentas orden activas" & ControlChars.CrLf & "5-Cuentas orden pasivas" & ControlChars.CrLf & "6-Ingresos" & ControlChars.CrLf & "7-Egresos")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta1_NE.Text.ToString)
                        txtCuenta1_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta2"
                    msNivel = "2"
                    If IsNumeric(txtCuenta2_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 2 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta2 = Integer.Parse(txtCuenta2_NE.Text.ToString)
                    If Not (miCuenta2 >= 1 And miCuenta2 <= 99) Then
                        GFsAvisar("Codigo Nivel 2 - no valido", sMENSAJE_, "Valores de 1 - 99")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta2_NE.Text.ToString)
                        txtCuenta2_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta3"
                    msNivel = "3"
                    If IsNumeric(txtCuenta3_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 3 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta3 = Integer.Parse(txtCuenta3_NE.Text.ToString)
                    If Not (miCuenta3 >= 1 And miCuenta3 <= 999) Then
                        GFsAvisar("Codigo Nivel 3 - no valido", sMENSAJE_, "Valores de 1 - 999")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta3_NE.Text.ToString)
                        txtCuenta3_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta4"
                    msNivel = "4"
                    If IsNumeric(txtCuenta4_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 4 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta4 = Integer.Parse(txtCuenta4_NE.Text.ToString)
                    If Not (miCuenta4 >= 1 And miCuenta4 <= 9999) Then
                        GFsAvisar("Codigo Nivel 4 - no valido", sMENSAJE_, "Valores de 1 - 9999")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta4_NE.Text.ToString)
                        txtCuenta4_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & txtCuenta4_NE.Text & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta5"
                    msNivel = "5"
                    If IsNumeric(txtCuenta5_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 5 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta5 = Integer.Parse(txtCuenta5_NE.Text.ToString)
                    If Not (miCuenta5 >= 1 And miCuenta5 <= 99999) Then
                        GFsAvisar("Codigo Nivel 5 - no valido", sMENSAJE_, "Valores de 1 - 99999")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta5_NE.Text.ToString)
                        txtCuenta5_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & txtCuenta4_NE.Text & sSeparador_ & txtCuenta5_NE.Text & sSeparador_ & sCero6_
                Case "cuenta6"
                    msNivel = "6"
                    If IsNumeric(txtCuenta6_NE.Text) = False Then
                        GFsAvisar("Codigo Nivel 6 - debe ser numerico", sMENSAJE_)
                        e.Cancel = True
                        Exit Sub
                    End If
                    miCuenta6 = Integer.Parse(txtCuenta6_NE.Text.ToString)
                    If Not (miCuenta6 >= 1 And miCuenta6 <= 999999) Then
                        GFsAvisar("Codigo Nivel 6 - no valido", sMENSAJE_, "Valores de 1 - 999999")
                        e.Cancel = True
                        Exit Sub
                    Else
                        miCuenta1 = Integer.Parse(txtCuenta6_NE.Text.ToString)
                        txtCuenta6_NE.Text = miCuenta1.ToString(sFormatD_ & msNivel)
                    End If
                    txtCodCuenta.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & txtCuenta4_NE.Text & sSeparador_ & txtCuenta5_NE.Text & sSeparador_ & txtCuenta6_NE.Text
            End Select
            Dim lsTipoCuenta As String = ""
            If InStr(CType(sender, Control).AccessibleName, "cuenta") > 0 Then
                Dim loFK1 As New Eb050plancuentas
                Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                Dim lsCodCuenta As String = txtCodCuenta.Text
                loFK1.codEmpresa = liCodEmpresa
                loFK1.codCuenta = lsCodCuenta
                If loFK1.GetPK = sOk_ Then
                    lsTipoCuenta = loFK1.tipo
                    If loFK1.tipo = sImputable_.Substring(0, 1) Then
                        LPOcultaNivelesInferior(loFK1.nivel)
                        cmbTipo.Focus()
                    End If
                Else
                    Dim loLookUp As New frmBb050plancuentas
                    loLookUp.Tag = sELEGIR_
                    loLookUp.codEmpresa = liCodEmpresa
                    GPCargar(loLookUp)
                    If loLookUp.entidad IsNot Nothing Then
                        txtCodCuenta.Text = CType(loLookUp.entidad, Eb050plancuentas).codCuenta
                        lsTipoCuenta = CType(loLookUp.entidad, Eb050plancuentas).tipo
                        If lsTipoCuenta = sTotales_.Substring(0, 1) Then
                            GFsAvisar("La Cuenta [" & txtCodCuenta.Text & "] no es IMPUTABLE", sMENSAJE_, "Los movimientos contable no puede realizarse con cuentas de TOTALES.")
                            e.Cancel = True
                            Exit Sub
                        End If
                        LPParseaPartesCuenta()
                        LPOcultaNivelesInferior(CType(loLookUp.entidad, Eb050plancuentas).nivel)
                        LPCuentaFocus(CType(loLookUp.entidad, Eb050plancuentas).nivel)
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                    loLookUp = Nothing
                End If
                If txtCodCuenta.Text.Substring(0, 1) = "6" Or txtCodCuenta.Text.Substring(0, 1) = "7" Then
                    If GFsDefinidoCuentaResultado(liCodEmpresa) = sNo_ Then
                        GFsAvisar("Las cuentas de resultados aun no han sido definidas para la Empresa No. [" & txtCodEmpresa_NE.Text & "]. A continuación se le va presentar el Browse de Empresas para que lo haga.", sMENSAJE_, "Debe realizar esta definición para poder ingresar movimiento con cuentas de Ingreso o Egreso.")
                        Dim loEmpresa As New frmBc001empresas
                        GPCargar(loEmpresa)
                        loEmpresa = Nothing
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
            LPDespliegaDescripciones()
        End If
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()
        ' Inicializa los controles de edición con los valores pertinentes
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls
        msEntidad = "movimiento contable"
        DesplegarMensaje()
        Dim liCodEmpresa As Integer = CType(entidadCabecera, Ee010asientoscabeceras).codEmpresa
        Dim liCodDocumento As Integer = CType(entidadCabecera, Ee010asientoscabeceras).codDocumento

        Dim loEmpresa As New Ec001empresas
        loEmpresa.codEmpresa = liCodEmpresa
        If loEmpresa.GetPK = sOk_ Then
            Dim loDocumento As New Ec020documentos
            loDocumento.codEmpresa = liCodEmpresa
            loDocumento.codDocumento = liCodDocumento
            If loDocumento.GetPK = sOk_ Then
                If loEmpresa.codMoneda = loDocumento.codMoneda Then
                    lblCotizacion.Visible = False
                    lblImporte_mb.Visible = False
                    txtImporte_mb_ND.Visible = False
                Else
                    lblCotizacion.Visible = True
                    lblImporte_mb.Visible = True
                    txtImporte_mb_ND.Visible = True
                End If
            End If
        End If

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                txtCodEmpresa_NE.Text = CType(entidad, Ed010asientosdetalles).codEmpresa.ToString
                txtNroAsiento_NE.Text = CType(entidad, Ed010asientosdetalles).nroAsiento.ToString
                Dim loDatos As New Ed010asientosdetalles
                txtCodigo_NE.Text = loDatos.ReservarRegistro(Integer.Parse(txtCodEmpresa_NE.Text.ToString), Integer.Parse(txtNroAsiento_NE.Text.ToString)).ToString
                lblImporte_mo.Text = "0"
                loDatos.CerrarConexion()
                loDatos = Nothing

            Case Else
                txtCodEmpresa_NE.Text = CType(entidad, Ed010asientosdetalles).codEmpresa.ToString
                txtNroAsiento_NE.Text = CType(entidad, Ed010asientosdetalles).nroAsiento.ToString
                txtCodigo_NE.Text = CType(entidad, Ed010asientosdetalles).nroSecuencia.ToString
                txtCodCuenta.Text = CType(entidad, Ed010asientosdetalles).codCuenta
                cmbTipo.Text = CType(entidad, Ed010asientosdetalles).tipoMovimiento
                txtImporte_mo_ND.Text = CType(entidad, Ed010asientosdetalles).importe_mo.ToString
                txtImporte_mo_ND.AccessibleDescription = CType(entidad, Ed010asientosdetalles).importe_mo.ToString
                txtImporte_mb_ND.Text = CType(entidad, Ed010asientosdetalles).importe_mb.ToString
                txtImporte_mb_ND.AccessibleDescription = CType(entidad, Ed010asientosdetalles).importe_mb.ToString
                txtCodConcepto_NE.Text = CType(entidad, Ed010asientosdetalles).codConcepto.ToString
                txtConcepto_AN.Text = CType(entidad, Ed010asientosdetalles).concepto
                cmbEstado.Text = CType(entidad, Ed010asientosdetalles).estado
        End Select

        lblNombreEmpresa.Text = ""
        lblNombreCuenta.Text = ""
        lblCotizacion.Text = ""

        ' Habilita o deshabilita los controles de edición
        txtCodEmpresa_NE.Enabled = True
        txtNroAsiento_NE.Enabled = True
        txtCodigo_NE.Enabled = True
        txtCodCuenta.Enabled = True
        cmbTipo.Enabled = True
        txtImporte_mo_ND.Enabled = True
        txtCodConcepto_NE.Enabled = True
        txtConcepto_AN.Enabled = True
        cmbEstado.Enabled = True

        txtCodEmpresa_NE.AccessibleName = "codempresa"
        txtNroAsiento_NE.AccessibleName = "nroasiento"
        txtCodigo_NE.AccessibleName = "codigo"
        txtCodCuenta.AccessibleName = "codcuenta"
        txtCuenta1_NE.AccessibleName = "cuenta1"
        txtCuenta2_NE.AccessibleName = "cuenta2"
        txtCuenta3_NE.AccessibleName = "cuenta3"
        txtCuenta4_NE.AccessibleName = "cuenta4"
        txtCuenta5_NE.AccessibleName = "cuenta5"
        txtCuenta6_NE.AccessibleName = "cuenta6"
        cmbTipo.AccessibleName = "tipomovimiento"
        txtImporte_mo_ND.AccessibleName = "importe_mo"
        txtCodConcepto_NE.AccessibleName = "codconcepto"
        txtConcepto_AN.AccessibleName = "concepto"
        cmbEstado.AccessibleName = "estado"

        lblImporte_mo.Size = txtImporte_mo_ND.Size
        lblImporte_mo.Location = txtImporte_mo_ND.Location
        lblImporte_mo.BackColor = Me.BackColor

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtCodEmpresa_NE.Enabled = False
                txtNroAsiento_NE.Enabled = False
                txtCodigo_NE.Enabled = False

            Case sMODIFICAR_
                txtCodEmpresa_NE.Enabled = False
                txtNroAsiento_NE.Enabled = False
                txtCodigo_NE.Enabled = False
                LPParseaPartesCuenta()
                Dim lsNivel As String = LFsDeterminaNivel()
                LPOcultaNivelesInferior(lsNivel)

            Case sCONSULTAR_, sBORRAR_
                LPParseaPartesCuenta()
                LPOcultaNivelesInferior(LFsDeterminaNivel)

                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
                loControls = Me.TabPage2.Controls
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.Substring(0, 3)) > 0 Then
                        loControls.Item(liNDX).Enabled = False
                    End If
                Next
        End Select
        LPDespliegaDescripciones()
    End Sub

    Private Sub LPOcultaNivelesInferior(ByVal psNivel As String)
        txtCuenta1_NE.Visible = True
        txtCuenta2_NE.Visible = True
        txtCuenta3_NE.Visible = True
        txtCuenta4_NE.Visible = True
        txtCuenta5_NE.Visible = True
        txtCuenta6_NE.Visible = True
        Select Case psNivel
            Case "2"
                txtCuenta3_NE.Visible = False
                txtCuenta4_NE.Visible = False
                txtCuenta5_NE.Visible = False
                txtCuenta6_NE.Visible = False
            Case "3"
                txtCuenta4_NE.Visible = False
                txtCuenta5_NE.Visible = False
                txtCuenta6_NE.Visible = False
            Case "4"
                txtCuenta5_NE.Visible = False
                txtCuenta6_NE.Visible = False
            Case "5"
                txtCuenta6_NE.Visible = False
        End Select
        txtCodCuenta.Visible = False
    End Sub

    Private Sub LPParseaPartesCuenta()
        txtCuenta1_NE.Text = txtCodCuenta.Text.Substring(0, sCero1_.Length)
        txtCuenta2_NE.Text = txtCodCuenta.Text.Substring(2, sCero2_.Length)
        txtCuenta3_NE.Text = txtCodCuenta.Text.Substring(5, sCero3_.Length)
        txtCuenta4_NE.Text = txtCodCuenta.Text.Substring(9, sCero4_.Length)
        txtCuenta5_NE.Text = txtCodCuenta.Text.Substring(14, sCero5_.Length)
        txtCuenta6_NE.Text = txtCodCuenta.Text.Substring(20, sCero6_.Length)
    End Sub

    Private Function LFsDeterminaNivel() As String
        Dim lsNivel As String = ""
        If txtCuenta5_NE.Text <> sCero5_ Then
            lsNivel = "5"
        Else
            If txtCuenta4_NE.Text <> sCero4_ Then
                lsNivel = "4"
            Else
                If txtCuenta3_NE.Text <> sCero3_ Then
                    lsNivel = "3"
                Else
                    If txtCuenta2_NE.Text <> sCero2_ Then
                        lsNivel = "2"
                    Else
                        If txtCuenta1_NE.Text <> sCero1_ Then
                            lsNivel = "1"
                        Else
                            lsNivel = "6"
                        End If
                    End If
                End If
            End If
        End If
        Return lsNivel
    End Function

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtCuenta1_NE.Focus()
            Case sMODIFICAR_
                LPCuentaFocus(msNivel)
        End Select
    End Sub

    Private Sub LPCuentaFocus(Optional ByVal psNivel As String = "1")
        Select Case psNivel
            Case "1"
                txtCuenta1_NE.Focus()
            Case "2"
                txtCuenta2_NE.Focus()
            Case "3"
                txtCuenta3_NE.Focus()
            Case "4"
                txtCuenta4_NE.Focus()
            Case "5"
                txtCuenta5_NE.Focus()
            Case "6"
                txtCuenta6_NE.Focus()
        End Select
    End Sub

    Private Sub LPDespliegaDescripciones()
        Dim liCodEmpresa As Integer = 0
        Dim liNroAsiento As Integer = 0
        Dim lsFecha As String = ""
        Dim liCodigo As Integer = 0
        Dim liCodConcepto As Integer = 0
        Dim lsDecimales As String = ""
        Dim lsCulture As String = ""
        Dim lsDecimales_b As String = ""
        Dim lsCulture_b As String = ""
        Dim lsMoneda As String = ""
        Dim lsMoneda_b As String = ""
        Dim lsCotizacion As String = ""
        Dim lsCodCuenta As String = txtCodCuenta.Text
        If lsCodCuenta.Trim.Length = 0 Then
            txtCodCuenta.Text = sCero1_ & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
        End If
        Me.Refresh()
        lblImporte.Text = "Importe:"
        Dim loA010 As New Ea010monedas
        loA010.codMoneda = CType(entidadCabecera, Ee010asientoscabeceras).codMoneda_o
        If loA010.GetPK = sOk_ Then
            lsMoneda = loA010.codMoneda
            lsDecimales = loA010.decimales.ToString
            lsCulture = loA010.culture
            lblImporte.Text = "Importe en " & lsMoneda & ":"
        End If
        loA010.CerrarConexion()
        loA010 = Nothing
        lblImporte.Refresh()

        lblImporte_mb.Text = ""
        lblNombreEmpresa.Text = ""
        If txtCodEmpresa_NE.Text.Trim.Length > 0 Then
            liCodEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
            Dim loFK As New Ec001empresas
            loFK.codEmpresa = liCodEmpresa
            If loFK.GetPK = sOk_ Then
                lblNombreEmpresa.Text = loFK.nombre
                lsMoneda_b = loFK.codMoneda
                Dim loMoneda As New Ea010monedas
                loMoneda.codMoneda = loFK.codMoneda
                If loMoneda.GetPK = sOk_ Then
                    lsDecimales_b = loMoneda.decimales.ToString
                    lsCulture_b = loMoneda.culture
                End If
                lblImporte_mb.Text = "Importe en " & lsMoneda_b
            End If
            loFK.CerrarConexion()
            loFK = Nothing
            txtCodEmpresa_NE.Text = liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength)
        End If
        lblImporte_mb.Refresh()
        lblNombreEmpresa.Refresh()
        txtCodEmpresa_NE.Refresh()

        lblNombreCuenta.Text = ""
        If lsCodCuenta.Trim.Length > 0 Then
            Dim loFK1 As New Eb050plancuentas
            liCodEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
            loFK1.codEmpresa = liCodEmpresa
            loFK1.codCuenta = lsCodCuenta
            If loFK1.GetPK = sOk_ Then
                lblNombreCuenta.Text = loFK1.nombre
            End If
            msNivel = loFK1.nivel
            loFK1.CerrarConexion()
            loFK1 = Nothing
        End If
        lblNombreCuenta.Refresh()

        lblCotizacion.Text = ""
        lsFecha = CType(entidadCabecera, Ee010asientoscabeceras).fecha
        lsCotizacion = CType(entidadCabecera, Ee010asientoscabeceras).cotizacion
        Dim liCotizacion() As Integer = GFiCotizacion(lsMoneda, lsMoneda_b, lsFecha)
        lblCotizacion.Text = "Cotizacion [" & lsCotizacion & "]: "
        Select Case lsCotizacion
            Case sCompra_
                lblCotizacion.Text &= liCotizacion(0).ToString
            Case sVenta_
                lblCotizacion.Text &= liCotizacion(1).ToString
            Case sSemisuma_
                lblCotizacion.Text &= ((liCotizacion(0) + liCotizacion(1)) \ 2).ToString
        End Select
        lblCotizacion.Text &= " " & lsMoneda_b & "/" & lsMoneda
        lblCotizacion.Refresh()


        If txtImporte_mo_ND.Text.Trim.Length > 0 Then
            Dim ldImporte As Decimal = 0.00D
            Dim ldImporte_mb As Decimal = 0.00D
            If IsNumeric(txtImporte_mo_ND.Text) Then
                ldImporte = Decimal.Parse(txtImporte_mo_ND.Text.ToString)
                lblImporte_mo.Text = ldImporte.ToString(sFormatC_ & lsDecimales, CultureInfo.CreateSpecificCulture(lsCulture))
                txtImporte_mo_ND.AccessibleDescription = ldImporte.ToString '(sFormatF_ & lsDecimales)
                txtImporte_mo_ND.ReadOnly = True
                lblImporte_mo.Visible = True
            End If
            If txtImporte_mo_ND.AccessibleDescription Is Nothing Then
                If IsNumeric(txtImporte_mo_ND.Text) Then
                    ldImporte = Decimal.Parse(txtImporte_mo_ND.AccessibleDescription.ToString)
                    txtImporte_mo_ND.AccessibleDescription = ldImporte.ToString '(sFormatF_ & lsDecimales)
                End If
            End If
            ldImporte_mb = GFdImporte_mb(liCodEmpresa, ldImporte, lsMoneda, lsFecha, lsCotizacion)
            txtImporte_mb_ND.Text = ldImporte_mb.ToString(sFormatC_ & lsDecimales_b, CultureInfo.CreateSpecificCulture(lsCulture_b))
            txtImporte_mb_ND.AccessibleDescription = ldImporte_mb.ToString '(sFormatF_ & lsDecimales_b)
        End If
        txtImporte_mb_ND.Refresh()

        Select Case cmbTipo.Text
            Case sDebito_.Substring(0, cmbTipo.MaxLength)
                cmbTipo.Text = sDebito_
            Case sCredito_.Substring(0, cmbTipo.MaxLength)
                cmbTipo.Text = sCredito_
        End Select
        If IsNumeric(txtNroAsiento_NE.Text) = True Then
            liNroAsiento = Integer.Parse(txtNroAsiento_NE.Text.ToString)
            txtNroAsiento_NE.Text = liNroAsiento.ToString(sFormatD_ & txtNroAsiento_NE.MaxLength.ToString)
        End If
        If IsNumeric(txtCodigo_NE.Text) = True Then
            liCodigo = Integer.Parse(txtCodigo_NE.Text.ToString)
            txtCodigo_NE.Text = liCodigo.toString(sFormatD_ & txtCodigo_NE.MaxLength.ToString)
        End If
        If IsNumeric(txtCodConcepto_NE.Text) = True Then
            liCodConcepto = Integer.Parse(txtCodConcepto_NE.Text.ToString)
            txtCodConcepto_NE.Text = liCodConcepto.ToString(sFormatD_ & txtCodConcepto_NE.MaxLength)
        End If
    End Sub

    Private Sub LPInicializaMaxLength()
        txtCodEmpresa_NE.MaxLength = 6
        txtNroAsiento_NE.MaxLength = 6
        txtCodigo_NE.MaxLength = 3
        txtCodCuenta.MaxLength = 26
        txtCuenta1_NE.MaxLength = 1
        txtCuenta2_NE.MaxLength = 2
        txtCuenta3_NE.MaxLength = 3
        txtCuenta4_NE.MaxLength = 4
        txtCuenta5_NE.MaxLength = 5
        txtCuenta6_NE.MaxLength = 6
        cmbTipo.MaxLength = 1
        txtImporte_mo_ND.MaxLength = 15
        txtCodConcepto_NE.MaxLength = 3
        txtConcepto_AN.MaxLength = 256
        cmbEstado.MaxLength = 15
    End Sub

    Private Sub LPInicializaControles()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                            AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                        Case sPrefijoComboBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                    End Select
                Next
            End If
        Next
        AddHandler txtCuenta1_NE.Validating, AddressOf Cuentas_Validating
        AddHandler txtCuenta2_NE.Validating, AddressOf Cuentas_Validating
        AddHandler txtCuenta3_NE.Validating, AddressOf Cuentas_Validating
        AddHandler txtCuenta4_NE.Validating, AddressOf Cuentas_Validating
        AddHandler txtCuenta5_NE.Validating, AddressOf Cuentas_Validating
        AddHandler txtCuenta6_NE.Validating, AddressOf Cuentas_Validating
    End Sub

    Private Function LFsExiste(ByVal psCampo As String) As String
        Dim lsResultado As String = sNo_
        For Each lsCampo As String In moRequeridos
            If psCampo = lsCampo Then
                lsResultado = sSi_
                Exit For
            End If
        Next
        Return lsResultado
    End Function

    Private Sub LPBorrarAlCancelar()
        If Me.Tag.ToString <> sAGREGAR_ Then Exit Sub

        Dim loDatos As New Ed010asientosdetalles
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim liNroAsiento As Integer = Integer.Parse(txtNroAsiento_NE.Text.ToString)
        Dim liCodigo As Integer = Integer.Parse(txtCodigo_NE.Text.ToString)
        loDatos.codEmpresa = liCodEmpresa
        loDatos.nroAsiento = liNroAsiento
        loDatos.nroSecuencia = liCodigo
        If loDatos.GetPK = sOk_ Then
            loDatos.codEmpresa = liCodEmpresa
            loDatos.nroAsiento = liNroAsiento
            loDatos.nroSecuencia = liCodigo
            loDatos.Del(sNo_, sNo_)
        End If
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub txtImporte_mo_ND_GotFocus(sender As Object, e As EventArgs) Handles txtImporte_mo_ND.GotFocus
        lblImporte_mo.Visible = False
        lblImporte_mo.Refresh()
        txtImporte_mo_ND.ReadOnly = False
        txtImporte_mo_ND.Refresh()
        txtImporte_mo_ND.SelectAll()
    End Sub

    Private Sub opcRecuperarAnterior_Click(sender As Object, e As EventArgs) Handles opcRecuperarAnterior.Click
        txtCodConcepto_NE.Text = CType(entidadCabecera, Ee010asientoscabeceras).codConcepto.ToString
        txtConcepto_AN.Text = CType(entidadCabecera, Ee010asientoscabeceras).concepto
    End Sub

    Private Sub lblImporte_mo_Click(sender As Object, e As EventArgs) Handles lblImporte_mo.Click
        lblImporte_mo.Visible = False
        txtImporte_mo_ND.ReadOnly = False
        txtImporte_mo_ND.Focus()
    End Sub

    Private Sub cmbTipo_Validating(sender As Object, e As CancelEventArgs) Handles cmbTipo.Validating
        If cmbTipo.Text.Trim.Length = 0 Then
            Dim ldValor As Decimal = CType(entidadCabecera, Ee010asientoscabeceras).debito_o - CType(entidadCabecera, Ee010asientoscabeceras).credito_o
            If ldValor > 0 Then
                cmbTipo.Text = sCredito_
            Else
                If ldValor <= 0 Then
                    cmbTipo.Text = sDebito_
                End If
            End If
            cmbTipo.Tag = sCancelar_
            e.Cancel = True
            Exit Sub
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub txtCodConcepto_NE_Validating(sender As Object, e As CancelEventArgs) Handles txtCodConcepto_NE.Validating
        If txtCodConcepto_NE.Text.Trim.Length = 0 Then
            txtCodConcepto_NE.Text = CType(entidadCabecera, Ee010asientoscabeceras).codConcepto.ToString
            txtConcepto_AN.SelectAll()
            txtConcepto_AN.Tag = sCancelar_
            e.Cancel = True
            Exit Sub
        End If
        If IsNumeric(txtCodConcepto_NE.Text) = False Then
            txtCodConcepto_NE.Text = StrDup(txtCodConcepto_NE.MaxLength, sCero1_)
            e.Cancel = True
            Exit Sub
        End If
        Dim liCodConcepto As Integer = Integer.Parse(txtCodConcepto_NE.Text.ToString)
        If liCodConcepto > 0 Then
            Dim loFK As New Eb020conceptos
            Dim lsResultado As String = ""
            loFK.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
            loFK.codConcepto = Integer.Parse(txtCodConcepto_NE.Text.ToString)
            lsResultado = loFK.GetPK
            loFK.CerrarConexion()
            loFK = Nothing
            If lsResultado <> sOk_ Then
                Dim loLookUp As New frmBb020conceptos
                loLookUp.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                loLookUp.Tag = sELEGIR_
                GPCargar(loLookUp)
                If loLookUp.entidad IsNot Nothing Then
                    txtCodConcepto_NE.Text = CType(loLookUp.entidad, Eb020conceptos).codConcepto.ToString
                Else
                    e.Cancel = True
                    Exit Sub
                End If
                loLookUp = Nothing
            End If

            If Me.Tag.ToString = sAGREGAR_ Then
                txtConcepto_AN.Text = loFK.descripcion
                txtConcepto_AN.Tag = txtConcepto_AN.Text
            End If
            If loFK.tipo = sFijo_ Then
                txtConcepto_AN.Enabled = False
            Else
                txtConcepto_AN.Enabled = True
                txtConcepto_AN.Focus()
            End If
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub txtConcepto_AN_Validating(sender As Object, e As CancelEventArgs) Handles txtConcepto_AN.Validating
        If txtConcepto_AN.Text.Trim.Length = 0 Then
            txtCodConcepto_NE.Text = CType(entidadCabecera, Ee010asientoscabeceras).codConcepto.ToString
            txtConcepto_AN.Text = CType(entidadCabecera, Ee010asientoscabeceras).concepto
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub txtImporte_mo_ND_Validating(sender As Object, e As CancelEventArgs) Handles txtImporte_mo_ND.Validating
        If txtImporte_mo_ND.Text.Trim.Length = 0 Then
            Dim ldValor As Decimal = CType(entidadCabecera, Ee010asientoscabeceras).debito_o - CType(entidadCabecera, Ee010asientoscabeceras).credito_o
            Select Case cmbTipo.Text
                Case sDebito_
                    If ldValor < 0 Then
                        txtImporte_mo_ND.Text = (ldValor * -1).ToString
                    End If
                Case sCredito_
                    If ldValor > 0 Then
                        txtImporte_mo_ND.Text = ldValor.ToString
                    End If
            End Select
            e.Cancel = True
            Exit Sub
        End If
        If IsNumeric(txtImporte_mo_ND.Text) = False Then
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
            Exit Sub
        End If
        LPDespliegaDescripciones()

    End Sub
End Class