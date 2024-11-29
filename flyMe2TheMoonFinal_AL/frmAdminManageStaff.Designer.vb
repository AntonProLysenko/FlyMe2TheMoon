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
        Me.SuspendLayout()
        '
        'btnAddNew
        '
        Me.btnAddNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(73, 391)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(401, 78)
        Me.btnAddNew.TabIndex = 11
        Me.btnAddNew.Text = "Add New Staff"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(535, 391)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(401, 78)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete Staff Member"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAssignToFlight
        '
        Me.btnAssignToFlight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssignToFlight.Location = New System.Drawing.Point(985, 391)
        Me.btnAssignToFlight.Name = "btnAssignToFlight"
        Me.btnAssignToFlight.Size = New System.Drawing.Size(450, 78)
        Me.btnAssignToFlight.TabIndex = 13
        Me.btnAssignToFlight.Text = "Assign Staff To Flight"
        Me.btnAssignToFlight.UseVisualStyleBackColor = True
        '
        'lblMain
        '
        Me.lblMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMain.Location = New System.Drawing.Point(563, 163)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(352, 55)
        Me.lblMain.TabIndex = 14
        Me.lblMain.Text = "Manage Staff"
        '
        'frmAdminManageStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1491, 583)
        Me.Controls.Add(Me.lblMain)
        Me.Controls.Add(Me.btnAssignToFlight)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.MinimumSize = New System.Drawing.Size(1517, 654)
        Me.Name = "frmAdminManageStaff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Staff"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAssignToFlight As Button
    Friend WithEvents lblMain As Label
End Class
