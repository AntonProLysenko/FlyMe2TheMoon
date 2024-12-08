Public Class frmAdminAddFutureFlight
    Private Sub frmAdminAddFutureFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFlightDate.MinDate = DateTime.Now.Date
        dtpFlightDate.MaxDate = DateTime.Now.Date.AddYears(1)
        dtpDepartureTime.Format = DateTimePickerFormat.Custom
        dtpDepartureTime.CustomFormat = "HH:mm"
        dtpLandingTme.Format = DateTimePickerFormat.Custom
        dtpLandingTme.CustomFormat = "HH:mm"

        dtpDepartureTime.MaxDate = DateTime.Now.Date.AddYears(1)
        dtpLandingTme.MaxDate = DateTime.Now.Date.AddYears(2)

        Dim dtAirports As DataTable = New DataTable
        Dim dtFromAirports As DataTable = New DataTable
        Dim dtPlanes As DataTable = New DataTable
        Dim dtFlights As DataTable = New DataTable


        Try
            CheckOpenDBConnection(Me)
            dtAirports = ExecuteSelectProdcedure("uspFindAllAirports")
            dtFromAirports = dtAirports.Copy()
            'Loadingg States results to a combobox
            cmbFromAirport.ValueMember = "intAirportID"
            cmbFromAirport.DisplayMember = "airportName"
            cmbFromAirport.DataSource = dtFromAirports


            cmbToAirport.ValueMember = "intAirportID"
            cmbToAirport.DisplayMember = "airportName"
            cmbToAirport.DataSource = dtAirports


            dtPlanes = ExecuteSelectProdcedure("uspFindAllPlanes")
            cmbPlanes.ValueMember = "intPlaneID"
            cmbPlanes.DisplayMember = "planeName"
            cmbPlanes.DataSource = dtPlanes


            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



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

        Dim blnValid As Boolean
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
            If txtFlightNumber.Text.Length = 3 Then

                If IsNumeric(txtFlightNumber.Text) Then
                    strFlightNumber = txtFlightNumber.Text
                    blnValid = True
                Else
                    MessageBox.Show("Flight Number has to be 3 digits long")
                    blnValid = False
                    txtFlightNumber.Focus()
                End If
            Else
                MessageBox.Show("Flight Number has to be 3 digits long")
                blnValid = False
                txtFlightNumber.Focus()
            End If
        End If



        If blnValid Then
            If Not isFlightExist(txtFlightNumber.Text) Then
                strFlightNumber = txtFlightNumber.Text.Trim()
                blnValid = True
            Else
                blnValid = False
                txtFlightNumber.Focus()
                MessageBox.Show("This Flight Already Exist!, Use Different Flight Number!")
            End If
        End If



        If blnValid Then
            If txtMiles.Text.Length >= 3 And txtMiles.Text.Length <= 5 Then

                If Integer.TryParse(txtMiles.Text, intMilesFlown) Then
                    blnValid = True
                Else
                    MessageBox.Show("Miles input has to be digits only")
                    blnValid = False
                    txtMiles.Focus()

                End If
            Else
                MessageBox.Show("Invalid Miles input")
                blnValid = False
                txtMiles.Focus()
            End If
        End If



        If blnValid Then
            If cmbFromAirport.SelectedValue = cmbToAirport.SelectedValue Then
                blnValid = False
                MessageBox.Show("Arival And Departure Airports have to be different!")
            Else
                intFromAirportID = cmbFromAirport.SelectedValue
                intToAirportID = cmbToAirport.SelectedValue
                blnValid = True
            End If
            intPlaneID = cmbPlanes.SelectedValue
        End If



        If blnValid Then
            strExecuteInsert = "Execute uspAddNewFlight '" & intFlightID & "', ' " & dtmFlightDate.Date & "', '" & strFlightNumber & "', '" & dtmTimeofDeparture & "', '" & dtmTimeOfLanding & "', '" & intFromAirportID & "', '" & intToAirportID & "', ' " & intMilesFlown & "', '" & intPlaneID & "'"
            'MessageBox.Show(strExecuteInsert)
            CheckOpenDBConnection(Me)

            If ExecuteUltimateTransaction(strExecuteInsert, "Flight", "", "Insert") Then
                Dim frmAdminMenu As New frmAdminMenu
                Me.Hide()
                frmAdminMenu.ShowDialog()
            End If
        End If
    End Sub


    Private Function isFlightExist(strFlightNumber As String) As Boolean

        Dim dtFlights As DataTable = New DataTable

        Dim arrOfFlightNums() As String
        Dim blnExists As Boolean = False

        Try
            CheckOpenDBConnection(Me)
            dtFlights = ExecuteSelectProdcedure("uspFindAllFlights")

            If dtFlights.Rows.Count > 0 Then

                ReDim arrOfFlightNums(dtFlights.Rows.Count - 1)
                For intIndex = 0 To dtFlights.Rows.Count - 1
                    arrOfFlightNums(intIndex) = dtFlights.Rows(intIndex)("strFlightNumber")
                Next

                If arrOfFlightNums.Contains(strFlightNumber) Then
                    blnExists = True
                End If

            End If

            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return blnExists
    End Function


    Private Sub dtpFlightDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFlightDate.ValueChanged
        Dim newMinDate As Date = dtpFlightDate.Value.Date
        Dim newMaxDate As Date = dtpFlightDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

        ' Ensure MinDate is less than MaxDate before setting
        If newMinDate <= dtpDepartureTime.MaxDate Then
            dtpDepartureTime.MinDate = newMinDate
            dtpDepartureTime.MaxDate = newMaxDate
            dtpDepartureTime.Value = dtpDepartureTime.MinDate
        Else
            dtpDepartureTime.MaxDate = newMaxDate
            dtpDepartureTime.MinDate = newMinDate
            dtpDepartureTime.Value = dtpDepartureTime.MinDate
        End If

    End Sub

    Private Sub dtpDepartureTime_ValueChanged(sender As Object, e As EventArgs) Handles dtpDepartureTime.ValueChanged
        'MessageBox.Show(dtpDepartureTime.MaxDate)

        Dim newMinDate As Date = dtpDepartureTime.Value.Date
        Dim newMaxDate As Date = dtpDepartureTime.MaxDate.AddDays(1)

        If newMaxDate >= dtpLandingTme.MinDate Then
            dtpLandingTme.MaxDate = newMaxDate
            dtpLandingTme.MinDate = newMinDate
            dtpLandingTme.Value = dtpLandingTme.MinDate
        Else
            dtpLandingTme.MinDate = dtpDepartureTime.Value.Date
            dtpLandingTme.MaxDate = dtpDepartureTime.MaxDate.AddDays(1)
            dtpLandingTme.Value = dtpLandingTme.MinDate
        End If

    End Sub

    Dim blnUpdated As Boolean = False
    Private Sub dtpLandingTme_ValueChanged(sender As Object, e As EventArgs) Handles dtpLandingTme.ValueChanged

        If blnUpdated Then Exit Sub

        If dtpLandingTme.Value.Date = dtpDepartureTime.Value.Date Then
            If dtpLandingTme.Value.Hour < dtpDepartureTime.Value.Hour Then
                blnUpdated = True
                dtpLandingTme.Value = dtpLandingTme.Value.AddHours(24)
                'Exit Sub
            End If
        Else
            If dtpLandingTme.Value.Hour > dtpDepartureTime.Value.Hour Then
                blnUpdated = True
                dtpLandingTme.Value = dtpLandingTme.Value.AddDays(-1)
                'Exit Sub
            End If
        End If
        blnUpdated = False
    End Sub








    Private Sub cmbFromAirport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFromAirport.SelectedIndexChanged
        If cmbFromAirport.SelectedIndex = cmbToAirport.SelectedIndex Then
            If cmbToAirport.SelectedIndex + 1 >= cmbToAirport.Items.Count - 1 Then
                cmbToAirport.SelectedIndex = 0
            Else
                cmbToAirport.SelectedIndex = cmbToAirport.SelectedIndex + 1
            End If
        End If
    End Sub

    Private Sub cmbToAirport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbToAirport.SelectedIndexChanged
        If cmbFromAirport.SelectedIndex = cmbToAirport.SelectedIndex Then

            If cmbToAirport.SelectedIndex + 1 >= cmbToAirport.Items.Count - 1 Then

                cmbToAirport.SelectedIndex = 0
            Else
                cmbToAirport.SelectedIndex = cmbToAirport.SelectedIndex + 1
            End If
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Dim frmAdminMenu As New frmAdminMenu
        Me.Hide()
        frmAdminMenu.ShowDialog()
    End Sub
End Class