Imports SAPbobsCOM

Public Class Eordr : Inherits DIAPI

#Region "Campos de control"
    Public Property Atributo As SAPbobsCOM.Documents
    Private moCompany As Company
    Private moObjeto As SAPbobsCOM.Documents
    Private msRama As String = sRegistryObjetosSAP_
    Private msObjeto As String = "la Orden de Venta"
#End Region

    Public Sub New()
        MyBase.New
        TableName = "ORDR"
        moCompany = SetearParametrosConexion(msRama, TableName)
        moObjeto = CType(moCompany.GetBusinessObject(BoObjectTypes.oOrders), SAPbobsCOM.Documents)
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
            lsRespuesta = "Ocurrió un error al intetar crear " & msObjeto & ". Motivo: " & ex.Message
        End Try
        Return lsRespuesta
    End Function

    Public Function Put() As String
        Dim lsRespuesta As String = sOk_
        Dim liRespuesta As Integer = 0
        Try
            liRespuesta = moObjeto.Update
            If liRespuesta <> 0 Then
                lsRespuesta = "Ocurrió un error al intentar ACTUALIZAR la OV. Motivo: " & moCompany.GetLastErrorDescription
            End If
        Catch ex As Exception
            lsRespuesta = "Ocurrió un error al intetar ACTUALIZAR la OV. Motivo: " & ex.Message
        End Try
        Return lsRespuesta
    End Function


    Public Function GetPK(ByVal psClave As Integer) As Boolean
        Return moObjeto.GetByKey(psClave)
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

    Public Sub SetAtributo_ORDR(ByVal psNombreCampo As String, ByVal psValor As String)
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
                            moObjeto.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Double)
                        End If
                    Case BoFieldTypes.db_Date
                        moObjeto.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Date)
                End Select
                Exit While
            End If
            loRecordSet.MoveNext()
        End While
    End Sub

    Public Sub SetAtributo_RDR1(ByVal psNombreCampo As String, ByVal psValor As String)
        Dim loSBObob As SAPbobsCOM.SBObob
        Dim loRecordSet As SAPbobsCOM.Recordset
        TableName = "RDR1"

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
                            moObjeto.Lines.UserFields.Fields.Item(psNombreCampo).Value = psValor.Substring(0, CType(loRecordSet.Fields.Item(1).Value, Integer))
                        Else
                            If loRecordSet.Fields.Item(4).Value.ToString <> "0" Then
                                moObjeto.Lines.UserFields.Fields.Item(psNombreCampo).Value = loSBObob.ConvertValidValueToEnumValue("Bo" & psNombreCampo & "s", psValor)
                            Else
                                moObjeto.Lines.UserFields.Fields.Item(psNombreCampo).Value = psValor
                            End If
                        End If
                    Case BoFieldTypes.db_Numeric
                        If psValor = "" Or psValor Is Nothing Then
                            moObjeto.Lines.UserFields.Fields.Item(psNombreCampo).Value = 0
                        Else
                            moObjeto.Lines.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Integer)
                        End If
                    Case BoFieldTypes.db_Float
                        If psValor = "" Or psValor Is Nothing Then
                            moObjeto.Lines.UserFields.Fields.Item(psNombreCampo).Value = 0D
                        Else
                            moObjeto.Lines.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Double)
                        End If
                    Case BoFieldTypes.db_Date
                        moObjeto.Lines.UserFields.Fields.Item(psNombreCampo).Value = CType(psValor, Date)
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
