Imports ResourcePack.TH17
Imports AgSTG
Imports System.Math
Imports System.Runtime.CompilerServices
Public Class Stage6
    Public Shared FrameCount As Long = -5
    Private DownBlock(15) As Media3D.MeshGeometry3D
    Public Shared BossStage As Integer = 0
    Public Shared cardback As Rectangle
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        t1.Brush = Textures.st06a
        t2.Brush = Textures.st06a
        t3.Brush = Textures.st06a
        t4.Brush = Textures.st06a
        t5.Brush = Textures.st06a
        t6.Brush = Textures.st06a
        t7.Brush = Textures.st06a
        t8.Brush = Textures.st06a
        t9.Brush = Textures.st06a
        t10.Brush = Textures.st06a
        t11.Brush = Textures.st06a
        t12.Brush = Textures.st06a
        t13.Brush = Textures.st06a
        t14.Brush = Textures.st06a
        t15.Brush = Textures.st06a
        t16.Brush = Textures.st06a
        t21.Brush = Textures.st06d
        t22.Brush = Textures.st06d
        t23.Brush = Textures.st06d
        t24.Brush = Textures.st06d
        t25.Brush = Textures.st06d
        t26.Brush = Textures.st06d
        t27.Brush = Textures.st06d
        t28.Brush = Textures.st06d
        t29.Brush = Textures.st06d
        t30.Brush = Textures.st06d
        t31.Brush = Textures.st06d
        t32.Brush = Textures.st06d
        t33.Brush = Textures.st06d
        t34.Brush = Textures.st06d
        t35.Brush = Textures.st06d
        t36.Brush = Textures.st06d
        t40.Brush = Textures.st05c00
        t41.Brush = Textures.st05b
        t42.Brush = Textures.st05b
        t43.Brush = Textures.st05b
        t44.Brush = Textures.st05b
        t45.Brush = Textures.st05b
        t46.Brush = Textures.st05b
        t47.Brush = Textures.st05b
        DownBlock(0) = d0
        DownBlock(1) = d1
        DownBlock(2) = d2
        DownBlock(3) = d3
        DownBlock(4) = d4
        DownBlock(5) = d5
        DownBlock(6) = d6
        DownBlock(7) = d7
        DownBlock(8) = d8
        DownBlock(9) = d9
        DownBlock(10) = d10
        DownBlock(11) = d11
        DownBlock(12) = d12
        DownBlock(13) = d13
        DownBlock(14) = d14
        DownBlock(15) = d15
        Height = 448
        Width = 384
        CB.Fill = Textures.cdbg06b
        cardback = CB
    End Sub
    Public Sub Render()
        FrameCount += 1
        If FrameCount = 0 Then
            STG.BackLayer.Children.Add(Me)
            Sounds.mu12.Position = New TimeSpan(0)
            Sounds.mu12.Play()
        End If
        EnemySpawn()
        RenderBackground()
    End Sub
    Private Sub EnemySpawn()
        Select Case FrameCount
            Case 240
                For i = 0 To 7
                    STG.Objects.Add(New Enemy(EnemyType.阴阳玉, 0, 192, 192, 50, "0000", 400, 0.5, i * 45) With {.Act = New Action(AddressOf .S6W1)})
                Next
                Exit Select
            Case 480
                For i = 0 To 7
                    STG.Objects.Add(New Enemy(EnemyType.阴阳玉, 0, 128, 192, 50, "0000", 400, 0.5, i * 45) With {.Act = New Action(AddressOf .S6W1)})
                    STG.Objects.Add(New Enemy(EnemyType.阴阳玉, 0, 256, 192, 50, "0000", 400, 0.5, i * 45) With {.Act = New Action(AddressOf .S6W1)})
                Next
                Exit Select
            Case 1440
                For i = 0 To 7
                    STG.Objects.Add(New Enemy(EnemyType.阴阳玉, 1, 128, 192, 50, "0011", 400, 0.5, i * 45) With {.Act = New Action(AddressOf .S6W1)})
                    STG.Objects.Add(New Enemy(EnemyType.阴阳玉, 1, 256, 192, 50, "0011", 400, 0.5, i * 45) With {.Act = New Action(AddressOf .S6W1)})
                Next
                Exit Select
            Case 1800
                For i = 0 To 7
                    STG.Objects.Add(New Enemy(EnemyType.阴阳玉, 1, 192, 128, 50, "0011", 400, 0.5, i * 45) With {.Act = New Action(AddressOf .S6W1)})
                    STG.Objects.Add(New Enemy(EnemyType.阴阳玉, 1, 192, 256, 50, "0011", 400, 0.5, i * 45) With {.Act = New Action(AddressOf .S6W1)})
                Next
                Exit Select
            Case 2200
                STG.Objects.Add(New Enemy.Boss(0, 192, -50) With {.Init = New Action(AddressOf .S6B0I), .Act = New Action(AddressOf .S6B0A)})
            Case 3600 To 4500
                If FrameCount Mod 30 = 0 Then
                    Dim temp As Integer = Int(Rnd() * 3)
                    If temp = 0 Then
                        STG.Objects.Add(New Enemy(EnemyType.幽灵, 0, Rnd() * 320 + 32, -16, 40, "01", 400, 0.5, 180 + Rnd() * 40 - 20) With {.Act = New Action(AddressOf .S6W2)})
                    ElseIf temp = 1 Then
                        STG.Objects.Add(New Enemy(EnemyType.幽灵, 0, -16, Rnd() * 400 + 24, 40, "01", 400, 0.5, 90 + Rnd() * 40 - 20) With {.Act = New Action(AddressOf .S6W2)})
                    Else
                        STG.Objects.Add(New Enemy(EnemyType.幽灵, 0, 400, Rnd() * 400 + 24, 40, "01", 400, 0.5, 270 + Rnd() * 40 - 20) With {.Act = New Action(AddressOf .S6W2)})
                    End If
                End If
                Exit Select
            Case 4501 To 5400
                If FrameCount Mod 15 = 0 Then
                    Dim temp As Integer = Int(Rnd() * 3)
                    If temp = 0 Then
                        STG.Objects.Add(New Enemy(EnemyType.幽灵, 0, Rnd() * 320 + 32, -16, 40, "01", 400, 0.5, 180 + Rnd() * 40 - 20) With {.Act = New Action(AddressOf .S6W2)})
                    ElseIf temp = 1 Then
                        STG.Objects.Add(New Enemy(EnemyType.幽灵, 0, -16, Rnd() * 400 + 24, 40, "01", 400, 0.5, 90 + Rnd() * 40 - 20) With {.Act = New Action(AddressOf .S6W2)})
                    Else
                        STG.Objects.Add(New Enemy(EnemyType.幽灵, 0, 400, Rnd() * 400 + 24, 40, "01", 400, 0.5, 270 + Rnd() * 40 - 20) With {.Act = New Action(AddressOf .S6W2)})
                    End If
                End If
                Exit Select
            Case 6000
                STG.Objects.Add(New Enemy.Boss(1, 192, -50) With {.Init = New Action(AddressOf .S6B1I), .Act = New Action(AddressOf .S6B1A)})
                Exit Select
        End Select
    End Sub
    Private Sub RenderBackground()
        If FrameCount = 0 Then
            camera.Position = New Media3D.Point3D(-2, 6, 0)
            camera.LookDirection = New Media3D.Vector3D(4, -2, 0)
            Textures.st06d.Opacity = 0
        End If
        If FrameCount > 0 Then
            If BossStage = 0 Then
                If FrameCount <= 480 Then
                    camera.Position = New Media3D.Point3D(-2, 6 - FrameCount / 120, 0)
                    camera.LookDirection = New Media3D.Vector3D(4, -2 + FrameCount / 480, 0)
                ElseIf FrameCount <= 1440 Then
                    If FrameCount >= 960 AndAlso FrameCount <= 1080 Then
                        Textures.st06d.Opacity = (FrameCount - 960) / 120
                    End If
                    camera.Position = New Media3D.Point3D(((FrameCount / 30) Mod 16) - 2, 2, 0)
                ElseIf FrameCount <= 3600 Then
                    camera.Position = New Media3D.Point3D(((FrameCount / 30) Mod 16) - 2, 2 + Abs(0.25 * Sin(FrameCount / 720 * PI)), 0.5 * Sin(FrameCount / 720 * PI))
                    camera_rotate.Angle = Sin(FrameCount / 720 * PI) * 10
                ElseIf FrameCount <= 5760 Then
                    camera.Position = New Media3D.Point3D(((FrameCount / 15) Mod 16) - 2, 2 + Abs(0.5 * Sin(FrameCount / 720 * PI)), Sin(FrameCount / 720 * PI))
                    camera_rotate.Angle = Sin(FrameCount / 720 * PI) * 20
                End If
                Light.Color = Color.FromRgb(128, Int(96 + 90 * Sin(FrameCount / 45)), Int(160 + 90 * Sin(FrameCount / 45)))
                Dim endx As Boolean
                For i = 0 To 15
                    endx = False
                    For j = 0 To 5
                        If DownBlock(i).Positions.Item(j).X < -4 Then
                            endx = True
                        End If
                        If endx Then
                            DownBlock(i).Positions.Item(j) = New Media3D.Point3D(DownBlock(i).Positions.Item(j).X + 63.8, DownBlock(i).Positions.Item(j).Y, DownBlock(i).Positions.Item(j).Z)
                        Else
                            DownBlock(i).Positions.Item(j) = New Media3D.Point3D(DownBlock(i).Positions.Item(j).X - 0.2, DownBlock(i).Positions.Item(j).Y, DownBlock(i).Positions.Item(j).Z)
                        End If
                    Next
                Next
            ElseIf BossStage = 1 Then
                Dim endx As Boolean
                For i = 0 To 15
                    endx = False
                    For j = 0 To 5
                        If DownBlock(i).Positions.Item(j).X < -4 Then
                            endx = True
                        End If
                        If endx Then
                            DownBlock(i).Positions.Item(j) = New Media3D.Point3D(DownBlock(i).Positions.Item(j).X + 63.8, DownBlock(i).Positions.Item(j).Y, DownBlock(i).Positions.Item(j).Z)
                        Else
                            DownBlock(i).Positions.Item(j) = New Media3D.Point3D(DownBlock(i).Positions.Item(j).X - 0.2, DownBlock(i).Positions.Item(j).Y, DownBlock(i).Positions.Item(j).Z)
                        End If
                    Next
                Next
                If FrameCount <= 100060 Then
                    camera.Position = New Media3D.Point3D(camera.Position.X - 0.08, 2, 0)
                    If camera.Position.X < 8 Then
                        camera.Position = New Media3D.Point3D(camera.Position.X + 8, 2, 0)
                    End If
                    FR.Opacity = (FrameCount - 100000) / 60
                ElseIf FrameCount < 100120 Then
                    camera.Position = New Media3D.Point3D(camera.Position.X - 0.15, 2, 0)
                    If camera.Position.X < 8 Then
                        camera.Position = New Media3D.Point3D(camera.Position.X + 8, 2, 0)
                    End If
                Else
                    camera.Position = New Media3D.Point3D(camera.Position.X - 0.3, 2, 0)
                    If camera.Position.X < 8 Then
                        camera.Position = New Media3D.Point3D(camera.Position.X + 8, 2, 0)
                    End If
                End If
            ElseIf BossStage = 2 Then
                Dim endx As Boolean
                For i = 0 To 15
                    endx = False
                    For j = 0 To 5
                        If DownBlock(i).Positions.Item(j).X < -4 Then
                            endx = True
                        End If
                        If endx Then
                            DownBlock(i).Positions.Item(j) = New Media3D.Point3D(DownBlock(i).Positions.Item(j).X + 63.8, DownBlock(i).Positions.Item(j).Y, DownBlock(i).Positions.Item(j).Z)
                        Else
                            DownBlock(i).Positions.Item(j) = New Media3D.Point3D(DownBlock(i).Positions.Item(j).X - 0.2, DownBlock(i).Positions.Item(j).Y, DownBlock(i).Positions.Item(j).Z)
                        End If
                    Next
                Next

                If FrameCount > 200060 AndAlso FrameCount <= 200420 Then
                    camera.Position = New Media3D.Point3D(camera.Position.X, camera.Position.Y + 0.05, 0)
                    camera.LookDirection = New Media3D.Vector3D(4, camera.LookDirection.Y - 0.05, 0)
                End If
                camera.Position = New Media3D.Point3D(camera.Position.X - 0.3, camera.Position.Y, 0)
                If camera.Position.X < 8 Then
                    camera.Position = New Media3D.Point3D(camera.Position.X + 8, camera.Position.Y, 0)
                End If
            ElseIf BossStage = 3 Then
                If FrameCount < 300120 Then
                    If FrameCount = 300030 Then
                        ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.big)
                    End If
                    Dim endx As Boolean
                    For i = 0 To 15
                        endx = False
                        For j = 0 To 5
                            If DownBlock(i).Positions.Item(j).X < -4 Then
                                endx = True
                            End If
                            If endx Then
                                DownBlock(i).Positions.Item(j) = New Media3D.Point3D(DownBlock(i).Positions.Item(j).X + 63.8, DownBlock(i).Positions.Item(j).Y, DownBlock(i).Positions.Item(j).Z)
                            Else
                                DownBlock(i).Positions.Item(j) = New Media3D.Point3D(DownBlock(i).Positions.Item(j).X - 0.2, DownBlock(i).Positions.Item(j).Y, DownBlock(i).Positions.Item(j).Z)
                            End If
                        Next
                    Next
                    camera.Position = New Media3D.Point3D(camera.Position.X - 0.3, camera.Position.Y + 0.2, 0)
                    If camera.Position.X < 8 Then
                        camera.Position = New Media3D.Point3D(camera.Position.X + 8, camera.Position.Y, 0)
                    End If
                    If FrameCount > 300060 Then
                        FW.Opacity = (FrameCount - 300060) / 60
                    End If
                ElseIf FrameCount = 300120 Then
                    FW.Opacity = 1
                    camera.Position = New Media3D.Point3D(-15, 0.5, 0)
                    camera.LookDirection = New Media3D.Vector3D(-4, -1, 0)
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.release)
                    FR.Opacity = 0
                    FB.Opacity = 0
                    BB.Fill = Textures.st06f
                    Light.Color = Color.FromRgb(255, 255, 255)
                ElseIf FrameCount <= 300180 Then
                    FW.Opacity = (60 - (FrameCount - 300120)) / 60
                    camera.Position = New Media3D.Point3D(camera.Position.X + 0.2, camera.Position.Y + 0.058, 0)
                ElseIf FrameCount >= 300360 Then
                    camera_rotate.Angle = 8 * Sin((FrameCount - 300360) / 1000 * PI)
                End If
            End If
        End If

    End Sub
