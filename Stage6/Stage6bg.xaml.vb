Imports System.Math
Imports System.Runtime.CompilerServices
Imports AgSTG
Imports ResourcePack.TH07
Public Class Stage6bg
    Public Shared cardback As Rectangle
    Public Particles3D(31) As Particle3D
    Public Shared Ticks As Long = 0
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        cardback = CB
        cardback.Fill = Textures.st06b
        RC_Tree1.Fill = Textures.st06a
        RC_Tree2.Fill = Textures.st06a
        RC_Tree3.Fill = Textures.st06c
        RC_Tree4.Fill = Textures.st06c
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
            Sounds.StopSound(STG.CurrentMusic)
            Sounds.PlaySound(Sounds.mu13)
            STG.CurrentMusic = Sounds.mu12
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
        End If

    End Sub

    Private Sub RenderBackground()

        If Ticks < 1000 Then
            Canvas.SetLeft(RC_Tree1, Canvas.GetLeft(RC_Tree1) + 10)
            Canvas.SetLeft(RC_Tree2, Canvas.GetLeft(RC_Tree2) + 10)
            If Canvas.GetLeft(RC_Tree1) >= 384 Then
                Canvas.SetLeft(RC_Tree1, Canvas.GetLeft(RC_Tree1) - 384 * 2)
            End If
            If Canvas.GetLeft(RC_Tree2) >= 384 Then
                Canvas.SetLeft(RC_Tree2, Canvas.GetLeft(RC_Tree2) - 384 * 2)
            End If
            Canvas.SetLeft(RC_Tree3, Canvas.GetLeft(RC_Tree3) - 4)
            Canvas.SetLeft(RC_Tree4, Canvas.GetLeft(RC_Tree4) - 4)
            If Canvas.GetLeft(RC_Tree3) <= -384 Then
                Canvas.SetLeft(RC_Tree3, Canvas.GetLeft(RC_Tree3) + 384 * 2)
            End If
            If Canvas.GetLeft(RC_Tree4) <= -384 Then
                Canvas.SetLeft(RC_Tree4, Canvas.GetLeft(RC_Tree4) + 384 * 2)
            End If
            camera.Position = New Media3D.Point3D(Cos(PI / 2 / 1000 * Ticks), 0.015, Sin(PI / 2 / 1000 * Ticks))
            camera.LookDirection = New Media3D.Vector3D(-Cos(PI / 2 / 1000 * Ticks), 0, -Sin(PI / 2 / 1000 * Ticks))
        End If
        If Ticks > 900 AndAlso Ticks <= 1000 Then
            GD_Main.Opacity = 1 - (Ticks - 900) / 100
        ElseIf Ticks > 1000 AndAlso Ticks <= 1100 Then
            GD_Main.Opacity = (Ticks - 1000) / 100
        End If
        If Ticks = 1000 Then
            camera.Position = New Media3D.Point3D(0, 0.015, 1)
            camera.LookDirection = New Media3D.Vector3D(0, 0, -1)
            RC_Tree1.Visibility = Visibility.Hidden
            RC_Tree2.Visibility = Visibility.Hidden
            RC_Tree4.Visibility = Visibility.Hidden
            Canvas.SetLeft(RC_Tree3, 0)
        End If
    End Sub
End Class
Module St6Eff
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