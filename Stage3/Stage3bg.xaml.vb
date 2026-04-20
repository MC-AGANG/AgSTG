Imports AgSTG
Imports ResourcePack.TH07
Public Class Stage3bg
    Public Ticks As Long
    Public Sub Render()
        If Ticks = 0 Then
            ResourcePack.Sounds.StopSound(STG.CurrentMusic)
            ResourcePack.Sounds.PlaySound(Sounds.mu06)
            STG.CurrentMusic = Sounds.mu06
        End If
        If Ticks <= 9480 Then
            Canvas.SetTop(BK1, -3136 + (Ticks / 9480 * 3136))

        End If

        Ticks += 1
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        BK1.Fill = Textures.st03a
        cardback.Fill = Textures.st03b
    End Sub
End Class
