Imports ResourcePack
Public Class BossName
    Private Stars(9) As Rectangle
    Private Scales(9) As ScaleTransform
    Public Property Tick As Long = 0
    Public Property Count As Integer = 0
    Private FadeoutTick As Integer = 0
    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        For i = 0 To 9
            Scales(i) = New ScaleTransform With {
                .CenterX = 4,
                .CenterY = 0
            }
            Stars(i) = New Rectangle With {
                .Width = 8,
                .Height = 8,
                .Fill = Textures.enemyspell,
                .RenderTransform = Scales(i)
            }
            SP_Stars.Children.Add(Stars(i))
        Next
    End Sub
    ''' <summary>
    ''' 初始化boss名称标签
    ''' </summary>
    ''' <param name="name">Boss名字</param>
    ''' <param name="count">符卡数量</param>
    Public Sub Initialize(name As String, count As Integer)
        count -= 1
        LB_Name.Content = name
        For i = 0 To count - 1
            Stars(i).Opacity = 1
        Next
        For i = count To 9
            Stars(i).Opacity = 0
        Next
        Me.Count = count
        Visibility = Visibility.Visible
    End Sub
    Public Sub Render()
        If Visibility = Visibility.Visible Then
            Tick += 1
            If FadeoutTick > 0 Then
                Stars(Count).Opacity = FadeoutTick / 25
                Scales(Count).ScaleX = 1 + (25 - FadeoutTick) / 25
                Scales(Count).ScaleY = 1 + (25 - FadeoutTick) / 25
                FadeoutTick -= 1
                If FadeoutTick = 0 Then
                    Stars(Count).Opacity = 0
                    Scales(Count).ScaleX = 1
                    Scales(Count).ScaleY = 1
                End If
            End If
        End If
    End Sub
    ''' <summary>
    ''' 进入下一张符卡或结束
    ''' </summary>
    Public Sub Break()
        If Count > 0 Then
            Count -= 1
            FadeoutTick = 25
        Else
            Visibility = Visibility.Hidden
        End If
    End Sub
End Class
