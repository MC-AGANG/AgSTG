Imports ResourcePack
Imports System.Math
''' <summary>
''' 表示玩家的子弹
''' 此类只能作为继承类使用
''' </summary>
Public MustInherit Class PlayerBullet
    Inherits GameObject
    Public Property Damage As Double
    Public Property Speed As Double
    Public Property Direction As Double
    Public Sub New(X As Double, Y As Double)
        MyBase.New(ObjectType.PlayerBullet, X, Y)
    End Sub
    Private FadeOutFrame As Byte = 0
    Private Sub Judge()
        If IsEnabled Then
            For Each obj In STG.SearchEnemy
                If obj.IsEnabled AndAlso IsHit(obj) Then
                    obj.Damage(Damage)
                    IsEnabled = False
                    FadeOutFrame = 1
                    STG.Score += Damage * 10
                    If obj.HP > 256 Then
                        Sounds.PlaySound(Sounds.damage00, 0.1)
                    Else
                        Sounds.PlaySound(Sounds.damage01, 0.1)
                    End If
                End If
            Next
        End If
        If Y < -32 OrElse X > 400 OrElse X < -16 OrElse Y > 480 Then
            Clear()
        End If
    End Sub
    Private Sub PlayerBullet_Move()
        X += Speed * Sin(Direction / 180 * PI)
        Y -= Speed * Cos(Direction / 180 * PI)
        Me_Rotate.Angle = Direction
    End Sub
    ''' <summary>
    ''' 灵梦主炮子弹
    ''' </summary>
    Public Class Pl0M
        Inherits PlayerBullet
        Public Sub New(X As Double, Y As Double)
            MyBase.New(X, Y)
            SetSize(16, 64, 8)
            Damage = 4
            Opacity = 0.8
            Speed = 24
        End Sub
        Public Overrides Sub Render()
            If FadeOutFrame = 0 Then
                Judge()
                Background = Textures.player_bullet(0, 0, (FrameCount \ 2) Mod 2)
            Else
                FadeOut()
            End If
            PlayerBullet_Move()
        End Sub
        Private Sub FadeOut()
            If FadeOutFrame = 1 Then
                Speed = 3
            End If
            Background = Textures.player_bullet(0, 0, (FadeOutFrame \ 4) + 1)
            FadeOutFrame += 1
            If FadeOutFrame > 16 Then
                Clear()
            End If
        End Sub
    End Class
    Public Class Pl0F
        Inherits PlayerBullet
        Public Sub New(X As Double, Y As Double, Direction As Double)
            MyBase.New(X, Y)
            Me.Direction = Direction
            SetSize(16, 16, 8)
            Damage = 4
            Speed = 2
            Background = Textures.player_bullet(0, 1, 0)
            Opacity = 0.75
        End Sub
        Public Overrides Sub Render()
            If FadeOutFrame = 0 Then
                Dim Target As Enemy = Nothing
                Dim targetdistanceistance As Double = 9999999
                For Each obj In STG.SearchEnemy
                    If GetDistance(obj) < targetdistanceistance Then
                        Target = obj
                        targetdistanceistance = GetDistance(obj)
                    End If
                Next
                If Not IsNothing(Target) Then
                    If Cos(Direction / 180 * PI) > -0.8 Then
                        Dim vec1 As New Vector(Target.X - X, Target.Y - Y)
                        Dim vec2 As New Vector(Speed * Sin(Direction / 180 * PI), -Speed * Cos(Direction / 180 * PI))
                        Direction -= (600 - vec1.Length) / 150 * Sign(Vector.AngleBetween(vec1, vec2))
                    End If
                End If
                Speed += 0.1
                Judge()
            Else
                Fadeout()
            End If
            PlayerBullet_Move()
        End Sub
        Private Sub Fadeout()
            If FadeOutFrame < 6 Then
                Background = Textures.player_bullet(0, 1, (FadeOutFrame \ 2) + 1)
                Me_Scale.ScaleX += 0.1
                Me_Scale.ScaleY += 0.1
                FadeOutFrame += 1
                Layer1.Opacity -= 0.05
            Else
                Clear()
            End If

        End Sub
    End Class
    Public Class Pl0S
        Inherits PlayerBullet
        Public Sub New(X As Double, Y As Double)
            MyBase.New(X, Y)
            SetSize(16, 64, 8)
            Damage = 2
            Speed = 24
        End Sub
        Public Overrides Sub Render()
            If FadeOutFrame = 0 Then
                Judge()
                Background = Textures.player_bullet(0, 2, (FrameCount \ 2) Mod 2)
            Else
                FadeOut()
            End If
            PlayerBullet_Move()
        End Sub
        Private Sub FadeOut()
            If FadeOutFrame = 1 Then
                Speed = 3
                Me_Rotate.Angle = (Rnd() * 30) - 15
                Opacity = 0.8
            End If
            Opacity -= 0.05
            FadeOutFrame += 1
            If FadeOutFrame > 16 Then
                Clear()
            End If
        End Sub
    End Class
    Public Class Pl0B
        Inherits PlayerBullet
        Private ID As Byte
        Private CenterX As Double
        Private CenterY As Double
        Public Sub New(X As Double, Y As Double, ID As Byte)
            MyBase.New(X, Y)
            Me.ID = ID
            SetSize(128, 128, 56)
            CenterX = STG.Player.X
            CenterY = STG.Player.Y
            Damage = 100
            Speed = 2
            Layer1.Fill = Textures.player_bullet(0, 3, 2)
            Layer2.Fill = Textures.player_bullet(0, 3, 1)
            Layer3.Fill = Textures.player_bullet(0, 3, 0)
            Layer2.Opacity = 0.8
            Layer3.Opacity = 0.8
            Direction = 45 * ID
            Layer1_rotate.CenterX = 64
            Layer1_rotate.CenterY = 64
            Layer2_rotate.CenterX = 64
            Layer2_rotate.CenterY = 64
            Layer3_rotate.CenterX = 64
            Layer3_rotate.CenterY = 64
            Layer1_scale.CenterX = 64
            Layer1_scale.CenterY = 64
            Layer2_scale.CenterX = 64
            Layer2_scale.CenterY = 64
            Layer3_scale.CenterX = 64
            Layer3_scale.CenterY = 64
            Layer1.Width = 128
            Layer2.Width = 128
            Layer3.Width = 128
            Layer1.Height = 128
            Layer2.Height = 128
            Layer3.Height = 128
        End Sub
        Public Overrides Sub Render()
            Dim Distance As Vector
            Dim Target As Enemy = Nothing
            Dim targetdistance As Double = 114514
            If FadeOutFrame = 0 Then
                If FrameCount < 20 Then
                    X += STG.Player.X - CenterX
                    CenterX = STG.Player.X
                    Y += STG.Player.Y - CenterY
                    CenterY = STG.Player.Y
                ElseIf FrameCount = 20 Then
                    Direction += 90
                    Speed = 4
                    X += STG.Player.X - CenterX
                    CenterX = STG.Player.X
                    Y += STG.Player.Y - CenterY
                    CenterY = STG.Player.Y
                ElseIf FrameCount > 20 AndAlso FrameCount <= (100 + 10 * ID) Then
                    Direction += 2
                    X += STG.Player.X - CenterX
                    CenterX = STG.Player.X
                    Y += STG.Player.Y - CenterY
                    CenterY = STG.Player.Y
                ElseIf FrameCount = 250 Then
                    FadeOutFrame = 1
                    Layer1.Opacity = 0
                ElseIf FrameCount > 20 Then
                    For Each tenemy In STG.SearchEnemy
                        If tenemy.IsEnabled Then
                            Distance = New Vector(tenemy.X - X, tenemy.Y - (Y - 16))
                            If IsHit(tenemy) Then
                                FadeOutFrame = 1
                                Speed = 0
                                tenemy.Damage(Damage)
                                STG.ShakeFrame = 30
                            Else
                                If Distance.Length < targetdistance Then
                                    Target = tenemy
                                    targetdistance = Distance.Length
                                End If
                            End If
                        End If
                    Next
                    If Not IsNothing(Target) Then
                        Distance = New Vector(Target.X - X, Target.Y - Y)
                        Direction = Vector.AngleBetween(Distance, New Vector(0, 1))
                    End If
                End If
                Layer1_rotate.Angle += 2
                Layer2_rotate.Angle += 5
                Layer3_rotate.Angle += 5
                Layer2_translate.X = Sin((FrameCount - ID) / 10) * 16
                Layer2_translate.Y = Cos((FrameCount - ID) / 8) * 16
                Layer3_translate.X = -Sin((FrameCount - ID) / 8) * 16
                Layer3_translate.Y = -Cos((FrameCount - ID) / 10) * 16
                X += Speed * Sin(Direction / 180 * PI)
                Y += Speed * Cos(Direction / 180 * PI)
                Canvas.SetLeft(Me, X - Width / 2)
                Canvas.SetTop(Me, Y - Height / 2)
                For Each tenbullet In STG.SearchBullet
                    If tenbullet.IsEnabled Then
                        Distance = New Vector(tenbullet.X - X, tenbullet.Y - Y)
                        If IsHit(tenbullet) Then
                            tenbullet.Break()
                        End If
                    End If
                Next
            ElseIf FadeOutFrame <= 16 Then
                If FadeOutFrame = 1 Then
                    For Each tenemy In STG.SearchEnemy
                        If tenemy.IsEnabled Then
                            Distance = New Vector(tenemy.X - X, tenemy.Y - (Y - 16))
                            If Distance.Length - 80 - tenemy.HitboxSize < 0 Then
                                tenemy.Damage(Damage)
                            End If
                        End If
                    Next
                    Sounds.PlaySound(Sounds.tan00)
                End If
                Layer2_translate.X = Sin((FrameCount - FadeOutFrame) / 10) * FadeOutFrame * 2
                Layer2_translate.Y = Cos((FrameCount - FadeOutFrame) / 10) * FadeOutFrame * 2
                Layer3_translate.X = -Sin((FrameCount - FadeOutFrame) / 10) * FadeOutFrame * 2
                Layer3_translate.Y = -Cos((FrameCount - FadeOutFrame) / 10) * FadeOutFrame * 2
                Layer2_scale.ScaleX -= 0.045
                Layer2_scale.ScaleY -= 0.045
                Layer3_scale.ScaleX -= 0.045
                Layer3_scale.ScaleY -= 0.045
                FadeOutFrame += 1
                Layer1_scale.ScaleX += 0.2
                Layer1_scale.ScaleY += 0.2
                Layer1.Opacity -= 0.05
            ElseIf FadeOutFrame < 32 Then
                Layer2.Opacity -= 0.05
                Layer3.Opacity -= 0.05
                Layer1_scale.ScaleX += 0.1
                Layer1_scale.ScaleY += 0.1
                Layer1.Opacity -= 0.05
                FadeOutFrame += 1
            Else
                Clear()
            End If
        End Sub
    End Class
    Public Class PL1M
        Inherits PlayerBullet
        Public Sub New(X As Double, Y As Double)
            MyBase.New(X, Y)
            SetSize(16, 32, 8)
            Damage = 5
            Opacity = 0.8
            Speed = 24
        End Sub
        Public Overrides Sub Render()
            If FadeOutFrame = 0 Then
                Judge()
                Background = Textures.player_bullet(0, 0, (FrameCount \ 2) Mod 2)
            Else
                FadeOut()
            End If
            PlayerBullet_Move()
        End Sub
        Private Sub FadeOut()
            If FadeOutFrame = 1 Then
                Speed = 3
            End If
            Background = Textures.player_bullet(0, 0, (FadeOutFrame \ 4) + 1)
            FadeOutFrame += 1
            If FadeOutFrame > 16 Then
                Clear()
            End If
        End Sub
    End Class
End Class
