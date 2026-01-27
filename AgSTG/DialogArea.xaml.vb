Imports System.IO
''' <summary>
''' 表示对话区域
''' </summary>
Public Class DialogArea
    ''' <summary>
    ''' 获取或设置对话是否结束
    ''' </summary>
    Public Property Finished As Boolean = True
    ''' <summary>
    ''' 获取或设置对话进行到第几句
    ''' </summary>
    ''' <returns></returns>
    Public Property Position As Integer = 0
    ''' <summary>
    ''' 储存对话内容
    ''' </summary>
    Public Dialogs As New List(Of Dialog)
    ''' <summary>
    ''' 储存玩家角色立绘
    ''' </summary>
    Public player As New List(Of ImageBrush)
    ''' <summary>
    ''' 储存敌方角色立绘
    ''' </summary>
    Public enemy As New List(Of ImageBrush)
    Private CD As Integer = 0
    Private CL_PlayerTop As Color = Color.FromArgb(192, 0, 0, 128)
    Private CL_PlayerBottom As Color = Color.FromArgb(0, 0, 0, 128)
    Private CL_EnemyTop As Color = Color.FromArgb(192, 128, 0, 0)
    Private CL_EnemyBottom As Color = Color.FromArgb(0, 128, 0, 0)
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)

    End Sub
    ''' <summary>
    ''' 从CSV文件加载对话
    ''' </summary>
    ''' <param name="file">要导入的文件，允许内存流</param>
    Public Sub LoadDialog(file As StreamReader)
        Dim source() As String
        Dialogs.Clear()
        file.ReadLine()
        Do Until file.EndOfStream
            source = file.ReadLine().Split(",")
            If source.Length >= 5 Then
                Dialogs.Add(New Dialog(Val(source(0)), source(1), Val(source(2)), Val(source(3)), Val(source(4))))
            End If
        Loop
        file.BaseStream.Position = 0
        Finished = False
        Position = 0
        RC_EnemyIllustration.Fill = Nothing
        RC_PlayerIllustration.Fill = Nothing

    End Sub
    ''' <summary>
    ''' 加载玩家角色立绘
    ''' </summary>
    ''' <param name="images">要加载的贴图</param>
    Public Sub LoadPlayer(images() As ImageBrush)
        player.Clear()
        For Each i In images
            If Not IsNothing(i) Then
                player.Add(i)
            End If
        Next
    End Sub
    ''' <summary>
    ''' 加载敌方角色立绘
    ''' </summary>
    ''' <param name="images">要加载的贴图</param>
    Public Sub LoadEnemy(images() As ImageBrush)
        enemy.Clear()
        For Each i In images
            If Not IsNothing(i) Then
                enemy.Add(i)
            End If
        Next
    End Sub
    ''' <summary>
    ''' 进入下一句对话
    ''' </summary>
    Public Sub [Next]()
        Dim content As String()
        If Position < Dialogs.Count Then
            TB_DialogContent.Inlines.Clear()
            If Dialogs(Position).Speaker = Speakers.Enemy Then
                Color_Top.Color = CL_EnemyTop
                Color_Bottom.Color = CL_EnemyBottom
                RC_EnemyIllustration.Opacity = 1
                RC_PlayerIllustration.Opacity = 0.75
                Canvas.SetLeft(RC_PlayerIllustration, -64)
                Canvas.SetLeft(RC_EnemyIllustration, 128)
                RC_EnemyIllustration.Fill = enemy(Dialogs(Position).Illustration)
            Else
                Color_Top.Color = CL_PlayerTop
                Color_Bottom.Color = CL_PlayerBottom
                RC_EnemyIllustration.Opacity = 0.75
                RC_PlayerIllustration.Opacity = 1
                Canvas.SetLeft(RC_PlayerIllustration, 0)
                Canvas.SetLeft(RC_EnemyIllustration, 192)
                RC_PlayerIllustration.Fill = player(Dialogs(Position).Illustration)
            End If
            CD = Dialogs(Position).CD
            content = Dialogs(Position).Content.Split("<br/>")
            For Each s In content
                TB_DialogContent.Inlines.Add(s)
            Next
            Position += 1
        Else
            Finished = True
            Hide()
        End If
    End Sub
    ''' <summary>
    ''' 渲染对话区域
    ''' </summary>
    Public Sub Render()
        If Not Finished Then
            If CD > 0 Then
                CD -= 1
            Else
                If Dialogs(Position - 1).Auto Then
                    [Next]()
                ElseIf KeyState.Shoot Then
                    [Next]()
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 现实对话区域
    ''' </summary>
    Public Sub Show()
        Visibility = Visibility.Visible
        [Next]()
    End Sub
    ''' <summary>
    ''' 隐藏对话区域
    ''' </summary>
    Public Sub Hide()
        Visibility = Visibility.Hidden
    End Sub
End Class
