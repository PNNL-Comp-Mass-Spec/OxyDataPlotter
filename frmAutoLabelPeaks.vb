Option Strict Off
Option Explicit On 

' -------------------------------------------------------------------------------
' Written by Matthew Monroe for the Department of Energy (PNNL, Richland, WA)
' Upgraded to VB.NET from VB6 in October 2003
' Copyright 2005, Battelle Memorial Institute.  All Rights Reserved.

' E-mail: matthew.monroe@pnl.gov or matt@alchemistmatt.com
' Website: http://ncrr.pnl.gov/ or http://www.sysbio.org/resources/staff/
' -------------------------------------------------------------------------------
' 
' Licensed under the Apache License, Version 2.0; you may not use this file except
' in compliance with the License.  You may obtain a copy of the License at 
' http://www.apache.org/licenses/LICENSE-2.0

Friend Class frmAutoLabelPeaks
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
	Public WithEvents cboSeriesNumber As System.Windows.Forms.ComboBox
	Public WithEvents txtMinimumIntensityPercentageOfMaximum As System.Windows.Forms.TextBox
	Public WithEvents txtCaptionAngle As System.Windows.Forms.TextBox
	Public WithEvents txtMaximumPeaksToLabel As System.Windows.Forms.TextBox
	Public WithEvents chkHideInDenseRegions As System.Windows.Forms.CheckBox
	Public WithEvents chkIncludeArrow As System.Windows.Forms.CheckBox
	Public WithEvents chkDisplayYPos As System.Windows.Forms.CheckBox
	Public WithEvents chkDisplayXPos As System.Windows.Forms.CheckBox
	Public WithEvents cboDataMode As System.Windows.Forms.ComboBox
	Public WithEvents txtThresholdMinimum As System.Windows.Forms.TextBox
	Public WithEvents cmdAutoLabel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents txtPeakWidthMinimum As System.Windows.Forms.TextBox
	Public WithEvents lblSeriesNumber As System.Windows.Forms.Label
	Public WithEvents lblCaptionAngleLabel As System.Windows.Forms.Label
	Public WithEvents lblMininumIntensityInstructions As System.Windows.Forms.Label
	Public WithEvents lblPercentLabel As System.Windows.Forms.Label
	Public WithEvents lblMinimumIntensityFractionOfMaximum As System.Windows.Forms.Label
	Public WithEvents lblCaptionAngle As System.Windows.Forms.Label
	Public WithEvents lblMaximumPeaksToLabel As System.Windows.Forms.Label
	Public WithEvents lblDirections As System.Windows.Forms.Label
	Public WithEvents lblThresholdMinimum As System.Windows.Forms.Label
	Public WithEvents lblPeakWidthMinimum As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAutoLabelPeaks))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cboSeriesNumber = New System.Windows.Forms.ComboBox
		Me.txtMinimumIntensityPercentageOfMaximum = New System.Windows.Forms.TextBox
		Me.txtCaptionAngle = New System.Windows.Forms.TextBox
		Me.txtMaximumPeaksToLabel = New System.Windows.Forms.TextBox
		Me.chkHideInDenseRegions = New System.Windows.Forms.CheckBox
		Me.chkIncludeArrow = New System.Windows.Forms.CheckBox
		Me.chkDisplayYPos = New System.Windows.Forms.CheckBox
		Me.chkDisplayXPos = New System.Windows.Forms.CheckBox
		Me.cboDataMode = New System.Windows.Forms.ComboBox
		Me.txtThresholdMinimum = New System.Windows.Forms.TextBox
		Me.cmdAutoLabel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.txtPeakWidthMinimum = New System.Windows.Forms.TextBox
		Me.lblSeriesNumber = New System.Windows.Forms.Label
		Me.lblCaptionAngleLabel = New System.Windows.Forms.Label
		Me.lblMininumIntensityInstructions = New System.Windows.Forms.Label
		Me.lblPercentLabel = New System.Windows.Forms.Label
		Me.lblMinimumIntensityFractionOfMaximum = New System.Windows.Forms.Label
		Me.lblCaptionAngle = New System.Windows.Forms.Label
		Me.lblMaximumPeaksToLabel = New System.Windows.Forms.Label
		Me.lblDirections = New System.Windows.Forms.Label
		Me.lblThresholdMinimum = New System.Windows.Forms.Label
		Me.lblPeakWidthMinimum = New System.Windows.Forms.Label
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Auto Label Peaks"
		Me.ClientSize = New System.Drawing.Size(365, 416)
		Me.Location = New System.Drawing.Point(3, 24)
		Me.ControlBox = False
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmAutoLabelPeaks"
		Me.cboSeriesNumber.Size = New System.Drawing.Size(81, 21)
		Me.cboSeriesNumber.Location = New System.Drawing.Point(120, 8)
		Me.cboSeriesNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboSeriesNumber.TabIndex = 21
		Me.cboSeriesNumber.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboSeriesNumber.BackColor = System.Drawing.SystemColors.Window
		Me.cboSeriesNumber.CausesValidation = True
		Me.cboSeriesNumber.Enabled = True
		Me.cboSeriesNumber.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboSeriesNumber.IntegralHeight = True
		Me.cboSeriesNumber.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboSeriesNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboSeriesNumber.Sorted = False
		Me.cboSeriesNumber.TabStop = True
		Me.cboSeriesNumber.Visible = True
		Me.cboSeriesNumber.Name = "cboSeriesNumber"
		Me.txtMinimumIntensityPercentageOfMaximum.AutoSize = False
		Me.txtMinimumIntensityPercentageOfMaximum.Size = New System.Drawing.Size(41, 19)
		Me.txtMinimumIntensityPercentageOfMaximum.Location = New System.Drawing.Point(104, 220)
		Me.txtMinimumIntensityPercentageOfMaximum.TabIndex = 12
		Me.txtMinimumIntensityPercentageOfMaximum.Text = "10"
		Me.txtMinimumIntensityPercentageOfMaximum.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMinimumIntensityPercentageOfMaximum.AcceptsReturn = True
		Me.txtMinimumIntensityPercentageOfMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMinimumIntensityPercentageOfMaximum.BackColor = System.Drawing.SystemColors.Window
		Me.txtMinimumIntensityPercentageOfMaximum.CausesValidation = True
		Me.txtMinimumIntensityPercentageOfMaximum.Enabled = True
		Me.txtMinimumIntensityPercentageOfMaximum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMinimumIntensityPercentageOfMaximum.HideSelection = True
		Me.txtMinimumIntensityPercentageOfMaximum.ReadOnly = False
		Me.txtMinimumIntensityPercentageOfMaximum.Maxlength = 0
		Me.txtMinimumIntensityPercentageOfMaximum.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMinimumIntensityPercentageOfMaximum.MultiLine = False
		Me.txtMinimumIntensityPercentageOfMaximum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMinimumIntensityPercentageOfMaximum.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMinimumIntensityPercentageOfMaximum.TabStop = True
		Me.txtMinimumIntensityPercentageOfMaximum.Visible = True
		Me.txtMinimumIntensityPercentageOfMaximum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMinimumIntensityPercentageOfMaximum.Name = "txtMinimumIntensityPercentageOfMaximum"
		Me.txtCaptionAngle.AutoSize = False
		Me.txtCaptionAngle.Size = New System.Drawing.Size(41, 19)
		Me.txtCaptionAngle.Location = New System.Drawing.Point(104, 152)
		Me.txtCaptionAngle.TabIndex = 6
		Me.txtCaptionAngle.Text = "0"
		Me.txtCaptionAngle.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtCaptionAngle.AcceptsReturn = True
		Me.txtCaptionAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCaptionAngle.BackColor = System.Drawing.SystemColors.Window
		Me.txtCaptionAngle.CausesValidation = True
		Me.txtCaptionAngle.Enabled = True
		Me.txtCaptionAngle.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCaptionAngle.HideSelection = True
		Me.txtCaptionAngle.ReadOnly = False
		Me.txtCaptionAngle.Maxlength = 0
		Me.txtCaptionAngle.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCaptionAngle.MultiLine = False
		Me.txtCaptionAngle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCaptionAngle.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCaptionAngle.TabStop = True
		Me.txtCaptionAngle.Visible = True
		Me.txtCaptionAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCaptionAngle.Name = "txtCaptionAngle"
		Me.txtMaximumPeaksToLabel.AutoSize = False
		Me.txtMaximumPeaksToLabel.Size = New System.Drawing.Size(41, 19)
		Me.txtMaximumPeaksToLabel.Location = New System.Drawing.Point(104, 284)
		Me.txtMaximumPeaksToLabel.TabIndex = 17
		Me.txtMaximumPeaksToLabel.Text = "1000"
		Me.txtMaximumPeaksToLabel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtMaximumPeaksToLabel.AcceptsReturn = True
		Me.txtMaximumPeaksToLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtMaximumPeaksToLabel.BackColor = System.Drawing.SystemColors.Window
		Me.txtMaximumPeaksToLabel.CausesValidation = True
		Me.txtMaximumPeaksToLabel.Enabled = True
		Me.txtMaximumPeaksToLabel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMaximumPeaksToLabel.HideSelection = True
		Me.txtMaximumPeaksToLabel.ReadOnly = False
		Me.txtMaximumPeaksToLabel.Maxlength = 0
		Me.txtMaximumPeaksToLabel.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMaximumPeaksToLabel.MultiLine = False
		Me.txtMaximumPeaksToLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMaximumPeaksToLabel.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMaximumPeaksToLabel.TabStop = True
		Me.txtMaximumPeaksToLabel.Visible = True
		Me.txtMaximumPeaksToLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMaximumPeaksToLabel.Name = "txtMaximumPeaksToLabel"
		Me.chkHideInDenseRegions.Text = "Hide in &Dense Regions"
		Me.chkHideInDenseRegions.Size = New System.Drawing.Size(161, 17)
		Me.chkHideInDenseRegions.Location = New System.Drawing.Point(8, 128)
		Me.chkHideInDenseRegions.TabIndex = 4
		Me.chkHideInDenseRegions.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chkHideInDenseRegions.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkHideInDenseRegions.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkHideInDenseRegions.BackColor = System.Drawing.SystemColors.Control
		Me.chkHideInDenseRegions.CausesValidation = True
		Me.chkHideInDenseRegions.Enabled = True
		Me.chkHideInDenseRegions.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkHideInDenseRegions.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkHideInDenseRegions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkHideInDenseRegions.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkHideInDenseRegions.TabStop = True
		Me.chkHideInDenseRegions.Visible = True
		Me.chkHideInDenseRegions.Name = "chkHideInDenseRegions"
		Me.chkIncludeArrow.Text = "Include &Arrow"
		Me.chkIncludeArrow.Size = New System.Drawing.Size(161, 17)
		Me.chkIncludeArrow.Location = New System.Drawing.Point(8, 112)
		Me.chkIncludeArrow.TabIndex = 3
		Me.chkIncludeArrow.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkIncludeArrow.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkIncludeArrow.BackColor = System.Drawing.SystemColors.Control
		Me.chkIncludeArrow.CausesValidation = True
		Me.chkIncludeArrow.Enabled = True
		Me.chkIncludeArrow.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkIncludeArrow.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkIncludeArrow.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkIncludeArrow.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkIncludeArrow.TabStop = True
		Me.chkIncludeArrow.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkIncludeArrow.Visible = True
		Me.chkIncludeArrow.Name = "chkIncludeArrow"
		Me.chkDisplayYPos.Text = "Display &Y Position (Intensity)"
		Me.chkDisplayYPos.Size = New System.Drawing.Size(161, 17)
		Me.chkDisplayYPos.Location = New System.Drawing.Point(8, 88)
		Me.chkDisplayYPos.TabIndex = 2
		Me.chkDisplayYPos.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkDisplayYPos.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkDisplayYPos.BackColor = System.Drawing.SystemColors.Control
		Me.chkDisplayYPos.CausesValidation = True
		Me.chkDisplayYPos.Enabled = True
		Me.chkDisplayYPos.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkDisplayYPos.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDisplayYPos.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDisplayYPos.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDisplayYPos.TabStop = True
		Me.chkDisplayYPos.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDisplayYPos.Visible = True
		Me.chkDisplayYPos.Name = "chkDisplayYPos"
		Me.chkDisplayXPos.Text = "Display &X Position"
		Me.chkDisplayXPos.Size = New System.Drawing.Size(161, 17)
		Me.chkDisplayXPos.Location = New System.Drawing.Point(8, 72)
		Me.chkDisplayXPos.TabIndex = 1
		Me.chkDisplayXPos.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.chkDisplayXPos.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.chkDisplayXPos.BackColor = System.Drawing.SystemColors.Control
		Me.chkDisplayXPos.CausesValidation = True
		Me.chkDisplayXPos.Enabled = True
		Me.chkDisplayXPos.ForeColor = System.Drawing.SystemColors.ControlText
		Me.chkDisplayXPos.Cursor = System.Windows.Forms.Cursors.Default
		Me.chkDisplayXPos.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.chkDisplayXPos.Appearance = System.Windows.Forms.Appearance.Normal
		Me.chkDisplayXPos.TabStop = True
		Me.chkDisplayXPos.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.chkDisplayXPos.Visible = True
		Me.chkDisplayXPos.Name = "chkDisplayXPos"
		Me.cboDataMode.Size = New System.Drawing.Size(193, 21)
		Me.cboDataMode.Location = New System.Drawing.Point(8, 40)
		Me.cboDataMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDataMode.TabIndex = 0
		Me.cboDataMode.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboDataMode.BackColor = System.Drawing.SystemColors.Window
		Me.cboDataMode.CausesValidation = True
		Me.cboDataMode.Enabled = True
		Me.cboDataMode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cboDataMode.IntegralHeight = True
		Me.cboDataMode.Cursor = System.Windows.Forms.Cursors.Default
		Me.cboDataMode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cboDataMode.Sorted = False
		Me.cboDataMode.TabStop = True
		Me.cboDataMode.Visible = True
		Me.cboDataMode.Name = "cboDataMode"
		Me.txtThresholdMinimum.AutoSize = False
		Me.txtThresholdMinimum.Size = New System.Drawing.Size(89, 19)
		Me.txtThresholdMinimum.Location = New System.Drawing.Point(104, 188)
		Me.txtThresholdMinimum.TabIndex = 9
		Me.txtThresholdMinimum.Text = "1"
		Me.txtThresholdMinimum.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtThresholdMinimum.AcceptsReturn = True
		Me.txtThresholdMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtThresholdMinimum.BackColor = System.Drawing.SystemColors.Window
		Me.txtThresholdMinimum.CausesValidation = True
		Me.txtThresholdMinimum.Enabled = True
		Me.txtThresholdMinimum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtThresholdMinimum.HideSelection = True
		Me.txtThresholdMinimum.ReadOnly = False
		Me.txtThresholdMinimum.Maxlength = 0
		Me.txtThresholdMinimum.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtThresholdMinimum.MultiLine = False
		Me.txtThresholdMinimum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtThresholdMinimum.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtThresholdMinimum.TabStop = True
		Me.txtThresholdMinimum.Visible = True
		Me.txtThresholdMinimum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtThresholdMinimum.Name = "txtThresholdMinimum"
		Me.cmdAutoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAutoLabel.Text = "Auto-&Label"
		Me.cmdAutoLabel.Size = New System.Drawing.Size(73, 25)
		Me.cmdAutoLabel.Location = New System.Drawing.Point(224, 40)
		Me.cmdAutoLabel.TabIndex = 19
		Me.cmdAutoLabel.Tag = "14510"
		Me.cmdAutoLabel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdAutoLabel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAutoLabel.CausesValidation = True
		Me.cmdAutoLabel.Enabled = True
		Me.cmdAutoLabel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAutoLabel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAutoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAutoLabel.TabStop = True
		Me.cmdAutoLabel.Name = "cmdAutoLabel"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton = Me.cmdClose
		Me.cmdClose.Text = "&Close"
		Me.AcceptButton = Me.cmdClose
		Me.cmdClose.Size = New System.Drawing.Size(73, 25)
		Me.cmdClose.Location = New System.Drawing.Point(224, 72)
		Me.cmdClose.TabIndex = 20
		Me.cmdClose.Tag = "4020"
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.txtPeakWidthMinimum.AutoSize = False
		Me.txtPeakWidthMinimum.Size = New System.Drawing.Size(41, 19)
		Me.txtPeakWidthMinimum.Location = New System.Drawing.Point(104, 252)
		Me.txtPeakWidthMinimum.TabIndex = 15
		Me.txtPeakWidthMinimum.Text = "5"
		Me.txtPeakWidthMinimum.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPeakWidthMinimum.AcceptsReturn = True
		Me.txtPeakWidthMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPeakWidthMinimum.BackColor = System.Drawing.SystemColors.Window
		Me.txtPeakWidthMinimum.CausesValidation = True
		Me.txtPeakWidthMinimum.Enabled = True
		Me.txtPeakWidthMinimum.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPeakWidthMinimum.HideSelection = True
		Me.txtPeakWidthMinimum.ReadOnly = False
		Me.txtPeakWidthMinimum.Maxlength = 0
		Me.txtPeakWidthMinimum.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPeakWidthMinimum.MultiLine = False
		Me.txtPeakWidthMinimum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPeakWidthMinimum.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPeakWidthMinimum.TabStop = True
		Me.txtPeakWidthMinimum.Visible = True
		Me.txtPeakWidthMinimum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPeakWidthMinimum.Name = "txtPeakWidthMinimum"
		Me.lblSeriesNumber.Text = "Series Number"
		Me.lblSeriesNumber.Size = New System.Drawing.Size(89, 17)
		Me.lblSeriesNumber.Location = New System.Drawing.Point(8, 11)
		Me.lblSeriesNumber.TabIndex = 22
		Me.lblSeriesNumber.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblSeriesNumber.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblSeriesNumber.BackColor = System.Drawing.SystemColors.Control
		Me.lblSeriesNumber.Enabled = True
		Me.lblSeriesNumber.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblSeriesNumber.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblSeriesNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblSeriesNumber.UseMnemonic = True
		Me.lblSeriesNumber.Visible = True
		Me.lblSeriesNumber.AutoSize = False
		Me.lblSeriesNumber.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblSeriesNumber.Name = "lblSeriesNumber"
		Me.lblCaptionAngleLabel.Text = "degrees"
		Me.lblCaptionAngleLabel.Size = New System.Drawing.Size(45, 13)
		Me.lblCaptionAngleLabel.Location = New System.Drawing.Point(152, 152)
		Me.lblCaptionAngleLabel.TabIndex = 7
		Me.lblCaptionAngleLabel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCaptionAngleLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblCaptionAngleLabel.BackColor = System.Drawing.SystemColors.Control
		Me.lblCaptionAngleLabel.Enabled = True
		Me.lblCaptionAngleLabel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblCaptionAngleLabel.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCaptionAngleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCaptionAngleLabel.UseMnemonic = True
		Me.lblCaptionAngleLabel.Visible = True
		Me.lblCaptionAngleLabel.AutoSize = False
		Me.lblCaptionAngleLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCaptionAngleLabel.Name = "lblCaptionAngleLabel"
		Me.lblMininumIntensityInstructions.Text = "Min intensity explanation ..."
		Me.lblMininumIntensityInstructions.Size = New System.Drawing.Size(157, 61)
		Me.lblMininumIntensityInstructions.Location = New System.Drawing.Point(200, 184)
		Me.lblMininumIntensityInstructions.TabIndex = 10
		Me.lblMininumIntensityInstructions.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMininumIntensityInstructions.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMininumIntensityInstructions.BackColor = System.Drawing.SystemColors.Control
		Me.lblMininumIntensityInstructions.Enabled = True
		Me.lblMininumIntensityInstructions.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMininumIntensityInstructions.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMininumIntensityInstructions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMininumIntensityInstructions.UseMnemonic = True
		Me.lblMininumIntensityInstructions.Visible = True
		Me.lblMininumIntensityInstructions.AutoSize = False
		Me.lblMininumIntensityInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMininumIntensityInstructions.Name = "lblMininumIntensityInstructions"
		Me.lblPercentLabel.Text = "%"
		Me.lblPercentLabel.Size = New System.Drawing.Size(29, 13)
		Me.lblPercentLabel.Location = New System.Drawing.Point(152, 224)
		Me.lblPercentLabel.TabIndex = 13
		Me.lblPercentLabel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPercentLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPercentLabel.BackColor = System.Drawing.SystemColors.Control
		Me.lblPercentLabel.Enabled = True
		Me.lblPercentLabel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPercentLabel.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPercentLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPercentLabel.UseMnemonic = True
		Me.lblPercentLabel.Visible = True
		Me.lblPercentLabel.AutoSize = False
		Me.lblPercentLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPercentLabel.Name = "lblPercentLabel"
		Me.lblMinimumIntensityFractionOfMaximum.Text = "Minimum Intensity Percent of Max"
		Me.lblMinimumIntensityFractionOfMaximum.Size = New System.Drawing.Size(93, 29)
		Me.lblMinimumIntensityFractionOfMaximum.Location = New System.Drawing.Point(8, 216)
		Me.lblMinimumIntensityFractionOfMaximum.TabIndex = 11
		Me.lblMinimumIntensityFractionOfMaximum.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMinimumIntensityFractionOfMaximum.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMinimumIntensityFractionOfMaximum.BackColor = System.Drawing.SystemColors.Control
		Me.lblMinimumIntensityFractionOfMaximum.Enabled = True
		Me.lblMinimumIntensityFractionOfMaximum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMinimumIntensityFractionOfMaximum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMinimumIntensityFractionOfMaximum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMinimumIntensityFractionOfMaximum.UseMnemonic = True
		Me.lblMinimumIntensityFractionOfMaximum.Visible = True
		Me.lblMinimumIntensityFractionOfMaximum.AutoSize = False
		Me.lblMinimumIntensityFractionOfMaximum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMinimumIntensityFractionOfMaximum.Name = "lblMinimumIntensityFractionOfMaximum"
		Me.lblCaptionAngle.Text = "Caption Angle"
		Me.lblCaptionAngle.Size = New System.Drawing.Size(93, 21)
		Me.lblCaptionAngle.Location = New System.Drawing.Point(8, 154)
		Me.lblCaptionAngle.TabIndex = 5
		Me.lblCaptionAngle.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCaptionAngle.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblCaptionAngle.BackColor = System.Drawing.SystemColors.Control
		Me.lblCaptionAngle.Enabled = True
		Me.lblCaptionAngle.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblCaptionAngle.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblCaptionAngle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblCaptionAngle.UseMnemonic = True
		Me.lblCaptionAngle.Visible = True
		Me.lblCaptionAngle.AutoSize = False
		Me.lblCaptionAngle.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblCaptionAngle.Name = "lblCaptionAngle"
		Me.lblMaximumPeaksToLabel.Text = "Maximum Peaks to Label"
		Me.lblMaximumPeaksToLabel.Size = New System.Drawing.Size(81, 29)
		Me.lblMaximumPeaksToLabel.Location = New System.Drawing.Point(8, 280)
		Me.lblMaximumPeaksToLabel.TabIndex = 16
		Me.lblMaximumPeaksToLabel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMaximumPeaksToLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblMaximumPeaksToLabel.BackColor = System.Drawing.SystemColors.Control
		Me.lblMaximumPeaksToLabel.Enabled = True
		Me.lblMaximumPeaksToLabel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblMaximumPeaksToLabel.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblMaximumPeaksToLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblMaximumPeaksToLabel.UseMnemonic = True
		Me.lblMaximumPeaksToLabel.Visible = True
		Me.lblMaximumPeaksToLabel.AutoSize = False
		Me.lblMaximumPeaksToLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblMaximumPeaksToLabel.Name = "lblMaximumPeaksToLabel"
		Me.lblDirections.Text = "Warning ..."
		Me.lblDirections.Size = New System.Drawing.Size(345, 81)
		Me.lblDirections.Location = New System.Drawing.Point(8, 320)
		Me.lblDirections.TabIndex = 18
		Me.lblDirections.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblDirections.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblDirections.BackColor = System.Drawing.SystemColors.Control
		Me.lblDirections.Enabled = True
		Me.lblDirections.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblDirections.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblDirections.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblDirections.UseMnemonic = True
		Me.lblDirections.Visible = True
		Me.lblDirections.AutoSize = False
		Me.lblDirections.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblDirections.Name = "lblDirections"
		Me.lblThresholdMinimum.Text = "Minimum &Intensity Threshold"
		Me.lblThresholdMinimum.Size = New System.Drawing.Size(93, 29)
		Me.lblThresholdMinimum.Location = New System.Drawing.Point(8, 184)
		Me.lblThresholdMinimum.TabIndex = 8
		Me.lblThresholdMinimum.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblThresholdMinimum.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblThresholdMinimum.BackColor = System.Drawing.SystemColors.Control
		Me.lblThresholdMinimum.Enabled = True
		Me.lblThresholdMinimum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblThresholdMinimum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblThresholdMinimum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblThresholdMinimum.UseMnemonic = True
		Me.lblThresholdMinimum.Visible = True
		Me.lblThresholdMinimum.AutoSize = False
		Me.lblThresholdMinimum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblThresholdMinimum.Name = "lblThresholdMinimum"
		Me.lblPeakWidthMinimum.Text = "Minimum Peak &Width (Points)"
		Me.lblPeakWidthMinimum.Size = New System.Drawing.Size(89, 29)
		Me.lblPeakWidthMinimum.Location = New System.Drawing.Point(8, 248)
		Me.lblPeakWidthMinimum.TabIndex = 14
		Me.lblPeakWidthMinimum.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPeakWidthMinimum.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblPeakWidthMinimum.BackColor = System.Drawing.SystemColors.Control
		Me.lblPeakWidthMinimum.Enabled = True
		Me.lblPeakWidthMinimum.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblPeakWidthMinimum.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblPeakWidthMinimum.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblPeakWidthMinimum.UseMnemonic = True
		Me.lblPeakWidthMinimum.Visible = True
		Me.lblPeakWidthMinimum.AutoSize = False
		Me.lblPeakWidthMinimum.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblPeakWidthMinimum.Name = "lblPeakWidthMinimum"
		Me.Controls.Add(cboSeriesNumber)
		Me.Controls.Add(txtMinimumIntensityPercentageOfMaximum)
		Me.Controls.Add(txtCaptionAngle)
		Me.Controls.Add(txtMaximumPeaksToLabel)
		Me.Controls.Add(chkHideInDenseRegions)
		Me.Controls.Add(chkIncludeArrow)
		Me.Controls.Add(chkDisplayYPos)
		Me.Controls.Add(chkDisplayXPos)
		Me.Controls.Add(cboDataMode)
		Me.Controls.Add(txtThresholdMinimum)
		Me.Controls.Add(cmdAutoLabel)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(txtPeakWidthMinimum)
		Me.Controls.Add(lblSeriesNumber)
		Me.Controls.Add(lblCaptionAngleLabel)
		Me.Controls.Add(lblMininumIntensityInstructions)
		Me.Controls.Add(lblPercentLabel)
		Me.Controls.Add(lblMinimumIntensityFractionOfMaximum)
		Me.Controls.Add(lblCaptionAngle)
		Me.Controls.Add(lblMaximumPeaksToLabel)
		Me.Controls.Add(lblDirections)
		Me.Controls.Add(lblThresholdMinimum)
		Me.Controls.Add(lblPeakWidthMinimum)
	End Sub
