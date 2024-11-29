<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbAdmin = New System.Windows.Forms.RadioButton()
        Me.rdbAttendant = New System.Windows.Forms.RadioButton()
        Me.rdbPilot = New System.Windows.Forms.RadioButton()
        Me.rdbPassenger = New System.Windows.Forms.RadioButton()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Mongolian Baiti", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWelcome.Location = New System.Drawing.Point(290, 103)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(742, 58)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "Welcome to Fly Me 2 The Moon"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(1091, 444)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(247, 90)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbAdmin)
        Me.GroupBox1.Controls.Add(Me.rdbAttendant)
        Me.GroupBox1.Controls.Add(Me.rdbPilot)
        Me.GroupBox1.Controls.Add(Me.rdbPassenger)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(317, 182)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(716, 349)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Please Select your role"
        '
        'rdbAdmin
        '
        Me.rdbAdmin.AutoSize = True
        Me.rdbAdmin.Location = New System.Drawing.Point(59, 253)
        Me.rdbAdmin.Name = "rdbAdmin"
        Me.rdbAdmin.Size = New System.Drawing.Size(260, 44)
        Me.rdbAdmin.TabIndex = 3
        Me.rdbAdmin.TabStop = True
        Me.rdbAdmin.Text = "Administrator"
        Me.rdbAdmin.UseVisualStyleBackColor = True
        '
        'rdbAttendant
        '
        Me.rdbAttendant.AutoSize = True
        Me.rdbAttendant.Location = New System.Drawing.Point(59, 183)
        Me.rdbAttendant.Name = "rdbAttendant"
        Me.rdbAttendant.Size = New System.Drawing.Size(300, 44)
        Me.rdbAttendant.TabIndex = 2
        Me.rdbAttendant.TabStop = True
        Me.rdbAttendant.Text = "Flight Attendant"
        Me.rdbAttendant.UseVisualStyleBackColor = True
        '
        'rdbPilot
        '
        Me.rdbPilot.AutoSize = True
        Me.rdbPilot.Location = New System.Drawing.Point(59, 116)
        Me.rdbPilot.Name = "rdbPilot"
        Me.rdbPilot.Size = New System.Drawing.Size(118, 44)
        Me.rdbPilot.TabIndex = 1
        Me.rdbPilot.TabStop = True
        Me.rdbPilot.Text = "Pilot"
        Me.rdbPilot.UseVisualStyleBackColor = True
        '
        'rdbPassenger
        '
        Me.rdbPassenger.AutoSize = True
        Me.rdbPassenger.Location = New System.Drawing.Point(59, 51)
        Me.rdbPassenger.Name = "rdbPassenger"
        Me.rdbPassenger.Size = New System.Drawing.Size(220, 44)
        Me.rdbPassenger.TabIndex = 0
        Me.rdbPassenger.TabStop = True
        Me.rdbPassenger.Text = "Passenger"
        Me.rdbPassenger.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmit.Location = New System.Drawing.Point(1091, 298)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(247, 90)
        Me.btnSubmit.TabIndex = 9
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.flyMe2TheMoon_AL.My.Resources.Resources._2
        Me.PictureBox1.Location = New System.Drawing.Point(1060, 50)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(328, 194)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1767, 756)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblWelcome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimumSize = New System.Drawing.Size(1765, 746)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fly Me 2 the Moon"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblWelcome As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdbAdmin As RadioButton
    Friend WithEvents rdbAttendant As RadioButton
    Friend WithEvents rdbPilot As RadioButton
    Friend WithEvents rdbPassenger As RadioButton
    Friend WithEvents btnSubmit As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
