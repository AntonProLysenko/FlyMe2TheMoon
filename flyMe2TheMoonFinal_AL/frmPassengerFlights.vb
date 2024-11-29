Public Class frmPassengerFlights
    Private Sub frmPassengerFutureFlights_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'This form is used For Showing Future And Past Flights of the passenger
        'It recieves a strFlightsFormState as a global variable
        'strFlightsFormState is stated on button click in passenger menu

        Dim strSelect As String = ""
        Dim dtRecievedData As DataTable = New DataTable


        Dim intCounter As Integer
        Dim intTotalMiles As Integer

        Dim strDateSelect As String
        Dim strTitleState As String

        Dim strProdcedureName As String

        If strFlightsFormState = "Future" Then

            lblMilesTotal.Text = "Upcoming Flights Total Miles:"
            Me.Text = strCurrentUserName & " Upcoming Flights"
            strTitleState = "Upcoming Flights"
            strDateSelect = "GETDATE() <= TF.dtmFlightDate"
            strProdcedureName = "uspUsersFutureFlight"
        ElseIf strFlightsFormState = "Past" Then
            lblMilesTotal.Text = "Past Flights Total Miles:"
            Me.Text = strCurrentUserName & " Past Flights"
            strTitleState = "Past Flights"
            strDateSelect = "GETDATE() > TF.dtmFlightDate"
            strProdcedureName = "uspUsersPastFlight"
        End If


        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                Me.Text + " Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If



            'Selecting Future Flights
            'strSelect = "SELECT TF.intFlightID,TFP.strSeat, TF.intMilesFlown,
            '                    FromAirport.strAirportCity + '(' + FromAirport.strAirportCode + ')' AS strDepartureLocation,
            '                    ToAirport.strAirportCity + '(' + ToAirport.strAirportCode + ')' AS strArrivalLocation,
            '                    CONVERT(VARCHAR, TF.dtmFlightDate, 101) AS dtmFlightDate, 
            '                    CONVERT(VARCHAR, TF.dtmTimeofDeparture, 100) AS dtmTimeofDeparture,
            '                    CONVERT(VARCHAR, TF.dtmTimeOfLanding, 100) AS dtmTimeOfLanding
            '                FROM TFlights AS  TF
            '                JOIN TAirports AS FromAirport 
            '                 ON TF.intFromAirportID = FromAirport.intAirportID
            '                JOIN TAirports AS ToAirport 
            '                 ON TF.intToAirportID = ToAirport.intAirportID
            '                JOIN TFlightPassengers as TFP
            '                 ON tfp.intFlightID = TF.intFlightID
            '                WHERE " & strDateSelect & " AND TFP.intPassengerID = " & intCurrentPassengerID &
            '                "ORDER BY TF.dtmFlightDate"

            'MessageBox.Show(strSelect)

            'dtRecievedData = GetDataTable(strSelect)

            dtRecievedData = ExecuteSelectProdcedure(strProdcedureName, "@user_id", intCurrentPassengerID)

            intCounter = 1

            lstUpcomingFlights.Items.Add("=================================================" & strTitleState & "=================================================")
            lstUpcomingFlights.Items.Add("  ")
            lstUpcomingFlights.Items.Add("#" & vbTab & "Departure Date" & vbTab & "Departure Time" & vbTab & "From" & vbTab & vbTab & "To" & vbTab & vbTab & "Seat" & vbTab & vbTab & "Arival Time" & vbTab & "Distance")
            lstUpcomingFlights.Items.Add("===================================================================================================================")


            'Looping Thorough Data Table
            For Each row As DataRow In dtRecievedData.Rows
                lstUpcomingFlights.Items.Add("  ")
                lstUpcomingFlights.Items.Add(intCounter & vbTab & row.Item("dtmFlightDate") & vbTab & row.Item("dtmTimeofDeparture") & vbTab & vbTab & row.Item("strDepartureLocation") & vbTab &
                                             row.Item("strArrivalLocation") & vbTab & row.Item("strSeat") & vbTab & vbTab & row.Item("dtmTimeOfLanding") & vbTab & vbTab & row.Item("intMilesFlown") & " mi")

                lstUpcomingFlights.Items.Add("===================================================================================================================")
                intTotalMiles += row.Item("intMilesFlown")
                intCounter += 1

            Next row

            'Aproach for looping through DataReader

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
        Dim frmPassengerMenu As New frmPassengerMenu
        Me.Hide()
        frmPassengerMenu.ShowDialog()
    End Sub
End Class