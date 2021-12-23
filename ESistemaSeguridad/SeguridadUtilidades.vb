Module SeguridadUtilidades
    Public Function GFsControlaReloj(ByVal psAccesoSistema As String) As String
        Dim lsResultado As String = psAccesoSistema
        Dim lsUltimoAcceso As String
        Dim lsMensaje As String

        lsUltimoAcceso = GFsParametroObtener("Ultimo Acceso Sistema_", sLocal_)

        If psAccesoSistema < lsUltimoAcceso Then
            lsMensaje = "Violacion de Seguridad!!! " &
                        "El sistema a detectado un cambio de fecha/hora [" & psAccesoSistema.Substring(0, 19) & "] " &
                        "Ultima fecha/hora registrada [" & lsUltimoAcceso.Substring(0, 19) & "] "

            GFsAvisar(lsMensaje, sErrorHashid_, lsResultado)
            lsResultado = sViolacion_
        Else
            GPParametroGuardar("Ultimo Acceso Sistema_", psAccesoSistema, sLocal_)
        End If

        Return lsResultado
    End Function

End Module
