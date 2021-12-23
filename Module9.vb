Module Module9

    Sub Main()
        Dim lsRamaGeneral As String = sRegistryTablasSeguridad_ & sGeneral_ & sDS_
        Dim lsDbms As String = GFsGetRegistry(lsRamaGeneral, "Dbms_")
        Dim lsServer As String = GFsGetRegistry(lsRamaGeneral, "Server_")
        Dim lsPort As String = GFsGetRegistry(lsRamaGeneral, "Port_")
        Dim lsDatabase As String = GFsGetRegistry(lsRamaGeneral, "Database_")
        Dim lsUser As String = GFsGetRegistry(lsRamaGeneral, "User_")
        Dim lsPassword As String = GFsGetRegistry(lsRamaGeneral, "Password_")
        Console.WriteLine("Parametros General")
        Console.WriteLine("----------------------------------------------------------------------")
        Console.WriteLine("Rama General: {0}", lsRamaGeneral)
        Console.WriteLine("Dbms........: {0}", lsDbms)
        Console.WriteLine("Server......: {0}", lsServer)
        Console.WriteLine("Port........: {0}", lsPort)
        Console.WriteLine("Database....: {0}", lsDatabase)
        Console.WriteLine("User........: {0}", lsUser)
        Console.WriteLine("Password....: {0}", lsPassword)
        Console.WriteLine("----------------------------------------------------------------------")
        Console.WriteLine("Presione <ENTER> para continuar")
        Console.ReadLine()

        lsRamaGeneral = sRegistryTablasSeguridad_ & sResetear_ & sDS_
        lsDbms = GFsGetRegistry(lsRamaGeneral, "Dbms")
        lsServer = GFsGetRegistry(lsRamaGeneral, "Server")
        lsPort = GFsGetRegistry(lsRamaGeneral, "Port")
        lsDatabase = GFsGetRegistry(lsRamaGeneral, "Database")
        lsUser = GFsGetRegistry(lsRamaGeneral, "User")
        lsPassword = GFsGetRegistry(lsRamaGeneral, "Password")

        Console.WriteLine("Parametros Resetear")
        Console.WriteLine("----------------------------------------------------------------------")
        Console.WriteLine("Rama General: {0}", lsRamaGeneral)
        Console.WriteLine("Dbms........: {0}", lsDbms)
        Console.WriteLine("Server......: {0}", lsServer)
        Console.WriteLine("Port........: {0}", lsPort)
        Console.WriteLine("Database....: {0}", lsDatabase)
        Console.WriteLine("User........: {0}", lsUser)
        Console.WriteLine("Password....: {0}", lsPassword)
        Console.WriteLine("----------------------------------------------------------------------")
        Console.WriteLine("Presione <ENTER> para continuar")
        Console.ReadLine()

        lsRamaGeneral = sRegistryTablasSeguridad_ & sGeneral_ & sDS_ & sResetear_ & sDS_
        lsDbms = GFsGetRegistry(lsRamaGeneral, "Dbms")
        lsServer = GFsGetRegistry(lsRamaGeneral, "Server")
        lsPort = GFsGetRegistry(lsRamaGeneral, "Port")
        lsDatabase = GFsGetRegistry(lsRamaGeneral, "Database")
        lsUser = GFsGetRegistry(lsRamaGeneral, "User")
        lsPassword = GFsGetRegistry(lsRamaGeneral, "Password")

        Console.WriteLine("Parametros General Resetear")
        Console.WriteLine("----------------------------------------------------------------------")
        Console.WriteLine("Rama General: {0}", lsRamaGeneral)
        Console.WriteLine("Dbms........: {0}", lsDbms)
        Console.WriteLine("Server......: {0}", lsServer)
        Console.WriteLine("Port........: {0}", lsPort)
        Console.WriteLine("Database....: {0}", lsDatabase)
        Console.WriteLine("User........: {0}", lsUser)
        Console.WriteLine("Password....: {0}", lsPassword)
        Console.WriteLine("----------------------------------------------------------------------")
        Console.WriteLine("Presione <ENTER> para continuar")
        Console.ReadLine()

        'Dim loSS010 As New Ess010sistemas
        'Dim loSS020 As New Ess020menues
        'Dim loSS030 As New Ess030tabcab
        'Dim loSS040 As New Ess040tabdet
        'Dim loSS050 As New Ess050usuarios
        'Dim loSS060 As New Ess060equipos
        'Dim loSS070 As New Ess070perfiles
        'Dim loSS080 As New Ess080restricciones
        'Dim loSS090 As New Ess090perusu
        'Dim loSS100 As New Ess100habilitaciones
        'Dim loSS110 As New Ess110parametros
        'Dim loSS120 As New Ess120bitdatcab
        'Dim loSS130 As New Ess130bitdatdet
        'Dim loSS140 As New Ess140bitsescab
        'Dim loSS150 As New Ess150bitsesdet
        'loSS010 = Nothing
        'loSS020 = Nothing
        'loSS030 = Nothing
        'loSS040 = Nothing
        'loSS050 = Nothing
        'loSS060 = Nothing
        'loSS070 = Nothing
        'loSS080 = Nothing
        'loSS090 = Nothing
        'loSS100 = Nothing
        'loSS110 = Nothing
        'loSS120 = Nothing
        'loSS130 = Nothing
        'loSS140 = Nothing
        'loSS150 = Nothing
    End Sub

End Module
