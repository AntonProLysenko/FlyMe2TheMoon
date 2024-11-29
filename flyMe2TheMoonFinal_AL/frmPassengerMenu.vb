Public Class frmPassengerMenu
    Private Sub frmPassengerMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Assigning Welcome mesage a value of current user and placing it exactly at the middle of the form
        lblPassengerWelcome.Text = "Welcome " & strCurrentUserName & "!"
        Me.Text = "Passenger " & strCurrentUserName
        'Placing Welcome message at the middle 
        lblPassengerWelcome.Left = Me.Width / 2 - lblPassengerWelcome.Size.Width / 2

    End Sub

    Private Sub btnUpdatePassenger_Click(sender As Object, e As EventArgs) Handles btnUpdatePassenger.Click
        Dim frmEditPassenger As New frmPassengerEdit
        Me.Hide()
        frmEditPassenger.ShowDialog()
    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        Dim frmAddFlight As New frmAdd_Passenger_To_Flight
        Me.Hide()
        frmAddFlight.ShowDialog()
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        strFlightsFormState = "Future"
        Dim frmUpcomingFlights As New frmPassengerFlights
        Me.Hide()
        frmUpcomingFlights.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        strFlightsFormState = "Past"
        Dim frmUpcomingFlights As New frmPassengerFlights
        Me.Hide()
        frmUpcomingFlights.ShowDialog()
    End Sub
End Class