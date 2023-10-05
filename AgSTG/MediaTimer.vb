Imports System.Threading
''' <summary>
''' 用于表示媒体定时器
''' 此定时器具有极高的精度
''' 可用于使游戏按一定速率稳定运行
''' </summary>
Public Class MediaTimer
    ''' <summary>
    ''' 到达时间间隔时触发
    ''' </summary>
    ''' <param name="MSPT">这一刻处理完负载所需要的时间，单位：毫秒</param>
    Public Event Tick(MSPT As Double)
    ''' <summary>
    ''' 获取或设置定时器每秒运行多少次
    ''' 当工作负载超过计算机处理能力时，实际的TPS会下降
    ''' </summary>
    ''' <returns></returns>
    Public Property TPS As Double
    ''' <summary>
    ''' 获取或设置这个定时器的工作负载
    ''' 由于定时器使用异步线程，此方法需要委托
    ''' </summary>
    Public Act As Action
    Private Enabled As Boolean
    Private T As Task
    Private SW As Stopwatch
    ''' <summary>
    ''' 创建新的MediaTimer
    ''' </summary>
    ''' <param name="TPS">定时器每秒运行的次数</param>
    ''' <param name="Act">定时器的工作负载，需要委托</param>
    Public Sub New(TPS As Double, Optional Act As Action = Nothing)
        Me.TPS = TPS
        Me.Act = Act
        SW = New Stopwatch
        T = New Task(AddressOf Main)
    End Sub
    ''' <summary>
    ''' 启动定时器
    ''' </summary>
    Public Sub Start()
        If Not Enabled Then
            T.Start()
            Enabled = True
        End If
    End Sub
    ''' <summary>
    ''' 使定时器停止
    ''' </summary>
    Public Sub [Stop]()
        If Enabled Then
            Enabled = False
        End If
    End Sub
    Private Sub Main()
        Do While Enabled
            SW.Restart()
            If Not IsNothing(Act) Then
                Act()
            End If
            RaiseEvent Tick(SW.ElapsedTicks / 10000)
            Do Until SW.ElapsedTicks >= (10000000 / TPS)
                Thread.Sleep(0)
            Loop
        Loop
    End Sub
    ''' <summary>
    ''' 获取定时器是否处于工作状态
    ''' </summary>
    ''' <returns></returns>
    Public Function IsEnabled() As Boolean
        Return Enabled
    End Function

End Class
