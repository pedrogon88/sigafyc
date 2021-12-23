Imports System.IO
Imports System.Windows.Forms

Public Class ArchivoControl
    Private Const sSufijoControl_ As String = "_control.sys"

    Public Sub Genera()
        Dim lsFechaExpiracion As String = ""
        Dim lsSerialHDD As String = ""
        Dim lsRazonSocial As String = ""
        Dim lsUltimoAcceso As String = ""
        Dim lsUsuarioSupervisor As String = ""
        Dim lsPasswordSupervisor As String = ""
        Dim lsUbicacion As String = My.Application.Info.DirectoryPath
        Dim lsFileName As String = My.Application.Info.AssemblyName & sSufijoControl_
        Dim loFormulario As New frmFGeneraArchivoControl

        loFormulario.ShowDialog()
        If loFormulario.Tag.ToString = sCancelar_ Then Exit Sub
        lsFechaExpiracion = loFormulario.txtFechaExpiracion_FE.Value.ToString(sFormatoFecha1_)
        lsSerialHDD = loFormulario.txtSerialHDD_AN.Text
        lsRazonSocial = loFormulario.txtRazonSocial_AN.Text
        lsUltimoAcceso = loFormulario.txtUltimoAcceso_FE.Text
        lsUsuarioSupervisor = loFormulario.txtUsuarioSupervisor_AB.Text
        lsPasswordSupervisor = loFormulario.txtPasswordSupervisor_AN.Text
        loFormulario = Nothing

        Dim loArchivoControl As New StreamWriter(lsUbicacion & sDS_ & lsFileName)
        Dim lsContenidoBack As String = ""
        Dim lsContenido As String = sFechaExpiracion_ & "=" & sPrefijoParam_ & sFechaExpiracion_ & sSF_ & sSerialHDD_ & "=" & sPrefijoParam_ & sSerialHDD_ & sSF_ & sRazonSocial_ & "=" & sPrefijoParam_ & sRazonSocial_ & sSF_ & sUltimoAcceso_ & "=" & sPrefijoParam_ & sUltimoAcceso_ & sSF_ & sUsuarioSupervisor_ & "=" & sPrefijoParam_ & sUsuarioSupervisor_ & sSF_ & sPasswordSupervisor_ & "=" & sPrefijoParam_ & sPasswordSupervisor_
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sFechaExpiracion_, lsFechaExpiracion)
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sSerialHDD_, lsSerialHDD)
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sRazonSocial_, lsRazonSocial)
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sUltimoAcceso_, lsUltimoAcceso)
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sUsuarioSupervisor_, lsUsuarioSupervisor)
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sPasswordSupervisor_, lsPasswordSupervisor)

        Dim loEncriptacion As New Encriptacion
        lsContenidoBack = lsContenido
        lsContenido = loEncriptacion.Encriptar(lsContenido)

        loArchivoControl.WriteLine(lsContenido)
        loArchivoControl.Close()
        loEncriptacion = Nothing
        loArchivoControl = Nothing
        MessageBox.Show("Ha sido generado exitosamente el archivo de control" & ControlChars.CrLf & "Ubicacion:" & lsUbicacion & ControlChars.CrLf & "Archivo:" & lsFileName)
    End Sub

    Public Sub Actualizar()
        Dim lsFechaExpiracion As String = SesionActiva.datosControl(sFechaExpiracion_).ToString
        Dim lsSerialHDD As String = SesionActiva.datosControl(sSerialHDD_).ToString
        Dim lsRazonSocial As String = SesionActiva.datosControl(sRazonSocial_).ToString
        Dim lsUsuarioSupervisor As String = SesionActiva.datosControl(sUsuarioSupervisor_).ToString
        Dim lsPasswordSupervisor As String = SesionActiva.datosControl(sPasswordSupervisor_).ToString
        Dim lsUbicacion As String = My.Application.Info.DirectoryPath
        Dim lsFileName As String = My.Application.Info.AssemblyName & sSufijoControl_

        Dim loArchivoControl As New StreamWriter(lsUbicacion & sDS_ & lsFileName)
        Dim lsContenido As String = sFechaExpiracion_ & "=" & sPrefijoParam_ & sFechaExpiracion_ & sSF_ & sSerialHDD_ & "=" & sPrefijoParam_ & sSerialHDD_ & sSF_ & sRazonSocial_ & "=" & sPrefijoParam_ & sRazonSocial_ & sSF_ & sUltimoAcceso_ & "=" & sPrefijoParam_ & sUltimoAcceso_ & sSF_ & sUsuarioSupervisor_ & "=" & sPrefijoParam_ & sUsuarioSupervisor_ & sSF_ & sPasswordSupervisor_ & "=" & sPrefijoParam_ & sPasswordSupervisor_
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sFechaExpiracion_, lsFechaExpiracion & sSeparador_)
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sSerialHDD_, lsSerialHDD)
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sRazonSocial_, lsRazonSocial)
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sUltimoAcceso_, Now.ToString(sFormatoFechaHora1_))
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sUsuarioSupervisor_, lsUsuarioSupervisor)
        lsContenido = lsContenido.Replace(sPrefijoParam_ & sPasswordSupervisor_, lsPasswordSupervisor)

        Dim loEncriptacion As New Encriptacion
        lsContenido = loEncriptacion.Encriptar(lsContenido)

        loArchivoControl.WriteLine(lsContenido)

        loArchivoControl.Close()
        loEncriptacion = Nothing
        loArchivoControl = Nothing
    End Sub

    Public Function Recupera() As Hashtable
        Dim loResultado As New Hashtable
        Dim loDesencriptar As New Encriptacion
        Dim lsUbicacion As String = My.Application.Info.DirectoryPath
        Dim lsFileName As String = My.Application.Info.AssemblyName & sSufijoControl_
        Dim lsArchivoControl As String = lsUbicacion & sDS_ & lsFileName
        If Not File.Exists(lsArchivoControl) Then
            MessageBox.Show("El archivo de control: " & lsFileName & ", no se encuentra." & ControlChars.CrLf & "Esto impedira que pueda ingresar al sistema")
            Clipboard.SetText("El archivo de control se encuentra: " & lsUbicacion & ControlChars.CrLf & "Nombre del archivo: " & lsFileName)

            If Application.MessageLoop Then
                Application.Exit()
            Else
                Environment.Exit(1)
            End If
            Recupera = Nothing
            Exit Function
        End If
        Dim loArchivoControl As New StreamReader(lsArchivoControl)
        Dim lsContenido As String = ""
        lsContenido = loDesencriptar.DesEncriptar(loArchivoControl.ReadLine)
        Dim lsCampos() As String = lsContenido.Split(sSF_)

        For liNDX As Integer = 0 To lsCampos.Length - 1
            Dim lsParte() As String = lsCampos(liNDX).Split("="c)
            loResultado.Add(lsParte(0), lsParte(1))
        Next
        loArchivoControl.Close()
        loArchivoControl = Nothing
        Return loResultado
    End Function

End Class
