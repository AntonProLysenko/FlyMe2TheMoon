<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaffFlight
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
        Me.lblTotalMIles = New System.Windows.Forms.Label()
        Me.lblMilesTotal = New System.Windows.Forms.Label()
        Me.lstUpcomingFlights = New System.Windows.Forms.ListBox()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTotalMIles
        '
        Me.lblTotalMIles.AutoSize = True
        Me.lblTotalMIles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMIles.Location = New System.Drawing.Point(482, 72)
        Me.lblTotalMIles.Name = "lblTotalMIles"
        Me.lblTotalMIles.Size = New System.Drawing.Size(35, 37)
        Me.lblTotalMIles.TabIndex = 7
        Me.lblTotalMIles.Text = "0"
        '
        'lblMilesTotal
        '
        Me.lblMilesTotal.AutoSize = True
        Me.lblMilesTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMilesTotal.Location = New System.Drawing.Point(57, 72)
        Me.lblMilesTotal.Name = "lblMilesTotal"
        Me.lblMilesTotal.Size = New System.Drawing.Size(438, 37)
        Me.lblMilesTotal.TabIndex = 6
        Me.lblMilesTotal.Text = "Upcoming Flights Total Miles:"
        '
        'lstUpcomingFlights
        '
        Me.lstUpcomingFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstUpcomingFlights.FormattingEnabled = True
        Me.lstUpcomingFlights.ItemHeight = 37
        Me.lstUpcomingFlights.Location = New System.Drawing.Point(33, 133)
        Me.lstUpcomingFlights.Name = "lstUpcomingFlights"
        Me.lstUpcomingFlights.Size = New System.Drawing.Size(2057, 337)
        Me.lstUpcomingFlights.TabIndex = 5
        '
        'btnDone
        '
        Me.btnDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDone.Location = New System.Drawing.Point(953, 514)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(235, 91)
        Me.btnDone.TabIndex = 4
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'frmStaffFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2121, 639)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTotalMIles)
        Me.Controls.Add(Me.lblMilesTotal)
        Me.Controls.Add(Me.lstUpcomingFlights)
        Me.Controls.Add(Me.btnDone)
        Me.MinimumSize = New System.Drawing.Size(2147, 710)
        Me.Name = "frmStaffFlight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "StaffFlight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTotalMIles As Label
    Friend WithEvents lblMilesTotal As Label
    Friend WithEvents lstUpcomingFlights As ListBox
    Friend WithEvents btnDone As Button
End Class
