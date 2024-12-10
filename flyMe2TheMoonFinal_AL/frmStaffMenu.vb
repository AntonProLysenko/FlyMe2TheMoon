Public Class frmStaffMenu
    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        Dim frmStaffFlight As New frmStaffFlight
        strFlightsFormState = "Future"
        Me.Hide()
        frmStaffFlight.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        Dim frmStaffFlight As New frmStaffFlight
        strFlightsFormState = "Past"
        Me.Hide()
        frmStaffFlight.ShowDialog()
        Me.Close()
    End Sub

    Private Sub frmAttendantMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblStaffWelcome.Text = "Welcome " & strCurrentUserName & "!"
        'Placing Welcome message at the middle 
        lblStaffWelcome.Left = Me.Width / 2 - lblStaffWelcome.Size.Width / 2

        If strStaffRole = "Attendant" Then
            'Assigning Welcome mesage a value of current user and placing it exactly at the middle of the form
            Me.Text = "Attendant " & strCurrentUserName
        ElseIf strStaffRole = "Pilot" Then
            Me.Text = "Pilot " & strCurrentUserName
        End If

    End Sub

    Private Sub btnUpdatePassenger_Click(sender As Object, e As EventArgs) Handles btnUpdatePassenger.Click
        Dim frmEditForm As New frmStaffEdit
        Me.Hide()
        frmEditForm.ShowDialog()
        Me.Close()
    End Sub
End Class