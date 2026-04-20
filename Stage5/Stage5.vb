Imports System.Math
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports AgSTG
Imports ResourcePack.TH07
Public Class Stage5
    Inherits Stage
    Private BG As Stage5bg
    Public Shared EndFrame As Integer = 0
    Public Shared finished As Boolean = False
    Sub New(Difficulty As Difficulty)
        MyBase.New(Difficulty)

    End Sub
    Public Overrides Sub Initialize()
        Reset()
    End Sub

    Public Overrides Sub Action()
        EnemySpawn()
        BG.Render()
        If Ticks = 0 Then
            Showmusic("日常坐臥")
        End If
        If Ticks <= 100 Then
            BG.Opacity = Ticks / 100
        End If
        If EndFrame > 0 Then
            If EndFrame < 120 Then
                EndFrame += 1
                If EndFrame > 20 Then
                    BG.Opacity = (120 - EndFrame) / 100
                End If
            Else
                EndFrame = 0
                STG.NextStage()
            End If
        End If
        If finished AndAlso STG.DialogArea.Finished Then
            EndFrame = 1
            finished = False
        End If
    End Sub
    Public Overrides Sub Reset()
        MyBase.Reset()
        Background = New Stage5bg
        BG = Background
        finished = False
        EndFrame = 0
    End Sub
    Private Sub EnemySpawn()
        Select Case Ticks
            Case 120
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S5B7I), .Act = New Action(AddressOf .S5B7A)})
        End Select
    End Sub
End Class
Public Class B7S0
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 2800
        SpellTime = 2400
        Score = 6000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "人智剑「天女返」"
    End Sub

    Public Overrides Sub Render()
        MyBase.Render()
        Static c As Double = 0
        If Ticks = 0 Then
            Owner.IsEnabled = True
            c = 0
        End If
        Dim t As Integer = Ticks Mod 240
        If Ticks > 60 Then
            Select Case t
                Case 60
                    Owner.MoveTo(STG.Player.X, STG.Player.Y, 60)
                Case 120
                    c = Rnd() * 360
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.蓝, Owner.X, Owner.Y, c, 16, 64, 150))
                Case 150
                    Dim tx As Double = Owner.X + 56 * Sin(c / 180 * PI)
                    Dim ty As Double = Owner.Y - 56 * Cos(c / 180 * PI)
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.蓝, tx, ty, Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - tx, STG.Player.Y - ty)), 16, 512, 120))
                    For i = 0 To 340 Step 20
                        STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.蓝, tx, ty, 2, i))
                    Next
            End Select
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B7S1
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 1600
        SpellTime = 2400
        Score = 6000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "樱花剑「闪闪散华」"
    End Sub
    Private tx, ty As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
        End If
        Dim t As Integer = Ticks Mod 600
        If Ticks >= 30 Then
            If t = 30 Then
                Owner.Visibility = Visibility.Hidden
            ElseIf t >= 90 AndAlso t < 240 Then
                If t Mod 30 = 0 Then
                    Owner.MoveTo(STG.Player.X, STG.Player.Y, 10)
                ElseIf t Mod 30 = 20 Then
                    tx = Owner.X
                    ty = Owner.Y
                    Preset1()
                End If
            ElseIf t = 270 Then
                Owner.MoveToCenter(30)
                Owner.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            ElseIf t = 330 Then
                Owner.Visibility = Visibility.Hidden
                Owner.MoveTo(192, -128, 30)
            ElseIf t >= 390 AndAlso t < 540 Then
                If t Mod 10 = 0 Then
                    tx = Rnd() * 320 + 32
                    ty = Rnd() * 256 + 32
                    Preset1()
                End If
            ElseIf t = 570 Then
                Owner.MoveToCenter(30)
                Owner.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
        End If
    End Sub
    Private Sub Preset1()
        Dim r As Double = Rnd() * 360
        For i = 0 To 315 Step 45
            STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.品红, tx, ty, 0, i + r) With {.Act = AddressOf .B7S1B1})
        Next
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Owner.Visibility = Visibility.Visible
        Return MyBase.Break()
    End Function
