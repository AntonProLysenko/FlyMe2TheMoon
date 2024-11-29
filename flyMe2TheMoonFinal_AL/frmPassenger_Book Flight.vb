Public Class frmAdd_Passenger_To_Flight
    Private Sub frmAdd_Passenger_To_Flight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim dtFlights As DataTable = New DataTable



        'Populating Flights on Load
        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If

            'cmbFlights.Items.Clear()




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

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim result
        Dim frmPassengerMenu As New frmPassengerMenu
        Dim intNextPrimaryKey As Integer
        Dim intFlightID As Integer
        Dim strSeatNumber As String

        Dim strInsert As String
        Dim strSelect As String
        Dim cmdInsert As New OleDb.OleDbCommand
        Dim intRowsAffected As Integer



        result = MessageBox.Show("Are You Sure you Want To Book This Fligh " & cmbFlights.Text & "?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        Select Case result
            Case DialogResult.Cancel
                MessageBox.Show("Booking Canceled")
                CloseDatabaseConnection()
                Me.Hide()
                frmPassengerMenu.ShowDialog()
            Case DialogResult.No
                MessageBox.Show("Booking Canceled")
                CloseDatabaseConnection()
                Me.Hide()
                frmPassengerMenu.ShowDialog()
            Case DialogResult.Yes




                'Opens DB Connection and detects next PK
                intNextPrimaryKey = DetectNextPK()
                intFlightID = cmbFlights.SelectedValue


                strSeatNumber = GenerateSeatNumber()

                strSelect = "SELECT intFlightID FROM TFlightPassengers WHERE intPassengerID =" & intCurrentPassengerID
                If isOnFlight(strSelect, cmbFlights.SelectedValue) Then
                    MessageBox.Show("You are already on this flight!")
                    CloseDatabaseConnection()
                Else
                    Try
                        strInsert = "INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat )" &
                            "VALUES( " & intNextPrimaryKey & ", " & intFlightID & ", " & intCurrentPassengerID & ", '" & strSeatNumber & "' )"

                        'MessageBox.Show(strInsert)


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
                        Close()
                        frmPassengerMenu.ShowDialog()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End If
        End Select
    End Sub






    Private Function DetectNextPK() As Integer
        Dim strSelectNextPK As String
        Dim cmdSelectNextPk As New OleDb.OleDbCommand
        Dim drNextPk As OleDb.OleDbDataReader
        Dim intNextPrimaryKey As Integer


        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            frmPassengerMenu.ShowDialog()

        End If

        strSelectNextPK = "SELECT max(intFlightPassengerID)+1 AS intNextPrimaryKey FROM TFlightPassengers"

        cmdSelectNextPk = New OleDb.OleDbCommand(strSelectNextPK, m_conAdministrator)
        drNextPk = cmdSelectNextPk.ExecuteReader

        drNextPk.Read()

        If drNextPk.IsDBNull(0) = True Then
            intNextPrimaryKey = 1
        Else
            intNextPrimaryKey = CInt(drNextPk("intNextPrimaryKey"))
        End If

        Return intNextPrimaryKey
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


        randomNumber = randomSeat.Next(1, 26)
        charRandomLetter = strSeats(randomSeat.Next(0, strSeats.Length))

        Return randomNumber & charRandomLetter

    End Function

    Public Function isOnFlight(strSelect As String, intFlightID As Integer) As Boolean

        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtFlights As DataTable = New DataTable

        Dim arrOfFligths() As Integer
        Dim blnOnFlight As Boolean = False

        Try

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

            Return blnOnFlight

        Catch ex As Exception

        End Try
    End Function


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim frmPassengerMenu As New frmPassengerMenu
        CloseDatabaseConnection()
        Me.Hide()
        frmPassengerMenu.ShowDialog()
    End Sub

End Class