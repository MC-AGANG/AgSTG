Imports System.Math
Imports System.Runtime.CompilerServices
Imports AgSTG
Imports ResourcePack.TH07
Public Class Stage3
    Inherits Stage
    Public Shared BG As Stage3bg
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
            Showmusic("Romantic Children")
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
        Background = New Stage3bg
        BG = Background
        Finished = False
        EndFrame = 0
    End Sub

    Private Sub EnemySpawnE()
        Select Case Ticks
            Case 240 To 320
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1E})
                End If
            Case 360 To 440
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1E})
                End If
            Case 480 To 560
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1E})
                End If
            Case 600 To 680
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1E})
                End If
            Case 720
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 840
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 304, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 80, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 1200 To 1340
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1E})
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1E})
                End If
            Case 1680 To 1860
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 1680) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3E})
                End If
            Case 1980 To 2160
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 1980) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3E})
                End If
            Case 2220
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 2340
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 2460
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 2580
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 2940
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 3060
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 3180
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 3300
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 3420
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 224, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 160, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 3540
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4E})
            Case 3660
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4E})
            Case 3780
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4E})
            Case 3900
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W4E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W4E})
            Case 4200 To 4380
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4200) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3E})
                End If
            Case 4500 To 4680
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4500) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3E})
                End If
            Case 4860 To 5040
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4860) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3E})
                End If
            Case 5160 To 5340
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 5160) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3E})
                End If
            Case 5520 To 5600
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1E})
                End If
            Case 5640 To 5720
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1E})
                End If
            Case 5820 To 5900
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 96, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1E})
                End If
            Case 5940 To 6020
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 228, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1E})
                End If
            Case 6150
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S3B3IE), .Act = New Action(AddressOf .S3B3AE)})


            Case 7920 To 8000
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1E})
                End If
            Case 8040 To 8120
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1E})
                End If
            Case 8220 To 8300
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 96, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1E})
                End If
            Case 8340 To 8420
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 228, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1E})
                End If
            Case 8580
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2E})
            Case 8700
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 304, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2E})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 80, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2E})

            Case 9480 To 9510
                For i = 0 To 3
                    If Ticks = 9480 + i * 10 Then
                        For j = 0 To 2
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, 40 + i * 10, 360 - i * 10, 1 + j * 0.4))
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, 344 - i * 10, 360 - i * 10, 1 + j * 0.4))
                        Next

                    End If
                Next
            Case 9520 To 9610
                If Ticks Mod 10 = 0 Then
                    Dim r1 As Double = 32 + 128 * Rnd()
                    Dim r2 As Double = 32 + Rnd() * 256
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.白, r2, r1, 1 + j * 0.4))
                    Next
                End If
            Case 9850
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S3B4IE), .Act = New Action(AddressOf .S3B4AE)})
        End Select
    End Sub

    Private Sub EnemySpawnN()
        Select Case Ticks
            Case 240 To 320
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1N})
                End If
            Case 360 To 440
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1N})
                End If
            Case 480 To 560
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1N})
                End If
            Case 600 To 680
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1N})
                End If
            Case 720
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 840
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 304, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 80, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 1200 To 1340
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1N})
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1N})
                End If
            Case 1680 To 1860
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 1680) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3N})
                End If
            Case 1980 To 2160
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 1980) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3N})
                End If
            Case 2220
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 2340
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 2460
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 2580
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 2940
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 3060
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 3180
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 3300
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 3420
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 224, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 160, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 3540
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4N})
            Case 3660
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4N})
            Case 3780
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4N})
            Case 3900
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W4N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W4N})
            Case 4200 To 4380
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4200) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3N})
                End If
            Case 4500 To 4680
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4500) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3N})
                End If
            Case 4860 To 5040
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4860) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3N})
                End If
            Case 5160 To 5340
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 5160) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3N})
                End If
            Case 5520 To 5600
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1N})
                End If
            Case 5640 To 5720
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1N})
                End If
            Case 5820 To 5900
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 96, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1N})
                End If
            Case 5940 To 6020
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 228, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1N})
                End If
            Case 6150
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S3B3IN), .Act = New Action(AddressOf .S3B3AN)})


            Case 7920 To 8000
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1N})
                End If
            Case 8040 To 8120
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1N})
                End If
            Case 8220 To 8300
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 96, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1N})
                End If
            Case 8340 To 8420
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 228, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1N})
                End If
            Case 8580
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2N})
            Case 8700
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 304, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2N})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 80, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2N})

            Case 9480 To 9510
                For i = 0 To 3
                    If Ticks = 9480 + i * 10 Then
                        For j = 0 To 2
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, 40 + i * 10, 360 - i * 10, 1 + j * 0.4))
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, 344 - i * 10, 360 - i * 10, 1 + j * 0.4))
                        Next

                    End If
                Next
            Case 9520 To 9610
                If Ticks Mod 10 = 0 Then
                    Dim r1 As Double = 32 + 128 * Rnd()
                    Dim r2 As Double = 32 + Rnd() * 256
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.白, r2, r1, 1 + j * 0.4))
                    Next
                End If
            Case 9850
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S3B4IN), .Act = New Action(AddressOf .S3B4AN)})
        End Select
    End Sub

    Private Sub EnemySpawnH()
        Select Case Ticks
            Case 240 To 320
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1H})
                End If
            Case 360 To 440
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1H})
                End If
            Case 480 To 560
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1H})
                End If
            Case 600 To 680
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1H})
                End If
            Case 720
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 840
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 304, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 80, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 1200 To 1340
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1H})
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1H})
                End If
            Case 1680 To 1860
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 1680) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3H})
                End If
            Case 1980 To 2160
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 1980) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3H})
                End If
            Case 2220
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 2340
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 2460
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 2580
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 2940
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 3060
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 3180
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 3300
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 3420
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 224, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 160, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 3540
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4H})
            Case 3660
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4H})
            Case 3780
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4H})
            Case 3900
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W4H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W4H})
            Case 4200 To 4380
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4200) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3H})
                End If
            Case 4500 To 4680
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4500) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3H})
                End If
            Case 4860 To 5040
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4860) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3H})
                End If
            Case 5160 To 5340
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 5160) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3H})
                End If
            Case 5520 To 5600
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1H})
                End If
            Case 5640 To 5720
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1H})
                End If
            Case 5820 To 5900
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 96, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1H})
                End If
            Case 5940 To 6020
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 228, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1H})
                End If
            Case 6150
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S3B3IH), .Act = New Action(AddressOf .S3B3AH)})


            Case 7920 To 8000
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1H})
                End If
            Case 8040 To 8120
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1H})
                End If
            Case 8220 To 8300
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 96, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1H})
                End If
            Case 8340 To 8420
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 228, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1H})
                End If
            Case 8580
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 8700
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 304, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2H})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 80, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2H})

            Case 9480 To 9510
                For i = 0 To 3
                    If Ticks = 9480 + i * 10 Then
                        For j = 0 To 2
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, 40 + i * 10, 360 - i * 10, 1 + j * 0.5))
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, 344 - i * 10, 360 - i * 10, 1 + j * 0.5))
                        Next

                    End If
                Next
            Case 9520 To 9610
                If Ticks Mod 10 = 0 Then
                    Dim r1 As Double = 32 + 128 * Rnd()
                    Dim r2 As Double = 32 + Rnd() * 256
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.白, r2, r1, 1 + j * 0.5))
                    Next
                End If
            Case 9850
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S3B4IH), .Act = New Action(AddressOf .S3B4AH)})
        End Select
    End Sub

    Private Sub EnemySpawnL()
        Select Case Ticks
            Case 240 To 320
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1L})
                End If
            Case 360 To 440
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1L})
                End If
            Case 480 To 560
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1L})
                End If
            Case 600 To 680
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1L})
                End If
            Case 720
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 840
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 304, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 80, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 1200 To 1340
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1L})
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1L})
                End If
            Case 1680 To 1860
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 1680) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3L})
                End If
            Case 1980 To 2160
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 1980) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3L})
                End If
            Case 2220
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 2340
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 2460
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 2580
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 2940
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 3060
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 3180
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 3300
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W2H})
            Case 3420
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 224, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 160, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 3540
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 256, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 128, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4L})
            Case 3660
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 288, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 96, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4L})
            Case 3780
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 320, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 64, -16, 150, "0011", 1000, 0.33, 180) With {.Act = AddressOf .S3W4L})
            Case 3900
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W4L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "00116", 1000, 0.33, 180) With {.Act = AddressOf .S3W4L})
            Case 4200 To 4380
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4200) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3L})
                End If
            Case 4500 To 4680
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4500) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3L})
                End If
            Case 4860 To 5040
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 4860) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, 400, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 265) With {.Act = AddressOf .S3W3L})
                End If
            Case 5160 To 5340
                If Ticks Mod 20 = 0 Then
                    Dim t As Integer = (Ticks - 5160) \ 20
                    STG.Add(New Enemy(EnemyType.小妖精, 0, -16, 32 + 24 * (t Mod 5), 20, "01", 128, 3, 95) With {.Act = AddressOf .S3W3L})
                End If
            Case 5520 To 5600
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1L})
                End If
            Case 5640 To 5720
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1L})
                End If
            Case 5820 To 5900
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 96, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1L})
                End If
            Case 5940 To 6020
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 228, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1L})
                End If
            Case 6150
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S3B3IL), .Act = New Action(AddressOf .S3B3AL)})


            Case 7920 To 8000
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 32, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1L})
                End If
            Case 8040 To 8120
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 352, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1L})
                End If
            Case 8220 To 8300
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 96, -16, 20, "1", 240, 2, 180) With {.Tag = 1, .Act = AddressOf .S3W1L})
                End If
            Case 8340 To 8420
                If Ticks Mod 20 = 0 Then
                    STG.Add(New Enemy(EnemyType.阴阳玉, 0, 228, -16, 20, "0", 240, 2, 180) With {.Tag = 2, .Act = AddressOf .S3W1L})
                End If
            Case 8580
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 352, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 32, -16, 150, "0011", 500, 0.33, 180) With {.Act = AddressOf .S3W2L})
            Case 8700
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 304, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2L})
                STG.Add(New Enemy(EnemyType.中蝴蝶, 0, 80, -16, 150, "0011", 800, 0.33, 180) With {.Act = AddressOf .S3W2L})

            Case 9480 To 9510
                For i = 0 To 3
                    If Ticks = 9480 + i * 10 Then
                        For j = 0 To 2
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, 40 + i * 10, 360 - i * 10, 1 + j * 0.8))
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.白, 344 - i * 10, 360 - i * 10, 1 + j * 0.8))
                        Next

                    End If
                Next
            Case 9520 To 9610
                If Ticks Mod 10 = 0 Then
                    Dim r1 As Double = 32 + 128 * Rnd()
                    Dim r2 As Double = 32 + Rnd() * 256
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.白, r2, r1, 1 + j * 0.8))
                    Next
                End If
            Case 9850
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S3B4IL), .Act = New Action(AddressOf .S3B4AL)})
        End Select
    End Sub
