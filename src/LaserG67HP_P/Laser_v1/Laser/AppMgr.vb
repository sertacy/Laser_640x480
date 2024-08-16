Public Class AppMgr

    Public Shared frm1 As FMain

    <STAThread()> Shared Sub Main()

        ' Declare a variable named frm1 of type Form1.



        ' Instantiate (create) a new Form1 object and assign

        ' it to variable frm1.

        frm1 = New FMain

        ' Call the Application class' Run method

        ' passing it the Form1 object created above.

        Application.Run(frm1)

    End Sub

End Class

