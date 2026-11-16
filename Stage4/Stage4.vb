Imports System.Math
Imports System.Runtime.CompilerServices
Imports AgSTG
Imports ResourcePack.TH07
Public Class Stage4
    Inherits Stage
    Public Shared BG As Stage4bg
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

    Public Overrides Sub Action()
        EnemySpawn()
        BG.Render()
        If Ticks = 1 Then
            Showmusic("春岚")
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
        Background = New Stage4bg
        BG = Background
        Finished = False
        EndFrame = 0
    End Sub

    Private Sub EnemySpawnE()
        Select Case Ticks
            Case 440 To 680
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -32, 64 + Rnd() * 64, 10, "1", 160, 2, 90) With {.Act = AddressOf .S4W1E})
                End If
            Case 840 To 1080
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 416, 64 + Rnd() * 64, 10, "0", 160, 2, 270) With {.Act = AddressOf .S4W1E})
                End If
            Case 1240 To 1480
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -32, 64 + Rnd() * 64, 10, "01", 160, 2, 90) With {.Act = AddressOf .S4W1E})
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 416, 64 + Rnd() * 64, 10, "01", 160, 2, 270) With {.Act = AddressOf .S4W1E})
                End If
            Case 2580
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 224, 200, "00001111", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W2E})
            Case 2600 To 2780
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 224, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3E})
                End If
            Case 2940
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 224, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2E})
            Case 2960 To 3140
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 224, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3E})
                End If
            Case 3340 To 3820
                If Ticks Mod 40 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 384, -16, 20, "01", 320, 2, 225) With {.Tag = 21, .Act = AddressOf .S4W3E})
                ElseIf Ticks Mod 40 = 20 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 0, -16, 20, "01", 320, 2, 135) With {.Tag = 22, .Act = AddressOf .S4W3E})
                End If
                If Ticks Mod 80 = 0 Then
                    STG.Add(New Enemy(EnemyType.小蝴蝶, 1, 32 + 320 * Rnd(), -16, 50, "0011", 320, 1.5, 180) With {.Tag = 21, .Act = AddressOf .S4W4E})
                End If
            Case 4080
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 315) With {.Tag = 21, .Act = AddressOf .S4W2E})
            Case 4100 To 4280
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 315) With {.Tag = 11, .Act = AddressOf .S4W3E})
                End If
            Case 4440
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 128, 200, "00001111", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W2E})
            Case 4460 To 4640
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 128, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3E})
                End If
            Case 4860
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2E})
            Case 4880 To 5060
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3E})
                End If
            Case 5220
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W2E})
            Case 5240 To 5420
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W3E})
                End If
            Case 5580
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 320, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2E})
            Case 5600 To 5780
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 320, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3E})
                End If
            Case 6000
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 320, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2E})
            Case 6020 To 6200
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 320, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3E})
                End If
            Case 6360 To 6940
                If Ticks Mod 40 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 384, -16, 20, "01", 320, 2, 225) With {.Tag = 31, .Act = AddressOf .S4W3E})
                ElseIf Ticks Mod 40 = 20 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 0, -16, 40, "01", 320, 2, 135) With {.Tag = 32, .Act = AddressOf .S4W3E})
                End If
                If Ticks Mod 80 = 0 Then
                    STG.Add(New Enemy(EnemyType.小蝴蝶, 1, 32 + 320 * Rnd(), -16, 80, "0011", 320, 1.5, 180) With {.Tag = 21, .Act = AddressOf .S4W4E})
                End If
            Case 7140
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S4B5IE), .Act = New Action(AddressOf .S4B5AE)})
            Case 9420
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W2E})
            Case 9440 To 9620
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W3E})
                End If
            Case 9720
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2E})
            Case 9740 To 9920
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3E})
                End If
            Case 10020
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 320, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2E})
            Case 10040 To 10120
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 320, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3E})
                End If
            Case 10200
                STG.Add(New Bullet(BulletType.中玉, 0, 192, 128, 0, 0, 0) With {.Act = AddressOf .WordsE, .Breakable = False})
            Case 11400
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, -64, 2000, "00000000111111116", 2400, 3, 180) With {.Act = AddressOf .S4W5E})
            Case 13200
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S4B6IE), .Act = New Action(AddressOf .S4B6AE)})
        End Select
        Select Case Ticks
            Case 5740
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W2E})
            Case 5760 To 5960
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3E})
                End If
            Case 6160
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 128, 200, "00001111", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W2E})
            Case 6180 To 6360
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 128, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3E})
                End If

        End Select
    End Sub

    Private Sub EnemySpawnN()
        Select Case Ticks
            Case 440 To 680
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -32, 64 + Rnd() * 64, 10, "1", 160, 2, 90) With {.Act = AddressOf .S4W1N})
                End If
            Case 840 To 1080
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 416, 64 + Rnd() * 64, 10, "0", 160, 2, 270) With {.Act = AddressOf .S4W1N})
                End If
            Case 1240 To 1480
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -32, 64 + Rnd() * 64, 10, "01", 160, 2, 90) With {.Act = AddressOf .S4W1N})
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 416, 64 + Rnd() * 64, 10, "01", 160, 2, 270) With {.Act = AddressOf .S4W1N})
                End If
            Case 2580
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 224, 200, "00001111", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W2N})
            Case 2600 To 2780
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 224, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3N})
                End If
            Case 2940
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 224, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2N})
            Case 2960 To 3140
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 224, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3N})
                End If
            Case 3340 To 3820
                If Ticks Mod 40 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 384, -16, 20, "01", 320, 2, 225) With {.Tag = 21, .Act = AddressOf .S4W3N})
                ElseIf Ticks Mod 40 = 20 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 0, -16, 20, "01", 320, 2, 135) With {.Tag = 22, .Act = AddressOf .S4W3N})
                End If
                If Ticks Mod 80 = 0 Then
                    STG.Add(New Enemy(EnemyType.小蝴蝶, 1, 32 + 320 * Rnd(), -16, 50, "0011", 320, 1.5, 180) With {.Tag = 21, .Act = AddressOf .S4W4N})
                End If
            Case 4080
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 315) With {.Tag = 21, .Act = AddressOf .S4W2N})
            Case 4100 To 4280
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 315) With {.Tag = 11, .Act = AddressOf .S4W3N})
                End If
            Case 4440
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 128, 200, "00001111", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W2N})
            Case 4460 To 4640
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 128, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3N})
                End If
            Case 4860
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2N})
            Case 4880 To 5060
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3N})
                End If
            Case 5220
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W2N})
            Case 5240 To 5420
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W3N})
                End If
            Case 5580
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 320, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2N})
            Case 5600 To 5780
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 320, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3N})
                End If
            Case 6000
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 320, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2N})
            Case 6020 To 6200
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 320, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3N})
                End If
            Case 6360 To 6940
                If Ticks Mod 40 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 384, -16, 20, "01", 320, 2, 225) With {.Tag = 31, .Act = AddressOf .S4W3N})
                ElseIf Ticks Mod 40 = 20 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 0, -16, 40, "01", 320, 2, 135) With {.Tag = 32, .Act = AddressOf .S4W3N})
                End If
                If Ticks Mod 80 = 0 Then
                    STG.Add(New Enemy(EnemyType.小蝴蝶, 1, 32 + 320 * Rnd(), -16, 80, "0011", 320, 1.5, 180) With {.Tag = 21, .Act = AddressOf .S4W4N})
                End If
            Case 7140
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S4B5IN), .Act = New Action(AddressOf .S4B5AN)})
            Case 9420
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W2N})
            Case 9440 To 9620
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W3N})
                End If
            Case 9720
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2N})
            Case 9740 To 9920
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3N})
                End If
            Case 10020
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 320, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2N})
            Case 10040 To 10120
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 320, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3N})
                End If
            Case 10200
                STG.Add(New Bullet(BulletType.中玉, 0, 192, 128, 0, 0, 0) With {.Act = AddressOf .WordsN, .Breakable = False})
            Case 11400
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, -64, 2000, "00000000111111116", 2400, 3, 180) With {.Act = AddressOf .S4W5N})
            Case 13200
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S4B6IN), .Act = New Action(AddressOf .S4B6AN)})
        End Select
        Select Case Ticks
            Case 5740
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W2N})
            Case 5760 To 5960
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3N})
                End If
            Case 6160
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 128, 200, "00001111", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W2N})
            Case 6180 To 6360
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 128, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3N})
                End If

        End Select
    End Sub

    Private Sub EnemySpawnH()
        Select Case Ticks
            Case 440 To 680
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -32, 64 + Rnd() * 64, 10, "1", 160, 2, 90) With {.Act = AddressOf .S4W1H})
                End If
            Case 840 To 1080
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 416, 64 + Rnd() * 64, 10, "0", 160, 2, 270) With {.Act = AddressOf .S4W1H})
                End If
            Case 1240 To 1480
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -32, 64 + Rnd() * 64, 10, "01", 160, 2, 90) With {.Act = AddressOf .S4W1H})
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 416, 64 + Rnd() * 64, 10, "01", 160, 2, 270) With {.Act = AddressOf .S4W1H})
                End If
            Case 2580
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 224, 200, "00001111", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W2H})
            Case 2600 To 2780
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 224, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3H})
                End If
            Case 2940
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 224, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2H})
            Case 2960 To 3140
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 224, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3H})
                End If
            Case 3340 To 3820
                If Ticks Mod 40 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 384, -16, 20, "01", 320, 2, 225) With {.Tag = 21, .Act = AddressOf .S4W3H})
                ElseIf Ticks Mod 40 = 20 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 0, -16, 20, "01", 320, 2, 135) With {.Tag = 22, .Act = AddressOf .S4W3H})
                End If
                If Ticks Mod 80 = 0 Then
                    STG.Add(New Enemy(EnemyType.小蝴蝶, 1, 32 + 320 * Rnd(), -16, 50, "0011", 320, 1.5, 180) With {.Tag = 21, .Act = AddressOf .S4W4H})
                End If
            Case 4080
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 315) With {.Tag = 21, .Act = AddressOf .S4W2H})
            Case 4100 To 4280
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 315) With {.Tag = 11, .Act = AddressOf .S4W3H})
                End If
            Case 4440
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 128, 200, "00001111", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W2H})
            Case 4460 To 4640
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 128, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3H})
                End If
            Case 4860
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2H})
            Case 4880 To 5060
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3H})
                End If
            Case 5220
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W2H})
            Case 5240 To 5420
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W3H})
                End If
            Case 5580
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 320, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2H})
            Case 5600 To 5780
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 320, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3H})
                End If
            Case 6000
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 320, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2H})
            Case 6020 To 6200
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 320, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3H})
                End If
            Case 6360 To 6940
                If Ticks Mod 40 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 384, -16, 20, "01", 320, 2, 225) With {.Tag = 31, .Act = AddressOf .S4W3H})
                ElseIf Ticks Mod 40 = 20 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 0, -16, 40, "01", 320, 2, 135) With {.Tag = 32, .Act = AddressOf .S4W3H})
                End If
                If Ticks Mod 80 = 0 Then
                    STG.Add(New Enemy(EnemyType.小蝴蝶, 1, 32 + 320 * Rnd(), -16, 80, "0011", 320, 1.5, 180) With {.Tag = 21, .Act = AddressOf .S4W4H})
                End If
            Case 7140
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S4B5IH), .Act = New Action(AddressOf .S4B5AH)})
            Case 9420
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W2H})
            Case 9440 To 9620
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W3H})
                End If
            Case 9720
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2H})
            Case 9740 To 9920
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3H})
                End If
            Case 10020
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 320, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2H})
            Case 10040 To 10120
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 320, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3H})
                End If
            Case 10200
                STG.Add(New Bullet(BulletType.中玉, 0, 192, 128, 0, 0, 0) With {.Act = AddressOf .WordsH, .Breakable = False})
            Case 11400
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, -64, 2000, "00000000111111116", 2400, 3, 180) With {.Act = AddressOf .S4W5H})
            Case 13200
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S4B6IH), .Act = New Action(AddressOf .S4B6AH)})
        End Select
        Select Case Ticks
            Case 5740
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W2H})
            Case 5760 To 5960
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3H})
                End If
            Case 6160
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 128, 200, "00001111", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W2H})
            Case 6180 To 6360
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 128, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3H})
                End If

        End Select
    End Sub

    Private Sub EnemySpawnL()
        Select Case Ticks
            Case 440 To 680
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -32, 64 + Rnd() * 64, 10, "1", 160, 2, 90) With {.Act = AddressOf .S4W1L})
                End If
            Case 840 To 1080
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 416, 64 + Rnd() * 64, 10, "0", 160, 2, 270) With {.Act = AddressOf .S4W1L})
                End If
            Case 1240 To 1480
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -32, 64 + Rnd() * 64, 10, "01", 160, 2, 90) With {.Act = AddressOf .S4W1L})
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 416, 64 + Rnd() * 64, 10, "01", 160, 2, 270) With {.Act = AddressOf .S4W1L})
                End If
            Case 2580
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 224, 200, "00001111", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W2L})
            Case 2600 To 2780
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 224, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3L})
                End If
            Case 2940
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 224, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2L})
            Case 2960 To 3140
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 224, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3L})
                End If
            Case 3340 To 3820
                If Ticks Mod 40 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 384, -16, 20, "01", 320, 2, 225) With {.Tag = 21, .Act = AddressOf .S4W3L})
                ElseIf Ticks Mod 40 = 20 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 0, -16, 20, "01", 320, 2, 135) With {.Tag = 22, .Act = AddressOf .S4W3L})
                End If
                If Ticks Mod 80 = 0 Then
                    STG.Add(New Enemy(EnemyType.小蝴蝶, 1, 32 + 320 * Rnd(), -16, 50, "0011", 320, 1.5, 180) With {.Tag = 21, .Act = AddressOf .S4W4L})
                End If
            Case 4080
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 315) With {.Tag = 21, .Act = AddressOf .S4W2L})
            Case 4100 To 4280
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 315) With {.Tag = 11, .Act = AddressOf .S4W3L})
                End If
            Case 4440
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 128, 200, "00001111", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W2L})
            Case 4460 To 4640
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 128, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3L})
                End If
            Case 4860
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2L})
            Case 4880 To 5060
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3L})
                End If
            Case 5220
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W2L})
            Case 5240 To 5420
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W3L})
                End If
            Case 5580
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 320, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2L})
            Case 5600 To 5780
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 320, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3L})
                End If
            Case 6000
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 320, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2L})
            Case 6020 To 6200
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 320, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3L})
                End If
            Case 6360 To 6940
                If Ticks Mod 40 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 384, -16, 20, "01", 320, 2, 225) With {.Tag = 31, .Act = AddressOf .S4W3L})
                ElseIf Ticks Mod 40 = 20 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 0, -16, 40, "01", 320, 2, 135) With {.Tag = 32, .Act = AddressOf .S4W3L})
                End If
                If Ticks Mod 80 = 0 Then
                    STG.Add(New Enemy(EnemyType.小蝴蝶, 1, 32 + 320 * Rnd(), -16, 80, "0011", 320, 1.5, 180) With {.Tag = 21, .Act = AddressOf .S4W4L})
                End If
            Case 7140
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S4B5IL), .Act = New Action(AddressOf .S4B5AL)})
            Case 9420
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, 512, 200, "00001111", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W2L})
            Case 9440 To 9620
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 192, 512, 20, "01", 320, 1.5, 45) With {.Tag = 12, .Act = AddressOf .S4W3L})
                End If
            Case 9720
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 21, .Act = AddressOf .S4W2L})
            Case 9740 To 9920
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3L})
                End If
            Case 10020
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 320, 200, "00001111", 320, 1.5, 135) With {.Tag = 22, .Act = AddressOf .S4W2L})
            Case 10040 To 10120
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 320, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3L})
                End If
            Case 10200
                STG.Add(New Bullet(BulletType.中玉, 0, 192, 128, 0, 0, 0) With {.Act = AddressOf .WordsL, .Breakable = False})
            Case 11400
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 192, -64, 2000, "00000000111111116", 2400, 3, 180) With {.Act = AddressOf .S4W5L})
            Case 13200
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S4B6IL), .Act = New Action(AddressOf .S4B6AL)})
        End Select
        Select Case Ticks
            Case 5740
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, 448, 128, 200, "00001111", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W2L})
            Case 5760 To 5960
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 448, 128, 20, "01", 320, 1.5, 225) With {.Tag = 11, .Act = AddressOf .S4W3L})
                End If
            Case 6160
                STG.Add(New Enemy(EnemyType.大蝴蝶, 0, -64, 128, 200, "00001111", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W2L})
            Case 6180 To 6360
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -64, 128, 20, "01", 320, 1.5, 135) With {.Tag = 12, .Act = AddressOf .S4W3L})
                End If

        End Select
    End Sub
