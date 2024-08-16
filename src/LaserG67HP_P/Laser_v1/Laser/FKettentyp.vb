Imports System
Imports System.IO
Imports TwinCAT.Ads
Imports System.Windows.Forms
Imports Laser

Public Class FKettentyp
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
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents btnESC As System.Windows.Forms.Button
    Friend WithEvents lblAktTypIndex As System.Windows.Forms.Label
    Friend WithEvents btnSpeichern As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAktTypIndex As System.Windows.Forms.Button
    Friend WithEvents btnGliederzahl As System.Windows.Forms.Button
    Friend WithEvents btnLaserPos1 As System.Windows.Forms.Button
    Friend WithEvents btnLaserPos2 As System.Windows.Forms.Button
    Friend WithEvents btnLaserPos3 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblStation = New System.Windows.Forms.Label
        Me.btnESC = New System.Windows.Forms.Button
        Me.lblAktTypIndex = New System.Windows.Forms.Label
        Me.btnSpeichern = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnAktTypIndex = New System.Windows.Forms.Button
        Me.btnGliederzahl = New System.Windows.Forms.Button
        Me.btnLaserPos1 = New System.Windows.Forms.Button
        Me.btnLaserPos2 = New System.Windows.Forms.Button
        Me.btnLaserPos3 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblStation
        '
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.lblStation.Location = New System.Drawing.Point(209, 8)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(208, 28)
        Me.lblStation.TabIndex = 5
        Me.lblStation.Text = "Kettentyp"
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
        'lblAktTypIndex
        '
        Me.lblAktTypIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAktTypIndex.ForeColor = System.Drawing.Color.Blue
        Me.lblAktTypIndex.Location = New System.Drawing.Point(196, 74)
        Me.lblAktTypIndex.Name = "lblAktTypIndex"
        Me.lblAktTypIndex.Size = New System.Drawing.Size(120, 20)
        Me.lblAktTypIndex.TabIndex = 7
        Me.lblAktTypIndex.Text = "Progr.Nummer :"
        '
        'btnSpeichern
        '
        Me.btnSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSpeichern.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSpeichern.Location = New System.Drawing.Point(211, 304)
        Me.btnSpeichern.Name = "btnSpeichern"
        Me.btnSpeichern.Size = New System.Drawing.Size(212, 40)
        Me.btnSpeichern.TabIndex = 9
        Me.btnSpeichern.Text = "Speichern"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(50, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Gliederzahl:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(250, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "LaserPos 1:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(378, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "LaserPos 2:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(506, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 20)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "LaserPos 3:"
        '
        'btnAktTypIndex
        '
        Me.btnAktTypIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAktTypIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAktTypIndex.Location = New System.Drawing.Point(336, 52)
        Me.btnAktTypIndex.Name = "btnAktTypIndex"
        Me.btnAktTypIndex.Size = New System.Drawing.Size(92, 64)
        Me.btnAktTypIndex.TabIndex = 18
        Me.btnAktTypIndex.Text = "0"
        '
        'btnGliederzahl
        '
        Me.btnGliederzahl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGliederzahl.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGliederzahl.Location = New System.Drawing.Point(30, 184)
        Me.btnGliederzahl.Name = "btnGliederzahl"
        Me.btnGliederzahl.Size = New System.Drawing.Size(126, 64)
        Me.btnGliederzahl.TabIndex = 19
        Me.btnGliederzahl.Text = "0"
        '
        'btnLaserPos1
        '
        Me.btnLaserPos1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLaserPos1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaserPos1.Location = New System.Drawing.Point(238, 184)
        Me.btnLaserPos1.Name = "btnLaserPos1"
        Me.btnLaserPos1.Size = New System.Drawing.Size(112, 64)
        Me.btnLaserPos1.TabIndex = 20
        Me.btnLaserPos1.Text = "0"
        '
        'btnLaserPos2
        '
        Me.btnLaserPos2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLaserPos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaserPos2.Location = New System.Drawing.Point(366, 184)
        Me.btnLaserPos2.Name = "btnLaserPos2"
        Me.btnLaserPos2.Size = New System.Drawing.Size(112, 64)
        Me.btnLaserPos2.TabIndex = 21
        Me.btnLaserPos2.Text = "0"
        '
        'btnLaserPos3
        '
        Me.btnLaserPos3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLaserPos3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLaserPos3.Location = New System.Drawing.Point(494, 184)
        Me.btnLaserPos3.Name = "btnLaserPos3"
        Me.btnLaserPos3.Size = New System.Drawing.Size(112, 64)
        Me.btnLaserPos3.TabIndex = 22
        Me.btnLaserPos3.Text = "0"
        '
        'FKettentyp
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(635, 362)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnLaserPos3)
        Me.Controls.Add(Me.btnLaserPos2)
        Me.Controls.Add(Me.btnLaserPos1)
        Me.Controls.Add(Me.btnGliederzahl)
        Me.Controls.Add(Me.btnAktTypIndex)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSpeichern)
        Me.Controls.Add(Me.lblAktTypIndex)
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.lblStation)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(2, 114)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FKettentyp"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FKettentyp"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public myAktTypIndex As UInt16  'word in SPS ist Uint16 in VB
    Public mySKettentyp As UInt16()
    Public myTPKettentyp As UInt16()

    'sps handles:
    Public hAktTypIndex As Integer
    Public hTPTypIndex As Integer
    Public hSKettentyparr As Integer

    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click
        AppMgr.frm1.Enabled = True
        Me.Close()
    End Sub

    Private Sub FKettentyp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppMgr.frm1.Enabled = False


        'lese zuerst AktTypIndex aus:
        hAktTypIndex = AppMgr.frm1.adsClient.CreateVariableHandle(".AktTypindex")
        AppMgr.frm1.dataStream.Position = 0
        AppMgr.frm1.adsClient.Read(hAktTypIndex, AppMgr.frm1.dataStream)
        myAktTypIndex = AppMgr.frm1.binread.ReadUInt16()
        btnAktTypIndex.Text = myAktTypIndex.ToString
        
        'dann speichere AktTypindex in TPTypIndex: (nötig für die SPS)
        hTPTypIndex = AppMgr.frm1.adsClient.CreateVariableHandle(".TPTypIndex")
        AppMgr.frm1.adsClient.WriteAny(hTPTypIndex, myAktTypIndex)

        'lese Aktuelle Typ-Eigenschaften von SKettentyp(0...3) of word
        ReDim mySKettentyp(3)
        Dim hSKettentyparr As Integer
        hSKettentyparr = AppMgr.frm1.adsClient.CreateVariableHandle(".SKettenTyp")
        mySKettentyp = AppMgr.frm1.adsClient.ReadAny(hSKettentyparr, GetType(UInt16()), New Integer() {4})
        btnGliederzahl.Text = mySKettentyp(0).ToString
        btnLaserPos1.Text = mySKettentyp(1).ToString
        btnLaserPos2.Text = mySKettentyp(2).ToString
        btnLaserPos3.Text = mySKettentyp(3).ToString
        'MsgBox(mySKettentyp(0).ToString + "---" + mySKettentyp(1).ToString + "---" + mySKettentyp(2).ToString + "---" + mySKettentyp(3).ToString)

    End Sub

    Public akttypeingabe As FPassw
    Private Sub btnAktTypIndex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAktTypIndex.Click
        akttypeingabe = New FPassw(3, Me, 1, sender)
        akttypeingabe.Show()
        akttypeingabe.BringToFront()
        Me.Enabled = False
    End Sub
    Public gliedereingabe As FPassw
    Private Sub btnGliederzahl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGliederzahl.Click
        gliedereingabe = New FPassw(3, Me, 2, sender)
        gliedereingabe.Show()
        gliedereingabe.BringToFront()
        Me.Enabled = False
    End Sub
    Public laserposeingabe1 As FPassw
    Private Sub btnLaserPos1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaserPos1.Click
        laserposeingabe1 = New FPassw(3, Me, 2, sender)
        laserposeingabe1.Show()
        laserposeingabe1.BringToFront()
        Me.Enabled = False
    End Sub
    Public laserposeingabe2 As FPassw
    Private Sub btnLaserPos2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaserPos2.Click
        laserposeingabe2 = New FPassw(3, Me, 2, sender)
        laserposeingabe2.Show()
        laserposeingabe2.BringToFront()
        Me.Enabled = False
    End Sub
    Public laserposeingabe3 As FPassw
    Private Sub btnLaserPos3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaserPos3.Click
        laserposeingabe3 = New FPassw(3, Me, 2, sender)
        laserposeingabe3.Show()
        laserposeingabe3.BringToFront()
        Me.Enabled = False
    End Sub

    Private Sub btnSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeichern.Click
        If myAktTypIndex.Equals(UInt16.Parse(btnAktTypIndex.Text)) Then  'Uint16 kann man nicht mit = vergleichen...
            MsgBox("Aktueller Typ kann nicht editiert werden!")
        ElseIf (UInt16.Parse(btnGliederzahl.Text)).Equals(UInt16.Parse(btnLaserPos1.Text)) Or _
               (UInt16.Parse(btnGliederzahl.Text)).Equals(UInt16.Parse(btnLaserPos2.Text)) Or _
               (UInt16.Parse(btnGliederzahl.Text)).Equals(UInt16.Parse(btnLaserPos3.Text)) Then
            MsgBox("Gliederzahl muss grösser als Laserpos 1 , 2 und 3 sein!")
        Else
            AppMgr.frm1.adsClient.WriteAny(hTPTypIndex, UInt16.Parse(btnAktTypIndex.Text))

            'zum editieren des geanderten Typen mit den eigenschaften von TPKettentyparr(0...3) of word
            ReDim myTPKettentyp(3)
            myTPKettentyp(0) = UInt16.Parse(btnGliederzahl.Text)
            myTPKettentyp(1) = UInt16.Parse(btnLaserPos1.Text)
            myTPKettentyp(2) = UInt16.Parse(btnLaserPos2.Text)
            myTPKettentyp(3) = UInt16.Parse(btnLaserPos3.Text)
            Dim hTPKettentyparr(3) As Integer
            For k As Integer = 0 To 3 Step 1  'schreibe array daten einzeln rein, da sonst nicht funzt mit uint16 und word.
                hTPKettentyparr(k) = AppMgr.frm1.adsClient.CreateVariableHandle(".TPKettenTyp[" + k.ToString + "]")
                AppMgr.frm1.adsClient.WriteAny(hTPKettentyparr(k), myTPKettentyp(k))
            Next
            Dim hTPtypspeichern As Integer
            hTPtypspeichern = AppMgr.frm1.adsClient.CreateVariableHandle(".TPTypSpeichern")
            AppMgr.frm1.adsClient.WriteAny(hTPtypspeichern, True)

            AppMgr.frm1.Enabled = True
            Me.Close()
        End If
    End Sub
End Class
