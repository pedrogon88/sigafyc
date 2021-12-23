﻿Imports System.Threading

Public Class frmFEjecutarAutomatico1

    Private moContador As Integer = 0
    Private msZohoId As String = ""
    Private msModulo As String = ""
    Private msTiempo As String = ""
    Private miTiempo As Integer = 0
    Private loProcesoCabecera As Thread = Nothing

    Private Sub frmFEjecutarAutomatico1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        If GFsGetRegistry(sSesion_, "Automatico1") = sRESERVADO_ Then
            MsgBox("Proceso Automatico 1, no esta habilitado para su uso...",, "Mensaje del Sistema")
            Timer1.Enabled = False
            Me.Close()
        End If
        If GFsGetRegistry(sSesion_, sAutomatico1Final_) = sRESERVADO_ Then
            MsgBox("Ya existe una instancia del Proceso Automatico 1...",, "Mensaje del Sistema")
            Timer1.Enabled = False
            Me.Close()
        End If
        miTiempo = 5000
        msTiempo = GFsGetRegistry(sSesion_, "Automatico1_Tiempo_Seg")
        If msTiempo = sRESERVADO_ Then
            GPSavRegistry(sSesion_, "Automatico1_Tiempo_Seg", miTiempo.ToString)
        Else
            miTiempo = CType(msTiempo, Integer)
        End If
        Label1.Text = Label1.Text.Replace("&segundos", miTiempo.ToString)
        Timer1.Interval = miTiempo * 1000
        CheckForIllegalCrossThreadCalls = False
        GPSavRegistry(sSesion_, sAutomatico1Inicio_, Now.ToString(sFormatoFechaHora1_))
        GPSavRegistry(sSesion_, sAutomatico1Final_, sRESERVADO_)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If MultiThread.Cantidad(sAutomatico_ & "_ProcesarIntegracion") = 0 Or MultiThread.Cantidad(sAutomatico_ & "_ProcesarIntegracion") = MultiThread.Culminados(sAutomatico_ & "_ProcesarIntegracion") Then
            loProcesoCabecera = New Thread(AddressOf GPProcesoCabecera)
            loProcesoCabecera.Name = sAutomatico_ & "_ProcesarIntegracion"
            loProcesoCabecera.IsBackground = True
            loProcesoCabecera.Start()
            MultiThread.Agregar(loProcesoCabecera)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        GPSavRegistry(sSesion_, sAutomatico1Final_, Now.ToString(sFormatoFechaHora1_))
        MultiThread.AbortarTodo()
        Me.Close()
    End Sub
End Class