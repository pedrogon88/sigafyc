
Public Class frmFimportar
    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        OpenFileDialog1.ShowDialog()
        txtExaminar.Text = OpenFileDialog1.FileName()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        'Conectar()
        If rdbExtracto.Checked = True Then
            Importar.importarExcelExtracto(txtExaminar.Text)
        ElseIf rdbMayor.Checked = True Then
            Importar.importarExcelMayorSAP(txtExaminar.Text)
        Else
            MsgBox("Debe seleccionar un Tipo de Planilla.")
        End If

        'Importar.importarExcelExtracto(txtExaminar.Text, DataGridView1)
    End Sub

    Private Sub frmFimportar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class