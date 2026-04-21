Imports AgSTG
Imports AgSTG.Core
Imports AgSTG.Controls
Imports ResourcePack.TH07
Class MainWindow
    Public FullScreen As Boolean
    Public WithEvents Timer1 As MediaTimer
    Public Ticks As Long
    Public GP As GamePage
    Public PP As PausePage
    Public TP As TitlePage
    Public CP As ClearPage
    Public FP As FailPage
    Private SW_FPS As New Stopwatch
    Private BR_Load As New ImageBrush(New BitmapImage(New Uri(Environment.CurrentDirectory + "\loadpage.png")))
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
        GameArea.Background = BR_Load
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
        STG.Stages.Add(New Stage1.Stage1(2))
        STG.Stages.Add(New Stage2.Stage2(2))
        STG.Stages.Add(New Stage3.Stage3(2))
        STG.Stages.Add(New Stage4.Stage4(2))
        STG.Stages.Add(New Stage5.Stage5(2))
        STG.Stages.Add(New Stage6.Stage6(2))
        TP = New TitlePage
        TP.MW = Me
        GameArea.Children.Add(TP.Page)
        Timer1 = New MediaTimer(60)
        Timer1.Start()
        PP = New PausePage
        GameArea.Children.Add(PP.Page)
        CP = New ClearPage
        FP = New FailPage
        GameArea.Children.Add(CP.Page)
        GameArea.Children.Add(FP.Page)
        PP.Page.Visibility = Visibility.Hidden
        CP.Page.Visibility = Visibility.Hidden
        FP.Page.Visibility = Visibility.Hidden
        TP.Page.Timer = Timer1
        PP.Page.Timer = Timer1
        GP.Timer = Timer1
        CP.Page.Timer = Timer1
        FP.Page.Timer = Timer1
        PP.MW = Me
        CP.MW = Me
        FP.MW = Me
        TP.Page.Activated = True
        GP.SetBackground(Textures.game_background)
        GP.Visibility = Visibility.Hidden
        GP.Act = AddressOf GamePage_Action
        Timer1.Act.Add(AddressOf FpsUpdate)
        Timer1.Act.Add(AddressOf KeyUpdate)
        Timer1.Act.Add(AddressOf ReleaseSounds)
        AddHandler STG.GameClear, AddressOf GameClear
        AddHandler STG.GameOver, AddressOf GameOver
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
            Case Key.LeftCtrl
                If STG.ReplayMode AndAlso GP.Activated Then
                    Timer1.TPS = 240
                End If
        End Select
    End Sub

    Private Sub Window_KeyUp(sender As Object, e As KeyEventArgs)
        Select Case e.Key
            Case Key.Escape
                KeyState.Escape = False
                Exit Select
            Case Key.LeftCtrl
                Timer1.TPS = 60
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
        Static interval As Long
        If Ticks Mod 120 = 0 Then
            Dim fps As Double = 1200000000 / SW_FPS.ElapsedTicks
            SW_FPS.Stop()
            interval = SW_FPS.ElapsedTicks
            Dispatcher.Invoke(Sub()
                                  If STG.ReplayMode Then
                                      LB_FPS.Content = "回放模式，机师：" + STG.PlayerName + " 长按Ctrl可快进。  " + fps.ToString("F2") + " fps"
                                  Else
                                      LB_FPS.Content = fps.ToString("F2") + " fps"
                                  End If
                              End Sub)
            SW_FPS.Restart()
        End If
        Ticks += 1
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
    Private Sub ReleaseSounds()
        If Ticks Mod 2 = 0 Then
            ResourcePack.Sounds.Sounds_Playing.Clear()
        End If

    End Sub
    Private Sub GameClear()
        If STG.ReplayMode Then
            GP.Activated = False
            TP.Page.Activated = True
            TP.Page.Visibility = Visibility.Visible
            GP.Visibility = Visibility.Hidden
            ManagedBass.Bass.ChannelPause(STG.CurrentMusic)
        Else
            GP.Activated = False
            CP.Page.Activated = True
            CP.Page.Visibility = Visibility.Visible
            STG.Blur.Radius = 5
        End If

    End Sub
    Private Sub GameOver()
        If STG.ReplayMode Then
            GP.Activated = False
            TP.Page.Activated = True
            TP.Page.Visibility = Visibility.Visible
            GP.Visibility = Visibility.Hidden
            ManagedBass.Bass.ChannelPause(STG.CurrentMusic)
        Else
            GP.Activated = False
            FP.Page.Activated = True
            FP.Page.Visibility = Visibility.Visible
            STG.Blur.Radius = 5
        End If

    End Sub
End Class
