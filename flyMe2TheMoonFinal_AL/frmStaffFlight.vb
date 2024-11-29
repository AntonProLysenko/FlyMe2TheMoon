Public Class frmStaffFlight
    Private Sub frmStaffFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'This form is used For Showing Future And Past Flights of the passenger
        'It recieves a strFlightsFormState as a global variable
        'strFlightsFormState is stated on button click in passenger menu

        Dim strSelect As String = ""
        Dim dtRecievedData As DataTable = New DataTable


        Dim intCounter As Integer
        Dim intTotalMiles As Integer

        Dim strDateSelect As String
        Dim strTitleState As String

        Dim strRoleWithTab As String


        If strFlightsFormState = "Future" Then

            lblMilesTotal.Text = "Upcoming Flights Total Miles:"
            Me.Text = strCurrentUserName & " Upcoming Flights"
            strDateSelect = "GETDATE() <= TF.dtmFlightDate"
            strTitleState = "Upcoming Flights"

        ElseIf strFlightsFormState = "Past" Then
            lblMilesTotal.Text = "Past Flights Total Miles:"
            Me.Text = strCurrentUserName & " Past Flights"
            strDateSelect = "GETDATE() > TF.dtmFlightDate"
            strTitleState = "Past Flights"
        End If




        If strStaffRole = "Pilot" Then
            strSelect = "SELECT TF.intFlightID, strPilotRole as strRole, TF.intMilesFlown,
                                FromAirport.strAirportCity + '(' + FromAirport.strAirportCode + ')' AS strDepartureLocation,
                                ToAirport.strAirportCity + '(' + ToAirport.strAirportCode + ')' AS strArrivalLocation,
                                CONVERT(VARCHAR, TF.dtmFlightDate, 101) AS dtmFlightDate, 
                                CONVERT(VARCHAR, TF.dtmTimeofDeparture, 100) AS dtmTimeofDeparture,
                                CONVERT(VARCHAR, TF.dtmTimeOfLanding, 100) AS dtmTimeOfLanding
                            FROM TFlights AS  TF
                            JOIN TAirports AS FromAirport 
	                            ON TF.intFromAirportID = FromAirport.intAirportID
                            JOIN TAirports AS ToAirport 
	                            ON TF.intToAirportID = ToAirport.intAirportID
                            JOIN TPilotFlights
	                            ON TPilotFlights.intFlightID = TF.intFlightID
                            JOIN TPilots
	                            ON TPilots.intPilotID = TPilotFlights.intPilotID
                            JOIN TPilotRoles
	                            ON TPilots.intPilotRoleID = TPilotRoles.intPilotRoleID
                            WHERE " & strDateSelect & " AND TPilotFlights.intPilotID = " & intCurrentStaffMemberID &
                           "ORDER BY TF.dtmFlightDate"

        ElseIf strStaffRole = "Attendant" Then
            strSelect = "SELECT TF.intFlightID, strRole = 'Flight Attendant', TF.intMilesFlown,
                                FromAirport.strAirportCity + '(' + FromAirport.strAirportCode + ')' AS strDepartureLocation,
                                ToAirport.strAirportCity + '(' + ToAirport.strAirportCode + ')' AS strArrivalLocation,
                                CONVERT(VARCHAR, TF.dtmFlightDate, 101) AS dtmFlightDate, 
                                CONVERT(VARCHAR, TF.dtmTimeofDeparture, 100) AS dtmTimeofDeparture,
                                CONVERT(VARCHAR, TF.dtmTimeOfLanding, 100) AS dtmTimeOfLanding
                        FROM TFlights AS  TF
                        JOIN TAirports AS FromAirport 
	                        ON TF.intFromAirportID = FromAirport.intAirportID
                        JOIN TAirports AS ToAirport 
	                        ON TF.intToAirportID = ToAirport.intAirportID
                        JOIN TAttendantFlights
	                        ON TAttendantFlights.intFlightID = TF.intFlightID
                        WHERE " & strDateSelect & " AND TAttendantFlights.intAttendantID = " & intCurrentStaffMemberID &
                        "ORDER BY TF.dtmFlightDate"
        End If


        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                Me.Text + " Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If



            'MessageBox.Show(strSelect)

            dtRecievedData = GetDataTable(strSelect)

            intCounter = 1

            lstUpcomingFlights.Items.Add("=================================================" & strTitleState & "=================================================")
            lstUpcomingFlights.Items.Add("  ")
            lstUpcomingFlights.Items.Add("#" & vbTab & "Departure Date" & vbTab & "Departure Time" & vbTab & "From" & vbTab & vbTab & "To" & vbTab & vbTab & "Role" & vbTab & vbTab & "Arival Time" & vbTab & "Distance")
            lstUpcomingFlights.Items.Add("===================================================================================================================")


            'Looping Thorough Data Table
            For Each row As DataRow In dtRecievedData.Rows
                'Removing Tab from Attendant Role to save space
                If strStaffRole = "Attendant" Then
                    strRoleWithTab = row.Item("strRole")
                Else
                    strRoleWithTab = row.Item("strRole") & vbTab
                End If

                lstUpcomingFlights.Items.Add("  ")
                lstUpcomingFlights.Items.Add(intCounter & vbTab & row.Item("dtmFlightDate") & vbTab & row.Item("dtmTimeofDeparture") & vbTab & vbTab & row.Item("strDepartureLocation") & vbTab &
                                             row.Item("strArrivalLocation") & vbTab & strRoleWithTab & vbTab & row.Item("dtmTimeOfLanding") & vbTab & vbTab & row.Item("intMilesFlown") & " mi")

                lstUpcomingFlights.Items.Add("===================================================================================================================")
                intTotalMiles += row.Item("intMilesFlown")
                intCounter += 1

            Next row

            'Aproach for looping through DataReader
            'I'm not using it Since I use a common function for getting datatable

            'While drSourceTable.Read()

            '    lstUpcomingFlights.Items.Add("  ")
            '    lstUpcomingFlights.Items.Add(intCounter & vbTab & drSourceTable("dtmFlightDate") & vbTab & drSourceTable("dtmTimeofDeparture") & vbTab & vbTab & drSourceTable("strDepartureLocation") & vbTab &
            '                                 drSourceTable("strArrivalLocation") & vbTab & drSourceTable("strSeat") & vbTab & vbTab & drSourceTable("dtmTimeOfLanding") & vbTab & vbTab & drSourceTable("intMilesFlown") & " mi")

            '    lstUpcomingFlights.Items.Add("===================================================================================================================")
            '    intTotalMiles += drSourceTable("intMilesFlown")
            '    intCounter += 1
            'End While


            'Showing Total Miles
            lblTotalMIles.Text = intTotalMiles & " mi"

            ' Clean up
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Dim frmStaffMenu As New frmStaffMenu
        Me.Hide()
        frmStaffMenu.ShowDialog()
    End Sub


End Class