Imports AgSTG
Imports ResourcePack.TH17
Class GamePage
    Public STG As New STG
    Public PropertyBoard As New PropertyBoard
    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        MainBoard.Children.Add(STG)
        Grid.SetColumn(STG, 1)
        Grid.SetRow(STG, 1)
        MainBoard.Children.Add(PropertyBoard)
        Grid.SetColumn(PropertyBoard, 2)
        Grid.SetRow(PropertyBoard, 1)
        Grid.SetRowSpan(PropertyBoard, 3)
        Background = Textures.game_background
    End Sub
End Class
