Imports AgSTG
Imports AgSTG.Core
Public Class GamePage
    Inherits Page
    Public STG As New STG
    Public PropertyBoard As New PropertyBoard
    Public Sub SetBackground(fill As Brush)
        CV_Main.Background = fill
    End Sub
    Public Sub New()
        MyBase.New()
        STG.Reset()
    End Sub
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        Canvas.SetLeft(STG, 32)
        Canvas.SetTop(STG, 16)
        CV_Main.Children.Add(STG)
        Canvas.SetLeft(PropertyBoard, 416)
        Canvas.SetTop(PropertyBoard, 16)
        CV_Main.Children.Add(PropertyBoard)
    End Sub
    Public Overrides Sub Act()
        MyBase.Act()
        STG.Render()
        PropertyBoard.Update()
    End Sub
End Class
