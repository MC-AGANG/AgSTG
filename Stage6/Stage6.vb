Imports System.Math
Imports System.Runtime.CompilerServices
Imports AgSTG
Imports ResourcePack.TH07
Public Class Stage6
    Inherits Stage
    Public Shared BG As Stage6bg
    Public Shared Finished As Boolean = False
    Public Shared EndFrame As Integer = 0
    Private EnemySpawn As Action
    Sub New(Difficulty As Difficulty)
        MyBase.New(Difficulty)
        Select Case Difficulty
            Case Difficulty.Easy
                EnemySpawn = AddressOf EnemySpawnE
            Case Difficulty.Normal
                EnemySpawn = AddressOf EnemySpawnN
            Case Difficulty.Hard
                EnemySpawn = AddressOf EnemySpawnH
            Case Difficulty.Lunatic
                EnemySpawn = AddressOf EnemySpawnL
        End Select
    End Sub
    Public Overrides Sub Initialize()
        Reset()
    End Sub

    Public Overrides Sub action()
        EnemySpawn()
        BG.Render()

        If Ticks = 0 Then
            Showmusic("After All")
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
        Background = New Stage6bg
        BG = Background
        Finished = False
        EndFrame = 0
    End Sub
    Private Sub EnemySpawnE()
        Select Case Ticks
            Case 120
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 128, 160, 1000, "111111111155", 800))
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 256, 160, 1000, "11111111118", 800))
            Case 1200
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S6B8IE), .Act = New Action(AddressOf .S6B8AE)})

        End Select
    End Sub

    Private Sub EnemySpawnN()
        Select Case Ticks
            Case 120
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 128, 160, 1000, "111111111155", 800))
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 256, 160, 1000, "11111111118", 800))
            Case 1200
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S6B8IN), .Act = New Action(AddressOf .S6B8AN)})

        End Select
    End Sub

    Private Sub EnemySpawnH()
        Select Case Ticks
            Case 120
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 128, 160, 1000, "111111111155", 800))
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 256, 160, 1000, "11111111118", 800))
            Case 1200
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S6B8IH), .Act = New Action(AddressOf .S6B8AH)})

        End Select
    End Sub

    Private Sub EnemySpawnL()
        Select Case Ticks
            Case 120
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 128, 160, 1000, "111111111155", 800))
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 256, 160, 1000, "11111111118", 800))
            Case 1200
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S6B8IL), .Act = New Action(AddressOf .S6B8AL)})

        End Select
    End Sub

End Class

#Region "Easy"
Public Class B8S0E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "「生的本能、死的欲望」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks > 60 AndAlso Ticks Mod 90 = 0 Then
                For i = 0 To 315 Step 45
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1.5 + Rnd(), i + Rnd() * 20 - 10, 0) With {.Act = AddressOf .B8S0B1E})
                Next
            End If

        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks = 10 Then
                STG.Add(New Bullet(BulletType.中玉, 0, 0, -600 + 224, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S0B3E})
                STG.Add(New Bullet(BulletType.中玉, 0, 0, 500 + 224, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S0B4E})
            End If
            If Ticks > 10 AndAlso Ticks Mod 120 = 0 Then
                For i = 0 To 315 Step 45
                    STG.Add(New Bullet(BulletType.刀弹, 2, Owner.X, Owner.Y, 1, i))
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        For Each b In STG.SearchBullet
            If Not b.Breakable Then
                b.Break(True, True)
            End If
        Next
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If

        Return MyBase.Break()
    End Function
End Class
Public Class B8S1E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "本能「超我」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 60 Then
                For i = 0 To 3
                    STG.Add(New Bullet.Laser(BulletColor.品红, 128, 100 * i, 225, 16, 200, 120))
                    STG.Add(New Bullet.Laser(BulletColor.品红, 256, 100 * i, 135, 16, 200, 120))
                Next
            ElseIf Ticks Mod 300 = 120 Then
                For i = 0 To 3
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 96, 100 * i + 32, 0.8 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1E})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 48, 100 * i + 80, 0.8 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1E})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 0, 100 * i + 128, 0.8 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1E})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 288, 100 * i + 32, 0.8 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1E})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 336, 100 * i + 80, 0.8 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1E})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 384, 100 * i + 128, 0.8 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1E})
                Next
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks = 10 Then
                STG.Add(New Bullet(BulletType.中玉, 0, 0, 128, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S1B2E, .Tag = 200})
                STG.Add(New Bullet(BulletType.中玉, 1, 384, 128, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S1B3E, .Tag = 200})
            End If

        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            For Each b In STG.SearchBullet
                If Not b.Breakable Then
                    b.Break(True, True)
                End If
            Next
        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S2E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "灵素「接近维克多」"
    End Sub
    Private c As Double

    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then

            If Ticks Mod 240 = 60 Then
                c = Rnd() * 45
                For i = 0 To 300 Step 60
                    STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c + i, 16, 240, 180) With {.Act = AddressOf .B8S2B1E})
                Next
            ElseIf Ticks Mod 240 = 180 Then
                For i = 0 To 300 Step 60
                    For j = 0 To 3
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X + 100 * j * Sin((c + i) / 180 * PI), Owner.Y - 80 * j * Cos((c + i) / 180 * PI), 0, c + i, 0) With {.Act = AddressOf .B8S2B2E})
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X + 100 * j * Sin((c + i) / 180 * PI), Owner.Y - 80 * j * Cos((c + i) / 180 * PI), 0, c + i, 0) With {.Act = AddressOf .B8S2B2E})
                    Next
                Next
            End If

        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks Mod 180 = 60 Then
                Owner.MoveTo(64 + Rnd() * 256, 64 + Rnd() * 320, 60)
                c = Owner.Direction + 90
            ElseIf Ticks Mod 180 = 80 OrElse Ticks Mod 180 = 120 Then
                STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c, 16, 320, 100) With {.Act = AddressOf .B8S2B3E})
                STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c + 180, 16, 320, 100) With {.Act = AddressOf .B8S2B3E})
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then

        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S3E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3200
        SpellTime = 2700
        Score = 8000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "吸魂「渐远的自我」"
    End Sub

    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Stage6.BG.CB.Visibility = Visibility.Visible
        ElseIf Ticks > 60 Then
            If Ticks Mod 50 = 0 Then
                Dim c As Double = Rnd() * 120
                For i = 0 To 300 Step 60
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1, i + c, 0) With {.Act = AddressOf .B8S3B1E, .Tag = 1})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1, i + c, 0) With {.Act = AddressOf .B8S3B1E, .Tag = 2})
                Next
                For i = 0 To 240 Step 120
                    STG.Add(New Bullet(BulletType.大玉, 1, Owner.X, Owner.Y, 1, i + c, 0))
                Next
            End If
            Dim d As Double = 448 - Ticks / 2
            If d < 100 Then
                d = 100
            End If
            For Each b In STG.SearchBullet
                If New Vector(b.X - Owner.X, b.Y - Owner.Y).Length > d Then
                    b.Opacity = 0.5 + 0.5 * Sin(Ticks / 30)
                End If
            Next
        End If
    End Sub

    Public Overrides Function Break() As Boolean
        If AtSpell Then

        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S4E
    Inherits SpellCard
    Private cleared(3) As Boolean
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 15000
        SpellTime = 7200
        Score = 10000000
        StageCount = 5
        StagePercent = {0.2, 0.4, 0.6, 0.8, 1}
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "咀嚼「玛格丽特·马拉」"
        For i = 0 To 3
            cleared(i) = False
        Next
    End Sub

    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Stage6.BG.CB.Visibility = Visibility.Visible
            Owner.MoveTo(192, 224, 30)
            Grid.SetRowSpan(STG.SpellCardLabel.cardname, 5)
        ElseIf Ticks > 60 Then
            If Ticks Mod 90 = 0 Then
                If Owner.HP > 12000 Then
                    Preset1()
                ElseIf Owner.HP > 9000 Then
                    If Not cleared(0) Then
                        cleared(0) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "消化「爱德华·桑代克」"
                    End If
                    Preset2()
                ElseIf Owner.HP > 6000 Then
                    If Not cleared(1) Then
                        cleared(1) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "吸收「让·皮亚傑」"
                    End If
                    Preset3()
                ElseIf Owner.HP > 3000 Then
                    If Not cleared(2) Then
                        cleared(2) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "混交「梅拉尼·克莱因」"
                    End If
                    Preset4()
                Else
                    If Not cleared(3) Then
                        cleared(3) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "吸收「安娜·弗洛伊德」"
                    End If
                    Preset4()
                End If
            End If
            If Ticks Mod 20 = 0 AndAlso Owner.HP <= 3000 Then
                preset5()
            End If
        End If
    End Sub
    Public Sub Preset1()
        Dim c As Double = Rnd() * 360
        For i = 0 To 330 Step 30
            STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.25, i + c, 0))
        Next
    End Sub
    Public Sub Preset2()
        Dim c As Double = Rnd() * 360
        For i = 0 To 330 Step 30
            If i Mod 60 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B2E})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B2E})
            End If
        Next
    End Sub
    Public Sub Preset3()
        Dim c As Double = Rnd() * 360
        For i = 0 To 330 Step 30
            If i Mod 60 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B3E})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B3E})
            End If
        Next
    End Sub
    Public Sub Preset4()
        Dim c As Double = Rnd() * 360
        For i = 0 To 330 Step 30
            If i Mod 60 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B4E})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B4E})
            End If
        Next
    End Sub
    Public Sub preset5()
        Dim tx, ty, td As Double
        tx = 48
        ty = Rnd() * 448
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 80, 90))
        tx = 336
        ty = Rnd() * 448
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 80, 90))
        tx = Rnd() * 384
        ty = 48
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 80, 90))
        tx = Rnd() * 384
        ty = 400
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 80, 90))
    End Sub

    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Grid.SetRowSpan(STG.SpellCardLabel.cardname, 1)
        End If
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0602a.ReadLine()
            s = Texts.dialog0602a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0602a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0602b.ReadLine()
            s = Texts.dialog0602b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0602b)
            STG.DialogArea.Show()
        End If
        Stage6.Finished = True
        Return MyBase.Break()
    End Function
