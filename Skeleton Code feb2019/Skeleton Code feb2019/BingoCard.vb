Public Class BingoCard
    Protected numbers(2, 8) As Integer ' numbers on card 'protect means only editable within that class

    Public Sub New()
        numbers = AssignNumbers()
    End Sub
    Private Function AssignNumbers() As Integer(,) 'assigns the numbers in the bingo card
        'Randomize()
        Dim row1(4) As Integer 'there are 5 numbers on each row and 5 spaces on each row 
        Dim row2(4) As Integer ' row() gets 5 numbers which gives the position on the row where the actual number to be called will be placed
        Dim row3(4) As Integer
        Dim cardnumbers(2, 8) As Integer 'refers to the whole card (3 rows, 9 columns)

        row1 = AssignRowPlaces()
        row2 = AssignRowPlaces()
        row3 = AssignRowPlaces()
        For x = 0 To 4
            Console.WriteLine(row1(x))
        Next
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

    Public Sub Displaycard() 'prints the card
        For x = 0 To 2
            For y = 0 To 8
                Console.Write(numbers(x, y) & ",")

            Next y
            Console.WriteLine()
        Next x
    End Sub

    Private Function AssignRowPlaces() As Integer()
        Dim numberCount As Integer 'automataily set to 0
        Dim row(4) As Integer
        Dim match As Boolean 'variable to check if there are duplicates
        For x = 0 To 4
            row(x) = -1 'this sets 5 numbers in each row to -1
        Next
        Do While numberCount <= 4
            match = False
            row(numberCount) = repo.NewRandom(0, 8) 'generates a random number beween 0 and 89 to be the random number on the card
            numberCount += 1
            For x = 0 To 4 'for loop and if statement below it to check if there are duplicates, then number count goes down 1 and the process repeats until it has 5 random numbers
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
        ' makes order on row of bingo card from smallest to largest
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

    Public Overridable Function GameOver(ByVal calledNumbers As Integer(), ByVal tail As Integer) As Integer 'checks to see how mow many numbers were actually called
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
