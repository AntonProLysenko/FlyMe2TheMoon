﻿Module modInterfaceUtilities

    Public Sub revealPassword(timer As System.Windows.Forms.Timer, intTime As Integer, txtPassword As Object)
        'Countdown is a var that sets timer length
        Dim countdown As Integer = intTime

        ' Define handler 
        Dim handler As EventHandler = Nothing

        ' Create the event handler logic
        handler = Sub(sender, e)
                      If countdown > 0 Then
                          txtPassword.PasswordChar = Nothing
                          countdown -= 1
                      Else
                          txtPassword.PasswordChar = "*"
                          timer.Stop() ' Stop the timer when countdown is complete
                          RemoveHandler timer.Tick, handler ' Remove the handler after stopping the timer
                      End If
                  End Sub

        ' Add the event handler
        AddHandler timer.Tick, handler

        timer.Interval = 500
        timer.Start() ' Start the timer
    End Sub

End Module
