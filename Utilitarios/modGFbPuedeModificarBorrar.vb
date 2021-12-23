Imports System.Data.Common
Module modGFbPuedeModificarBorrar

    Public Function GFbPuedeModificarBorrar(ByVal psAccion As String, ByVal psTableName As String, ByVal psHash_Pk As String, ByVal psCodigo As String) As Boolean
        Dim lbResultado As Boolean = True

        Dim lsRestriccion As String = ""
        If psAccion <> sCONSULTAR_ Then
            Dim lsFechaHora As String = LFsFechaHoraCarga(psTableName, psHash_Pk)
            If lsFechaHora.Trim.Length = 0 Then
                Dim lsTableName As String = ""
                If psTableName.Substring(0, 2) = "ss" Then
                    lsTableName = psTableName.Substring(5, psTableName.Length - 5).ToUpper
                Else
                    lsTableName = psTableName.Substring(4, psTableName.Length - 4).ToUpper
                End If
                If GFsPuedeUsar(psTableName & "_Puede:" & psAccion & "_RegistroCreadoPorSistema") = sNo_ Then
                    GFsAvisar("Tabla: " & lsTableName & ControlChars.CrLf & "Codigo: " & psCodigo & ControlChars.CrLf & "Restringido para su accion [" & psAccion & "]", sMENSAJE_, "El registro ha sido creado por el sistema")
                    lbResultado = False
                End If
            Else
                Dim lsDatosAlta() As String = lsFechaHora.Split(sSF_)
                Dim liDias As Long = DateDiff(DateInterval.Day, Date.ParseExact(lsDatosAlta(1), "yyyy-MM-dd", Nothing), Today)
                Dim lsDias As String = GFsParametroObtener(sUsuario_, psTableName & " / " & psAccion & " / Cantidad dias anteriores")
                If lsDias = sRESERVADO_ Then
                    lsDias = "0"
                    GPParametroGuardar(sUsuario_, psTableName & " / " & psAccion & " / Cantidad dias anteriores", lsDias)
                End If
                If liDias > Val(lsDias) Then
                    If GFsPuedeUsar(psTableName & "_Puede:" & psAccion & "_RegistroDiasAnteriores") = sNo_ Then
                        lbResultado = False
                    Else
                        Dim lsValores As String = GFsParametroObtener(sUsuario_, psTableName & " / " & psAccion & " / Dias anteriores / De usuarios")
                        If lsValores <> sRESERVADO_ Then
                            If InStr(lsValores.ToLower, lsDatosAlta(0).ToLower) = 0 Then
                                If GFsPuedeUsar(psTableName & "_" & psAccion & "_RegistroDiasAnteriores_OtrosUsuarios") = sNo_ Then
                                    GFsAvisar("Su usuario puede [" & psAccion & "] registros de dias anteriores", sMENSAJE_, "Pero este fue cargado por [" & lsDatosAlta(0) & "] y usted solo puede " & psAccion.ToLower & " de [" & lsValores & "]")
                                    lbResultado = False
                                End If
                            End If
                        Else
                            lsValores = SesionActiva.usuario
                            GPParametroGuardar(sUsuario_, psTableName & " / " & psAccion & " / Dias anteriores / De usuarios", lsValores)
                        End If
                    End If
                End If
            End If
        End If
        Return lbResultado
    End Function

    Private Function LFsFechaHoraCarga(ByVal psTableName As String, ByVal psHash_Pk As String) As String
        Dim lsResultado As String = ""
        Dim loAuditoria As New Ess120bitdatcab
        Dim loDReader As DbDataReader
        Dim lsSQL As String = GFsGeneraSQL("Ess120bitdatcab_QuienCuando")
        loAuditoria.tabla = psTableName
        loAuditoria.pk_hash = psHash_Pk
        loDReader = loAuditoria.RecuperarConsulta(lsSQL)
        Do While loDReader.Read
            If loDReader.Item("operacion").ToString = sAGREGAR_ Then
                lsResultado = loDReader.Item("usuario").ToString & sSF_ & loDReader.Item("fechahora").ToString.Substring(0, 10)
                Exit Do
            End If
        Loop
        loDReader.Close()
        loDReader = Nothing
        loAuditoria.CerrarConexion()
        loAuditoria = Nothing

        Return lsResultado
    End Function

End Module