#End Region 
    ''#Region "Upgrade Support "
    ''	Private Shared m_vb6FormDefInstance As frmAutoLabelPeaks
    ''	Private Shared m_InitializingDefInstance As Boolean
    ''	Public Shared Property DefInstance() As frmAutoLabelPeaks
    ''		Get
    ''			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
    ''				m_InitializingDefInstance = True
    ''				m_vb6FormDefInstance = New frmAutoLabelPeaks()
    ''				m_InitializingDefInstance = False
    ''			End If
    ''			DefInstance = m_vb6FormDefInstance
    ''		End Get
    ''		Set
    ''			m_vb6FormDefInstance = Value
    ''		End Set
    ''	End Property
    ''#End Region 
	
	Private mRecentOptions As udtAutoLabelPeaksOptionsInternalType
	
	Private mCWGraphControl As CWGraphControl
	
	Private Sub AutoLabelPeaks()
		Dim blnForceAsContinuousData, blnForceAsDiscreteData As Boolean
		
		cmdAutoLabel.Enabled = False
		
		With mCWGraphControl
            .SetPeakDetectIntensityThresholdCounts(SharedVBNetRoutines.VBNetRoutines.CDblSafe(txtThresholdMinimum.Text))
            .SetPeakDetectIntensityThresholdPercentageOfMaximum(SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtMinimumIntensityPercentageOfMaximum.Text))
            .SetPeakDetectWidthPointsMinimum(SharedVBNetRoutines.VBNetRoutines.CDblSafe(txtPeakWidthMinimum.Text))
			
			If cboDataMode.SelectedIndex = modCWSpectrum.dmDataModeConstants.dmContinuous Then
				blnForceAsContinuousData = True
			Else
				blnForceAsDiscreteData = True
			End If
			
            .AutoLabelPeaks(cboSeriesNumber.SelectedIndex + 1, chkDisplayXPos.Checked, chkDisplayYPos.Checked, SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtCaptionAngle.Text), chkIncludeArrow.Checked, chkHideInDenseRegions.Checked, SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtMaximumPeaksToLabel.Text), blnForceAsContinuousData, blnForceAsDiscreteData)

        End With

        UpdateCurrentSettings()

        cmdAutoLabel.Enabled = True
        cmdClose.Focus()

    End Sub

    Public Function InitializeForm(ByRef ctlCallingControl As CWGraphControl, ByRef intSeriesIndex As Short) As Boolean
        Dim strDirections As String
        Dim udtAutoLabelOptions As udtAutoLabelPeaksOptionsInternalType

        On Error GoTo InitializeFormErrorHandler

        If mCWGraphControl Is Nothing Then
            mCWGraphControl = ctlCallingControl
        End If

        PopulateComboBoxes()

        strDirections = "Peaks in the given series will be located and automatically labeled using the X position, Y position, or both."
        strDirections = strDirections & "  In Discrete Data mode, every data point is labeled."
        strDirections = strDirections & "  In Continuous Data mode, the peaks are located and only the peak apexes labeled."
        strDirections = strDirections & "  You must provide a minimum peak intensity and minimum peak width (in number of data points per peak)."
        strDirections = strDirections & "  Note that existing annotations in the current series will be replaced."
        lblDirections.Text = strDirections

        strDirections = "The minimum intensity is the greater of the 'minimum intensity threshold' and the 'percent of maximum intensity' settings."
        lblMininumIntensityInstructions.Text = strDirections

        If intSeriesIndex >= 1 And intSeriesIndex <= mCWGraphControl.GetSeriesCount() Then

            AutoLabelOptionsRetrieve(udtAutoLabelOptions)

            With udtAutoLabelOptions
                txtCaptionAngle.Text = .CaptionAngle.ToString.Trim
                txtThresholdMinimum.Text = FormatNumberAsString(.IntensityThresholdMinimum, 12, 7)
                txtMinimumIntensityPercentageOfMaximum.Text = .MinimumIntensityPercentageOfMaximum.ToString.Trim
                txtPeakWidthMinimum.Text = .PeakWidthMinimumPoints.ToString.Trim
                txtMaximumPeaksToLabel.Text = .PeakLabelCountMaximum.ToString.Trim

                chkDisplayXPos.Checked = .DisplayXPos
                chkDisplayYPos.Checked = .DisplayYPos

                chkIncludeArrow.Checked = .IncludeArrow
                chkHideInDenseRegions.Checked = .HideInDenseRegions
            End With

            ' This should cascade to call UpdateDataMode
            cboSeriesNumber.SelectedIndex = intSeriesIndex - 1

            UpdateCurrentSettings()

            InitializeForm = True
        Else
            MsgBox("Invalid series number (" & intSeriesIndex.ToString.Trim & "); unable to auto-label peaks.", MsgBoxStyle.Information + MsgBoxStyle.OKOnly, "Error")
            InitializeForm = False
        End If

        Exit Function

