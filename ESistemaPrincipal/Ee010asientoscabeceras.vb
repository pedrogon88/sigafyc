Public Class Ee010asientoscabeceras : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "e010asientoscabeceras"

    Private msRequeridos As String = "codempresa" & sInteger_ & sSF_ &
                                       "ejercicio" & sString_ & sSF_ &
                                       "nroasiento" & sInteger_ & sSF_ &
                                       "codsucursal" & sInteger_ & sSF_ &
                                       "fecha" & sString_ & sSF_ &
                                       "coddocumento" & sInteger_ & sSF_ &
                                       "nrodocumento" & sString_ & sSF_ &
                                       "codmoneda_o" & sString_ & sSF_ &
                                       "codmoneda_b" & sString_ & sSF_ &
                                       "codconcepto" & sInteger_ & sSF_ &
                                       "concepto" & sString_ & sSF_ &
                                       "codempresa_v" & sInteger_ & sSF_ &
                                       "nroasiento_v" & sInteger_ & sSF_ &
                                       "cotizacion" & sString_ & sSF_ &
                                       "compra" & sInteger_ & sSF_ &
                                       "venta" & sInteger_ & sSF_ &
                                       "debito_o" & sDecimal_ & sSF_ &
                                       "credito_o" & sDecimal_ & sSF_ &
                                       "debito_b" & sDecimal_ & sSF_ &
                                       "credito_b" & sDecimal_

    Private msCampos_PK() As Integer = {0, 1, 2}
    Private msAutonumerado As String = "nroasiento"
    Private msFiltroClave As String = FiltroClave(msRequeridos, msCampos_PK, msAutonumerado)
#End Region

#Region "Campos requeridos"
    Private miCodEmpresa As Integer
    Private msEjercicio As String
    Private miNroAsiento As Integer
    Private miCodSucursal As Integer
    Private msFecha As String
    Private miCodDocumento As Integer
    Private msNroDocumento As String
    Private msCodMoneda_o As String
    Private msCodMoneda_b As String
    Private miCodConcepto As Integer
    Private msConcepto As String
    Private miCodEmpresa_v As Integer
    Private miNroAsiento_v As Integer
    Private msCotizacion As String
    Private miCompra As Integer
    Private miVenta As Integer
    Private mdDebito_o As Decimal
    Private mdCredito_o As Decimal
    Private mdDebito_b As Decimal
    Private mdCredito_b As Decimal

#End Region

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
            msEjercicio = GFsEjercicioContable(miCodEmpresa)
        End Set
    End Property

    Public Property ejercicio As String
        Get
            Return msEjercicio
        End Get
        Set(value As String)
            msEjercicio = value
        End Set
    End Property

    Public Property nroAsiento As Integer
        Get
            Return miNroAsiento
        End Get
        Set(value As Integer)
            miNroAsiento = value
        End Set
    End Property

    Public Property codSucursal As Integer
        Get
            Return miCodSucursal
        End Get
        Set(value As Integer)
            miCodSucursal = value
        End Set
    End Property

    Public Property fecha As String
        Get
            Return msFecha
        End Get
        Set(value As String)
            msFecha = value
        End Set
    End Property

    Public Property codDocumento As Integer
        Get
            Return miCodDocumento
        End Get
        Set(value As Integer)
            miCodDocumento = value
        End Set
    End Property

    Public Property nroDocumento As String
        Get
            Return msNroDocumento
        End Get
        Set(value As String)
            msNroDocumento = value
        End Set
    End Property

    Public Property codMoneda_o As String
        Get
            Return msCodMoneda_o
        End Get
        Set(value As String)
            msCodMoneda_o = value
        End Set
    End Property

    Public Property codMoneda_b As String
        Get
            Return msCodMoneda_b
        End Get
        Set(value As String)
            msCodMoneda_b = value
        End Set
    End Property
    Public Property codConcepto As Integer
        Get
            Return miCodConcepto
        End Get
        Set(value As Integer)
            miCodConcepto = value
        End Set
    End Property

    Public Property concepto As String
        Get
            Return msConcepto
        End Get
        Set(value As String)
            msConcepto = value
        End Set
    End Property

    Public Property codEmpresa_v As Integer
        Get
            Return miCodEmpresa_v
        End Get
        Set(value As Integer)
            miCodEmpresa_v = value
        End Set
    End Property

    Public Property nroAsiento_v As Integer
        Get
            Return miNroAsiento_v
        End Get
        Set(value As Integer)
            miNroAsiento_v = value
        End Set
    End Property

    Public Property cotizacion As String
        Get
            Return msCotizacion
        End Get
        Set(value As String)
            msCotizacion = value
        End Set
    End Property

    Public Property compra As Integer
        Get
            Return miCompra
        End Get
        Set(value As Integer)
            miCompra = value
        End Set
    End Property

    Public Property venta As Integer
        Get
            Return miVenta
        End Get
        Set(value As Integer)
            miVenta = value
        End Set
    End Property

    Public Property debito_o As Decimal
        Get
            Return mdDebito_o
        End Get
        Set(value As Decimal)
            mdDebito_o = value
        End Set
    End Property

    Public Property credito_o As Decimal
        Get
            Return mdCredito_o
        End Get
        Set(value As Decimal)
            mdCredito_o = value
        End Set
    End Property

    Public Property debito_b As Decimal
        Get
            Return mdDebito_b
        End Get
        Set(value As Decimal)
            mdDebito_b = value
        End Set
    End Property

    Public Property credito_b As Decimal
        Get
            Return mdCredito_b
        End Get
        Set(value As Decimal)
            mdCredito_b = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Function ReservarRegistro(ByVal piCodEmpresa As Integer) As Integer
        codEmpresa = piCodEmpresa
        Dim liNumero As Integer = SiguienteNumero(msAutonumerado, msTableName, msFiltroClave)
        codEmpresa = piCodEmpresa
        nroAsiento = liNumero
        codSucursal = 0
        fecha = sCero6_ & sCero4_
        codDocumento = 0
        nroDocumento = sRESERVADO_
        codMoneda_o = sCero3_
        codMoneda_b = sCero3_
        codConcepto = 0
        concepto = sRESERVADO_
        codEmpresa_v = 0
        nroAsiento_v = 0
        cotizacion = sCero6_
        compra = 0
        venta = 0
        debito_o = 0.00D
        credito_o = 0.00D
        debito_b = 0.00D
        credito_b = 0.00D
        Add(sNo_, sNo_)
        Return liNumero
    End Function

    Public Sub CerrarConexion()
        Desconectar(msTableName)
    End Sub

    Protected Overloads Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