End Class

#Region "Easy"
Public Class B5S0E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 4000
        UsualTime = 2160
        HaveUsual = True
        Items = "000000000011111111115"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        Dim t As Integer = Ticks Mod 900
        Select Case t
            Case 60
                Owner.MoveTo(80, 192, 30)
            Case 90
                Preset1()
            Case 105
                Preset2()
            Case 180
                Owner.MoveTo(304, 192, 30)
            Case 210
                Preset1()
            Case 225
                Preset2()
            Case 300
                Owner.MoveTo(192, 128, 30)
            Case 330
                Preset1()
            Case 345
                Preset2()
            Case 450
                Owner.MoveTo(192, 256, 30)
            Case 480
                Owner.MoveTo(192, 128, 200)
            Case 490 To 690
                If Ticks Mod 10 = 0 Then
                    Preset3((t - 480) \ 10)
                End If
        End Select
    End Sub
    Private Sub Preset1()
        For i = 0 To 300 Step 60
            For j = 0 To 5
                STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, Owner.X, Owner.Y, j / 1.75, i + j * 6, 0) With {.Act = AddressOf .B5S0B1E})
            Next
        Next
    End Sub
    Private Sub Preset2()
        For i = 0 To 300 Step 60
            For j = 0 To 5
                STG.Add(New Bullet(BulletType.鳞弹, BulletColor.橙, Owner.X, Owner.Y, j / 1.75, i + 30 + j * 6, 0) With {.Act = AddressOf .B5S0B2E})
            Next
        Next
    End Sub
    Private Sub Preset3(n As Integer)
        Dim m As Integer = (n + 1) \ 2
        If n Mod 2 = 0 Then
            For i = 210 - (m / 2) * 5 To 210 + (m / 2) * 5 - 1 Step 15
                STG.Add(New Bullet(BulletType.小星弹, BulletColor.黄, Owner.X, Owner.Y, 1, i + Rnd() * 5 - 2.5, 0))
            Next
        Else
            For i = 150 - (m / 2) * 5 To 150 + (m / 2) * 5 - 1 Step 15
                STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 1, i + Rnd() * 5 - 2.5, 0))
            Next
        End If
    End Sub
