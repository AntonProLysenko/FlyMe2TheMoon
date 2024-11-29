Public Class frmAdminManageStaff
    Private Sub frmAdminManageStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If strManageRole = "Pilot" Then
            Me.Text = "Manage Pilots"
            btnDelete.Text = "Delete Pilot"
            btnAssignToFlight.Text = "Assign Pilot To Flight"
            btnAddNew.Text = "Add New Pilot"
            lblMain.Text = "Manage Pilots"

        ElseIf strManageRole = "Attendant" Then
            Me.Text = "Manage Attendants"
            btnDelete.Text = "Delete Attendant"
            btnAssignToFlight.Text = "Assign Attendant To Flight"
            btnAddNew.Text = "Add New Attendant"
            lblMain.Text = "Manage Attendants"

        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim frmDeleteStaff As New frmAdminDeleteStaff
        Me.Hide()
        frmDeleteStaff.ShowDialog()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim frmAddStaff As New frmAdminAddNewStaff
        Me.Hide()
        frmAddStaff.ShowDialog()
    End Sub

    Private Sub btnAssignToFlight_Click(sender As Object, e As EventArgs) Handles btnAssignToFlight.Click
        Dim frmStaffAssign As New frmAdminAddStaffToFlight
        Me.Hide()
        frmStaffAssign.ShowDialog()
    End Sub
End Class