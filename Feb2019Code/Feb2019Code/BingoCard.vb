Public Class BingoCard
    Protected numbers(2, 8) As Integer

    Public Sub New()
        numbers = AssignNumbers()
    End Sub
    Private Function AssignNumbers() As Integer(,)
        Randomize()
        Dim row1(4) As Integer
        Dim row2(4) As Integer
        Dim row3(4) As Integer
        Dim cardnumbers(2, 8) As Integer

        row1 = AssignRowPlaces()
        row2 = AssignRowPlaces()
        row3 = AssignRowPlaces()

        For x = 0 To 4
            cardnumbers(0, row1(x)) = repo.NewRandom(1, 8) + (10 * row1(x))
        Next

        For x = 0 To 4
            Dim base As Integer
            base = (cardnumbers(0, row2(x)) Mod 10) + 1
            base = repo.NewRandom(base, 9)
            cardnumbers(1, row2(x)) = base + (10 * row2(x))
        Next

        For x = 0 To 4
            Dim base As Integer
            If cardnumbers(1, row3(x)) = 0 Then

                base = (cardnumbers(0, row3(x)) Mod 10) + 1
            Else
                base = (cardnumbers(1, row3(x)) Mod 10) + 1
            End If
            base = repo.NewRandom(base, 10)
            cardnumbers(2, row3(x)) = base + (10 * row3(x))
        Next
        Return cardnumbers

    End Function

    Public Sub Displaycard()
        For x = 0 To 2
            Console.Write("|")
            For y = 0 To 8
                ' Console.Write(numbers(x, y) & ",")
                If Len(CStr(numbers(x, y))) = 2 Then 'this if statement is for spacing and alignment of the board
                    If numbers(x, y) = -1 Then 'added this nested IF statement in order to display X when the number is picked
                        Console.Write(" X | ")
                    Else
                        Console.Write(numbers(x, y) & " | ") 'changed the , to a | so it is easier to see the columns separately
                    End If
                ElseIf Len(CStr((numbers(x, y)))) = 1 Then
                    Console.Write(" " & numbers(x, y) & " | ")
                End If
            Next y
            Console.WriteLine()
        Next x
    End Sub
    Public Sub removenumbers(ByVal callernum As Integer) 'added sub for when number is picked
        For x = 0 To 2
            For y = 0 To 8
                If numbers(x, y) = callernum Then
                    numbers(x, y) = -1
                End If
            Next
        Next
    End Sub
    Private Function AssignRowPlaces() As Integer()
        Dim numberCount As Integer
        Dim row(4) As Integer
        Dim match As Boolean
        For x = 0 To 4
            row(x) = -1
        Next
        Do While numberCount <= 4
            match = False
            row(numberCount) = repo.NewRandom(0, 8)
            numberCount += 1

            For x = 0 To 4
                If row(numberCount - 1) = row(x) And numberCount - 1 <> x Then

                    match = True
                End If
            Next

            If match Then
                numberCount -= 1
            End If

        Loop
        row = rearrage(row, 4)
        Return row
    End Function

    Private Function rearrage(ByVal dataSet As Integer(), ByVal size As Integer) As Integer()
        Dim i, j As Integer
        For i = 0 To size - 1
            For j = 0 To size - 1
                If (dataSet(j) > dataSet(j + 1)) Then
                    Dim temp As Integer = dataSet(j)
                    dataSet(j) = dataSet(j + 1)
                    dataSet(j + 1) = temp
                End If
            Next
        Next
        Return dataSet
    End Function


    Public Overridable Function GameOver(ByVal calledNumbers As Integer(), ByVal tail As Integer) As Integer
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
