Imports System.Data.Common
Imports System.Reflection

Public Class Ebase : Inherits BaseDatos
#Region "Propiedades Publicas"
    Private Const sVerifica_ As String = "Verifica"
    Private msRequeridos As String = "estado" & sString_ & sSF_ &
                                        "borrado" & sString_ & sSF_ &
                                        "hashid" & sString_
    Private moRequeridos() As String
    Private msSQL As String
    Private miCampos_PK() As Integer
    Private moObjeto As Object
    Private msTableName As String
    Private msCancelado As String = sNo_

    Private msEstado As String
    Private msBorrado As String
    Private msHashid As String
    Private msHash_Pk As String
#End Region

    Public Property cancelado As String
        Get
            Return msCancelado
        End Get
        Set(value As String)
            msCancelado = value
        End Set
    End Property

    Public Property estado As String
        Get
            Return msEstado
        End Get
        Set(value As String)
            msEstado = value
        End Set
    End Property

    Public Property borrado As String
        Get
            Return msBorrado
        End Get
        Set(value As String)
            msBorrado = value
        End Set
    End Property

    Public Property hashid As String
        Get
            Return msHashid
        End Get
        Set(value As String)
            msHashid = value
        End Set
    End Property

    Public ReadOnly Property tableName As String
        Get
            Return msTableName
        End Get
    End Property

    Public ReadOnly Property hash_Pk As String
        Get
            Return msHash_Pk
        End Get
    End Property

    Public Sub New()
        MyBase.New
        estado = sActivo_
        borrado = sBlanco_
        hashid = ""
    End Sub

    Public Sub SetParametros(ByVal psRama As String, ByVal psTableName As String, ByVal psRequeridos As String, ByVal piCampos_PK() As Integer, ByVal poObjeto As Object)
        msTableName = psTableName
        msSQL = "SELECT * FROM " & psTableName & ControlChars.CrLf
        moObjeto = poObjeto
        msRequeridos = psRequeridos & sSF_ & msRequeridos
        moRequeridos = msRequeridos.Split(sSF_)
        miCampos_PK = piCampos_PK
        Call SetearParametrosConexion(psRama, psTableName, psRequeridos, piCampos_PK, poObjeto)
    End Sub

    Public Function ProcHashid(ByVal poDataRow As DataRow, Optional ByVal psAccion As String = sVerifica_, Optional ByVal psTipo As String = sTipoMsgLargo_) As String
        Dim lsHashid As String = ""
        Dim lsVerificado As String = ""
        Dim lsResultado As String = sOk_

        For Each loColumn In poDataRow.Table.Columns
            If loColumn.ToString <> sHashidField_ Then
                lsVerificado &= poDataRow(loColumn.ToString).ToString
            Else
                If Not IsDBNull(poDataRow(loColumn.ToString)) Then
                    lsHashid = poDataRow(loColumn.ToString).ToString
                End If
            End If
        Next
        lsVerificado = GFsSHA256(lsVerificado)
        If psAccion = sVerifica_ Then
            If lsVerificado <> lsHashid Then
                Select Case psTipo
                    Case sTipoMsgLargo_
                        lsResultado = "Error de consistencia:" & ControlChars.CrLf &
                            "Hashid....: " & lsHashid.ToUpper & ControlChars.CrLf &
                            "Verificado: " & lsVerificado
                    Case Else
                        lsResultado = sErrorHashid_
                End Select
                Throw New SeguridadException(lsResultado)
            End If
        Else
            lsResultado = lsVerificado
        End If

        Return lsResultado
    End Function

    Public Function GetPK(Optional ByVal psHash_Pk As String = sNo_) As String
        Dim lsAccion As String = sCONSULTAR_
        Dim lsResultado As String = sOk_
        Dim lsSQL As String
        lsSQL = msSQL

        lsSQL = LFsAsignaParametros(lsSQL)

        Dim loDataTable As DataTable = Nothing
        Dim loDataRow As DataRowCollection = Nothing
        Try
            Call CrearComando(lsSQL)
            loDataTable = EjecutarConsultaTable()
            loDataRow = loDataTable.Rows
            If psHash_Pk = sSi_ Then msHash_Pk = GFsSHA256(LFsObtienePrimaryKey(loDataTable))

        Catch ex As DbException
            lsResultado = ex.Message
            Throw New BaseDatosException(ex.Message)
        End Try

        Try
            If loDataRow.Count > 0 Then
                Dim loPropiedadInfo As PropertyInfo
                For Each loPropiedadInfo In moObjeto.GetType.GetProperties()
                    If LFsExisteAtributo(msRequeridos.ToLower, loPropiedadInfo.Name.ToLower) = sSi_ Then
                        If Not IsDBNull(loDataRow.Item(0).Item(loPropiedadInfo.Name)) Then
                            loPropiedadInfo.SetValue(moObjeto, loDataRow.Item(0).Item(loPropiedadInfo.Name))
                        End If

                    End If
                Next
                Dim lsVerificacion As String = ProcHashid(loDataTable.Rows.Item(0))
                If lsVerificacion <> sOk_ Then
                    lsResultado = lsVerificacion
                End If
            Else
                lsResultado = sSinRegistros_
            End If
        Catch ex As SeguridadException
            GFsAvisar(lsAccion, sErrorHashid_, loDataRow.Item(0), ex.Message)
        Catch ex As DbException
            GFsAvisar(lsAccion, sError_, loDataRow.Item(0), ex.Message)
        End Try
        Return lsResultado
    End Function

    Public Sub Add(Optional ByVal psConfirmar As String = sSi_, Optional ByVal psBitacora As String = sSi_, Optional psDesplegarRegistro As String = sNo_, Optional psMensaje As String = "")
        Dim lsResultado As String = sOk_
        Dim lsSQL As String
        Dim lsAccion As String = sAGREGAR_

        lsSQL = msSQL

        lsSQL = LFsAsignaParametros(lsSQL)

        Dim loDataTable As DataTable = Nothing
        Dim loDataRow As DataRow = Nothing
        Try
            Call CrearComando(lsSQL)
            loDataTable = RecuperarTable()
            loDataRow = loDataTable.NewRow()

            Dim loPropiedadInfo As PropertyInfo
            For Each loPropiedadInfo In moObjeto.GetType.GetProperties()
                If LFsExisteAtributo(msRequeridos.ToLower, loPropiedadInfo.Name.ToLower) = sSi_ Then
                    If loPropiedadInfo.Name.ToLower <> sHashidField_ Then
                        If Not IsDBNull(loPropiedadInfo.GetValue(moObjeto, Nothing)) Then
                            loDataRow(loPropiedadInfo.Name.ToLower) = loPropiedadInfo.GetValue(moObjeto, Nothing)
                        End If
                    Else
                        loDataRow(loPropiedadInfo.Name.ToLower) = ProcHashid(loDataRow, sGenerar_)
                        loPropiedadInfo.SetValue(moObjeto, loDataRow(loPropiedadInfo.Name.ToLower))
                    End If
                End If
            Next
            If psConfirmar = sSi_ Then
                cancelado = sNo_
                If GFsConfirmacion(lsAccion, loDataRow) = sCancelar_ Then
                    cancelado = sSi_
                    Exit Sub
                End If
            End If

            loDataTable.Rows.Add(loDataRow)
            ActualizarTable(loDataTable)
            If psDesplegarRegistro = sSi_ Then
                GFsAvisar(lsAccion, sMENSAJE_, loDataRow, psMensaje)
            End If
            If psBitacora = sSi_ Then
                Dim loConexion As New ParametrosConexion
                loConexion.dbms = dbms
                loConexion.server = server
                Throw New BitacoraRegistrar(lsAccion, loDataTable, Nothing, loConexion)
            End If
        Catch ex As DbException
            GFsAvisar(lsAccion, sError_, loDataRow, ex.Message)
        End Try

    End Sub

    Public Sub Del(Optional ByVal psConfirmar As String = sSi_, Optional ByVal psBitacora As String = sSi_)
        Dim lsSQL As String
        Dim lsAccion As String = sBORRAR_

        lsSQL = msSQL

        lsSQL = LFsAsignaParametros(lsSQL)

        Dim loBackTable As DataTable = Nothing
        Dim loDataTable As DataTable = Nothing
        Dim loDataRow As DataRowCollection = Nothing
        Try
            Call CrearComando(lsSQL)

            loDataTable = RecuperarTable()
            loBackTable = loDataTable.Copy()

            loDataRow = loDataTable.Rows

            If loDataRow.Count > 0 Then
                Dim lsVerificacion As String = ProcHashid(loDataTable.Rows.Item(0))
                If lsVerificacion = sOk_ Then
                    If psConfirmar = sSi_ Then
                        cancelado = sNo_
                        If GFsConfirmacion(lsAccion, loDataRow.Item(0)) = sCancelar_ Then
                            cancelado = sSi_
                            Exit Sub
                        End If
                    End If
                    loDataRow.Item(0).Delete()
                    ActualizarTable(loDataTable)
                    If psBitacora = sSi_ Then
                        Dim loConexion As New ParametrosConexion
                        loConexion.dbms = dbms
                        loConexion.server = server
                        Throw New BitacoraRegistrar(lsAccion, loDataTable, loBackTable, loConexion)
                    End If
                End If
            Else
                Throw New BaseDatosException("No se ha encontrado ningun registro")
            End If
        Catch ex As SeguridadException
            GFsAvisar(lsAccion, sErrorHashid_, loDataRow.Item(0), ex.Message)
        Catch ex As DbException
            Call CancelarTransaccion()
            GFsAvisar(lsAccion, sError_, loDataRow.Item(0), ex.Message)
        End Try
    End Sub

    Public Sub Put(Optional ByVal psConfirmar As String = sSi_, Optional ByVal psBitacora As String = sSi_, Optional ByVal psAccion As String = "")
        Dim lsSQL As String
        Dim lsAccion As String = sMODIFICAR_
        If psAccion.Trim.Length > 0 Then
            lsAccion = psAccion
        End If

        lsSQL = msSQL

        lsSQL = LFsAsignaParametros(lsSQL)

        Dim loDataTable As DataTable = Nothing
        Dim loBackTable As DataTable = Nothing
        Dim loDataRow As DataRowCollection = Nothing
        Try
            Call CrearComando(lsSQL)

            loDataTable = RecuperarTable()
            loBackTable = loDataTable.Copy()

            loDataRow = loDataTable.Rows

            If loDataRow.Count > 0 Then
                Dim lsVerificacion As String = ProcHashid(loDataTable.Rows.Item(0))
                If lsVerificacion = sOk_ Then
                    For Each loPropiedadInfo In moObjeto.GetType.GetProperties()
                        If LFsExisteAtributo(msRequeridos.ToLower, loPropiedadInfo.Name.ToLower) = sSi_ Then
                            If loPropiedadInfo.Name.ToLower <> sHashidField_ Then
                                If Not IsDBNull(loPropiedadInfo.GetValue(moObjeto, Nothing)) Then
                                    loDataRow.Item(0).Item(loPropiedadInfo.Name.ToLower) = loPropiedadInfo.GetValue(moObjeto, Nothing)
                                End If
                            Else
                                loDataRow.Item(0).Item(loPropiedadInfo.Name.ToLower) = ProcHashid(loDataTable.Rows.Item(0), sGenerar_)
                            End If
                        End If
                    Next
                    If LFsExisteModificaciones(loBackTable, loDataTable) = sSi_ Then
                        If psConfirmar = sSi_ Then
                            cancelado = sNo_
                            If GFsConfirmacion(lsAccion, loDataRow.Item(0)) = sCancelar_ Then
                                cancelado = sSi_
                                Exit Sub
                            End If
                        End If
                        ActualizarTable(loDataTable)
                        If psBitacora = sSi_ Then
                            Dim loConexion As New ParametrosConexion
                            loConexion.dbms = dbms
                            loConexion.server = server
                            If lsAccion = sAGREGAR_ Then
                                Throw New BitacoraRegistrar(lsAccion, loDataTable, Nothing, loConexion)
                            Else
                                Throw New BitacoraRegistrar(lsAccion, loDataTable, loBackTable, loConexion)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As SeguridadException
            GFsAvisar(lsAccion, sErrorHashid_, loDataRow.Item(0), ex.Message)
        Catch ex As DbException
            Call CancelarTransaccion()
            GFsAvisar(lsAccion, sError_, loDataRow.Item(0), ex.Message)
        End Try
    End Sub

    Public Function GenerarSQL(ByVal psCampos As String, ByVal psConcat As String, Optional ByVal psWhere As String = "", Optional ByVal psTablesNames As String = "", Optional ByVal psJoin As String = "") As String
        Dim lsResultado As String = "SELECT" & ControlChars.CrLf
        lsResultado &= psCampos & ControlChars.CrLf
        lsResultado &= "FROM" & ControlChars.CrLf
        If psTablesNames.Trim.Length > 0 Then
            lsResultado &= psTablesNames & ControlChars.CrLf
        Else
            lsResultado &= msTableName & ControlChars.CrLf
        End If
        lsResultado &= "WHERE"
        lsResultado &= sFiltroBorrado_
        If psJoin.Trim.Length > 0 Then
            lsResultado &= " AND " & ControlChars.CrLf & psJoin
        Else

        End If
        If psWhere.Trim.Length > 0 Then
            lsResultado &= " AND " & ControlChars.CrLf & psWhere
        End If
        lsResultado &= " AND " & ControlChars.CrLf & psConcat
        Return lsResultado
    End Function

    Public Function RecuperarTabla(ByVal psSQL As String) As DataSet
        Dim lsSQL As String = psSQL
        Dim loDataSet As DataSet

        lsSQL = LFsReemplazarParametros(lsSQL)
        Try
            Call CrearComando(lsSQL)
            loDataSet = EjecutarConsultaDataSet(msTableName)

        Catch ex As DbException
            Throw New BaseDatosException(ex.Message)

        End Try
        Return loDataSet
    End Function

    Public Function RecuperarTabla2(ByVal psSQL As String) As DataSet
        Dim lsSQL As String = psSQL
        Dim loDataSet As DataSet

        lsSQL = LFsReemplazarParametros(lsSQL)
        Try
            Call CrearComando(lsSQL)
            loDataSet = EjecutarConsultaDataSet2(msTableName)

        Catch ex As DbException
            Throw New BaseDatosException(ex.Message)

        End Try
        Return loDataSet
    End Function

    Public Function RecuperarConsulta(ByVal psSQL As String) As DbDataReader
        Dim lsSQL As String = psSQL
        Dim loDataReader As DbDataReader

        lsSQL = LFsReemplazarParametros(lsSQL)
        Try
            Call CrearComando(lsSQL)
            loDataReader = EjecutarConsulta()

        Catch ex As DbException
            Throw New BaseDatosException(ex.Message)

        End Try
        Return loDataReader
    End Function

    Private Function LFsReemplazarParametros(ByVal psSQL As String) As String
        Dim lsResultado As String = psSQL

        lsResultado = LFsReemplazaPropiedades(lsResultado)
        Return lsResultado
    End Function

    Private Function LFsAsignaParametros(ByVal psSQL As String, Optional ByVal psAccion As String = "") As String
        Dim lsResultado As String = psSQL
        lsResultado &= LFsCrearWhere(psAccion)
        Return lsResultado
    End Function

    Private Function LFsCrearWhere(ByVal psAccion As String) As String
        Dim lsResultado As String = "WHERE" & sFiltroBorrado_
        Dim liNDX As Integer

        lsResultado = LFsWherePK(lsResultado)
        If psAccion = sAGREGAR_ Then
            For liNDX = 0 To miCampos_PK.Length
                Dim lsParte() As String = moRequeridos(miCampos_PK(liNDX)).Split(sSeparador_)
                Select Case lsParte(1)
                    Case sString_
                        lsResultado = lsResultado.Replace(sPrefijoParam_ & lsParte(0), AsignarValor(Chr(255)))
                    Case sInteger_
                        lsResultado = lsResultado.Replace(sPrefijoParam_ & lsParte(0), AsignarValor(Int32.MaxValue))
                    Case sDecimal_
                        lsResultado = lsResultado.Replace(sPrefijoParam_ & lsParte(0), AsignarValor(Decimal.MaxValue))
                End Select
            Next
        Else
            lsResultado = LFsReemplazaPropiedades(lsResultado)
        End If

        Return lsResultado
    End Function

    Private Function LFsWherePK(ByVal psSQL As String) As String
        Dim lsResultado As String = psSQL
        For liNDX = 0 To miCampos_PK.Length - 1
            Dim lsParte() As String = moRequeridos(miCampos_PK(liNDX)).Split(sSeparador_)
            lsResultado &= " AND " & ControlChars.CrLf & lsParte(0) & " = " & sPrefijoParam_ & lsParte(0)
        Next
        Return lsResultado
    End Function


    Private Function LFsReemplazaPropiedades(ByVal psSQL As String) As String
        Dim loPropiedadInfo As PropertyInfo
        Dim lsResultado As String = psSQL
        For Each loPropiedadInfo In moObjeto.GetType.GetProperties()
            If InStr(lsResultado, sPrefijoParam_) > 0 Then
                If LFsExisteAtributo(msRequeridos.ToLower, loPropiedadInfo.Name.ToLower) = sSi_ Then
                    Dim lsParametro As String = sPrefijoParam_ & loPropiedadInfo.Name.ToLower
                    If loPropiedadInfo.GetValue(moObjeto, Nothing) IsNot Nothing Then
                        Dim lsValor As String = loPropiedadInfo.GetValue(moObjeto, Nothing).ToString
                        lsResultado = Replace(lsResultado, lsParametro, AsignarValor(lsValor))
                    End If
                End If
            Else
                Exit For
            End If
        Next
        Return lsResultado
    End Function

    Private Function LFsObtienePrimaryKey(ByVal poDataTable As DataTable) As String
        Dim lsResultado As String = ""
        Dim loColumns() As DataColumn
        loColumns = poDataTable.PrimaryKey

        Dim liNDX As Integer
        For liNDX = 0 To loColumns.Length - 1
            lsResultado &= poDataTable.Rows(0).Item(loColumns(liNDX).ColumnName).ToString
        Next
        Return lsResultado
    End Function

    Private Function LFsExisteModificaciones(ByVal poAntesRow As DataTable, ByVal poDespuesRow As DataTable) As String
        Dim lsResultado As String = sNo_
        For Each loColumn As DataColumn In poDespuesRow.Rows.Item(0).Table.Columns
            If poAntesRow.Rows.Item(0)(loColumn.ToString).ToString <> poDespuesRow.Rows.Item(0)(loColumn.ToString).ToString Then
                lsResultado = sSi_
                Exit For
            End If
        Next
        Return lsResultado
    End Function

    Private Function LFsExisteAtributo(ByVal psRequeridos As String, ByVal psAtributo As String) As String
        Dim lsResultado = sNo_
        Dim lsCampos() As String = psRequeridos.Split(sSF_)

        For I As Integer = 0 To lsCampos.Length - 1
            Dim lsParte() As String = lsCampos(I).Split(sSeparador_)
            If lsParte(0) = psAtributo Then
                lsResultado = sSi_
                Exit For
            End If
        Next
        Return lsResultado
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
