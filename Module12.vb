Module Module12

    Public Sub Main()
        Dim loControl As New ArchivoControl
        Dim loCampos As Hashtable = Nothing

        loControl.Genera()
        loCampos = loControl.Recupera
        '--"FechaExpiracion=@FechaExpiracion|SerialHDD=@SerialHDD|RazonSocial=@RazonSocial|UltimoAcceso=@UltimoAcceso|Final= "
        'lsContenido = lsContenido.Replace("@FechaExpiracion", lsFechaExpiracion)
        'lsContenido = lsContenido.Replace("@SerialHDD", lsSerialHDD)
        'lsContenido = lsContenido.Replace("@RazonSocial", lsRazonSocial)
        'lsContenido = lsContenido.Replace("@UltimoAcceso", Now.ToString("yyyy-MM-dd HH:mm:ss"))
        'lsContenido = lsContenido.Replace("@UsuarioSupervisor", sManagerName_)
        'lsContenido = lsContenido.Replace("@PasswordSupervisor", sManagerPassword_)

        Console.Clear()
        Console.WriteLine("----------------------------------------------------------------")
        Console.WriteLine("Fecha expiracion.: {0}", loCampos("FechaExpiracion"))
        Console.WriteLine("Serial HDD.......: {0}", loCampos("SerialHDD"))
        Console.WriteLine("Razon Social.....: {0}", loCampos("RazonSocial"))
        Console.WriteLine("Ultimo acceso....: {0}", loCampos("UltimoAcceso"))
        Console.WriteLine("Nombre SysAdmin..: {0}", loCampos("UsuarioSupervisor"))
        Console.WriteLine("Password SysAdmin: {0}", loCampos("PasswordSupervisor"))
        Console.WriteLine("----------------------------------------------------------------")
        Console.WriteLine("presione <ENTER> para continuar")
        Console.ReadLine()
    End Sub

End Module
