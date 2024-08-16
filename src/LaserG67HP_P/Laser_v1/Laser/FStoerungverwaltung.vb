Imports System.IO
Imports Laser

Public Class FStoerungverwaltung
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
    Friend WithEvents lblstorungengesamt As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lboxFehlerGesamt As System.Windows.Forms.ListBox
    Friend WithEvents lboxFehlerAktuell As System.Windows.Forms.ListBox
    Friend WithEvents btnESC As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblstorungengesamt = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lboxFehlerGesamt = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lboxFehlerAktuell = New System.Windows.Forms.ListBox
        Me.btnESC = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblstorungengesamt
        '
        Me.lblstorungengesamt.BackColor = System.Drawing.Color.Transparent
        Me.lblstorungengesamt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lblstorungengesamt.Location = New System.Drawing.Point(8, 34)
        Me.lblstorungengesamt.Name = "lblstorungengesamt"
        Me.lblstorungengesamt.Size = New System.Drawing.Size(176, 22)
        Me.lblstorungengesamt.TabIndex = 2
        Me.lblstorungengesamt.Text = "Störungverlauf :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(8, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Störungsverwaltung"
        '
        'lboxFehlerGesamt
        '
        Me.lboxFehlerGesamt.Location = New System.Drawing.Point(6, 60)
        Me.lboxFehlerGesamt.Name = "lboxFehlerGesamt"
        Me.lboxFehlerGesamt.Size = New System.Drawing.Size(624, 199)
        Me.lboxFehlerGesamt.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(8, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 22)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "letzte Störung :"
        '
        'lboxFehlerAktuell
        '
        Me.lboxFehlerAktuell.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lboxFehlerAktuell.ItemHeight = 20
        Me.lboxFehlerAktuell.Location = New System.Drawing.Point(6, 290)
        Me.lboxFehlerAktuell.Name = "lboxFehlerAktuell"
        Me.lboxFehlerAktuell.Size = New System.Drawing.Size(624, 44)
        Me.lboxFehlerAktuell.TabIndex = 6
        '
        'btnESC
        '
        Me.btnESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnESC.Location = New System.Drawing.Point(560, 4)
        Me.btnESC.Name = "btnESC"
        Me.btnESC.Size = New System.Drawing.Size(72, 40)
        Me.btnESC.TabIndex = 7
        Me.btnESC.Text = "ESC"
        '
        'FStoerungverwaltung
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(635, 362)
        Me.Controls.Add(Me.btnESC)
        Me.Controls.Add(Me.lboxFehlerAktuell)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lboxFehlerGesamt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblstorungengesamt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(2, 114)
        Me.Name = "FStoerungverwaltung"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Störungverwaltung"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public strpath As String = ""
    Public dateipfad As String = "/Stoerungsverwaltung.txt"

    Private Sub FStoerungverwaltung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AppMgr.frm1.Enabled() = False

        strpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString
        If (strpath.Substring(0, 6) = "file:\") Then  'hier nur überprüfung zum compilieren auf laptop.
            strpath = strpath.Substring(6)
        End If
        If File.Exists(strpath & dateipfad) Then
            Dim sR As New StreamReader(strpath & dateipfad)
            Dim sRR As New StreamReader(strpath & dateipfad)
            Dim line As String, temp As String = ""
            Dim textlaenge As Integer = 0
            Dim i As Integer = 0

            Do Until sRR.Peek = -1   'laenge ermitteln für die anzeige.
                line = sRR.ReadLine()
                textlaenge = textlaenge + 1
            Loop
            sRR.Close()

            Do Until sR.Peek = -1
                i = i + 1
                line = sR.ReadLine()
                If (i > (textlaenge - 50)) Then
                    lboxFehlerGesamt.Items.Insert(0, line)  'füge an erster stelle ein damit aktuellster fehler oben ist.
                End If
            Loop
            sR.Close()
            If (line <> "") Then
                lboxFehlerAktuell.Items.Add(line)
            Else
                lboxFehlerAktuell.Items.Add("Störungsverwaltung ist leer!")
            End If
        Else
            Dim sw As StreamWriter
            sw = New StreamWriter(strpath & dateipfad, False)  'mit false wird neue datei erstellt...
            sw.Close()
            lboxFehlerAktuell.Items.Add("Störungsverwaltung ist leer!")
            lboxFehlerGesamt.Items.Add("Störungsverwaltung ist leer!")
        End If
    End Sub


    Private Sub btnESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnESC.Click
        AppMgr.frm1.Enabled() = True
        Me.Close()
    End Sub
End Class
