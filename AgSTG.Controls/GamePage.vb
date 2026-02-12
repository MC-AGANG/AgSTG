Imports AgSTG
Imports AgSTG.Core
''' <summary>
''' 表示游戏界面。
''' </summary>
Public Class GamePage
    Inherits Page
    ''' <summary>
    ''' 获取或设置游戏区域。
    ''' </summary>
    Public STG As New STG(0, Difficulty.Normal)
    ''' <summary>
    ''' 获取或设置属性面板。
    ''' </summary>
    Public PropertyBoard As New PropertyBoard
    ''' <summary>
    ''' 获取或设置游戏页面的背景图。
    ''' </summary>
    ''' <param name="fill">背景的填充内容</param>
    Public Sub SetBackground(fill As Brush)
        CV_Main.Background = fill
    End Sub
    Public Sub New()
        MyBase.New()
    End Sub
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        Canvas.SetLeft(STG, 32)
        Canvas.SetTop(STG, 16)
        CV_Main.Children.Add(STG)
        Canvas.SetLeft(PropertyBoard, 416)
        Canvas.SetTop(PropertyBoard, 16)
        CV_Main.Children.Add(PropertyBoard)
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If FreezeTime > 0 Then
            Return
        End If
        Dispatcher.Invoke(Sub()
                              STG.Render()
                              PropertyBoard.Update()
                          End Sub)
    End Sub
    Private Sub GamePage_ActivatedChanged(Activated As Boolean) Handles Me.ActivatedChanged
        If Activated Then
            STG.Blur.Radius = 0
        Else
            STG.Blur.Radius = 5
        End If
    End Sub
End Class
