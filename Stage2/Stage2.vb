Imports System.Math
Imports System.Runtime.CompilerServices
Imports AgSTG
Imports ResourcePack.TH07
Public Class Stage2
    Inherits Stage
    Public Shared BG As Stage2bg
    Public Shared Finished As Boolean = False
    Public Shared EndFrame As Integer = 0
    Sub New(Difficulty As Difficulty)
        MyBase.New(Difficulty)

    End Sub
    Public Overrides Sub Initialize()
        Reset()
    End Sub

    Public Overrides Sub Action()
        EnemySpawn()
        BG.Render()
        If Ticks = 1 Then
            Showmusic("开不尽的幻想物语")
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
        If Finished AndAlso STG.DialogArea.Finished Then
            EndFrame = 1
            Finished = False
        End If
    End Sub
    Public Overrides Sub Reset()
        MyBase.Reset()
        Background = New Stage2bg
        BG = Background
        Finished = False
        EndFrame = 0
    End Sub
    Private Sub EnemySpawn()
        Select Case Ticks
            Case 30
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 64, 300, "111100006", 400, 2.8, 210) With {.Tag = 1, .Act = AddressOf .S2W1})
            Case 240 To 320
                For i = 0 To 8
                    If Ticks = 240 + i * 10 Then
                        STG.Add(New Enemy(EnemyType.小妖精, 0, 64 + i * 32, -16, 20, "1", 240, 2.5, 180) With {.Act = AddressOf .S2W2})
                    End If
                Next
            Case 450
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 64, 300, "111100006", 400, 2.8, 150) With {.Tag = 2, .Act = AddressOf .S2W1})
            Case 660 To 740
                For i = 0 To 8
                    If Ticks = 660 + i * 10 Then
                        STG.Add(New Enemy(EnemyType.小妖精, 0, 320 - i * 32, -16, 20, "0", 240, 2.5, 180) With {.Act = AddressOf .S2W2})
                    End If
                Next
            Case 870
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 64, 150, "111100004", 400, 2.8, 210) With {.Tag = 1, .Act = AddressOf .S2W1})
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 64, 150, "111100004", 400, 2.8, 150) With {.Tag = 2, .Act = AddressOf .S2W1})
            Case 1640
                For i = 0 To 4
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 352, -16, 20, "10", 160, 4 + i * 2.5, 180) With {.Act = AddressOf .S2W3, .Tag = i})
                Next
            Case 1700
                For i = 0 To 4
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 246, -16, 20, "10", 160, 4 + i * 2.5, 180) With {.Act = AddressOf .S2W3, .Tag = i})
                Next
            Case 1760
                For i = 0 To 4
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 138, -16, 20, "10", 160, 4 + i * 2.5, 180) With {.Act = AddressOf .S2W3, .Tag = i})
                Next
            Case 1820
                For i = 0 To 4
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 32, -16, 20, "10", 160, 4 + i * 2.5, 180) With {.Act = AddressOf .S2W3, .Tag = i})
                Next
            Case 1821 To 1836
                STG.Add(New Enemy(EnemyType.幽灵, 0, 352 - 20 * (Ticks - 1821) + Rnd() * 8 - 4, -16 + Rnd() * 8 - 4, 10, "1", 200, 4, 180) With {.Act = AddressOf .S2W4})
            Case 2040
                For i = 0 To 4
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 32, -16, 20, "10", 160, 4 + i * 2.5, 180) With {.Act = AddressOf .S2W3, .Tag = i})
                Next
            Case 2100
                For i = 0 To 4
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 138, -16, 20, "10", 160, 4 + i * 2.5, 180) With {.Act = AddressOf .S2W3, .Tag = i})
                Next
            Case 2160
                For i = 0 To 4
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 246, -16, 20, "10", 160, 4 + i * 2.5, 180) With {.Act = AddressOf .S2W3, .Tag = i})
                Next
            Case 2220
                For i = 0 To 4
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 352, -16, 20, "10", 160, 4 + i * 2.5, 180) With {.Act = AddressOf .S2W3, .Tag = i})
                Next
            Case 2221 To 2236
                STG.Add(New Enemy(EnemyType.幽灵, 0, 32 + 20 * (Ticks - 2221) + Rnd() * 8 - 4, -16 + Rnd() * 8 - 4, 10, "0", 200, 4, 180) With {.Act = AddressOf .S2W4})
            Case 2530
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 64, 300, "111100006", 400, 2.8, 150) With {.Tag = 2, .Act = AddressOf .S2W1})
            Case 2780
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 64, 300, "111100004", 400, 2.8, 210) With {.Tag = 1, .Act = AddressOf .S2W1})
            Case 2940 To 3390
                For j = 0 To 3
                    For i = 0 To 3
                        If 2940 + 30 * i + 120 * j = Ticks Then
                            STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 192 - i * 32, 20, "10", 160, 1 + i * 0.75, 90) With {.Act = AddressOf .S2W5})
                        End If
                    Next
                Next
            Case 3420 To 4030
                If (Ticks - 20) Mod 50 = 0 Then
                    STG.Add(New Enemy(EnemyType.小蝴蝶, 1, 32 + 320 * Rnd(), -32, 50, "1100", 256, 4, 180) With {.Act = AddressOf .S2W6})
                End If
            Case 4150
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S2B1I), .Act = New Action(AddressOf .S2B1A)})
            Case 6180 To 6250
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 352, -16, 30, "10", 400, 2, 180) With {.Act = AddressOf .S2W7, .Tag = 1})
                End If
            Case 6300 To 6530
                If Ticks Mod 45 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 1, 32 + Rnd() * 320, 16 + Rnd() * 64, 30, "1100", 400, 0, 180) With {.Act = AddressOf .S2W8, .Tag = Int(Rnd() * 2)})
                End If
            Case 6540 To 6610
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 32, -16, 30, "10", 400, 2, 180) With {.Act = AddressOf .S2W7, .Tag = 2})
                End If
            Case 6630 To 6720
                If Ticks Mod 45 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 1, 32 + Rnd() * 320, 16 + Rnd() * 64, 30, "1100", 400, 0, 180) With {.Act = AddressOf .S2W8, .Tag = Int(Rnd() * 2)})
                End If
            Case 6750 To 6800
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 320, -16, 30, "10", 400, 2, 180) With {.Act = AddressOf .S2W7, .Tag = 1})
                End If
            Case 6820 To 6940
                If Ticks Mod 45 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 1, 32 + Rnd() * 320, 16 + Rnd() * 64, 30, "1100", 400, 0, 180) With {.Act = AddressOf .S2W8, .Tag = Int(Rnd() * 2)})
                End If
            Case 6950 To 7000
                If Ticks Mod 45 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 64, -16, 30, "10", 400, 2, 180) With {.Act = AddressOf .S2W7, .Tag = 2})
                End If
            Case 7020 To 7140
                If Ticks Mod 45 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 1, 32 + Rnd() * 320, 16 + Rnd() * 64, 30, "1100", 400, 0, 180) With {.Act = AddressOf .S2W8, .Tag = Int(Rnd() * 2)})
                End If
            Case 7150 To 7200
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 256, -16, 30, "10", 400, 2, 180) With {.Act = AddressOf .S2W7, .Tag = 1})
                End If
            Case 7230 To 7350
                If Ticks Mod 45 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 1, 32 + Rnd() * 320, 16 + Rnd() * 64, 30, "1100", 400, 0, 180) With {.Act = AddressOf .S2W8, .Tag = Int(Rnd() * 2)})
                End If
            Case 7360 To 7410
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 128, -16, 30, "10", 400, 2, 180) With {.Act = AddressOf .S2W7, .Tag = 2})
                End If
            Case 7680
                For i = 0 To 7
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 32 + Rnd() * 320, 16 + Rnd() * 128, 40, "1100", 400, 0, 180) With {.Act = AddressOf .S2W9})

                Next
            Case 7950
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S2B2I), .Act = New Action(AddressOf .S2B2A)})

        End Select
    End Sub
