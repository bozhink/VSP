Imports System
Imports System.Data
Imports System.Data.Odbc



Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'construct the command object and open a connection to the Contacts table

            Dim cmdString As String = "Select EMP_NO, FIRST_NAME, LAST_NAME from EMPLOYEE"
            Dim connString As String = "DSN=FirebirdTest"
            Dim myConnection As OdbcConnection = New OdbcConnection(connString)

            ' Open connection
            myConnection.Open()

            'Create OdbcCommand object
            Dim TheCommand As OdbcCommand = New OdbcCommand(cmdString, myConnection)

            TheCommand.CommandType = CommandType.Text
            ' Create a DataReader and call Execute on the Command Object to construct it

            Dim TheDataReader As OdbcDataReader = TheCommand.ExecuteReader()

            While TheDataReader.Read()
                System.Console.Write(TheDataReader("EMP_NO").ToString())
                System.Console.Write(" ")
                System.Console.Write(TheDataReader("FIRST_NAME").ToString())
                System.Console.Write(" ")
                System.Console.Write(TheDataReader("LAST_NAME").ToString())
                System.Console.WriteLine()
            End While

        Catch ae As OdbcException
            MsgBox(ae.Message())
        End Try

    End Sub
End Class
