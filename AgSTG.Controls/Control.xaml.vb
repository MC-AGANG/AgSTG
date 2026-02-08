''' <summary>
''' 表示一个控件，更多地使用键盘操作。
''' </summary>
Public MustInherit Class Control
    ''' <summary>
    ''' 获取或设置控件已运行多少帧
    ''' </summary>
    ''' <returns></returns>
    Public Property Tick As Long = 0
    Public Property X As Double
        Get
            Return _X
        End Get
        Set(value As Double)
            _X = value
            Canvas.SetLeft(Me, _X)
        End Set
    End Property
    Private _X As Double

    Public Property Y As Double
        Get
            Return _Y
        End Get
        Set(value As Double)
            _Y = value
            Canvas.SetTop(Me, _Y)
        End Set
    End Property
    Private _Y As Double
    Private _Height As Double
    Private _Width As Double
    ''' <summary>
    ''' 创建新的控件
    ''' </summary>
    ''' <param name="Width">宽度</param>
    ''' <param name="Height">高度</param>
    Public Sub New(Width As Double, Height As Double)
        InitializeComponent()
        Me.Width = Width
        Me.Height = Height
    End Sub
    Public Sub New(X As Double, Y As Double, Width As Double, Height As Double)
        InitializeComponent()
        Me.X = X
        Me.Y = Y
        _Height = Height
        _Width = Width
    End Sub
    Public MustOverride Sub Render()
    Public MustOverride Sub Initialize()

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        Height = _Height
        Width = _Width
        Initialize()
    End Sub
End Class
