Public Class ValidacionDataEntry
    Private Const sAlfabeticoLN_ As String = "$%#´&()=?¿¡\*+{}[]|'_:;,1234567890^`~"""
    Private Const sNumeroEnteroLB_ As String = "0123456789"
    Private Const sAlfaNumericoLN_ As String = "´&/()?¿¡|+{}';^`~"""
    Private Const sSoloRucLN_ As String = "áéíóúÁÉÍÓÚ$%#´&/()=?¿¡\*+{}[]|'_:;,-^`~abcdefghijklmnñopqrstuvwxyz"
    Private Const sNumeroDecimalLB_ As String = "0123456789,"
    Private Const sFechaLB_ As String = "0123456789 -:/"

    Private msTipoValor As eTipoValor
    Private msMayuscula As String

    Public Property tipoValor As eTipoValor
        Get
            Return msTipoValor
        End Get
        Set(value As eTipoValor)
            msTipoValor = value
        End Set
    End Property

    Public Property mayuscula As String
        Get
            Return msMayuscula
        End Get
        Set(value As String)
            msMayuscula = value
        End Set
    End Property

    Public Sub New()
        tipoValor = eTipoValor.NumeroEntero
        mayuscula = sNo_
    End Sub

    Public Function TeclaPresionada(ByVal piKeyCode As Integer, Optional ByVal poSender As Object = Nothing) As Integer
        Dim liResultado As Integer = piKeyCode

        If mayuscula = sSi_ Then
            liResultado = Asc(UCase(Chr(LFiValidaCaracter(piKeyCode, poSender))))
        Else
            liResultado = LFiValidaCaracter(piKeyCode, poSender)
        End If

        Return liResultado
    End Function

    Private Function LFiValidaCaracter(ByVal piKeyCode As Integer, Optional ByVal poSender As Object = Nothing) As Integer
        Dim liResultado As Integer = piKeyCode
        Select Case tipoValor
            Case eTipoValor.Alfabetico
                For miNDX = 1 To Len(Trim(sAlfabeticoLN_))
                    If Mid(Trim(sAlfabeticoLN_), miNDX, 1) = Chr(piKeyCode) Then
                        liResultado = 0
                        Exit For
                    End If
                Next
            Case eTipoValor.NumeroEntero
                liResultado = 0
                If piKeyCode = Keys.Back Then
                    liResultado = piKeyCode
                Else
                    For miNDX = 1 To Len(Trim(sNumeroEnteroLB_))
                        If Mid(Trim(sNumeroEnteroLB_), miNDX, 1) = Chr(piKeyCode) Then
                            liResultado = piKeyCode
                            Exit For
                        End If
                    Next
                End If

            Case eTipoValor.AlfaNumerico
                For miNDX = 1 To Len(Trim(sAlfaNumericoLN_))
                    If Mid(Trim(sAlfaNumericoLN_), miNDX, 1) = Chr(piKeyCode) Then
                        liResultado = 0
                        Exit For
                    End If
                Next
            Case eTipoValor.Ruc
                For miNDX = 1 To Len(Trim(sSoloRucLN_))
                    If Mid(Trim(sSoloRucLN_), miNDX, 1) = Chr(piKeyCode) Then
                        liResultado = 0
                        Exit For
                    End If
                Next
            Case eTipoValor.NumeroDecimal
                liResultado = 0
                If piKeyCode = Keys.Back Then
                    liResultado = piKeyCode
                Else
                    If piKeyCode = 46 Then piKeyCode = piKeyCode - 2
                    For miNDX = 1 To Len(Trim(sNumeroDecimalLB_))
                        If Mid(Trim(sNumeroDecimalLB_), miNDX, 1) = Chr(piKeyCode) Then
                            liResultado = piKeyCode
                            Exit For
                        End If
                    Next
                End If
            Case eTipoValor.Fecha
                liResultado = 0
                If piKeyCode = Keys.Back Then
                    liResultado = piKeyCode
                Else
                    For miNDX = 1 To Len(Trim(sFechaLB_))
                        If Mid(Trim(sFechaLB_), miNDX, 1) = Chr(piKeyCode) Then
                            liResultado = piKeyCode
                            Exit For
                        End If
                    Next
                End If
        End Select
        If Not (poSender Is Nothing) Then
            CType(poSender, Control).BackColor = Color.FromArgb(93, 209, 172)
            If liResultado = 0 Then
                If piKeyCode <> 13 Then
                    CType(poSender, Control).BackColor = Drawing.Color.LightPink
                End If
            End If
        End If
        Return liResultado
    End Function
End Class
