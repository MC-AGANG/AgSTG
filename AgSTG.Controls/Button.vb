Imports System.Math
Imports AgSTG.Core
Public Class Button
    Inherits Control
    Public Property Selected As Boolean
        Get
            Return _Selected
        End Get
        Set(value As Boolean)
            _Selected = value
            If value Then
                ForeLayer.Visibility = Visibility.Visible
            Else
                ForeLayer.Visibility = Visibility.Hidden
            End If
            RaiseEvent SelectionChanged(Me, value)
        End Set
    End Property
    Private _Selected As Boolean
    Public BackLayer As New Rectangle
    Public ForeLayer As New Rectangle
    Public Event SelectionChanged(sender As Button, selected As Boolean)
    Public Event Clicked(sender As Button)
    Public Sub New(Width As Double, Height As Double)
        MyBase.New(Width, Height)
        BackLayer.Width = Width
        BackLayer.Height = Height
        ForeLayer.Width = Width
        ForeLayer.Height = Height
    End Sub
    Public Overrides Sub Render()
        If Selected Then
            Foreground.Opacity = Sin(PI / 60 * Tick) * 0.5 + 0.5
            If KeyState.Shoot Then
                RaiseEvent Clicked(Me)
            End If
            Tick += 1
        End If
    End Sub
    Public Overrides Sub Initialize()
        GD_Main.Children.Add(BackLayer)
        GD_Main.Children.Add(ForeLayer)
    End Sub
End Class