End Class
Public Class B6S0E
    Inherits SpellCard
    Private c As Integer
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "糖符「Von Bon Bon大玉夫人」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 600
            If t < 300 Then
                If t = 90 Then
                    c = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
                If t >= 90 AndAlso t < 150 Then
                    If t Mod 5 = 0 Then
                        For i = 0 To 315 Step 45
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, Owner.X, Owner.Y, t / 60, i + c, 0))
                        Next
                    End If
                End If
                If t = 150 OrElse t = 250 Then
                    For i = -90 To 90 Step 45
                        STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1, i))
                    Next
                ElseIf t = 200 Then
                    For i = -90 To 90 Step 45
                        STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1, i + 20))
                    Next
                End If
                If t = 270 Then
                    Owner.DefaultMove(30)
                End If
            Else
                If t = 390 Then
                    c = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
                If t >= 390 AndAlso t < 450 Then
                    If t Mod 5 = 0 Then
                        For i = 0 To 315 Step 45
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.黄, Owner.X, Owner.Y, t / 60 - 5, i + c, 0))
                        Next
                    End If
                End If
                If t = 450 OrElse t = 500 OrElse t = 550 Then
                    For i = 0 To 300 Step 60
                        STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.2, i))
                    Next
                End If
                If t = 570 Then
                    Owner.DefaultMove(30)
                End If
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            Dim t As Integer = Ticks Mod 600
            Select Case t
                Case 60
                    Owner.MoveTo(64, 128, 30)
                Case 90
                    Owner.MoveTo(320, 64, 90)
                Case 95 To 175
                    If t Mod 10 = 0 Then
                        Preset1()
                    End If
                Case 180
                    Owner.MoveTo(320, 128, 5)
                Case 185
                    Owner.MoveTo(64, 64, 90)
                Case 190 To 265
                    If t Mod 10 = 0 Then
                        Preset1()
                    End If
                Case 270
                    Owner.MoveToCenter(30)
                Case 360
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 390
                    Preset2()
                Case 420
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 450
                    Preset2()
                Case 480
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 510
                    Preset2()
                Case 540
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 570
                    Preset2()
            End Select
        End If
    End Sub
    Private Sub Preset1()
        STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1E})
        STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1E})
        STG.Add(New Bullet(BulletType.环弹, BulletColor.土黄, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1E})
    End Sub
    Private Sub Preset2()
        For i = 0 To 315 Step 45
            STG.Add(New Bullet(BulletType.星弹, 2, Owner.X, Owner.Y, 1, i))
        Next
        For i = -2 To 2 Step 2
            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 0, i, 0) With {.Act = AddressOf .B6S0B1E})
        Next
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S1E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "饴符「大玉之庭」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 240
            Select Case t
                Case 30
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2, 290, 0) With {.Act = AddressOf .B6S1B1E})
                Case 80
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.2, 0, 0) With {.Act = AddressOf .B6S1B1E})
                Case 130
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2, 70, 0) With {.Act = AddressOf .B6S1B1E})
                Case 180
                    If Ticks Mod 480 < 240 Then
                        For i = -90 To 90 Step 60
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1, i))
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.5, i))
                        Next
                        For i = -60 To 60 Step 60
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.25, i))
                        Next
                    Else
                        For i = -60 To 60 Step 60
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1, i))
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.5, i))
                        Next
                        For i = -60 To 60 Step 60
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.25, i))
                        Next
                    End If
            End Select
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            If Ticks > 90 Then
                If Ticks Mod 45 = 0 Then
                    For i = 0 To 315 Step 45
                        STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 1.25, i))
                    Next
                End If
                If Ticks Mod 360 = 0 Then
                    For i = 1 To 2
                        For j = 1 To i + 2
                            STG.Add(New Bullet(BulletType.小玉, BulletColor.土黄, 64, 16, Rnd() * 0.2 + 1.2 + i * 1.5, 180 - j * 25 + Rnd() * 5 + i * 20, 0) With {.Act = AddressOf .B6S1B2E})
                        Next
                    Next
                ElseIf Ticks Mod 360 = 180 Then
                    For i = 1 To 2
                        For j = 1 To i + 2
                            STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 320, 16, Rnd() * 0.2 + 1.2 + i * 1.5, 180 + j * 25 - Rnd() * 5 - i * 20, 0) With {.Act = AddressOf .B6S1B2E})
                        Next
                    Next
                End If
            End If
        End If
    End Sub

    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S2E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 4000
        SpellTime = 3200
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "甘符「莉莉与大玉工厂」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 240
            For i = 60 To 150 Step 30
                If t = i Then
                    STG.Add(New Bullet(BulletType.大玉, 2, Owner.X, Owner.Y, 1 + Rnd() * 0.5, Rnd() * 360, 0) With {.Act = AddressOf .B6S1B1E})
                End If
            Next
            If t Mod 50 = 0 AndAlso Ticks > 60 Then
                STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1, Ticks / 2, 0))
                STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1, Ticks / 2 + 180, 0))
            End If
            If Ticks Mod 90 = 0 Then
                Owner.DefaultMove(60)
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            If Ticks <= 420 AndAlso Ticks > 60 Then
                If Ticks Mod 20 = 0 Then
                    For i = -162 To 162 Step 36
                        STG.Add(New Bullet(BulletType.星弹, 6, Owner.X, Owner.Y, 2, i * (Ticks - 60) / 360, 0))
                    Next
                End If
            ElseIf Ticks > 420 AndAlso Ticks <= 480 Then
                If Ticks Mod 20 = 0 Then
                    For i = -162 To 162 Step 36
                        STG.Add(New Bullet(BulletType.星弹, 6, Owner.X, Owner.Y, 2, i, 0))
                    Next
                End If
            End If
            If Ticks > 450 Then
                If Ticks Mod 45 = 0 Then
                    STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B6S2B1E})
                End If
                If Ticks Mod 45 = 0 Then
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X + 64 * Sin(Ticks), Owner.Y - 24 * Cos(Ticks), 1.2, Ticks, 0))
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X + 64 * Sin(Ticks + PI), Owner.Y - 24 * Cos(Ticks + PI), 1.2, Ticks + 180, 0))
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S3E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "蜜乐园「大玉摩天轮」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Owner.MoveTo(192, 224, 30)
        End If
        If Ticks = 60 Then
            For i = 0 To 345 Step 15
                STG.Add(New Bullet(BulletType.大玉, 0, 192 + 224 * Sin(i / 180 * PI), 224 + 224 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1E, .Tag = 224})
            Next
        End If
        If Ticks = 90 Then
            For i = 0 To 315 Step 45
                For j = 0 To 8 Step 2
                    STG.Add(New Bullet(BulletType.星弹, 6, 192 + 240 * j / 10 * Sin(i / 180 * PI), 224 + 240 * j / 10 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1E, .Tag = 240 * j / 8})
                Next
                For j = 1 To 7 Step 2
                    STG.Add(New Bullet(BulletType.星弹, 2, 192 + 240 * j / 10 * Sin(i / 180 * PI), 224 + 240 * j / 10 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1E, .Tag = 240 * j / 8})
                Next
            Next
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        For Each b In STG.SearchBullet
            b.Break(True, True)
        Next
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0401a.ReadLine()
            s = Texts.dialog0401a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0401a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0401b.ReadLine()
            s = Texts.dialog0401b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0401b)
            STG.DialogArea.Show()
        End If
        Stage4.Finished = True
        Return MyBase.Break()
    End Function
End Class
Module St4EnmE
    <Extension>
    Public Sub S4W1E(e As Enemy)
        With e
            If .Ticks = 70 Then
                For i = 0 To 270 Step 90
                    For j = 0 To 4
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.品红, .X, .Y, 1.2 + j * 0.1, i))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W2E(e As Enemy)
        With e
            If .Tag Mod 2 = 1 Then
                .Direction += 0.5
            Else
                .Direction -= 0.5
            End If
            If .Ticks Mod 30 = 0 AndAlso .Ticks > 30 Then
                Dim r As Integer = Rnd() * 360
                Select Case .Tag \ 10
                    Case 1
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                        For i = 0 To 3
                            STG.Add(New Bullet(BulletType.札弹, BulletColor.黄, .X + 12 * Sin((r + 90 * i) / 180 * PI), .Y - 12 * Cos((r + 90 * i) / 180 * PI), 0, r + 90 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                        Next
                        For i = 0 To 3
                            STG.Add(New Bullet(BulletType.札弹, BulletColor.红, .X + 12 * Sin((r + 90 * i + 45) / 180 * PI), .Y - 12 * Cos((r + 90 * i + 45) / 180 * PI), 0, r + 90 * i + 45, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                        Next
                    Case 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.心弹, 6, .X + 10 * Sin((r + 72 * i) / 180 * PI), .Y - 10 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i + 180, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                        Next
                End Select
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W3E(e As Enemy)
        With e
            If .Tag Mod 2 = 1 Then
                .Direction += 0.5
            Else
                .Direction -= 0.5
            End If
            If .Ticks Mod 120 = 0 AndAlso .Ticks > 30 Then

                Select Case .Tag \ 10
                    Case 1
                        Dim r As Integer = Rnd() * 360
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                        Next
                    Case 2
                        Dim r As Integer = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                        Next
                    Case 3
                        Dim r As Integer = 180 + Rnd() * 30 - 15
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                        Next
                End Select
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W4E(e As Enemy)
        With e
            If .Ticks = 40 Then
                .Speed = 0
            ElseIf .Ticks = 300 Then
                .Direction = 0
                .Speed = 1
            End If
            If .Ticks Mod 150 = 0 AndAlso .Ticks > 30 Then
                Dim r As Integer = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))

                STG.Add(New Bullet(BulletType.小玉, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                For i = 0 To 9
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.黄, .X + 14 * Sin((r + 36 * i) / 180 * PI), .Y - 14 * Cos((r + 36 * i) / 180 * PI), 0, r + 36 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1E})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W2B1E(e As Bullet)
        With e
            If .Ticks = 16 AndAlso .BulletType = BulletType.心弹 Then
                .SetSize(16, 16, 4)
            End If
            If .Ticks > 30 Then
                .X += .Ticks / 60 * Sin(.Tag / 180 * PI)
                .Y -= .Ticks / 60 * Cos(.Tag / 180 * PI)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4B5IE(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(5, i))
            Next

            .SpellCards.Add(New B5S0E(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(5, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S4B5AE(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Lily White", 1)
                .NextSpell()
            End If

        End With
    End Sub
    <Extension>
    Public Sub B5S0B1E(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 0
            ElseIf .Ticks = 90 Then
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub B5S0B2E(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 0
            ElseIf .Ticks = 75 Then
                .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub WordsE(e As Bullet)
        With e
            Select Case .Ticks
                Case 16
                    .SetSize(128, 32, 0.01)
                    .Background = Textures.words(0)
                Case 240
                    .Background = Textures.words(1)
                Case 480
                    .Background = Textures.words(2)
                Case 720
                    .Background = Textures.words(3)
                Case 1000
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y)) + 90
                    .SetSize(128, 32, 8)
            End Select
            If .Ticks > 1000 Then
                .X += 4 * Sin((.Direction - 90) / 180 * PI)
                .Y -= 4 * Cos((.Direction - 90) / 180 * PI)
            End If
            If .Ticks = 1200 Then
                .Break(False, True)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W5E(e As Enemy)
        With e
            If .Ticks = 64 Then
                .Speed = 0
            End If
            If .Ticks > 64 Then
                If .Ticks Mod 20 = 0 Then
                    For i = 0 To 4
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.青, .X, .Y, 1.2, .Ticks * 1.2 + i * 13, 0))
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X, .Y, 1.2, - .Ticks * 1.2 - i * 13, 0))
                    Next
                End If
                If .Ticks Mod 60 = 0 Then
                    For i = 0 To 315 Step 45
                        STG.Add(New Bullet(BulletType.中玉, 0, .X, .Y, 0.9, i))
                    Next
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4B6IE(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(5, i))
            Next
            .SpellCards.Add(New B6S0E(e))
            .SpellCards.Add(New B6S1E(e))
            .SpellCards.Add(New B6S2E(e))
            .SpellCards.Add(New B6S3E(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(5, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S4B6AE(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Lily White", 4)
                ResourcePack.Sounds.StopSound(STG.CurrentMusic)
                ResourcePack.Sounds.PlaySound(Sounds.mu09)
                Stage.Showmusic("云霄之上的花与舞")
                STG.CurrentMusic = Sounds.mu09
                .NextSpell()
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S0B1E(e As Bullet)
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
    Public Sub B6S1B1E(e As Bullet)
        With e
            If .Ticks = 80 Then
                .Speed = 0
                .Tag = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
            ElseIf .Ticks > 90 AndAlso .Ticks <= 150 AndAlso .Ticks Mod 5 = 0 Then
                For i = 0 To 300 Step 60
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X, .Y, .Ticks / 60 + 1, i + Val(.Tag), 0))
                Next
            ElseIf .Ticks = 185 Then
                .Break()
            End If

        End With
    End Sub
    <Extension>
    Public Sub B6S1B2E(e As Bullet)
        With e
            If .Ticks = 80 Then
                .Speed = 0
            ElseIf .Ticks = 120 Then
                If .BulletColor = BulletColor.土黄 Then
                    STG.Add(New Bullet(BulletType.大玉, 3, .X, .Y, 0, 170 + Rnd() * 20, 0) With {.Act = AddressOf .B6S1B3E})
                Else
                    STG.Add(New Bullet(BulletType.大玉, 0, .X, .Y, 0, 170 + Rnd() * 20, 0) With {.Act = AddressOf .B6S1B3E})
                End If
                .Break(False)
            End If

        End With
    End Sub
    <Extension>
    Public Sub B6S1B3E(e As Bullet)
        With e
            If .Ticks > 30 AndAlso .Ticks < 100 Then
                .Speed += 0.01
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S2B1E(e As Bullet)
        With e
            If IsNothing(.Tag) Then
                .Tag = -2
            Else
                .Tag += 0.025
                .Y += .Tag
            End If
            .X += .Direction
            If Rnd() > 0.995 Then
                .Break(False)
                For i = -1 To 1 Step 1
                    STG.Add(New Bullet(BulletType.星弹, 6, .X, .Y, 0, i, 0) With {.Act = AddressOf .B6S0B1E})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S3B1E(e As Bullet)
        With e
            If .BulletColor = 2 Then
                .X = 192 + .Tag * Sin((.Direction + .Ticks / 5) / 180 * PI)
                .Y = 224 + .Tag * Cos((.Direction + .Ticks / 5) / 180 * PI)
            Else
                .X = 192 + .Tag * Sin((.Direction - .Ticks / 5) / 180 * PI)
                .Y = 224 + .Tag * Cos((.Direction - .Ticks / 5) / 180 * PI)
            End If
        End With
    End Sub
End Module
#End Region

#Region "Normal"
Public Class B5S0N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 4000
        UsualTime = 2160
        HaveUsual = True
        Items = "000000000011111111115"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        Dim t As Integer = Ticks Mod 900
        Select Case t
            Case 60
                Owner.MoveTo(80, 192, 30)
            Case 90
                Preset1()
            Case 105
                Preset2()
            Case 180
                Owner.MoveTo(304, 192, 30)
            Case 210
                Preset1()
            Case 225
                Preset2()
            Case 300
                Owner.MoveTo(192, 128, 30)
            Case 330
                Preset1()
            Case 345
                Preset2()
            Case 450
                Owner.MoveTo(192, 256, 30)
            Case 480
                Owner.MoveTo(192, 128, 200)
            Case 490 To 690
                If Ticks Mod 9 = 0 Then
                    Preset3((t - 480) \ 8)
                End If
        End Select
    End Sub
    Private Sub Preset1()
        For i = 0 To 300 Step 60
            For j = 0 To 7
                STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, Owner.X, Owner.Y, j / 2, i + j * 6, 0) With {.Act = AddressOf .B5S0B1N})
            Next
        Next
    End Sub
    Private Sub Preset2()
        For i = 0 To 300 Step 60
            For j = 0 To 7
                STG.Add(New Bullet(BulletType.鳞弹, BulletColor.橙, Owner.X, Owner.Y, j / 2, i + 30 + j * 6, 0) With {.Act = AddressOf .B5S0B2N})
            Next
        Next
    End Sub
    Private Sub Preset3(n As Integer)
        Dim m As Integer = (n + 1) \ 2
        If n Mod 2 = 0 Then
            For i = 210 - (m / 2) * 5 To 210 + (m / 2) * 5 - 1 Step 10
                STG.Add(New Bullet(BulletType.小星弹, BulletColor.黄, Owner.X, Owner.Y, 1, i + Rnd() * 5 - 2.5, 0))
            Next
        Else
            For i = 150 - (m / 2) * 5 To 150 + (m / 2) * 5 - 1 Step 10
                STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 1, i + Rnd() * 5 - 2.5, 0))
            Next
        End If
    End Sub
