Imports System.ComponentModel

Public Class frmFe010asientoscabeceras
    Private msValidado As String = ""
    Private msRequeridos As String() = {"codempresa", "nroasiento", "codsucursal", "fecha", "coddocumento", "nrodocumento", "codmoneda_o", "codconcepto", "concepto"}
    Private moRequeridos As New ArrayList(msRequeridos)
    Private msEjercicio As String = ""
    Private msCodMoneda As String = ""
    Private msPeriodoInicial As String = ""
    Private msPeriodoFinal As String = ""
    Private msCotizacion As String = ""

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
                        Dim loDatos As New Ee010asientoscabeceras
                        LPTruncaSegunLongitud()
                        Dim liFactor() As Integer = GFiCotizacion(txtCodMoneda_AN.Text, msCodMoneda, txtFecha_FE.Text)
                        loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                        loDatos.nroAsiento = Integer.Parse(txtCodigo_NE.Text.ToString)
                        loDatos.codSucursal = Integer.Parse(txtCodSucursal_NE.Text.ToString)
                        loDatos.fecha = txtFecha_FE.Text
                        loDatos.codDocumento = Integer.Parse(txtCodDocumento_NE.Text.ToString)
                        loDatos.nroDocumento = txtNroDocumento_AN.Text
                        loDatos.codMoneda_o = txtCodMoneda_AN.Text
                        loDatos.codMoneda_b = msCodMoneda
                        loDatos.codConcepto = Integer.Parse(txtCodConcepto_NE.Text.ToString)
                        loDatos.concepto = txtConcepto_AN.Text
                        loDatos.cotizacion = msCotizacion
                        loDatos.compra = liFactor(0)
                        loDatos.venta = liFactor(1)
                        loDatos.debito_o = 0.00D
                        loDatos.credito_o = 0.00D
                        loDatos.debito_b = 0.00D
                        loDatos.credito_b = 0.00D
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Put(sSi_, sSi_, sAGREGAR_)
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim loDatos As New Ee010asientoscabeceras
                        loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                        loDatos.nroAsiento = Integer.Parse(txtCodigo_NE.Text.ToString)
                        If loDatos.GetPK = sOk_ Then
                            LPTruncaSegunLongitud()
                            Dim liFactor() As Integer = GFiCotizacion(txtCodMoneda_AN.Text, msCodMoneda, txtFecha_FE.Text)
                            loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                            loDatos.nroAsiento = Integer.Parse(txtCodigo_NE.Text.ToString)
                            loDatos.codSucursal = Integer.Parse(txtCodSucursal_NE.Text.ToString)
                            loDatos.fecha = txtFecha_FE.Text
                            loDatos.codDocumento = Integer.Parse(txtCodDocumento_NE.Text.ToString)
                            loDatos.nroDocumento = txtNroDocumento_AN.Text
                            loDatos.codMoneda_o = txtCodMoneda_AN.Text
                            loDatos.codMoneda_b = msCodMoneda
                            loDatos.codConcepto = Integer.Parse(txtCodConcepto_NE.Text.ToString)
                            loDatos.concepto = txtConcepto_AN.Text
                            loDatos.cotizacion = msCotizacion
                            loDatos.compra = liFactor(0)
                            loDatos.venta = liFactor(1)
                            If cmbEstado.Text.Trim.Length > 0 Then
                                loDatos.estado = cmbEstado.Text
                            End If
                            loDatos.Put()
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
                Dim loDatos As New Ee010asientoscabeceras
                loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                loDatos.nroAsiento = Integer.Parse(txtCodigo_NE.Text.ToString)
                If loDatos.GetPK = sOk_ Then
                    loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                    loDatos.nroAsiento = Integer.Parse(txtCodigo_NE.Text.ToString)
                    loDatos.Del()
                End If
                loDatos.CerrarConexion()
                loDatos = Nothing
            Else
                Me.AccessibleName = txtCodigo_NE.Text
            End If
            Me.Tag = sOk_
            GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
            Me.Close()
        End If
    End Sub

    Private Sub ManejoEvento_Validating(sender As Object, e As CancelEventArgs)
        If CType(sender, Control).Text.Trim.Length = 0 Then
            If LFsExiste(CType(sender, Control).AccessibleName) = sNo_ Then Exit Sub
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).AccessibleName
                Case "codsucursal"
                    lsValorInicial = "1"
                Case "fecha"
                    lsValorInicial = Today.ToString(sFormatoFecha1_)
                Case "nrodocumento"
                    lsValorInicial = txtCodigo_NE.Text
                Case "codmoneda_o"
                    lsValorInicial = msCodMoneda
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "codsucursal"
                    If Not IsNumeric(txtCodEmpresa_NE.Text) Then Exit Sub
                    Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                    If liCodEmpresa = 0 Then Exit Sub

                    If Not IsNumeric(txtCodSucursal_NE.Text) Then Exit Sub
                    Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text.ToString)
                    If liCodSucursal = 0 Then
                        e.Cancel = True
                        Exit Sub
                    End If

                    Dim loFK As New Eb070sucursales
                    Dim lsResultado As String = ""
                    loFK.codEmpresa = liCodEmpresa
                    loFK.codSucursal = liCodSucursal
                    lsResultado = loFK.GetPK
                    If lsResultado = sSinRegistros_ Then
                        Dim loLookUp As New frmBb070sucursales
                        loLookUp.codEmpresa = liCodEmpresa
                        loLookUp.Tag = sELEGIR_
                        GPCargar(loLookUp)
                        If loLookUp.entidad IsNot Nothing Then
                            txtCodSucursal_NE.Text = CType(loLookUp.entidad, Eb070sucursales).codSucursal.ToString
                        Else
                            e.Cancel = True
                            Exit Sub
                        End If
                        loLookUp = Nothing
                    End If
                    loFK.CerrarConexion()
                    loFK = Nothing
                Case "fecha"
                    If Not IsDate(txtFecha_FE.Text) Then
                        GFsAvisar("El dato ingresado [" & txtFecha_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
                        e.Cancel = True
                        Exit Sub
                    End If
                    Dim ldFecha As Date = Date.Parse(txtFecha_FE.Text.ToString)
                    txtFecha_FE.Text = ldFecha.ToString(sFormatoFecha1_)
                    If Not (txtFecha_FE.Text >= msPeriodoInicial And txtFecha_FE.Text <= msPeriodoFinal) Then
                        GFsAvisar("La fecha ingresada [" & txtFecha_FE.Text & "] esta fuera del rango del periodo contable vigente", sMENSAJE_, "Periodo vigente [" & msPeriodoInicial & " - " & msPeriodoFinal & "]")
                        e.Cancel = True
                        Exit Sub
                    End If
                Case "coddocumento"
                    If Not IsNumeric(txtCodEmpresa_NE.Text) Then Exit Sub
                    Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                    If liCodEmpresa = 0 Then Exit Sub

                    If Not IsNumeric(txtCodDocumento_NE.Text) Then Exit Sub
                    Dim liCodDocumento As Integer = Integer.Parse(txtCodDocumento_NE.Text.ToString)
                    If liCodDocumento = 0 Then
                        e.Cancel = True
                        Exit Sub
                    End If

                    Dim loFK As New Ec020documentos
                    Dim lsResultado As String = ""

                    loFK.codEmpresa = liCodEmpresa
                    loFK.codDocumento = liCodDocumento
                    lsResultado = loFK.GetPK
                    If lsResultado = sSinRegistros_ Then
                        Dim loLookUp As New frmBc020documentos
                        loLookUp.codEmpresa = liCodEmpresa
                        loLookUp.Tag = sELEGIR_
                        GPCargar(loLookUp)
                        If loLookUp.entidad IsNot Nothing Then
                            msCotizacion = CType(loLookUp.entidad, Ec020documentos).cotizacion
                            txtCodDocumento_NE.Text = CType(loLookUp.entidad, Ec020documentos).codDocumento.ToString
                            txtCodMoneda_AN.Text = CType(loLookUp.entidad, Ec020documentos).codMoneda
                            txtCodMoneda_AN.Enabled = False
                        Else
                            e.Cancel = True
                            Exit Sub
                        End If
                        loLookUp = Nothing
                    Else
                        txtCodMoneda_AN.Text = loFK.codMoneda
                        txtCodMoneda_AN.Enabled = False
                    End If
                    loFK.CerrarConexion()
                    loFK = Nothing
                    Dim liCotizacion() As Integer = GFiCotizacion(txtCodMoneda_AN.Text, msCodMoneda, txtFecha_FE.Text)
                    If liCotizacion(0) + liCotizacion(1) = 0 Then
                        GFsAvisar("No existe cotizacion disponible para [" & txtCodMoneda_AN.Text & " - " & msCodMoneda & "]", sMENSAJE_, "Favor ingrese una cotización con vigencia [" & txtFecha_FE.Text & "]")
                        Dim loFrmCotizacion As New frmBb030cotizaciones
                        GPCargar(loFrmCotizacion)
                        loFrmCotizacion = Nothing
                        e.Cancel = True
                        Exit Sub
                    End If
                Case "codmoneda_o"
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
                        Else
                            e.Cancel = True
                            Exit Sub
                        End If
                        loLookUp = Nothing
                    End If
                Case "codconcepto"
                    If Not IsNumeric(txtCodEmpresa_NE.Text) Then Exit Sub
                    Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                    If liCodEmpresa = 0 Then Exit Sub

                    If Not IsNumeric(txtCodConcepto_NE.Text) Then
                        txtCodConcepto_NE.Text = "0"
                        e.Cancel = True
                        Exit Sub
                    End If
                    Dim liCodConcepto As Integer = Integer.Parse(txtCodConcepto_NE.Text.ToString)

                    If liCodConcepto > 0 Then
                        Dim loFK As New Eb020conceptos
                        Dim lsResultado As String = ""
                        loFK.codEmpresa = liCodEmpresa
                        loFK.codConcepto = liCodConcepto
                        lsResultado = loFK.GetPK
                        If lsResultado = sSinRegistros_ Then
                            Dim loLookUp As New frmBb020conceptos
                            loLookUp.codEmpresa = liCodEmpresa
                            loLookUp.Tag = sELEGIR_
                            GPCargar(loLookUp)
                            If loLookUp.entidad IsNot Nothing Then
                                txtCodConcepto_NE.Text = CType(loLookUp.entidad, Eb020conceptos).codConcepto.ToString
                                txtConcepto_AN.Text = CType(loLookUp.entidad, Eb020conceptos).descripcion
                                If CType(loLookUp.entidad, Eb020conceptos).tipo = sFijo_ Then
                                    txtConcepto_AN.Enabled = False
                                Else
                                    txtConcepto_AN.Enabled = True
                                End If
                            Else
                                e.Cancel = True
                                Exit Sub
                            End If
                            loLookUp = Nothing
                        Else
                            txtConcepto_AN.Text = loFK.descripcion
                            If loFK.tipo = sFijo_ Then
                                txtConcepto_AN.Enabled = False
                            Else
                                txtConcepto_AN.Enabled = True
                            End If
                        End If
                        loFK.CerrarConexion()
                        loFK = Nothing
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
        msEntidad = "Documento"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                Dim loDatos As New Ee010asientoscabeceras
                txtCodEmpresa_NE.Text = CType(entidad, Ee010asientoscabeceras).codEmpresa.ToString
                txtCodigo_NE.Text = loDatos.ReservarRegistro(Integer.Parse(txtCodEmpresa_NE.Text.ToString)).ToString
                loDatos.CerrarConexion()
                loDatos = Nothing
            Case Else
                txtCodEmpresa_NE.Text = CType(entidad, Ee010asientoscabeceras).codEmpresa.ToString
                txtCodigo_NE.Text = CType(entidad, Ee010asientoscabeceras).nroAsiento.ToString
                txtCodSucursal_NE.Text = CType(entidad, Ee010asientoscabeceras).codSucursal.ToString
                txtFecha_FE.Text = CType(entidad, Ee010asientoscabeceras).fecha.ToString
                txtCodDocumento_NE.Text = CType(entidad, Ee010asientoscabeceras).codDocumento.ToString
                txtNroDocumento_AN.Text = CType(entidad, Ee010asientoscabeceras).nroDocumento
                txtCodMoneda_AN.Text = CType(entidad, Ee010asientoscabeceras).codMoneda_o
                txtCodConcepto_NE.Text = CType(entidad, Ee010asientoscabeceras).codConcepto.ToString
                txtConcepto_AN.Text = CType(entidad, Ee010asientoscabeceras).concepto
                cmbEstado.Text = CType(entidad, Ee010asientoscabeceras).estado
        End Select
        ' Habilita o deshabilita los controles de edición
        txtCodEmpresa_NE.Enabled = True
        txtCodigo_NE.Enabled = True
        txtCodSucursal_NE.Enabled = True
        txtFecha_FE.Enabled = True
        txtCodDocumento_NE.Enabled = True
        txtNroDocumento_AN.Enabled = True
        txtCodMoneda_AN.Enabled = True
        txtCodConcepto_NE.Enabled = True
        txtConcepto_AN.Enabled = True
        cmbEstado.Enabled = True

        txtCodEmpresa_NE.AccessibleName = "codempresa"
        txtCodigo_NE.AccessibleName = "codigo"
        txtCodSucursal_NE.AccessibleName = "codsucursal"
        txtFecha_FE.AccessibleName = "fecha"
        txtCodDocumento_NE.AccessibleName = "coddocumento"
        txtNroDocumento_AN.AccessibleName = "nrodocumento"
        txtCodMoneda_AN.AccessibleName = "codmoneda_o"
        txtCodConcepto_NE.AccessibleName = "codconcepto"
        txtConcepto_AN.AccessibleName = "concepto"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtCodEmpresa_NE.Enabled = False
                txtCodigo_NE.Enabled = False

            Case sMODIFICAR_
                txtCodEmpresa_NE.Enabled = False
                txtCodigo_NE.Enabled = False
                txtCodMoneda_AN.Enabled = False

            Case sCONSULTAR_, sBORRAR_
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

    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtCodSucursal_NE.Focus()
            Case sMODIFICAR_
                txtCodSucursal_NE.Focus()
        End Select
        LPDespliegaDescripciones()
    End Sub

    Private Sub LPDespliegaDescripciones()
        Dim liCodEmpresa As Integer = 0
        Dim liCodSucursal As Integer = 0
        Dim liCodDocumento As Integer = 0
        Dim liCodConcepto As Integer = 0

        lblNombreEmpresa.Text = ""
        If txtCodEmpresa_NE.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtCodEmpresa_NE.Text) Then Exit Sub
            liCodEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)

            Dim loFK As New Ec001empresas
            loFK.codEmpresa = liCodEmpresa
            If loFK.GetPK = sOk_ Then
                lblNombreEmpresa.Text = loFK.nombre
                If loFK.periodoInicio IsNot Nothing Then
                    Dim ldFecha As Date = Date.Parse(loFK.periodoInicio)
                    msEjercicio = ldFecha.ToString("yyyy")
                    msPeriodoInicial = loFK.periodoInicio
                    msPeriodoFinal = loFK.periodoFinal
                End If
                msCodMoneda = loFK.codMoneda
            End If
            loFK.CerrarConexion()
            loFK = Nothing
        End If

        lblNombreSucursal.Text = ""
        If txtCodSucursal_NE.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtCodSucursal_NE.Text) Then Exit Sub
            liCodSucursal = Integer.Parse(txtCodSucursal_NE.Text.ToString)

            Dim loFK As New Eb070sucursales
            loFK.codEmpresa = liCodEmpresa
            loFK.codSucursal = liCodSucursal
            If loFK.GetPK = sOk_ Then
                lblNombreSucursal.Text = loFK.nombre
            End If
            loFK.CerrarConexion()
            loFK = Nothing
        End If

        lblNombreDocumento.Text = ""
        If txtCodDocumento_NE.Text.Trim.Length > 0 Then
            If Not IsNumeric(txtCodDocumento_NE.Text) Then Exit Sub
            liCodDocumento = Integer.Parse(txtCodDocumento_NE.Text.ToString)
            If liCodDocumento = 0 Then Exit Sub

            Dim loFK As New Ec020documentos
            loFK.codEmpresa = liCodEmpresa
            loFK.codDocumento = liCodDocumento
            If loFK.GetPK = sOk_ Then
                lblNombreDocumento.Text = loFK.nombre
                msCotizacion = loFK.cotizacion
            End If
            loFK.CerrarConexion()
            loFK = Nothing
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

        liCodConcepto = 0
        If IsNumeric(txtCodConcepto_NE.Text) Then
            liCodConcepto = Integer.Parse(txtCodConcepto_NE.Text.ToString)
        End If
        txtCodEmpresa_NE.Text = liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength)
        txtCodSucursal_NE.Text = liCodSucursal.ToString(sFormatD_ & txtCodSucursal_NE.MaxLength)
        txtCodDocumento_NE.Text = liCodDocumento.ToString(sFormatD_ & txtCodDocumento_NE.MaxLength)
        txtCodConcepto_NE.Text = liCodConcepto.ToString(sFormatD_ & txtCodConcepto_NE.MaxLength)
        If liCodSucursal = 0 Then
            txtCodSucursal_NE.SelectAll()
        End If
    End Sub

    Private Sub LPInicializaMaxLength()
        txtCodEmpresa_NE.MaxLength = 6
        txtCodigo_NE.MaxLength = 6
        txtCodSucursal_NE.MaxLength = 3
        txtFecha_FE.MaxLength = 10
        txtCodDocumento_NE.MaxLength = 3
        txtNroDocumento_AN.MaxLength = 15
        txtCodMoneda_AN.MaxLength = 3
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
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                            AddHandler loControl.KeyPress, AddressOf ManejoEvento_KeyPress
                            AddHandler loControl.Click, AddressOf TextBox_Click
                        Case sPrefijoComboBox_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoRadioButton_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        AddHandler loControl1.Validating, AddressOf ManejoEvento_Validating
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                        AddHandler loControl1.KeyPress, AddressOf ManejoEvento_KeyPress
                                        AddHandler loControl1.Click, AddressOf TextBox_Click
                                    Case sPrefijoComboBox_
                                        AddHandler loControl.Validating, AddressOf ManejoEvento_Validating
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                    Case sPrefijoRadioButton_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                End Select
                            Next
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

        Dim loDatos As New Ee010asientoscabeceras
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim liCodigo As Integer = Integer.Parse(txtCodigo_NE.Text.ToString)
        loDatos.codEmpresa = liCodEmpresa
        loDatos.nroAsiento = liCodigo
        If loDatos.GetPK = sOk_ Then
            loDatos.codEmpresa = liCodEmpresa
            loDatos.nroAsiento = liCodigo
            loDatos.Del(sNo_, sNo_)
        End If
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub

    Private Sub TextBox_Click(sender As Object, e As EventArgs)
        CType(sender, TextBox).SelectAll()
    End Sub
End Class