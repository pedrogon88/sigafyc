Module modGFsEjercicioContable

    Public Function GFsEjercicioContable(ByVal piCodEmpresa As Integer) As String
        Dim lsCodEmpresa As String = piCodEmpresa.ToString(sFormatD_ & sCero6_.Length.ToString)
        Dim lsResultado As String = SesionActiva.Ejercicios(lsCodEmpresa)
        If lsResultado = sNODEFINIDO_ Then
            Dim loEmpresa As New Ec001empresas
            loEmpresa.codEmpresa = piCodEmpresa
            If loEmpresa.GetPK = sOk_ Then
                If loEmpresa.periodoInicio.Trim.Length > 0 Then
                    Dim ldFecha As Date = Date.Parse(loEmpresa.periodoInicio)
                    lsResultado = ldFecha.ToString("yyyy")
                End If
            End If
            loEmpresa.CerrarConexion()
            loEmpresa = Nothing
            SesionActiva.Ejercicios_Save(lsCodEmpresa, lsResultado)
        End If

        Return lsResultado
    End Function

End Module
