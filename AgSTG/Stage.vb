
''' <summary>
''' 表示一个关卡。
''' </summary>
Public MustInherit Class Stage
    ''' <summary>
    ''' 获取或设置关卡的背景动画。
    ''' </summary>
    Public Background As UserControl
    ''' <summary>
    ''' 获取或设置关卡运行时间
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property Ticks As Long
    ''' <summary>
    ''' 获取或设置关卡难度
    ''' </summary>
    ''' <returns></returns>
    Public Property Difficulty As Difficulty
    ''' <summary>
    ''' 初始化关卡，继承后必须重写。
    ''' </summary>
    Public MustOverride Sub Initialize()
    ''' <summary>
    ''' 运行这个关卡的主循环，继承后必须重写。
    ''' </summary>
    Public MustOverride Sub Render()
    ''' <summary>
    ''' 创建新的关卡实例。
    ''' </summary>
    ''' <param name="Difficulty">设置关卡难度</param>
    Public Sub New(Difficulty As Difficulty)
        Me.Difficulty = Difficulty
        Initialize()
    End Sub
    ''' <summary>
    ''' 加载关卡到游戏中。
    ''' </summary>
    Public Sub Load()
        If Not IsNothing(Background) Then
            STG.BackLayer.Children.Add(Background)
        End If
    End Sub
    ''' <summary>
    ''' 卸载关卡。
    ''' </summary>
    Public Sub Unload()
        If Not IsNothing(Background) Then
            STG.BackLayer.Children.Remove(Background)
        End If
        Reset()
    End Sub
    ''' <summary>
    ''' 重置关卡状态
    ''' </summary>
    Public Overridable Sub Reset()
        Ticks = 0
    End Sub
    ''' <summary>
    ''' 通过当前关卡
    ''' </summary>
    Public Overridable Sub Clear()
        Reset()
        STG.NextStage()
    End Sub
End Class
Public Enum Difficulty
    Easy = 1
    Normal = 2
    Hard = 3
    Lunatic = 4
    Override = 5
    Extra = 9
    Phantasm = 10
End Enum