End Class
Public Class B1S0
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Time
        SpellHP = 10000
        SpellTime = 720
        Score = 3000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "卵隐「凤凰伪装」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If AtSpell Then
            If Ticks = 0 Then
                Stage2.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks <= 150 AndAlso Ticks Mod 60 = 30 Then
                For i = 0 To 240 Step 120
                    Preset1(i)
                Next
            ElseIf Ticks <= 150 AndAlso Ticks Mod 60 = 10 Then
                Owner.DefaultMove(20)
            ElseIf Ticks = 240 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
            ElseIf Ticks >= 300 AndAlso Ticks <= 410 Then
                If Ticks Mod 10 = 0 Then
                    STG.Add(New Bullet(BulletType.中玉, 1, Owner.X, Owner.Y, 2, Rnd() * 360, 0) With {.Act = AddressOf .B1S0B1})
                End If
            ElseIf Ticks = 420 Then
                Owner.IsEnabled = False
                Owner.MoveTo(0, -128, 60)
            End If
        End If
    End Sub
    Private Sub Preset1(corner As Double)
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2.8, corner))

        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2.4, corner - 5))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2.4, corner + 5))

        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2, corner - 8))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2, corner))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2, corner + 8))

        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 1.6, corner - 12))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 1.6, corner - 4))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 1.6, corner + 4))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 1.6, corner + 12))
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage2.BG.cardback.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B1S1
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Time
        SpellHP = 10000
        SpellTime = 880
        Score = 3000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "梅印「天仙宣告」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If AtSpell Then
            If Ticks = 0 Then
                Stage2.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = False
                Owner.Visibility = Visibility.Hidden
            End If
            If Ticks > 0 Then
                If Ticks Mod 180 <= 120 AndAlso Ticks Mod 15 = 0 Then
                    Preset1()
                End If
                If Ticks Mod 180 = 0 Then
                    Owner.MoveTo(STG.Player.X, STG.Player.Y, 120)
                ElseIf Ticks Mod 180 = 130 Then
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
                ElseIf Ticks Mod 180 = 160 Then
                    For Each b In STG.SearchBullet
                        If b.BulletType = BulletType.环弹 Then
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, b.X, b.Y, 1, Rnd() * 360, 0))
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, b.X, b.Y, 1, Rnd() * 360, 0))
                            STG.ShakeFrame = 20
                            b.Break(False)
                        End If
                    Next
                End If
            End If

        End If

    End Sub
    Private Sub Preset1()
        For i = 0 To 315 Step 45
            STG.Add(New Bullet(BulletType.环弹, BulletColor.白, Owner.X + 24 * Sin(i / 180 * PI), Owner.Y + 24 * Cos(i / 180 * PI), 0, 0, 0) With {.SoundEffect = ResourcePack.Sounds.kira00})
        Next
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage2.BG.cardback.Visibility = Visibility.Hidden
            Stage2.BG.Change()
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B2S0
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 2800
        UsualTime = 2400
        SpellHP = 2500
        SpellTime = 2400
        Score = 3000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "式神「八云蓝」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        Dim c As Integer
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 720
            Select Case t
                Case 120
                    c = Rnd() * 360
                    For i = 0 To 348 Step 18
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 1, .Act = AddressOf .B2S0B1})
                    Next
                Case 140
                    c = Rnd() * 360
                    For i = 0 To 348 Step 18
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 2, .Act = AddressOf .B2S0B1})
                    Next
                Case 160
                    c = Rnd() * 360
                    For i = 0 To 348 Step 18
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 1, .Act = AddressOf .B2S0B1})
                    Next
                Case 300
                    c = Rnd() * 360
                    For i = 0 To 348 Step 18
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 2, .Act = AddressOf .B2S0B1})
                    Next
                Case 320
                    c = Rnd() * 360
                    For i = 0 To 348 Step 18
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 1, .Act = AddressOf .B2S0B1})
                    Next
                Case 340
                    c = Rnd() * 360
                    For i = 0 To 348 Step 18
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 2, .Act = AddressOf .B2S0B1})
                    Next
                Case 530, 570, 630
                    Owner.DefaultMove(30)
                Case 540, 600, 660
                    For i = 0 To 240 Step 120
                        Preset2(i)
                    Next
            End Select
        Else
            If Ticks = 0 Then
                Stage2.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks = 60 Then
                STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 3) With {.Tag = "lan", .Breakable = False, .Act = AddressOf .B2S0B2})
            End If
            If Ticks > 60 AndAlso Ticks Mod 50 = 0 Then
                For i = 0 To 324 Step 36
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.天蓝, Owner.X, Owner.Y, 2, i))
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.天蓝, Owner.X, Owner.Y, 2.2, i))
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage2.BG.cardback.Visibility = Visibility.Hidden
            For Each b In STG.SearchBullet
                If Not IsNothing(b.Tag) Then
                    If b.Tag = "lan" Then
                        b.Break(True, True)
                    End If
                End If
            Next
        End If
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
    Private Sub Preset2(corner As Double)
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2.8, corner))

        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2.4, corner - 5))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2.4, corner + 5))

        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2, corner - 8))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2, corner))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 2, corner + 8))

        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 1.6, corner - 12))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 1.6, corner - 4))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 1.6, corner + 4))
        STG.Add(New Bullet(BulletType.小玉, BulletColor.绿, Owner.X, Owner.Y, 1.6, corner + 12))
    End Sub
