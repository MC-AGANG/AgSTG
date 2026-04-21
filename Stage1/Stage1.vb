Imports System.Math
Imports System.Runtime.CompilerServices
Imports AgSTG
Imports ResourcePack.TH07
Public Class Stage1
    Inherits Stage
    Private BG As Stage1bg
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
            Showmusic("無何有の郷 ～ Deep Mountain")
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
        Background = New Stage1bg
        BG = Background
        finished = False
        EndFrame = 0
    End Sub
    Private Sub EnemySpawn()
        Select Case Ticks
            Case 480 To 535
                If Ticks Mod 5 = 0 Then
                    If Ticks Mod 10 Then
                        STG.Add(New Enemy(EnemyType.小妖精, 0, 320 + Rnd() * 10 - 5, -16, 10, "1", 200, 4, 180) With {.Tag = 1, .Act = AddressOf .S1W1})
                    Else
                        STG.Add(New Enemy(EnemyType.小妖精, 0, 300 + Rnd() * 10 - 5, -16, 10, "1", 200, 4, 180) With {.Tag = 1, .Act = AddressOf .S1W1})
                    End If
                End If
            Case 720 To 775
                If Ticks Mod 5 = 0 Then
                    If Ticks Mod 10 Then
                        STG.Add(New Enemy(EnemyType.小妖精, 1, 64 + Rnd() * 16 - 8, -16, 10, "0", 200, 4, 180) With {.Tag = 2, .Act = AddressOf .S1W1})
                    Else
                        STG.Add(New Enemy(EnemyType.小妖精, 1, 84 + Rnd() * 16 - 8, -16, 10, "0", 200, 4, 180) With {.Tag = 2, .Act = AddressOf .S1W1})
                    End If
                End If
            Case 900 To 955
                If Ticks Mod 5 = 0 Then
                    If Ticks Mod 10 Then
                        STG.Add(New Enemy(EnemyType.小妖精, 0, 320 + Rnd() * 10 - 5, -16, 10, "1", 200, 4, 180) With {.Tag = 1, .Act = AddressOf .S1W1})
                    Else
                        STG.Add(New Enemy(EnemyType.小妖精, 0, 300 + Rnd() * 10 - 5, -16, 10, "1", 200, 4, 180) With {.Tag = 1, .Act = AddressOf .S1W1})
                    End If
                End If
            Case 1080 To 1135
                If Ticks Mod 5 = 0 Then
                    If Ticks Mod 10 Then
                        STG.Add(New Enemy(EnemyType.小妖精, 1, 64 + Rnd() * 16 - 8, -16, 10, "0", 200, 4, 180) With {.Tag = 2, .Act = AddressOf .S1W1})
                    Else
                        STG.Add(New Enemy(EnemyType.小妖精, 1, 84 + Rnd() * 16 - 8, -16, 10, "0", 200, 4, 180) With {.Tag = 2, .Act = AddressOf .S1W1})
                    End If
                End If
            Case 1200 To 1800
                If Ticks Mod 50 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 3, 192 + Rnd() * 256 - 128, -16, 40, "10", 400, 2, 180) With {.Act = AddressOf .S1W2})
                End If
            Case 2040 To 2059
                STG.Add(New Enemy(EnemyType.小妖精, 2, 192 + Rnd() * 256 - 128, -16, 10, "01", 400, 2, 180) With {.Act = AddressOf .S1W3})
            Case 2250
                For x = 64 To 320 Step 64
                    STG.Add(New Enemy(EnemyType.小妖精, 0, x, -16, 10, "0011", 400, 2, 180) With {.Act = AddressOf .S1W4})
                Next
            Case 2400
                For x = 72 To 312 Step 80
                    STG.Add(New Enemy(EnemyType.小妖精, 1, x, -16, 10, "0011", 400, 2, 180) With {.Act = AddressOf .S1W4})
                Next
            Case 2500
                For x = 64 To 320 Step 64
                    STG.Add(New Enemy(EnemyType.小妖精, 3, x, -16, 10, "0011", 400, 2, 180) With {.Act = AddressOf .S1W5})
                Next
            Case 2650
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S1B0I), .Act = New Action(AddressOf .S1B0A)})
        End Select
        Select Case Ticks
            Case 1400 To 1480
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 2, -32, 128, 20, "1", 200, 2.5, 90))
                End If
            Case 1600 To 1680
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 2, 416, 160, 20, "1", 200, 2.5, 270))
                End If
            Case 1720 To 1800
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 416, 138, 20, "0", 200, 2.5, 270))
                End If
            Case 1820 To 1890
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, -32, 118, 20, "0", 200, 2.5, 90))
                End If
            Case 1920 To 2000
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 1, -32, 128, 20, "01", 200, 2.5, 90))
                    STG.Add(New Enemy(EnemyType.阴阳玉, 1, 416, 128, 20, "01", 200, 2.5, 270))
                End If
        End Select

    End Sub
