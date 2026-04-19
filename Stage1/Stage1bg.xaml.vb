Imports AgSTG
Imports ResourcePack.TH07
Imports System.Runtime.CompilerServices
Public Class Stage1bg
    Public Shared Ticks As Long = 0
    Public snows(23) As Particle
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        t1.Brush = Textures.st01a
        t2.Brush = Textures.st01a
        t3.Brush = Textures.st01a

        t11.Brush = Textures.st01b
        t13.Brush = Textures.st01b
        t15.Brush = Textures.st01b
        t17.Brush = Textures.st01b
        t19.Brush = Textures.st01b
        t21.Brush = Textures.st01b
        t23.Brush = Textures.st01b
        t25.Brush = Textures.st01b
        t27.Brush = Textures.st01b
        t29.Brush = Textures.st01b
        t31.Brush = Textures.st01b
        t33.Brush = Textures.st01b
        t35.Brush = Textures.st01b
        t37.Brush = Textures.st01b
        t39.Brush = Textures.st01b
        t41.Brush = Textures.st01b

        t12.Brush = Textures.st01c
        t14.Brush = Textures.st01c
        t16.Brush = Textures.st01c
        t18.Brush = Textures.st01c
        t20.Brush = Textures.st01c
        t22.Brush = Textures.st01c
        t24.Brush = Textures.st01c
        t26.Brush = Textures.st01c
        t28.Brush = Textures.st01c
        t30.Brush = Textures.st01c
        t32.Brush = Textures.st01c
        t34.Brush = Textures.st01c
        t36.Brush = Textures.st01c
        t38.Brush = Textures.st01c
        t40.Brush = Textures.st01c
        t42.Brush = Textures.st01c

        t11.Brush.Opacity = 0.5
        t12.Brush.Opacity = 0.5
        t13.Brush.Opacity = 0.5
        t14.Brush.Opacity = 0.5
        t15.Brush.Opacity = 0.5
        t16.Brush.Opacity = 0.5
        t17.Brush.Opacity = 0.5
        t18.Brush.Opacity = 0.5
        t19.Brush.Opacity = 0.5
        t20.Brush.Opacity = 0.5
        t21.Brush.Opacity = 0.5
        t22.Brush.Opacity = 0.5
        t23.Brush.Opacity = 0.5
        t24.Brush.Opacity = 0.5
        t25.Brush.Opacity = 0.5
        t26.Brush.Opacity = 0.5
        t27.Brush.Opacity = 0.5
        t28.Brush.Opacity = 0.5
        t29.Brush.Opacity = 0.5
        t30.Brush.Opacity = 0.5
        t31.Brush.Opacity = 0.5
        t32.Brush.Opacity = 0.5
        t33.Brush.Opacity = 0.5
        t34.Brush.Opacity = 0.5
        t35.Brush.Opacity = 0.5
        t36.Brush.Opacity = 0.5
        t37.Brush.Opacity = 0.5
        t38.Brush.Opacity = 0.5
        t39.Brush.Opacity = 0.5
        t40.Brush.Opacity = 0.5
        t41.Brush.Opacity = 0.5
        t42.Brush.Opacity = 0.5
        For i = 0 To 23
            Dim size As Double = Rnd() * 8 + 16
            snows(i) = New Particle(Rnd() * 384, Rnd() * 448, size, size, ParticleLayer) With {
                .Speed = 0.8 + 0.4 * Rnd(),
                .Direction = 180 + Rnd() * 30 - 15,
                .Angular = Rnd() * 4 - 2,
                .Background = ResourcePack.Textures.particle_snow,
                .Act = AddressOf .S1E1
            }
        Next
    End Sub
    Public Sub Render()
        If Ticks = 0 Then

            Sounds.StopSound(STG.CurrentMusic)
            Sounds.PlaySound(Sounds.mu02)
            STG.CurrentMusic = Sounds.mu02
        End If
        For Each p In snows
            p.Render()
        Next
        RenderBackground()
        Ticks += 1
    End Sub
    Public Sub RenderBackground()
        camera.Position = New Media3D.Point3D(camera.Position.X + 0.01, camera.Position.Y, camera.Position.Z)
        If camera.Position.X > 6 Then
            camera.Position = New Media3D.Point3D(camera.Position.X - 8, camera.Position.Y, camera.Position.Z)
        End If
    End Sub

End Class
Module St1Eff
    <Extension>
    Public Sub S1E1(e As Particle)
        With e
            If .Y >= 512 Then
                .Y = -16
                .X = Rnd() * 384
            End If
        End With
    End Sub
End Module