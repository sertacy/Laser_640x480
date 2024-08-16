Imports System
Imports System.IO
Imports System.Windows.Forms
Public Class CInileser
    Public Sub New()
        If File.Exists(Application.StartupPath & "\kokev.INI") Then
            Me.LoadValues()
        Else
            neueIniDateiAnlegen()
        End If

    End Sub

    Public iniwerte(31) As String 'für 32 werte

    ' INI-API
    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    ' Speichert einen INI-Wert
    Private Sub WriteINI(ByVal Pfad As String, ByVal Sektion As String, Optional ByVal Key As String = vbNullString, Optional ByVal Value As String = vbNullString)
        WritePrivateProfileString(Sektion, Key, Value, Application.StartupPath & "\Settings.ini")
    End Sub

    ' Liest einen INI-Wert aus
    Private Function GetINI(ByVal Pfad As String, ByVal Sektion As String, ByVal Key As String, Optional ByVal DefaultValue As String = "def") As String
        Dim MyStr As String = Space(100)
        Dim MyLength As Integer = GetPrivateProfileString(Sektion, Key, DefaultValue, MyStr, MyStr.Length, Pfad)
        GetINI = Microsoft.VisualBasic.Left(MyStr, MyLength)
    End Function

    Private Sub SaveValues(ByVal Number As Integer)
        ' Werte speichern
        ' WriteINI(Application.StartupPath & "\settings.INI", Number, "Name", TxtName.Text)
        'WriteINI(Application.StartupPath & "\settings.INI", Number, "Alter", TxtAlter.Text)
        'WriteINI(Application.StartupPath & "\settings.INI", Number, "Geschlecht", IIf(RdbWeiblich.Checked = True, "w", "m"))
        'WriteINI(Application.StartupPath & "\settings.INI", Number, "Gewicht", TxtGewicht.Text)
    End Sub


    Private Sub LoadValues()  'wenn die Ini datei existiert....
        ' Werte einlesen
        iniwerte(0) = GetINI(Application.StartupPath & "\kokev.INI", "Auftragsverwaltung", "ArtikelfilesPfad")
        iniwerte(1) = GetINI(Application.StartupPath & "\kokev.INI", "Auftragsverwaltung", "AktuellerArtikel")
        iniwerte(2) = GetINI(Application.StartupPath & "\kokev.INI", "Auftragsverwaltung", "MinChainLength")
        iniwerte(3) = GetINI(Application.StartupPath & "\kokev.INI", "Auftragsverwaltung", "MaxChainLength")
        iniwerte(4) = GetINI(Application.StartupPath & "\kokev.INI", "Maschinenstörungen", "MalFilePath")
        iniwerte(5) = GetINI(Application.StartupPath & "\kokev.INI", "Maschinenstörungen", "MalFileName")
        iniwerte(6) = GetINI(Application.StartupPath & "\kokev.INI", "Maschinenstörungen", "Analyse")
        iniwerte(7) = GetINI(Application.StartupPath & "\kokev.INI", "Maschinenstörungen", "WriteFile")
        iniwerte(8) = GetINI(Application.StartupPath & "\kokev.INI", "Kettenfehler", "ChainErrorFilePath")
        iniwerte(9) = GetINI(Application.StartupPath & "\kokev.INI", "Kettenfehler", "ChainErrorFileName")
        iniwerte(10) = GetINI(Application.StartupPath & "\kokev.INI", "Kettenfehler", "Analyse")
        iniwerte(11) = GetINI(Application.StartupPath & "\kokev.INI", "Kettenfehler", "WriteFile")
        iniwerte(12) = GetINI(Application.StartupPath & "\kokev.INI", "Systemfehler", "File")
        iniwerte(13) = GetINI(Application.StartupPath & "\kokev.INI", "Zuordnungsdateien", "Störungstexte")
        iniwerte(14) = GetINI(Application.StartupPath & "\kokev.INI", "Zuordnungsdateien", "Bedienernamen")
        iniwerte(15) = GetINI(Application.StartupPath & "\kokev.INI", "MasterUser", "Bedienernummer")
        iniwerte(16) = GetINI(Application.StartupPath & "\kokev.INI", "Remote", "Enable")
        iniwerte(17) = GetINI(Application.StartupPath & "\kokev.INI", "Remote", "RemoteDisableAV")
        iniwerte(18) = GetINI(Application.StartupPath & "\kokev.INI", "Remote", "RemotePort")
        iniwerte(19) = GetINI(Application.StartupPath & "\kokev.INI", "Remote", "ServerPort")
        iniwerte(20) = GetINI(Application.StartupPath & "\kokev.INI", "Remote", "ServerIP")
        iniwerte(21) = GetINI(Application.StartupPath & "\kokev.INI", "Konfiguration", "ColorTable")
        iniwerte(22) = GetINI(Application.StartupPath & "\kokev.INI", "Konfiguration", "MaschineName")
        iniwerte(23) = GetINI(Application.StartupPath & "\kokev.INI", "Konfiguration", "KettenFlexi")
        iniwerte(24) = GetINI(Application.StartupPath & "\kokev.INI", "Konfiguration", "NKRvisible")
        iniwerte(25) = GetINI(Application.StartupPath & "\kokev.INI", "Konfiguration", "HueRiApp")
        iniwerte(26) = GetINI(Application.StartupPath & "\kokev.INI", "Konfiguration", "HBBefuellen")
        iniwerte(27) = GetINI(Application.StartupPath & "\kokev.INI", "Konfiguration", "Topf2Drehzahl")
        iniwerte(28) = GetINI(Application.StartupPath & "\kokev.INI", "Maschinenparameter", "NKR_Einzug")
        iniwerte(29) = GetINI(Application.StartupPath & "\kokev.INI", "Maschinenparameter", "SM_Teller")
        iniwerte(30) = GetINI(Application.StartupPath & "\kokev.INI", "Maschinenparameter", "ServoMontage")
        iniwerte(31) = GetINI(Application.StartupPath & "\kokev.INI", "Maschinenparameter", "ServoMasspresse")
        'bsp zum anzeigen:
        'MsgBox(iniwerte(0) & System.Environment.NewLine & iniwerte(1) & System.Environment.NewLine & iniwerte(31))
    End Sub

    '**************** iniwerte array Belegung zur Einsicht ************************
    '[Auftragsverwaltung]
    'iniwerte(0) =  ArtikelfilesPfad=c:\Visualisierung\AV\
    'iniwerte(1) =  AktuellerArtikel=89999999
    'iniwerte(2) =  MinChainLength=1
    'iniwerte(3) =  MaxChainLength=1000
    '[Maschinenstörungen]
    'iniwerte(4) =  MalFilePath=c:\Visualisierung\Störungen\
    'iniwerte(5) =  MalFileName=störungen
    'iniwerte(6) =  Analyse=0
    'iniwerte(7) =  WriteFile=1
    '[Kettenfehler]
    'iniwerte(8) =  ChainErrorFilePath=c:\Visualisierung\Kettenfehler\
    'iniwerte(9) =  ChainErrorFileName=Kettenfehler
    'iniwerte(10) =  Analyse=
    'iniwerte(11) =  WriteFile=0
    '[Systemfehler]
    'iniwerte(12) =  File=0
    '[Zuordnungsdateien]
    'iniwerte(13) =  Störungstexte=störungen.txt
    'iniwerte(14) =  Bedienernamen=bediener.txt
    '[MasterUser]
    'iniwerte(15) =  Bedienernummer=9999
    '[Remote]
    'iniwerte(16) =  Enable=0
    'iniwerte(17) =  RemoteDisableAV=0
    'iniwerte(18) =  RemotePort=5444
    'iniwerte(19) =  ServerPort=5445
    'iniwerte(20) =  ServerIP=192.168.0.45
    '[Konfiguration]
    'iniwerte(21) =  ColorTable=13FF-F51B-B2E0-2F49
    'iniwerte(22) =  MaschineName=kokev xxxxBeispiel
    'iniwerte(23) =  KettenFlexi=0
    'iniwerte(24) =  NKRvisible=0
    'iniwerte(25) =  HueRiApp=1
    'iniwerte(26) =  HBBefuellen=1
    'iniwerte(27) =  Topf2Drehzahl=0
    '[Maschinenparameter]
    'iniwerte(28) =  NKR_Einzug=0
    'iniwerte(29) =  SM_Teller=0
    'iniwerte(30) =  ServoMontage=0
    'iniwerte(31) =  ServoMasspresse=0


    Private Sub neueIniDateiAnlegen()  'wenn noch keine Ini datei existiert....(nur bei neustarts des systems ohne zugehörige ini)
        Dim defaultiniwerte As String
        Dim objDateiMacher As StreamWriter

        defaultiniwerte = "[Auftragsverwaltung]" & System.Environment.NewLine & _
                          "ArtikelfilesPfad=c:\Visualisierung\AV\" & System.Environment.NewLine & _
                          "AktuellerArtikel=89999999" & System.Environment.NewLine & _
                          "MinChainLength=1" & System.Environment.NewLine & _
                          "MaxChainLength=1000" & System.Environment.NewLine & _
                          "[Maschinenstörungen]" & System.Environment.NewLine & _
                          "MalFilePath=c:\Visualisierung\Störungen\" & System.Environment.NewLine & _
                          "MalFileName=störungen" & System.Environment.NewLine & _
                          "Analyse=0" & System.Environment.NewLine & _
                          "WriteFile=1" & System.Environment.NewLine & _
                          "[Kettenfehler]" & System.Environment.NewLine & _
                          "ChainErrorFilePath=c:\Visualisierung\Kettenfehler\" & System.Environment.NewLine & _
                          "ChainErrorFileName=Kettenfehler" & System.Environment.NewLine & _
                          "Analyse=0" & System.Environment.NewLine & _
                          "WriteFile=0" & System.Environment.NewLine & _
                          "[Systemfehler]" & System.Environment.NewLine & _
                          "File=0" & System.Environment.NewLine & _
                          "[Zuordnungsdateien]" & System.Environment.NewLine & _
                          "Störungstexte=störungen.txt" & System.Environment.NewLine & _
                          "Bedienernamen=bediener.txt" & System.Environment.NewLine & _
                          "[MasterUser]" & System.Environment.NewLine & _
                          "Bedienernummer=9999" & System.Environment.NewLine & _
                          "[Remote]" & System.Environment.NewLine & _
                          "Enable=0" & System.Environment.NewLine & _
                          "RemoteDisableAV=0" & System.Environment.NewLine & _
                          "RemotePort=5444" & System.Environment.NewLine & _
                          "ServerPort=5445" & System.Environment.NewLine & _
                          "ServerIP=192.168.0.45" & System.Environment.NewLine & _
                          "[Konfiguration]" & System.Environment.NewLine & _
                          "ColorTable=13FF-F51B-B2E0-2F49" & System.Environment.NewLine & _
                          "MaschineName=IGLD G53_A" & System.Environment.NewLine & _
                          "KettenFlexi=0" & System.Environment.NewLine & _
                          "NKRvisible=0" & System.Environment.NewLine & _
                          "HueRiApp=1" & System.Environment.NewLine & _
                          "HBBefuellen=1" & System.Environment.NewLine & _
                          "Topf2Drehzahl=0" & System.Environment.NewLine & _
                          "[Maschinenparameter]" & System.Environment.NewLine & _
                          "NKR_Einzug=0" & System.Environment.NewLine & _
                          "SM_Teller=0" & System.Environment.NewLine & _
                          "ServoMontage=0" & System.Environment.NewLine & _
                          "ServoMasspresse=0"
        objDateiMacher = New StreamWriter(Application.StartupPath & "\kokev.INI")
        objDateiMacher.Write(defaultiniwerte)
        objDateiMacher.Close()
        objDateiMacher = Nothing


        MsgBox(defaultiniwerte)


    End Sub

End Class