End Class
Public Class B6S0N
    Inherits SpellCard
    Private c As Integer
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "糖符「Von Bon Bon大玉夫人」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 600
            If t < 300 Then
                If t = 90 Then
                    c = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
                If t >= 90 AndAlso t < 160 Then
                    If t Mod 5 = 0 Then
                        For i = 0 To 330 Step 30
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, Owner.X, Owner.Y, t / 60, i + c, 0))
                        Next
                    End If
                End If
                If t = 150 OrElse t = 250 Then
                    For i = -80 To 80 Step 40
                        STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.2, i))
                    Next
                ElseIf t = 200 Then
                    For i = -80 To 80 Step 40
                        STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.2, i + 20))
                    Next
                End If
                If t = 270 Then
                    Owner.DefaultMove(30)
                End If
            Else
                If t = 390 Then
                    c = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
                If t >= 390 AndAlso t < 460 Then
                    If t Mod 5 = 0 Then
                        For i = 0 To 330 Step 30
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.黄, Owner.X, Owner.Y, t / 60 - 5, i + c, 0))
                        Next
                    End If
                End If
                If t = 450 OrElse t = 500 OrElse t = 550 Then
                    For i = 0 To 315 Step 45
                        STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.2, i))
                    Next
                End If
                If t = 570 Then
                    Owner.DefaultMove(30)
                End If
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            Dim t As Integer = Ticks Mod 600
            Select Case t
                Case 60
                    Owner.MoveTo(64, 128, 30)
                Case 90
                    Owner.MoveTo(320, 64, 90)
                Case 95 To 175
                    If t Mod 8 = 0 Then
                        Preset1()
                    End If
                Case 180
                    Owner.MoveTo(320, 128, 5)
                Case 185
                    Owner.MoveTo(64, 64, 90)
                Case 190 To 265
                    If t Mod 8 = 0 Then
                        Preset1()
                    End If
                Case 270
                    Owner.MoveToCenter(30)
                Case 360
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 390
                    Preset2()
                Case 420
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 450
                    Preset2()
                Case 480
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 510
                    Preset2()
                Case 540
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 570
                    Preset2()
            End Select
        End If
    End Sub
    Private Sub Preset1()
        STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1N})
        STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1N})
        STG.Add(New Bullet(BulletType.环弹, BulletColor.土黄, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1N})
    End Sub
    Private Sub Preset2()
        For i = 0 To 340 Step 30
            STG.Add(New Bullet(BulletType.星弹, 2, Owner.X, Owner.Y, 1.2, i))
        Next
        For i = -2 To 2
            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 0, i, 0) With {.Act = AddressOf .B6S0B1N})
        Next
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S1N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "饴符「大玉之庭」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 240
            Select Case t
                Case 30
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2, 290, 0) With {.Act = AddressOf .B6S1B1N})
                Case 80
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.2, 0, 0) With {.Act = AddressOf .B6S1B1N})
                Case 130
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2, 70, 0) With {.Act = AddressOf .B6S1B1N})
                Case 180
                    If Ticks Mod 480 < 240 Then
                        For i = -90 To 90 Step 45
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.2, i))
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.8, i))
                        Next
                        For i = -67.5 To 67.5 Step 45
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.5, i))
                        Next
                    Else
                        For i = -90 To 90 Step 45
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.2, i))
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.8, i))
                        Next
                        For i = -67.5 To 67.5 Step 45
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.5, i))
                        Next
                    End If
            End Select
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            If Ticks > 90 Then
                If Ticks Mod 45 = 0 Then
                    For i = 0 To 330 Step 30
                        STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 1.5, i))
                    Next
                End If
                If Ticks Mod 360 = 0 Then
                    For i = 1 To 3
                        For j = 1 To i + 2
                            STG.Add(New Bullet(BulletType.小玉, BulletColor.土黄, 64, 16, Rnd() * 0.2 + 1.2 + i, 180 - j * 25 + Rnd() * 5 + i * 15, 0) With {.Act = AddressOf .B6S1B2N})
                        Next
                    Next
                ElseIf Ticks Mod 360 = 180 Then
                    For i = 1 To 3
                        For j = 1 To i + 2
                            STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 320, 16, Rnd() * 0.2 + 1.2 + i, 180 + j * 25 - Rnd() * 5 - i * 15, 0) With {.Act = AddressOf .B6S1B2N})
                        Next
                    Next
                End If
            End If
        End If
    End Sub

    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S2N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 4000
        SpellTime = 3200
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "甘符「莉莉与大玉工厂」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 240
            For i = 60 To 150 Step 30
                If t = i Then
                    STG.Add(New Bullet(BulletType.大玉, 2, Owner.X, Owner.Y, 1 + Rnd() * 0.5, Rnd() * 360, 0) With {.Act = AddressOf .B6S1B1N})
                End If
            Next
            If t Mod 40 = 0 AndAlso Ticks > 60 Then
                STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.2, Ticks / 2, 0))
                STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.2, Ticks / 2 + 180, 0))
            End If
            If Ticks Mod 90 = 0 Then
                Owner.DefaultMove(60)
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            If Ticks <= 420 AndAlso Ticks > 60 Then
                If Ticks Mod 15 = 0 Then
                    For i = -162 To 162 Step 36
                        STG.Add(New Bullet(BulletType.星弹, 6, Owner.X, Owner.Y, 2, i * (Ticks - 60) / 360, 0))
                    Next
                End If
            ElseIf Ticks > 420 AndAlso Ticks <= 480 Then
                If Ticks Mod 15 = 0 Then
                    For i = -162 To 162 Step 36
                        STG.Add(New Bullet(BulletType.星弹, 6, Owner.X, Owner.Y, 2, i, 0))
                    Next
                End If
            End If
            If Ticks > 450 Then
                If Ticks Mod 30 = 0 Then
                    STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B6S2B1N})
                End If
                If Ticks Mod 30 = 0 Then
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X + 64 * Sin(Ticks), Owner.Y - 24 * Cos(Ticks), 1.2, Ticks, 0))
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X + 64 * Sin(Ticks + PI), Owner.Y - 24 * Cos(Ticks + PI), 1.2, Ticks + 180, 0))
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S3N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "蜜乐园「大玉摩天轮」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Owner.MoveTo(192, 224, 30)
        End If
        If Ticks = 60 Then
            For i = 0 To 345 Step 15
                STG.Add(New Bullet(BulletType.大玉, 0, 192 + 224 * Sin(i / 180 * PI), 224 + 224 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1N, .Tag = 224})
            Next
        End If
        If Ticks = 90 Then
            For i = 0 To 315 Step 45
                For j = 0 To 10 Step 2
                    STG.Add(New Bullet(BulletType.星弹, 6, 192 + 240 * j / 10 * Sin(i / 180 * PI), 224 + 240 * j / 10 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1N, .Tag = 240 * j / 10})
                Next
                For j = 1 To 9 Step 2
                    STG.Add(New Bullet(BulletType.星弹, 2, 192 + 240 * j / 10 * Sin(i / 180 * PI), 224 + 240 * j / 10 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1N, .Tag = 240 * j / 10})
                Next
            Next
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        For Each b In STG.SearchBullet
            b.Break(True, True)
        Next
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0401a.ReadLine()
            s = Texts.dialog0401a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0401a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0401b.ReadLine()
            s = Texts.dialog0401b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0401b)
            STG.DialogArea.Show()
        End If
        Stage4.Finished = True
        Return MyBase.Break()
    End Function
