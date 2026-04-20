Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports ResourcePack.My.Resources
Imports System.IO
Imports ManagedBass
Public Class Textures

    Public Shared number(4, 14) As ImageBrush

    Public Shared bullet(20, 15) As ImageBrush

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

    Public Shared particle_cherry As ImageBrush
    Public Shared particle_snow As ImageBrush

    Public Shared enemyspell As ImageBrush

    Public Shared Sub Load()

        For i = 0 To 3
            For j = 0 To 14
                number(i, j) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("number_big" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next
        For i = 0 To 10
            number(4, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("number_small00" + i.ToString("D2"))))
        Next

        For i = 0 To 10
            For j = 0 To 15
                bullet(i, j) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("bullet" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next
        For j = 0 To 15
            bullet(19, j) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("bullet19" + j.ToString("D2"))))
        Next
        For i = 11 To 18
            For j = 0 To 7
                bullet(i, j) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("bullet" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next
        For i = 0 To 3
            bullet(20, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("bullet20" + i.ToString("D2"))))
        Next
        For i = 0 To 15
            For j = 0 To 7
                bulletbreak(i, j) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("bulletbreak" + Color16to8(i).ToString("D1") + j.ToString("D1"))))
            Next
        Next
        For i = 0 To 15
            bulletin(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("bulletin10" + Color16to8(i).ToString("D1"))))
        Next
        deadcircle = New ImageBrush(B2I(MyResource.deadcircle))
        magicsquare = New ImageBrush(B2I(MyResource.magicsquare))
        For i = 0 To 3
            graze(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("graze" + i.ToString("D1"))))
        Next
        spellattack = New ImageBrush(B2I(MyResource.spellattack))
        For i = 0 To 2
            hpbar(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("hpbar" + i.ToString("D1"))))
        Next
        hpbar(1).Stretch = Stretch.None
        hpbar(1).AlignmentX = AlignmentX.Left
        hpbar(1).AlignmentY = AlignmentY.Top
        cardlabelbg = New ImageBrush(B2I(MyResource.cardlabel))
        bonusfailed = New ImageBrush(B2I(MyResource.bonusfailed))
        getbonus = New ImageBrush(B2I(MyResource.getbonus))
        labelfailed = New ImageBrush(B2I(MyResource.failed))

        icon_hiscore = New ImageBrush(B2I(MyResource.icon_hiscore))
        icon_score = New ImageBrush(B2I(MyResource.icon_score))
        icon_life = New ImageBrush(B2I(MyResource.icon_life))
        icon_lifepiece = New ImageBrush(B2I(MyResource.icon_lifepiece))
        icon_spellcard = New ImageBrush(B2I(MyResource.icon_spellcard))
        icon_spellcardpiece = New ImageBrush(B2I(MyResource.icon_spellcardpiece))
        icon_power = New ImageBrush(B2I(MyResource.icon_power))
        icon_pointvalue = New ImageBrush(B2I(MyResource.icon_pointvalue))
        icon_graze = New ImageBrush(B2I(MyResource.icon_graze))
        For i = 0 To 5
            life_icon(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("life_i" + i.ToString("D1"))))
        Next
        For i = 0 To 5
            spell_icon(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("spell_i" + i.ToString("D1"))))
        Next

        For i = 0 To 3
            enemy(0, i, 0) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e00" + i.ToString("D2") + "00")))
            enemy(0, i, 1) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e00" + i.ToString("D2") + "01")))
        Next
        For i = 0 To 7
            For j = 0 To 11
                enemy(1, i, j) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e01" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next
        For i = 0 To 11
            enemy(2, 0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e0200" + i.ToString("D2"))))
            enemy(2, 1, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e0201" + i.ToString("D2"))))
            enemy(3, 0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e0300" + i.ToString("D2"))))
            enemy(3, 1, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e0301" + i.ToString("D2"))))
            enemy(4, 0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e0400" + i.ToString("D2"))))
            enemy(4, 1, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e0401" + i.ToString("D2"))))
        Next
        For i = 0 To 3
            For j = 0 To 7
                enemy(5, i, j) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e05" + i.ToString("D2") + j.ToString("D2"))))
            Next
        Next
        For i = 0 To 3
            enemy(6, 0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("e0600" + i.ToString("D2"))))
        Next

        For i = 0 To 9
            item_number(0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("item_" + CStr(i))))
            item_number(1, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("item_y" + CStr(i))))
            item_number(2, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("item_r" + CStr(i))))
        Next
        item_point = New ImageBrush(B2I(MyResource.item_point))
        item_point_u = New ImageBrush(B2I(MyResource.item_point_u))
        item_power = New ImageBrush(B2I(MyResource.item_power))
        item_power_u = New ImageBrush(B2I(MyResource.item_power_u))
        item_bigpower = New ImageBrush(B2I(MyResource.item_bigpower))
        item_bigpower_u = New ImageBrush(B2I(MyResource.item_bigpower_u))
        item_life = New ImageBrush(B2I(MyResource.item_life))
        item_life_u = New ImageBrush(B2I(MyResource.item_life_u))
        item_lifepiece = New ImageBrush(B2I(MyResource.item_lifepiece))
        item_lifepiece_u = New ImageBrush(B2I(MyResource.item_lifepiece_u))
        item_spell = New ImageBrush(B2I(MyResource.item_spell))
        item_spell_u = New ImageBrush(B2I(MyResource.item_spell_u))
        item_spellpiece = New ImageBrush(B2I(MyResource.item_spellpiece))
        item_spellpiece_u = New ImageBrush(B2I(MyResource.item_spellpiece_u))
        item_pointvalue = New ImageBrush(B2I(MyResource.item_pointvalue))
        item_powerup = New ImageBrush(B2I(MyResource.item_powerup))

        player_hitbox = New ImageBrush(B2I(MyResource.player_hitbox))
        For i = 0 To 2
            For j = 0 To 7
                player(0, i, j) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("pl0" + CStr(i) + CStr(j))))
                player(1, i, j) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("pl1" + CStr(i) + CStr(j))))
            Next
        Next
        For i = 0 To 5
            player_bullet(0, 0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("plbullet00" + CStr(i))))
        Next
        For i = 0 To 3
            player_bullet(0, 1, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("plbullet01" + CStr(i))))
        Next
        For i = 0 To 1
            player_bullet(0, 2, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("plbullet02" + CStr(i))))
        Next
        For i = 0 To 2
            player_bullet(0, 3, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("plbullet03" + CStr(i))))
        Next
        For i = 0 To 3
            player_bullet(1, 0, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("plbullet10" + CStr(i))))
        Next
        For i = 0 To 8
            player_bullet(1, 1, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("plbullet11" + CStr(i))))
        Next
        For i = 0 To 9
            player_bullet(1, 2, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("plbullet12" + CStr(i))))
        Next
        For i = 0 To 1
            player_bullet(1, 3, i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("plbullet13" + CStr(i))))
        Next
        For i = 0 To 1
            player_option(i) = New ImageBrush(B2I(MyResource.ResourceManager.GetObject("pl" + CStr(i) + "_option")))
        Next
        particle_cherry = New ImageBrush(B2I(MyResource.cherry))
        particle_snow = New ImageBrush(B2I(MyResource.snow))

        enemyspell = New ImageBrush(B2I(MyResource.enemyspell))
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
    Public Shared big As Integer
    Public Shared bonus As Integer
    Public Shared bonus2 As Integer
    Public Shared bonus4 As Integer
    Public Shared boon00 As Integer
    Public Shared boon01 As Integer
    Public Shared cancel00 As Integer
    Public Shared cardget As Integer
    Public Shared cat00 As Integer
    Public Shared ch00 As Integer
    Public Shared ch01 As Integer
    Public Shared ch02 As Integer
    Public Shared ch03 As Integer
    Public Shared changeitem As Integer
    Public Shared damage00 As Integer
    Public Shared damage01 As Integer
    Public Shared don00 As Integer
    Public Shared enep00 As Integer
    Public Shared enep01 As Integer
    Public Shared enep02 As Integer
    Public Shared etbreak As Integer
    Public Shared extend As Integer
    Public Shared extend2 As Integer
    Public Shared fault As Integer
    Public Shared graze As Integer
    Public Shared gun00 As Integer
    Public Shared heal As Integer
    Public Shared invalid As Integer
    Public Shared item00 As Integer
    Public Shared item01 As Integer
    Public Shared kira00 As Integer
    Public Shared kira01 As Integer
    Public Shared kira02 As Integer
    Public Shared lazer00 As Integer
    Public Shared lazer01 As Integer
    Public Shared lazer02 As Integer
    Public Shared lgods1 As Integer
    Public Shared lgods2 As Integer
    Public Shared lgods3 As Integer
    Public Shared lgods4 As Integer
    Public Shared lgodsget As Integer
    Public Shared msl As Integer
    Public Shared msl2 As Integer
    Public Shared msl3 As Integer
    Public Shared nep00 As Integer
    Public Shared nodamage As Integer
    Public Shared noise As Integer
    Public Shared ok00 As Integer
    Public Shared pause As Integer
    Public Shared pin00 As Integer
    Public Shared pin01 As Integer
    Public Shared pldead00 As Integer
    Public Shared pldead01 As Integer
    Public Shared plst00 As Integer
    Public Shared power0 As Integer
    Public Shared power1 As Integer
    Public Shared powerup As Integer
    Public Shared release As Integer
    Public Shared select00 As Integer
    Public Shared slash As Integer
    Public Shared tan00 As Integer
    Public Shared tan01 As Integer
    Public Shared tan02 As Integer
    Public Shared tan03 As Integer
    Public Shared timeout As Integer
    Public Shared timeout2 As Integer
    Public Shared trophy As Integer
    Public Shared wolf As Integer
    Public Shared Sounds_Playing As New List(Of Integer)
    Public Shared Sub Load()
        Bass.Init()
        big = Bass.CreateStream(MyResource.se_big, 0, MyResource.se_big.Length, BassFlags.Default)
        bonus = Bass.CreateStream(MyResource.se_bonus, 0, MyResource.se_bonus.Length, BassFlags.Default)
        bonus2 = Bass.CreateStream(MyResource.se_bonus2, 0, MyResource.se_bonus2.Length, BassFlags.Default)
        bonus4 = Bass.CreateStream(MyResource.se_bonus4, 0, MyResource.se_bonus4.Length, BassFlags.Default)
        boon00 = Bass.CreateStream(MyResource.se_boon00, 0, MyResource.se_boon00.Length, BassFlags.Default)
        boon01 = Bass.CreateStream(MyResource.se_boon01, 0, MyResource.se_boon01.Length, BassFlags.Default)
        cancel00 = Bass.CreateStream(MyResource.se_cancel00, 0, MyResource.se_cancel00.Length, BassFlags.Default)
        cardget = Bass.CreateStream(MyResource.se_cardget, 0, MyResource.se_cardget.Length, BassFlags.Default)
        cat00 = Bass.CreateStream(MyResource.se_cat00, 0, MyResource.se_cat00.Length, BassFlags.Default)
        ch00 = Bass.CreateStream(MyResource.se_ch00, 0, MyResource.se_ch00.Length, BassFlags.Default)
        ch01 = Bass.CreateStream(MyResource.se_ch01, 0, MyResource.se_ch01.Length, BassFlags.Default)
        ch02 = Bass.CreateStream(MyResource.se_ch02, 0, MyResource.se_ch02.Length, BassFlags.Default)
        ch03 = Bass.CreateStream(MyResource.se_ch03, 0, MyResource.se_ch03.Length, BassFlags.Default)
        changeitem = Bass.CreateStream(MyResource.se_changeitem, 0, MyResource.se_changeitem.Length, BassFlags.Default)
        damage00 = Bass.CreateStream(MyResource.se_damage00, 0, MyResource.se_damage00.Length, BassFlags.Default)
        damage01 = Bass.CreateStream(MyResource.se_damage01, 0, MyResource.se_damage01.Length, BassFlags.Default)
        don00 = Bass.CreateStream(MyResource.se_don00, 0, MyResource.se_don00.Length, BassFlags.Default)
        enep00 = Bass.CreateStream(MyResource.se_enep00, 0, MyResource.se_enep00.Length, BassFlags.Default)
        enep01 = Bass.CreateStream(MyResource.se_enep01, 0, MyResource.se_enep01.Length, BassFlags.Default)
        enep02 = Bass.CreateStream(MyResource.se_enep02, 0, MyResource.se_enep02.Length, BassFlags.Default)
        etbreak = Bass.CreateStream(MyResource.se_etbreak, 0, MyResource.se_etbreak.Length, BassFlags.Default)
        extend = Bass.CreateStream(MyResource.se_extend, 0, MyResource.se_extend.Length, BassFlags.Default)
        extend2 = Bass.CreateStream(MyResource.se_extend2, 0, MyResource.se_extend2.Length, BassFlags.Default)
        fault = Bass.CreateStream(MyResource.se_fault, 0, MyResource.se_fault.Length, BassFlags.Default)
        graze = Bass.CreateStream(MyResource.se_graze, 0, MyResource.se_graze.Length, BassFlags.Default)
        gun00 = Bass.CreateStream(MyResource.se_gun00, 0, MyResource.se_gun00.Length, BassFlags.Default)
        heal = Bass.CreateStream(MyResource.se_heal, 0, MyResource.se_heal.Length, BassFlags.Default)
        invalid = Bass.CreateStream(MyResource.se_invalid, 0, MyResource.se_invalid.Length, BassFlags.Default)
        item00 = Bass.CreateStream(MyResource.se_item00, 0, MyResource.se_item00.Length, BassFlags.Default)
        item01 = Bass.CreateStream(MyResource.se_item01, 0, MyResource.se_item01.Length, BassFlags.Default)
        kira00 = Bass.CreateStream(MyResource.se_kira00, 0, MyResource.se_kira00.Length, BassFlags.Default)
        kira01 = Bass.CreateStream(MyResource.se_kira01, 0, MyResource.se_kira01.Length, BassFlags.Default)
        kira02 = Bass.CreateStream(MyResource.se_kira02, 0, MyResource.se_kira02.Length, BassFlags.Default)
        lazer00 = Bass.CreateStream(MyResource.se_lazer00, 0, MyResource.se_lazer00.Length, BassFlags.Default)
        lazer01 = Bass.CreateStream(MyResource.se_lazer01, 0, MyResource.se_lazer01.Length, BassFlags.Default)
        lazer02 = Bass.CreateStream(MyResource.se_lazer02, 0, MyResource.se_lazer02.Length, BassFlags.Default)
        lgods1 = Bass.CreateStream(MyResource.se_lgods1, 0, MyResource.se_lgods1.Length, BassFlags.Default)
        lgods2 = Bass.CreateStream(MyResource.se_lgods2, 0, MyResource.se_lgods2.Length, BassFlags.Default)
        lgods3 = Bass.CreateStream(MyResource.se_lgods3, 0, MyResource.se_lgods3.Length, BassFlags.Default)
        lgods4 = Bass.CreateStream(MyResource.se_lgods4, 0, MyResource.se_lgods4.Length, BassFlags.Default)
        lgodsget = Bass.CreateStream(MyResource.se_lgodsget, 0, MyResource.se_lgodsget.Length, BassFlags.Default)
        msl = Bass.CreateStream(MyResource.se_msl, 0, MyResource.se_msl.Length, BassFlags.Default)
        msl2 = Bass.CreateStream(MyResource.se_msl2, 0, MyResource.se_msl2.Length, BassFlags.Default)
        msl3 = Bass.CreateStream(MyResource.se_msl3, 0, MyResource.se_msl3.Length, BassFlags.Default)
        nep00 = Bass.CreateStream(MyResource.se_nep00, 0, MyResource.se_nep00.Length, BassFlags.Default)
        nodamage = Bass.CreateStream(MyResource.se_nodamage, 0, MyResource.se_nodamage.Length, BassFlags.Default)
        noise = Bass.CreateStream(MyResource.se_noise, 0, MyResource.se_noise.Length, BassFlags.Default)
        ok00 = Bass.CreateStream(MyResource.se_ok00, 0, MyResource.se_ok00.Length, BassFlags.Default)
        pause = Bass.CreateStream(MyResource.se_pause, 0, MyResource.se_pause.Length, BassFlags.Default)
        pin00 = Bass.CreateStream(MyResource.se_pin00, 0, MyResource.se_pin00.Length, BassFlags.Default)
        pin01 = Bass.CreateStream(MyResource.se_pin01, 0, MyResource.se_pin01.Length, BassFlags.Default)
        pldead00 = Bass.CreateStream(MyResource.se_pldead00, 0, MyResource.se_pldead00.Length, BassFlags.Default)
        pldead01 = Bass.CreateStream(MyResource.se_pldead01, 0, MyResource.se_pldead01.Length, BassFlags.Default)
        plst00 = Bass.CreateStream(MyResource.se_plst00, 0, MyResource.se_plst00.Length, BassFlags.Default)
        power0 = Bass.CreateStream(MyResource.se_power0, 0, MyResource.se_power0.Length, BassFlags.Default)
        power1 = Bass.CreateStream(MyResource.se_power1, 0, MyResource.se_power1.Length, BassFlags.Default)
        powerup = Bass.CreateStream(MyResource.se_powerup, 0, MyResource.se_powerup.Length, BassFlags.Default)
        release = Bass.CreateStream(MyResource.se_release, 0, MyResource.se_release.Length, BassFlags.Default)
        select00 = Bass.CreateStream(MyResource.se_select00, 0, MyResource.se_select00.Length, BassFlags.Default)
        slash = Bass.CreateStream(MyResource.se_slash, 0, MyResource.se_slash.Length, BassFlags.Default)
        tan00 = Bass.CreateStream(MyResource.se_tan00, 0, MyResource.se_tan00.Length, BassFlags.Default)
        tan01 = Bass.CreateStream(MyResource.se_tan01, 0, MyResource.se_tan01.Length, BassFlags.Default)
        tan02 = Bass.CreateStream(MyResource.se_tan02, 0, MyResource.se_tan02.Length, BassFlags.Default)
        tan03 = Bass.CreateStream(MyResource.se_tan03, 0, MyResource.se_tan03.Length, BassFlags.Default)
        timeout = Bass.CreateStream(MyResource.se_timeout, 0, MyResource.se_timeout.Length, BassFlags.Default)
        timeout2 = Bass.CreateStream(MyResource.se_timeout2, 0, MyResource.se_timeout2.Length, BassFlags.Default)
        trophy = Bass.CreateStream(MyResource.se_trophy, 0, MyResource.se_trophy.Length, BassFlags.Default)
        wolf = Bass.CreateStream(MyResource.se_wolf, 0, MyResource.se_wolf.Length, BassFlags.Default)
    End Sub

    ''' <summary>
    ''' 播放声音
    ''' </summary>
    ''' <param name="Sound">需要播放的声音</param>
    ''' <param name="Volume">音量大小，默认为100%</param>
    Public Shared Sub PlaySound(Sound As Integer, Optional Volume As Double = 1)
        If Not Sounds_Playing.Contains(Sound) Then
            Bass.ChannelSetAttribute(Sound, ChannelAttribute.Volume, Volume)
            Bass.ChannelPlay(Sound, True)
            Sounds_Playing.Add(Sound)
        End If
    End Sub
    Public Shared Sub StopSound(Sound As Integer)
        Bass.ChannelStop(Sound)
    End Sub
End Class
