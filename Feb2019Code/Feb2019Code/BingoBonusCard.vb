Public Class BingoBonusCard
    Inherits BingoCard

    Public Overrides Function GameOver(ByVal calledNumbers As Integer(), ByVal tail As Integer) As Integer
        Dim matched As Integer
        matched = FullHouse(calledNumbers, tail)
        If matched = 15 Then
            Return 1
        End If



        Console.WriteLine("You only matched " & matched)
        Return 0
    End Function

    Private Function FullHouse(ByVal calledNumbers As Integer(), ByVal tail As Integer) As Integer
        Dim matched As Integer
        For x = 0 To 2
            For y = 0 To 8
                If numbers(x, y) <> 0 Then
                    For z = 0 To tail
                        If numbers(x, y) = calledNumbers(z) Then
                            matched += 1
                        End If
                    Next
                End If

            Next
        Next
        Return matched
    End Function
End Class
