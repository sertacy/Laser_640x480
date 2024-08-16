Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Drawing
Imports System.Windows.Forms
Imports Laser
Imports System.Runtime.InteropServices 'dll import namespaces um taskleiste auszuschalten


' User-Interface (Visualisierung) Laser Version 0.0.0.1  Ausrichtung LINKS (mit Bürste)
' Entwicklung: Sertac Yilmaz
' 2007 Copyright by Sertac Yilmaz 
' LaserG67HP_Peter

Public Class FMain
    Inherits System.Windows.Forms.Form

    'dll Imports zum ausschalten der System-Taskleiste! 
    <DllImport("user32.dll")> _
    Public Shared Function ShowWindow(ByVal hWnd As Integer, ByVal wFlags As Integer) As Integer
    End Function
    <DllImport("user32.dll")> _
    Public Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    End Function
    'dll Imports für Sytem-Taskleiste Ende!


    'variablen aus der SPS****************
    'touchpanel read/write:
    Public myTP_LaserAktiv As Boolean
    Public myTP_LaserHand As Boolean
    Public myTP_KammeraAktiv As Boolean
    Public myTP_Hand As Boolean
    Public myTP_Auto As Boolean
    'stoerung anlage read:
    Public myS_StUeberlast As Boolean
    Public myS_StLaser As Boolean
    Public myS_StKammera As Boolean
    Public myS_StKupplung As Boolean
    Public myS_StSpeicherSchutz As Boolean
    Public myS_StLaserSchutz As Boolean
    Public myS_StSpeicher As Boolean
    Public myS_StSammelstoerung As Boolean
    Public myS_StDruck As Boolean
    Public myS_StNotAus As Boolean
    Public myS_StRef As Boolean
    Public myS_StSchutzTuer As Boolean
    Public myS_StSchutzHaube As Boolean
    Public myS_StAbsaugFilter As Boolean
    Public myS_StAbsaug100p As Boolean

    Public myS_MSpeicherVoll As Boolean
    Public myS_MSpeicherLeer As Boolean
    Public myS_MWarteSpeicher As Boolean
    Public myS_MWarteLaser As Boolean
    Public myS_MHand As Boolean
    Public myS_FKamera As Boolean
    Public myS_FLaser As Boolean
    Public myS_MAutoStart As Boolean
    Public myS_MAutoStop As Boolean
    Public mySI_Gliederzahl As Short
    Public mySI_ProgNr As Short
    Public mySI_IO As Short
    Public mySI_NIO As Short
    Public myS_StShutter As Boolean
    Public myS_MShutterBetrieb As Boolean
    Public mySI_FLaser As Short 'fehlerzaehler laser
    Public mySI_FKamera As Short 'fehlerzaehler kamera

    Public myS_StLasAuftragEnde As Boolean 'Auftrag Ende
    Public myS_StLasShutterZu As Boolean   'Shutter zu 
    Public myS_StLasSoftware As Boolean   'Software NIO
    Public myS_StLasHardware As Boolean  'Hardware NIO
    Public myS_StIndexVor As Boolean   'Index vor NIO
    Public myS_StIndexRueck As Boolean   'Index rueck NIO

    Public myIFrgMoma1 As Boolean
    Public myIFrgMoma2 As Boolean
    Public myS_MMarkieren As Boolean
    Public myS_MBuersteNBereit As Boolean
    Public myS_MDrehgMontPos As Boolean

    Public myCounterSoll As Short 'CounterSoll read-write
    Public myCounterIst As Short  'CounterIst read-write
    Public myTPCounterAktiv As Boolean 'write
    Public mySAuftragFertig As Boolean 'read

    ' ende vars aus der sps ************

    Public adsClient As TcAdsClient
    Public dataStream As AdsStream   'daten strom zur schnitstelle
    Public binread As BinaryReader   'reader object zum einlesen

    Public twincataktif As Boolean
    Public strpath As String = ""    'verzeichnissstruktur 
    Public hConnect() As Integer   'variablen handler array 

    'semaphoren für die Kettenfehler einträge mit CFehlerschreiber = CF...
    Public CFS_StUeberlast As Boolean = False
    Public CFS_StLaser As Boolean = False
    Public CFS_StKammera As Boolean = False
    Public CFS_StKupplung As Boolean = False
    Public CFS_StSpeicherSchutz As Boolean = False
    Public CFS_StLaserSchutz As Boolean = False
    Public CFS_StSpeicher As Boolean = False
    Public CFS_StDruck As Boolean = False
    Public CFS_StNotAus As Boolean = False
    Public CFS_StRef As Boolean = False
    Public CFS_StAbsaugFilter As Boolean = False
    Public CFS_StAbsaug100p As Boolean = False
    Public CFS_S_FKamera As Boolean = False
    Public CFS_S_FLaser As Boolean = False
    Public CFS_S_StShutter As Boolean = False

    Public CFS_StLasSoftware As Boolean = False  'Software NIO
    Public CFS_StLasHardware As Boolean = False  'Hardware NIO
    Public CFS_StIndexVor As Boolean = False 'Index vor NIO
    Public CFS_StIndexRueck As Boolean = False 'Index rueck NIO


