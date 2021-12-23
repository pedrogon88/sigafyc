Module Module14
    Public Sub main()
        LPPruebaOCRD()
        Application.Exit()
    End Sub

    Private Sub LPPruebaOITM()
        Dim msRetorno As String = ""
        Dim moOITM As Eoitm = New Eoitm
        Dim msItemName As String = ""
        Dim msU_Marca As String = ""

        If moOITM.GetPK("C10798") = True Then
            Console.WriteLine("Primera lectura")
            Console.WriteLine("--------------------------------------------------------------")
            Console.WriteLine("ItemCode: " & moOITM.GetAtributo("ItemCode"))
            msItemName = moOITM.GetAtributo("ItemName")
            msU_Marca = moOITM.GetAtributo("U_marca")
            Console.WriteLine("ItemName: " & msItemName)
            Console.WriteLine("U_marca.: " & msU_Marca)

            moOITM.SetAtributo("ItemName", "SEMI REMOLQUE LIBRELATO TANQUE CHASIS 9A90TN663JRDJ5304")
            'moOITM.SetAtributo("ItemName", "***MODIFICADO******MODIFICADO******MODIFICADO******MODIFICADO***" & msItemName)
            'moOITM.SetAtributo("U_marca", "SCANIA")
            moOITM.SetAtributo("U_marca", "LIBRELATO")

            msRetorno = moOITM.Put()

            If msRetorno <> sOk_ Then
                Console.WriteLine("Error: " & msRetorno)
            End If
            If moOITM.GetPK("C10798") = True Then
                Console.WriteLine("Segunda lectura")
                Console.WriteLine("--------------------------------------------------------------")
                Console.WriteLine("ItemCode: " & moOITM.GetAtributo("ItemCode"))
                msItemName = moOITM.GetAtributo("ItemName")
                msU_Marca = moOITM.GetAtributo("U_marca")
                Console.WriteLine("ItemName: " & msItemName)
                Console.WriteLine("U_Name..: " & msU_Marca)
            End If
            moOITM.Desconectar()
        End If
    End Sub

    Private Sub LPPruebaOCRD()
        Dim msCodigo As String = "1359893$"
        Dim msRetorno As String = ""
        Dim moOCRD As Eocrd = New Eocrd
        Dim msCardName As String = ""
        Dim msCardType As String = ""

        If moOCRD.GetPK(msCodigo) = True Then
            Console.WriteLine("Primera lectura")
            Console.WriteLine("--------------------------------------------------------------")
            Console.WriteLine("Cardcode: " & moOCRD.GetAtributo("CardCode"))
            msCardName = moOCRD.GetAtributo("CardName")
            msCardType = moOCRD.Atributo.CardType.ToString
            Console.WriteLine("CardName: " & msCardName)
            Console.WriteLine("CardType: " & msCardType)

            'moOCRD.SetAtributo("CardName", "JOSE ARMANDO CANDIA TORRES")
            moOCRD.SetAtributo("CardName", "DANIEL OSORIO ROMAN")
            moOCRD.Atributo.CardType = SAPbobsCOM.BoCardTypes.cSupplier
            msRetorno = moOCRD.Put()

            If msRetorno <> sOk_ Then
                Console.WriteLine("Error: " & msRetorno)
            End If
            If moOCRD.GetPK(msCodigo) = True Then
                Console.WriteLine("Segunda lectura")
                Console.WriteLine("--------------------------------------------------------------")
                Console.WriteLine("Cardcode: " & moOCRD.GetAtributo("CardCode"))
                msCardName = moOCRD.GetAtributo("CardName")
                msCardType = moOCRD.Atributo.CardType.ToString
                Console.WriteLine("CardName: " & msCardName)
                Console.WriteLine("CardType: " & msCardType)
            End If
            moOCRD.Desconectar()
        Else
            Console.WriteLine("No existen datos para OCRD #:" & msCodigo)
        End If
        Console.ReadLine()
    End Sub

End Module
