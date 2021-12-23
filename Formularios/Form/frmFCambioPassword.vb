Imports System.ComponentModel

Public Class frmFCambioPassword
    Private msValidado As String = ""
    Private msRequeridos As String() = {"passwordActual", "passwordNuevo", "passwordNuevo2"}
    Private moRequeridos As New ArrayList(msRequeridos)

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
                txtPasswordActual_AN.Focus()
            Else
                Select Case Me.Tag.ToString
                    Case sMODIFICAR_
                        Dim loDatos As New Ess050usuarios
                        loDatos.codigo = SesionActiva.usuario
                        If loDatos.GetPK = sOk_ Then
                            loDatos.password = GFsSHA256(txtPasswordNuevo_AN.Text)
                            loDatos.Put()
                        End If
                        loDatos.CerrarConexion()
                        loDatos = Nothing
                End Select
                Me.Tag = sOk_
                GPBitacoraRegistrar(sSALIO_, Me.Text & ", haciendo click en ACEPTAR.")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ManejoEvento_Validating(sender As Object, e As CancelEventArgs)

        If CType(sender, Control).Text.Trim.Length = 0 Then
            If LFsExiste(CType(sender, Control).AccessibleName) = sNo_ Then Exit Sub
            Dim lsValorInicial As String = ""
            Select Case CType(sender, Control).AccessibleName
            End Select
            CType(sender, Control).Text = lsValorInicial
            CType(sender, Control).Tag = sCancelar_
            e.Cancel = True
        Else
            Select Case CType(sender, Control).AccessibleName
                Case "passwordActual"
                    Dim loDatos As New Ess050usuarios
                    loDatos.codigo = SesionActiva.usuario
                    If loDatos.GetPK = sOk_ Then
                        If GFsSHA256(txtPasswordActual_AN.Text) <> loDatos.password Then
                            GFsAvisar("La contraseña [" & txtPasswordActual_AN.Text & "] ingresada como actual", sMENSAJE_, "No es valida, favor reintentelo.")
                            txtPasswordActual_AN.Text = ""
                            e.Cancel = True
                        End If
                    Else
                        GFsAvisar("Esto no deberia haber pasado", sViolacion_, "El usuario [" & SesionActiva.usuario & "] no es un usuario autorizado.")
                    End If
                Case "passwordNuevo2"
                    If txtPasswordNuevo_AN.Text <> txtPasswordNuevo2_AN.Text Then
                        GFsAvisar("Los password introducidos no coinciden", sMENSAJE_, "favor reingreselos para poder concluir esta operación.")
                        txtPasswordNuevo_AN.Text = ""
                        txtPasswordNuevo2_AN.Text = ""
                        txtPasswordNuevo_AN.Focus()
                    End If
            End Select
        End If
    End Sub

    Private Sub ManejoEvento_Validated(sender As Object, e As EventArgs)
        CType(sender, Control).Tag = sOk_
        Select Case CType(sender, Control).Name
        End Select
    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = "Cambiar contraseña de " & SesionActiva.usuario
        LPInicializaMaxLength()
        LPInicializaControles()
        Dim loControls As TabPage.ControlCollection = Me.TabPage1.Controls

        ' Inicializa los controles de edición con los valores pertinentes
        msEntidad = "contraseña usuario activo"
        DesplegarMensaje()

        ' Habilita o deshabilita los controles de edición
        txtPasswordActual_AN.Enabled = True
        txtPasswordNuevo_AN.Enabled = True
        txtPasswordNuevo2_AN.Enabled = True

        txtPasswordActual_AN.AccessibleName = "passwordActual"
        txtPasswordNuevo_AN.AccessibleName = "passwordNuevo"
        txtPasswordNuevo2_AN.AccessibleName = "passwordNuevo2"
    End Sub

    Private Sub Formulario_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        '--> AQUI DEBE INGRESARSE EL FOCUS DEL PRIMER ELEMENTO DEL FORMULARIO
        If InStr(sAGREGAR_ & sSF_ & sMODIFICAR_, Me.Tag.ToString) > 0 Then
            txtPasswordActual_AN.Focus()
        End If
    End Sub

    Private Overloads Sub LPInicializaMaxLength()
        txtPasswordActual_AN.MaxLength = 15
        txtPasswordNuevo_AN.MaxLength = 15
        txtPasswordNuevo2_AN.MaxLength = 15
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
                            AddHandler loControl.KeyDown, AddressOf ManejoEvento_KeyDown
                    End Select
                Next
            End If
        Next
    End Sub
End Class