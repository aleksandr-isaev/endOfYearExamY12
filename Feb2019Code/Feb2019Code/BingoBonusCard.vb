Public Class BingoBonusCard
    Inherits BingoCard

    Public Overrides Function GameOver(ByVal calledNumbers As Integer(), ByVal tail As Integer) As Integer
        Dim matched As Integer
        matched = FullHouse(calledNumbers)
        If matched = 15 Then
            Return 1
        ElseIf Corners(calledNumbers) Then
            Return 3
        ElseIf Horizontal(calledNumbers) Then
            Return 2
        End If


        Console.WriteLine("You only matched " & matched)
        Return 0
    End Function
    'Changed so that it checks for -1's
    Private Function FullHouse(ByVal calledNumbers As Integer()) As Integer
        Dim matched As Integer
        For x = 0 To 2
            For y = 0 To 8
                If numbers(x, y) = -1 Then
                    matched += 1
                End If
            Next
        Next
        Return matched
    End Function
    'Checks the 4 corners
    Private Function Corners(ByVal calledNumbers As Integer()) As Boolean
        Dim matched As Integer
        For x = 0 To 2
            For y = 0 To 8
                If numbers(x, y) = -1 Then
                    If (x = 0 And y = 0) Or (x = 0 And y = 8) Or (x = 2 And y = 0) Or (x = 2 And y = 8) Then
                        matched += 1
                    End If
                End If
            Next
        Next
        If matched = 4 Then
            Return True
        Else
            Return False
        End If
    End Function
    'Checks horizontal lines
    Private Function Horizontal(ByVal calledNumbers As Integer()) As Boolean
        Dim matched() As Integer = {0, 0, 0}
        For x = 0 To 2
            For y = 0 To 8
                If numbers(x, y) = -1 Then
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
