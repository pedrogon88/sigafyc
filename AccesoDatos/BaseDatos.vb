Imports System.Data.Common

Public Class BaseDatos
    Private moConexion As DbConnection
    Private moComando As DbCommand
    Private moTransaccion As DbTransaction
    Private moFactory As DbProviderFactory
    Private moDataAdapter As DbDataAdapter
    Private msSQL As String = ""

    Private msDbms As String = ""
    Private msServer As String = ""
    Private msPort As String
    Private msDatabase As String = ""
    Private msUid As String = ""
    Private msPwd As String = ""
    Private moCadenaConexion As String = ""
    Private moProveedorDB As Hashtable

    Public Property dbms As String
        Get
            Return msDbms
        End Get
        Set(value As String)
            msDbms = value
        End Set
    End Property

    Public Property server As String
        Get
            Return msServer
        End Get
        Set(value As String)
            msServer = value
        End Set
    End Property

    Public ReadOnly Property port As String
        Get
            Return msPort
        End Get
    End Property

    Public ReadOnly Property database As String
        Get
            Return msDatabase
        End Get
    End Property

    Public ReadOnly Property uid As String
        Get
            Return msUid
        End Get
    End Property

    Public ReadOnly Property pwd As String
        Get
            Return msPwd
        End Get
    End Property

    Public ReadOnly Property conexion As DbConnection
        Get
            Return moConexion
        End Get
    End Property

    Public Sub New()
        Call LPInicializaVariables()
    End Sub

    Private Sub LPInicializaVariables()
        moProveedorDB = New Hashtable()
        moProveedorDB.Add(sPOSTGRES_, "Npgsql")
        moProveedorDB.Add(sSQLSERVER_, "System.Data.SqlClient")
        moProveedorDB.Add(sMYSQL_, "MySql.Data.MySqlClient")
    End Sub

    Public Sub SetearParametrosConexion(ByVal psRama As String, Optional ByVal psTableName As String = "Temporal", Optional ByVal psRequeridos As String = "", Optional ByVal piCampos_PK() As Integer = Nothing, Optional ByVal poObjeto As Object = Nothing)
        Dim loParametroConexion As New ParametrosConexion
        Dim lsRama As String = psRama & psTableName & sDS_
        Dim lsRamaGeneral As String = psRama & sGeneral_ & sDS_

        loParametroConexion.dbms = LFsObtieneParametro(loParametroConexion.claveDbms, lsRama, lsRamaGeneral)
        loParametroConexion.server = LFsObtieneParametro(loParametroConexion.claveServer, lsRama, lsRamaGeneral)
        loParametroConexion.port = LFsObtieneParametro(loParametroConexion.clavePort, lsRama, lsRamaGeneral)
        loParametroConexion.database = LFsObtieneParametro(loParametroConexion.claveDatabase, lsRama, lsRamaGeneral)
        loParametroConexion.user = LFsObtieneParametro(loParametroConexion.claveUser, lsRama, lsRamaGeneral)
        loParametroConexion.password = LFsObtieneParametro(loParametroConexion.clavePassword, lsRama, lsRamaGeneral)

        Call Configurar(loParametroConexion)
    End Sub

    Private Function LFsObtieneParametro(ByVal psClave As String, ByVal psRama As String, ByVal psRamaGeneral As String) As String
        Dim lsRama As String = psRama & sResetear_ & sDS_
        Dim lsRamaGeneral As String = psRamaGeneral & sResetear_ & sDS_
        Dim lsClave As String = psClave.Substring(0, psClave.Length - 1)
        Dim lsResultado As String = ""

        lsResultado = GFsGetRegistry(lsRamaGeneral, lsClave)
        If lsResultado <> sRESERVADO_ Then
            If SesionActiva.AutorizadoResetear(lsRamaGeneral, lsClave, lsResultado) = sSi_ Then
                GPSavRegistry(psRamaGeneral, psClave, lsResultado)
                GPSavRegistry(lsRamaGeneral, lsClave, sRESERVADO_)
            End If
        End If

        lsResultado = GFsGetRegistry(lsRama, lsClave)
        If lsResultado <> sRESERVADO_ Then
            If SesionActiva.AutorizadoResetear(lsRama, lsClave, lsResultado) = sSi_ Then
                GPSavRegistry(psRama, psClave, lsResultado)
                GPSavRegistry(lsRama, lsClave, sRESERVADO_)
            End If
        End If

        lsResultado = GFsGetRegistry(psRama, psClave)
        If lsResultado = sRESERVADO_ Then
            lsResultado = GFsGetRegistry(psRamaGeneral, psClave)
            If lsResultado <> sRESERVADO_ Then
                GPSavRegistry(psRama, psClave, lsResultado)
            End If
        End If
        Return lsResultado
    End Function

    Public Sub Configurar(ByVal poParametroConexion As ParametrosConexion)
        msDbms = poParametroConexion.dbms
        msServer = poParametroConexion.server
        msPort = poParametroConexion.port
        msDatabase = poParametroConexion.database
        msUid = poParametroConexion.user
        msPwd = poParametroConexion.password

        Try
            Me.moCadenaConexion = LFsCreaCadenaConexion()
            Me.moFactory = DbProviderFactories.GetFactory(moProveedorDB(msDbms).ToString)

        Catch ex As BaseDatosException
            Throw New BaseDatosException("Servidor no especificado [" & sRESERVADO_ & "]")
        Catch ex As DbException   ' ConfigurationException
            Throw New BaseDatosException("Error al cargar la configuración del acceso a datos.", ex)

        End Try
    End Sub

    Private Function LFsCreaCadenaConexion() As String
        Dim lsResultado As String = ""
        If msServer.Trim.Length > 0 Then
            If msServer = sRESERVADO_ Then Throw New BaseDatosException("Servidor no especificado [" & sRESERVADO_ & "]")
            lsResultado &= "Server=" & msServer & ";"
        End If
        If msDbms <> sSQLSERVER_ Then
            If msPort.Trim.Length > 0 Then
                If msPort = sRESERVADO_ Then Throw New BaseDatosException("Puerto no especificado [" & sRESERVADO_ & "]")
                lsResultado &= "Port=" & msPort & ";"
            End If
        End If

        If msDatabase.Trim.Length > 0 Then
            If msDatabase = sRESERVADO_ Then Throw New BaseDatosException("Base de datos no especificada [" & sRESERVADO_ & "]")
            lsResultado &= "Database=" & msDatabase & ";"
        End If
        If msUid.Trim.Length > 0 Then
            If msUid = sRESERVADO_ Then Throw New BaseDatosException("Usuario no especificado [" & sRESERVADO_ & "]")
            lsResultado &= "uid=" & msUid & ";"
        End If
        If msPwd.Trim.Length > 0 Then
            If msPwd = sRESERVADO_ Then Throw New BaseDatosException("Password no especificado [" & sRESERVADO_ & "]")
            lsResultado &= "pwd=" & msPwd & ";"
        End If
        Select Case msDbms
            Case sSQLSERVER_
                lsResultado &= "Pooling=true"
            Case sPOSTGRES_
                lsResultado &= "Pooling=true;Maximum Pool Size=1024;Read Buffer Size=16384;Write Buffer Size=16384"
        End Select
        Return lsResultado
    End Function

    Public Sub Conectar(Optional ByVal psTabla As String = "Temporal")
        ' Descomentar si se desea hacer seguimiento al correcto uso de conectar y desconectar
        ' GPSavRegistry(sSesion_ & sDS_ & "Conexiones Abiertas", psTabla, sActivo_)
        If Not moConexion Is Nothing Then
            If moConexion.State.Equals(ConnectionState.Closed) Then
                Throw New BaseDatosException("La conexion ya se encuentra abierta.")  '---> comentado el 2018-12-26 11:13 por JAC
            End If
        End If

        Try
            If moConexion Is Nothing Then
                moConexion = moFactory.CreateConnection()
                moConexion.ConnectionString = Me.moCadenaConexion
            End If
            moConexion.Open()

        Catch ex As DbException
            Throw New BaseDatosException(ex.Message)
        End Try

    End Sub

    Public Sub Desconectar(Optional ByVal psTabla As String = "Desconocido")
        ' Descomentar si se desea hacer seguimiento al correcto uso de conectar y desconectar
        ' GPSavRegistry(sSesion_ & sDS_ & "Conexiones Abiertas", psTabla, sCancelar_)
        If moConexion.State.Equals(ConnectionState.Open) Then
            moConexion.Close()
        End If
    End Sub

    Public Sub CrearComando(ByVal psSQL As String, Optional psCommandType As String = sQuery_)
        moComando = moFactory.CreateCommand()
        moComando.Connection = moConexion
        If psCommandType = sQuery_ Then
            moComando.CommandType = CommandType.Text
        Else
            moComando.CommandType = CommandType.StoredProcedure
        End If
        moComando.CommandText = psSQL

        If Not moTransaccion Is Nothing Then
            moComando.Transaction = moTransaccion
        End If
    End Sub

    Public Sub AsignarParametro(ByVal psNombre As String, Optional ByVal psValor As String = "")
        moComando.Parameters.Item(psNombre).Value = psValor
    End Sub

    Public Sub AsignarParametro(ByVal psNombre As String, ByVal psvalor As Byte())
        moComando.Parameters.Item(psNombre).Value = psvalor
    End Sub

    Public Sub AsignarParametro(ByVal psNombre As String, ByVal psValor As Decimal)
        moComando.Parameters.Item(psNombre).Value = psValor
    End Sub

    Public Sub AsignarParametro(ByVal psNombre As String, ByVal psValor As DateTime)
        moComando.Parameters.Item(psNombre).Value = psValor
    End Sub

    Public Sub AsignarParametro(ByVal psNombre As String, ByVal psSeparador As String, ByVal psValor As String)
        Dim liIndice As Integer = moComando.CommandText.IndexOf(psNombre)
        Dim lsPrefijo As String = moComando.CommandText.Substring(0, liIndice)
        Dim lsSufijo As String = moComando.CommandText.Substring(liIndice + psNombre.Length)
        Me.moComando.Parameters.Item(psNombre).Value = lsPrefijo & psSeparador & psValor & psSeparador & lsSufijo
    End Sub

    Public Function AsignarValor(ByVal poValue As Object, Optional ByVal psSeparador As String = Chr(39)) As Object
        Dim loResultado As Object = Nothing
        Select Case poValue.GetType
            Case GetType(String)
                loResultado = AsignarValor(CType(poValue, String), psSeparador)
            Case GetType(Integer)
                loResultado = AsignarValor(CType(poValue.ToString, Integer))
            Case GetType(Decimal)
                loResultado = AsignarValor(CType(poValue.ToString, Decimal))
            Case GetType(DateTime)
                loResultado = AsignarValor(CType(poValue.ToString, DateTime))
        End Select
        Return loResultado
    End Function

    Public Function AsignarValor(ByVal psValue As String, Optional ByVal psSeparador As String = Chr(39)) As String
        Dim lsResultado As String = psSeparador & psValue & psSeparador
        Select Case psSeparador
            Case "X"
                lsResultado = psValue
            Case "U"
                lsResultado = psValue.ToUpper
            Case "L"
                lsResultado = psValue.ToLower
        End Select
        Return lsResultado
    End Function

    Public Function AsignarValor(ByVal psValue As Integer) As String
        Return psValue.ToString
    End Function

    Public Function AsignarValor(ByVal psValue As DateTime) As String
        Return psValue.ToString(sFormatoFecha1_)
    End Function

    Public Function AsignarValor(ByVal psValue As Decimal) As String
        Return psValue.ToString
    End Function

    Public Function EjecutarConsulta() As DbDataReader
        Return moComando.ExecuteReader()
    End Function

    Public Function EjecutarConsultaDataSet(ByVal psTabla As String) As DataSet
        Dim loDataSet As New DataSet
        moDataAdapter = moFactory.CreateDataAdapter()
        moDataAdapter.SelectCommand = moComando
        moDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
        moDataAdapter.Fill(loDataSet, psTabla)
        Return loDataSet
    End Function

    Public Function EjecutarConsultaDataSet2(ByVal psTabla As String) As DataSet
        Dim loDataSet As New DataSet
        loDataSet.EnforceConstraints = False
        moDataAdapter = moFactory.CreateDataAdapter()
        moDataAdapter.SelectCommand = moComando
        moDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
        moDataAdapter.Fill(loDataSet, psTabla)
        Return loDataSet
    End Function

    Public Function RecuperarDataSet(ByVal psTabla As String) As DataSet
        Dim loDataSet As New DataSet
        Dim loCommandBuilder As DbCommandBuilder
        loCommandBuilder = moFactory.CreateCommandBuilder()
        loCommandBuilder.DataAdapter = moDataAdapter
        moDataAdapter.InsertCommand = loCommandBuilder.GetInsertCommand
        moDataAdapter.UpdateCommand = loCommandBuilder.GetUpdateCommand
        moDataAdapter.DeleteCommand = loCommandBuilder.GetDeleteCommand
        loCommandBuilder.RefreshSchema()
        moDataAdapter.Fill(loDataSet, psTabla)
        Return loDataSet
    End Function

    Public Sub ActualizarDataSet(ByVal poDataSet As DataSet, ByVal psTabla As String)
        moDataAdapter.Update(poDataSet, psTabla)
    End Sub

    Public Function EjecutarConsultaTable() As DataTable
        Dim loDataTable As New DataSet
        Try
            moDataAdapter = moFactory.CreateDataAdapter()
            moDataAdapter.SelectCommand = moComando
            moDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
            moDataAdapter.Fill(loDataTable)
        Catch ex As Exception
            GFsAvisar("EjecutarConsultaTable-->" & ex.Message, sMENSAJE_)
        End Try
        Return loDataTable.Tables(0)
    End Function

    Public Function RecuperarTable() As DataTable
        Dim loDataTable As New DataTable
        Dim loCommandBuilder As DbCommandBuilder

        loCommandBuilder = moFactory.CreateCommandBuilder()
        moDataAdapter = moFactory.CreateDataAdapter()
        loCommandBuilder.DataAdapter = moDataAdapter

        moDataAdapter.SelectCommand = moComando
        moDataAdapter.InsertCommand = loCommandBuilder.GetInsertCommand
        moDataAdapter.UpdateCommand = loCommandBuilder.GetUpdateCommand
        moDataAdapter.DeleteCommand = loCommandBuilder.GetDeleteCommand

        loCommandBuilder.RefreshSchema()
        moDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
        moDataAdapter.Fill(loDataTable)
        Return loDataTable
    End Function

    Public Sub ActualizarTable(ByVal poDataTable As DataTable)
        moDataAdapter.Update(poDataTable)
    End Sub


    Public Function EjecutarEscalar() As Integer
        Dim liEscalar As Integer = 0

        Try
            Dim loResultado As Object = moComando.ExecuteScalar()
            If Not loResultado Is Nothing Then
                liEscalar = Integer.Parse(loResultado.ToString)
            Else
                liEscalar = -1
            End If

        Catch ex As DbException
            Throw New BaseDatosException(ex.Message)
        Catch ex As InvalidCastException
            Throw New BaseDatosException(ex.Message)
        Catch ex As Exception
            Throw New BaseDatosException(ex.Message)
        End Try
        Return liEscalar
    End Function

    Public Sub EjecutarComando()

        Try
            moComando.ExecuteNonQuery()

        Catch ex As InvalidCastException
            Throw New BaseDatosException(ex.Message)
        Catch ex As DbException
            Dim men As String
            'configuracion del mensaje de acuerdo al numero de error devuelto por la MRDB 
            Select Case ex.ErrorCode
                Case 23503
                    men = "Esta tratando de grabar un dato que no esta relacionado"

            End Select

            If ex.ErrorCode = 8152 Then
                men = "Existen datos demasiados extensos, corrija el problema y vuelva a intentar"
            ElseIf ex.ErrorCode = 2627 Then
                If ex.Message.IndexOf("PRIMARY") <> -1 Then
                    men = "Error por intentar grabar valores duplicados en campos clave, corrija el problema y vuelva a intentar"

                ElseIf ex.Message.IndexOf("UNIQUE") <> -1 Then
                    men = "Error por intentar grabar valores duplicados en campos de valores únicos, corrija el problema y vuelva a intentar"
                Else
                    men = "Error general en la base de datos"
                End If
            ElseIf ex.ErrorCode = 515 Then
                men = "Algunos datos no han sido ingresados y son necesario para completar la operación, corrija el problema y vuelva a intentar"
            Else
                men = ex.Message '"Error general en la base de datos"
            End If

            'Indicamos el mensaje 
            Throw New BaseDatosException(men)


            'Throw New BaseDatosException(ex.Message)

        End Try

    End Sub

    Public Function EjecutarComandoNonQuery() As Integer
        Try
            Return moComando.ExecuteNonQuery()
        Catch ex As InvalidCastException
            Throw New BaseDatosException(ex.Message)

        Catch ex As DbException
            Dim men As String
            'configuracion del mensaje de acuerdo al numero de error devuelto por la MRDB 
            Select Case ex.ErrorCode
                Case 23503
                    men = "Error al relacionar datos. " & ex.Message
                Case 8152
                    men = "Existen datos demasiados extensos, corrija el problema y vuelva a intentar"
                Case 2627
                    If ex.Message.IndexOf("PRIMARY") <> -1 Then
                        men = "Error por intentar grabar valores duplicados en campos clave, corrija el problema y vuelva a intentar"

                    ElseIf ex.Message.IndexOf("UNIQUE") <> -1 Then
                        men = "Error por intentar grabar valores duplicados en campos de valores únicos, corrija el problema y vuelva a intentar"
                    Else
                        men = "Error general en la base de datos"
                    End If
                Case 515
                    men = "Algunos datos no han sido ingresados y son necesario para completar la operación, corrija el problema y vuelva a intentar"
                Case Else
                    men = ex.Message '"Error general en la base de datos"

            End Select

            'Indicamos el mensaje 
            Throw New BaseDatosException(men)
        End Try

    End Function

    Public Sub ComenzarTransaccion()
        If moTransaccion Is Nothing Then
            moTransaccion = moConexion.BeginTransaction()
        End If
    End Sub

    Public Sub CancelarTransaccion()
        If Not moTransaccion Is Nothing Then
            moTransaccion.Rollback()
        End If
    End Sub

    Public Sub ConfirmarTransaccion()
        If Not moTransaccion Is Nothing Then
            moTransaccion.Commit()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
