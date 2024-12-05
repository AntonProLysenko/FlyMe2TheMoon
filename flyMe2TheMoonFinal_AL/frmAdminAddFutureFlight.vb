Public Class frmAdminAddFutureFlight

    Private Sub frmAdminAddFutureFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFlightDate.MinDate = DateTime.Now.Date
        dtpDepartureTime.Format = DateTimePickerFormat.Custom
        dtpDepartureTime.CustomFormat = "HH:mm"
        dtpLandingTme.Format = DateTimePickerFormat.Custom
        dtpLandingTme.CustomFormat = "HH:mm"

        Dim dtAirports As DataTable = New DataTable
        Dim dtFromAirports As DataTable = New DataTable
        Dim dtPlanes As DataTable = New DataTable


        Try
            CheckOpenDBConnection(Me)
            dtAirports = ExecuteSelectProdcedure("uspFindAllAirports")
            dtFromAirports = dtAirports.Copy()
            'Loadingg States results to a combobox
            cmbFromAirport.ValueMember = "intAirportID"
            cmbFromAirport.DisplayMember = "airportName"
            cmbFromAirport.DataSource = dtFromAirports

            'If cmbFromAirport.Items.Count > 0 Then
            '    cmbFromAirport.SelectedIndex = 0
            'End If

            cmbToAirport.ValueMember = "intAirportID"
            cmbToAirport.DisplayMember = "airportName"
            cmbToAirport.DataSource = dtAirports

            'If cmbFromAirport.Items.Count > 0 AndAlso cmbToAirport.Items.Count > 0 Then
            '    cmbToAirport.SelectedIndex = 1
            'End If


            dtPlanes = ExecuteSelectProdcedure("uspFindAllPlanes")
            cmbPlanes.ValueMember = "intPlaneID"
            cmbPlanes.DisplayMember = "planeName"
            cmbPlanes.DataSource = dtPlanes
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub dtpFlightDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFlightDate.ValueChanged
    '    dtpDepartureTime.MinDate = dtpFlightDate.Value.Date
    '    dtpDepartureTime.MaxDate = dtpFlightDate.Value.Date
    '    dtpLandingTme.MinDate = dtpDepartureTime.Value.Date
    '    dtpLandingTme.MaxDate = dtpDepartureTime.Value.Date.AddHours(24)
    'End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim intFlightID As Integer = 1
        Dim dtmFlightDate As DateTime
        Dim strFlightNumber As String
        Dim dtmTimeofDeparture As String
        Dim dtmTimeOfLanding As String
        Dim intFromAirportID As Integer
        Dim intToAirportID As Integer
        Dim intMilesFlown As Integer
        Dim intPlaneID As Integer

        Dim blnValid
        Dim strExecuteInsert As String

        ValidateFutureDate(blnValid, dtmFlightDate, dtpFlightDate, "Flight")

        If blnValid Then

            If dtpDepartureTime.Value.Date = dtpLandingTme.Value.Date AndAlso dtpDepartureTime.Value.Hour < dtpLandingTme.Value.Hour Then
                blnValid = True
                dtmTimeofDeparture = dtpDepartureTime.Value.Hour & ":" & dtpDepartureTime.Value.Minute
                dtmTimeOfLanding = dtpLandingTme.Value.Hour & ":" & dtpLandingTme.Value.Minute
            ElseIf dtpDepartureTime.Value.Date < dtpLandingTme.Value.Date Then
                blnValid = True
                dtmTimeofDeparture = dtpDepartureTime.Value.Hour & ":" & dtpDepartureTime.Value.Minute
                dtmTimeOfLanding = dtpLandingTme.Value.Hour & ":" & dtpLandingTme.Value.Minute
            Else
                blnValid = False
                MessageBox.Show("Invalid Departure or Landing Time! Try Again")
            End If
        End If

        If blnValid Then
            intFromAirportID = cmbFromAirport.SelectedValue
            intToAirportID = cmbToAirport.SelectedValue
            intPlaneID = cmbPlanes.SelectedValue
            strFlightNumber = txtFlightNumber.Text
            intMilesFlown = txtMiles.Text

        End If


        If blnValid Then
            strExecuteInsert = "Execute uspAddNewFlight '" & intFlightID & "', ' " & dtmFlightDate.Date & "', ' " & strFlightNumber & "', ' " & dtmTimeofDeparture & "', ' " & dtmTimeOfLanding & "', ' " & intFromAirportID & "', ' " & intToAirportID & "', ' " & intMilesFlown & "', ' " & intPlaneID & "'"
            MessageBox.Show(strExecuteInsert)
            CheckOpenDBConnection(Me)
            ExecuteUltimateTransaction(strExecuteInsert, "Flight", "", "Insert")
        End If
    End Sub
End Class