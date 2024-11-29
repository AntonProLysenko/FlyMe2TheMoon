<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminAddStaffToFlight
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
        Me.cmbFlights = New System.Windows.Forms.ComboBox()
        Me.cmbStaff = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSelectStaf = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbFlights
        '
        Me.cmbFlights.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFlights.FormattingEnabled = True
        Me.cmbFlights.Location = New System.Drawing.Point(214, 350)
        Me.cmbFlights.Name = "cmbFlights"
        Me.cmbFlights.Size = New System.Drawing.Size(1053, 45)
        Me.cmbFlights.TabIndex = 3
        '
        'cmbStaff
        '
        Me.cmbStaff.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStaff.FormattingEnabled = True
        Me.cmbStaff.Location = New System.Drawing.Point(214, 178)
        Me.cmbStaff.Name = "cmbStaff"
        Me.cmbStaff.Size = New System.Drawing.Size(1053, 45)
        Me.cmbStaff.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(913, 504)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(323, 89)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(233, 504)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(451, 89)
        Me.btnSubmit.TabIndex = 5
        Me.btnSubmit.Text = "Assign"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(526, 281)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(407, 49)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Select  Flight:"
        '
        'lblSelectStaf
        '
        Me.lblSelectStaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectStaf.Location = New System.Drawing.Point(539, 107)
        Me.lblSelectStaf.Name = "lblSelectStaf"
        Me.lblSelectStaf.Size = New System.Drawing.Size(407, 49)
        Me.lblSelectStaf.TabIndex = 8
        Me.lblSelectStaf.Text = "Select  Staff:"
        '
        'frmAdminAddStaffToFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1515, 652)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblSelectStaf)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cmbStaff)
        Me.Controls.Add(Me.cmbFlights)
        Me.MinimumSize = New System.Drawing.Size(1541, 723)
        Me.Name = "frmAdminAddStaffToFlight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assign Staff To Flight"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbFlights As ComboBox
    Friend WithEvents cmbStaff As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSelectStaf As Label
End Class
