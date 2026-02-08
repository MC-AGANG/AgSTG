Imports AgSTG
Imports AgSTG.Core
Imports AgSTG.Controls
Imports ResourcePack.TH17
Class MainWindow
    Public FullScreen As Boolean
    Public WithEvents Timer1 As MediaTimer
    Public Ticks As Long
    Public GP As GamePage
    Public PP As PausePage

    Private Sub Window_SizeChanged(sender As Object, e As SizeChangedEventArgs)
        If FillArea.ActualHeight / 3 > FillArea.ActualWidth / 4 Then
            me_scale.ScaleX = FillArea.ActualWidth / 640
            me_scale.ScaleY = FillArea.ActualWidth / 640
        Else
            me_scale.ScaleX = FillArea.ActualHeight / 480
            me_scale.ScaleY = FillArea.ActualHeight / 480
        End If
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        ResourcePack.Textures.Load()
        ResourcePack.Sounds.Load()
        Textures.Load()
        Sounds.Load()
        Texts.Load()
        If FullScreen Then
            Height += 480 - FillArea.ActualHeight
            Width += 640 - FillArea.ActualWidth
            MinHeight = Height
            MinWidth = Width
            WindowStyle = WindowStyle.None
            WindowState = WindowState.Maximized
        Else
            Height += 480 - FillArea.ActualHeight
            Width += 640 - FillArea.ActualWidth
            MinHeight = Height
            MinWidth = Width
        End If
        GameArea.Height = 480
        GameArea.Width = 640
        GP = New GamePage
        GameArea.Children.Add(GP)
        STG.stages.add(New Stage6.Stage6(2))
        Timer1 = New MediaTimer(60)
        Timer1.Start()
        PP = New PausePage
        GameArea.Children.Add(PP.Page)
        PP.Page.Visibility = Visibility.Hidden
        PP.Page.Timer = Timer1
        GP.Timer = Timer1
        PP.MW = Me
        GP.Activated = True
        GP.SetBackground(Textures.game_background)
        STG.NextStage()

    End Sub
    Private Sub Window_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.Key
            Case Key.Escape
                If GP.Activated Then
                    GP.Activated = False
                    PP.Page.Activated = True
                    PP.Page.Visibility = Visibility.Visible
                ElseIf PP.Page.Activated Then
                    PP.Page.Activated = False
                    GP.Activated = True
                    PP.Page.Visibility = Visibility.Hidden
                End If
                Exit Select
            Case Key.F11
                If WindowStyle = WindowStyle.None Then
                    WindowStyle = WindowStyle.SingleBorderWindow
                    WindowState = WindowState.Normal
                    Height = MinHeight
                    Width = MinWidth
                Else
                    WindowStyle = WindowStyle.None
                    WindowState = WindowState.Maximized
                End If
                Exit Select
            Case Key.Up
                KeyState.Up = True
                Exit Select
            Case Key.Down
                KeyState.Down = True
                Exit Select
            Case Key.Left
                KeyState.Left = True
                Exit Select
            Case Key.Right
                KeyState.Right = True
                Exit Select
            Case Key.LeftShift
                KeyState.Slow = True
                Exit Select
            Case Key.Z
                KeyState.Shoot = True
                Exit Select
            Case Key.X
                KeyState.Bomb = True
                Exit Select
        End Select
    End Sub

    Private Sub Window_KeyUp(sender As Object, e As KeyEventArgs)
        If Not STG.ReplayMode Then
            Select Case e.Key
                Case Key.Up
                    KeyState.Up = False
                    Exit Select
                Case Key.Down
                    KeyState.Down = False
                    Exit Select
                Case Key.Left
                    KeyState.Left = False
                    Exit Select
                Case Key.Right
                    KeyState.Right = False
                    Exit Select
                Case Key.LeftShift
                    KeyState.Slow = False
                    Exit Select
                Case Key.Z
                    KeyState.Shoot = False
                    Exit Select
                Case Key.X
                    KeyState.Bomb = False
                    Exit Select
            End Select
        End If
    End Sub
End Class
