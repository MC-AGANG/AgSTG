Imports System.IO
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports ManagedBass
Imports ResourcePack.TH07.My.Resources
Public Class Textures
    Public Shared game_background As ImageBrush
    Public Shared boss(8, 16) As ImageBrush
    Public Shared illustrations(16)() As ImageBrush
    Public Shared stagetitle(8) As ImageBrush
    Public Shared bt_continue(1) As ImageBrush
    Public Shared bt_retry(1) As ImageBrush
    Public Shared bt_title(1) As ImageBrush
    Public Shared bt_start(1) As ImageBrush
    Public Shared bt_replay(1) As ImageBrush
    Public Shared bt_quit(1) As ImageBrush

    Public Shared title_bk As ImageBrush

    Public Shared st01a As ImageBrush
    Public Shared st01b As ImageBrush
    Public Shared st01c As ImageBrush
    Public Shared st02a As ImageBrush
    Public Shared st02b As ImageBrush
    Public Shared st02c As ImageBrush
    Public Shared st03a As ImageBrush
    Public Shared st03b As ImageBrush
    Public Shared st04a As ImageBrush
    Public Shared st04b As ImageBrush
    Public Shared st04c As ImageBrush
    Public Shared st04d As ImageBrush
    Public Shared st04e As ImageBrush
    Public Shared st04f As ImageBrush
    Public Shared st04g As ImageBrush
    Public Shared st05a As ImageBrush
    Public Shared st06a As ImageBrush
    Public Shared st06b As ImageBrush
    Public Shared st06c As ImageBrush

    Public Shared words(3) As ImageBrush
    Public Shared circle_blue As ImageBrush
    Public Shared circle_red As ImageBrush
    Public Shared circle_cyan As ImageBrush
    Public Shared circle_magenta As ImageBrush
    Public Shared Sub Load()
        game_background = New ImageBrush(B2I(MyResource.game_background))
        For i = 0 To 4
            boss(0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss000" + CStr(i))))
            boss(8, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss080" + CStr(i))))
        Next
        For i = 0 To 6
            boss(1, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss01" + i.ToString("D2"))))
        Next
        For i = 0 To 1
            boss(2, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss020" + CStr(i))))
        Next
        boss(3, 0) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss0300")))
        For i = 0 To 8
            boss(4, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss040" + CStr(i))))
            boss(7, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss070" + CStr(i))))
        Next
        For i = 0 To 3
            boss(5, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("boss050" + CStr(i))))
        Next

        Dim it0(0) As ImageBrush
        Dim it1(3) As ImageBrush
        Dim it2(3) As ImageBrush
        Dim it4(3) As ImageBrush
        Dim it5(1) As ImageBrush
        Dim it11(5) As ImageBrush
        Dim it12(5) As ImageBrush
        it0(0) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("illustration0000")))
        For i = 0 To 1
            it5(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("illustration050" + CStr(i))))
        Next
        For i = 0 To 3
            it1(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("illustration010" + CStr(i))))
            it2(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("illustration020" + CStr(i))))
            it4(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("illustration040" + CStr(i))))
        Next
        For i = 0 To 5
            it11(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("illustration110" + CStr(i))))
            it12(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("illustration120" + CStr(i))))
        Next
        illustrations(0) = it0
        illustrations(1) = it1
        illustrations(2) = it2
        illustrations(4) = it4
        illustrations(5) = it5
        illustrations(11) = it11
        illustrations(12) = it12

        bt_continue(0) = New ImageBrush(B2I(MyResource.bt_continue))
        bt_continue(1) = New ImageBrush(B2I(MyResource.bt_continue_b))
        bt_retry(0) = New ImageBrush(B2I(MyResource.bt_retry))
        bt_retry(1) = New ImageBrush(B2I(MyResource.bt_retry_b))
        bt_title(0) = New ImageBrush(B2I(MyResource.bt_title))
        bt_title(1) = New ImageBrush(B2I(MyResource.bt_title_b))
        bt_start(0) = New ImageBrush(B2I(MyResource.bt_start))
        bt_start(1) = New ImageBrush(B2I(MyResource.bt_start_b))
        bt_replay(0) = New ImageBrush(B2I(MyResource.bt_replay))
        bt_replay(1) = New ImageBrush(B2I(MyResource.bt_replay_b))
        bt_quit(0) = New ImageBrush(B2I(MyResource.bt_quit))
        bt_quit(1) = New ImageBrush(B2I(MyResource.bt_quit_b))

        title_bk = New ImageBrush(B2I(MyResource.title_bk00))

        st01a = New ImageBrush(B2I(MyResource.st01a))
        st01b = New ImageBrush(B2I(MyResource.st01b))
        st01c = New ImageBrush(B2I(MyResource.st01c))
        st02a = New ImageBrush(B2I(MyResource.st02a))
        st02b = New ImageBrush(B2I(MyResource.st02b))
        st02c = New ImageBrush(B2I(MyResource.st02c))
        st03a = New ImageBrush(B2I(MyResource.st03a))
        st03b = New ImageBrush(B2I(MyResource.st03b))
        st04a = New ImageBrush(B2I(MyResource.st04a))
        st04b = New ImageBrush(B2I(MyResource.st04b))
        st04c = New ImageBrush(B2I(MyResource.st04c))
        st04d = New ImageBrush(B2I(MyResource.st04d))
        st04e = New ImageBrush(B2I(MyResource.st04e))
        st04f = New ImageBrush(B2I(MyResource.st04f))
        st04g = New ImageBrush(B2I(MyResource.st04g))
        st05a = New ImageBrush(B2I(MyResource.st05a))
        st06a = New ImageBrush(B2I(MyResource.st06a))
        st06b = New ImageBrush(B2I(MyResource.st06b))
        st06c = New ImageBrush(B2I(MyResource.st06c))
        For i = 0 To 3
            words(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("words" + CStr(i))))
        Next

        circle_blue = New ImageBrush(B2I(MyResource.circle_blue))
        circle_red = New ImageBrush(B2I(MyResource.circle_red))
        circle_cyan = New ImageBrush(B2I(MyResource.circle_cyan))
        circle_magenta = New ImageBrush(B2I(MyResource.circle_magenta))
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
    Public Shared mu01 As New Integer
    Public Shared mu02 As New Integer
    Public Shared mu03 As New Integer
    Public Shared mu04 As New Integer
    Public Shared mu05 As New Integer
    Public Shared mu06 As New Integer
    Public Shared mu07 As New Integer
    Public Shared mu08 As New Integer
    Public Shared mu09 As New Integer
    Public Shared mu10 As New Integer
    Public Shared mu11 As New Integer
    Public Shared mu12 As New Integer
    Public Shared mu13 As New Integer

    Public Shared ding As New Integer
    Public Shared Sub Load()
        mu01 = Bass.CreateStream(MyResource.th07_01, 0, MyResource.th07_01.Length, BassFlags.Default)
        mu02 = Bass.CreateStream(MyResource.th07_02, 0, MyResource.th07_02.Length, BassFlags.Default)
        mu03 = Bass.CreateStream(MyResource.th07_03, 0, MyResource.th07_03.Length, BassFlags.Default)
        mu04 = Bass.CreateStream(MyResource.th07_04, 0, MyResource.th07_04.Length, BassFlags.Default)
        mu05 = Bass.CreateStream(MyResource.th07_05, 0, MyResource.th07_05.Length, BassFlags.Default)
        mu06 = Bass.CreateStream(MyResource.th07_06, 0, MyResource.th07_06.Length, BassFlags.Default)
        mu07 = Bass.CreateStream(MyResource.th07_07, 0, MyResource.th07_07.Length, BassFlags.Default)
        mu08 = Bass.CreateStream(MyResource.th07_08, 0, MyResource.th07_08.Length, BassFlags.Default)
        mu09 = Bass.CreateStream(MyResource.th07_09, 0, MyResource.th07_09.Length, BassFlags.Default)
        mu10 = Bass.CreateStream(MyResource.th07_10, 0, MyResource.th07_10.Length, BassFlags.Default)
        mu11 = Bass.CreateStream(MyResource.th07_11, 0, MyResource.th07_11.Length, BassFlags.Default)
        mu12 = Bass.CreateStream(MyResource.th07_12, 0, MyResource.th07_12.Length, BassFlags.Default)
        mu13 = Bass.CreateStream(MyResource.th07_13, 0, MyResource.th07_13.Length, BassFlags.Default)
        ding = Bass.CreateStream(MyResource.ding, 0, MyResource.ding.Length, BassFlags.Default)
    End Sub
    Public Shared Sub PlaySound(Sound As System.Windows.Media.MediaPlayer, Optional Volume As Double = 1)
        Sound.Position = New TimeSpan(0)
        Sound.Volume = Volume
        Sound.Play()
    End Sub
    ''' <summary>
    ''' 播放声音
    ''' </summary>
    ''' <param name="Sound">需要播放的声音</param>
    ''' <param name="Volume">音量大小，默认为100%</param>
    Public Shared Sub PlaySound(Sound As Integer, Optional Volume As Double = 1)
        Bass.ChannelSetAttribute(Sound, ChannelAttribute.Volume, Volume)
        Bass.ChannelPlay(Sound, True)
    End Sub
    Public Shared Sub StopSound(Sound As Integer)
        Bass.ChannelStop(Sound)
    End Sub
End Class

Public Class Texts
    Public Shared dialog0101a As StreamReader
    Public Shared dialog0101b As StreamReader
    Public Shared dialog0201a As StreamReader
    Public Shared dialog0201b As StreamReader
    Public Shared dialog0202a As StreamReader
    Public Shared dialog0202b As StreamReader
    Public Shared dialog0301a As StreamReader
    Public Shared dialog0301b As StreamReader
    Public Shared dialog0302a As StreamReader
    Public Shared dialog0302b As StreamReader
    Public Shared dialog0401a As StreamReader
    Public Shared dialog0401b As StreamReader
    Public Shared dialog0501a As StreamReader
    Public Shared dialog0501b As StreamReader
    Public Shared dialog0502a As StreamReader
    Public Shared dialog0502b As StreamReader
    Public Shared dialog0601a As StreamReader
    Public Shared dialog0601b As StreamReader
    Public Shared dialog0602a As StreamReader
    Public Shared dialog0602b As StreamReader
    Public Shared Sub Load()
        dialog0101a = New StreamReader(New MemoryStream(MyResource.dialog0101a))
        dialog0101b = New StreamReader(New MemoryStream(MyResource.dialog0101b))
        dialog0201a = New StreamReader(New MemoryStream(MyResource.dialog0201a))
        dialog0201b = New StreamReader(New MemoryStream(MyResource.dialog0201b))
        dialog0202a = New StreamReader(New MemoryStream(MyResource.dialog0202a))
        dialog0202b = New StreamReader(New MemoryStream(MyResource.dialog0202b))
        dialog0301a = New StreamReader(New MemoryStream(MyResource.dialog0301a))
        dialog0301b = New StreamReader(New MemoryStream(MyResource.dialog0301b))
        dialog0302a = New StreamReader(New MemoryStream(MyResource.dialog0302a))
        dialog0302b = New StreamReader(New MemoryStream(MyResource.dialog0302b))
        dialog0401a = New StreamReader(New MemoryStream(MyResource.dialog0401a))
        dialog0401b = New StreamReader(New MemoryStream(MyResource.dialog0401b))
        dialog0501a = New StreamReader(New MemoryStream(MyResource.dialog0501a))
        dialog0501b = New StreamReader(New MemoryStream(MyResource.dialog0501b))
        dialog0502a = New StreamReader(New MemoryStream(MyResource.dialog0502a))
        dialog0502b = New StreamReader(New MemoryStream(MyResource.dialog0502b))
        dialog0601a = New StreamReader(New MemoryStream(MyResource.dialog0601a))
        dialog0601b = New StreamReader(New MemoryStream(MyResource.dialog0601b))
        dialog0602a = New StreamReader(New MemoryStream(MyResource.dialog0602a))
        dialog0602b = New StreamReader(New MemoryStream(MyResource.dialog0602b))
    End Sub
End Class
