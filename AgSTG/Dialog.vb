Public Class Dialog
    ''' <summary>
    ''' 获取或设置对话内容
    ''' </summary>
    ''' <returns></returns>
    Public Property Content As String
    ''' <summary>
    ''' 获取或设置己方立绘<br/>
    ''' 若为Nothing则表示保持现状
    ''' </summary>
    ''' <returns></returns>
    Public Property Image1 As ImageBrush
    ''' <summary>
    ''' 获取或设置敌方立绘<br/>
    ''' 若为Nothing则表示保持现状
    ''' </summary>
    ''' <returns></returns>
    Public Property Image2 As ImageBrush
    ''' <summary>
    ''' 获取或设置对话来源
    ''' </summary>
    ''' <returns>True代表己方，False代表敌方</returns>
    Public Property Target As Boolean
    ''' <summary>
    ''' 获取或设置经过多少时间之后才能进入下一条对话
    ''' </summary>
    ''' <returns></returns>
    Public Property CD As Integer
    ''' <summary>
    ''' 获取或设置此条对话结束后执行的操作
    ''' </summary>
    ''' <returns></returns>
    Public Property Action As DialogAction
    ''' <summary>
    ''' 获取或设置要显示的敌方名称
    ''' </summary>
    ''' <returns></returns>
    Public Property EnemyName As ImageBrush
    ''' <summary>
    ''' 创建一条新的对话
    ''' </summary>
    ''' <param name="Content">对话内容</param>
    ''' <param name="target">对话来源，True代表己方，False代表敌方</param>
    ''' <param name="CD">经过多少时间之后才能进入下一条对话，默认为5帧</param>
    ''' <param name="Action">此条对话结束后执行的操作，默认为进入下一条</param>
    ''' <param name="image1">己方立绘，默认为保持不变</param>
    ''' <param name="image2">敌方立绘，默认为保持不变</param>
    ''' <param name="EnemyName">敌方立绘，默认为保持不变</param>
    Public Sub New(Content As String, target As Boolean, Optional CD As Integer = 5, Optional Action As DialogAction = DialogAction.Default, Optional image1 As ImageBrush = Nothing, Optional image2 As ImageBrush = Nothing, Optional EnemyName As ImageBrush = Nothing)
        Me.Content = Content
        Me.Target = target
        Me.CD = CD
        Me.Action = Action
        Me.Image1 = image1
        Me.Image2 = image2
        Me.EnemyName = EnemyName
    End Sub
    ''' <summary>
    ''' 显示当前对话
    ''' </summary>
    Public Sub Show()
        STG.DialogArea.Visibility = Visibility.Visible
        STG.DialogText.Text = Content
        If Target Then
            STG.DialogBackUp.Color = Color.FromArgb(255, 0, 0, 128)
            STG.DialogBackDown.Color = Color.FromArgb(0, 0, 0, 128)
        Else
            STG.DialogBackUp.Color = Color.FromArgb(255, 128, 0, 0)
            STG.DialogBackUp.Color = Color.FromArgb(0, 128, 0, 0)
        End If
        If Not IsNothing(Image1) Then
            STG.DialogImage1.Fill = Image1
        End If
        If Not IsNothing(Image2) Then
            STG.DialogImage2.Fill = Image1
        End If
        STG.DialogName.Fill = EnemyName
        STG.DialogCD = CD
    End Sub
End Class
''' <summary>
''' 枚举对话后执行的操作
''' </summary>
Public Enum DialogAction As Byte
    ''' <summary>
    ''' 进入下一条对话
    ''' </summary>
    [Default] = 0
    ''' <summary>
    ''' 开始战斗
    ''' </summary>
    Battle = 1
    ''' <summary>
    ''' 进入下一关
    ''' </summary>
    NextStage = 2
End Enum