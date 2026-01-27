''' <summary>
''' 表示一句对话
''' </summary>
Public Class Dialog
    Public Property Content As String
    Public Property Speaker As Speakers
    Public Property CD As Integer
    Public Property Auto As Boolean
    Public Illustration As Integer
    ''' <summary>
    ''' 创建一句新的对话
    ''' </summary>
    ''' <param name="Speaker">对话来源</param>
    ''' <param name="Content">对话内容</param>
    ''' <param name="CD">对话后冷却时间</param>
    ''' <param name="Auto">冷却结束后是否自动进入下一句对话</param>
    Public Sub New(Speaker As Speakers, Content As String, illustration As Integer, Optional CD As Integer = 30, Optional Auto As Boolean = False)
        Me.Content = Content
        Me.Speaker = Speaker
        Me.Illustration = illustration
        Me.CD = CD
        Me.Auto = Auto
    End Sub
End Class
Public Enum Speakers
    Player = 0
    Enemy = 1
End Enum