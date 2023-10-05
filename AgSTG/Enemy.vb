Imports ResourcePack
Imports System.Math
''' <summary>
''' 表示敌机单位
''' </summary>
Public Class Enemy
    Inherits GameObject
    ''' <summary>
    ''' 获取或设置敌机的类型
    ''' 当这个属性100时，代表Boss
    ''' </summary>
    ''' <returns></returns>
    Public Property EnemyType As EnemyType
    ''' <summary>
    ''' 获取或设置敌机的颜色
    ''' 当敌机为Boss时，这个属性代表Boss的编号
    ''' </summary>
    ''' <returns></returns>
    Public Property Color As BulletColor
    ''' <summary>
    ''' 获取或设置敌机的血量
    ''' </summary>
    ''' <returns></returns>
    Public Property HP As Double
    ''' <summary>
    ''' 获取或设置敌机的防御值，范围为0到1
    ''' </summary>
    Public Property Defence As Double
    ''' <summary>
    ''' 获取或设置掉落物
    ''' 格式为一连串掉落物编号
    ''' 示例：0011代表掉落2个P点和2个蓝点
    ''' </summary>
    ''' <returns></returns>
    Public Property DropItems As String
    ''' <summary>
    ''' 获取或设置敌机的最大存在时间
    ''' </summary>
    ''' <returns></returns>
    Public Property Life As Integer
    ''' <summary>
    ''' 获取或设置敌机的移动速度
    ''' </summary>
    ''' <returns></returns>
    Public Property Speed As Double
    ''' <summary>
    ''' 获取或设置敌机的移动方向，单位：角度
    ''' 以向上为0度，顺时针递增
    ''' </summary>
    ''' <returns></returns>
    Public Property Direction As Double
    ''' <summary>
    ''' 为敌机设置的弹幕脚本<br/>
    ''' 可在关卡脚本中使用扩展方法来创建<br/>
    ''' 并且在初始化时使用with语句来添加
    ''' </summary>
    Public Act As Action = Nothing
    Private Appearance As Action
    Private TurnFrame As SByte = 0
    Private FadeOutFrame As Byte = 0
    Private ghostfires As List(Of GhostFire)
    Private rm_ghostfires As List(Of GhostFire)
    ''' <summary>
    ''' 创建新的敌机单位
    ''' </summary>
    ''' <param name="EnemyType">种类（指外观）</param>
    ''' <param name="Color">颜色（指细分的种类）</param>
    ''' <param name="X">初始X坐标</param>
    ''' <param name="Y">初始Y坐标</param>
    ''' <param name="HP">血量</param>
    ''' <param name="DropItems">掉落物</param>
    ''' <param name="Life">存在时间</param>
    ''' <param name="Defence">防御值，默认为0</param>
    ''' <param name="Speed">移动速度，默认为0</param>
    ''' <param name="Direction">方向，默认为0，即向上</param>
    Public Sub New(EnemyType As EnemyType, Color As Byte, X As Double, Y As Double, HP As Double, DropItems As String, Life As Integer, Optional Speed As Double = 0, Optional Direction As Double = 0, Optional Defence As Double = 0)
        MyBase.New(ObjectType.Enemy, X, Y)
        Me.EnemyType = EnemyType
        Me.Color = Color
        Me.HP = HP
        Me.Defence = Defence
        Me.DropItems = DropItems
        Me.Life = Life
        Me.Speed = Speed
        Me.Direction = Direction
        IsEnabled = False
        Opacity = 0
        InitAppearance()
    End Sub
    ''' <summary>
    ''' 使敌机受到伤害
    ''' </summary>
    ''' <param name="Value">伤害的量</param>
    Public Sub Damage(Value As Double)
        HP -= Value * (1 - Defence)
    End Sub
    Private Sub InitAppearance()
        Select Case EnemyType
            Case EnemyType.阴阳玉
                SetSize(32, 32, 12)
                Layer1.Fill = Textures.enemy(0, Color, 0)
                Layer2.Fill = Textures.enemy(0, Color, 0)
                Layer3.Fill = Textures.enemy(0, Color, 1)
                Layer1.Width = 32
                Layer1.Height = 32
                Layer2.Width = 32
                Layer2.Height = 32
                Layer3.Width = 32
                Layer3.Height = 32
                Layer1_scale.ScaleX = 1.2
                Layer1_scale.ScaleY = 1.2
                Layer2_scale.ScaleX = 0.9
                Layer2_scale.ScaleY = 0.9
                Appearance = New Action(AddressOf Appearance0)
                Exit Select
            Case EnemyType.小妖精
                SetSize(32, 32, 12)
                Appearance = New Action(AddressOf Appearance1234)
                Exit Select
            Case EnemyType.小蝴蝶
                SetSize(48, 32, 16)
                Appearance = New Action(AddressOf Appearance1234)
                Exit Select
            Case EnemyType.中蝴蝶
                SetSize(48, 48, 20)
                Appearance = New Action(AddressOf Appearance1234)
                Exit Select
            Case EnemyType.大蝴蝶
                SetSize(64, 64, 24)
                Appearance = New Action(AddressOf Appearance1234)
                Exit Select
            Case EnemyType.幽灵
                SetSize(32, 32, 12)
                ghostfires = New List(Of GhostFire)
                rm_ghostfires = New List(Of GhostFire)
                Appearance = New Action(AddressOf Appearance5)
                Exit Select
            Case EnemyType.乌鸦
                Exit Select
            Case EnemyType.Boss
                Exit Select
            Case Else
                Exit Select
        End Select
    End Sub
    Private Sub Appearance0()
        Layer1_rotate.Angle = (-FrameCount * 4) Mod 360
        Layer2_rotate.Angle = (FrameCount * 8) Mod 360
    End Sub
    Private Sub Appearance1234()
        If Abs(TurnFrame) <> 0 AndAlso Abs(TurnFrame) < 17 Then
            Background = Textures.enemy(EnemyType, Color, 4 + Abs(TurnFrame \ 4))
            If TurnFrame = -1 Then
                Me_Scale.ScaleX = -1
            ElseIf TurnFrame = 1 Then
                Me_Scale.ScaleX = 1
            End If
            TurnFrame += GetXDirection()
        Else
            If Sign(TurnFrame) > GetXDirection() Then
                TurnFrame -= 1
            ElseIf Sign(TurnFrame) < GetXDirection() Then
                TurnFrame += 1
            ElseIf TurnFrame = 0 AndAlso FrameCount Mod 6 = 0 Then
                If FrameCount Mod 6 = 0 Then
                    Background = Textures.enemy(EnemyType, Color, (FrameCount \ 6) Mod 4)
                End If
            ElseIf FrameCount Mod 6 = 0 Then
                Background = Textures.enemy(EnemyType, Color, ((FrameCount \ 6) Mod 4) + 8)
            End If
        End If
    End Sub
    Private Sub Appearance5()
        Background = Textures.enemy(EnemyType, Color, (FrameCount \ 2) Mod 8)
        If FrameCount Mod 2 = 0 Then
            ghostfires.Add(New GhostFire(Me))
        End If
        For Each g In ghostfires
            g.Render()
        Next
        For Each g In rm_ghostfires
            ghostfires.Remove(g)
        Next
    End Sub
    Private Function GetXDirection() As SByte
        Direction = Direction Mod 360
        If Direction < 0 Then
            Direction += 360
        End If
        If Speed <> 0 Then
            If Direction > 185 AndAlso Direction < 355 Then
                Return -1
            ElseIf Direction > 5 AndAlso Direction < 175 Then
                Return 1
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function
    Public Overrides Sub Render()
        If FrameCount <= 30 Then
            Opacity = FrameCount / 30
            If FrameCount = 30 Then
                IsEnabled = True
            End If
        End If
        If FadeOutFrame = 0 Then
            If Not IsNothing(Appearance) Then
                Appearance()
            End If
            X += Speed * Sin(Direction / 180 * PI)
            Y -= Speed * Cos(Direction / 180 * PI)
        Else
            FadeOut()
        End If
        If （FrameCount > Life AndAlso IsEnabled） OrElse (HP <= 0 AndAlso IsEnabled) Then
            FadeOutFrame = 1
            IsEnabled = False
        End If
        If Not IsNothing(Act) Then
            Act()
        End If
    End Sub
    Private Sub FadeOut()
        If FadeOutFrame <= 16 Then
            If FadeOutFrame = 1 Then
                Background = Textures.deadcircle
                Layer1.Opacity = 0
                Layer2.Opacity = 0
                Layer3.Opacity = 0
                Sounds.PlaySound(Sounds.enep00, 0.4)
                If HP <= 0 Then
                    DropItem()
                End If
            End If
            Opacity = (16 - FadeOutFrame) / 16
            Me_Scale.ScaleX = 1 + (FadeOutFrame / 8)
            Me_Scale.ScaleY = 1 + (FadeOutFrame / 8)
        Else
            Clear()
        End If
        FadeOutFrame += 1
    End Sub
    Public Sub DropItem()
        If Not IsNothing(DropItems) Then
            For Each c In DropItems
                STG.Objects_Add.Add(New Item(Val(c), X + (Rnd() * HitboxSize * 4) - (Rnd() * HitboxSize * 2), Y + (Rnd() * HitboxSize * 4) - (Rnd() * HitboxSize * 2)))
            Next
        End If
    End Sub
    Public Sub Judge()
        If IsEnabled AndAlso STG.Player.Invin = 0 Then
            If IsHit(STG.Player) Then
                STG.Player.Miss()
            End If
        End If
    End Sub
    Private Class GhostFire
        Public X As Double
        Public Y As Double
        Public framecount As Integer
        Public rec As Rectangle
        Private owner As Enemy
        Public Sub New(owner As Enemy)
            Me.owner = owner
            X = Rnd() * 16 - 8
            Y = 16
            rec = New Rectangle
            owner.MainBoard.Children.Add(rec)
            rec.Height = 16
            rec.Width = 16
        End Sub
        Public Sub Render()
            Y -= 4
            X = Rnd() * 16 - 8
            framecount += 1
            rec.Height -= 2
            rec.Width -= 2
            Canvas.SetLeft(rec, X - rec.Width / 2 + 16)
            Canvas.SetTop(rec, Y - rec.Height / 2)
            rec.Fill = Textures.enemy(owner.EnemyType, owner.Color, (framecount \ 2) Mod 8)
            If framecount >= 8 Then
                owner.MainBoard.Children.Remove(rec)
                owner.rm_ghostfires.Add(Me)
            End If
        End Sub
    End Class
    Public Class Boss
        Inherits Enemy
        ''' <summary>
        ''' 获取或设置进行到第几张符卡<br/>
        ''' 当这个数值等于-1时，表示战斗还未开始
        ''' </summary>
        ''' <returns></returns>
        Public Property CurrentSpell As SByte = -1
        ''' <summary>
        ''' 获取或设置Boss的符卡列表
        ''' </summary>
        ''' <returns></returns>
        Public Property SpellCards As New List(Of SpellCard)
        ''' <summary>
        ''' Boss初始化脚本程序
        ''' 可以在关卡脚本中使用扩展方法来添加
        ''' </summary>
        Public Init As Action
        Private HPBar As New HPBar
        Private MoveFrame As Integer

        Public Sub New(BossID As Byte, X As Double, Y As Double)
            MyBase.New(EnemyType.Boss, BossID, X, Y, 99999, "", 99999)
            IsEnabled = False
            Opacity = 1
            SetSize(128, 128, 24)
            Layer1.Fill = Textures.magicsquare
            Layer1.Width = 128
            Layer1.Height = 128
            Layer1_scale.ScaleX = 0
            Layer1_scale.ScaleY = 0
            Layer1.Opacity = 0.5
            MainBoard.Children.Add(HPBar)
            HPBar.Visibility = Visibility.Hidden
            STG.BossAttack = True
        End Sub
        Private Sub Boss_Move()
            If MoveFrame > 0 Then
                X += Speed * Sin(Direction / 180 * PI)
                Y -= Speed * Cos(Direction / 180 * PI)
                MoveFrame -= 1
            End If
        End Sub
        ''' <summary>
        ''' Boss单位子类建议重写并调用此方法<br/>
        ''' 否则会导致部分功能无法自动运行
        ''' </summary>
        Public Overrides Sub Render()
            If FrameCount = 0 Then
                Init()
            End If
            Boss_Move()
            MagicSquare()
            If CurrentSpell > -1 Then
                If SpellCards(CurrentSpell).IsEnabled Then
                    SpellCards(CurrentSpell).Render()
                    SpellCards(CurrentSpell).FrameCount += 1
                    HPBar.Update(SpellCards(CurrentSpell).AtSpell, HP)
                End If
            End If
            If FadeOutFrame >= 1 Then
                If FadeOutFrame = 60 Then
                    Layer1.Fill = Nothing
                    Layer2.Fill = Nothing
                    Layer3.Fill = Nothing
                    Background = Textures.deadcircle
                ElseIf FadeOutFrame > 60 AndAlso FadeOutFrame <= 90 Then
                    Me_Scale.ScaleX = (FadeOutFrame - 60) / 15
                    Me_Scale.ScaleY = (FadeOutFrame - 60) / 15
                    Opacity = (30 - (FadeOutFrame - 60)) / 30
                Else
                    Clear()
                End If
                FadeOutFrame += 1
            Else
                Act()
                If HP <= 0 Then
                    HP = 99999
                    SpellFinish(True)
                End If
            End If
        End Sub
        Private Sub MagicSquare()
            If CurrentSpell > -1 Then
                If SpellCards(CurrentSpell).IsEnabled Then
                    Layer1_rotate.Angle = (FrameCount * 5) Mod 360
                    If SpellCards(CurrentSpell).FrameCount < 60 Then
                        Layer1_scale.ScaleX = SpellCards(CurrentSpell).FrameCount / 30
                        Layer1_scale.ScaleY = SpellCards(CurrentSpell).FrameCount / 30
                    Else
                        Layer1_scale.ScaleX = (0.2 * Sin((SpellCards(CurrentSpell).FrameCount - 60) / 20)) + 2
                        Layer1_scale.ScaleY = (0.2 * Sin((SpellCards(CurrentSpell).FrameCount - 60) / 20)) + 2
                    End If
                Else
                    Layer1_scale.ScaleX = 0
                    Layer1_scale.ScaleY = 0
                End If
            End If
        End Sub
        ''' <summary>
        ''' 按默认程序移动<br/>
        ''' 算法为：X轴80%概率向玩家所在的方向移动，Y轴随机<br/>
        ''' 如果到达边缘附近，则必然往相反方向运动
        ''' </summary>
        ''' <param name="time">移动持续时间</param>
        Public Sub DefaultMove(time As Integer)
            MoveFrame = time
            If X < 64 Then
                Direction = 90 + Rnd() * 30 - 15
            ElseIf X > 320 Then
                Direction = 270 + Rnd() * 30 - 15
            Else
                Dim near As Boolean
                If Rnd() < 0.8 Then
                    near = True
                End If
                If STG.Player.X > X Then
                    If near Then
                        Direction = 90 + Rnd() * 30 - 15
                    Else
                        Direction = 270 + Rnd() * 30 - 15
                    End If
                Else
                    If near Then
                        Direction = 270 + Rnd() * 30 - 15
                    Else
                        Direction = 90 + Rnd() * 30 - 15
                    End If
                End If
            End If
            Speed = Rnd() * 64 / time
        End Sub
        ''' <summary>
        ''' 结束当前符卡或非符
        ''' <paramref name="IsBreak">符卡或非符有没有被击破</paramref>
        ''' </summary>
        Public Sub SpellFinish(IsBreak As Boolean)
            IsEnabled = False
            If SpellCards(CurrentSpell).Break() Then
                If IsBreak Then
                    DropItems = SpellCards(CurrentSpell).Items
                    DropItem()
                    If SpellCards(CurrentSpell).Score > 0 Then
                        STG.SpellCardLabel.Success()
                        STG.Score += SpellCards(CurrentSpell).Score
                    Else
                        STG.SpellCardLabel.Fail()
                    End If
                Else
                    STG.SpellCardLabel.Fail()
                End If
                NextSpell()
            End If
            Sounds.PlaySound(Sounds.tan00)
            STG.ClearBullet()
        End Sub
        ''' <summary>
        ''' 进入下一张符卡，可根据需求重写
        ''' </summary>
        Public Overridable Sub NextSpell()
            Sounds.PlaySound(Sounds.ch02)
            If CurrentSpell < SpellCards.Count - 1 Then
                CurrentSpell += 1
                SpellCards(CurrentSpell).IsEnabled = True
                If SpellCards(CurrentSpell).HaveUsual Then
                    HP = SpellCards(CurrentSpell).UsualHP
                End If
                HPBar.Visibility = Visibility.Visible
                If IsNothing(SpellCards(CurrentSpell).StagePercent) OrElse SpellCards(CurrentSpell).StagePercent.Length = 0 Then
                    HPBar.Preset(SpellCards(CurrentSpell).UsualHP, SpellCards(CurrentSpell).SpellHP)
                Else
                    HPBar.Preset(SpellCards(CurrentSpell).UsualHP, SpellCards(CurrentSpell).SpellHP, SpellCards(CurrentSpell).StagePercent)
                End If

                IsEnabled = True
                Else
                    FadeOutFrame = 1
                Sounds.PlaySound(Sounds.enep01)
                STG.BossAttack = False
            End If
        End Sub
        ''' <summary>
        ''' 将Boss移动到X轴中央（X=192,Y=128）
        ''' </summary>
        ''' <param name="time">移动持续时间</param>
        Public Sub MoveToCenter(time As Integer)
            MoveTo(192, 128, time)
        End Sub
        ''' <summary>
        ''' 将Boss移动到指定位置
        ''' </summary>
        ''' <param name="X">X坐标</param>
        ''' <param name="Y">Y坐标</param>
        ''' <param name="Time">移动持续时间</param>
        Public Sub MoveTo(X As Double, Y As Double, Time As Integer)
            MoveFrame = Time
            Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(X - Me.X, Y - Me.Y))
            Speed = New Vector(X - Me.X, Y - Me.Y).Length / Time
        End Sub
    End Class
End Class
''' <summary>
''' 枚举敌机的种类
''' </summary>
Public Enum EnemyType As Byte
    阴阳玉 = 0
    小妖精 = 1
    小蝴蝶 = 2
    中蝴蝶 = 3
    大蝴蝶 = 4
    幽灵 = 5
    乌鸦 = 6
    Boss = 100
End Enum