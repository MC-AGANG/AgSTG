Imports System.IO

Public Class ReplayFile
    ''' <summary>
    ''' 获取或设置玩家机签
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String
    ''' <summary>
    ''' 获取或设置游戏难度
    ''' </summary>
    ''' <returns></returns>
    Public Property Difficulty As Integer
    ''' <summary>
    ''' 获取或设置玩家使用的角色
    ''' </summary>
    ''' <returns></returns>
    Public Property Character As Integer
    ''' <summary>
    ''' 包含这个回放文件中的所有关卡回放数据
    ''' </summary>
    Public Stages As New List(Of Replay)
    Public Sub New(difficulty As Integer, character As Integer, Optional name As String = "")
        Me.Difficulty = difficulty
        Me.Character = character
        Me.Name = name
    End Sub
    ''' <summary>
    ''' 从文件中读取回放文件
    ''' </summary>
    ''' <param name="Path">文件路径</param>
    Public Sub New(Path As String)
        Dim fs As New FileStream(Path, FileMode.Open)
        Dim reader As New BinaryReader(fs)
        Name = reader.ReadString
        Difficulty = reader.ReadInt32
        Character = reader.ReadInt32
        Do While fs.Position <= fs.Length - 1
            Dim stage As New Replay(reader.ReadDouble)
            For i = 1 To reader.ReadInt32
                stage.PropertyData.Add(reader.ReadInt64)
            Next
            For i = 1 To reader.ReadInt32
                stage.KeyData.Add(reader.ReadByte)
            Next
            Stages.Add(stage)
        Loop
        fs.Close
    End Sub
    ''' <summary>
    ''' 保存回放文件
    ''' </summary>
    ''' <param name="Path">储存路径</param>
    Public Sub Save(Path As String)
        Dim fs As New FileStream(Path, FileMode.Create)
        Dim writer As New BinaryWriter(fs)
        writer.Write(Name)
        writer.Write(Difficulty)
        writer.Write(Character)
        For Each stage In Stages
            writer.Write(stage.Seed)
            writer.Write(stage.PropertyData.Count)
            For Each d In stage.PropertyData
                writer.Write(d)
            Next
            writer.Write(stage.KeyData.Count)
            For Each d In stage.KeyData
                writer.Write(d)
            Next
        Next
        fs.Close()
    End Sub
End Class
