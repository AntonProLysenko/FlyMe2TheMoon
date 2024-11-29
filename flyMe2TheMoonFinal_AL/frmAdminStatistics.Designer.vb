<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminStatistics
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTotalCustomers = New System.Windows.Forms.Label()
        Me.lblTotalFlights = New System.Windows.Forms.Label()
        Me.lblAverageMiles = New System.Windows.Forms.Label()
        Me.lstPilots = New System.Windows.Forms.ListBox()
        Me.lstAttendants = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(727, 800)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(283, 86)
        Me.btnClose.TabIndex = 21
        Me.btnClose.Text = "Done"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTotalCustomers
        '
        Me.lblTotalCustomers.AutoSize = True
        Me.lblTotalCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCustomers.Location = New System.Drawing.Point(30, 54)
        Me.lblTotalCustomers.Name = "lblTotalCustomers"
        Me.lblTotalCustomers.Size = New System.Drawing.Size(241, 33)
        Me.lblTotalCustomers.TabIndex = 22
        Me.lblTotalCustomers.Text = "Total Customers: "
        '
        'lblTotalFlights
        '
        Me.lblTotalFlights.AutoSize = True
        Me.lblTotalFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFlights.Location = New System.Drawing.Point(30, 159)
        Me.lblTotalFlights.Name = "lblTotalFlights"
        Me.lblTotalFlights.Size = New System.Drawing.Size(275, 33)
        Me.lblTotalFlights.TabIndex = 23
        Me.lblTotalFlights.Text = "Total Flights Taken: "
        '
        'lblAverageMiles
        '
        Me.lblAverageMiles.AutoSize = True
        Me.lblAverageMiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAverageMiles.Location = New System.Drawing.Point(30, 274)
        Me.lblAverageMiles.Name = "lblAverageMiles"
        Me.lblAverageMiles.Size = New System.Drawing.Size(293, 33)
        Me.lblAverageMiles.TabIndex = 24
        Me.lblAverageMiles.Text = "Average Miles Flown: "
        '
        'lstPilots
        '
        Me.lstPilots.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPilots.FormattingEnabled = True
        Me.lstPilots.ItemHeight = 37
        Me.lstPilots.Location = New System.Drawing.Point(501, 50)
        Me.lstPilots.Name = "lstPilots"
        Me.lstPilots.Size = New System.Drawing.Size(552, 707)
        Me.lstPilots.TabIndex = 25
        '
        'lstAttendants
        '
        Me.lstAttendants.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAttendants.FormattingEnabled = True
        Me.lstAttendants.ItemHeight = 37
        Me.lstAttendants.Location = New System.Drawing.Point(1112, 50)
        Me.lstAttendants.Name = "lstAttendants"
        Me.lstAttendants.Size = New System.Drawing.Size(552, 707)
        Me.lstAttendants.TabIndex = 26
        '
        'frmAdminStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1734, 910)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstAttendants)
        Me.Controls.Add(Me.lstPilots)
        Me.Controls.Add(Me.lblAverageMiles)
        Me.Controls.Add(Me.lblTotalFlights)
        Me.Controls.Add(Me.lblTotalCustomers)
        Me.Controls.Add(Me.btnClose)
        Me.MinimumSize = New System.Drawing.Size(1520, 981)
        Me.Name = "frmAdminStatistics"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Statistics"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents lblTotalCustomers As Label
    Friend WithEvents lblTotalFlights As Label
    Friend WithEvents lblAverageMiles As Label
    Friend WithEvents lstPilots As ListBox
    Friend WithEvents lstAttendants As ListBox
End Class