End Class
Public Class B7S2
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 2800
        SpellTime = 2400
        Score = 6000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "断想剑「草木成佛斩」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
        End If
        Dim t As Integer = Ticks Mod 600
        If Ticks >= 30 Then
            If t = 60 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch00)
            ElseIf t = 90 Then
                STG.Objects_Add.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2) With {.Act = AddressOf .B7S2B1})
            ElseIf t = 270 Then
                Owner.DefaultMove(30)
            ElseIf t = 360 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch00)
            ElseIf t >= 390 AndAlso t < 540 Then
                If t Mod 5 = 0 Then
                    STG.Objects_Add.Add(New Bullet(BulletType.环弹, BulletColor.品红, 74 + (t - 390) * 2, 64, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B7S2B2})
                    STG.Objects_Add.Add(New Bullet(BulletType.米弹, BulletColor.品红, 74 + (t - 390) * 2, 64, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B7S2B2})
                End If
            ElseIf t = 570 Then
                Owner.DefaultMove(30)
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B7S3
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Time
        SpellHP = 10000
        SpellTime = 1500
        Score = 6000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "瞑斩「楼观赐我斩断弹幕之心眼」"
    End Sub
    Private ry As Double
    Private rd As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If AtSpell Then
            If Ticks = 0 Then
                Owner.IsEnabled = False
                Owner.Visibility = Visibility.Hidden
            End If

            If Ticks < 600 Then
                Dim t As Integer = Ticks Mod 150
                If t = 60 Then
                    For i = 0 To 340 Step 20
                        STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.天蓝, Owner.X, Owner.Y, 1.5, i + Rnd() * 4 - 2))
                    Next
                ElseIf t = 90 Then
                    ry = 32 + Rnd() * 384
                    rd = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - -4, STG.Player.Y - ry))
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.天蓝, -4, ry, rd, 16, 512, 90))
                ElseIf t = 120 Then
                    Dim r As Double = Rnd() * 320
                    For i = 0 To 7
                        STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.品红, -4 + r * Sin(rd / 180 * PI), ry - r * Cos(rd / 180 * PI), 2, Rnd() * 360))
                    Next
                End If
            ElseIf Ticks < 1000 Then
                Dim t As Integer = Ticks Mod 100
                If t = 30 Then
                    For i = 0 To 340 Step 20
                        STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.天蓝, Owner.X, Owner.Y, 1.5, i + Rnd() * 4 - 2))
                    Next
                ElseIf t = 60 Then
                    ry = 32 + Rnd() * 384
                    rd = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - -4, STG.Player.Y - ry))
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.天蓝, -4, ry, rd, 16, 512, 90))
                ElseIf t = 90 Then
                    Dim r As Double = Rnd() * 320
                    For i = 0 To 7
                        STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.品红, -4 + r * Sin(rd / 180 * PI), ry - r * Cos(rd / 180 * PI), 2, Rnd() * 360))
                    Next
                End If
            ElseIf Ticks < 1300 Then
                Dim t As Integer = Ticks Mod 50
                If t = 10 Then
                    For i = 0 To 340 Step 20
                        STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.天蓝, Owner.X, Owner.Y, 1.5, i + Rnd() * 4 - 2))
                    Next
                ElseIf t = 15 Then
                    ry = 32 + Rnd() * 384
                    rd = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - -4, STG.Player.Y - ry))
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.天蓝, -4, ry, rd, 16, 512, 90))
                ElseIf t = 45 Then
                    Dim r As Double = Rnd() * 320
                    For i = 0 To 7
                        STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.品红, -4 + r * Sin(rd / 180 * PI), ry - r * Cos(rd / 180 * PI), 2, Rnd() * 360))
                    Next
                End If
            Else
                Dim t As Integer = Ticks Mod 35
                If t = 1 Then
                    For i = 0 To 340 Step 20
                        STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.天蓝, Owner.X, Owner.Y, 1.5, i + Rnd() * 4 - 2))
                    Next
                ElseIf t = 2 Then
                    ry = 32 + Rnd() * 384
                    rd = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - -4, STG.Player.Y - ry))
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.天蓝, -4, ry, rd, 16, 512, 90))
                ElseIf t = 32 Then
                    Dim r As Double = Rnd() * 320
                    For i = 0 To 7
                        STG.Objects_Add.Add(New Bullet(BulletType.鳞弹, BulletColor.品红, -4 + r * Sin(rd / 180 * PI), ry - r * Cos(rd / 180 * PI), 2, Rnd() * 360))
                    Next
                End If
            End If

        End If

    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Owner.MoveToCenter(30)
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B7S4
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Time
        SpellHP = 10000
        SpellTime = 300
        Score = 6000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "空观剑「六根清净斩」"
    End Sub
    Private Activated As Boolean = False
    Private px, py As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If AtSpell Then
            If Ticks = 0 Then
                Owner.IsEnabled = False
                Owner.Visibility = Visibility.Visible
            End If
            If Not Activated Then
                If Ticks = 150 Then
                    Owner.IsEnabled = True
                    Owner.NormalTextures.Clear()
                    Owner.NormalTextures.Add(Textures.boss(7, 8))
                ElseIf Ticks > 150 AndAlso Ticks < 300 Then
                    If Owner.HP <= 9998 Then
                        Owner.IsEnabled = False
                        ResourcePack.Sounds.PlaySound(Sounds.ding)
                        Activated = True
                        px = STG.Player.X
                        py = STG.Player.Y
                        Ticks = 10
                        Owner.Layer1.Visibility = Visibility.Hidden
                        For i = 1 To 5
                            STG.Objects_Add.Add(New Bullet(BulletType.中玉, BulletColor.品红, Owner.X, Owner.Y, 0, 0, 0) With {.Act = AddressOf .B7S4B1, .Tag = i})
                        Next
                    End If
                End If
            Else
                STG.Player.X = px
                STG.Player.Y = py
                Owner.X = px + 80 * Sin(Ticks / 180 * PI)
                Owner.Y = py + 80 * Cos(Ticks / 180 * PI)
                STG.Player.Invin = 0
                For Each o In STG.Objects
                    If o.ObjectType = ObjectType.Bomb OrElse o.ObjectType = ObjectType.PlayerBullet Then
                        o.Clear()
                    End If
                Next
                If STG.Player.PlayerType = PlayerType.魔理沙 Then
                    STG.Player.Speed = 5
                End If
                If Ticks = 239 Then
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.品红, px, py + 32, 0, 64, 512, 62))
                End If
            End If

        End If

    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Dim s() As String
            If STG.Player.PlayerType = PlayerType.灵梦 Then
                Texts.dialog0502a.ReadLine()
                s = Texts.dialog0502a.ReadLine().Split(",")
                STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                STG.DialogArea.LoadDialog(Texts.dialog0502a)
                STG.DialogArea.Show()
            Else
                Texts.dialog0502b.ReadLine()
                s = Texts.dialog0502b.ReadLine().Split(",")
                STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                STG.DialogArea.LoadDialog(Texts.dialog0502b)
                STG.DialogArea.Show()
            End If
            Stage5.finished = True
        End If

        Return MyBase.Break()
    End Function
