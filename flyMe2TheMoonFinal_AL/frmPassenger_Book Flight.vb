Public Class frmAdd_Passenger_To_Flight
    Dim dblDataLoaded As Boolean = False
    Dim dblTotalPrice As Double

    Public intGlobalFlightID As Integer

    Private Sub frmAdd_Passenger_To_Flight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim dtFlights As DataTable = New DataTable



        'Populating Flights on Load
        Try
            CheckOpenDBConnection(Me)
            'Selecting Future Flights
            strSelect = "SELECT TF.intFlightID, TF.dtmFlightDate,
		                        FromAirport.strAirportCity + '(' + FromAirport.strAirportCode +')'+ ' - ' + ToAirport.strAirportCity+'('+ToAirport.strAirportCode +'): '  + 
		                        CONVERT(VARCHAR, TF.dtmFlightDate, 101) + ' at '+ CONVERT(VARCHAR, TF.dtmTimeofDeparture, 108) as strFlightName
                        FROM TFlights as  TF
                        JOIN TAirports as FromAirport 
	                        ON TF.intFromAirportID = FromAirport.intAirportID
                        JOIN TAirports as ToAirport 
	                        ON TF.intToAirportID = ToAirport.intAirportID
                        WHERE GETDATE() <= TF.dtmFlightDate
                        ORDER BY TF.dtmFlightDate"

            dtFlights = GetDataTable(strSelect)


            cmbFlights.ValueMember = "intFlightID"
            cmbFlights.DisplayMember = "strFlightName"
            cmbFlights.DataSource = dtFlights



            ' Selecting firs Flight by default
            If cmbFlights.Items.Count > 0 Then
                cmbFlights.SelectedIndex = 0
            End If
            dblDataLoaded = True
            intGlobalFlightID = cmbFlights.SelectedValue
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click



        Dim result
        Dim frmPassengerMenu As New frmPassengerMenu
        Dim frmPassengerSelectSeat As New frmPassengerSelectSeat(Me)
        Dim intNextPrimaryKey As Integer
        Dim intFlightID As Integer
        Dim strSeatNumber As String



        intFlightID = cmbFlights.SelectedValue


        If rdbReserved.Checked Then
            intGlobalFlightID = cmbFlights.SelectedValue
            frmPassengerSelectSeat.ShowDialog()
            strSeatNumber = frmPassengerSelectSeat.strSelectedSeat
            If strSeatNumber = "" Then
            Else

                result = MessageBox.Show("Are You Sure you Want To Book This Fligh " & cmbFlights.Text & " for " & dblTotalPrice.ToString("$00.00 ") & "Seat: " & strSeatNumber & " ?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                Select Case result
                    Case DialogResult.Cancel
                        MessageBox.Show("Booking Canceled")
                        CloseDatabaseConnection()

                    Case DialogResult.No
                        MessageBox.Show("Booking Canceled")
                        CloseDatabaseConnection()
                        Me.Hide()
                        frmPassengerMenu.ShowDialog()
                        Me.Close()
                    Case DialogResult.Yes

                        intNextPrimaryKey = DetectNextPK()
                        AddPassengerToFlight(intNextPrimaryKey, intFlightID, strSeatNumber)
                        CloseDatabaseConnection()

                End Select
            End If
        Else

            result = MessageBox.Show("Are You Sure you Want To Book This Fligh " & cmbFlights.Text & " for " & dblTotalPrice.ToString("$00.00 ") & "?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Booking Canceled")
                    CloseDatabaseConnection()

                Case DialogResult.No
                    MessageBox.Show("Booking Canceled")
                    CloseDatabaseConnection()
                    Me.Hide()
                    frmPassengerMenu.ShowDialog()
                    Me.Close()
                Case DialogResult.Yes




                    'Opens DB Connection and detects next PK
                    'CheckOpenDBConnection(Me)
                    intNextPrimaryKey = DetectNextPK()
                    strSeatNumber = GenerateSeatNumber()
                    AddPassengerToFlight(intNextPrimaryKey, intFlightID, strSeatNumber)
                    CloseDatabaseConnection()

            End Select
        End If
    End Sub

    Public Function AddPassengerToFlight(intNextPrimaryKey As Integer, intFlightID As Integer, strSeatNumber As String)

        Dim frmPassengerMenu As New frmPassengerMenu

        Dim strInsert As String
        Dim strSelect As String
        Dim cmdInsert As New OleDb.OleDbCommand
        Dim intRowsAffected As Integer
        strSelect = "SELECT intFlightID FROM TFlightPassengers WHERE intPassengerID =" & intCurrentPassengerID
        If isOnFlight(strSelect, cmbFlights.SelectedValue) Then
            MessageBox.Show("You are already on this flight!")
            CloseDatabaseConnection()
        Else
            Try
                CheckOpenDBConnection(Me)
                strInsert = "INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat, dblTicketPrice)" &
                            "VALUES( " & intNextPrimaryKey & ", " & intFlightID & ", " & intCurrentPassengerID & ", '" & strSeatNumber & "', " & dblTotalPrice & ")"

                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                intRowsAffected = cmdInsert.ExecuteNonQuery()

                If intRowsAffected > 0 Then
                    If strSeatNumber.Contains("A") OrElse strSeatNumber.Contains("F") Then
                        MessageBox.Show("We got you seated by the window")
                    ElseIf strSeatNumber.Contains("C") OrElse strSeatNumber.Contains("D") Then
                        MessageBox.Show("We got you seated by the asile")
                    Else
                        MessageBox.Show("We got you seated between two people")
                    End If
                End If

                CloseDatabaseConnection()
                Me.Hide()
                frmPassengerMenu.ShowDialog()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                CloseDatabaseConnection()
            End Try
        End If
    End Function


    Private Function DetectNextPK() As Integer
        Dim strSelectNextPK As String
        Dim cmdSelectNextPk As New OleDb.OleDbCommand
        Dim drNextPk As OleDb.OleDbDataReader
        Dim intNextPrimaryKey As Integer

        strSelectNextPK = "SELECT max(intFlightPassengerID)+1 AS intNextPrimaryKey FROM TFlightPassengers"
        Try
            CheckOpenDBConnection(Me)
            cmdSelectNextPk = New OleDb.OleDbCommand(strSelectNextPK, m_conAdministrator)
            drNextPk = cmdSelectNextPk.ExecuteReader

            drNextPk.Read()

            If drNextPk.IsDBNull(0) = True Then
                intNextPrimaryKey = 1
            Else
                intNextPrimaryKey = CInt(drNextPk("intNextPrimaryKey"))
            End If
            CloseDatabaseConnection()
            Return intNextPrimaryKey
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            CloseDatabaseConnection()
        End Try
    End Function


    Private Function GenerateSeatNumber() As String
        Dim randomSeat As New Random()
        Dim randomSRow As New Random()

        Dim strSeats As String
        Dim charRandomLetter As Char
        Dim randomNumber As Integer

        'Robert Nields doesn't have a privilege to be seated by the window
        If strCurrentUserName = "Bob Nields" Then
            strSeats = "AF"
        Else
            strSeats = "ABCDEF"
        End If


        randomNumber = randomSeat.Next(1, 20)
        charRandomLetter = strSeats(randomSeat.Next(0, strSeats.Length))



        If isSeatAvailable(randomNumber & charRandomLetter, cmbFlights.SelectedValue) Then
            Return randomNumber & charRandomLetter
        Else
            Return GenerateSeatNumber()
        End If


    End Function

    Public Function isOnFlight(strSelect As String, intFlightID As Integer) As Boolean

        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtFlights As DataTable = New DataTable

        Dim arrOfFligths() As Integer
        Dim blnOnFlight As Boolean = False

        Try
            CheckOpenDBConnection(Me)
            'MessageBox.Show(strSelect)
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtFlights.Load(drSourceTable)

            If dtFlights.Rows.Count > 0 Then

                ReDim arrOfFligths(dtFlights.Rows.Count - 1)
                For intIndex = 0 To dtFlights.Rows.Count - 1
                    arrOfFligths(intIndex) = Convert.ToInt32(dtFlights.Rows(intIndex)("intFlightID"))
                Next

                If arrOfFligths.Contains(intFlightID) Then
                    blnOnFlight = True
                End If

            End If
            CloseDatabaseConnection()
            Return blnOnFlight

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            CloseDatabaseConnection()
        End Try
    End Function

    Public Function isSeatAvailable(strDesiredSeat As String, intFlightID As Integer)
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtSeats As DataTable = New DataTable

        Dim strSelect As String
        Dim arrOfTakenSeats() As String
        Dim blnAvailable As Boolean = True
        strDesiredSeat = strDesiredSeat.ToLower()

        strSelect = "SELECT strSeat FROM TFlightPassengers
                    WHERE intFlightID = " & intFlightID
        Try
            CheckOpenDBConnection(Me)
            'MessageBox.Show(strSelect)
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtSeats.Load(drSourceTable)

            If dtSeats.Rows.Count > 0 Then

                ReDim arrOfTakenSeats(dtSeats.Rows.Count - 1)
                For intIndex = 0 To dtSeats.Rows.Count - 1
                    arrOfTakenSeats(intIndex) = dtSeats.Rows(intIndex)("strSeat").ToString().ToLower()
                Next

                If arrOfTakenSeats.Contains(strDesiredSeat) Then
                    blnAvailable = False
                End If

            End If
            CloseDatabaseConnection()
            Return blnAvailable

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            CloseDatabaseConnection()
        End Try
    End Function


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim frmPassengerMenu As New frmPassengerMenu
        CloseDatabaseConnection()
        Me.Hide()
        frmPassengerMenu.ShowDialog()
        Me.Close()
    End Sub



    Private Function CalculateAndDisplayPrice()
        Dim dblBasePrice As Double = 250
        Dim dblFarFlightFee As Double = 50
        Dim dblHighDemandFee As Double = 100
        Dim dblLowDemandDiscount As Double = 50
        Dim dblReliablePlaneFee As Double = 35
        Dim dblUnrelaiblePlaneDiscount As Double = 25
        Dim dblMiamiFee As Double = 15
        Dim dblReservedSeatFee = 125
        Dim dblSeniorDiscount = 20 / 100
        Dim dblChildDiscount = 65 / 100
        Dim dblLowLoyaltyDiscount = 10 / 100
        Dim dblHighLoyaltyDiscount = 20 / 100
        Dim dblFinalCost As Double

        Dim strSelect As String

        Dim intFlightMiles As Integer
        Dim intPassengersOnFlight As Integer
        Dim strPlaneType As String
        Dim strAirportCode As String
        Dim dtmDOB As DateTime = DateTime.Now
        Dim intAge As Integer
        Dim intTotalFlights As Integer

        Dim dtmToday As DateTime = DateTime.Now

        Dim blnReservedSeat As Boolean = False

        dblFinalCost = dblBasePrice
        Console.WriteLine("-----------------------------------")
        Console.WriteLine("Initial: " & dblFinalCost)
        GetNeededDataForTicketCost(intFlightMiles, intPassengersOnFlight, strPlaneType, strAirportCode, dtmDOB, intTotalFlights)




        If rdbReserved.Checked Then
            blnReservedSeat = True
        End If

        If intFlightMiles > 750 Then
            dblFinalCost += dblFarFlightFee
        End If
        Console.WriteLine(intFlightMiles & " Miles: " & dblFinalCost)
        If intPassengersOnFlight > 8 Then
            dblFinalCost += dblHighDemandFee
        ElseIf intPassengersOnFlight < 4 Then
            dblFinalCost -= dblLowDemandDiscount
        End If
        Console.WriteLine(intPassengersOnFlight & " Demand: " & dblFinalCost)

        If strPlaneType = "Boeing 747-8" Then
            dblFinalCost -= dblUnrelaiblePlaneDiscount
        ElseIf strPlaneType = "Airbus A350" Then
            dblFinalCost += dblReliablePlaneFee
        End If
        Console.WriteLine(strPlaneType & " Plane: " & dblFinalCost)

        If strAirportCode = "MIA" Then
            dblFinalCost += dblMiamiFee
        End If
        Console.WriteLine(strAirportCode & " Airport: " & dblFinalCost)

        If blnReservedSeat Then
            dblFinalCost += dblReservedSeatFee
        End If

        Console.WriteLine(blnReservedSeat & " Reserved Seat: " & dblFinalCost)


        Console.WriteLine(dtmDOB & " Date Of Birth")

        intAge = dtmToday.Year - dtmDOB.Year

        If dtmDOB.Month > dtmToday.Month Then
            intAge -= 1
        ElseIf dtmDOB.Month = dtmToday.Month And dtmDOB.Day > dtmToday.Day Then
            intAge -= 1
        End If



        If intAge > 65 Then
            dblFinalCost -= dblFinalCost * dblSeniorDiscount
        ElseIf intAge < 5 Then
            dblFinalCost -= dblFinalCost * dblChildDiscount
        End If

        Console.WriteLine(intAge & " Age Discount : " & dblFinalCost)


        If intTotalFlights > 5 And intTotalFlights <= 10 Then
            dblFinalCost -= dblFinalCost * dblLowLoyaltyDiscount
        ElseIf intTotalFlights > 10 Then
            dblFinalCost -= dblFinalCost * dblHighLoyaltyDiscount
        End If
        Console.WriteLine(intTotalFlights & " Prev Flights : " & dblFinalCost)

        dblTotalPrice = dblFinalCost
        lblPrice.Text = "Final Price: " & dblFinalCost.ToString("$00.00")
    End Function



    Private Sub GetNeededDataForTicketCost(ByRef intFlightMiles As Integer, ByRef intPassengersOnFlight As Integer, ByRef strPlaneType As String, ByRef strAirportCode As String, ByRef dtmDOB As DateTime, ByRef intTotalFlights As Integer)
        Dim strSelect As String
        Dim dtPriceData As DataTable = New DataTable
        Dim strSelectExecuteStatement As String = "EXECUTE uspFindDataForFlightPrice " & "'" & cmbFlights.SelectedValue & "', '" & intCurrentPassengerID & "'"
        If dblDataLoaded Then

            Try
                CheckOpenDBConnection(Me)

                dtPriceData = ExecuteSelectProdcedure("uspFindDataForFlightPrice", "@intFlightID", cmbFlights.SelectedValue, "@intPassengerID", intCurrentPassengerID)

                For Each col As DataColumn In dtPriceData.Columns
                    Console.WriteLine($"Column Name: {col.ColumnName}, Value: {dtPriceData.Rows(0)(col)}")
                Next

                intFlightMiles = dtPriceData.Rows(0)("intMilesFlown")
                intPassengersOnFlight = dtPriceData.Rows(0)("intTotalPassengers")
                strPlaneType = dtPriceData.Rows(0)("strPlaneType")
                strAirportCode = dtPriceData.Rows(0)("strToAirportCode")
                dtmDOB = dtPriceData.Rows(0)("dtmDateOFBirth")
                intTotalFlights = dtPriceData.Rows(0)("TotalFlights")

                CloseDatabaseConnection()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub


    Private Sub cmbFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFlights.SelectedIndexChanged
        intGlobalFlightID = cmbFlights.SelectedValue
        If dblDataLoaded Then
            CalculateAndDisplayPrice()
        End If

        If rdbNotReserved.Checked Then
            btnSubmit.Text = "Book Flight"
            lblNotReserved.Text = dblTotalPrice.ToString("$00.00")
            lblReserved.Text = ""
            lblPrice.Text = dblTotalPrice.ToString("$00.00")
        ElseIf rdbReserved.Checked Then
            btnSubmit.Text = "Select Seat"
            lblNotReserved.Text = ""
            lblReserved.Text = dblTotalPrice.ToString("$00.00")
            lblPrice.Text = dblTotalPrice.ToString("$00.00")
        Else
            lblPrice.Text = ""
        End If
    End Sub


    Private Sub rdbNotReserved_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNotReserved.CheckedChanged
        If dblDataLoaded Then
            CalculateAndDisplayPrice()
        End If

        If rdbNotReserved.Checked Then
            btnSubmit.Text = "Book Flight"
            lblNotReserved.Text = dblTotalPrice.ToString("$00.00")
            lblReserved.Text = ""
            lblPrice.Text = dblTotalPrice.ToString("$00.00")
        ElseIf rdbReserved.Checked Then
            btnSubmit.Text = "Select Seat"
            lblNotReserved.Text = ""
            lblReserved.Text = dblTotalPrice.ToString("$00.00")
            lblPrice.Text = dblTotalPrice.ToString("$00.00")
        Else
            lblPrice.Text = ""
        End If
    End Sub

    Private Sub rdbReserved_CheckedChanged(sender As Object, e As EventArgs) Handles rdbReserved.CheckedChanged
        If dblDataLoaded Then
            CalculateAndDisplayPrice()
        End If

        If rdbNotReserved.Checked Then
            btnSubmit.Text = "Book Flight"
            lblNotReserved.Text = dblTotalPrice.ToString("$00.00")
            lblReserved.Text = ""
            lblPrice.Text = dblTotalPrice.ToString("$00.00")
        ElseIf rdbReserved.Checked Then
            btnSubmit.Text = "Select Seat"
            lblNotReserved.Text = ""
            lblReserved.Text = dblTotalPrice.ToString("$00.00")
            lblPrice.Text = dblTotalPrice.ToString("$00.00")
        Else
            lblPrice.Text = ""
        End If
    End Sub


End Class