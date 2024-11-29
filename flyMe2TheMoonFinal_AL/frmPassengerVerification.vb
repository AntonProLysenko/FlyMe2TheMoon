Public Class frmPassengerVerification
    Private Sub frmPassengerVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateDropdown()
    End Sub

    'Private Sub frmPassengerVerification_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    '    PopulateDropdown()
    'End Sub


    Public Sub PopulateDropdown()
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtPassengers As DataTable = New DataTable

        Try

            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            Else

            End If

            'cmbPassengers.Items.Clear()

            'Selecting Passengers
            'strSelect = "SELECT intPassengerID, strFirstName + ' ' + strLastName as PassengerFullName FROM TPassengers"


            'Lockal Procedure Execution
            'cmdSelect = New OleDb.OleDbCommand("uspListOfPassengersID", m_conAdministrator)
            'cmdSelect.CommandType = CommandType.StoredProcedure
            'drSourceTable = cmdSelect.ExecuteReader
            'dtPassengers.Load(drSourceTable)

            dtPassengers = ExecuteSelectProdcedure("uspListOfPassengersID")

            cmbPassengers.ValueMember = "intPassengerID"
            cmbPassengers.DisplayMember = "PassengerFullName"
            cmbPassengers.DataSource = dtPassengers



            ' Selecting firs Passenger by default
            If cmbPassengers.Items.Count > 0 Then
                cmbPassengers.SelectedIndex = 0
            End If

            'drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Me.Hide()
        Dim frmAddNewPassenger As New frmPassengerAddNew
        frmAddNewPassenger.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim frmPassengerMenu As New frmPassengerMenu

        intCurrentPassengerID = cmbPassengers.SelectedValue
        strCurrentUserName = cmbPassengers.Text
        Me.Hide()
        frmPassengerMenu.ShowDialog()
    End Sub


End Class