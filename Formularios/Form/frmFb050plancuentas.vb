Imports System.ComponentModel
Imports System.Data.Common

Public Class frmFb050plancuentas
    Private msValidado As String = ""
    Private msRequeridos As String() = {"codempresa", "codcuenta", "nombre", "tipo", "nivel"}
    Private moRequeridos As New ArrayList(msRequeridos)
    Private miCuenta1 As Integer = 0
    Private miCuenta2 As Integer = 0
    Private miCuenta3 As Integer = 0
    Private miCuenta4 As Integer = 0
    Private miCuenta5 As Integer = 0
    Private miCuenta6 As Integer = 0
    Private msCantSubCuentas As String = ""
    Private msCantMovimientos As String = ""

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
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
                        Dim loDatos As New Eb050plancuentas
                        LPTruncaSegunLongitud()
                        loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                        loDatos.codCuenta = txtCodigo_NE.Text
                        loDatos.nombre = txtNombre_AN.Text
                        loDatos.tipo = cmbTipo.Text.Substring(0, cmbTipo.MaxLength)
                        loDatos.nivel = cmbNivel.Text.Substring(0, cmbNivel.MaxLength)
                        If cmbEstado.Text.Trim.Length > 0 Then
                            loDatos.estado = cmbEstado.Text
                        End If
                        loDatos.Add()
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                    Case sMODIFICAR_
                        Dim loDatos As New Eb050plancuentas
                        loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                        loDatos.codCuenta = txtCodigo_NE.Text
                        If loDatos.GetPK = sOk_ Then
                            LPTruncaSegunLongitud()
                            loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                            loDatos.codCuenta = txtCodigo_NE.Text
                            loDatos.nombre = txtNombre_AN.Text
                            loDatos.tipo = cmbTipo.Text.Substring(0, cmbTipo.MaxLength)
                            loDatos.nivel = cmbNivel.Text.Substring(0, cmbNivel.MaxLength)
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
                Dim loDatos As New Eb050plancuentas
                loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                loDatos.codCuenta = txtCodigo_NE.Text
                If loDatos.GetPK = sOk_ Then
                    loDatos.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                    loDatos.codCuenta = txtCodigo_NE.Text
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

    Private Sub ManejoEvento_Validating(sender As Object, e As CancelEventArgs)
        If CType(sender, Control).Text.Trim.Length = 0 Then
            If LFsExiste(CType(sender, Control).AccessibleName) = sNo_ Then Exit Sub
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).AccessibleName
                Case "nombre"
                    lsValorInicial = "Cuenta denominacion " & txtCodigo_NE.Text
                Case "tipo"
                    If cmbNivel.Text >= "3" Then
                        lsValorInicial = sImputable_
                    Else
                        lsValorInicial = sTotales_
                    End If

            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "cuenta1"
                    cmbNivel.Text = "1"
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
                        txtCuenta1_NE.Text = miCuenta1.ToString("D" & cmbNivel.Text)
                    End If
                    txtCodigo_NE.Text = txtCuenta1_NE.Text & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta2"
                    cmbNivel.Text = "2"
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
                        txtCuenta2_NE.Text = miCuenta1.ToString("D" & cmbNivel.Text)
                    End If
                    txtCodigo_NE.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta3"
                    cmbNivel.Text = "3"
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
                        txtCuenta3_NE.Text = miCuenta1.ToString("D" & cmbNivel.Text)
                    End If
                    txtCodigo_NE.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta4"
                    cmbNivel.Text = "4"
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
                        txtCuenta4_NE.Text = miCuenta1.ToString("D" & cmbNivel.Text)
                    End If
                    txtCodigo_NE.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & txtCuenta4_NE.Text & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "cuenta5"
                    cmbNivel.Text = "5"
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
                        txtCuenta5_NE.Text = miCuenta1.ToString("D" & cmbNivel.Text)
                    End If
                    txtCodigo_NE.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & txtCuenta4_NE.Text & sSeparador_ & txtCuenta5_NE.Text & sSeparador_ & sCero6_
                Case "cuenta6"
                    cmbNivel.Text = "6"
                    cmbTipo.Text = sImputable_
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
                        txtCuenta6_NE.Text = miCuenta1.ToString("D" & cmbNivel.Text)
                    End If
                    txtCodigo_NE.Text = txtCuenta1_NE.Text & sSeparador_ & txtCuenta2_NE.Text & sSeparador_ & txtCuenta3_NE.Text & sSeparador_ & txtCuenta4_NE.Text & sSeparador_ & txtCuenta5_NE.Text & sSeparador_ & txtCuenta6_NE.Text
            End Select
            If CType(sender, Control).Name.Substring(0, 3) = sPrefijoComboBox_ Then
                If CType(sender, ComboBox).Items.Contains(CType(sender, ComboBox).Text) = False Then
                    e.Cancel = True
                    CType(sender, Control).Tag = sCancelar_
                End If
            End If
            If InStr(CType(sender, Control).AccessibleName, "cuenta") > 0 Then
                Dim loFK1 As New Eb050plancuentas
                loFK1.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                loFK1.codCuenta = txtCodigo_NE.Text
                If loFK1.GetPK = sOk_ Then
                    e.Cancel = True
                Else
                    txtNombre_AN.Focus()
                End If
                LPDespliegaDescripciones()
            End If
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
        msEntidad = "registro Cuenta contable"
        DesplegarMensaje()

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                For liNDX As Integer = 0 To loControls.Count - 1
                    If InStr("txt|cmb", loControls.Item(liNDX).Name.ToLower) > 0 Then
                        loControls.Item(liNDX).Text = ""
                    End If
                Next
                txtCodEmpresa_NE.Text = CType(entidad, Eb050plancuentas).codEmpresa.ToString
                txtCodigo_NE.Text = CType(entidad, Eb050plancuentas).codCuenta
                LPParsearCodigoCuenta()

            Case Else
                txtCodEmpresa_NE.Text = CType(entidad, Eb050plancuentas).codEmpresa.ToString
                txtCodigo_NE.Text = CType(entidad, Eb050plancuentas).codCuenta
                txtNombre_AN.Text = CType(entidad, Eb050plancuentas).nombre
                cmbTipo.Text = CType(entidad, Eb050plancuentas).tipo
                Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
                Dim lsCodCuenta As String = txtCodigo_NE.Text
                Select Case cmbTipo.Text
                    Case sTotales_.Substring(0, cmbTipo.MaxLength)
                        cmbTipo.Text = sTotales_
                    Case sImputable_.Substring(0, cmbTipo.MaxLength)
                        cmbTipo.Text = sImputable_
                End Select
                cmbNivel.Text = CType(entidad, Eb050plancuentas).nivel
                Select Case cmbTipo.Text
                    Case sTotales_
                        msCantSubCuentas = GFsTieneSubCuentas(lsCodCuenta, cmbNivel.Text)
                    Case sImputable_
                        msCantMovimientos = GFsTieneMovimientos(liCodEmpresa, lsCodCuenta)
                End Select
                cmbEstado.Text = CType(entidad, Eb050plancuentas).estado
        End Select

        lblNombreEmpresa.Text = ""

        ' Habilita o deshabilita los controles de edición
        txtCodEmpresa_NE.Enabled = True
        txtNombre_AN.Enabled = True
        cmbTipo.Enabled = True
        cmbNivel.Enabled = True
        cmbEstado.Enabled = True

        txtCodEmpresa_NE.AccessibleName = "codEmpresa"
        txtCuenta1_NE.AccessibleName = "cuenta1"
        txtCuenta2_NE.AccessibleName = "cuenta2"
        txtCuenta3_NE.AccessibleName = "cuenta3"
        txtCuenta4_NE.AccessibleName = "cuenta4"
        txtCuenta5_NE.AccessibleName = "cuenta5"
        txtCuenta6_NE.AccessibleName = "cuenta6"
        txtNombre_AN.AccessibleName = "nombre"
        cmbTipo.AccessibleName = "tipo"
        cmbNivel.AccessibleName = "nivel"
        cmbEstado.AccessibleName = "estado"

        Select Case Me.Tag.ToString
            Case sAGREGAR_
                txtCodEmpresa_NE.Enabled = False
                cmbNivel.Enabled = False
                If cmbNivel.Text = "6" Then
                    cmbTipo.Text = sImputable_
                    cmbTipo.Enabled = False
                End If

            Case sMODIFICAR_
                txtCodEmpresa_NE.Enabled = False
                txtCuenta1_NE.Enabled = False
                txtCuenta2_NE.Enabled = False
                txtCuenta3_NE.Enabled = False
                txtCuenta4_NE.Enabled = False
                txtCuenta5_NE.Enabled = False
                txtCuenta6_NE.Enabled = False
                cmbNivel.Enabled = False
                cmbEstado.Enabled = False
                If cmbNivel.Text = "1" Then
                    txtNombre_AN.Enabled = False
                Else
                    txtNombre_AN.Enabled = True
                End If
                If cmbTipo.Text = sTotales_ Then
                    If msCantSubCuentas = sSi_ Then
                        cmbTipo.Enabled = False
                    Else
                        cmbTipo.Enabled = True
                    End If
                Else
                    If msCantMovimientos = sSi_ Then
                        cmbTipo.Enabled = False
                    Else
                        cmbTipo.Enabled = True
                    End If
                End If
                If cmbNivel.Text = "6" Then
                    cmbTipo.Enabled = False
                End If
                If cmbNivel.Text = "6" And cmbTipo.Text = sTotales_ Then
                    cmbTipo.Text = sImputable_
                    cmbTipo.Enabled = False
                End If
                cmbNivel.Enabled = False
                LPParseaPartesCuenta()
                LPOcultaNivelesInferior(cmbNivel.Text)

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
                LPParseaPartesCuenta()
                LPOcultaNivelesInferior(cmbNivel.Text)
        End Select
    End Sub

    Private Sub LPParsearCodigoCuenta()
        Dim liUltimo As Integer = 0
        Dim lsNivel As String = ""
        Dim lsCuenta As String = ""
        Dim loCuenta As New Eb050plancuentas
        ' 12345678901234567890123456
        ' 0.00.000.0000.00000.000000
        loCuenta.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        loCuenta.codCuenta = txtCodigo_NE.Text
        If loCuenta.GetPK = sOk_ Then
            txtNombre_AN.Text = loCuenta.nombre
            If loCuenta.tipo = sTotales_.Substring(0, cmbTipo.MaxLength) Then
                Select Case loCuenta.nivel
                    Case "1"
                        liUltimo = 4
                        lsNivel = "2"
                    Case "2"
                        liUltimo = 8
                        lsNivel = "3"
                    Case "3"
                        liUltimo = 13
                        lsNivel = "4"
                    Case "4"
                        liUltimo = 19
                        lsNivel = "5"
                    Case "5"
                        liUltimo = 26
                        lsNivel = "6"
                End Select
            Else
                lsNivel = loCuenta.nivel
                Select Case loCuenta.nivel
                    Case "2"
                        liUltimo = 4
                    Case "3"
                        liUltimo = 8
                    Case "4"
                        liUltimo = 13
                    Case "5"
                        liUltimo = 19
                    Case "6"
                        liUltimo = 26
                End Select
            End If
            lsCuenta = txtCodigo_NE.Text.Substring(0, liUltimo)
            lsCuenta = LFsSiguienteCuenta(lsCuenta, liUltimo, lsNivel)
            Select Case lsNivel
                Case "2"
                    txtCodigo_NE.Text = lsCuenta & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "3"
                    txtCodigo_NE.Text = lsCuenta & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "4"
                    txtCodigo_NE.Text = lsCuenta & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
                Case "5"
                    txtCodigo_NE.Text = lsCuenta & sSeparador_ & sCero6_
                Case "6"
                    txtCodigo_NE.Text = lsCuenta
            End Select
            cmbNivel.Text = lsNivel
            LPParseaPartesCuenta()
            LPBloqueaNivelesInferior(lsNivel)
            LPOcultaNivelesInferior(lsNivel)
        End If
    End Sub

    Private Sub LPBloqueaNivelesInferior(ByVal psNivel As String)
        txtCuenta1_NE.Enabled = False
        txtCuenta2_NE.Enabled = False
        txtCuenta3_NE.Enabled = False
        txtCuenta4_NE.Enabled = False
        txtCuenta5_NE.Enabled = False
        txtCuenta6_NE.Enabled = False
        Select Case psNivel
            Case "2"
                txtCuenta2_NE.Enabled = True
            Case "3"
                txtCuenta3_NE.Enabled = True
            Case "4"
                txtCuenta4_NE.Enabled = True
            Case "5"
                txtCuenta5_NE.Enabled = True
            Case "6"
                txtCuenta6_NE.Enabled = True
        End Select
        cmbNivel.Text = psNivel
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
        txtCodigo_NE.Visible = False
    End Sub

    Private Sub LPParseaPartesCuenta()
        txtCuenta1_NE.Text = txtCodigo_NE.Text.Substring(0, sCero1_.Length)
        txtCuenta2_NE.Text = txtCodigo_NE.Text.Substring(2, sCero2_.Length)
        txtCuenta3_NE.Text = txtCodigo_NE.Text.Substring(5, sCero3_.Length)
        txtCuenta4_NE.Text = txtCodigo_NE.Text.Substring(9, sCero4_.Length)
        txtCuenta5_NE.Text = txtCodigo_NE.Text.Substring(14, sCero5_.Length)
        txtCuenta6_NE.Text = txtCodigo_NE.Text.Substring(20, sCero6_.Length)
    End Sub

    Private Function LFsSiguienteCuenta(ByVal psCuenta As String, ByVal piUltimo As Integer, ByVal psNivel As String) As String
        Dim lsResultado As String = LFsObtieneCuenta(psCuenta, piUltimo, psNivel)
        Dim lsPedazo As String = ""
        Dim liDesde As Integer = 0
        Dim liCantidad As Integer = 0
        Dim liSiguiente As Integer = 0
        Select Case psNivel
            Case "2"
                liDesde = Len(sCero1_ & sSeparador_)
                liCantidad = Len(sCero2_)
            Case "3"
                liDesde = Len(sCero1_ & sSeparador_ & sCero2_ & sSeparador_)
                liCantidad = Len(sCero3_)
            Case "4"
                liDesde = Len(sCero1_ & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_)
                liCantidad = Len(sCero4_)
            Case "5"
                liDesde = Len(sCero1_ & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_)
                liCantidad = Len(sCero5_)
            Case "6"
                liDesde = Len(sCero1_ & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_)
                liCantidad = Len(sCero6_)
        End Select

        lsPedazo = lsResultado.Substring(liDesde, liCantidad)
        liSiguiente = Integer.Parse(lsPedazo) + 1
        Select Case psNivel
            Case "2"
                liCantidad = sCero2_.Length
            Case "3"
                liCantidad = sCero3_.Length
            Case "4"
                liCantidad = sCero4_.Length
            Case "5"
                liCantidad = sCero5_.Length
            Case "6"
                liCantidad = sCero6_.Length
        End Select
        lsResultado = psCuenta.Substring(0, psCuenta.Length - liCantidad) & liSiguiente.ToString("D" & psNivel)
        Return lsResultado
    End Function

    Private Function LFsObtieneCuenta(ByVal psCuenta As String, ByVal piUltimo As Integer, ByVal psNivel As String) As String
        Dim lsResultado As String = ""
        Dim lsSQL As String = GFsGeneraSQL("Eb050plancuentas_Siguiente")
        lsSQL = lsSQL.Replace("@posicion", piUltimo.ToString)
        Dim lsCuenta As String = psCuenta
        Select Case psNivel
            Case "2"
                lsCuenta = lsCuenta.Substring(0, lsCuenta.Length - sCero2_.Length)
            Case "3"
                lsCuenta = lsCuenta.Substring(0, lsCuenta.Length - sCero3_.Length)
            Case "4"
                lsCuenta = lsCuenta.Substring(0, lsCuenta.Length - sCero4_.Length)
            Case "5"
                lsCuenta = lsCuenta.Substring(0, lsCuenta.Length - sCero5_.Length)
            Case "6"
                lsCuenta = lsCuenta.Substring(0, lsCuenta.Length - sCero6_.Length)
        End Select
        lsSQL = lsSQL.Replace("@cuenta", lsCuenta)
        lsSQL = lsSQL.Replace("@nivel", psNivel)
        Dim loPCuentas As New Eb050plancuentas
        Dim loDatos As DbDataReader = Nothing
        Try
            loPCuentas.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
            loDatos = loPCuentas.RecuperarConsulta(lsSQL)
            If loDatos.Read Then
                If Not loDatos.Item("cuenta") Is DBNull.Value Then
                    lsResultado = loDatos.Item("cuenta").ToString
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("frmFb050plancuentas.LFsSiguienteCuenta.Read" & ControlChars.CrLf & ex.Message)
        End Try
        loDatos.Close()
        loDatos = Nothing
        If lsResultado.Trim.Length = 0 Then lsResultado = psCuenta

        Return lsResultado
    End Function

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        Select Case Me.Tag.ToString
            Case sAGREGAR_
                Select Case cmbNivel.Text
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
            Case sMODIFICAR_
                txtNombre_AN.Focus()
        End Select
        LPDespliegaDescripciones()
    End Sub
    Private Sub LPDespliegaDescripciones()
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        txtCodEmpresa_NE.Text = liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength)

        Dim lsCodCuenta As String = txtCodigo_NE.Text
        If lsCodCuenta.Trim.Length = 0 Then
            txtCodigo_NE.Text = sCero1_ & sSeparador_ & sCero2_ & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_ & sSeparador_ & sCero6_
        End If

        lblNombreEmpresa.Text = ""
        Dim loFK As New Ec001empresas
        loFK.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        If loFK.GetPK = sOk_ Then
            lblNombreEmpresa.Text = loFK.nombre
        End If
        loFK.CerrarConexion()
        loFK = Nothing

        Dim loFK1 As New Eb050plancuentas
        loFK1.codEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        loFK1.codCuenta = txtCodigo_NE.Text
        If loFK1.GetPK = sOk_ Then
            txtNombre_AN.Text = loFK1.nombre
        End If
        loFK1.CerrarConexion()
        loFK1 = Nothing
    End Sub

    Private Sub LPInicializaMaxLength()
        txtCodEmpresa_NE.MaxLength = 6
        txtCuenta1_NE.MaxLength = 1
        txtCuenta2_NE.MaxLength = 2
        txtCuenta3_NE.MaxLength = 3
        txtCuenta4_NE.MaxLength = 4
        txtCuenta5_NE.MaxLength = 5
        txtCuenta6_NE.MaxLength = 6
        txtNombre_AN.MaxLength = 128
        cmbTipo.MaxLength = 1
        cmbNivel.MaxLength = 1
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

        Dim loDatos As New Eb050plancuentas
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        loDatos.codEmpresa = liCodEmpresa
        loDatos.codCuenta = txtCodigo_NE.Text
        If loDatos.GetPK = sOk_ Then
            loDatos.codEmpresa = liCodEmpresa
            loDatos.codCuenta = txtCodigo_NE.Text
            loDatos.Del(sNo_, sNo_)
        End If
        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub
End Class