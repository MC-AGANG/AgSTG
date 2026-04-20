Imports AgSTG
Imports ResourcePack.TH07

Public Class Stage5bg
    Public Ticks As Long
    Public Sub Render()
        If Ticks = 0 Then
            ResourcePack.Sounds.StopSound(STG.CurrentMusic)
            ResourcePack.Sounds.PlaySound(Sounds.mu10)
            STG.CurrentMusic = Sounds.mu10
        End If
        Ticks += 1
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        RC1.Fill = Textures.st05a
    End Sub
End Class
