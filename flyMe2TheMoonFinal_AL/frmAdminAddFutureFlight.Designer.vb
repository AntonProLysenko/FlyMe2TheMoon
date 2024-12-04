<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminAddFutureFlight
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
        Me.dtpFlightDate = New System.Windows.Forms.DateTimePicker()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.dtpDepartureTme = New System.Windows.Forms.DateTimePicker()
        Me.dtpLandingTme = New System.Windows.Forms.DateTimePicker()
        Me.cmbFromAirport = New System.Windows.Forms.ComboBox()
        Me.cmbToAirport = New System.Windows.Forms.ComboBox()
        Me.txtMiles = New System.Windows.Forms.TextBox()
        Me.cmbPlanes = New System.Windows.Forms.ComboBox()
        Me.lblPlane = New System.Windows.Forms.Label()
        Me.lblMiles = New System.Windows.Forms.Label()
        Me.lblToAirport = New System.Windows.Forms.Label()
        Me.lblFromAirport = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtpFlightDate
        '
        Me.dtpFlightDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFlightDate.Location = New System.Drawing.Point(457, 194)
        Me.dtpFlightDate.Name = "dtpFlightDate"
        Me.dtpFlightDate.Size = New System.Drawing.Size(730, 45)
        Me.dtpFlightDate.TabIndex = 0
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlightNumber.Location = New System.Drawing.Point(457, 278)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(730, 45)
        Me.txtFlightNumber.TabIndex = 1
        '
        'dtpDepartureTme
        '
        Me.dtpDepartureTme.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDepartureTme.Location = New System.Drawing.Point(457, 356)
        Me.dtpDepartureTme.Name = "dtpDepartureTme"
        Me.dtpDepartureTme.Size = New System.Drawing.Size(730, 45)
        Me.dtpDepartureTme.TabIndex = 3
        '
        'dtpLandingTme
        '
        Me.dtpLandingTme.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLandingTme.Location = New System.Drawing.Point(457, 504)
        Me.dtpLandingTme.Name = "dtpLandingTme"
        Me.dtpLandingTme.Size = New System.Drawing.Size(730, 45)
        Me.dtpLandingTme.TabIndex = 4
        '
        'cmbFromAirport
        '
        Me.cmbFromAirport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFromAirport.FormattingEnabled = True
        Me.cmbFromAirport.Location = New System.Drawing.Point(457, 428)
        Me.cmbFromAirport.Name = "cmbFromAirport"
        Me.cmbFromAirport.Size = New System.Drawing.Size(730, 46)
        Me.cmbFromAirport.TabIndex = 5
        '
        'cmbToAirport
        '
        Me.cmbToAirport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbToAirport.FormattingEnabled = True
        Me.cmbToAirport.Location = New System.Drawing.Point(457, 576)
        Me.cmbToAirport.Name = "cmbToAirport"
        Me.cmbToAirport.Size = New System.Drawing.Size(730, 46)
        Me.cmbToAirport.TabIndex = 6
        '
        'txtMiles
        '
        Me.txtMiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiles.Location = New System.Drawing.Point(457, 643)
        Me.txtMiles.Name = "txtMiles"
        Me.txtMiles.Size = New System.Drawing.Size(730, 45)
        Me.txtMiles.TabIndex = 7
        '
        'cmbPlanes
        '
        Me.cmbPlanes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlanes.FormattingEnabled = True
        Me.cmbPlanes.Location = New System.Drawing.Point(457, 713)
        Me.cmbPlanes.Name = "cmbPlanes"
        Me.cmbPlanes.Size = New System.Drawing.Size(730, 46)
        Me.cmbPlanes.TabIndex = 8
        '
        'lblPlane
        '
        Me.lblPlane.AutoSize = True
        Me.lblPlane.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlane.Location = New System.Drawing.Point(114, 716)
        Me.lblPlane.Name = "lblPlane"
        Me.lblPlane.Size = New System.Drawing.Size(123, 39)
        Me.lblPlane.TabIndex = 9
        Me.lblPlane.Text = "Plane: "
        '
        'lblMiles
        '
        Me.lblMiles.AutoSize = True
        Me.lblMiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMiles.Location = New System.Drawing.Point(114, 646)
        Me.lblMiles.Name = "lblMiles"
        Me.lblMiles.Size = New System.Drawing.Size(115, 39)
        Me.lblMiles.TabIndex = 10
        Me.lblMiles.Text = "Miles: "
        '
        'lblToAirport
        '
        Me.lblToAirport.AutoSize = True
        Me.lblToAirport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToAirport.Location = New System.Drawing.Point(114, 579)
        Me.lblToAirport.Name = "lblToAirport"
        Me.lblToAirport.Size = New System.Drawing.Size(184, 39)
        Me.lblToAirport.TabIndex = 11
        Me.lblToAirport.Text = "To Airport: "
        '
        'lblFromAirport
        '
        Me.lblFromAirport.AutoSize = True
        Me.lblFromAirport.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromAirport.Location = New System.Drawing.Point(114, 431)
        Me.lblFromAirport.Name = "lblFromAirport"
        Me.lblFromAirport.Size = New System.Drawing.Size(223, 39)
        Me.lblFromAirport.TabIndex = 12
        Me.lblFromAirport.Text = "From Airport: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 508)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(261, 39)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Time of Landing"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(114, 360)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 39)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Time of Departure"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(114, 281)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(240, 39)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Flight Number:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(114, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(191, 39)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Flight Date:"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(235, 830)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(302, 84)
        Me.btnAdd.TabIndex = 17
        Me.btnAdd.Text = "Add Flight"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.14286!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(794, 830)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(302, 84)
        Me.btnExit.TabIndex = 18
        Me.btnExit.Text = "Cancel"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.85714!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(329, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(674, 74)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Add New Future Flight"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmAdminAddFutureFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1393, 954)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblFromAirport)
        Me.Controls.Add(Me.lblToAirport)
        Me.Controls.Add(Me.lblMiles)
        Me.Controls.Add(Me.lblPlane)
        Me.Controls.Add(Me.cmbPlanes)
        Me.Controls.Add(Me.txtMiles)
        Me.Controls.Add(Me.cmbToAirport)
        Me.Controls.Add(Me.cmbFromAirport)
        Me.Controls.Add(Me.dtpLandingTme)
        Me.Controls.Add(Me.dtpDepartureTme)
        Me.Controls.Add(Me.txtFlightNumber)
        Me.Controls.Add(Me.dtpFlightDate)
        Me.Name = "frmAdminAddFutureFlight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Future Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpFlightDate As DateTimePicker
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents dtpDepartureTme As DateTimePicker
    Friend WithEvents dtpLandingTme As DateTimePicker
    Friend WithEvents cmbFromAirport As ComboBox
    Friend WithEvents cmbToAirport As ComboBox
    Friend WithEvents txtMiles As TextBox
    Friend WithEvents cmbPlanes As ComboBox
    Friend WithEvents lblPlane As Label
    Friend WithEvents lblMiles As Label
    Friend WithEvents lblToAirport As Label
    Friend WithEvents lblFromAirport As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Label5 As Label
End Class
