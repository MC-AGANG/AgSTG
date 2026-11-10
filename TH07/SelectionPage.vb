Imports AgSTG
Imports AgSTG.Core
Imports AgSTG.Controls
Imports ResourcePack.TH07

Public Class SelectionPage
    Public WithEvents Page As New Page
    Private GB_Difficulty As New GroupBox(192, 96, 256, 480)
    Private WithEvents BT_Easy As New Button(0, 0, 256, 96)
    Private WithEvents BT_Normal As New Button(0, 96, 256, 96)
    Private WithEvents BT_Hard As New Button(0, 192, 256, 96)
    Private WithEvents BT_Lunatic As New Button(0, 288, 256, 96)
    Public MW As MainWindow
    Public Sub Initialize()
        Page.Background = Textures.select_background
        BT_Easy.ForeLayer.Fill = Textures.sl_easy
        BT_Easy.BackLayer.Fill = Textures.sl_easy_b
        BT_Normal.ForeLayer.Fill = Textures.sl_normal
        BT_Normal.BackLayer.Fill = Textures.sl_normal_b
        BT_Hard.ForeLayer.Fill = Textures.sl_hard
        BT_Hard.BackLayer.Fill = Textures.sl_hard_b
        BT_Lunatic.ForeLayer.Fill = Textures.sl_lunatic
        BT_Lunatic.BackLayer.Fill = Textures.sl_lunatic_b
        Page.Controls.Add(GB_Difficulty)
        GB_Difficulty.Buttons.Add(BT_Easy)
        GB_Difficulty.Buttons.Add(BT_Normal)
        GB_Difficulty.Buttons.Add(BT_Hard)
        GB_Difficulty.Buttons.Add(BT_Lunatic)
        Page.Act = AddressOf Action
    End Sub
    Public Sub New()
        MyBase.New()
        Initialize()
    End Sub

    'Private Sub BT_Start_Clicked() Handles BT_Start.Clicked
    '    STG.ReplayMode = False
    '    Page.Activated = False
    '    MW.GP.Activated = True
    '    Page.Visibility = Visibility.Hidden
    '    MW.GP.Visibility = Visibility.Visible
    '    STG.Reset()
    'End Sub


    Public Sub Page_ActivatedChanged(Activated As Boolean) Handles Page.ActivatedChanged
        'If Activated Then
        '    ResourcePack.Sounds.PlaySound(Sounds.mu01)
        '    STG.ReplayMode = False
        'Else
        '    ManagedBass.Bass.ChannelStop(Sounds.mu01)
        'End If
    End Sub
    Private Sub Action()
        Static Tick = 0
        'If Tick <= 50 Then
        '    GB_Difficulty.Opacity = Tick / 50
        '    Tick += 1
        'End If
    End Sub
End Class
