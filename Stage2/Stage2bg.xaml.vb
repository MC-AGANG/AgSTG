Imports AgSTG
Imports ResourcePack.TH07
Imports System.Runtime.CompilerServices
Public Class Stage2bg
    Public Ticks As Long
    Private changed As Boolean
    Public Particles3D(7) As Particle3D
    Public Sub Render()
        If Ticks = 0 Then

            Sounds.StopSound(STG.CurrentMusic)
            Sounds.PlaySound(Sounds.mu04)
            STG.CurrentMusic = Sounds.mu04
        End If
        RenderBackground()
        Ticks += 1
    End Sub
    Private Sub RenderBackground()
        If changed Then
            camera.Position = New Media3D.Point3D(camera.Position.X + 0.02, camera.Position.Y, camera.Position.Z)
        Else
            camera.Position = New Media3D.Point3D(camera.Position.X + 0.08, camera.Position.Y, camera.Position.Z)
        End If
        If changed Then
            If camera.Position.X > 14 Then
                camera.Position = New Media3D.Point3D(camera.Position.X - 8, camera.Position.Y, camera.Position.Z)
            End If
        Else
            If camera.Position.X > 14 Then
                camera.Position = New Media3D.Point3D(camera.Position.X - 16, camera.Position.Y, camera.Position.Z)
            End If
        End If

        If cardback.Visibility = Visibility.Visible Then
            Canvas.SetTop(CB1, Canvas.GetTop(CB1) - 2)
            Canvas.SetTop(CB2, Canvas.GetTop(CB2) - 2)
            If Canvas.GetTop(CB1) <= -448 Then
                Canvas.SetTop(CB1, Canvas.GetTop(CB1) + 896)
            End If
            If Canvas.GetTop(CB2) <= -448 Then
                Canvas.SetTop(CB2, Canvas.GetTop(CB2) + 896)
            End If
        End If
        For i = 0 To 7
            Particles3D(i).Render()
        Next
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        RC_Sky.Fill = Textures.st02a
        t1.Brush = Textures.st01a
        t2.Brush = Textures.st01a
        t3.Brush = Textures.st01a
        t4.Brush = Textures.st01a

        CB1.Fill = Textures.st02b
        CB2.Fill = Textures.st02b
        For i = 0 To 7
            Dim rz As Double = Rnd() * 0.5 + 1
            Particles3D(i) = New Particle3D(i * 0.5, 0.5 + Rnd() * 0.1, Rnd() * 0.2 - 0.1, rz, rz, New Media3D.Vector3D(-0.08, -0.01 * Rnd(), 0), Particle3DLayer, Textures.st02c) With {
                .Act = New Action(AddressOf .P21)
            }
            Particles3D(i).Rotation.Axis = New Media3D.Vector3D(0, 0, 1)
            Particles3D(i).Rotation.Angle = 90
        Next
    End Sub
    Public Sub Change()
        changed = True
        FW.Visibility = Visibility.Hidden
        FY.Visibility = Visibility.Visible
        camera.Position = New Media3D.Point3D(camera.Position.X, 4, camera.Position.Z)
        camera.LookDirection = New Media3D.Vector3D(3, -4, 0)
        RC_Sky.Visibility = Visibility.Hidden
        VP_Particle.Visibility = Visibility.Hidden
        Light.Color = Color.FromArgb(255, 255, 255, 200)
    End Sub
End Class
Module St2Eff
    <Extension>
    Public Sub P21(e As Particle3D)
        With e
            If .X < 0 Then
                .X += 4
                .Y = 0.5 + Rnd() * 0.2
            End If
        End With
    End Sub
End Module