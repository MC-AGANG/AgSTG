Imports System.Windows.Media.Media3D
Imports AgSTG
Imports AgSTG.Controls
Imports AgSTG.Core
Imports ResourcePack.TH07

Public Class DataPage
    Public WithEvents Page As New Page
    Private GB_Difficulty As New GroupBox(32, 96, 64, 320)
    Private WithEvents BT_Easy As New Button(0, 0, 128, 32)
    Private WithEvents BT_Normal As New Button(0, 96, 128, 32)
    Private WithEvents BT_Hard As New Button(0, 192, 128, 32)
    Private WithEvents BT_Lunatic As New Button(0, 288, 128, 32)


    Private GB_Player As New GroupBox(192, 64, 384, 32)
    Private WithEvents BT_Reimu As New Button(0, 0, 256, 32)
    Private WithEvents BT_Marisa As New Button(150, 0, 256, 32)

    Private LB_Score(9) As Label
    Public WithEvents MW As MainWindow

    Private difficulty As Difficulty = Difficulty.Easy
    Private character As PlayerType = PlayerType.灵梦
    Public Sub Initialize()
        For i = 0 To 9
            LB_Score(i) = New Label(96, 96 + 32 * i, 448, 32)
            Page.Controls.Add(LB_Score(i))
        Next

        Page.Background = Textures.select_background
        GB_Difficulty.Direction = GroupDirection.Vertical
        GB_Player.Direction = GroupDirection.Horizontal
        BT_Easy.Text = "简单"
        BT_Normal.Text = "普通"
        BT_Hard.Text = "困难"
        BT_Lunatic.Text = "疯狂"

        BT_Reimu.Text = "博丽灵梦"
        BT_Marisa.Text = "雾雨魔理沙"

        Page.Controls.Add(GB_Difficulty)
        Page.Controls.Add(GB_Player)

        GB_Difficulty.Buttons.Add(BT_Easy)
        GB_Difficulty.Buttons.Add(BT_Normal)
        GB_Difficulty.Buttons.Add(BT_Hard)
        GB_Difficulty.Buttons.Add(BT_Lunatic)

        GB_Player.Buttons.Add(BT_Reimu)
        GB_Player.Buttons.Add(BT_Marisa)


        Page.Act = AddressOf Action
    End Sub

    Public Sub New()
        MyBase.New()
        Initialize()
    End Sub

    Public Sub Page_ActivatedChanged(Activated As Boolean) Handles Page.ActivatedChanged
        If Activated Then
            Page.FreezeTime = 15
        End If
    End Sub

    Private Sub BT_Easy_SelectionChanged(sender As Object, Selected As Boolean) Handles BT_Easy.SelectionChanged
        If Selected Then
            difficulty = Difficulty.Easy
            UpdateData()
        End If
    End Sub

    Private Sub BT_Normal_SelectionChanged(sender As Object, Selected As Boolean) Handles BT_Normal.SelectionChanged
        If Selected Then
            difficulty = Difficulty.Normal
            UpdateData()
        End If
    End Sub

    Private Sub BT_Hard_SelectionChanged(sender As Object, Selected As Boolean) Handles BT_Hard.SelectionChanged
        If Selected Then
            difficulty = Difficulty.Hard
            UpdateData()
        End If
    End Sub

    Private Sub BT_Lunatic_SelectionChanged(sender As Object, Selected As Boolean) Handles BT_Lunatic.SelectionChanged
        If Selected Then
            difficulty = Difficulty.Lunatic
            UpdateData()
        End If
    End Sub

    Private Sub BT_Reimu_SelectionChanged(sender As Object, Selected As Boolean) Handles BT_Reimu.SelectionChanged
        If Selected Then
            character = PlayerType.灵梦
            UpdateData()
        End If
    End Sub
    Private Sub BT_Marisa_SelectionChanged(sender As Object, Selected As Boolean) Handles BT_Marisa.SelectionChanged
        If Selected Then
            character = PlayerType.魔理沙
            UpdateData()
        End If
    End Sub

    Private Sub UpdateData()
        For Each rs In STG.ScoreRecord.Results
            If rs.Difficulty = difficulty AndAlso rs.Character = character Then
                For i = 0 To 9
                    If i < 9 Then
                        LB_Score(i).Text = CStr(i + 1) + ":" + vbTab + rs.Scores(i).Score.ToString("D10") + vbTab + rs.Scores(i).PlayerName
                    Else
                        LB_Score(i).Text = CStr(i + 1) + ":" + vbTab + rs.Scores(i).Score.ToString("D10") + vbTab + rs.Scores(i).PlayerName
                    End If

                Next
            End If
        Next
        Page.FreezeTime = 15
    End Sub
    Private Sub Action()
        If KeyState.Bomb OrElse KeyState.Escape Then
            Page.Visibility = Visibility.Hidden
            Page.Activated = False
            MW.TP.Page.Activated = True
            MW.TP.Page.Visibility = Visibility.Visible
            ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cancel00)
        End If
    End Sub
End Class
