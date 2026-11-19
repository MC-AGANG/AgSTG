Imports System.Windows.Media.Media3D
Imports AgSTG
Imports AgSTG.Controls
Imports AgSTG.Core
Imports ResourcePack.TH07

Public Class OptionPage
    Public WithEvents Page As New Page
    Private Group As New GroupBox(0, 0, 640, 480)
    Private WithEvents LB_WindowState As New Label(64, 96, 256, 32)
    Private WithEvents BT_WindowState As New Button(384, 96, 256, 32)
    Private WithEvents LB_EffectVolume As New Label(64, 128, 256, 32)
    Private WithEvents BT_EffectVolume As New Button(384, 128, 256, 32)
    Private WithEvents LB_MusicVolume As New Label(64, 160, 256, 32)
    Private WithEvents BT_MusicVolume As New Button(384, 160, 256, 32)
    Private WithEvents LB_Key_Up As New Label(64, 192, 256, 32)
    Private WithEvents BT_Key_Up As New Button(384, 192, 256, 32)
    Private WithEvents LB_Key_Down As New Label(64, 224, 256, 32)
    Private WithEvents BT_Key_Down As New Button(384, 224, 256, 32)
    Private WithEvents LB_Key_Left As New Label(64, 256, 256, 32)
    Private WithEvents BT_Key_Left As New Button(384, 256, 256, 32)
    Private WithEvents LB_Key_Right As New Label(64, 288, 256, 32)
    Private WithEvents BT_Key_Right As New Button(384, 288, 256, 32)
    Private WithEvents LB_Key_Shoot As New Label(64, 320, 256, 32)
    Private WithEvents BT_Key_Shoot As New Button(384, 320, 256, 32)
    Private WithEvents LB_Key_Bomb As New Label(64, 352, 256, 32)
    Private WithEvents BT_Key_Bomb As New Button(384, 352, 256, 32)
    Private WithEvents LB_Key_Slow As New Label(64, 384, 256, 32)
    Private WithEvents BT_Key_Slow As New Button(384, 384, 256, 32)
    Private WithEvents BT_Reset As New Button(64, 416, 256, 32)
    Private WithEvents BT_Save As New Button(384, 416, 256, 32)
    Public WithEvents MW As MainWindow

    Private EffectVolume_Backup As Integer
    Private MusicVolume_Backup As Integer
    Private Pre_Up As Integer
    Private Pre_Down As Integer
    Private Pre_Left As Integer
    Private Pre_Right As Integer
    Private Pre_Shoot As Integer
    Private Pre_Bomb As Integer
    Private Pre_Slow As Integer
    Public Sub Initialize()
        Page.Background = Textures.select_background
        LB_WindowState.Text = "显示模式"
        LB_EffectVolume.Text = "音效音量"
        LB_MusicVolume.Text = "音乐音量"
        LB_Key_Up.Text = "向上"
        LB_Key_Down.Text = "向下"
        LB_Key_Left.Text = "向左"
        LB_Key_Right.Text = "向右"
        LB_Key_Shoot.Text = "开火"
        LB_Key_Bomb.Text = "符卡"
        LB_Key_Slow.Text = "减速"
        BT_Reset.Text = "重置"
        BT_Save.Text = "保存"

        Page.Controls.Add(Group)
        Page.Controls.Add(LB_WindowState)
        Group.Buttons.Add(BT_WindowState)
        Page.Controls.Add(LB_EffectVolume)
        Group.Buttons.Add(BT_EffectVolume)
        Page.Controls.Add(LB_MusicVolume)
        Group.Buttons.Add(BT_MusicVolume)
        Page.Controls.Add(LB_Key_Up)
        Group.Buttons.Add(BT_Key_Up)
        Page.Controls.Add(LB_Key_Down)
        Group.Buttons.Add(BT_Key_Down)
        Page.Controls.Add(LB_Key_Left)
        Group.Buttons.Add(BT_Key_Left)
        Page.Controls.Add(LB_Key_Right)
        Group.Buttons.Add(BT_Key_Right)
        Page.Controls.Add(LB_Key_Shoot)
        Group.Buttons.Add(BT_Key_Shoot)
        Page.Controls.Add(LB_Key_Bomb)
        Group.Buttons.Add(BT_Key_Bomb)
        Page.Controls.Add(LB_Key_Slow)
        Group.Buttons.Add(BT_Key_Slow)
        Group.Buttons.Add(BT_Reset)
        Group.Buttons.Add(BT_Save)
        Page.Act = AddressOf Action
    End Sub
    Public Sub InitOption()
        If MW.WindowStyle = WindowStyle.None Then
            BT_WindowState.Text = "全屏"
        Else
            BT_WindowState.Text = "窗口"
        End If
        BT_EffectVolume.Text = ResourcePack.Sounds.EffectVolume & "%"
        BT_MusicVolume.Text = ResourcePack.Sounds.MusicVolume & "%"
        BT_Key_Up.Text = [Enum].GetName(GetType(Key), Settings.Key_Up)
        BT_Key_Down.Text = [Enum].GetName(GetType(Key), Settings.Key_Down)
        BT_Key_Left.Text = [Enum].GetName(GetType(Key), Settings.Key_Left)
        BT_Key_Right.Text = [Enum].GetName(GetType(Key), Settings.Key_Right)
        BT_Key_Shoot.Text = [Enum].GetName(GetType(Key), Settings.Key_Shoot)
        BT_Key_Bomb.Text = [Enum].GetName(GetType(Key), Settings.Key_Bomb)
        BT_Key_Slow.Text = [Enum].GetName(GetType(Key), Settings.Key_Slow)
        Pre_Up = Settings.Key_Up
        Pre_Down = Settings.Key_Down
        Pre_Left = Settings.Key_Left
        Pre_Right = Settings.Key_Right
        Pre_Shoot = Settings.Key_Shoot
        Pre_Bomb = Settings.Key_Bomb
        Pre_Slow = Settings.Key_Slow
        EffectVolume_Backup = ResourcePack.Sounds.EffectVolume
        MusicVolume_Backup = ResourcePack.Sounds.MusicVolume
    End Sub

    Public Sub UpdateOption()
        If MW.WindowStyle = WindowStyle.None Then
            BT_WindowState.Text = "全屏"
        Else
            BT_WindowState.Text = "窗口"
        End If
        BT_EffectVolume.Text = ResourcePack.Sounds.EffectVolume & "%"
        BT_MusicVolume.Text = ResourcePack.Sounds.MusicVolume & "%"
        BT_Key_Up.Text = [Enum].GetName(GetType(Key), Pre_Up)
        BT_Key_Down.Text = [Enum].GetName(GetType(Key), Pre_Down)
        BT_Key_Left.Text = [Enum].GetName(GetType(Key), Pre_Left)
        BT_Key_Right.Text = [Enum].GetName(GetType(Key), Pre_Right)
        BT_Key_Shoot.Text = [Enum].GetName(GetType(Key), Pre_Shoot)
        BT_Key_Bomb.Text = [Enum].GetName(GetType(Key), Pre_Bomb)
        BT_Key_Slow.Text = [Enum].GetName(GetType(Key), Pre_Slow)
    End Sub

    Public Sub New()
        MyBase.New()
        Initialize()
    End Sub

    Private Sub BT_WindowState_Clicked() Handles BT_WindowState.Clicked
        If MW.WindowStyle = WindowStyle.None Then
            MW.WindowStyle = WindowStyle.SingleBorderWindow
            MW.WindowState = WindowState.Normal
            MW.Height = MW.MinHeight
            MW.Width = MW.MinWidth
        Else
            If MW.WindowState = WindowState.Maximized Then
                MW.WindowState = WindowState.Normal
            End If
            MW.WindowStyle = WindowStyle.None
            MW.WindowState = WindowState.Maximized
        End If
        UpdateOption()
        Page.FreezeTime = 15
    End Sub

    Public Sub Page_ActivatedChanged(Activated As Boolean) Handles Page.ActivatedChanged
        If Activated Then
            Page.FreezeTime = 15
            InitOption()
        End If
    End Sub
    Private Sub BT_Key_Up_Clicked() Handles BT_Key_Up.Clicked
        BT_Key_Up.Text = "(请按下按键)"
        Threading.Thread.Sleep(5)
        Group.IsEnabled = False
    End Sub
    Private Sub BT_Key_Down_Clicked() Handles BT_Key_Down.Clicked
        BT_Key_Down.Text = "(请按下按键)"
        Threading.Thread.Sleep(5)
        Group.IsEnabled = False
    End Sub
    Private Sub BT_Key_Left_Clicked() Handles BT_Key_Left.Clicked
        BT_Key_Left.Text = "(请按下按键)"
        Threading.Thread.Sleep(5)
        Group.IsEnabled = False
    End Sub
    Private Sub BT_Key_Right_Clicked() Handles BT_Key_Right.Clicked
        BT_Key_Right.Text = "(请按下按键)"
        Threading.Thread.Sleep(5)
        Group.IsEnabled = False
    End Sub
    Private Sub BT_Key_Shoot_Clicked() Handles BT_Key_Shoot.Clicked
        BT_Key_Shoot.Text = "(请按下按键)"
        Threading.Thread.Sleep(5)
        Group.IsEnabled = False
    End Sub
    Private Sub BT_Key_Bomb_Clicked() Handles BT_Key_Bomb.Clicked
        BT_Key_Bomb.Text = "(请按下按键)"
        Threading.Thread.Sleep(5)
        Group.IsEnabled = False
    End Sub
    Private Sub BT_Key_Slow_Clicked() Handles BT_Key_Slow.Clicked
        BT_Key_Slow.Text = "(请按下按键)"
        Threading.Thread.Sleep(5)
        Group.IsEnabled = False
    End Sub
    Private Sub BT_Reset_Clicked() Handles BT_Reset.Clicked
        ResourcePack.Sounds.EffectVolume = 100
        ResourcePack.Sounds.MusicVolume = 100
        Pre_Up = 24
        Pre_Down = 26
        Pre_Left = 23
        Pre_Right = 25
        Pre_Shoot = 69
        Pre_Bomb = 67
        Pre_Slow = 116
        UpdateOption()
        Page.FreezeTime = 15
    End Sub

    Private Sub BT_Save_Clicked() Handles BT_Save.Clicked
        Settings.Key_Up = Pre_Up
        Settings.Key_Down = Pre_Down
        Settings.Key_Left = Pre_Left
        Settings.Key_Right = Pre_Right
        Settings.Key_Shoot = Pre_Shoot
        Settings.Key_Bomb = Pre_Bomb
        Settings.Key_Slow = Pre_Slow
        Settings.WriteVolume()
        Settings.WriteKeys()
        If MW.WindowStyle = WindowStyle.None Then
            Settings.WriteWindowStage(True)
        Else
            Settings.WriteWindowStage(False)
        End If
        Page.Visibility = Visibility.Hidden
        Page.Activated = False
        MW.TP.Page.Activated = True
        MW.TP.Page.Visibility = Visibility.Visible
    End Sub

    Private Sub Page_KeyDown(sender As Object, e As KeyEventArgs) Handles MW.KeyDown
        Dim flag As Boolean = False

        If BT_Key_Up.Text = "(请按下按键)" Then
            Pre_Up = e.Key
            flag = True
        ElseIf BT_Key_Down.Text = "(请按下按键)" Then
            Pre_Down = e.Key
            flag = True
        ElseIf BT_Key_Left.Text = "(请按下按键)" Then
            Pre_Left = e.Key
            flag = True
        ElseIf BT_Key_Right.Text = "(请按下按键)" Then
            Pre_Right = e.Key
            flag = True
        ElseIf BT_Key_Shoot.Text = "(请按下按键)" Then
            Pre_Shoot = e.Key
            flag = True
        ElseIf BT_Key_Bomb.Text = "(请按下按键)" Then
            Pre_Bomb = e.Key
            flag = True
        ElseIf BT_Key_Slow.Text = "(请按下按键)" Then
            Pre_Slow = e.Key
            flag = True
        End If
        If flag Then
            UpdateOption()
            Group.IsEnabled = True
            Page.FreezeTime = 15
            ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ok00)
        End If
    End Sub
    Private Sub Action()
        If KeyState.Left Then
            If BT_WindowState.Selected Then
                BT_WindowState_Clicked()
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ok00)
            ElseIf BT_EffectVolume.Selected Then
                If ResourcePack.Sounds.EffectVolume >= 5 Then
                    ResourcePack.Sounds.EffectVolume -= 5
                Else
                    ResourcePack.Sounds.EffectVolume = 0
                End If
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ok00)
                UpdateOption()
                Page.FreezeTime = 10
            ElseIf BT_MusicVolume.Selected Then
                If ResourcePack.Sounds.MusicVolume >= 5 Then
                    ResourcePack.Sounds.MusicVolume -= 5
                Else
                    ResourcePack.Sounds.MusicVolume = 0
                End If
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ok00)
                UpdateOption()
                Page.FreezeTime = 10
            End If
        End If
        If KeyState.Right Then
            If BT_WindowState.Selected Then
                BT_WindowState_Clicked()
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ok00)
            ElseIf BT_EffectVolume.Selected Then
                If ResourcePack.Sounds.EffectVolume <= 95 Then
                    ResourcePack.Sounds.EffectVolume += 5
                Else
                    ResourcePack.Sounds.EffectVolume = 100
                End If
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ok00)
                UpdateOption()
                Page.FreezeTime = 10
            ElseIf BT_MusicVolume.Selected Then
                If ResourcePack.Sounds.MusicVolume <= 95 Then
                    ResourcePack.Sounds.MusicVolume += 5
                Else
                    ResourcePack.Sounds.MusicVolume = 100
                End If
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ok00)
                UpdateOption()
                Page.FreezeTime = 10
            End If
        End If
        If KeyState.Bomb OrElse KeyState.Escape Then
            Page.Visibility = Visibility.Hidden
            Page.Activated = False
            MW.TP.Page.Activated = True
            MW.TP.Page.Visibility = Visibility.Visible
            ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cancel00)
            ResourcePack.Sounds.EffectVolume = EffectVolume_Backup
            ResourcePack.Sounds.MusicVolume = MusicVolume_Backup
        End If
    End Sub
End Class