End Class
Module St6EnmE
    <Extension>
    Public Sub S6B8IE(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(8, i))
            Next
            .MoveTextures.Add(Textures.boss(8, 4))
            .SpellCards.Add(New B8S0E(e))
            .SpellCards.Add(New B8S1E(e))
            .SpellCards.Add(New B8S2E(e))
            .SpellCards.Add(New B8S3E(e))
            .SpellCards.Add(New B8S4E(e))
            .Layer3.Height = 96
            .Layer3.Width = 96
            Canvas.SetLeft(.Layer3, 16)
            Canvas.SetTop(.Layer3, 16)
            .Layer3_scale.CenterX = 48
            .Layer3.Fill = Textures.boss(8, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S6B8AE(e As Enemy.Boss)
        Static started As Boolean = False
        With e
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0601a.ReadLine()
                    s = Texts.dialog0601a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0601a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0601b.ReadLine()
                    s = Texts.dialog0601b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0601b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                .IsEnabled = True
                started = True
                STG.NameArea.Initialize("Shion", 5)

                ResourcePack.Sounds.StopSound(ResourcePack.Sounds.CurrentMusic)
                ResourcePack.Sounds.PlayMusic(Sounds.mu13)
                Stage.Showmusic("縁から外れた名前")
                ResourcePack.Sounds.CurrentMusic = Sounds.mu13
                .NextSpell()

            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B1E(e As Bullet)
        With e
            If .Ticks < 60 Then
                .Y += .Ticks * 0.02
            ElseIf .Ticks = 60 Then
                .Break(False)
                STG.Add(New Bullet(BulletType.刀弹, 2, .X, .Y, 0) With {.Act = AddressOf .B8S0B2E})
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B2E(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 1
            ElseIf .Ticks > 30 Then
                .Speed += 0.018
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B3E(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(1024, 1024, 0)
                .Background = Textures.circle_red
            Else
                .X = 600 * Sin(.Ticks / 180) + 192
                .Y = 600 * Cos(.Ticks / 180) + 224
            End If
            If .Ticks Mod 120 = 60 Then
                For i = -20 To 20 Step 5
                    Dim d As Double = i + Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + 512 * Sin(d / 180 * PI), .Y - 512 * Cos(d / 180 * PI), 1.25, d, 0) With {.Act = AddressOf .B8S0B5E})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = -20 To 20 Step 8
                    Dim d As Double = i + Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, .X + 512 * Sin(d / 180 * PI), .Y - 512 * Cos(d / 180 * PI), 1.25, d + 180, 0))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B4E(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(1024, 1024, 0)
                .Background = Textures.circle_blue
            Else
                .X = 500 * Sin(.Ticks / 180 + PI) + 192
                .Y = 500 * Cos(.Ticks / 180 + PI) + 224
                For Each b In STG.SearchBullet
                    If b.BulletColor = BulletColor.品红 AndAlso New Vector(b.X - .X, b.Y - .Y).Length < 512 Then
                        b.BulletColor = BulletColor.蓝
                        b.Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - b.X, .Y - b.Y))
                    End If
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B5E(e As Bullet)
        With e
            If .BulletColor = BulletColor.蓝 Then
                .Speed += 0.018
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B1E(e As Bullet)
        With e

            .Y += .Ticks * 0.015
        End With
    End Sub
    <Extension>
    Public Sub B8S1B2E(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(400, 400, 0)
                .Background = Textures.circle_magenta
            Else
                .Tag -= 0.1
                For Each o In STG.Objects
                    If o.ObjectType = ObjectType.PlayerBullet OrElse o.ObjectType = ObjectType.Bomb Then
                        If .GetDistance(o) < .Tag - 8 Then
                            For Each b In STG.SearchBullet
                                If b.BulletType = BulletType.中玉 AndAlso b.BulletColor = 1 Then
                                    b.Tag -= 1
                                End If
                            Next
                            o.Clear()
                            .Tag += 1
                        End If
                    End If
                Next

                If .Tag > 320 Then
                    .Tag = 320
                ElseIf .Tag < 32 Then
                    .Tag = 32
                End If
                .SetSize(.Tag * 2, .Tag * 2, 0)
            End If
            If .Ticks Mod 120 = 60 Then
                For i = 0 To 359.9 Step 2880 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r + 225, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4E})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = 0 To 359.9 Step 2880 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r - 45, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4E})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B3E(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(400, 400, 0)
                .Background = Textures.circle_cyan
            Else
                .Tag -= 0.1
                For Each o In STG.Objects
                    If o.ObjectType = ObjectType.PlayerBullet OrElse o.ObjectType = ObjectType.Bomb Then
                        If .GetDistance(o) < .Tag - 8 Then
                            For Each b In STG.SearchBullet
                                If b.BulletType = BulletType.中玉 AndAlso b.BulletColor = 0 Then
                                    b.Tag -= 1
                                End If
                            Next
                            o.Clear()
                            .Tag += 1
                        End If
                    End If
                Next

                If .Tag > 320 Then
                    .Tag = 320
                ElseIf .Tag < 32 Then
                    .Tag = 32
                End If
                .SetSize(.Tag * 2, .Tag * 2, 0)
            End If
            If .Ticks Mod 120 = 60 Then
                For i = 0 To 359.9 Step 2160 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r + 225, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4E})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = 0 To 359.9 Step 2160 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r - 45, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4E})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B4E(e As Bullet)
        With e
            If New Vector(.X - 192, .Y - 128).Length >= 320 Then
                .Breakable = True
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B1E(e As Bullet)
        With e
            If .Ticks = 61 Then
                .Speed = 2
            ElseIf .Ticks > 60 AndAlso .Ticks < 120 Then
                .X += .Speed * Sin(.Direction / 180 * PI)
                .Y -= .Speed * Cos(.Direction / 180 * PI)
            ElseIf .Ticks = 120 Then
                .Break(False)
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B2E(e As Bullet)
        With e
            If .Ticks = 60 Then
                If .BulletColor = BulletColor.红 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                Else
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y)) + 180
                End If
                .Speed = 1
            ElseIf .Ticks > 60 Then
                .Speed += 0.01
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B3E(e As Bullet)
        With e
            If .Ticks = 90 Then
                For i = 100 To 300 Step 100
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + i * Sin(.Direction / 180 * PI), .Y - i * Cos(.Direction / 180 * PI), 0, .Direction + 90, 0) With {.Act = AddressOf .B8S2B4E})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + i * Sin(.Direction / 180 * PI), .Y - i * Cos(.Direction / 180 * PI), 0, .Direction - 90, 0) With {.Act = AddressOf .B8S2B4E})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B4E(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 1
            Else
                .Speed += 0.015
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S3B1E(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 60 Then
                    .Direction += 2
                ElseIf .Ticks < 120 Then
                    .Direction -= 1
                End If
            Else
                If .Ticks < 60 Then
                    .Direction -= 2
                ElseIf .Ticks < 120 Then
                    .Direction += 1
                End If
            End If

        End With
    End Sub
    <Extension>
    Public Sub B8S4B2E(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 75 Then
                    .Direction += 1
                End If
            Else
                If .Ticks < 75 Then
                    .Direction -= 1
                End If
            End If

        End With
    End Sub
    <Extension>
    Public Sub B8S4B3E(e As Bullet)
        With e
            If .BulletColor = BulletColor.红 Then
                If .Tag = 1 Then
                    If .Ticks < 75 Then
                        .Direction += 1
                    End If
                Else
                    If .Ticks < 75 Then
                        .Direction -= 1
                    End If
                End If
                If .X < 8 OrElse .X > 376 OrElse .Y < 8 OrElse .Y > 440 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    .BulletColor = BulletColor.品红
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.kira00, 0.5)
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S4B4E(e As Bullet)
        With e
            If .BulletColor = BulletColor.红 Then
                If .Tag Mod 2 = 1 Then
                    If .Ticks < 75 Then
                        .Direction += 1
                    End If
                Else
                    If .Ticks < 75 Then
                        .Direction -= 1
                    End If
                End If
                If .X < 8 OrElse .X > 376 OrElse .Y < 8 OrElse .Y > 440 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    .BulletColor = BulletColor.品红
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.kira00, 0.5)
                End If
            End If
            If .Tag < 10 AndAlso .BulletColor = BulletColor.红 Then
                For Each b In STG.SearchBullet
                    If b.BulletType = BulletType.小玉 AndAlso b.BulletColor = BulletColor.品红 AndAlso New Vector(b.X - .X, b.Y - .Y).Length < 8 Then
                        STG.Add(New Bullet(BulletType.刀弹, 2, b.X, b.Y, 1.2, b.Direction, 0))
                        b.Break(False)
                        .Tag += 10
                        Exit For
                    End If
                Next
            End If
        End With
    End Sub
End Module

#End Region

#Region "Normal"
Public Class B8S0N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "「生的本能、死的欲望」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks > 60 AndAlso Ticks Mod 90 = 0 Then
                For i = 0 To 330 Step 30
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1.8 + Rnd(), i + Rnd() * 20 - 10, 0) With {.Act = AddressOf .B8S0B1N})
                Next
            End If

        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks = 10 Then
                STG.Add(New Bullet(BulletType.中玉, 0, 0, -600 + 224, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S0B3N})
                STG.Add(New Bullet(BulletType.中玉, 0, 0, 500 + 224, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S0B4N})
            End If
            If Ticks > 10 AndAlso Ticks Mod 120 = 0 Then
                For i = 0 To 315 Step 45
                    STG.Add(New Bullet(BulletType.刀弹, 2, Owner.X, Owner.Y, 1.2, i))
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        For Each b In STG.SearchBullet
            If Not b.Breakable Then
                b.Break(True, True)
            End If
        Next
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If

        Return MyBase.Break()
    End Function
