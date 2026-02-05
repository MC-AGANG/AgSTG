Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Public Class GroupBox
    Inherits Control
    Public WithEvents Buttons As New ObservableCollection(Of Button)
    Public Overrides Sub Render()

    End Sub
    Public Overrides Sub Initialize()
        AddHandler Buttons.CollectionChanged, AddressOf Update
    End Sub
    Public Sub New(Width As Double, Height As Double)
        MyBase.New(Width, Height)
    End Sub
    Private Sub Update(sender As Object, e As NotifyCollectionChangedEventArgs)
        If e.Action = NotifyCollectionChangedAction.Add Then
            For Each btn As Button In e.NewItems
                GD_Main.Children.Add(btn)
            Next
        End If
    End Sub
End Class
