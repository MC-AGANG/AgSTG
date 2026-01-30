Imports System.Math
Imports System.Runtime.CompilerServices
Imports AgSTG
Imports ResourcePack.TH17
Public Class Stage6bg
    Private DownBlock(15) As Media3D.MeshGeometry3D
    Public Shared cardback As Rectangle
    Public Particles3D(31) As Particle3D
    Public Shared Ticks As Long = 0
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
        For i = 0 To 31
            Particles3D(i) = New Particle3D(Rnd() * 6 - 3, -2 + Rnd() * 8, Rnd() * 8 - 4, 0.16, 0.16, New Media3D.Vector3D(0.008 * Rnd() - 0.004, 0.01 + Rnd() * 0.01, 0.012 * Rnd() - 0.006), Particle3DLayer, Brushes.White) With {
                .Angular = Rnd() * 4,
                .Act = New Action(AddressOf .P61)
            }
            Particles3D(i).Rotation.Axis = New Media3D.Vector3D(Rnd(), Rnd(), Rnd())
        Next
    End Sub
    Public Sub Render()
        If Ticks = 0 Then
            Sounds.mu12.Position = New TimeSpan(0)
            Sounds.mu12.Play()
        End If
        RenderBackground()
        RenderParticle()
        Ticks += 1
    End Sub
    Public Sub RenderParticle()
        If Ticks > 2 Then
            For i = 0 To 31
                Particles3D(i).Render()
            Next
            If Stage6.BossStage = 2 AndAlso camera_particle.FieldOfView = 60 Then
                For i = 0 To 31
                    Particles3D(i).Speed = New Media3D.Vector3D(Particles3D(i).Speed.X, Particles3D(i).Speed.Y + 0.15, Particles3D(i).Speed.Z)
                Next
                camera_particle.FieldOfView = 90
            ElseIf Stage6.BossStage = 3 AndAlso camera_particle.FieldOfView = 90 Then
                For i = 0 To 31
                    Particles3D(i).Speed = New Media3D.Vector3D(Particles3D(i).Speed.X, Particles3D(i).Speed.Y - 0.15, Particles3D(i).Speed.Z)
                Next
                camera_particle.FieldOfView = 60
                Light_particle.Color = Color.FromRgb(255, 160, 160)
            End If
        End If

    End Sub

    Private Sub RenderBackground()
        If Ticks = 0 Then
            camera.Position = New Media3D.Point3D(-2, 6, 0)
            camera.LookDirection = New Media3D.Vector3D(4, -2, 0)
            Textures.st06d.Opacity = 0
        End If
        If Ticks > 0 Then
            If Stage6.BossStage = 0 Then
                If Ticks <= 480 Then
                    camera.Position = New Media3D.Point3D(-2, 6 - Ticks / 120, 0)
                    camera.LookDirection = New Media3D.Vector3D(4, -2 + Ticks / 480, 0)
                ElseIf Ticks <= 1440 Then
                    If Ticks >= 960 AndAlso Ticks <= 1080 Then
                        Textures.st06d.Opacity = (Ticks - 960) / 120
                    End If
                    camera.Position = New Media3D.Point3D(((Ticks / 30) Mod 16) - 2, 2, 0)
                ElseIf Ticks <= 3600 Then
                    camera.Position = New Media3D.Point3D(((Ticks / 30) Mod 16) - 2, 2 + Abs(0.25 * Sin(Ticks / 720 * PI)), 0.5 * Sin(Ticks / 720 * PI))
                    camera_rotate.Angle = Sin(Ticks / 720 * PI) * 10
                ElseIf Ticks <= 5760 Then
                    camera.Position = New Media3D.Point3D(((Ticks / 15) Mod 16) - 2, 2 + Abs(0.5 * Sin(Ticks / 720 * PI)), Sin(Ticks / 720 * PI))
                    camera_rotate.Angle = Sin(Ticks / 720 * PI) * 20
                End If
                Light.Color = Color.FromRgb(128, Int(96 + 90 * Sin(Ticks / 45)), Int(160 + 90 * Sin(Ticks / 45)))
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
            ElseIf Stage6.BossStage = 1 Then
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
                If Ticks <= 100060 Then
                    camera.Position = New Media3D.Point3D(camera.Position.X - 0.08, 2, 0)
                    If camera.Position.X < 8 Then
                        camera.Position = New Media3D.Point3D(camera.Position.X + 8, 2, 0)
                    End If
                    FR.Opacity = (Ticks - 100000) / 60
                ElseIf Ticks < 100120 Then
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
            ElseIf Stage6.BossStage = 2 Then
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

                If Ticks > 200060 AndAlso Ticks <= 200420 Then
                    camera.Position = New Media3D.Point3D(camera.Position.X, camera.Position.Y + 0.05, 0)
                    camera.LookDirection = New Media3D.Vector3D(4, camera.LookDirection.Y - 0.05, 0)
                End If
                camera.Position = New Media3D.Point3D(camera.Position.X - 0.3, camera.Position.Y, 0)
                If camera.Position.X < 8 Then
                    camera.Position = New Media3D.Point3D(camera.Position.X + 8, camera.Position.Y, 0)
                End If
            ElseIf Stage6.BossStage = 3 Then
                If Ticks < 300120 Then
                    If Ticks = 300030 Then
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
                    If Ticks > 300060 Then
                        FW.Opacity = (Ticks - 300060) / 60
                    End If
                ElseIf Ticks = 300120 Then
                    FW.Opacity = 1
                    camera.Position = New Media3D.Point3D(-15, 0.5, 0)
                    camera.LookDirection = New Media3D.Vector3D(-4, -1, 0)
                    ResourcePack.Sounds.PlaySound(ResourcePack.Sounds.release)
                    FR.Opacity = 0
                    FB.Opacity = 0
                    BB.Fill = Textures.st06f
                    Light.Color = Color.FromRgb(255, 255, 255)
                ElseIf Ticks <= 300180 Then
                    FW.Opacity = (60 - (Ticks - 300120)) / 60
                    camera.Position = New Media3D.Point3D(camera.Position.X + 0.2, camera.Position.Y + 0.058, 0)
                ElseIf Ticks >= 300360 Then
                    camera_rotate.Angle = 8 * Sin((Ticks - 300360) / 1000 * PI)
                End If
            End If
        End If

    End Sub
End Class
Module Stage6BGA
    <Extension>
    Public Sub P61(e As Particle3D)
        With e
            If .Y >= 8 Then
                .X = Rnd() * 6 - 3
                .Y = -2
                .Z = Rnd() * 8 - 4
            End If
        End With
    End Sub
End Module