End Class
Module St5Enm
    <Extension>
    Public Sub S5B7I(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(7, i))
            Next
            For i = 4 To 7
                .MoveTextures.Add(Textures.boss(7, i))
            Next
            .SpellCards.Add(New B7S0(e))
            .SpellCards.Add(New B7S1(e))
            .SpellCards.Add(New B7S2(e))
            .SpellCards.Add(New B7S3(e))
            .SpellCards.Add(New B7S4(e))
            .Layer3.Height = 64
            .Layer3.Width = 48
            Canvas.SetLeft(.Layer3, 40)
            Canvas.SetTop(.Layer3, 32)
            .Layer3_scale.CenterX = 24
            .Layer3.Fill = Textures.boss(7, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S5B7A(e As Enemy.Boss)
        Static started As Boolean = False
        With e
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0501a.ReadLine()
                    s = Texts.dialog0501a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0501a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0501b.ReadLine()
                    s = Texts.dialog0501b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0501b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                .IsEnabled = True
                started = True
                STG.NameArea.Initialize("Konpaku Youmu", 5)
                ResourcePack.Sounds.StopSound(STG.CurrentMusic)
                ResourcePack.Sounds.PlaySound(Sounds.mu11)
                Stage.Showmusic("広有射怪鳥事 ～ Till When?")
                STG.CurrentMusic = Sounds.mu11
                .NextSpell()

            End If
        End With
    End Sub
    <Extension>
    Public Sub B7S1B1(e As Bullet)
        With e
            If .Ticks < 200 Then
                .Speed += 0.02
            End If
        End With
    End Sub
    <Extension>
    Public Sub B7S2B1(e As Bullet)
        With e
            If .Ticks Mod 20 = 0 Then
                STG.Objects_Add.Add(New Bullet.Laser(BulletColor.品红, .X, .Y, .Direction + 80 + Rnd() * 20, 16, 256, 120))
            ElseIf .Ticks Mod 20 = 10 Then
                STG.Objects_Add.Add(New Bullet.Laser(BulletColor.品红, .X, .Y, .Direction - 80 - Rnd() * 20, 16, 256, 120))
            End If
            If .Ticks Mod 5 = 0 Then
                STG.Objects_Add.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X, .Y, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B7S2B2})
            End If
        End With
    End Sub
    <Extension>
    Public Sub B7S2B2(e As Bullet)
        With e
            If IsNothing(.Tag) Then
                .Tag = -2
            Else
                .Tag += 0.025
                .Y += .Tag
            End If
            .X += .Direction
        End With
    End Sub
    <Extension>
    Public Sub B7S4B1(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(48, 64, 0)
                .Background = Textures.boss(7, 8)
            Else
                .X = STG.Player.X + 80 * Sin((.Ticks + .Tag * 60) / 180 * PI)
                .Y = STG.Player.Y + 80 * Cos((.Ticks + .Tag * 60) / 180 * PI)
            End If
        End With
    End Sub
End Module