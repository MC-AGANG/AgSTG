Imports System.Math
''' <summary>
''' 表示粒子效果。<br/>
''' 注意，此类不属于GameObject
''' </summary>
Public Class Particle
    ''' <summary>
    ''' 获取或设置粒子的位置X坐标。
    ''' </summary>
    ''' <returns></returns>
    Public Property X As Double
    ''' <summary>
    ''' 获取或设置粒子的位置Y坐标。
    ''' </summary>
    ''' <returns></returns>
    Public Property Y As Double
    ''' <summary>
    ''' 获取或设置粒子的速度。
    ''' </summary>
    ''' <returns></returns>
    Public Property Speed As Double
    ''' <summary>
    ''' 获取或设置粒子的运动方向。
    ''' </summary>
    ''' <returns></returns>
    Public Property Direction As Double
    ''' <summary>
    ''' 获取或设置粒子的角速度。
    ''' </summary>
    ''' <returns></returns>
    Public Property Angular As Double
    ''' <summary>
    ''' 获取或设置粒子已经存在的时间。
    ''' </summary>
    ''' <returns></returns>
    Public Property Ticks As Long
    ''' <summary>
    ''' 获取或设置粒子的行为。
    ''' </summary>
    ''' <returns></returns>
    Public Act As Action = Nothing
    ''' <summary>
    ''' 获取或设置粒子所属的画布。
    ''' </summary>
    Public Owner As Canvas
    ''' <summary>
    ''' 创建新的粒子效果。
    ''' </summary>
    ''' <param name="X">粒子X坐标</param>
    ''' <param name="Y">粒子Y坐标</param>
    ''' <param name="Width">粒子宽度</param>
    ''' <param name="Height">粒子高度</param>
    ''' <param name="Owner">要将粒子添加到的画布</param>
    Public Sub New(X As Double, Y As Double, Width As Double, Height As Double, Owner As Canvas)
        InitializeComponent()
        Me.X = X
        Me.Y = Y
        Me.Owner = Owner
        Owner.Children.Add(Me)
        Me.Width = Width
        Me.Height = Height
        SetCenter()
        Move()
    End Sub
    ''' <summary>
    ''' 渲染粒子效果
    ''' </summary>
    Public Sub Render()
        If Not IsNothing(Act) Then
            Act()
        End If
        X += Speed * Sin(Direction / 180 * PI)
        Y -= Speed * Cos(Direction / 180 * PI)
        Move()
        Ticks += 1
    End Sub
    Public Sub Move()
        Canvas.SetLeft(Me, X)
        Canvas.SetTop(Me, Y)
        Me_Rotate.Angle += Angular
    End Sub
    Private Sub SetCenter()
        Me_Translate.X = -Width / 2
        Me_Translate.Y = -Height / 2
    End Sub
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