End Class
Public Class B2S1
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 2400
        UsualTime = 2400
        SpellHP = 2500
        SpellTime = 2400
        Score = 3000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "式神「八云紫」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()

        If Not AtSpell Then
            If Ticks > 30 Then
                If Ticks Mod 20 = 0 Then
                    For i = 0 To 315 Step 45
                        For j = 0 To 5
                            STG.Add(New Bullet(BulletType.苦无, BulletColor.橙, Owner.X, Owner.Y, 1 + j * 0.5, i))
                        Next
                    Next
                End If
            End If
        Else
            If Ticks = 0 Then
                Stage2.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks = 60 Then
                STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1) With {.Tag = "zi", .Breakable = False, .Act = AddressOf .B2S1B1})
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage2.BG.cardback.Visibility = Visibility.Hidden
            For Each b In STG.SearchBullet
                If Not IsNothing(b.Tag) Then
                    If b.Tag = "zi" Then
                        b.Break(True, True)
                    End If
                End If
            Next
            Dim s() As String
            If STG.Player.PlayerType = PlayerType.灵梦 Then
                Texts.dialog0202a.ReadLine()
                s = Texts.dialog0202a.ReadLine().Split(",")
                STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                STG.DialogArea.LoadDialog(Texts.dialog0202a)
                STG.DialogArea.Show()
            Else
                Texts.dialog0202b.ReadLine()
                s = Texts.dialog0202b.ReadLine().Split(",")
                STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                STG.DialogArea.LoadDialog(Texts.dialog0202b)
                STG.DialogArea.Show()
            End If
            Stage2.Finished = True
        End If
        Return MyBase.Break()
    End Function
