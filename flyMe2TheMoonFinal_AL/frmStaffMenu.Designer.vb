<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaffMenu
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
        Me.btnFutureFlights = New System.Windows.Forms.Button()
        Me.btnPastFlights = New System.Windows.Forms.Button()
        Me.btnUpdatePassenger = New System.Windows.Forms.Button()
        Me.lblStaffWelcome = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnFutureFlights
        '
        Me.btnFutureFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFutureFlights.Location = New System.Drawing.Point(566, 412)
        Me.btnFutureFlights.Name = "btnFutureFlights"
        Me.btnFutureFlights.Size = New System.Drawing.Size(379, 78)
        Me.btnFutureFlights.TabIndex = 9
        Me.btnFutureFlights.Text = "Show Upcoming Flights"
        Me.btnFutureFlights.UseVisualStyleBackColor = True
        '
        'btnPastFlights
        '
        Me.btnPastFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPastFlights.Location = New System.Drawing.Point(1046, 412)
        Me.btnPastFlights.Name = "btnPastFlights"
        Me.btnPastFlights.Size = New System.Drawing.Size(319, 78)
        Me.btnPastFlights.TabIndex = 8
        Me.btnPastFlights.Text = "Show Past Flights"
        Me.btnPastFlights.UseVisualStyleBackColor = True
        '
        'btnUpdatePassenger
        '
        Me.btnUpdatePassenger.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdatePassenger.Location = New System.Drawing.Point(102, 412)
        Me.btnUpdatePassenger.Name = "btnUpdatePassenger"
        Me.btnUpdatePassenger.Size = New System.Drawing.Size(370, 78)
        Me.btnUpdatePassenger.TabIndex = 6
        Me.btnUpdatePassenger.Text = "Update My Information"
        Me.btnUpdatePassenger.UseVisualStyleBackColor = True
        '
        'lblStaffWelcome
        '
        Me.lblStaffWelcome.AutoSize = True
        Me.lblStaffWelcome.Font = New System.Drawing.Font("Modern No. 20", 22.125!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStaffWelcome.Location = New System.Drawing.Point(620, 131)
        Me.lblStaffWelcome.Name = "lblStaffWelcome"
        Me.lblStaffWelcome.Size = New System.Drawing.Size(243, 60)
        Me.lblStaffWelcome.TabIndex = 5
        Me.lblStaffWelcome.Text = "Welcome"
        '
        'frmStaffMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1512, 583)
        Me.Controls.Add(Me.btnFutureFlights)
        Me.Controls.Add(Me.btnPastFlights)
        Me.Controls.Add(Me.btnUpdatePassenger)
        Me.Controls.Add(Me.lblStaffWelcome)
        Me.MinimumSize = New System.Drawing.Size(1538, 654)
        Me.Name = "frmStaffMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Staff Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnFutureFlights As Button
    Friend WithEvents btnPastFlights As Button
    Friend WithEvents btnUpdatePassenger As Button
    Friend WithEvents lblStaffWelcome As Label
End Class
