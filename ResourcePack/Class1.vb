Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports ResourcePack.My.Resources
Imports System.IO

Public Class Textures

    Public Shared number(4, 14) As ImageBrush

    Public Shared bullet(18, 15) As ImageBrush

    Public Shared bulletbreak(15, 7) As ImageBrush
    Public Shared bulletin(15) As ImageBrush
    Public Shared deadcircle As ImageBrush
    Public Shared magicsquare As ImageBrush
    Public Shared graze(3) As ImageBrush
    Public Shared spellattack As ImageBrush
    Public Shared hpbar(2) As ImageBrush
    Public Shared cardlabelbg As ImageBrush
    Public Shared bonusfailed As ImageBrush
    Public Shared getbonus As ImageBrush
    Public Shared labelfailed As ImageBrush

    Public Shared icon_hiscore As ImageBrush
    Public Shared icon_score As ImageBrush
    Public Shared icon_life As ImageBrush
    Public Shared icon_lifepiece As ImageBrush
    Public Shared icon_spellcard As ImageBrush
    Public Shared icon_spellcardpiece As ImageBrush
    Public Shared icon_power As ImageBrush
    Public Shared icon_pointvalue As ImageBrush
    Public Shared icon_graze As ImageBrush
    Public Shared life_icon(5) As ImageBrush
    Public Shared spell_icon(5) As ImageBrush

    Public Shared enemy(6, 7, 11) As ImageBrush

    Public Shared item_number(2, 9) As ImageBrush
    Public Shared item_point As ImageBrush
    Public Shared item_point_u As ImageBrush
    Public Shared item_power As ImageBrush
    Public Shared item_power_u As ImageBrush
    Public Shared item_bigpower As ImageBrush
    Public Shared item_bigpower_u As ImageBrush
    Public Shared item_life As ImageBrush
    Public Shared item_life_u As ImageBrush
    Public Shared item_lifepiece As ImageBrush
    Public Shared item_lifepiece_u As ImageBrush
    Public Shared item_spell As ImageBrush
    Public Shared item_spell_u As ImageBrush
    Public Shared item_spellpiece As ImageBrush
    Public Shared item_spellpiece_u As ImageBrush
    Public Shared item_pointvalue As ImageBrush
    Public Shared item_powerup As ImageBrush

    Public Shared player_hitbox As ImageBrush
    Public Shared player(1, 2, 7) As ImageBrush
    Public Shared player_bullet(1, 3, 9) As ImageBrush
    Public Shared player_option(1) As ImageBrush
    Public Shared Sub Load()

        For i = 0 To 3
            For j = 0 To 14
                number(i, j) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("number_big" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next
        For i = 0 To 10
            number(4, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("number_small00" + i.ToString("D2"))))
        Next

        For i = 0 To 10
            For j = 0 To 15
                bullet(i, j) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("bullet" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next
        For i = 11 To 18
            For j = 0 To 7
                bullet(i, j) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("bullet" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next

        For i = 0 To 15
            For j = 0 To 7
                bulletbreak(i, j) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("bulletbreak" + Color16to8(i).ToString("D1") + j.ToString("D1"))))
            Next
        Next
        For i = 0 To 15
            bulletin(i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("bulletin10" + Color16to8(i).ToString("D1"))))
        Next
        deadcircle = New ImageBrush(b2i(MyResource.deadcircle))
        magicsquare = New ImageBrush(b2i(MyResource.magicsquare))
        For i = 0 To 3
            graze(i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("graze" + i.ToString("D1"))))
        Next
        spellattack = New ImageBrush(b2i(MyResource.spellattack))
        For i = 0 To 2
            hpbar(i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("hpbar" + i.ToString("D1"))))
        Next
        hpbar(1).Stretch = Stretch.None
        hpbar(1).AlignmentX = AlignmentX.Left
        hpbar(1).AlignmentY = AlignmentY.Top
        cardlabelbg = New ImageBrush(b2i(MyResource.cardlabel))
        bonusfailed = New ImageBrush(b2i(MyResource.bonusfailed))
        getbonus = New ImageBrush(b2i(MyResource.getbonus))
        labelfailed = New ImageBrush(b2i(MyResource.failed))

        icon_hiscore = New ImageBrush(b2i(MyResource.icon_hiscore))
        icon_score = New ImageBrush(b2i(MyResource.icon_score))
        icon_life = New ImageBrush(b2i(MyResource.icon_life))
        icon_lifepiece = New ImageBrush(b2i(MyResource.icon_lifepiece))
        icon_spellcard = New ImageBrush(b2i(MyResource.icon_spellcard))
        icon_spellcardpiece = New ImageBrush(b2i(MyResource.icon_spellcardpiece))
        icon_power = New ImageBrush(b2i(MyResource.icon_power))
        icon_pointvalue = New ImageBrush(b2i(MyResource.icon_pointvalue))
        icon_graze = New ImageBrush(b2i(MyResource.icon_graze))
        For i = 0 To 5
            life_icon(i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("life_i" + i.ToString("D1"))))
        Next
        For i = 0 To 5
            spell_icon(i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("spell_i" + i.ToString("D1"))))
        Next

        For i = 0 To 3
            enemy(0, i, 0) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e00" + i.ToString("D2") + "00")))
            enemy(0, i, 1) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e00" + i.ToString("D2") + "01")))
        Next
        For i = 0 To 7
            For j = 0 To 11
                enemy(1, i, j) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e01" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next
        For i = 0 To 11
            enemy(2, 0, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e0200" + i.ToString("D2"))))
            enemy(2, 1, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e0201" + i.ToString("D2"))))
            enemy(3, 0, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e0300" + i.ToString("D2"))))
            enemy(3, 1, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e0301" + i.ToString("D2"))))
            enemy(4, 0, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e0400" + i.ToString("D2"))))
            enemy(4, 1, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e0401" + i.ToString("D2"))))
        Next
        For i = 0 To 3
            For j = 0 To 7
                enemy(5, i, j) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e05" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next
        For i = 0 To 3
            enemy(6, 0, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("e0600" + i.ToString("D2"))))
        Next

        For i = 0 To 9
            item_number(0, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("item_" + CStr(i))))
            item_number(1, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("item_y" + CStr(i))))
            item_number(2, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("item_r" + CStr(i))))
        Next
        item_point = New ImageBrush(b2i(MyResource.item_point))
        item_point_u = New ImageBrush(b2i(MyResource.item_point_u))
        item_power = New ImageBrush(b2i(MyResource.item_power))
        item_power_u = New ImageBrush(b2i(MyResource.item_power_u))
        item_bigpower = New ImageBrush(b2i(MyResource.item_bigpower))
        item_bigpower_u = New ImageBrush(b2i(MyResource.item_bigpower_u))
        item_life = New ImageBrush(b2i(MyResource.item_life))
        item_life_u = New ImageBrush(b2i(MyResource.item_life_u))
        item_lifepiece = New ImageBrush(b2i(MyResource.item_lifepiece))
        item_lifepiece_u = New ImageBrush(b2i(MyResource.item_lifepiece_u))
        item_spell = New ImageBrush(b2i(MyResource.item_spell))
        item_spell_u = New ImageBrush(b2i(MyResource.item_spell_u))
        item_spellpiece = New ImageBrush(b2i(MyResource.item_spellpiece))
        item_spellpiece_u = New ImageBrush(b2i(MyResource.item_spellpiece_u))
        item_pointvalue = New ImageBrush(b2i(MyResource.item_pointvalue))
        item_powerup = New ImageBrush(b2i(MyResource.item_powerup))

        player_hitbox = New ImageBrush(b2i(MyResource.player_hitbox))
        For i = 0 To 2
            For j = 0 To 7
                player(0, i, j) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("pl0" + CStr(i) + CStr(j))))
                player(1, i, j) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("pl1" + CStr(i) + CStr(j))))
            Next
        Next
        For i = 0 To 5
            player_bullet(0, 0, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("plbullet00" + CStr(i))))
        Next
        For i = 0 To 3
            player_bullet(0, 1, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("plbullet01" + CStr(i))))
        Next
        For i = 0 To 1
            player_bullet(0, 2, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("plbullet02" + CStr(i))))
        Next
        For i = 0 To 2
            player_bullet(0, 3, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("plbullet03" + CStr(i))))
        Next
        For i = 0 To 3
            player_bullet(1, 0, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("plbullet10" + CStr(i))))
        Next
        For i = 0 To 8
            player_bullet(1, 1, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("plbullet11" + CStr(i))))
        Next
        For i = 0 To 9
            player_bullet(1, 2, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("plbullet12" + CStr(i))))
        Next
        For i = 0 To 1
            player_bullet(1, 3, i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("plbullet13" + CStr(i))))
        Next
        For i = 0 To 1
            player_option(i) = New ImageBrush(b2i(MyResource.ResourceManager.GetObject("pl" + CStr(i) + "_option")))
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

    Public Shared Function Color16to8(input As Byte) As Byte
        Select Case input
            Case 0
                Return 0
            Case 1 To 13
                Return input \ 2
            Case 14
                Return 6
            Case Else
                Return 7
        End Select
    End Function
