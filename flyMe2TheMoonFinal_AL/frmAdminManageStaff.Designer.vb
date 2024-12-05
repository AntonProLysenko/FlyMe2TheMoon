<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminManageStaff
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
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAssignToFlight = New System.Windows.Forms.Button()
        Me.lblMain = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddNew
        '
        Me.btnAddNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(67, 375)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(368, 75)
        Me.btnAddNew.TabIndex = 11
        Me.btnAddNew.Text = "Add New Staff"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(490, 375)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(368, 75)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete Staff Member"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAssignToFlight
        '
        Me.btnAssignToFlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssignToFlight.Location = New System.Drawing.Point(903, 375)
        Me.btnAssignToFlight.Name = "btnAssignToFlight"
        Me.btnAssignToFlight.Size = New System.Drawing.Size(413, 75)
        Me.btnAssignToFlight.TabIndex = 13
        Me.btnAssignToFlight.Text = "Assign Staff To Flight"
        Me.btnAssignToFlight.UseVisualStyleBackColor = True
        '
        'lblMain
        '
        Me.lblMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMain.Location = New System.Drawing.Point(516, 156)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(323, 53)
        Me.lblMain.TabIndex = 14
        Me.lblMain.Text = "Manage Staff"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(1140, 54)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(160, 62)
        Me.btnClose.TabIndex = 21
        Me.btnClose.Text = "Go Back"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmAdminManageStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1369, 566)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblMain)
        Me.Controls.Add(Me.btnAssignToFlight)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.MinimumSize = New System.Drawing.Size(1393, 630)
        Me.Name = "frmAdminManageStaff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Staff"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAssignToFlight As Button
    Friend WithEvents lblMain As Label
    Friend WithEvents btnClose As Button
End Class
