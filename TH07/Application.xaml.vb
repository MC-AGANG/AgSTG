Class Application
    Private MW As New MainWindow
    Private Async Sub Application_Startup(sender As Object, e As StartupEventArgs)
        MW = New MainWindow
        MW.Show()
        Await LoadResource()
        MW.Start()
    End Sub

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.
    Private Async Function LoadResource() As Task
        ResourcePack.Textures.Load()
        ResourcePack.Sounds.Load()
        ResourcePack.TH07.Textures.Load()
        ResourcePack.TH07.Sounds.Load()
        ResourcePack.TH07.Texts.Load()
    End Function
End Class