End Class

Public Class Sounds
    Public Shared big As New MediaPlayer
    Public Shared bonus As New MediaPlayer
    ''' <summary>
    ''' 符卡掉落
    ''' </summary>
    Public Shared bonus2 As New MediaPlayer
    ''' <summary>
    ''' 残机掉落
    ''' </summary>
    Public Shared bonus4 As New MediaPlayer
    ''' <summary>
    ''' 进入游戏
    ''' </summary>
    Public Shared boon00 As New MediaPlayer
    Public Shared boon01 As New MediaPlayer
    ''' <summary>
    ''' 取消
    ''' </summary>
    Public Shared cancel00 As New MediaPlayer
    Public Shared cardget As New MediaPlayer
    Public Shared cat00 As New MediaPlayer
    Public Shared ch00 As New MediaPlayer
    Public Shared ch01 As New MediaPlayer
    Public Shared ch02 As New MediaPlayer
    Public Shared ch03 As New MediaPlayer
    Public Shared changeitem As New MediaPlayer
    Public Shared damage00 As New MediaPlayer
    Public Shared damage01 As New MediaPlayer
    Public Shared don00 As New MediaPlayer
    Public Shared enep00 As New MediaPlayer
    Public Shared enep01 As New MediaPlayer
    Public Shared enep02 As New MediaPlayer
    Public Shared etbreak As New MediaPlayer
    Public Shared extend As New MediaPlayer
    Public Shared extend2 As New MediaPlayer
    Public Shared fault As New MediaPlayer
    Public Shared graze As New MediaPlayer
    Public Shared gun00 As New MediaPlayer
    Public Shared heal As New MediaPlayer
    Public Shared invalid As New MediaPlayer
    Public Shared item00 As New MediaPlayer
    Public Shared item01 As New MediaPlayer
    Public Shared kira00 As New MediaPlayer
    Public Shared kira01 As New MediaPlayer
    Public Shared kira02 As New MediaPlayer
    Public Shared lazer00 As New MediaPlayer
    Public Shared lazer01 As New MediaPlayer
    Public Shared lazer02 As New MediaPlayer
    Public Shared lgods1 As New MediaPlayer
    Public Shared lgods2 As New MediaPlayer
    Public Shared lgods3 As New MediaPlayer
    Public Shared lgods4 As New MediaPlayer
    Public Shared lgodsget As New MediaPlayer
    Public Shared msl As New MediaPlayer
    Public Shared msl2 As New MediaPlayer
    Public Shared msl3 As New MediaPlayer
    Public Shared nep00 As New MediaPlayer
    Public Shared nodamage As New MediaPlayer
    Public Shared noise As New MediaPlayer
    Public Shared ok00 As New MediaPlayer
    Public Shared pause As New MediaPlayer
    Public Shared pin00 As New MediaPlayer
    Public Shared pin01 As New MediaPlayer
    Public Shared pldead00 As New MediaPlayer
    Public Shared pldead01 As New MediaPlayer
    Public Shared plst00 As New MediaPlayer
    Public Shared power0 As New MediaPlayer
    Public Shared power1 As New MediaPlayer
    Public Shared powerup As New MediaPlayer
    Public Shared release As New MediaPlayer
    Public Shared select00 As New MediaPlayer
    Public Shared slash As New MediaPlayer
    Public Shared tan00 As New MediaPlayer
    Public Shared tan01 As New MediaPlayer
    Public Shared tan02 As New MediaPlayer
    Public Shared tan03 As New MediaPlayer
    Public Shared timeout As New MediaPlayer
    Public Shared timeout2 As New MediaPlayer
    Public Shared trophy As New MediaPlayer
    Public Shared wolf As New MediaPlayer
    Public Shared Sub Load()
        big.Open(New Uri(Environment.CurrentDirectory + "\audio\se_big.wav"))
        bonus.Open(New Uri(Environment.CurrentDirectory + "\audio\se_bonus.wav"))
        bonus2.Open(New Uri(Environment.CurrentDirectory + "\audio\se_bonus2.wav"))
        bonus4.Open(New Uri(Environment.CurrentDirectory + "\audio\se_bonus4.wav"))
        boon00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_boon00.wav"))
        boon01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_boon01.wav"))
        cancel00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_cancel00.wav"))
        cardget.Open(New Uri(Environment.CurrentDirectory + "\audio\se_cardget.wav"))
        cat00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_cat00.wav"))
        ch00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_ch00.wav"))
        ch01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_ch01.wav"))
        ch02.Open(New Uri(Environment.CurrentDirectory + "\audio\se_ch02.wav"))
        ch03.Open(New Uri(Environment.CurrentDirectory + "\audio\se_ch03.wav"))
        changeitem.Open(New Uri(Environment.CurrentDirectory + "\audio\se_changeitem.wav"))
        damage00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_damage00.wav"))
        damage01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_damage01.wav"))
        don00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_don00.wav"))
        enep00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_enep00.wav"))
        enep01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_enep01.wav"))
        enep02.Open(New Uri(Environment.CurrentDirectory + "\audio\se_enep02.wav"))
        etbreak.Open(New Uri(Environment.CurrentDirectory + "\audio\se_etbreak.wav"))
        extend.Open(New Uri(Environment.CurrentDirectory + "\audio\se_extend.wav"))
        extend2.Open(New Uri(Environment.CurrentDirectory + "\audio\se_extend2.wav"))
        fault.Open(New Uri(Environment.CurrentDirectory + "\audio\se_fault.wav"))
        graze.Open(New Uri(Environment.CurrentDirectory + "\audio\se_graze.wav"))
        gun00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_gun00.wav"))
        heal.Open(New Uri(Environment.CurrentDirectory + "\audio\se_heal.wav"))
        invalid.Open(New Uri(Environment.CurrentDirectory + "\audio\se_invalid.wav"))
        item00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_item00.wav"))
        item01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_item01.wav"))
        kira00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_kira00.wav"))
        kira01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_kira01.wav"))
        kira02.Open(New Uri(Environment.CurrentDirectory + "\audio\se_kira02.wav"))
        lazer00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_lazer00.wav"))
        lazer01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_lazer01.wav"))
        lazer02.Open(New Uri(Environment.CurrentDirectory + "\audio\se_lazer02.wav"))
        lgods1.Open(New Uri(Environment.CurrentDirectory + "\audio\se_lgods1.wav"))
        lgods2.Open(New Uri(Environment.CurrentDirectory + "\audio\se_lgods2.wav"))
        lgods3.Open(New Uri(Environment.CurrentDirectory + "\audio\se_lgods3.wav"))
        lgods4.Open(New Uri(Environment.CurrentDirectory + "\audio\se_lgods4.wav"))
        lgodsget.Open(New Uri(Environment.CurrentDirectory + "\audio\se_lgodsget.wav"))
        msl.Open(New Uri(Environment.CurrentDirectory + "\audio\se_msl.wav"))
        msl2.Open(New Uri(Environment.CurrentDirectory + "\audio\se_msl2.wav"))
        msl3.Open(New Uri(Environment.CurrentDirectory + "\audio\se_msl3.wav"))
        nep00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_nep00.wav"))
        nodamage.Open(New Uri(Environment.CurrentDirectory + "\audio\se_nodamage.wav"))
        noise.Open(New Uri(Environment.CurrentDirectory + "\audio\se_noise.wav"))
        ok00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_ok00.wav"))
        pause.Open(New Uri(Environment.CurrentDirectory + "\audio\se_pause.wav"))
        pin00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_pin00.wav"))
        pin01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_pin01.wav"))
        pldead00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_pldead00.wav"))
        pldead01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_pldead01.wav"))
        plst00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_plst00.wav"))
        power0.Open(New Uri(Environment.CurrentDirectory + "\audio\se_power0.wav"))
        power1.Open(New Uri(Environment.CurrentDirectory + "\audio\se_power1.wav"))
        powerup.Open(New Uri(Environment.CurrentDirectory + "\audio\se_powerup.wav"))
        release.Open(New Uri(Environment.CurrentDirectory + "\audio\se_release.wav"))
        select00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_select00.wav"))
        slash.Open(New Uri(Environment.CurrentDirectory + "\audio\se_slash.wav"))
        tan00.Open(New Uri(Environment.CurrentDirectory + "\audio\se_tan00.wav"))
        tan01.Open(New Uri(Environment.CurrentDirectory + "\audio\se_tan01.wav"))
        tan02.Open(New Uri(Environment.CurrentDirectory + "\audio\se_tan02.wav"))
        tan03.Open(New Uri(Environment.CurrentDirectory + "\audio\se_tan03.wav"))
        timeout.Open(New Uri(Environment.CurrentDirectory + "\audio\se_timeout.wav"))
        timeout2.Open(New Uri(Environment.CurrentDirectory + "\audio\se_timeout2.wav"))
        trophy.Open(New Uri(Environment.CurrentDirectory + "\audio\se_trophy.wav"))
        wolf.Open(New Uri(Environment.CurrentDirectory + "\audio\se_wolf.wav"))
    End Sub
    ''' <summary>
    ''' 播放声音
    ''' </summary>
    ''' <param name="Sound">需要播放的声音</param>
    ''' <param name="Volume">音量大小，默认为100%</param>
    Public Shared Sub PlaySound(Sound As MediaPlayer, Optional Volume As Double = 1)
        Sound.Position = New TimeSpan(0)
        Sound.Volume = Volume
        Sound.Play()
    End Sub

End Class
