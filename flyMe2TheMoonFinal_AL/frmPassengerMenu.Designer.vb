<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassengerMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblPassengerWelcome = New System.Windows.Forms.Label()
        Me.btnUpdatePassenger = New System.Windows.Forms.Button()
        Me.btnAddFlight = New System.Windows.Forms.Button()
        Me.btnPastFlights = New System.Windows.Forms.Button()
        Me.btnFutureFlights = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPassengerWelcome
        '
        Me.lblPassengerWelcome.AutoSize = True
        Me.lblPassengerWelcome.Font = New System.Drawing.Font("Modern No. 20", 22.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassengerWelcome.Location = New System.Drawing.Point(369, 134)
        Me.lblPassengerWelcome.Name = "lblPassengerWelcome"
        Me.lblPassengerWelcome.Size = New System.Drawing.Size(243, 60)
        Me.lblPassengerWelcome.TabIndex = 0
        Me.lblPassengerWelcome.Text = "Welcome"
        '
        'btnUpdatePassenger
        '
        Me.btnUpdatePassenger.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdatePassenger.Location = New System.Drawing.Point(30, 352)
        Me.btnUpdatePassenger.Name = "btnUpdatePassenger"
        Me.btnUpdatePassenger.Size = New System.Drawing.Size(370, 78)
        Me.btnUpdatePassenger.TabIndex = 1
        Me.btnUpdatePassenger.Text = "Update My Information"
        Me.btnUpdatePassenger.UseVisualStyleBackColor = True
        '
        'btnAddFlight
        '
        Me.btnAddFlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddFlight.Location = New System.Drawing.Point(433, 352)
        Me.btnAddFlight.Name = "btnAddFlight"
        Me.btnAddFlight.Size = New System.Drawing.Size(280, 78)
        Me.btnAddFlight.TabIndex = 2
        Me.btnAddFlight.Text = "Add Flight"
        Me.btnAddFlight.UseVisualStyleBackColor = True
        '
        'btnPastFlights
        '
        Me.btnPastFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPastFlights.Location = New System.Drawing.Point(1143, 352)
        Me.btnPastFlights.Name = "btnPastFlights"
        Me.btnPastFlights.Size = New System.Drawing.Size(319, 78)
        Me.btnPastFlights.TabIndex = 3
        Me.btnPastFlights.Text = "Show Past Flights"
        Me.btnPastFlights.UseVisualStyleBackColor = True
        '
        'btnFutureFlights
        '
        Me.btnFutureFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFutureFlights.Location = New System.Drawing.Point(743, 352)
        Me.btnFutureFlights.Name = "btnFutureFlights"
        Me.btnFutureFlights.Size = New System.Drawing.Size(379, 78)
        Me.btnFutureFlights.TabIndex = 4
        Me.btnFutureFlights.Text = "Show Upcoming Flights"
        Me.btnFutureFlights.UseVisualStyleBackColor = True
        '
        'frmPassengerMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1512, 583)
        Me.Controls.Add(Me.btnFutureFlights)
        Me.Controls.Add(Me.btnPastFlights)
        Me.Controls.Add(Me.btnAddFlight)
        Me.Controls.Add(Me.btnUpdatePassenger)
        Me.Controls.Add(Me.lblPassengerWelcome)
        Me.MinimumSize = New System.Drawing.Size(1538, 654)
        Me.Name = "frmPassengerMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Passenger Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPassengerWelcome As Label
    Friend WithEvents btnUpdatePassenger As Button
    Friend WithEvents btnAddFlight As Button
    Friend WithEvents btnPastFlights As Button
    Friend WithEvents btnFutureFlights As Button
End Class
