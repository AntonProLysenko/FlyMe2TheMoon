Public Class frmPassengerAddNew

    Private Sub frmAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtState As DataTable = New DataTable

        txtPassword.PasswordChar = "*"

        Try

            CheckOpenDBConnection(Me)
            dtState = ExecuteSelectProdcedure("uspStatesList")

            'Loadingg States results to a combobox
            cboStates.ValueMember = "intStateID"
            cboStates.DisplayMember = "strState"
            cboStates.DataSource = dtState

            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAddPassenger_Click(sender As Object, e As EventArgs) Handles btnAddPassenger.Click
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

        Dim frmPassengerVerification As New frmPassengerVerification


        'Called With Module Reference for easier find
        Call modFormInputValidation.ValidatePassengerFormInput(blnValidInput, strFirstName, strLastName, strAddress, strCity, strState, intStateID, strZip, strPhoneNum, strEmail, intLoginID, strPassword,
                                                  txtFirstName, txtLastName, txtAddress, txtCity, txtZip, cboStates, txtPhoneNumber, txtEmail, txtLoginID, txtPassword)

        If blnValidInput Then
            ValidateDateOfBirth(blnValidInput, dtmDateOfBirth, dtpDateOfBirth)
        End If

        If blnValidInput Then
            If PushToDB(strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNum, strEmail, intLoginID, strPassword, dtmDateOfBirth) Then
                Me.Hide()
                frmPassengerVerification.ShowDialog()
            End If
            'frmPassengerVerification.PopulateDropdown()
        End If

    End Sub


    Private Function PushToDB(strFirstName As String, strLastName As String, strAddress As String, strCity As String, intStateID As Integer, strZip As String, strPhoneNum As String, strEmail As String, intLoginID As Integer, strPassword As String, dtmDateOfBirth As DateTime)
        Try
            Dim intNextPrimaryKey As Integer
            Dim strInsert As String

            intNextPrimaryKey = DetectNextPK()


            strInsert = "INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, intPassengerLoginID, strPassengerPassword, dtmDateOfBrth)" &
                " VALUES (" & intNextPrimaryKey & ", '" & strFirstName & "', '" & strLastName & "', '" & strAddress & "', '" & strCity & "', " & intStateID & ", '" & strZip & "', '" & strPhoneNum & "', '" & strEmail & "', " & intLoginID & ",'" & strPassword & "', '" & dtmDateOfBirth & "')"

            'MessageBox.Show(strInsert)

            InsertData(strInsert)
            CloseDatabaseConnection()

            Return True

        Catch ex As Exception
            If ex.Message.Contains("UNIQUE") Then
                MessageBox.Show("Login ID Already Exist")
            Else
                MessageBox.Show(ex.Message)
            End If
            Return False
        End Try

    End Function
    Private Function DetectNextPK()
        'Dim strSelectNextPK As String
        Dim cmdSelectNextPk As New OleDb.OleDbCommand
        'Dim drNextPk As OleDb.OleDbDataReader
        Dim intNextPrimaryKey As Integer
        Dim dtNextPK As New DataTable

        CheckOpenDBConnection(Me)

        dtNextPK = ExecuteSelectNextPK("TPassengers", "intPassengerID")

        If dtNextPK.Rows(0)("intNextPrimaryKey") = Nothing Then
            intNextPrimaryKey = 1
        Else
            intNextPrimaryKey = dtNextPK.Rows(0)("intNextPrimaryKey")
        End If

        Return intNextPrimaryKey
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim frmPassengerVerification As New frmPassengerVerification
        Me.Hide()
        frmPassengerVerification.ShowDialog()
    End Sub

End Class