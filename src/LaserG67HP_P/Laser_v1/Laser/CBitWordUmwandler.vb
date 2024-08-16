Public Class CBitWordUmwandler
    Private _wordwert As Short
    Public boolarr(15) As Boolean  'boolean array das aus dem twincat word gebildet wird.

    Public Sub New(ByVal plcWord As Short) 'konstruktor um ein twincat word in ein booleanArray zu teilen!
        _wordwert = plcWord
        SchreibeWordInArray()
    End Sub

    Private Function SchreibeWordInArray()
        For i As Integer = 0 To 15
            boolarr(i) = BitIsSet(_wordwert, i + 1)
        Next
    End Function

    Private Function BitIsSet(ByVal Value As Short, ByVal Bit As Integer) As Boolean
        If (Bit <= 0) Then
            MessageBox.Show("fehlerhafter zugriff auf bit")
            Return False
        End If
        Dim nPwr As Integer = CInt(IIf(Bit = 16, -2, 2))       'Bestimmung des Koeffizienten 2 oder -2 für die Potenz
        Return ((CShort(Math.Pow(nPwr, Bit - 1)) And Value) > 0)
    End Function

End Class

