Imports AgSTG
Imports AgSTG.Core
Imports AgSTG.Controls
Imports ResourcePack.TH07

Public Class SelectionPage
    Public WithEvents Page As New Page
    Private GB_Difficulty As New GroupBox(192, 96, 256, 480)
    Private GB_Character As New GroupBox(0, 0, 640, 480)
    Private LB_Title As New Label(192, 16, 256, 64)
    Private WithEvents BT_Easy As New Button(0, 0, 256, 96)
    Private WithEvents BT_Normal As New Button(0, 96, 256, 96)
    Private WithEvents BT_Hard As New Button(0, 192, 256, 96)
    Private WithEvents BT_Lunatic As New Button(0, 288, 256, 96)
    Private WithEvents BT_Player0 As New Button(0, 0, 640, 480)
    Private WithEvents BT_Player1 As New Button(0, 0, 640, 480)
    Public MW As MainWindow
    Private difficulty As Difficulty
    Private State As Boolean = False
    Public Sub Initialize()
        Page.Background = Textures.select_background
        LB_Title.BackLayer.Fill = Textures.title_difficulty
        BT_Easy.ForeLayer.Fill = Textures.sl_easy
        BT_Easy.BackLayer.Fill = Textures.sl_easy_b
        BT_Normal.ForeLayer.Fill = Textures.sl_normal
        BT_Normal.BackLayer.Fill = Textures.sl_normal_b
        BT_Hard.ForeLayer.Fill = Textures.sl_hard
        BT_Hard.BackLayer.Fill = Textures.sl_hard_b
        BT_Lunatic.ForeLayer.Fill = Textures.sl_lunatic
        BT_Lunatic.BackLayer.Fill = Textures.sl_lunatic_b
        Page.Controls.Add(GB_Difficulty)
        Page.Controls.Add(LB_Title)
        GB_Difficulty.Buttons.Add(BT_Easy)
        GB_Difficulty.Buttons.Add(BT_Normal)
        GB_Difficulty.Buttons.Add(BT_Hard)
        GB_Difficulty.Buttons.Add(BT_Lunatic)

        BT_Player0.BackLayer.Fill = Textures.sl_pl0
        BT_Player1.BackLayer.Fill = Textures.sl_pl1
        GB_Character.Buttons.Add(BT_Player0)
        GB_Character.Buttons.Add(BT_Player1)
        GB_Character.IsEnabled = False
        GB_Character.Visibility = Visibility.Hidden
        Page.Controls.Add(GB_Character)
        BT_Player0.Visibility = Visibility.Visible
        BT_Player1.Visibility = Visibility.Hidden
        Page.Act = AddressOf Action
    End Sub

    Public Sub New()
        MyBase.New()
        Initialize()
    End Sub

    Private Sub BT_Easy_Clicked() Handles BT_Easy.Clicked
        SetDifficulty(Difficulty.Easy)
    End Sub

    Private Sub BT_Normal_Clicked() Handles BT_Normal.Clicked
        SetDifficulty(Difficulty.Normal)
    End Sub

    Private Sub BT_Hard_Clicked() Handles BT_Hard.Clicked
        SetDifficulty(Difficulty.Hard)
    End Sub

    Private Sub BT_Lunatic_Clicked() Handles BT_Lunatic.Clicked
        SetDifficulty(Difficulty.Lunatic)
    End Sub

    Private Sub BT_Player0_Clicked() Handles BT_Player0.Clicked
        STG.ReplayMode = False
        STG.Stages.Clear()
        'STG.Stages.Add(New Stage1.Stage1(difficulty))
        STG.Stages.Add(New Stage2.Stage2(difficulty))
        STG.Stages.Add(New Stage3.Stage3(difficulty))
        STG.Stages.Add(New Stage4.Stage4(difficulty))
        STG.Stages.Add(New Stage5.Stage5(difficulty))
        STG.Stages.Add(New Stage6.Stage6(difficulty))
        STG.Difficulty = difficulty
        STG.PlayerID = 0
        MW.GP.Activated = True
        Page.Visibility = Visibility.Hidden
        Page.Activated = False
        MW.GP.Visibility = Visibility.Visible
        STG.Reset()
        ManagedBass.Bass.ChannelStop(Sounds.mu01)
        MW.GP.PropertyBoard.SetDifficulty(difficulty)
        STG.Power = 400
        STG.Life = 6
    End Sub

    Private Sub BT_Player1_Clicked() Handles BT_Player1.Clicked
        STG.ReplayMode = False
        STG.Stages.Clear()
        'STG.Stages.Add(New Stage1.Stage1(difficulty))
        STG.Stages.Add(New Stage2.Stage2(difficulty))
        STG.Stages.Add(New Stage3.Stage3(difficulty))
        STG.Stages.Add(New Stage4.Stage4(difficulty))
        STG.Stages.Add(New Stage5.Stage5(difficulty))
        STG.Stages.Add(New Stage6.Stage6(difficulty))
        STG.Difficulty = difficulty
        STG.PlayerID = 1
        MW.GP.Activated = True
        Page.Visibility = Visibility.Hidden
        Page.Activated = False
        MW.GP.Visibility = Visibility.Visible
        STG.Reset()
        ManagedBass.Bass.ChannelStop(Sounds.mu01)
        MW.GP.PropertyBoard.SetDifficulty(difficulty)
    End Sub

    Private Sub BT_Player0_SelectionChanged(sender As Object, Selected As Boolean) Handles BT_Player0.SelectionChanged
        BT_Player0.Visibility = Visibility.Visible
        BT_Player1.Visibility = Visibility.Hidden
        Page.FreezeTime = 15
    End Sub

    Private Sub BT_Player1_SelectionChanged(sender As Object, Selected As Boolean) Handles BT_Player1.SelectionChanged
        BT_Player0.Visibility = Visibility.Hidden
        BT_Player1.Visibility = Visibility.Visible
        Page.FreezeTime = 15
    End Sub

    Private Sub SetDifficulty(value As Difficulty)
        KeyState.Shoot = False
        Page.FreezeTime = 15
        difficulty = value
        LB_Title.BackLayer.Fill = Textures.title_character
        State = True
        GB_Difficulty.IsEnabled = False
        GB_Difficulty.Visibility = Visibility.Hidden
        GB_Character.IsEnabled = True
        GB_Character.Visibility = Visibility.Visible
    End Sub
    Public Sub Reset()
        State = False
        GB_Character.IsEnabled = False
        GB_Character.Visibility = Visibility.Hidden
        GB_Difficulty.IsEnabled = True
        GB_Difficulty.Visibility = Visibility.Visible
        LB_Title.BackLayer.Fill = Textures.title_difficulty
        Page.FreezeTime = 15

    End Sub
    Public Sub Page_ActivatedChanged(Activated As Boolean) Handles Page.ActivatedChanged
        If Activated Then
            Page.FreezeTime = 15
        End If
    End Sub
    Private Sub Action()
        If KeyState.Bomb OrElse KeyState.Escape Then
            If State = True Then
                Reset()
            Else
                Page.Visibility = Visibility.Hidden
                Page.Activated = False
                MW.TP.Page.Activated = True
                MW.TP.Page.Visibility = Visibility.Visible
            End If
            ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cancel00)
        End If
    End Sub
End Class