End Class

#Region "Easy"
Public Class B3S0E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 5000
        UsualTime = 2400
        HaveUsual = True
        Items = "000000000011111111113"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks Mod 300 = 240 Then
            Owner.MoveTo(STG.Player.X, Owner.Y, 60)
        ElseIf Ticks Mod 300 = 60 Then
            ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
        End If
        If Ticks Mod 900 = 120 Then
            For i = 0 To 2
                For j = 160 To 200 Step 40
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.4, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 140 Then
            For i = 0 To 2
                For j = 168 To 192 Step 8
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25 + i * 0.4, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 160 Then
            For i = 0 To 2
                For j = 140 To 220 Step 20
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.4, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 420 Then
            For i = 0 To 2
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.4))
            Next
        ElseIf Ticks Mod 900 = 440 Then
            For i = 0 To 2
                For j = -3 To 3 Step 6
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25 + i * 0.4, j))
                Next
            Next
        ElseIf Ticks Mod 900 = 460 Then
            For i = 0 To 2
                For j = -10 To 10 Step 10
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.4, j))
                Next
            Next
        ElseIf Ticks Mod 900 = 720 Then
            For j = 105 To 255 Step 15
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.2, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.2, j - 1, 0))
            Next
        ElseIf Ticks Mod 900 = 740 Then
            For j = 90 To 270 Step 15
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.2, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.2, j - 1, 0))
            Next
        ElseIf Ticks Mod 900 = 760 Then
            For j = 105 To 255 Step 15
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.2, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.2, j - 1, 0))
            Next
        End If
    End Sub
