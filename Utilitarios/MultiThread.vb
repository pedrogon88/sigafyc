Imports System.Threading

Public Class MultiThread

    Shared moListThread As List(Of Thread) = Nothing

    Public Shared Property listThread As List(Of Thread)
        Get
            Return moListThread
        End Get
        Set(value As List(Of Thread))
            moListThread = value
        End Set
    End Property

    Public Shared Sub Agregar(ByRef poThread As Thread)
        If moListThread Is Nothing Then moListThread = New List(Of Thread)

        moListThread.Add(poThread)

        For liPos As Integer = 0 To moListThread.Count - 1
            If moListThread(liPos) IsNot Nothing Then
                Select Case moListThread(liPos).ThreadState
                    Case ThreadState.Unstarted
                        moListThread(liPos).Start()
                End Select
            End If
        Next
    End Sub

    Public Shared Function Cantidad(Optional psName As String = "") As Integer
        Dim liCount As Integer = 0
        If moListThread IsNot Nothing Then
            If psName.Trim.Length > 0 Then
                For liPos As Integer = 0 To moListThread.Count - 1
                    If moListThread(liPos) IsNot Nothing Then
                        If moListThread(liPos).Name.Length >= psName.Length Then
                            If moListThread(liPos).Name = psName Then
                                liCount += 1
                            Else
                                If moListThread(liPos).Name.Substring(0, psName.Length - 1) = psName Then
                                    liCount += 1
                                End If
                            End If
                        End If
                    End If
                Next
            Else
                liCount = moListThread.Count
            End If
        End If
        Return liCount
    End Function

    Public Shared Function Vivos(Optional psName As String = "") As Integer
        Dim liCount As Integer = 0
        If moListThread Is Nothing Then
            Return liCount
            Exit Function
        End If
        For lipos As Integer = 0 To moListThread.Count - 1
            If moListThread(lipos) IsNot Nothing Then
                If moListThread(lipos).ThreadState = ThreadState.Unstarted Then
                    moListThread(lipos).Start()
                End If
            End If
        Next
        For liPos As Integer = 0 To moListThread.Count - 1
            If moListThread(liPos) IsNot Nothing Then
                If moListThread(liPos).Name.Length >= psName.Length Then
                    If moListThread(liPos).Name = psName Then
                        If moListThread(liPos).IsAlive = True Then
                            liCount += 1
                        End If
                    Else
                        If moListThread(liPos).Name.Substring(0, psName.Length - 1) = psName Then
                            If moListThread(liPos).IsAlive = True Then
                                liCount += 1
                            End If
                        End If
                    End If
                End If
            End If
        Next
        Return liCount
    End Function

    Public Shared Function Culminados(Optional psName As String = "") As Integer
        Dim liCount As Integer = 0
        If moListThread Is Nothing Then
            Return liCount
            Exit Function
        End If
        For lipos As Integer = 0 To moListThread.Count - 1
            If moListThread(lipos) IsNot Nothing Then
                If moListThread(lipos).ThreadState = ThreadState.Unstarted Then
                    moListThread(lipos).Start()
                End If
            End If
        Next
        For liPos As Integer = 0 To moListThread.Count - 1
            If moListThread(liPos) IsNot Nothing Then
                If moListThread(liPos).Name.Length >= psName.Length Then
                    If moListThread(liPos).Name = psName Then
                        If moListThread(liPos).IsAlive = False Then
                            liCount += 1
                        End If
                    Else
                        If moListThread(liPos).Name.Substring(0, psName.Length) = psName Then
                            If moListThread(liPos).IsAlive = False Then
                                liCount += 1
                            End If
                        End If
                    End If
                End If
            End If
        Next
        Return liCount
    End Function

    Public Shared Sub AbortarTodo()
        For lipos As Integer = 0 To moListThread.Count - 1
            If moListThread(lipos) IsNot Nothing Then
                If moListThread(lipos).IsAlive = True Then
                    moListThread(lipos).Abort()
                End If
            End If
        Next
    End Sub

End Class
