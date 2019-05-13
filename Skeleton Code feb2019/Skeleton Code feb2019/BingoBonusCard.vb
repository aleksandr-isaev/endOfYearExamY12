Public Class BingoBonusCard
    Inherits BingoCard

    Public Overrides Function GameOver(ByVal calledNumbers As Integer(), ByVal tail As Integer) As Integer
        Dim matched As Integer
        matched = Corners(calledNumbers, tail)
        If matched = 4 Then
            Return 3
        End If
        matched = FullHouse(calledNumbers, tail)
        Console.WriteLine("You only matched " & matched)
        If matched = 15 Then
            Return 1 ' if all numbers matched then returns 1
        End If





        Return 0 ' if no numbers matched returns 0



    End Function

    Private Function FullHouse(ByVal calledNumbers As Integer(), ByVal tail As Integer) As Integer
        Dim matched As Integer
        For x = 0 To 2
            For y = 0 To 8
                If numbers(x, y) <> 0 Then
                    For z = 0 To tail ' 0 to amount of umbers called
                        If numbers(x, y) = calledNumbers(z) Then
                            matched += 1 ' checks if numbers matched with calledNe Umbers
                        End If
                    Next
                End If

            Next
        Next
        Return matched
        'new loop to check if the user has a full row 

    End Function
    Private Function Corners(ByVal calledNumbers As Integer(), ByVal tail As Integer)
        Dim matched As Integer
        Dim x As Integer


        Dim Left As Boolean
        Dim right As Boolean

        x = 0
        Do
            Left = False
            right = False

            For y = 0 To 8
                If numbers(x, y) <> 0 And Left = False Then
                    Left = True
                    For z = 0 To tail ' 0 to amount of numbers called
                        If numbers(x, y) = calledNumbers(z) Then
                            matched += 1 ' checks if numbers matched with calledNe Umbers

                        End If
                    Next
                End If
                If numbers(x, 8 - y) <> 0 And right = False Then
                    right = True
                    For z = 0 To tail ' 0 to amount of umbers called
                        If numbers(x, 8 - y) = calledNumbers(z) Then
                            matched += 1 ' checks if numbers matched with calledNe Umbers

                        End If
                    Next
                End If


            Next

            x += 2

        Loop Until x > 2

        Return matched
    End Function



End Class

