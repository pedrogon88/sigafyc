Public Class Encriptacion

    Private Const sSEPARADOR_ As String = "_"
    Private Const sBLANCO_ As String = " "
    Private Const sFORMAT1_ As String = "00"
    Private Const sFORMAT2_ As String = "00000"
    Private Const sFORMAT_000_ As String = "000"
    Private Const sFORMAT_000000_ As String = "000000"
    Private Const iLongMaxima_ As Integer = 32000
    Private Const iLngSufijo_ As Integer = 12 'Que seria la sumatoria de las longitud de la siguiente concatenacion de formatos: sFormat1_ & sFormat2_ & sFormat2_

    Public Function Encriptar(ByVal psValor As String) As String
        Dim loAleatorio As New Random()
        Dim liDesplazamiento As Integer
        Dim liCantEspacio As Integer
        Dim lsCadena As String
        Dim liLngMaxima As Integer = iLongMaxima_ - iLngSufijo_

        Encriptar = psValor
        If psValor.Trim.Length = 0 Then Exit Function
        If psValor.Trim.Length > liLngMaxima Then Exit Function
        If psValor.IndexOf(Chr(255)) > 0 Then Exit Function

        liDesplazamiento = loAleatorio.Next(1, 11)
        liCantEspacio = (liLngMaxima - Integer.Parse(psValor.Trim.Length.ToString)) \ Integer.Parse(psValor.Trim.Length.ToString)

        lsCadena = LFsCadenaInicial(loAleatorio.Next(1, 11), liLngMaxima)

        For i As Integer = 0 To psValor.Trim.Length - 1
            Dim j As Integer = i * liCantEspacio
            If j = 0 Then j = 1

            Dim c As String = psValor.Substring(i, 1)
            If Asc(c) = Asc(sSEPARADOR_) Then c = Chr(255)
            If Asc(c) = Asc(sBLANCO_) Then c = sSEPARADOR_
            If Asc(c) <> 255 Then
                Mid(lsCadena, j, 1) = Chr(Asc(c) + liDesplazamiento)
            Else
                Mid(lsCadena, j, 1) = Chr(Asc(c))
            End If
        Next

        lsCadena = lsCadena.Trim & Format(liDesplazamiento, sFORMAT1_) & Format(psValor.Trim.Length, sFORMAT2_) & Format(liCantEspacio, sFORMAT2_)
        Encriptar = lsCadena
    End Function

    Public Function DesEncriptar(ByVal psValor As String) As String
        DesEncriptar = ""

        If psValor Is Nothing Then Exit Function
        If psValor.Trim.Length = 0 Then Exit Function

        Dim liLngMaxima As Integer = iLongMaxima_ - iLngSufijo_

        Dim liDesplazamiento As Integer = CType(Mid(psValor, liLngMaxima + 1, sFORMAT1_.Length), Integer)
        Dim liLongCadena As Integer = CType(Mid(psValor, liLngMaxima + 3, sFORMAT2_.Length), Integer)
        Dim liCantEspacio As Integer = CType(Mid(psValor, liLngMaxima + 8, sFORMAT2_.Length), Integer)

        For i As Integer = 0 To liLongCadena - 1
            Dim j As Integer = i * liCantEspacio
            If j = 0 Then j = 1
            If j > psValor.Trim.Length Then j = psValor.Trim.Length - iLngSufijo_

            Dim c As String
            If Asc(Mid(psValor, j, 1)) <> 255 Then
                c = Chr(Asc(Mid(psValor, j, 1)) - liDesplazamiento)
            Else
                c = Chr(Asc(Mid(psValor, j, 1)))
            End If

            DesEncriptar &= c.Trim
        Next i
        For i As Integer = 1 To liLongCadena
            If Mid(DesEncriptar, i, 1) = sSEPARADOR_ Then
                Mid(DesEncriptar, i, 1) = sBLANCO_
            End If
            If Mid(DesEncriptar, i, 1) = Chr(255) Then
                Mid(DesEncriptar, i, 1) = sSEPARADOR_
            End If
        Next i
    End Function
    Private Function LFsCadenaInicial(ByVal piIndice As Integer, ByVal piLngMaxima As Integer) As String
        LFsCadenaInicial = GFsGetRegistry("Encriptacion", "CadenaBase_No." & piIndice)
        If LFsCadenaInicial = sRESERVADO_ Then
            LFsCadenaInicial = LFsGeneraCadena(piLngMaxima)
            GPSavRegistry("Encriptacion", "CadenaBase_No." & piIndice, LFsCadenaInicial)
        End If
    End Function

    Private Function LFsGeneraCadena(ByVal piLongitud As Integer) As String
        Dim loValorAscii As New Random()
        LFsGeneraCadena = ""
        For i As Integer = 1 To piLongitud Step 1
            LFsGeneraCadena &= Chr(loValorAscii.Next(33, 255))
        Next i
    End Function

End Class

