Module Module4

    Sub Main()

        Dim ss020 As Ess020modulos

        ss020 = New Ess020modulos
        ss020.ss010_codigo = "sigafyc"
        ss020.codigo = "01" & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_
        ss020.nombre = "Configurador..."
        ss020.tipo = sMenu_
        ss020.descripcion = "Contiene todas las opciones relacionadas con las configuraciones del sistema"
        ss020.Add()

        ss020.ss010_codigo = "sigafyc"
        ss020.codigo = "02" & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_
        ss020.nombre = "Control de Stock..."
        ss020.tipo = sMenu_
        ss020.descripcion = "Todas las opciones relacionadas con el control de stock"
        ss020.Add()

        ss020.ss010_codigo = "sigafyc"
        ss020.codigo = "03" & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_
        ss020.nombre = "Facturacion..."
        ss020.tipo = sMenu_
        ss020.descripcion = "Todas las opciones relacionadas con facturacion"
        ss020.Add()

        ss020.ss010_codigo = "sigafyc"
        ss020.codigo = "04" & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_
        ss020.nombre = "Cuentas Deudoras..."
        ss020.tipo = sMenu_
        ss020.descripcion = "Todas las opciones de las cuentas deudoras"
        ss020.Add()

        ss020.ss010_codigo = "sigafyc"
        ss020.codigo = "05" & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_
        ss020.nombre = "Cuentas Bancarias..."
        ss020.tipo = sMenu_
        ss020.descripcion = "Todas las operaciones de bancos"
        ss020.Add()

        ss020.ss010_codigo = "sigafyc"
        ss020.codigo = "06" & sSeparador_ & sCero3_ & sSeparador_ & sCero4_ & sSeparador_ & sCero5_
        ss020.nombre = "Cajas..."
        ss020.tipo = sMenu_
        ss020.descripcion = "Todas las operaciones movimientos de valores"
        ss020.Add()

        ss020.CerrarConexion()
        ss020 = Nothing
    End Sub

End Module
