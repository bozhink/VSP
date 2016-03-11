Option Explicit On

Module Module1
    Declare Function AddNumbers Lib "Example.dll" _
    (ByVal a As Double, ByVal b As Double) As Double

    Sub Main()
        Dim Result As Double
        Result = AddNumbers(1, 2)
        System.Console.WriteLine("The result is: " & Result)
        'System.Console.ReadKey()
    End Sub

End Module
