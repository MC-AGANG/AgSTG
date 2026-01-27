Imports ResourcePack
Imports System.Math
''' <summary>
''' 表示自机
''' 此类只能作为继承类使用
''' </summary>
Public MustInherit Class Player
    Inherits GameObject
    ''' <summary>
    ''' 获取或设置自机无敌帧的剩余时间
    ''' </summary>
    ''' <returns></returns>
    Public Property Invin As Integer = 0
    ''' <summary>
    ''' 获取或设置机体高速状态下的移速
    ''' </summary>
    ''' <returns></returns>
    Public Property Speed As Double
    ''' <summary>
    ''' 获取或设置机体类型
    ''' </summary>
    ''' <returns></returns>
    Public Property PlayerType As PlayerType
    ''' <summary>
    ''' 包含所有的子机
    ''' </summary>
    Public Options(3) As PlayerOption
    Public SlowFrame As Integer
    Public ShootFrame As Integer
    Public SpellFrame As Integer
    Private XMoveFrame As SByte
    Private FadeOutFrame As Byte
    Private GrazeParticles As New List(Of GrazeParticle)
    Private rm_GrazeParticles As New List(Of GrazeParticle)

    ''' <summary>
    ''' 创建新的自机，此类通常由STG创建
    ''' </summary>
    Public Sub New()
        MyBase.New(ObjectType.Player, 192, 464)
        Layer1.Width = 32
        Layer1.Height = 48
        Canvas.SetLeft(Layer1, 16)
        Canvas.SetTop(Layer1, 8)
        Layer2.Fill = Textures.player_hitbox
        Layer2.Width = 64
        Layer2.Height = 64
        Layer3.Fill = Textures.player_hitbox
        Layer3.Width = 64
        Layer3.Height = 64
        Invin = 120
        Layer2.Opacity = 0
        Layer3.Opacity = 0
        IsEnabled = False
    End Sub
    ''' <summary>
    ''' 触发撞弹
    ''' </summary>
    Public Sub Miss()
        Sounds.PlaySound(Sounds.pldead00)
        FadeOutFrame = 1
        Background = Textures.deadcircle
        IsEnabled = False
        Layer1.Visibility = Visibility.Hidden
        Layer2.Visibility = Visibility.Hidden
        Layer3.Visibility = Visibility.Hidden
        STG.bonusfail = True
    End Sub
    ''' <summary>
    ''' 触发擦弹
    ''' </summary>
    Public Sub Graze()
        Dim gp As New GrazeParticle
        GrazeParticles.Add(gp)
        MainBoard.Children.Add(gp.Rec)
        gp.Rec.Height = 8
        gp.Rec.Width = 8
        gp.Rec.Fill = Textures.graze(Int(Rnd() * 4))
        Canvas.SetLeft(gp.Rec, 28)
        Canvas.SetTop(gp.Rec, 28)
        gp.Rec.Opacity = 0.5
        STG.Graze += 1
        If STG.Graze Mod 10 = 0 Then
            STG.PointValue += 10
        End If
        Sounds.PlaySound(Sounds.graze)
    End Sub
    Private Sub GrazeMove()
        For Each gp In GrazeParticles
            gp.Ticks += 1
            Canvas.SetLeft(gp.Rec, 28 + gp.Ticks * 4 * Sin(gp.Direction / 180 * PI))
            Canvas.SetTop(gp.Rec, 28 + gp.Ticks * 4 * Cos(gp.Direction / 180 * PI))
            gp.Rec.Opacity = (16 - gp.Ticks) / 32
            If gp.Ticks > 16 Then
                rm_GrazeParticles.Add(gp)
            End If
        Next
        For Each gp In rm_GrazeParticles
            GrazeParticles.Remove(gp)
            MainBoard.Children.Remove(gp.Rec)
        Next
        rm_GrazeParticles.Clear()
    End Sub
    Public Sub Fadeout()
        If FadeOutFrame > 0 Then
            Me_Scale.ScaleX = 1 + FadeOutFrame / 15
            Me_Scale.ScaleY = 1 + FadeOutFrame / 15
            Opacity = (30 - FadeOutFrame) / 30
            FadeOutFrame += 1
            If FadeOutFrame = 30 Then
                Layer1.Visibility = Visibility.Visible
                Layer2.Visibility = Visibility.Visible
                Layer3.Visibility = Visibility.Visible
                Background = Nothing
                Me_Scale.ScaleX = 1
                Me_Scale.ScaleY = 1
                Ticks = 0
                FadeOutFrame = 0
                Opacity = 1
                Invin = 120
                STG.ClearBullet()
                If STG.Life > 0 Then
                    STG.Life -= 1
                End If
                STG.Spell = 3
            End If
        End If
    End Sub
    Private Sub Player_Move()
        GrazeMove()
        If Ticks <= 40 Then
            Y = 464 - (Ticks * 2)
            If Ticks = 40 Then
                IsEnabled = True
            End If
        ElseIf FadeOutFrame = 0 Then
            If KeyState.Slow Then
                If KeyState.Up Then
                    If KeyState.Left Then
                        X -= Speed * 0.35
                        Y -= Speed * 0.35
                    ElseIf KeyState.Right Then
                        X += Speed * 0.35
                        Y -= Speed * 0.35
                    Else
                        Y -= Speed * 0.5
                    End If
                ElseIf KeyState.Down Then
                    If KeyState.Left Then
                        X -= Speed * 0.35
                        Y += Speed * 0.35
                    ElseIf KeyState.Right Then
                        X += Speed * 0.35
                        Y += Speed * 0.35
                    Else
                        Y += Speed * 0.5
                    End If
                ElseIf KeyState.Left Then
                    X -= Speed * 0.5
                ElseIf KeyState.Right Then
                    X += Speed * 0.5
                End If
            Else
                If KeyState.Up Then
                    If KeyState.Left Then
                        X -= Speed * 0.7
                        Y -= Speed * 0.7
                    ElseIf KeyState.Right Then
                        X += Speed * 0.7
                        Y -= Speed * 0.7
                    Else
                        Y -= Speed
                    End If
                ElseIf KeyState.Down Then
                    If KeyState.Left Then
                        X -= Speed * 0.7
                        Y += Speed * 0.7
                    ElseIf KeyState.Right Then
                        X += Speed * 0.7
                        Y += Speed * 0.7
                    Else
                        Y += Speed
                    End If
                ElseIf KeyState.Left Then
                    X -= Speed
                ElseIf KeyState.Right Then
                    X += Speed
                End If
            End If
            If X < 16 Then X = 16
            If Y < 24 Then Y = 24
            If X > 368 Then X = 368
            If Y > 424 Then Y = 424
        Else
            Fadeout()
        End If
    End Sub
    Private Sub Appearance()
        If Invin > 0 Then
            If Invin Mod 8 = 0 Then
                Layer1.Opacity = 0.5
            ElseIf Invin Mod 4 = 0 Then
                Layer1.Opacity = 1
            End If
            Invin -= 1
        End If
        If KeyState.Left Then
            If XMoveFrame >= -4 Then
                XMoveFrame -= 1
            End If
        ElseIf KeyState.Right Then
            If XMoveFrame <= 4 Then
                XMoveFrame += 1
            End If
        Else
            If XMoveFrame < 0 Then
                XMoveFrame += 1
            ElseIf XMoveFrame > 0 Then
                XMoveFrame -= 1
            End If
        End If
        If XMoveFrame > 0 Then
            If XMoveFrame <= 4 Then
                Layer1.Fill = Textures.player(PlayerType, 2, XMoveFrame - 1)
            Else
                If Ticks Mod 4 = 0 Then
                    Layer1.Fill = Textures.player(PlayerType, 2, ((Ticks \ 4) Mod 4) + 4)
                End If
            End If
        ElseIf XMoveFrame < 0 Then
            If XMoveFrame >= -4 Then
                Layer1.Fill = Textures.player(PlayerType, 1, Abs(XMoveFrame) - 1)
            Else
                If Ticks Mod 4 = 0 Then
                    Layer1.Fill = Textures.player(PlayerType, 1, ((Ticks \ 4) Mod 4) + 4)
                End If
            End If
        Else
            If Ticks Mod 4 = 0 Then
                Layer1.Fill = Textures.player(PlayerType, 0, (Ticks \ 4) Mod 8)
            End If
        End If
        If KeyState.Slow Then
            Layer2_rotate.Angle = Ticks Mod 360
            Layer3_rotate.Angle = -Ticks Mod 360
            If SlowFrame <= 10 Then
                Layer2.Opacity = SlowFrame / 10
                Layer2_scale.ScaleX = SlowFrame / 8
                Layer2_scale.ScaleY = SlowFrame / 8
                Layer3.Opacity = SlowFrame / 16
                SlowFrame += 1
            ElseIf SlowFrame = 11 Then
                Layer2.Opacity = 0.87
                Layer3.Opacity = 0.7
                Layer2_scale.ScaleX = 1.125
                Layer2_scale.ScaleY = 1.125
                SlowFrame += 1
            ElseIf SlowFrame = 12 Then
                Layer2.Opacity = 0.75
                Layer3.Opacity = 0.75
                Layer2_scale.ScaleX = 1
                Layer2_scale.ScaleY = 1
                SlowFrame += 1
            End If
        ElseIf SlowFrame > 0 Then
            Layer2_rotate.Angle = Ticks Mod 360
            Layer3_rotate.Angle = -Ticks Mod 360
            SlowFrame -= 1
            Layer2_scale.ScaleX = SlowFrame / 10
            Layer2_scale.ScaleY = SlowFrame / 10
            Layer2.Opacity = SlowFrame / 10
            Layer3.Opacity = SlowFrame / 16
        End If
    End Sub
    Private Class GrazeParticle
        Public Property Direction As Double
        Public Property X As Double
        Public Property Y As Double
        Public Property Ticks As Integer = 0
        Public Rec As Rectangle
        Public Sub New()
            Direction = Rnd() * 360
            Rec = New Rectangle

        End Sub
    End Class
    ''' <summary>
    ''' 灵梦机体
    ''' </summary>
    Public Class Player0
        Inherits Player
        Public Sub New()
            MyBase.New
            SetSize(64, 64, 1)
            Speed = 4
            For i = 0 To 3
                Options(i) = New PlayerOption.Option0(i)
                STG.Objects.Add(Options(i))
            Next
        End Sub
        Public Overrides Sub Render()
            Appearance()
            Player_Move()
            If STG.DialogArea.Visibility = Visibility.Hidden Then
                Shoot()
            End If
        End Sub
        Private Sub Shoot()
            If KeyState.Shoot OrElse (ShootFrame > 0 AndAlso ShootFrame <= 36) Then
                If ShootFrame Mod 4 = 0 Then
                    STG.Objects_Add.Add(New PlayerBullet.Pl0M(X - 8, Y))
                    STG.Objects_Add.Add(New PlayerBullet.Pl0M(X + 8, Y))
                    For i = 0 To (STG.Power \ 100) - 1
                        Options(i).Shoot()
                    Next
                End If
                ShootFrame += 1
                Sounds.PlaySound(Sounds.plst00, 0.1)
            ElseIf ShootFrame > 0 Then
                ShootFrame = 0
            End If
            If KeyState.Bomb Then
                Spell()
            End If
            If SpellFrame > 0 Then
                SpellFrame -= 1
            End If
        End Sub
        Public Sub Spell()
            If STG.Spell > 0 AndAlso SpellFrame = 0 AndAlso FadeOutFrame <= 3 Then
                SpellFrame = 300
                Invin = 300
                STG.Spell -= 1
                For i = 0 To 7
                    STG.Objects_Add.Add(New PlayerBullet.Pl0B(X, Y, i))
                Next
                If FadeOutFrame > 0 Then
                    Layer1.Visibility = Visibility.Visible
                    Layer2.Visibility = Visibility.Visible
                    Layer3.Visibility = Visibility.Visible
                    Background = Nothing
                    Me_Scale.ScaleX = 1
                    Me_Scale.ScaleY = 1
                    FadeOutFrame = 0
                End If
                STG.bonusfail = True
            End If
        End Sub
    End Class
    Public Class Player1
        Inherits Player
        Public Sub New()
            MyBase.New
            PlayerType = PlayerType.魔理沙
            SetSize(64, 64, 1.5)
            Speed = 4
            For i = 0 To 3
                Options(i) = New PlayerOption.Option1(i)
                STG.Objects.Add(Options(i))
            Next
        End Sub
        Public Overrides Sub Render()
            Appearance()
            Player_Move()
            If STG.DialogArea.Visibility = Visibility.Hidden Then
                Shoot()
            End If
        End Sub
        Private Sub Shoot()
            If KeyState.Shoot OrElse (ShootFrame > 0 AndAlso ShootFrame <= 36) Then
                If ShootFrame Mod 4 = 0 Then
                    STG.Objects_Add.Add(New PlayerBullet.PL1M(X - 8, Y - 16))
                    STG.Objects_Add.Add(New PlayerBullet.PL1M(X + 8, Y - 16))
                End If
                ShootFrame += 1
                Sounds.PlaySound(Sounds.plst00, 0.1)
            ElseIf ShootFrame > 0 Then
                ShootFrame = 0
            End If
            If KeyState.Shoot Then
                For i = 0 To (STG.Power \ 100) - 1
                    Options(i).Shoot()
                Next
            End If
            If KeyState.Bomb Then
                Spell()
            End If
            If SpellFrame > 0 Then
                SpellFrame -= 1
            End If
        End Sub
        Public Sub Spell()
            If STG.Spell > 0 AndAlso SpellFrame = 0 AndAlso FadeOutFrame <= 3 Then
                SpellFrame = 300
                Invin = 300
                STG.Spell -= 1
                STG.Objects_Add.Add(New PlayerBullet.PL1B(X, Y))
                Sounds.PlaySound(Sounds.nep00)
                Sounds.PlaySound(Sounds.slash)
                If FadeOutFrame > 0 Then
                    Layer1.Visibility = Visibility.Visible
                    Layer2.Visibility = Visibility.Visible
                    Layer3.Visibility = Visibility.Visible
                    Background = Nothing
                    Me_Scale.ScaleX = 1
                    Me_Scale.ScaleY = 1
                    FadeOutFrame = 0
                End If
                STG.bonusfail = True
            End If
        End Sub
    End Class
End Class
''' <summary>
''' 枚举机体类型
''' </summary>
Public Enum PlayerType As Byte
    灵梦 = 0
    魔理沙 = 1
End Enum