#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Public resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FMain))
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuBeenden As System.Windows.Forms.MenuItem
    Friend WithEvents pnlFirmenLogo As System.Windows.Forms.Panel
    Friend WithEvents pnlVerbingung As System.Windows.Forms.Panel
    Friend WithEvents pnldatum As System.Windows.Forms.Panel
    Friend WithEvents pnlZeit As System.Windows.Forms.Panel
    Friend WithEvents pnlArtikelnr As System.Windows.Forms.Panel
    Friend WithEvents pnlGlieder As System.Windows.Forms.Panel
    Friend WithEvents pnlStatus As System.Windows.Forms.Panel
    Friend WithEvents pnlStoerung As System.Windows.Forms.Panel
    Friend WithEvents pnlKettenAuftrag As System.Windows.Forms.Panel
    Friend WithEvents pnlTakteMin As System.Windows.Forms.Panel
    Friend WithEvents lblDatum As System.Windows.Forms.Label
    Friend WithEvents lblZeit As System.Windows.Forms.Label
    Friend WithEvents lblGlieder As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Lbltwincat As System.Windows.Forms.Label
    Friend WithEvents Llbtcpip As System.Windows.Forms.Label
    Friend WithEvents picIwis As System.Windows.Forms.PictureBox
    Friend WithEvents lblmaschienenName As System.Windows.Forms.Label
    Friend WithEvents lbltaktemin2 As System.Windows.Forms.Label
    Friend WithEvents btnKettenspeicher As System.Windows.Forms.Button
    Friend WithEvents btnKamera As System.Windows.Forms.Button
    Friend WithEvents btnLaser As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents piclaseraktiv As System.Windows.Forms.PictureBox
    Friend WithEvents pickameraaktiv As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents piclasereingang As System.Windows.Forms.PictureBox
    Friend WithEvents piclaserausgang As System.Windows.Forms.PictureBox
    Friend WithEvents pickameraeingang As System.Windows.Forms.PictureBox
    Friend WithEvents pickameraausgang As System.Windows.Forms.PictureBox
    Friend WithEvents btnLaserStatus As System.Windows.Forms.Button
    Friend WithEvents btnKameraStatus As System.Windows.Forms.Button
    Friend WithEvents btnSpeicherStatus As System.Windows.Forms.Button
    Friend WithEvents picspeichereingang As System.Windows.Forms.PictureBox
    Friend WithEvents picspeicherausgang As System.Windows.Forms.PictureBox
    Friend WithEvents lblStoerungen As System.Windows.Forms.Label
    Friend WithEvents lblMaschinenStatus As System.Windows.Forms.Label
    Friend WithEvents btnEinrichtbetrieb As System.Windows.Forms.Button
    Friend WithEvents btnReferenzieren As System.Windows.Forms.Button
    Friend WithEvents btnAutomatik As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LeseTimer As System.Windows.Forms.Timer
    Friend WithEvents picboxTwincat As System.Windows.Forms.PictureBox
    Friend WithEvents picboxTcpIp As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgruen0 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxrot0 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgruen1 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxrot1 As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgruen1blau As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgruen0blau As System.Windows.Forms.PictureBox
    Friend WithEvents picboxrot1blau As System.Windows.Forms.PictureBox
    Friend WithEvents picboxrot0blau As System.Windows.Forms.PictureBox
    Friend WithEvents lblProgNr As System.Windows.Forms.Label
    Friend WithEvents lblAnzahlIO As System.Windows.Forms.Label
    Friend WithEvents lblAnzahlNIO As System.Windows.Forms.Label
    Friend WithEvents btnIOruecksetz As System.Windows.Forms.Button
    Friend WithEvents btnIOnotRuecksetz As System.Windows.Forms.Button
    Friend WithEvents lbl1StLaserSchutz As System.Windows.Forms.Label
    Friend WithEvents lbl2StSpeicherSchutz As System.Windows.Forms.Label
    Friend WithEvents lbl3StUeberlast As System.Windows.Forms.Label
    Friend WithEvents lbl4StSpeicher As System.Windows.Forms.Label
    Friend WithEvents lbl5StKupplung As System.Windows.Forms.Label
    Friend WithEvents lbl6StDruck As System.Windows.Forms.Label
    Friend WithEvents lbl7StNotAus As System.Windows.Forms.Label
    Friend WithEvents lblProgrammnummer As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblKameraNIO As System.Windows.Forms.Label
    Friend WithEvents txtKameraNIO As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblLaserNIO As System.Windows.Forms.Label
    Friend WithEvents txtLaserNIO As System.Windows.Forms.Label
    Friend WithEvents lbl8StSchutzTuer As System.Windows.Forms.Label
    Friend WithEvents lbl8StSchutzHaube As System.Windows.Forms.Label
    Friend WithEvents lbl9StAbsaugFilter As System.Windows.Forms.Label
    Friend WithEvents lbl9StAbsaug100p As System.Windows.Forms.Label
    Friend WithEvents lblmyS_FKamera As System.Windows.Forms.Label
    Friend WithEvents lblmyS_FLaser As System.Windows.Forms.Label
    Friend WithEvents lblmyS_StShutter As System.Windows.Forms.Label
    Friend WithEvents lblmyS_StLasAuftragEnde As System.Windows.Forms.Label
    Friend WithEvents lblmyS_StLasShutterZu As System.Windows.Forms.Label
    Friend WithEvents lblmyS_StLasSoftware As System.Windows.Forms.Label
    Friend WithEvents lblmyS_StLasHardware As System.Windows.Forms.Label
    Friend WithEvents lblmyS_StIndexVor As System.Windows.Forms.Label
    Friend WithEvents lblmyS_StIndexRueck As System.Windows.Forms.Label
    Friend WithEvents lblmyIFrgMoma1 As System.Windows.Forms.Button
    Friend WithEvents lblmyIFrgMoma2 As System.Windows.Forms.Button
    Friend WithEvents lblmyS_MMarkieren As System.Windows.Forms.Label
    Friend WithEvents lblmyS_MBuersteNBereit As System.Windows.Forms.Button
    Friend WithEvents btnCounter As System.Windows.Forms.Button
    Friend WithEvents lblCounterTextSoll As System.Windows.Forms.Label
    Friend WithEvents lblCounterTextIst As System.Windows.Forms.Label
    Friend WithEvents lblCounterSoll As System.Windows.Forms.Label
    Friend WithEvents lblCounterIst As System.Windows.Forms.Label
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FMain))
        Me.Lbltwincat = New System.Windows.Forms.Label
        Me.picboxTwincat = New System.Windows.Forms.PictureBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuBeenden = New System.Windows.Forms.MenuItem
        Me.pnlFirmenLogo = New System.Windows.Forms.Panel
        Me.picIwis = New System.Windows.Forms.PictureBox
        Me.picboxrot1 = New System.Windows.Forms.PictureBox
        Me.picboxgruen1 = New System.Windows.Forms.PictureBox
        Me.picboxrot0 = New System.Windows.Forms.PictureBox
        Me.lblmaschienenName = New System.Windows.Forms.Label
        Me.picboxgruen0 = New System.Windows.Forms.PictureBox
        Me.picboxgruen1blau = New System.Windows.Forms.PictureBox
        Me.picboxgruen0blau = New System.Windows.Forms.PictureBox
        Me.picboxrot1blau = New System.Windows.Forms.PictureBox
        Me.picboxrot0blau = New System.Windows.Forms.PictureBox
        Me.pnlVerbingung = New System.Windows.Forms.Panel
        Me.picboxTcpIp = New System.Windows.Forms.PictureBox
        Me.Llbtcpip = New System.Windows.Forms.Label
        Me.pnldatum = New System.Windows.Forms.Panel
        Me.lblDatum = New System.Windows.Forms.Label
        Me.pnlZeit = New System.Windows.Forms.Panel
        Me.lblZeit = New System.Windows.Forms.Label
        Me.pnlArtikelnr = New System.Windows.Forms.Panel
        Me.lblProgNr = New System.Windows.Forms.Label
        Me.lblProgrammnummer = New System.Windows.Forms.Label
        Me.pnlGlieder = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblGlieder = New System.Windows.Forms.Label
        Me.pnlStatus = New System.Windows.Forms.Panel
        Me.lblMaschinenStatus = New System.Windows.Forms.Label
        Me.pnlStoerung = New System.Windows.Forms.Panel
        Me.lblStoerungen = New System.Windows.Forms.Label
        Me.pnlKettenAuftrag = New System.Windows.Forms.Panel
        Me.lblAnzahlIO = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.pnlTakteMin = New System.Windows.Forms.Panel
        Me.lblAnzahlNIO = New System.Windows.Forms.Label
        Me.lbltaktemin2 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnKettenspeicher = New System.Windows.Forms.Button
        Me.btnKamera = New System.Windows.Forms.Button
        Me.btnLaser = New System.Windows.Forms.Button
        Me.lblmyS_FLaser = New System.Windows.Forms.Label
        Me.lblmyS_FKamera = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.lblmyIFrgMoma1 = New System.Windows.Forms.Button
        Me.lblmyIFrgMoma2 = New System.Windows.Forms.Button
        Me.piclaseraktiv = New System.Windows.Forms.PictureBox
        Me.pickameraaktiv = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.piclasereingang = New System.Windows.Forms.PictureBox
        Me.piclaserausgang = New System.Windows.Forms.PictureBox
        Me.pickameraeingang = New System.Windows.Forms.PictureBox
        Me.pickameraausgang = New System.Windows.Forms.PictureBox
        Me.btnLaserStatus = New System.Windows.Forms.Button
        Me.btnKameraStatus = New System.Windows.Forms.Button
        Me.btnSpeicherStatus = New System.Windows.Forms.Button
        Me.picspeichereingang = New System.Windows.Forms.PictureBox
        Me.picspeicherausgang = New System.Windows.Forms.PictureBox
        Me.btnEinrichtbetrieb = New System.Windows.Forms.Button
        Me.btnReferenzieren = New System.Windows.Forms.Button
        Me.lbl1StLaserSchutz = New System.Windows.Forms.Label
        Me.btnAutomatik = New System.Windows.Forms.Button
        Me.LeseTimer = New System.Windows.Forms.Timer(Me.components)
        Me.btnIOruecksetz = New System.Windows.Forms.Button
        Me.btnIOnotRuecksetz = New System.Windows.Forms.Button
        Me.lbl2StSpeicherSchutz = New System.Windows.Forms.Label
        Me.lbl3StUeberlast = New System.Windows.Forms.Label
        Me.lbl4StSpeicher = New System.Windows.Forms.Label
        Me.lbl5StKupplung = New System.Windows.Forms.Label
        Me.lbl6StDruck = New System.Windows.Forms.Label
        Me.lbl7StNotAus = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblKameraNIO = New System.Windows.Forms.Label
        Me.txtKameraNIO = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblLaserNIO = New System.Windows.Forms.Label
        Me.txtLaserNIO = New System.Windows.Forms.Label
        Me.lbl8StSchutzTuer = New System.Windows.Forms.Label
        Me.lbl8StSchutzHaube = New System.Windows.Forms.Label
        Me.lbl9StAbsaugFilter = New System.Windows.Forms.Label
        Me.lbl9StAbsaug100p = New System.Windows.Forms.Label
        Me.lblmyS_StShutter = New System.Windows.Forms.Label
        Me.lblmyS_StLasAuftragEnde = New System.Windows.Forms.Label
        Me.lblmyS_StLasShutterZu = New System.Windows.Forms.Label
        Me.lblmyS_StLasSoftware = New System.Windows.Forms.Label
        Me.lblmyS_StLasHardware = New System.Windows.Forms.Label
        Me.lblmyS_StIndexVor = New System.Windows.Forms.Label
        Me.lblmyS_StIndexRueck = New System.Windows.Forms.Label
        Me.lblmyS_MMarkieren = New System.Windows.Forms.Label
        Me.lblmyS_MBuersteNBereit = New System.Windows.Forms.Button
        Me.btnCounter = New System.Windows.Forms.Button
        Me.lblCounterTextSoll = New System.Windows.Forms.Label
        Me.lblCounterTextIst = New System.Windows.Forms.Label
        Me.lblCounterSoll = New System.Windows.Forms.Label
        Me.lblCounterIst = New System.Windows.Forms.Label
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.pnlFirmenLogo.SuspendLayout()
        Me.pnlVerbingung.SuspendLayout()
        Me.pnldatum.SuspendLayout()
        Me.pnlZeit.SuspendLayout()
        Me.pnlArtikelnr.SuspendLayout()
        Me.pnlGlieder.SuspendLayout()
        Me.pnlStatus.SuspendLayout()
        Me.pnlStoerung.SuspendLayout()
        Me.pnlKettenAuftrag.SuspendLayout()
        Me.pnlTakteMin.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbltwincat
        '
        Me.Lbltwincat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbltwincat.Location = New System.Drawing.Point(18, 28)
        Me.Lbltwincat.Name = "Lbltwincat"
        Me.Lbltwincat.Size = New System.Drawing.Size(56, 16)
        Me.Lbltwincat.TabIndex = 0
        Me.Lbltwincat.Text = "TwinCAT"
        '
        'picboxTwincat
        '
        Me.picboxTwincat.Image = CType(resources.GetObject("picboxTwincat.Image"), System.Drawing.Image)
        Me.picboxTwincat.Location = New System.Drawing.Point(2, 28)
        Me.picboxTwincat.Name = "picboxTwincat"
        Me.picboxTwincat.Size = New System.Drawing.Size(16, 16)
        Me.picboxTwincat.TabIndex = 1
        Me.picboxTwincat.TabStop = False
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuBeenden})
        Me.MenuItem1.Text = "Aktionen ausführen"
        '
        'MenuBeenden
        '
        Me.MenuBeenden.Index = 0
        Me.MenuBeenden.Text = "Beenden"
        '
        'pnlFirmenLogo
        '
        Me.pnlFirmenLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFirmenLogo.Controls.Add(Me.picIwis)
        Me.pnlFirmenLogo.Controls.Add(Me.picboxrot1)
        Me.pnlFirmenLogo.Controls.Add(Me.picboxgruen1)
        Me.pnlFirmenLogo.Controls.Add(Me.picboxrot0)
        Me.pnlFirmenLogo.Controls.Add(Me.lblmaschienenName)
        Me.pnlFirmenLogo.Controls.Add(Me.picboxgruen0)
        Me.pnlFirmenLogo.Controls.Add(Me.picboxgruen1blau)
        Me.pnlFirmenLogo.Controls.Add(Me.picboxgruen0blau)
        Me.pnlFirmenLogo.Controls.Add(Me.picboxrot1blau)
        Me.pnlFirmenLogo.Controls.Add(Me.picboxrot0blau)
        Me.pnlFirmenLogo.Location = New System.Drawing.Point(0, 0)
        Me.pnlFirmenLogo.Name = "pnlFirmenLogo"
        Me.pnlFirmenLogo.Size = New System.Drawing.Size(104, 69)
        Me.pnlFirmenLogo.TabIndex = 4
        '
        'picIwis
        '
        Me.picIwis.Image = CType(resources.GetObject("picIwis.Image"), System.Drawing.Image)
        Me.picIwis.Location = New System.Drawing.Point(0, 16)
        Me.picIwis.Name = "picIwis"
        Me.picIwis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picIwis.TabIndex = 16
        Me.picIwis.TabStop = False
        '
        'picboxrot1
        '
        Me.picboxrot1.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        Me.picboxrot1.Location = New System.Drawing.Point(26, 42)
        Me.picboxrot1.Name = "picboxrot1"
        Me.picboxrot1.Size = New System.Drawing.Size(16, 16)
        Me.picboxrot1.TabIndex = 53
        Me.picboxrot1.TabStop = False
        '
        'picboxgruen1
        '
        Me.picboxgruen1.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
        Me.picboxgruen1.Location = New System.Drawing.Point(6, 42)
        Me.picboxgruen1.Name = "picboxgruen1"
        Me.picboxgruen1.Size = New System.Drawing.Size(16, 16)
        Me.picboxgruen1.TabIndex = 52
        Me.picboxgruen1.TabStop = False
        '
        'picboxrot0
        '
        Me.picboxrot0.Image = CType(resources.GetObject("picboxrot0.Image"), System.Drawing.Image)
        Me.picboxrot0.Location = New System.Drawing.Point(26, 24)
        Me.picboxrot0.Name = "picboxrot0"
        Me.picboxrot0.Size = New System.Drawing.Size(16, 16)
        Me.picboxrot0.TabIndex = 51
        Me.picboxrot0.TabStop = False
        '
        'lblmaschienenName
        '
        Me.lblmaschienenName.BackColor = System.Drawing.Color.Transparent
        Me.lblmaschienenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmaschienenName.Location = New System.Drawing.Point(6, -2)
        Me.lblmaschienenName.Name = "lblmaschienenName"
        Me.lblmaschienenName.Size = New System.Drawing.Size(92, 18)
        Me.lblmaschienenName.TabIndex = 16
        Me.lblmaschienenName.Text = "Laser"
        Me.lblmaschienenName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picboxgruen0
        '
        Me.picboxgruen0.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
        Me.picboxgruen0.Location = New System.Drawing.Point(6, 24)
        Me.picboxgruen0.Name = "picboxgruen0"
        Me.picboxgruen0.Size = New System.Drawing.Size(16, 16)
        Me.picboxgruen0.TabIndex = 50
        Me.picboxgruen0.TabStop = False
        '
        'picboxgruen1blau
        '
        Me.picboxgruen1blau.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
        Me.picboxgruen1blau.Location = New System.Drawing.Point(48, 42)
        Me.picboxgruen1blau.Name = "picboxgruen1blau"
        Me.picboxgruen1blau.Size = New System.Drawing.Size(16, 16)
        Me.picboxgruen1blau.TabIndex = 50
        Me.picboxgruen1blau.TabStop = False
        '
        'picboxgruen0blau
        '
        Me.picboxgruen0blau.Image = CType(resources.GetObject("picboxgruen0blau.Image"), System.Drawing.Image)
        Me.picboxgruen0blau.Location = New System.Drawing.Point(48, 24)
        Me.picboxgruen0blau.Name = "picboxgruen0blau"
        Me.picboxgruen0blau.Size = New System.Drawing.Size(16, 16)
        Me.picboxgruen0blau.TabIndex = 51
        Me.picboxgruen0blau.TabStop = False
        '
        'picboxrot1blau
        '
        Me.picboxrot1blau.Image = CType(resources.GetObject("picboxrot1blau.Image"), System.Drawing.Image)
        Me.picboxrot1blau.Location = New System.Drawing.Point(68, 42)
        Me.picboxrot1blau.Name = "picboxrot1blau"
        Me.picboxrot1blau.Size = New System.Drawing.Size(16, 16)
        Me.picboxrot1blau.TabIndex = 50
        Me.picboxrot1blau.TabStop = False
        '
        'picboxrot0blau
        '
        Me.picboxrot0blau.Image = CType(resources.GetObject("picboxrot0blau.Image"), System.Drawing.Image)
        Me.picboxrot0blau.Location = New System.Drawing.Point(68, 24)
        Me.picboxrot0blau.Name = "picboxrot0blau"
        Me.picboxrot0blau.Size = New System.Drawing.Size(16, 16)
        Me.picboxrot0blau.TabIndex = 50
        Me.picboxrot0blau.TabStop = False
        '
        'pnlVerbingung
        '
        Me.pnlVerbingung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlVerbingung.Controls.Add(Me.Lbltwincat)
        Me.pnlVerbingung.Controls.Add(Me.picboxTcpIp)
        Me.pnlVerbingung.Controls.Add(Me.Llbtcpip)
        Me.pnlVerbingung.Controls.Add(Me.picboxTwincat)
        Me.pnlVerbingung.Location = New System.Drawing.Point(104, 0)
        Me.pnlVerbingung.Name = "pnlVerbingung"
        Me.pnlVerbingung.Size = New System.Drawing.Size(70, 69)
        Me.pnlVerbingung.TabIndex = 5
        '
        'picboxTcpIp
        '
        Me.picboxTcpIp.Image = CType(resources.GetObject("picboxTcpIp.Image"), System.Drawing.Image)
        Me.picboxTcpIp.Location = New System.Drawing.Point(2, 49)
        Me.picboxTcpIp.Name = "picboxTcpIp"
        Me.picboxTcpIp.Size = New System.Drawing.Size(16, 16)
        Me.picboxTcpIp.TabIndex = 16
        Me.picboxTcpIp.TabStop = False
        '
        'Llbtcpip
        '
        Me.Llbtcpip.Location = New System.Drawing.Point(18, 50)
        Me.Llbtcpip.Name = "Llbtcpip"
        Me.Llbtcpip.Size = New System.Drawing.Size(56, 16)
        Me.Llbtcpip.TabIndex = 16
        Me.Llbtcpip.Text = "TCP/IP"
        '
        'pnldatum
        '
        Me.pnldatum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnldatum.Controls.Add(Me.lblDatum)
        Me.pnldatum.Location = New System.Drawing.Point(174, 0)
        Me.pnldatum.Name = "pnldatum"
        Me.pnldatum.Size = New System.Drawing.Size(76, 35)
        Me.pnldatum.TabIndex = 6
        '
        'lblDatum
        '
        Me.lblDatum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatum.Location = New System.Drawing.Point(0, 8)
        Me.lblDatum.Name = "lblDatum"
        Me.lblDatum.Size = New System.Drawing.Size(67, 16)
        Me.lblDatum.TabIndex = 0
        Me.lblDatum.Text = "Datum"
        Me.lblDatum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlZeit
        '
        Me.pnlZeit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlZeit.Controls.Add(Me.lblZeit)
        Me.pnlZeit.Location = New System.Drawing.Point(174, 34)
        Me.pnlZeit.Name = "pnlZeit"
        Me.pnlZeit.Size = New System.Drawing.Size(76, 35)
        Me.pnlZeit.TabIndex = 7
        '
        'lblZeit
        '
        Me.lblZeit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZeit.Location = New System.Drawing.Point(0, 7)
        Me.lblZeit.Name = "lblZeit"
        Me.lblZeit.Size = New System.Drawing.Size(67, 16)
        Me.lblZeit.TabIndex = 1
        Me.lblZeit.Text = "Zeit"
        Me.lblZeit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlArtikelnr
        '
        Me.pnlArtikelnr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlArtikelnr.Controls.Add(Me.lblProgNr)
        Me.pnlArtikelnr.Controls.Add(Me.lblProgrammnummer)
        Me.pnlArtikelnr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlArtikelnr.Location = New System.Drawing.Point(250, 0)
        Me.pnlArtikelnr.Name = "pnlArtikelnr"
        Me.pnlArtikelnr.Size = New System.Drawing.Size(120, 35)
        Me.pnlArtikelnr.TabIndex = 8
        '
        'lblProgNr
        '
        Me.lblProgNr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgNr.Location = New System.Drawing.Point(-2, 0)
        Me.lblProgNr.Name = "lblProgNr"
        Me.lblProgNr.Size = New System.Drawing.Size(118, 16)
        Me.lblProgNr.TabIndex = 16
        Me.lblProgNr.Text = "0"
        Me.lblProgNr.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblProgrammnummer
        '
        Me.lblProgrammnummer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgrammnummer.Location = New System.Drawing.Point(-4, 16)
        Me.lblProgrammnummer.Name = "lblProgrammnummer"
        Me.lblProgrammnummer.Size = New System.Drawing.Size(124, 16)
        Me.lblProgrammnummer.TabIndex = 1
        Me.lblProgrammnummer.Text = "Programmnummer"
        Me.lblProgrammnummer.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlGlieder
        '
        Me.pnlGlieder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlGlieder.Controls.Add(Me.Label5)
        Me.pnlGlieder.Controls.Add(Me.lblGlieder)
        Me.pnlGlieder.Location = New System.Drawing.Point(370, 0)
        Me.pnlGlieder.Name = "pnlGlieder"
        Me.pnlGlieder.Size = New System.Drawing.Size(64, 35)
        Me.pnlGlieder.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Glieder"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGlieder
        '
        Me.lblGlieder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGlieder.Location = New System.Drawing.Point(-2, 0)
        Me.lblGlieder.Name = "lblGlieder"
        Me.lblGlieder.Size = New System.Drawing.Size(64, 16)
        Me.lblGlieder.TabIndex = 18
        Me.lblGlieder.Text = "0"
        Me.lblGlieder.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlStatus
        '
        Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlStatus.Controls.Add(Me.lblMaschinenStatus)
        Me.pnlStatus.Location = New System.Drawing.Point(510, 0)
        Me.pnlStatus.Name = "pnlStatus"
        Me.pnlStatus.Size = New System.Drawing.Size(122, 35)
        Me.pnlStatus.TabIndex = 11
        '
        'lblMaschinenStatus
        '
        Me.lblMaschinenStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblMaschinenStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaschinenStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMaschinenStatus.Location = New System.Drawing.Point(-8, 0)
        Me.lblMaschinenStatus.Name = "lblMaschinenStatus"
        Me.lblMaschinenStatus.Size = New System.Drawing.Size(136, 32)
        Me.lblMaschinenStatus.TabIndex = 45
        Me.lblMaschinenStatus.Text = "MaschinenStatus"
        Me.lblMaschinenStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlStoerung
        '
        Me.pnlStoerung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlStoerung.Controls.Add(Me.lblStoerungen)
        Me.pnlStoerung.Location = New System.Drawing.Point(510, 34)
        Me.pnlStoerung.Name = "pnlStoerung"
        Me.pnlStoerung.Size = New System.Drawing.Size(122, 35)
        Me.pnlStoerung.TabIndex = 12
        '
        'lblStoerungen
        '
        Me.lblStoerungen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStoerungen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStoerungen.Location = New System.Drawing.Point(-8, 0)
        Me.lblStoerungen.Name = "lblStoerungen"
        Me.lblStoerungen.Size = New System.Drawing.Size(136, 32)
        Me.lblStoerungen.TabIndex = 44
        Me.lblStoerungen.Text = "Störung"
        Me.lblStoerungen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlKettenAuftrag
        '
        Me.pnlKettenAuftrag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlKettenAuftrag.Controls.Add(Me.lblAnzahlIO)
        Me.pnlKettenAuftrag.Controls.Add(Me.Label6)
        Me.pnlKettenAuftrag.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlKettenAuftrag.Location = New System.Drawing.Point(434, 0)
        Me.pnlKettenAuftrag.Name = "pnlKettenAuftrag"
        Me.pnlKettenAuftrag.Size = New System.Drawing.Size(76, 35)
        Me.pnlKettenAuftrag.TabIndex = 13
        '
        'lblAnzahlIO
        '
        Me.lblAnzahlIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnzahlIO.Location = New System.Drawing.Point(0, 0)
        Me.lblAnzahlIO.Name = "lblAnzahlIO"
        Me.lblAnzahlIO.Size = New System.Drawing.Size(74, 16)
        Me.lblAnzahlIO.TabIndex = 21
        Me.lblAnzahlIO.Text = "0"
        Me.lblAnzahlIO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-4, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Anzahl IO"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlTakteMin
        '
        Me.pnlTakteMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlTakteMin.Controls.Add(Me.lblAnzahlNIO)
        Me.pnlTakteMin.Controls.Add(Me.lbltaktemin2)
        Me.pnlTakteMin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlTakteMin.Location = New System.Drawing.Point(434, 34)
        Me.pnlTakteMin.Name = "pnlTakteMin"
        Me.pnlTakteMin.Size = New System.Drawing.Size(76, 35)
        Me.pnlTakteMin.TabIndex = 14
        '
        'lblAnzahlNIO
        '
        Me.lblAnzahlNIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnzahlNIO.Location = New System.Drawing.Point(0, 0)
        Me.lblAnzahlNIO.Name = "lblAnzahlNIO"
        Me.lblAnzahlNIO.Size = New System.Drawing.Size(72, 16)
        Me.lblAnzahlNIO.TabIndex = 22
        Me.lblAnzahlNIO.Text = "0"
        Me.lblAnzahlNIO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbltaktemin2
        '
        Me.lbltaktemin2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltaktemin2.Location = New System.Drawing.Point(-2, 16)
        Me.lbltaktemin2.Name = "lbltaktemin2"
        Me.lbltaktemin2.Size = New System.Drawing.Size(74, 20)
        Me.lbltaktemin2.TabIndex = 21
        Me.lbltaktemin2.Text = "Anzahl NIO"
        Me.lbltaktemin2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'btnKettenspeicher
        '
        Me.btnKettenspeicher.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnKettenspeicher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKettenspeicher.Location = New System.Drawing.Point(60, 192)
        Me.btnKettenspeicher.Name = "btnKettenspeicher"
        Me.btnKettenspeicher.Size = New System.Drawing.Size(100, 200)
        Me.btnKettenspeicher.TabIndex = 15
        Me.btnKettenspeicher.Text = "Speicher"
        Me.btnKettenspeicher.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnKamera
        '
        Me.btnKamera.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnKamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKamera.Location = New System.Drawing.Point(190, 192)
        Me.btnKamera.Name = "btnKamera"
        Me.btnKamera.Size = New System.Drawing.Size(100, 200)
        Me.btnKamera.TabIndex = 16
        Me.btnKamera.Text = "Kamera"
        Me.btnKamera.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnLaser
        '
        Me.btnLaser.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLaser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaser.Location = New System.Drawing.Point(320, 192)
        Me.btnLaser.Name = "btnLaser"
        Me.btnLaser.Size = New System.Drawing.Size(100, 200)
        Me.btnLaser.TabIndex = 17
        Me.btnLaser.Text = "Laser"
        Me.btnLaser.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmyS_FLaser
        '
        Me.lblmyS_FLaser.BackColor = System.Drawing.Color.Red
        Me.lblmyS_FLaser.Location = New System.Drawing.Point(330, 238)
        Me.lblmyS_FLaser.Name = "lblmyS_FLaser"
        Me.lblmyS_FLaser.Size = New System.Drawing.Size(80, 18)
        Me.lblmyS_FLaser.TabIndex = 19
        Me.lblmyS_FLaser.Text = "nicht gelasert!"
        Me.lblmyS_FLaser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_FLaser.Visible = False
        '
        'lblmyS_FKamera
        '
        Me.lblmyS_FKamera.BackColor = System.Drawing.Color.Red
        Me.lblmyS_FKamera.Location = New System.Drawing.Point(200, 238)
        Me.lblmyS_FKamera.Name = "lblmyS_FKamera"
        Me.lblmyS_FKamera.Size = New System.Drawing.Size(80, 18)
        Me.lblmyS_FKamera.TabIndex = 20
        Me.lblmyS_FKamera.Text = "nicht gelasert!"
        Me.lblmyS_FKamera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_FKamera.Visible = False
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(290, 272)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 30)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "<"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(160, 272)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(30, 30)
        Me.Button2.TabIndex = 26
        Me.Button2.Text = "<"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(30, 272)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 30)
        Me.Button3.TabIndex = 27
        Me.Button3.Text = "<"
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(420, 272)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(30, 30)
        Me.Button4.TabIndex = 28
        Me.Button4.Text = "<"
        '
        'lblmyIFrgMoma1
        '
        Me.lblmyIFrgMoma1.Enabled = False
        Me.lblmyIFrgMoma1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblmyIFrgMoma1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyIFrgMoma1.Location = New System.Drawing.Point(500, 246)
        Me.lblmyIFrgMoma1.Name = "lblmyIFrgMoma1"
        Me.lblmyIFrgMoma1.Size = New System.Drawing.Size(40, 40)
        Me.lblmyIFrgMoma1.TabIndex = 29
        Me.lblmyIFrgMoma1.Text = "F.Sp1"
        '
        'lblmyIFrgMoma2
        '
        Me.lblmyIFrgMoma2.Enabled = False
        Me.lblmyIFrgMoma2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblmyIFrgMoma2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyIFrgMoma2.Location = New System.Drawing.Point(500, 290)
        Me.lblmyIFrgMoma2.Name = "lblmyIFrgMoma2"
        Me.lblmyIFrgMoma2.Size = New System.Drawing.Size(40, 40)
        Me.lblmyIFrgMoma2.TabIndex = 30
        Me.lblmyIFrgMoma2.Text = "F.Sp2"
        '
        'piclaseraktiv
        '
        Me.piclaseraktiv.Image = CType(resources.GetObject("piclaseraktiv.Image"), System.Drawing.Image)
        Me.piclaseraktiv.Location = New System.Drawing.Point(344, 214)
        Me.piclaseraktiv.Name = "piclaseraktiv"
        Me.piclaseraktiv.Size = New System.Drawing.Size(16, 16)
        Me.piclaseraktiv.TabIndex = 31
        Me.piclaseraktiv.TabStop = False
        '
        'pickameraaktiv
        '
        Me.pickameraaktiv.Image = CType(resources.GetObject("pickameraaktiv.Image"), System.Drawing.Image)
        Me.pickameraaktiv.Location = New System.Drawing.Point(214, 214)
        Me.pickameraaktiv.Name = "pickameraaktiv"
        Me.pickameraaktiv.Size = New System.Drawing.Size(16, 16)
        Me.pickameraaktiv.TabIndex = 32
        Me.pickameraaktiv.TabStop = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label7.Location = New System.Drawing.Point(368, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 18)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Aktiv"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label8.Location = New System.Drawing.Point(236, 213)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 18)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Aktiv"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'piclasereingang
        '
        Me.piclasereingang.Image = CType(resources.GetObject("piclasereingang.Image"), System.Drawing.Image)
        Me.piclasereingang.Location = New System.Drawing.Point(400, 280)
        Me.piclasereingang.Name = "piclasereingang"
        Me.piclasereingang.Size = New System.Drawing.Size(16, 16)
        Me.piclasereingang.TabIndex = 35
        Me.piclasereingang.TabStop = False
        '
        'piclaserausgang
        '
        Me.piclaserausgang.Image = CType(resources.GetObject("piclaserausgang.Image"), System.Drawing.Image)
        Me.piclaserausgang.Location = New System.Drawing.Point(322, 280)
        Me.piclaserausgang.Name = "piclaserausgang"
        Me.piclaserausgang.Size = New System.Drawing.Size(16, 16)
        Me.piclaserausgang.TabIndex = 36
        Me.piclaserausgang.TabStop = False
        '
        'pickameraeingang
        '
        Me.pickameraeingang.Image = CType(resources.GetObject("pickameraeingang.Image"), System.Drawing.Image)
        Me.pickameraeingang.Location = New System.Drawing.Point(270, 280)
        Me.pickameraeingang.Name = "pickameraeingang"
        Me.pickameraeingang.Size = New System.Drawing.Size(16, 16)
        Me.pickameraeingang.TabIndex = 37
        Me.pickameraeingang.TabStop = False
        '
        'pickameraausgang
        '
        Me.pickameraausgang.Image = CType(resources.GetObject("pickameraausgang.Image"), System.Drawing.Image)
        Me.pickameraausgang.Location = New System.Drawing.Point(192, 280)
        Me.pickameraausgang.Name = "pickameraausgang"
        Me.pickameraausgang.Size = New System.Drawing.Size(16, 16)
        Me.pickameraausgang.TabIndex = 38
        Me.pickameraausgang.TabStop = False
        '
        'btnLaserStatus
        '
        Me.btnLaserStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLaserStatus.Location = New System.Drawing.Point(330, 360)
        Me.btnLaserStatus.Name = "btnLaserStatus"
        Me.btnLaserStatus.Size = New System.Drawing.Size(80, 24)
        Me.btnLaserStatus.TabIndex = 39
        Me.btnLaserStatus.Text = "Status"
        '
        'btnKameraStatus
        '
        Me.btnKameraStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKameraStatus.Location = New System.Drawing.Point(200, 360)
        Me.btnKameraStatus.Name = "btnKameraStatus"
        Me.btnKameraStatus.Size = New System.Drawing.Size(80, 24)
        Me.btnKameraStatus.TabIndex = 40
        Me.btnKameraStatus.Text = "Status"
        '
        'btnSpeicherStatus
        '
        Me.btnSpeicherStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSpeicherStatus.Location = New System.Drawing.Point(70, 360)
        Me.btnSpeicherStatus.Name = "btnSpeicherStatus"
        Me.btnSpeicherStatus.Size = New System.Drawing.Size(80, 24)
        Me.btnSpeicherStatus.TabIndex = 41
        Me.btnSpeicherStatus.Text = "Status"
        '
        'picspeichereingang
        '
        Me.picspeichereingang.Image = CType(resources.GetObject("picspeichereingang.Image"), System.Drawing.Image)
        Me.picspeichereingang.Location = New System.Drawing.Point(140, 280)
        Me.picspeichereingang.Name = "picspeichereingang"
        Me.picspeichereingang.Size = New System.Drawing.Size(16, 16)
        Me.picspeichereingang.TabIndex = 42
        Me.picspeichereingang.TabStop = False
        '
        'picspeicherausgang
        '
        Me.picspeicherausgang.Image = CType(resources.GetObject("picspeicherausgang.Image"), System.Drawing.Image)
        Me.picspeicherausgang.Location = New System.Drawing.Point(62, 280)
        Me.picspeicherausgang.Name = "picspeicherausgang"
        Me.picspeicherausgang.Size = New System.Drawing.Size(16, 16)
        Me.picspeicherausgang.TabIndex = 43
        Me.picspeicherausgang.TabStop = False
        '
        'btnEinrichtbetrieb
        '
        Me.btnEinrichtbetrieb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEinrichtbetrieb.Location = New System.Drawing.Point(511, 108)
        Me.btnEinrichtbetrieb.Name = "btnEinrichtbetrieb"
        Me.btnEinrichtbetrieb.Size = New System.Drawing.Size(120, 35)
        Me.btnEinrichtbetrieb.TabIndex = 44
        Me.btnEinrichtbetrieb.Text = "Einrichtbetrieb"
        '
        'btnReferenzieren
        '
        Me.btnReferenzieren.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReferenzieren.Location = New System.Drawing.Point(511, 396)
        Me.btnReferenzieren.Name = "btnReferenzieren"
        Me.btnReferenzieren.Size = New System.Drawing.Size(120, 35)
        Me.btnReferenzieren.TabIndex = 45
        Me.btnReferenzieren.Text = "Referenzieren"
        Me.btnReferenzieren.Visible = False
        '
        'lbl1StLaserSchutz
        '
        Me.lbl1StLaserSchutz.BackColor = System.Drawing.Color.Red
        Me.lbl1StLaserSchutz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1StLaserSchutz.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl1StLaserSchutz.Location = New System.Drawing.Point(14, 74)
        Me.lbl1StLaserSchutz.Name = "lbl1StLaserSchutz"
        Me.lbl1StLaserSchutz.Size = New System.Drawing.Size(230, 16)
        Me.lbl1StLaserSchutz.TabIndex = 46
        Me.lbl1StLaserSchutz.Text = "-- Störung Laserschutz! --"
        Me.lbl1StLaserSchutz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl1StLaserSchutz.Visible = False
        '
        'btnAutomatik
        '
        Me.btnAutomatik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutomatik.Location = New System.Drawing.Point(511, 72)
        Me.btnAutomatik.Name = "btnAutomatik"
        Me.btnAutomatik.Size = New System.Drawing.Size(120, 35)
        Me.btnAutomatik.TabIndex = 49
        Me.btnAutomatik.Text = "Automatik"
        '
        'LeseTimer
        '
        '
        'btnIOruecksetz
        '
        Me.btnIOruecksetz.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnIOruecksetz.Enabled = False
        Me.btnIOruecksetz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIOruecksetz.Location = New System.Drawing.Point(294, 70)
        Me.btnIOruecksetz.Name = "btnIOruecksetz"
        Me.btnIOruecksetz.Size = New System.Drawing.Size(181, 78)
        Me.btnIOruecksetz.TabIndex = 50
        Me.btnIOruecksetz.Text = "Zähler zurücksetzen."
        Me.btnIOruecksetz.Visible = False
        '
        'btnIOnotRuecksetz
        '
        Me.btnIOnotRuecksetz.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnIOnotRuecksetz.Enabled = False
        Me.btnIOnotRuecksetz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIOnotRuecksetz.Location = New System.Drawing.Point(294, 148)
        Me.btnIOnotRuecksetz.Name = "btnIOnotRuecksetz"
        Me.btnIOnotRuecksetz.Size = New System.Drawing.Size(181, 78)
        Me.btnIOnotRuecksetz.TabIndex = 51
        Me.btnIOnotRuecksetz.Text = "ESC"
        Me.btnIOnotRuecksetz.Visible = False
        '
        'lbl2StSpeicherSchutz
        '
        Me.lbl2StSpeicherSchutz.BackColor = System.Drawing.Color.Red
        Me.lbl2StSpeicherSchutz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2StSpeicherSchutz.Location = New System.Drawing.Point(262, 74)
        Me.lbl2StSpeicherSchutz.Name = "lbl2StSpeicherSchutz"
        Me.lbl2StSpeicherSchutz.Size = New System.Drawing.Size(230, 16)
        Me.lbl2StSpeicherSchutz.TabIndex = 52
        Me.lbl2StSpeicherSchutz.Text = "-- Störung Speicherschutz! --"
        Me.lbl2StSpeicherSchutz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl2StSpeicherSchutz.Visible = False
        '
        'lbl3StUeberlast
        '
        Me.lbl3StUeberlast.BackColor = System.Drawing.Color.Red
        Me.lbl3StUeberlast.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3StUeberlast.Location = New System.Drawing.Point(262, 122)
        Me.lbl3StUeberlast.Name = "lbl3StUeberlast"
        Me.lbl3StUeberlast.Size = New System.Drawing.Size(230, 16)
        Me.lbl3StUeberlast.TabIndex = 53
        Me.lbl3StUeberlast.Text = "-- Störung Überlast! --"
        Me.lbl3StUeberlast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl3StUeberlast.Visible = False
        '
        'lbl4StSpeicher
        '
        Me.lbl4StSpeicher.BackColor = System.Drawing.Color.Red
        Me.lbl4StSpeicher.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl4StSpeicher.Location = New System.Drawing.Point(14, 90)
        Me.lbl4StSpeicher.Name = "lbl4StSpeicher"
        Me.lbl4StSpeicher.Size = New System.Drawing.Size(230, 16)
        Me.lbl4StSpeicher.TabIndex = 54
        Me.lbl4StSpeicher.Text = "-- Störung Speicher! --"
        Me.lbl4StSpeicher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl4StSpeicher.Visible = False
        '
        'lbl5StKupplung
        '
        Me.lbl5StKupplung.BackColor = System.Drawing.Color.Red
        Me.lbl5StKupplung.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl5StKupplung.Location = New System.Drawing.Point(262, 90)
        Me.lbl5StKupplung.Name = "lbl5StKupplung"
        Me.lbl5StKupplung.Size = New System.Drawing.Size(230, 16)
        Me.lbl5StKupplung.TabIndex = 55
        Me.lbl5StKupplung.Text = "-- Störung Kupplung! --"
        Me.lbl5StKupplung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl5StKupplung.Visible = False
        '
        'lbl6StDruck
        '
        Me.lbl6StDruck.BackColor = System.Drawing.Color.Red
        Me.lbl6StDruck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6StDruck.Location = New System.Drawing.Point(14, 106)
        Me.lbl6StDruck.Name = "lbl6StDruck"
        Me.lbl6StDruck.Size = New System.Drawing.Size(230, 16)
        Me.lbl6StDruck.TabIndex = 56
        Me.lbl6StDruck.Text = "-- Störung Druckluft! --"
        Me.lbl6StDruck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl6StDruck.Visible = False
        '
        'lbl7StNotAus
        '
        Me.lbl7StNotAus.BackColor = System.Drawing.Color.Red
        Me.lbl7StNotAus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl7StNotAus.Location = New System.Drawing.Point(262, 106)
        Me.lbl7StNotAus.Name = "lbl7StNotAus"
        Me.lbl7StNotAus.Size = New System.Drawing.Size(230, 16)
        Me.lbl7StNotAus.TabIndex = 57
        Me.lbl7StNotAus.Text = "-- NOT AUS --"
        Me.lbl7StNotAus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl7StNotAus.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblKameraNIO)
        Me.Panel1.Controls.Add(Me.txtKameraNIO)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel1.Location = New System.Drawing.Point(250, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 35)
        Me.Panel1.TabIndex = 58
        '
        'lblKameraNIO
        '
        Me.lblKameraNIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKameraNIO.Location = New System.Drawing.Point(0, 0)
        Me.lblKameraNIO.Name = "lblKameraNIO"
        Me.lblKameraNIO.Size = New System.Drawing.Size(90, 16)
        Me.lblKameraNIO.TabIndex = 21
        Me.lblKameraNIO.Text = "0"
        Me.lblKameraNIO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtKameraNIO
        '
        Me.txtKameraNIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKameraNIO.Location = New System.Drawing.Point(-4, 16)
        Me.txtKameraNIO.Name = "txtKameraNIO"
        Me.txtKameraNIO.Size = New System.Drawing.Size(96, 16)
        Me.txtKameraNIO.TabIndex = 20
        Me.txtKameraNIO.Text = "Kamera NIO"
        Me.txtKameraNIO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lblLaserNIO)
        Me.Panel2.Controls.Add(Me.txtLaserNIO)
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel2.Location = New System.Drawing.Point(344, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(90, 35)
        Me.Panel2.TabIndex = 59
        '
        'lblLaserNIO
        '
        Me.lblLaserNIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLaserNIO.Location = New System.Drawing.Point(0, 0)
        Me.lblLaserNIO.Name = "lblLaserNIO"
        Me.lblLaserNIO.Size = New System.Drawing.Size(88, 16)
        Me.lblLaserNIO.TabIndex = 21
        Me.lblLaserNIO.Text = "0"
        Me.lblLaserNIO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtLaserNIO
        '
        Me.txtLaserNIO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLaserNIO.Location = New System.Drawing.Point(-4, 16)
        Me.txtLaserNIO.Name = "txtLaserNIO"
        Me.txtLaserNIO.Size = New System.Drawing.Size(92, 16)
        Me.txtLaserNIO.TabIndex = 20
        Me.txtLaserNIO.Text = "Laser NIO"
        Me.txtLaserNIO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbl8StSchutzTuer
        '
        Me.lbl8StSchutzTuer.BackColor = System.Drawing.Color.Red
        Me.lbl8StSchutzTuer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl8StSchutzTuer.Location = New System.Drawing.Point(14, 122)
        Me.lbl8StSchutzTuer.Name = "lbl8StSchutzTuer"
        Me.lbl8StSchutzTuer.Size = New System.Drawing.Size(230, 16)
        Me.lbl8StSchutzTuer.TabIndex = 60
        Me.lbl8StSchutzTuer.Text = "-- Schutztür offen! --"
        Me.lbl8StSchutzTuer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl8StSchutzTuer.Visible = False
        '
        'lbl8StSchutzHaube
        '
        Me.lbl8StSchutzHaube.BackColor = System.Drawing.Color.Red
        Me.lbl8StSchutzHaube.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl8StSchutzHaube.Location = New System.Drawing.Point(14, 138)
        Me.lbl8StSchutzHaube.Name = "lbl8StSchutzHaube"
        Me.lbl8StSchutzHaube.Size = New System.Drawing.Size(230, 16)
        Me.lbl8StSchutzHaube.TabIndex = 61
        Me.lbl8StSchutzHaube.Text = "-- Schutzhaube offen! --"
        Me.lbl8StSchutzHaube.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl8StSchutzHaube.Visible = False
        '
        'lbl9StAbsaugFilter
        '
        Me.lbl9StAbsaugFilter.BackColor = System.Drawing.Color.Red
        Me.lbl9StAbsaugFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl9StAbsaugFilter.Location = New System.Drawing.Point(262, 138)
        Me.lbl9StAbsaugFilter.Name = "lbl9StAbsaugFilter"
        Me.lbl9StAbsaugFilter.Size = New System.Drawing.Size(230, 16)
        Me.lbl9StAbsaugFilter.TabIndex = 62
        Me.lbl9StAbsaugFilter.Text = "-- Absauger Filter NIO --"
        Me.lbl9StAbsaugFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl9StAbsaugFilter.Visible = False
        '
        'lbl9StAbsaug100p
        '
        Me.lbl9StAbsaug100p.BackColor = System.Drawing.Color.Red
        Me.lbl9StAbsaug100p.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl9StAbsaug100p.Location = New System.Drawing.Point(262, 154)
        Me.lbl9StAbsaug100p.Name = "lbl9StAbsaug100p"
        Me.lbl9StAbsaug100p.Size = New System.Drawing.Size(230, 16)
        Me.lbl9StAbsaug100p.TabIndex = 63
        Me.lbl9StAbsaug100p.Text = "-- Störung Absauger --"
        Me.lbl9StAbsaug100p.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl9StAbsaug100p.Visible = False
        '
        'lblmyS_StShutter
        '
        Me.lblmyS_StShutter.BackColor = System.Drawing.Color.Red
        Me.lblmyS_StShutter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyS_StShutter.Location = New System.Drawing.Point(262, 170)
        Me.lblmyS_StShutter.Name = "lblmyS_StShutter"
        Me.lblmyS_StShutter.Size = New System.Drawing.Size(230, 16)
        Me.lblmyS_StShutter.TabIndex = 64
        Me.lblmyS_StShutter.Text = "-- Störung Shutter --"
        Me.lblmyS_StShutter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_StShutter.Visible = False
        '
        'lblmyS_StLasAuftragEnde
        '
        Me.lblmyS_StLasAuftragEnde.BackColor = System.Drawing.Color.Red
        Me.lblmyS_StLasAuftragEnde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyS_StLasAuftragEnde.Location = New System.Drawing.Point(516, 180)
        Me.lblmyS_StLasAuftragEnde.Name = "lblmyS_StLasAuftragEnde"
        Me.lblmyS_StLasAuftragEnde.Size = New System.Drawing.Size(110, 16)
        Me.lblmyS_StLasAuftragEnde.TabIndex = 65
        Me.lblmyS_StLasAuftragEnde.Text = "Auftrag Ende"
        Me.lblmyS_StLasAuftragEnde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_StLasAuftragEnde.Visible = False
        '
        'lblmyS_StLasShutterZu
        '
        Me.lblmyS_StLasShutterZu.BackColor = System.Drawing.Color.Red
        Me.lblmyS_StLasShutterZu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyS_StLasShutterZu.Location = New System.Drawing.Point(516, 196)
        Me.lblmyS_StLasShutterZu.Name = "lblmyS_StLasShutterZu"
        Me.lblmyS_StLasShutterZu.Size = New System.Drawing.Size(110, 16)
        Me.lblmyS_StLasShutterZu.TabIndex = 66
        Me.lblmyS_StLasShutterZu.Text = "Shutter zu"
        Me.lblmyS_StLasShutterZu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_StLasShutterZu.Visible = False
        '
        'lblmyS_StLasSoftware
        '
        Me.lblmyS_StLasSoftware.BackColor = System.Drawing.Color.Red
        Me.lblmyS_StLasSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyS_StLasSoftware.Location = New System.Drawing.Point(516, 212)
        Me.lblmyS_StLasSoftware.Name = "lblmyS_StLasSoftware"
        Me.lblmyS_StLasSoftware.Size = New System.Drawing.Size(110, 16)
        Me.lblmyS_StLasSoftware.TabIndex = 67
        Me.lblmyS_StLasSoftware.Text = "RofinVMC2-NIO"
        Me.lblmyS_StLasSoftware.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_StLasSoftware.Visible = False
        '
        'lblmyS_StLasHardware
        '
        Me.lblmyS_StLasHardware.BackColor = System.Drawing.Color.Red
        Me.lblmyS_StLasHardware.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyS_StLasHardware.Location = New System.Drawing.Point(516, 228)
        Me.lblmyS_StLasHardware.Name = "lblmyS_StLasHardware"
        Me.lblmyS_StLasHardware.Size = New System.Drawing.Size(110, 16)
        Me.lblmyS_StLasHardware.TabIndex = 68
        Me.lblmyS_StLasHardware.Text = "Hardware NIO"
        Me.lblmyS_StLasHardware.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_StLasHardware.Visible = False
        '
        'lblmyS_StIndexVor
        '
        Me.lblmyS_StIndexVor.BackColor = System.Drawing.Color.Red
        Me.lblmyS_StIndexVor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyS_StIndexVor.Location = New System.Drawing.Point(14, 154)
        Me.lblmyS_StIndexVor.Name = "lblmyS_StIndexVor"
        Me.lblmyS_StIndexVor.Size = New System.Drawing.Size(230, 16)
        Me.lblmyS_StIndexVor.TabIndex = 69
        Me.lblmyS_StIndexVor.Text = "-- Index vor --"
        Me.lblmyS_StIndexVor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_StIndexVor.Visible = False
        '
        'lblmyS_StIndexRueck
        '
        Me.lblmyS_StIndexRueck.BackColor = System.Drawing.Color.Red
        Me.lblmyS_StIndexRueck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyS_StIndexRueck.Location = New System.Drawing.Point(14, 170)
        Me.lblmyS_StIndexRueck.Name = "lblmyS_StIndexRueck"
        Me.lblmyS_StIndexRueck.Size = New System.Drawing.Size(230, 16)
        Me.lblmyS_StIndexRueck.TabIndex = 70
        Me.lblmyS_StIndexRueck.Text = "-- Index zurück --"
        Me.lblmyS_StIndexRueck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_StIndexRueck.Visible = False
        '
        'lblmyS_MMarkieren
        '
        Me.lblmyS_MMarkieren.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyS_MMarkieren.ForeColor = System.Drawing.Color.Red
        Me.lblmyS_MMarkieren.Location = New System.Drawing.Point(36, 402)
        Me.lblmyS_MMarkieren.Name = "lblmyS_MMarkieren"
        Me.lblmyS_MMarkieren.Size = New System.Drawing.Size(422, 20)
        Me.lblmyS_MMarkieren.TabIndex = 71
        Me.lblmyS_MMarkieren.Text = "Schutzhaube öffnen und Kette markieren!"
        Me.lblmyS_MMarkieren.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblmyS_MMarkieren.Visible = False
        '
        'lblmyS_MBuersteNBereit
        '
        Me.lblmyS_MBuersteNBereit.Enabled = False
        Me.lblmyS_MBuersteNBereit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblmyS_MBuersteNBereit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmyS_MBuersteNBereit.Location = New System.Drawing.Point(450, 264)
        Me.lblmyS_MBuersteNBereit.Name = "lblmyS_MBuersteNBereit"
        Me.lblmyS_MBuersteNBereit.Size = New System.Drawing.Size(50, 46)
        Me.lblmyS_MBuersteNBereit.TabIndex = 72
        Me.lblmyS_MBuersteNBereit.Text = "Bürste"
        '
        'btnCounter
        '
        Me.btnCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCounter.Location = New System.Drawing.Point(511, 144)
        Me.btnCounter.Name = "btnCounter"
        Me.btnCounter.Size = New System.Drawing.Size(120, 35)
        Me.btnCounter.TabIndex = 74
        Me.btnCounter.Text = "Counter"
        '
        'lblCounterTextSoll
        '
        Me.lblCounterTextSoll.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblCounterTextSoll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounterTextSoll.Location = New System.Drawing.Point(332, 326)
        Me.lblCounterTextSoll.Name = "lblCounterTextSoll"
        Me.lblCounterTextSoll.Size = New System.Drawing.Size(26, 18)
        Me.lblCounterTextSoll.TabIndex = 75
        Me.lblCounterTextSoll.Text = "Soll:"
        Me.lblCounterTextSoll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCounterTextIst
        '
        Me.lblCounterTextIst.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblCounterTextIst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCounterTextIst.Location = New System.Drawing.Point(334, 342)
        Me.lblCounterTextIst.Name = "lblCounterTextIst"
        Me.lblCounterTextIst.Size = New System.Drawing.Size(22, 18)
        Me.lblCounterTextIst.TabIndex = 76
        Me.lblCounterTextIst.Text = "Ist:"
        Me.lblCounterTextIst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCounterSoll
        '
        Me.lblCounterSoll.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblCounterSoll.Location = New System.Drawing.Point(360, 326)
        Me.lblCounterSoll.Name = "lblCounterSoll"
        Me.lblCounterSoll.Size = New System.Drawing.Size(52, 18)
        Me.lblCounterSoll.TabIndex = 77
        Me.lblCounterSoll.Text = "10"
        Me.lblCounterSoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCounterIst
        '
        Me.lblCounterIst.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblCounterIst.Location = New System.Drawing.Point(360, 342)
        Me.lblCounterIst.Name = "lblCounterIst"
        Me.lblCounterIst.Size = New System.Drawing.Size(52, 18)
        Me.lblCounterIst.TabIndex = 78
        Me.lblCounterIst.Text = "0"
        Me.lblCounterIst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem3})
        Me.MenuItem2.Text = "Info"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 0
        Me.MenuItem3.Text = "Version"
        '
        'FMain
        '
        Me.AutoScale = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(632, 433)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblCounterIst)
        Me.Controls.Add(Me.lblCounterSoll)
        Me.Controls.Add(Me.lblCounterTextIst)
        Me.Controls.Add(Me.lblCounterTextSoll)
        Me.Controls.Add(Me.btnCounter)
        Me.Controls.Add(Me.lblmyS_MBuersteNBereit)
        Me.Controls.Add(Me.lblmyS_MMarkieren)
        Me.Controls.Add(Me.lblmyS_StIndexRueck)
        Me.Controls.Add(Me.lblmyS_StIndexVor)
        Me.Controls.Add(Me.lblmyS_StLasHardware)
        Me.Controls.Add(Me.lblmyS_StLasSoftware)
        Me.Controls.Add(Me.lblmyS_StLasShutterZu)
        Me.Controls.Add(Me.lblmyS_StLasAuftragEnde)
        Me.Controls.Add(Me.lblmyS_StShutter)
        Me.Controls.Add(Me.lbl9StAbsaug100p)
        Me.Controls.Add(Me.lbl9StAbsaugFilter)
        Me.Controls.Add(Me.lbl8StSchutzHaube)
        Me.Controls.Add(Me.lbl8StSchutzTuer)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblmyS_FKamera)
        Me.Controls.Add(Me.lblmyS_FLaser)
        Me.Controls.Add(Me.lbl7StNotAus)
        Me.Controls.Add(Me.lbl6StDruck)
        Me.Controls.Add(Me.lbl5StKupplung)
        Me.Controls.Add(Me.lbl4StSpeicher)
        Me.Controls.Add(Me.lbl3StUeberlast)
        Me.Controls.Add(Me.lbl2StSpeicherSchutz)
        Me.Controls.Add(Me.lbl1StLaserSchutz)
        Me.Controls.Add(Me.btnAutomatik)
        Me.Controls.Add(Me.btnReferenzieren)
        Me.Controls.Add(Me.btnEinrichtbetrieb)
        Me.Controls.Add(Me.picspeicherausgang)
        Me.Controls.Add(Me.picspeichereingang)
        Me.Controls.Add(Me.btnSpeicherStatus)
        Me.Controls.Add(Me.btnKameraStatus)
        Me.Controls.Add(Me.btnLaserStatus)
        Me.Controls.Add(Me.pickameraausgang)
        Me.Controls.Add(Me.pickameraeingang)
        Me.Controls.Add(Me.piclaserausgang)
        Me.Controls.Add(Me.piclasereingang)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pickameraaktiv)
        Me.Controls.Add(Me.piclaseraktiv)
        Me.Controls.Add(Me.lblmyIFrgMoma2)
        Me.Controls.Add(Me.lblmyIFrgMoma1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnLaser)
        Me.Controls.Add(Me.btnKamera)
        Me.Controls.Add(Me.btnKettenspeicher)
        Me.Controls.Add(Me.pnlTakteMin)
        Me.Controls.Add(Me.pnlKettenAuftrag)
        Me.Controls.Add(Me.pnlStoerung)
        Me.Controls.Add(Me.pnlStatus)
        Me.Controls.Add(Me.pnlGlieder)
        Me.Controls.Add(Me.pnlArtikelnr)
        Me.Controls.Add(Me.pnlZeit)
        Me.Controls.Add(Me.pnldatum)
        Me.Controls.Add(Me.pnlVerbingung)
        Me.Controls.Add(Me.pnlFirmenLogo)
        Me.Controls.Add(Me.btnIOruecksetz)
        Me.Controls.Add(Me.btnIOnotRuecksetz)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Name = "FMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Laser"
        Me.pnlFirmenLogo.ResumeLayout(False)
        Me.pnlVerbingung.ResumeLayout(False)
        Me.pnldatum.ResumeLayout(False)
        Me.pnlZeit.ResumeLayout(False)
        Me.pnlArtikelnr.ResumeLayout(False)
        Me.pnlGlieder.ResumeLayout(False)
        Me.pnlStatus.ResumeLayout(False)
        Me.pnlStoerung.ResumeLayout(False)
        Me.pnlKettenAuftrag.ResumeLayout(False)
        Me.pnlTakteMin.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dataStream = New AdsStream(4)
        binread = New BinaryReader(dataStream)
        verbindeSpsVariablen()  ' createVariableHandles mit SPS variablen


        'Timeraufruf für datum und zeitanzeige!
        Timer1_Tick(Me, e)
        If (twincataktif = True) Then
            LeseTimer.Enabled = True
            LeseTimer_Tick(Me, e) 'lese Variablenwerte aus SPS
        End If

        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString
        'default bilder laden:
        'picIwis.Image = Image.FromFile("bilder/iwis.jpg")

        'txtAktKette.Text = New String(Conn.tcClient.ReadAny(Handle1.hshort, GetType(Short)).ToString())
        ShowWindow(FindWindow("Shell_TrayWnd", ""), 0)
       
    End Sub

    Private Sub verbindeSpsVariablen()
        'Instanz der Klasse TcAdsClient erzeugen
        adsClient = New TcAdsClient
        ReDim hConnect(52) 'erweitern nicht vergessen, sonst IndexOutOfBoundsError...

        'Verbindung mit Port 801 
        Try
            adsClient.Connect(801)
            twincataktif = True

            hConnect(0) = adsClient.CreateVariableHandle(".TP_LaserAktiv")
            hConnect(1) = adsClient.CreateVariableHandle(".TP_LaserHand")
            hConnect(2) = adsClient.CreateVariableHandle(".TP_KammeraAktiv")
            hConnect(3) = adsClient.CreateVariableHandle(".TP_Hand")
            hConnect(4) = adsClient.CreateVariableHandle(".TP_Auto")
            hConnect(5) = adsClient.CreateVariableHandle(".S_StUeberlast")
            hConnect(6) = adsClient.CreateVariableHandle(".S_StLaser")
            hConnect(7) = adsClient.CreateVariableHandle(".S_StKammera")
            hConnect(8) = adsClient.CreateVariableHandle(".S_StKupplung")
            hConnect(9) = adsClient.CreateVariableHandle(".S_StSpeicherSchutz")
            hConnect(10) = adsClient.CreateVariableHandle(".S_StLaserSchutz")
            hConnect(11) = adsClient.CreateVariableHandle(".S_StSpeicher")
            hConnect(12) = adsClient.CreateVariableHandle(".S_StSammelstoerung")
            hConnect(13) = adsClient.CreateVariableHandle(".S_StDruck")
            hConnect(14) = adsClient.CreateVariableHandle(".S_StNotAus")
            hConnect(15) = adsClient.CreateVariableHandle(".S_StRef")
            hConnect(16) = adsClient.CreateVariableHandle(".S_MSpeicherVoll")
            hConnect(17) = adsClient.CreateVariableHandle(".S_MSpeicherLeer")
            hConnect(18) = adsClient.CreateVariableHandle(".S_MWarteSpeicher")
            hConnect(19) = adsClient.CreateVariableHandle(".S_MHand")
            hConnect(20) = adsClient.CreateVariableHandle(".S_FKamera")
            hConnect(21) = adsClient.CreateVariableHandle(".S_FLaser")
            hConnect(22) = adsClient.CreateVariableHandle(".S_MAutoStart")
            hConnect(23) = adsClient.CreateVariableHandle(".S_MAutoStop")
            hConnect(24) = adsClient.CreateVariableHandle(".SI_Gliederzahl")
            hConnect(25) = adsClient.CreateVariableHandle(".SI_ProgNr")
            hConnect(26) = adsClient.CreateVariableHandle(".SI_IO")
            hConnect(27) = adsClient.CreateVariableHandle(".SI_NIO")
            hConnect(28) = adsClient.CreateVariableHandle(".S_StShutter")
            hConnect(29) = adsClient.CreateVariableHandle(".S_MShutterBetrieb")
            hConnect(30) = adsClient.CreateVariableHandle(".SI_FLaser")
            hConnect(31) = adsClient.CreateVariableHandle(".SI_FKamera")
            hConnect(32) = adsClient.CreateVariableHandle(".S_StSchutzTuer")
            hConnect(33) = adsClient.CreateVariableHandle(".S_StSchutzHaube")
            hConnect(34) = adsClient.CreateVariableHandle(".S_StAbsaugFilter")
            hConnect(35) = adsClient.CreateVariableHandle(".S_StAbsaug100p")
            hConnect(36) = adsClient.CreateVariableHandle(".S_StLasAuftragEnde")
            hConnect(37) = adsClient.CreateVariableHandle(".S_StLasShutterZu")
            hConnect(38) = adsClient.CreateVariableHandle(".S_StLasSoftware")
            hConnect(39) = adsClient.CreateVariableHandle(".S_StLasHardware")
            hConnect(40) = adsClient.CreateVariableHandle(".S_StIndexVor")
            hConnect(41) = adsClient.CreateVariableHandle(".S_StIndexRueck")
            hConnect(42) = adsClient.CreateVariableHandle(".IFrgMoma1")
            hConnect(43) = adsClient.CreateVariableHandle(".IFrgMoma2")
            hConnect(44) = adsClient.CreateVariableHandle(".S_MWarteLaser")
            hConnect(45) = adsClient.CreateVariableHandle(".S_MMarkieren")
            hConnect(46) = adsClient.CreateVariableHandle(".S_MBuersteNBereit")
            hConnect(47) = adsClient.CreateVariableHandle(".S_MDrehgMontPos")
            hConnect(48) = adsClient.CreateVariableHandle(".CounterSoll")
            hConnect(49) = adsClient.CreateVariableHandle(".CounterIst")
            hConnect(50) = adsClient.CreateVariableHandle(".TPCounterAktiv")
            hConnect(51) = adsClient.CreateVariableHandle(".SAuftragFertig")

        Catch err As Exception
            MessageBox.Show("Keine Verbindung!" & vbCrLf & err.Message)
            adsClient.Dispose()
            twincataktif = False
        End Try
    End Sub


    Private Sub LeseTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeseTimer.Tick
        dataStream.Position = 0
        adsClient.Read(hConnect(0), dataStream)
        myTP_LaserAktiv = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(1), dataStream)
        myTP_LaserHand = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(2), dataStream)
        myTP_KammeraAktiv = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(3), dataStream)
        myTP_Hand = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(4), dataStream)
        myTP_Auto = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(5), dataStream)
        myS_StUeberlast = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(6), dataStream)
        myS_StLaser = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(7), dataStream)
        myS_StKammera = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(8), dataStream)
        myS_StKupplung = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(9), dataStream)
        myS_StSpeicherSchutz = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(10), dataStream)
        myS_StLaserSchutz = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(11), dataStream)
        myS_StSpeicher = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(12), dataStream)
        myS_StSammelstoerung = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(13), dataStream)
        myS_StDruck = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(14), dataStream)
        myS_StNotAus = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(15), dataStream)
        myS_StRef = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(16), dataStream)
        myS_MSpeicherVoll = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(17), dataStream)
        myS_MSpeicherLeer = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(18), dataStream)
        myS_MWarteSpeicher = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(19), dataStream)
        myS_MHand = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(20), dataStream)
        myS_FKamera = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(21), dataStream)
        myS_FLaser = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(22), dataStream)
        myS_MAutoStart = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(23), dataStream)
        myS_MAutoStop = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(24), dataStream)
        mySI_Gliederzahl = binread.ReadInt16()

        dataStream.Position = 0
        adsClient.Read(hConnect(25), dataStream)
        mySI_ProgNr = binread.ReadInt16()

        dataStream.Position = 0
        adsClient.Read(hConnect(26), dataStream)
        mySI_IO = binread.ReadInt16()

        dataStream.Position = 0
        adsClient.Read(hConnect(27), dataStream)
        mySI_NIO = binread.ReadInt16()

        dataStream.Position = 0
        adsClient.Read(hConnect(28), dataStream)
        myS_StShutter = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(29), dataStream)
        myS_MShutterBetrieb = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(30), dataStream)
        mySI_FLaser = binread.ReadInt16()

        dataStream.Position = 0
        adsClient.Read(hConnect(31), dataStream)
        mySI_FKamera = binread.ReadInt16()

        dataStream.Position = 0
        adsClient.Read(hConnect(32), dataStream)
        myS_StSchutzTuer = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(33), dataStream)
        myS_StSchutzHaube = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(34), dataStream)
        myS_StAbsaugFilter = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(35), dataStream)
        myS_StAbsaug100p = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(36), dataStream)
        myS_StLasAuftragEnde = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(37), dataStream)
        myS_StLasShutterZu = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(38), dataStream)
        myS_StLasSoftware = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(39), dataStream)
        myS_StLasHardware = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(40), dataStream)
        myS_StIndexVor = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(41), dataStream)
        myS_StIndexRueck = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(42), dataStream)
        myIFrgMoma1 = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(43), dataStream)
        myIFrgMoma2 = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(44), dataStream)
        myS_MWarteLaser = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(45), dataStream)
        myS_MMarkieren = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(46), dataStream)
        myS_MBuersteNBereit = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(47), dataStream)
        myS_MDrehgMontPos = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(48), dataStream)
        myCounterSoll = binread.ReadInt16()

        dataStream.Position = 0
        adsClient.Read(hConnect(49), dataStream)
        myCounterIst = binread.ReadInt16()

        dataStream.Position = 0
        adsClient.Read(hConnect(50), dataStream)
        myTPCounterAktiv = binread.ReadBoolean()

        dataStream.Position = 0
        adsClient.Read(hConnect(51), dataStream)
        mySAuftragFertig = binread.ReadBoolean()

        auswerten()

        'ueberpruefe ob fenster verschoben wurde:
        If (MyBase.DesktopLocation.X <> 0 Or MyBase.DesktopLocation.Y <> 0) Then
            MyBase.SetDesktopLocation(0, 0)
        End If

    End Sub

    Private Sub auswerten()
        'Hand/Auto ueberpruefung: (wird nicht mehr genutzt da TP variablen nur geschrieben werden***********
        'If myTP_Hand = True Then
        'btnEinrichtbetrieb.BackColor = Color.Yellow
        'btnAutomatik.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        'btnReferenzieren.Visible = True
        'Else
        '    btnEinrichtbetrieb.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        '    btnAutomatik.BackColor = Color.LightGreen
        '    btnReferenzieren.Visible = False
        'End If

        'If myTP_Auto = True Then
        'btnAutomatik.BackColor = Color.LightGreen
        'btnEinrichtbetrieb.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        'btnReferenzieren.Visible = False
        'lblMaschinenStatus.Text = "Automatik"
        'lblMaschinenStatus.BackColor = Color.LightBlue
        'Else
        '    btnAutomatik.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        '    btnEinrichtbetrieb.BackColor = Color.Yellow
        '    btnReferenzieren.Visible = True
        'End If
        'ende hand/auto pruefung****************************

        'Automatik gestartet/gestoppt uberpruefung:*********

        If (myS_MHand = True) Then
            lblMaschinenStatus.Text = "Einrichtbetrieb"
            lblMaschinenStatus.BackColor = Color.Yellow
            btnAutomatik.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
            btnEinrichtbetrieb.BackColor = Color.Yellow
            btnReferenzieren.Visible = True
        End If
        If myS_MAutoStart = True Then
            lblMaschinenStatus.Text = "Autom. gestartet"
            lblMaschinenStatus.BackColor = Color.LightGreen
            btnAutomatik.BackColor = Color.LightGreen
            btnEinrichtbetrieb.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
            btnReferenzieren.Visible = False
        End If
        If (myS_MAutoStop = True) Then
            lblMaschinenStatus.Text = "Autom. gestoppt"
            lblMaschinenStatus.BackColor = Color.LightBlue
            btnAutomatik.BackColor = Color.LightGreen
            btnEinrichtbetrieb.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
            btnReferenzieren.Visible = False
        End If
        'ende Automatik gestartet/gestoppt *****************

        'shutterbetrieb anzeige ***************************
        If (myS_MShutterBetrieb = True) Then
            lblMaschinenStatus.Text = "Shutterbetrieb"
            lblMaschinenStatus.BackColor = Color.White
        End If
        'ende shutter anzeige ************************

        'Station 1 LASER *******************
        'laser aktif:
        If myTP_LaserAktiv = True Then
            btnLaserStatus.Text = "Aktiv"
            btnLaserStatus.BackColor = Color.Yellow
            Me.piclaseraktiv.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
        Else
            Me.piclaseraktiv.Image = CType(resources.GetObject("picboxrot1blau.Image"), System.Drawing.Image)
        End If

        'laser status hand / störung:
        If (myTP_LaserHand = True And myS_StLaser = False) Then
            btnLaserStatus.Text = "Hand"
            btnLaserStatus.BackColor = Color.LightBlue
            Me.piclasereingang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
            Me.piclaserausgang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
        ElseIf (myTP_LaserHand = True And myS_StLaser = True) Then
            btnLaserStatus.Text = "Störung"
            btnLaserStatus.BackColor = Color.Red
            Me.piclasereingang.Image = CType(resources.GetObject("picboxrot1blau.Image"), System.Drawing.Image)
            Me.piclaserausgang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
        ElseIf (myS_StLaser = True) Then
            btnLaserStatus.Text = "Störung"
            btnLaserStatus.BackColor = Color.Red
            Me.piclasereingang.Image = CType(resources.GetObject("picboxrot1blau.Image"), System.Drawing.Image)
            Me.piclaserausgang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
        ElseIf myS_MWarteLaser = True Then
            btnLaserStatus.Text = "startet..."
            btnLaserStatus.BackColor = Color.Yellow
        Else
            btnLaserStatus.Text = "bereit"
            btnLaserStatus.BackColor = Color.LightGreen
            Me.piclasereingang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
            Me.piclaserausgang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
        End If

        'fehler zaehler und fehler glied anzeige (fehler zaehler fehlt noch):
        'lblmySI_FPosLaser.Text = mySI_FPosLaser  'wurde wieder rausgenommen.
        'Station 1 LASER ende*******************

        'Station 2 KAMERA ********************** 
        'kamera aktif:
        If myTP_KammeraAktiv = True Then
            Me.pickameraaktiv.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
        Else
            Me.pickameraaktiv.Image = CType(resources.GetObject("picboxrot1blau.Image"), System.Drawing.Image)
        End If

        'kamera status störung:
        If (myS_StKammera = True) Then
            btnKameraStatus.Text = "Störung"
            btnKameraStatus.BackColor = Color.Red
            Me.pickameraeingang.Image = CType(resources.GetObject("picboxrot1blau.Image"), System.Drawing.Image)
            Me.pickameraausgang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
        Else
            btnKameraStatus.Text = "bereit"
            btnKameraStatus.BackColor = Color.LightGreen
            Me.pickameraeingang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
            Me.pickameraausgang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
        End If
        'fehler zaehler und fehler glied anzeige (fehler zaehler fehlt noch):
        'lblmySI_FPosKamera.Text = mySI_FPosKamera   'wurde wieder rausgenommen.
        'Station 2 KAMERA ende*******************


        'Anzeige Gliederzahl der Kette:
        lblGlieder.Text = mySI_Gliederzahl
        'anzeige Programmnummer:
        lblProgNr.Text = mySI_ProgNr
        'anzeige anzahl nio und io:
        lblAnzahlIO.Text = mySI_IO
        lblAnzahlNIO.Text = mySI_NIO
        'anzeige anzahl laser nio und kamera nio:
        lblLaserNIO.Text = mySI_FLaser
        lblKameraNIO.Text = mySI_FKamera


        ' Anzeige ob gelasert oder nicht! ***************

        If (myS_FLaser = True) Then  'nur fehler schreiben
            lblmyS_FLaser.Visible = True
            If (CFS_S_FLaser = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Laser Station: nicht gelasert!")
                f = Nothing
                CFS_S_FLaser = True
            End If
        Else
            CFS_S_FLaser = False
            lblmyS_FLaser.Visible = False
        End If


        If (myS_FKamera = True) Then  'nur fehler schreiben
            lblmyS_FKamera.Visible = True
            If (CFS_S_FKamera = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Kamera Station: nicht gelasert!")
                f = Nothing
                CFS_S_FKamera = True
            End If
        Else
            CFS_S_FKamera = False
            lblmyS_FKamera.Visible = False
        End If

        'Stoerungen ueberpruefen: *******************

        If (myS_StLaser = True) Then  'nur fehler schreiben
            If (CFS_StLaser = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Laser!")
                f = Nothing
                CFS_StLaser = True
            End If
        Else
            CFS_StLaser = False
        End If

        If (myS_StKammera = True) Then  'nur fehler schreiben
            If (CFS_StKammera = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Kamera!")
                f = Nothing
                CFS_StKammera = True
            End If
        Else
            CFS_StKammera = False
        End If

        If (myS_StLaserSchutz = True) Then
            lbl1StLaserSchutz.Visible = True
            If (CFS_StLaserSchutz = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Laserschutz!")
                f = Nothing
                CFS_StLaserSchutz = True
            End If
        Else
            lbl1StLaserSchutz.Visible = False
            CFS_StLaserSchutz = False
        End If

        If (myS_StSpeicherSchutz = True) Then
            lbl2StSpeicherSchutz.Visible = True
            If (CFS_StSpeicherSchutz = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Speicherschutz!")
                f = Nothing
                CFS_StSpeicherSchutz = True
            End If
        Else
            lbl2StSpeicherSchutz.Visible = False
            CFS_StSpeicherSchutz = False
        End If

        If (myS_StUeberlast = True) Then
            lbl3StUeberlast.Visible = True
            If (CFS_StUeberlast = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Überlast!")
                f = Nothing
                CFS_StUeberlast = True
            End If
        Else
            lbl3StUeberlast.Visible = False
            CFS_StUeberlast = False
        End If

        If (myS_StSpeicher = True) Then
            lbl4StSpeicher.Visible = True
            If (CFS_StSpeicher = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Speicher!")
                f = Nothing
                CFS_StSpeicher = True
            End If
        Else
            lbl4StSpeicher.Visible = False
            CFS_StSpeicher = False
        End If

        If (myS_StKupplung = True) Then
            lbl5StKupplung.Visible = True
            If (CFS_StKupplung = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Kupplung!")
                f = Nothing
                CFS_StKupplung = True
            End If
        Else
            lbl5StKupplung.Visible = False
            CFS_StKupplung = False
        End If

        If (myS_StDruck = True) Then
            lbl6StDruck.Visible = True
            If (CFS_StDruck = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Druckluft!")
                f = Nothing
                CFS_StDruck = True
            End If
        Else
            lbl6StDruck.Visible = False
            CFS_StDruck = False
        End If

        If (myS_StNotAus = True) Then
            lbl7StNotAus.Visible = True
            If (CFS_StNotAus = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Not Aus betätigt!")
                f = Nothing
                CFS_StNotAus = True
            End If
        Else
            lbl7StNotAus.Visible = False
            CFS_StNotAus = False
        End If

        If (myS_StSchutzTuer = True) Then
            lbl8StSchutzTuer.Visible = True   'schutztuer offen wird nicht in die stoerungdatei aufgenommen!
        Else
            lbl8StSchutzTuer.Visible = False
        End If

        If (myS_StSchutzHaube = True) Then
            lbl8StSchutzHaube.Visible = True  'schutzhaube offen wird nicht in die stoerungdatei aufgenommen!
        Else
            lbl8StSchutzHaube.Visible = False
        End If

        If (myS_StAbsaugFilter = True) Then
            lbl9StAbsaugFilter.Visible = True
            If (CFS_StAbsaugFilter = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Absaugfilter!")
                f = Nothing
                CFS_StAbsaugFilter = True
            End If
        Else
            lbl9StAbsaugFilter.Visible = False
            CFS_StAbsaugFilter = False
        End If

        If (myS_StAbsaug100p = True) Then
            lbl9StAbsaug100p.Visible = True
            If (CFS_StAbsaug100p = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Absaugfilter < 100%")
                f = Nothing
                CFS_StAbsaug100p = True
            End If
        Else
            lbl9StAbsaug100p.Visible = False
            CFS_StAbsaug100p = False
        End If

        If (myS_StShutter = True) Then
            lblmyS_StShutter.Visible = True
            If (CFS_S_StShutter = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Störung Shutter")
                f = Nothing
                CFS_S_StShutter = True
            End If
        Else
            lblmyS_StShutter.Visible = False
            CFS_S_StShutter = False
        End If

        If (myS_StLasAuftragEnde = True) Then
            lblmyS_StLasAuftragEnde.Visible = True
        Else
            lblmyS_StLasAuftragEnde.Visible = False
        End If

        If (myS_StLasShutterZu = True) Then
            lblmyS_StLasShutterZu.Visible = True
        Else
            lblmyS_StLasShutterZu.Visible = False
        End If

        If (myS_StLasSoftware = True) Then
            lblmyS_StLasSoftware.Visible = True
        Else
            lblmyS_StLasSoftware.Visible = False
        End If

        If (myS_StLasHardware = True) Then
            lblmyS_StLasHardware.Visible = True
        Else
            lblmyS_StLasHardware.Visible = False
        End If

        If (myS_StIndexVor = True) Then
            lblmyS_StIndexVor.Visible = True
        Else
            lblmyS_StIndexVor.Visible = False
        End If

        If (myS_StIndexRueck = True) Then
            lblmyS_StIndexRueck.Visible = True
        Else
            lblmyS_StIndexRueck.Visible = False
        End If

        'Anzeige Stoerung Status allgemein:
        If (myS_StRef = True) Then
            lblStoerungen.BackColor = Color.Red
            lblStoerungen.Text = "Referenz Störung"
            If (CFS_StRef = False) Then  'wenn noch nicht geschrieben dann...
                Dim f As New CFehlerschreiber("Referenzfehler!")
                f = Nothing
                CFS_StRef = True
            End If
        ElseIf (myS_StLaserSchutz = True Or myS_StSpeicherSchutz = True Or myS_StUeberlast = True Or _
                myS_StSpeicher = True Or myS_StKupplung = True Or myS_StDruck = True Or myS_StNotAus = True Or _
                myS_StSchutzTuer = True Or myS_StSchutzHaube = True Or myS_StAbsaugFilter = True Or _
                myS_StAbsaug100p = True Or myS_StShutter = True Or myS_StLasAuftragEnde = True Or _
                myS_StLasShutterZu = True Or myS_StLasSoftware = True Or myS_StLasHardware = True Or _
                myS_StIndexVor = True Or myS_StIndexRueck = True) Then
            lblStoerungen.BackColor = Color.Red
            lblStoerungen.Text = "Störung"
            CFS_StRef = False
        Else
            lblStoerungen.BackColor = Color.LightGreen
            lblStoerungen.Text = "Betriebsbereit"
            CFS_StRef = False
        End If

        'status lampen und statustext des kettenspeichers anzeigen:
        If (myS_MSpeicherVoll = True And myS_MSpeicherLeer = False) Then
            Me.picspeichereingang.Image = CType(resources.GetObject("picboxrot1blau.Image"), System.Drawing.Image)
            Me.picspeicherausgang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
            btnSpeicherStatus.Text = "voll"
            btnSpeicherStatus.BackColor = Color.LightGreen
        ElseIf (myS_MSpeicherVoll = False And myS_MSpeicherLeer = True) Then
            Me.picspeichereingang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
            Me.picspeicherausgang.Image = CType(resources.GetObject("picboxrot1blau.Image"), System.Drawing.Image)
            btnSpeicherStatus.Text = "leer"
            btnSpeicherStatus.BackColor = Color.LightBlue
        ElseIf (myS_MSpeicherVoll = False And myS_MSpeicherLeer = False) Then
            Me.picspeichereingang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
            Me.picspeicherausgang.Image = CType(resources.GetObject("picboxgruen1blau.Image"), System.Drawing.Image)
            btnSpeicherStatus.Text = "aktiv"
            btnSpeicherStatus.BackColor = Color.Yellow
        End If
        If (myS_MWarteSpeicher = True) Then
            btnSpeicherStatus.Text = "wartet"
            btnSpeicherStatus.BackColor = Color.LightGreen
        End If
        If (myS_StSpeicher = True) Then
            btnSpeicherStatus.Text = "Störung"
            btnSpeicherStatus.BackColor = Color.Red
        End If

        If (myIFrgMoma1 = False) Then
            lblmyIFrgMoma1.BackColor = Color.Red
        Else
            lblmyIFrgMoma1.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        End If

        If (myIFrgMoma2 = False) Then
            lblmyIFrgMoma2.BackColor = Color.Red
        Else
            lblmyIFrgMoma2.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        End If

        If (myS_MBuersteNBereit = True) Then
            lblmyS_MBuersteNBereit.BackColor = Color.Red
        Else
            lblmyS_MBuersteNBereit.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        End If

        If myS_MMarkieren Then
            lblmyS_MMarkieren.Visible = True
        Else
            lblmyS_MMarkieren.Visible = False
        End If

        'Counter behandlung neu am 23.09.2008:
        If myTPCounterAktiv Then
            lblCounterTextSoll.Visible = True
            lblCounterTextIst.Visible = True
            lblCounterSoll.Visible = True
            lblCounterIst.Visible = True
            lblCounterSoll.Text = myCounterSoll.ToString
            lblCounterIst.Text = myCounterIst.ToString
        Else
            lblCounterTextSoll.Visible = False
            lblCounterTextIst.Visible = False
            lblCounterSoll.Visible = False
            lblCounterIst.Visible = False
        End If

        If mySAuftragFertig And myTPCounterAktiv Then
            btnCounter.BackColor = Color.Red
        Else
            btnCounter.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        End If

        '****ende onnotificationeventabfrage********
        'If myNot_Aus = True Then
        '   lblStatusMaschine.Text = "***NOT AUS***"
        '   lblStatusMaschine.ForeColor = Color.Red
        '   Me.picboxstatusmaschine.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
        'End If

    End Sub

    Private Sub frm1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        LeseTimer.Enabled = False
        Try
            adsClient.Dispose()
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ShowWindow(FindWindow("Shell_TrayWnd", ""), 1) 'Schalte System-Taskleiste beim beender der Visu wieder ein!
        MyBase.Dispose()
    End Sub

    Private Sub MenuBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuBeenden.Click
        LeseTimer.Enabled = False
        Try
            adsClient.Dispose()
            Close()
        Catch err As Exception
            MessageBox.Show(err.Message)
        End Try
        ShowWindow(FindWindow("Shell_TrayWnd", ""), 1) 'Schalte System-Taskleiste beim beender der Visu wieder ein!
        MyBase.Dispose()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblDatum.Text = DateTime.Today  'Datum anzeigen
        lblZeit.Text = DateTime.Now.ToLongTimeString  'Uhrzeit anzeigen
        Try

            If adsClient.ReadState.AdsState = AdsState.Run Then
                If (Me.picboxTwincat.Image Is CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)) Then
                    Me.picboxTwincat.Image = CType(resources.GetObject("picboxgruen0.Image"), System.Drawing.Image)
                Else
                    Me.picboxTwincat.Image = CType(resources.GetObject("picboxgruen1.Image"), System.Drawing.Image)
                End If
                Me.picboxTcpIp.Image = CType(resources.GetObject("picboxrot0.Image"), System.Drawing.Image)

            Else
                Me.picboxTwincat.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
                Me.picboxTcpIp.Image = CType(resources.GetObject("picboxrot0.Image"), System.Drawing.Image)

            End If
        Catch err As Exception
            Timer1.Enabled = False
            MessageBox.Show("Twincat System nicht bereit!" & vbCrLf & err.Message)
            Me.picboxTwincat.Image = CType(resources.GetObject("picboxrot1.Image"), System.Drawing.Image)
            Me.picboxTcpIp.Image = CType(resources.GetObject("picboxrot0.Image"), System.Drawing.Image)
        End Try
    End Sub

    Private Sub btnAutomatik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutomatik.Click
        adsClient.WriteAny(hConnect(4), True) 'hConnect(3) ist verbingdungshandle zu .TP_Auto
        adsClient.WriteAny(hConnect(3), False) 'hConnect(3) ist verbingdungshandle zu .TP_Hand
    End Sub

    Private Sub btnEinrichtbetrieb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEinrichtbetrieb.Click
        adsClient.WriteAny(hConnect(3), True) 'hConnect(3) ist verbingdungshandle zu .TP_Hand
        adsClient.WriteAny(hConnect(4), False) 'hConnect(4) ist verbingdungshandle zu .TP_Auto 
    End Sub

    ' Ereignisse um UserID zu wechseln.
    Private Sub pnlBediener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim BedienerEingabe As New FPassw(1) ' Konstruktor aufruf von FPassw mit UserID modus 1 und hauptfenster referenz :(
        ' keine andere lösung gefunden leider :(
        'BedienerEingabe.TopMost() = True
        'BedienerEingabe.Show()
    End Sub

    Private Sub lblaktBediener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'pnlBediener_Click(sender, e) 'gebe clickevent einfach an pnlBediener weiter...(da sonst im panel die schriften nicht clicksensibel sind.)
    End Sub

    Private Sub lblBediener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'pnlBediener_Click(sender, e) 'gebe clickevent einfach an pnlBediener weiter...(da sonst im panel die schriften nicht clicksensibel sind.)
    End Sub

    Private Sub lblStoerungen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblStoerungen.Click
        Dim Stoerungsverwaltung As New FStoerungverwaltung
        Stoerungsverwaltung.TopMost = True
        Stoerungsverwaltung.Show()
    End Sub

    Private Sub btnKamera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKamera.Click
        If (myS_MHand = True) Then
            Dim kameraAktifForm As New FKamera
            kameraAktifForm.TopMost() = True
            kameraAktifForm.Show()
        Else
            MsgBox("Nur im Einrichtbetrieb möglich!")
        End If
    End Sub

    Private Sub btnLaser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaser.Click
        If (myS_MHand = True) Then
            Dim LaserStation As New FLaser
            LaserStation.TopMost() = True
            LaserStation.Show()
        Else
            MsgBox("Nur im Einrichtbetrieb möglich!")
        End If
    End Sub

    Private Sub btnKettenspeicher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKettenspeicher.Click
        If (myS_MHand = True) Then
            Dim Kettenspeicher As New FKettenspeicher
            Kettenspeicher.TopMost() = True
            Kettenspeicher.Show()
        Else
            MsgBox("Nur im Einrichtbetrieb möglich!")
        End If
    End Sub


    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    'End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        'zu btnKamera_Click weiterleiten:
        btnKamera_Click(sender, e)
    End Sub

    Private Sub pickameraaktiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pickameraaktiv.Click
        'zu btnKamera_Click weiterleiten:
        btnKamera_Click(sender, e)
    End Sub

    Private Sub pickameraeingang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pickameraeingang.Click
        'zu btnKamera_Click weiterleiten:
        btnKamera_Click(sender, e)
    End Sub

    Private Sub pickameraausgang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pickameraausgang.Click
        'zu btnKamera_Click weiterleiten:
        btnKamera_Click(sender, e)
    End Sub

    Private Sub btnKameraStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKameraStatus.Click
        'zu btnKamera_Click weiterleiten:
        btnKamera_Click(sender, e)
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        'zu btnLaser_Click weiterleiten:
        btnLaser_Click(sender, e)
    End Sub

    Private Sub piclaseraktiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles piclaseraktiv.Click
        'zu btnLaser_Click weiterleiten:
        btnLaser_Click(sender, e)
    End Sub

    Private Sub piclasereingang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles piclasereingang.Click
        'zu btnLaser_Click weiterleiten:
        btnLaser_Click(sender, e)
    End Sub

    Private Sub piclaserausgang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles piclaserausgang.Click
        'zu btnLaser_Click weiterleiten:
        btnLaser_Click(sender, e)
    End Sub

    Private Sub btnLaserStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaserStatus.Click
        'zu btnLaser_Click weiterleiten:
        btnLaser_Click(sender, e)
    End Sub

    Private Sub picspeichereingang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picspeichereingang.Click
        'zu btnKettenspeicher_Click weiterleiten:
        btnKettenspeicher_Click(sender, e)
    End Sub

    Private Sub picspeicherausgang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picspeicherausgang.Click
        'zu btnKettenspeicher_Click weiterleiten:
        btnKettenspeicher_Click(sender, e)
    End Sub

    Private Sub btnSpeicherStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeicherStatus.Click
        'zu btnKettenspeicher_Click weiterleiten:
        btnKettenspeicher_Click(sender, e)
    End Sub

    Private Sub pnlStoerung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlStoerung.Click
        lblStoerungen_Click(sender, e)
    End Sub


    ' umwandeln von WORD in array
    Public Shared Function BitsToBooleanArray(ByVal value As Short) As Boolean()
        'Array mit boolean-werten aus twincat word (in VB ein Uint16 oder short)
        Dim bits(15) As Boolean
        'bitmaske fuer das unterste Bit
        Dim mask As Short = 1
        'Schleife ueber alle Bits
        For i As Integer = 0 To 15
            'bitwert prüfen und speichern
            bits(i) = (value And mask) <> 0
            'Maske für naechstes bit setzen
            mask <<= 1
        Next
        Return bits
    End Function

    'IO / NIO zaehler zuruecksetzen:**************************
    Private del As Threading.ThreadStart
    Private myFirstThread As Threading.Thread
    Private Sub lblAnzahlIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAnzahlIO.Click
        If (myFirstThread Is Nothing) Then
            btnIOruecksetz.Visible = True
            btnIOruecksetz.Enabled = True
            btnIOruecksetz.BringToFront()
            btnIOnotRuecksetz.Visible = True
            btnIOnotRuecksetz.Enabled = True
            btnIOnotRuecksetz.BringToFront()
            del = New Threading.ThreadStart(AddressOf buttonthread2)
            myFirstThread = New Threading.Thread(del)
            myFirstThread.Start()
        End If
    End Sub

    Public Sub buttonthread2()
        myFirstThread.Sleep(2000)  'disable buttons nach 2 sec
        btnIOruecksetz.Visible = False
        btnIOruecksetz.Enabled = False
        btnIOnotRuecksetz.Visible = False
        btnIOnotRuecksetz.Enabled = False
        myFirstThread = Nothing
        del = Nothing
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        lblAnzahlIO_Click(sender, e)
    End Sub

    Private Sub btnIOruecksetz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIOruecksetz.Click
        Dim sh As Short = 0
        adsClient.WriteAny(hConnect(26), sh)  ' .SI_IO nullen
        adsClient.WriteAny(hConnect(27), sh)  ' .SI_NIO nullen
        adsClient.WriteAny(hConnect(30), sh)  ' .SI_FLaser nullen
        adsClient.WriteAny(hConnect(31), sh)  ' .SI_FKamera nullen
        sh = Nothing
    End Sub

    Private Sub btnIOnotRuecksetz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIOnotRuecksetz.Click
        btnIOruecksetz.Visible = False
        btnIOruecksetz.Enabled = False
        btnIOnotRuecksetz.Visible = False
        btnIOnotRuecksetz.Enabled = False
    End Sub
    'ende IO / NIO zaehler ruecksetzen********************************


    Private Sub btnReferenzieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReferenzieren.Click
        Dim hvar As Integer
        hvar = adsClient.CreateVariableHandle(".TP_RefSetzen")
        adsClient.WriteAny(hvar, True)
        adsClient.DeleteVariableHandle(hvar)
        MsgBox("Referenz wurde gesetzt!")
        hvar = Nothing
    End Sub

    'Kettentypen editieren:
    Public myKettentyp As FKettentyp
    Private Sub lblProgrammnummer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProgrammnummer.Click
        If (myS_MHand = True) Then
            Dim passwortcheck As New FPassw(2, Me)
            passwortcheck.Show()
            passwortcheck.BringToFront()
            Me.Enabled = False
        Else
            MsgBox("Nur im Einrichtbetrieb möglich!")
        End If
    End Sub
    Public Sub statuswechsel() 'zeige Kettentyp form wenn passwort OK.
        myKettentyp = New FKettentyp
        myKettentyp.TopMost() = True
        myKettentyp.Show()
    End Sub

    Private Sub lblProgNr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblProgNr.Click
        lblProgrammnummer_Click(sender, e)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblmyIFrgMoma2.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblmyIFrgMoma1.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub

    Private Sub lblAnzahlNIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAnzahlNIO.Click
        lblAnzahlIO_Click(sender, e)  'zum zaehler zuruecksetzen...
    End Sub

    Private Sub lbltaktemin2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltaktemin2.Click
        lblAnzahlIO_Click(sender, e)  'zum zaehler zuruecksetzen...
    End Sub

    Private Sub lblLaserNIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLaserNIO.Click
        lblAnzahlIO_Click(sender, e)  'zum zaehler zuruecksetzen...
    End Sub

    Private Sub txtLaserNIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLaserNIO.Click
        lblAnzahlIO_Click(sender, e)  'zum zaehler zuruecksetzen...
    End Sub

    Private Sub txtKameraNIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKameraNIO.Click
        lblAnzahlIO_Click(sender, e)  'zum zaehler zuruecksetzen...
    End Sub

    Private Sub lblKameraNIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblKameraNIO.Click
        lblAnzahlIO_Click(sender, e)  'zum zaehler zuruecksetzen...
    End Sub

    Public counterAktivForm As FCounter
    Private Sub btnCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCounter.Click
        If (myS_MHand = True) Then
            counterAktivForm = New FCounter
            counterAktivForm.TopMost() = True
            counterAktivForm.Show()
        Else
            MsgBox("Nur im Einrichtbetrieb möglich!")
        End If
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        MessageBox.Show("Version: 25092008" & vbCrLf & "IWIS TCM" & vbCrLf & "Programmierung" & vbCrLf & "Visu: Sertac Yilmaz" & vbCrLf & "SPS: MK")
    End Sub
End Class
