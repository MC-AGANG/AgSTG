''' <summary>
''' 表示Boss的符卡<br/>
''' 此类只能作为继承类使用
''' </summary>
Public MustInherit Class SpellCard
    ''' <summary>
    ''' 获取或设置符卡是否正在运行
    ''' </summary>
    ''' <returns></returns>
    Public Property IsEnabled As Boolean = False
    ''' <summary>
    ''' 获取或设置符卡已运行时间
    ''' </summary>
    ''' <returns></returns>
    Public Property FrameCount As Long = 0
    ''' <summary>
    ''' 获取或设置符卡的所有者
    ''' </summary>
    ''' <returns></returns>
    Public Property Owner As Enemy.Boss
    ''' <summary>
    ''' 获取或设置符卡名称
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String
    ''' <summary>
    ''' 获取或设置符卡类型
    ''' </summary>
    ''' <returns></returns>
    Public Property Type As SpellType
    ''' <summary>
    ''' 获取或设置符卡是否拥有非符阶段
    ''' </summary>
    ''' <returns></returns>
    Public Property HaveUsual As Boolean
    ''' <summary>
    ''' 获取或设置符卡有几个阶段（不包括非符，时符无效）
    ''' </summary>
    Public Property StageCount As Byte
    ''' <summary>
    ''' 获取或设置符卡掉落物
    ''' </summary>
    ''' <returns></returns>
    Public Property Items As String
    ''' <summary>
    ''' 获取或设置非符血量
    ''' </summary>
    ''' <returns></returns>
    Public Property UsualHP As Double
    ''' <summary>
    ''' 获取或设置非符时间限制
    ''' </summary>
    ''' <returns></returns>
    Public Property UsualTime As Integer
    ''' <summary>
    ''' 获取或设置符卡血量
    ''' </summary>
    ''' <returns></returns>
    Public Property SpellHP As Double
    ''' <summary>
    ''' 获取或设置符卡时间限制
    ''' </summary>
    ''' <returns></returns>
    Public Property SpellTime As Integer
    ''' <summary>
    ''' 获取或设置击破符卡后的加分
    ''' </summary>
    ''' <returns></returns>
    Public Property Score As Long
    ''' <summary>
    ''' 获取或设置是否处于符卡阶段
    ''' </summary>
    ''' <returns></returns>
    Public Property AtSpell As Boolean = False
    ''' <summary>
    ''' 获取或设置符卡名用于展示
    ''' </summary>
    ''' <returns></returns>
    Public Property SpellName As ImageBrush
    Public StagePercent() As Double
    ''' <summary>
    ''' 控制符卡的行为<br/>
    ''' 所有符卡必须重写这个方法
    ''' </summary>
    Public Overridable Sub Render()
        STG.timerarea.Visibility = Visibility.Visible
        If FrameCount = 0 Then
            If Not HaveUsual Then
                AtSpell = True
                Owner.HP = SpellHP
            End If
        End If
        If AtSpell Then
            If FrameCount = 0 Then
                STG.SpellCardLabel.Show(SpellName)
                STG.bonusfail = False
            Else
                If STG.bonusfail = True Then
                    Score = 0
                End If
            End If
            If Score - 20 > 0 Then
                Score -= 20
            End If
            STG.UpdateTime(SpellTime - FrameCount)
            If FrameCount > SpellTime Then
                Owner.SpellFinish(False)
                STG.timerarea.Visibility = Visibility.Hidden
            End If
            STG.SpellCardLabel.Update(Score)
        Else
            STG.UpdateTime(UsualTime - FrameCount)
            If FrameCount > UsualTime Then
                Owner.SpellFinish(False)
                STG.timerarea.Visibility = Visibility.Hidden
            End If
        End If
    End Sub
    Public Sub New(Owner As Enemy.Boss)
        Me.Owner = Owner
    End Sub
    ''' <summary>
    ''' 符卡或非符阶段被击破
    ''' </summary>
    ''' <returns>是否要进入下一张符卡</returns>
    Public Overridable Function Break() As Boolean
        If Type = SpellType.None Then
            IsEnabled = False
            STG.timerarea.Visibility = Visibility.Hidden
            Return True
        Else
            If AtSpell Then
                IsEnabled = False
                STG.timerarea.Visibility = Visibility.Hidden
                Return True
            Else
                FrameCount = 0
                AtSpell = True
                Owner.HP = SpellHP
                Return False
            End If
        End If
    End Function
End Class
''' <summary>
''' 枚举符卡类型
''' </summary>
Public Enum SpellType As Byte
    ''' <summary>
    ''' 仅非符
    ''' </summary>
    None = 0
    ''' <summary>
    ''' 普通符卡
    ''' </summary>
    Life = 1
    ''' <summary>
    ''' 时符
    ''' </summary>
    Time = 2
End Enum