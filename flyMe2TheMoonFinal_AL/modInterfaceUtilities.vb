'Module modInterfaceUtilities
'    Dim countdown As Integer


'    Public Sub revealPassword(timer As System.Windows.Forms.Timer, intTime As Integer, txtPassword As Object)
'        countdown = intTime

'        AddHandler timer.Tick, Sub(sender, e) TimerTickHandler(timer, txtPassword)

'        timer.Interval = 500
'        timer.Start() ' Start the timer
'    End Sub


'    Private Sub TimerTickHandler(timer As System.Windows.Forms.Timer, txtPassword As Object)
'        If countdown > 0 Then
'            txtPassword.PasswordChar = Nothing
'            countdown -= 1
'        Else
'            txtPassword.PasswordChar = "*"
'            timer.Stop() ' Stop the timer when countdown is complete

'            ' Remove the handler to avoid multiple calls
'            RemoveHandler timer.Tick, Sub(sender, e) TimerTickHandler(timer, txtPassword)
'        End If
'    End Sub

'End Module


Module modInterfaceUtilities

    Public Sub revealPassword(timer As System.Windows.Forms.Timer, intTime As Integer, txtPassword As Object)
        ' Declare countdown as a local variable
        Dim countdown As Integer = intTime

        ' Define a handler delegate
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
