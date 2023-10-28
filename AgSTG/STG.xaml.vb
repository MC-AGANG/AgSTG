Imports System.Numerics
Imports ResourcePack
''' <summary>
''' 表示游戏事件发生的区域
''' </summary>
Public Class STG
    ''' <summary>
    ''' 通过当前关卡
    ''' </summary>
    Public Shared Event StageClear()
    ''' <summary>
    ''' 游戏内所有实体的集合
    ''' </summary>
    Public Shared Objects As New List(Of GameObject)
    ''' <summary>
    ''' 需要移除的对象
    ''' 里面的内容将在一帧的末尾被清理
    ''' </summary>
    Public Shared Objects_rm As New List(Of GameObject)
    ''' <summary>
    ''' 在穷举对象过程中需要添加对象时请先将对象添加到此处
    ''' </summary>
    Public Shared Objects_Add As New List(Of GameObject)
    ''' <summary>
    ''' 可视化渲染的区域
    ''' </summary>
    Public Shared MainBoard As Canvas
    ''' <summary>
    ''' 自机
    ''' </summary>
    Public Shared WithEvents Player As Player
    ''' <summary>
    ''' 获取或设置历史最高分数
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property HiScore As Long
    ''' <summary>
    ''' 获取或设置当前分数
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property Score As Long
    ''' <summary>
    ''' 获取或设置当前残机数量
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property Life As Byte = 2
    ''' <summary>
    ''' 获取或设置当前残机碎片数量
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property LifePiece As Byte
    ''' <summary>
    ''' 获取或设置当前符卡数量
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property Spell As Byte = 3
    ''' <summary>
    ''' 获取或设置当前符卡碎片数量
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property SpellPiece As Byte
    ''' <summary>
    ''' 获取或设置当前火力
    ''' </summary>
    Public Shared Property Power As Short = 400
    ''' <summary>
    ''' 获取或设置当前最大得点
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property PointValue As Long = 10000
    ''' <summary>
    ''' 获取或设置当前擦弹数量
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property Graze As Long
    ''' <summary>
    ''' 获取或设置视角摇晃还会持续多久
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property ShakeFrame As Integer
    ''' <summary>
    ''' 获取或设置是否处于Boss战状态
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property BossAttack As Boolean
    ''' <summary>
    ''' 获取或设置是否处于对话状态
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property DialogMode As Boolean
    ''' <summary>
    ''' 获取或设置是否处于回放状态
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property ReplayMode As Boolean
    Public Shared BackLayer As Grid
    Public Shared CurrentDialog As Integer = -1
    Public Shared DialogList As List(Of Dialog)
    Public Shared DialogCD As Integer
    Public Shared timer10 As Rectangle
    Public Shared timer1 As Rectangle
    Public Shared timer01 As Rectangle
    Public Shared timer001 As Rectangle
    Public Shared timerarea As Canvas
    Public Shared DialogArea As Grid
    Public Shared DialogImage1 As Rectangle
    Public Shared DialogImage2 As Rectangle
    Public Shared DialogBack As Rectangle
    Public Shared DialogText As TextBlock
    Public Shared DialogBackUp As GradientStop
    Public Shared DialogBackDown As GradientStop
    Public Shared DialogName As Rectangle
    Public Shared SpellCardLabel As CardLabel
    Public Shared bonusfail As Boolean = False

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        Height = 448
        Width = 384
        MainBoard = mb
        BackLayer = BL
        Player = New Player.Player0
        Objects.Add(Player)
        time0.Fill = Textures.number(0, 11)
        timer10 = time10
        timer1 = time1
        timer01 = time01
        timer001 = time001
        timerarea = timearea
        DialogArea = DA
        DialogImage1 = DI1
        DialogImage2 = DI2
        DialogBack = DB
        DialogText = DT
        DialogBackUp = DBCU
        DialogBackDown = DBCD
        DialogName = DN
        SpellCardLabel = SA
    End Sub
    Public Sub Render()
        For Each obj In Objects
            obj.FrameCount += 1
            obj.Render()
            obj.Move()
        Next
        For Each obj In Objects_Add
            Objects.Add(obj)
        Next
        Objects_Add.Clear()
        For Each obj In Objects_rm
            Objects.Remove(obj)
        Next
        Objects_rm.Clear()
        Dialogs()
        SpellCardLabel.Render()
        If ShakeFrame > 0 Then
            Shake()
        End If
    End Sub
    Public Shared Sub ClearBullet()
        Dim temp As Bullet
        For Each obj In Objects
            If obj.ObjectType = ObjectType.Bullet Then
                temp = obj
                temp.Break(True)
            End If
        Next
    End Sub
    Public Shared Function SearchEnemy(Tag As Object) As List(Of Enemy)
        Dim output As New List(Of Enemy)
        For Each obj In Objects
            If obj.ObjectType = ObjectType.Enemy AndAlso obj.Tag = Tag AndAlso obj.IsEnabled Then
                output.Add(obj)
            End If
        Next
        Return output
    End Function
    Public Shared Function SearchEnemy() As List(Of Enemy)
        Dim output As New List(Of Enemy)
        For Each obj In Objects
            If obj.ObjectType = ObjectType.Enemy AndAlso obj.IsEnabled Then
                output.Add(obj)
            End If
        Next
        Return output
    End Function
    Public Shared Function SearchBullet() As List(Of Bullet)
        Dim output As New List(Of Bullet)
        For Each obj In Objects
            If obj.ObjectType = ObjectType.Bullet AndAlso obj.IsEnabled Then
                output.Add(obj)
            End If
        Next
        Return output
    End Function
    ''' <summary>
    ''' 重置STG
    ''' </summary>
    Public Shared Sub Reset()

    End Sub
    ''' <summary>
    ''' 转到下一条对话
    ''' </summary>
    Public Shared Sub NextDialog()
        If CurrentDialog + 1 <= DialogList.Count Then
            If CurrentDialog >= 0 Then
                If DialogList(CurrentDialog).Action = DialogAction.Battle Then
                    Dim tempboss As Enemy.Boss
                    For Each obj In SearchEnemy()
                        If obj.EnemyType = EnemyType.Boss Then
                            tempboss = obj
                            tempboss.NextSpell()
                        End If
                    Next
                ElseIf DialogList(CurrentDialog).Action = DialogAction.NextStage Then
                    RaiseEvent StageClear()
                    CurrentDialog = -1
                End If
            Else
                CurrentDialog += 1
                DialogList(CurrentDialog).Show()
            End If
        End If
    End Sub
    Public Sub Dialogs()
        If DialogMode Then
            If DialogCD > 0 Then
                DialogCD -= 1
            Else
                If KeyState.Shoot Then
                    NextDialog()
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 更新符卡计时器
    ''' </summary>
    ''' <param name="Value">倒计时剩余时间</param>
    Public Shared Sub UpdateTime(Value As Integer)
        If Value >= 6000 Then
            Value = 5999
        ElseIf Value < 0 Then
            Value = 0
        End If
        If Value Mod 60 = 0 Then
            If Value <= 180 Then
                Sounds.PlaySound(Sounds.timeout, 0.8)
            ElseIf Value <= 540 Then
                Sounds.PlaySound(Sounds.timeout2, 0.8)
            End If
        End If
        If Value <= 540 Then
            timer10.Fill = Textures.number(2, Value \ 600)
            Value = Value Mod 600
            timer1.Fill = Textures.number(2, Value \ 60)
            Value = Value Mod 60
            timer01.Fill = Textures.number(2, Value \ 6)
            Value = Value Mod 6
            If Value = 0 Then
                timer001.Fill = Textures.number(2, 0)
            Else
                timer001.Fill = Textures.number(2, (Value * 2) - 1)
            End If
        Else
            timer10.Fill = Textures.number(0, Value \ 600)
            Value = Value Mod 600
            timer1.Fill = Textures.number(0, Value \ 60)
            Value = Value Mod 60
            timer01.Fill = Textures.number(0, Value \ 6)
            Value = Value Mod 6
            If Value = 0 Then
                timer001.Fill = Textures.number(0, 0)
            Else
                timer001.Fill = Textures.number(0, (Value * 2) - 1)
            End If

        End If
    End Sub
    Private Sub Shake()
        ShakeFrame -= 1
        If ShakeFrame = 0 Then
            me_translate.X = 0
            me_translate.Y = 0
        Else
            me_translate.X = ShakeFrame * Rnd() - ShakeFrame / 2
            me_translate.Y = ShakeFrame * Rnd() - ShakeFrame / 2
        End If
    End Sub
End Class
