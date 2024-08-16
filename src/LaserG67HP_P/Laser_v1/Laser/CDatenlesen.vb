Imports System.IO
Imports System

Public Class CDatenlesen

    Public DatenArrayWerte(,) As String
    ' DatenArrayWerte(i,0)  ist nummer
    ' DatenArrayWerte(i,1)  ist name der nummer


    Public Sub leseDatenfile(ByVal sFile As String)
        Dim oStream As StreamReader
        Dim oFile As New FileInfo(sFile)
        Dim stringarray() As String
        Dim sLine As String = ""
        Dim i As Integer = 0
        ReDim stringarray(2)
        If oFile.Exists() = True Then
            oStream = New StreamReader(sFile)
            sLine = oStream.ReadLine()  'erste zeile schon mal einlesen
            Do While Not IsNothing(sLine)
                stringarray = sLine.Split(" ", 2)
                ReDim DatenArrayWerte(i, 1)
                DatenArrayWerte(i, 0) = stringarray(0)
                DatenArrayWerte(i, 1) = stringarray(1)
                Debug.WriteLine(DatenArrayWerte(i, 0) & " " & DatenArrayWerte(i, 1))
                Debug.WriteLine(stringarray(0))
                Debug.WriteLine(stringarray(1))
                sLine = oStream.ReadLine()
                i = i + 1
            Loop

            oStream.Close()
        Else
            MsgBox("fehler beim einlesen von" & sFile.ToString & System.Environment.NewLine & _
            "Angegebene Datei ist nicht vorhanden!" & System.Environment.NewLine & _
            "Datei muss in das gleiche Verzeichniss der visu kopiert werden!" & System.Environment.NewLine)

        End If

    End Sub



End Class
