Imports System.ComponentModel

Public Class frmFc001empresas
    Private msValidado As String = ""
    Private msRequeridos As String() = {"codempresa", "nombre", "abreviado", "codmoneda", "ruc", "periodoinicio", "periodofinal"}
    Private moRequeridos As New ArrayList(msRequeridos)

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LPBorrarAlCancelar()
        Me.Tag = sCancelar_
        GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en CANCELAR.")
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If InStr(sAGREGAR_ & sMODIFICAR_, Me.Tag.ToString) > 0 Then
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
                        Dim loDatos As New Ec001empresas
                        loDatos.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
                        loDatos.nombre = txtNombre_AN.Text
                        loDatos.abreviado = txtAbreviado_AN.Text
                        loDatos.codMoneda = txtCodMoneda_AN.Text
                        loDatos.ruc = txtRuc_AN.Text
                        loDatos.periodoInicio = txtPeriodoInicio_FE.Text
                        loDatos.periodoFinal = txtPeriodoFinal_FE.Text
                        loDatos.direccion = txtDireccion_AN.Text
                        loDatos.ciudad = txtCiudad_AN.Text
                        loDatos.telefono = txtTelefono_AN.Text
                        loDatos.ctaResultado1 = txtCtaResultado1_AN.Text
                        loDatos.ctaResultado2 = txtCtaResultado2__AN.Text
                        loDatos.ctaResultado3 = txtCtaResultado3_AN.Text
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Put(sSi_, sSi_, sAGREGAR_)
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                        LPCreaCuentasBasicas()
                        LPCreaCasaCentral()
                    Case sMODIFICAR_
                        Dim loDatos As New Ec001empresas
                        Dim liCodEmpresa As Integer = Integer.Parse(txtCodigo_NE.Text.ToString)
                        loDatos.codEmpresa = liCodEmpresa
                        If loDatos.GetPK = sOk_ Then
                            loDatos.codMoneda = txtCodigo_NE.Text
                            loDatos.nombre = txtNombre_AN.Text
                            loDatos.abreviado = txtAbreviado_AN.Text
                            loDatos.codMoneda = txtCodMoneda_AN.Text
                            loDatos.ruc = txtRuc_AN.Text
                            loDatos.periodoInicio = txtPeriodoInicio_FE.Text
                            loDatos.periodoFinal = txtPeriodoFinal_FE.Text
                            loDatos.direccion = txtDireccion_AN.Text
                            loDatos.ciudad = txtCiudad_AN.Text
                            loDatos.telefono = txtTelefono_AN.Text
                            loDatos.ctaResultado1 = txtCtaResultado1_AN.Text
                            loDatos.ctaResultado2 = txtCtaResultado2__AN.Text
                            loDatos.ctaResultado3 = txtCtaResultado3_AN.Text
                            If cmbEstado.Text.Trim.Length > 0 Then
                                loDatos.estado = cmbEstado.Text
                            End If
                            loDatos.Put()
                            SesionActiva.Ejercicios_Save(liCodEmpresa.ToString(sFormatD_ & txtCodigo_NE.MaxLength.ToString), txtPeriodoInicio_FE.Text.Substring(0, 4))
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
                Dim loDatos As New Ec001empresas
                loDatos.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
                If loDatos.GetPK = sOk_ Then
                    loDatos.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
                    loDatos.Del()
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
            End If
            Me.Tag = sOk_
            GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
            Me.Close()
        End If
    End Sub

    Private Sub LPCreaCuentasBasicas()
        Dim loPlanCuentas As New Eb050plancuentas
        loPlanCuentas.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
        loPlanCuentas.codCuenta = "1" & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
        loPlanCuentas.nombre = "A C T I V O"
        loPlanCuentas.tipo = sTotales_.Substring(0, 1)
        loPlanCuentas.nivel = "1"
        loPlanCuentas.Add(sNo_, sNo_)

        loPlanCuentas.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
        loPlanCuentas.codCuenta = "2" & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
        loPlanCuentas.nombre = "P A S I V O"
        loPlanCuentas.tipo = sTotales_.Substring(0, 1)
        loPlanCuentas.nivel = "1"
        loPlanCuentas.Add(sNo_, sNo_)

        loPlanCuentas.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
        loPlanCuentas.codCuenta = "3" & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
        loPlanCuentas.nombre = "PATRIMONIO NETO"
        loPlanCuentas.tipo = sTotales_.Substring(0, 1)
        loPlanCuentas.nivel = "1"
        loPlanCuentas.Add(sNo_, sNo_)

        loPlanCuentas.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
        loPlanCuentas.codCuenta = "4" & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
        loPlanCuentas.nombre = "CUENTAS ORDEN ACTIVAS"
        loPlanCuentas.tipo = sTotales_.Substring(0, 1)
        loPlanCuentas.nivel = "1"
        loPlanCuentas.Add(sNo_, sNo_)

        loPlanCuentas.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
        loPlanCuentas.codCuenta = "5" & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
        loPlanCuentas.nombre = "CUENTAS ORDEN PASIVAS"
        loPlanCuentas.tipo = sTotales_.Substring(0, 1)
        loPlanCuentas.nivel = "1"
        loPlanCuentas.Add(sNo_, sNo_)

        loPlanCuentas.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
        loPlanCuentas.codCuenta = "6" & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
        loPlanCuentas.nombre = "I N G R E S O S"
        loPlanCuentas.tipo = sTotales_.Substring(0, 1)
        loPlanCuentas.nivel = "1"
        loPlanCuentas.Add(sNo_, sNo_)

        loPlanCuentas.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
        loPlanCuentas.codCuenta = "7" & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
        loPlanCuentas.nombre = "E G R E S O S"
        loPlanCuentas.tipo = sTotales_.Substring(0, 1)
        loPlanCuentas.nivel = "1"
        loPlanCuentas.Add(sNo_, sNo_)

        loPlanCuentas.CerrarConexion()
        loPlanCuentas = Nothing
    End Sub

    Private Sub LPCreaCasaCentral()
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodigo_NE.Text.ToString)
        Dim liCodSucursal As Integer = 0
        Dim loSucursal As New Eb070sucursales
        loSucursal.codEmpresa = liCodEmpresa
        liCodSucursal = loSucursal.ReservarRegistro(liCodEmpresa)
        loSucursal.codSucursal = liCodSucursal
        loSucursal.nombre = "CASA CENTRAL"
        loSucursal.abreviado = "CASA CENTRAL"
        loSucursal.Put(sNo_, sNo_, sAGREGAR_)

        loSucursal.CerrarConexion()
        loSucursal = Nothing
    End Sub

    Private Sub ManejoEvento_Validating(sender As Object, e As CancelEventArgs)
        If CType(sender, Control).Text.Trim.Length = 0 Then
            If LFsExiste(CType(sender, Control).AccessibleName) = sNo_ Then Exit Sub
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).AccessibleName
                Case "nombre"
                    lsValorInicial = "Nombre Empresa No. " & txtCodigo_NE.Text
                Case "abreviado"
                    If txtNombre_AN.Text.Trim.Length > 0 Then
                        lsValorInicial = txtNombre_AN.Text
                    Else
                        lsValorInicial = "Empresa No. " & txtCodigo_NE.Text
                    End If
                Case "codmoneda"
                    lsValorInicial = sCero3_
                Case "ruc"
                    lsValorInicial = sRESERVADO_
                Case "periodoinicio"
                    lsValorInicial = Today.ToString("yyyy") & "-01-01"
                Case "periodofinal"
                    lsValorInicial = Today.ToString("yyyy") & "-12-31"
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "codmoneda"
                    Dim loFK As New Ea010monedas
                    Dim lsResultado As String = ""
                    loFK.codMoneda = txtCodMoneda_AN.Text
                    lsResultado = loFK.GetPK
                    loFK.CerrarConexion()
                    loFK = Nothing
                    If lsResultado = sSinRegistros_ Then
                        Dim loLookUp As New frmBa010monedas
                        loLookUp.Tag = sELEGIR_
                        GPCargar(loLookUp)
                        If loLookUp.entidad IsNot Nothing Then
                            txtCodMoneda_AN.Text = CType(loLookUp.entidad, Ea010monedas).codMoneda
                        End If
                        e.Cancel = True
                        loLookUp = Nothing
                    End If
                Case "periodoinicio"
                    If Not IsDate(txtPeriodoInicio_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtPeriodoInicio_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtPeriodoInicio_FE.Text.ToString)
                        txtPeriodoInicio_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                Case "periodofinal"
                    If Not IsDate(txtPeriodoFinal_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtPeriodoFinal_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                    Else
                        Dim ldFecha As Date = Date.Parse(txtPeriodoFinal_FE.Text.ToString)
                        txtPeriodoFinal_FE.Text = ldFecha.ToString("yyyy-MM-dd")
                    End If
                    If txtPeriodoFinal_FE.Text < txtPeriodoInicio_FE.Text Then
                        Dim lsAuxiliar As String = txtPeriodoFinal_FE.Text
                        txtPeriodoFinal_FE.Text = txtPeriodoInicio_FE.Text
                        txtPeriodoInicio_FE.Text = lsAuxiliar
                        txtPeriodoInicio_FE.Focus()
                    End If
                Case "ctaresultado1"
                    If txtCtaResultado1_AN.Text.Trim.Length > 0 Then
                        Dim liCodEmpresa As Integer = Integer.Parse(txtCodigo_NE.Text.ToString)
                        Dim lsCodCuenta As String = txtCtaResultado1_AN.Text
                        Dim loFK1 As New Eb050plancuentas
                        loFK1.codEmpresa = liCodEmpresa
                        loFK1.codCuenta = lsCodCuenta
                        If loFK1.GetPK = sSinRegistros_ Then
                            Dim loLookUp As New frmBb050plancuentas
                            loLookUp.Tag = sELEGIR_
                            GPCargar(loLookUp)
                            If loLookUp.entidad IsNot Nothing Then
                                txtCtaResultado1_AN.Text = CType(loLookUp.entidad, Eb050plancuentas).codCuenta
                            End If
                            e.Cancel = True
                            loLookUp = Nothing
                        End If
                    End If
                Case "ctaresultado2"
                    If txtCtaResultado2__AN.Text.Trim.Length > 0 Then
                        Dim liCodEmpresa As Integer = Integer.Parse(txtCodigo_NE.Text.ToString)
                        Dim lsCodCuenta As String = txtCtaResultado2__AN.Text
                        Dim loFK1 As New Eb050plancuentas
                        loFK1.codEmpresa = liCodEmpresa
                        loFK1.codCuenta = lsCodCuenta
                        If loFK1.GetPK = sSinRegistros_ Then
                            Dim loLookUp As New frmBb050plancuentas
                            loLookUp.Tag = sELEGIR_
                            GPCargar(loLookUp)
                            If loLookUp.entidad IsNot Nothing Then
                                txtCtaResultado2__AN.Text = CType(loLookUp.entidad, Eb050plancuentas).codCuenta
                            End If
                            e.Cancel = True
                            loLookUp = Nothing
                        End If
                    End If
                Case "ctaresultado3"
                    If txtCtaResultado3_AN.Text.Trim.Length > 0 Then
                        Dim liCodEmpresa As Integer = Integer.Parse(txtCodigo_NE.Text.ToString)
                        Dim lsCodCuenta As String = txtCtaResultado3_AN.Text
                        Dim loFK1 As New Eb050plancuentas
                        loFK1.codEmpresa = liCodEmpresa
                        loFK1.codCuenta = lsCodCuenta
                        If loFK1.GetPK = sSinRegistros_ Then
                            Dim loLookUp As New frmBb050plancuentas
                            loLookUp.Tag = sELEGIR_
                            GPCargar(loLookUp)
                            If loLookUp.entidad IsNot Nothing Then
                                txtCtaResultado3_AN.Text = CType(loLookUp.entidad, Eb050plancuentas).codCuenta
                            End If
                            e.Cancel = True
                            loLookUp = Nothing
                        End If
                    End If
            End Select
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoComboBox_ Then
                If CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) = False Then
                    e.Cancel = True
                    CType(sender, Control).Tag = sCancelar_
                End If
            End If
        End If
        LPDespliegaDescripciones()
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
        msEntidad = "registro de Empresa"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
            Case Else
                txtCodigo_NE.Text = CType(entidad, Ec001empresas).codEmpresa.ToString
                txtNombre_AN.Text = CType(entidad, Ec001empresas).nombre
                txtAbreviado_AN.Text = CType(entidad, Ec001empresas).abreviado
                txtCodMoneda_AN.Text = CType(entidad, Ec001empresas).codMoneda
                txtRuc_AN.Text = CType(entidad, Ec001empresas).ruc
                txtPeriodoInicio_FE.Text = CType(entidad, Ec001empresas).periodoInicio
                txtPeriodoFinal_FE.Text = CType(entidad, Ec001empresas).periodoFinal
                txtDireccion_AN.Text = CType(entidad, Ec001empresas).direccion
                txtCiudad_AN.Text = CType(entidad, Ec001empresas).ciudad
                txtTelefono_AN.Text = CType(entidad, Ec001empresas).telefono
                txtCtaResultado1_AN.Text = CType(entidad, Ec001empresas).ctaResultado1
                txtCtaResultado2__AN.Text = CType(entidad, Ec001empresas).ctaResultado2
                txtCtaResultado3_AN.Text = CType(entidad, Ec001empresas).ctaResultado3
                cmbEstado.Text = CType(entidad, Ec001empresas).estado
        End Select
        ' Habilita o deshabilita los controles de edición
        txtCodigo_NE.Enabled = True
        txtNombre_AN.Enabled = True
        txtAbreviado_AN.Enabled = True
        txtCodMoneda_AN.Enabled = True
        txtRuc_AN.Enabled = True
        txtPeriodoInicio_FE.Enabled = True
        txtPeriodoFinal_FE.Enabled = True
        txtDireccion_AN.Enabled = True
        txtCiudad_AN.Enabled = True
        txtTelefono_AN.Enabled = True
        txtCtaResultado1_AN.Enabled = True
        txtCtaResultado2__AN.Enabled = True
        txtCtaResultado3_AN.Enabled = True
        cmbEstado.Enabled = True

        txtCodigo_NE.AccessibleName = "codigo"
        txtNombre_AN.AccessibleName = "nombre"
        txtAbreviado_AN.AccessibleName = "abreviado"
        txtCodMoneda_AN.AccessibleName = "codmoneda"
        txtRuc_AN.AccessibleName = "ruc"
        txtPeriodoInicio_FE.AccessibleName = "periodoinicio"
        txtPeriodoFinal_FE.AccessibleName = "periodofinal"
        txtDireccion_AN.AccessibleName = "direccion"
        txtCiudad_AN.AccessibleName = "ciudad"
        txtTelefono_AN.AccessibleName = "telefono"
        txtCtaResultado1_AN.AccessibleName = "ctaresultado1"
        txtCtaResultado2__AN.AccessibleName = "ctaresultado2"
        txtCtaResultado3_AN.AccessibleName = "ctaresultado3"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                Dim loDatos As New Ec001empresas
                txtCodigo_NE.Text = loDatos.ReservarRegistro.ToString
                loDatos.CerrarConexion()
                loDatos = Nothing
                txtCodigo_NE.Enabled = False

            Case sMODIFICAR_
                txtCodigo_NE.Enabled = False

            Case sCONSULTAR_, sBORRAR_
                For Each loTabPage As TabPage In TabControl1.TabPages
                    If loTabPage.AccessibleName = sActivo_ Then
                        For Each loControl As Control In loTabPage.Controls
                            If InStr("txt|cmb", loControl.Name.Substring(0, 3)) > 0 Then
                                loControl.Enabled = False
                            End If
                        Next
                    End If
                Next
        End Select
        LPDespliegaDescripciones()
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtNombre_AN.Focus()
            Case sMODIFICAR_
                txtNombre_AN.Focus()
        End Select
    End Sub
    Private Sub LPDespliegaDescripciones()
        Dim liCodEmpresa As Integer
        Dim lsCodCuenta As String

        If txtCodigo_NE.Text.Trim.Length > 0 Then
            liCodEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
        End If

        lblNombreResultado1.Text = ""
        If txtCtaResultado1_AN.Text.Trim.Length > 0 Then
            lsCodCuenta = txtCtaResultado1_AN.Text
            Dim loFK1 As New Eb050plancuentas
            loFK1.codEmpresa = liCodEmpresa
            loFK1.codCuenta = lsCodCuenta
            If loFK1.GetPK = sOk_ Then
                lblNombreResultado1.Text = loFK1.nombre
            End If
        End If

        lblNombreResultado2.Text = ""
        If txtCtaResultado2__AN.Text.Trim.Length > 0 Then
            lsCodCuenta = txtCtaResultado2__AN.Text
            Dim loFK1 As New Eb050plancuentas
            loFK1.codEmpresa = liCodEmpresa
            loFK1.codCuenta = lsCodCuenta
            If loFK1.GetPK = sOk_ Then
                lblNombreResultado2.Text = loFK1.nombre
            End If
        End If

        lblNombreResultado3.Text = ""
        If txtCtaResultado3_AN.Text.Trim.Length > 0 Then
            lsCodCuenta = txtCtaResultado3_AN.Text
            Dim loFK1 As New Eb050plancuentas
            loFK1.codEmpresa = liCodEmpresa
            loFK1.codCuenta = lsCodCuenta
            If loFK1.GetPK = sOk_ Then
                lblNombreResultado3.Text = loFK1.nombre
            End If
        End If

        lblNombreMoneda.Text = ""
        If txtCodMoneda_AN.Text.Trim.Length > 0 Then
            Dim loFK1 As New Ea010monedas
            loFK1.codMoneda = txtCodMoneda_AN.Text
            If loFK1.GetPK = sOk_ Then
                lblNombreMoneda.Text = loFK1.nombre
            End If
            loFK1.CerrarConexion()
            loFK1 = Nothing
        End If
    End Sub

    Private Sub LPInicializaMaxLength()
        txtCodigo_NE.MaxLength = 6
        txtNombre_AN.MaxLength = 100
        txtAbreviado_AN.MaxLength = 30
        txtCodMoneda_AN.MaxLength = 3
        txtRuc_AN.MaxLength = 30
        txtPeriodoInicio_FE.MaxLength = 10
        txtPeriodoFinal_FE.MaxLength = 10
        txtDireccion_AN.MaxLength = 128
        txtCiudad_AN.MaxLength = 64
        txtTelefono_AN.MaxLength = 64
        txtCtaResultado1_AN.MaxLength = 26
        txtCtaResultado2__AN.MaxLength = 26
        txtCtaResultado3_AN.MaxLength = 26
        cmbEstado.MaxLength = 15
    End Sub

    Private Sub LPInicializaControles()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                            AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                        Case sPrefijoComboBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                    End Select
                Next
            End If
        Next
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

        Dim loDatos As New Ec001empresas
        loDatos.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
        If loDatos.GetPK = sOk_ Then
            loDatos.codEmpresa = Integer.Parse(txtCodigo_NE.Text.ToString)
            loDatos.Del(sNo_, sNo_)
        End If
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

End Class