End Class
Public Class B8S1N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "本能「超我」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 60 Then
                For i = 0 To 5
                    STG.Add(New Bullet.Laser(BulletColor.品红, 128, 60 * i, 225, 16, 200, 120))
                    STG.Add(New Bullet.Laser(BulletColor.品红, 256, 60 * i, 135, 16, 200, 120))
                Next
            ElseIf Ticks Mod 300 = 120 Then
                For i = 0 To 5
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 96, 60 * i + 32, 1 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1N})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 48, 60 * i + 80, 1 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1N})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 0, 60 * i + 128, 1 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1N})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 288, 60 * i + 32, 1 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1N})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 336, 60 * i + 80, 1 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1N})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 384, 60 * i + 128, 1 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1N})
                Next
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks = 10 Then
                STG.Add(New Bullet(BulletType.中玉, 0, 0, 128, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S1B2N, .Tag = 200})
                STG.Add(New Bullet(BulletType.中玉, 1, 384, 128, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S1B3N, .Tag = 200})
            End If

        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            For Each b In STG.SearchBullet
                If Not b.Breakable Then
                    b.Break(True, True)
                End If
            Next
        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S2N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "灵素「接近维克多」"
    End Sub
    Private c As Double

    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then

            If Ticks Mod 240 = 60 Then
                c = Rnd() * 45
                For i = 0 To 300 Step 60
                    STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c + i, 16, 240, 180) With {.Act = AddressOf .B8S2B1N})
                Next
            ElseIf Ticks Mod 240 = 180 Then
                For i = 0 To 300 Step 60
                    For j = 0 To 4
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X + 80 * j * Sin((c + i) / 180 * PI), Owner.Y - 80 * j * Cos((c + i) / 180 * PI), 0, c + i, 0) With {.Act = AddressOf .B8S2B2N})
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X + 80 * j * Sin((c + i) / 180 * PI), Owner.Y - 80 * j * Cos((c + i) / 180 * PI), 0, c + i, 0) With {.Act = AddressOf .B8S2B2N})
                    Next
                Next
            End If

        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks Mod 180 = 60 Then
                Owner.MoveTo(64 + Rnd() * 256, 64 + Rnd() * 320, 60)
                c = Owner.Direction + 90
            ElseIf Ticks Mod 180 = 80 OrElse Ticks Mod 180 = 120 Then
                STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c, 16, 320, 100) With {.Act = AddressOf .B8S2B3N})
                STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c + 180, 16, 320, 100) With {.Act = AddressOf .B8S2B3N})
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then

        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S3N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3200
        SpellTime = 2700
        Score = 8000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "吸魂「渐远的自我」"
    End Sub

    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Stage6.BG.CB.Visibility = Visibility.Visible
        ElseIf Ticks > 60 Then
            If Ticks Mod 50 = 0 Then
                Dim c As Double = Rnd() * 120
                For i = 0 To 315 Step 45
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1.2, i + c, 0) With {.Act = AddressOf .B8S3B1N, .Tag = 1})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1.2, i + c, 0) With {.Act = AddressOf .B8S3B1N, .Tag = 2})
                Next
                For i = 0 To 240 Step 120
                    STG.Add(New Bullet(BulletType.大玉, 1, Owner.X, Owner.Y, 1.2, i + c, 0))
                Next
            End If
            Dim d As Double = 448 - Ticks / 2
            If d < 80 Then
                d = 80
            End If
            For Each b In STG.SearchBullet
                If New Vector(b.X - Owner.X, b.Y - Owner.Y).Length > d Then
                    b.Opacity = 0.5 + 0.5 * Sin(Ticks / 30)
                End If
            Next
        End If
    End Sub

    Public Overrides Function Break() As Boolean
        If AtSpell Then

        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S4N
    Inherits SpellCard
    Private cleared(3) As Boolean
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 15000
        SpellTime = 7200
        Score = 10000000
        StageCount = 5
        StagePercent = {0.2, 0.4, 0.6, 0.8, 1}
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "咀嚼「玛格丽特·马拉」"
        For i = 0 To 3
            cleared(i) = False
        Next
    End Sub

    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Stage6.BG.CB.Visibility = Visibility.Visible
            Owner.MoveTo(192, 224, 30)
            Grid.SetRowSpan(STG.SpellCardLabel.cardname, 5)
        ElseIf Ticks > 60 Then
            If Ticks Mod 60 = 0 Then
                If Owner.HP > 12000 Then
                    Preset1()
                ElseIf Owner.HP > 9000 Then
                    If Not cleared(0) Then
                        cleared(0) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "消化「爱德华·桑代克」"
                    End If
                    Preset2()
                ElseIf Owner.HP > 6000 Then
                    If Not cleared(1) Then
                        cleared(1) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "吸收「让·皮亚傑」"
                    End If
                    Preset3()
                ElseIf Owner.HP > 3000 Then
                    If Not cleared(2) Then
                        cleared(2) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "混交「梅拉尼·克莱因」"
                    End If
                    Preset4()
                Else
                    If Not cleared(3) Then
                        cleared(3) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "吸收「安娜·弗洛伊德」"
                    End If
                    Preset4()
                End If
            End If
            If Ticks Mod 15 = 0 AndAlso Owner.HP <= 3000 Then
                preset5()
            End If
        End If
    End Sub
    Public Sub Preset1()
        Dim c As Double = Rnd() * 360
        For i = 0 To 330 Step 30
            STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.25, i + c, 0))
        Next
    End Sub
    Public Sub Preset2()
        Dim c As Double = Rnd() * 360
        For i = 0 To 330 Step 30
            If i Mod 60 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B2N})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B2N})
            End If
        Next
    End Sub
    Public Sub Preset3()
        Dim c As Double = Rnd() * 360
        For i = 0 To 330 Step 30
            If i Mod 60 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B3N})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B3N})
            End If
        Next
    End Sub
    Public Sub Preset4()
        Dim c As Double = Rnd() * 360
        For i = 0 To 330 Step 30
            If i Mod 60 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B4N})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B4N})
            End If
        Next
    End Sub
    Public Sub preset5()
        Dim tx, ty, td As Double
        tx = 48
        ty = Rnd() * 448
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 100, 90))
        tx = 336
        ty = Rnd() * 448
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 100, 90))
        tx = Rnd() * 384
        ty = 48
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 100, 90))
        tx = Rnd() * 384
        ty = 400
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 100, 90))
    End Sub

    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Grid.SetRowSpan(STG.SpellCardLabel.cardname, 1)
        End If
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0602a.ReadLine()
            s = Texts.dialog0602a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0602a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0602b.ReadLine()
            s = Texts.dialog0602b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0602b)
            STG.DialogArea.Show()
        End If
        Stage6.Finished = True
        Return MyBase.Break()
    End Function
