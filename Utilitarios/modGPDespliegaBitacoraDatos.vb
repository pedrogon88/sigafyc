Module modGPDespliegaBitacoraDatos

    Public Sub GPDespliegaBitacoraDatos(ByVal psTableName As String, ByVal psHash_Pk As String)
        Dim loBitacoraDatos As New frmBBitacoraDatos
        loBitacoraDatos.tabla = psTableName
        loBitacoraDatos.pk_Hash = psHash_Pk
        GPCargar(loBitacoraDatos)
        loBitacoraDatos = Nothing
    End Sub

End Module
