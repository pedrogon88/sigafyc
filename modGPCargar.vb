Module modGPCargar
    Public Sub GPCargar(ByVal poFormulario As Form, Optional ByVal piTipoVentana As Integer = 0)
        Dim lsSS080_codigo As String = poFormulario.Name
        Dim lsNombre As String = poFormulario.Text
        Dim lsResultado As String = SesionActiva.ControlaReloj

        If lsResultado.Trim.Length > 0 Then
            GFsAvisar(lsResultado, sViolacion_, "Esto hara que su sesion termine de manera anormal.")
            Exit Sub
        End If

        If GFsPuedeUsar(lsSS080_codigo, lsNombre) = sNo_ Then
            Exit Sub
        End If

        If InStr(sPrefijoFormularios_, poFormulario.Name.Substring(0, 4)) > 0 Then LPHabilitarBotones(poFormulario)
        If poFormulario.Name.Substring(0, 4) = sFormReporte_ Then
            poFormulario.Tag = GFsParametroObtener(sUsuario_, "Informe - Borrar Archivos temporales")
        End If
        Dim lsTitulo As String = poFormulario.Text
        If poFormulario.Name.Substring(0, 4) = sForm_ Then
            If poFormulario.Tag.ToString.Trim.Length > 0 Then
                lsTitulo &= ", con la accion de " & poFormulario.Tag.ToString
            End If
            If poFormulario.AccessibleName IsNot Nothing Then
                lsTitulo &= ", " & poFormulario.AccessibleName
            End If
        End If
        GPBitacoraRegistrar(sENTRO_, lsTitulo)
        If piTipoVentana = 0 Then
            poFormulario.ShowDialog()
        Else
            poFormulario.Show()
        End If
    End Sub

    Private Sub LPHabilitarBotones(poFormulario As Form)
        Dim moControl As Control
        For Each moControl In poFormulario.Controls
            If Trim(moControl.Name) = sBotonAuditoria_ Then
                If GFsPuedeUsar(sBotonAuditoria_, "Puede usar Boton Auditoria", sNo_) = sNo_ Then
                    moControl.Visible = False
                End If
            End If
            If InStr(sPrefijoControles_, moControl.Name.Substring(0, 3)) > 0 Then
                If InStr(sBotonesSinRestriccion_, moControl.Name) = 0 Then
                    If GFsPuedeUsar(poFormulario.Name & ":" & moControl.Text.ToUpper.Replace("&", ""), "Habilitar Boton - [" & moControl.Text.ToUpper.Replace("&", "") & "] para Formulario [" & poFormulario.Text & "]", sNo_) = sSi_ Then
                        moControl.Enabled = True
                    Else
                        moControl.Enabled = False
                    End If
                End If
            End If
        Next
    End Sub
End Module
