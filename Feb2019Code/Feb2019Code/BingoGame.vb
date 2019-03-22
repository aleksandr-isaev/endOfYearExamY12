Public Class BingoGame
    Dim numbers As New NumberMachine
    Dim round As Integer = 0 'added
    Dim callernum As Integer 'added


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
            playerCard.removenumbers(callernum) 'added
            Console.WriteLine("Did you win?")
            Console.WriteLine("Enter 1 for yes and 0 for no?")
            Do
                Try 'added try catc
                    won = Console.ReadLine()
                Catch ex As Exception
                    Console.WriteLine("That was not a valid option. Please enter 1 or 0")
                    won = Console.ReadLine()
                End Try
            Loop Until won = "0" Or won = "1"
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
            playerCard.removenumbers(callernum) 'added
            Console.WriteLine("Did you win?")
            Console.WriteLine("Enter 1 for yes and 0 for no?")
            Do
                Try 'add try catch
                    won = Console.ReadLine()
                Catch ex As Exception
                    Console.WriteLine("That was not a valid option. Please enter 1 or 0")
                    won = Console.ReadLine()
                End Try
            Loop Until won = "0" Or won = "1"
            'won = console.readline() 'removed this
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
        'caller = numbers.nextBall 'removed line
        callernum = numbers.nextBall 'added
        If round = 0 Then 'added
            Console.WriteLine("The first ball is ... ") 'added
            round = round + 1 'added
        ElseIf callernum = -1 Then 'changed from caller to callernum
            Console.WriteLine("Sorry there are no more available numbers left in the game") 'added
        Else
            Console.WriteLine("and the next ball is.....")
            round = round + 1
        End If
        If callernum = 11 Then 'changed from caller to callernum
            Console.WriteLine("legs 11")
        ElseIf callernum = 22 Then 'added 'changed from caller to callernum
            Console.WriteLine("two little ducks") 'added
        Else
            Console.WriteLine(callernum) 'changed from caller to callernum
        End If
    End Function

    Public Function Menu() As Boolean
        Dim choice As Integer
        Do
            Try 'added try catch
                MenuOptions()
                choice = Console.ReadLine()
            Catch ex As Exception
            End Try
            Select Case choice
                Case 0
                    Console.WriteLine("Goodbye")
                    Return False 'added to fix error when enter 0 in menu
                Case 1
                    Console.Clear() 'added
                    PlayGame()
                Case 2
                    Console.Clear() 'added
                    PlayBonusGame()
                Case 3
                    numbers.PracticeGame()
                    Console.Clear()
                    Console.WriteLine("Practice Game Initiated")
                    PlayGame() 'added
                Case Else
                    Console.WriteLine("Not an Option")
            End Select
        Loop Until choice = 1 Or choice = 2 Or choice = 0 Or choice = 3 'added choice = 3
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