End Class
Module St6EnmN
    <Extension>
    Public Sub S6B8IN(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(8, i))
            Next
            .MoveTextures.Add(Textures.boss(8, 4))
            .SpellCards.Add(New B8S0N(e))
            .SpellCards.Add(New B8S1N(e))
            .SpellCards.Add(New B8S2N(e))
            .SpellCards.Add(New B8S3N(e))
            .SpellCards.Add(New B8S4N(e))
            .Layer3.Height = 96
            .Layer3.Width = 96
            Canvas.SetLeft(.Layer3, 16)
            Canvas.SetTop(.Layer3, 16)
            .Layer3_scale.CenterX = 48
            .Layer3.Fill = Textures.boss(8, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S6B8AN(e As Enemy.Boss)
        Static started As Boolean = False
        With e
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0601a.ReadLine()
                    s = Texts.dialog0601a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0601a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0601b.ReadLine()
                    s = Texts.dialog0601b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0601b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                .IsEnabled = True
                started = True
                STG.NameArea.Initialize("Shion", 5)

                ResourcePack.Sounds.StopSound(ResourcePack.Sounds.CurrentMusic)
                ResourcePack.Sounds.PlayMusic(Sounds.mu13)
                Stage.Showmusic("縁から外れた名前")
                ResourcePack.Sounds.CurrentMusic = Sounds.mu13
                .NextSpell()

            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B1N(e As Bullet)
        With e
            If .Ticks < 60 Then
                .Y += .Ticks * 0.03
            ElseIf .Ticks = 60 Then
                .Break(False)
                STG.Add(New Bullet(BulletType.刀弹, 2, .X, .Y, 0) With {.Act = AddressOf .B8S0B2N})
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B2N(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 1
            ElseIf .Ticks > 30 Then
                .Speed += 0.018
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B3N(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(1024, 1024, 0)
                .Background = Textures.circle_red
            Else
                .X = 600 * Sin(.Ticks / 180) + 192
                .Y = 600 * Cos(.Ticks / 180) + 224
            End If
            If .Ticks Mod 120 = 60 Then
                For i = -20 To 20 Step 4
                    Dim d As Double = i + Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + 512 * Sin(d / 180 * PI), .Y - 512 * Cos(d / 180 * PI), 1.5, d, 0) With {.Act = AddressOf .B8S0B5N})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = -20 To 20 Step 5
                    Dim d As Double = i + Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, .X + 512 * Sin(d / 180 * PI), .Y - 512 * Cos(d / 180 * PI), 1.5, d + 180, 0))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B4N(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(1024, 1024, 0)
                .Background = Textures.circle_blue
            Else
                .X = 500 * Sin(.Ticks / 180 + PI) + 192
                .Y = 500 * Cos(.Ticks / 180 + PI) + 224
                For Each b In STG.SearchBullet
                    If b.BulletColor = BulletColor.品红 AndAlso New Vector(b.X - .X, b.Y - .Y).Length < 512 Then
                        b.BulletColor = BulletColor.蓝
                        b.Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - b.X, .Y - b.Y))
                    End If
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B5N(e As Bullet)
        With e
            If .BulletColor = BulletColor.蓝 Then
                .Speed += 0.018
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B1N(e As Bullet)
        With e

            .Y += .Ticks * 0.018
        End With
    End Sub
    <Extension>
    Public Sub B8S1B2N(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(400, 400, 0)
                .Background = Textures.circle_magenta
            Else
                .Tag -= 0.1
                For Each o In STG.Objects
                    If o.ObjectType = ObjectType.PlayerBullet OrElse o.ObjectType = ObjectType.Bomb Then
                        If .GetDistance(o) < .Tag - 8 Then
                            For Each b In STG.SearchBullet
                                If b.BulletType = BulletType.中玉 AndAlso b.BulletColor = 1 Then
                                    b.Tag -= 1
                                End If
                            Next
                            o.Clear()
                            .Tag += 1
                        End If
                    End If
                Next

                If .Tag > 320 Then
                    .Tag = 320
                ElseIf .Tag < 32 Then
                    .Tag = 32
                End If
                .SetSize(.Tag * 2, .Tag * 2, 0)
            End If
            If .Ticks Mod 120 = 60 Then
                For i = 0 To 359.9 Step 2160 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r + 225, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4N})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = 0 To 359.9 Step 2160 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r - 45, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4N})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B3N(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(400, 400, 0)
                .Background = Textures.circle_cyan
            Else
                .Tag -= 0.1
                For Each o In STG.Objects
                    If o.ObjectType = ObjectType.PlayerBullet OrElse o.ObjectType = ObjectType.Bomb Then
                        If .GetDistance(o) < .Tag - 8 Then
                            For Each b In STG.SearchBullet
                                If b.BulletType = BulletType.中玉 AndAlso b.BulletColor = 0 Then
                                    b.Tag -= 1
                                End If
                            Next
                            o.Clear()
                            .Tag += 1
                        End If
                    End If
                Next

                If .Tag > 320 Then
                    .Tag = 320
                ElseIf .Tag < 32 Then
                    .Tag = 32
                End If
                .SetSize(.Tag * 2, .Tag * 2, 0)
            End If
            If .Ticks Mod 120 = 60 Then
                For i = 0 To 359.9 Step 2160 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r + 225, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4N})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = 0 To 359.9 Step 2160 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r - 45, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4N})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B4N(e As Bullet)
        With e
            If New Vector(.X - 192, .Y - 128).Length >= 320 Then
                .Breakable = True
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B1N(e As Bullet)
        With e
            If .Ticks = 61 Then
                .Speed = 2
            ElseIf .Ticks > 60 AndAlso .Ticks < 120 Then
                .X += .Speed * Sin(.Direction / 180 * PI)
                .Y -= .Speed * Cos(.Direction / 180 * PI)
            ElseIf .Ticks = 120 Then
                .Break(False)
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B2N(e As Bullet)
        With e
            If .Ticks = 60 Then
                If .BulletColor = BulletColor.红 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                Else
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y)) + 180
                End If
                .Speed = 1
            ElseIf .Ticks > 60 Then
                .Speed += 0.015
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B3N(e As Bullet)
        With e
            If .Ticks = 90 Then
                For i = 80 To 320 Step 80
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + i * Sin(.Direction / 180 * PI), .Y - i * Cos(.Direction / 180 * PI), 0, .Direction + 90, 0) With {.Act = AddressOf .B8S2B4N})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + i * Sin(.Direction / 180 * PI), .Y - i * Cos(.Direction / 180 * PI), 0, .Direction - 90, 0) With {.Act = AddressOf .B8S2B4N})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B4N(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 1
            Else
                .Speed += 0.018
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S3B1N(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 60 Then
                    .Direction += 2
                ElseIf .Ticks < 120 Then
                    .Direction -= 1
                End If
            Else
                If .Ticks < 60 Then
                    .Direction -= 2
                ElseIf .Ticks < 120 Then
                    .Direction += 1
                End If
            End If

        End With
    End Sub
    <Extension>
    Public Sub B8S4B2N(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 75 Then
                    .Direction += 1
                End If
            Else
                If .Ticks < 75 Then
                    .Direction -= 1
                End If
            End If

        End With
    End Sub
    <Extension>
    Public Sub B8S4B3N(e As Bullet)
        With e
            If .BulletColor = BulletColor.红 Then
                If .Tag = 1 Then
                    If .Ticks < 75 Then
                        .Direction += 1
                    End If
                Else
                    If .Ticks < 75 Then
                        .Direction -= 1
                    End If
                End If
                If .X < 8 OrElse .X > 376 OrElse .Y < 8 OrElse .Y > 440 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    .BulletColor = BulletColor.品红
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.kira00, 0.5)
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S4B4N(e As Bullet)
        With e
            If .BulletColor = BulletColor.红 Then
                If .Tag Mod 2 = 1 Then
                    If .Ticks < 75 Then
                        .Direction += 1
                    End If
                Else
                    If .Ticks < 75 Then
                        .Direction -= 1
                    End If
                End If
                If .X < 8 OrElse .X > 376 OrElse .Y < 8 OrElse .Y > 440 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    .BulletColor = BulletColor.品红
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.kira00, 0.5)
                End If
            End If
            If .Tag < 10 AndAlso .BulletColor = BulletColor.红 Then
                For Each b In STG.SearchBullet
                    If b.BulletType = BulletType.小玉 AndAlso b.BulletColor = BulletColor.品红 AndAlso New Vector(b.X - .X, b.Y - .Y).Length < 8 Then
                        STG.Add(New Bullet(BulletType.刀弹, 2, b.X, b.Y, 1.5, b.Direction, 0))
                        b.Break(False)
                        .Tag += 10
                        Exit For
                    End If
                Next
            End If
        End With
    End Sub
End Module

#End Region

#Region "Hard"
Public Class B8S0H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "「生的本能、死的欲望」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks > 60 AndAlso Ticks Mod 90 = 0 Then
                For i = 0 To 342 Step 18
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 2 + Rnd(), i + Rnd() * 20 - 10, 0) With {.Act = AddressOf .B8S0B1H})
                Next
            End If

        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks = 10 Then
                STG.Add(New Bullet(BulletType.中玉, 0, 0, -600 + 224, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S0B3H})
                STG.Add(New Bullet(BulletType.中玉, 0, 0, 500 + 224, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S0B4H})
            End If
            If Ticks > 10 AndAlso Ticks Mod 100 = 0 Then
                For i = 0 To 330 Step 30
                    STG.Add(New Bullet(BulletType.刀弹, 2, Owner.X, Owner.Y, 1.2, i))
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        For Each b In STG.SearchBullet
            If Not b.Breakable Then
                b.Break(True, True)
            End If
        Next
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If

        Return MyBase.Break()
    End Function
