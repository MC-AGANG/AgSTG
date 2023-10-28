Imports System.Math
Imports ResourcePack
Public Class HPBar
    ''' <summary>
    ''' 获取或设置非符血量
    ''' </summary>
    ''' <returns></returns>
    Public Property UsualHP As Double
    ''' <summary>
    ''' 获取或设置符卡血量
    ''' </summary>
    ''' <returns></returns>
    Public Property SpellHP As Double
    ''' <summary>
    ''' 获取或设置非符在血条中的占比
    ''' </summary>
    ''' <returns></returns>
    Public Property UsualPercent As Double
    ''' <summary>
    ''' 获取或设置符卡有几个阶段
    ''' </summary>
    ''' <returns></returns>
    Public Property SpellStages As Byte
    ''' <summary>
    ''' 获取或设置符卡每个阶段的占比
    ''' </summary>
    Public StagePercent() As Double
    Private s(3) As Rectangle
    Private s_r(3) As RotateTransform
    Private FadeInFrame As Byte = 0
    Public Sub Preset(UsualHP As Double, SpellHP As Double, Optional Usualpercent As Double = 0.75)
        Me.SpellHP = SpellHP
        Me.UsualHP = UsualHP
        Me.UsualPercent = Usualpercent
        For i = 0 To 3
            s(i).Visibility = Visibility.Hidden
        Next
        If SpellHP = 0 Then

        ElseIf UsualHP = 0 Then

        Else
            SetStage(0, 0.75 * 360)
        End If
        FadeInFrame = 60
    End Sub
    Public Sub Preset(UsualHP As Double, SpellHP As Double, StagePercent() As Double, Optional Usualpercent As Double = 0.75)
        Me.SpellHP = SpellHP
        Me.UsualHP = UsualHP
        Me.UsualPercent = Usualpercent
        Me.StagePercent = StagePercent
        For i = 0 To 3
            s(i).Visibility = Visibility.Hidden
        Next
        If SpellHP = 0 Then

        ElseIf UsualHP = 0 Then

            For i = 0 To StagePercent.Length - 2
                SetStage(i + 1, StagePercent(i) * 360)
            Next
        Else
            For i = 0 To StagePercent.Length - 2
                SetStage(i + 1, (Usualpercent + (1 - Usualpercent) * StagePercent(i)) * 360)
            Next
            SetStage(0, 0.75 * 360)
        End If
        FadeInFrame = 60
    End Sub
    Public Sub Update(IsSpell As Boolean, Value As Double)
        If FadeInFrame > 0 Then
            SetPath(360 - （FadeInFrame * 6)）
            FadeInFrame -= 1
        Else
            If Value < 0 Then
                Value = 0
            End If
            If IsSpell Then
                If UsualHP = 0 Then
                    SetPath(Value / SpellHP * 360)
                Else
                    SetPath(Value / SpellHP * 360 * (1 - UsualPercent))
                End If
            Else
                If SpellHP = 0 Then
                    SetPath(Value / UsualHP * 360)
                Else
                    SetPath((Value / UsualHP * 360 * UsualPercent) + (360 * (1 - UsualPercent)))
                End If
            End If
        End If
    End Sub
    Private Sub SetStage(id As Byte, angle As Double)
        s_r(id).Angle = angle
        s(id).Visibility = Visibility.Visible
    End Sub
    Public Sub SetPath(Angle As Double)
        Dim temp As Double
        temp = Angle - 180
        If temp > 179.95 Then
            temp = 179.95
        End If
        If temp > 0 Then
            r.IsLargeArc = True
        Else
            r.IsLargeArc = False
        End If
        r.Point = New Point(64 + 64 * Sin(temp / 180 * PI), 64 + 64 * Cos(temp / 180 * PI))
        r2.Point = New Point(64 + 64 * Sin(temp / 180 * PI), 64 + 64 * Cos(temp / 180 * PI))
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        back.Fill = Textures.hpbar(0)
        front.Fill = Textures.hpbar(1)
        Width = 128
        Height = 128
        s(0) = s0
        s(1) = s1
        s(2) = s2
        s(3) = s3
        s_r(0) = s0_r
        s_r(1) = s1_r
        s_r(2) = s2_r
        s_r(3) = s3_r
        For i = 0 To 3
            s(i).Fill = Textures.hpbar(2)
        Next
    End Sub
End Class
