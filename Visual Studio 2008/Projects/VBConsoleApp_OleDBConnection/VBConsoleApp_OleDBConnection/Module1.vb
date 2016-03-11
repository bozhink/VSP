Imports System
Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()
        Try
            'construct the command object and open a connection to the Contacts table

            Dim cmdString As String = "Select Title, Address, City from [Employees]"
            Dim connString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Program Files\\Microsoft Office\\OFFICE11\\SAMPLES\\Northwind.mdb"
            Dim myConnection As OleDbConnection = New OleDbConnection(connString)

            ' Open connection
            myConnection.Open()

            'Create OleDbCommand object
            Dim TheCommand As OleDbCommand = New OleDbCommand(cmdString, myConnection)

            TheCommand.CommandType = CommandType.Text
            ' Create a DataReader and call Execute on the Command Object to construct it

            Dim TheDataReader As OleDbDataReader = TheCommand.ExecuteReader()

            While TheDataReader.Read()
                System.Console.Write(TheDataReader("Title").ToString())
                System.Console.Write(" ")
                System.Console.Write(TheDataReader("Address").ToString())
                System.Console.Write(" ")
                System.Console.Write(TheDataReader("City").ToString())
                System.Console.WriteLine()
            End While

        Catch ae As OleDbException
            MsgBox(ae.Message())
        End Try
        System.Console.ReadKey()

    End Sub

End Module
