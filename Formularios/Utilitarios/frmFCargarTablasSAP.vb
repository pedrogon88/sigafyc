Imports System.ComponentModel

Public Class frmFCargarTablasSAP
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim lsEliminar As String = ""
        If rbtSI.Checked = True Then
            lsEliminar = sSi_
            If rbtNO.Checked = True Then
                lsEliminar = sNo_
            End If
        End If

        GPCargarTablasSAP(txtTablasPermitidas_AN.Text, lsEliminar)
    End Sub

    Private Sub frmFCargarTablasSAP_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblMensaje.Text = "Usuario: " & SesionActiva.usuario & ", IP:" & SesionActiva.ip
        txtTablasPermitidas_AN.Text = GFsParametroObtener(sGeneral_, "ZohoAPI V2 - Tablas SAP Permitidas")
    End Sub

    Private Sub txtTablasPermitidas_AN_Validating(sender As Object, e As CancelEventArgs) Handles txtTablasPermitidas_AN.Validating
        If txtTablasPermitidas_AN.Text.Trim.Length = 0 Then
            Dim lsRepuesta As String = GFsAvisar("Al dejar en blanco este campo indica que desea que tome el valor parametrizado.", sMENSAJE_)
            txtTablasPermitidas_AN.Text = GFsParametroObtener(sGeneral_, "ZohoAPI V2 - Tablas SAP Permitidas")
            e.Cancel = True
        End If
    End Sub
End Class