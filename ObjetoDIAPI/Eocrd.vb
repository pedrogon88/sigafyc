Imports SAPbobsCOM

Public Class Eocrd : Inherits DIAPI

#Region "Campos de control"
    Public Property Atributo As SAPbobsCOM.BusinessPartners
    Private moCompany As Company
    Private moObjeto As SAPbobsCOM.BusinessPartners
    Private msRama As String = sRegistryObjetosSAP_
    Private msObjeto As String = "el Socio de Negocios"
#End Region

    Public Sub New()
        MyBase.New
        TableName = "OCRD"
        moCompany = SetearParametrosConexion(msRama, TableName)
        moObjeto = CType(moCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners), SAPbobsCOM.BusinessPartners)
        Atributo = moObjeto 
    End Sub

    Public Function Add() As String
        Dim lsRespuesta As String = sOk_
        Dim liRespuesta As Integer = 0
        Try
            liRespuesta = moObjeto.Add()
            If liRespuesta <> 0 Then
                lsRespuesta = "Ocurrió un error al intentar crear " & msObjeto & ". Motivo: " & moCompany.GetLastErrorDescription
            End If
        Catch ex As Exception
            lsRespuesta = "Ocurrió un error al intentar crear " & msObjeto & ". Motivo: " & ex.Message
        End Try
        Return lsRespuesta
    End Function

    Public Function Put() As String
        Dim lsRespuesta As String = sOk_
        Dim liRespuesta As Integer = 0
        Try
            liRespuesta = moObjeto.Update
            If liRespuesta <> 0 Then
                lsRespuesta = "Ocurrió un error al intentar ACTUALIZAR el articulo. Motivo: " & moCompany.GetLastErrorDescription
            End If
        Catch ex As Exception
            lsRespuesta = "Ocurrió un error al intentar ACTUALIZAR el articulo. Motivo: " & ex.Message
        End Try
        Return lsRespuesta
    End Function


    Public Function GetPK(ByVal psClave As String) As Boolean
        Dim lbResultado As Boolean = False
        Try
            lbResultado = moObjeto.GetByKey(psClave)
        Catch ex As Exception
            Return lbResultado
        End Try
        Return lbResultado
    End Function

    Public Function GetAtributo(ByVal psNombreCampo As String) As String
        Dim lsResultado As String = ""

        Dim lsNombreCampo As String = GFsParametroObtener(sGeneral_, sDIAPI_Alias_ & TableName & "." & psNombreCampo)
        If lsNombreCampo <> sRESERVADO_ Then
            psNombreCampo = lsNombreCampo
        End If

        Try
            lsResultado = moObjeto.UserFields.Fields.Item(psNombreCampo).Value.ToString()
        Catch ex As Exception
            lsResultado = "Error: " & ex.Message
        End Try
        Return lsResultado
    End Function

    Public Function GetAtributoOCPR(ByVal psNombreCampo As String, ByVal piLinea As Integer) As String
        Dim lsResultado As String = ""

        TableName = "OCPR"
        Dim lsNombreCampo As String = GFsParametroObtener(sGeneral_, sDIAPI_Alias_ & TableName & "." & psNombreCampo)

        If lsNombreCampo <> sRESERVADO_ Then
            psNombreCampo = lsNombreCampo
        End If

        Try
            moObjeto.ContactEmployees.SetCurrentLine(piLinea)
            lsResultado = moObjeto.ContactEmployees.UserFields.Fields.Item(psNombreCampo).Value.ToString()
        Catch ex As Exception
            lsResultado = "Error: " & ex.Message
        End Try
        Return lsResultado
    End Function

    Public Function GetAtributoCRD1(ByVal psNombreCampo As String, ByVal piLinea As Integer) As String
        Dim lsResultado As String = ""

        TableName = "CRD1"
        Dim lsNombreCampo As String = GFsParametroObtener(sGeneral_, sDIAPI_Alias_ & TableName & "." & psNombreCampo)

        If lsNombreCampo <> sRESERVADO_ Then
            psNombreCampo = lsNombreCampo
        End If

        Try
            moObjeto.Addresses.SetCurrentLine(piLinea)
            lsResultado = moObjeto.Addresses.UserFields.Fields.Item(psNombreCampo).Value.ToString()
        Catch ex As Exception
            lsResultado = "Error: " & ex.Message
        End Try
        Return lsResultado
    End Function

    Public Sub SetAtributo(ByVal psNombreCampo As String, ByVal psValor As String)
        Dim loSBObob As SAPbobsCOM.SBObob
        Dim loRecordSet As SAPbobsCOM.Recordset

        Dim lsNombreCampo As String = GFsParametroObtener(sGeneral_, sDIAPI_Alias_ & TableName & "." & psNombreCampo)
        If lsNombreCampo <> sRESERVADO_ Then
            psNombreCampo = lsNombreCampo
        End If

        loSBObob = CType(moCompany.GetBusinessObject(BoObjectTypes.BoBridge), SAPbobsCOM.SBObob)
        loRecordSet = CType(moCompany.GetBusinessObject(BoObjectTypes.BoRecordset), SAPbobsCOM.Recordset)
        loRecordSet = loSBObob.GetTableFieldList(TableName)
        While Not loRecordSet.EoF
            If CType(loRecordSet.Fields.Item(0).Value, String) = psNombreCampo Then
                Select Case CType(loRecordSet.Fields.Item(2).Value, BoFieldTypes)
                    Case BoFieldTypes.db_Alpha
                        If psValor.Trim.Length > CType(loRecordSet.Fields.Item(1).Value, Integer) Then
                            moObjeto.UserFields.Fields.Item(psNombreCampo).Value = psValor.Substring(0, CType(loRecordSet.Fields.Item(1).Value, Integer))
                        Else
                            If loRecordSet.Fields.Item(4).Value.ToString <> "0" Then
                                moObjeto.UserFields.Fields.Item(psNombreCampo).Value = loSBObob.ConvertValidValueToEnumValue("Bo" & psNombreCampo & "s", psValor)
                            Else
                                moObjeto.UserFields.Fields.Item(psNombreCampo).Value = psValor
                            End If
                        End If
                    Case BoFieldTypes.db_Numeric
                        If psValor = "" Or psValor Is Nothing Then
                            moObjeto.UserFields.Fields.Item(psNombreCampo).Value = 0
                        Else
                            moObjeto.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Integer)
                        End If
                    Case BoFieldTypes.db_Float
                        If psValor = "" Or psValor Is Nothing Then
                            moObjeto.UserFields.Fields.Item(psNombreCampo).Value = 0D
                        Else
                            moObjeto.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Decimal)
                        End If
                    Case BoFieldTypes.db_Date
                        moObjeto.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Date)
                End Select
                Exit While
            End If
            loRecordSet.MoveNext()
        End While
    End Sub

    Public Sub SetCurrentLineOCPR(ByVal piLine As Integer)
        moObjeto.ContactEmployees.SetCurrentLine(piLine)
    End Sub

    Public Sub SetCurrentLineCRD1(ByVal piLine As Integer)
        moObjeto.Addresses.SetCurrentLine(piLine)
    End Sub

    Public Function GetCurrentLineName_OCPR(ByVal psName As String) As Integer
        Dim liResultado As Integer = -1
        Dim liCantidad As Integer = moObjeto.ContactEmployees.Count
        For liPos As Integer = 0 To liCantidad - 1
            moObjeto.ContactEmployees.SetCurrentLine(liPos)
            If moObjeto.ContactEmployees.Name = psName Then
                liResultado = liPos
                Exit For
            End If
        Next
        Return liResultado
    End Function

    Public Function GetCurrentLineName_CRD1(ByVal psName As String) As Integer
        Dim liResultado As Integer = -1
        Dim liCantidad As Integer = moObjeto.Addresses.Count
        For liPos As Integer = 0 To liCantidad - 1
            moObjeto.Addresses.SetCurrentLine(liPos)
            If moObjeto.Addresses.AddressName = psName Then
                liResultado = liPos
                Exit For
            End If
        Next
        Return liResultado
    End Function

    Public Sub SetAtributoOCPR(ByVal psNombreCampo As String, ByVal psValor As String)
        Dim loSBObob As SAPbobsCOM.SBObob
        Dim loRecordSet As SAPbobsCOM.Recordset

        TableName = "OCPR"
        Dim lsNombreCampo As String = GFsParametroObtener(sGeneral_, sDIAPI_Alias_ & TableName & "." & psNombreCampo)
        If lsNombreCampo <> sRESERVADO_ Then
            psNombreCampo = lsNombreCampo
        End If

        loSBObob = CType(moCompany.GetBusinessObject(BoObjectTypes.BoBridge), SAPbobsCOM.SBObob)
        loRecordSet = CType(moCompany.GetBusinessObject(BoObjectTypes.BoRecordset), SAPbobsCOM.Recordset)
        loRecordSet = loSBObob.GetTableFieldList(TableName)
        While Not loRecordSet.EoF
            If CType(loRecordSet.Fields.Item(0).Value, String) = psNombreCampo Then
                Select Case CType(loRecordSet.Fields.Item(2).Value, BoFieldTypes)
                    Case BoFieldTypes.db_Alpha
                        If psValor.Trim.Length > CType(loRecordSet.Fields.Item(1).Value, Integer) Then
                            moObjeto.ContactEmployees.UserFields.Fields.Item(psNombreCampo).Value = psValor.Substring(0, CType(loRecordSet.Fields.Item(1).Value, Integer))
                        Else
                            If loRecordSet.Fields.Item(4).Value.ToString <> "0" Then
                                moObjeto.ContactEmployees.UserFields.Fields.Item(psNombreCampo).Value = loSBObob.ConvertValidValueToEnumValue("Bo" & psNombreCampo & "s", psValor)
                            Else
                                moObjeto.ContactEmployees.UserFields.Fields.Item(psNombreCampo).Value = psValor
                            End If
                        End If
                    Case BoFieldTypes.db_Numeric
                        If psValor = "" Or psValor Is Nothing Then
                            moObjeto.ContactEmployees.UserFields.Fields.Item(psNombreCampo).Value = 0
                        Else
                            moObjeto.ContactEmployees.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Integer)
                        End If
                    Case BoFieldTypes.db_Float
                        If psValor = "" Or psValor Is Nothing Then
                            moObjeto.ContactEmployees.UserFields.Fields.Item(psNombreCampo).Value = 0D
                        Else
                            moObjeto.ContactEmployees.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Decimal)
                        End If
                    Case BoFieldTypes.db_Date
                        moObjeto.ContactEmployees.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Date)
                End Select
                Exit While
            End If
            loRecordSet.MoveNext()
        End While
    End Sub

    Public Sub SetAtributoCRD1(ByVal psNombreCampo As String, ByVal psValor As String)
        Dim loSBObob As SAPbobsCOM.SBObob
        Dim loRecordSet As SAPbobsCOM.Recordset

        TableName = "CRD1"
        Dim lsNombreCampo As String = GFsParametroObtener(sGeneral_, sDIAPI_Alias_ & TableName & "." & psNombreCampo)
        If lsNombreCampo <> sRESERVADO_ Then
            psNombreCampo = lsNombreCampo
        End If

        loSBObob = CType(moCompany.GetBusinessObject(BoObjectTypes.BoBridge), SAPbobsCOM.SBObob)
        loRecordSet = CType(moCompany.GetBusinessObject(BoObjectTypes.BoRecordset), SAPbobsCOM.Recordset)
        loRecordSet = loSBObob.GetTableFieldList(TableName)
        While Not loRecordSet.EoF
            If CType(loRecordSet.Fields.Item(0).Value, String) = psNombreCampo Then
                Select Case CType(loRecordSet.Fields.Item(2).Value, BoFieldTypes)
                    Case BoFieldTypes.db_Alpha
                        If psValor.Trim.Length > CType(loRecordSet.Fields.Item(1).Value, Integer) Then
                            If psValor = GFsParametroObtener(sGeneral_, "GPIntegracionZoho_SAP -> TIPO DIRECCION PREDETERMINADA") Then
                                Atributo.Addresses.AddressType = SAPbobsCOM.BoAddressType.bo_BillTo
                            Else
                                moObjeto.Addresses.UserFields.Fields.Item(psNombreCampo).Value = psValor.Substring(0, CType(loRecordSet.Fields.Item(1).Value, Integer))
                            End If
                        Else
                            If loRecordSet.Fields.Item(4).Value.ToString <> "0" Then
                                moObjeto.Addresses.UserFields.Fields.Item(psNombreCampo).Value = loSBObob.ConvertValidValueToEnumValue("Bo" & psNombreCampo & "s", psValor)
                            Else
                                moObjeto.Addresses.UserFields.Fields.Item(psNombreCampo).Value = psValor
                            End If
                        End If
                    Case BoFieldTypes.db_Numeric
                        If psValor = "" Or psValor Is Nothing Then
                            moObjeto.Addresses.UserFields.Fields.Item(psNombreCampo).Value = 0
                        Else
                            moObjeto.Addresses.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Integer)
                        End If
                    Case BoFieldTypes.db_Float
                        If psValor = "" Or psValor Is Nothing Then
                            moObjeto.Addresses.UserFields.Fields.Item(psNombreCampo).Value = 0D
                        Else
                            moObjeto.Addresses.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Decimal)
                        End If
                    Case BoFieldTypes.db_Date
                        moObjeto.Addresses.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Date)
                End Select
                Exit While
            End If
            loRecordSet.MoveNext()
        End While
    End Sub

    Public Function ConsultaEscalar(ByVal psSQL As String, ByVal psCampo As String) As String
        Dim lsResultado As String = ""

        Try
            lsResultado = EjecutarConsultaEscalar(psSQL, psCampo)
        Catch ex As Exception
            lsResultado = "Error: " & ex.Message
        End Try

        Return lsResultado
    End Function
End Class

