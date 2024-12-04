<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminMenu
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
        Me.btnManagePilots = New System.Windows.Forms.Button()
        Me.btnManageAttendants = New System.Windows.Forms.Button()
        Me.btnStatistics = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnManagePilots
        '
        Me.btnManagePilots.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManagePilots.Location = New System.Drawing.Point(56, 353)
        Me.btnManagePilots.Name = "btnManagePilots"
        Me.btnManagePilots.Size = New System.Drawing.Size(277, 75)
        Me.btnManagePilots.TabIndex = 10
        Me.btnManagePilots.Text = "Manage Pilots"
        Me.btnManagePilots.UseVisualStyleBackColor = True
        '
        'btnManageAttendants
        '
        Me.btnManageAttendants.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageAttendants.Location = New System.Drawing.Point(382, 353)
        Me.btnManageAttendants.Name = "btnManageAttendants"
        Me.btnManageAttendants.Size = New System.Drawing.Size(277, 75)
        Me.btnManageAttendants.TabIndex = 11
        Me.btnManageAttendants.Text = "Manage Attendants"
        Me.btnManageAttendants.UseVisualStyleBackColor = True
        '
        'btnStatistics
        '
        Me.btnStatistics.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStatistics.Location = New System.Drawing.Point(1022, 353)
        Me.btnStatistics.Name = "btnStatistics"
        Me.btnStatistics.Size = New System.Drawing.Size(277, 75)
        Me.btnStatistics.TabIndex = 12
        Me.btnStatistics.Text = "FlyMy2theMoon Statistics"
        Me.btnStatistics.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(325, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(433, 48)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Administrator Menu"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.flyMe2TheMoon_AL.My.Resources.Resources._2
        Me.PictureBox1.Location = New System.Drawing.Point(875, 41)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(319, 204)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(696, 353)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(277, 75)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Add New Flight"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmAdminMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1369, 566)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnStatistics)
        Me.Controls.Add(Me.btnManageAttendants)
        Me.Controls.Add(Me.btnManagePilots)
        Me.MinimumSize = New System.Drawing.Size(1393, 630)
        Me.Name = "frmAdminMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrator Menu"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnManagePilots As Button
    Friend WithEvents btnManageAttendants As Button
    Friend WithEvents btnStatistics As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
End Class
