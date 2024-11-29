Public Class frmAdminAddStaffToFlight
    Private Sub frmAdminAddStaffToFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strFlightsSelect As String = ""
        Dim strStaffSelect As String = ""
        Dim dtFlights As DataTable = New DataTable
        Dim dtStaffMembers As DataTable = New DataTable


        If strManageRole = "Pilot" Then
            Me.Text = "Assign Pilot To Flight"
            btnSubmit.Text = "Assign Pilot"
            lblSelectStaf.Text = "Select Pilot:"
        ElseIf strManageRole = "Attendant" Then
            Me.Text = "Assign Attendant To Flight"
            btnSubmit.Text = "Assign Attendant"
            lblSelectStaf.Text = "Select Attendant:"
        End If


        'Populating Flights on Load
        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If

            'Selecting Future Flights
            strFlightsSelect = "SELECT TF.intFlightID, TF.dtmFlightDate,
		                                FromAirport.strAirportCity + '(' + FromAirport.strAirportCode +')'+ ' - ' + ToAirport.strAirportCity+'('+ToAirport.strAirportCode +'): '  + 
		                                CONVERT(VARCHAR, TF.dtmFlightDate, 101) + ' at '+ CONVERT(VARCHAR, TF.dtmTimeofDeparture, 108) as strFlightName
                                FROM TFlights as  TF
                                JOIN TAirports as FromAirport 
	                                ON TF.intFromAirportID = FromAirport.intAirportID
                                JOIN TAirports as ToAirport 
	                                ON TF.intToAirportID = ToAirport.intAirportID
                                WHERE GETDATE() <= TF.dtmFlightDate
                                ORDER BY TF.dtmFlightDate"



            dtFlights = GetDataTable(strFlightsSelect)

            cmbFlights.ValueMember = "intFlightID"
            cmbFlights.DisplayMember = "strFlightName"
            cmbFlights.DataSource = dtFlights

            ' Selecting firs Flight by default
            If cmbFlights.Items.Count > 0 Then
                cmbFlights.SelectedIndex = 0
            End If


            If strManageRole = "Pilot" Then
                strStaffSelect = "SELECT intPilotID as intID, strFirstName + ' ' + strLastName as strFullName FROM TPilots"
            ElseIf strManageRole = "Attendant" Then
                strStaffSelect = "SELECT intAttendantID as intID, strFirstName + ' ' + strLastName as strFullName FROM TAttendants"
            End If

            dtStaffMembers = GetDataTable(strStaffSelect)

            cmbStaff.ValueMember = "intID"

            cmbStaff.DisplayMember = "strFullName"
            cmbStaff.DataSource = dtStaffMembers



            ' Selecting firs Member by default
            If cmbStaff.Items.Count > 0 Then
                cmbStaff.SelectedIndex = 0
            End If


            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub





    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strSelect As String
        Dim strInsert As String
        Dim strSelectNextPK As String

        Dim intNextPrimaryKey As Integer


        'Assigning Queries based on Managing Role State
        If strManageRole = "Pilot" Then
            strSelectNextPK = "SELECT max(intPilotFlightID)+1 AS intNextPrimaryKey FROM TPilotFlights"
            intNextPrimaryKey = DetectNextPK(strSelectNextPK)

            strSelect = "SELECT intFlightID FROM TPilotFlights WHERE intPilotID =" & cmbStaff.SelectedValue

            strInsert = "INSERT INTO TPilotFlights ( intPilotFlightID, intPilotID, intFlightID)" &
                   "VALUES( " & intNextPrimaryKey & ", " & cmbStaff.SelectedValue & ", " & cmbFlights.SelectedValue & " )"


        ElseIf strManageRole = "Attendant" Then
            strSelectNextPK = "SELECT max(intAttendantFlightID)+1 AS intNextPrimaryKey FROM TAttendantFlights"
            intNextPrimaryKey = DetectNextPK(strSelectNextPK)

            strSelect = "SELECT intFlightID FROM TAttendantFlights WHERE intAttendantID =" & cmbStaff.SelectedValue

            strInsert = "INSERT INTO TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID)" &
                    "VALUES( " & intNextPrimaryKey & ", " & cmbStaff.SelectedValue & ", " & cmbFlights.SelectedValue & " )"

        End If



        If frmAdd_Passenger_To_Flight.isOnFlight(strSelect, cmbFlights.SelectedValue) Then
            MessageBox.Show("This " & strManageRole & " is already on this flight!")
            CloseDatabaseConnection()

        Else
            Try
                InsertData(strInsert)
                CloseDatabaseConnection()

                Dim frmManageStaff As New frmAdminManageStaff
                Me.Hide()
                frmManageStaff.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub



    Private Function DetectNextPK(strSelectNextPK As String) As Integer

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




    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim frmManageStaff As New frmAdminManageStaff
        Me.Hide()
        frmManageStaff.ShowDialog()
    End Sub


End Class