''' <summary>
''' 表示一个关卡回放文件
''' </summary>
Public Class Replay
    ''' <summary>
    ''' 获取或设置随机数种子
    ''' </summary>
    ''' <returns></returns>
    Public Property Seed As Double
    ''' <summary>
    ''' 获取或设置当前关卡
    ''' </summary>
    ''' <returns></returns>
    Public Property Stage As Integer
    ''' <summary>
    ''' 包含回放中的所有属性数据
    ''' </summary>
    Public Property PropertyData As New List(Of Long)
    ''' <summary>
    ''' 包含回放中的所有按键数据
    ''' </summary>
    Public KeyData As New List(Of Byte)
    ''' <summary>
    ''' 创建新的空白关卡回放
    ''' </summary>
    ''' <param name="seed">随机数种子</param>
    Public Sub New(seed As Double)
        Me.Seed = seed
    End Sub
End Class
