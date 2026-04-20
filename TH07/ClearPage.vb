Imports AgSTG
Imports AgSTG.Controls
Imports AgSTG.Core
Imports ResourcePack.TH07
Public Class ClearPage
    Public WithEvents Page As New Page
    Private Group As New GroupBox(48, 192, 256, 256)
    Private WithEvents BT_Save As New Button(0, 0, 256, 32)
    Private WithEvents BT_Title As New Button(0, 40, 256, 32)
    Private WithEvents BT_Retry As New Button(0, 80, 256, 32)
    Public MW As MainWindow
    Public Sub Initialize()
        BT_Save.ForeLayer.Fill = Textures.bt_save(0)
        BT_Save.BackLayer.Fill = Textures.bt_save(1)
        BT_Title.ForeLayer.Fill = Textures.bt_title(0)
        BT_Title.BackLayer.Fill = Textures.bt_title(1)
        BT_Retry.ForeLayer.Fill = Textures.bt_retry(0)
        BT_Retry.BackLayer.Fill = Textures.bt_retry(1)
        Page.Controls.Add(Group)
        Group.Buttons.Add(BT_Save)
        Group.Buttons.Add(BT_Title)
        Group.Buttons.Add(BT_Retry)
        Page.Act = AddressOf Action
    End Sub
    Public Sub New()
        MyBase.New()
        Initialize()
    End Sub
    Private Sub BT_Save_Clicked() Handles BT_Save.Clicked
        Dim name As String = InputBox("输入你的昵称", "保存回放", "Save")
        Dim sd As New Microsoft.Win32.SaveFileDialog With {.Filter = "回放文件 (*.rep)|*.rep", .FileName = name + ".rep", .DefaultDirectory = Environment.CurrentDirectory + "\replay"}
        If sd.ShowDialog() Then
            Dim rf As New ReplayFile(2, GamePage.PlayerID, name)
            For Each r In STG.Replays
                rf.Stages.Add(r)
            Next
            rf.Save(sd.FileName)
        End If
        Page.Visibility = Visibility.Hidden
        Page.Activated = False
        MW.TP.Page.Activated = True
        MW.TP.Page.Visibility = Visibility.Visible
        MW.GP.Visibility = Visibility.Hidden
    End Sub
    Private Sub BT_Title_Clicked() Handles BT_Title.Clicked
        Page.Visibility = Visibility.Hidden
        Page.Activated = False
        MW.TP.Page.Activated = True
        MW.TP.Page.Visibility = Visibility.Visible
        MW.GP.Visibility = Visibility.Hidden
    End Sub
    Private Sub BT_Retry_Clicked() Handles BT_Retry.Clicked
        STG.Stages(STG.CurrentStage).Reset()
        STG.Reset()
        Page.Activated = False
        MW.GP.Activated = True
        Page.Visibility = Visibility.Hidden
    End Sub
    Private Sub Page_ActivatedChanged(Activated As Boolean) Handles Page.ActivatedChanged
        If Activated Then
            ManagedBass.Bass.ChannelPause(STG.CurrentMusic)
        End If
    End Sub
    Private Sub Action()

    End Sub
End Class
