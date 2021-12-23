Imports System.Data.Common

Public Class Eb050plancuentas : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "b050plancuentas"

    Private msRequeridos As String = "codempresa" & sInteger_ & sSF_ &
                                       "codcuenta" & sString_ & sSF_ &
                                       "nombre" & sString_ & sSF_ &
                                       "tipo" & sString_ & sSF_ &
                                       "nivel" & sString_

    Private msCampos_PK() As Integer = {0, 1}
#End Region

#Region "Campos requeridos"
    Private miCodEmpresa As Integer
    Private msCodCuenta As String
    Private msNombre As String
    Private msTipo As String
    Private msNivel As String
#End Region

    Public Property codEmpresa As Integer
        Get
            Return miCodEmpresa
        End Get
        Set(value As Integer)
            miCodEmpresa = value
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

    Public Property nombre As String
        Get
            Return msNombre
        End Get
        Set(value As String)
            msNombre = value
        End Set
    End Property

    Public Property tipo As String
        Get
            Return msTipo
        End Get
        Set(value As String)
            msTipo = value
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

    Public Sub New()
        MyBase.New()
        SetParametros(msRama, msTableName, msRequeridos, msCampos_PK, Me)
        Conectar(msTableName)
    End Sub

    Public Sub CerrarConexion()
        Desconectar(msTableName)
    End Sub

    Protected Overloads Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