End Class
Module St4EnmN
    <Extension>
    Public Sub S4W1N(e As Enemy)
        With e
            If .Ticks = 70 Then
                For i = 0 To 270 Step 90
                    For j = 0 To 5
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.品红, .X, .Y, 1.5 + j * 0.1, i))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W2N(e As Enemy)
        With e
            If .Tag Mod 2 = 1 Then
                .Direction += 0.5
            Else
                .Direction -= 0.5
            End If
            If .Ticks Mod 20 = 0 AndAlso .Ticks > 30 Then
                Dim r As Integer = Rnd() * 360
                Select Case .Tag \ 10
                    Case 1
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                        For i = 0 To 3
                            STG.Add(New Bullet(BulletType.札弹, BulletColor.黄, .X + 12 * Sin((r + 90 * i) / 180 * PI), .Y - 12 * Cos((r + 90 * i) / 180 * PI), 0, r + 90 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                        Next
                        For i = 0 To 3
                            STG.Add(New Bullet(BulletType.札弹, BulletColor.红, .X + 12 * Sin((r + 90 * i + 45) / 180 * PI), .Y - 12 * Cos((r + 90 * i + 45) / 180 * PI), 0, r + 90 * i + 45, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                        Next
                    Case 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.心弹, 6, .X + 10 * Sin((r + 72 * i) / 180 * PI), .Y - 10 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i + 180, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                        Next
                End Select
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W3N(e As Enemy)
        With e
            If .Tag Mod 2 = 1 Then
                .Direction += 0.5
            Else
                .Direction -= 0.5
            End If
            If .Ticks Mod 100 = 0 AndAlso .Ticks > 30 Then

                Select Case .Tag \ 10
                    Case 1
                        Dim r As Integer = Rnd() * 360
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                        Next
                    Case 2
                        Dim r As Integer = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                        Next
                    Case 3
                        Dim r As Integer = 180 + Rnd() * 30 - 15
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                        Next
                End Select
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W4N(e As Enemy)
        With e
            If .Ticks = 40 Then
                .Speed = 0
            ElseIf .Ticks = 300 Then
                .Direction = 0
                .Speed = 1
            End If
            If .Ticks Mod 120 = 0 AndAlso .Ticks > 30 Then
                Dim r As Integer = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))

                STG.Add(New Bullet(BulletType.小玉, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                For i = 0 To 9
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.黄, .X + 14 * Sin((r + 36 * i) / 180 * PI), .Y - 14 * Cos((r + 36 * i) / 180 * PI), 0, r + 36 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1N})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W2B1N(e As Bullet)
        With e
            If .Ticks = 16 AndAlso .BulletType = BulletType.心弹 Then
                .SetSize(16, 16, 4)
            End If
            If .Ticks > 30 Then
                .X += .Ticks / 60 * Sin(.Tag / 180 * PI)
                .Y -= .Ticks / 60 * Cos(.Tag / 180 * PI)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4B5IN(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(5, i))
            Next

            .SpellCards.Add(New B5S0N(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(5, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S4B5AN(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Lily White", 1)
                .NextSpell()
            End If

        End With
    End Sub
    <Extension>
    Public Sub B5S0B1N(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 0
            ElseIf .Ticks = 90 Then
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub B5S0B2N(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 0
            ElseIf .Ticks = 75 Then
                .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub WordsN(e As Bullet)
        With e
            Select Case .Ticks
                Case 16
                    .SetSize(128, 32, 0.01)
                    .Background = Textures.words(0)
                Case 240
                    .Background = Textures.words(1)
                Case 480
                    .Background = Textures.words(2)
                Case 720
                    .Background = Textures.words(3)
                Case 1000
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y)) + 90
                    .SetSize(128, 32, 8)
            End Select
            If .Ticks > 1000 Then
                .X += 5 * Sin((.Direction - 90) / 180 * PI)
                .Y -= 5 * Cos((.Direction - 90) / 180 * PI)
            End If
            If .Ticks = 1200 Then
                .Break(False, True)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W5N(e As Enemy)
        With e
            If .Ticks = 64 Then
                .Speed = 0
            End If
            If .Ticks > 64 Then
                If .Ticks Mod 15 = 0 Then
                    For i = 0 To 4
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.青, .X, .Y, 1.2, .Ticks * 1.2 + i * 13, 0))
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X, .Y, 1.2, - .Ticks * 1.2 - i * 13, 0))
                    Next
                End If
                If .Ticks Mod 60 = 0 Then
                    For i = 0 To 330 Step 30
                        STG.Add(New Bullet(BulletType.中玉, 0, .X, .Y, 0.9, i))
                    Next
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4B6IN(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(5, i))
            Next
            .SpellCards.Add(New B6S0N(e))
            .SpellCards.Add(New B6S1N(e))
            .SpellCards.Add(New B6S2N(e))
            .SpellCards.Add(New B6S3N(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(5, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S4B6AN(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Lily White", 4)
                ResourcePack.Sounds.StopSound(STG.CurrentMusic)
                ResourcePack.Sounds.PlaySound(Sounds.mu09)
                Stage.Showmusic("云霄之上的花与舞")
                STG.CurrentMusic = Sounds.mu09
                .NextSpell()
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S0B1N(e As Bullet)
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
    Public Sub B6S1B1N(e As Bullet)
        With e
            If .Ticks = 80 Then
                .Speed = 0
                .Tag = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
            ElseIf .Ticks > 90 AndAlso .Ticks <= 160 AndAlso .Ticks Mod 5 = 0 Then
                For i = 0 To 315 Step 45
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X, .Y, .Ticks / 60 + 1, i + Val(.Tag), 0))
                Next
            ElseIf .Ticks = 185 Then
                .Break()
            End If

        End With
    End Sub
    <Extension>
    Public Sub B6S1B2N(e As Bullet)
        With e
            If .Ticks = 80 Then
                .Speed = 0
            ElseIf .Ticks = 120 Then
                If .BulletColor = BulletColor.土黄 Then
                    STG.Add(New Bullet(BulletType.大玉, 3, .X, .Y, 0, 170 + Rnd() * 20, 0) With {.Act = AddressOf .B6S1B3N})
                Else
                    STG.Add(New Bullet(BulletType.大玉, 0, .X, .Y, 0, 170 + Rnd() * 20, 0) With {.Act = AddressOf .B6S1B3N})
                End If
                .Break(False)
            End If

        End With
    End Sub
    <Extension>
    Public Sub B6S1B3N(e As Bullet)
        With e
            If .Ticks > 30 AndAlso .Ticks < 100 Then
                .Speed += 0.015
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S2B1N(e As Bullet)
        With e
            If IsNothing(.Tag) Then
                .Tag = -2
            Else
                .Tag += 0.025
                .Y += .Tag
            End If
            .X += .Direction
            If Rnd() > 0.9925 Then
                .Break(False)
                For i = -1 To 1 Step 1
                    STG.Add(New Bullet(BulletType.星弹, 6, .X, .Y, 0, i, 0) With {.Act = AddressOf .B6S0B1N})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S3B1N(e As Bullet)
        With e
            If .BulletColor = 2 Then
                .X = 192 + .Tag * Sin((.Direction + .Ticks / 5) / 180 * PI)
                .Y = 224 + .Tag * Cos((.Direction + .Ticks / 5) / 180 * PI)
            Else
                .X = 192 + .Tag * Sin((.Direction - .Ticks / 5) / 180 * PI)
                .Y = 224 + .Tag * Cos((.Direction - .Ticks / 5) / 180 * PI)
            End If
        End With
    End Sub
End Module
#End Region

#Region "Hard"
Public Class B5S0H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 4000
        UsualTime = 2160
        HaveUsual = True
        Items = "000000000011111111115"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        Dim t As Integer = Ticks Mod 900
        Select Case t
            Case 60
                Owner.MoveTo(80, 192, 30)
            Case 90
                Preset1()
            Case 105
                Preset2()
            Case 180
                Owner.MoveTo(304, 192, 30)
            Case 210
                Preset1()
            Case 225
                Preset2()
            Case 300
                Owner.MoveTo(192, 128, 30)
            Case 330
                Preset1()
            Case 345
                Preset2()
            Case 450
                Owner.MoveTo(192, 256, 30)
            Case 480
                Owner.MoveTo(192, 128, 200)
            Case 490 To 690
                If Ticks Mod 5 = 0 Then
                    Preset3((t - 480) \ 5)
                End If
        End Select
    End Sub
    Private Sub Preset1()
        For i = 0 To 300 Step 60
            For j = 0 To 9
                STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, Owner.X, Owner.Y, j / 2, i + j * 6, 0) With {.Act = AddressOf .B5S0B1H})
            Next
        Next
    End Sub
    Private Sub Preset2()
        For i = 0 To 300 Step 60
            For j = 0 To 9
                STG.Add(New Bullet(BulletType.鳞弹, BulletColor.橙, Owner.X, Owner.Y, j / 2, i + 30 + j * 6, 0) With {.Act = AddressOf .B5S0B2H})
            Next
        Next
    End Sub
    Private Sub Preset3(n As Integer)
        Dim m As Integer = (n + 1) \ 2
        If n Mod 2 = 0 Then
            For i = 210 - (m / 2) * 5 To 210 + (m / 2) * 5 - 1 Step 10
                STG.Add(New Bullet(BulletType.小星弹, BulletColor.黄, Owner.X, Owner.Y, 1.2, i + Rnd() * 5 - 2.5, 0))
            Next
        Else
            For i = 150 - (m / 2) * 5 To 150 + (m / 2) * 5 - 1 Step 10
                STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 1.2, i + Rnd() * 5 - 2.5, 0))
            Next
        End If
    End Sub
