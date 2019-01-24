Class NumberMachine
    Private numberOrder(74) As Integer ' bingo balls 
    Private current As Integer ' current number of bingo balls shown
    Private back As Integer = 74 ' number of bingo balls


    Public Sub New()
        Dim temp, num1, num2 As Integer
        For x = 1 To 75
            numberOrder(x - 1) = x ' sets numberOrder from 1 to 75
        Next x

        For x = 1 To 1000
            num1 = repo.NewRandom(0, 74) ' random number assigned to num1
            num2 = repo.NewRandom(0, 74) ' random number assigned to num2
            ' switches numberOrder(num1) with numberOrder(num2)
            temp = numberOrder(num1) ' integer in numberOrder with position of num1 is assigned to temp
            numberOrder(num1) = numberOrder(num2) ' integer in numberOrder with position of num2 is assigned to numberOrder(num1)
            numberOrder(num2) = temp ' integer in temp is assigned to numberOrder(num2)
        Next
    End Sub

    Public Sub PracticeGame() ' set order of bingo balls
        numberOrder(0) = 4
        numberOrder(1) = 11
        numberOrder(2) = 5
        numberOrder(3) = 57
        numberOrder(4) = 65
        numberOrder(5) = 33
        numberOrder(6) = 48
        numberOrder(7) = 58
        numberOrder(8) = 68
        numberOrder(9) = 78
        numberOrder(10) = 47
        numberOrder(11) = 18
        numberOrder(12) = 50
        numberOrder(13) = 59
        numberOrder(14) = 80
        numberOrder(15) = 81

    End Sub

    Public Function nextBall() As Integer
        If current < back Then ' if current is more than the original number it will stop showing
            current += 1 ' number of bingo balls shown

            Return numberOrder(current - 1) ' shows next bingo ball
        Else
            Return -1 ' returns -1 if ran out of bingo balls
        End If

    End Function
    Public Function getNumbers() As Integer()
        Return numberOrder
    End Function
    Public Function getBack() As Integer
        Return current
    End Function
End Class
