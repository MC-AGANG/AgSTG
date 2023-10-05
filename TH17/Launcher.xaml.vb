Public Class Launcher
    Private Sub fulbut_Click(sender As Object, e As RoutedEventArgs)
        Dim mw As New MainWindow
        mw.FullScreen = True
        mw.Show()
        Close()
    End Sub

    Private Sub winbut_Click(sender As Object, e As RoutedEventArgs)
        Dim mw As New MainWindow
        mw.FullScreen = False
        mw.Show()
        Close()
    End Sub
End Class
