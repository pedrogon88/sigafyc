Module Module8

    Sub Main()
        Dim sColores(3) As String
        sColores(0) = "Azul"
        sColores(1) = "Verde"
        sColores(2) = "Rosa"
        sColores(3) = "Blanco"
        MostrarArray(sColores)
        ' copiar usando el método CopyTo(),
        ' copiamos en el array sColorDestino,
        ' y comenzando por su posición 2, los
        ' valores del array sColores
        Dim sColorDestino(6) As String
        sColores.CopyTo(sColorDestino, 2)
        Console.WriteLine("Array sColorDestino")
        MostrarArray(sColorDestino)
        ' copiar usando el método Copy(),
        ' copiamos en el array sListaColores,
        ' a partir de su posición 2,
        ' 2 elementos del array sColores, comenzando
        ' desde la posición 1 de sColores
        Dim sListaColores(10) As String
        sListaColores(0) = "Color 0"
        sListaColores(1) = "Color 1"
        sListaColores(2) = "Color 2"
        sListaColores(3) = "Color 3"
        sListaColores(4) = "Color 4"
        Array.Copy(sColores, 0, sListaColores, 5, 3)
        Console.WriteLine("Array sListaColores")
        MostrarArray(sListaColores)
        Console.ReadLine()
    End Sub

    Private Sub MostrarArray(ByVal sMiLista() As String)
        Dim iContador As Integer
        For iContador = 0 To sMiLista.Length - 1
            Console.WriteLine("Elemento: {0} - Valor: {1}", iContador, sMiLista(iContador))
        Next
        Console.WriteLine()
    End Sub

End Module