End Class
Public Class B8S1H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "本能「超我」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 60 Then
                For i = 0 To 7
                    STG.Add(New Bullet.Laser(BulletColor.品红, 128, 48 * i, 225, 16, 200, 120))
                    STG.Add(New Bullet.Laser(BulletColor.品红, 256, 48 * i, 135, 16, 200, 120))
                Next
            ElseIf Ticks Mod 300 = 120 Then
                For i = 0 To 7
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 96, 48 * i + 32, 1 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1H})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 64, 48 * i + 64, 1 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1H})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 32, 48 * i + 96, 1 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1H})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 0, 48 * i + 128, 1 + Rnd(), 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1H})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 288, 48 * i + 32, 1 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1H})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 320, 48 * i + 64, 1 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1H})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 352, 48 * i + 96, 1 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1H})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 384, 48 * i + 128, 1 + Rnd(), 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1H})
                Next
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks = 10 Then
                STG.Add(New Bullet(BulletType.中玉, 0, 0, 128, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S1B2H, .Tag = 200})
                STG.Add(New Bullet(BulletType.中玉, 1, 384, 128, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S1B3H, .Tag = 200})
            End If

        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            For Each b In STG.SearchBullet
                If Not b.Breakable Then
                    b.Break(True, True)
                End If
            Next
        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S2H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "灵素「接近维克多」"
    End Sub
    Private c As Double

    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then

            If Ticks Mod 240 = 60 Then
                c = Rnd() * 45
                For i = 0 To 315 Step 45
                    STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c + i, 16, 240, 180) With {.Act = AddressOf .B8S2B1H})
                Next
            ElseIf Ticks Mod 240 = 180 Then
                For i = 0 To 315 Step 45
                    For j = 0 To 5
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X + 64 * j * Sin((c + i) / 180 * PI), Owner.Y - 64 * j * Cos((c + i) / 180 * PI), 0, c + i, 0) With {.Act = AddressOf .B8S2B2H})
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X + 64 * j * Sin((c + i) / 180 * PI), Owner.Y - 64 * j * Cos((c + i) / 180 * PI), 0, c + i, 0) With {.Act = AddressOf .B8S2B2H})
                    Next
                Next
            End If

        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks Mod 180 = 60 Then
                Owner.MoveTo(64 + Rnd() * 256, 64 + Rnd() * 320, 60)
                c = Owner.Direction + 90
            ElseIf Ticks Mod 180 = 80 OrElse Ticks Mod 180 = 100 OrElse Ticks Mod 180 = 120 Then
                STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c, 16, 320, 100) With {.Act = AddressOf .B8S2B3H})
                STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c + 180, 16, 320, 100) With {.Act = AddressOf .B8S2B3H})
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then

        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S3H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3200
        SpellTime = 2700
        Score = 8000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "吸魂「渐远的自我」"
    End Sub

    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Stage6.BG.CB.Visibility = Visibility.Visible
        ElseIf Ticks > 60 Then
            If Ticks Mod 50 = 0 Then
                Dim c As Double = Rnd() * 120
                For i = 0 To 330 Step 30
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Act = AddressOf .B8S3B1H, .Tag = 1})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Act = AddressOf .B8S3B1H, .Tag = 2})
                Next
                For i = 0 To 240 Step 120
                    STG.Add(New Bullet(BulletType.大玉, 1, Owner.X, Owner.Y, 1.5, i + c, 0))
                Next
            End If
            Dim d As Double = 448 - Ticks / 2
            If d < 64 Then
                d = 64
            End If
            For Each b In STG.SearchBullet
                If New Vector(b.X - Owner.X, b.Y - Owner.Y).Length > d Then
                    b.Opacity = 0.5 + 0.5 * Sin(Ticks / 30)
                End If
            Next
        End If
    End Sub

    Public Overrides Function Break() As Boolean
        If AtSpell Then

        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S4H
    Inherits SpellCard
    Private cleared(3) As Boolean
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 15000
        SpellTime = 7200
        Score = 10000000
        StageCount = 5
        StagePercent = {0.2, 0.4, 0.6, 0.8, 1}
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "咀嚼「玛格丽特·马拉」"
        For i = 0 To 3
            cleared(i) = False
        Next
    End Sub

    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Stage6.BG.CB.Visibility = Visibility.Visible
            Owner.MoveTo(192, 224, 30)
            Grid.SetRowSpan(STG.SpellCardLabel.cardname, 5)
        ElseIf Ticks > 60 Then
            If Ticks Mod 60 = 0 Then
                If Owner.HP > 12000 Then
                    Preset1()
                ElseIf Owner.HP > 9000 Then
                    If Not cleared(0) Then
                        cleared(0) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "消化「爱德华·桑代克」"
                    End If
                    Preset2()
                ElseIf Owner.HP > 6000 Then
                    If Not cleared(1) Then
                        cleared(1) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "吸收「让·皮亚傑」"
                    End If
                    Preset3()
                ElseIf Owner.HP > 3000 Then
                    If Not cleared(2) Then
                        cleared(2) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "混交「梅拉尼·克莱因」"
                    End If
                    Preset4()
                Else
                    If Not cleared(3) Then
                        cleared(3) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "吸收「安娜·弗洛伊德」"
                    End If
                    Preset4()
                End If
            End If
            If Ticks Mod 10 = 0 AndAlso Owner.HP <= 3000 Then
                preset5()
            End If
        End If
    End Sub
    Public Sub Preset1()
        Dim c As Double = Rnd() * 360
        For i = 0 To 345 Step 15
            STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.5, i + c, 0))
        Next
    End Sub
    Public Sub Preset2()
        Dim c As Double = Rnd() * 360
        For i = 0 To 345 Step 15
            If i Mod 30 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B2H})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B2H})
            End If
        Next
    End Sub
    Public Sub Preset3()
        Dim c As Double = Rnd() * 360
        For i = 0 To 345 Step 15
            If i Mod 30 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B3H})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B3H})
            End If
        Next
    End Sub
    Public Sub Preset4()
        Dim c As Double = Rnd() * 360
        For i = 0 To 345 Step 15
            If i Mod 30 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B4H})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.5, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B4H})
            End If
        Next
    End Sub
    Public Sub preset5()
        Dim tx, ty, td As Double
        tx = 48
        ty = Rnd() * 448
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 100, 90))
        tx = 336
        ty = Rnd() * 448
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 100, 90))
        tx = Rnd() * 384
        ty = 48
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 100, 90))
        tx = Rnd() * 384
        ty = 400
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 100, 90))
    End Sub

    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Grid.SetRowSpan(STG.SpellCardLabel.cardname, 1)
        End If
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0602a.ReadLine()
            s = Texts.dialog0602a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0602a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0602b.ReadLine()
            s = Texts.dialog0602b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0602b)
            STG.DialogArea.Show()
        End If
        Stage6.Finished = True
        Return MyBase.Break()
    End Function
