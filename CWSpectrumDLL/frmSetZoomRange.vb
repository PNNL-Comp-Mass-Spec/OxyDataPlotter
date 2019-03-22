Option Strict Off
Option Explicit On 

' -------------------------------------------------------------------------------
' Written by Matthew Monroe for the Department of Energy (PNNL, Richland, WA)
' Upgraded to VB.NET from VB6 in October 2003
' Copyright 2005, Battelle Memorial Institute.  All Rights Reserved.

' E-mail: matthew.monroe@pnl.gov or matt@alchemistmatt.com
' Website: http://panomics.pnl.gov/ or http://www.sysbio.org/resources/staff/
' -------------------------------------------------------------------------------
' 
' Licensed under the Apache License, Version 2.0; you may not use this file except
' in compliance with the License.  You may obtain a copy of the License at 
' http://www.apache.org/licenses/LICENSE-2.0

Friend Class frmSetZoomRange
	Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
        'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents txtYStart As System.Windows.Forms.TextBox
	Public WithEvents txtYEnd As System.Windows.Forms.TextBox
	Public WithEvents txtXEnd As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdSet As System.Windows.Forms.Button
	Public WithEvents txtXStart As System.Windows.Forms.TextBox
	Public WithEvents lblYStart As System.Windows.Forms.Label
	Public WithEvents lblYEnd As System.Windows.Forms.Label
    Public WithEvents lblXEnd As System.Windows.Forms.Label
	Public WithEvents lblXStart As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtYStart = New System.Windows.Forms.TextBox()
        Me.txtYEnd = New System.Windows.Forms.TextBox()
        Me.txtXEnd = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSet = New System.Windows.Forms.Button()
        Me.txtXStart = New System.Windows.Forms.TextBox()
        Me.lblYStart = New System.Windows.Forms.Label()
        Me.lblYEnd = New System.Windows.Forms.Label()
        Me.lblXEnd = New System.Windows.Forms.Label()
        Me.lblXStart = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtYStart
        '
        Me.txtYStart.AcceptsReturn = True
        Me.txtYStart.BackColor = System.Drawing.SystemColors.Window
        Me.txtYStart.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtYStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYStart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtYStart.Location = New System.Drawing.Point(125, 89)
        Me.txtYStart.MaxLength = 0
        Me.txtYStart.Name = "txtYStart"
        Me.txtYStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtYStart.Size = New System.Drawing.Size(107, 23)
        Me.txtYStart.TabIndex = 5
        Me.txtYStart.Text = "0"
        '
        'txtYEnd
        '
        Me.txtYEnd.AcceptsReturn = True
        Me.txtYEnd.BackColor = System.Drawing.SystemColors.Window
        Me.txtYEnd.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtYEnd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYEnd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtYEnd.Location = New System.Drawing.Point(125, 118)
        Me.txtYEnd.MaxLength = 0
        Me.txtYEnd.Name = "txtYEnd"
        Me.txtYEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtYEnd.Size = New System.Drawing.Size(107, 24)
        Me.txtYEnd.TabIndex = 7
        Me.txtYEnd.Text = "10"
        '
        'txtXEnd
        '
        Me.txtXEnd.AcceptsReturn = True
        Me.txtXEnd.BackColor = System.Drawing.SystemColors.Window
        Me.txtXEnd.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtXEnd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXEnd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtXEnd.Location = New System.Drawing.Point(125, 49)
        Me.txtXEnd.MaxLength = 0
        Me.txtXEnd.Name = "txtXEnd"
        Me.txtXEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtXEnd.Size = New System.Drawing.Size(107, 24)
        Me.txtXEnd.TabIndex = 3
        Me.txtXEnd.Text = "10"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(250, 59)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(87, 31)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Tag = "4020"
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdSet
        '
        Me.cmdSet.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSet.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSet.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSet.Location = New System.Drawing.Point(250, 20)
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSet.Size = New System.Drawing.Size(87, 30)
        Me.cmdSet.TabIndex = 8
        Me.cmdSet.Tag = "14510"
        Me.cmdSet.Text = "&Set"
        Me.cmdSet.UseVisualStyleBackColor = False
        '
        'txtXStart
        '
        Me.txtXStart.AcceptsReturn = True
        Me.txtXStart.BackColor = System.Drawing.SystemColors.Window
        Me.txtXStart.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtXStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXStart.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtXStart.Location = New System.Drawing.Point(125, 20)
        Me.txtXStart.MaxLength = 0
        Me.txtXStart.Name = "txtXStart"
        Me.txtXStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtXStart.Size = New System.Drawing.Size(107, 23)
        Me.txtXStart.TabIndex = 1
        Me.txtXStart.Text = "0"
        '
        'lblYStart
        '
        Me.lblYStart.BackColor = System.Drawing.SystemColors.Control
        Me.lblYStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblYStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblYStart.Location = New System.Drawing.Point(10, 89)
        Me.lblYStart.Name = "lblYStart"
        Me.lblYStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblYStart.Size = New System.Drawing.Size(111, 25)
        Me.lblYStart.TabIndex = 4
        Me.lblYStart.Text = "Y Start"
        '
        'lblYEnd
        '
        Me.lblYEnd.BackColor = System.Drawing.SystemColors.Control
        Me.lblYEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblYEnd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblYEnd.Location = New System.Drawing.Point(10, 118)
        Me.lblYEnd.Name = "lblYEnd"
        Me.lblYEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblYEnd.Size = New System.Drawing.Size(106, 26)
        Me.lblYEnd.TabIndex = 6
        Me.lblYEnd.Text = "Y End"
        '
        'lblXEnd
        '
        Me.lblXEnd.BackColor = System.Drawing.SystemColors.Control
        Me.lblXEnd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblXEnd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblXEnd.Location = New System.Drawing.Point(10, 49)
        Me.lblXEnd.Name = "lblXEnd"
        Me.lblXEnd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXEnd.Size = New System.Drawing.Size(106, 26)
        Me.lblXEnd.TabIndex = 2
        Me.lblXEnd.Text = "X End"
        '
        'lblXStart
        '
        Me.lblXStart.BackColor = System.Drawing.SystemColors.Control
        Me.lblXStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblXStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblXStart.Location = New System.Drawing.Point(10, 20)
        Me.lblXStart.Name = "lblXStart"
        Me.lblXStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXStart.Size = New System.Drawing.Size(111, 26)
        Me.lblXStart.TabIndex = 0
        Me.lblXStart.Text = "X Start"
        '
        'frmSetZoomRange
        '
        Me.AcceptButton = Me.cmdSet
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(404, 201)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtYStart)
        Me.Controls.Add(Me.txtYEnd)
        Me.Controls.Add(Me.txtXEnd)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdSet)
        Me.Controls.Add(Me.txtXStart)
        Me.Controls.Add(Me.lblYStart)
        Me.Controls.Add(Me.lblYEnd)
        Me.Controls.Add(Me.lblXEnd)
        Me.Controls.Add(Me.lblXStart)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetZoomRange"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Tag = "14500"
        Me.Text = "Set Zoom Range"
        Me.ResumeLayout(False)

    End Sub
