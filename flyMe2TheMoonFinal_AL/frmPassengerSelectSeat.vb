Public Class frmPassengerSelectSeat

    Dim frmBookFlight As New frmAdd_Passenger_To_Flight()

    Public strSelectedSeat As String
    Dim intFlightID As Integer
    'Constructor to accept the parent form instance
    Public Sub New(parentForm As frmAdd_Passenger_To_Flight)
        InitializeComponent()
        intFlightID = parentForm.intGlobalFlightID
    End Sub



    Private Sub frmPassengerSelectSeat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillOutSeatsLayout()


        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim seatCheckbox As CheckBox = CType(ctrl, CheckBox)
                AddHandler seatCheckbox.CheckedChanged, AddressOf CheckBox_Checked
            End If
        Next
    End Sub

    Private Function FillOutSeatsLayout()
        Dim cmdSelect As OleDb.OleDbCommand
        Dim drSourceTable As OleDb.OleDbDataReader
        Dim dtSeats As DataTable = New DataTable

        Dim strSelect As String
        Dim arrOfTakenSeats() As String

        strSelect = "SELECT strSeat FROM TFlightPassengers
                    WHERE intFlightID = " & intFlightID

        Try
            CheckOpenDBConnection(Me)
            'MessageBox.Show(strSelect)
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtSeats.Load(drSourceTable)

            If dtSeats.Rows.Count > 0 Then

                ReDim arrOfTakenSeats(dtSeats.Rows.Count - 1)
                For intIndex = 0 To dtSeats.Rows.Count - 1
                    arrOfTakenSeats(intIndex) = dtSeats.Rows(intIndex)("strSeat").ToString().ToLower()
                Next


                For CheckboxIndex As Integer = 1 To 120
                    Dim seat As CheckBox = CType(Me.Controls($"CheckBox{CheckboxIndex}"), CheckBox)
                    If seat IsNot Nothing Then


                        If seat.Tag IsNot Nothing Then
                            If arrOfTakenSeats.Contains(seat.Tag.ToString().ToLower()) Then
                                seat.Checked = True
                                seat.Enabled = False
                            End If

                        End If
                    End If
                Next


            End If


            CloseDatabaseConnection()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function



    'Checkboxes handeler
    Private Sub CheckBox_Checked(sender As Object, e As EventArgs)

        'checkbox that fired the event
        Dim newCheckedCheckbox As CheckBox = CType(sender, CheckBox)

        ' If the new checkbox is checked, uncheck all others
        If newCheckedCheckbox.Checked Then

            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is CheckBox Then

                    Dim oldCheckbox As CheckBox = CType(ctrl, CheckBox)

                    ' Uncheck other enabled checkboxes
                    If oldCheckbox.Enabled AndAlso oldCheckbox IsNot newCheckedCheckbox Then
                        oldCheckbox.Checked = False
                    End If
                End If
            Next
            lblSelectedSeat.Text = "Selected Seat: " & newCheckedCheckbox.Tag
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        strSelectedSeat = ""

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim seatCheckbox As CheckBox = CType(ctrl, CheckBox)

                If seatCheckbox.Enabled AndAlso seatCheckbox.Checked Then
                    strSelectedSeat = seatCheckbox.Tag.ToString()
                    Exit For
                End If
            End If
        Next

        'Validate that seat was Picked
        If strSelectedSeat = "" Then
            MessageBox.Show("Please select a seat before submitting.")
        Else



            If frmAdd_Passenger_To_Flight.isSeatAvailable(strSelectedSeat, intFlightID) Then

                Me.Hide()
                Me.Close()

            Else

                MessageBox.Show("Sorry, Someone was Faster Than You!" & vbNewLine & strSelectedSeat & " Seat is already Taken!" & vbNewLine & "Pick another one!")

                For Each ctrl As Control In Me.Controls
                    If TypeOf ctrl Is CheckBox Then
                        Dim seatCheckbox As CheckBox = CType(ctrl, CheckBox)

                        If seatCheckbox.Enabled AndAlso seatCheckbox.Tag = strSelectedSeat Then
                            seatCheckbox.Enabled = False
                            Exit For
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dim frmBookFlight As New frmAdd_Passenger_To_Flight
        Me.Hide()
        'frmBookFlight.ShowDialog()
        Me.Close()
    End Sub

End Class