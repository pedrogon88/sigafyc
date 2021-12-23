Public Class frmFVisualizadorReporte
    Private Sub frmFVisualizadorReporte_Load(sender As Object, e As EventArgs) Handles Me.Load
        CrystalReportViewer1.ShowCloseButton = True
        CrystalReportViewer1.ShowLogo = False
        CrystalReportViewer1.ShowParameterPanelButton = False
        CrystalReportViewer1.DisplayStatusBar = True
        CrystalReportViewer1.DisplayToolbar = True
        CrystalReportViewer1.ShowTextSearchButton = True
        CrystalReportViewer1.ShowZoomButton = True
        CrystalReportViewer1.Zoom(150)
    End Sub
End Class