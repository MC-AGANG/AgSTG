Imports AgSTG.Core
Public Class Page
    Public Timer As MediaTimer
    Public Property Activated As Boolean
        Get
            Return _Activated
        End Get
        Set(value As Boolean)
            _Activated = value
            If Activated Then
                Timer.Act = AddressOf Render
            Else
                Timer.Act = Nothing
            End If
        End Set
    End Property
    Private _Activated As Boolean
    Public Ticks As Long = 0
    Public Act As Action = Nothing
    Public Children As New List(Of Control)
    Public Sub Render()
        Ticks += 1
        Dispatcher.Invoke(Sub()
                              If Not IsNothing(Act) Then
                                  Act()
                              End If
                              For Each c In Children
                                  c.Render()
                              Next
                          End Sub)
    End Sub
    Public Sub Add(obj As Control)
        Children.Add(obj)
        CV_Main.Children.Add(obj)
    End Sub
    Public Sub Remove(obj As Control)
        Children.Remove(obj)
        CV_Main.Children.Remove(obj)
    End Sub
End Class
