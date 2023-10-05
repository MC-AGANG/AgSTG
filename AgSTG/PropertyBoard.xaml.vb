Imports ResourcePack
Public Class PropertyBoard
    Public HiScore As Long
    Public lifei(7) As Rectangle
    Public spelli(7) As Rectangle
    Public hiscorei(9) As Rectangle
    Public hiscoresi(2) As Rectangle
    Public scorei(9) As Rectangle
    Public scoresi(2) As Rectangle
    Public poweri(2) As Rectangle
    Public pointvaluei(7) As Rectangle
    Public pointvaluesi(1) As Rectangle
    Public grazei(7) As Rectangle
    Public grazesi(1) As Rectangle
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        p_hiscore.Fill = Textures.icon_hiscore
        p_score.Fill = Textures.icon_score
        p_life.Fill = Textures.icon_life
        p_lifepiece.Fill = Textures.icon_lifepiece
        p_spellcard.Fill = Textures.icon_spellcard
        p_spellcardpiece.Fill = Textures.icon_spellcardpiece
        p_power.Fill = Textures.icon_power
        p_pointvalue.Fill = Textures.icon_pointvalue
        p_graze.Fill = Textures.icon_graze
        Init()
    End Sub
    Public Sub Update()
        Dim i As Integer
        Dim score = STG.Score
        Do While score > 0
            If scorei(i).Visibility = Visibility.Hidden Then scorei(i).Visibility = Visibility.Visible
            scorei(i).Fill = Textures.number(0, score Mod 10)
            If i = 3 Then scoresi(0).Visibility = Visibility.Visible
            If i = 6 Then scoresi(1).Visibility = Visibility.Visible
            If i = 9 Then scoresi(2).Visibility = Visibility.Visible
            score \= 10
            i += 1
        Loop
        i = 0
        Dim power = STG.Power
        Do While power > 0
            poweri(i).Fill = Textures.number(2, power Mod 10)
            power \= 10
            i += 1
        Loop
        i = 0
        Dim pointvalue = STG.PointValue
        Do While pointvalue > 0
            If pointvaluei(i).Visibility = Visibility.Hidden Then pointvaluei(i).Visibility = Visibility.Visible
            pointvaluei(i).Fill = Textures.number(3, pointvalue Mod 10)
            If i = 3 Then pointvaluesi(0).Visibility = Visibility.Visible
            If i = 6 Then pointvaluesi(1).Visibility = Visibility.Visible
            pointvalue \= 10
            i += 1
        Loop
        i = 0
        Dim graze = STG.Graze
        Do While graze > 0
            If grazei(i).Visibility = Visibility.Hidden Then grazei(i).Visibility = Visibility.Visible
            grazei(i).Fill = Textures.number(1, graze Mod 10)
            If i = 3 Then grazesi(0).Visibility = Visibility.Visible
            If i = 6 Then grazesi(1).Visibility = Visibility.Visible
            graze \= 10
            i += 1
        Loop
        For i = 0 To STG.Life - 1
            lifei(i).Fill = Textures.life_icon(5)
        Next
        For i = STG.Life + 1 To 7
            lifei(i).Fill = Textures.life_icon(0)
        Next
        If STG.Life < 8 Then
            Select Case STG.LifePiece
                Case 0
                    lifei(STG.Life).Fill = Textures.life_icon(0)
                    Exit Select
                Case 1
                    lifei(STG.Life).Fill = Textures.life_icon(2)
                    Exit Select
                Case 2
                    lifei(STG.Life).Fill = Textures.life_icon(3)
                    Exit Select
            End Select
        End If
        For i = 0 To STG.Spell - 1
            spelli(i).Fill = Textures.spell_icon(5)
        Next
        For i = STG.Spell + 1 To 7
            spelli(i).Fill = Textures.spell_icon(0)
        Next
        If STG.Spell < 8 Then
            Select Case STG.SpellPiece
                Case 0
                    spelli(STG.Spell).Fill = Textures.spell_icon(0)
                    Exit Select
                Case 1
                    spelli(STG.Spell).Fill = Textures.spell_icon(1)
                    Exit Select
                Case 2
                    spelli(STG.Spell).Fill = Textures.spell_icon(2)
                    Exit Select
                Case 3
                    spelli(STG.Spell).Fill = Textures.spell_icon(3)
                    Exit Select
                Case 4
                    spelli(STG.Spell).Fill = Textures.spell_icon(4)
                    Exit Select
            End Select
        End If
    End Sub
    Public Sub Init()
        For i = 0 To 9
            scorei(i) = New Rectangle
            With scorei(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(scorei(i), 184 - (i * 12 + (i \ 3) * 4))
                .Fill = Textures.number(0, 0)
                .Visibility = Visibility.Hidden
            End With
            p_scorearea.Children.Add(scorei(i))
            hiscorei(i) = New Rectangle
            With hiscorei(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(hiscorei(i), 184 - (i * 12 + (i \ 3) * 4))
                .Fill = Textures.number(1, 0)
                .Visibility = Visibility.Hidden
            End With
            p_hiscorearea.Children.Add(hiscorei(i))
        Next

        For i = 0 To 2
            scoresi(i) = New Rectangle
            With scoresi(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(scoresi(i), 196 - (i + 1) * 40)
                Canvas.SetTop(scoresi(i), 4)
                .Fill = Textures.number(0, 14)
                .Visibility = Visibility.Hidden
            End With
            p_scorearea.Children.Add(scoresi(i))
            hiscoresi(i) = New Rectangle
            With hiscoresi(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(hiscoresi(i), 196 - (i + 1) * 40)
                Canvas.SetTop(hiscoresi(i), 4)
                .Fill = Textures.number(1, 14)
                .Visibility = Visibility.Hidden
            End With
            p_hiscorearea.Children.Add(hiscoresi(i))
        Next
        poweri(0) = New Rectangle
        With poweri(0)
            .Height = 10
            .Width = 10
            .Fill = Textures.number(2, 0)
            Canvas.SetLeft(poweri(0), 130)
            Canvas.SetTop(poweri(0), 5)
        End With
        p_powerarea.Children.Add(poweri(0))
        poweri(1) = New Rectangle
        With poweri(1)
            .Height = 10
            .Width = 10
            .Fill = Textures.number(2, 0)
            Canvas.SetLeft(poweri(1), 124)
            Canvas.SetTop(poweri(1), 5)
        End With
        p_powerarea.Children.Add(poweri(1))
        poweri(2) = New Rectangle
        With poweri(2)
            .Height = 16
            .Width = 16
            .Fill = Textures.number(2, 1)
            Canvas.SetLeft(poweri(2), 103)
        End With
        p_powerarea.Children.Add(poweri(2))
        For i = 0 To 7
            pointvaluei(i) = New Rectangle
            With pointvaluei(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(pointvaluei(i), 184 - (i * 12 + (i \ 3) * 4))
                .Fill = Textures.number(3, 0)
                .Visibility = Visibility.Hidden
            End With
            p_pointvaluearea.Children.Add(pointvaluei(i))
            grazei(i) = New Rectangle
            With grazei(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(grazei(i), 184 - (i * 12 + (i \ 3) * 4))
                .Fill = Textures.number(1, 0)
                .Visibility = Visibility.Hidden
            End With
            p_grazearea.Children.Add(grazei(i))
        Next
        For i = 0 To 1
            pointvaluesi(i) = New Rectangle
            With pointvaluesi(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(pointvaluesi(i), 196 - (i + 1) * 40)
                Canvas.SetTop(pointvaluesi(i), 4)
                .Fill = Textures.number(3, 14)
                .Visibility = Visibility.Hidden
            End With
            p_pointvaluearea.Children.Add(pointvaluesi(i))
            grazesi(i) = New Rectangle
            With grazesi(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(grazesi(i), 196 - (i + 1) * 40)
                Canvas.SetTop(grazesi(i), 4)
                .Fill = Textures.number(1, 14)
                .Visibility = Visibility.Hidden
            End With
            p_grazearea.Children.Add(grazesi(i))
        Next
        scorei(0).Visibility = Visibility.Visible
        hiscorei(0).Visibility = Visibility.Visible
        pointvaluei(0).Visibility = Visibility.Visible
        grazei(0).Visibility = Visibility.Visible
        For i = 0 To 7
            lifei(i) = New Rectangle
            With lifei(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(lifei(i), 96 + i * 12)
                .Fill = Textures.life_icon(0)
            End With
            p_lifearea.Children.Add(lifei(i))
            spelli(i) = New Rectangle
            With spelli(i)
                .Width = 16
                .Height = 16
                Canvas.SetLeft(spelli(i), 96 + i * 12)
                .Fill = Textures.spell_icon(0)
            End With
            p_spellarea.Children.Add(spelli(i))
        Next
    End Sub
End Class
