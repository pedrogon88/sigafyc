Module modGPTablaGralEliminarDetalle

    Public Sub GPTablaGralEliminarDetalle(ByVal psCodigo As String, ByVal psValor As String)
        Dim lsTipo As String = ""
        Dim lsClave As String = ""
        Dim lsValor As String = ""
        Dim lsCodigo As String = ""

        lsTipo = sGeneral_
        lsClave = "Zoho API V2 - Tabla SAP Campos X " & psCodigo
        lsValor = psValor
        lsCodigo = GFsParametroObtener(lsTipo, lsClave)
        If lsCodigo = sRESERVADO_ Then
            lsCodigo = lsValor
            GPParametroGuardar(lsTipo, lsClave, lsValor)
        End If
        GPTablaGeneralObtener(lsCodigo)
        '-------Encabezado para iniciar despliegue de formulario---------------
        Dim loFrmProcesamiento As New frmProcesamiento
        loFrmProcesamiento.Show()
        loFrmProcesamiento.lblTitulo.Text = "Procesamiento [Tabla:" & psCodigo & "," & psValor & "]"

        Dim loDatos As New Ess040tabdet
        Dim loConexion As New BaseDatos
        loConexion.SetearParametrosConexion(sRegistryTablasSAP_, psCodigo)
        loConexion.Conectar(psCodigo)
        Dim lsSQL As String = GFsGeneraSQL("ZohoV2API - Tabla SAP - " & psCodigo.ToUpper)
        loConexion.CrearComando(lsSQL)
        Dim loDataTable As DataTable = loConexion.EjecutarConsultaTable()
        Dim loDataColumns As DataColumnCollection = loDataTable.Rows.Item(0).Table.Columns
        For Each loDataColumn As DataColumn In loDataColumns
            loDatos.ss010_codigo = SesionActiva.sistema
            loDatos.ss030_codigo = lsCodigo
            loDatos.codigo = loDataColumn.ColumnName
            '-------Despliega registros leidos---------------
            loFrmProcesamiento.lblRegistroLeido.Text = "Leyendo [Modulo:" & lsCodigo & ", " & loDatos.codigo & "]"
            loFrmProcesamiento.Refresh()
            If loDatos.GetPK = sOk_ Then
                loDatos.ss010_codigo = SesionActiva.sistema
                loDatos.ss030_codigo = lsCodigo
                loDatos.codigo = loDataColumn.ColumnName
                Try
                    loDatos.Del(sNo_, sNo_)
                Catch ex As Exception
                    GPBitacoraRegistrar(sError_, "GPTablaGralEliminarDetalle.Del() --> " & ex.Message)
                End Try
                '-------Despliega registros leidos---------------
                loFrmProcesamiento.lblRegistroProcesado.Text = "Eliminando [Modulo:" & lsCodigo & ", " & loDataColumn.ColumnName & "]"
                loFrmProcesamiento.Refresh()
            End If
        Next
        '-------Encabezado para iniciar despliegue de formulario---------------
        loFrmProcesamiento.Close()
        loFrmProcesamiento.Dispose()
        loFrmProcesamiento = Nothing

        loDatos.CerrarConexion()
        loDatos = Nothing
    End Sub
End Module
