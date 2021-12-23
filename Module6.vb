Imports System.Reflection
Module Module6
    Sub Main()
        Dim ss010 As New Ess010sistemas
        ss010.codigo = "sigafyc_ss"
        If ss010.GetPK() = sOk_ Then
            Console.WriteLine("codigo: {0}", ss010.codigo)
            Console.WriteLine("nombre: {0}", ss010.nombre)
            Console.WriteLine("estado: {0}", ss010.estado)
            Console.WriteLine("borrado: {0}", ss010.borrado)
            Console.WriteLine("hashid: {0}", ss010.hashid)
        Else
            ss010.nombre = "Sistema Integrado de Gestion Administrativa, Financiera y Contable (Sistema Seguridad)"
            ss010.Add()
        End If
        Console.WriteLine("------------------------------------------------------------")
        Console.WriteLine("presione <ENTER> para continuar")
        Console.ReadLine()
        ss010 = Nothing
    End Sub

End Module


