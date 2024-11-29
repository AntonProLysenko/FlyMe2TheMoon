Public Class frmStaffEdit
    Private Sub frmStaffEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim strSelect As String
        Dim dtRoles As DataTable = New DataTable
        Dim dtStaffData As DataTable = New DataTable

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
            Else
                strSelect = "SELECT *
                        FROM TAttendants 
                        Where intAttendantID = " & intCurrentStaffMemberID
            End If

            ' Retrieve and poulate all the records 
            dtStaffData = GetDataTable(strSelect)

            txtFirstName.Text = dtStaffData.Rows(0)("strFirstName")
            txtLastName.Text = dtStaffData.Rows(0)("strLastName")
            txtEmployeeID.Text = dtStaffData.Rows(0)("strEmployeeID")
            dtpTerminationDate.Value = dtStaffData.Rows(0)("dtmDateOfTermination")

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

        Dim frmStaffMenu As New frmStaffMenu

        ValidateEmployeeEditFormInput(blnValidInput, strFirstName, strLastName, dtmDateOfTermination, strEmployeeID,
                                      txtFirstName, txtLastName, dtpTerminationDate, txtEmployeeID)

        If blnValidInput Then
            UpdateRecord(strFirstName, strLastName, dtmDateOfTermination, strEmployeeID)
            Me.Hide()
            frmStaffMenu.ShowDialog()

        End If

    End Sub


    Private Sub UpdateRecord(strFirstName, strLastName, dtmDateOFTermination, strEmployeeID)
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
                                                            "', '" & strEmployeeID & "', '" & cboRole.SelectedValue & "'"

                'strUpdate = "UPDATE TPilots SET " &
                '    "strFirstName = '" & strFirstName & "', " &
                '    "strLastName = '" & strLastName & "', " &
                '    "dtmDateOfTermination = '" & dtmDateOFTermination & "', " &
                '    "strEmployeeID = '" & strEmployeeID & "' , " &
                '    "intPilotRoleID = " & cboRole.SelectedValue &
                '    " WHERE intPilotID = " & intCurrentStaffMemberID.ToString




            ElseIf strStaffRole = "Attendant" Then
                strUpdateExecute = "EXECUTE uspUpdateAttendant '" & intCurrentStaffMemberID.ToString & "', '" & strFirstName & "', '" & strLastName & "', '" & dtmDateOFTermination &
                                                            "', '" & strEmployeeID & "'"

                'strUpdate = "UPDATE TAttendants SET " &
                '    "strFirstName = '" & strFirstName & "', " &
                '    "strLastName = '" & strLastName & "', " &
                '    "dtmDateOfTermination = '" & dtmDateOFTermination & "', " &
                '    "strEmployeeID = '" & strEmployeeID & "' " &
                '    "WHERE intAttendantID = " & intCurrentStaffMemberID.ToString
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


End Class