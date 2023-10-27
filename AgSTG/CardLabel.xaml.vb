Imports ResourcePack
Public Class CardLabel
    Public FadeInFrame As Integer
    Public FadeOutFrame As Integer
    Public scorei(7) As Rectangle
    Private scah(5, 5) As Rectangle
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        bg.Fill = Textures.cardlabelbg
        failed.Fill = Textures.labelfailed
        getbonus.Fill = Textures.getbonus
        bonusfailed.Fill = Textures.bonusfailed
        scorei(0) = score1
        scorei(1) = score2
        scorei(2) = score3
        scorei(3) = score4
        scorei(4) = score5
        scorei(5) = score6
        scorei(6) = score7
        scorei(7) = score8
        scar1.Fill = Textures.spellattack
        scar2.Fill = Textures.spellattack
        scar3.Fill = Textures.spellattack
        scar4.Fill = Textures.spellattack
        scar5.Fill = Textures.spellattack
        scar6.Fill = Textures.spellattack
        scar7.Fill = Textures.spellattack
        scar8.Fill = Textures.spellattack
        scar11.Fill = Textures.spellattack
        scar12.Fill = Textures.spellattack
        scar13.Fill = Textures.spellattack
        scar14.Fill = Textures.spellattack
        scar15.Fill = Textures.spellattack
        scar16.Fill = Textures.spellattack
        scar17.Fill = Textures.spellattack
        scar18.Fill = Textures.spellattack
        scar21.Fill = Textures.spellattack
        scar22.Fill = Textures.spellattack
        scar23.Fill = Textures.spellattack
        scar24.Fill = Textures.spellattack
        scar25.Fill = Textures.spellattack
        scar26.Fill = Textures.spellattack
        scar27.Fill = Textures.spellattack
        scar28.Fill = Textures.spellattack
        Dim scah_r As New RotateTransform With {
            .CenterX = 64,
            .CenterY = 8,
            .Angle = -15
        }
        For y = 0 To 5
            For x = 0 To 5
                scah(x, y) = New Rectangle With {
                    .Fill = Textures.spellattack,
                    .Height = 16,
                    .Width = 128,
                    .RenderTransform = scah_r
                }
                scarea.Children.Add(scah(x, y))
                Canvas.SetLeft(scah(x, y), 100 * x - 128)
                Canvas.SetTop(scah(x, y), 160 + y * 32 - x * 28)
            Next
        Next
    End Sub
    Public Sub Render()
        If FadeInFrame > 60 Then
            FadeInFrame -= 1
            cn_scale.ScaleX = (FadeInFrame - 60) / 15 + 1
            cn_scale.ScaleY = (FadeInFrame - 60) / 15 + 1
            cardname.Opacity = (90 - FadeInFrame) / 60 + 0.5
        ElseIf FadeInFrame > 30 Then
            FadeInFrame -= 1
            cn_translate.Y -= 12
        ElseIf FadeInFrame > 0 Then
            FadeInFrame -= 1
            bg.Opacity = (30 - FadeInFrame) / 30
            For i = 0 To 7
                scorei(i).Opacity = (30 - FadeInFrame) / 30
            Next
        End If
        If FadeInFrame > 0 Then
            scarea.Opacity = FadeInFrame / 200
            Sca_Render()
        End If
        If FadeOutFrame > 0 Then
            FadeOutFrame -= 1
            getbonus.Opacity = FadeOutFrame / 60
            If FadeOutFrame = 0 Then
                Visibility = Visibility.Hidden
            End If
        ElseIf FadeOutFrame < 0 Then
            FadeOutFrame += 1
            bonusfailed.Opacity = Math.Abs(FadeOutFrame) / 60
            If FadeOutFrame = 0 Then
                Visibility = Visibility.Hidden
            End If
        End If
    End Sub

    Public Sub Update(Score As Long)
        If Score = 0 Then
            For i = 0 To 7
                scorei(i).Visibility = Visibility.Hidden
            Next
            failed.Visibility = Visibility.Visible
        Else
            failed.Visibility = Visibility.Hidden
            For i = 0 To 7
                scorei(i).Visibility = Visibility.Visible
                scorei(i).Fill = Textures.number(4, (Score \ 10 ^ i) Mod 10)
            Next
        End If
    End Sub
    Public Sub Show(CardName As ImageBrush)
        Visibility = Visibility.Visible
        Me.cardname.Fill = CardName
        bg.Visibility = Visibility.Visible
        Me.cardname.Visibility = Visibility.Visible
        FadeInFrame = 90
        cn_scale.ScaleX = 3
        cn_scale.ScaleY = 3
        Me.cardname.Opacity = 0
        bg.Opacity = 0
        cn_translate.Y = 360
        For i = 0 To 7
            scorei(i).Visibility = Visibility.Visible
            scorei(i).Opacity = 0
        Next
        FadeOutFrame = 0
        getbonus.Opacity = 0
        bonusfailed.Opacity = 0
        failed.Visibility = Visibility.Hidden
        Sounds.PlaySound(Sounds.cat00, 0.8)
    End Sub
    Public Sub Success()
        FadeOutFrame = 120
        bg.Visibility = Visibility.Hidden
        cardname.Visibility = Visibility.Hidden
        failed.Visibility = Visibility.Hidden
        For i = 0 To 7
            scorei(i).Visibility = Visibility.Hidden
        Next
    End Sub
    Public Sub Fail()
        FadeOutFrame = -120
        bg.Visibility = Visibility.Hidden
        cardname.Visibility = Visibility.Hidden
        failed.Visibility = Visibility.Hidden
        For i = 0 To 7
            scorei(i).Visibility = Visibility.Hidden
        Next
    End Sub
    Public Sub Sca_Render()
        r1_r.Angle += 2
        r2_r.Angle += 2
        r3_r.Angle += 2
        r4_r.Angle += 2
        r5_r.Angle += 2
        r6_r.Angle += 2
        r7_r.Angle += 2
        r8_r.Angle += 2
        r11_r.Angle += 2
        r12_r.Angle += 2
        r13_r.Angle += 2
        r14_r.Angle += 2
        r15_r.Angle += 2
        r16_r.Angle += 2
        r17_r.Angle += 2
        r18_r.Angle += 2
        r21_r.Angle -= 3
        r22_r.Angle -= 3
        r23_r.Angle -= 3
        r24_r.Angle -= 3
        r25_r.Angle -= 3
        r26_r.Angle -= 3
        r27_r.Angle -= 3
        r28_r.Angle -= 3
        For x = 0 To 5
            For y = 0 To 5
                Canvas.SetLeft(scah(x, y), Canvas.GetLeft(scah(x, y)) + 2 * Math.Cos(15 / 180 * Math.PI))
                Canvas.SetTop(scah(x, y), Canvas.GetTop(scah(x, y)) - 2 * Math.Sin(15 / 180 * Math.PI))
                If Canvas.GetLeft(scah(x, y)) > 400 Then
                    Canvas.SetLeft(scah(x, y), Canvas.GetLeft(scah(x, y)) - 600)
                    Canvas.SetTop(scah(x, y), Canvas.GetTop(scah(x, y)) + 166)
                End If
            Next
        Next
    End Sub
End Class