End Class
Public Class B4S0E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "一符"
    End Sub
    Private px, py, pd As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 24 Then
                Owner.DefaultMove(30)
            ElseIf Ticks Mod 300 = 60 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
            End If
            For i = 90 To 150 Step 5
                If Ticks Mod 600 = i Then
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.红, Owner.X, Owner.Y, 0.8 + Rnd() * 1.8, 100 + Rnd() * 160, 0))
                    Next
                End If
            Next
            For i = 90 To 150 Step 15
                If Ticks Mod 600 = i + 300 Then
                    For j = 0 To 300 Step 60
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.红, Owner.X, Owner.Y, 2, j + i * 2, 0) With {.Act = AddressOf .B4S0B1E})
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 2, j + i * 2 + 30, 0))
                    Next
                End If
            Next
        Else
            If Ticks = 0 Then
                Stage3.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks > 60 Then
                If Ticks Mod 8 = 0 Then
                    For i = 2 To 3
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.红, Owner.X, Owner.Y, 4, 40 + i * 5 + 30 * Sin(Ticks / 30)))
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.红, Owner.X, Owner.Y, 4, -40 - i * 5 - 30 * Sin(Ticks / 30)))
                    Next

                End If
                If Ticks Mod 5 = 0 AndAlso Ticks Mod 30 <= 20 Then
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, px, py, 2, pd, 0) With {.SoundEffect = ResourcePack.Sounds.kira00})
                End If
                If Ticks Mod 60 = 30 Then
                    Owner.DefaultMove(50)
                End If
                If Ticks Mod 30 = 0 Then
                    px = Rnd() * 48 - 24 + Owner.X
                    py = Rnd() * 48 - 24 + Owner.Y
                    pd = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B4S1E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "二符"
    End Sub
    Private px, py As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 24 Then
                Owner.DefaultMove(30)
            ElseIf Ticks Mod 300 = 60 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
            End If
            For i = 90 To 150 Step 3
                If Ticks Mod 600 = i Then
                    STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, Owner.X, Owner.Y, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B4S1B1E})
                    px = Rnd() * 64 - 32 + Owner.X
                    py = Rnd() * 64 - 32 + Owner.Y
                    If i Mod 10 = 0 Then
                        For j = 0 To 2
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.蓝, px, py, 1 + j * 0.4))
                        Next
                    End If
                End If
            Next
            For i = 90 To 150 Step 10
                If Ticks Mod 600 = i + 300 Then
                    For j = 0 To 300 Step 60
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, Owner.X, Owner.Y, 2, j + i * 2 + 22.5, 0))
                    Next
                End If
            Next
        Else
            If Ticks = 0 Then
                Stage3.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks > 60 Then
                If Ticks Mod 20 = 0 Then
                    For i = 0 To 5
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, Owner.X, Owner.Y, 1.2, i * 60 + Ticks \ 2, 0) With {.Act = AddressOf .B4S1B2E})

                    Next
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B4S2E
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "终符"
    End Sub
    Private px, py As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Stage3.BG.cardback.Visibility = Visibility.Visible
            Owner.IsEnabled = True
        End If
        If Ticks Mod 60 = 50 Then
            Owner.DefaultMove(60)
        End If
        If Ticks > 30 Then
            If Ticks Mod 6 = 0 Then
                For i = 0 To 30 Step 10
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.黄, Owner.X, Owner.Y, 2, Ticks * 16 + i, 0))
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.黄, Owner.X, Owner.Y, 2, Ticks * 16 + i + 180, 0))
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0302a.ReadLine()
            s = Texts.dialog0302a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0302a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0302b.ReadLine()
            s = Texts.dialog0302b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0302b)
            STG.DialogArea.Show()
        End If
        Stage3.Finished = True
        Return MyBase.Break()
    End Function
End Class


