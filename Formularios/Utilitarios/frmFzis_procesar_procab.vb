Public Class frmFzis_procesar_procab

    Public Property NumTra As Integer = 0
    Private moZIS_PROCAB As Ezis_procab

    Private Sub frmFzis_procesar_procab_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnAceptar.Enabled = False
        If NumTra > 0 Then
            moZIS_PROCAB = New Ezis_procab
            moZIS_PROCAB.numtra = NumTra
            If moZIS_PROCAB.GetPK = sOk_ Then
                If Not (moZIS_PROCAB.formproc = sManual_) Then
                    GFsAvisar("Proceso Integración No:" & moZIS_PROCAB.numtra.ToString & ", NO esta definido para que pueda procesarse manualmente!!", sMENSAJE_)
                    Me.Close()
                    Exit Sub
                End If
            Else
                GFsAvisar("Proceso Integración No:" & NumTra.ToString & ", no existe!!", sMENSAJE_)
                Me.Close()
                Exit Sub
            End If

            txtNumTra_NE.ReadOnly = True
            txtNombre_AN.ReadOnly = True
            txtAbreviado_AN.ReadOnly = True
            cmbFormProc.Enabled = False
            cmbTipExec.Enabled = False
            cmbTipAct.Enabled = False
            txtStart.ReadOnly = True
            txtEnding.ReadOnly = True

            txtNumTra_NE.Text = moZIS_PROCAB.numtra.ToString
            txtNombre_AN.Text = moZIS_PROCAB.nombre
            txtAbreviado_AN.Text = moZIS_PROCAB.abreviado
            cmbFormProc.Text = moZIS_PROCAB.formproc
            cmbTipExec.Text = moZIS_PROCAB.tipexec
            cmbTipAct.Text = moZIS_PROCAB.tipact
            txtStart.Text = moZIS_PROCAB.start
            txtEnding.Text = moZIS_PROCAB.ending
            btnAceptar.Enabled = True
        Else
            Exit Sub
        End If
        moZIS_PROCAB.CerrarConexion()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        GPProcesoCabecera(moZIS_PROCAB.numtra)
        Me.Close()
    End Sub
End Class