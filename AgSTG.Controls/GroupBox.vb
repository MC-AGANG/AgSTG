Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports AgSTG.Core
Public Class GroupBox
    Inherits Control
    Public WithEvents Buttons As New ObservableCollection(Of Button)
    Public SelectedIndex As Integer = 0
    Public Overrides Sub Render()
        Static switchcd As Integer = 0
        If KeyState.Down Then
            If switchcd = 0 Then
                SelectedIndex += 1
                If SelectedIndex >= Buttons.Count Then SelectedIndex = 0
                Buttons(SelectedIndex).Selected = True
                switchcd = 10
            End If
        ElseIf KeyState.Up Then
            If switchcd = 0 Then
                SelectedIndex -= 1
                If SelectedIndex < 0 Then SelectedIndex = Buttons.Count - 1
                Buttons(SelectedIndex).Selected = True
                switchcd = 10
            End If
        End If
        If switchcd > 0 Then
            switchcd -= 1
        End If
        If Buttons.Count > 0 Then
            Buttons(SelectedIndex).Render()
        End If
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
                SelectedIndex = 0
            Next
        ElseIf e.Action = NotifyCollectionChangedAction.Remove Then
            For Each btn As Button In e.OldItems
                GD_Main.Children.Remove(btn)
                SelectedIndex = 0
            Next
        End If
    End Sub
End Class
