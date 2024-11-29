Public Class frmStaffVerification

    Private Sub frmPilotVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateDropdown()
    End Sub

    Public Sub PopulateDropdown()
        Dim dtStaffMembers As DataTable
        'Dim strSelect As String
        Dim strProdcedureName As String

        If strStaffRole = "Pilot" Then
            Me.Text = "Pilot Verification"
            'strSelect = "SELECT intPilotID as intID, strFirstName + ' ' + strLastName as strFullName FROM TPilots"
            strProdcedureName = "uspPilotsList"
        ElseIf strStaffRole = "Attendant" Then
            Me.Text = "Attendant Verification"
            'strSelect = "SELECT intAttendantID as intID, strFirstName + ' ' + strLastName as strFullName FROM TAttendants"
            strProdcedureName = "uspAttendantsList"
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



            'Populating Attendants Dropdown
            'dtStaffMembers = GetDataTable(strSelect)
            dtStaffMembers = ExecuteSelectProdcedure(strProdcedureName)


            cmbStaff.ValueMember = "intID"

            cmbStaff.DisplayMember = "strFullName"
            cmbStaff.DataSource = dtStaffMembers



            ' Selecting firs Pilot by default
            If cmbStaff.Items.Count > 0 Then
                cmbStaff.SelectedIndex = 0
            End If


            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim frmAttendantMenu As New frmStaffMenu
        intCurrentStaffMemberID = cmbStaff.SelectedValue
        strCurrentUserName = cmbStaff.Text
        Me.Hide()
        frmAttendantMenu.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

End Class