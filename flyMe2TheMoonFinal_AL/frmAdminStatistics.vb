Public Class frmAdminStatistics


    Private Sub frmAdminStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim dtResult As DataTable = New DataTable



        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            Else

            End If


            'Total Passengers
            'strSelect = "SELECT COUNT(intPassengerID) as TotalPassangers FROM TPassengers"
            'dtResult = GetDataTable(strSelect)

            dtResult = ExecuteSelectProdcedure("uspTotalPassengers")
            lblTotalCustomers.Text = lblTotalCustomers.Text & " " & dtResult.Rows(0)("TotalPassangers")

            'Total Flights
            'strSelect = "SELECT Count(intFlightID) as TotalFlightsTaken FROM TFlightPassengers"
            'dtResult = GetDataTable(strSelect)

            dtResult = ExecuteSelectProdcedure("uspTotalFlights")
            lblTotalFlights.Text = lblTotalFlights.Text & " " & dtResult.Rows(0)("TotalFlightsTaken")



            'Average Miles Flown By All Customers
            'strSelect = "SELECT AVG(intMilesFlown) as AverageMilesFlown
            '            FROM TFlights
            '            JOIN TFlightPassengers
            '                ON TFlightPassengers.intFlightID = TFlights.intFlightID"
            'dtResult = GetDataTable(strSelect)

            dtResult = ExecuteSelectProdcedure("uspAverageMilesByPassengers")
            lblAverageMiles.Text = lblAverageMiles.Text & " " & dtResult.Rows(0)("AverageMilesFlown") & "mi"


            'Pilot's total Miles
            'strSelect = "SELECT TPilots.intPilotID, strFirstName + ' ' + strLastName as PilotFullName, ISNULL( SUM(intMilesFlown), 0)  as TotalMiles
            '            FROM TPilots
            '            LEFT JOIN TPilotFlights
            '            On TPilotFlights.intPilotID = TPilots.intPilotID
            '            LEFT JOIN TFlights
            '            ON TFlights.intFlightID = TPilotFlights.intFlightID
            '            GROUP BY TPilots.intPilotID, strFirstName, strLastName"
            'dtResult = GetDataTable(strSelect)

            dtResult = ExecuteSelectProdcedure("uspAverageMilesByEachPilot")



            lstPilots.Items.Add("Pilots")
            lstPilots.Items.Add("  ")
            lstPilots.Items.Add("Full Name" & vbTab & "Total Miles")
            lstPilots.Items.Add("_________________________________")

            For Each row As DataRow In dtResult.Rows
                lstPilots.Items.Add("  ")

                If row.Item("PilotFullName").Length() < 10 Then
                    lstPilots.Items.Add(row.Item("PilotFullName") & vbTab & vbTab & row.Item("TotalMiles") & " mi")
                Else
                    lstPilots.Items.Add(row.Item("PilotFullName") & vbTab & row.Item("TotalMiles") & " mi")
                End If
            Next row




            'Attendant's total Miles
            'strSelect = "SELECT TAttendants.intAttendantID, strFirstName + ' ' + strLastName as AttendantFullName, ISNULL( SUM(intMilesFlown), 0)  as TotalMiles
            '            FROM TAttendants
            '            LEFT JOIN TAttendantFlights
            '            On TAttendantFlights.intAttendantID = TAttendants.intAttendantID
            '            LEFT JOIN TFlights
            '            ON TFlights.intFlightID = TAttendantFlights.intFlightID
            '            GROUP BY TAttendants.intAttendantID, strFirstName, strLastName"
            'dtResult = GetDataTable(strSelect)

            dtResult = ExecuteSelectProdcedure("uspAverageMilesByEachAttendant")

            lstAttendants.Items.Add("Attendants")
            lstAttendants.Items.Add("  ")
            lstAttendants.Items.Add("Full Name" & vbTab & "Total Miles")
            lstAttendants.Items.Add("_________________________________")

            For Each row As DataRow In dtResult.Rows
                lstAttendants.Items.Add("  ")

                If row.Item("AttendantFullName").Length() < 10 Then
                    lstAttendants.Items.Add(row.Item("AttendantFullName") & vbTab & vbTab & row.Item("TotalMiles") & " mi")
                Else

                    lstAttendants.Items.Add(row.Item("AttendantFullName") & vbTab & row.Item("TotalMiles") & " mi")
                End If

            Next row







            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim frmAdminMenu As New frmAdminMenu
        Me.Hide()
        frmAdminMenu.ShowDialog()
    End Sub
End Class