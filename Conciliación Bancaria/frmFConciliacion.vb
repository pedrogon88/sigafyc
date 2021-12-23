
Public Class frmFconciliacion

    Private Sub btnConciliacion_Click(sender As Object, e As EventArgs) Handles btnConciliacion.Click
        Dim frm As New CuadrodeProceso
        frm.Show("Espere un momento...")
        If ConciliacionBancaria() Then
            frm.Close()
            MessageBox.Show("Conciliación completada")

            btnDesExtracto.Visible = True
            btnDescMayor.Visible = True
        Else
            frm.Close()
            MessageBox.Show("Error al realizar la conciliación.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnDesExtracto_Click(sender As Object, e As EventArgs) Handles btnDesExtracto.Click
        ban = 1
        Dim frm As New frmFlistarInformes
        frm.ShowDialog()
        ds.Clear()
        ds.Dispose()
    End Sub

    Private Sub btnDescMayor_Click(sender As Object, e As EventArgs) Handles btnDescMayor.Click
        ban = 2
        Dim frm As New frmFlistarInformes
        frm.ShowDialog()
        ds.Clear()
        ds.Dispose()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class