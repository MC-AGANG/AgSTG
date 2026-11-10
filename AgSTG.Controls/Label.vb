Public Class Label
    Inherits Control
    ''' <summary>
    ''' 标签的背景层
    ''' </summary>
    Public BackLayer As New Rectangle
    ''' <summary>
    ''' 创建新的标签
    ''' </summary>
    ''' <param name="Width">宽度</param>
    ''' <param name="Height">高度</param>
    Public Sub New(Width As Double, Height As Double)
        MyBase.New(Width, Height)
    End Sub
    Public Sub New(X As Double, Y As Double, Width As Double, Height As Double)
        MyBase.New(X, Y, Width, Height)
    End Sub
    ''' <summary>
    ''' 渲染这个标签
    ''' </summary>
    Public Overrides Sub Render()

    End Sub
    ''' <summary>
    ''' 初始化按钮
    ''' </summary>
    Public Overrides Sub Initialize()
        GD_Main.Children.Add(BackLayer)
        BackLayer.Width = Width
        BackLayer.Height = Height
    End Sub
End Class
