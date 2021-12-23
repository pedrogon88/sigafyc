Imports System.Data.Common

Module modGFsPuedeUsar
    Public Function GFsPuedeUsar(ByVal psSS080_codigo As String, Optional ByVal psNombreOpcion As String = sRESERVADO_, Optional ByVal psMensaje As String = sSi_) As String
        Dim lsSistema As String = SesionActiva.sistema
        Dim lsUsuario As String = SesionActiva.usuario
        Dim lsUsuarioSupervisor As String = SesionActiva.datosControl(sUsuarioSupervisor_).ToString

        GFsPuedeUsar = sNo_
        Dim lsResultado As String = SesionActiva.PuedeUsar(psSS080_codigo)
        If lsResultado <> sNODEFINIDO_ Then
            GFsPuedeUsar = lsResultado
            If lsResultado = sNo_ Then
                If psMensaje = sSi_ Then GFsAvisar("La opción " & psSS080_codigo.ToUpper & " no se encuentra habilitada para su usuario " & lsUsuario.ToUpper, sMENSAJE_, "Consulte con el Dpto. de Informatica.")
            End If
            Exit Function
        End If

        SesionActiva.PuedeUsar_Save(psSS080_codigo, GFsPuedeUsar)

        Dim loSS080 As New Ess080restricciones
        loSS080.ss010_codigo = lsSistema
        loSS080.codigo = lsUsuarioSupervisor
        If loSS080.GetPK = sSinRegistros_ Then
            loSS080.ss010_codigo = lsSistema
            loSS080.codigo = lsUsuarioSupervisor
            loSS080.nombre = "Puede utilizar todas las opciones del sistema"
            loSS080.estado = sActivo_
            Try
                loSS080.Add(sNo_, sNo_)
            Catch ex As Exception
                GFsAvisar("GFsPuedeUsar.VerificaRestriccion", sMENSAJE_, ex.Message)
                Exit Function
            End Try
        End If
        loSS080.CerrarConexion()
        loSS080 = Nothing

        loSS080 = New Ess080restricciones
        loSS080.ss010_codigo = lsSistema
        loSS080.codigo = psSS080_codigo
        If loSS080.GetPK = sSinRegistros_ Then
            loSS080.ss010_codigo = lsSistema
            loSS080.codigo = psSS080_codigo
            If psNombreOpcion.Trim.Length > 0 Then
                If psNombreOpcion = sRESERVADO_ Then
                    loSS080.nombre = "Descripción de restriccion " & psSS080_codigo
                Else
                    loSS080.nombre = psNombreOpcion
                End If
            Else
                loSS080.nombre = "Descripción de restriccion " & psSS080_codigo
            End If
            loSS080.estado = sActivo_
            Try
                loSS080.Add(sNo_, sNo_)
            Catch ex As Exception
                GFsAvisar("GFsPuedeUsar.VerificaRestriccion", sMENSAJE_, ex.Message)
                Exit Function
            End Try
        End If
        Dim lsEstado As String = loSS080.estado
        loSS080.CerrarConexion()
        loSS080 = Nothing

        If lsEstado = sBloqueado_ Then
            If psMensaje = sSi_ Then GFsAvisar("La opción [" & psSS080_codigo & "] se encuentra Bloqueado para su uso", sMENSAJE_, "Consulte con el Dpto. de Informatica.")
            Exit Function
        End If

        If lsUsuario = lsUsuarioSupervisor Then
            GFsPuedeUsar = sSi_
            SesionActiva.PuedeUsar_Save(psSS080_codigo, GFsPuedeUsar)
            Exit Function
        End If

        Dim loDataReader As DbDataReader
        Dim loSS090 As New Ess090perusu
        Dim lsSQL As String = GFsGeneraSQL("Ess090perusu_PuedeUsar")
        If lsSQL = sRESERVADO_ Then
            GFsAvisar("Ess090perusu_PuedeUsar", sMENSAJE_, "Aun no ha sido definido.")
            GFsPuedeUsar = sSi_
            SesionActiva.PuedeUsar_Save(psSS080_codigo, GFsPuedeUsar)
            Exit Function
        End If

        Dim loSS100 As New Ess100habilitaciones
        loSS090.ss050_codigo = lsUsuario
        loDataReader = loSS090.RecuperarConsulta(lsSQL)
        While loDataReader.Read()
            loSS100.ss010_codigo = lsSistema
            loSS100.tipo = sPerfil_
            loSS100.codigo = loDataReader.Item("ss070_codigo").ToString
            loSS100.ss080_codigo = lsUsuarioSupervisor
            If loSS100.GetPK = sOk_ Then
                If loSS100.estado = sActivo_ Then
                    If Today.ToString(sFormatoFecha1_) >= loSS100.valido And Today.ToString(sFormatoFecha1_) <= loSS100.expira Then
                        GFsPuedeUsar = sSi_
                        SesionActiva.PuedeUsar_Save(psSS080_codigo, GFsPuedeUsar)
                        Exit Function
                    End If
                End If
            End If

            loSS100.ss010_codigo = lsSistema
            loSS100.tipo = sPerfil_
            loSS100.codigo = loDataReader.Item("ss070_codigo").ToString
            loSS100.ss080_codigo = psSS080_codigo
            If loSS100.GetPK = sOk_ Then
                If loSS100.estado = sActivo_ Then
                    If Today.ToString(sFormatoFecha1_) >= loSS100.valido And Today.ToString(sFormatoFecha1_) <= loSS100.expira Then
                        GFsPuedeUsar = sSi_
                        SesionActiva.PuedeUsar_Save(psSS080_codigo, GFsPuedeUsar)
                        Exit Function
                    End If
                End If
            End If
        End While
        loDataReader.Close()
        loSS090.CerrarConexion()
        loSS090 = Nothing

        loSS100.ss010_codigo = lsSistema
        loSS100.tipo = sUsuario_
        loSS100.codigo = lsUsuario
        loSS100.ss080_codigo = psSS080_codigo
        If loSS100.GetPK = sOk_ Then
            If loSS100.estado = sActivo_ Then
                If Today.ToString(sFormatoFecha1_) >= loSS100.valido And Today.ToString(sFormatoFecha1_) <= loSS100.expira Then
                    GFsPuedeUsar = sSi_
                    SesionActiva.PuedeUsar_Save(psSS080_codigo, GFsPuedeUsar)
                    Exit Function
                End If
            End If
        End If
        If psMensaje = sSi_ Then GFsAvisar("La opción " & psSS080_codigo.ToUpper & " no se encuentra habilitada para su usuario " & lsUsuario.ToUpper, sMENSAJE_, "Consulte con el Dpto. de Informatica.")
        loSS100.CerrarConexion()
        loSS100 = Nothing
    End Function
End Module
