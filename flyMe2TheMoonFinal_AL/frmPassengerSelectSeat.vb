Public Class frmPassengerSelectSeat

    Dim frmBookFlight As New frmAdd_Passenger_To_Flight()

    Public strSelectedSeat As String
    Dim intFlightID As Integer


    ' Constructor to accept the parent form instance
    Public Sub New(parentForm As frmAdd_Passenger_To_Flight)
        InitializeComponent()
        intFlightID = parentForm.intGlobalFlightID
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Hide()
        frmBookFlight.ShowDialog()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        If frmAdd_Passenger_To_Flight.isSeatAvailable(txtSeat.Text, intFlightID) Then
            strSelectedSeat = txtSeat.Text
            Me.Hide()

        Else
            MessageBox.Show(txtSeat.Text & " Seat is already Taken!" & vbNewLine & "Try another one!")
            txtSeat.Text = ""
            txtSeat.Focus()
        End If
    End Sub
End Class