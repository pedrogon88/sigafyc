Public Class Dd010asientosdetalles
#Region "Campos requeridos"
    Private miCodEmpresa As Integer
    Private msEjercicio As String
    Private miNroAsiento As Integer
    Private miNroSecuencia As Integer
    Private msCodCuenta As String
    Private msTipoMovimiento As String
    Private mdImporte_mo As Decimal
    Private mdImporte_mb As Decimal
    Private miCodConcepto As Integer
    Private msConcepto As String
#End Region

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
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

    Public Property nroSecuencia As Integer
        Get
            Return miNroSecuencia
        End Get
        Set(value As Integer)
            miNroSecuencia = value
        End Set
    End Property

    Public Property codCuenta As String
        Get
            Return msCodCuenta
        End Get
        Set(value As String)
            msCodCuenta = value
        End Set
    End Property

    Public Property tipoMovimiento As String
        Get
            Return msTipoMovimiento
        End Get
        Set(value As String)
            msTipoMovimiento = value
        End Set
    End Property

    Public Property importe_mo As Decimal
        Get
            Return mdImporte_mo
        End Get
        Set(value As Decimal)
            mdImporte_mo = value
        End Set
    End Property

    Public Property importe_mb As Decimal
        Get
            Return mdImporte_mb
        End Get
        Set(value As Decimal)
            mdImporte_mb = value
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

End Class
