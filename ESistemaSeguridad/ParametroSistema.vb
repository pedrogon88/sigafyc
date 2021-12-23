Public Class ParametroSistema
    Private ss110 As Ess110parametros
    Private moSesionActiva As SesionActiva

    Public Function Obtener(ByVal psTipo As String, ByVal psClave As String, Optional ByVal psEscalando As String = sSi_) As String
        Dim lsResultado As String = ""
        Try
            lsResultado = LFsParametroGet(psTipo, psClave)
            If lsResultado = sNODEFINIDO_ Then
                lsResultado = sRESERVADO_
                If psEscalando = sSi_ Then
                    If psTipo <> sGeneral_ Then
                        lsResultado = LFsParametroGet(sGeneral_, psClave)
                        If lsResultado = sNODEFINIDO_ Then
                            lsResultado = sRESERVADO_
                            LPParametroSave(sGeneral_, psClave, lsResultado)
                        End If
                    End If
                End If
                LPParametroSave(psTipo, psClave, lsResultado)
            Else
                If lsResultado = sRESERVADO_ Then
                    If psEscalando = sSi_ Then
                        lsResultado = LFsParametroGet(sGeneral_, psClave)
                        If lsResultado = sNODEFINIDO_ Then
                            lsResultado = sRESERVADO_
                            LPParametroSave(sGeneral_, psClave, lsResultado)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Utiles.GFsAvisar("ParametrosSistema.Obtener", sError_, ex.Message)
        End Try
        Return lsResultado
    End Function

    Public Sub Guardar(ByVal psTipo As String, ByVal psClave As String, ByVal psValor As String, Optional ByVal psEscalando As String = sSi_)
        Try
            LPParametroSave(psTipo, psClave, psValor)
            If psEscalando = sSi_ Then
                If psTipo <> sGeneral_ Then
                    Dim lsResultado = LFsParametroGet(sGeneral_, psClave)
                    If lsResultado = sNODEFINIDO_ Or lsResultado = sRESERVADO_ Then
                        LPParametroSave(sGeneral_, psClave, psValor)
                    End If
                End If
            End If
        Catch ex As Exception
            Utiles.GFsAvisar("ParametrosSistema.Guardar", sError_, ex.Message)
        End Try
    End Sub

    Private Function LFsParametroGet(ByVal psTipo As String, ByVal psClave As String) As String
        Dim lsResultado As String = ""

        ss110 = New Ess110parametros

        ss110.ss010_codigo = SesionActiva.sistema
        ss110.tipo = psTipo
        ss110.prefijo = LFsPrefijo(psTipo)
        ss110.clave = psClave
        Try
            If ss110.GetPK = sOk_ Then
                If ss110.clave.Substring(ss110.clave.Length - 1, 1) <> sMarcaEncriptado_ Then
                    lsResultado = ss110.valor
                Else
                    Dim loDesEncriptar As New Encriptacion
                    lsResultado = loDesEncriptar.DesEncriptar(ss110.valor)
                End If
            Else
                lsResultado = sNODEFINIDO_
            End If
        Catch ex As Exception
            Throw New BaseDatosException("LFsParametroGet" & ControlChars.CrLf & ex.Message)
        End Try
        ss110.CerrarConexion()
        ss110 = Nothing
        Return lsResultado
    End Function

    Private Sub LPParametroSave(ByVal psTipo As String, ByVal psClave As String, ByVal psValor As String)
        Dim lbExiste As Boolean = False
        ss110 = New Ess110parametros

        ss110.ss010_codigo = SesionActiva.sistema
        ss110.tipo = psTipo
        ss110.prefijo = LFsPrefijo(psTipo)
        ss110.clave = psClave
        Try
            If ss110.GetPK = sOk_ Then
                lbExiste = True
            End If
        Catch ex As Exception
            Throw New BaseDatosException(ex.Message)
        End Try

        ss110.ss010_codigo = SesionActiva.sistema
        ss110.tipo = psTipo
        ss110.prefijo = LFsPrefijo(psTipo)
        ss110.clave = psClave
        If ss110.clave.Substring(ss110.clave.Length - 1, 1) <> sMarcaEncriptado_ Then
            ss110.valor = psValor
        Else
            Dim loEncriptar As New Encriptacion
            ss110.valor = loEncriptar.Encriptar(psValor)
        End If

        Try
            If lbExiste Then
                ss110.Put(sNo_, sNo_)
            Else
                ss110.Add(sNo_, sNo_)
            End If
        Catch ex As Exception
            Throw New BaseDatosException("LPParametroSave" & ControlChars.CrLf & ex.Message)
        End Try
        ss110.CerrarConexion()
        ss110 = Nothing
    End Sub

    Private Function LFsPrefijo(ByVal psTipo As String) As String
        Dim loSesionActiva As New SesionActiva
        Dim lsResultado As String = ""
        Select Case psTipo
            Case sGeneral_
                lsResultado = sGeneral_
            Case sLocal_
                lsResultado = SesionActiva.equipo
            Case sUsuario_
                lsResultado = SesionActiva.usuario
            Case sFecha_
                lsResultado = Today.ToString(sFormatoFecha1_)
        End Select

        Return lsResultado
    End Function

End Class
