Imports System.Data.Common

Module modGFsCrearTablaTemporal

    Public Function GFsCrearTablaTemporal(ByVal psArchivo As String, ByVal psEstructura As String) As DataSet
        Dim lsResultado As String = "_" & psArchivo.Trim.ToUpper & "_" & SesionActiva.usuario.ToUpper & "_" & SesionActiva.equipo.ToUpper & "_" & Now.ToString("yyyyMMdd_hhmmssfff") & "_"
        Dim loDataSet As New DataSet("Tablas_Temporales")
        Dim loDataTable As DataTable = loDataSet.Tables.Add(lsResultado)

        Dim lsFields() As String = psEstructura.Split(sSF_)

        For I As Integer = 0 To lsFields.Length - 1
            Dim lsAtributos() As String = lsFields(I).Split(sSeparador_)
            Select Case lsAtributos(1)
                Case sString_.Substring(1, sString_.Length - 1)
                    loDataTable.Columns.Add(lsAtributos(0), GetType(String))
                Case sInteger_.Substring(1, sInteger_.Length - 1)
                    loDataTable.Columns.Add(lsAtributos(0), GetType(Integer))
                Case sDecimal_.Substring(1, sDecimal_.Length - 1)
                    loDataTable.Columns.Add(lsAtributos(0), GetType(Decimal))
                Case sDouble_.Substring(1, sDouble_.Length - 1)
                    loDataTable.Columns.Add(lsAtributos(0), GetType(Double))
            End Select
        Next

        Return loDataSet
    End Function

    Private Function LFDeterminaTipo(ByVal psTipo As String) As Object
        Dim loResultado As Object = Nothing
        Select Case psTipo
            Case sString_.Substring(1, sString_.Length - 1)
                loResultado = GetType(String)
            Case sInteger_.Substring(1, sInteger_.Length - 1)
                loResultado = GetType(Integer)
            Case sDecimal_.Substring(1, sDecimal_.Length - 1)
                loResultado = GetType(Decimal)
            Case sDouble_.Substring(1, sDouble_.Length - 1)
                loResultado = GetType(Double)
        End Select
        Return loResultado
    End Function

End Module