End Class
Public Class B6S0H
    Inherits SpellCard
    Private c As Integer
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "糖符「Von Bon Bon大玉夫人」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 600
            If t < 300 Then
                If t = 90 Then
                    c = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
                If t >= 90 AndAlso t < 180 Then
                    If t Mod 5 = 0 Then
                        For i = 0 To 340 Step 20
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, Owner.X, Owner.Y, t / 60, i + c, 0))
                        Next
                    End If
                End If
                If t = 150 OrElse t = 250 Then
                    For i = -90 To 90 Step 30
                        STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.5, i))
                    Next
                ElseIf t = 200 Then
                    For i = -90 To 90 Step 30
                        STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.5, i + 15))
                    Next
                End If
                If t = 270 Then
                    Owner.DefaultMove(30)
                End If
            Else
                If t = 390 Then
                    c = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
                If t >= 390 AndAlso t < 480 Then
                    If t Mod 5 = 0 Then
                        For i = 0 To 340 Step 20
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.黄, Owner.X, Owner.Y, t / 60 - 5, i + c, 0))
                        Next
                    End If
                End If
                If t = 450 OrElse t = 500 OrElse t = 550 Then
                    For i = 0 To 330 Step 30
                        STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.5, i))
                    Next
                End If
                If t = 570 Then
                    Owner.DefaultMove(30)
                End If
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            Dim t As Integer = Ticks Mod 600
            Select Case t
                Case 60
                    Owner.MoveTo(64, 128, 30)
                Case 90
                    Owner.MoveTo(320, 64, 90)
                Case 95 To 175
                    If t Mod 5 = 0 Then
                        Preset1()
                    End If
                Case 180
                    Owner.MoveTo(320, 128, 5)
                Case 185
                    Owner.MoveTo(64, 64, 90)
                Case 190 To 265
                    If t Mod 5 = 0 Then
                        Preset1()
                    End If
                Case 270
                    Owner.MoveToCenter(30)
                Case 360
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 390
                    Preset2()
                Case 420
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 450
                    Preset2()
                Case 480
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 510
                    Preset2()
                Case 540
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 570
                    Preset2()
            End Select
        End If
    End Sub
    Private Sub Preset1()
        STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1H})
        STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1H})
        STG.Add(New Bullet(BulletType.环弹, BulletColor.土黄, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1H})
    End Sub
    Private Sub Preset2()
        For i = 0 To 324 Step 36
            STG.Add(New Bullet(BulletType.星弹, 2, Owner.X, Owner.Y, 1.5, i))
        Next
        For i = -2 To 2
            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 0, i, 0) With {.Act = AddressOf .B6S0B1H})
        Next
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S1H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "饴符「大玉之庭」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 240
            Select Case t
                Case 30
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2, 290, 0) With {.Act = AddressOf .B6S1B1H})
                Case 80
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.2, 0, 0) With {.Act = AddressOf .B6S1B1H})
                Case 130
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2, 70, 0) With {.Act = AddressOf .B6S1B1H})
                Case 180
                    If Ticks Mod 480 < 240 Then
                        For i = -90 To 90 Step 30
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.2, i))
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.8, i))
                        Next
                        For i = -75 To 75 Step 30
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.5, i))
                        Next
                    Else
                        For i = -90 To 90 Step 30
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.2, i))
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.8, i))
                        Next
                        For i = -75 To 75 Step 30
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.5, i))
                        Next
                    End If
            End Select
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            If Ticks > 90 Then
                If Ticks Mod 30 = 0 Then
                    For i = 0 To 342 Step 18
                        STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 1.5, i))
                    Next
                End If
                If Ticks Mod 360 = 0 Then
                    For i = 1 To 3
                        For j = 1 To i + 3
                            STG.Add(New Bullet(BulletType.小玉, BulletColor.土黄, 64, 16, Rnd() * 0.2 + 1.2 + i, 180 - j * 20 + Rnd() * 5 + i * 15, 0) With {.Act = AddressOf .B6S1B2H})
                        Next
                    Next
                ElseIf Ticks Mod 360 = 180 Then
                    For i = 1 To 3
                        For j = 1 To i + 3
                            STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 320, 16, Rnd() * 0.2 + 1.2 + i, 180 + j * 20 - Rnd() * 5 - i * 15, 0) With {.Act = AddressOf .B6S1B2H})
                        Next
                    Next
                End If
            End If
        End If
    End Sub

    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S2H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 4000
        SpellTime = 3200
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "甘符「莉莉与大玉工厂」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 240
            For i = 60 To 150 Step 30
                If t = i Then
                    STG.Add(New Bullet(BulletType.大玉, 2, Owner.X, Owner.Y, 1 + Rnd() * 0.5, Rnd() * 360, 0) With {.Act = AddressOf .B6S1B1H})
                End If
            Next
            If t Mod 30 = 0 AndAlso Ticks > 60 Then
                STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.5, Ticks / 2, 0))
                STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.5, Ticks / 2 + 180, 0))
            End If
            If Ticks Mod 90 = 0 Then
                Owner.DefaultMove(60)
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            If Ticks <= 420 AndAlso Ticks > 60 Then
                If Ticks Mod 10 = 0 Then
                    For i = -162 To 162 Step 36
                        STG.Add(New Bullet(BulletType.星弹, 6, Owner.X, Owner.Y, 3, i * (Ticks - 60) / 360, 0))
                    Next
                End If
            ElseIf Ticks > 420 AndAlso Ticks <= 480 Then
                If Ticks Mod 10 = 0 Then
                    For i = -162 To 162 Step 36
                        STG.Add(New Bullet(BulletType.星弹, 6, Owner.X, Owner.Y, 3, i, 0))
                    Next
                End If
            End If
            If Ticks > 450 Then
                If Ticks Mod 30 = 0 Then
                    STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B6S2B1H})
                End If
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X + 64 * Sin(Ticks), Owner.Y - 24 * Cos(Ticks), 1.2, Ticks, 0))
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X + 64 * Sin(Ticks + PI), Owner.Y - 24 * Cos(Ticks + PI), 1.2, Ticks + 180, 0))
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S3H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "蜜乐园「大玉摩天轮」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Owner.MoveTo(192, 224, 30)
        End If
        If Ticks = 60 Then
            For i = 0 To 345 Step 15
                STG.Add(New Bullet(BulletType.大玉, 0, 192 + 224 * Sin(i / 180 * PI), 224 + 224 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1H, .Tag = 224})
            Next
        End If
        If Ticks = 90 Then
            For i = 0 To 330 Step 30
                For j = 0 To 10 Step 2
                    STG.Add(New Bullet(BulletType.星弹, 6, 192 + 240 * j / 10 * Sin(i / 180 * PI), 224 + 240 * j / 10 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1H, .Tag = 240 * j / 10})
                Next
                For j = 1 To 9 Step 2
                    STG.Add(New Bullet(BulletType.星弹, 2, 192 + 240 * j / 10 * Sin(i / 180 * PI), 224 + 240 * j / 10 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1H, .Tag = 240 * j / 10})
                Next
            Next
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        For Each b In STG.SearchBullet
            b.Break(True, True)
        Next
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0401a.ReadLine()
            s = Texts.dialog0401a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0401a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0401b.ReadLine()
            s = Texts.dialog0401b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0401b)
            STG.DialogArea.Show()
        End If
        Stage4.Finished = True
        Return MyBase.Break()
    End Function
