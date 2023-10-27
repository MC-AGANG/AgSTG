Imports System.IO
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports ResourcePack.TH17.My.Resources
Public Class Textures
    Public Shared st06a As ImageBrush
    Public Shared st06d As ImageBrush
    Public Shared st06f As ImageBrush
    Public Shared st05c00 As ImageBrush
    Public Shared st05b As ImageBrush
    Public Shared cdbg06b As ImageBrush
    Public Shared game_background As ImageBrush
    Public Shared boss(1, 5) As ImageBrush
    Public Shared st6enm(0, 2) As ImageBrush
    Public Shared st6s(6) As ImageBrush
    Public Shared Sub Load()
        st06a = New ImageBrush(B2I(MyResource.st06a))
        st06d = New ImageBrush(B2I(MyResource.st06d))
        st06f = New ImageBrush(B2I(MyResource.st06f))
        st05c00 = New ImageBrush(B2I(MyResource.stage05c00))
        st05b = New ImageBrush(B2I(MyResource.stage05b))
        game_background = New ImageBrush(B2I(MyResource.game_background))
        cdbg06b = New ImageBrush(B2I(MyResource.cdbg06b))
        For i = 0 To 5
            boss(0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss000" + CStr(i))))
        Next
        For i = 0 To 4
            boss(1, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss010" + CStr(i))))
        Next
        For i = 0 To 2
            st6enm(0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("st6e000" + CStr(i))))
        Next
        For i = 0 To 6
            st6s(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("st6s" + CStr(i))))
        Next
    End Sub
    Public Shared Function B2I(byteArray As Byte()) As BitmapImage
        Using stream As Stream = New MemoryStream(byteArray)
            Dim image As New BitmapImage()
            stream.Position = 0
            image.BeginInit()
            image.CacheOption = BitmapCacheOption.OnLoad
            image.StreamSource = stream
            image.EndInit()
            image.Freeze()
            Return image
        End Using
    End Function
End Class
Public Class Sounds
    Public Shared mu12 As New MediaPlayer
    Public Shared mu13 As New MediaPlayer
    Public Shared Sub Load()
        mu12.Open(New Uri(Environment.CurrentDirectory + "\audio\th17_12.mp3"))
        mu13.Open(New Uri(Environment.CurrentDirectory + "\audio\th17_13.mp3"))
        SetLoop()
    End Sub
    Public Shared Sub Loop12()
        mu12.Position = New TimeSpan(0, 0, 12)
    End Sub
    Public Shared Sub Loop13()
        mu12.Position = New TimeSpan(0, 0, 0, 22, 580)
    End Sub
    Public Shared Sub SetLoop()
        AddHandler mu12.MediaEnded, AddressOf Loop12
        AddHandler mu13.MediaEnded, AddressOf Loop13
    End Sub
    Public Shared Sub PlaySound(Sound As MediaPlayer, Optional Volume As Double = 1)
        Sound.Position = New TimeSpan(0)
        Sound.Volume = Volume
        Sound.Play()
    End Sub
End Class