Module St3EnmE
    <Extension>
    Public Sub S3W1E(e As Enemy)
        With e
            If .Ticks > 1 AndAlso .Ticks < 360 Then
                If .Tag = 1 Then
                    .Direction -= 1
                Else
                    .Direction += 1
                End If

            End If
            If .Ticks = 100 Then
                STG.Add(New Bullet(BulletType.环弹, BulletColor.红, .X, .Y, 1))
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W2E(e As Enemy)
        With e
            If .Ticks = 160 Then
                For i = -30 To 30 Step 30
                    For j = 0 To 1
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.白, .X, .Y, 1 + j * 0.8, i))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W3E(e As Enemy)
        With e
            If .Ticks > 16 AndAlso Rnd() > 0.99 Then
                For i = -40 To 40 Step 40
                    STG.Add(New Bullet(BulletType.环弹, BulletColor.白, .X, .Y, 1.5, i))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W4E(e As Enemy)
        With e
            If .Ticks = 160 Then

                For j = 0 To 3
                    STG.Add(New Bullet(BulletType.点弹, BulletColor.白, .X, .Y, 1 + j * 0.2))
                Next

            End If
        End With
    End Sub
    <Extension>
    Public Sub S3B3IE(e As Enemy.Boss)
        With e
            .NormalTextures.Add(Textures.boss(3, 0))

            .SpellCards.Add(New B3S0E(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(3, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S3B3AE(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("???", 1)
                .NextSpell()
            End If

        End With
    End Sub
    <Extension>
    Public Sub S3B4IE(e As Enemy.Boss)
        With e
            .NormalTextures.Add(Textures.boss(4, 0))
            For i = 4 To 8
                .MoveTextures.Add(Textures.boss(4, i))
            Next
            .SpellCards.Add(New B4S0E(e))
            .SpellCards.Add(New B4S1E(e))
            .SpellCards.Add(New B4S2E(e))
            .Layer3.Height = 64
            .Layer3.Width = 48
            .Layer3_scale.CenterX = 24
            Canvas.SetLeft(.Layer3, 40)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(4, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S3B4AE(e As Enemy.Boss)
        With e
            Static started As Boolean = False
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0301a.ReadLine()
                    s = Texts.dialog0301a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0301a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0301b.ReadLine()
                    s = Texts.dialog0301b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0301b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                started = True
                .IsEnabled = True
                STG.NameArea.Initialize("Alice", 3)
                .NextSpell()
                ResourcePack.Sounds.StopSound(ResourcePack.Sounds.CurrentMusic)
                ResourcePack.Sounds.PlayMusic(Sounds.mu07)
                Stage.Showmusic("the Grimoire of Alice")
                ResourcePack.Sounds.CurrentMusic = Sounds.mu07
            End If
        End With
    End Sub
    <Extension>
    Public Sub B4S0B1E(e As Bullet)
        With e
            If .Ticks = 60 Then
                .Speed = 0
            ElseIf .Ticks = 90 Then
                .Speed = 2
                .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
            End If
        End With
    End Sub
    <Extension>
    Public Sub B4S1B1E(e As Bullet)
        With e
            If IsNothing(.Tag) Then
                .Tag = -2
            Else
                .Tag += 0.02
                .Y += .Tag
            End If

            .X += .Direction
        End With
    End Sub
    <Extension>
    Public Sub B4S1B2E(e As Bullet)
        With e
            If .X < 8 Then
                .Direction = 360 - .Direction
            ElseIf .X > 376 Then
                .Direction = 360 - .Direction
            ElseIf .Y < 8 Then
                .Direction = 180 - .Direction
            End If
        End With
    End Sub
End Module
#End Region

#Region "Normal"
Public Class B3S0N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 5000
        UsualTime = 2400
        HaveUsual = True
        Items = "000000000011111111113"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks Mod 300 = 240 Then
            Owner.MoveTo(STG.Player.X, Owner.Y, 60)
        ElseIf Ticks Mod 300 = 60 Then
            ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
        End If
        If Ticks Mod 900 = 120 Then
            For i = 0 To 2
                For j = 150 To 210 Step 30
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.5, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 140 Then
            For i = 0 To 2
                For j = 168 To 192 Step 8
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25 + i * 0.5, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 160 Then
            For i = 0 To 2
                For j = 135 To 225 Step 15
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.5, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 420 Then
            For i = 0 To 2
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.5))
            Next
        ElseIf Ticks Mod 900 = 440 Then
            For i = 0 To 2
                For j = -4 To 4 Step 8
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25 + i * 0.5, j))
                Next
            Next
        ElseIf Ticks Mod 900 = 460 Then
            For i = 0 To 2
                For j = -12 To 12 Step 12
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.5, j))
                Next
            Next
        ElseIf Ticks Mod 900 = 720 Then
            For j = 105 To 255 Step 10
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, j - 1, 0))
            Next
        ElseIf Ticks Mod 900 = 740 Then
            For j = 100 To 260 Step 10
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, j - 1, 0))
            Next
        ElseIf Ticks Mod 900 = 760 Then
            For j = 105 To 255 Step 10
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, j - 1, 0))
            Next
        End If
    End Sub
End Class
Public Class B4S0N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "一符"
    End Sub
    Private px, py, pd As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 24 Then
                Owner.DefaultMove(30)
            ElseIf Ticks Mod 300 = 60 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
            End If
            For i = 90 To 150 Step 3
                If Ticks Mod 600 = i Then
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.红, Owner.X, Owner.Y, 0.8 + Rnd() * 2, 100 + Rnd() * 160, 0))
                    Next
                End If
            Next
            For i = 90 To 150 Step 10
                If Ticks Mod 600 = i + 300 Then
                    For j = 0 To 315 Step 45
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.红, Owner.X, Owner.Y, 2.25, j + i * 2, 0) With {.Act = AddressOf .B4S0B1N})
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 2.25, j + i * 2 + 22.5, 0))
                    Next
                End If
            Next
        Else
            If Ticks = 0 Then
                Stage3.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks > 60 Then
                If Ticks Mod 8 = 0 Then
                    For i = 1 To 3
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.红, Owner.X, Owner.Y, 4, 40 + i * 4 + 30 * Sin(Ticks / 30)))
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.红, Owner.X, Owner.Y, 4, -40 - i * 4 - 30 * Sin(Ticks / 30)))
                    Next

                End If
                If Ticks Mod 5 = 0 AndAlso Ticks Mod 30 <= 20 Then
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, px, py, 2.5, pd, 0) With {.SoundEffect = ResourcePack.Sounds.kira00})
                End If
                If Ticks Mod 60 = 30 Then
                    Owner.DefaultMove(50)
                End If
                If Ticks Mod 30 = 0 Then
                    px = Rnd() * 48 - 24 + Owner.X
                    py = Rnd() * 48 - 24 + Owner.Y
                    pd = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B4S1N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "二符"
    End Sub
    Private px, py As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 24 Then
                Owner.DefaultMove(30)
            ElseIf Ticks Mod 300 = 60 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
            End If
            For i = 90 To 150 Step 2
                If Ticks Mod 600 = i Then
                    STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, Owner.X, Owner.Y, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B4S1B1N})
                    px = Rnd() * 64 - 32 + Owner.X
                    py = Rnd() * 64 - 32 + Owner.Y
                    If i Mod 10 = 0 Then
                        For j = 0 To 2
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.蓝, px, py, 1 + j * 0.4))
                        Next
                    End If
                End If
            Next
            For i = 90 To 150 Step 7
                If Ticks Mod 600 = i + 300 Then
                    For j = 0 To 300 Step 60
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, Owner.X, Owner.Y, 2.25, j + i * 2 + 22.5, 0))
                    Next
                End If
            Next
        Else
            If Ticks = 0 Then
                Stage3.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks > 60 Then
                If Ticks Mod 15 = 0 Then
                    For i = 0 To 5
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, i * 60 + Ticks \ 2, 0) With {.Act = AddressOf .B4S1B2N})

                    Next
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B4S2N
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "终符"
    End Sub
    Private px, py As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Stage3.BG.cardback.Visibility = Visibility.Visible
            Owner.IsEnabled = True
        End If
        If Ticks Mod 60 = 50 Then
            Owner.DefaultMove(60)
        End If
        If Ticks > 30 Then
            If Ticks Mod 4 = 0 Then
                For i = 0 To 30 Step 10
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.黄, Owner.X, Owner.Y, 3, Ticks * 16 + i, 0))
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.黄, Owner.X, Owner.Y, 3, Ticks * 16 + i + 180, 0))
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0302a.ReadLine()
            s = Texts.dialog0302a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0302a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0302b.ReadLine()
            s = Texts.dialog0302b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0302b)
            STG.DialogArea.Show()
        End If
        Stage3.Finished = True
        Return MyBase.Break()
    End Function