End Class
Module St6EnmH
    <Extension>
    Public Sub S6B8IH(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(8, i))
            Next
            .MoveTextures.Add(Textures.boss(8, 4))
            .SpellCards.Add(New B8S0H(e))
            .SpellCards.Add(New B8S1H(e))
            .SpellCards.Add(New B8S2H(e))
            .SpellCards.Add(New B8S3H(e))
            .SpellCards.Add(New B8S4H(e))
            .Layer3.Height = 96
            .Layer3.Width = 96
            Canvas.SetLeft(.Layer3, 16)
            Canvas.SetTop(.Layer3, 16)
            .Layer3_scale.CenterX = 48
            .Layer3.Fill = Textures.boss(8, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S6B8AH(e As Enemy.Boss)
        Static started As Boolean = False
        With e
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0601a.ReadLine()
                    s = Texts.dialog0601a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0601a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0601b.ReadLine()
                    s = Texts.dialog0601b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0601b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                .IsEnabled = True
                started = True
                STG.NameArea.Initialize("Shion", 5)

                ResourcePack.Sounds.StopSound(ResourcePack.Sounds.CurrentMusic)
                ResourcePack.Sounds.PlayMusic(Sounds.mu13)
                Stage.Showmusic("縁から外れた名前")
                ResourcePack.Sounds.CurrentMusic = Sounds.mu13
                .NextSpell()

            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B1H(e As Bullet)
        With e
            If .Ticks < 60 Then
                .Y += .Ticks * 0.03
            ElseIf .Ticks = 60 Then
                .Break(False)
                STG.Add(New Bullet(BulletType.刀弹, 2, .X, .Y, 0) With {.Act = AddressOf .B8S0B2H})
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B2H(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 1
            ElseIf .Ticks > 30 Then
                .Speed += 0.02
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B3H(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(1024, 1024, 0)
                .Background = Textures.circle_red
            Else
                .X = 600 * Sin(.Ticks / 180) + 192
                .Y = 600 * Cos(.Ticks / 180) + 224
            End If
            If .Ticks Mod 120 = 60 Then
                For i = -20 To 20 Step 2.5
                    Dim d As Double = i + Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + 512 * Sin(d / 180 * PI), .Y - 512 * Cos(d / 180 * PI), 1.5, d, 0) With {.Act = AddressOf .B8S0B5H})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = -20 To 20 Step 4
                    Dim d As Double = i + Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, .X + 512 * Sin(d / 180 * PI), .Y - 512 * Cos(d / 180 * PI), 1.5, d + 180, 0))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B4H(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(1024, 1024, 0)
                .Background = Textures.circle_blue
            Else
                .X = 500 * Sin(.Ticks / 180 + PI) + 192
                .Y = 500 * Cos(.Ticks / 180 + PI) + 224
                For Each b In STG.SearchBullet
                    If b.BulletColor = BulletColor.品红 AndAlso New Vector(b.X - .X, b.Y - .Y).Length < 512 Then
                        b.BulletColor = BulletColor.蓝
                        b.Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - b.X, .Y - b.Y))
                    End If
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B5H(e As Bullet)
        With e
            If .BulletColor = BulletColor.蓝 Then
                .Speed += 0.02
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B1H(e As Bullet)
        With e

            .Y += .Ticks * 0.02
        End With
    End Sub
    <Extension>
    Public Sub B8S1B2H(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(400, 400, 0)
                .Background = Textures.circle_magenta
            Else
                .Tag -= 0.1
                For Each o In STG.Objects
                    If o.ObjectType = ObjectType.PlayerBullet OrElse o.ObjectType = ObjectType.Bomb Then
                        If .GetDistance(o) < .Tag - 8 Then
                            For Each b In STG.SearchBullet
                                If b.BulletType = BulletType.中玉 AndAlso b.BulletColor = 1 Then
                                    b.Tag -= 1
                                End If
                            Next
                            o.Clear()
                            .Tag += 1
                        End If
                    End If
                Next

                If .Tag > 320 Then
                    .Tag = 320
                ElseIf .Tag < 32 Then
                    .Tag = 32
                End If
                .SetSize(.Tag * 2, .Tag * 2, 0)
            End If
            If .Ticks Mod 120 = 60 Then
                For i = 0 To 359.9 Step 1440 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r + 225, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4H})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = 0 To 359.9 Step 1440 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r - 45, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4H})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B3H(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(400, 400, 0)
                .Background = Textures.circle_cyan
            Else
                .Tag -= 0.1
                For Each o In STG.Objects
                    If o.ObjectType = ObjectType.PlayerBullet OrElse o.ObjectType = ObjectType.Bomb Then
                        If .GetDistance(o) < .Tag - 8 Then
                            For Each b In STG.SearchBullet
                                If b.BulletType = BulletType.中玉 AndAlso b.BulletColor = 0 Then
                                    b.Tag -= 1
                                End If
                            Next
                            o.Clear()
                            .Tag += 1
                        End If
                    End If
                Next

                If .Tag > 320 Then
                    .Tag = 320
                ElseIf .Tag < 32 Then
                    .Tag = 32
                End If
                .SetSize(.Tag * 2, .Tag * 2, 0)
            End If
            If .Ticks Mod 120 = 60 Then
                For i = 0 To 359.9 Step 1440 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r + 225, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4H})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = 0 To 359.9 Step 1440 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r - 45, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4H})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B4H(e As Bullet)
        With e
            If New Vector(.X - 192, .Y - 128).Length >= 320 Then
                .Breakable = True
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B1H(e As Bullet)
        With e
            If .Ticks = 61 Then
                .Speed = 2
            ElseIf .Ticks > 60 AndAlso .Ticks < 120 Then
                .X += .Speed * Sin(.Direction / 180 * PI)
                .Y -= .Speed * Cos(.Direction / 180 * PI)
            ElseIf .Ticks = 120 Then
                .Break(False)
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B2H(e As Bullet)
        With e
            If .Ticks = 60 Then
                If .BulletColor = BulletColor.红 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                Else
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y)) + 180
                End If
                .Speed = 1
            ElseIf .Ticks > 60 Then
                .Speed += 0.02
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B3H(e As Bullet)
        With e
            If .Ticks = 90 Then
                For i = 64 To 320 Step 64
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + i * Sin(.Direction / 180 * PI), .Y - i * Cos(.Direction / 180 * PI), 0, .Direction + 90, 0) With {.Act = AddressOf .B8S2B4H})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + i * Sin(.Direction / 180 * PI), .Y - i * Cos(.Direction / 180 * PI), 0, .Direction - 90, 0) With {.Act = AddressOf .B8S2B4H})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B4H(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 1
            Else
                .Speed += 0.02
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S3B1H(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 60 Then
                    .Direction += 2
                ElseIf .Ticks < 120 Then
                    .Direction -= 1
                End If
            Else
                If .Ticks < 60 Then
                    .Direction -= 2
                ElseIf .Ticks < 120 Then
                    .Direction += 1
                End If
            End If

        End With
    End Sub
    <Extension>
    Public Sub B8S4B2H(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 75 Then
                    .Direction += 1
                End If
            Else
                If .Ticks < 75 Then
                    .Direction -= 1
                End If
            End If

        End With
    End Sub
    <Extension>
    Public Sub B8S4B3H(e As Bullet)
        With e
            If .BulletColor = BulletColor.红 Then
                If .Tag = 1 Then
                    If .Ticks < 75 Then
                        .Direction += 1
                    End If
                Else
                    If .Ticks < 75 Then
                        .Direction -= 1
                    End If
                End If
                If .X < 8 OrElse .X > 376 OrElse .Y < 8 OrElse .Y > 440 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    .BulletColor = BulletColor.品红
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.kira00, 0.5)
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S4B4H(e As Bullet)
        With e
            If .BulletColor = BulletColor.红 Then
                If .Tag Mod 2 = 1 Then
                    If .Ticks < 75 Then
                        .Direction += 1
                    End If
                Else
                    If .Ticks < 75 Then
                        .Direction -= 1
                    End If
                End If
                If .X < 8 OrElse .X > 376 OrElse .Y < 8 OrElse .Y > 440 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    .BulletColor = BulletColor.品红
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.kira00, 0.5)
                End If
            End If
            If .Tag < 10 AndAlso .BulletColor = BulletColor.红 Then
                For Each b In STG.SearchBullet
                    If b.BulletType = BulletType.小玉 AndAlso b.BulletColor = BulletColor.品红 AndAlso New Vector(b.X - .X, b.Y - .Y).Length < 8 Then
                        STG.Add(New Bullet(BulletType.刀弹, 2, b.X, b.Y, 1.5, b.Direction, 0))
                        b.Break(False)
                        .Tag += 10
                        Exit For
                    End If
                Next
            End If
        End With
    End Sub
End Module

#End Region

#Region "Lunatic"
Public Class B8S0L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "「生的本能、死的欲望」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks > 60 AndAlso Ticks Mod 90 = 0 Then
                For i = 0 To 345 Step 15
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 2 + Rnd() * 1.2, i + Rnd() * 20 - 10, 0) With {.Act = AddressOf .B8S0B1L})
                Next
            End If

        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks = 10 Then
                STG.Add(New Bullet(BulletType.中玉, 0, 0, -600 + 224, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S0B3L})
                STG.Add(New Bullet(BulletType.中玉, 0, 0, 500 + 224, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S0B4L})
            End If
            If Ticks > 10 AndAlso Ticks Mod 100 = 0 Then
                For i = 0 To 340 Step 20
                    STG.Add(New Bullet(BulletType.刀弹, 2, Owner.X, Owner.Y, 1.5, i))
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        For Each b In STG.SearchBullet
            If Not b.Breakable Then
                b.Break(True, True)
            End If
        Next
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If

        Return MyBase.Break()
    End Function
