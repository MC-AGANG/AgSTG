'使用方法：
'将制作完的ViewPort3D覆盖掉MainWindow.xaml的ViewPort3D
'其中镜头需要命名为camera
'然后启动本程序
'即可以自由视角查看3D模型
'键位与Minecraft旁观者模式相同
Imports System.Math
Imports System.Runtime.InteropServices
Imports ResourcePack.TH17

Class MainWindow
    Dim tick As Long = 0
    Dim lx As Double = 90
    Dim ly As Double = 206
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Textures.Load()
        t1.Brush = Textures.st06a
        t2.Brush = Textures.st06a
        t3.Brush = Textures.st06a
        t4.Brush = Textures.st06a
        t5.Brush = Textures.st06a
        t6.Brush = Textures.st06a
        t7.Brush = Textures.st06a
        t8.Brush = Textures.st06a
        t9.Brush = Textures.st06d
        t10.Brush = Textures.st06d
        t11.Brush = Textures.st06d
        t12.Brush = Textures.st06d
        t13.Brush = Textures.st06d
        t14.Brush = Textures.st06d
        t15.Brush = Textures.st06d
        t16.Brush = Textures.st06d
        t31.Brush = Textures.st05c00
        t41.Brush = Textures.st05b
        t42.Brush = Textures.st05b
        t43.Brush = Textures.st05b
        t44.Brush = Textures.st05b
        t45.Brush = Textures.st05b
        t46.Brush = Textures.st05b
        t47.Brush = Textures.st05b
        SetMouseAtCenterScreen()
        WindowState = WindowState.Maximized
        AddHandler CompositionTarget.Rendering, AddressOf mainthread
    End Sub
    Private Sub Window_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Key = Key.Escape Then
            Close()
        End If
    End Sub
    Public Sub mainthread()
        tick += 1
        If tick > 10 Then
            Dim winwidth As Integer = Forms.Screen.PrimaryScreen.WorkingArea.Width
            Dim winheight As Integer = Forms.Screen.PrimaryScreen.WorkingArea.Height
            lx = (lx - (Mouse.GetPosition(Me).X - winwidth / 2) / 10) Mod 360
            If ly + (Mouse.GetPosition(Me).Y - winheight / 2) / 10 > 100 AndAlso ly + (Mouse.GetPosition(Me).Y - winheight / 2) / 10 < 260 Then
                ly = (ly + (Mouse.GetPosition(Me).Y - winheight / 2) / 10) Mod 360
            End If

            camera.LookDirection = New Media3D.Vector3D(Sin(lx * PI / 180) * Cos(ly * PI / 180), Sin(ly * PI / 180), Cos(lx * PI / 180) * Cos(ly * PI / 180))
            SetMouseAtCenterScreen()
            If Keyboard.IsKeyDown(Key.Space) Then
                camera.Position = New Media3D.Point3D(camera.Position.X, camera.Position.Y + 0.04, camera.Position.Z)
            End If
            If Keyboard.IsKeyDown(Key.LeftShift) Then
                camera.Position = New Media3D.Point3D(camera.Position.X, camera.Position.Y - 0.04, camera.Position.Z)
            End If
            If Keyboard.IsKeyDown(Key.W) Then
                camera.Position = New Media3D.Point3D(camera.Position.X - 0.04 * Sin(lx * PI / 180), camera.Position.Y, camera.Position.Z - 0.04 * Cos(lx * PI / 180))
            End If
            If Keyboard.IsKeyDown(Key.S) Then
                camera.Position = New Media3D.Point3D(camera.Position.X + 0.04 * Sin(lx * PI / 180), camera.Position.Y, camera.Position.Z + 0.04 * Cos(lx * PI / 180))
            End If
            If Keyboard.IsKeyDown(Key.A) Then
                camera.Position = New Media3D.Point3D(camera.Position.X - 0.04 * Cos(lx * PI / 180), camera.Position.Y, camera.Position.Z + 0.04 * Sin(lx * PI / 180))
            End If
            If Keyboard.IsKeyDown(Key.D) Then
                camera.Position = New Media3D.Point3D(camera.Position.X + 0.04 * Cos(lx * PI / 180), camera.Position.Y, camera.Position.Z - 0.04 * Sin(lx * PI / 180))
            End If
        End If
    End Sub
    <DllImport("user32.dll")>
    Private Shared Function SetCursorPos(x As Integer, y As Integer) As Integer
    End Function
    Public Sub MoveMouseToPoint(p As Point)
        SetCursorPos(p.X, p.Y)
    End Sub

    Public Sub SetMouseAtCenterScreen()
        Dim winHeight As Integer = Forms.Screen.PrimaryScreen.WorkingArea.Height
        Dim winWidth As Integer = Forms.Screen.PrimaryScreen.WorkingArea.Width
        Dim centerP As New Point(winWidth / 2, winHeight / 2)
        MoveMouseToPoint(centerP)
    End Sub


End Class
