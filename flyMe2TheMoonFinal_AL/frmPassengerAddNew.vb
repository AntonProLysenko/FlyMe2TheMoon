Public Class frmPassengerAddNew

    Private Sub frmAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim strSelectStates As String = ""
        'Dim cmdSelectStates As OleDb.OleDbCommand
        'Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtState As DataTable = New DataTable


        Try



            If OpenDatabaseConnectionSQLServer() = False Then
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()

            End If

            'Selecting States
            'strSelectStates = "SELECT * FROM TStates"

            'cmdSelectStates = New OleDb.OleDbCommand(strSelectStates, m_conAdministrator)
            'drSourceTable = cmdSelectStates.ExecuteReader
            dtState = ExecuteSelectProdcedure("uspStatesList")

            'Loadingg States results to a combobox
            cboStates.ValueMember = "intStateID"
            cboStates.DisplayMember = "strState"
            cboStates.DataSource = dtState

            'drSourceTable.Close()

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

        Dim frmPassengerVerification As New frmPassengerVerification


        'Called With Module Reference for easier find
        Call modFormInputValidation.ValidatePassengerFormInput(blnValidInput, strFirstName, strLastName, strAddress, strCity, strState, intStateID, strZip, strPhoneNum, strEmail, intLoginID, strPassword,
                                                  txtFirstName, txtLastName, txtAddress, txtCity, txtZip, cboStates, txtPhoneNumber, txtEmail, txtLoginID, txtPassword)

        If blnValidInput Then

            PushToDB(strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNum, strEmail)
            'frmPassengerVerification.PopulateDropdown()
            Me.Hide()
            frmPassengerVerification.ShowDialog()
        End If

    End Sub


    Private Function PushToDB(strFirstName As String, strLastName As String, strAddress As String, strCity As String, intStateID As Integer, strZip As String, strPhoneNum As String, strEmail As String)
        Try
            Dim intNextPrimaryKey As Integer
            Dim strInsert As String

            intNextPrimaryKey = DetectNextPK()

            strInsert = "INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail)" &
                " VALUES (" & intNextPrimaryKey & ", '" & strFirstName & "', '" & strLastName & "', '" & strAddress & "', '" & strCity & "', " & intStateID & ", '" & strZip & "', '" & strPhoneNum & "', '" & strEmail & "')"

            'MessageBox.Show(strInsert)

            InsertData(strInsert)
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function
    Private Function DetectNextPK()
        'Dim strSelectNextPK As String
        Dim cmdSelectNextPk As New OleDb.OleDbCommand
        'Dim drNextPk As OleDb.OleDbDataReader
        Dim intNextPrimaryKey As Integer
        Dim dtNextPK As New DataTable

        If OpenDatabaseConnectionSQLServer() = False Then
            MessageBox.Show(Me, "Database connection error." & vbNewLine &
                            "The application will now close.",
                            Me.Text + " Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()

        End If

        'strSelectNextPK = "SELECT MAX(intPassengerID) + 1 AS intNextPrimaryKey FROM TPassengers"

        'cmdSelectNextPk = New OleDb.OleDbCommand(strSelectNextPK, m_conAdministrator)
        'drNextPk = cmdSelectNextPk.ExecuteReader

        'drNextPk.Read()


        dtNextPK = ExecuteSelectNextPK("TPassengers", "intPassengerID")


        If dtNextPK.Rows(0)("intNextPrimaryKey") = Nothing Then
            intNextPrimaryKey = 1
        Else
            intNextPrimaryKey = dtNextPK.Rows(0)("intNextPrimaryKey")
        End If

        'If drNextPk.IsDBNull(0) = True Then
        '    intNextPrimaryKey = 1
        'Else
        '    intNextPrimaryKey = CInt(drNextPk("intNextPrimaryKey"))
        'End If

        Return intNextPrimaryKey
    End Function
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim frmPassengerVerification As New frmPassengerVerification
        Me.Hide()
        frmPassengerVerification.ShowDialog()
    End Sub

End Class