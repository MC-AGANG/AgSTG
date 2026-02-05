Public Class KeyState
    Public Shared Up As Boolean
    Public Shared Down As Boolean
    Public Shared Left As Boolean
    Public Shared Right As Boolean
    Public Shared Slow As Boolean
    Public Shared Shoot As Boolean
    Public Shared Bomb As Boolean
    Public Shared Function Encode() As Byte
        Encode = 0
        If Up Then Encode += 1
        If Down Then Encode += 2
        If Left Then Encode += 4
        If Right Then Encode += 8
        If Slow Then Encode += 16
        If Shoot Then Encode += 32
        If Bomb Then Encode += 64
    End Function
    Public Shared Sub Decode(value As Byte)
        If value >= 128 Then value -= 128
        If value >= 64 Then
            Bomb = True
            value -= 64
        Else
            Bomb = False
        End If
        If value >= 32 Then
            Shoot = True
            value -= 32
        Else
            Shoot = False
        End If
        If value >= 16 Then
            Slow = True
            value -= 16
        Else
            Slow = False
        End If
        If value >= 8 Then
            Right = True
            value -= 8
        Else
            Right = False
        End If
        If value >= 4 Then
            Left = True
            value -= 4
        Else
            Left = False
        End If
        If value >= 2 Then
            Down = True
            value -= 2
        Else
            Down = False
        End If
        If value >= 1 Then
            Up = True
        Else
            Up = False
        End If
    End Sub
End Class
