Imports System.Data.Common

Module BitacoraDatos
    Private Const sCabecera_ As String = "cabecera"
    Private Const sDetalle_ As String = "detalle"

    Public Sub Registrar(ByVal psAccion As String, ByVal poDespuesRow As DataTable, ByVal poAntesRow As DataTable, ByVal poConexion As ParametrosConexion)
        Dim ss120 As New Ess120bitdatcab
        If psAccion = sBORRAR_ Then
            ss120.tabla = poAntesRow.Rows(0).Table.TableName.ToLower
            ss120.pk_hash = LFsPKHash(poAntesRow)
        Else
            ss120.tabla = poDespuesRow.Rows(0).Table.TableName.ToLower
            ss120.pk_hash = LFsPKHash(poDespuesRow)
        End If
        ss120.fechaHora = Now.ToString(sFormatoFechaHora2_)
        ss120.ss050_codigo = SesionActiva.usuario
        ss120.ss010_codigo = SesionActiva.sistema
        ss120.ss060_codigo = SesionActiva.equipo
        ss120.loginAcceso = SesionActiva.loginAcceso
        ss120.mac = SesionActiva.mac
        ss120.ip = SesionActiva.ip
        ss120.operacion = psAccion
        ss120.dbms = poConexion.dbms
        ss120.server = poConexion.server
        Try
            ss120.Add(sNo_, sNo_)
            ' Dim lsLinea As String = LFsCargaLinea(sCabecera_, ss120)
            ' GPBitacoraRegistrar(psAccion, lsLinea)
            Detalle(psAccion, ss120.hashid, poDespuesRow, poAntesRow)
        Catch ex As DbException
            GFsAvisar("Bitacora de Datos", sMENSAJE_, ex.Message)
        End Try
        ss120.CerrarConexion()
        ss120 = Nothing
    End Sub

    Private Function LFsCargaLinea(ByVal psTipo As String, ByVal poEntidad As Object) As String
        Dim lsLineaCabecera As String = "@tabla @pk_hash @fechahora @ss050_codigo @ss010_codigo @ss060_codigo @loginacceso @mac @ip @operacion"
        Dim lsLineaDetalle As String = "@ss120_codigo @orden @campo @antes @despues"
        Dim lsResultado As String
        Select Case psTipo
            Case "cabecera"
                lsResultado = lsLineaCabecera
                lsResultado = lsResultado.Replace("@tabla", CType(poEntidad, Ess120bitdatcab).tabla.ToString)
                lsResultado = lsResultado.Replace("@pk_hash", CType(poEntidad, Ess120bitdatcab).pk_hash.ToString)
                lsResultado = lsResultado.Replace("@fechahora", CType(poEntidad, Ess120bitdatcab).fechaHora.ToString)
                lsResultado = lsResultado.Replace("@ss050_codigo", CType(poEntidad, Ess120bitdatcab).ss050_codigo.ToString)
                lsResultado = lsResultado.Replace("@ss010_codigo", CType(poEntidad, Ess120bitdatcab).ss010_codigo.ToString)
                lsResultado = lsResultado.Replace("@ss060_codigo", CType(poEntidad, Ess120bitdatcab).ss060_codigo.ToString)
                lsResultado = lsResultado.Replace("@loginacceso", CType(poEntidad, Ess120bitdatcab).loginAcceso.ToString)
                lsResultado = lsResultado.Replace("@mac", CType(poEntidad, Ess120bitdatcab).mac.ToString)
                lsResultado = lsResultado.Replace("@ip", CType(poEntidad, Ess120bitdatcab).ip.ToString)
                lsResultado = lsResultado.Replace("@operacion", CType(poEntidad, Ess120bitdatcab).operacion.ToString)
            Case "detalle"
                lsResultado = lsLineaDetalle
                lsResultado = lsResultado.Replace("@ss120_codigo", CType(poEntidad, Ess130bitdatdet).ss120_codigo.ToString)
                lsResultado = lsResultado.Replace("@orden", CType(poEntidad, Ess130bitdatdet).orden.ToString)
                lsResultado = lsResultado.Replace("@campo", CType(poEntidad, Ess130bitdatdet).campo.ToString)
                lsResultado = lsResultado.Replace("@antes", CType(poEntidad, Ess130bitdatdet).antes.ToString)
                lsResultado = lsResultado.Replace("@despues", CType(poEntidad, Ess130bitdatdet).despues.ToString)
            Case Else
                lsResultado = lsLineaCabecera
                lsResultado = lsResultado.Replace("@tabla", CType(poEntidad, Ess120bitdatcab).tabla.ToString)
                lsResultado = lsResultado.Replace("@pk_hash", CType(poEntidad, Ess120bitdatcab).pk_hash.ToString)
                lsResultado = lsResultado.Replace("@fechahora", CType(poEntidad, Ess120bitdatcab).fechaHora.ToString)
                lsResultado = lsResultado.Replace("@ss050_codigo", CType(poEntidad, Ess120bitdatcab).ss050_codigo.ToString)
                lsResultado = lsResultado.Replace("@ss010_codigo", CType(poEntidad, Ess120bitdatcab).ss010_codigo.ToString)
                lsResultado = lsResultado.Replace("@ss060_codigo", CType(poEntidad, Ess120bitdatcab).ss060_codigo.ToString)
                lsResultado = lsResultado.Replace("@loginacceso", CType(poEntidad, Ess120bitdatcab).loginAcceso.ToString)
                lsResultado = lsResultado.Replace("@mac", CType(poEntidad, Ess120bitdatcab).mac.ToString)
                lsResultado = lsResultado.Replace("@ip", CType(poEntidad, Ess120bitdatcab).ip.ToString)
                lsResultado = lsResultado.Replace("@operacion", CType(poEntidad, Ess120bitdatcab).operacion.ToString)
        End Select
        Return lsResultado
    End Function

    Private Function LFsPKHash(ByVal poDataTable As DataTable) As String
        Dim lsResultado As String = ""
        Dim loColumns() As DataColumn
        loColumns = poDataTable.PrimaryKey

        For liNDX As Integer = 0 To loColumns.Length - 1
            lsResultado &= poDataTable.Rows(0).Item(loColumns(liNDX).ColumnName).ToString
        Next
        Return GFsSHA256(lsResultado)
    End Function

    Public Sub Detalle(ByVal psAccion As String, ByVal psHashId As String, ByVal poDespuesRow As DataTable, ByVal poAntesRow As DataTable)
        Select Case psAccion
            Case sAGREGAR_
                For Each loColumn As DataColumn In poDespuesRow.Rows.Item(0).Table.Columns
                    Dim ss130 As New Ess130bitdatdet
                    ss130.ss120_codigo = psHashId
                    ss130.orden = loColumn.Ordinal + 1
                    ss130.campo = loColumn.ColumnName
                    ss130.antes = sNODEFINIDO_
                    ss130.despues = poDespuesRow.Rows.Item(0)(loColumn.ToString).ToString
                    ss130.Add(sNo_, sNo_)
                    ' Dim lsLinea As String = LFsCargaLinea(sDetalle_, ss130)
                    ' GPBitacoraRegistrar(psAccion, lsLinea)
                    ss130.CerrarConexion()
                    ss130 = Nothing
                Next
            Case sMODIFICAR_
                For Each loColumn As DataColumn In poDespuesRow.Rows.Item(0).Table.Columns
                    If poAntesRow.Rows.Item(0)(loColumn.ToString).ToString <> poDespuesRow.Rows.Item(0)(loColumn.ToString).ToString Then
                        Dim ss130 As New Ess130bitdatdet
                        ss130.ss120_codigo = psHashId
                        ss130.orden = loColumn.Ordinal
                        ss130.campo = loColumn.ColumnName
                        ss130.antes = poAntesRow.Rows.Item(0)(loColumn.ToString).ToString
                        ss130.despues = poDespuesRow.Rows.Item(0)(loColumn.ToString).ToString
                        ss130.Add(sNo_, sNo_)
                        ' Dim lsLinea As String = LFsCargaLinea(sDetalle_, ss130)
                        ' GPBitacoraRegistrar(psAccion, lsLinea)
                        ss130.CerrarConexion()
                        ss130 = Nothing
                    End If
                Next
            Case sBORRAR_
                For Each loColumn As DataColumn In poAntesRow.Rows.Item(0).Table.Columns
                    Dim ss130 As New Ess130bitdatdet
                    ss130.ss120_codigo = psHashId
                    ss130.orden = loColumn.Ordinal
                    ss130.campo = loColumn.ColumnName
                    ss130.antes = poAntesRow.Rows.Item(0)(loColumn.ToString).ToString
                    ss130.despues = sNODEFINIDO_
                    ss130.Add(sNo_, sNo_)
                    ' Dim lsLinea As String = LFsCargaLinea(sDetalle_, ss130)
                    ' GPBitacoraRegistrar(psAccion, lsLinea)
                    ss130.CerrarConexion()
                    ss130 = Nothing
                Next
        End Select
    End Sub
End Module
