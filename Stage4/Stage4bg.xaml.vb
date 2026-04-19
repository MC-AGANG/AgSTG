Imports System.Runtime.CompilerServices
Imports AgSTG
Imports ResourcePack.TH07
Public Class Stage4bg
    Public Ticks As Long
    Public p2d(23) As Particle
    Public Sub Render()
        If Ticks = 0 Then
            Sounds.StopSound(STG.CurrentMusic)
            Sounds.PlaySound(Sounds.mu08)
            STG.CurrentMusic = Sounds.mu08
        End If

        RenderBackground()
        Ticks += 1
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        RC_vortex.Fill = Textures.st04a
        RC_Sky.Fill = Textures.st04c
        t1.Brush = Textures.st04g
        t2.Brush = Textures.st04g
        t3.Brush = Textures.st04g
        t4.Brush = Textures.st04g
        For i = 0 To 7
            Dim size As Double = Rnd() * 8 + 16
            p2d(i) = New Particle(Rnd() * 384, Rnd() * 448, size, size, ParticleLayer) With {
                .Speed = 0.8 + 0.4 * Rnd(),
                .Direction = 180 + Rnd() * 30 - 15,
                .Angular = Rnd() * 4 - 2,
                .Background = ResourcePack.Textures.particle_snow,
                .Act = AddressOf .S4E1
            }
        Next
        For i = 8 To 23
            Dim size As Double = Rnd() * 8 + 16
            p2d(i) = New Particle(Rnd() * 384, Rnd() * 448, size, size, ParticleLayer) With {
                .Speed = 0.8 + 0.4 * Rnd(),
                .Direction = 180 + Rnd() * 30 - 15,
                .Angular = Rnd() * 4 - 2,
                .Background = ResourcePack.Textures.particle_cherry,
                .Act = AddressOf .S4E1
            }
        Next
    End Sub
    Public Sub RenderBackground()
        If RC_vortex.Visibility = Visibility.Visible Then
            Rotate_vortex.Angle += 0.25
        End If
        For Each p In p2d
            p.Render()
        Next
        If Ticks > 1850 AndAlso Ticks <= 2050 Then
            ParticleLayer.Opacity = (Ticks - 1850) / 400
        ElseIf Ticks > 7150 AndAlso Ticks < 7250 Then
            RC_vortex.Opacity = (7250 - Ticks) / 100
        ElseIf Ticks = 7250 Then
            RC_vortex.Visibility = Visibility.Hidden
        ElseIf Ticks = 8600 Then
            VP3D.Visibility = Visibility.Visible
        ElseIf Ticks > 8600 AndAlso Ticks < 9100 Then
            RC_Sky.Opacity = 1 - (9100 - Ticks) / 500
            VP3D.Opacity = 1 - (9100 - Ticks) / 500
        End If
        If VP3D.Visibility = Visibility.Visible Then
            camera.Position = New Media3D.Point3D(camera.Position.X + 0.02, camera.Position.Y, camera.Position.Z)
            If camera.Position.X > 6 Then
                camera.Position = New Media3D.Point3D(camera.Position.X - 4, camera.Position.Y, camera.Position.Z)
            End If
        End If

    End Sub
End Class
Module St4Eff
    <Extension>
    Public Sub S4E1(e As Particle)
        With e
            If .Y >= 512 Then
                .Y = -16
                .X = Rnd() * 384
            End If
        End With
    End Sub
End Module