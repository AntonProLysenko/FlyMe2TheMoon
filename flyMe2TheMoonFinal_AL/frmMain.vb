﻿Public Class frmMain


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnPassenger_Click(sender As Object, e As EventArgs) Handles btnPassenger.Click
        Dim frmPassengerVerification As New frmPassengerVerification
        strManageRole = ""
        strStaffRole = ""
        frmPassengerVerification.ShowDialog()
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        Dim frmStaffVerification As New frmStaffVerification
        frmStaffVerification.ShowDialog()
        strManageRole = ""
        strStaffRole = ""
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
