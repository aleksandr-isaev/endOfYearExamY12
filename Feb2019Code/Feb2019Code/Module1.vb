Module Module1

    Sub Main()
        Dim loopCount As Integer = 0
        Dim NewBingoGame As New BingoGame
        NewBingoGame.Menu()
        Do
            Console.WriteLine("Do you want to play again? - Y or N")
            If Console.ReadLine = "Y" Then
                NewBingoGame.Menu()

            Else
                loopCount = 1
            End If
        Loop Until loopCount = 1
        Console.ReadLine()
    End Sub

End Module
