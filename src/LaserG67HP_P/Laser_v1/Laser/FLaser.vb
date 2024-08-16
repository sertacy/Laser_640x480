Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Windows.Forms
Imports Laser


Public Class FLaser
    Inherits System.Windows.Forms.Form

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
    Public resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FLaser))
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents btnESC As System.Windows.Forms.Button
    Friend WithEvents btnLaserAktiv As System.Windows.Forms.Button
    Friend WithEvents piclaseraktiv As System.Windows.Forms.PictureBox
    Friend WithEvents btnHandLasern As System.Windows.Forms.Button
    Friend WithEvents pichandlasern As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgruen1big As System.Windows.Forms.PictureBox
    Friend WithEvents picboxrot1big As System.Windows.Forms.PictureBox
    Friend WithEvents picdrehgebpos As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TimerDrehgeber As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FLaser))
        Me.lblStation = New System.Windows.Forms.Label
        Me.btnESC = New System.Windows.Forms.Button
        Me.btnLaserAktiv = New System.Windows.Forms.Button
        Me.piclaseraktiv = New System.Windows.Forms.PictureBox
        Me.btnHandLasern = New System.Windows.Forms.Button
        Me.pichandlasern = New System.Windows.Forms.PictureBox
        Me.picdrehgebpos = New System.Windows.Forms.PictureBox
        Me.picboxgruen1big = New System.Windows.Forms.PictureBox
        Me.picboxrot1big = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TimerDrehgeber = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblStation
        '
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblStation.Location = New System.Drawing.Point(209, 8)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(208, 28)
        Me.lblStation.TabIndex = 4
        Me.lblStation.Text = "Laser Station"
        Me.lblStation.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnESC
        '
        Me.btnESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnESC.Location = New System.Drawing.Point(560, 4)
        Me.btnESC.Name = "btnESC"
        Me.btnESC.Size = New System.Drawing.Size(72, 40)
        Me.btnESC.TabIndex = 5
        Me.btnESC.Text = "ESC"
        '
        'btnLaserAktiv
        '
        Me.btnLaserAktiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaserAktiv.Location = New System.Drawing.Point(86, 100)
        Me.btnLaserAktiv.Name = "btnLaserAktiv"
        Me.btnLaserAktiv.Size = New System.Drawing.Size(184, 60)
        Me.btnLaserAktiv.TabIndex = 6
        Me.btnLaserAktiv.Text = "Laser Aktiv"
        '
        'piclaseraktiv
        '
        Me.piclaseraktiv.Location = New System.Drawing.Point(280, 120)
        Me.piclaseraktiv.Name = "piclaseraktiv"
        Me.piclaseraktiv.Size = New System.Drawing.Size(20, 20)
        Me.piclaseraktiv.TabIndex = 36
        Me.piclaseraktiv.TabStop = False
        '
        'btnHandLasern
        '
        Me.btnHandLasern.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHandLasern.Location = New System.Drawing.Point(86, 198)
        Me.btnHandLasern.Name = "btnHandLasern"
        Me.btnHandLasern.Size = New System.Drawing.Size(184, 60)
        Me.btnHandLasern.TabIndex = 39
        Me.btnHandLasern.Text = "Hand Lasern"
        '
        'pichandlasern
        '
        Me.pichandlasern.Location = New System.Drawing.Point(280, 218)
        Me.pichandlasern.Name = "pichandlasern"
        Me.pichandlasern.Size = New System.Drawing.Size(20, 20)
        Me.pichandlasern.TabIndex = 41
        Me.pichandlasern.TabStop = False
        '
        'picdrehgebpos
        '
        Me.picdrehgebpos.Location = New System.Drawing.Point(486, 156)
        Me.picdrehgebpos.Name = "picdrehgebpos"
        Me.picdrehgebpos.Size = New System.Drawing.Size(20, 20)
        Me.picdrehgebpos.TabIndex = 42
        Me.picdrehgebpos.TabStop = False
        '
        'picboxgruen1big
        '
        Me.picboxgruen1big.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        Me.picboxgruen1big.Location = New System.Drawing.Point(454, 334)
        Me.picboxgruen1big.Name = "picboxgruen1big"
        Me.picboxgruen1big.Size = New System.Drawing.Size(20, 20)
        Me.picboxgruen1big.TabIndex = 43
        Me.picboxgruen1big.TabStop = False
        Me.picboxgruen1big.Visible = False
        '
        'picboxrot1big
        '
        Me.picboxrot1big.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        Me.picboxrot1big.Location = New System.Drawing.Point(478, 334)
        Me.picboxrot1big.Name = "picboxrot1big"
        Me.picboxrot1big.Size = New System.Drawing.Size(20, 20)
        Me.picboxrot1big.TabIndex = 44
        Me.picboxrot1big.TabStop = False
        Me.picboxrot1big.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(424, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 44)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Drehgeber Montageposition"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Location = New System.Drawing.Point(422, 152)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(150, 72)
        Me.Panel1.TabIndex = 46
        '
        'TimerDrehgeber
        '
        Me.TimerDrehgeber.Interval = 300
        '
        'FLaser
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(635, 362)
        Me.ControlBox = False
        Me.Controls.Add(Me.picdrehgebpos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picboxrot1big)
        Me.Controls.Add(Me.picboxgruen1big)
        Me.Controls.Add(Me.pichandlasern)
        Me.Controls.Add(Me.btnHandLasern)
        Me.Controls.Add(Me.piclaseraktiv)
        Me.Controls.Add(Me.btnLaserAktiv)
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(2, 114)
        Me.Name = "FLaser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FLaser"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click
        AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(1), False) '  .TP_LaserHand deaktivieren beim fenster schliessen
        TimerDrehgeber.Enabled = False
        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Private Sub FLaser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppMgr.frm1.Enabled = False
        TimerDrehgeber.Enabled = True
        TimerDrehgeber_Tick(Me, e)
        ueberpruefe()
    End Sub

    Public Sub ueberpruefe()
        If (Laser.AppMgr.frm1.myTP_LaserAktiv = True) Then
            Me.piclaseraktiv.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        Else
            Me.piclaseraktiv.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        End If

        If (Laser.AppMgr.frm1.myTP_LaserHand = True) Then
            Me.pichandlasern.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        Else
            Me.pichandlasern.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        End If
    End Sub

    Private Sub btnLaserAktiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaserAktiv.Click
        Dim passwortcheck As New FPassw(2, Me)
        passwortcheck.Show()
        passwortcheck.BringToFront()
        Me.Enabled = False
    End Sub

    Public Sub statuswechsel()   'wird über passwort eingabe fenster aufgerufen.
        If (Laser.AppMgr.frm1.myTP_LaserAktiv = True) Then
            AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(0), False) '  .TP_LaserAktiv deaktivieren
            Me.piclaseraktiv.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        Else
            AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(0), True) '  .TP_LaserAktiv aktivieren
            Me.piclaseraktiv.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        End If
    End Sub

    Private Sub btnHandLasern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHandLasern.Click
        ' ohne passwort abfrage...
        If (Laser.AppMgr.frm1.myTP_LaserHand = True) Then
            AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(1), False) '  .TP_LaserHand deaktivieren
            Me.pichandlasern.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        Else
            AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(1), True) '  .TP_LaserHand aktivieren
            Me.pichandlasern.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        End If
    End Sub

    Private Sub TimerDrehgeber_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDrehgeber.Tick
        If (Laser.AppMgr.frm1.myS_MDrehgMontPos = True) Then
            Me.picdrehgebpos.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        Else
            Me.picdrehgebpos.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        End If
    End Sub
End Class
