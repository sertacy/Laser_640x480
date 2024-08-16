Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Windows.Forms
Imports Laser

Public Class FCounter
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
    Public resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FCounter))
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents btnESC As System.Windows.Forms.Button
    Friend WithEvents btnCounterAktiv As System.Windows.Forms.Button
    Friend WithEvents piccounteraktiv As System.Windows.Forms.PictureBox
    Friend WithEvents btnSollEditieren As System.Windows.Forms.Button
    Friend WithEvents btnIstNullen As System.Windows.Forms.Button
    Friend WithEvents picboxrot1big As System.Windows.Forms.PictureBox
    Friend WithEvents picboxgruen1big As System.Windows.Forms.PictureBox
    Friend WithEvents lblSollWert As System.Windows.Forms.Label
    Friend WithEvents lblIstWert As System.Windows.Forms.Label
    Friend WithEvents lblAuftragFertig As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FCounter))
        Me.lblStation = New System.Windows.Forms.Label
        Me.btnESC = New System.Windows.Forms.Button
        Me.btnCounterAktiv = New System.Windows.Forms.Button
        Me.piccounteraktiv = New System.Windows.Forms.PictureBox
        Me.btnSollEditieren = New System.Windows.Forms.Button
        Me.btnIstNullen = New System.Windows.Forms.Button
        Me.lblSollWert = New System.Windows.Forms.Label
        Me.lblIstWert = New System.Windows.Forms.Label
        Me.picboxrot1big = New System.Windows.Forms.PictureBox
        Me.picboxgruen1big = New System.Windows.Forms.PictureBox
        Me.lblAuftragFertig = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblStation
        '
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblStation.Location = New System.Drawing.Point(209, 8)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(208, 28)
        Me.lblStation.TabIndex = 6
        Me.lblStation.Text = "Counter Einstellungen"
        Me.lblStation.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnESC
        '
        Me.btnESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnESC.Location = New System.Drawing.Point(560, 4)
        Me.btnESC.Name = "btnESC"
        Me.btnESC.Size = New System.Drawing.Size(72, 40)
        Me.btnESC.TabIndex = 7
        Me.btnESC.Text = "ESC"
        '
        'btnCounterAktiv
        '
        Me.btnCounterAktiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCounterAktiv.Location = New System.Drawing.Point(86, 62)
        Me.btnCounterAktiv.Name = "btnCounterAktiv"
        Me.btnCounterAktiv.Size = New System.Drawing.Size(184, 60)
        Me.btnCounterAktiv.TabIndex = 8
        Me.btnCounterAktiv.Text = "Counter Aktiv"
        '
        'piccounteraktiv
        '
        Me.piccounteraktiv.Location = New System.Drawing.Point(280, 82)
        Me.piccounteraktiv.Name = "piccounteraktiv"
        Me.piccounteraktiv.Size = New System.Drawing.Size(20, 20)
        Me.piccounteraktiv.TabIndex = 38
        Me.piccounteraktiv.TabStop = False
        '
        'btnSollEditieren
        '
        Me.btnSollEditieren.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSollEditieren.Location = New System.Drawing.Point(86, 226)
        Me.btnSollEditieren.Name = "btnSollEditieren"
        Me.btnSollEditieren.Size = New System.Drawing.Size(184, 60)
        Me.btnSollEditieren.TabIndex = 39
        Me.btnSollEditieren.Text = "Soll Eingabe"
        '
        'btnIstNullen
        '
        Me.btnIstNullen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIstNullen.Location = New System.Drawing.Point(378, 226)
        Me.btnIstNullen.Name = "btnIstNullen"
        Me.btnIstNullen.Size = New System.Drawing.Size(184, 60)
        Me.btnIstNullen.TabIndex = 40
        Me.btnIstNullen.Text = "Ist Nullen"
        '
        'lblSollWert
        '
        Me.lblSollWert.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSollWert.Location = New System.Drawing.Point(112, 290)
        Me.lblSollWert.Name = "lblSollWert"
        Me.lblSollWert.Size = New System.Drawing.Size(134, 24)
        Me.lblSollWert.TabIndex = 41
        Me.lblSollWert.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblIstWert
        '
        Me.lblIstWert.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblIstWert.Location = New System.Drawing.Point(404, 290)
        Me.lblIstWert.Name = "lblIstWert"
        Me.lblIstWert.Size = New System.Drawing.Size(134, 24)
        Me.lblIstWert.TabIndex = 42
        Me.lblIstWert.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'picboxrot1big
        '
        Me.picboxrot1big.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        Me.picboxrot1big.Location = New System.Drawing.Point(604, 328)
        Me.picboxrot1big.Name = "picboxrot1big"
        Me.picboxrot1big.Size = New System.Drawing.Size(20, 20)
        Me.picboxrot1big.TabIndex = 46
        Me.picboxrot1big.TabStop = False
        Me.picboxrot1big.Visible = False
        '
        'picboxgruen1big
        '
        Me.picboxgruen1big.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        Me.picboxgruen1big.Location = New System.Drawing.Point(580, 328)
        Me.picboxgruen1big.Name = "picboxgruen1big"
        Me.picboxgruen1big.Size = New System.Drawing.Size(20, 20)
        Me.picboxgruen1big.TabIndex = 47
        Me.picboxgruen1big.TabStop = False
        Me.picboxgruen1big.Visible = False
        '
        'lblAuftragFertig
        '
        Me.lblAuftragFertig.BackColor = System.Drawing.Color.Red
        Me.lblAuftragFertig.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAuftragFertig.Location = New System.Drawing.Point(208, 167)
        Me.lblAuftragFertig.Name = "lblAuftragFertig"
        Me.lblAuftragFertig.Size = New System.Drawing.Size(221, 23)
        Me.lblAuftragFertig.TabIndex = 48
        Me.lblAuftragFertig.Text = "Auftrag fertig!"
        Me.lblAuftragFertig.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblAuftragFertig.Visible = False
        '
        'FCounter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(635, 362)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblAuftragFertig)
        Me.Controls.Add(Me.picboxgruen1big)
        Me.Controls.Add(Me.picboxrot1big)
        Me.Controls.Add(Me.lblIstWert)
        Me.Controls.Add(Me.lblSollWert)
        Me.Controls.Add(Me.btnIstNullen)
        Me.Controls.Add(Me.btnSollEditieren)
        Me.Controls.Add(Me.piccounteraktiv)
        Me.Controls.Add(Me.btnCounterAktiv)
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.lblStation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(2, 114)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FCounter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FCounter"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click
        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Private Sub FCounter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppMgr.frm1.Enabled = False
        ueberpruefe()
    End Sub

    Public Sub ueberpruefe()
        If (Laser.AppMgr.frm1.myTPCounterAktiv = True) Then
            Me.piccounteraktiv.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
            If (Laser.AppMgr.frm1.mySAuftragFertig = True) Then
                lblAuftragFertig.Visible = True
            Else
                lblAuftragFertig.Visible = False
            End If
        Else
            Me.piccounteraktiv.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
            lblAuftragFertig.Visible = False
        End If

        lblSollWert.Text = Laser.AppMgr.frm1.myCounterSoll
        lblIstWert.Text = Laser.AppMgr.frm1.myCounterIst
    End Sub

    Private Sub btnCounterAktiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCounterAktiv.Click
        If (Laser.AppMgr.frm1.myTPCounterAktiv = True) Then
            AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(50), False) '  .TP_KammeraAktiv deaktivieren
            Me.piccounteraktiv.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        Else
            AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(50), True) '  .TP_KammeraAktiv aktivieren
            Me.piccounteraktiv.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        End If
    End Sub

    Private Sub btnIstNullen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIstNullen.Click
        Dim nullwert As Short = 0
        AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(49), nullwert)
        lblIstWert.Text = nullwert.ToString
        lblAuftragFertig.Visible = False
    End Sub
    Public sollWertEingabe As FPassw
    Private Sub btnSollEditieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSollEditieren.Click
        sollWertEingabe = New FPassw(3, Me, 2, sender)
        sollWertEingabe.Show()
        sollWertEingabe.BringToFront()
        Me.Enabled = False
    End Sub
    Public Sub schreibeSollwert()
        Dim wert As New Short
        wert = Int16.Parse(lblSollWert.Text)
        AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(48), wert)
    End Sub
End Class
