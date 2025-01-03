﻿Public Class frmAdminAddNewStaff
    Private Sub frmAdminAddNewStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String
        Dim dtRoles As DataTable = New DataTable
        txtPassword.PasswordChar = "* "
        Try
            If strManageRole = "Pilot" Then
                CheckOpenDBConnection(Me)


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

        Dim intLoginID As Integer
        Dim strPassword As String



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
            ValidateLoginCredentials(blnValidInput, intLoginID, strPassword, txtLoginID, txtPassword)
        End If

        If blnValidInput Then
            PushToDB(strFirstName, strLastName, strEmployeeID, dtmDateOfHire, dtmDateOFLicenseExparation, intLoginID, strPassword)
        End If
    End Sub



    Private Function PushToDB(strFirstName As String, strLastName As String, strEmployeeID As String, dtmDateOfHire As DateTime, dtmDateOFLicenseExparation As DateTime, intLoginID As Integer, strPassword As String)
        Dim intNextPrimaryKey As Integer
        Dim strExecuteInsert As String

        Try

            'Dim strInsert As String
            'intNextPrimaryKey = DetectNextPK()

            CheckOpenDBConnection(Me)

            intNextPrimaryKey = 1

            If strManageRole = "Pilot" Then
                strExecuteInsert = "EXECUTE uspAddPilot '" & intNextPrimaryKey & "','" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dtmDateOfHire.Date & "','" & "1 / 1 / 2099" & "','" & dtmDateOFLicenseExparation.Date & "','" & cboRole.SelectedValue & "', '" &
                                    intNextPrimaryKey & "', '" & intLoginID & "', '" & strPassword & "'"
            ElseIf strManageRole = "Attendant" Then
                strExecuteInsert = "EXECUTE uspAddAttendant '" & intNextPrimaryKey & "','" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dtmDateOfHire.Date & "','" & "1 / 1 / 2099" & "', '" & intNextPrimaryKey & "', '" & intLoginID & "', '" & strPassword & "'"
            End If

            'MessageBox.Show(strInsert)
            'InsertData(strInsert)

            'MessageBox.Show(strExecuteInsert)

            ExecuteUltimateTransaction(strExecuteInsert, strManageRole, strFirstName & " " & strLastName, "Insert")
            CloseDatabaseConnection()

            Dim frmManageStaff As New frmAdminManageStaff
            Me.Hide()
            frmManageStaff.ShowDialog()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub btmShowPass_Click(sender As Object, e As EventArgs) Handles btmShowPass.Click
        revealPassword(Timer1, 1, txtPassword)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim frmManageStaff As New frmAdminManageStaff
        Me.Hide()
        frmManageStaff.ShowDialog()
    End Sub
End Class