End Class
Module St4EnmH
    <Extension>
    Public Sub S4W1H(e As Enemy)
        With e
            If .Ticks = 70 Then
                For i = 0 To 270 Step 90
                    For j = 0 To 7
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.品红, .X, .Y, 1.5 + j * 0.1, i))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W2H(e As Enemy)
        With e
            If .Tag Mod 2 = 1 Then
                .Direction += 0.5
            Else
                .Direction -= 0.5
            End If
            If .Ticks Mod 15 = 0 AndAlso .Ticks > 30 Then
                Dim r As Integer = Rnd() * 360
                Select Case .Tag \ 10
                    Case 1
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                        For i = 0 To 3
                            STG.Add(New Bullet(BulletType.札弹, BulletColor.黄, .X + 12 * Sin((r + 90 * i) / 180 * PI), .Y - 12 * Cos((r + 90 * i) / 180 * PI), 0, r + 90 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                        Next
                        For i = 0 To 3
                            STG.Add(New Bullet(BulletType.札弹, BulletColor.红, .X + 12 * Sin((r + 90 * i + 45) / 180 * PI), .Y - 12 * Cos((r + 90 * i + 45) / 180 * PI), 0, r + 90 * i + 45, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                        Next
                    Case 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.心弹, 6, .X + 10 * Sin((r + 72 * i) / 180 * PI), .Y - 10 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i + 180, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                        Next
                End Select
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W3H(e As Enemy)
        With e
            If .Tag Mod 2 = 1 Then
                .Direction += 0.5
            Else
                .Direction -= 0.5
            End If
            If .Ticks Mod 80 = 0 AndAlso .Ticks > 30 Then

                Select Case .Tag \ 10
                    Case 1
                        Dim r As Integer = Rnd() * 360
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                        Next
                    Case 2
                        Dim r As Integer = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                        Next
                    Case 3
                        Dim r As Integer = 180 + Rnd() * 30 - 15
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                        Next
                End Select
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W4H(e As Enemy)
        With e
            If .Ticks = 40 Then
                .Speed = 0
            ElseIf .Ticks = 300 Then
                .Direction = 0
                .Speed = 1
            End If
            If .Ticks Mod 90 = 0 AndAlso .Ticks > 30 Then
                Dim r As Integer = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))

                STG.Add(New Bullet(BulletType.小玉, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                For i = 0 To 9
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.黄, .X + 14 * Sin((r + 36 * i) / 180 * PI), .Y - 14 * Cos((r + 36 * i) / 180 * PI), 0, r + 36 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1H})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W2B1H(e As Bullet)
        With e
            If .Ticks = 16 AndAlso .BulletType = BulletType.心弹 Then
                .SetSize(16, 16, 4)
            End If
            If .Ticks > 30 Then
                .X += .Ticks / 60 * Sin(.Tag / 180 * PI)
                .Y -= .Ticks / 60 * Cos(.Tag / 180 * PI)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4B5IH(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(5, i))
            Next

            .SpellCards.Add(New B5S0H(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(5, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S4B5AH(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Lily White", 1)
                .NextSpell()
            End If

        End With
    End Sub
    <Extension>
    Public Sub B5S0B1H(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 0
            ElseIf .Ticks = 90 Then
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub B5S0B2H(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 0
            ElseIf .Ticks = 75 Then
                .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub WordsH(e As Bullet)
        With e
            Select Case .Ticks
                Case 16
                    .SetSize(128, 32, 0.01)
                    .Background = Textures.words(0)
                Case 240
                    .Background = Textures.words(1)
                Case 480
                    .Background = Textures.words(2)
                Case 720
                    .Background = Textures.words(3)
                Case 1000
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y)) + 90
                    .SetSize(128, 32, 8)
            End Select
            If .Ticks > 1000 Then
                .X += 6 * Sin((.Direction - 90) / 180 * PI)
                .Y -= 6 * Cos((.Direction - 90) / 180 * PI)
            End If
            If .Ticks = 1200 Then
                .Break(False, True)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W5H(e As Enemy)
        With e
            If .Ticks = 64 Then
                .Speed = 0
            End If
            If .Ticks > 64 Then
                If .Ticks Mod 10 = 0 Then
                    For i = 0 To 4
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.青, .X, .Y, 1.5, .Ticks * 1.2 + i * 13, 0))
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X, .Y, 1.5, - .Ticks * 1.2 - i * 13, 0))
                    Next
                End If
                If .Ticks Mod 60 = 0 Then
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.中玉, 0, .X, .Y, 1, i))
                    Next
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4B6IH(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(5, i))
            Next
            .SpellCards.Add(New B6S0H(e))
            .SpellCards.Add(New B6S1H(e))
            .SpellCards.Add(New B6S2H(e))
            .SpellCards.Add(New B6S3H(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(5, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S4B6AH(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Lily White", 4)
                ResourcePack.Sounds.StopSound(STG.CurrentMusic)
                ResourcePack.Sounds.PlaySound(Sounds.mu09)
                Stage.Showmusic("云霄之上的花与舞")
                STG.CurrentMusic = Sounds.mu09
                .NextSpell()
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S0B1H(e As Bullet)
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
    Public Sub B6S1B1H(e As Bullet)
        With e
            If .Ticks = 80 Then
                .Speed = 0
                .Tag = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
            ElseIf .Ticks > 90 AndAlso .Ticks <= 180 AndAlso .Ticks Mod 5 = 0 Then
                For i = 0 To 324 Step 36
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X, .Y, .Ticks / 60 + 1, i + Val(.Tag), 0))
                Next
            ElseIf .Ticks = 185 Then
                .Break()
            End If

        End With
    End Sub
    <Extension>
    Public Sub B6S1B2H(e As Bullet)
        With e
            If .Ticks = 80 Then
                .Speed = 0
            ElseIf .Ticks = 120 Then
                If .BulletColor = BulletColor.土黄 Then
                    STG.Add(New Bullet(BulletType.大玉, 3, .X, .Y, 0, 170 + Rnd() * 20, 0) With {.Act = AddressOf .B6S1B3H})
                Else
                    STG.Add(New Bullet(BulletType.大玉, 0, .X, .Y, 0, 170 + Rnd() * 20, 0) With {.Act = AddressOf .B6S1B3H})
                End If
                .Break(False)
            End If

        End With
    End Sub
    <Extension>
    Public Sub B6S1B3H(e As Bullet)
        With e
            If .Ticks > 30 AndAlso .Ticks < 100 Then
                .Speed += 0.02
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S2B1H(e As Bullet)
        With e
            If IsNothing(.Tag) Then
                .Tag = -2
            Else
                .Tag += 0.025
                .Y += .Tag
            End If
            .X += .Direction
            If Rnd() > 0.9925 Then
                .Break(False)
                For i = -1.5 To 1.5 Step 1
                    STG.Add(New Bullet(BulletType.星弹, 6, .X, .Y, 0, i, 0) With {.Act = AddressOf .B6S0B1H})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S3B1H(e As Bullet)
        With e
            If .BulletColor = 2 Then
                .X = 192 + .Tag * Sin((.Direction + .Ticks / 5) / 180 * PI)
                .Y = 224 + .Tag * Cos((.Direction + .Ticks / 5) / 180 * PI)
            Else
                .X = 192 + .Tag * Sin((.Direction - .Ticks / 5) / 180 * PI)
                .Y = 224 + .Tag * Cos((.Direction - .Ticks / 5) / 180 * PI)
            End If
        End With
    End Sub
End Module
#End Region

#Region "Lunatic"
Public Class B5S0L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 4000
        UsualTime = 2160
        HaveUsual = True
        Items = "000000000011111111115"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        Dim t As Integer = Ticks Mod 900
        Select Case t
            Case 60
                Owner.MoveTo(80, 192, 30)
            Case 90
                Preset1()
            Case 105
                Preset2()
            Case 180
                Owner.MoveTo(304, 192, 30)
            Case 210
                Preset1()
            Case 225
                Preset2()
            Case 300
                Owner.MoveTo(192, 128, 30)
            Case 330
                Preset1()
            Case 345
                Preset2()
            Case 450
                Owner.MoveTo(192, 256, 30)
            Case 480
                Owner.MoveTo(192, 128, 200)
            Case 490 To 690
                If Ticks Mod 4 = 0 Then
                    Preset3((t - 480) \ 4)
                End If
        End Select
    End Sub
    Private Sub Preset1()
        For i = 0 To 315 Step 45
            For j = 0 To 9
                STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, Owner.X, Owner.Y, j / 2, i + j * 6, 0) With {.Act = AddressOf .B5S0B1L})
            Next
        Next
    End Sub
    Private Sub Preset2()
        For i = 0 To 315 Step 45
            For j = 0 To 9
                STG.Add(New Bullet(BulletType.鳞弹, BulletColor.橙, Owner.X, Owner.Y, j / 2, i + 22.5 + j * 6, 0) With {.Act = AddressOf .B5S0B2L})
            Next
        Next
    End Sub
    Private Sub Preset3(n As Integer)
        Dim m As Integer = (n + 1) \ 2
        If n Mod 2 = 0 Then
            For i = 210 - (m / 2) * 5 To 210 + (m / 2) * 5 - 1 Step 10
                STG.Add(New Bullet(BulletType.小星弹, BulletColor.黄, Owner.X, Owner.Y, 1.2, i + Rnd() * 5 - 2.5, 0))
            Next
        Else
            For i = 150 - (m / 2) * 5 To 150 + (m / 2) * 5 - 1 Step 10
                STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 1.2, i + Rnd() * 5 - 2.5, 0))
            Next
        End If
    End Sub
End Class
Public Class B6S0L
    Inherits SpellCard
    Private c As Integer
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "糖符「Von Bon Bon大玉夫人」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 600
            If t < 300 Then
                If t = 90 Then
                    c = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
                If t >= 90 AndAlso t < 190 Then
                    If t Mod 5 = 0 Then
                        For i = 0 To 340 Step 20
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, Owner.X, Owner.Y, t / 60, i + c, 0))
                        Next
                    End If
                End If
                If t = 150 OrElse t = 250 Then
                    For i = -100 To 100 Step 25
                        STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.8, i))
                    Next
                ElseIf t = 200 Then
                    For i = -100 To 100 Step 25
                        STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.8, i + 12.5))
                    Next
                End If
                If t = 270 Then
                    Owner.DefaultMove(30)
                End If
            Else
                If t = 390 Then
                    c = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
                If t >= 390 AndAlso t < 490 Then
                    If t Mod 5 = 0 Then
                        For i = 0 To 340 Step 20
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.黄, Owner.X, Owner.Y, t / 60 - 5, i + c, 0))
                        Next
                    End If
                End If
                If t = 450 OrElse t = 500 OrElse t = 550 Then
                    For i = 0 To 340 Step 20
                        STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.8, i))
                    Next
                End If
                If t = 570 Then
                    Owner.DefaultMove(30)
                End If
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            Dim t As Integer = Ticks Mod 600
            Select Case t
                Case 60
                    Owner.MoveTo(64, 128, 30)
                Case 90
                    Owner.MoveTo(320, 64, 90)
                Case 95 To 175
                    If t Mod 4 = 0 Then
                        Preset1()
                    End If
                Case 180
                    Owner.MoveTo(320, 128, 5)
                Case 185
                    Owner.MoveTo(64, 64, 90)
                Case 190 To 265
                    If t Mod 4 = 0 Then
                        Preset1()
                    End If
                Case 270
                    Owner.MoveToCenter(30)
                Case 360
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 390
                    Preset2()
                Case 420
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 450
                    Preset2()
                Case 480
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 510
                    Preset2()
                Case 540
                    Owner.MoveTo(32 + 320 * Rnd(), 64 + 128 * Rnd(), 30)
                Case 570
                    Preset2()
            End Select
        End If
    End Sub
    Private Sub Preset1()
        STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1L})
        STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1L})
        STG.Add(New Bullet(BulletType.环弹, BulletColor.土黄, Owner.X, Owner.Y, 0, Rnd() * 2 - 1, 0) With {.Act = AddressOf .B6S0B1L})
    End Sub
    Private Sub Preset2()
        For i = 0 To 330 Step 30
            STG.Add(New Bullet(BulletType.星弹, 2, Owner.X, Owner.Y, 1.5, i))
        Next
        For i = -3 To 3
            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 0, i, 0) With {.Act = AddressOf .B6S0B1L})
        Next
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S1L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "饴符「大玉之庭」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 240
            Select Case t
                Case 30
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2, 290, 0) With {.Act = AddressOf .B6S1B1L})
                Case 80
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.2, 0, 0) With {.Act = AddressOf .B6S1B1L})
                Case 130
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2, 70, 0) With {.Act = AddressOf .B6S1B1L})
                Case 180
                    If Ticks Mod 480 < 240 Then
                        For i = -100 To 100 Step 25
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.5, i))
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 2, i))
                        Next
                        For i = -87.5 To 87.5 Step 25
                            STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.75, i))
                        Next
                    Else
                        For i = -100 To 100 Step 25
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.5, i))
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 2, i))
                        Next
                        For i = -87.5 To 87.5 Step 25
                            STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.75, i))
                        Next
                    End If
            End Select
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            If Ticks > 90 Then
                If Ticks Mod 30 = 0 Then
                    For i = 0 To 345 Step 15
                        STG.Add(New Bullet(BulletType.小星弹, BulletColor.品红, Owner.X, Owner.Y, 1.8, i))
                    Next
                End If
                If Ticks Mod 360 = 0 Then
                    For i = 1 To 4
                        For j = 1 To i + 3
                            STG.Add(New Bullet(BulletType.小玉, BulletColor.土黄, 64, 16, Rnd() * 0.2 + 1.2 + i * 0.75, 180 - j * 20 + Rnd() * 5 + i * 12, 0) With {.Act = AddressOf .B6S1B2L})
                        Next
                    Next
                ElseIf Ticks Mod 360 = 180 Then
                    For i = 1 To 4
                        For j = 1 To i + 3
                            STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, 320, 16, Rnd() * 0.2 + 1.2 + i * 0.75, 180 + j * 20 - Rnd() * 5 - i * 12, 0) With {.Act = AddressOf .B6S1B2L})
                        Next
                    Next
                End If
            End If
        End If
    End Sub

    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S2L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 4000
        SpellTime = 3200
        Score = 5000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "甘符「莉莉与大玉工厂」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim t As Integer = Ticks Mod 240
            For i = 60 To 150 Step 30
                If t = i Then
                    STG.Add(New Bullet(BulletType.大玉, 2, Owner.X, Owner.Y, 1 + Rnd() * 0.5, Rnd() * 360, 0) With {.Act = AddressOf .B6S1B1L})
                End If
            Next
            If t Mod 30 = 0 AndAlso Ticks > 60 Then
                STG.Add(New Bullet(BulletType.大玉, 0, Owner.X, Owner.Y, 1.5, Ticks / 2, 0))
                STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 1.5, Ticks / 2 + 180, 0))
            End If
            If Ticks Mod 90 = 0 Then
                Owner.DefaultMove(60)
            End If
        Else
            If Ticks = 0 Then
                Owner.IsEnabled = True
            End If
            If Ticks <= 420 AndAlso Ticks > 60 Then
                If Ticks Mod 10 = 0 Then
                    For i = -160 To 160 Step 20
                        STG.Add(New Bullet(BulletType.星弹, 6, Owner.X, Owner.Y, 4, i * (Ticks - 60) / 360, 0))
                    Next
                End If
            ElseIf Ticks > 420 AndAlso Ticks <= 480 Then
                If Ticks Mod 10 = 0 Then
                    For i = -160 To 160 Step 20
                        STG.Add(New Bullet(BulletType.星弹, 6, Owner.X, Owner.Y, 4, i, 0))
                    Next
                End If
            End If
            If Ticks > 450 Then
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Bullet(BulletType.大玉, 3, Owner.X, Owner.Y, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B6S2B1L})
                End If
                If Ticks Mod 15 = 0 Then
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X + 64 * Sin(Ticks), Owner.Y - 24 * Cos(Ticks), 1.2, Ticks, 0))
                    STG.Add(New Bullet(BulletType.大玉, 0, Owner.X + 64 * Sin(Ticks + PI), Owner.Y - 24 * Cos(Ticks + PI), 1.2, Ticks + 180, 0))
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B6S3L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3000
        SpellTime = 2700
        Score = 5000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "蜜乐园「大玉摩天轮」"
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Owner.IsEnabled = True
            Owner.MoveTo(192, 224, 30)
        End If
        If Ticks = 60 Then
            For i = 0 To 345 Step 15
                STG.Add(New Bullet(BulletType.大玉, 0, 192 + 224 * Sin(i / 180 * PI), 224 + 224 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1L, .Tag = 224})
            Next
        End If
        If Ticks = 90 Then
            For i = 0 To 330 Step 30
                For j = 0 To 12 Step 2
                    STG.Add(New Bullet(BulletType.星弹, 6, 192 + 240 * j / 10 * Sin(i / 180 * PI), 224 + 240 * j / 10 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1L, .Tag = 240 * j / 12})
                Next
                For j = 1 To 11 Step 2
                    STG.Add(New Bullet(BulletType.星弹, 2, 192 + 240 * j / 10 * Sin(i / 180 * PI), 224 + 240 * j / 10 * Cos(i / 180 * PI), 0, i, 0) With {.Breakable = False, .Act = AddressOf .B6S3B1L, .Tag = 240 * j / 12})
                Next
            Next
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        For Each b In STG.SearchBullet
            b.Break(True, True)
        Next
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0401a.ReadLine()
            s = Texts.dialog0401a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0401a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0401b.ReadLine()
            s = Texts.dialog0401b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0401b)
            STG.DialogArea.Show()
        End If
        Stage4.Finished = True
        Return MyBase.Break()
    End Function
