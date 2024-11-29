Public Class frmAdminDeleteStaff
    Private Sub frmDeletePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If strManageRole = "Pilot" Then
            Me.Text = "Delete Pilot"
            btnDelete.Text = "Delete Pilot"
            lblStafDelete.Text = "Pilot To Delete: "

        ElseIf strManageRole = "Attendant" Then
            Me.Text = "Delete Attendant"
            btnDelete.Text = "Delete Attendant"
            lblStafDelete.Text = "Attendant To Delete: "

        End If

        PopulateDropdown()
    End Sub


    Public Sub PopulateDropdown()
        Dim dtStaffMembers As DataTable
        Dim strSelect As String

        If strManageRole = "Pilot" Then
            strSelect = "SELECT intPilotID as intID, strFirstName + ' ' + strLastName as strFullName FROM TPilots"
        ElseIf strManageRole = "Attendant" Then
            strSelect = "SELECT intAttendantID as intID, strFirstName + ' ' + strLastName as strFullName FROM TAttendants"
        End If

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            Else

            End If



            'Populating Staff Dropdown
            dtStaffMembers = GetDataTable(strSelect)


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



    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As DialogResult
        'Dim strDelete As String
        Dim strDeleteExecution As String
        Dim intNumOfFutureFlights As Integer
        Dim frmManageStaff As New frmAdminManageStaff

        Try

            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.", Me.Text + " Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If



            intNumOfFutureFlights = NumOFFurureFlights(cmbStaff.SelectedValue)

            If intNumOfFutureFlights > 0 Then
                result = MessageBox.Show("Are you sure you want to Delete " & strManageRole & ": " & cmbStaff.Text & "?" & vbNewLine &
                                        "They are assigned to " & intNumOfFutureFlights & " Future Flights", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Else
                result = MessageBox.Show("Are you sure you want to Delete " & strManageRole & ": " & cmbStaff.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            End If


            If result = DialogResult.Cancel Then
                MessageBox.Show("Action Canceled")
                CloseDatabaseConnection()
                Me.Hide()
                frmManageStaff.ShowDialog()
            ElseIf result = DialogResult.No Then
                MessageBox.Show("Action Canceled")
                CloseDatabaseConnection()

                Me.Hide()
                frmManageStaff.ShowDialog()
            ElseIf result = DialogResult.Yes Then

                'Actual Deleting
                If strManageRole = "Pilot" Then
                    'First we need to delate any related Data

                    strDeleteExecution = "EXECUTE uspDeletePilot '" & cmbStaff.SelectedValue.ToString & "' "

                    'strDelete = "DELETE FROM TPilotFlights
                    '                WHERE intPilotID = " & cmbStaff.SelectedValue.ToString & vbNewLine &
                    '                "DELETE FROM TPilots
                    '            WHERE intPilotID = " & cmbStaff.SelectedValue.ToString

                ElseIf strManageRole = "Attendant" Then

                    strDeleteExecution = "EXECUTE uspDeleteAttendant '" & cmbStaff.SelectedValue.ToString & "' "

                    'strDelete = "DELETE FROM TAttendantFlights
                    '                 WHERE intAttendantID =  " & cmbStaff.SelectedValue.ToString & vbNewLine &
                    '            "DELETE FROM TAttendants
                    '             WHERE intAttendantID =  " & cmbStaff.SelectedValue.ToString
                End If
                'MessageBox.Show(strDelete)

                'DeleteData(strDelete)
                ExecuteUltimateTransaction(strDeleteExecution, strStaffRole, cmbStaff.Text, "Delete")

            End If
            CloseDatabaseConnection()
            Me.Hide()
            frmManageStaff.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    'Checks if Emloee assigned to any future Flights And Returns Integer - ammount of future Flights
    Private Function NumOFFurureFlights(intEmployeeID As Integer) As Integer
        Dim strSelect As String
        Dim dtResult As DataTable
        Dim intFutureFlights As Integer = 0
        If strManageRole = "Pilot" Then
            strSelect = "SELECT *FROM TPilotFlights
                    JOIN TFlights
	                    ON TPilotFlights.intFlightID = TFlights.intFlightID
                    WHERE intPilotID = " & intEmployeeID & " AND TFlights.dtmFlightDate < GETDATE()"
        ElseIf strManageRole = "Attendant" Then
            strSelect = "SELECT *FROM TAttendantFlights
                    JOIN TFlights
	                    ON TAttendantFlights.intFlightID = TFlights.intFlightID
                    WHERE intAttendantID = " & intEmployeeID & " AND TFlights.dtmFlightDate < GETDATE()"
        End If
        dtResult = GetDataTable(strSelect)

        If dtResult.Rows.Count > 0 Then
            intFutureFlights = dtResult.Rows.Count
        End If

        Return intFutureFlights
    End Function



    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim frmManageStaff As New frmAdminManageStaff
        Me.Hide()
        frmManageStaff.ShowDialog()
    End Sub
End Class