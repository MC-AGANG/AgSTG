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
    Private FadeOutFrame As SByte = 0
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
                Background = Textures.player_bullet(0, 0, (Ticks \ 2) Mod 2)
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
                Background = Textures.player_bullet(0, 2, (Ticks \ 2) Mod 2)
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
                If Ticks < 20 Then
                    X += STG.Player.X - CenterX
                    CenterX = STG.Player.X
                    Y += STG.Player.Y - CenterY
                    CenterY = STG.Player.Y
                ElseIf Ticks = 20 Then
                    Direction += 90
                    Speed = 4
                    X += STG.Player.X - CenterX
                    CenterX = STG.Player.X
                    Y += STG.Player.Y - CenterY
                    CenterY = STG.Player.Y
                ElseIf Ticks > 20 AndAlso Ticks <= (100 + 10 * ID) Then
                    Direction += 2
                    X += STG.Player.X - CenterX
                    CenterX = STG.Player.X
                    Y += STG.Player.Y - CenterY
                    CenterY = STG.Player.Y
                ElseIf Ticks = 250 Then
                    FadeOutFrame = 1
                    Layer1.Opacity = 0
                ElseIf Ticks > 20 Then
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
                Layer2_translate.X = Sin((Ticks - ID) / 10) * 16
                Layer2_translate.Y = Cos((Ticks - ID) / 8) * 16
                Layer3_translate.X = -Sin((Ticks - ID) / 8) * 16
                Layer3_translate.Y = -Cos((Ticks - ID) / 10) * 16
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
                Layer2_translate.X = Sin((Ticks - FadeOutFrame) / 10) * FadeOutFrame * 2
                Layer2_translate.Y = Cos((Ticks - FadeOutFrame) / 10) * FadeOutFrame * 2
                Layer3_translate.X = -Sin((Ticks - FadeOutFrame) / 10) * FadeOutFrame * 2
                Layer3_translate.Y = -Cos((Ticks - FadeOutFrame) / 10) * FadeOutFrame * 2
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
            Background = Textures.player_bullet(1, 0, 0)
        End Sub
        Public Overrides Sub Render()
            If FadeOutFrame = 0 Then
                Judge()
            Else
                FadeOut()
            End If
            PlayerBullet_Move()
        End Sub
        Private Sub FadeOut()
            If FadeOutFrame = 1 Then
                Speed = 1
            End If
            Background = Textures.player_bullet(1, 0, (FadeOutFrame \ 4) + 1)
            FadeOutFrame += 1
            If FadeOutFrame > 12 Then
                Clear()
            End If
        End Sub
    End Class
    Public Class PL1F
        Inherits PlayerBullet
        Public cx, cy As Double
        Public OID As Integer
        Public Sub New(X As Double, Y As Double, Direction As Double)
            MyBase.New(X, Y - 8)
            Me.Direction = Direction
            SetSize(16, 32, 8)
            Damage = 2
            Speed = 16
            Opacity = 0.8
            cx = X
            cy = Y
        End Sub
        Public Overrides Sub Render()
            If FadeOutFrame = 0 Then
                Judge()
                If Not KeyState.Shoot Then
                    FadeOutFrame = -1
                End If
            Else
                Fadeout()
            End If
            If FadeOutFrame <= 0 Then
                X += STG.Player.Options(OID).X - cx
                cx = STG.Player.Options(OID).X
                Y += STG.Player.Options(OID).Y - cy
                cy = STG.Player.Options(OID).Y
                PlayerBullet_Move()
            End If

        End Sub
        Private Sub Fadeout()
            If FadeOutFrame > 0 Then
                If FadeOutFrame = 1 Then
                    Speed = 1
                    Background = Textures.player_bullet(1, 1, 8)
                End If
                If FadeOutFrame < 8 Then
                    Opacity -= 0.1
                    FadeOutFrame += 1
                Else
                    Clear()
                End If
            Else
                If FadeOutFrame > -8 Then
                    FadeOutFrame -= 1
                    Opacity -= 0.1
                Else
                    Clear()
                End If
            End If

        End Sub
    End Class
    Public Class PL1S
        Inherits PlayerBullet
        Public Sub New(X As Double, Y As Double)
            MyBase.New(X, Y)
            SetSize(16, 48, 8)
            Damage = 10
            Speed = 0
            Background = Textures.player_bullet(1, 2, 0)
            Opacity = 0.75
        End Sub
        Public Overrides Sub Render()
            If Ticks < 20 Then
                Speed += 0.4
            End If
            If FadeOutFrame = 0 Then
                Judge()
                If Ticks Mod 4 = 0 Then
                    Background = Textures.player_bullet(1, 2, (Ticks \ 4) Mod 2)
                End If
            Else
                FadeOut()
            End If
            PlayerBullet_Move()
        End Sub
        Private Sub FadeOut()
            If FadeOutFrame < 16 Then
                If FadeOutFrame = 1 Then
                    Speed = 1
                    SetSize(32, 32, 0)
                    Sounds.PlaySound(Sounds.msl2, 0.25)
                End If
                Background = Textures.player_bullet(1, 2, 2 + FadeOutFrame \ 2)
                FadeOutFrame += 1
                Me_Scale.ScaleX += 0.1
                Me_Scale.ScaleY += 0.1
                Opacity -= 0.05
            Else
                Clear()
            End If
        End Sub
    End Class
    Public Class PL1B
        Inherits PlayerBullet
        Public Sub New(X As Double, Y As Double)
            MyBase.New(X, Y)
            SetSize(256, 512, 0)
            Layer1.Fill = Textures.player_bullet(1, 3, 0)
            Layer2.Fill = Textures.player_bullet(1, 3, 1)
            Layer3.Fill = Textures.player_bullet(1, 3, 1)
            Layer2.VerticalAlignment = VerticalAlignment.Top
            Layer3.VerticalAlignment = VerticalAlignment.Top
            Layer2.Height = 160
            Layer3.Height = 160
            Layer1.Opacity = 0.5
            Layer1.Height = 512
            Layer1.Width = 256
            Layer1_translate.Y = -225
            Layer2.Width = 256
            Layer2.Height = 160
            Layer3.Width = 256
            Layer3.Height = 160
            Canvas.SetTop(Layer2, 0)
            Canvas.SetTop(Layer3, -256)
            STG.Player.Speed = 1
            Opacity = 0
            Damage = 10
        End Sub
        Public Overrides Sub Render()
            If Ticks < 10 Then
                Opacity += 0.1
            ElseIf Ticks < 250 Then
                For Each tenemy In STG.SearchEnemy
                    If tenemy.IsEnabled Then
                        If tenemy.Y < STG.Player.Y Then
                            If tenemy.X > X - 128 - Sin(Direction / 180 * PI) * (tenemy.Y - STG.Player.Y) AndAlso tenemy.X < X + 128 - Sin(Direction / 180 * PI) * (tenemy.Y - STG.Player.Y) Then
                                tenemy.Damage(Damage)
                            End If
                        End If
                    End If
                Next
                STG.ShakeFrame = 15
                For Each tenbullet In STG.SearchBullet
                    If tenbullet.IsEnabled Then
                        If tenbullet.Y < STG.Player.Y Then
                            If tenbullet.X > X - 128 - Sin(Direction / 180 * PI) * (tenbullet.Y - STG.Player.Y) AndAlso tenbullet.X < X + 128 - Sin(Direction / 180 * PI) * (tenbullet.Y - STG.Player.Y) Then
                                tenbullet.Break()
                            End If
                        End If
                    End If
                Next
            ElseIf Ticks < 270 Then
                Opacity -= 0.5
            Else
                STG.Player.Speed = 5
                Clear()
            End If
            If KeyState.Left Then
                If Direction >= -30 Then
                    Direction -= 0.2
                End If
            End If
            If KeyState.Right Then
                If Direction <= 30 Then
                    Direction += 0.2
                End If
            End If
            X = STG.Player.X
            Y = STG.Player.Y
            Canvas.SetTop(Layer2, 240 - (Ticks * 8 Mod 512))
            Canvas.SetTop(Layer3, 240 - ((Ticks * 8 + 256) Mod 512))
            If Canvas.GetTop(Layer2) >= 112 Then
                Layer2_scale.ScaleX = (240 - Canvas.GetTop(Layer2)) / 128
                Layer2.Opacity = (240 - Canvas.GetTop(Layer2)) / 128
            End If
            If Canvas.GetTop(Layer3) >= 112 Then
                Layer3_scale.ScaleX = (240 - Canvas.GetTop(Layer3)) / 128
                Layer3.Opacity = (240 - Canvas.GetTop(Layer3)) / 128
            End If
            PlayerBullet_Move()
        End Sub

    End Class
End Class
