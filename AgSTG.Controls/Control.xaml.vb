Public MustInherit Class Control
    Public Property Tick As Long = 0
    Public Sub New(Width As Double, Height As Double)
        InitializeComponent()
    End Sub
    Public MustOverride Sub Render()
    Public MustOverride Sub Initialize()

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        Initialize()
    End Sub
End Class