End Class
Module St2Enm
    <Extension>
    Public Sub S2W1(e As Enemy)
        With e
            If .Ticks < 240 Then
                .Speed -= 0.008
                If .Tag = 1 Then
                    .Direction += 0.5
                Else
                    .Direction -= 0.5
                End If

            Else
                .Speed += 0.008
            End If
            If .IsEnabled AndAlso .Ticks Mod 5 = 0 Then
                For i = 0 To 2
                    STG.Add(New Bullet(BulletType.椭弹, 2, .X, .Y, 0.2, .Ticks * 4 + i * 120, 0) With {.SoundEffect = -1, .Act = AddressOf .S2W1B1})
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X, .Y, 0.5, .Ticks * 4 + i * 120, 0) With {.SoundEffect = ResourcePack.Sounds.kira00, .Act = AddressOf .S2W1B1})
                Next

            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W1B1(e As Bullet)
        With e
            .Speed += 0.005
        End With
    End Sub
    <Extension>
    Public Sub S2W2(e As Enemy)
        With e
            If .Ticks > 16 AndAlso .Ticks Mod 50 = 0 Then
                For i = -1 To 1
                    STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, .X, .Y, 0.5, 270 + i * 10, 0) With {.SoundEffect = ResourcePack.Sounds.kira00, .Act = AddressOf .S2W2B1})

                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W2B1(e As Bullet)
        With e
            If .Direction > 200 Then
                .Direction -= 0.4
            End If
            .Speed += 0.005
        End With
    End Sub
    <Extension>
    Public Sub S2W3(e As Enemy)
        With e
            If .Ticks < 32 Then
                .Speed -= 4 / 32 + .Tag * 2.5 / 32
            ElseIf .Ticks = 32 Then
                .Speed = 0
                For i = 0 To 270 Step 90
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.品红, .X, .Y, 0.8 + j * 0.8, i, 0) With {.Tag = j, .Act = AddressOf .S2W3B1})
                    Next
                Next
            ElseIf .Ticks = 96 Then
                .Speed = 1
                .Direction = 210
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W3B1(e As Bullet)
        With e
            If .Ticks < 64 Then
                .Speed -= (0.8 + .Tag * 0.8) / 64
            ElseIf .Ticks = 64 Then
                STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, .X, .Y, 1.5, 0, 0) With {.SoundEffect = ResourcePack.Sounds.kira00})
                STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, .X, .Y, 1.5, 180, 0))
                .Break(False)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W4(e As Enemy)
        With e
            If .Ticks = 64 Then
                STG.Add(New Bullet(BulletType.环弹, BulletColor.红, .X, .Y, 1, Rnd() * 30 - 15))
            ElseIf .Ticks <= 39 Then
                .Speed -= 0.1
            ElseIf .Ticks = 80 Then
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W5(e As Enemy)
        With e
            If .Ticks = 50 Then
                Dim r As Double = Rnd() * 360
                For i = 0 To 315 Step 45
                    STG.Add(New Bullet(BulletType.中玉, 3, .X, .Y, 2.3, i + r, 0))
                    STG.Add(New Bullet(BulletType.中玉, 3, .X, .Y, 1.7, i + 22.5 + r, 0))
                Next
                For i = 0 To 324 Step 36
                    STG.Add(New Bullet(BulletType.点弹, BulletColor.天蓝, .X, .Y, 2, i + r, 0))
                    STG.Add(New Bullet(BulletType.点弹, BulletColor.天蓝, .X, .Y, 1.4, i + 18 + r, 0))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W6(e As Enemy)
        With e
            If .IsEnabled AndAlso .Ticks < 40 Then
                .Speed -= 0.1

            ElseIf .Ticks = 40 Then
                .Speed = 0
                .Direction = 0
            Else
                .Speed += 0.02
            End If
            If .Ticks = 1 Then
                For i = 0 To 5
                    STG.Add(New Bullet(BulletType.中玉, 1, .X, .Y, .Speed, 180, 0) With {.Tag = i, .Act = AddressOf .S2W6B1})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W6B1(e As Bullet)
        With e
            If .Ticks < 1 Then
                .Speed -= 0.1
            ElseIf .Ticks = 40 Then
                .Speed = 0
            ElseIf .Ticks = 60 Then
                .Speed = 4
                .Direction = .Tag * 60
            ElseIf .Ticks = 80 Then
                .Speed = 0
            End If
            If .Ticks >= 60 AndAlso .Ticks < 80 Then
                If .Ticks Mod 5 = 0 Then
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X, .Y, 0, .Direction, 0) With {.Tag = e, .Act = AddressOf .S2W6B3})
                End If
            ElseIf .Ticks = 120 Then
                For Each b In STG.SearchBullet()
                    If Not IsNothing(b.Tag) AndAlso b.Tag.Equals(e) Then
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.品红, b.X, b.Y, 1, Rnd() * 60 - 30, 0) With {.Act = AddressOf .S2W6B2})
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.品红, b.X, b.Y, 1, Rnd() * 60 - 30, 0) With {.SoundEffect = ResourcePack.Sounds.kira00, .Act = AddressOf .S2W6B2})
                        b.Break(False)
                    End If
                Next
                .Break(False)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W6B2(e As Bullet)
        With e
            If Abs(((.Direction + 720) Mod 360) - 180) > 5 Then
                If .Direction > 0 Then
                    .Direction += 2
                Else
                    .Direction -= 2
                End If
                .Speed += 0.03
            End If

        End With
    End Sub
    <Extension>
    Public Sub S2W6B3(e As Bullet)
        With e
            If .Ticks = 64 Then
                .Break(False)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2B1I(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(1, i))
            Next
            For i = 4 To 6
                .MoveTextures.Add(Textures.boss(1, i))
            Next
            .SpellCards.Add(New B1S0(e))
            .SpellCards.Add(New B1S1(e))
            .Layer3.Height = 64
            .Layer3.Width = 48
            .Layer3_scale.CenterX = 24
            Canvas.SetLeft(.Layer3, 40)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(1, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S2B1A(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Chen", 2)
                .NextSpell()
            End If

        End With
    End Sub
    <Extension>
    Public Sub B1S0B1(e As Bullet)
        With e
            Dim c As Integer = Rnd() * 2
            If .Ticks = 40 Then
                For i = 0 To 340 Step 20
                    If c = 0 Then
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, .X, .Y, 4, i, 0) With {.Tag = 1, .Act = AddressOf .B1S0B2})
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, .X, .Y, 2, i, 0) With {.SoundEffect = ResourcePack.Sounds.kira00, .Tag = 2, .Act = AddressOf .B1S0B2})
                    Else
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.橙, .X, .Y, 4, i, 0) With {.Tag = 1, .Act = AddressOf .B1S0B2})
                        STG.Add(New Bullet(BulletType.鳞弹, BulletColor.橙, .X, .Y, 2, i, 0) With {.SoundEffect = ResourcePack.Sounds.kira00, .Tag = 2, .Act = AddressOf .B1S0B2})
                    End If
                    .Break(False)
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B1S0B2(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 20 Then
                    .Speed -= 0.2
                ElseIf .Ticks = 20 Then
                    .Speed = 0
                ElseIf .Ticks = 40 Then
                    .Speed = 1.2
                    .Direction += 45
                End If
            Else
                If .Ticks < 20 Then
                    .Speed -= 0.1
                ElseIf .Ticks = 20 Then
                    .Speed = 0
                ElseIf .Ticks = 40 Then
                    .Speed = 2.5
                    .Direction -= 45
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W7(e As Enemy)
        With e
            If .Tag = 1 Then
                If .Ticks >= 60 AndAlso .Ticks < 240 Then
                    .Direction += 2
                End If
            Else
                If .Ticks >= 60 AndAlso .Ticks < 240 Then
                    .Direction -= 2
                End If
            End If
            If .IsEnabled AndAlso .Ticks > 20 Then
                If Rnd() > 0.999 Then
                    For i = -15 To 15 Step 10
                        STG.Add(New Bullet(BulletType.环弹, BulletColor.红, .X, .Y, 1.5, i))
                    Next

                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W8(e As Enemy)
        With e
            If .Tag = 1 Then
                If .Ticks = 60 Then
                    For i = -16 To 16 Step 8
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.红, .X, .Y, 1.5, i))
                    Next
                End If
            Else
                If .Ticks = 60 Then
                    For i = 0 To 5
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, .X, .Y, 1 + 0.2 * i, -3))
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, .X, .Y, 1 + 0.2 * i, 3))
                    Next
                End If
            End If
            If .Ticks = 180 Then
                .Speed = 1.5
            ElseIf .Ticks = 120 Then
                For i = 0 To 2
                    For j = 0 To 4
                        STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, .X, .Y, 1 + 0.2 * j, i * 120))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2W9(e As Enemy)
        With e
            If .Ticks = 10 Then
                For i = 80 To 280 Step 10
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, .X, .Y, 1.5, i))
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, .X, .Y, 1.2, i))
                Next

            ElseIf .Ticks = 12 Then
                For i = 0 To 315 Step 45
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.黄, .X, .Y, 1, i))
                Next
            ElseIf .Ticks = 14 Then
                For i = 0 To 5
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, .X, .Y, 1.2 + i * 0.2))
                Next
            ElseIf .Ticks = 90 Then
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub S2B2I(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(1, i))
            Next
            For i = 4 To 6
                .MoveTextures.Add(Textures.boss(1, i))
            Next
            .SpellCards.Add(New B2S0(e))
            .SpellCards.Add(New B2S1(e))
            .Layer3.Height = 64
            .Layer3.Width = 48
            .Layer3_scale.CenterX = 24
            Canvas.SetLeft(.Layer3, 40)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(1, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S2B2A(e As Enemy.Boss)
        With e
            Static started As Boolean = False
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0201a.ReadLine()
                    s = Texts.dialog0201a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0201a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0201b.ReadLine()
                    s = Texts.dialog0201b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0201b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                started = True
                .IsEnabled = True
                STG.NameArea.Initialize("Chen", 2)
                .NextSpell()
                ResourcePack.Sounds.StopSound(STG.CurrentMusic)
                ResourcePack.Sounds.PlaySound(Sounds.mu05)
                Stage.Showmusic("Withered Leaf")
                STG.CurrentMusic = Sounds.mu05
            End If
        End With
    End Sub
    <Extension>
    Public Sub B2S0B1(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 105 Then
                    .Direction += 4
                    .Speed -= 0.01
                ElseIf .Ticks = 105 Then
                    .Speed = 1
                ElseIf .Ticks < 180 Then
                    .Speed += 0.01
                    .Direction += 1
                End If
            Else
                If .Ticks < 105 Then
                    .Direction -= 4
                    .Speed -= 0.01
                ElseIf .Ticks = 105 Then
                    .Speed = 1
                ElseIf .Ticks < 180 Then
                    .Speed += 0.01
                    .Direction -= 1
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub B2S0B2(e As Bullet)
        With e
            Static n As Integer = 0
            If .Ticks < 16 Then
                .Background = Textures.boss(2, 0)
                n = 0
            End If
            If .X < 16 Then
                .X = 16.1
                .Direction = 90 + Rnd() * 120 - 120
                If n Mod 2 = 1 Then
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 2, i + n * 2, 0))
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 1.6, i + n * 2, 0))
                    Next
                Else
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.蝶弹, 3, .X, .Y, 2, i + n * 2, 0))
                        STG.Add(New Bullet(BulletType.蝶弹, 3, .X, .Y, 1.6, i + n * 2, 0))
                    Next
                End If
                n += 1
            ElseIf .Y < 16 Then
                .Y = 16.1
                .Direction = 180 + Rnd() * 120 - 120
                If n Mod 2 = 1 Then
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 2, i + n * 2, 0))
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 1.6, i + n * 2, 0))
                    Next
                Else
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.蝶弹, 3, .X, .Y, 2, i + n * 2, 0))
                        STG.Add(New Bullet(BulletType.蝶弹, 3, .X, .Y, 1.6, i + n * 2, 0))
                    Next
                End If
                n += 1
            ElseIf .X > 368 Then
                .X = 367.9
                .Direction = 270 + Rnd() * 120 - 120
                If n Mod 2 = 1 Then
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 2, i + n * 2, 0))
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 1.6, i + n * 2, 0))
                    Next
                Else
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.蝶弹, 3, .X, .Y, 2, i + n * 2, 0))
                        STG.Add(New Bullet(BulletType.蝶弹, 3, .X, .Y, 1.6, i + n * 2, 0))
                    Next
                End If
                n += 1
            ElseIf .Y > 432 Then
                .Y = 431.9
                .Direction = 0 + Rnd() * 120 - 120
                If n Mod 2 = 1 Then
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 2, i + n * 2, 0))
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 1.6, i + n * 2, 0))
                    Next
                Else
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.蝶弹, 3, .X, .Y, 2, i + n * 2, 0))
                        STG.Add(New Bullet(BulletType.蝶弹, 3, .X, .Y, 1.6, i + n * 2, 0))
                    Next
                End If
                n += 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub B2S1B1(e As Bullet)
        With e
            If .Ticks < 16 Then
                .Background = Textures.boss(2, 1)
            End If
            Dim t As Integer = .Ticks Mod 360
            Select Case t
                Case 50
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                    .Speed = New Vector(STG.Player.X - .X, STG.Player.Y - .Y).Length / 120
                Case 170
                    .Speed = 0
                Case 180
                    For i = 0 To 300 Step 60
                        STG.Add(New Bullet.Laser(4, .X, .Y, .Direction + i, 16, 448, 180))
                    Next
                Case 190
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 2, i))
                        STG.Add(New Bullet(BulletType.蝶弹, 1, .X, .Y, 1.6, i))
                    Next
            End Select
        End With
    End Sub
End Module