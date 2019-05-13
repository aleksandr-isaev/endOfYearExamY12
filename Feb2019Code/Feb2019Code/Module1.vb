Module Module1

    Sub Main()
        Dim loopCount As Integer = 0 'added to allow them to play games as many as they want
        Dim NewBingoGame As New BingoGame
        'added = True

        Do
            If NewBingoGame.Menu() = True Then
                Console.WriteLine("Do you want to play again? - Y or N")

                If UCase(Console.ReadLine) = "Y" Then
                Else
                    loopCount = 1 'added
                End If
            Else loopCount = 1
            End If
        Loop Until loopCount = 1 'added
    End Sub

End Module
