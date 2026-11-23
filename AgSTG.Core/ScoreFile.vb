Imports System.IO
''' <summary>
''' 表示分数文件
''' </summary>
Public Class ScoreFile
    ''' <summary>
    ''' 获取或设置记录的分数排名
    ''' </summary>
    ''' <returns></returns>
    Public Results As New List(Of Ranking)
    ''' <summary>
    ''' 获取或设置保存时最多保存多少条分数
    ''' </summary>
    ''' <returns></returns>
    Public Property RankLimit As Integer = 10
    ''' <summary>
    ''' 获取或设置符卡记录
    ''' </summary>
    Public SpellCards As New List(Of SpellCardHistory)
    ''' <summary>
    ''' 创建空的分数记录
    ''' </summary>
    Public Sub New()

    End Sub
    ''' <summary>
    ''' 从现有文件读取分数记录
    ''' </summary>
    ''' <param name="Path">文件路径</param>
    Public Sub New(Path As String)
        Dim fs As New FileStream(Path, FileMode.Open)
        Dim reader As New BinaryReader(fs)
        RankLimit = reader.ReadInt32
        Dim rankcount As Integer = reader.ReadInt32 - 1
        For i = 0 To rankcount
            Dim rs As New Ranking
            Results.Add(rs)
            rs.Difficulty = reader.ReadInt32
            rs.Character = reader.ReadInt32
            For j = 0 To RankLimit - 1
                rs.Scores.Add(New ScoreData With {.PlayerName = reader.ReadString, .Score = reader.ReadInt64})
            Next
            rs.Sort()
            Do While fs.Position <= fs.Length - 1
                SpellCards.Add(New SpellCardHistory With {.ClassName = reader.ReadString, .SpellName = reader.ReadString, .Total = reader.ReadInt32, .Success = reader.ReadInt32})
            Loop
        Next
        fs.Close()
    End Sub
    ''' <summary>
    ''' 保存分数记录
    ''' </summary>
    ''' <param name="Path">文件路径</param>
    Public Sub Save(Path As String)
        Dim fs As New FileStream(Path, FileMode.Create)
        Dim writer As New BinaryWriter(fs)
        writer.Write(RankLimit)
        writer.Write(Results.Count)
        For Each rs In Results
            writer.Write(rs.Difficulty)
            writer.Write(rs.Character)
            For i = rs.Scores.Count To RankLimit - 1
                rs.Scores.Add(New ScoreData With {.PlayerName = "", .Score = 10000})
            Next
            rs.Sort()
            For i = 0 To RankLimit - 1
                writer.Write(rs.Scores(i).PlayerName)
                writer.Write(rs.Scores(i).Score)
            Next
        Next
        For Each sc In SpellCards
            writer.Write(sc.ClassName)
            writer.Write(sc.SpellName)
            writer.Write(sc.Total)
            writer.Write(sc.Success)
        Next
        fs.Close()
    End Sub
End Class
''' <summary>
''' 表示某个难度下某个特定机体的分数排名
''' </summary>
Public Class Ranking
    ''' <summary>
    ''' 获取或设置这个排名的难度
    ''' </summary>
    ''' <returns></returns>
    Public Property Difficulty As Integer
    ''' <summary>
    ''' 获取或设置这个排名的机体
    ''' </summary>
    ''' <returns></returns>
    Public Property Character As Integer
    ''' <summary>
    ''' 获取或设置这个排名中记录的分数
    ''' </summary>
    Public Scores As New List(Of ScoreData)
    ''' <summary>
    ''' 对记录进行排序
    ''' </summary>
    Public Sub Sort()
        Scores = Scores.OrderByDescending(Function(s) s.Score).ToList
    End Sub
End Class
''' <summary>
''' 表示单次游戏的分数
''' </summary>
Public Structure ScoreData
    ''' <summary>
    ''' 获取或设置玩家机签
    ''' </summary>
    Public Property PlayerName As String
    ''' <summary>
    ''' 获取或设置分数
    ''' </summary>
    Public Property Score As Long
End Structure
''' <summary>
''' 表示一个符卡的历史记录
''' </summary>
Public Structure SpellCardHistory
    ''' <summary>
    ''' 获取或设置符卡对应的类名
    ''' </summary>
    ''' <returns></returns>
    Public Property ClassName As String
    ''' <summary>
    ''' 获取或设置符卡名
    ''' </summary>
    ''' <returns></returns>
    Public Property SpellName As String
    ''' <summary>
    ''' 获取或设置这个符卡被尝试了多少次
    ''' </summary>
    ''' <returns></returns>
    Public Property Total As Integer
    ''' <summary>
    ''' 获取或设置这个符卡被收取了多少次
    ''' </summary>
    ''' <returns></returns>
    Public Property Success As Integer
End Structure