End Class
Public Class B0S0
    Inherits SpellCard
    Private corner As Integer
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.None
        UsualHP = 3000
        UsualTime = 1200
        HaveUsual = True
        Items = "000000000011111111114"
        Score = 10
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If FrameCount > 10 Then
            corner += 1
            If FrameCount Mod 10 = 0 Then
                For i = 0 To 4
                    STG.Objects_Add.Add(New Bullet(BulletType.箭头, 6, Owner.X + Sin((corner - i * 5) / 180 * PI) * i * 48, Owner.Y + Cos((corner - i * 5) / 180 * PI) * i * 48, 2, -corner + 90 - 15, 0))
                    STG.Objects_Add.Add(New Bullet(BulletType.箭头, 6, Owner.X - Sin((corner + i * 5) / 180 * PI) * i * 32, Owner.Y - Cos((corner + i * 5) / 180 * PI) * i * 32, 2, -corner + 90 + 15, 0))
                Next
            End If
        End If
    End Sub
End Class
Public Class B1S0
    Inherits SpellCard
    Private corner As Integer
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 4000
        UsualTime = 3000
        SpellHP = 4000
        SpellTime = 3000
        Score = 6000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = Textures.st6s(0)
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            If FrameCount > 10 Then
                corner += 1
                If FrameCount Mod 10 = 0 Then
                    Preset0(corner)
                    Preset0(-corner)
                End If
            End If
        Else
            If FrameCount = 0 Then
                Stage6.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If FrameCount > 10 Then
                corner += 1
                If FrameCount Mod 300 < 150 Then
                    If FrameCount Mod 50 = 0 Then
                        Preset1(corner)
                    End If
                ElseIf FrameCount Mod 300 < 240 Then
                    If FrameCount Mod 20 = 0 Then
                        Preset1(corner)
                    End If
                End If

            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        If AtSpell Then
            Stage6.cardback.Visibility = Visibility.Hidden
            Stage6.BossStage = 2
            Stage6.FrameCount = 200000
        End If
        Return MyBase.Break()
    End Function
    Private Sub Preset0(direction As Double)
        STG.Objects_Add.Add(New Bullet(BulletType.中玉, 6, Owner.X, Owner.Y, 2, direction, 0))
        For i = 0 To 9
            If i Mod 2 = 0 Then
                STG.Objects_Add.Add(New Bullet(BulletType.小星弹, BulletColor.深绿, Owner.X + 16 * Sin((i * 36 + direction) / 180 * PI), Owner.Y + 16 * Cos((i * 36 + direction) / 180 * PI), 2, direction, 0))
            Else
                STG.Objects_Add.Add(New Bullet(BulletType.棱弹, BulletColor.深蓝, Owner.X + 16 * Sin((i * 36 + direction) / 180 * PI), Owner.Y + 16 * Cos((i * 36 + direction) / 180 * PI), 2, direction, 0))
            End If
        Next
        STG.Objects_Add.Add(New Bullet(BulletType.星弹, 6, Owner.X + 20 * Sin((direction + 180) / 180 * PI), Owner.Y - 20 * Cos((direction + 180) / 180 * PI), 2, direction, 0))
    End Sub
    Private Sub Preset1(direction As Double)
        Dim c As Double = direction
        For i = 0 To 63
            STG.Objects_Add.Add(New Bullet(BulletType.棱弹, BulletColor.深蓝, Owner.X, Owner.Y, 2 - Max(Abs(Sin((i * 5.625 + 2.8125 + direction) / 180 * PI)), Abs(Cos((i * 5.625 + 2.8125 + direction) / 180 * PI))), i * 5.625 + c, 0))
        Next
    End Sub
