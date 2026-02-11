Imports System.IO
''' <summary>
''' 表示一个游戏回放文件
''' </summary>
Public Class Replay
    ''' <summary>
    ''' 获取或设置随机数种子
    ''' </summary>
    ''' <returns></returns>
    Public Property Seed As Double
    ''' <summary>
    ''' 包含回放中的所有按键数据
    ''' </summary>
    Public Data As New List(Of Byte)
    ''' <summary>
    ''' 创建新的空白回放
    ''' </summary>
    ''' <param name="seed">随机数种子</param>
    Public Sub New(seed As Double)
        Me.Seed = seed
    End Sub
    ''' <summary>
    ''' 从文件中读取回放文件
    ''' </summary>
    ''' <param name="Path">文件路径</param>
    Public Sub New(Path As String)
        Dim fs As New FileStream(Path, FileMode.Open)
        Dim reader As New BinaryReader(fs)
        Seed = reader.ReadDouble
        Do Until fs.Position <= fs.Length - 1
            Data.Add(reader.ReadByte)
        Loop
    End Sub
    ''' <summary>
    ''' 保存回放文件
    ''' </summary>
    ''' <param name="Path">储存路径</param>
    Public Sub Save(Path As String)
        Dim fs As New FileStream(Path, FileMode.Create)
        Dim writer As New BinaryWriter(fs)
        writer.Write(Seed)
        For Each d In Data
            writer.Write(d)
        Next
        fs.Close()
    End Sub
End Class
