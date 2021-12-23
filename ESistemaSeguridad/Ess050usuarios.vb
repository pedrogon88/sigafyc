Public Class Ess050usuarios : Inherits RBase
#Region "Campos de control"
    Private msRama As String = sRegistryTablasSeguridad_
    Private msTableName As String = "ss050usuarios"

    Private msRequeridos As String = "codigo" & sString_ & sSF_ &
                                        "nombre" & sString_ & sSF_ &
                                        "login" & sString_ & sSF_ &
                                        "password" & sString_ & sSF_ &
                                        "ss060_codigo" & sString_ & sSF_ &
                                        "valido" & sString_ & sSF_ &
                                        "expira" & sString_
    Private msCampos_PK() As Integer = {0}
#End Region

#Region "Campos requeridos"
    Private msCodigo As String
    Private msNombre As String
    Private msLogin As String
    Private msPassword As String
    Private msSS060_codigo As String
    Private msValido As String
    Private msExpira As String
    Private msLoginSesion As String
    Private msMacSesion As String
    Private msIpSesion As String
#End Region

    Public Property codigo As String
        Get
            Return msCodigo
        End Get
        Set(value As String)
            msCodigo = value
        End Set
    End Property

    Public Property nombre As String
        Get
            Return msNombre
        End Get
        Set(value As String)
            msNombre = value
        End Set
    End Property

    Public Property login As String
        Get
            Return msLogin
        End Get
        Set(value As String)
            msLogin = value
        End Set
    End Property

    Public Property password As String
        Get
            Return msPassword
        End Get
        Set(value As String)
            msPassword = value
        End Set
    End Property

    Public Property ss060_codigo As String
        Get
            Return msSS060_codigo
        End Get
        Set(value As String)
            msSS060_codigo = value
        End Set
    End Property

    Public Property valido As String
        Get
            Return msValido
        End Get
        Set(value As String)
            msValido = value
        End Set
    End Property

    Public Property expira As String
        Get
            Return msExpira
        End Get
        Set(value As String)
            msExpira = value
        End Set
    End Property

    Public Property loginSesion As String
        Get
            Return msLoginSesion
        End Get
        Set(value As String)
            msLoginSesion = value
        End Set
    End Property

    Public Property macSesion As String
        Get
            Return msMacSesion
        End Get
        Set(value As String)
            msMacSesion = value
        End Set
    End Property

    Public Property ipSesion As String
        Get
            Return msIpSesion
        End Get
        Set(value As String)
            msIpSesion = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()

        Call SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Sub CerrarConexion()
        Desconectar(msTableName)
    End Sub

    Public Overloads Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Function CantidadEquivocacionPassword() As Integer
        Dim lsClave As String = "Cantidad equivocaciones password - " & Today.ToString("yyyy-MM")
        Dim lsResultado As String = "0"
        lsResultado = GFsParametroObtener(sUsuario_, lsClave, sNo_)
        If lsResultado = sRESERVADO_ Then
            lsResultado = "0"
            GPParametroGuardar(sUsuario_, lsClave, lsResultado, sNo_)
        Else
            If Not IsNumeric(lsResultado) Then
                lsResultado = "0"
                GPParametroGuardar(sUsuario_, lsClave, lsResultado, sNo_)
            End If
        End If

        Return Integer.Parse(lsResultado)
    End Function

    Public Function MaxCantidadEquivocacionPassword() As Integer
        Dim lsClave As String = "Maxima cantidad equivocaciones password"
        Dim lsResultado As String = ""
        lsResultado = GFsParametroObtener(sUsuario_, lsClave)
        If lsResultado = sRESERVADO_ Then
            lsResultado = "5"
            GPParametroGuardar(sUsuario_, lsClave, lsResultado)
        Else
            If Not IsNumeric(lsResultado) Then
                lsResultado = "5"
                GPParametroGuardar(sUsuario_, lsClave, lsResultado)
            End If
        End If
        Return Integer.Parse(lsResultado)
    End Function

    Public Sub SaveCantidadEquivocacionPassword(ByVal psCantidad As String)
        Dim lsClave As String = "Cantidad equivocaciones password - " & Today.ToString("yyyy-MM")
        Dim lsResultado As String = "0"
        GPParametroGuardar(sUsuario_, lsClave, psCantidad, sNo_)
    End Sub

    Public Sub Bloquear(Optional ByVal psAccion As String = "")
        estado = sBloqueado_
        Put(sNo_)
        If psAccion.Trim.Length > 0 Then
            GPBitacoraRegistrar(sBloqueado_, psAccion)
        End If
    End Sub

    Public Sub DesBloquear()
        estado = sActivo_
        Put(sNo_)
    End Sub

    Public Function PuedeUsar(ByVal psSS010_codigo As String, ByVal psCodigo As String, ByVal psNombre As String) As Boolean
        Dim lbResultado As Boolean = False
        If LFsVerificaRestriccion(psSS010_codigo, psCodigo, psNombre) = sBloqueado_ Then
            GFsAvisar("Codigo Restriccion: " & psCodigo, sMENSAJE_, "Se encuentra bloqueado para su uso, Consulte con el Dpto. Informatica")
            Return lbResultado
        End If

        If codigo.Trim.ToUpper = SesionActiva.datosControl(sManagerName_).ToString.Trim.ToUpper Then
            lbResultado = True
            Return lbResultado
        End If

        'Dim ss8 As New ss8PUSU

        'ss8.CODUSR = CODUSR
        'liPuedeusar = ss8.PuedeUsar(strCODSYS, strCODRES)
        'If Not (liPuedeusar = NoHayRegistros_) Then
        '    If liPuedeusar = Si_ Then
        '        PuedeUsar = Si_
        '    Else
        '        PuedeUsar = No_
        '    End If
        '    Exit Function
        'End If
        ''>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        'Dim ss4 As New ss4HABI

        'Dim lrs As New ADODB.Recordset

        'lrs.LockType = adLockOptimistic
        'lrs.CursorType = adOpenForwardOnly
        'lrs.ActiveConnection = gcSECURITY

        'lrs.Source = "select * " &
        '        "from " & msTABLE &
        '        "where CODUSR = '" & CODUSR & "'"

        'lrs.MaxRecords = 1
        'lrs.Open

        'If lrs.EOF = True And lrs.BOF = True Then
        '    GPMensaje "El usuario no esta habiltado para trabajar, consulte con el Administrador del Sistema."
        'PuedeUsar = No_
        '    Exit Function
        'End If

        'ss4.TIPCOD = Usuario_
        'ss4.CODIGO = CODUSR
        'ss4.CODSYS = strCODSYS
        'ss4.CODRES = UCase(GFvGetClave(Security_ & "_ManagerName_", General_))
        'ss4.GetPK
        'If ss4.ERROR = OK_ Then
        '    If ss4.PuedeUsar() = Si_ Then
        '        PuedeUsar = Si_
        '    Else
        '        PuedeUsar = No_
        '    End If
        '    Exit Function
        'End If

        'ss4.TIPCOD = Usuario_
        'ss4.CODIGO = CODUSR
        'ss4.CODSYS = strCODSYS
        'ss4.CODRES = strCODRES
        'ss4.GetPK
        'If ss4.ERROR = OK_ Then
        '    If ss4.PuedeUsar() = Si_ Then
        '        PuedeUsar = Si_
        '    Else
        '        PuedeUsar = No_
        '    End If
        'Else
        '    GPMensaje "Sistema/Restricción: " & strCODSYS & " / " & strCODRES & " no se encuentra habilitado para su uso."
        'PuedeUsar = No_
        'End If

        'Set ss4 = Nothing

        'lrs.Close
        'Set lrs = Nothing

        Return lbResultado
    End Function

    Private Function LFsVerificaRestriccion(ByVal psSS010_codigo As String, ByVal psCodigo As String, ByVal psNombre As String) As String
        Dim lsResultado As String
        Dim loDatos As New Ess080restricciones

        loDatos.ss010_codigo = psSS010_codigo
        loDatos.codigo = psCodigo
        If loDatos.GetPK = sSinRegistros_ Then
            loDatos.ss010_codigo = psSS010_codigo
            loDatos.codigo = psCodigo
            If psNombre.Trim.Length > 0 Then
                loDatos.nombre = psNombre
            Else
                loDatos.nombre = sAuto_ & "Restriccion: " & psCodigo & " descripcion no habilitado"
            End If
            loDatos.estado = sActivo_
            loDatos.Add(sNo_)
        End If
        lsResultado = loDatos.estado

        loDatos.CerrarConexion()
        loDatos = Nothing
        Return lsResultado
    End Function

End Class