End Class
Public Class B8S1L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "本能「超我」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 60 Then
                For i = 0 To 9
                    STG.Add(New Bullet.Laser(BulletColor.品红, 128, 38.5 * i, 225, 16, 200, 120))
                    STG.Add(New Bullet.Laser(BulletColor.品红, 256, 38.5 * i, 135, 16, 200, 120))
                Next
            ElseIf Ticks Mod 300 = 120 Then
                For i = 0 To 9
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 96, 38.5 * i + 32, 1 + Rnd() * 1.2, 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1L})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 64, 38.5 * i + 64, 1 + Rnd() * 1.2, 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1L})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 32, 38.5 * i + 96, 1 + Rnd() * 1.2, 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1L})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 0, 38.5 * i + 128, 1 + Rnd() * 1.2, 30 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1L})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 288, 38.5 * i + 32, 1 + Rnd() * 1.2, 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1L})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 320, 38.5 * i + 64, 1 + Rnd() * 1.2, 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1L})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 352, 38.5 * i + 96, 1 + Rnd() * 1.2, 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1L})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 384, 38.5 * i + 128, 1 + Rnd() * 1.2, 285 + Rnd() * 30, 0) With {.Act = AddressOf .B8S1B1L})
                Next
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks = 10 Then
                STG.Add(New Bullet(BulletType.中玉, 0, 0, 128, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S1B2L, .Tag = 200})
                STG.Add(New Bullet(BulletType.中玉, 1, 384, 128, 0, 0, 0) With {.Breakable = False, .Act = AddressOf .B8S1B3L, .Tag = 200})
            End If

        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            For Each b In STG.SearchBullet
                If Not b.Breakable Then
                    b.Break(True, True)
                End If
            Next
        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S2L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3200
        UsualTime = 2400
        SpellHP = 2800
        SpellTime = 2700
        Score = 8000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "灵素「接近维克多」"
    End Sub
    Private c As Double

    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then

            If Ticks Mod 240 = 60 Then
                c = Rnd() * 45
                For i = 0 To 330 Step 30
                    STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c + i, 16, 240, 180) With {.Act = AddressOf .B8S2B1L})
                Next
            ElseIf Ticks Mod 240 = 180 Then
                For i = 0 To 330 Step 30
                    For j = 0 To 7
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X + 48 * j * Sin((c + i) / 180 * PI), Owner.Y - 48 * j * Cos((c + i) / 180 * PI), 0, c + i, 0) With {.Act = AddressOf .B8S2B2L})
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X + 48 * j * Sin((c + i) / 180 * PI), Owner.Y - 48 * j * Cos((c + i) / 180 * PI), 0, c + i, 0) With {.Act = AddressOf .B8S2B2L})
                    Next
                Next
            End If

        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
                Stage6.BG.CB.Visibility = Visibility.Visible
            End If
            If Ticks Mod 180 = 60 Then
                Owner.MoveTo(64 + Rnd() * 256, 64 + Rnd() * 320, 60)
                c = Owner.Direction + 90
            ElseIf Ticks Mod 180 = 80 OrElse Ticks Mod 180 = 93 OrElse Ticks Mod 180 = 107 OrElse Ticks Mod 180 = 120 Then
                STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c, 16, 320, 100) With {.Act = AddressOf .B8S2B3L})
                STG.Add(New Bullet.Laser(BulletColor.品红, Owner.X, Owner.Y, c + 180, 16, 320, 100) With {.Act = AddressOf .B8S2B3L})
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then

        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S3L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3200
        SpellTime = 2700
        Score = 8000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "吸魂「渐远的自我」"
    End Sub

    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Stage6.BG.CB.Visibility = Visibility.Visible
        ElseIf Ticks > 60 Then
            If Ticks Mod 50 = 0 Then
                Dim c As Double = Rnd() * 120
                For i = 0 To 340 Step 20
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1.8, i + c, 0) With {.Act = AddressOf .B8S3B1L, .Tag = 1})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, Owner.X, Owner.Y, 1.8, i + c, 0) With {.Act = AddressOf .B8S3B1L, .Tag = 2})
                Next
                For i = 0 To 288 Step 72
                    STG.Add(New Bullet(BulletType.大玉, 1, Owner.X, Owner.Y, 1.8, i + c, 0))
                Next
            End If
            Dim d As Double = 448 - Ticks / 2
            If d < 40 Then
                d = 40
            End If
            For Each b In STG.SearchBullet
                If New Vector(b.X - Owner.X, b.Y - Owner.Y).Length > d Then
                    b.Opacity = 0.5 + 0.5 * Sin(Ticks / 30)
                End If
            Next
        End If
    End Sub

    Public Overrides Function Break() As Boolean
        If AtSpell Then

        End If
        Owner.MoveToCenter(30)
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Return MyBase.Break()
    End Function
End Class
Public Class B8S4L
    Inherits SpellCard
    Private cleared(3) As Boolean
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 15000
        SpellTime = 7200
        Score = 10000000
        StageCount = 5
        StagePercent = {0.2, 0.4, 0.6, 0.8, 1}
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "咀嚼「玛格丽特·马拉」"
        For i = 0 To 3
            cleared(i) = False
        Next
    End Sub

    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Stage6.BG.CB.Visibility = Visibility.Visible
            Owner.MoveTo(192, 224, 30)
            Grid.SetRowSpan(STG.SpellCardLabel.cardname, 5)
        ElseIf Ticks > 60 Then
            If Ticks Mod 45 = 0 Then
                If Owner.HP > 12000 Then
                    Preset1()
                ElseIf Owner.HP > 9000 Then
                    If Not cleared(0) Then
                        cleared(0) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "消化「爱德华·桑代克」"
                    End If
                    Preset2()
                ElseIf Owner.HP > 6000 Then
                    If Not cleared(1) Then
                        cleared(1) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "吸收「让·皮亚傑」"
                    End If
                    Preset3()
                ElseIf Owner.HP > 3000 Then
                    If Not cleared(2) Then
                        cleared(2) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "混交「梅拉尼·克莱因」"
                    End If
                    Preset4()
                Else
                    If Not cleared(3) Then
                        cleared(3) = True
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.cat00)
                        STG.SpellCardLabel.cardname.Content += vbCrLf + "吸收「安娜·弗洛伊德」"
                    End If
                    Preset4()
                End If
            End If
            If Ticks Mod 10 = 0 AndAlso Owner.HP <= 3000 Then
                preset5()
            End If
        End If
    End Sub
    Public Sub Preset1()
        Dim c As Double = Rnd() * 360
        For i = 0 To 348 Step 12
            STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.8, i + c, 0))
        Next
    End Sub
    Public Sub Preset2()
        Dim c As Double = Rnd() * 360
        For i = 0 To 348 Step 12
            If i Mod 24 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.8, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B2L})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1.8, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B2L})
            End If
        Next
    End Sub
    Public Sub Preset3()
        Dim c As Double = Rnd() * 360
        For i = 0 To 348 Step 12
            If i Mod 24 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.8, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B3L})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.8, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B3L})
            End If
        Next
    End Sub
    Public Sub Preset4()
        Dim c As Double = Rnd() * 360
        For i = 0 To 348 Step 12
            If i Mod 24 = 0 Then
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.8, i + c, 0) With {.Tag = 1, .Act = AddressOf .B8S4B4L})
            Else
                STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.8, i + c, 0) With {.Tag = 2, .Act = AddressOf .B8S4B4L})
            End If
        Next
    End Sub
    Public Sub preset5()
        Dim tx, ty, td As Double
        tx = 48
        ty = Rnd() * 448
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 120, 90))
        tx = 336
        ty = Rnd() * 448
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 120, 90))
        tx = Rnd() * 384
        ty = 48
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 120, 90))
        tx = Rnd() * 384
        ty = 400
        td = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - tx, 224 - ty)) + 180
        STG.Add(New Bullet.Laser(BulletColor.品红, tx, ty, td, 8, 120, 90))
    End Sub

    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Grid.SetRowSpan(STG.SpellCardLabel.cardname, 1)
        End If
        If AtSpell Then
            Stage6.BG.CB.Visibility = Visibility.Hidden
        End If
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0602a.ReadLine()
            s = Texts.dialog0602a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0602a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0602b.ReadLine()
            s = Texts.dialog0602b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0602b)
            STG.DialogArea.Show()
        End If
        Stage6.Finished = True
        Return MyBase.Break()
    End Function
