Imports AgSTG
Imports AgSTG.Core
Imports AgSTG.Controls
Imports ResourcePack.TH07
Class MainWindow
    Public FullScreen As Boolean
    Public WithEvents Timer1 As MediaTimer
    Public Ticks As Long
    Public GP As GamePage
    Public SP As SelectionPage
    Public PP As PausePage
    Public TP As TitlePage
    Public CP As ClearPage
    Public FP As FailPage
    Public OP As OptionPage

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
        Settings.ReadKeys()
        If Settings.ReadWindowState = "FullScreen" Then
            WindowStyle = WindowStyle.None
            WindowState = WindowState.Maximized
        End If
        Settings.ReadVolume()
    End Sub
    Public Sub Start()
        Timer1 = New MediaTimer(60)
        InitializePages()
        Timer1.Act.Add(AddressOf FpsUpdate)
        Timer1.Act.Add(AddressOf KeyUpdate)
        Timer1.Act.Add(AddressOf ReleaseSounds)
        Timer1.Start()
        AddHandler STG.GameClear, AddressOf GameClear
        AddHandler STG.GameOver, AddressOf GameOver
    End Sub

    Private Sub InitializePages()
        '标题
        TP = New TitlePage
        TP.MW = Me
        TP.Page.Timer = Timer1
        TP.Page.Activated = True
        GameArea.Children.Add(TP.Page)
        '游戏
        GP = New GamePage
        GameArea.Children.Add(GP)
        GP.Timer = Timer1
        GP.SetBackground(Textures.game_background)
        GP.Visibility = Visibility.Hidden
        GP.Act = AddressOf GamePage_Action
        '暂停
        PP = New PausePage
        GameArea.Children.Add(PP.Page)
        PP.Page.Visibility = Visibility.Hidden
        PP.Page.Timer = Timer1
        PP.MW = Me
        '通关
        CP = New ClearPage
        GameArea.Children.Add(CP.Page)
        CP.Page.Visibility = Visibility.Hidden
        CP.Page.Timer = Timer1
        CP.MW = Me
        '失败
        FP = New FailPage
        GameArea.Children.Add(FP.Page)
        FP.Page.Visibility = Visibility.Hidden
        FP.Page.Timer = Timer1
        FP.MW = Me
        '选择
        SP = New SelectionPage
        SP.MW = Me
        GameArea.Children.Add(SP.Page)
        SP.Page.Timer = Timer1
        SP.Page.Visibility = Visibility.Hidden
        '设置
        OP = New OptionPage
        OP.MW = Me
        GameArea.Children.Add(OP.Page)
        OP.Page.Timer = Timer1
        OP.Page.Visibility = Visibility.Hidden
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
                    If WindowState = WindowState.Maximized Then
                        WindowState = WindowState.Normal
                    End If
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
                              If IsActive Then
                                  KeyState.Up = Keyboard.IsKeyDown(Settings.Key_Up)
                                  KeyState.Down = Keyboard.IsKeyDown(Settings.Key_Down)
                                  KeyState.Left = Keyboard.IsKeyDown(Settings.Key_Left)
                                  KeyState.Right = Keyboard.IsKeyDown(Settings.Key_Right)
                                  KeyState.Slow = Keyboard.IsKeyDown(Settings.Key_Slow)
                                  KeyState.Shoot = Keyboard.IsKeyDown(Settings.Key_Shoot)
                                  KeyState.Bomb = Keyboard.IsKeyDown(Settings.Key_Bomb)
                              End If
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
            ManagedBass.Bass.ChannelPause(ResourcePack.Sounds.CurrentMusic)
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
            ManagedBass.Bass.ChannelPause(ResourcePack.Sounds.CurrentMusic)
        Else
            GP.Activated = False
            FP.Page.Activated = True
            FP.Page.Visibility = Visibility.Visible
            STG.Blur.Radius = 5
        End If

    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        Application.Current.Shutdown()
    End Sub
End Class