End Class
Public Class B1S1
    Inherits SpellCard
    Private corner As Integer
    Private deltacorner As Integer = 16
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 4000
        UsualTime = 3000
        SpellHP = 2000
        SpellTime = 3000
        Score = 6000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = Textures.st6s(1)
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim zerovec As New Vector(0, -1)
            If FrameCount > 60 Then
                If FrameCount Mod 15 = 0 Then
                    If corner > 90 Then
                        deltacorner = -16
                    ElseIf corner < -90 Then
                        deltacorner = 16
                    End If
                    corner += deltacorner
                    Preset0(Vector.AngleBetween(New Vector(Owner.X - STG.Player.X, STG.Player.Y - Owner.Y), zerovec) + corner)
                    Preset0(Vector.AngleBetween(New Vector(Owner.X - STG.Player.X, STG.Player.Y - Owner.Y), zerovec) - corner)
                End If
            End If
        Else
            If FrameCount = 0 Then
                Stage6.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If FrameCount > 60 AndAlso FrameCount <= 260 Then
                For i = 0 To 4
                    If FrameCount Mod 5 = 0 Then
                        STG.Objects_Add.Add(New Bullet(BulletType.小玉, BulletColor.红, Owner.X + 64 * Sin((FrameCount \ 5) * 9 / 180 * PI), Owner.Y + 64 * Cos((FrameCount \ 5) * 9 / 180 * PI), 0) With {.Tag = i * 100 + (FrameCount \ 5) - 13})
                    End If
                Next
            End If
            If FrameCount = 600 Then
                For i = 0 To 4
                    Preset1(i, i * 72)
                Next
            End If
            If FrameCount = 700 Then
                For i = 0 To 4
                    Preset3(i)
                Next
            End If
            If FrameCount = 800 Then
                For i = 0 To 4
                    Preset2(i)
                Next
            End If
            If FrameCount = 900 Then
                For i = 0 To 4
                    Preset3(i)
                Next
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Stage6.cardback.Visibility = Visibility.Hidden
        If AtSpell Then
            Stage6.BossStage = 3
            Stage6.FrameCount = 300000
        End If
        Return MyBase.Break()
    End Function
    Private Sub Preset0(direction As Double)
        STG.Objects_Add.Add(New Bullet(BulletType.中玉, 6, Owner.X, Owner.Y, 2, direction, 0))
        For i = 0 To 9
            If i Mod 2 = 0 Then
                STG.Objects_Add.Add(New Bullet(BulletType.小星弹, BulletColor.深绿, Owner.X + 16 * Sin((i * 36 + direction) / 180 * PI), Owner.Y + 16 * Cos((i * 36 + direction) / 180 * PI), 2, direction, 0))
            Else
                STG.Objects_Add.Add(New Bullet(BulletType.棱弹, BulletColor.深蓝, Owner.X + 16 * Sin((i * 36 + direction) / 180 * PI), Owner.Y + 16 * Cos((i * 36 + direction) / 180 * PI), 2, direction, 0))
            End If
        Next
        STG.Objects_Add.Add(New Bullet(BulletType.星弹, 6, Owner.X + 20 * Sin((direction + 180) / 180 * PI), Owner.Y - 20 * Cos((direction + 180) / 180 * PI), 2, direction, 0))
    End Sub
    Private Sub Preset1(target As Integer, direction As Double)
        For i = 0 To 39
            For Each obj In STG.SearchBullet
                If obj.Tag = target * 100 + i Then
                    obj.Direction = direction
                    obj.Speed = 2
                End If
            Next
        Next
    End Sub
    Private Sub Preset2(target As Integer)
        For i = 0 To 39
            For Each obj In STG.SearchBullet
                If obj.Tag = target * 100 + i Then
                    obj.Direction = 180 + obj.Direction * 2
                    obj.Speed = 2
                End If
            Next
        Next
    End Sub
    Private Sub Preset3(target As Integer)
        For i = 0 To 39
            For Each obj In STG.SearchBullet
                If obj.Tag = target * 100 + i Then
                    obj.Speed = 0
                End If
            Next
        Next
    End Sub