End Class
Module St6EnmL
    <Extension>
    Public Sub S6B8IL(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(8, i))
            Next
            .MoveTextures.Add(Textures.boss(8, 4))
            .SpellCards.Add(New B8S0L(e))
            .SpellCards.Add(New B8S1L(e))
            .SpellCards.Add(New B8S2L(e))
            .SpellCards.Add(New B8S3L(e))
            .SpellCards.Add(New B8S4L(e))
            .Layer3.Height = 96
            .Layer3.Width = 96
            Canvas.SetLeft(.Layer3, 16)
            Canvas.SetTop(.Layer3, 16)
            .Layer3_scale.CenterX = 48
            .Layer3.Fill = Textures.boss(8, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S6B8AL(e As Enemy.Boss)
        Static started As Boolean = False
        With e
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0601a.ReadLine()
                    s = Texts.dialog0601a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0601a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0601b.ReadLine()
                    s = Texts.dialog0601b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0601b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                .IsEnabled = True
                started = True
                STG.NameArea.Initialize("Shion", 5)

                ResourcePack.Sounds.StopSound(ResourcePack.Sounds.CurrentMusic)
                ResourcePack.Sounds.PlayMusic(Sounds.mu13)
                Stage.Showmusic("縁から外れた名前")
                ResourcePack.Sounds.CurrentMusic = Sounds.mu13
                .NextSpell()

            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B1L(e As Bullet)
        With e
            If .Ticks < 60 Then
                .Y += .Ticks * 0.03
            ElseIf .Ticks = 60 Then
                .Break(False)
                STG.Add(New Bullet(BulletType.刀弹, 2, .X, .Y, 0) With {.Act = AddressOf .B8S0B2L})
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B2L(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 1
            ElseIf .Ticks > 30 Then
                .Speed += 0.02
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B3L(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(1024, 1024, 0)
                .Background = Textures.circle_red
            Else
                .X = 600 * Sin(.Ticks / 180) + 192
                .Y = 600 * Cos(.Ticks / 180) + 224
            End If
            If .Ticks Mod 120 = 60 Then
                For i = -20 To 20 Step 2
                    Dim d As Double = i + Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + 512 * Sin(d / 180 * PI), .Y - 512 * Cos(d / 180 * PI), 1.8, d, 0) With {.Act = AddressOf .B8S0B5L})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = -20 To 20 Step 2.5
                    Dim d As Double = i + Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, .X + 512 * Sin(d / 180 * PI), .Y - 512 * Cos(d / 180 * PI), 1.8, d + 180, 0))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B4L(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(1024, 1024, 0)
                .Background = Textures.circle_blue
            Else
                .X = 500 * Sin(.Ticks / 180 + PI) + 192
                .Y = 500 * Cos(.Ticks / 180 + PI) + 224
                For Each b In STG.SearchBullet
                    If b.BulletColor = BulletColor.品红 AndAlso New Vector(b.X - .X, b.Y - .Y).Length < 512 Then
                        b.BulletColor = BulletColor.蓝
                        b.Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - b.X, .Y - b.Y))
                    End If
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S0B5L(e As Bullet)
        With e
            If .BulletColor = BulletColor.蓝 Then
                .Speed += 0.02
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B1L(e As Bullet)
        With e

            .Y += .Ticks * 0.02
        End With
    End Sub
    <Extension>
    Public Sub B8S1B2L(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(400, 400, 0)
                .Background = Textures.circle_magenta
            Else
                .Tag -= 0.1
                For Each o In STG.Objects
                    If o.ObjectType = ObjectType.PlayerBullet OrElse o.ObjectType = ObjectType.Bomb Then
                        If .GetDistance(o) < .Tag - 8 Then
                            For Each b In STG.SearchBullet
                                If b.BulletType = BulletType.中玉 AndAlso b.BulletColor = 1 Then
                                    b.Tag -= 1
                                End If
                            Next
                            o.Clear()
                            .Tag += 1
                        End If
                    End If
                Next

                If .Tag > 320 Then
                    .Tag = 320
                ElseIf .Tag < 32 Then
                    .Tag = 32
                End If
                .SetSize(.Tag * 2, .Tag * 2, 0)
            End If
            If .Ticks Mod 120 = 60 Then
                For i = 0 To 359.9 Step 1080 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1.2, r + 225, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4L})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = 0 To 359.9 Step 1080 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1.2, r - 45, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4L})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B3L(e As Bullet)
        With e
            If .Ticks = 16 Then
                .SetSize(400, 400, 0)
                .Background = Textures.circle_cyan
            Else
                .Tag -= 0.1
                For Each o In STG.Objects
                    If o.ObjectType = ObjectType.PlayerBullet OrElse o.ObjectType = ObjectType.Bomb Then
                        If .GetDistance(o) < .Tag - 8 Then
                            For Each b In STG.SearchBullet
                                If b.BulletType = BulletType.中玉 AndAlso b.BulletColor = 0 Then
                                    b.Tag -= 1
                                End If
                            Next
                            o.Clear()
                            .Tag += 1
                        End If
                    End If
                Next

                If .Tag > 320 Then
                    .Tag = 320
                ElseIf .Tag < 32 Then
                    .Tag = 32
                End If
                .SetSize(.Tag * 2, .Tag * 2, 0)
            End If
            If .Ticks Mod 120 = 60 Then
                For i = 0 To 359.9 Step 1440 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r + 225, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4L})
                Next
            ElseIf .Ticks Mod 120 = 0 Then
                For i = 0 To 359.9 Step 1440 / .Tag
                    Dim tx As Double = .X + .Tag * Sin(i / 180 * PI)
                    Dim ty As Double = .Y - .Tag * Cos(i / 180 * PI)
                    Dim r As Double = Vector.AngleBetween(New Vector(0, -1), New Vector(.X - tx, .Y - ty))
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, tx, ty, 1, r - 45, 0) With {.Breakable = False, .Act = AddressOf .B8S1B4L})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S1B4L(e As Bullet)
        With e
            If New Vector(.X - 192, .Y - 128).Length >= 320 Then
                .Breakable = True
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B1L(e As Bullet)
        With e
            If .Ticks = 61 Then
                .Speed = 2
            ElseIf .Ticks > 60 AndAlso .Ticks < 120 Then
                .X += .Speed * Sin(.Direction / 180 * PI)
                .Y -= .Speed * Cos(.Direction / 180 * PI)
            ElseIf .Ticks = 120 Then
                .Break(False)
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B2L(e As Bullet)
        With e
            If .Ticks = 60 Then
                If .BulletColor = BulletColor.红 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                Else
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y)) + 180
                End If
                .Speed = 1
            ElseIf .Ticks > 60 Then
                .Speed += 0.025
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B3L(e As Bullet)
        With e
            If .Ticks = 90 Then
                For i = 70 To 320 Step 50
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + i * Sin(.Direction / 180 * PI), .Y - i * Cos(.Direction / 180 * PI), 0, .Direction + 90, 0) With {.Act = AddressOf .B8S2B4L})
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X + i * Sin(.Direction / 180 * PI), .Y - i * Cos(.Direction / 180 * PI), 0, .Direction - 90, 0) With {.Act = AddressOf .B8S2B4L})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S2B4L(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 1
            Else
                .Speed += 0.02
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S3B1L(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 60 Then
                    .Direction += 2
                ElseIf .Ticks < 120 Then
                    .Direction -= 1
                End If
            Else
                If .Ticks < 60 Then
                    .Direction -= 2
                ElseIf .Ticks < 120 Then
                    .Direction += 1
                End If
            End If

        End With
    End Sub
    <Extension>
    Public Sub B8S4B2L(e As Bullet)
        With e
            If .Tag = 1 Then
                If .Ticks < 75 Then
                    .Direction += 1
                End If
            Else
                If .Ticks < 75 Then
                    .Direction -= 1
                End If
            End If

        End With
    End Sub
    <Extension>
    Public Sub B8S4B3L(e As Bullet)
        With e
            If .BulletColor = BulletColor.红 Then
                If .Tag = 1 Then
                    If .Ticks < 75 Then
                        .Direction += 1
                    End If
                Else
                    If .Ticks < 75 Then
                        .Direction -= 1
                    End If
                End If
                If .X < 8 OrElse .X > 376 OrElse .Y < 8 OrElse .Y > 440 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    .BulletColor = BulletColor.品红
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.kira00, 0.5)
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub B8S4B4L(e As Bullet)
        With e
            If .BulletColor = BulletColor.红 Then
                If .Tag Mod 2 = 1 Then
                    If .Ticks < 75 Then
                        .Direction += 1
                    End If
                Else
                    If .Ticks < 75 Then
                        .Direction -= 1
                    End If
                End If
                If .X < 8 OrElse .X > 376 OrElse .Y < 8 OrElse .Y > 440 Then
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(192 - .X, 224 - .Y))
                    .BulletColor = BulletColor.品红
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.kira00, 0.5)
                End If
            End If
            If .Tag < 10 AndAlso .BulletColor = BulletColor.红 Then
                For Each b In STG.SearchBullet
                    If b.BulletType = BulletType.小玉 AndAlso b.BulletColor = BulletColor.品红 AndAlso New Vector(b.X - .X, b.Y - .Y).Length < 8 Then
                        STG.Add(New Bullet(BulletType.刀弹, 2, b.X, b.Y, 1.8, b.Direction, 0))
                        b.Break(False)
                        .Tag += 10
                        Exit For
                    End If
                Next
            End If
        End With
    End Sub
End Module

#End Region