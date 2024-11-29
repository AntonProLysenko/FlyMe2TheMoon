Public Class frmPassengerEdit
    Private Sub frmEditPassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim strSelect As String
        'Dim cmdSelect As OleDb.OleDbCommand
        'Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtState As DataTable = New DataTable
        Dim dtPassengerData As DataTable = New DataTable

        Me.Text = "Edit " & strCurrentUserName
        Try
            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()
            End If

            'Selecting States
            'strSelect = "SELECT * FROM TStates"

            'cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            'drSourceTable = cmdSelect.ExecuteReader
            dtState = ExecuteSelectProdcedure("uspStatesList")

            'Loadingg States results to a combobox
            cboStates.ValueMember = "intStateID"
            cboStates.DisplayMember = "strState"
            cboStates.DataSource = dtState

            ' Selecting passenger's info
            'strSelect = "SELECT intPassengerID, strFirstName, strLastName, strAddress, strCity, TStates.intStateID, strState, strZip, strPhoneNumber, strEmail
            '            FROM TPassengers 
            '            Join TStates
            '            ON TStates.intStateID = TPassengers.intStateID
            '            Where intPassengerID = " & intCurrentPassengerID
            'MessageBox.Show(strSelect)

            ' Retrieve and poulate all the records 
            'cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            'drSourceTable = cmdSelect.ExecuteReader

            'drSourceTable.Read()
            dtPassengerData = ExecuteSelectProdcedure("uspPassengerDetails", "@Passanger_id", intCurrentPassengerID)



            txtFirstName.Text = dtPassengerData.Rows(0)("strFirstName")
            txtLastName.Text = dtPassengerData.Rows(0)("strLastName")
            txtAddress.Text = dtPassengerData.Rows(0)("strAddress")
            txtCity.Text = dtPassengerData.Rows(0)("strCity")
            cboStates.SelectedValue = dtPassengerData.Rows(0)("intStateID")
            txtZip.Text = dtPassengerData.Rows(0)("strZip")
            txtPhoneNumber.Text = dtPassengerData.Rows(0)("strPhoneNumber")
            txtEmail.Text = dtPassengerData.Rows(0)("strEmail")

            'drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim blnValidInput As Boolean = False
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim strState As String
        Dim intStateID As Integer
        Dim strZip As String
        Dim strPhoneNum As String
        Dim strEmail As String

        'Called With Module Reference for easier find
        Call modFormInputValidation.ValidatePassengerFormInput(blnValidInput, strFirstName, strLastName, strAddress, strCity, strState, intStateID, strZip, strPhoneNum, strEmail,
                                                  txtFirstName, txtLastName, txtAddress, txtCity, txtZip, cboStates, txtPhoneNumber, txtEmail)

        If blnValidInput Then
            UpdateRecord(strFirstName, strLastName, strAddress, strCity, strState, intStateID, strZip, strPhoneNum, strEmail)
            Me.Hide()
            frmPassengerMenu.ShowDialog()

        End If

    End Sub

    Private Sub UpdateRecord(strFirstName, strLastName, strAddress, strCity, strState, intStateID, strZip, strPhoneNumber, strEmail)
        Dim strUpdate As String

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If



            'update query
            strUpdate = "UPDATE TPassengers SET " &
                    "strFirstName = '" & strFirstName & "', " &
                    "strLastName = '" & strLastName & "', " &
                    "strAddress = '" & strAddress & "', " &
                    "strCity = '" & strCity & "', " &
                    "intStateID = " & intStateID & ", " &
                    "strZip = '" & strZip & "', " &
                    "strPhoneNumber = '" & strPhoneNumber & "', " &
                    "strEmail = '" & strEmail & "' " &
                    "WHERE intPassengerID = " & intCurrentPassengerID.ToString

            UpdateData(strUpdate)

            strCurrentUserName = strFirstName & " " & strLastName

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim frmPassengerMenu As New frmPassengerMenu
        Me.Hide()
        frmPassengerMenu.ShowDialog()
    End Sub
End Class