End Class
Public Class B1S2
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3000
        UsualTime = 3000
        SpellHP = 4000
        SpellTime = 3000
        Score = 6000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = Textures.st6s(2)
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim zerovec As New Vector(0, -1)
            If FrameCount > 60 Then
                If FrameCount Mod 15 = 0 Then
                    Preset0()
                End If
            End If
        Else
            If FrameCount = 0 Then
                Stage6.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
            End If
            If FrameCount Mod 400 = 80 Then
                Preset1(FrameCount)
            ElseIf FrameCount Mod 400 = 300 Then
                Owner.DefaultMove(60)
            End If
            Preset2()
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Stage6.cardback.Visibility = Visibility.Hidden
        Return MyBase.Break()
    End Function
    Private Sub Preset0()
        Dim x As Integer = Rnd() * 384
        Dim direction = Rnd() * 30 - 15 + 180
        STG.Objects_Add.Add(New Bullet(BulletType.中玉, 6, x, 0, 3, direction, 0))
        For i = 0 To 9
            If i Mod 2 = 0 Then
                STG.Objects_Add.Add(New Bullet(BulletType.小星弹, BulletColor.深绿, x + 16 * Sin((i * 36 + direction) / 180 * PI), 16 * Cos((i * 36 + direction) / 180 * PI), 3, direction, 0))
            Else
                STG.Objects_Add.Add(New Bullet(BulletType.棱弹, BulletColor.深蓝, x + 16 * Sin((i * 36 + direction) / 180 * PI), 16 * Cos((i * 36 + direction) / 180 * PI), 3, direction, 0))
            End If
        Next
        STG.Objects_Add.Add(New Bullet(BulletType.星弹, 6, x + 20 * Sin((direction + 180) / 180 * PI), -20 * Cos((direction + 180) / 180 * PI), 3, direction, 0))
    End Sub
    Private Sub Preset1(direction As Double)
        For i = 0 To 31
            STG.Objects_Add.Add(New Bullet(BulletType.米弹, BulletColor.黄, Owner.X, Owner.Y, 2 * (2 - Max(Abs(Sin((i * 11.25 + direction) / 180 * PI)), Abs(Cos((i * 11.25 + direction) / 180 * PI)))), i * 11.25, 0))
        Next
    End Sub
    Private Sub Preset2()
        For Each obj In STG.SearchBullet
            If obj.BulletType = BulletType.米弹 Then
                If obj.X < 1 Then
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.黄, obj.X, obj.Y, 90 + (270 - obj.Direction), 16, 640, 240))
                    obj.Break(False)
                ElseIf obj.X > 383 Then
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.黄, obj.X, obj.Y, 270 + (90 - obj.Direction), 16, 640, 240))
                    obj.Break(False)
                ElseIf obj.Y < 1 Then
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.黄, obj.X, obj.Y, 180 + (0 - obj.Direction), 16, 640, 240))
                    obj.Break(False)
                ElseIf obj.Y > 447 Then
                    STG.Objects_Add.Add(New Bullet.Laser(BulletColor.黄, obj.X, obj.Y, 0 + (180 - obj.Direction), 16, 640, 240))
                    obj.Break(False)
                End If
            End If
        Next
    End Sub
