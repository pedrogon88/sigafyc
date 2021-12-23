Imports Newtonsoft
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Module modGPInactivarContacto_ZOHO_SAP
    Public Sub GPInactivarContacto_ZOHO_SAP(ByVal psExternoCardCode As String)
        GPBitacoraRegistrar(sENTRO_, "InactivarContacto_ZOHO_SAP")

        Dim lsRespuesta As String = ""

        Dim lsSepararExterno As Array = Split(psExternoCardCode, "|")

        Dim lsCardCode_Cliente As String = CType(lsSepararExterno.GetValue(0), String)
        Dim lsRuc_Contacto As String = CType(lsSepararExterno.GetValue(2), String)

        'Obtenemos el CardCode del Contacto o Cuenta de Zoho.
        'Dim loLeerJSON_CC As JObject = Nothing
        'Dim psModulo As String = "Contacts" 'If(loLeerJSON("data")(0)("Account_Name").ToString = "", "Contacts", "Accounts")
        ''Dim psZohoId_Cliente As String = If(loLeerJSON("data")(0)("Account_Name").ToString = "", loLeerJSON("data")(0)("Contact_Name")("id").ToString, loLeerJSON("data")(0)("Account_Name")("id").ToString)
        'Dim lsCOQL_CC As String = GFsGeneraSQL("COQL - OBTENER CARDCODE", sGeneral_, sZIS_TablaScriptCOQL_, sUbicacionQueryCOQL_)
        'lsCOQL_CC = lsCOQL_CC.Replace("&Modulo", psModulo.ToString)
        'lsCOQL_CC = lsCOQL_CC.Replace("&zohoId", psZohoId_Cliente.ToString)
        'Dim lsDatosZoho_CC As String = GFsGetCOQLRecords(lsCOQL_CC)
        'If lsDatosZoho_CC.Trim.Length = 0 Then
        '    GFsAvisar("COQL: " & lsCOQL_CC.Trim & ", Error no se recuperaron datos", sMENSAJE_)

        '    Exit Sub
        'End If
        'loLeerJSON_CC = JObject.Parse(lsDatosZoho_CC)

        ''Conectamos con SAP
        Dim loEocrd As New Eocrd
        'Dim lsCardCode As String = loLeerJSON_CC("data")(0)("Codigo_CardCode").ToString()
        Dim liCantContactos As Integer = CInt(loEocrd.ConsultaEscalar("SELECT COUNT(*) as Cantidad FROM OCPR WHERE CardCode = '" & lsCardCode_Cliente & "'", "Cantidad"))
        Dim lsNotes1 As String

        If CInt(loEocrd.GetPK(lsCardCode_Cliente)) <> 0 Then
            For i As Integer = 0 To liCantContactos - 1
                lsNotes1 = loEocrd.GetAtributoOCPR("Notes1", i)

                If lsRuc_Contacto = Left(lsNotes1, InStr(lsNotes1, "-") - 1) Then
                    'If CInt(loEocrd.ConsultaEscalar("SELECT COUNT(*) as Cantidad FROM OCPR WHERE CardCode = '" & lsCardCode_Cliente & "' AND Notes1 Like '%" & lsRuc_Contacto & "%'", "Cantidad")) > 0 Then
                    Call loEocrd.Atributo.ContactEmployees.SetCurrentLine(i)
                    loEocrd.Atributo.ContactEmployees.Active = SAPbobsCOM.BoYesNoEnum.tNO
                End If
            Next

            lsRespuesta = loEocrd.Put()
        End If

        GPBitacoraRegistrar(sSALIO_, "InactivarContacto_ZOHO_SAP --> Zodo Id:" & lsCardCode_Cliente & ", Modulo: Contacto Relacionado")
    End Sub
End Module