End Class


Module St3EnmN
    <Extension>
    Public Sub S3W1N(e As Enemy)
        With e
            If .Ticks > 1 AndAlso .Ticks < 360 Then
                If .Tag = 1 Then
                    .Direction -= 1
                Else
                    .Direction += 1
                End If

            End If
            If .Ticks = 100 Then
                STG.Add(New Bullet(BulletType.环弹, BulletColor.红, .X, .Y, 1.2))
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W2N(e As Enemy)
        With e
            If .Ticks = 160 Then
                For i = -60 To 60 Step 30
                    For j = 0 To 1
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.白, .X, .Y, 1 + j * 0.8, i))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W3N(e As Enemy)
        With e
            If .Ticks > 16 AndAlso Rnd() > 0.99 Then
                For i = -40 To 40 Step 40
                    STG.Add(New Bullet(BulletType.环弹, BulletColor.白, .X, .Y, 2, i))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W4N(e As Enemy)
        With e
            If .Ticks = 160 Then

                For j = 0 To 5
                    STG.Add(New Bullet(BulletType.点弹, BulletColor.白, .X, .Y, 1 + j * 0.2))
                Next

            End If
        End With
    End Sub
    <Extension>
    Public Sub S3B3IN(e As Enemy.Boss)
        With e
            .NormalTextures.Add(Textures.boss(3, 0))

            .SpellCards.Add(New B3S0N(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(3, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S3B3AN(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("???", 1)
                .NextSpell()
            End If

        End With
    End Sub
    <Extension>
    Public Sub S3B4IN(e As Enemy.Boss)
        With e
            .NormalTextures.Add(Textures.boss(4, 0))
            For i = 4 To 8
                .MoveTextures.Add(Textures.boss(4, i))
            Next
            .SpellCards.Add(New B4S0N(e))
            .SpellCards.Add(New B4S1N(e))
            .SpellCards.Add(New B4S2N(e))
            .Layer3.Height = 64
            .Layer3.Width = 48
            .Layer3_scale.CenterX = 24
            Canvas.SetLeft(.Layer3, 40)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(4, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S3B4AN(e As Enemy.Boss)
        With e
            Static started As Boolean = False
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0301a.ReadLine()
                    s = Texts.dialog0301a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0301a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0301b.ReadLine()
                    s = Texts.dialog0301b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0301b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                started = True
                .IsEnabled = True
                STG.NameArea.Initialize("Alice", 3)
                .NextSpell()
                ResourcePack.Sounds.StopSound(ResourcePack.Sounds.CurrentMusic)
                ResourcePack.Sounds.PlayMusic(Sounds.mu07)
                Stage.Showmusic("the Grimoire of Alice")
                ResourcePack.Sounds.CurrentMusic = Sounds.mu07
            End If
        End With
    End Sub
    <Extension>
    Public Sub B4S0B1N(e As Bullet)
        With e
            If .Ticks = 60 Then
                .Speed = 0
            ElseIf .Ticks = 90 Then
                .Speed = 2
                .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
            End If
        End With
    End Sub
    <Extension>
    Public Sub B4S1B1N(e As Bullet)
        With e
            If IsNothing(.Tag) Then
                .Tag = -2
            Else
                .Tag += 0.02
                .Y += .Tag
            End If

            .X += .Direction
        End With
    End Sub
    <Extension>
    Public Sub B4S1B2N(e As Bullet)
        With e
            If .X < 8 Then
                .Direction = 360 - .Direction
            ElseIf .X > 376 Then
                .Direction = 360 - .Direction
            ElseIf .Y < 8 Then
                .Direction = 180 - .Direction
            End If
        End With
    End Sub
End Module
#End Region

#Region "Hard"
Public Class B3S0H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 5000
        UsualTime = 2400
        HaveUsual = True
        Items = "000000000011111111113"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks Mod 300 = 240 Then
            Owner.MoveTo(STG.Player.X, Owner.Y, 60)
        ElseIf Ticks Mod 300 = 60 Then
            ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
        End If
        If Ticks Mod 900 = 120 Then
            For i = 0 To 3
                For j = 150 To 210 Step 30
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.5, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 140 Then
            For i = 0 To 3
                For j = 168 To 192 Step 8
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25 + i * 0.5, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 160 Then
            For i = 0 To 3
                For j = 135 To 225 Step 15
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.5, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 420 Then
            For i = 0 To 3
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.5))
            Next
        ElseIf Ticks Mod 900 = 440 Then
            For i = 0 To 3
                For j = -4 To 4 Step 8
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25 + i * 0.5, j))
                Next
            Next
        ElseIf Ticks Mod 900 = 460 Then
            For i = 0 To 3
                For j = -12 To 12 Step 12
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.5, j))
                Next
            Next
        ElseIf Ticks Mod 900 = 720 Then
            For j = 105 To 255 Step 10
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2, j - 1, 0))
            Next
        ElseIf Ticks Mod 900 = 740 Then
            For j = 100 To 260 Step 10
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2, j - 1, 0))
            Next
        ElseIf Ticks Mod 900 = 760 Then
            For j = 105 To 255 Step 10
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2, j - 1, 0))
            Next
        End If
    End Sub
