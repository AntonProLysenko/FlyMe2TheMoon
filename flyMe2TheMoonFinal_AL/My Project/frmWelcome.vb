Public Class frmWelcome1
    Private Sub frmWelcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim frmMain As New frmMain
        ProgressBar1.Increment(5)
        If ProgressBar1.Value = 55 Then
            CheckOpenDBConnection(Me)
        End If
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            Timer1.Stop()
            Me.Hide()
            frmMain.ShowDialog()
            Me.Close()
            CloseDatabaseConnection()
            Exit Sub
        End If
    End Sub
End Class