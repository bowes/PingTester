Imports System
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Text
Module Module1

    Sub Main(args As String())
        If args.Length = 0 Then
            Console.WriteLine("Bowes IT Solutions Ping Tester v0.40b")
            Console.WriteLine("")
            Console.WriteLine("Usage:")
            Console.WriteLine("pingtest address [address] [address]...")
            Console.WriteLine("Example:")
            Console.WriteLine("pingtest 192.168.0.1 www.google.com 8.8.8.8")
            Console.WriteLine("One argument is required, any number of arguments can be specified.")
            Exit Sub
        End If

        Dim filename As String = ".\PingResult.txt"
        Dim fileWriter As New System.IO.StreamWriter(filename, True)

        fileWriter.WriteLine("Bowes IT Solutions Ping Tester v0.40b running at " & System.DateTime.Now)
        fileWriter.WriteLine("")

        Console.WriteLine("Bowes IT Solutions Ping Tester v0.40b") '
        Console.WriteLine("Build Date: October 21, 2020")
        Console.WriteLine("")
        Console.WriteLine("Checking:")

        For Each a As String In args
            Console.WriteLine("- " & a)
        Next

        Console.WriteLine("")
        Console.WriteLine("**** Press any key to stop ****")
        Console.WriteLine("")
        Console.Write("Working")

        While Not Console.KeyAvailable
            For Each arg As String In args
                Dim res As String = Pingit(arg)
                'Console.WriteLine(arg & " " & res & " " & System.DateTime.Now)
                Console.Write(".")
                If res <> "Success" Then
                    fileWriter.WriteLine(arg & " - " & res & " - " & System.DateTime.Now)
                End If
            Next
        End While

        fileWriter.WriteLine("")
        fileWriter.Close()

    End Sub

    Function Pingit(pingaddress As String)

        Dim pingrequest As New Ping
        Dim pingoptions As New PingOptions
        'Dim data As String = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
        Dim reply As PingReply

        pingoptions.DontFragment = True
        'pingoptions.

        Try
            reply = pingrequest.Send(pingaddress)
        Catch ex As Exception
            Return "Error pinging " & pingaddress & ", does the address resolve?"
        End Try

        Return reply.Status.ToString

    End Function

End Module
