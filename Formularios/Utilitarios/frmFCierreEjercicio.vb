Imports System.ComponentModel
Imports System.Data.Common

Public Class frmFCierreEjercicio
    Private msValidado As String = ""
    Private mbPrimeraVez As Boolean = True
    Private msPeriodoInicio As String = ""
    Private msPeriodoFinal As String = ""

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        LPInicializaMaxLength()
        LPInicializaControles()
        LPInicializarPredeterminados()
        lblNombreEmpresa.Text = ""
        lblNombreSucursal.Text = ""
        lblNombreDocumento.Text = ""
        chkCabecera.Checked = True
        chkSaldos.Checked = True
    End Sub

    Private Sub Form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If mbPrimeraVez Then
            mbPrimeraVez = False
            txtCodEmpresa_NE.Focus()
        End If
    End Sub

    Private Sub txtCodEmpresa_NE_Validating(sender As Object, e As CancelEventArgs) Handles txtCodEmpresa_NE.Validating
        If txtCodEmpresa_NE.Text.Trim.Length = 0 Then
            GFsAvisar("Debe ingresar codigo de empresa valido", sMENSAJE_, "Por favor intentelo de nuevo.")
            Dim lsValor As String = GFsParametroObtener(sUsuario_, Me.Name & "_" & CType(sender, Control).Name)
            If lsValor = sRESERVADO_ Then
                txtCodEmpresa_NE.Text = "0"
            Else
                txtCodEmpresa_NE.Text = lsValor
            End If
            e.Cancel = True
            Exit Sub
        End If
        If Not IsNumeric(txtCodEmpresa_NE.Text) Then
            GFsAvisar("El codigo de empresa debe ser un valor numerico", sMENSAJE_, "Por favor intentelo de nuevo.")
            txtCodEmpresa_NE.Text = "0"
            e.Cancel = True
            Exit Sub
        End If
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)

        Dim loFK As New Ec001empresas
        loFK.codEmpresa = liCodEmpresa
        If loFK.GetPK = sSinRegistros_ Then
            Dim loLookUp As New frmBc001empresas
            loLookUp.Tag = sELEGIR_
            GPCargar(loLookUp)
            If loLookUp.entidad IsNot Nothing Then
                txtCodEmpresa_NE.Text = CType(loLookUp.entidad, Ec001empresas).codEmpresa.ToString
            Else
                e.Cancel = True
                Exit Sub
            End If
            loLookUp = Nothing
        End If
        loFK.CerrarConexion()
        loFK = Nothing
        LPDespliegaDescripciones()

        If GFsPuedeUsar("Empresa No." & liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength), "Puede gestionar la Empresa No." & liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength)) <> sSi_ Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub txtCodSucursal_NE_Validating(sender As Object, e As CancelEventArgs) Handles txtCodSucursal_NE.Validating
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)

        If txtCodSucursal_NE.Text.Trim.Length = 0 Then
            Dim lsValor As String = GFsParametroObtener(sUsuario_, Me.Name & "_" & CType(sender, Control).Name)
            If lsValor = sRESERVADO_ Then
                txtCodSucursal_NE.Text = "0"
            Else
                txtCodSucursal_NE.Text = lsValor
            End If
            e.Cancel = True
            Exit Sub
        End If

        If Not IsNumeric(txtCodSucursal_NE.Text) Then
            txtCodSucursal_NE.Text = "0"
            e.Cancel = True
            Exit Sub
        End If

        Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text.ToString)

        If liCodSucursal > 0 Then
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
                End If
                e.Cancel = True
                loLookUp = Nothing
            End If
            loFK.CerrarConexion()
            loFK = Nothing
            If GFsPuedeUsar("Empresa No." & liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength) & "- Sucursal No." & liCodSucursal.ToString(sFormatD_ & txtCodSucursal_NE.MaxLength), "Puede gestionar Empresa No." & liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength) & "- Sucursal No." & liCodSucursal.ToString(sFormatD_ & txtCodSucursal_NE.MaxLength)) <> sSi_ Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub txtCodDocumento_NE_Validating(sender As Object, e As CancelEventArgs) Handles txtCodDocumento_NE.Validating
        If Not IsNumeric(txtCodEmpresa_NE.Text) Then Exit Sub
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        If liCodEmpresa = 0 Then Exit Sub

        If txtCodDocumento_NE.Text.Trim.Length = 0 Then
            txtCodDocumento_NE.Text = "0"
            e.Cancel = True
            Exit Sub
        End If

        If Not IsNumeric(txtCodDocumento_NE.Text) Then Exit Sub
        Dim liCodDocumento As Integer = Integer.Parse(txtCodDocumento_NE.Text.ToString)

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
                txtCodDocumento_NE.Text = CType(loLookUp.entidad, Ec020documentos).codDocumento.ToString
            End If
            loLookUp = Nothing
            e.Cancel = True
            Exit Sub
        End If
        loFK.CerrarConexion()
        loFK = Nothing
        LPDespliegaDescripciones()
    End Sub

    Private Sub txtFecha_FE_Validating(sender As Object, e As CancelEventArgs) Handles txtFecha_FE.Validating
        If txtFecha_FE.Text.Trim.Length = 0 Then
            txtFecha_FE.Text = Today.ToString("yyyy-MM-dd")
            e.Cancel = True
            Exit Sub
        End If
        If Not IsDate(txtFecha_FE.Text) Then
            GFsAvisar("El dato ingresado [" & txtFecha_FE.Text & "] no es una fecha valida", sMENSAJE_, "reintentelo de nuevo")
            e.Cancel = True
            Exit Sub
        End If
        Dim ldFecha As Date = Date.Parse(txtFecha_FE.Text.ToString)
        txtFecha_FE.Text = ldFecha.ToString(sFormatoFecha1_)
        If Not (txtFecha_FE.Text >= msPeriodoInicio And txtFecha_FE.Text <= msPeriodoFinal) Then
            GFsAvisar("La fecha ingresada [" & txtFecha_FE.Text & "] esta fuera del rango del periodo contable vigente", sMENSAJE_, "Periodo vigente [" & msPeriodoInicio & " - " & msPeriodoFinal & "]")
            e.Cancel = True
            Exit Sub
        End If
        LPDespliegaDescripciones()
    End Sub

    Private Sub LPDespliegaDescripciones()
        Dim liCodEmpresa As Integer = 0
        Dim liCodSucursal As Integer = 0
        Dim liCodDocumento As Integer = 0

        lblNombreEmpresa.Text = ""
        If txtCodEmpresa_NE.Text.Trim.Length > 0 Then
            Dim loFK As New Ec001empresas
            liCodEmpresa = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
            loFK.codEmpresa = liCodEmpresa
            If loFK.GetPK = sOk_ Then
                lblNombreEmpresa.Text = loFK.nombre
                msPeriodoInicio = loFK.periodoInicio
                msPeriodoFinal = loFK.periodoFinal
            End If
            loFK.CerrarConexion()
            loFK = Nothing
            txtCodEmpresa_NE.Text = liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength)
        End If

        lblNombreSucursal.Text = ""
        If txtCodEmpresa_NE.Text.Trim.Length > 0 Then
            If txtCodSucursal_NE.Text.Trim.Length > 0 Then
                If Not IsNumeric(txtCodSucursal_NE.Text) Then Exit Sub
                liCodSucursal = Integer.Parse(txtCodSucursal_NE.Text.ToString)

                If liCodSucursal = 0 Then
                    lblNombreSucursal.Text = "TODAS LAS SUCURSALES"
                Else
                    Dim loFK As New Eb070sucursales
                    loFK.codEmpresa = liCodEmpresa
                    loFK.codSucursal = liCodSucursal
                    If loFK.GetPK = sOk_ Then
                        lblNombreSucursal.Text = loFK.nombre
                    End If
                    loFK.CerrarConexion()
                    loFK = Nothing
                End If
            End If
            txtCodSucursal_NE.Text = liCodSucursal.ToString(sFormatD_ & txtCodSucursal_NE.MaxLength)
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
            End If
            loFK.CerrarConexion()
            loFK = Nothing
        End If
        txtCodEmpresa_NE.Text = liCodEmpresa.ToString(sFormatD_ & txtCodEmpresa_NE.MaxLength)
        txtCodSucursal_NE.Text = liCodSucursal.ToString(sFormatD_ & txtCodSucursal_NE.MaxLength)
        txtCodDocumento_NE.Text = liCodDocumento.ToString(sFormatD_ & txtCodDocumento_NE.MaxLength)
    End Sub

    Private Sub LPInicializaMaxLength()
        txtCodEmpresa_NE.MaxLength = 6
        txtCodSucursal_NE.MaxLength = 3
        txtCodDocumento_NE.MaxLength = 3
        txtFecha_FE.MaxLength = 10
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
                        Case sPrefijoRadioButton_
                            loControl.Tag = sOk_
                            AddHandler loControl.Validated, AddressOf ManejoEvento_Validated
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                        AddHandler loControl1.KeyPress, AddressOf ManejoEvento_KeyPress
                                    Case sPrefijoComboBox_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                    Case sPrefijoRadioButton_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                    Case sPrefijoCheckBox_
                                        AddHandler loControl1.Validated, AddressOf ManejoEvento_Validated
                                        AddHandler loControl1.KeyDown, AddressOf ManejoEvento_KeyDown
                                End Select
                            Next
                    End Select
                Next
            End If
        Next
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        msValidado = ""
        For Each loControl As Control In Me.TabPage1.Controls
            Select Case loControl.Name.Substring(0, 3)
                Case sPrefijoGroupBox_
                    For Each loControl1 As Control In loControl.Controls
                        Select Case loControl1.Name.Substring(0, 3)
                            Case sPrefijoTextBox_
                                If InStr(sDEControles_, loControl1.Name.Substring(0, 3)) > 0 Then
                                    msValidado &= loControl1.Tag.ToString
                                End If
                        End Select
                    Next
                Case Else
                    If InStr(sDEControles_, loControl.Name.Substring(0, 3)) > 0 Then
                        msValidado &= loControl.Tag.ToString
                    End If
            End Select
        Next
        If InStr(msValidado, sCancelar_) > 0 Then
            GFsAvisar("Validacion final", sMENSAJE_, "No han sido ingresado correctamente todos los datos")
            txtCodEmpresa_NE.Focus()
            Exit Sub
        End If
        If GFsConfirmacion(sMENSAJE_, "Esta a punto de generar los asientos de Cierre de Ejercicio, para la Empresa:" & lblNombreEmpresa.Text & ", Sucursal:" & lblNombreSucursal.Text & ", con el Documento:" & lblNombreDocumento.Text & " y fecha de cierre:" & txtFecha_FE.Text) = sOk_ Then
            btnAceptar.Enabled = False
            btnCancelar.Enabled = False
            LPProcesaParametros()
            LPGuardaValoresPredeterminados()
            GPBitacoraRegistrar(sSALIO_, Me.Text & ", dando click en [ACEPTAR]")
        Else
            GPBitacoraRegistrar(sSALIO_, Me.Text & ", CANCELANDO")
        End If
        Me.Close()
    End Sub

    Private Sub LPProcesaParametros()
        Dim liCodEmpresa As Integer = Integer.Parse(txtCodEmpresa_NE.Text.ToString)
        Dim liCodSucursal As Integer = Integer.Parse(txtCodSucursal_NE.Text.ToString)
        Dim liCodDocumento As Integer = Integer.Parse(txtCodDocumento_NE.Text.ToString)
        Dim lsFecha As String = txtFecha_FE.Text
        If liCodSucursal = 0 Then
            Dim lsSQL As String = GFsGeneraSQL("frmFCierreEjercicio_Sucursales")
            lsSQL = lsSQL.Replace("@codempresa", liCodDocumento.ToString)
            Dim loDataReader As DbDataReader
            Dim loCN As New BaseDatos
            loCN.SetearParametrosConexion(sRegistryTablasPrincipal_)
            loCN.Conectar("TablaGenerica")
            loCN.CrearComando(lsSQL)
            loDataReader = loCN.EjecutarConsulta
            While loDataReader.Read
                liCodSucursal = Integer.Parse(loDataReader.Item("codsucursal").ToString)
                GPCierreEjercicio(liCodEmpresa, liCodSucursal, liCodDocumento, lsFecha, chkSaldos.Checked, chkCabecera.Checked)
            End While
            loDataReader.Close()
            loDataReader = Nothing
            loCN.Desconectar()
            loCN = Nothing
        Else
            GPCierreEjercicio(liCodEmpresa, liCodSucursal, liCodDocumento, lsFecha)
        End If

    End Sub


    Private Sub LPGuardaValoresPredeterminados()
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            GPParametroGuardar(sUsuario_, Me.Name & "_" & loControl.Name, loControl.Text)
                        Case sPrefijoComboBox_
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        GPParametroGuardar(sUsuario_, Me.Name & "_" & loControl1.Name, loControl1.Text)
                                End Select
                            Next
                    End Select
                Next
            End If
        Next
    End Sub

    Private Sub LPInicializarPredeterminados()
        Dim lsValor As String = ""
        For Each loTabPage As TabPage In TabControl1.TabPages
            If loTabPage.AccessibleName = sActivo_ Then
                For Each loControl As Control In loTabPage.Controls
                    Select Case loControl.Name.Substring(0, 3)
                        Case sPrefijoTextBox_
                            lsValor = GFsParametroObtener(sUsuario_, Me.Name & "_" & loControl.Name)
                            If lsValor <> sRESERVADO_ Then
                                loControl.Text = lsValor
                                loControl.Tag = sOk_
                            End If
                        Case sPrefijoComboBox_
                        Case sPrefijoGroupBox_
                            For Each loControl1 As Control In loControl.Controls
                                Select Case loControl1.Name.Substring(0, 3)
                                    Case sPrefijoTextBox_
                                        lsValor = GFsParametroObtener(sUsuario_, Me.Name & "_" & loControl1.Name)
                                        If lsValor <> sRESERVADO_ Then
                                            loControl1.Text = lsValor
                                            loControl1.Tag = sOk_
                                        End If
                                End Select
                            Next
                    End Select
                Next
            End If
        Next
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        GPBitacoraRegistrar(sSALIO_, Me.Text & ", dando click en [CANCELAR]")
    End Sub
End Class