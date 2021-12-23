Public Class frmMBalances
    Private miCodEmpresa As Integer
    Private miCodSucursal As Integer
    Private msFecha As String
    Private msNivel As String

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
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

    Public Property nivel As String
        Get
            Return msNivel
        End Get
        Set(value As String)
            msNivel = value
        End Set
    End Property

    Private Sub btnCuadroPatrimonial_Click(sender As Object, e As EventArgs) Handles btnCuadroPatrimonial.Click
        GRCuadroPatrimonial(miCodEmpresa, miCodSucursal, msFecha, msNivel)
    End Sub

    Private Sub btnCuadroResultado_Click(sender As Object, e As EventArgs) Handles btnCuadroResultado.Click
        GRCuadroResultado(miCodEmpresa, miCodSucursal, msFecha, msNivel)
    End Sub

    Private Sub btnBalance8Columnas_Click(sender As Object, e As EventArgs) Handles btnBalance8Columnas.Click
        GRBalance8Columnas(miCodEmpresa, miCodSucursal, msFecha)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()

    End Sub
End Class