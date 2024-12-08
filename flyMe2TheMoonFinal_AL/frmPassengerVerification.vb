Public Class frmPassengerVerification
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Me.Hide()
        Dim frmAddNewPassenger As New frmPassengerAddNew
        frmAddNewPassenger.ShowDialog()
    End Sub



    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim frmPassengerMenu As New frmPassengerMenu
        Dim dtPassenger As DataTable = New DataTable
        Dim intID As Integer
        Dim blnValid As Boolean = False

        'Validation
        If txtPassengerID.Text.Length <= 0 Then
            txtPassengerID.Focus()
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

            If Integer.TryParse(txtPassengerID.Text, intID) Then
                blnValid = True
            Else
                blnValid = False
                txtPassengerID.Focus()
                lblErrormessage.Left = 20
                lblErrormessage.Text = "Passenger ID Has To Be Numbers Only"
            End If
        End If


        'Pass verification
        If blnValid Then

            Try
                CheckOpenDBConnection(Me)

                dtPassenger = ExecuteSelectProdcedure("uspFindPassengerByID", "@logInID", txtPassengerID.Text)
                If dtPassenger.Rows.Count > 0 Then
                    If dtPassenger.Rows(0)("strPassengerPassword") = txtPassword.Text Then
                        lblErrormessage.Text = ""
                        intCurrentPassengerID = dtPassenger.Rows(0)("intPassengerID")
                        strCurrentUserName = dtPassenger.Rows(0)("PassengerFullName")

                        CloseDatabaseConnection()
                        Me.Hide()
                        frmPassengerMenu.ShowDialog()

                    Else
                        txtPassword.Focus()
                        lblErrormessage.Left = 100
                        lblErrormessage.Text = "Invalid Password!"
                        CloseDatabaseConnection()
                        'blnValid = False
                    End If
                Else
                    txtPassengerID.Focus()
                    lblErrormessage.Left = 100
                    lblErrormessage.Text = "User Not Found!"
                    CloseDatabaseConnection()

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            If blnValid Then

            End If


        End If



    End Sub

    Private Sub frmPassengerVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'GroupBox1.TabStop = True
        'Me.TabStop = True

        txtPassengerID.Focus()
        txtPassword.PasswordChar = "*"
    End Sub


    Private Sub btmShowPass_Click(sender As Object, e As EventArgs) Handles btmShowPass.Click
        revealPassword(Timer1, 1, txtPassword)
    End Sub

End Class