End Class
Public Class B4S0H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "一符"
    End Sub
    Private px, py, pd As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 24 Then
                Owner.DefaultMove(30)
            ElseIf Ticks Mod 300 = 60 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
            End If
            For i = 90 To 150 Step 2
                If Ticks Mod 600 = i Then
                    For j = 0 To 3
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.红, Owner.X, Owner.Y, 1 + Rnd() * 2, 100 + Rnd() * 160, 0))
                    Next
                End If
            Next
            For i = 90 To 150 Step 5
                If Ticks Mod 600 = i + 300 Then
                    For j = 0 To 315 Step 45
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.红, Owner.X, Owner.Y, 2.5, j + i * 2, 0) With {.Act = AddressOf .B4S0B1H})
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 2.5, j + i * 2 + 22.5, 0))
                    Next
                End If
            Next
        Else
            If Ticks = 0 Then
                Stage3.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks > 60 Then
                If Ticks Mod 8 = 0 Then
                    For i = 0 To 3
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.红, Owner.X, Owner.Y, 4, 40 + i * 4 + 30 * Sin(Ticks / 30)))
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.红, Owner.X, Owner.Y, 4, -40 - i * 4 - 30 * Sin(Ticks / 30)))
                    Next

                End If
                If Ticks Mod 4 = 0 AndAlso Ticks Mod 30 <= 20 Then
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, px, py, 3, pd, 0) With {.SoundEffect = ResourcePack.Sounds.kira00})
                End If
                If Ticks Mod 60 = 30 Then
                    Owner.DefaultMove(50)
                End If
                If Ticks Mod 30 = 0 Then
                    px = Rnd() * 48 - 24 + Owner.X
                    py = Rnd() * 48 - 24 + Owner.Y
                    pd = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B4S1H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "二符"
    End Sub
    Private px, py As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 24 Then
                Owner.DefaultMove(30)
            ElseIf Ticks Mod 300 = 60 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
            End If
            For i = 90 To 150 Step 2
                If Ticks Mod 600 = i Then
                    For j = 0 To 1
                        STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, Owner.X, Owner.Y, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B4S1B1H})
                    Next
                    px = Rnd() * 64 - 32 + Owner.X
                    py = Rnd() * 64 - 32 + Owner.Y
                    If i Mod 10 = 0 Then
                        For j = 0 To 3
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.蓝, px, py, 1 + j * 0.4))
                        Next
                    End If
                End If
            Next
            For i = 90 To 150 Step 7
                If Ticks Mod 600 = i + 300 Then
                    For j = 0 To 315 Step 45
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, Owner.X, Owner.Y, 2.5, j + i * 2 + 22.5, 0))
                    Next
                End If
            Next
        Else
            If Ticks = 0 Then
                Stage3.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks > 60 Then
                If Ticks Mod 15 = 0 Then
                    For i = 0 To 7
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, Owner.X, Owner.Y, 1.5, i * 45 + Ticks \ 2, 0) With {.Act = AddressOf .B4S1B2H})

                    Next
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B4S2H
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "终符"
    End Sub
    Private px, py As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Stage3.BG.cardback.Visibility = Visibility.Visible
            Owner.IsEnabled = True
        End If
        If Ticks Mod 60 = 50 Then
            Owner.DefaultMove(60)
        End If
        If Ticks > 30 Then
            If Ticks Mod 4 = 0 Then
                For i = 0 To 28 Step 8
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.黄, Owner.X, Owner.Y, 3, Ticks * 16 + i, 0))
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.黄, Owner.X, Owner.Y, 3, Ticks * 16 + i + 180, 0))
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0302a.ReadLine()
            s = Texts.dialog0302a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0302a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0302b.ReadLine()
            s = Texts.dialog0302b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0302b)
            STG.DialogArea.Show()
        End If
        Stage3.Finished = True
        Return MyBase.Break()
    End Function
End Class


Module St3EnmH
    <Extension>
    Public Sub S3W1H(e As Enemy)
        With e
            If .Ticks > 1 AndAlso .Ticks < 360 Then
                If .Tag = 1 Then
                    .Direction -= 1
                Else
                    .Direction += 1
                End If

            End If
            If .Ticks = 100 Then
                STG.Add(New Bullet(BulletType.环弹, BulletColor.红, .X, .Y, 1.5))
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W2H(e As Enemy)
        With e
            If .Ticks = 160 Then
                For i = -60 To 60 Step 30
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.白, .X, .Y, 1 + j * 0.8, i))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W3H(e As Enemy)
        With e
            If .Ticks > 16 AndAlso Rnd() > 0.99 Then
                For i = -40 To 40 Step 20
                    STG.Add(New Bullet(BulletType.环弹, BulletColor.白, .X, .Y, 2, i))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W4H(e As Enemy)
        With e
            If .Ticks = 160 Then

                For j = 0 To 8
                    STG.Add(New Bullet(BulletType.点弹, BulletColor.白, .X, .Y, 1 + j * 0.2))
                Next

            End If
        End With
    End Sub
    <Extension>
    Public Sub S3B3IH(e As Enemy.Boss)
        With e
            .NormalTextures.Add(Textures.boss(3, 0))

            .SpellCards.Add(New B3S0H(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(3, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S3B3AH(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("???", 1)
                .NextSpell()
            End If

        End With
    End Sub
    <Extension>
    Public Sub S3B4IH(e As Enemy.Boss)
        With e
            .NormalTextures.Add(Textures.boss(4, 0))
            For i = 4 To 8
                .MoveTextures.Add(Textures.boss(4, i))
            Next
            .SpellCards.Add(New B4S0H(e))
            .SpellCards.Add(New B4S1H(e))
            .SpellCards.Add(New B4S2H(e))
            .Layer3.Height = 64
            .Layer3.Width = 48
            .Layer3_scale.CenterX = 24
            Canvas.SetLeft(.Layer3, 40)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(4, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S3B4AH(e As Enemy.Boss)
        With e
            Static started As Boolean = False
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0301a.ReadLine()
                    s = Texts.dialog0301a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0301a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0301b.ReadLine()
                    s = Texts.dialog0301b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0301b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                started = True
                .IsEnabled = True
                STG.NameArea.Initialize("Alice", 3)
                .NextSpell()
                ResourcePack.Sounds.StopSound(ResourcePack.Sounds.CurrentMusic)
                ResourcePack.Sounds.PlayMusic(Sounds.mu07)
                Stage.Showmusic("the Grimoire of Alice")
                ResourcePack.Sounds.CurrentMusic = Sounds.mu07
            End If
        End With
    End Sub
    <Extension>
    Public Sub B4S0B1H(e As Bullet)
        With e
            If .Ticks = 60 Then
                .Speed = 0
            ElseIf .Ticks = 90 Then
                .Speed = 2
                .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
            End If
        End With
    End Sub
    <Extension>
    Public Sub B4S1B1H(e As Bullet)
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
    Public Sub B4S1B2H(e As Bullet)
        With e
            If .X < 8 Then
                .Direction = 360 - .Direction
            ElseIf .X > 376 Then
                .Direction = 360 - .Direction
            ElseIf .Y < 8 Then
                .Direction = 180 - .Direction
            End If
        End With
    End Sub
End Module
#End Region

#Region "Lunatic"
Public Class B3S0L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 5000
        UsualTime = 2400
        HaveUsual = True
        Items = "000000000011111111113"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks Mod 300 = 240 Then
            Owner.MoveTo(STG.Player.X, Owner.Y, 60)
        ElseIf Ticks Mod 300 = 60 Then
            ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
        End If
        If Ticks Mod 900 = 120 Then
            For i = 0 To 4
                For j = 160 To 220 Step 20
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.8, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 140 Then
            For i = 0 To 4
                For j = 168 To 192 Step 8
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25 + i * 0.8, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 160 Then
            For i = 0 To 4
                For j = 135 To 225 Step 15
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.8, j, 0))
                Next
            Next
        ElseIf Ticks Mod 900 = 420 Then
            For i = 0 To 4
                STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.8))
            Next
        ElseIf Ticks Mod 900 = 440 Then
            For i = 0 To 4
                For j = -4 To 4 Step 8
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 1.25 + i * 0.8, j))
                Next
            Next
        ElseIf Ticks Mod 900 = 460 Then
            For i = 0 To 4
                For j = -12 To 12 Step 12
                    STG.Add(New Bullet(BulletType.小玉, BulletColor.蓝, Owner.X, Owner.Y, 1 + i * 0.8, j))
                Next
            Next
        ElseIf Ticks Mod 900 = 720 Then
            For j = 105 To 255 Step 10
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2.5, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2.5, j - 1, 0))
            Next
        ElseIf Ticks Mod 900 = 740 Then
            For j = 100 To 260 Step 10
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2.5, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2.5, j - 1, 0))
            Next
        ElseIf Ticks Mod 900 = 760 Then
            For j = 105 To 255 Step 10
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2.5, j + 1, 0))
                STG.Add(New Bullet(BulletType.米弹, BulletColor.蓝, Owner.X, Owner.Y, 2.5, j - 1, 0))
            Next
        End If
    End Sub
