Imports System
Imports System.IO
Imports System.Windows.Forms
Imports Laser

Public Class CFehlerschreiber

    Public dateipfad As String = "/Stoerungsverwaltung.txt"
    Private strpath As String = ""
    Private datumstr As String = ""
    Private zeitstr As String = ""
    Private werteanhaengen As Boolean = True


    Public Sub New(ByVal fehlerstring As String)

        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString

        If (strpath.Substring(0, 6) = "file:\") Then  'hier nur überprüfung zum compilieren auf laptop für CE/XP.
            strpath = strpath.Substring(6)            'bei XP ist pfad mit file:\ das muss rausgeschnitten werden!
        End If


        datumstr = DateTime.Today  'Datum anzeigen
        zeitstr = DateTime.Now.ToLongTimeString  'Uhrzeit anzeigen
        If Not File.Exists(strpath & dateipfad) Then
            Dim tempstream As StreamWriter
            tempstream = New StreamWriter(strpath & dateipfad, False)  'mit false wird neue datei erstellt...
            tempstream.Close()
        End If

        Dim finfo As New FileInfo(strpath & dateipfad)
        Dim filelaenge As Long = 0
        filelaenge = finfo.Length

        If (filelaenge > 102400) Then
            werteanhaengen = False
        Else
            werteanhaengen = True
        End If
        filelaenge = Nothing
        finfo = Nothing
        Dim sw As StreamWriter
        sw = New StreamWriter(strpath & dateipfad, werteanhaengen) 'mit true werden daten angehaengt
        sw.WriteLine(datumstr & " - " & zeitstr & " - " & fehlerstring)
        sw.Close()
        sw = Nothing

    End Sub
End Class
