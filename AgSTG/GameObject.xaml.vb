''' <summary>
''' 表示游戏中的一切实体<br/>
''' 此类只能作为继承类使用
''' </summary>
Public MustInherit Class GameObject
    ''' <summary>
    ''' 获取或设置对象的X坐标
    ''' </summary>
    ''' <returns></returns>
    Public Property X As Double
    ''' <summary>
    ''' 获取或设置对象的Y坐标
    ''' </summary>
    ''' <returns></returns>
    Public Property Y As Double
    ''' <summary>
    ''' 获取或设置对象的碰撞体积
    ''' </summary>
    ''' <returns></returns>
    Public Property HitboxSize As Double
    ''' <summary>
    ''' 获取或设置对象的已存在的时间<br/>
    ''' 不建议手动修改
    ''' </summary>
    ''' <returns></returns>
    Public Property FrameCount As Long = -1
    ''' <summary>
    ''' 获取或设置对象的类型
    ''' </summary>
    ''' <returns></returns>
    Public Property ObjectType As ObjectType
    ''' <summary>
    ''' 获取或设置对象是否处于可交互的状态
    ''' </summary>
    ''' <returns></returns>
    Public Shadows Property IsEnabled As Boolean = True
    ''' <summary>
    ''' 创建新的游戏实体，只能在继承时使用
    ''' </summary>
    ''' <param name="ObjectType">对象类型</param>
    ''' <param name="X">初始X坐标</param>
    ''' <param name="Y">初始Y坐标</param>
    Public Sub New(ObjectType As ObjectType, X As Double, Y As Double)
        InitializeComponent()
        Me.ObjectType = ObjectType
        Me.X = X
        Me.Y = Y
        STG.MainBoard.Children.Add(Me)
            Move()
    End Sub
    ''' <summary>
    ''' 设置对象的大小和碰撞体积
    ''' </summary>
    ''' <param name="Width">宽度</param>
    ''' <param name="Height">高度</param>
    ''' <param name="HitboxSize">碰撞体积</param>
    Public Sub SetSize(Width As Double, Height As Double, HitboxSize As Double)
        Me.Width = Width
        Me.Height = Height
        SetCenter()
        Me.HitboxSize = HitboxSize
    End Sub
    ''' <summary>
    ''' 从游戏中移除这个对象
    ''' </summary>
    Public Sub Clear()
        STG.MainBoard.Children.Remove(Me)
        STG.Objects_rm.Add(Me)
    End Sub
    ''' <summary>
    ''' 用于控制对象的行为<br/>
    ''' 每一帧都会被执行一次<br/>
    ''' 一切对象必须重写这个方法
    ''' </summary>
    Public MustOverride Sub Render()
    ''' <summary>
    ''' 将对象的坐标锚点从左上角移动到对象的中心点
    ''' </summary>
    Public Sub SetCenter()
        Me_Translate.X = -Width / 2
        Me_Translate.Y = -Height / 2
        Layer1_rotate.CenterX = Width / 2
        Layer1_rotate.CenterY = Height / 2
        Layer2_rotate.CenterX = Width / 2
        Layer2_rotate.CenterY = Height / 2
        Layer3_rotate.CenterX = Width / 2
        Layer3_rotate.CenterY = Height / 2
        Layer1_scale.CenterX = Width / 2
        Layer1_scale.CenterY = Height / 2
        Layer2_scale.CenterX = Width / 2
        Layer2_scale.CenterY = Height / 2
        Layer3_scale.CenterX = Width / 2
        Layer3_scale.CenterY = Height / 2
    End Sub
    ''' <summary>
    ''' 把对象的实际坐标渲染到画面上
    ''' </summary>
    Public Sub Move()
        Canvas.SetLeft(Me, X)
        Canvas.SetTop(Me, Y)
    End Sub
    ''' <summary>
    ''' 判断两个对象是否碰撞
    ''' </summary>
    ''' <param name="obj1">第一个对象</param>
    ''' <param name="obj2">第二个对象</param>
    ''' <returns></returns>
    Public Shared Function IsHit(obj1 As GameObject, obj2 As GameObject) As Boolean
        Return obj1.HitboxSize + obj2.HitboxSize > GetDistance(obj1, obj2)
    End Function
    ''' <summary>
    ''' 判断这个对象自身与目标对象是否碰撞
    ''' </summary>
    ''' <param name="Target">要判定的目标</param>
    ''' <returns></returns>
    Public Function IsHit(Target As GameObject)
        Return HitboxSize + Target.HitboxSize > GetDistance(Target)
    End Function
    ''' <summary>
    ''' 获取两个对象之间的距离
    ''' </summary>
    ''' <param name="obj1">第一个对象</param>
    ''' <param name="obj2">第二个对象</param>
    ''' <returns></returns>
    Public Shared Function GetDistance(obj1 As GameObject, obj2 As GameObject) As Double
        Dim vec As New Vector(obj1.X - obj2.X, obj1.Y - obj2.Y)
        Return vec.Length
    End Function
    ''' <summary>
    ''' 获取这个对象与目标对象之间的距离
    ''' </summary>
    ''' <param name="Target">目标对象</param>
    ''' <returns></returns>
    Public Function GetDistance(Target As GameObject) As Double
        Dim vec As New Vector(X - Target.X, Y - Target.Y)
        Return vec.Length
    End Function
    '''' <summary>
    '''' 测量一个对象到一个激光的垂直距离
    '''' </summary>
    '''' <param name="StartX">激光起始点X坐标</param>
    '''' <param name="StartY">激光起始点Y坐标</param>
    '''' <param name="EndX">激光终止点X坐标</param>
    '''' <param name="EndY">激光终止点Y坐标</param>
    '''' <param name="Target">要测量的对象</param>
    '''' <returns></returns>
    'Public Shared Function GetLaserDistance(StartX As Double, StartY As Double, EndX As Double, EndY As Double, Target As GameObject) As Double
    '    Return 0
    'End Function
    '''' <summary>
    '''' 测量一个对象到一个激光的垂直距离
    '''' </summary>
    '''' <param name="StartX">激光起始点X坐标</param>
    '''' <param name="StartY">激光起始点Y坐标</param>
    '''' <param name="Direction">激光方向</param>
    '''' <param name="Target">要测量的对象</param>
    '''' <returns></returns>
    'Public Shared Function GetLaserDistance(StartX As Double, StartY As Double, Direction As Double, Target As GameObject) As Double
    '    Return 0
    'End Function
End Class
''' <summary>
''' 枚举游戏对象类型
''' </summary>
Public Enum ObjectType As Byte
    ''' <summary>
    ''' 敌机子弹
    ''' </summary>
    Bullet = 0
    ''' <summary>
    ''' 敌机
    ''' </summary>
    Enemy = 1
    ''' <summary>
    ''' 自机
    ''' </summary>
    Player = 2
    ''' <summary>
    ''' 自机子弹
    ''' </summary>
    PlayerBullet = 3
    ''' <summary>
    ''' 子机
    ''' </summary>
    PlayerOption = 4
    ''' <summary>
    ''' 自机符卡的子弹
    ''' </summary>
    Bomb = 5
    ''' <summary>
    ''' 掉落物
    ''' </summary>
    Item = 6
End Enum