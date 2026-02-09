Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports AgSTG.Core
Imports ResourcePack
''' <summary>
''' 表示组控件，可用于管理多个按钮。
''' </summary>
Public Class GroupBox
    Inherits Control
    ''' <summary>
    ''' 被添加到自动化管理的按钮。
    ''' </summary>
    Public WithEvents Buttons As New ObservableCollection(Of Button)
    ''' <summary>
    ''' 当前选中的按钮。
    ''' </summary>
    Public SelectedIndex As Integer = 0
    Public CV_Main As New Canvas
    ''' <summary>
    ''' 运行主循环。
    ''' </summary>
    Public Overrides Sub Render()
        Static switchcd As Integer = 0
        If KeyState.Down Then
            If switchcd = 0 Then
                Buttons(SelectedIndex).Selected = False
                SelectedIndex += 1
                If SelectedIndex >= Buttons.Count Then SelectedIndex = 0
                Buttons(SelectedIndex).Selected = True
                switchcd = 10
                Sounds.PlaySound(Sounds.select00)
            End If
        ElseIf KeyState.Up Then
            If switchcd = 0 Then
                Buttons(SelectedIndex).Selected = False
                SelectedIndex -= 1
                If SelectedIndex < 0 Then SelectedIndex = Buttons.Count - 1
                Buttons(SelectedIndex).Selected = True
                switchcd = 10
                Sounds.PlaySound(Sounds.select00)
            End If
        End If
        If switchcd > 0 Then
            switchcd -= 1
        End If
        If Buttons.Count > 0 Then
            Buttons(SelectedIndex).Render()
        End If
    End Sub
    ''' <summary>
    ''' 初始化组。
    ''' </summary>
    Public Overrides Sub Initialize()

        GD_Main.Children.Add(CV_Main)
    End Sub
    ''' <summary>
    ''' 创建新的组。
    ''' </summary>
    ''' <param name="Width">宽度</param>
    ''' <param name="Height">高度</param>
    Public Sub New(Width As Double, Height As Double)
        MyBase.New(Width, Height)
        AddHandler Buttons.CollectionChanged, AddressOf Update
    End Sub
    Public Sub New(X As Double, Y As Double, Width As Double, Height As Double)
        MyBase.New(X, Y, Width, Height)
        AddHandler Buttons.CollectionChanged, AddressOf Update
    End Sub
    Private Sub Update(sender As Object, e As NotifyCollectionChangedEventArgs)
        If e.Action = NotifyCollectionChangedAction.Add Then
            For Each btn As Button In e.NewItems
                CV_Main.Children.Add(btn)
                SelectedIndex = 0
            Next
            Buttons(0).Selected = True
        ElseIf e.Action = NotifyCollectionChangedAction.Remove Then
            For Each btn As Button In e.OldItems
                CV_Main.Children.Remove(btn)
                SelectedIndex = 0
            Next
            If Buttons.Count > 0 Then
                Buttons(0).Selected = True
            End If
        End If
    End Sub
End Class