End Class
Module St4EnmL
    <Extension>
    Public Sub S4W1L(e As Enemy)
        With e
            If .Ticks = 70 Then
                For i = 0 To 270 Step 90
                    For j = 0 To 9
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.品红, .X, .Y, 1.8 + j * 0.1, i))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W2L(e As Enemy)
        With e
            If .Tag Mod 2 = 1 Then
                .Direction += 0.5
            Else
                .Direction -= 0.5
            End If
            If .Ticks Mod 12 = 0 AndAlso .Ticks > 30 Then
                Dim r As Integer = Rnd() * 360
                Select Case .Tag \ 10
                    Case 1
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                        For i = 0 To 3
                            STG.Add(New Bullet(BulletType.札弹, BulletColor.黄, .X + 12 * Sin((r + 90 * i) / 180 * PI), .Y - 12 * Cos((r + 90 * i) / 180 * PI), 0, r + 90 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                        Next
                        For i = 0 To 3
                            STG.Add(New Bullet(BulletType.札弹, BulletColor.红, .X + 12 * Sin((r + 90 * i + 45) / 180 * PI), .Y - 12 * Cos((r + 90 * i + 45) / 180 * PI), 0, r + 90 * i + 45, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                        Next
                    Case 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.心弹, 6, .X + 10 * Sin((r + 72 * i) / 180 * PI), .Y - 10 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i + 180, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                        Next
                End Select
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W3L(e As Enemy)
        With e
            If .Tag Mod 2 = 1 Then
                .Direction += 0.5
            Else
                .Direction -= 0.5
            End If
            If .Ticks Mod 60 = 0 AndAlso .Ticks > 30 Then

                Select Case .Tag \ 10
                    Case 1
                        Dim r As Integer = Rnd() * 360
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                        Next
                    Case 2
                        Dim r As Integer = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                        Next
                    Case 3
                        Dim r As Integer = 180 + Rnd() * 30 - 15
                        For i = 0 To 4
                            STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X + 6 * Sin((r + 72 * i) / 180 * PI), .Y - 6 * Cos((r + 72 * i) / 180 * PI), 0, r + 72 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                        Next
                End Select
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W4L(e As Enemy)
        With e
            If .Ticks = 40 Then
                .Speed = 0
            ElseIf .Ticks = 300 Then
                .Direction = 0
                .Speed = 1
            End If
            If .Ticks Mod 75 = 0 AndAlso .Ticks > 30 Then
                Dim r As Integer = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))

                STG.Add(New Bullet(BulletType.小玉, BulletColor.黄, .X, .Y, 0, 0, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                For i = 0 To 9
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.黄, .X + 14 * Sin((r + 36 * i) / 180 * PI), .Y - 14 * Cos((r + 36 * i) / 180 * PI), 0, r + 36 * i, 0) With {.Tag = r, .Act = AddressOf .S4W2B1L})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W2B1L(e As Bullet)
        With e
            If .Ticks = 16 AndAlso .BulletType = BulletType.心弹 Then
                .SetSize(16, 16, 4)
            End If
            If .Ticks > 30 Then
                .X += .Ticks / 60 * Sin(.Tag / 180 * PI)
                .Y -= .Ticks / 60 * Cos(.Tag / 180 * PI)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4B5IL(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(5, i))
            Next

            .SpellCards.Add(New B5S0L(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(5, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S4B5AL(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Lily White", 1)
                .NextSpell()
            End If

        End With
    End Sub
    <Extension>
    Public Sub B5S0B1L(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 0
            ElseIf .Ticks = 90 Then
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub B5S0B2L(e As Bullet)
        With e
            If .Ticks = 30 Then
                .Speed = 0
            ElseIf .Ticks = 75 Then
                .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
                .Speed = 1
            End If
        End With
    End Sub
    <Extension>
    Public Sub WordsL(e As Bullet)
        With e
            Select Case .Ticks
                Case 16
                    .SetSize(128, 32, 0.01)
                    .Background = Textures.words(0)
                Case 240
                    .Background = Textures.words(1)
                Case 480
                    .Background = Textures.words(2)
                Case 720
                    .Background = Textures.words(3)
                Case 1000
                    .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y)) + 90
                    .SetSize(128, 32, 8)
            End Select
            If .Ticks > 1000 Then
                .X += 8 * Sin((.Direction - 90) / 180 * PI)
                .Y -= 8 * Cos((.Direction - 90) / 180 * PI)
            End If
            If .Ticks = 1200 Then
                .Break(False, True)
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4W5L(e As Enemy)
        With e
            If .Ticks = 64 Then
                .Speed = 0
            End If
            If .Ticks > 64 Then
                If .Ticks Mod 10 = 0 Then
                    For i = 0 To 5
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.青, .X, .Y, 1.8, .Ticks * 1.2 + i * 13, 0))
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.品红, .X, .Y, 1.8, - .Ticks * 1.2 - i * 13, 0))
                    Next
                End If
                If .Ticks Mod 60 = 0 Then
                    For i = 0 To 345 Step 15
                        STG.Add(New Bullet(BulletType.中玉, 0, .X, .Y, 1.2, i))
                    Next
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S4B6IL(e As Enemy.Boss)
        With e
            For i = 0 To 3
                .NormalTextures.Add(Textures.boss(5, i))
            Next
            .SpellCards.Add(New B6S0L(e))
            .SpellCards.Add(New B6S1L(e))
            .SpellCards.Add(New B6S2L(e))
            .SpellCards.Add(New B6S3L(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(5, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S4B6AL(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("Lily White", 4)
                ResourcePack.Sounds.StopSound(STG.CurrentMusic)
                ResourcePack.Sounds.PlaySound(Sounds.mu09)
                Stage.Showmusic("云霄之上的花与舞")
                STG.CurrentMusic = Sounds.mu09
                .NextSpell()
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S0B1L(e As Bullet)
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
    Public Sub B6S1B1L(e As Bullet)
        With e
            If .Ticks = 80 Then
                .Speed = 0
                .Tag = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
            ElseIf .Ticks > 90 AndAlso .Ticks <= 190 AndAlso .Ticks Mod 5 = 0 Then
                For i = 0 To 330 Step 30
                    STG.Add(New Bullet(BulletType.米弹, BulletColor.品红, .X, .Y, .Ticks / 60 + 1, i + Val(.Tag), 0))
                Next
            ElseIf .Ticks = 200 Then
                .Break()
            End If

        End With
    End Sub
    <Extension>
    Public Sub B6S1B2L(e As Bullet)
        With e
            If .Ticks = 80 Then
                .Speed = 0
            ElseIf .Ticks = 120 Then
                If .BulletColor = BulletColor.土黄 Then
                    STG.Add(New Bullet(BulletType.大玉, 3, .X, .Y, 0, 170 + Rnd() * 20, 0) With {.Act = AddressOf .B6S1B3L})
                Else
                    STG.Add(New Bullet(BulletType.大玉, 0, .X, .Y, 0, 170 + Rnd() * 20, 0) With {.Act = AddressOf .B6S1B3L})
                End If
                .Break(False)
            End If

        End With
    End Sub
    <Extension>
    Public Sub B6S1B3L(e As Bullet)
        With e
            If .Ticks > 30 AndAlso .Ticks < 100 Then
                .Speed += 0.03
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S2B1L(e As Bullet)
        With e
            If IsNothing(.Tag) Then
                .Tag = -2
            Else
                .Tag += 0.025
                .Y += .Tag
            End If
            .X += .Direction
            If Rnd() > 0.991 Then
                .Break(False)
                For i = -2.5 To 2.5 Step 1
                    STG.Add(New Bullet(BulletType.星弹, 6, .X, .Y, 0, i, 0) With {.Act = AddressOf .B6S0B1L})
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub B6S3B1L(e As Bullet)
        With e
            If .BulletColor = 2 Then
                .X = 192 + .Tag * Sin((.Direction + .Ticks / 5) / 180 * PI)
                .Y = 224 + .Tag * Cos((.Direction + .Ticks / 5) / 180 * PI)
            Else
                .X = 192 + .Tag * Sin((.Direction - .Ticks / 5) / 180 * PI)
                .Y = 224 + .Tag * Cos((.Direction - .Ticks / 5) / 180 * PI)
            End If
        End With
    End Sub
End Module
#End Region