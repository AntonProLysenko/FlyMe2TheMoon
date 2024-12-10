Public Class frmPassengerEdit
    Private Sub frmEditPassenger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtState As DataTable = New DataTable
        Dim dtPassengerData As DataTable = New DataTable

        txtPassword.PasswordChar = "*"
        Me.Text = "Edit " & strCurrentUserName
        Try
            CheckOpenDBConnection(Me)

            dtState = ExecuteSelectProdcedure("uspStatesList")

            'Loadingg States results to a combobox
            cboStates.ValueMember = "intStateID"
            cboStates.DisplayMember = "strState"
            cboStates.DataSource = dtState

            dtPassengerData = ExecuteSelectProdcedure("uspPassengerDetails", "@Passanger_id", intCurrentPassengerID)



            txtFirstName.Text = dtPassengerData.Rows(0)("strFirstName")
            txtLastName.Text = dtPassengerData.Rows(0)("strLastName")
            dtpDateOfBirth.Value = dtPassengerData.Rows(0)("dtmDateOfBirth")
            txtAddress.Text = dtPassengerData.Rows(0)("strAddress")
            txtCity.Text = dtPassengerData.Rows(0)("strCity")
            cboStates.SelectedValue = dtPassengerData.Rows(0)("intStateID")
            txtZip.Text = dtPassengerData.Rows(0)("strZip")
            txtPhoneNumber.Text = dtPassengerData.Rows(0)("strPhoneNumber")
            txtEmail.Text = dtPassengerData.Rows(0)("strEmail")
            txtPassword.Text = dtPassengerData.Rows(0)("strPassengerPassword")
            txtLoginID.Text = dtPassengerData.Rows(0)("intPassengerLoginID")


            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim blnValidInput As Boolean = False
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim strState As String
        Dim intStateID As Integer
        Dim strZip As String
        Dim strPhoneNum As String
        Dim strEmail As String
        Dim intLoginID As Integer
        Dim strPassword As String
        Dim dtmDateOfBirth As DateTime
        Dim frmPassengerMenu As New frmPassengerMenu

        'Called With Module Reference for easier find
        Call modFormInputValidation.ValidatePassengerFormInput(blnValidInput, strFirstName, strLastName, strAddress, strCity, strState, intStateID, strZip, strPhoneNum, strEmail, intLoginID, strPassword,
                                                  txtFirstName, txtLastName, txtAddress, txtCity, txtZip, cboStates, txtPhoneNumber, txtEmail, txtLoginID, txtPassword)
        If blnValidInput Then
            ValidateDateOfBirth(blnValidInput, dtmDateOfBirth, dtpDateOfBirth)
        End If

        If blnValidInput Then
            UpdateRecord(blnValidInput, strFirstName, strLastName, strAddress, strCity, strState, intStateID, strZip, strPhoneNum, strEmail, intLoginID, strPassword, dtmDateOfBirth)
        End If

        If blnValidInput Then
            Me.Hide()
            frmPassengerMenu.ShowDialog()
            Me.Close()
        End If


    End Sub

    Private Sub UpdateRecord(ByRef blnSucess As Boolean, strFirstName As String, strLastName As String, strAddress As String, strCity As String, strState As String, intStateID As Integer, strZip As String, strPhoneNumber As String,
                             strEmail As String, intLoginID As Integer, strPassword As String, dtmDateOfBirth As DateTime)

        Dim strUpdate As String

        Try
            CheckOpenDBConnection(Me)

            'update query
            strUpdate = "UPDATE TPassengers SET " &
                    "strFirstName = '" & strFirstName & "', " &
                    "strLastName = '" & strLastName & "', " &
                    "strAddress = '" & strAddress & "', " &
                    "strCity = '" & strCity & "', " &
                    "intStateID = " & intStateID & ", " &
                    "strZip = '" & strZip & "', " &
                    "strPhoneNumber = '" & strPhoneNumber & "', " &
                    "strEmail = '" & strEmail & "', " &
                    "strPassengerPassword = '" & strPassword & "', " &
                    "intPassengerLoginID = " & intLoginID & ", " &
                    "dtmDateOfBirth = '" & dtmDateOfBirth.Date & "' " &
                    " WHERE intPassengerID = " & intCurrentPassengerID.ToString
            'MessageBox.Show(strUpdate)
            UpdateData(strUpdate)

            strCurrentUserName = strFirstName & " " & strLastName

            CloseDatabaseConnection()
            blnSucess = True

        Catch ex As Exception
            If ex.Message.Contains("UNIQUE") Then
                MessageBox.Show("Login ID Already Exist")
            Else
                MessageBox.Show(ex.Message)
            End If
            blnSucess = False
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim frmPassengerMenu As New frmPassengerMenu
        Me.Hide()
        frmPassengerMenu.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btmShowPass_Click(sender As Object, e As EventArgs) Handles btmShowPass.Click
        revealPassword(Timer1, 1, txtPassword)
    End Sub
End Class