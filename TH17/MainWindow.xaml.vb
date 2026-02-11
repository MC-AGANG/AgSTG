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
    Private SW_FPS As New Stopwatch
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
        STG.Stages.Add(New Stage6.Stage6(2))
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
        GP.Act = AddressOf GamePage_Action
        Timer1.Act.Add(AddressOf FpsUpdate)
        Timer1.Act.Add(AddressOf KeyUpdate)
    End Sub
    Private Sub Window_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.Key
            Case Key.Escape
                KeyState.Escape = True
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
        End Select
    End Sub

    Private Sub Window_KeyUp(sender As Object, e As KeyEventArgs)
        Select Case e.Key
            Case Key.Escape
                KeyState.Escape = False
                Exit Select
        End Select
    End Sub
    Private Sub GamePage_Action()
        Static pausecd As Integer = 10
        If pausecd = 0 Then
            If KeyState.Escape AndAlso GP.Activated Then
                GP.Activated = False
                PP.Page.Activated = True
                PP.Page.Visibility = Visibility.Visible
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.pause)
                pausecd = 10
                STG.Blur.Radius = 5
            End If
        Else
            pausecd -= 1
        End If

    End Sub
    Private Sub FpsUpdate()
        Static tick As Integer = 0
        Static interval As Long
        If tick = 120 Then
            Dim fps As Double = 1200000000 / SW_FPS.ElapsedTicks
            SW_FPS.Stop()
            interval = SW_FPS.ElapsedTicks
            Dispatcher.Invoke(Sub()
                                  LB_FPS.Content = fps.ToString("F2") + " fps"
                              End Sub)
            SW_FPS.Restart()
            tick = 0
        Else
            tick += 1
        End If
    End Sub
    Private Sub KeyUpdate()
        Dispatcher.Invoke(Sub()
                              KeyState.Up = Keyboard.IsKeyDown(Key.Up)
                              KeyState.Down = Keyboard.IsKeyDown(Key.Down)
                              KeyState.Left = Keyboard.IsKeyDown(Key.Left)
                              KeyState.Right = Keyboard.IsKeyDown(Key.Right)
                              KeyState.Slow = Keyboard.IsKeyDown(Key.LeftShift)
                              KeyState.Shoot = Keyboard.IsKeyDown(Key.Z)
                              KeyState.Bomb = Keyboard.IsKeyDown(Key.X)
                          End Sub)

    End Sub
End Class
