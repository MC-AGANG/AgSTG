''' <summary>
''' 表示数字标签<br/> 
''' 可以使用贴图展示数字
''' </summary>
Public Class NumberLabel
    Public Textures As ImageBrush()
    Private LS_RC As New List(Of Rectangle)
    Private Shadows Content As String
    ''' <summary>
    ''' 更新显示的数字<br/>
    ''' </summary>
    ''' <param name="content">要显示的内容</param>
    Public Sub Update(content As String)
        If Me.Content <> content Then
            If Textures.Length < 1 Then
                Throw New Exception("未设置贴图")
            End If
            Dim compensation As Double = 0
            Do While LS_RC.Count < content.Length
                Dim tr As New Rectangle
                LS_RC.Add(tr)
                CV_Main.Children.Add(tr)
                tr.Width = Textures(0).ImageSource.Width
                tr.Height = Textures(0).ImageSource.Height
            Loop
            For i = content.Length - 1 To 0 Step -1
                Dim c As Char = content(i)
                If c >= "0" AndAlso c <= "9" Then
                    LS_RC(i + (LS_RC.Count - content.Length)).Fill = Textures(Val(c))
                    Canvas.SetLeft(LS_RC(i + (LS_RC.Count - content.Length)), ActualWidth - (Textures(0).ImageSource.Width * 0.75 * (content.Length - i)) + compensation)
                    Canvas.SetTop(LS_RC(i + (LS_RC.Count - content.Length)), 0)
                ElseIf c = "/" Then
                    LS_RC(i + (LS_RC.Count - content.Length)).Fill = Textures(10)
                    Canvas.SetLeft(LS_RC(i + (LS_RC.Count - content.Length)), ActualWidth - (Textures(0).ImageSource.Width * 0.75 * (content.Length - i)) + compensation)
                    Canvas.SetTop(LS_RC(i + (LS_RC.Count - content.Length)), 0)
                ElseIf c = "." Then
                    LS_RC(i + (LS_RC.Count - content.Length)).Fill = Textures(11)
                    Canvas.SetLeft(LS_RC(i + (LS_RC.Count - content.Length)), ActualWidth - (Textures(0).ImageSource.Width * 0.75 * (content.Length - i)) + compensation + 5)
                    Canvas.SetTop(LS_RC(i + (LS_RC.Count - content.Length)), 0)
                    compensation += 7
                ElseIf c = "s" Then
                    LS_RC(i + (LS_RC.Count - content.Length)).Fill = Textures(12)
                    Canvas.SetLeft(LS_RC(i + (LS_RC.Count - content.Length)), ActualWidth - (Textures(0).ImageSource.Width * 0.75 * (content.Length - i)) + compensation)
                    Canvas.SetTop(LS_RC(i + (LS_RC.Count - content.Length)), 0)
                ElseIf c = "x" Then
                    LS_RC(i + (LS_RC.Count - content.Length)).Fill = Textures(13)
                    Canvas.SetLeft(LS_RC(i + (LS_RC.Count - content.Length)), ActualWidth - (Textures(0).ImageSource.Width * 0.75 * (content.Length - i)) + compensation)
                    Canvas.SetTop(LS_RC(i + (LS_RC.Count - content.Length)), 0)
                ElseIf c = "," Then
                    LS_RC(i + (LS_RC.Count - content.Length)).Fill = Textures(14)
                    Canvas.SetLeft(LS_RC(i + (LS_RC.Count - content.Length)), ActualWidth - (Textures(0).ImageSource.Width * 0.75 * (content.Length - i)) + compensation + 7)
                    Canvas.SetTop(LS_RC(i + (LS_RC.Count - content.Length)), 3)
                    compensation += 7
                End If
            Next
            For i = 0 To LS_RC.Count - content.Length - 1
                LS_RC(i).Fill = Nothing
            Next
            Me.Content = content
        End If

    End Sub
End Class