Public Class Settings
    Public Shared Key_Up As Integer = 24
    Public Shared Key_Down As Integer = 26
    Public Shared Key_Left As Integer = 23
    Public Shared Key_Right As Integer = 25
    Public Shared Key_Shoot As Integer = 69
    Public Shared Key_Bomb As Integer = 67
    Public Shared Key_Slow As Integer = 116

    Public Shared Sub ReadKeys()
        Key_Up = IniTool.ReadValue("TH07APRIL", "Key_Up", "24", Environment.CurrentDirectory + "\Settings.ini")
        Key_Down = IniTool.ReadValue("TH07APRIL", "Key_Down", "26", Environment.CurrentDirectory + "\Settings.ini")
        Key_Left = IniTool.ReadValue("TH07APRIL", "Key_Left", "23", Environment.CurrentDirectory + "\Settings.ini")
        Key_Right = IniTool.ReadValue("TH07APRIL", "Key_Right", "25", Environment.CurrentDirectory + "\Settings.ini")
        Key_Shoot = IniTool.ReadValue("TH07APRIL", "Key_Shoot", "69", Environment.CurrentDirectory + "\Settings.ini")
        Key_Bomb = IniTool.ReadValue("TH07APRIL", "Key_Bomb", "67", Environment.CurrentDirectory + "\Settings.ini")
        Key_Slow = IniTool.ReadValue("TH07APRIL", "Key_Slow", "116", Environment.CurrentDirectory + "\Settings.ini")
    End Sub

    Public Shared Function ReadWindowState() As String
        Return IniTool.ReadValue("TH07APRIL", "WindowState", "Windowed", Environment.CurrentDirectory + "\Settings.ini")
    End Function

    Public Shared Sub ReadVolume()
        ResourcePack.Sounds.EffectVolume = IniTool.ReadValue("TH07APRIL", "EffectVolume", "100", Environment.CurrentDirectory + "\Settings.ini")
        ResourcePack.Sounds.MusicVolume = IniTool.ReadValue("TH07APRIL", "MusicVolume", "100", Environment.CurrentDirectory + "\Settings.ini")
    End Sub

    Public Shared Sub WriteKeys()
        IniTool.WriteValue("TH07APRIL", "Key_Up", Key_Up, Environment.CurrentDirectory + "\Settings.ini")
        IniTool.WriteValue("TH07APRIL", "Key_Down", Key_Down, Environment.CurrentDirectory + "\Settings.ini")
        IniTool.WriteValue("TH07APRIL", "Key_Left", Key_Left, Environment.CurrentDirectory + "\Settings.ini")
        IniTool.WriteValue("TH07APRIL", "Key_Right", Key_Right, Environment.CurrentDirectory + "\Settings.ini")
        IniTool.WriteValue("TH07APRIL", "Key_Shoot", Key_Shoot, Environment.CurrentDirectory + "\Settings.ini")
        IniTool.WriteValue("TH07APRIL", "Key_Bomb", Key_Bomb, Environment.CurrentDirectory + "\Settings.ini")
        IniTool.WriteValue("TH07APRIL", "Key_Slow", Key_Slow, Environment.CurrentDirectory + "\Settings.ini")
    End Sub

    Public Shared Sub WriteWindowStage(FullScreen As Boolean)
        If FullScreen Then
            IniTool.WriteValue("TH07APRIL", "WindowState", "FullScreen", Environment.CurrentDirectory + "\Settings.ini")
        Else
            IniTool.WriteValue("TH07APRIL", "WindowState", "Windowed", Environment.CurrentDirectory + "\Settings.ini")
        End If
    End Sub

    Public Shared Sub WriteVolume()
        IniTool.WriteValue("TH07APRIL", "EffectVolume", ResourcePack.Sounds.EffectVolume, Environment.CurrentDirectory + "\Settings.ini")
        IniTool.WriteValue("TH07APRIL", "MusicVolume", ResourcePack.Sounds.MusicVolume, Environment.CurrentDirectory + "\Settings.ini")
    End Sub
End Class