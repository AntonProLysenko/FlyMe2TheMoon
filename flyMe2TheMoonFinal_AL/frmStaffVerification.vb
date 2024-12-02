Public Class frmStaffVerification

    Private Sub frmPilotVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmAttendantMenu As New frmStaffMenu








        Dim frmStaffMenu As New frmStaffMenu
        Dim frmAdminMenu As New frmAdminMenu


        Dim dtEmployee As DataTable = New DataTable
        Dim intID As Integer
        Dim blnValid As Boolean = False


        If Integer.TryParse(txtEmployeeID.Text, intID) Then
            blnValid = True
        Else
            txtEmployeeID.Focus()
            lblErrormessage.Text = "Employee ID Has To Be Numbers Only"
        End If

        If txtPassword.Text.Length > 0 Then
            blnValid = True
        Else
            txtPassword.Focus()
            lblErrormessage.Text = "Enter your Password!"
        End If


        If blnValid Then

            Try
                CheckOpenDBConnection(Me)

                dtEmployee = ExecuteSelectProdcedure("uspFindEmployeeByID", "@logInID", txtEmployeeID.Text)

                If dtEmployee.Rows.Count > 0 Then
                    If dtEmployee.Rows(0)("strEmployeePassword") = txtPassword.Text Then
                        lblErrormessage.Text = ""



                        If dtEmployee.Rows(0)("strRole") = "Admin" Then
                            CloseDatabaseConnection()
                            Me.Hide()
                            frmAdminMenu.ShowDialog()
                        Else
                            Select Case dtEmployee.Rows(0)("strRole")
                                Case "Pilot"
                                    strStaffRole = "Pilot"
                                    dtEmployee = ExecuteSelectProdcedure("uspFindPilotByEmployeeID", "@@employeeID", dtEmployee.Rows(0)("strEmployeeID"))
                                Case "Attendant"
                                    strStaffRole = "Attendant"
                                    dtEmployee = ExecuteSelectProdcedure("uspFindAttendantByEmployeeID", "@@employeeID", dtEmployee.Rows(0)("strEmployeeID"))
                            End Select
                            intCurrentStaffMemberID = dtEmployee.Rows(0)("intID")
                            strCurrentUserName = dtEmployee.Rows(0)("strFullName")

                            CloseDatabaseConnection()
                            Me.Hide()
                            frmStaffMenu.ShowDialog()
                        End If
                    Else
                        txtPassword.Focus()
                        lblErrormessage.Text = "Invalid Password!"
                        CloseDatabaseConnection()
                        'blnValid = False
                    End If
                Else
                    txtEmployeeID.Focus()
                    lblErrormessage.Text = "User Not Found!"
                    CloseDatabaseConnection()
                    'blnValid = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub



    Private Sub btnExit_Click(sender As Object, e As EventArgs) 
        Close()
    End Sub

    Private Sub btmShowPass_Click(sender As Object, e As EventArgs) Handles btmShowPass.Click
        revealPassword(Timer1, 1, txtPassword)
    End Sub

End Class