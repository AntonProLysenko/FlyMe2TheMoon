Public Class frmAdminMenu
    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        Dim frmStat As New frmAdminStatistics
        strManageRole = ""
        Me.Hide()
        frmStat.ShowDialog()
    End Sub

    Private Sub btnManageAttendants_Click(sender As Object, e As EventArgs) Handles btnManageAttendants.Click
        Dim frmManageAttendant As New frmAdminManageStaff
        strManageRole = "Attendant"
        Me.Hide()
        frmManageAttendant.ShowDialog()
    End Sub

    Private Sub btnManagePilots_Click(sender As Object, e As EventArgs) Handles btnManagePilots.Click
        Dim frmManagePilot As New frmAdminManageStaff
        strManageRole = "Pilot"
        Me.Hide()
        frmManagePilot.ShowDialog()
    End Sub
End Class