Imports SAPbobsCOM

Public Class Eocrg : Inherits DIAPI

#Region "Campos de control"
    Public Property Atributo As SAPbobsCOM.BusinessPartnerGroups
    Private moCompany As Company
    Private moObjeto As SAPbobsCOM.BusinessPartnerGroups
    Private msRama As String = sRegistryObjetosSAP_
#End Region

    Public Sub New()
        MyBase.New
        TableName = "OCRG"
        moCompany = SetearParametrosConexion(msRama, TableName)
        moObjeto = CType(moCompany.GetBusinessObject(BoObjectTypes.oBusinessPartnerGroups), SAPbobsCOM.BusinessPartnerGroups)
        Atributo = moObjeto
    End Sub

    Public Function Add() As String
        Dim lsRespuesta As String = sOk_
        Dim liRespuesta As Integer = 0
        Try
            liRespuesta = moObjeto.Add()
            If liRespuesta <> 0 Then
                lsRespuesta = "Ocurrió un error al intentar crear el articulo. Motivo: " & moCompany.GetLastErrorDescription
            End If
        Catch ex As Exception
            lsRespuesta = "Ocurrió un error al intetar crear el articulo. Motivo: " & ex.Message
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


    Public Function GetPK(ByVal piClave As Integer) As Boolean
        Return moObjeto.GetByKey(piClave)
    End Function

    Public Function GetAtributo(ByVal psNombreCampo As String) As String
        Dim lsResultado As String = ""

        Dim lsNombreCampo As String = GFsParametroObtener(sGeneral_, sDIAPI_Alias_ & TableName & "." & psNombreCampo)
        If lsNombreCampo <> sRESERVADO_ Then
            psNombreCampo = lsNombreCampo
        End If

        lsResultado = moObjeto.UserFields.Fields.Item(psNombreCampo).Value.ToString()
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
                        moObjeto.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Integer)
                    Case BoFieldTypes.db_Float
                        moObjeto.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Decimal)
                    Case BoFieldTypes.db_Date
                        moObjeto.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Date)
                End Select
                Exit While
            End If
            loRecordSet.MoveNext()
        End While
    End Sub
End Class

