Imports System.Windows.Media.Media3D
''' <summary>
''' 表示三维粒子，默认沿X-Z平面
''' </summary>
Public Class Particle3D
    ''' <summary>
    ''' 获取或设置粒子的位置X坐标。
    ''' </summary>
    ''' <returns></returns>
    Public Property X As Double
    ''' <summary>
    ''' 获取或设置粒子的位置Y坐标。
    ''' </summary>
    ''' <returns></returns>
    Public Property Y As Double
    ''' <summary>
    ''' 获取或设置粒子的位置Z坐标。
    ''' </summary>
    ''' <returns></returns>
    Public Property Z As Double
    ''' <summary>
    ''' 获取或设置粒子的宽度。
    ''' </summary>
    ''' <returns></returns>
    Public Property Width As Double
    ''' <summary>
    ''' 获取或设置粒子的高度。
    ''' </summary>
    ''' <returns></returns>
    Public Property Height As Double
    ''' <summary>
    ''' 获取或设置粒子的速度。
    ''' </summary>
    ''' <returns></returns>
    Public Property Speed As Vector3D
    ''' <summary>
    ''' 获取或设置粒子的角速度。
    ''' </summary>
    ''' <returns></returns>
    Public Property Angular As Double
    ''' <summary>
    ''' 获取或设置粒子已经存在的时间。
    ''' </summary>
    ''' <returns></returns>
    Public Property Ticks As Long
    ''' <summary>
    ''' 获取或设置粒子所属的三维模型组。
    ''' </summary>
    Public Owner As Model3DGroup
    Private Model As GeometryModel3D
    Private Mesh As MeshGeometry3D
    Private Points(3) As Point3D
    ''' <summary>
    ''' 获取或设置粒子的平移变换。
    ''' </summary>
    Public Translation As TranslateTransform3D
    ''' <summary>
    ''' 获取或设置粒子的旋转变换。
    ''' </summary>
    Public Rotation As AxisAngleRotation3D
    Private RT As RotateTransform3D
    ''' <summary>
    ''' 获取或设置粒子的缩放变换。
    ''' </summary>
    Public Scale As ScaleTransform3D
    ''' <summary>
    ''' 获取或设置粒子的行为。
    ''' </summary>
    Public Act As Action
    Private Transforms As Transform3DGroup
    ''' <summary>
    ''' 创建新的三维粒子。
    ''' </summary>
    ''' <param name="X">粒子X坐标</param>
    ''' <param name="Y">粒子Y坐标</param>
    ''' <param name="Z">粒子Z坐标</param>
    ''' <param name="Width">粒子宽度</param>
    ''' <param name="Height">粒子高度</param>
    ''' <param name="Speed">粒子速度</param>
    ''' <param name="Owner">要将粒子添加到的三维模型组</param>
    ''' <param name="texture">粒子纹理</param>
    Public Sub New(X As Double, Y As Double, Z As Double, Width As Double, Height As Double, Speed As Vector3D, Owner As Model3DGroup, texture As Brush)
        Me.X = X
        Me.Y = Y
        Me.Z = Z
        Me.Width = Width
        Me.Height = Height
        Me.Speed = Speed
        Me.Owner = Owner
        Mesh = New MeshGeometry3D()
        'points(0) = New Point3D(X - Width / 2, Y, Z - Height / 2)
        'points(1) = New Point3D(X + Width / 2, Y, Z - Height / 2)
        'points(2) = New Point3D(X + Width / 2, Y, Z + Height / 2)
        'points(3) = New Point3D(X - Width / 2, Y, Z + Height / 2)
        Points(0) = New Point3D(X, Y, Z)
        Points(1) = New Point3D(X + Width, Y, Z)
        Points(2) = New Point3D(X + Width, Y, Z + Height)
        Points(3) = New Point3D(X, Y, Z + Height)
        Mesh.Positions.Add(Points(0))
        Mesh.Positions.Add(Points(1))
        Mesh.Positions.Add(Points(2))
        Mesh.Positions.Add(Points(3))
        Mesh.TextureCoordinates.Add(New Point(0, 0))
        Mesh.TextureCoordinates.Add(New Point(1, 0))
        Mesh.TextureCoordinates.Add(New Point(1, 1))
        Mesh.TextureCoordinates.Add(New Point(0, 1))
        Mesh.TriangleIndices.Add(0)
        Mesh.TriangleIndices.Add(1)
        Mesh.TriangleIndices.Add(2)
        Mesh.TriangleIndices.Add(0)
        Mesh.TriangleIndices.Add(2)
        Mesh.TriangleIndices.Add(3)
        Mesh.TriangleIndices.Add(0)
        Mesh.TriangleIndices.Add(2)
        Mesh.TriangleIndices.Add(1)
        Mesh.TriangleIndices.Add(0)
        Mesh.TriangleIndices.Add(3)
        Mesh.TriangleIndices.Add(2)
        Model = New GeometryModel3D With {
            .Geometry = Mesh,
            .Material = New DiffuseMaterial(texture)
        }
        Translation = New TranslateTransform3D(-Width / 2, 0, -Height / 2)
        'Translation = New TranslateTransform3D(0, 0, 0)
        Rotation = New AxisAngleRotation3D
        RT = New RotateTransform3D
        RT.Rotation = Rotation
        Scale = New ScaleTransform3D(1, 1, 1)
        Transforms = New Transform3DGroup()
        Transforms.Children.Add(Translation)
        Transforms.Children.Add(RT)
        Transforms.Children.Add(Scale)
        Model.Transform = Transforms
        Owner.Children.Add(Model)
    End Sub
    ''' <summary>
    ''' 渲染粒子效果。
    ''' </summary>
    Public Sub Render()
        Move()
        Ticks += 1
        If Not IsNothing(Act) Then
            Act()
        End If
    End Sub
    Private Sub Move()
        X += Speed.X
        Y += Speed.Y
        Z += Speed.Z
        Points(0) = New Point3D(X, Y, Z)
        Points(1) = New Point3D(X + Width, Y, Z)
        Points(2) = New Point3D(X + Width, Y, Z + Height)
        Points(3) = New Point3D(X, Y, Z + Height)
        RT.CenterX = X
        RT.CenterY = Y
        RT.CenterZ = Z
        For i = 0 To 3
            Mesh.Positions(i) = Points(i)
        Next
        Rotation.Angle += Angular
    End Sub
End Class
