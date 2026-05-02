Imports System.IO
Imports System.Threading.Channels
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
    Public Shared bt_save(1) As ImageBrush

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
        bt_save(0) = New ImageBrush(B2I(MyResource.bt_save))
        bt_save(1) = New ImageBrush(B2I(MyResource.bt_save_b))

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
    Public Shared mu01 As Integer
    Public Shared mu02 As Integer
    Public Shared mu03 As Integer
    Public Shared mu04 As Integer
    Public Shared mu05 As Integer
    Public Shared mu06 As Integer
    Public Shared mu07 As Integer
    Public Shared mu08 As Integer
    Public Shared mu09 As Integer
    Public Shared mu10 As Integer
    Public Shared mu11 As Integer
    Public Shared mu12 As Integer
    Public Shared mu13 As Integer

    Public Shared lp01 As Double = 2.05
    Public Shared lp02 As Double = 20.085
    Public Shared lp03 As Double = 0
    Public Shared lp04 As Double = 120.25
    Public Shared lp05 As Double = 6.67
    Public Shared lp06 As Double = 15.705
    Public Shared lp07 As Double = 7.155
    Public Shared lp08 As Double = 30.23
    Public Shared lp09 As Double = 0.395
    Public Shared lp10 As Double = 10.665
    Public Shared lp11 As Double = 3.775
    Public Shared lp12 As Double = 0.459
    Public Shared lp13 As Double = 12.61

    Public Shared ep01 As Double = 89.005
    Public Shared ep02 As Double = 91.75
    Public Shared ep03 As Double = 67.8
    Public Shared ep04 As Double = 236
    Public Shared ep05 As Double = 46.125
    Public Shared ep06 As Double = 156
    Public Shared ep07 As Double = 91.665
    Public Shared ep08 As Double = 229.755
    Public Shared ep09 As Double = 107.855
    Public Shared ep10 As Double = 64
    Public Shared ep11 As Double = 85.875
    Public Shared ep12 As Double = 58.125
    Public Shared ep13 As Double = 335.415

    Public Shared ding As Integer
    Public Shared Sub Load()
        mu01 = Bass.CreateStream(MyResource.th07_01, 0, MyResource.th07_01.Length, BassFlags.Loop)
        mu02 = Bass.CreateStream(MyResource.th07_02, 0, MyResource.th07_02.Length, BassFlags.Loop)
        mu03 = Bass.CreateStream(MyResource.th07_03, 0, MyResource.th07_03.Length, BassFlags.Loop)
        mu04 = Bass.CreateStream(MyResource.th07_04, 0, MyResource.th07_04.Length, BassFlags.Loop)
        mu05 = Bass.CreateStream(MyResource.th07_05, 0, MyResource.th07_05.Length, BassFlags.Loop)
        mu06 = Bass.CreateStream(MyResource.th07_06, 0, MyResource.th07_06.Length, BassFlags.Loop)
        mu07 = Bass.CreateStream(MyResource.th07_07, 0, MyResource.th07_07.Length, BassFlags.Loop)
        mu08 = Bass.CreateStream(MyResource.th07_08, 0, MyResource.th07_08.Length, BassFlags.Loop)
        mu09 = Bass.CreateStream(MyResource.th07_09, 0, MyResource.th07_09.Length, BassFlags.Loop)
        mu10 = Bass.CreateStream(MyResource.th07_10, 0, MyResource.th07_10.Length, BassFlags.Loop)
        mu11 = Bass.CreateStream(MyResource.th07_11, 0, MyResource.th07_11.Length, BassFlags.Loop)
        mu12 = Bass.CreateStream(MyResource.th07_12, 0, MyResource.th07_12.Length, BassFlags.Loop)
        mu13 = Bass.CreateStream(MyResource.th07_13, 0, MyResource.th07_13.Length, BassFlags.Loop)

        Bass.ChannelSetSync(mu01, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu01, ep01), AddressOf Loop01, IntPtr.Zero)
        Bass.ChannelSetSync(mu02, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu02, ep02), AddressOf Loop02, IntPtr.Zero)
        Bass.ChannelSetSync(mu03, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu03, ep03), AddressOf Loop03, IntPtr.Zero)
        Bass.ChannelSetSync(mu04, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu04, ep04), AddressOf Loop04, IntPtr.Zero)
        Bass.ChannelSetSync(mu05, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu05, ep05), AddressOf Loop05, IntPtr.Zero)
        Bass.ChannelSetSync(mu06, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu06, ep06), AddressOf Loop06, IntPtr.Zero)
        Bass.ChannelSetSync(mu07, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu07, ep07), AddressOf Loop07, IntPtr.Zero)
        Bass.ChannelSetSync(mu08, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu08, ep08), AddressOf Loop08, IntPtr.Zero)
        Bass.ChannelSetSync(mu09, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu09, ep09), AddressOf Loop09, IntPtr.Zero)
        Bass.ChannelSetSync(mu10, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu10, ep10), AddressOf Loop10, IntPtr.Zero)
        Bass.ChannelSetSync(mu11, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu11, ep11), AddressOf Loop11, IntPtr.Zero)
        Bass.ChannelSetSync(mu12, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu12, ep12), AddressOf Loop12, IntPtr.Zero)
        Bass.ChannelSetSync(mu13, SyncFlags.Position, Bass.ChannelSeconds2Bytes(mu13, ep13), AddressOf Loop13, IntPtr.Zero)
        ding = Bass.CreateStream(MyResource.ding, 0, MyResource.ding.Length, BassFlags.Default)
    End Sub
    Public Shared Sub Loop01(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp01))
    End Sub
    Public Shared Sub Loop02(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp02))
    End Sub
    Public Shared Sub Loop03(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp03))
    End Sub
    Public Shared Sub Loop04(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp04))
    End Sub
    Public Shared Sub Loop05(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp05))
    End Sub
    Public Shared Sub Loop06(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp06))
    End Sub
    Public Shared Sub Loop07(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp07))
    End Sub
    Public Shared Sub Loop08(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp08))
    End Sub
    Public Shared Sub Loop09(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp09))
    End Sub
    Public Shared Sub Loop10(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp10))
    End Sub
    Public Shared Sub Loop11(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp11))
    End Sub
    Public Shared Sub Loop12(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp12))
    End Sub
    Public Shared Sub Loop13(handle As Integer, channel As Integer, data As Integer, user As IntPtr)
        Bass.ChannelSetPosition(channel, Bass.ChannelSeconds2Bytes(channel, lp13))
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