End Class
Public Class B0S0
    Inherits SpellCard
    Private Delta As Double
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 1800
        UsualTime = 1800
        HaveUsual = True
        Items = "000000000011111111114"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        For i = 0 To 14
            Delta += Rnd() * 2 - 1
            If Ticks Mod 360 = i * 10 + 60 Then
                For c = 0 To 345 Step 15
                    STG.Add(New Bullet(BulletType.中玉, 1, Owner.X + i * 18 * Sin((c + Delta) / 180 * PI), Owner.Y - i * 18 * Cos((c + Delta) / 180 * PI), 0.8, c + Delta, 0) With {.Act = AddressOf .B1S0B1})
                Next
            End If
        Next

    End Sub
End Class
Public Class B0S1
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 1800
        UsualTime = 1800
        HaveUsual = True
        Items = "000000000011111111114"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks >= 30 AndAlso Ticks Mod 15 = 0 Then
            For i = 0 To 7
                Preset(Owner.X + 32 * Sin(Ticks * 2 / 180 * PI), Owner.Y + 32 * Cos(Ticks * 2 / 180 * PI), i * 45 + Ticks)
            Next
        End If


    End Sub
    Private Sub Preset(x As Double, y As Double, corner As Double)
        For i = -4 To 4
            STG.Add(New Bullet(BulletType.椭弹, 3, x, y, 3 - Abs(i / 10), corner + i * 0.8, 0))
        Next

    End Sub
End Class
Public Class B0S2
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 1800
        UsualTime = 1800
        HaveUsual = True
        Items = "000000000011111111114"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks > 30 Then
            Dim t As Integer = Abs((Ticks - 30) Mod 320)
            If t < 80 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 3, Rnd() * 360, 0))
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 3, Rnd() * 360, 0))
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 3, Rnd() * 360, 0))
            ElseIf t < 160 Then
                If Ticks Mod 15 = 0 Then
                    For i = 0 To 7
                        Preset2(Owner.X + 32 * Sin(Ticks * 2 / 180 * PI), Owner.Y + 32 * Cos(Ticks * 2 / 180 * PI), i * 45 + Ticks)
                    Next
                End If
            ElseIf t < 240 Then
                If t Mod 12 = 0 Then
                    Dim c As Double = Rnd() * 15
                    For i = 0 To 345 Step 15
                        STG.Add(New Bullet(BulletType.心弹, 6, Owner.X, Owner.Y, 3, i + c, 2))
                    Next
                End If
            Else
                STG.Add(New Bullet(BulletType.中玉, 5, Owner.X, Owner.Y + (Ticks Mod 64) - 32, 3, Rnd() * 360, 0))
                STG.Add(New Bullet(BulletType.中玉, 5, Owner.X, Owner.Y + (Ticks Mod 64) - 32, 3, Rnd() * 360, 0))
            End If

        End If



    End Sub
    Private Sub Preset2(x As Double, y As Double, corner As Double)
        For i = -4 To 4
            STG.Add(New Bullet(BulletType.椭弹, 3, x, y, 3 - Abs(i / 10), corner + i * 0.8, 0))
        Next

    End Sub
    Public Overrides Function Break() As Boolean
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0101a.ReadLine()
            s = Texts.dialog0101a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0101a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0101b.ReadLine()
            s = Texts.dialog0101b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0101b)
            STG.DialogArea.Show()
        End If
        Stage1.finished = True
        Return MyBase.Break()
    End Function
