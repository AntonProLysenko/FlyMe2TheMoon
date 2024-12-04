Public Class frmAdminAddFutureFlight
    Private Sub frmAdminAddFutureFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFlightDate.MinDate = DateTime.Now.Date
        dtpDepartureTme.Format = DateTimePickerFormat.Time
        dtpLandingTme.Format = DateTimePickerFormat.Time

        Dim dtComboboxVals As DataTable = New DataTable


        Try

            CheckOpenDBConnection(Me)
            dtComboboxVals = ExecuteSelectProdcedure("uspFindAllAirports")

            'Loadingg States results to a combobox
            cmbFromAirport.ValueMember = "intAirportID"
            cmbFromAirport.DisplayMember = "airportName"
            cmbFromAirport.DataSource = dtComboboxVals
            If cmbFromAirport.Items.Count > 0 Then
                cmbFromAirport.SelectedIndex = 0
            End If

            cmbToAirport.ValueMember = "intAirportID"
            cmbToAirport.DisplayMember = "airportName"
            cmbToAirport.DataSource = dtComboboxVals
            If cmbFromAirport.Items.Count > 0 AndAlso cmbToAirport.Items.Count > 0 Then
                cmbToAirport.SelectedIndex = 1
            End If


            dtComboboxVals = ExecuteSelectProdcedure("uspFindAllPlanes")
            cmbPlanes.ValueMember = "intPlaneID"
            cmbPlanes.DisplayMember = "planeName"
            cmbPlanes.DataSource = dtComboboxVals
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtpFlightDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFlightDate.ValueChanged
        dtpDepartureTme.MinDate = dtpFlightDate.Value.Date
        dtpDepartureTme.MaxDate = dtpFlightDate.Value.Date
        dtpLandingTme.MinDate = dtpDepartureTme.Value.Date
        dtpLandingTme.MaxDate = dtpDepartureTme.Value.Date.AddHours(24)
    End Sub

End Class