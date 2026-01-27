Imports ResourcePack
Imports System.Math
''' <summary>
''' 表示敌机子弹
''' </summary>
Public Class Bullet
    Inherits GameObject
    ''' <summary>
    ''' 获取或设置子弹种类
    ''' </summary>
    ''' <returns></returns>
    Public Property BulletType As Byte
    ''' <summary>
    ''' 获取或设置子弹颜色
    ''' </summary>
    ''' <returns></returns>
    Public Property BulletColor As Byte
    ''' <summary>
    ''' 获取或设置子弹速度
    ''' </summary>
    ''' <returns></returns>
    Public Property Speed As Double
    ''' <summary>
    ''' 获取或设置子弹方向，单位：角度
    ''' 以向上为0度，顺时针递增
    ''' </summary>
    ''' <returns></returns>
    Public Property Direction As Double
    ''' <summary>
    ''' 获取或设置子弹生成时播放的音效
    ''' 默认为“tan00.wav”
    ''' </summary>
    ''' <returns></returns>
    Public Property SoundEffect As MediaPlayer
    ''' <summary>
    ''' 获取或设置这个子弹是否已经擦弹过了
    ''' </summary>
    ''' <returns></returns>
    Public Property Grazed As Boolean = False
    ''' <summary>
    ''' 控制子弹行为的方法
    ''' 可在创建时使用with语句添加
    ''' </summary>
    Public Act As Action
    Private FadeOutFrame As Byte
    ''' <summary>
    ''' 创建新的子弹
    ''' </summary>
    ''' <param name="BulletType">子弹种类</param>
    ''' <param name="BulletColor">子弹颜色</param>
    ''' <param name="X">初始X坐标</param>
    ''' <param name="Y">初始Y坐标</param>
    ''' <param name="Speed">子弹速度</param>
    ''' <param name="Direction">子弹方向</param>
    ''' <param name="Delta">随机附加的方向偏移量，默认为0</param>
    Public Sub New(BulletType As BulletType, BulletColor As BulletColor, X As Double, Y As Double, Speed As Double, Direction As Double, Optional Delta As Double = 0)
        MyBase.New(ObjectType.Bullet, X, Y)
        Me.BulletType = BulletType
        Me.BulletColor = BulletColor
        Me.Speed = Speed
        Me.Direction = Direction + Delta * Rnd() - Delta / 2
        InitAppearance()
        IsEnabled = False
        Background = Textures.bulletin(BulletColor)
        Sounds.PlaySound(Sounds.tan00, 0.2)
    End Sub
    ''' <summary>
    ''' 创建一个自机狙子弹
    ''' </summary>
    ''' <param name="BulletType"></param>
    ''' <param name="BulletColor"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="Speed"></param>
    ''' <param name="Delta"></param>
    Public Sub New(BulletType As BulletType, BulletColor As BulletColor, X As Double, Y As Double, Speed As Double, Optional Delta As Double = 0)
        MyBase.New(ObjectType.Bullet, X, Y)
        Dim zerovec As New Vector(0, -1)
        Me.BulletType = BulletType
        Me.BulletColor = BulletColor
        Direction = Vector.AngleBetween(zerovec, New Vector(STG.Player.X - Me.X, STG.Player.Y - Me.Y)) + Delta
        Me.Speed = Speed
        InitAppearance()
        IsEnabled = False
        Background = Textures.bulletin(BulletColor)
        Sounds.PlaySound(Sounds.tan00, 0.2)
    End Sub
    ''' <summary>
    ''' 创建新的子弹，并指定音效
    ''' </summary>
    ''' <param name="BulletType">子弹种类</param>
    ''' <param name="BulletColor">子弹颜色</param>
    ''' <param name="X">初始X坐标</param>
    ''' <param name="Y">初始Y坐标</param>
    ''' <param name="Speed">子弹速度</param>
    ''' <param name="Direction">子弹方向</param>
    ''' <param name="SoundEffect">子弹生成时播放的音效</param>
    ''' <param name="Delta">随机附加的方向偏移量，默认为0</param>
    Public Sub New(BulletType As BulletType, BulletColor As BulletColor, X As Double, Y As Double, Speed As Double, Direction As Double, SoundEffect As MediaPlayer, Optional Delta As Double = 0)
        MyBase.New(ObjectType.Bullet, X, Y)
        Me.BulletType = BulletType
        Me.BulletColor = BulletColor
        Me.Speed = Speed
        Me.Direction = Direction + Delta * Rnd() - Delta / 2
        Me.SoundEffect = SoundEffect
        InitAppearance()
        IsEnabled = False
        Background = Textures.bulletin(BulletColor)
        If Not IsNothing(Me.SoundEffect) Then
            Sounds.PlaySound(Me.SoundEffect, 0.2)
        End If
    End Sub
    ''' <summary>
    ''' 创建一个自机狙子弹，并指定音效
    ''' </summary>
    ''' <param name="BulletType"></param>
    ''' <param name="BulletColor"></param>
    ''' <param name="X"></param>
    ''' <param name="Y"></param>
    ''' <param name="Speed"></param>
    ''' <param name="SoundEffect">子弹生成时播放的音效</param>
    ''' <param name="Delta"></param>
    Public Sub New(BulletType As BulletType, BulletColor As BulletColor, X As Double, Y As Double, Speed As Double, SoundEffect As MediaPlayer, Optional Delta As Double = 0)
        MyBase.New(ObjectType.Bullet, X, Y)
        Dim zerovec As New Vector(0, -1)
        Me.BulletType = BulletType
        Me.BulletColor = BulletColor
        Direction = Vector.AngleBetween(zerovec, New Vector(STG.Player.X - Me.X, STG.Player.Y - Me.Y)) + Delta
        Me.SoundEffect = SoundEffect
        Me.Speed = Speed
        InitAppearance()
        IsEnabled = False
        Background = Textures.bulletin(BulletColor)
        If Not IsNothing(Me.SoundEffect) Then
            Sounds.PlaySound(Me.SoundEffect, 0.2)
        End If
    End Sub
    Private Sub InitAppearance()
        Select Case BulletType
            Case 0
                Exit Select
            Case 1, 2, 3, 7
                SetSize(16, 16, 6)
                Exit Select
            Case 4, 5, 6, 8, 9, 10
                SetSize(16, 16, 3)
                Exit Select
            Case 11, 13, 15, 18
                SetSize(32, 32, 6)
                Exit Select
            Case 12, 16
                SetSize(32, 32, 8)
                Exit Select
            Case 14, 17
                SetSize(32, 32, 3)
                Me_Translate.Y = 8
                Exit Select
        End Select
    End Sub
    Public Overrides Sub Render()
        If Ticks <= 10 Then
            Opacity = (10 - Ticks) / 10
        ElseIf Ticks = 11 Then
            Opacity = 1
            Background = Textures.bullet(BulletType, BulletColor)
            IsEnabled = True
        ElseIf FadeOutFrame > 0 Then
            Background = Textures.bulletbreak(BulletColor, FadeOutFrame \ 4)
            Opacity = (32 - FadeOutFrame) / 32
            Me_Scale.ScaleX = 1 + FadeOutFrame / 16
            Me_Scale.ScaleY = 1 + FadeOutFrame / 16
            FadeOutFrame += 1
            If FadeOutFrame >= 32 Then
                Clear()
            End If
        End If
        If Not IsNothing(Act) AndAlso IsEnabled Then
            Act()
        End If
        X += Speed * Sin(Direction / 180 * PI)
        Y -= Speed * Cos(Direction / 180 * PI)
        Judge()
        If BulletType = 10 Or BulletType = 11 Then
            Me_Rotate.Angle += 8
        Else
            Me_Rotate.Angle = Direction
        End If

    End Sub
    Public Overridable Sub Judge()
        If IsEnabled Then
            If IsHit(STG.Player) AndAlso STG.Player.IsEnabled Then
                Break(True)
                IsEnabled = False
                If STG.Player.Invin = 0 Then
                    STG.Player.Miss()
                End If
            End If
            If GetDistance(STG.Player) < 32 + HitboxSize AndAlso Not Grazed Then
                STG.Player.Graze()
                Grazed = True
            End If
            If Y < -32 OrElse X > 400 OrElse X < -16 OrElse Y > 480 Then
                Clear()
            End If
        End If
    End Sub
    ''' <summary>
    ''' 消弹并产生信仰点
    ''' </summary>
    ''' <param name="Drop">消弹后是否产生信仰点，默认产生</param>
    Public Overridable Sub Break(Optional Drop As Boolean = True)
        IsEnabled = False
        FadeOutFrame = 1
        If Drop Then
            STG.Objects_Add.Add(New Item(ItemType.PointValue, X, Y))
        End If
    End Sub
    Public Class Laser
        Inherits Bullet
        Public Property LaserWidth As Double
        Public Property LaserLength As Double
        Public Property Life As Integer
        Public Sub New(BulletColor As BulletColor, X As Double, Y As Double, Direction As Double, Width As Double, Length As Double, Life As Integer)
            MyBase.New(AgSTG.BulletType.激光, BulletColor, X, Y, 0, Direction, Sounds.lazer00, 0)
            LaserWidth = Width
            LaserLength = Length
            SetSize(4, Length, 0)
            Background = Textures.bullet(0, BulletColor)
            Me_Rotate.Angle = Direction
            Me_Translate.Y = -Length
            Me.Life = Life
        End Sub
        Public Overrides Sub Render()
            If Ticks > 30 AndAlso Ticks <= 60 Then
                Width = (Ticks - 30) / 30 * LaserWidth
                Me_Translate.X = -Width / 2

                If Ticks = 60 Then
                    IsEnabled = True
                End If
            End If
            If FadeOutFrame = 0 AndAlso Ticks > 30 Then
                Opacity = 0.8 + 0.2 * Sin(Ticks)
            End If
            If FadeOutFrame = 0 AndAlso Ticks > Life Then
                Break(False)
            ElseIf FadeOutFrame > 0 Then
                FadeOutFrame += 1
                Width = (30 - FadeOutFrame) / 30
                Me_Translate.X = -Width / 2
                If FadeOutFrame = 30 Then
                    Clear()
                End If
            End If
            Judge()
        End Sub
        Public Overrides Sub Judge()
            If IsEnabled AndAlso STG.Player.IsEnabled Then
                Dim td, tx, ty As Double
                Direction = (Direction + 360) Mod 360
                If Direction > 90 AndAlso Direction < 270 Then
                    td = (Direction + 180) Mod 360
                    tx = X - (STG.Player.X - X)
                    ty = Y - (STG.Player.Y - Y)
                Else
                    td = Direction
                    tx = STG.Player.X
                    ty = STG.Player.Y
                End If
                If ty < Y - 0.125 * Height * Cos(td * PI / 180) AndAlso
                    ty > Y - 0.875 * Height * Cos(td * PI / 180) AndAlso
                    tx > X - 0.25 * Width * Cos(td * PI / 180) - Tan(td * PI / 180) * (ty - Y) AndAlso
                    tx < X + 0.25 * Width * Cos(td * PI / 180) - Tan(td * PI / 180) * (ty - Y) Then
                    STG.Player.Miss()
                ElseIf ty < Y AndAlso
                    ty > Y - Height * Cos(td * PI / 180) AndAlso
                    tx > X - 4 * Width * Cos(td * PI / 180) - Tan(td * PI / 180) * (ty - Y) AndAlso
                    tx < X + 4 * Width * Cos(td * PI / 180) - Tan(td * PI / 180) * (ty - Y) Then
                    If Ticks Mod 4 = 0 Then
                        STG.Player.Graze()
                    End If
                End If
            End If
        End Sub
        Public Overrides Sub Break(Optional Drop As Boolean = True)
            FadeOutFrame = 1
            IsEnabled = False
            If Drop Then

            End If
        End Sub
    End Class
End Class
''' <summary>
''' 枚举子弹种类
''' </summary>
Public Enum BulletType As Byte
    ''' <summary>
    ''' 请勿通过Bullet类创建激光，应使用Bullet.Laser
    ''' </summary>
    激光 = 0
    鳞弹 = 1
    环弹 = 2
    小玉 = 3
    米弹 = 4
    苦无 = 5
    棱弹 = 6
    札弹 = 7
    座药 = 8
    黑心弹 = 9
    小星弹 = 10
    星弹 = 11
    中玉 = 12
    蝶弹 = 13
    刀弹 = 14
    椭弹 = 15
    心弹 = 16
    箭头 = 17
    小光玉 = 18
End Enum
Public Enum BulletColor As Byte
    灰 = 0
    暗红 = 1
    红 = 2
    紫 = 3
    品红 = 4
    深蓝 = 5
    蓝 = 6
    青 = 7
    天蓝 = 8
    深绿 = 9
    绿 = 10
    黄绿 = 11
    土黄 = 12
    黄 = 13
    橙 = 14
    白 = 15
End Enum