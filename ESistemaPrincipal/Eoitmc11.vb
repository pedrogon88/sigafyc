Imports System.Data.Common

Public Class Eoitmc11 : Inherits RBase

#Region "Campos de control"
    Private msRama As String = sRegistryTablasPrincipal_
    Private msTableName As String = "oitmc11"

    Private msRequeridos As String = "itemcode" & sString_ & sSF_ &
                                       "cardcode" & sString_ & sSF_ &
                                       "fechahora" & sString_ & sSF_ &
                                       "comentario" & sString_

    Private msCampos_PK() As Integer = {0, 1, 2}
#End Region

#Region "Campos requeridos"
    Private msItemCode As String
    Private msCardCode As String
    Private msFechaHora As String
    Private msComentario As String
#End Region

    Public Property ItemCode As String
        Get
            Return msItemCode
        End Get
        Set(value As String)
            msItemCode = value
        End Set
    End Property

    Public Property CardCode As String
        Get
            Return msCardCode
        End Get
        Set(value As String)
            msCardCode = value
        End Set
    End Property

    Public Property FechaHora As String
        Get
            Return msFechaHora
        End Get
        Set(value As String)
            msFechaHora = value
        End Set
    End Property

    Public Property Comentario As String
        Get
            Return msComentario
        End Get
        Set(value As String)
            msComentario = value
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
