Imports AgSTG
Imports AgSTG.Controls
Imports AgSTG.Core
Imports ResourcePack.TH17
Public Class TitlePage
    Public WithEvents Page As New Page
    Private RC_Title As New Rectangle
    Private RC_Character As New Rectangle
    Private Group As New GroupBox(430, 256, 160, 96)
    Private WithEvents BT_Start As New Button(0, 0, 160, 24)
    Private WithEvents BT_Replay As New Button(0, 24, 160, 24)
    Private WithEvents BT_Quit As New Button(0, 48, 160, 24)
    Public MW As MainWindow
    Public Sub Initialize()
        RC_Title.Fill = Textures.title_logo
        RC_Character.Fill = Textures.title_ch
        Page.Background = Textures.title_bk
        BT_Start.ForeLayer.Fill = Textures.bt_start(0)
        BT_Start.BackLayer.Fill = Textures.bt_start(1)
        BT_Replay.ForeLayer.Fill = Textures.bt_replay(0)
        BT_Replay.BackLayer.Fill = Textures.bt_replay(1)
        BT_Quit.ForeLayer.Fill = Textures.bt_quit(0)
        BT_Quit.BackLayer.Fill = Textures.bt_quit(1)
        Page.CV_Main.Children.Add(RC_Character)
        RC_Character.Width = 640
        RC_Character.Height = 480
        RC_Character.Opacity = 0
        Canvas.SetLeft(RC_Character, 200)
        Page.CV_Main.Children.Add(RC_Title)
        RC_Title.Width = 240
        RC_Title.Height = 200
        RC_Title.Opacity = 0
        Canvas.SetLeft(RC_Title, 360)
        Canvas.SetTop(RC_Title, 32)
        Page.Controls.Add(Group)
        Group.Buttons.Add(BT_Start)
        Group.Buttons.Add(BT_Replay)
        Group.Buttons.Add(BT_Quit)
        Group.Opacity = 0
        Page.Act = AddressOf Action
    End Sub
    Public Sub New()
        MyBase.New()
        Initialize()
    End Sub

    Private Sub BT_Start_Clicked() Handles BT_Start.Clicked
        Page.Activated = False
        MW.GP.Activated = True
        Page.Visibility = Visibility.Hidden
        MW.GP.Visibility = Visibility.Visible
        STG.NextStage()
    End Sub
    Private Sub BT_Quit_Clicked() Handles BT_Quit.Clicked
        MW.Timer1.Stop()
        MW.Close()
    End Sub

    Public Sub Page_ActivatedChanged(Activated As Boolean) Handles Page.ActivatedChanged
        If Activated Then
            Sounds.PlaySound(Sounds.mu01)
        Else
            Sounds.mu01.Stop()
        End If
    End Sub
    Private Sub Action()
        Static Tick = 0
        If Tick <= 150 Then
            If Tick < 50 Then
                Canvas.SetLeft(RC_Character, (49 - Tick) * 4)
                RC_Character.Opacity = Tick / 50
            ElseIf Tick < 100 Then
                RC_Title.Opacity = (Tick - 50) / 50
            ElseIf Tick < 150 Then
                Group.Opacity = (Tick - 100) / 50
            End If
            Tick += 1
        End If

    End Sub
End Class