End Class
Module St1Enm
    <Extension>
    Public Sub S1W1(e As Enemy)
        With e
            If .Ticks < 55 Then
                .Speed -= 0.07
            ElseIf .Ticks = 55 Then
                .Speed = 0
            ElseIf .Ticks = 60 Then
                If .Tag = 1 Then
                    .Speed = 2
                    .Direction = 240
                Else
                    .Speed = 2
                    .Direction = 120
                End If

            End If
        End With
    End Sub
    <Extension>
    Public Sub S1W2(e As Enemy)
        With e
            If .Ticks = 50 Then
                .Speed = 0
            ElseIf .Ticks = 100 Then
                .Speed = 1
                .Direction = 180 + Rnd() * 240 - 120
            ElseIf .Ticks = 150 Then
                .Direction = 180 + Rnd() * 240 - 120
                STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, .X, .Y, 1))
                STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, .X, .Y, 1.2))
            End If
        End With
    End Sub
    <Extension>
    Public Sub S1W3(e As Enemy)
        With e
            If .Ticks = 50 Then
                .Speed = 0
            ElseIf .Ticks = 100 Then
                .Speed = 1
                .Direction = 180 + Rnd() * 120 - 60
                If Rnd() > 0.8 Then
                    For i = 1.2 To 1.6 Step 0.1
                        STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, .X, .Y, i))
                    Next
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S1W4(e As Enemy)
        With e
            If .Ticks = 50 Then
                .Speed = 0
            ElseIf .Ticks = 100 Then
                .Speed = 1
                .Direction = 180 + Rnd() * 120 - 60
                For i = 1.2 To 1.6 Step 0.1
                    STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, .X, .Y, i))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S1W5(e As Enemy)
        With e
            If .Ticks = 50 Then
                .Speed = 0
            ElseIf .Ticks = 100 Then
                .Speed = 1
                .Direction = 0
                For i = 1.2 To 1.6 Step 0.1
                    For j = -90 To 90 Step 45
                        STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, .X, .Y, i, j))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S1B0I(e As Enemy.Boss)
        With e
            For i = 0 To 4
                .NormalTextures.Add(Textures.boss(0, i))
            Next
            .SpellCards.Add(New B0S0(e))
            .SpellCards.Add(New B0S1(e))
            .SpellCards.Add(New B0S2(e))
            .Layer3.Height = 96
            .Layer3.Width = 96
            .Layer3_scale.CenterY = 48
            Canvas.SetLeft(.Layer3, 16)
            Canvas.SetTop(.Layer3, 16)
            .Layer3.Fill = Textures.boss(0, 0)

            ResourcePack.Sounds.StopSound(STG.CurrentMusic)
            ResourcePack.Sounds.PlaySound(Sounds.mu03)
            Stage.Showmusic("スカーレット警察ゲットーパトロール24時")
            STG.CurrentMusic = Sounds.mu03
        End With
    End Sub
    <Extension>
    Public Sub S1B0A(e As Enemy.Boss)
        With e
            Dim t As Integer = .Ticks Mod 24
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Funky", 3)
                .NextSpell()
            End If
            If t < 8 Then
                .Layer3_scale.ScaleY = 1 - (t / 60)
            Else
                .Layer3_scale.ScaleY = 1 + Abs((t - 8) / 60)
            End If

        End With
    End Sub
    <Extension>
    Public Sub B1S0B1(e As Bullet)
        With e
            If .Ticks < 60 Then
                .Speed -= 0.02
            ElseIf .Ticks = 60 Then
                .Speed = -1
            Else
                .Speed -= 0.025
            End If
        End With
    End Sub

End Module