End Class
Public Class B1S3
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        UsualHP = 3000
        UsualTime = 3000
        SpellHP = 3000
        SpellTime = 3000
        Score = 6000000
        HaveUsual = True
        Items = "000000000011111111114"
        SpellName = Textures.st6s(3)
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If Not AtSpell Then
            Dim zerovec As New Vector(0, -1)
            If FrameCount > 60 Then
                If FrameCount Mod 60 = 0 Then
                    For i = 0 To 15
                        Preset0(i * 22.5)
                    Next
                    Owner.DefaultMove(30)
                End If
            End If
        Else
            If FrameCount = 0 Then
                Stage6.cardback.Visibility = Visibility.Visible
                Owner.IsEnabled = True
                Owner.MoveToCenter(60)
            End If
            If FrameCount Mod 300 = 60 Then
                For i = 64 To 320 Step 64
                    Dim te As New Enemy(60, 0, Owner.X - 192 + i, Owner.Y, 300, "1100", 300, 0, 180) With {.Act = New Action(AddressOf .S6W3)}
                    te.S6W3I()
                    STG.Objects_Add.Add(te)
                Next
            ElseIf FrameCount Mod 300 = 180 Then
                Owner.DefaultMove(30)
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Stage6.cardback.Visibility = Visibility.Hidden
        For Each obj In STG.SearchEnemy
            obj.Damage(1000)
        Next
        Return MyBase.Break()
    End Function
    Private Sub Preset0(direction As Double)
        STG.Objects_Add.Add(New Bullet(BulletType.中玉, 6, Owner.X, Owner.Y, 2, direction, 0))
        For i = 0 To 9
            If i Mod 2 = 0 Then
                STG.Objects_Add.Add(New Bullet(BulletType.小星弹, BulletColor.深绿, Owner.X + 16 * Sin((i * 36 + direction) / 180 * PI), Owner.Y + 16 * Cos((i * 36 + direction) / 180 * PI), 2, direction, 0))
            Else
                STG.Objects_Add.Add(New Bullet(BulletType.棱弹, BulletColor.深蓝, Owner.X + 16 * Sin((i * 36 + direction) / 180 * PI), Owner.Y + 16 * Cos((i * 36 + direction) / 180 * PI), 2, direction, 0))
            End If
        Next
        STG.Objects_Add.Add(New Bullet(BulletType.星弹, 6, Owner.X + 20 * Sin((direction + 180) / 180 * PI), Owner.Y - 20 * Cos((direction + 180) / 180 * PI), 2, direction, 0))
    End Sub
