Public Class frmAdminAddNewStaff
    Private Sub frmAdminAddNewStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim dtRoles As DataTable = New DataTable
        Try
            If strManageRole = "Pilot" Then
                If OpenDatabaseConnectionSQLServer() = False Then


                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Me.Close()
                End If

                Me.Text = "Add Pilot " & strCurrentUserName
                btnAdd.Text = "Add Pilot"
                'Selecting Roles
                strSelect = "SELECT * FROM TPilotRoles"
                dtRoles = GetDataTable(strSelect)

                'Loadingg States results to a combobox
                cboRole.ValueMember = "intPilotRoleID"
                cboRole.DisplayMember = "strPilotRole"
                cboRole.DataSource = dtRoles

                If dtRoles.Rows.Count > 0 Then
                    cboRole.SelectedIndex = 0
                End If

                CloseDatabaseConnection()

            ElseIf strManageRole = "Attendant" Then
                Me.Text = "Add Flight Attendant " & strCurrentUserName
                btnAdd.Text = "Add Attendant"

                GroupBox1.Height = GroupBox1.Size.Height - cboRole.Height - dtpLicenseExparationDate.Height

                cboRole.Visible = False
                lblRole.Visible = False
                lblLicenceExp.Visible = False
                dtpLicenseExparationDate.Visible = False
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim strInsert As String
        Dim blnValidInput As Boolean = False

        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim dtmDateOfHire As DateTime
        Dim dtmDateOFLicenseExparation As DateTime



        If strManageRole = "Pilot" Then
            Call ValidateEmployeeAddFormInput(blnValidInput, strFirstName, strLastName, dtmDateOfHire, strEmployeeID,
                                                txtFirstName, txtLastName, dtpHireDate, txtEmployeeID)
            If blnValidInput Then
                Call ValidateLicenseExpDate(blnValidInput, dtmDateOFLicenseExparation, dtpLicenseExparationDate)
            End If
        ElseIf strManageRole = "Attendant" Then
            Call ValidateEmployeeAddFormInput(blnValidInput, strFirstName, strLastName, dtmDateOfHire, strEmployeeID,
        txtFirstName, txtLastName, dtpHireDate, txtEmployeeID)
        End If

        If blnValidInput Then
            PushToDB(strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOFLicenseExparation)
        End If
    End Sub



    Private Function PushToDB(strFirstName As String, strLastName As String, strEmployeeID As String, dtmDateOfHire As DateTime, dtmDateOFLicenseExparation As DateTime)
        Dim intNextPrimaryKey As Integer
        Dim strExecuteInsert As String

        Try

            'Dim strInsert As String
            'intNextPrimaryKey = DetectNextPK()


            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                "The application will now close.",
                                Me.Text + " Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If

            intNextPrimaryKey = 1

            If strManageRole = "Pilot" Then

                'strInsert = "INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
                '                       VALUES(" & intNextPrimaryKey & ", '" & strFirstName & "', '" & strLastName & "', '" & strEmployeeID & "', '" & dtmDateOfHire.Date & "', '1/1/2099', '" & dtmDateOFLicenseExparation.Date & "'," & cboRole.SelectedValue & " )"

                strExecuteInsert = "EXECUTE uspAddPilot '" & intNextPrimaryKey & "','" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dtmDateOfHire.Date & "','" & "1 / 1 / 2099" & "','" & dtmDateOFLicenseExparation.Date & "','" & cboRole.SelectedValue & "'"

            ElseIf strManageRole = "Attendant" Then

                'strInsert = "INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
                '                      VALUES(" & intNextPrimaryKey & ", '" & strFirstName & "', '" & strLastName & "', '" & strEmployeeID & "', '" & dtmDateOfHire.Date & "', '1/1/2099' )"


                strExecuteInsert = "EXECUTE uspAddAttendant '" & intNextPrimaryKey & "','" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dtmDateOfHire.Date & "','" & "1 / 1 / 2099" & "'"
            End If

            'MessageBox.Show(strInsert)
            'InsertData(strInsert)

            MessageBox.Show(strExecuteInsert)

            ExecuteUltimateTransaction(strExecuteInsert, strManageRole, strFirstName & " " & strLastName, "Insert")
            CloseDatabaseConnection()

                Dim frmManageStaff As New frmAdminManageStaff
                Me.Hide()
                frmManageStaff.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function







    'Private Function DetectNextPK()
    '    Dim strSelectNextPK As String
    '    Dim cmdSelectNextPk As New OleDb.OleDbCommand
    '    Dim drNextPk As OleDb.OleDbDataReader
    '    Dim intNextPrimaryKey As Integer


    '    If OpenDatabaseConnectionSQLServer() = False Then
    '        MessageBox.Show(Me, "Database connection error." & vbNewLine &
    '                        "The application will now close.",
    '                        Me.Text + " Error",
    '                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Me.Close()

    '    End If
    '    If strManageRole = "Pilot" Then
    '        strSelectNextPK = "SELECT MAX(intPilotID) + 1 AS intNextPrimaryKey FROM TPilots"
    '    ElseIf strManageRole = "Attendant" Then
    '        strSelectNextPK = "SELECT MAX(intAttendantID) + 1 AS intNextPrimaryKey FROM TAttendants"
    '    End If

    '    cmdSelectNextPk = New OleDb.OleDbCommand(strSelectNextPK, m_conAdministrator)
    '    drNextPk = cmdSelectNextPk.ExecuteReader

    '    drNextPk.Read()

    '    If drNextPk.IsDBNull(0) = True Then
    '        intNextPrimaryKey = 1
    '    Else
    '        intNextPrimaryKey = CInt(drNextPk("intNextPrimaryKey"))
    '    End If

    '    Return intNextPrimaryKey
    'End Function

    'Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    '    Dim frmManageStaff As New frmAdminManageStaff
    '    Me.Hide()
    '    frmManageStaff.ShowDialog()
    'End Sub



    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim frmManageStaff As New frmAdminManageStaff
        Me.Hide()
        frmManageStaff.ShowDialog()
    End Sub


End Class