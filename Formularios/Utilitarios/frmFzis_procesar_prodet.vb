Public Class frmFzis_procesar_prodet
    Public Property NumTra As Integer = 0
    Public Property NumOrd As Integer = 0
    Private moZIS_PROCAB As Ezis_procab
    Private moZIS_PRODET As Ezis_prodet

    Private Sub frmFzis_procesar_prodet_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnAceptar.Enabled = False
        If NumTra > 0 Then
            moZIS_PROCAB = New Ezis_procab
            moZIS_PROCAB.numtra = NumTra
            If moZIS_PROCAB.GetPK = sOk_ Then
                If Not (moZIS_PROCAB.formproc = sManual_) Then
                    GFsAvisar("Proceso Integración No:" & moZIS_PROCAB.numtra.ToString & ", NO esta definido para que pueda procesarse manualmente!!", sMENSAJE_)
                    Me.Close()
                    Exit Sub
                Else
                    moZIS_PRODET = New Ezis_prodet
                    moZIS_PRODET.numtra = NumTra
                    moZIS_PRODET.numord = NumOrd
                    If Not (moZIS_PRODET.GetPK = sOk_) Then
                        GFsAvisar("Proceso Integración No:" & NumTra.ToString & ", Linea No.:" & NumOrd.ToString & " no existe!!," & vbCrLf & "ESTO NO DEBERIA HABER PASADO!!", sMENSAJE_)
                        Me.Close()
                        Exit Sub
                    End If
                End If
            Else
                GFsAvisar("Proceso Integración No:" & NumTra.ToString & ", no existe!!", sMENSAJE_)
                Me.Close()
                Exit Sub
            End If

            txtNumTra_NE.ReadOnly = True
            txtNumOrd_NE.ReadOnly = True
            txtNumMod_NE.ReadOnly = True
            cmbFormAct.Enabled = False
            txtStart.ReadOnly = True
            txtEnding.ReadOnly = True

            Dim loZIS_MODCAB As Ezis_modcab = New Ezis_modcab
            loZIS_MODCAB.numtra = moZIS_PRODET.nummod
            If Not (loZIS_MODCAB.GetPK = sOk_) Then
                GFsAvisar("Modelo Integración No.:" & moZIS_PRODET.nummod.ToString & ", no existe, ESTO NO DEBERIA HABER PASADO!!!", sMENSAJE_)
                Me.Close()
                Exit Sub
            End If

            txtNumTra_NE.Text = moZIS_PRODET.numtra.ToString
            txtNumOrd_NE.Text = moZIS_PRODET.numord.ToString
            txtNumMod_NE.Text = moZIS_PRODET.nummod.ToString
            lblNomMod.Text = loZIS_MODCAB.nombre
            cmbFormAct.Text = moZIS_PRODET.formact.ToString
            txtStart.Text = moZIS_PRODET.start.ToString
            txtEnding.Text = moZIS_PRODET.ending.ToString
            btnAceptar.Enabled = True
            loZIS_MODCAB.CerrarConexion()
        Else
            Exit Sub
        End If

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        GPProcesoCabecera(moZIS_PRODET.numtra, moZIS_PRODET.numord)
        Me.Close()
        moZIS_PROCAB.CerrarConexion()
        moZIS_PRODET.CerrarConexion()
    End Sub
End Class