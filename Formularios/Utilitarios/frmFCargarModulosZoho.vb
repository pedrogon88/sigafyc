Imports System.ComponentModel

Public Class frmFCargarModulosZoho
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim lsEliminar As String = ""
        If rbtSI.Checked = True Then
            lsEliminar = sSi_
            If rbtNO.Checked = True Then
                lsEliminar = sNo_
            End If
        End If

        GPCargarTablasSettingsZoho(txtModulosPermitidos_AN.Text, lsEliminar)
    End Sub

    Private Sub frmFCargarModulosZoho_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblMensaje.Text = "Usuario: " & SesionActiva.usuario & ", IP:" & SesionActiva.ip
        txtModulosPermitidos_AN.Text = GFsParametroObtener(sGeneral_, "ZohoAPI V2 - Modulos Permitidos")
    End Sub

    Private Sub txtModulosPermitidos_AN_Validating(sender As Object, e As CancelEventArgs) Handles txtModulosPermitidos_AN.Validating
        If txtModulosPermitidos_AN.Text.Trim.Length = 0 Then
            Dim lsRepuesta As String = GFsAvisar("Al dejar en blanco este campo indica que desea que tome el valor parametrizado.", sMENSAJE_)
            txtModulosPermitidos_AN.Text = GFsParametroObtener(sGeneral_, "ZohoAPI V2 - Modulos Permitidos")
            e.Cancel = True
        End If
    End Sub
End Class