End Class
Public Class B4S0L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "一符"
    End Sub
    Private px, py, pd As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 24 Then
                Owner.DefaultMove(30)
            ElseIf Ticks Mod 300 = 60 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
            End If
            For i = 90 To 150 Step 2
                If Ticks Mod 600 = i Then
                    For j = 0 To 4
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.红, Owner.X, Owner.Y, 1 + Rnd() * 3, 100 + Rnd() * 160, 0))
                    Next
                End If
            Next
            For i = 90 To 150 Step 5
                If Ticks Mod 600 = i + 300 Then
                    For j = 0 To 330 Step 30
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.红, Owner.X, Owner.Y, 2.5, j + i * 2, 0) With {.Act = AddressOf .B4S0B1L})
                        STG.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X, Owner.Y, 2.5, j + i * 2 + 15, 0))
                    Next
                End If
            Next
        Else
            If Ticks = 0 Then
                Stage3.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks > 60 Then
                If Ticks Mod 8 = 0 Then
                    For i = 0 To 4
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.红, Owner.X, Owner.Y, 4, 40 + i * 4 + 30 * Sin(Ticks / 30)))
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.红, Owner.X, Owner.Y, 4, -40 - i * 4 - 30 * Sin(Ticks / 30)))
                    Next

                End If
                If Ticks Mod 4 = 0 AndAlso Ticks Mod 30 <= 20 Then
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.红, px, py, 4, pd, 0) With {.SoundEffect = ResourcePack.Sounds.kira00})
                End If
                If Ticks Mod 60 = 30 Then
                    Owner.DefaultMove(50)
                End If
                If Ticks Mod 30 = 0 Then
                    px = Rnd() * 48 - 24 + Owner.X
                    py = Rnd() * 48 - 24 + Owner.Y
                    pd = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - Owner.X, STG.Player.Y - Owner.Y))
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B4S1L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3600
        UsualTime = 2400
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = "二符"
    End Sub
    Private px, py As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If Ticks Mod 300 = 24 Then
                Owner.DefaultMove(30)
            ElseIf Ticks Mod 300 = 60 Then
                ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.ch02)
            End If
            For i = 90 To 150 Step 2
                If Ticks Mod 600 = i Then
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.环弹, BulletColor.蓝, Owner.X, Owner.Y, 0, Rnd() * 4 - 2, 0) With {.Act = AddressOf .B4S1B1L})
                    Next
                    px = Rnd() * 64 - 32 + Owner.X
                    py = Rnd() * 64 - 32 + Owner.Y
                    If i Mod 10 = 0 Then
                        For j = 0 To 4
                            STG.Add(New Bullet(BulletType.点弹, BulletColor.蓝, px, py, 1 + j * 0.5))
                        Next
                    End If
                End If
            Next
            For i = 90 To 150 Step 7
                If Ticks Mod 600 = i + 300 Then
                    For j = 0 To 330 Step 30
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, Owner.X, Owner.Y, 2.8, j + i * 2 + 15, 0))
                    Next
                End If
            Next
        Else
            If Ticks = 0 Then
                Stage3.BG.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If Ticks > 60 Then
                If Ticks Mod 12 = 0 Then
                    For i = 0 To 7
                        STG.Add(New Bullet(BulletType.棱弹, BulletColor.蓝, Owner.X, Owner.Y, 1.8, i * 45 + Ticks \ 2, 0) With {.Act = AddressOf .B4S1B2L})

                    Next
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Owner.MoveToCenter(30)
        Return MyBase.Break()
    End Function
