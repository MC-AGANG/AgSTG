''' <summary>
''' 包含按键状态
''' </summary>
Public Class KeyState
    ''' <summary>
    ''' 获取或设置光标上键是否被按下
    ''' </summary>
    Public Shared Up As Boolean
    ''' <summary>
    ''' 获取或设置光标下键是否被按下
    ''' </summary>
    Public Shared Down As Boolean
    ''' <summary>
    ''' 获取或设置光标左键是否被按下
    ''' </summary>
    Public Shared Left As Boolean
    ''' <summary>
    ''' 获取或设置光标右键是否被按下
    ''' </summary>
    Public Shared Right As Boolean
    ''' <summary>
    ''' 获取或设置减速键是否被按下
    ''' </summary>
    Public Shared Slow As Boolean
    ''' <summary>
    ''' 获取或设置开火键是否被按下
    ''' </summary>
    Public Shared Shoot As Boolean
    ''' <summary>
    ''' 获取或设置大招键是否被按下
    ''' </summary>
    Public Shared Bomb As Boolean
    ''' <summary>
    ''' 获取或设置扩展按键是否被按下
    ''' </summary>
    Public Shared Extend As Boolean
    ''' <summary>
    ''' 获取或设置退出键是否被按下（不会被编码）
    ''' </summary>
    Public Shared Escape As Boolean
    ''' <summary>
    ''' 将当前按键状态编码为一个字节
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Encode() As Byte
        Encode = 0
        If Up Then Encode += 1
        If Down Then Encode += 2
        If Left Then Encode += 4
        If Right Then Encode += 8
        If Slow Then Encode += 16
        If Shoot Then Encode += 32
        If Bomb Then Encode += 64
        If Extend Then Encode += 128
    End Function
    ''' <summary>
    ''' 将一个字节解码为按键状态
    ''' </summary>
    ''' <param name="value">要被解码的字节</param>
    Public Shared Sub Decode(value As Key)
        Up = value.HasFlag(Key.Up)
        Down = value.HasFlag(Key.Down)
        Left = value.HasFlag(Key.Left)
        Right = value.HasFlag(Key.Right)
        Slow = value.HasFlag(Key.Slow)
        Shoot = value.HasFlag(Key.Shoot)
        Bomb = value.HasFlag(Key.Bomb)
        Extend = value.HasFlag(Key.Extend)
    End Sub
    ''' <summary>
    ''' 枚举按键
    ''' </summary>
    Public Enum Key As Byte
        Up = 1
        Down = 2
        Left = 4
        Right = 8
        Slow = 16
        Shoot = 32
        Bomb = 64
        Extend = 128
    End Enum
End Class