End Class
Public Class B1S4
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 4000
        SpellTime = 3000
        Score = 6000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = Textures.st6s(4)
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If FrameCount = 0 Then
            Stage6.cardback.Visibility = Visibility.Visible
            Owner.IsEnabled = True
            Owner.MoveToCenter(60)
        End If
        If FrameCount > 60 Then
            For i = 0 To 3
                If FrameCount Mod 30 <= 20 Then
                    If FrameCount Mod 2 = 0 Then
                        STG.Objects_Add.Add(New Bullet(BulletType.棱弹, BulletColor.红, Owner.X + 64 * Sin((FrameCount + 90 * i) / 180 * PI), Owner.Y + 64 * Cos((FrameCount + 90 * i) / 180 * PI), 1, FrameCount - 90 * i, 0))
                    End If
                End If
            Next
            If FrameCount Mod 300 = 0 Then
                Preset1(0)
                Preset1(45)
            End If
        End If
    End Sub
    Private Sub Preset1(direction As Double)
        For i = 0 To 63
            STG.Objects_Add.Add(New Bullet(BulletType.棱弹, BulletColor.深蓝, Owner.X, Owner.Y, 2 - Max(Abs(Sin((i * 5.625 + 2.8125 + direction) / 180 * PI)), Abs(Cos((i * 5.625 + 2.8125 + direction) / 180 * PI))), i * 5.625, 0))
        Next
    End Sub
    Public Overrides Function Break() As Boolean
        Stage6.cardback.Visibility = Visibility.Hidden
        Return MyBase.Break()
    End Function
