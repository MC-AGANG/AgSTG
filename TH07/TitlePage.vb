Imports AgSTG
Imports AgSTG.Core
Imports AgSTG.Controls
Imports ResourcePack.TH07
Public Class TitlePage
    Public WithEvents Page As New Page
    Private Group As New GroupBox(430, 256, 160, 96)
    Private WithEvents BT_Start As New Button(0, 0, 160, 24)
    Private WithEvents BT_Replay As New Button(0, 24, 160, 24)
    Private WithEvents BT_Quit As New Button(0, 48, 160, 24)
    Public MW As MainWindow
    Public Sub Initialize()
        Page.Background = Textures.title_bk
        BT_Start.ForeLayer.Fill = Textures.bt_start(0)
        BT_Start.BackLayer.Fill = Textures.bt_start(1)
        BT_Replay.ForeLayer.Fill = Textures.bt_replay(0)
        BT_Replay.BackLayer.Fill = Textures.bt_replay(1)
        BT_Quit.ForeLayer.Fill = Textures.bt_quit(0)
        BT_Quit.BackLayer.Fill = Textures.bt_quit(1)
        Page.Controls.Add(Group)
        Group.Buttons.Add(BT_Start)
        Group.Buttons.Add(BT_Replay)
        Group.Buttons.Add(BT_Quit)
        Group.Opacity = 0
        Page.Background.Opacity = 0
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
        STG.Reset()
    End Sub
    Private Sub BT_Replay_Clicked() Handles BT_Replay.Clicked
        Dim ofd As New Microsoft.Win32.OpenFileDialog With {.Filter = "回放文件 (*.rep)|*.rep", .DefaultDirectory = Environment.CurrentDirectory + "\replay"}
        If ofd.ShowDialog() Then
            STG.ReplayMode = True
            STG.Replays.Clear()
            Dim rf As New ReplayFile(ofd.FileName)
            For Each r In rf.Stages
                STG.Replays.Add(r)
            Next
            STG.Reset()
            Page.Activated = False
            MW.GP.Activated = True
            Page.Visibility = Visibility.Hidden
            MW.GP.Visibility = Visibility.Visible
        End If
    End Sub
    Private Sub BT_Quit_Clicked() Handles BT_Quit.Clicked
        MW.Timer1.Stop()
        MW.Close()
    End Sub

    Public Sub Page_ActivatedChanged(Activated As Boolean) Handles Page.ActivatedChanged
        If Activated Then
            ResourcePack.Sounds.PlaySound(Sounds.mu01)
        Else
            ManagedBass.Bass.ChannelStop(Sounds.mu01)
        End If
    End Sub
    Private Sub Action()
        Static Tick = 0
        If Tick <= 150 Then
            If Tick = 100 Then
                Page.Background.Opacity = 1
            ElseIf Tick < 150 Then
                Group.Opacity = (Tick - 100) / 50
            End If
            Tick += 1
        End If

    End Sub
End Class