#End Region

    Public Sub ReturnValues(ByRef dblXStart As Double, ByRef dblXEnd As Double, ByRef dblYStart As Double, ByRef dblYEnd As Double)
        dblXStart = PRISM.DataUtils.StringToValueUtils.CDoubleSafe(txtXStart.Text, 0)
        dblXEnd = PRISM.DataUtils.StringToValueUtils.CDoubleSafe(txtXEnd.Text, 10)

        dblYStart = PRISM.DataUtils.StringToValueUtils.CDoubleSafe(txtYStart.Text, 0)
        dblYEnd = PRISM.DataUtils.StringToValueUtils.CDoubleSafe(txtYEnd.Text, 10)
    End Sub

    Public Sub SetValues(dblXStart As Double, dblXEnd As Double, dblYStart As Double, dblYEnd As Double)
        txtXStart.Text = FormatNumberAsString(dblXStart, 12)
        txtXEnd.Text = FormatNumberAsString(dblXEnd, 12)

        txtYStart.Text = FormatNumberAsString(dblYStart, 12)
        txtYEnd.Text = FormatNumberAsString(dblYEnd, 12)
    End Sub

    Private Sub cmdCancel_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub cmdSet_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdSet.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub frmSetZoomRange_Load(eventSender As System.Object, eventArgs As System.EventArgs) Handles MyBase.Load
        SizeAndCenterWindow(Me, modCWSpectrum.wpcWindowPosConstants.UpperThird, 300, 150)
    End Sub

    Private Sub txtXEnd_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtXEnd.Enter
        TextBoxGotFocusHandler(txtXEnd)
    End Sub

    Private Sub txtXEnd_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtXEnd.KeyPress
        PRISMWin.TextBoxUtils.TextBoxKeyPressHandler(txtXEnd, eventArgs, True, True, True, False, False, False, False, False, False, True, True)
    End Sub

    Private Sub txtXStart_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtXStart.Enter
        TextBoxGotFocusHandler(txtXStart)
    End Sub

    Private Sub txtXStart_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtXStart.KeyPress
        PRISMWin.TextBoxUtils.TextBoxKeyPressHandler(txtXStart, eventArgs, True, True, True, False, False, False, False, False, False, True, True)
    End Sub

    Private Sub txtYEnd_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtYEnd.Enter
        TextBoxGotFocusHandler(txtYEnd)
    End Sub

    Private Sub txtYEnd_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtYEnd.KeyPress
        PRISMWin.TextBoxUtils.TextBoxKeyPressHandler(txtYEnd, eventArgs, True, True, True, False, False, False, False, False, False, True, True)
    End Sub

    Private Sub txtYStart_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtYStart.Enter
        TextBoxGotFocusHandler(txtYStart)
    End Sub

    Private Sub txtYStart_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtYStart.KeyPress
        PRISMWin.TextBoxUtils.TextBoxKeyPressHandler(txtYStart, eventArgs, True, True, True, False, False, False, False, False, False, True, True)
    End Sub
End Class