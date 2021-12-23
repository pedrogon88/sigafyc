Module modGFsHabilitarOpciones

    Public Function GFsHabilitarOpciones(ByVal poParent As Form, ByVal psSS010_codigo As String, ByVal psTipo As String, ByVal psCodigo As String, ByVal psValido As String, ByVal psExpira As String, ByVal psEstado As String, ByVal poLista As ListBox) As String
        Dim lsResultado As String = ""
        Dim loDatos As New Ess100habilitaciones
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.TopMost = True
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Agregando las habilitaciones seleccionadas..."
        For Each lsItem As String In poLista.Items
            Dim lsMostrar As String = psSS010_codigo & sSF_ & psTipo & sSF_ & psCodigo & sSF_ & psValido & sSF_ & psExpira
            loFrmProcesamiento.lblRegistroLeido.Text = lsMostrar
            loDatos.ss010_codigo = psSS010_codigo
            loDatos.tipo = psTipo
            loDatos.codigo = psCodigo
            loDatos.valido = psValido
            loDatos.expira = psExpira
            If psEstado.Trim.Length > 0 Then
                loDatos.estado = psEstado
            End If
            loDatos.ss080_codigo = lsItem
            loDatos.Add(sNo_)
            lsMostrar = loDatos.ss010_codigo & sSF_ & loDatos.tipo & sSF_ & loDatos.codigo & sSF_ & loDatos.ss080_codigo
            loFrmProcesamiento.lblRegistroProcesado.Text = lsMostrar
            loFrmProcesamiento.Refresh()
            lsResultado = lsItem
        Next
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing
        loDatos.CerrarConexion()
        loDatos = Nothing
        Return lsResultado
    End Function

End Module
