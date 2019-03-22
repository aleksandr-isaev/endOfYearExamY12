Module Module1

    Sub Main()
        Dim loopCount As Integer = 0 'added to allow them to play games as many as they want
        Dim NewBingoGame As New BingoGame
        If NewBingoGame.Menu() = True Then 'added = True

            Do
                Console.WriteLine("Do you want to play again? - Y or N")
                If Console.ReadLine = "Y" Then
                    NewBingoGame.Menu()

                Else
                    loopCount = 1 'added
                End If
            Loop Until loopCount = 1 'added

        End If
        Console.ReadLine()
    End Sub

End Module
