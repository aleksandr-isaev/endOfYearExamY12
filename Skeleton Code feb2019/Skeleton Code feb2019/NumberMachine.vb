Class NumberMachine
    Private numberOrder(74) As Integer
    Private current As Integer
    Private back As Integer = 74


    Public Sub New()
        Dim temp, num1, num2 As Integer
        For x = 1 To 75
            numberOrder(x - 1) = x
        Next x

        For x = 1 To 1000
            num1 = repo.NewRandom(0, 74)
            num2 = repo.NewRandom(0, 74)

            temp = numberOrder(num1)
            numberOrder(num1) = numberOrder(num2)
            numberOrder(num2) = temp
        Next
    End Sub

    Public Sub PracticeGame()
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
        If current < back Then
            current += 1

            Return numberOrder(current - 1)
        Else
            Return -1
        End If

    End Function

    Public Function getNumbers() As Integer()
        Return numberOrder
    End Function
    Public Function getBack() As Integer
        Return current
    End Function
End Class