End Class
Public Class B4S2L
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 3000
        SpellTime = 2400
        Score = 4000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = "终符"
    End Sub
    Private px, py As Double
    Public Overrides Sub Render()
        MyBase.Render()
        If Ticks = 0 Then
            Stage3.BG.cardback.Visibility = Visibility.Visible
            Owner.IsEnabled = True
        End If
        If Ticks Mod 60 = 50 Then
            Owner.DefaultMove(60)
        End If
        If Ticks > 30 Then
            If Ticks Mod 3 = 0 Then
                For i = 0 To 24 Step 6
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.黄, Owner.X, Owner.Y, 3.2, Ticks * 16 + i, 0))
                    STG.Add(New Bullet(BulletType.鳞弹, BulletColor.黄, Owner.X, Owner.Y, 3.2, Ticks * 16 + i + 180, 0))
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage3.BG.cardback.Visibility = Visibility.Hidden

        End If
        Dim s() As String
        If STG.Player.PlayerType = PlayerType.灵梦 Then
            Texts.dialog0302a.ReadLine()
            s = Texts.dialog0302a.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0302a)
            STG.DialogArea.Show()
        Else
            Texts.dialog0302b.ReadLine()
            s = Texts.dialog0302b.ReadLine().Split(",")
            STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
            STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
            STG.DialogArea.LoadDialog(Texts.dialog0302b)
            STG.DialogArea.Show()
        End If
        Stage3.Finished = True
        Return MyBase.Break()
    End Function
End Class


Module St3EnmL
    <Extension>
    Public Sub S3W1L(e As Enemy)
        With e
            If .Ticks > 1 AndAlso .Ticks < 360 Then
                If .Tag = 1 Then
                    .Direction -= 1
                Else
                    .Direction += 1
                End If

            End If
            If .Ticks = 100 Then
                STG.Add(New Bullet(BulletType.环弹, BulletColor.红, .X, .Y, 2))
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W2L(e As Enemy)
        With e
            If .Ticks = 160 Then
                For i = -60 To 60 Step 20
                    For j = 0 To 2
                        STG.Add(New Bullet(BulletType.点弹, BulletColor.白, .X, .Y, 1 + j, i))
                    Next
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W3L(e As Enemy)
        With e
            If .Ticks > 16 AndAlso Rnd() > 0.99 Then
                For i = -45 To 45 Step 15
                    STG.Add(New Bullet(BulletType.环弹, BulletColor.白, .X, .Y, 2.5, i))
                Next
            End If
        End With
    End Sub
    <Extension>
    Public Sub S3W4L(e As Enemy)
        With e
            If .Ticks = 160 Then

                For j = 0 To 9
                    STG.Add(New Bullet(BulletType.点弹, BulletColor.白, .X, .Y, 1 + j * 0.25))
                Next

            End If
        End With
    End Sub
    <Extension>
    Public Sub S3B3IL(e As Enemy.Boss)
        With e
            .NormalTextures.Add(Textures.boss(3, 0))

            .SpellCards.Add(New B3S0L(e))
            .Layer3.Height = 64
            .Layer3.Width = 64
            Canvas.SetLeft(.Layer3, 32)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(3, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S3B3AL(e As Enemy.Boss)
        With e
            If .Ticks = 0 Then
                .MoveToCenter(60)
            End If
            If .Ticks = 65 Then
                .IsEnabled = True
                STG.NameArea.Initialize("???", 1)
                .NextSpell()
            End If

        End With
    End Sub
    <Extension>
    Public Sub S3B4IL(e As Enemy.Boss)
        With e
            .NormalTextures.Add(Textures.boss(4, 0))
            For i = 4 To 8
                .MoveTextures.Add(Textures.boss(4, i))
            Next
            .SpellCards.Add(New B4S0L(e))
            .SpellCards.Add(New B4S1L(e))
            .SpellCards.Add(New B4S2L(e))
            .Layer3.Height = 64
            .Layer3.Width = 48
            .Layer3_scale.CenterX = 24
            Canvas.SetLeft(.Layer3, 40)
            Canvas.SetTop(.Layer3, 32)
            .Layer3.Fill = Textures.boss(4, 0)
            STG.ClearBullet()
        End With
    End Sub
    <Extension>
    Public Sub S3B4AL(e As Enemy.Boss)
        With e
            Static started As Boolean = False
            If .Ticks = 0 Then
                started = False
                Dim s() As String
                .MoveToCenter(60)
                If STG.Player.PlayerType = PlayerType.灵梦 Then
                    Texts.dialog0301a.ReadLine()
                    s = Texts.dialog0301a.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0301a)
                    STG.DialogArea.Show()
                Else
                    Texts.dialog0301b.ReadLine()
                    s = Texts.dialog0301b.ReadLine().Split(",")
                    STG.DialogArea.LoadPlayer(Textures.illustrations(s(0)))
                    STG.DialogArea.LoadEnemy(Textures.illustrations(s(1)))
                    STG.DialogArea.LoadDialog(Texts.dialog0301b)
                    STG.DialogArea.Show()
                End If
            End If
            If STG.DialogArea.Finished AndAlso Not started Then
                started = True
                .IsEnabled = True
                STG.NameArea.Initialize("Alice", 3)
                .NextSpell()
                ResourcePack.Sounds.StopSound(ResourcePack.Sounds.CurrentMusic)
                ResourcePack.Sounds.PlayMusic(Sounds.mu07)
                Stage.Showmusic("the Grimoire of Alice")
                ResourcePack.Sounds.CurrentMusic = Sounds.mu07
            End If
        End With
    End Sub
    <Extension>
    Public Sub B4S0B1L(e As Bullet)
        With e
            If .Ticks = 60 Then
                .Speed = 0
            ElseIf .Ticks = 90 Then
                .Speed = 2
                .Direction = Vector.AngleBetween(New Vector(0, -1), New Vector(STG.Player.X - .X, STG.Player.Y - .Y))
            End If
        End With
    End Sub
    <Extension>
    Public Sub B4S1B1L(e As Bullet)
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
    Public Sub B4S1B2L(e As Bullet)
        With e
            If .X < 8 Then
                .Direction = 360 - .Direction
            ElseIf .X > 376 Then
                .Direction = 360 - .Direction
            ElseIf .Y < 8 Then
                .Direction = 180 - .Direction
            End If
        End With
    End Sub
End Module
#End Region