Public Class frmStaffVerification

    Private Sub frmPilotVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"
        txtEmployeeID.Focus()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frmStaffMenu As New frmStaffMenu
        Dim frmAdminMenu As New frmAdminMenu


        Dim dtEmployee As DataTable = New DataTable
        Dim intID As Integer
        Dim blnValid As Boolean = False

        'Form Validation
        If txtEmployeeID.Text.Length <= 0 Then
            txtEmployeeID.Focus()
            lblErrormessage.Left = 100
            lblErrormessage.Text = "Enter Employee ID"
            blnValid = False
        Else
            blnValid = True
        End If

        If blnValid Then

            If txtPassword.Text.Length > 0 Then
                blnValid = True
            Else
                blnValid = False
                txtPassword.Focus()
                lblErrormessage.Left = 100
                lblErrormessage.Text = "Enter your Password!"
            End If
        End If

        If blnValid Then

            If Integer.TryParse(txtEmployeeID.Text, intID) Then
                blnValid = True
            Else
                blnValid = False
                txtEmployeeID.Focus()
                lblErrormessage.Left = 20
                lblErrormessage.Text = "Employee ID Has To Be Numbers Only"
            End If
        End If

        'Pass verification
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
                            Me.Close()
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
                            Me.Close()
                        End If
                    Else
                        txtPassword.Focus()
                        lblErrormessage.Left = 100
                        lblErrormessage.Text = "Invalid Password!"
                        CloseDatabaseConnection()
                        'blnValid = False
                    End If
                Else
                    txtEmployeeID.Focus()
                    lblErrormessage.Left = 100
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