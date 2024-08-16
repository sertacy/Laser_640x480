Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Windows.Forms
Imports Laser

Public Class FKettenspeicher
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
    Friend WithEvents btnESC As System.Windows.Forms.Button
    Friend WithEvents lblKettenspeicher As System.Windows.Forms.Label
    Friend WithEvents btnVorSchnell As System.Windows.Forms.Button
    Friend WithEvents btnRueckSchnell As System.Windows.Forms.Button
    Friend WithEvents btnVorLangsam As System.Windows.Forms.Button
    Friend WithEvents btnRueckLangsam As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblKettenspeicher = New System.Windows.Forms.Label
        Me.btnESC = New System.Windows.Forms.Button
        Me.btnVorSchnell = New System.Windows.Forms.Button
        Me.btnRueckSchnell = New System.Windows.Forms.Button
        Me.btnVorLangsam = New System.Windows.Forms.Button
        Me.btnRueckLangsam = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblKettenspeicher
        '
        Me.lblKettenspeicher.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblKettenspeicher.Location = New System.Drawing.Point(213, 8)
        Me.lblKettenspeicher.Name = "lblKettenspeicher"
        Me.lblKettenspeicher.Size = New System.Drawing.Size(208, 28)
        Me.lblKettenspeicher.TabIndex = 4
        Me.lblKettenspeicher.Text = "Kettenspeicher"
        Me.lblKettenspeicher.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        'btnVorSchnell
        '
        Me.btnVorSchnell.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVorSchnell.Location = New System.Drawing.Point(102, 174)
        Me.btnVorSchnell.Name = "btnVorSchnell"
        Me.btnVorSchnell.Size = New System.Drawing.Size(182, 68)
        Me.btnVorSchnell.TabIndex = 6
        Me.btnVorSchnell.Text = "<<<"
        '
        'btnRueckSchnell
        '
        Me.btnRueckSchnell.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRueckSchnell.Location = New System.Drawing.Point(362, 174)
        Me.btnRueckSchnell.Name = "btnRueckSchnell"
        Me.btnRueckSchnell.Size = New System.Drawing.Size(182, 68)
        Me.btnRueckSchnell.TabIndex = 7
        Me.btnRueckSchnell.Text = ">>>"
        '
        'btnVorLangsam
        '
        Me.btnVorLangsam.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVorLangsam.Location = New System.Drawing.Point(102, 264)
        Me.btnVorLangsam.Name = "btnVorLangsam"
        Me.btnVorLangsam.Size = New System.Drawing.Size(182, 68)
        Me.btnVorLangsam.TabIndex = 8
        Me.btnVorLangsam.Text = "<"
        '
        'btnRueckLangsam
        '
        Me.btnRueckLangsam.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRueckLangsam.Location = New System.Drawing.Point(362, 264)
        Me.btnRueckLangsam.Name = "btnRueckLangsam"
        Me.btnRueckLangsam.Size = New System.Drawing.Size(182, 68)
        Me.btnRueckLangsam.TabIndex = 9
        Me.btnRueckLangsam.Text = ">"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(392, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 22)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Zurück"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(136, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 22)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Vor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FKettenspeicher
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(635, 362)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnRueckLangsam)
        Me.Controls.Add(Me.btnVorLangsam)
        Me.Controls.Add(Me.btnRueckSchnell)
        Me.Controls.Add(Me.btnVorSchnell)
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.lblKettenspeicher)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(2, 114)
        Me.Name = "FKettenspeicher"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FKettenspeicher"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public hval() As Integer

    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click

        For i As Integer = 0 To 3 Step 1
            AppMgr.frm1.adsClient.WriteAny(hval(i), False)  'alle auf false setzen
        Next

        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Private Sub FKettenspeicher_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReDim hval(3)
        AppMgr.frm1.Enabled = False
        ueberpruefe()
    End Sub

    Public Sub ueberpruefe()
        hval(0) = AppMgr.frm1.adsClient.CreateVariableHandle(".TP_MVor")
        hval(1) = AppMgr.frm1.adsClient.CreateVariableHandle(".TP_MRueck")
        hval(2) = AppMgr.frm1.adsClient.CreateVariableHandle(".TP_MVorS")
        hval(3) = AppMgr.frm1.adsClient.CreateVariableHandle(".TP_MRueckS")

        For i As Integer = 0 To 3 Step 1
            AppMgr.frm1.adsClient.WriteAny(hval(i), False)  'alle auf false setzen
        Next

        btnVorLangsam.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnRueckLangsam.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnVorSchnell.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnRueckSchnell.BackColor = Color.FromName(System.Drawing.KnownColor.Control)

    End Sub

    Private Sub btnVorLangsam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVorLangsam.Click
        AppMgr.frm1.adsClient.WriteAny(hval(0), True)
        AppMgr.frm1.adsClient.WriteAny(hval(1), False)
        AppMgr.frm1.adsClient.WriteAny(hval(2), False)
        AppMgr.frm1.adsClient.WriteAny(hval(3), False)

        btnVorLangsam.BackColor = Color.LightGreen
        btnRueckLangsam.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnVorSchnell.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnRueckSchnell.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
    End Sub

    Private Sub btnRueckLangsam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRueckLangsam.Click
        AppMgr.frm1.adsClient.WriteAny(hval(0), False)
        AppMgr.frm1.adsClient.WriteAny(hval(1), True)
        AppMgr.frm1.adsClient.WriteAny(hval(2), False)
        AppMgr.frm1.adsClient.WriteAny(hval(3), False)

        btnVorLangsam.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnRueckLangsam.BackColor = Color.LightGreen
        btnVorSchnell.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnRueckSchnell.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
    End Sub

    Private Sub btnVorSchnell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVorSchnell.Click
        AppMgr.frm1.adsClient.WriteAny(hval(0), False)
        AppMgr.frm1.adsClient.WriteAny(hval(1), False)
        AppMgr.frm1.adsClient.WriteAny(hval(2), True)
        AppMgr.frm1.adsClient.WriteAny(hval(3), False)

        btnVorLangsam.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnRueckLangsam.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnVorSchnell.BackColor = Color.LightGreen
        btnRueckSchnell.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
    End Sub

    Private Sub btnRueckSchnell_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRueckSchnell.Click
        AppMgr.frm1.adsClient.WriteAny(hval(0), False)
        AppMgr.frm1.adsClient.WriteAny(hval(1), False)
        AppMgr.frm1.adsClient.WriteAny(hval(2), False)
        AppMgr.frm1.adsClient.WriteAny(hval(3), True)

        btnVorLangsam.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnRueckLangsam.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnVorSchnell.BackColor = Color.FromName(System.Drawing.KnownColor.Control)
        btnRueckSchnell.BackColor = Color.LightGreen
    End Sub
End Class
