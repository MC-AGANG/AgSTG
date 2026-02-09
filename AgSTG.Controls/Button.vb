Imports System.Math
Imports AgSTG.Core
Imports ResourcePack
''' <summary>
''' 表示按钮控件，此按钮使用键盘操作。
''' </summary>
Public Class Button
    Inherits Control
    ''' <summary>
    ''' 获取或设置按钮是否被选中。
    ''' </summary>
    ''' <returns>按钮是否被选中</returns>
    Public Property Selected As Boolean
        Get
            Return _Selected
        End Get
        Set(value As Boolean)
            _Selected = value
            If value Then
                ForeLayer.Visibility = Visibility.Visible
            Else
                ForeLayer.Visibility = Visibility.Hidden
            End If
            RaiseEvent SelectionChanged(Me, value)
        End Set
    End Property
    Private _Selected As Boolean = False
    ''' <summary>
    ''' 按钮的背景层
    ''' </summary>
    Public BackLayer As New Rectangle
    ''' <summary>
    ''' 按钮的前景层
    ''' </summary>
    Public ForeLayer As New Rectangle
    ''' <summary>
    ''' 当按钮的选中状态发生变化时触发
    ''' </summary>
    ''' <param name="sender">发生变化的按钮</param>
    ''' <param name="selected">是否被选中</param>
    Public Event SelectionChanged(sender As Button, selected As Boolean)
    ''' <summary>
    ''' 当按钮被按下时触发。
    ''' </summary>
    ''' <param name="sender">被按下的按钮。</param>
    Public Event Clicked(sender As Button)
    ''' <summary>
    ''' 按下按钮时要播放的音效
    ''' </summary>
    Public SoundEffect As MediaPlayer
    ''' <summary>
    ''' 创建新的按钮
    ''' </summary>
    ''' <param name="Width">宽度</param>
    ''' <param name="Height">高度</param>
    Public Sub New(Width As Double, Height As Double)
        MyBase.New(Width, Height)
        Selected = False
        SoundEffect = Sounds.ok00
    End Sub
    Public Sub New(X As Double, Y As Double, Width As Double, Height As Double)
        MyBase.New(X, Y, Width, Height)
        Selected = False
        SoundEffect = Sounds.ok00
    End Sub
    ''' <summary>
    ''' 渲染这个按钮
    ''' </summary>
    Public Overrides Sub Render()
        If Selected Then
            ForeLayer.Opacity = Sin(PI / 60 * Tick) * 0.5 + 0.5
            If KeyState.Shoot Then
                Sounds.PlaySound(SoundEffect)
                RaiseEvent Clicked(Me)
            End If
            Tick += 1
        End If
    End Sub
    ''' <summary>
    ''' 初始化按钮
    ''' </summary>
    Public Overrides Sub Initialize()
        GD_Main.Children.Add(BackLayer)
        GD_Main.Children.Add(ForeLayer)
        BackLayer.Width = Width
        BackLayer.Height = Height
        ForeLayer.Width = Width
        ForeLayer.Height = Height

    End Sub
End Class
