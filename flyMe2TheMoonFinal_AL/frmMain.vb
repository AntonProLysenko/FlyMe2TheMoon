Public Class frmMain

    'Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
    '    Dim frmPassengerVerification As New frmPassengerVerification
    '    Dim frmStaffVerification As New frmStaffVerification
    '    Dim frmAdminMenu As New frmAdminMenu

    '    If rdbPassenger.Checked Then
    '        strManageRole = ""
    '        strStaffRole = ""
    '        frmPassengerVerification.ShowDialog()
    '    ElseIf rdbPilot.Checked Then
    '        strManageRole = ""
    '        strStaffRole = "Pilot"
    '        frmStaffVerification.ShowDialog()
    '    ElseIf rdbAttendant.Checked Then
    '        strManageRole = ""
    '        strStaffRole = "Attendant"
    '        frmStaffVerification.ShowDialog()
    '    ElseIf rdbAdmin.Checked Then
    '        strManageRole = ""
    '        strStaffRole = ""
    '        frmAdminMenu.ShowDialog()
    '    End If
    'End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
