Imports AgSTG
Imports AgSTG.Controls
Imports AgSTG.Core
Imports ResourcePack.TH17
Public Class PausePage
    Public WithEvents Page As New Page
    Private Group As New GroupBox(48, 192, 256, 256)
    Private WithEvents BT_Continue As New Button(0, 0, 256, 32)
    Private WithEvents BT_Title As New Button(0, 40, 256, 32)
    Private WithEvents BT_Retry As New Button(0, 80, 256, 32)
    Public MW As MainWindow
    Public Sub Initialize()
        BT_Continue.ForeLayer.Fill = Textures.bt_continue(0)
        BT_Continue.BackLayer.Fill = Textures.bt_continue(1)
        BT_Title.ForeLayer.Fill = Textures.bt_title(0)
        BT_Title.BackLayer.Fill = Textures.bt_title(1)
        BT_Retry.ForeLayer.Fill = Textures.bt_retry(0)
        BT_Retry.BackLayer.Fill = Textures.bt_retry(1)
        Page.Controls.Add(Group)
        Group.Buttons.Add(BT_Continue)
        Group.Buttons.Add(BT_Title)
        Group.Buttons.Add(BT_Retry)
        Page.Act = AddressOf Action
    End Sub
    Public Sub New()
        MyBase.New()
        Initialize()
    End Sub
    Private Sub BT_Continue_Clicked() Handles BT_Continue.Clicked
        Page.Activated = False
        MW.GP.Activated = True
        Page.Visibility = Visibility.Hidden
        STG.CurrentMusic.Play()
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
            STG.CurrentMusic.Pause()
        End If
    End Sub
    Private Sub Action()
        If KeyState.Escape OrElse KeyState.Bomb Then
            Page.Activated = False
            MW.GP.Activated = True
            Page.Visibility = Visibility.Hidden
            ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cancel00)
        End If
    End Sub
End Class
