Imports ResourcePack
Imports System.Math
''' <summary>
''' 表示掉落物
''' </summary>
Public Class Item
    Inherits GameObject
    ''' <summary>
    ''' 获取或设置掉落物种类
    ''' </summary>
    ''' <returns></returns>
    Public Property ItemType As ItemType
    ''' <summary>
    ''' 获取或设置掉落物是否会主动飞向自机
    ''' </summary>
    ''' <returns></returns>
    Public Property ForceCollect As Boolean
    Private FadeOutFrame As Byte
    ''' <summary>
    ''' 创建新的掉落物
    ''' </summary>
    ''' <param name="ItemType">掉落物种类</param>
    ''' <param name="X">初始X坐标</param>
    ''' <param name="Y">初始Y坐标</param>
    Public Sub New(ItemType As ItemType, X As Double, Y As Double)
        MyBase.New(ObjectType.Item, X, Y)
        Me.ItemType = ItemType
        Select Case ItemType
            Case 0
                Background = Textures.item_power
                SetSize(16, 16, 16)
            Case 1
                Background = Textures.item_point
                SetSize(16, 16, 16)
            Case 2
                Background = Textures.item_pointvalue
                Opacity = 0.5
                SetSize(16, 16, 16)
            Case 3
                Background = Textures.item_life
                SetSize(32, 32, 32)
                Sounds.PlaySound(Sounds.bonus)
            Case 4
                Background = Textures.item_lifepiece
                SetSize(32, 32, 32)
                Sounds.PlaySound(Sounds.bonus)
            Case 5
                Background = Textures.item_spell
                SetSize(32, 32, 32)
                Sounds.PlaySound(Sounds.bonus2)
            Case 6
                Background = Textures.item_spellpiece
                SetSize(32, 32, 32)
                Sounds.PlaySound(Sounds.bonus2)
        End Select
    End Sub
    Public Overrides Sub Render()
        If Ticks <= 30 AndAlso ItemType <> ItemType.PointValue AndAlso IsEnabled Then
            Me_Rotate.Angle = Ticks * 24
        End If
        Judge()
        If FadeOutFrame > 0 Then
            FadeOut()
        Else
            Item_Move()
            If STG.Player.Y <= 128 Then
                ForceCollect = True
            End If
        End If
    End Sub
    Private Sub Item_Move()
        If ForceCollect Then
            Dim Distance As New Vector(STG.Player.X - X, STG.Player.Y - Y)
            Distance.Normalize()
            X += 8 * Distance.X
            Y += 8 * Distance.Y
        Else
            If Ticks <= 30 Then
                Y -= (30 - Ticks) / 5
            Else
                If ItemType = ItemType.PointValue Then
                    ForceCollect = True
                End If
                Y += 1
            End If
            If KeyState.Slow Then
                If GetDistance(STG.Player) < 64 Then
                    Dim Distance As New Vector(STG.Player.X - X, STG.Player.Y - Y)
                    Distance.Normalize()
                    X += 2 * Distance.X
                    Y += 2 * Distance.Y
                ElseIf GetDistance(STG.Player) < 32 Then
                    Dim Distance As New Vector(STG.Player.X - X, STG.Player.Y - Y)
                    Distance.Normalize()
                    X += 2 * Distance.X
                    Y += 2 * Distance.Y
                End If
            End If
        End If
        If Y < -Height / 2 Then
            Me_Translast2.Y = (Height / 2) - Y
            Select Case ItemType
                Case 0
                    Background = Textures.item_power_u
                    Exit Select
                Case 1
                    Background = Textures.item_point_u
                    Exit Select
                Case 3
                    Background = Textures.item_life_u
                    Exit Select
                Case 4
                    Background = Textures.item_lifepiece_u
                    Exit Select
                Case 5
                    Background = Textures.item_spell_u
                    Exit Select
                Case 6
                    Background = Textures.item_spellpiece_u
                    Exit Select
                Case Else
                    Exit Select
            End Select
        Else
            Me_Translast2.Y = 0
            Select Case ItemType
                Case 0
                    Background = Textures.item_power
                    Exit Select
                Case 1
                    Background = Textures.item_point
                    Exit Select
                Case 3
                    Background = Textures.item_life
                    Exit Select
                Case 4
                    Background = Textures.item_lifepiece
                    Exit Select
                Case 5
                    Background = Textures.item_spell
                    Exit Select
                Case 6
                    Background = Textures.item_spellpiece
                    Exit Select
                Case Else
                    Exit Select
            End Select
        End If
    End Sub
    Private Sub FadeOut()
        Opacity = (60 - FadeOutFrame) / 60
        FadeOutFrame += 1
        If FadeOutFrame >= 60 Then
            Clear()
        End If
    End Sub
    Private Sub ShowNumber(Color As Byte, Value As Long)
        Me_Rotate.Angle = 0
        If Color = 3 Then
            SetSize(48, 8, 0)
            Background = Textures.item_powerup
        Else
            Background = Nothing
            Dim dig As Integer = Int(Log10(Value)) + 1
            Dim rec(dig - 1) As Rectangle
            Dim s As String = Value
            SetSize(dig * 8, 8, 0)
            For i = 0 To dig - 1
                rec(i) = New Rectangle
                MainBoard.Children.Add(rec(i))
                With rec(i)
                    .Height = 8
                    .Width = 8
                    .Fill = Textures.item_number(Color, Val(Mid(s, i + 1, 1)))
                End With
                Canvas.SetLeft(rec(i), i * 8)
            Next
        End If
    End Sub
    Private Sub Judge()
        If IsEnabled AndAlso IsHit(STG.Player) Then
            Collect()
        End If
    End Sub
    Private Sub Collect()
        IsEnabled = False
        Sounds.PlaySound(Sounds.item00, 0.5)
        Select Case ItemType
            Case 0
                If STG.Power < 400 Then
                    STG.Power += 1
                    If STG.Power Mod 100 = 0 Then
                        ShowNumber(3, 0)
                        Sounds.PlaySound(Sounds.powerup, 0.8)
                    Else
                        ShowNumber(2, STG.Power)
                    End If
                Else
                    STG.Score += 51200
                    ShowNumber(1, 51200)
                End If
                FadeOutFrame = 1
                Exit Select
            Case 1
                If ForceCollect OrElse STG.Player.Y < 128 Then
                    STG.Score += STG.PointValue
                    ShowNumber(1, STG.PointValue)
                Else
                    STG.Score += Int(STG.PointValue * (400 - (STG.Player.Y - 128)) / 4000) * 10
                    ShowNumber(0, Int(STG.PointValue * (400 - (STG.Player.Y - 128)) / 4000) * 10)
                End If
                FadeOutFrame = 1
                Exit Select
            Case 2
                STG.PointValue += 10
                Clear()
                Exit Select
            Case 3
                If STG.Life < 8 Then
                    STG.Life += 1
                    Sounds.PlaySound(Sounds.extend)
                End If
                Clear()
                Exit Select
            Case 4
                If STG.LifePiece < 2 Then
                    STG.LifePiece += 1
                Else
                    If STG.Life < 8 Then
                        STG.Life += 1
                        STG.LifePiece = 0
                        Sounds.PlaySound(Sounds.extend)
                    End If
                End If
                Clear()
                Exit Select
            Case 5
                If STG.Spell < 8 Then
                    STG.Spell += 1
                    Sounds.PlaySound(Sounds.cardget)
                End If
                Clear()
                Exit Select
            Case 6
                If STG.SpellPiece < 5 Then
                    STG.SpellPiece += 1
                Else
                    If STG.Spell < 8 Then
                        STG.Spell += 1
                        STG.Spell = 0
                        Sounds.PlaySound(Sounds.cardget)
                    End If
                End If
                Clear()
                Exit Select
            Case Else
                Clear()
                Exit Select
        End Select
    End Sub
End Class
''' <summary>
''' 枚举掉落物种类
''' </summary>
Public Enum ItemType
    ''' <summary>
    ''' P点
    ''' </summary>
    Power = 0
    ''' <summary>
    ''' 蓝点
    ''' </summary>
    Point = 1
    ''' <summary>
    ''' 信仰点
    ''' </summary>
    PointValue = 2
    ''' <summary>
    ''' 残机
    ''' </summary>
    Life = 3
    ''' <summary>
    ''' 残机碎片
    ''' </summary>
    LifePiece = 4
    ''' <summary>
    ''' 符卡（B）
    ''' </summary>
    Spell = 5
    ''' <summary>
    ''' 符卡（B）碎片
    ''' </summary>
    SpellPiece = 6
End Enum