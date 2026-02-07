Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
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
    Public WithEvents Controls As New ObservableCollection(Of Control)
    Public Overridable Sub Initialize()

    End Sub
    Public Overridable Sub Act()

    End Sub
    Public Sub Render()
        Ticks += 1
        Dispatcher.Invoke(Sub()
                              Act()

                              For Each c In Controls
                                  c.Render()
                              Next
                          End Sub)
    End Sub
    Private Sub Update(sender As Object, e As NotifyCollectionChangedEventArgs)
        If e.Action = NotifyCollectionChangedAction.Add Then
            For Each ctl As Button In e.NewItems
                CV_Main.Children.Add(ctl)
            Next
        ElseIf e.Action = NotifyCollectionChangedAction.Remove Then
            For Each ctl As Button In e.OldItems
                CV_Main.Children.Remove(ctl)
            Next
        End If
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        AddHandler Controls.CollectionChanged, AddressOf Update
        Initialize()
    End Sub
End Class