End Class
Public Class B1S5
    Inherits SpellCard
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 4000
        SpellTime = 3000
        Score = 6000000
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = Textures.st6s(5)
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If FrameCount = 0 Then
            Stage6.cardback.Visibility = Visibility.Visible
            Owner.IsEnabled = True
            Owner.MoveToCenter(60)
        End If
        If FrameCount > 50 Then
            If FrameCount Mod 240 >= 60 Then
                If FrameCount Mod 18 = 0 Then
                    Preset1(9 - ((FrameCount Mod 240) - 60) \ 18)
                End If
            End If
        End If
    End Sub
    Private Sub Preset1(id As Integer)
        Dim direction As Double = id * 10
        Dim c As Double = Rnd() * 10
        For i = 0 To 39
            STG.Objects_Add.Add(New Bullet(BulletType.棱弹, BulletColor.深蓝, Owner.X, Owner.Y, 0.5 * (2 - Max(Abs(Sin((i * 9 + direction) / 180 * PI)), Abs(Cos((i * 9 + direction) / 180 * PI)))), i * 9 + c, 0) With {.Tag = id, .Act = New Action(AddressOf .S6B1B1)})
        Next
    End Sub
    Public Overrides Function Break() As Boolean
        Stage6.cardback.Visibility = Visibility.Hidden
        Return MyBase.Break()
    End Function
End Class
Public Class B1S6
    Inherits SpellCard
    Private cleared(2) As Boolean
    Public Sub New(owner As Enemy.Boss)
        MyBase.New(owner)
        Type = SpellType.Life
        SpellHP = 16000
        SpellTime = 7200
        Score = 10000000
        StageCount = 4
        StagePercent = {0.25, 0.5, 0.75, 1}
        HaveUsual = False
        Items = "000000000011111111114"
        SpellName = Textures.st6s(6)
    End Sub
    Public Overrides Sub Render()
        MyBase.Render()
        If FrameCount = 0 Then
            Stage6.cardback.Visibility = Visibility.Visible
            Owner.IsEnabled = True
            Owner.MoveToCenter(60)
        End If
        If FrameCount > 50 Then
            If FrameCount Mod 6 = 0 Then
                If Owner.HP > 12000 Then
                    Preset0()
                ElseIf Owner.HP > 8000 Then
                    If Not cleared(0) Then
                        STG.ClearBullet()
                        cleared(0) = True
                    End If
                    Preset0()
                    Preset1()
                ElseIf Owner.HP > 4000 Then
                    If Not cleared(1) Then
                        STG.ClearBullet()
                        cleared(1) = True
                    End If
                    Preset0()
                    Preset1()
                    Preset2()
                Else
                    If Not cleared(2) Then
                        STG.ClearBullet()
                        cleared(2) = True
                    End If
                    Preset0()
                    Preset1()
                    Preset2()
                    Preset3()
                End If
            End If
        End If
    End Sub
    Public Overrides Function Break() As Boolean
        Stage6.cardback.Visibility = Visibility.Hidden
        Return MyBase.Break()
    End Function
    Private Sub Preset0()
        For i = 0 To 2
            STG.Objects_Add.Add(New Bullet(BulletType.苦无, BulletColor.红, Owner.X + 64 + 64 * Sin(Owner.FrameCount / 180 * PI), Owner.Y + 0 + 64 * Cos(Owner.FrameCount / 180 * PI), 1.5, i * 120 + Owner.FrameCount * 4, 0))
        Next
    End Sub
    Private Sub Preset1()
        For i = 0 To 2
            STG.Objects_Add.Add(New Bullet(BulletType.苦无, BulletColor.蓝, Owner.X + 0 + 64 * Sin((Owner.FrameCount + 90) / 180 * PI), Owner.Y + 64 + 64 * Cos((Owner.FrameCount + 90) / 180 * PI), 1.5, i * 120 + Owner.FrameCount * 4, 0))
        Next
    End Sub
    Private Sub Preset2()
        For i = 0 To 2
            STG.Objects_Add.Add(New Bullet(BulletType.苦无, BulletColor.黄, Owner.X - 64 + 64 * Sin((Owner.FrameCount + 180) / 180 * PI), Owner.Y + 0 + 64 * Cos((Owner.FrameCount + 180) / 180 * PI), 1.5, i * 120 + Owner.FrameCount * 4, 0))
        Next
    End Sub
    Private Sub Preset3()
        For i = 0 To 2
            STG.Objects_Add.Add(New Bullet(BulletType.苦无, BulletColor.品红, Owner.X + 0 + 64 * Sin((Owner.FrameCount + 270) / 180 * PI), Owner.Y - 64 + 64 * Cos((Owner.FrameCount + 270) / 180 * PI), 1.5, i * 120 + Owner.FrameCount * 4, 0))
        Next
    End Sub
