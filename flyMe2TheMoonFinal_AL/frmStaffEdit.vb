Public Class frmStaffEdit
    Private Sub frmStaffEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim strSelect As String
        Dim dtRoles As DataTable = New DataTable
        Dim dtStaffData As DataTable = New DataTable
        Dim dtEmploeeCredentials As DataTable = New DataTable
        Dim strCredentialsSelect As String

        txtPassword.PasswordChar = "*"
        Try
            If OpenDatabaseConnectionSQLServer() = False Then


                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()
            End If


            If strStaffRole = "Pilot" Then

                Me.Text = "Edit Pilot " & strCurrentUserName
                'Selecting Roles
                strSelect = "SELECT * FROM TPilotRoles"
                dtRoles = GetDataTable(strSelect)

                'Loadingg States results to a combobox
                cboRole.ValueMember = "intPilotRoleID"
                cboRole.DisplayMember = "strPilotRole"
                cboRole.DataSource = dtRoles
            Else
                Me.Text = "Edit Flight Attendant " & strCurrentUserName
                cboRole.Visible = False
                lblRole.Visible = False
            End If





            ' Selecting Emploee's info
            If strStaffRole = "Pilot" Then

                strSelect = "SELECT *
                        FROM TPilots 
                        Where intPilotID = " & intCurrentStaffMemberID

                strCredentialsSelect = "SELECT *
                                        FROM TEmployeeCredentials
                                        WHERE strEmployeeID in(" & "SELECT strEmployeeID
                                                                    FROM TPilots
                                                                    WHERE intPilotID = " & intCurrentStaffMemberID & ")"

            Else
                strSelect = "SELECT *
                        FROM TAttendants 
                        Where intAttendantID = " & intCurrentStaffMemberID

                strCredentialsSelect = "SELECT *
                                        FROM TEmployeeCredentials
                                        WHERE strEmployeeID in(" & "SELECT strEmployeeID
                                                                    FROM TAttendants
                                                                    WHERE intAttendantID = " & intCurrentStaffMemberID & ")"
            End If

            ' Retrieve and poulate all the records 
            dtStaffData = GetDataTable(strSelect)
            dtEmploeeCredentials = GetDataTable(strCredentialsSelect)

            txtFirstName.Text = dtStaffData.Rows(0)("strFirstName")
            txtLastName.Text = dtStaffData.Rows(0)("strLastName")
            txtEmployeeID.Text = dtStaffData.Rows(0)("strEmployeeID")
            dtpTerminationDate.Value = dtStaffData.Rows(0)("dtmDateOfTermination")
            txtPassword.Text = dtEmploeeCredentials.Rows(0)("strEmployeePassword")
            txtLoginID.Text = dtEmploeeCredentials.Rows(0)("intEmployeeLoginID")

            If strStaffRole = "Pilot" Then
                cboRole.SelectedValue = dtStaffData.Rows(0)("intPilotRoleID")
            End If


            'drSourceTable.Close()
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim frmStaffMenu As New frmStaffMenu
        Me.Hide()
        frmStaffMenu.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim blnValidInput As Boolean
        Dim strUpdate As String

        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim intPilotRoleID As Integer
        Dim dtmDateOfTermination As DateTime

        Dim strPassword As String
        Dim intLoginID As Integer

        Dim frmStaffMenu As New frmStaffMenu

        ValidateEmployeeEditFormInput(blnValidInput, strFirstName, strLastName, dtmDateOfTermination, strEmployeeID,
                                      txtFirstName, txtLastName, dtpTerminationDate, txtEmployeeID)

        If blnValidInput Then
            ValidateLoginCredentials(blnValidInput, intLoginID, strPassword, txtLoginID, txtPassword)
        End If


        If blnValidInput Then
            UpdateRecord(strFirstName, strLastName, dtmDateOfTermination, strEmployeeID, intLoginID, strPassword)
            Me.Hide()
            frmStaffMenu.ShowDialog()

        End If

    End Sub


    Private Sub UpdateRecord(strFirstName As String, strLastName As String, dtmDateOFTermination As DateTime, strEmployeeID As String, intLoginID As Integer, strPassword As String)

        Dim strUpdate As String
        Dim strUpdateExecute As String

        Try
            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If



            'update query
            If strStaffRole = "Pilot" Then
                strUpdateExecute = "EXECUTE uspUpdatePilot '" & intCurrentStaffMemberID.ToString & "', '" & strFirstName & "', '" & strLastName & "', '" & dtmDateOFTermination &
                                                            "', '" & strEmployeeID & "', '" & cboRole.SelectedValue & "', '" & intLoginID & "', '" & strPassword & "'"

            ElseIf strStaffRole = "Attendant" Then
                strUpdateExecute = "EXECUTE uspUpdateAttendant '" & intCurrentStaffMemberID.ToString & "', '" & strFirstName & "', '" & strLastName & "', '" & dtmDateOFTermination &
                                                            "', '" & strEmployeeID & "', '" & intLoginID & "', '" & strPassword & "'"
            End If
            'MessageBox.Show(strUpdate)
            'UpdateData(strUpdate)

            ExecuteUltimateTransaction(strUpdateExecute, strStaffRole, strFirstName & " " & strLastName, "Update")

            strCurrentUserName = strFirstName & " " & strLastName

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try






    End Sub

    Private Sub btmShowPass_Click(sender As Object, e As EventArgs) Handles btmShowPass.Click
        revealPassword(Timer1, 1, txtPassword)
    End Sub


End Class