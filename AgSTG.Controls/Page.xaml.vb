Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports AgSTG.Core
''' <summary>
''' 表示页面。
''' </summary>
Public Class Page
    ''' <summary>
    ''' 获取或设置这个页面的时钟。
    ''' </summary>
    Public Timer As MediaTimer
    ''' <summary>
    ''' 获取或设置这个页面是否处于活动状态。
    ''' </summary>
    ''' <returns>若为False则页面不会运行</returns>
    Public Property Activated As Boolean
        Get
            Return _Activated
        End Get
        Set(value As Boolean)
            _Activated = value
            If Activated Then
                Timer.Act.Add(AddressOf Render)
                FreezeTime = 15
            Else
                Timer.Act.Remove(AddressOf Render)
            End If
            RaiseEvent ActivatedChanged(Activated)
        End Set
    End Property
    Private _Activated As Boolean = False
    Public FreezeTime As Integer = 0
    ''' <summary>
    ''' 获取或设置页面运行时间。
    ''' </summary>
    Public Ticks As Long = 0
    ''' <summary>
    ''' 获取或设置页面中包含的控件。
    ''' </summary>
    Public WithEvents Controls As New ObservableCollection(Of Control)
    Public Event ActivatedChanged(Activated As Boolean)
    ''' <summary>
    ''' 初始化页面。
    ''' </summary>
    Public Overridable Sub Initialize()
        Height = 480
        Width = 640
    End Sub
    ''' <summary>
    ''' 页面的循环脚本。
    ''' </summary>
    Public Act As Action

    ''' <summary>
    ''' 渲染当前页面。
    ''' </summary>
    Public Overridable Sub Render()
        Ticks += 1
        If FreezeTime > 0 Then
            FreezeTime -= 1
            Return
        End If
        Dispatcher.Invoke(Sub()
                              If Not IsNothing(Act) Then
                                  Act()
                              End If
                              For Each c In Controls
                                  c.Render()
                              Next
                          End Sub)
    End Sub
    Private Sub Update(sender As Object, e As NotifyCollectionChangedEventArgs)
        If e.Action = NotifyCollectionChangedAction.Add Then
            For Each ctl As Control In e.NewItems
                CV_Main.Children.Add(ctl)
            Next
        ElseIf e.Action = NotifyCollectionChangedAction.Remove Then
            For Each ctl As Control In e.OldItems
                CV_Main.Children.Remove(ctl)
            Next
        End If
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)

        Initialize()
    End Sub
    Public Sub New()
        InitializeComponent()
        AddHandler Controls.CollectionChanged, AddressOf Update
    End Sub
End Class
