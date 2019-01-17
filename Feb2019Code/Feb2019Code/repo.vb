Public Class repo
    Public Shared Function NewRandom(ByVal lowerbound As Integer, ByVal upperbound As Integer)
        Return CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound

    End Function
End Class
