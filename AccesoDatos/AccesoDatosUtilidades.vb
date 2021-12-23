Public Module Utiles
    Private Function LFsObtieneDatos(ByVal psAccion As String, ByVal poDataRow As DataRow, Optional ByVal psTipo As String = sMENSAJE_, Optional ByVal psFooter As String = "") As String
        Dim lsExcluir As String = sBorradoField_ & sSF_ & sHashidField_
        Dim lsResultado As String
        If psTipo = sErrorHashid_ Then
            lsResultado = "El registro cuyos datos se muestran mas abajo, ha sido modificado fuera del sistema" & ControlChars.CrLf
        Else
            lsResultado = "Usted va a " & psAccion & " los datos mas abajo indicados:" & ControlChars.CrLf
        End If

        lsResultado &= "--------------------------------------------------------" & ControlChars.CrLf
        For Each loColumn As DataColumn In poDataRow.Table.Columns
            If InStr(lsExcluir, loColumn.ColumnName) = 0 Then
                lsResultado &= loColumn.ColumnName & " = " & poDataRow(loColumn.ToString).ToString & ControlChars.CrLf
            End If
        Next

        lsResultado &= "--------------------------------------------------------" & ControlChars.CrLf
        If psFooter.Trim.Length > 0 Then
            lsResultado &= psFooter & ControlChars.CrLf
        End If
        lsResultado &= "--------------------------------------------------------" & ControlChars.CrLf
        If psTipo = sErrorHashid_ Then
            lsResultado &= "Este evento forzara su salida del sistema"
        Else
            lsResultado &= "Confirme esta accion, introduciendo el codigo indicado"
        End If
        Return lsResultado
    End Function

    Public Function GFsConfirmacion(ByVal psAccion As String, ByVal poDataRow As DataRow) As String
        Dim lsResultado As String = ""
        Dim lsMensaje As String = LFsObtieneDatos(psAccion, poDataRow)
        If GFsGetRegistry(sSesion_, "TipoEjecución") = sAutomatico_ Then
            GPBitacoraRegistrar(sMENSAJE_, lsMensaje)
        Else
            Dim loConfirmar As New frmConfirmacion
            loConfirmar.Text = "Confirmación antes de " & psAccion
            loConfirmar.txtMensaje.Text = lsMensaje
            loConfirmar.ShowDialog()
            lsResultado = loConfirmar.Tag.ToString
            loConfirmar = Nothing
        End If


        Return lsResultado
    End Function

    Public Function GFsConfirmacion(ByVal psAccion As String, ByVal psAccionDetalle As String) As String
        Dim lsResultado As String = ""
        If GFsGetRegistry(sSesion_, "TipoEjecución") = sAutomatico_ Then
            GPBitacoraRegistrar(sMENSAJE_, psAccionDetalle)
        Else
            Dim loConfirmar As New frmConfirmacion
            loConfirmar.Text = "Confirmación antes de " & psAccion
            loConfirmar.txtMensaje.Text = psAccionDetalle
            loConfirmar.ShowDialog()
            lsResultado = loConfirmar.Tag.ToString
            loConfirmar = Nothing
        End If
        Return lsResultado
    End Function

    Public Function GFsAvisar(ByVal psAccion As String, ByVal psTipo As String, ByVal poDataRow As DataRow, Optional ByVal psFooter As String = "") As String
        Dim lsResultado As String = ""
        lsResultado = LFsObtieneDatos(psAccion, poDataRow, psTipo, psFooter)
        If GFsGetRegistry(sSesion_, "TipoEjecución") = sAutomatico_ Then
            GPBitacoraRegistrar(sMENSAJE_, lsResultado)
        Else
            Dim loAvisar As New frmAviso
            loAvisar.Tag = psTipo
            loAvisar.txtMensaje.Text = lsResultado
            loAvisar.ShowDialog()
            lsResultado = loAvisar.Tag.ToString
            loAvisar = Nothing
        End If

        Return lsResultado
    End Function

    Public Function GFsAvisar(ByVal psAccion As String, ByVal psTipo As String, Optional ByVal psFooter As String = "") As String
        Dim lsResultado As String = ""
        lsResultado = psAccion & ControlChars.CrLf
        If psFooter.Trim.Length > 0 Then
            lsResultado &= psFooter & ControlChars.CrLf
        End If
        If GFsGetRegistry(sSesion_, "TipoEjecución") = sAutomatico_ Then
            GPBitacoraRegistrar(sMENSAJE_, lsResultado)
        Else
            Dim loAvisar As New frmAviso
            loAvisar.Tag = psTipo
            loAvisar.txtMensaje.Text = lsResultado
            loAvisar.ShowDialog()
            lsResultado = loAvisar.Tag.ToString
            loAvisar = Nothing
        End If
        Return lsResultado
    End Function

    Public Function GFsAvisar(ByVal poParametrosAviso As ParametrosAviso) As String
        Dim lsResultado As String = ""
        Dim loAvisar As New frmAviso
        loAvisar.Tag = sError_
        lsResultado = poParametrosAviso.titulo & ControlChars.CrLf
        lsResultado &= "Error No.: " & poParametrosAviso.codigoError & ControlChars.CrLf
        lsResultado &= "Mensaje..: " & poParametrosAviso.mensajeError & ControlChars.CrLf
        lsResultado &= poParametrosAviso.parametroConexion.claveDbms & " -> " & poParametrosAviso.parametroConexion.dbms
        lsResultado &= poParametrosAviso.parametroConexion.claveServer & " -> " & poParametrosAviso.parametroConexion.server
        lsResultado &= poParametrosAviso.parametroConexion.clavePort & " -> " & poParametrosAviso.parametroConexion.port
        lsResultado &= poParametrosAviso.parametroConexion.claveDatabase & " -> " & poParametrosAviso.parametroConexion.database
        lsResultado &= poParametrosAviso.parametroConexion.claveUser & " -> " & poParametrosAviso.parametroConexion.user
        loAvisar.txtMensaje.Text = lsResultado
        loAvisar.ShowDialog()
        lsResultado = loAvisar.Tag.ToString
        loAvisar = Nothing
        Return lsResultado
    End Function

End Module
