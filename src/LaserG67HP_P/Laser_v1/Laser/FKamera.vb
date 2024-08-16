Public Class FKamera
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
    Public resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FKamera))
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents btnESC As System.Windows.Forms.Button
    Friend WithEvents btnLaserAktiv As System.Windows.Forms.Button
    Friend WithEvents picboxgruen1big As System.Windows.Forms.PictureBox
    Friend WithEvents picboxrot1big As System.Windows.Forms.PictureBox
    Friend WithEvents pickameraaktiv As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FKamera))
        Me.lblStation = New System.Windows.Forms.Label
        Me.btnESC = New System.Windows.Forms.Button
        Me.btnLaserAktiv = New System.Windows.Forms.Button
        Me.pickameraaktiv = New System.Windows.Forms.PictureBox
        Me.picboxgruen1big = New System.Windows.Forms.PictureBox
        Me.picboxrot1big = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'lblStation
        '
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblStation.Location = New System.Drawing.Point(209, 8)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(208, 28)
        Me.lblStation.TabIndex = 5
        Me.lblStation.Text = "Kamera Station"
        Me.lblStation.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnESC
        '
        Me.btnESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnESC.Location = New System.Drawing.Point(560, 4)
        Me.btnESC.Name = "btnESC"
        Me.btnESC.Size = New System.Drawing.Size(72, 40)
        Me.btnESC.TabIndex = 6
        Me.btnESC.Text = "ESC"
        '
        'btnLaserAktiv
        '
        Me.btnLaserAktiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaserAktiv.Location = New System.Drawing.Point(86, 62)
        Me.btnLaserAktiv.Name = "btnLaserAktiv"
        Me.btnLaserAktiv.Size = New System.Drawing.Size(184, 60)
        Me.btnLaserAktiv.TabIndex = 7
        Me.btnLaserAktiv.Text = "Kamera Aktiv"
        '
        'pickameraaktiv
        '
        Me.pickameraaktiv.Location = New System.Drawing.Point(280, 82)
        Me.pickameraaktiv.Name = "pickameraaktiv"
        Me.pickameraaktiv.Size = New System.Drawing.Size(20, 20)
        Me.pickameraaktiv.TabIndex = 37
        Me.pickameraaktiv.TabStop = False
        '
        'picboxgruen1big
        '
        Me.picboxgruen1big.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        Me.picboxgruen1big.Location = New System.Drawing.Point(534, 334)
        Me.picboxgruen1big.Name = "picboxgruen1big"
        Me.picboxgruen1big.Size = New System.Drawing.Size(20, 20)
        Me.picboxgruen1big.TabIndex = 44
        Me.picboxgruen1big.TabStop = False
        Me.picboxgruen1big.Visible = False
        '
        'picboxrot1big
        '
        Me.picboxrot1big.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        Me.picboxrot1big.Location = New System.Drawing.Point(558, 334)
        Me.picboxrot1big.Name = "picboxrot1big"
        Me.picboxrot1big.Size = New System.Drawing.Size(20, 20)
        Me.picboxrot1big.TabIndex = 45
        Me.picboxrot1big.TabStop = False
        Me.picboxrot1big.Visible = False
        '
        'FKamera
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(635, 362)
        Me.ControlBox = False
        Me.Controls.Add(Me.picboxrot1big)
        Me.Controls.Add(Me.picboxgruen1big)
        Me.Controls.Add(Me.pickameraaktiv)
        Me.Controls.Add(Me.btnLaserAktiv)
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.lblStation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(2, 114)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FKamera"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FKamera"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click
        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Private Sub FKamera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppMgr.frm1.Enabled = False
        ueberpruefe()
    End Sub

    Public Sub ueberpruefe()
        If (Laser.AppMgr.frm1.myTP_KammeraAktiv = True) Then
            Me.pickameraaktiv.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        Else
            Me.pickameraaktiv.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        End If
    End Sub

    Private Sub btnLaserAktiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaserAktiv.Click
        Dim passwortcheck As New FPassw(2, Me)
        passwortcheck.Show()
        passwortcheck.BringToFront()
        Me.Enabled = False
    End Sub

    Public Sub statuswechsel()   'wird über passwort eingabe fenster aufgerufen.
        If (Laser.AppMgr.frm1.myTP_KammeraAktiv = True) Then
            AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(2), False) '  .TP_KammeraAktiv deaktivieren
            Me.pickameraaktiv.Image = CType(resources.GetObject("picboxrot1big.Image"), System.Drawing.Image)
        Else
            AppMgr.frm1.adsClient.WriteAny(AppMgr.frm1.hConnect(2), True) '  .TP_KammeraAktiv aktivieren
            Me.pickameraaktiv.Image = CType(resources.GetObject("picboxgruen1big.Image"), System.Drawing.Image)
        End If
    End Sub
End Class
