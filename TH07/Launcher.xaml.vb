Public Class Launcher
    Private Sub fulbut_Click(sender As Object, e As RoutedEventArgs)
        If RB_Reimu.IsChecked Then
            AgSTG.STG.PlayerID = 0
        Else
            AgSTG.STG.PlayerID = 1
        End If
        Dim mw As New MainWindow
        mw.FullScreen = True
        mw.Show()
        Close()
    End Sub

    Private Sub winbut_Click(sender As Object, e As RoutedEventArgs)
        If RB_Reimu.IsChecked Then
            AgSTG.STG.PlayerID = 0
        Else
            AgSTG.STG.PlayerID = 1
        End If
        Dim mw As New MainWindow
        mw.FullScreen = False
        mw.Show()
        Close()
    End Sub
End Class
