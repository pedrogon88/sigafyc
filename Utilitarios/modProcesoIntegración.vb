Imports System.Threading

Module modProcesoIntegración
    Private Const sProcesoDetalle_ As String = "ProcesoDetalle"
    Private miNumtra As Integer = 0
    Private miNumord As Integer = 0
    Private moRegistroOperativo As RegistrosOperativos = Nothing

    Public Sub GPProcesoCabecera(ByVal piNumtra As Integer, ByVal piNumord As Integer)
        Dim loCabecera As Ezis_procab = New Ezis_procab
        loCabecera.numtra = piNumtra
        If loCabecera.GetPK = sOk_ Then
            loCabecera.start = Now.ToString(sFormatoFechaHora1_)
            loCabecera.ending = ""
            Try
                loCabecera.Put(sNo_)
            Catch ex As Exception
                GPBitacoraRegistrar(sError_, "Actualizar Cab.Proc.Integrac.No." & piNumtra.ToString & "-> Start, " & ex.Message)
                Exit Sub
            End Try
        Else
            GFsAvisar("Proceso Integración No.:" & piNumtra.ToString & ", no existe!!", sMENSAJE_)
            Exit Sub
        End If
        Dim loDetalle As Ezis_prodet = New Ezis_prodet
        loDetalle.numtra = piNumtra
        loDetalle.numord = piNumord
        If Not (loDetalle.GetPK = sOk_) Then
            GFsAvisar("Proceso Integración No:" & piNumtra.ToString & ", Linea No.:" & piNumord.ToString & " no existe!!," & vbCrLf & "ESTO NO DEBERIA HABER PASADO!!", sMENSAJE_)
            Exit Sub
        End If

        If loCabecera.tipexec = "Secuencial" Then
            Dim loPDetalle As cProcesoDetalle = New cProcesoDetalle
            loPDetalle.Inicializa(CInt(loDetalle.numtra), CInt(loDetalle.numord))
            loPDetalle.Procesar()
            loCabecera.numtra = piNumtra
            If loCabecera.GetPK = sOk_ Then
                loCabecera.ending = Now.ToString(sFormatoFechaHora1_)
                Try
                    loCabecera.Put(sNo_)
                Catch ex As Exception
                    GPBitacoraRegistrar(sError_, "Actualizar Cab.Proc.Integrac.No." & piNumtra.ToString & "-> Ending, " & ex.Message)
                End Try
            End If
        Else
            Dim loPDetalle As cProcesoDetalle = New cProcesoDetalle
            loPDetalle.Inicializa(CInt(loDetalle.numtra), CInt(loDetalle.numord))
            Dim moThread As Thread = New Thread(AddressOf loPDetalle.Procesar)
            moThread.IsBackground = True
            Dim loModelo As Ezis_modcab = New Ezis_modcab
            loModelo.numtra = CInt(loDetalle.nummod)
            moThread.Name = sProcesoDetalle_ & "_T" & loDetalle.numtra.ToString & "-O" & loDetalle.numord.ToString & "-M" & loModelo.nombre
            moThread.Start()
            MultiThread.Agregar(moThread)
            Do While True
                Dim liCulminados As Integer = MultiThread.Culminados(sProcesoDetalle_)
                Dim liVivos As Integer = MultiThread.Vivos(sProcesoDetalle_)
                If liCulminados = liVivos Then Exit Do
            Loop
        End If
        loCabecera.CerrarConexion()

    End Sub

    Public Sub GPProcesoCabecera(ByVal piNumtra As Integer)
        Dim loCabecera As Ezis_procab = New Ezis_procab
        loCabecera.numtra = piNumtra
        If loCabecera.GetPK = sOk_ Then
            loCabecera.start = Now.ToString(sFormatoFechaHora1_)
            loCabecera.ending = ""
            Try
                loCabecera.Put(sNo_)
            Catch ex As Exception
                GPBitacoraRegistrar(sError_, "Actualizar Cab.Proc.Integrac.No." & piNumtra.ToString & "-> Start, " & ex.Message)
                Exit Sub
            End Try
        Else
            GFsAvisar("Proceso Integración No.:" & piNumtra.ToString & ", no existe!!", sMENSAJE_)
            Exit Sub
        End If

        Dim loConexion As BaseDatos = New BaseDatos
        loConexion.SetearParametrosConexion(sRegistryTablasSAP_, "OITM")
        loConexion.Conectar("OITM")
        Dim lsSQL As String = GFsGeneraSQL("GPProcesoCabecera_Detalle")
        lsSQL = lsSQL.Replace("&numtra", piNumtra.ToString)
        loConexion.CrearComando(lsSQL)
        Dim loProcesoDetalle As DataTable = loConexion.EjecutarConsultaTable()
        loConexion.Desconectar()
        loConexion = Nothing
        Dim loDetalle As DataRow = Nothing

        If loCabecera.tipexec = "Secuencial" Then
            For Each loDetalle In loProcesoDetalle.Rows
                Dim loPDetalle As cProcesoDetalle = New cProcesoDetalle
                loPDetalle.Inicializa(CInt(loDetalle.Item("numtra")), CInt(loDetalle.Item("numord")))
                loPDetalle.Procesar()
            Next
            loCabecera.numtra = piNumtra
            If loCabecera.GetPK = sOk_ Then
                loCabecera.ending = Now.ToString(sFormatoFechaHora1_)
                Try
                    loCabecera.Put(sNo_)
                Catch ex As Exception
                    GPBitacoraRegistrar(sError_, "Actualizar Cab.Proc.Integrac.No." & piNumtra.ToString & "-> Ending, " & ex.Message)
                End Try
            End If
        Else
            For Each loDetalle In loProcesoDetalle.Rows
                Dim loPDetalle As cProcesoDetalle = New cProcesoDetalle
                loPDetalle.Inicializa(CInt(loDetalle.Item("numtra")), CInt(loDetalle.Item("numord")))
                Dim moThread As Thread = New Thread(AddressOf loPDetalle.Procesar)
                moThread.IsBackground = True
                Dim loModelo As Ezis_modcab = New Ezis_modcab
                loModelo.numtra = CInt(loDetalle.Item("nummod").ToString)
                moThread.Name = sProcesoDetalle_ & "_T" & loDetalle.Item("numtra").ToString & "-O" & loDetalle.Item("numord").ToString
                moThread.Start()
                MultiThread.Agregar(moThread)
            Next
            Do While True
                Dim liCulminados As Integer = MultiThread.Culminados(sProcesoDetalle_)
                Dim liCantidad As Integer = MultiThread.Cantidad(sProcesoDetalle_)
                If liCulminados = liCantidad Then Exit Do
            Loop
        End If
        loCabecera.CerrarConexion()
    End Sub

    Public Sub GPProcesoCabecera()
        GPBitacoraRegistrar(sENTRO_, "GPProcesoCabecera")
        Dim loDataTable As DataTable = GFoRecuperaDataTable("GPProcesoCabecera")
        Dim loDataRow As DataRow = Nothing
        For Each loDataRow In loDataTable.Rows
            Dim lsFechaInicio As String = loDataRow.Item("start").ToString
            If lsFechaInicio.Trim.Length = 0 Then
                lsFechaInicio = Now.ToString(sFormatoFechaHora1_)
            End If
            If GFoVerificaFrecuencia(lsFechaInicio, loDataRow.Item("undtmp").ToString) >= Double.Parse(loDataRow.Item("tiempo").ToString) Then
                Dim loConexion As BaseDatos = New BaseDatos
                loConexion.SetearParametrosConexion(sRegistryTablasSAP_, "OITM")
                loConexion.Conectar("OITM")
                Dim lsSQL As String = GFsGeneraSQL("GPProcesoCabecera_Detalle")
                lsSQL = lsSQL.Replace("&numtra", loDataRow.Item("numtra").ToString)
                loConexion.CrearComando(lsSQL)
                Dim loProcesoDetalle As DataTable = loConexion.EjecutarConsultaTable()
                loConexion.Desconectar()
                loConexion = Nothing
                Dim loDetalle As DataRow = Nothing
                Dim loCabecera As Ezis_procab = New Ezis_procab
                loCabecera.numtra = CInt(loDataRow.Item("numtra").ToString)
                If loCabecera.GetPK = sOk_ Then
                    loCabecera.start = Now.ToString(sFormatoFechaHora1_)
                    loCabecera.ending = ""
                    Try
                        loCabecera.Put(sNo_)
                    Catch ex As Exception
                        GPBitacoraRegistrar(sError_, "Actualizar Cab.Proc.Integrac.No." & loDataRow.Item("numtra").ToString & "-> Start, " & ex.Message)
                    End Try
                End If
                If loDataRow.Item("tipexec").ToString = "Secuencial" Then
                    For Each loDetalle In loProcesoDetalle.Rows
                        Dim loPDetalle As cProcesoDetalle = New cProcesoDetalle
                        loPDetalle.Inicializa(CInt(loDetalle.Item("numtra")), CInt(loDetalle.Item("numord")))
                        loPDetalle.Procesar()
                    Next
                    loCabecera.numtra = CInt(loDataRow.Item("numtra").ToString)
                    If loCabecera.GetPK = sOk_ Then
                        loCabecera.ending = Now.ToString(sFormatoFechaHora1_)
                        Try
                            loCabecera.Put(sNo_)
                        Catch ex As Exception
                            GPBitacoraRegistrar(sError_, "Actualizar Cab.Proc.Integrac.No." & loDataRow.Item("numtra").ToString & "-> Ending, " & ex.Message)
                        End Try
                    End If
                Else
                    For Each loDetalle In loProcesoDetalle.Rows
                        Dim loPDetalle As cProcesoDetalle = New cProcesoDetalle
                        loPDetalle.Inicializa(CInt(loDetalle.Item("numtra")), CInt(loDetalle.Item("numord")))
                        Dim moThread As Thread = New Thread(AddressOf loPDetalle.Procesar)
                        moThread.IsBackground = True
                        Dim loModelo As Ezis_modcab = New Ezis_modcab
                        loModelo.numtra = CInt(loDetalle.Item("nummod").ToString)
                        moThread.Name = sProcesoDetalle_ & "_T" & loDetalle.Item("numtra").ToString & "-O" & loDetalle.Item("numord").ToString
                        moThread.Start()
                        MultiThread.Agregar(moThread)
                    Next
                    Do While True
                        Dim liCulminados As Integer = MultiThread.Culminados(sProcesoDetalle_)
                        Dim liVivos As Integer = MultiThread.Vivos(sProcesoDetalle_)
                        If liCulminados = liVivos Then Exit Do
                    Loop
                End If
                loCabecera.CerrarConexion()
            End If
        Next
        GPBitacoraRegistrar(sSALIO_, "GPProcesoCabecera")
    End Sub

    Private Class cProcesoDetalle
        Private miNumtra As Integer
        Private miNumord As Integer
        Private msFechaHoraAnterior As String = ""

        Private moCabecera As Ezis_procab = New Ezis_procab
        Private moDetalle As Ezis_prodet = New Ezis_prodet
        Private msTipAct As String = sBulkUpsert_
        Private moDataTable As DataTable = Nothing
        Private moModelo As Ezis_modcab = Nothing
        Private moRegistroOperativo As RegistrosOperativos = Nothing
        Private moThread As Thread = Nothing

        Public Sub Inicializa(ByVal piNumtra As Integer, ByVal piNumord As Integer)
            miNumtra = piNumtra
            miNumord = piNumord
            GPBitacoraRegistrar(sENTRO_, "Instancia ProcesoDetalle - Transacción: " & miNumtra.ToString & ", Orden:" & miNumord.ToString)
        End Sub

        Public Sub Procesar()
            moCabecera.numtra = miNumtra
            If moCabecera.GetPK = sOk_ Then
                msTipAct = moCabecera.tipact
            End If
            moDetalle.numtra = miNumtra
            moDetalle.numord = miNumord
            If moDetalle.GetPK() = sOk_ Then
                moModelo = New Ezis_modcab
                moModelo.numtra = moDetalle.nummod
                If moModelo.GetPK() = sOk_ Then
                    moDetalle.numtra = miNumtra
                    moDetalle.numord = miNumord
                    msFechaHoraAnterior = sFechaHoraAnterior_ & "=" & moDetalle.start
                    moDetalle.start = Now.ToString(sFormatoFechaHora1_)
                    moDetalle.ending = ""
                    moDetalle.Put(sNo_)
                    Select Case moModelo.sentido.ToLower
                        Case sZIS_SAPzoho_.ToLower
                            moDataTable = GFoRecuperaDataTable(moModelo.script,, moModelo.numtra, msFechaHoraAnterior)
                            moDataTable.TableName = moModelo.script
                            If GFsParametroObtener(sGeneral_, "Proceso BULK - optimizando creditos") = sSi_ Then
                                Dim liLimiteBulk As Integer = CInt(GFsParametroObtener(sGeneral_, sZIS_Bulk_creditos_))
                                If moDataTable.Rows.Count > liLimiteBulk Then
                                    moThread = New Thread(AddressOf LPEjecutaProcesarBulk)
                                    moThread.Name = sZIS_SAPzoho_.ToLower & "_" & moDetalle.formact
                                    moThread.IsBackground = True
                                    moThread.Start()
                                Else
                                    moThread = New Thread(AddressOf LPEjecutaProcesarDeAUno)
                                    moThread.Name = sZIS_SAPzoho_.ToLower & "_" & moDetalle.formact
                                    moThread.IsBackground = True
                                    moThread.Start()
                                End If
                                MultiThread.Agregar(moThread)
                            Else
                                Select Case moDetalle.formact
                                    Case sBulk_
                                        moThread = New Thread(AddressOf LPEjecutaProcesarBulk)
                                        moThread.Name = sZIS_SAPzoho_.ToLower & "_" & moDetalle.formact
                                        moThread.IsBackground = True
                                        moThread.Start()
                                    Case sDeAUno_
                                        moThread = New Thread(AddressOf LPEjecutaProcesarDeAUno)
                                        moThread.Name = sZIS_SAPzoho_.ToLower & "_" & moDetalle.formact
                                        moThread.IsBackground = True
                                        moThread.Start()
                                End Select
                                MultiThread.Agregar(moThread)
                            End If
                        Case sZIS_ZOHOsap_.ToLower
                            moThread = New Thread(AddressOf LP_Integracion_ZohoSAP)
                            moThread.Name = sZIS_ZOHOsap_.ToLower & "_Proc:" & moDetalle.numtra & "_Mod.:" & moDetalle.nummod
                            moThread.IsBackground = True
                            moThread.Start()
                            MultiThread.Agregar(moThread)
                    End Select

                    Dim liCulminados As Integer
                    Dim liCantidad As Integer
                    Do While True
                        liCulminados = MultiThread.Culminados(moModelo.sentido.ToLower)
                        liCantidad = MultiThread.Cantidad(moModelo.sentido.ToLower)

                        If liCantidad > 0 And liCulminados = liCantidad Then
                            moModelo.numtra = moDetalle.nummod
                            If moModelo.GetPK() = sOk_ Then
                                moDetalle.numtra = miNumtra
                                moDetalle.numord = miNumord
                                moDetalle.ending = Now.ToString(sFormatoFechaHora1_)
                                Try
                                    moDetalle.Put(sNo_)
                                Catch ex As Exception
                                    GPBitacoraRegistrar(sError_, "Actualiza finalizacion en Modelo: " & ex.Message)
                                End Try
                                moCabecera.numtra = miNumtra
                                If moCabecera.GetPK = sOk_ Then
                                    If moCabecera.tipexec = sZIS_Multihilo_ Then
                                        If moCabecera.ending = "" Or moDetalle.ending > moCabecera.ending Then
                                            moCabecera.ending = moDetalle.ending
                                            Try
                                                moCabecera.Put(sNo_)
                                            Catch ex As Exception
                                                GPBitacoraRegistrar(sError_, "Actualiza finalizacion en Cabecera Proceso: " & ex.Message)
                                            End Try
                                        End If
                                    End If
                                End If
                            End If
                            Exit Do
                        Else
                            If liCantidad = 0 Then
                                moModelo.numtra = moDetalle.nummod
                                If moModelo.GetPK() = sOk_ Then
                                    moDetalle.numtra = miNumtra
                                    moDetalle.numord = miNumord
                                    moDetalle.ending = Now.ToString(sFormatoFechaHora1_)
                                    Try
                                        moDetalle.Put(sNo_)
                                    Catch ex As Exception
                                        GPBitacoraRegistrar(sError_, "Actualiza finalizacion en Modelo: " & ex.Message)
                                    End Try
                                    moCabecera.numtra = miNumtra
                                    If moCabecera.GetPK = sOk_ Then
                                        If moCabecera.tipexec = sZIS_Multihilo_ Then
                                            If moCabecera.ending = "" Or moDetalle.ending > moCabecera.ending Then
                                                moCabecera.ending = moDetalle.ending
                                                Try
                                                    moCabecera.Put(sNo_)
                                                Catch ex As Exception
                                                    GPBitacoraRegistrar(sError_, "Actualiza finalizacion en Cabecera Proceso: " & ex.Message)
                                                End Try
                                            End If
                                        End If
                                    End If
                                End If
                                Exit Do
                            End If
                        End If
                    Loop
                Else
                    GPBitacoraRegistrar(sMENSAJE_, "No existe el Modelo No." & moModelo.numtra.ToString & ", por favor verifique para continuar")
                End If
            Else
                GPBitacoraRegistrar(sMENSAJE_, "No existe el Proceso No." & miNumtra.ToString & ", Orden No. " & miNumord.ToString & ", por favor verifique para continuar")
            End If
            GPBitacoraRegistrar(sSALIO_, "Instancia ProcesoDetalle - Transacción: " & miNumtra.ToString & ", Orden:" & miNumord.ToString)
        End Sub

        Private Sub LPEjecutaProcesarBulk()
            moRegistroOperativo = New RegistrosOperativos("Logs_BULK_P" & miNumtra.ToString & "_O" & miNumord.ToString & "_M" & moDetalle.nummod.ToString & "_")
            GPProcesarBulk(moDataTable,, moModelo.destino, moModelo.numtra, msTipAct, moRegistroOperativo, moModelo.campopk)
            moRegistroOperativo.Cerrar()
        End Sub

        Private Sub LPEjecutaProcesarDeAUno()
            moRegistroOperativo = New RegistrosOperativos("Logs_DEAUNO_P" & miNumtra.ToString & "_O" & miNumord.ToString & "_M" & moDetalle.nummod.ToString & "_")
            GPProcesarDeAUno(moModelo.script, moModelo.destino, moModelo.numtra,, moModelo.findby, msTipAct, moRegistroOperativo, msFechaHoraAnterior)
            moRegistroOperativo.Cerrar()
        End Sub

        Private Sub LP_Integracion_ZohoSAP()
            moRegistroOperativo = New RegistrosOperativos("Logs_Integracion_ZohoSAP_" & miNumtra.ToString & "_O" & miNumord.ToString & "_M" & moDetalle.nummod.ToString & "_")
            GPIntegracionZohoSAP_COQL(moModelo.numtra, moRegistroOperativo)
            moRegistroOperativo.Cerrar()
        End Sub
    End Class
End Module

