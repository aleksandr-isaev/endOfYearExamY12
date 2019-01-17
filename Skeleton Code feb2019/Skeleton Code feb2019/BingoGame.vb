Public Class BingoGame
    Dim numbers As New NumberMachine

    Public Sub New()
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$")
        Console.WriteLine("*        B-I-N-G-O S-I-M      *")
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$")
    End Sub

    Public Sub PlayGame()
        Dim playerCard As New BingoCard
        Dim won As Boolean
        playerCard.Displaycard()
        Console.WriteLine("Eyes Down... ")

        Do
            Caller()
            Console.WriteLine("Did you win?")
            Console.WriteLine("Enter 1 for yes and 0 for no?")
            won = Console.ReadLine()
            Console.Clear()
            playerCard.Displaycard()
        Loop Until won

        Console.WriteLine("You have matched " & playerCard.GameOver(numbers.getNumbers, numbers.getBack))
        If playerCard.GameOver(numbers.getNumbers, numbers.getBack) = 15 Then
            Console.WriteLine("Yes you have won!")
        Else
            Console.WriteLine("Sorry you stopped too early")
            Console.WriteLine("You only matched " & playerCard.GameOver(numbers.getNumbers, numbers.getBack))
            Console.WriteLine("GAME OVER")
        End If

    End Sub

    Public Sub PlayBonusGame()
        Dim playerCard As New BingoBonusCard
        Dim won As Boolean
        playerCard.Displaycard()
        Console.WriteLine("Eyes Down... ")

        Do
            Console.WriteLine("**BINGO BONUS**")
            Caller()
            Console.WriteLine("Did you win?")
            Console.WriteLine("Enter 1 for yes and 0 for no?")
            won = Console.ReadLine()
            Console.Clear()
            playerCard.Displaycard()
        Loop Until won


        Select Case playerCard.GameOver(numbers.getNumbers, numbers.getBack)
            Case 1
                Console.WriteLine("Well Done Full House")
            Case 2
                Console.WriteLine("Well Done Two Lines")
            Case 0
                Console.WriteLine("Sorry you stopped too early, GAME OVER")

        End Select


    End Sub

    Private Function Caller() As Integer
        Caller = numbers.nextBall
        Console.WriteLine("and the next ball is.....")
        If Caller = 11 Then
            Console.WriteLine("legs 11")
        Else
            Console.WriteLine(Caller)
        End If
    End Function

    Public Function Menu() As Boolean
        Dim choice As Integer
        Do
            MenuOptions()
            choice = Console.ReadLine()

            Select Case choice
                Case 0
                    Console.WriteLine("Goodbye")
                Case 1
                    PlayGame()
                Case 2
                    PlayBonusGame()
                Case 3
                    numbers.PracticeGame()
                    Console.Clear()
                    Console.WriteLine("Practice Game Initiated")
                Case Else
                    Console.WriteLine("Not an Option")
            End Select
        Loop Until choice = 1 Or choice = 2 Or choice = 0
        Return True
    End Function

    Public Sub MenuOptions()
        Console.WriteLine("---------------------------------------")
        Console.WriteLine("Choose 1 play Bingo")
        Console.WriteLine("Choose 2 play Bingo Bonus")
        Console.WriteLine("Choose 3 play practice game")
        Console.WriteLine("Choose 0 to exit")
    End Sub
End Class
