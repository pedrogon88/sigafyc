Imports SAPbobsCOM

Public Class DIAPI
    Private moCompany As Company

    Public Property TableName As String = ""
    Private Property Server As String
    Private Property LicenseServer As String
    Private Property Database As String
    Private Property DBServerType As String
    Private Property CompanyDB As String
    Private Property DbUsername As String
    Private Property DbPassword As String
    Private Property Username As String
    Private Property Password As String

    Public Const sDIAPI_Alias_ As String = "SAP V9.3 - DIAPI - Alias - "

    Public Sub New()
        moCompany = CType(CreateObject("SAPbobsCOM.Company"), Company)
    End Sub


    Public Function SetearParametrosConexion(ByVal psRama As String, Optional ByVal psTableName As String = "Temporal", Optional ByVal psRequeridos As String = "", Optional ByVal piCampos_PK() As Integer = Nothing, Optional ByVal poObjeto As Object = Nothing) As Company
        Dim loParametroConexion As New ParametrosDIAPI
        Dim lsRama As String = psRama & psTableName & sDS_
        Dim lsRamaGeneral As String = psRama & sGeneral_ & sDS_

        loParametroConexion.Server = LFsObtieneParametro(loParametroConexion.ClaveServer, lsRama, lsRamaGeneral)
        loParametroConexion.LicenseServer = LFsObtieneParametro(loParametroConexion.ClaveLicenseServer, lsRama, lsRamaGeneral)
        loParametroConexion.Database = LFsObtieneParametro(loParametroConexion.ClaveDatabase, lsRama, lsRamaGeneral)
        loParametroConexion.DbServerType = LFsObtieneParametro(loParametroConexion.ClaveDbServerType, lsRama, lsRamaGeneral)
        loParametroConexion.CompanyDB = LFsObtieneParametro(loParametroConexion.ClaveCompanyDB, lsRama, lsRamaGeneral)
        loParametroConexion.DbUsername = LFsObtieneParametro(loParametroConexion.ClaveDbUsername, lsRama, lsRamaGeneral)
        loParametroConexion.DbPassword = LFsObtieneParametro(loParametroConexion.ClaveDbPassword, lsRama, lsRamaGeneral)
        loParametroConexion.Username = LFsObtieneParametro(loParametroConexion.ClaveUsername, lsRama, lsRamaGeneral)
        loParametroConexion.Password = LFsObtieneParametro(loParametroConexion.ClavePassword, lsRama, lsRamaGeneral)
        Call Configurar(loParametroConexion)

        Return moCompany
    End Function

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

    Private Sub Configurar(ByVal poParametroConexion As ParametrosDIAPI)
        Server = poParametroConexion.Server
        LicenseServer = poParametroConexion.LicenseServer
        Database = poParametroConexion.Database
        DBServerType = poParametroConexion.DbServerType
        CompanyDB = poParametroConexion.CompanyDB
        DbUsername = poParametroConexion.DbUsername
        DbPassword = poParametroConexion.DbPassword
        Username = poParametroConexion.Username
        Password = poParametroConexion.Password

        Try
            moCompany.Server = Server
            moCompany.LicenseServer = LicenseServer
            Select Case DBServerType
                Case "HANADB"
                    moCompany.DbServerType = BoDataServerTypes.dst_HANADB
                Case "MSSQL2012"
                    moCompany.DbServerType = BoDataServerTypes.dst_MSSQL2012
                Case "MSSQL2014"
                    moCompany.DbServerType = BoDataServerTypes.dst_MSSQL2014
                    'Case "MSSQL2016"
                    '    moCompany.DbServerType = BoDataServerTypes.dst_MSSQL2016
                    'Case "MSSQL2017"
                    '    moCompany.DbServerType = BoDataServerTypes.dst_MSSQL2017
            End Select

            moCompany.CompanyDB = CompanyDB
            moCompany.DbUserName = DbUsername
            moCompany.DbPassword = DbPassword
            moCompany.UserName = Username
            moCompany.Password = Password

            If RealizaConexion(moCompany) <> 0 Then
                Exit Sub
            End If
        Catch ex As Exception   ' ConfigurationException
            MsgBox("Error al cargar la configuración del acceso a datos.: " & ex.Message)
        End Try
    End Sub

    Public Function RealizaConexion(ByRef moCompany As Company) As Integer
        Dim lIRetorno As Integer = 0
        Do While True
            lIRetorno = moCompany.Connect()
            If lIRetorno <> 0 Then
                If moCompany.GetLastErrorCode.ToString = "100000085" Then
                    Dim liRespuesta As Integer = MsgBox("El usuario SAP de conexion ha llegado al numero de sesiones permitidas" & vbCrLf & "Si desea volver a intentar conectarse en 5 segundos, haga click en Aceptar" & vbCrLf & "o click Cancelar para salir", MsgBoxStyle.OkCancel)
                    If liRespuesta = 1 Then
                        Threading.Thread.Sleep(5000) ' 500 milliseconds = 0.5 seconds
                    Else
                        lIRetorno = liRespuesta
                        Exit Do
                    End If
                Else
                    MsgBox("Ocurrió un error al intentar conectar. Motivo: " & moCompany.GetLastErrorDescription() & "-" & moCompany.GetLastErrorCode.ToString)
                    Exit Do
                End If
            Else
                Exit Do
            End If
        Loop
        Return lIRetorno
    End Function

    Public Sub Desconectar()
        ' Descomentar si se desea hacer seguimiento al correcto uso de conectar y desconectar
        ' GPSavRegistry(sSesion_ & sDS_ & "Conexiones Abiertas", psTabla, sCancelar_)
        If moCompany.Connected Then
            moCompany.Disconnect()

            System.Runtime.InteropServices.Marshal.ReleaseComObject(moCompany)
            GC.Collect()
        End If

    End Sub

    Public Function EjecutarConsultaEscalar(ByVal psSQL As String, ByVal psCampo As String) As String
        Dim msResultado As String = ""
        Dim moRecordSet As Object = moCompany.GetBusinessObject(BoObjectTypes.BoRecordset)
        Try
            CType(moRecordSet, Recordset).DoQuery(psSQL)
            If CType(moRecordSet, Recordset).RecordCount > 0 Then
                While Not CType(moRecordSet, Recordset).EoF
                    msResultado = CType(moRecordSet, Recordset).Fields.Item(psCampo).Value.ToString
                    CType(moRecordSet, Recordset).MoveNext()
                End While
            End If
            System.Runtime.InteropServices.Marshal.ReleaseComObject(CType(moRecordSet, Recordset))
            GC.Collect()

        Catch ex As Exception
            MsgBox("Eror durante manipuleo RecordSet: " & ex.Message)
        End Try

        Return msResultado
    End Function


    Public Sub ComenzarTransaccion()
        If moCompany Is Nothing Then
            moCompany.StartTransaction()
        End If
    End Sub

    Public Sub CancelarTransaccion()
        If moCompany.InTransaction Then
            moCompany.EndTransaction(BoWfTransOpt.wf_RollBack)
        End If
    End Sub

    Public Sub ConfirmarTransaccion()
        If moCompany.InTransaction Then
            moCompany.EndTransaction(BoWfTransOpt.wf_Commit)
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