End Class
Module St6Enm
    <Extension>
    Public Sub S6W1(e As Enemy)
        With e
            If .IsEnabled Then
                If .FrameCount = 60 OrElse .FrameCount = 240 Then
                    STG.Objects_Add.Add(New Bullet(BulletType.小玉, BulletColor.深蓝, .X, .Y, 2, 10))
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S6W2(e As Enemy)
        With e
            If .IsEnabled Then
                If .FrameCount = 240 Then
                    STG.Objects_Add.Add(New Bullet(BulletType.中玉, 1, .X, .Y, 2, 15))
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S6W3I(e As Enemy)
        With e
            .SetSize(48, 80, 20)
            .Background = Textures.st6enm(0, 0)
        End With
    End Sub
    <Extension>
    Public Sub S6W3(e As Enemy)
        With e
            If .IsEnabled Then
                .Background = Textures.st6enm(0, (.FrameCount \ 10) Mod 3)
                If .FrameCount Mod 120 > 30 AndAlso .FrameCount Mod 120 <= 60 Then
                    If .FrameCount Mod 3 = 0 Then
                        STG.Objects_Add.Add(New Bullet(BulletType.箭头, 6, .X, .Y, 0.5, 330, 0) With {.Act = New Action(AddressOf .S6W3B1)})
                        STG.Objects_Add.Add(New Bullet(BulletType.箭头, 6, .X, .Y, 0.5, 30, 0) With {.Act = New Action(AddressOf .S6W3B1)})
                    End If
                ElseIf .FrameCount Mod 120 = 90 Then
                    For i = 0 To 9
                        STG.Objects_Add.Add(New Bullet(BulletType.箭头, 3, .X, .Y, 2, 270 + i * 20, 0))
                    Next
                End If
                .Speed += 0.01
            End If
        End With
    End Sub
    <Extension>
    Public Sub S6W3B1(e As Bullet)
        With e
            If .IsEnabled Then
                If .Direction > 180 Then
                    If .Direction > 190 Then
                        .Direction -= 1
                    ElseIf .Speed < 2 Then
                        .Speed += 0.1
                    End If
                Else
                    If .Direction < 170 Then
                        .Direction += 1
                    ElseIf .Speed < 2 Then
                        .Speed += 0.1
                    End If
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S6B1B1(e As Bullet)
        With e
            If .IsEnabled Then
                If .FrameCount = .Tag * 18 + 65 Then
                    .Speed = 1.5
                    .Direction = 180 + .Direction
                ElseIf .FrameCount = .Tag * 18 + 5 Then
                    .Speed = 0
                End If
            End If
        End With
    End Sub
    <Extension>
    Public Sub S6B0I(e As Enemy.Boss)
        With e
            .SpellCards.Add(New B0S0(e))
            .Layer3.Height = 96
            .Layer3.Width = 96
            Canvas.SetLeft(.Layer3, 16)
            Canvas.SetTop(.Layer3, 16)
            .Layer3.Fill = Textures.boss(0, 0)
        End With
    End Sub
    <Extension>
    Public Sub S6B0A(e As Enemy.Boss)
        With e
            .Layer3.Fill = Textures.boss(0, (.FrameCount \ 8) Mod 6)
            If .FrameCount = 0 Then
                .MoveToCenter(60)
            End If
            If .FrameCount = 290 Then
                .IsEnabled = True
                .NextSpell()
            End If
            .Layer3_translate.Y = 4 * Sin(e.FrameCount / 90 * PI)
        End With
    End Sub
    <Extension>
    Public Sub S6B1I(e As Enemy.Boss)
        With e
            .SpellCards.Add(New B1S0(e))
            .SpellCards.Add(New B1S1(e))
            .SpellCards.Add(New B1S2(e))
            .SpellCards.Add(New B1S3(e))
            .SpellCards.Add(New B1S4(e))
            .SpellCards.Add(New B1S5(e))
            .SpellCards.Add(New B1S6(e))
            .Layer3.Height = 112
            .Layer3.Width = 96
            Canvas.SetLeft(.Layer3, 16)
            Canvas.SetTop(.Layer3, 8)
            .Layer3.Fill = Textures.boss(1, 0)
        End With
    End Sub
    <Extension>
    Public Sub S6B1A(e As Enemy.Boss)
        With e
            .Layer3.Fill = Textures.boss(1, (.FrameCount \ 8) Mod 5)
            If .FrameCount = 0 Then
                .MoveToCenter(60)
            End If
            If .FrameCount = 90 Then
                Stage6.BossStage = 1
                Stage6.FrameCount = 100000
                .IsEnabled = True
                .NextSpell()
                Sounds.mu12.Stop()
                Sounds.mu13.Position = New TimeSpan(0)
                Sounds.mu13.Play()
            End If
            .Layer3_translate.Y = 4 * Sin(e.FrameCount / 90 * PI)
        End With
    End Sub
End Module