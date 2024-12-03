Module modFormInputValidation
    Public Sub ValidatePassengerFormInput(ByRef blnValidInput As Boolean, ByRef strFirstName As String, ByRef strLastName As String, ByRef strAddress As String, ByRef strCity As String,
                             ByRef strState As String, ByRef intStateID As Integer, ByRef strZip As String, ByRef strPhoneNum As String, ByRef strEmail As String, ByRef intLoginID As Integer, ByRef strPassword As String,
                             txtFirstName As Object, txtLastName As Object, txtAddress As Object, txtCity As Object, txtZip As Object, cboStates As Object, txtPhoneNumber As Object, txtEmail As Object,
                              txtLoginID As Object, txtPassword As Object)
        Call ValidateName(blnValidInput, strFirstName, strLastName, txtFirstName, txtLastName)

        If blnValidInput Then
            ValidateAddress(blnValidInput, strAddress, strCity, strState, intStateID, strZip, txtAddress, txtCity, txtZip, cboStates)
        End If

        If blnValidInput Then
            ValidateContactInfo(blnValidInput, strPhoneNum, strEmail, txtPhoneNumber, txtEmail)
        End If

        If blnValidInput Then
            ValidateLoginCredentials(blnValidInput, intLoginID, strPassword, txtLoginID, txtPassword)
        End If
    End Sub

    Public Sub ValidateEmployeeEditFormInput(ByRef blnValidInput As Boolean, ByRef strFirstName As String, ByRef strLastName As String, ByRef dtmDateOFTermination As DateTime, ByRef strEmployeeID As String,
                                      txtFirstName As Object, txtLastName As Object, dtpTerminationDate As Object, txtEmployeeID As Object)
        Call ValidateName(blnValidInput, strFirstName, strLastName, txtFirstName, txtLastName)

        If blnValidInput Then
            ValidateEmployeeID(blnValidInput, strEmployeeID, txtEmployeeID)
        End If
        If blnValidInput Then
            ValidateFutureDate(blnValidInput, dtmDateOFTermination, dtpTerminationDate, "Termination")
        End If
    End Sub


    Public Sub ValidateEmployeeAddFormInput(ByRef blnValidInput As Boolean, ByRef strFirstName As String, ByRef strLastName As String, ByRef dtmDateOFHire As DateTime, ByRef strEmployeeID As String,
                                      txtFirstName As Object, txtLastName As Object, dtpHireDate As Object, txtEmployeeID As Object)
        Call ValidateName(blnValidInput, strFirstName, strLastName, txtFirstName, txtLastName)

        If blnValidInput Then
            ValidateEmployeeID(blnValidInput, strEmployeeID, txtEmployeeID)
        End If

        If blnValidInput Then
            ValidateFutureDate(blnValidInput, dtmDateOFHire, dtpHireDate, "Hire")
        End If

    End Sub

    Private Sub ValidateName(ByRef blnValidInput As Boolean, ByRef strFirstName As String, ByRef strLastName As String,
                             txtFirstName As Object, txtLastName As Object)
        Call ValidateString(txtFirstName, strFirstName, blnValidInput, "First Name")

        If blnValidInput Then
            Call ValidateString(txtLastName, strLastName, blnValidInput, "Last Name")
        End If
    End Sub

    Private Sub ValidateString(txtField As Object, ByRef strStringVar As String, ByRef blnValid As Boolean, strVarName As String)
        If txtField.Text = "" Then
            MessageBox.Show(strVarName & "Cannot Be Empty")
            blnValid = False
            txtField.Focus()
            Exit Sub
        ElseIf ContainsNumber(txtField.Text) Then
            MessageBox.Show("Please, Enter a Valid " & strVarName)
            blnValid = False
            txtField.Focus()
            Exit Sub
        Else
            blnValid = True
            strStringVar = txtField.Text.Trim()
        End If
    End Sub

    Private Function ContainsNumber(str As String)
        Dim arrNums() As Integer = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}
        Dim blnContainsNumber As Boolean = False


        For index As Integer = 0 To arrNums.Length - 1
            If str.Contains(arrNums(index).ToString()) Then
                blnContainsNumber = True
                Exit For
            End If
        Next

        Return blnContainsNumber
    End Function

    Private Sub ValidateAddress(ByRef blnValidInput As Boolean, ByRef strAddress As String, ByRef strCity As String, ByRef strState As String, ByRef intStateID As Integer, ByRef strZip As String,
                                txtAddress As Object, txtCity As Object, txtZip As Object, cboStates As Object)
        If txtAddress.Text.Length <= 0 Then
            MessageBox.Show("Please, Enter A Valid Address")
            blnValidInput = False
            txtAddress.Focus()
            Exit Sub
        ElseIf Not ContainsNumber(txtAddress.Text) Then
            MessageBox.Show("Please, Enter A Valid Address")
            blnValidInput = False
            txtAddress.Focus()
            Exit Sub
        Else
            blnValidInput = True
            strAddress = txtAddress.Text.Trim()
        End If

        If blnValidInput Then
            Call ValidateString(txtCity, strCity, blnValidInput, "City")
        End If



        If blnValidInput Then

            If txtZip.Text.Length = 5 Then
                If IsNumeric(txtZip.Text) Then
                    blnValidInput = True
                    strZip = txtZip.Text.Trim()
                Else
                    MessageBox.Show("Please, Enter A Valid Zip Code")
                    blnValidInput = False
                    txtZip.Focus()
                    Exit Sub
                End If
            Else
                MessageBox.Show("Please, Enter A Valid Zip Code")
                blnValidInput = False
                txtZip.Focus()
                Exit Sub
            End If
        End If

        If blnValidInput Then
            Call ValidateString(cboStates, strState, blnValidInput, "State")
        End If

        If blnValidInput Then
            If cboStates.SelectedValue Then

                If cboStates.Items.Contains(cboStates.SelectedItem) Then
                    intStateID = cboStates.SelectedValue

                End If
            Else
                MessageBox.Show("Please, choose an existing State from the menu")
                blnValidInput = False
                cboStates.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub ValidateContactInfo(ByRef blnValid As Boolean, ByRef strPhoneNum As String, ByRef strEmail As String,
                                    txtPhoneNumber As Object, txtEmail As Object)
        If IsNumeric(txtPhoneNumber.Text) Then
            If txtPhoneNumber.Text.Length = 10 Then
                blnValid = True
                strPhoneNum = txtPhoneNumber.Text.Trim()
            Else
                MessageBox.Show("Please, Enter A Valid Phone Number")
                blnValid = False
                txtPhoneNumber.Focus()
                Exit Sub
            End If
        Else
            MessageBox.Show("Please, Enter A Valid Phone Number")
            blnValid = False
            txtPhoneNumber.Focus()
            Exit Sub
        End If

        If blnValid Then
            If txtEmail.Text = "" Then
                MessageBox.Show("Please, Enter An Email")
                blnValid = False
                txtEmail.Focus()
                Exit Sub
            ElseIf Not txtEmail.Text.Contains("@") OrElse txtEmail.Text.length < 4 Then
                MessageBox.Show("Please, Enter A Valid Email")
                blnValid = False
                txtEmail.Focus()
                Exit Sub
            Else
                strEmail = txtEmail.Text
                blnValid = True

            End If
        End If
    End Sub

    Private Sub ValidateFutureDate(ByRef blnValid As Boolean, ByRef dtmDate As DateTime, dtpDatePicker As Object, strPurpose As String)
        If dtpDatePicker.Value.Date >= DateTime.Now.Date Then
            dtmDate = dtpDatePicker.Value
            blnValid = True
        Else
            MessageBox.Show(strPurpose & " date cannot be in a past!")
            blnValid = False
            dtpDatePicker.Focus()
            Exit Sub
        End If
    End Sub

    Public Sub ValidateDateOfBirth(ByRef blnValid As Boolean, ByRef dtmDate As DateTime, dtpDatePicker As Object)

        If dtpDatePicker.Value.Date <= DateTime.Now.Date Then

            dtmDate = dtpDatePicker.Value
            blnValid = True
        Else
            MessageBox.Show("Date of Birth Cannot be in a Future!")
            blnValid = False
            dtpDatePicker.Focus()
            Exit Sub
        End If
    End Sub

    Public Sub ValidateLicenseExpDate(ByRef blnValid As Boolean, ByRef dtmDate As DateTime, dtpDatePicker As Object)
        Dim dtmSelectedDate As DateTime = dtpDatePicker.Value.Date
        Dim dtmToday As DateTime = DateTime.Now.Date



        If dtpDatePicker.Value.Date >= DateTime.Now.Date Then

            If (dtmSelectedDate - dtmToday).TotalDays > 7 Then
                dtmDate = dtpDatePicker.Value
                blnValid = True
            Else
                MessageBox.Show("License has to be valid for more than 7 days!")
                blnValid = False
                dtpDatePicker.Focus()
                Exit Sub
            End If
        Else
            MessageBox.Show("License Exparation Date cannot be in a past!")
            blnValid = False
            dtpDatePicker.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub ValidateEmployeeID(ByRef blnValid As Boolean, ByRef strEmployeeID As String, txtEmployeeID As Object)
        If txtEmployeeID.Text.Length = 5 Then
            If IsNumeric(txtEmployeeID.Text) Then
                strEmployeeID = txtEmployeeID.Text
                blnValid = True
            Else
                MessageBox.Show("Employee ID Has To Be Numeric Only!")
                blnValid = False
                txtEmployeeID.Focus()
            End If
        Else
            MessageBox.Show("Employee ID Has To Be 5 Numbers Long")
            blnValid = False
            txtEmployeeID.Focus()
        End If

    End Sub




    Public Sub ValidateLoginCredentials(ByRef blnValidInput As Boolean, ByRef intLoginID As Integer, ByRef strPassword As String, txtLoginID As Object, txtPassword As Object)
        If Integer.TryParse(txtLoginID.Text, intLoginID) Then
            blnValidInput = True
        ElseIf txtLoginID.Text.length < 5 Then
            MessageBox.Show("Login ID Has To Be  at least 5 digits long")
            blnValidInput = False
            txtLoginID.Focus()
        Else
            MessageBox.Show("Login ID Has To Be Numeric only")
            blnValidInput = False
            txtLoginID.Focus()
        End If


        If blnValidInput Then
            If txtPassword.Text.Length <= 5 Then
                blnValidInput = False
                MessageBox.Show("Password is too short")
                txtPassword.Focus()
            ElseIf ContainsNumber(txtPassword.Text) = False Then
                blnValidInput = False
                MessageBox.Show("Password has to include at least one digit")
                txtPassword.Focus()
            Else
                strPassword = txtPassword.Text
                blnValidInput = True

            End If

        End If

    End Sub
End Module
