Public Class repo ' class to assign random values
    Public Shared Function NewRandom(ByVal lowerbound As Integer, ByVal upperbound As Integer) ' upperbound = the highest value you want, lowerbound = lowest value you want

        Return CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound ' does the randomization 

    End Function
End Class
