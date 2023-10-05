Imports ResourcePack
Imports System.Math
''' <summary>
''' 表示子机
''' 此类只能作为继承类使用
''' </summary>
Public MustInherit Class PlayerOption
    Inherits GameObject
    Public Property PlayerType As PlayerType
    Private Property ID As Byte
    Private presetx(,) As Double
    Private presety(,) As Double
    Private presetxs(,) As Double
    Private presetys(,) As Double
    Private presetdirection(,) As Double
    Public MustOverride Sub Shoot()
    ''' <summary>
    ''' 创建新的子机
    ''' 这个方法通常由Player执行
    ''' </summary>
    Public Sub New(id As Byte)
        MyBase.New(ObjectType.PlayerOption, 0, 0)
        Me.ID = id
        SetSize(16, 16, 0)
    End Sub

    Private Sub Option_Move()
        If KeyState.Slow Then
            If STG.Player.SlowFrame <= 10 Then
                X = STG.Player.X + ((10 - STG.Player.SlowFrame) * presetx((STG.Power \ 100) - 1, ID) + STG.Player.SlowFrame * presetxs((STG.Power \ 100) - 1, ID)) / 10
                Y = STG.Player.Y + ((10 - STG.Player.SlowFrame) * presety((STG.Power \ 100) - 1, ID) + STG.Player.SlowFrame * presetys((STG.Power \ 100) - 1, ID)) / 10
            Else
                X = STG.Player.X + presetxs((STG.Power \ 100) - 1, ID)
                Y = STG.Player.Y + presetys((STG.Power \ 100) - 1, ID)
            End If
        Else
            If STG.Player.SlowFrame > 0 AndAlso STG.Player.SlowFrame < 10 Then
                X = STG.Player.X + ((10 - STG.Player.SlowFrame) * presetx((STG.Power \ 100) - 1, ID) + STG.Player.SlowFrame * presetxs((STG.Power \ 100) - 1, ID)) / 10
                Y = STG.Player.Y + ((10 - STG.Player.SlowFrame) * presety((STG.Power \ 100) - 1, ID) + STG.Player.SlowFrame * presetys((STG.Power \ 100) - 1, ID)) / 10
            ElseIf STG.Player.SlowFrame = 0 Then
                X = STG.Player.X + presetx((STG.Power \ 100) - 1, ID)
                Y = STG.Player.Y + presety((STG.Power \ 100) - 1, ID)
            End If
        End If
    End Sub
    ''' <summary>
    ''' 灵梦子机
    ''' </summary>
    Public Class Option0
        Inherits PlayerOption
        Public Sub New(id As Byte)
            MyBase.New(id)
            PlayerType = PlayerType.灵梦
            Layer1.Fill = Textures.player_option(0)
            Layer2.Fill = Textures.player_option(0)
            Layer1.Width = 16
            Layer1.Height = 16
            Layer2.Width = 16
            Layer2.Height = 16
            Layer1_scale.ScaleX = 1.2
            Layer1_scale.ScaleY = 1.2
            Layer1.Opacity = 0.5
            presetx = {
                {0, 0, 0, 0},
                {-32, 32, 0, 0},
                {-32, 0, 32, 0},
                {-40, -16, 16, 40}
            }
            presety = {
                {-32, 0, 0, 0},
                {0, 0, 0, 0},
                {16, 32, 16, 0},
                {16, 32, 32, 16}
            }
            presetxs = {
                {0, 0, 0, 0},
                {-16, 16, 0, 0},
                {-16, 0, 16, 0},
                {-16, -8, 8, 16}
            }
            presetys = {
                {-20, 0, 0, 0},
                {-20, -20, 0, 0},
                {-20, -32, -20, 0},
                {-24, -32, -32, -24}
            }
            presetdirection = {
                {0, 0, 0, 0},
                {-25, 25, 0, 0},
                {-30, 0, 30, 0},
                {-45, -15, 15, 45}
            }
        End Sub
        Public Overrides Sub Render()
            Layer1_rotate.Angle = (-FrameCount * 4) Mod 360
            Layer2_rotate.Angle = (FrameCount * 2) Mod 360
            Option_Move()
            If (STG.Power \ 100) - 1 >= ID Then
                Opacity = 1
            Else
                Opacity = 0
            End If
        End Sub
        Public Overrides Sub Shoot()
            If KeyState.Slow Then
                STG.Objects_Add.Add(New PlayerBullet.Pl0S(X - 4, Y))
                STG.Objects_Add.Add(New PlayerBullet.Pl0S(X + 4, Y))
            ElseIf STG.Player.ShootFrame Mod 8 = 0 Then
                STG.Objects_Add.Add(New PlayerBullet.Pl0F(X, Y, presetdirection((STG.Power \ 100) - 1, ID)))
            End If

        End Sub
    End Class
    Public Class Option1
        Inherits PlayerOption
        Public Sub New(id As Byte)
            MyBase.New(id)
            PlayerType = PlayerType.魔理沙
            Layer1.Fill = Textures.player_option(1)
            Layer1.Width = 16
            Layer1.Height = 16
            presetx = {
                {0, 0, 0, 0},
                {-16, 16, 0, 0},
                {-32, 0, 32, 0},
                {-32, -16, 16, 32}
            }
            presety = {
                {-32, 0, 0, 0},
                {-32, -32, 0, 0},
                {0, -32, 0, 0},
                {0, -32, -32, 0}
            }
            presetxs = {
                {0, 0, 0, 0},
                {-8, 8, 0, 0},
                {-12, 0, 12, 0},
                {-20, -8, 8, 20}
            }
            presetys = {
                {-20, 0, 0, 0},
                {-20, -20, 0, 0},
                {-20, -32, -20, 0},
                {-24, -32, -32, -24}
            }
            presetdirection = {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {-5, 0, 5, 0},
                {-5, 0, 0, 5}
            }
        End Sub
        Public Overrides Sub Shoot()
            Throw New NotImplementedException()
        End Sub

        Public Overrides Sub Render()
            Layer1_scale.ScaleX = Sin(FrameCount / 10) * 0.1 + 1
            Layer1_scale.ScaleY = Sin(FrameCount / 10) * 0.1 + 1
            If (STG.Power \ 100) - 1 >= ID Then
                Opacity = 1
            Else
                Opacity = 0
            End If
        End Sub
    End Class
End Class
