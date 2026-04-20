Imports System.Numerics
Imports ResourcePack
Imports AgSTG.Core
''' <summary>
''' 表示游戏事件发生的区域
''' </summary>
Public Class STG
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
    Public Shared Property Power As Short = 100
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
    ''' 获取或设置是否处于回放状态
    ''' </summary>
    ''' <returns></returns>
    Public Shared Property ReplayMode As Boolean
    Public Shared Replays As New List(Of Replay)
    ''' <summary>
    ''' 获取或设置当前难度
    ''' </summary>
    Public Shared Difficulty As Difficulty
    ''' <summary>
    ''' 获取或设置当前关卡列表
    ''' </summary>
    Public Shared Stages As New List(Of Stage)

    Public Shared CurrentStage As Integer = 0
    Public Shared BackLayer As Grid
    Public Shared BackLayer_BlackHole As wpfpslib.BlackHoleEffect
    Public Shared timer10 As Rectangle
    Public Shared timer1 As Rectangle
    Public Shared timer01 As Rectangle
    Public Shared timer001 As Rectangle
    Public Shared timerarea As Canvas
    Public Shared SpellCardLabel As CardLabel
    Public Shared bonusfail As Boolean = False
    Public Shared WithEvents DialogArea As DialogArea
    Public Shared TitleArea As Rectangle
    Public Shared MusicArea As Label
    Public Shared NameArea As BossName
    Public Shared Event GameClear()
    Public Shared Event GameOver()
    Public Shared Blur As Effects.BlurEffect
    Public Shared CurrentMusic As Integer
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        Height = 448
        Width = 384
        Objects.Add(Player)
        time0.Fill = Textures.number(0, 11)
        AddHandler Player.GameOver, AddressOf Player_GameOver
    End Sub
    Public Sub New(PlayerID As Integer, Difficulty As Difficulty)
        InitializeComponent()
        MainBoard = mb
        BackLayer = BL
        BackLayer_BlackHole = BL_BH
        timer10 = time10
        timer1 = time1
        timer01 = time01
        timer001 = time001
        timerarea = timearea

        SpellCardLabel = SA
        DialogArea = DA
        TitleArea = RC_Title
        MusicArea = LB_Music
        NameArea = BN
        Blur = Me_Blur
        Select Case PlayerID
            Case 0
                Player = New Player.Player0
            Case 1
                Player = New Player.Player1
        End Select
        Me.Difficulty = Difficulty
    End Sub
    Public Sub Render()
        If Not ReplayMode Then
            Replays.Last.KeyData.Add(KeyState.Encode)
        Else
            KeyState.Decode(Replays(CurrentStage).KeyData(Stages(CurrentStage).Ticks))
        End If
        For Each obj In Objects
            obj.Ticks += 1
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
        SpellCardLabel.Render()
        If ShakeFrame > 0 Then
            Shake()
        End If
        DialogArea.Render()
        If CurrentStage >= 0 Then
            Stages(CurrentStage).Render()
        End If
        NameArea.Render()
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
        BackLayer_BlackHole.Radius = 0
        Stages(CurrentStage).Unload()
        For Each s In Stages
            s.Reset()
        Next
        CurrentStage = -1
        Score = 0
        Life = 2
        LifePiece = 0
        Spell = 3
        SpellPiece = 0
        Graze = 0
        PointValue = 10000
        Power = 100
        If Not ReplayMode Then
            Replays.Clear()
        End If
        NextStage()
        For Each e In Objects
            e.Clear()
        Next
        Player = New Player.Player0
        Objects.Add(Player)
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
    ''' <summary>
    ''' 进入下一关
    ''' </summary>
    Public Shared Sub NextStage()
        If Not IsNothing(CurrentMusic) Then
            Sounds.StopSound(CurrentMusic)
        End If
        If Not ReplayMode Then
            If CurrentStage < Stages.Count - 1 Then
                Dim seed As Double = Date.Now.Millisecond + Date.Now.Second * 1000
                Rnd(-1)
                Randomize(seed)
                If CurrentStage >= 0 Then
                    Stages(CurrentStage).Unload()
                End If
                CurrentStage += 1
                Stages(CurrentStage).Load()
                Replays.Add(New Replay(seed))
                Replays.Last.PropertyData.Add(Score)
                Replays.Last.PropertyData.Add(Life)
                Replays.Last.PropertyData.Add(LifePiece)
                Replays.Last.PropertyData.Add(Spell)
                Replays.Last.PropertyData.Add(SpellPiece)
                Replays.Last.PropertyData.Add(Power)
                Replays.Last.PropertyData.Add(PointValue)
                Replays.Last.PropertyData.Add(Graze)
            Else
                RaiseEvent GameClear()
            End If
        Else
            If CurrentStage < Stages.Count - 1 Then
                Dim seed As Double = Replays(CurrentStage + 1).Seed
                Rnd(-1)
                Randomize(seed)
                If CurrentStage >= 0 Then
                    Stages(CurrentStage).Unload()
                End If
                CurrentStage += 1
                Stages(CurrentStage).Load()

                Score = Replays(CurrentStage).PropertyData(0)
                Life = Replays(CurrentStage).PropertyData(1)
                LifePiece = Replays(CurrentStage).PropertyData(2)
                Spell = Replays(CurrentStage).PropertyData(3)
                SpellPiece = Replays(CurrentStage).PropertyData(4)
                Power = Replays(CurrentStage).PropertyData(5)
                PointValue = Replays(CurrentStage).PropertyData(6)
                Graze = Replays(CurrentStage).PropertyData(7)
            Else
                RaiseEvent GameClear()
            End If
        End If


    End Sub
    Private Sub Player_GameOver()
        RaiseEvent GameOver()
    End Sub
End Class
