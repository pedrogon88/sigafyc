Imports System.IO
Imports System.Management
Imports System.Net
Imports System.Net.NetworkInformation
Module Module11
    Private Const sTiposRed_ As String = "Ethernet" & sSF_ & "Wi-Fi"
    Sub Main()
        Console.WriteLine("My.Application.Info.DirectoryPath: {0}", My.Application.Info.DirectoryPath)
        Console.WriteLine("My.Application.Info.AssemblyName: {0}", My.Application.Info.AssemblyName)
        Console.WriteLine("My.Application.Info.CompanyName: {0}", My.Application.Info.CompanyName)
        Console.WriteLine("My.Application.Info.Version: {0}", My.Application.Info.Version)
        Console.WriteLine("My.Application.Info.Description: {0}", My.Application.Info.Description)
        Console.WriteLine("My.Application.GetEnvironmentVariable(USERNAME): {0}", My.Application.GetEnvironmentVariable("USERNAME"))
        Console.WriteLine("My.Application.GetEnvironmentVariable(COMPUTERNAME): {0}", My.Application.GetEnvironmentVariable("COMPUTERNAME"))
        For Each drive As DriveInfo In My.Computer.FileSystem.Drives
            If drive.DriveType = DriveType.Fixed Then
                With drive
                    Console.WriteLine("Name: {0}", .Name)
                    Console.WriteLine("DriveType: {0}", .DriveType)
                    Console.WriteLine("DriveFormat: {0}", .DriveFormat)
                    Console.WriteLine("VolumeLabel: {0}", .VolumeLabel)
                    Console.WriteLine("RootDirectory: {0}", .RootDirectory)
                    Console.WriteLine("------------------------------------------------------------")
                End With
            End If
        Next

        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive")
        For Each wmi_HD As ManagementObject In searcher.Get()
            If InStr(wmi_HD("DeviceId"), "PHYSICALDRIVE0") > 0 Then
                Console.WriteLine("Model: {0}", wmi_HD("Model"))
                Console.WriteLine("MediaType: {0}", wmi_HD("MediaType"))
                Console.WriteLine("SerialNumber: {0}", wmi_HD("SerialNumber").ToString.Trim)
                Console.WriteLine("Signature: {0}", wmi_HD("Signature"))
            End If
            Console.WriteLine("------------------------------------------------------------" & ControlChars.CrLf)
        Next wmi_HD

        Console.WriteLine("IP address: {0}", ObtenerIP())
        For Each loRed As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces
            If loRed.OperationalStatus = OperationalStatus.Up Then
                If InStr(sTiposRed_, loRed.Name) > 0 Then
                    Console.WriteLine("MAC Address: {0}", loRed.GetPhysicalAddress.ToString)
                End If
            End If
        Next

        'searcher = New ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")

        'Console.WriteLine("SELECT * FROM Win32_PhysicalMedia")
        'For Each wmi_HD As ManagementObject In searcher.Get()

        '    If wmi_HD("SerialNumber") Is Nothing Then
        '        Console.WriteLine("No tiene serial number")
        '    Else
        '        For Each loPropertyData As PropertyData In wmi_HD.Properties
        '            Console.WriteLine("{0} --> {1}", loPropertyData.Name, loPropertyData.Value)
        '        Next
        '    End If
        '    Console.WriteLine("------------------------------------------------------------" & ControlChars.CrLf)
        'Next wmi_HD


        'Dim lsHostName = Dns.GetHostName
        'Dim lsIP, lsGateway, lsDNS1, lsDNS2 As String
        'lsIP = ""
        'lsGateway = ""
        'lsDNS1 = ""
        'lsDNS2 = ""
        'Console.WriteLine("HostName: {0}", lsHostName)
        'For Each ip In System.Net.Dns.GetHostEntry(lsHostName).AddressList
        '    If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
        '        'IPv4 Adress
        '        lsIP = ip.ToString
        '        Console.WriteLine("IP: {0}", lsIP)

        '        For Each adapter As NetworkInterface In Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        '            For Each unicastIPAddressInformation As Net.NetworkInformation.UnicastIPAddressInformation In adapter.GetIPProperties().UnicastAddresses
        '                If unicastIPAddressInformation.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
        '                    If ip.Equals(unicastIPAddressInformation.Address) Then
        '                        'Subnet Mask
        '                        Console.WriteLine("Subnet Mask: {0}", unicastIPAddressInformation.IPv4Mask.ToString())

        '                        Dim adapterProperties As Net.NetworkInformation.IPInterfaceProperties = adapter.GetIPProperties()
        '                        For Each gateway As Net.NetworkInformation.GatewayIPAddressInformation In adapterProperties.GatewayAddresses
        '                            'Default Gateway
        '                            lsGateway = gateway.Address.ToString()
        '                            Console.WriteLine("Default Gateway: {0}", lsGateWay)
        '                        Next

        '                        'DNS1
        '                        If adapterProperties.DnsAddresses.Count > 0 Then
        '                            lsDNS1 = adapterProperties.DnsAddresses(0).ToString()
        '                            Console.WriteLine("DNS1: {0}", lsDNS1)

        '                        End If

        '                        'DNS2
        '                        If adapterProperties.DnsAddresses.Count > 1 Then
        '                            lsDNS2 = adapterProperties.DnsAddresses(1).ToString()
        '                            Console.WriteLine("DNS2: {0}", lsDNS2)
        '                        End If
        '                    End If
        '                End If
        '            Next
        '        Next
        '    End If
        '    If lsGateway.Trim.Length > 0 And lsDNS1.Trim.Length > 0 Then
        '        If lsGateway = lsDNS1 Then
        '            Console.WriteLine("===================================================================")
        '            Console.WriteLine("Esta es la IP correcta: {0}", lsIP)
        '            Console.WriteLine("===================================================================")
        '        End If
        '    End If
        'Next
        Console.WriteLine("presione <ENTER> p/continuar")
        Console.ReadLine()

    End Sub

    Public Function ObtenerIP() As String
        Dim lsHostName = Dns.GetHostName
        Dim lsIP, lsGateway, lsDNS1, lsDNS2 As String
        lsIP = ""
        lsGateway = ""
        lsDNS1 = ""
        lsDNS2 = ""
        For Each ip In System.Net.Dns.GetHostEntry(lsHostName).AddressList
            If ip.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                'IPv4 Adress
                lsIP = ip.ToString

                For Each adapter As NetworkInterface In Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                    For Each unicastIPAddressInformation As Net.NetworkInformation.UnicastIPAddressInformation In adapter.GetIPProperties().UnicastAddresses
                        If unicastIPAddressInformation.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                            If ip.Equals(unicastIPAddressInformation.Address) Then
                                'Subnet Mask
                                Dim adapterProperties As Net.NetworkInformation.IPInterfaceProperties = adapter.GetIPProperties()
                                For Each gateway As Net.NetworkInformation.GatewayIPAddressInformation In adapterProperties.GatewayAddresses
                                    'Default Gateway
                                    lsGateway = gateway.Address.ToString()
                                Next

                                'DNS1
                                If adapterProperties.DnsAddresses.Count > 0 Then
                                    lsDNS1 = adapterProperties.DnsAddresses(0).ToString()
                                End If
                            End If
                        End If
                    Next
                Next
            End If
            If lsGateway.Trim.Length > 0 And lsDNS1.Trim.Length > 0 Then
                If lsGateway = lsDNS1 Then
                    Exit For
                End If
            End If
        Next
        Return lsIP
    End Function

End Module
