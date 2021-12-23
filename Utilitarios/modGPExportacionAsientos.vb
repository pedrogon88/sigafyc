Module modGPExportacionAsientos

    Public Sub GPExportacionAsientos(ByVal piCodEmpresa As Integer, ByVal piCodSucursal As Integer, ByVal psFecha1 As String, ByVal psFecha2 As String, ByVal piAsiento1 As Integer, ByVal piAsiento2 As Integer)
        Dim lsSucursal As String = ""
        Dim lsSQL As String = GFsGeneraSQL("GPExportacionAsientos")
        lsSQL = lsSQL.Replace("@codempresa", piCodEmpresa.ToString)
        If piCodSucursal > 0 Then
            lsSucursal = "AND e010.codsucursal = " & piCodSucursal.ToString
        End If
        lsSQL = lsSQL.Replace("@Sucursal", lsSucursal)
        lsSQL = lsSQL.Replace("@fecha1", psFecha1)
        lsSQL = lsSQL.Replace("@fecha2", psFecha2)
        lsSQL = lsSQL.Replace("@asiento1", piAsiento1.ToString)
        lsSQL = lsSQL.Replace("@asiento2", piAsiento2.ToString)
        Dim lsMensaje As String = "Parametros a utilizar" & ControlChars.CrLf
        lsMensaje &= "Codigo empresa:" & piCodEmpresa.ToString & ControlChars.CrLf
        lsMensaje &= "Codigo sucursal:" & piCodSucursal.ToString & ControlChars.CrLf
        lsMensaje &= "Fecha desde:" & psFecha1 & ControlChars.CrLf
        lsMensaje &= "Fecha hasta:" & psFecha2 & ControlChars.CrLf
        lsMensaje &= "Asiento desde:" & piAsiento1.ToString & ControlChars.CrLf
        lsMensaje &= "Asiento hasta:" & piAsiento2.ToString & ControlChars.CrLf

        GPBitacoraRegistrar(sINFORMAR_, lsMensaje)
        GPDatatableTexto(lsSQL, "Asientos")
    End Sub

End Module
