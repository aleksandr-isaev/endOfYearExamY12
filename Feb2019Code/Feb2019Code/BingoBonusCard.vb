Public Class BingoBonusCard
    Inherits BingoCard

    Public Overrides Function GameOver(ByVal tail As Integer) As Integer
        Dim matched As Integer
        matched = MyBase.GameOver(tail)
        If Corners() Then
            Return 3
        ElseIf Horizontal() Then
            Return 2
        ElseIf matched = 15 Then
            Return 1
        End If

        Console.WriteLine("You only matched " & matched)
        Return 0
    End Function

    'Checks the 4 corners
    Private Function Corners() As Boolean
        Dim matched As Integer
        Dim left As Boolean = False
        Dim count As Integer = 0
        Dim right As Boolean = False
        For x = 0 To 2
            While x <> 1 And left = False
                If numbers(x, count) <> 0 Then
                    left = True
                    If callednum(x, count) Then
                        matched += 1
                    End If
                Else count += 1
                End If
            End While
            count = 0
            While x <> 1 And right = False
                If numbers(x, 8 - count) <> 0 Then
                    right = True
                    If callednum(x, 8 - count) Then
                        matched += 1
                    End If
                Else count += 1
                End If
            End While
            count = 0
            left = False
            right = False
        Next
        'OLD CORNERS CODE (DOES NOT WORK)
        'For x = 0 To 2
        '    For y = 0 To 8
        '        If x <> 1 Then
        '            If first = False And numbers(x, y) <> 0 Then
        '                first = True
        '                If left = False Then
        '                    If callednum(x, y) = True Then
        '                        matched += 1
        '                        left = True
        '                    End If
        '                End If

        '            End If
        '        End If
        '    Next
        '    While right <> 8
        '        If last = False And numbers(x, 8 - right) <> 0 Then
        '            last = True
        '            If callednum(x, 8 - right) = True And rightbool = False Then
        '                matched += 1
        '                rightbool = True
        '            End If
        '        End If
        '        right += 1
        '    End While
        '    rightbool = False
        '    left = False
        '    last = False
        '    first = False
        'Next
        If matched = 4 Then
            Return True
        Else
            Return False
        End If

    End Function
    'Checks horizontal lines
    Private Function Horizontal() As Boolean
        Dim matched() As Integer = {0, 0, 0}

        For x = 0 To 2

            For y = 0 To 8
                If callednum(x, y) = True Then
                    matched(x) += 1
                End If

            Next

            If matched(x) = 5 Then
                Return True
            End If

        Next
        Return False
    End Function
End Class
