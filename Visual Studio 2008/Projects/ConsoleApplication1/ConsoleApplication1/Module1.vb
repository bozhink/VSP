Option Explicit On


Module Module1
    Declare Function AddNumbers Lib "example.dll" _
            (ByVal a As Double, ByVal v As Double) As Double

    Sub Main()
        Dim Result As Double
        Result = AddNumbers(1, 2)
        Debug.Print("The result was" & Result)
        Console.WriteLine("The result was " & Result)
    End Sub

End Module
