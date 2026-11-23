Imports ResourcePack
Public Class PropertyBoard
    Public HiScore As Long
    Public lifei(7) As Rectangle
    Public spelli(7) As Rectangle
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
        If STG.Score > STG.HiScore Then
            STG.HiScore = STG.Score
        End If
        NL_HiScore.Update(STG.HiScore.ToString("N0"))
        NL_Score.Update(STG.Score.ToString("N0"))
        NL_Power.Update((STG.Power / 100).ToString("F2") + "/4.00")
        NL_PointValue.Update(STG.PointValue.ToString("N0"))
        NL_Graze.Update(STG.Graze.ToString("N0"))
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
        NL_Score.Textures = Textures.number(0)
        NL_HiScore.Textures = Textures.number(1)
        NL_Power.Textures = Textures.number(2)
        NL_PointValue.Textures = Textures.number(3)
        NL_Graze.Textures = Textures.number(1)
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
        Height = 480
        Width = 224
    End Sub
    Public Sub SetDifficulty(value As Difficulty)
        Select Case value
            Case Difficulty.Easy
                p_difficulty.Fill = Textures.icon_easy
            Case Difficulty.Normal
                p_difficulty.Fill = Textures.icon_normal
            Case Difficulty.Hard
                p_difficulty.Fill = Textures.icon_hard
            Case Difficulty.Lunatic
                p_difficulty.Fill = Textures.icon_lunatic
            Case Difficulty.Extra
                p_difficulty.Fill = Textures.icon_extra
            Case Difficulty.Phantasm
                p_difficulty.Fill = Textures.icon_phantasm
        End Select
    End Sub
End Class
