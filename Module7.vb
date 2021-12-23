Module Module7
    Private msRequeridos() As String = {"estado" & sString_, "borrado" & sString_, "hashid" & sString_}
    Sub Main()
        MostrarArray(msRequeridos, "msRequeridos() -> (" & msRequeridos.Length & ")")

        Dim lsRequeridos() As String = {"ss010_codigo" & sString_,
                                        "ss030_codigo" & sString_,
                                        "codigo" & sString_,
                                        "tipo" & sString_,
                                        "longitud" & sString_,
                                        "fraccion" & sString_,
                                        "obligatorio" & sString_,
                                        "nivel" & sString_,
                                        "nombreform" & sString_,
                                        "nombrereport" & sString_,
                                        "pk" & sString_,
                                        "fk" & sString_,
                                        "descripcion" & sString_}

        MostrarArray(lsRequeridos, "psRequeridos() -> (" & lsRequeridos.Length & ")")

        Dim liLength As Integer = lsRequeridos.Length
        ReDim Preserve lsRequeridos(liLength + msRequeridos.Length - 1)
        Array.Copy(msRequeridos, 0, lsRequeridos, liLength, msRequeridos.Length)

        MostrarArray(lsRequeridos, "msRequeridos() agregado -> (" & msRequeridos.Length & ")")

    End Sub

    Private Sub MostrarArray(ByVal psArray() As String, Optional ByVal psTitulo As String = "Impresione de Array")
        Dim liNDX As Integer = 0

        Console.WriteLine(psTitulo)
        Console.WriteLine("--------------------------------------------------------------------------------")
        For liNDX = 0 To psArray.Length - 1
            Console.WriteLine("Array({0}) = {1}", liNDX, psArray(liNDX))
        Next
        Console.WriteLine("--------------------------------------------------------------------------------")
        Console.WriteLine("presione <ENTER> para continuar" & ControlChars.CrLf)
        Console.ReadLine()
    End Sub

End Module
