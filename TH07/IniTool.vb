Imports System.Runtime.InteropServices
Imports System.Text

Public Class IniTool
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetPrivateProfileString(
        ByVal lpAppName As String,
        ByVal lpKeyName As String,
        ByVal lpDefault As String,
        ByVal lpReturnedString As StringBuilder,
        ByVal nSize As Integer,
        ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function WritePrivateProfileString(
        ByVal lpAppName As String,
        ByVal lpKeyName As String,
        ByVal lpString As String,
        ByVal lpFileName As String) As Integer
    End Function

    ''' <summary>
    ''' 读取字符串值
    ''' </summary>
    ''' <param name="section">要读取的节</param>
    ''' <param name="key">要读取的关键词</param>
    ''' <param name="defaultValue">默认值</param>
    ''' <param name="filePath">文件路径</param>
    ''' <returns></returns>
    Public Shared Function ReadValue(section As String, key As String, defaultValue As String, filePath As String) As String
        Dim sb As New StringBuilder(65535)
        GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, filePath)
        Return sb.ToString()
    End Function

    ''' <summary>
    ''' 写入字符串值
    ''' </summary>
    ''' <param name="section">要写入的节</param>
    ''' <param name="key">要写入的关键词</param>
    ''' <param name="value">要写入的值</param>
    ''' <param name="filePath">文件路径</param>
    Public Shared Sub WriteValue(section As String, key As String, value As String, filePath As String)
        WritePrivateProfileString(section, key, value, filePath)
    End Sub
End Class