InitializeFormErrorHandler:
        System.Diagnostics.Debug.WriteLine("Error occurred in frmAutoLabelPeaks.InitializeForm(): " & Err.Description)
        InitializeForm = False

    End Function

    Private Sub PopulateComboBoxes()

        Dim intSeriesNumber As Short

        With cboSeriesNumber
            .Items.Clear()
            For intSeriesNumber = 1 To mCWGraphControl.GetSeriesCount()
                .Items.Add("Series " & intSeriesNumber.ToString.Trim)
            Next intSeriesNumber
        End With

        With cboDataMode
            .Items.Clear()
            .Items.Add("Discrete Data Mode")
            .Items.Add("Continuous Data Mode")
            .SelectedIndex = modCWSpectrum.dmDataModeConstants.dmDiscrete
        End With

    End Sub

    Public Sub StoreAutoLabelSettingsInModule()
        AutoLabelOptionsStore(mRecentOptions)
    End Sub

    Private Sub ShowHideOptions()
        Dim blnShowContinuousDataControls As Boolean

        If cboDataMode.SelectedIndex = modCWSpectrum.dmDataModeConstants.dmContinuous Then
            blnShowContinuousDataControls = True
        Else
            blnShowContinuousDataControls = False
        End If

        txtPeakWidthMinimum.Visible = blnShowContinuousDataControls
        lblPeakWidthMinimum.Visible = blnShowContinuousDataControls
    End Sub

    Private Sub UpdateCurrentSettings()
        With mRecentOptions
            .DataMode = cboDataMode.SelectedIndex
            .DisplayXPos = chkDisplayXPos.Checked
            .DisplayYPos = chkDisplayYPos.Checked
            .IncludeArrow = chkIncludeArrow.Checked
            .HideInDenseRegions = chkHideInDenseRegions.Checked
            .CaptionAngle = SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtCaptionAngle.Text)
            .IntensityThresholdMinimum = SharedVBNetRoutines.VBNetRoutines.CDblSafe(txtThresholdMinimum.Text)
            .MinimumIntensityPercentageOfMaximum = SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtMinimumIntensityPercentageOfMaximum.Text)
            .PeakWidthMinimumPoints = SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtPeakWidthMinimum.Text)
            .PeakLabelCountMaximum = SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtMaximumPeaksToLabel.Text)
        End With
    End Sub

    Private Sub UpdateDataMode()
        Dim ePlotMode As CWGraphControl.pmPlotModeConstants

        ePlotMode = mCWGraphControl.GetSeriesPlotMode(cboSeriesNumber.SelectedIndex + 1)

        If ePlotMode = CWGraphControl.pmPlotModeConstants.pmLines Or ePlotMode = CWGraphControl.pmPlotModeConstants.pmPointsAndLines Then
            ' Continuous data
            cboDataMode.SelectedIndex = modCWSpectrum.dmDataModeConstants.dmContinuous
        Else
            cboDataMode.SelectedIndex = modCWSpectrum.dmDataModeConstants.dmDiscrete
        End If

    End Sub

    Private Sub cboDataMode_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboDataMode.SelectedIndexChanged
        ShowHideOptions()
    End Sub

    Private Sub cboSeriesNumber_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboSeriesNumber.SelectedIndexChanged
        UpdateDataMode()
    End Sub

    Private Sub cmdAutoLabel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAutoLabel.Click
        AutoLabelPeaks()
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        UpdateCurrentSettings()
        Me.Hide()
    End Sub

    Private Sub frmAutoLabelPeaks_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        SizeAndCenterWindow(Me, modCWSpectrum.wpcWindowPosContants.UpperThird, 370, 440)
    End Sub

    Private Sub frmAutoLabelPeaks_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
        mCWGraphControl = Nothing
    End Sub

    Private Sub txtCaptionAngle_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCaptionAngle.Enter
        TextBoxGotFocusHandler(txtCaptionAngle)
    End Sub

    Private Sub txtCaptionAngle_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCaptionAngle.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtCaptionAngle, eventArgs, True, False)
    End Sub

    Private Sub txtCaptionAngle_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtCaptionAngle.Leave
        SharedVBNetRoutines.VBNetRoutines.ValidateTextboxInt(txtCaptionAngle, 0, 360, 0)
    End Sub

    Private Sub txtMaximumPeaksToLabel_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMaximumPeaksToLabel.Enter
        TextBoxGotFocusHandler(txtMaximumPeaksToLabel)
    End Sub

    Private Sub txtMaximumPeaksToLabel_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMaximumPeaksToLabel.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtMaximumPeaksToLabel, eventArgs, True, False)
    End Sub

    Private Sub txtMaximumPeaksToLabel_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMaximumPeaksToLabel.Leave
        SharedVBNetRoutines.VBNetRoutines.ValidateTextboxInt(txtMaximumPeaksToLabel, 0, 100000, 1000)
    End Sub

    Private Sub txtMinimumIntensityPercentageOfMaximum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMinimumIntensityPercentageOfMaximum.Enter
        TextBoxGotFocusHandler(txtMinimumIntensityPercentageOfMaximum)
    End Sub

    Private Sub txtMinimumIntensityPercentageOfMaximum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMinimumIntensityPercentageOfMaximum.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtMinimumIntensityPercentageOfMaximum, eventArgs, True, False)
    End Sub

    Private Sub txtMinimumIntensityPercentageOfMaximum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMinimumIntensityPercentageOfMaximum.Leave
        SharedVBNetRoutines.VBNetRoutines.ValidateTextboxInt(txtMinimumIntensityPercentageOfMaximum, 0, 100, 0)
    End Sub

    Private Sub txtPeakWidthMinimum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPeakWidthMinimum.Enter
        TextBoxGotFocusHandler(txtPeakWidthMinimum)
    End Sub

    Private Sub txtPeakWidthMinimum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPeakWidthMinimum.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtPeakWidthMinimum, eventArgs, True, False)
    End Sub

    Private Sub txtPeakWidthMinimum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPeakWidthMinimum.Leave
        SharedVBNetRoutines.VBNetRoutines.ValidateTextboxSng(txtPeakWidthMinimum, 0, 100000000.0#, 5)
    End Sub

    Private Sub txtThresholdMinimum_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtThresholdMinimum.Enter
        TextBoxGotFocusHandler(txtThresholdMinimum)
    End Sub

    Private Sub txtThresholdMinimum_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtThresholdMinimum.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtThresholdMinimum, eventArgs, True, True, True, False, True, False, False, False, False, True)
    End Sub

    Private Sub txtThresholdMinimum_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtThresholdMinimum.Leave
        SharedVBNetRoutines.VBNetRoutines.ValidateTextboxSng(txtThresholdMinimum, -1.0E+38, 1.0E+38, 0)
    End Sub
End Class