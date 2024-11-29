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


        If Integer.TryParse(txtPassengerID.Text, intID) Then
            blnValid = True
        Else
            txtPassengerID.Focus()
            lblErrormessage.Text = "Passenger ID Has To Be Numbers Only"
        End If


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
                        'blnValid = True



                    Else
                        txtPassword.Focus()
                        lblErrormessage.Text = "Invalid Password!"
                        CloseDatabaseConnection()
                        'blnValid = False
                    End If
                Else
                    txtPassengerID.Focus()
                    lblErrormessage.Text = "User Not Found!"
                    CloseDatabaseConnection()
                    'blnValid = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            If blnValid Then

            End If


        End If



    End Sub

    Private Sub frmPassengerVerification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"
    End Sub






    'TIMER
    Private countdown As Integer = 1
    Private Sub btmShowPass_Click(sender As Object, e As EventArgs) Handles btmShowPass.Click
        countdown = 1

        Timer1.Interval = 1000
        Timer1.Start() ' Start the timer
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If countdown > 0 Then
            txtPassword.PasswordChar = Nothing
            countdown -= 1
        Else
            txtPassword.PasswordChar = "*"
            Timer1.Stop() ' Stop the timer when countdown is complete
        End If
    End Sub




End Class