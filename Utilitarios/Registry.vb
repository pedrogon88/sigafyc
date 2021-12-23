Public Class Registry
    Shared moRegistry As New Hashtable

    Public Function GetRegistry(ByVal psRama As String, ByVal psClave As String) As String
        Dim loDesEncriptar As New Encriptacion
        Dim lsGetRegistry As String
        Dim loRegistry As Microsoft.Win32.RegistryKey
        Dim loKey As String = sRegistryRoot_ & My.Application.Info.AssemblyName & sDS_ & psRama
        loRegistry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(loKey, True)

        If loRegistry Is Nothing Then
            loRegistry = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(loKey)
        End If
        lsGetRegistry = loRegistry.GetValue(psClave, sNODEFINIDO_).ToString
        If lsGetRegistry = sNODEFINIDO_ Then
            lsGetRegistry = sRESERVADO_
            SavRegistry(psRama, psClave, lsGetRegistry)
        Else
            Dim lsKey As String = psRama & psClave
            If psClave.Substring(psClave.Length - 1, 1) = sMarcaEncriptado_ Then
                If moRegistry.ContainsKey(lsKey) = False Then
                    lsGetRegistry = loDesEncriptar.DesEncriptar(lsGetRegistry)
                    moRegistry.Add(lsKey, lsGetRegistry)
                Else
                    lsGetRegistry = moRegistry(lsKey).ToString
                End If
            End If
        End If
        loRegistry.Close()
        loDesEncriptar = Nothing
        Return lsGetRegistry
    End Function

    Public Sub SavRegistry(ByVal psRama As String, ByVal psClave As String, ByVal psValor As String)
        Dim loEncriptar As New Encriptacion
        Dim lsValor As String = psValor
        Dim loRegistry As Microsoft.Win32.RegistryKey
        Dim loKey As String = sRegistryRoot_ & My.Application.Info.AssemblyName & sDS_ & psRama

        loRegistry = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(loKey, True)
        If loRegistry Is Nothing Then
            loRegistry = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(loKey)
        End If

        If psClave.Substring(psClave.Length - 1, 1) = sMarcaEncriptado_ Then
            Dim lsKey As String = psRama & psClave
            If moRegistry.ContainsKey(lsKey) = True Then
                moRegistry(lsKey) = lsValor
            Else
                moRegistry.Add(lsKey, lsValor)
            End If
            lsValor = loEncriptar.Encriptar(lsValor)
        End If
        loRegistry.SetValue(psClave, lsValor)
        loRegistry.Close()
    End Sub

End Class
