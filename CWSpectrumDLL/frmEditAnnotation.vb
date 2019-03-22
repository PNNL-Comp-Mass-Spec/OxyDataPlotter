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

Friend Class frmEditAnnotation
	Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        mComponentsInitialized = True
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
    Public WithEvents scrDataPointSelection As System.Windows.Forms.HScrollBar
    Public WithEvents txtPointToBindTo As System.Windows.Forms.TextBox
    Public WithEvents cboAnnotationSnapMode As System.Windows.Forms.ComboBox
    Public WithEvents chkShowArrow As System.Windows.Forms.CheckBox
    Public WithEvents chkHideInCrowdedRegions As System.Windows.Forms.CheckBox
    Public WithEvents cboSeriesNumber As System.Windows.Forms.ComboBox
    Public WithEvents txtYPos As System.Windows.Forms.TextBox
    Public WithEvents txtXPos As System.Windows.Forms.TextBox
    Public WithEvents lblPointToBind As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents lblSeriesNumber As System.Windows.Forms.Label
    Public WithEvents lblYPos As System.Windows.Forms.Label
    Public WithEvents lblXPos As System.Windows.Forms.Label
    Public WithEvents fraPosition As System.Windows.Forms.GroupBox
    Public WithEvents chkAnnotationShowsNearestPointY As System.Windows.Forms.CheckBox
    Public WithEvents chkAnnotationShowsNearestPointX As System.Windows.Forms.CheckBox
    Public WithEvents txtCaptionAngle As System.Windows.Forms.TextBox
    Public WithEvents txtCaption As System.Windows.Forms.TextBox
    Public WithEvents lblRotationUnits As System.Windows.Forms.Label
    Public WithEvents lblCaptionAngle As System.Windows.Forms.Label
    Public WithEvents lblCaption As System.Windows.Forms.Label
    Public WithEvents fraCaptionOptions As System.Windows.Forms.GroupBox
    Public WithEvents cmdRemove As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOK As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraPosition = New System.Windows.Forms.GroupBox
        Me.scrDataPointSelection = New System.Windows.Forms.HScrollBar
        Me.txtPointToBindTo = New System.Windows.Forms.TextBox
        Me.cboAnnotationSnapMode = New System.Windows.Forms.ComboBox
        Me.chkShowArrow = New System.Windows.Forms.CheckBox
        Me.chkHideInCrowdedRegions = New System.Windows.Forms.CheckBox
        Me.cboSeriesNumber = New System.Windows.Forms.ComboBox
        Me.txtYPos = New System.Windows.Forms.TextBox
        Me.txtXPos = New System.Windows.Forms.TextBox
        Me.lblPointToBind = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSeriesNumber = New System.Windows.Forms.Label
        Me.lblYPos = New System.Windows.Forms.Label
        Me.lblXPos = New System.Windows.Forms.Label
        Me.fraCaptionOptions = New System.Windows.Forms.GroupBox
        Me.chkAnnotationShowsNearestPointY = New System.Windows.Forms.CheckBox
        Me.chkAnnotationShowsNearestPointX = New System.Windows.Forms.CheckBox
        Me.txtCaptionAngle = New System.Windows.Forms.TextBox
        Me.txtCaption = New System.Windows.Forms.TextBox
        Me.lblRotationUnits = New System.Windows.Forms.Label
        Me.lblCaptionAngle = New System.Windows.Forms.Label
        Me.lblCaption = New System.Windows.Forms.Label
        Me.cmdRemove = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.fraPosition.SuspendLayout()
        Me.fraCaptionOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraPosition
        '
        Me.fraPosition.BackColor = System.Drawing.SystemColors.Control
        Me.fraPosition.Controls.Add(Me.scrDataPointSelection)
        Me.fraPosition.Controls.Add(Me.txtPointToBindTo)
        Me.fraPosition.Controls.Add(Me.cboAnnotationSnapMode)
        Me.fraPosition.Controls.Add(Me.chkShowArrow)
        Me.fraPosition.Controls.Add(Me.chkHideInCrowdedRegions)
        Me.fraPosition.Controls.Add(Me.cboSeriesNumber)
        Me.fraPosition.Controls.Add(Me.txtYPos)
        Me.fraPosition.Controls.Add(Me.txtXPos)
        Me.fraPosition.Controls.Add(Me.lblPointToBind)
        Me.fraPosition.Controls.Add(Me.Label1)
        Me.fraPosition.Controls.Add(Me.lblSeriesNumber)
        Me.fraPosition.Controls.Add(Me.lblYPos)
        Me.fraPosition.Controls.Add(Me.lblXPos)
        Me.fraPosition.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPosition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPosition.Location = New System.Drawing.Point(8, 128)
        Me.fraPosition.Name = "fraPosition"
        Me.fraPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraPosition.Size = New System.Drawing.Size(345, 193)
        Me.fraPosition.TabIndex = 8
        Me.fraPosition.TabStop = False
        Me.fraPosition.Text = "Caption Position and Visibility"
        '
        'scrDataPointSelection
        '
        Me.scrDataPointSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.scrDataPointSelection.LargeChange = 1
        Me.scrDataPointSelection.Location = New System.Drawing.Point(176, 122)
        Me.scrDataPointSelection.Maximum = 32767
        Me.scrDataPointSelection.Name = "scrDataPointSelection"
        Me.scrDataPointSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.scrDataPointSelection.Size = New System.Drawing.Size(161, 17)
        Me.scrDataPointSelection.TabIndex = 25
        Me.scrDataPointSelection.TabStop = True
        '
        'txtPointToBindTo
        '
        Me.txtPointToBindTo.AcceptsReturn = True
        Me.txtPointToBindTo.AutoSize = False
        Me.txtPointToBindTo.BackColor = System.Drawing.SystemColors.Window
        Me.txtPointToBindTo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPointToBindTo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPointToBindTo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPointToBindTo.Location = New System.Drawing.Point(120, 120)
        Me.txtPointToBindTo.MaxLength = 0
        Me.txtPointToBindTo.Name = "txtPointToBindTo"
        Me.txtPointToBindTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPointToBindTo.Size = New System.Drawing.Size(49, 20)
        Me.txtPointToBindTo.TabIndex = 23
        Me.txtPointToBindTo.Text = "0"
        '
        'cboAnnotationSnapMode
        '
        Me.cboAnnotationSnapMode.BackColor = System.Drawing.SystemColors.Window
        Me.cboAnnotationSnapMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboAnnotationSnapMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnnotationSnapMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnnotationSnapMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboAnnotationSnapMode.Location = New System.Drawing.Point(120, 96)
        Me.cboAnnotationSnapMode.Name = "cboAnnotationSnapMode"
        Me.cboAnnotationSnapMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboAnnotationSnapMode.Size = New System.Drawing.Size(153, 22)
        Me.cboAnnotationSnapMode.TabIndex = 16
        '
        'chkShowArrow
        '
        Me.chkShowArrow.BackColor = System.Drawing.SystemColors.Control
        Me.chkShowArrow.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkShowArrow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowArrow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkShowArrow.Location = New System.Drawing.Point(120, 152)
        Me.chkShowArrow.Name = "chkShowArrow"
        Me.chkShowArrow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkShowArrow.Size = New System.Drawing.Size(193, 17)
        Me.chkShowArrow.TabIndex = 17
        Me.chkShowArrow.Text = "Show &Arrow"
        '
        'chkHideInCrowdedRegions
        '
        Me.chkHideInCrowdedRegions.BackColor = System.Drawing.SystemColors.Control
        Me.chkHideInCrowdedRegions.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkHideInCrowdedRegions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHideInCrowdedRegions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkHideInCrowdedRegions.Location = New System.Drawing.Point(120, 168)
        Me.chkHideInCrowdedRegions.Name = "chkHideInCrowdedRegions"
        Me.chkHideInCrowdedRegions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkHideInCrowdedRegions.Size = New System.Drawing.Size(193, 17)
        Me.chkHideInCrowdedRegions.TabIndex = 18
        Me.chkHideInCrowdedRegions.Text = "&Hide in Crowded Regions"
        '
        'cboSeriesNumber
        '
        Me.cboSeriesNumber.BackColor = System.Drawing.SystemColors.Window
        Me.cboSeriesNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboSeriesNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSeriesNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSeriesNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSeriesNumber.Location = New System.Drawing.Point(120, 72)
        Me.cboSeriesNumber.Name = "cboSeriesNumber"
        Me.cboSeriesNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboSeriesNumber.Size = New System.Drawing.Size(153, 22)
        Me.cboSeriesNumber.TabIndex = 14
        '
        'txtYPos
        '
        Me.txtYPos.AcceptsReturn = True
        Me.txtYPos.AutoSize = False
        Me.txtYPos.BackColor = System.Drawing.SystemColors.Window
        Me.txtYPos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtYPos.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYPos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtYPos.Location = New System.Drawing.Point(120, 48)
        Me.txtYPos.MaxLength = 0
        Me.txtYPos.Name = "txtYPos"
        Me.txtYPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtYPos.Size = New System.Drawing.Size(81, 20)
        Me.txtYPos.TabIndex = 12
        Me.txtYPos.Text = "0"
        '
        'txtXPos
        '
        Me.txtXPos.AcceptsReturn = True
        Me.txtXPos.AutoSize = False
        Me.txtXPos.BackColor = System.Drawing.SystemColors.Window
        Me.txtXPos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtXPos.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXPos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtXPos.Location = New System.Drawing.Point(120, 24)
        Me.txtXPos.MaxLength = 0
        Me.txtXPos.Name = "txtXPos"
        Me.txtXPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtXPos.Size = New System.Drawing.Size(81, 20)
        Me.txtXPos.TabIndex = 10
        Me.txtXPos.Text = "0"
        '
        'lblPointToBind
        '
        Me.lblPointToBind.BackColor = System.Drawing.SystemColors.Control
        Me.lblPointToBind.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPointToBind.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPointToBind.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPointToBind.Location = New System.Drawing.Point(8, 122)
        Me.lblPointToBind.Name = "lblPointToBind"
        Me.lblPointToBind.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPointToBind.Size = New System.Drawing.Size(105, 17)
        Me.lblPointToBind.TabIndex = 24
        Me.lblPointToBind.Text = "Point to Bind to"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Snap Mode"
        '
        'lblSeriesNumber
        '
        Me.lblSeriesNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblSeriesNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSeriesNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeriesNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeriesNumber.Location = New System.Drawing.Point(8, 75)
        Me.lblSeriesNumber.Name = "lblSeriesNumber"
        Me.lblSeriesNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSeriesNumber.Size = New System.Drawing.Size(89, 17)
        Me.lblSeriesNumber.TabIndex = 13
        Me.lblSeriesNumber.Text = "Series Number"
        '
        'lblYPos
        '
        Me.lblYPos.BackColor = System.Drawing.SystemColors.Control
        Me.lblYPos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblYPos.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYPos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblYPos.Location = New System.Drawing.Point(8, 50)
        Me.lblYPos.Name = "lblYPos"
        Me.lblYPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblYPos.Size = New System.Drawing.Size(105, 17)
        Me.lblYPos.TabIndex = 11
        Me.lblYPos.Text = "&Y Position"
        '
        'lblXPos
        '
        Me.lblXPos.BackColor = System.Drawing.SystemColors.Control
        Me.lblXPos.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblXPos.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXPos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblXPos.Location = New System.Drawing.Point(8, 26)
        Me.lblXPos.Name = "lblXPos"
        Me.lblXPos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXPos.Size = New System.Drawing.Size(105, 17)
        Me.lblXPos.TabIndex = 9
        Me.lblXPos.Text = "&X Position"
        '
        'fraCaptionOptions
        '
        Me.fraCaptionOptions.BackColor = System.Drawing.SystemColors.Control
        Me.fraCaptionOptions.Controls.Add(Me.chkAnnotationShowsNearestPointY)
        Me.fraCaptionOptions.Controls.Add(Me.chkAnnotationShowsNearestPointX)
        Me.fraCaptionOptions.Controls.Add(Me.txtCaptionAngle)
        Me.fraCaptionOptions.Controls.Add(Me.txtCaption)
        Me.fraCaptionOptions.Controls.Add(Me.lblRotationUnits)
        Me.fraCaptionOptions.Controls.Add(Me.lblCaptionAngle)
        Me.fraCaptionOptions.Controls.Add(Me.lblCaption)
        Me.fraCaptionOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCaptionOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCaptionOptions.Location = New System.Drawing.Point(8, 8)
        Me.fraCaptionOptions.Name = "fraCaptionOptions"
        Me.fraCaptionOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraCaptionOptions.Size = New System.Drawing.Size(345, 113)
        Me.fraCaptionOptions.TabIndex = 0
        Me.fraCaptionOptions.TabStop = False
        Me.fraCaptionOptions.Text = "Caption &Options"
        '
        'chkAnnotationShowsNearestPointY
        '
        Me.chkAnnotationShowsNearestPointY.BackColor = System.Drawing.SystemColors.Control
        Me.chkAnnotationShowsNearestPointY.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAnnotationShowsNearestPointY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnnotationShowsNearestPointY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAnnotationShowsNearestPointY.Location = New System.Drawing.Point(120, 56)
        Me.chkAnnotationShowsNearestPointY.Name = "chkAnnotationShowsNearestPointY"
        Me.chkAnnotationShowsNearestPointY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAnnotationShowsNearestPointY.Size = New System.Drawing.Size(217, 17)
        Me.chkAnnotationShowsNearestPointY.TabIndex = 4
        Me.chkAnnotationShowsNearestPointY.Text = "Caption Displays Y"
        '
        'chkAnnotationShowsNearestPointX
        '
        Me.chkAnnotationShowsNearestPointX.BackColor = System.Drawing.SystemColors.Control
        Me.chkAnnotationShowsNearestPointX.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAnnotationShowsNearestPointX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnnotationShowsNearestPointX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAnnotationShowsNearestPointX.Location = New System.Drawing.Point(120, 40)
        Me.chkAnnotationShowsNearestPointX.Name = "chkAnnotationShowsNearestPointX"
        Me.chkAnnotationShowsNearestPointX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAnnotationShowsNearestPointX.Size = New System.Drawing.Size(217, 17)
        Me.chkAnnotationShowsNearestPointX.TabIndex = 3
        Me.chkAnnotationShowsNearestPointX.Text = "Caption Displays X"
        '
        'txtCaptionAngle
        '
        Me.txtCaptionAngle.AcceptsReturn = True
        Me.txtCaptionAngle.AutoSize = False
        Me.txtCaptionAngle.BackColor = System.Drawing.SystemColors.Window
        Me.txtCaptionAngle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCaptionAngle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaptionAngle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCaptionAngle.Location = New System.Drawing.Point(120, 80)
        Me.txtCaptionAngle.MaxLength = 0
        Me.txtCaptionAngle.Name = "txtCaptionAngle"
        Me.txtCaptionAngle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCaptionAngle.Size = New System.Drawing.Size(49, 20)
        Me.txtCaptionAngle.TabIndex = 6
        Me.txtCaptionAngle.Text = "0"
        '
        'txtCaption
        '
        Me.txtCaption.AcceptsReturn = True
        Me.txtCaption.AutoSize = False
        Me.txtCaption.BackColor = System.Drawing.SystemColors.Window
        Me.txtCaption.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCaption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCaption.Location = New System.Drawing.Point(120, 16)
        Me.txtCaption.MaxLength = 0
        Me.txtCaption.Name = "txtCaption"
        Me.txtCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCaption.Size = New System.Drawing.Size(217, 20)
        Me.txtCaption.TabIndex = 2
        Me.txtCaption.Text = ""
        '
        'lblRotationUnits
        '
        Me.lblRotationUnits.BackColor = System.Drawing.SystemColors.Control
        Me.lblRotationUnits.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblRotationUnits.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRotationUnits.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRotationUnits.Location = New System.Drawing.Point(176, 84)
        Me.lblRotationUnits.Name = "lblRotationUnits"
        Me.lblRotationUnits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRotationUnits.Size = New System.Drawing.Size(105, 17)
        Me.lblRotationUnits.TabIndex = 7
        Me.lblRotationUnits.Text = "degrees"
        '
        'lblCaptionAngle
        '
        Me.lblCaptionAngle.BackColor = System.Drawing.SystemColors.Control
        Me.lblCaptionAngle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCaptionAngle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaptionAngle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCaptionAngle.Location = New System.Drawing.Point(8, 82)
        Me.lblCaptionAngle.Name = "lblCaptionAngle"
        Me.lblCaptionAngle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCaptionAngle.Size = New System.Drawing.Size(105, 17)
        Me.lblCaptionAngle.TabIndex = 5
        Me.lblCaptionAngle.Text = "Rotation"
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.SystemColors.Control
        Me.lblCaption.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCaption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCaption.Location = New System.Drawing.Point(8, 18)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCaption.Size = New System.Drawing.Size(105, 17)
        Me.lblCaption.TabIndex = 1
        Me.lblCaption.Text = "Caption"
        '
        'cmdRemove
        '
        Me.cmdRemove.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRemove.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRemove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRemove.Location = New System.Drawing.Point(368, 80)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRemove.Size = New System.Drawing.Size(73, 33)
        Me.cmdRemove.TabIndex = 21
        Me.cmdRemove.Tag = "9020"
        Me.cmdRemove.Text = "&Remove"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(368, 48)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 20
        Me.cmdCancel.Tag = "4020"
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(368, 16)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(73, 25)
        Me.cmdOK.TabIndex = 19
        Me.cmdOK.Tag = "4010"
        Me.cmdOK.Text = "&OK"
        '
        'frmEditAnnotation
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(452, 331)
        Me.ControlBox = False
        Me.Controls.Add(Me.fraPosition)
        Me.Controls.Add(Me.fraCaptionOptions)
        Me.Controls.Add(Me.cmdRemove)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 24)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditAnnotation"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Edit Annotation"
        Me.fraPosition.ResumeLayout(False)
        Me.fraCaptionOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private mComponentsInitialized As Boolean

    Private Structure udtAnnotationDetailsType
        Dim AnnotationIndex As Integer
        Dim CaptionXPos As Double
        Dim CaptionYPos As Double
        Dim CaptionText As String
        Dim CaptionAngle As Integer
        Dim SeriesNumber As Short
        Dim SnapMode As CWGraphControl.asmAnnotationSnapModeConstants
        Dim PointNumberToBind As Integer
        Dim AnnotationShowsNearestPointX As Boolean
        Dim AnnotationShowsNearestPointY As Boolean
        Dim IncludeArrow As Boolean
        Dim HideInDenseRegions As Boolean
    End Structure

    Private udtAnnotationSaved As udtAnnotationDetailsType
    Private udtAnnotationNew As udtAnnotationDetailsType

    Private mUpdatingControls As Boolean
    Private mOriginalCaption As String

    Private mCWGraphControl As CWGraphControl

    Private Function GetDynamicCaptionText(ByRef udtAnnotationDetails As udtAnnotationDetailsType) As String
        Dim blnBindToPoint As Boolean

        With udtAnnotationDetails
            If .AnnotationShowsNearestPointX Or .AnnotationShowsNearestPointY Then
                If .SnapMode = CWGraphControl.asmAnnotationSnapModeConstants.asmFloating Then
                    blnBindToPoint = False
                Else
                    blnBindToPoint = True
                End If
                GetDynamicCaptionText = mCWGraphControl.GenerateAnnotationUsingNearestPoint(.CaptionXPos, .CaptionYPos, .SeriesNumber, .AnnotationShowsNearestPointX, .AnnotationShowsNearestPointY, blnBindToPoint, .CaptionText, .PointNumberToBind)
            Else
                ' Caption is not dynamic, return text in txtCaption
                GetDynamicCaptionText = txtCaption.Text
            End If
        End With

    End Function

    Public Function InitializeForm(ByRef ctlCallingControl As CWGraphControl, ByRef lngAnnotationIndex As Integer, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, Optional ByRef strCaptionText As String = "", Optional ByRef lngCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Short = 1, Optional ByRef eSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional ByRef lngPointNumberToBind As Integer = 0, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = False) As Boolean

        On Error GoTo InitializeFormErrorHandler

        If mCWGraphControl Is Nothing Then
            mCWGraphControl = ctlCallingControl
        End If

        PopulateComboBoxes()
        UpdateDynamicControls()

        mUpdatingControls = True

        With mCWGraphControl
            If intSeriesNumber < 1 Or intSeriesNumber > .GetSeriesCount() Then intSeriesNumber = 1
            cboSeriesNumber.SelectedIndex = intSeriesNumber - 1

            If lngAnnotationIndex < 1 Or lngAnnotationIndex > .GetAnnotationCount() Then
                ' Use defaults
                ' Disable cmdRemove
                cmdRemove.Enabled = False
                udtAnnotationSaved.AnnotationIndex = 0
            Else
                If Not .GetAnnotationByIndex(lngAnnotationIndex, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions) Then
                    udtAnnotationSaved.AnnotationIndex = 0
                    cmdRemove.Enabled = False
                Else
                    udtAnnotationSaved.AnnotationIndex = lngAnnotationIndex
                    cmdRemove.Enabled = True

                    If eSnapMode = CWGraphControl.asmAnnotationSnapModeConstants.asmFloating Then
                        lngPointNumberToBind = -1
                    Else
                        lngPointNumberToBind = lngPointNumberToBind
                    End If
                End If
            End If
        End With

        With udtAnnotationSaved
            .CaptionXPos = CaptionXPos
            .CaptionYPos = CaptionYPos
            .CaptionText = strCaptionText
            mOriginalCaption = strCaptionText
            .CaptionAngle = lngCaptionAngle
            .SeriesNumber = intSeriesNumber
            .SnapMode = eSnapMode
            .PointNumberToBind = lngPointNumberToBind
            .AnnotationShowsNearestPointX = blnAnnotationShowsNearestPointX
            .AnnotationShowsNearestPointY = blnAnnotationShowsNearestPointY
            .IncludeArrow = blnIncludeArrow
            .HideInDenseRegions = blnHideInDenseRegions
        End With

        udtAnnotationNew = udtAnnotationSaved
        mUpdatingControls = False

        ShowCurrentOptions()

        InitializeForm = True
        Exit Function

InitializeFormErrorHandler:
        MsgBox("Error in frmEditAnnotation.InitializeForm:" & vbCrLf & Err.Description, MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, "Error")
        InitializeForm = False

    End Function

    Private Sub InitializeScrollBar(ByRef lngMin As Integer, ByRef lngMax As Integer)
        Dim NewLargeChange As Short

        On Error Resume Next

        If lngMax < lngMin Then lngMax = lngMin

        With scrDataPointSelection
            .Minimum = lngMin
            .Maximum = (lngMax + .LargeChange - 1)

            NewLargeChange = ((.Maximum - .LargeChange + 1) - .Minimum) / 20
            .Maximum = .Maximum + NewLargeChange - .LargeChange
            .LargeChange = NewLargeChange
            .SmallChange = 1
        End With
    End Sub

    Private Sub PopulateComboBoxes()
        Dim intSeriesNumber As Short

        If mUpdatingControls Then Exit Sub
        mUpdatingControls = True

        With cboSeriesNumber
            .Items.Clear()
            For intSeriesNumber = 1 To mCWGraphControl.GetSeriesCount()
                .Items.Add("Series " & intSeriesNumber.ToString.Trim)
            Next intSeriesNumber
        End With

        With cboAnnotationSnapMode
            .Items.Clear()
            .Items.Add("Bind to any data point")
            .Items.Add("Bind to specific point")
            .Items.Add("Freely floating")
            .SelectedIndex = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint
        End With

        mUpdatingControls = False
    End Sub

    Private Sub ShowCurrentOptions()

        On Error GoTo ShowCurrentOptionsErrorHandler

        If mUpdatingControls Then Exit Sub
        mUpdatingControls = True

        With udtAnnotationNew
            txtXPos.Text = FormatNumberAsString(.CaptionXPos, 12)
            txtYPos.Text = FormatNumberAsString(.CaptionYPos, 12)

            If .SeriesNumber < 1 Or .SeriesNumber > cboSeriesNumber.Items.Count Then .SeriesNumber = 1
            If cboSeriesNumber.Items.Count > 0 Then
                cboSeriesNumber.SelectedIndex = .SeriesNumber - 1
            End If

            chkAnnotationShowsNearestPointX.Checked = .AnnotationShowsNearestPointX
            chkAnnotationShowsNearestPointY.Checked = .AnnotationShowsNearestPointY

            InitializeScrollBar(0, mCWGraphControl.GetDataCount(.SeriesNumber) - 1)

            cboAnnotationSnapMode.SelectedIndex = .SnapMode
            If .PointNumberToBind >= 0 Then
                txtPointToBindTo.Text = CStr(.PointNumberToBind)
                ''            ShowHidePointNumberControls True
            Else
                ''            ShowHidePointNumberControls False
            End If

            ' Yes, we need to update txtCaption twice
            ' The reason is that GetDynamicCaptionText() simply returns txtCaption's text if no dynamic options are enabled
            txtCaption.Text = .CaptionText
            txtCaption.Text = GetDynamicCaptionText(udtAnnotationNew)

            txtCaptionAngle.Text = .CaptionAngle.ToString.Trim
            chkShowArrow.Checked = .IncludeArrow
            chkHideInCrowdedRegions.Checked = .HideInDenseRegions
        End With

        mUpdatingControls = False
        Exit Sub

ShowCurrentOptionsErrorHandler:
        System.Diagnostics.Debug.WriteLine("Error occurred in frmEditAnnotation.ShowCurrentOptions(): " & Err.Description)

    End Sub

    Public Sub ReturnCurrentSettings(ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, ByRef strCaptionText As String, ByRef lngCaptionAngle As Integer, ByRef intSeriesNumber As Short, ByRef eSnapMode As CWGraphControl.asmAnnotationSnapModeConstants, ByRef lngPointNumberToBind As Integer, ByRef blnAnnotationShowsNearestPointX As Boolean, ByRef blnAnnotationShowsNearestPointY As Boolean, ByRef blnIncludeArrow As Boolean, ByRef blnHideInDenseRegions As Boolean)

        With udtAnnotationNew
            CaptionXPos = .CaptionXPos
            CaptionYPos = .CaptionYPos

            strCaptionText = .CaptionText
            lngCaptionAngle = .CaptionAngle

            intSeriesNumber = .SeriesNumber
            eSnapMode = .SnapMode
            lngPointNumberToBind = .PointNumberToBind

            blnAnnotationShowsNearestPointX = .AnnotationShowsNearestPointX
            blnAnnotationShowsNearestPointY = .AnnotationShowsNearestPointY
            blnIncludeArrow = .IncludeArrow
            blnHideInDenseRegions = .HideInDenseRegions

        End With

    End Sub

    Private Sub ShowHidePointNumberControls(ByRef blnShow As Boolean)
        lblPointToBind.Visible = blnShow
        txtPointToBindTo.Visible = blnShow
        scrDataPointSelection.Visible = blnShow
    End Sub

    Private Sub SynchronizeDataPointNumberSelection(ByRef blnFavorScrollBar As Boolean)
        Dim blnUpdatingControlsSaved As Boolean
        Dim lngDataPointNumber As Integer

        blnUpdatingControlsSaved = mUpdatingControls
        mUpdatingControls = True

        If blnFavorScrollBar Then
            txtPointToBindTo.Text = CStr(scrDataPointSelection.Value)
        Else
            lngDataPointNumber = SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtPointToBindTo.Text)

            With scrDataPointSelection
                If lngDataPointNumber >= .Minimum And lngDataPointNumber <= (.Maximum - .LargeChange + 1) Then
                    scrDataPointSelection.Value = lngDataPointNumber
                End If
            End With
        End If

        mUpdatingControls = blnUpdatingControlsSaved

    End Sub

    Private Sub UpdateCurrentOptions(Optional ByRef blnUpdateCallingControl As Boolean = True)

        Dim blnOldShowNearestPointX, blnOldShowNearestPointY As Boolean
        Dim strOldCaptionText As String
        Static blnUpdatingOptions As Boolean

        If Not mComponentsInitialized OrElse blnUpdatingOptions OrElse mUpdatingControls Then Exit Sub
        blnUpdatingOptions = True

        With udtAnnotationNew

            If cboSeriesNumber.SelectedIndex >= 0 Then
                .SeriesNumber = cboSeriesNumber.SelectedIndex + 1
            End If

            strOldCaptionText = .CaptionText
            blnOldShowNearestPointX = .AnnotationShowsNearestPointX
            blnOldShowNearestPointY = .AnnotationShowsNearestPointY
            .AnnotationShowsNearestPointX = chkAnnotationShowsNearestPointX.Checked
            .AnnotationShowsNearestPointY = chkAnnotationShowsNearestPointY.Checked

            If .PointNumberToBind >= 0 Then .PointNumberToBind = SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtPointToBindTo.Text)

            If (cboAnnotationSnapMode.SelectedIndex = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint And .SnapMode <> CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint) Or (cboAnnotationSnapMode.SelectedIndex <> CWGraphControl.asmAnnotationSnapModeConstants.asmFloating And .PointNumberToBind < 0) Then
                .SnapMode = cboAnnotationSnapMode.SelectedIndex

                ' Determine the nearest data point for the given series and update .PointNumberToBind
                .PointNumberToBind = mCWGraphControl.LookupNearestPointNumber(.CaptionXPos, .CaptionYPos, .SeriesNumber, 0, True)
                txtPointToBindTo.Text = CStr(.PointNumberToBind)
            Else
                .SnapMode = cboAnnotationSnapMode.SelectedIndex
            End If

            .CaptionText = GetDynamicCaptionText(udtAnnotationNew)

            If .AnnotationShowsNearestPointX Or .AnnotationShowsNearestPointY Then
                If Not blnOldShowNearestPointX And Not blnOldShowNearestPointY Then
                    ' User just turned on either show nearest X and show nearest Y
                    ' Update mOriginalCaption
                    mOriginalCaption = strOldCaptionText
                End If
            ElseIf Not .AnnotationShowsNearestPointX And Not .AnnotationShowsNearestPointY Then
                If blnOldShowNearestPointX Or blnOldShowNearestPointY Then
                    ' User just turned off both show nearest X and show nearest Y
                    ' Restore the most recent caption
                    .CaptionText = mOriginalCaption
                End If
            End If

            txtCaption.Text = .CaptionText

            .CaptionXPos = SharedVBNetRoutines.VBNetRoutines.CDblSafe(txtXPos.Text)
            .CaptionYPos = SharedVBNetRoutines.VBNetRoutines.CDblSafe(txtYPos.Text)
            .CaptionAngle = SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtCaptionAngle.Text)

            .IncludeArrow = chkShowArrow.Checked
            .HideInDenseRegions = chkHideInCrowdedRegions.Checked

            If blnUpdateCallingControl Then
                mCWGraphControl.SetAnnotationByIndex(.AnnotationIndex, .CaptionXPos, .CaptionYPos, .CaptionText, .CaptionAngle, .SeriesNumber, .SnapMode, .PointNumberToBind, .AnnotationShowsNearestPointX, .AnnotationShowsNearestPointY, .IncludeArrow, .HideInDenseRegions, False)
            End If

        End With

        blnUpdatingOptions = False

    End Sub

    Private Sub UpdateDynamicControls()
        If cboAnnotationSnapMode.SelectedIndex = CWGraphControl.asmAnnotationSnapModeConstants.asmFloating Then
            chkAnnotationShowsNearestPointX.Text = "Caption Displays X position"
            chkAnnotationShowsNearestPointY.Text = "Caption Displays Y position"
        Else
            chkAnnotationShowsNearestPointX.Text = "Caption Displays X of Nearest Point"
            chkAnnotationShowsNearestPointY.Text = "Caption Displays Y of Nearest Point"
        End If
    End Sub

    Private Sub cboAnnotationSnapMode_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboAnnotationSnapMode.SelectedIndexChanged
        If cboAnnotationSnapMode.SelectedIndex = CWGraphControl.asmAnnotationSnapModeConstants.asmFloating Then
            ShowHidePointNumberControls(False)
        Else
            ShowHidePointNumberControls(True)
        End If

        UpdateDynamicControls()
        UpdateCurrentOptions()
    End Sub

    Private Sub cboSeriesNumber_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboSeriesNumber.SelectedIndexChanged
        InitializeScrollBar(0, mCWGraphControl.GetDataCount(cboSeriesNumber.SelectedIndex + 1) - 1)

        UpdateCurrentOptions()
    End Sub

    Private Sub chkAnnotationShowsNearestPointX_CheckStateChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkAnnotationShowsNearestPointX.CheckStateChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub chkAnnotationShowsNearestPointY_CheckStateChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkAnnotationShowsNearestPointY.CheckStateChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub chkHideInCrowdedRegions_CheckStateChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkHideInCrowdedRegions.CheckStateChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub chkShowArrow_CheckStateChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkShowArrow.CheckStateChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub cmdCancel_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdCancel.Click
        ' Restore the saved options, then call ApplyChanges
        udtAnnotationNew = udtAnnotationSaved

        With udtAnnotationNew
            mCWGraphControl.SetAnnotationByIndex(.AnnotationIndex, .CaptionXPos, .CaptionYPos, .CaptionText, .CaptionAngle, .SeriesNumber, .SnapMode, .PointNumberToBind, .AnnotationShowsNearestPointX, .AnnotationShowsNearestPointY, .IncludeArrow, .HideInDenseRegions, False)
        End With
        Me.DialogResult = DialogResult.Cancel

        Me.Hide()
    End Sub

    Private Sub cmdOK_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub cmdRemove_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdRemove.Click
        ' We're using .Retry to signify "Remove annotation"
        Me.DialogResult = DialogResult.Retry
        Me.Hide()
    End Sub

    Private Sub frmEditAnnotation_Activated(eventSender As System.Object, eventArgs As System.EventArgs) Handles MyBase.Activated
        txtCaption.Focus()
    End Sub

    Private Sub frmEditAnnotation_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load
        SizeAndCenterWindow(Me, wpcWindowPosConstants.BottomCenter, 460, 350)
    End Sub

    Private Sub frmEditAnnotation_Closed(eventSender As System.Object, eventArgs As System.EventArgs) Handles MyBase.Closed
        mCWGraphControl = Nothing
    End Sub

    Private Sub txtCaption_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtCaption.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtCaption_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtCaption.Enter
        TextBoxGotFocusHandler(txtCaption)
    End Sub

    Private Sub txtCaption_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtCaption.Leave
        UpdateCurrentOptions()
    End Sub

    Private Sub txtCaptionAngle_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtCaptionAngle.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtCaptionAngle_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtCaptionAngle.Enter
        TextBoxGotFocusHandler(txtCaptionAngle)
    End Sub

    Private Sub txtCaptionAngle_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtCaptionAngle.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtCaptionAngle, eventArgs, True, False)
    End Sub

    Private Sub txtCaptionAngle_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtCaptionAngle.Leave
        SharedVBNetRoutines.VBNetRoutines.ValidateTextboxInt(txtCaptionAngle, 0, 360, 0)
        UpdateCurrentOptions()
    End Sub

    Private Sub txtPointToBindTo_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPointToBindTo.TextChanged
        SynchronizeDataPointNumberSelection(False)
        UpdateCurrentOptions()
    End Sub

    Private Sub txtPointToBindTo_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPointToBindTo.Enter
        TextBoxGotFocusHandler(txtPointToBindTo)
    End Sub

    Private Sub txtPointToBindTo_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPointToBindTo.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtPointToBindTo, eventArgs, True, False)
    End Sub

    Private Sub txtPointToBindTo_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPointToBindTo.Leave
        SharedVBNetRoutines.VBNetRoutines.ValidateTextboxSng(txtPointToBindTo, 0, 100000000.0#, 0)
        UpdateCurrentOptions()
    End Sub

    Private Sub txtXPos_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtXPos.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtXPos_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtXPos.Enter
        TextBoxGotFocusHandler(txtXPos)
    End Sub

    Private Sub txtXPos_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtXPos.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtXPos, eventArgs, True, True, True, False, True, False, False, False, False, True)
    End Sub

    Private Sub txtXPos_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtXPos.Leave
        UpdateCurrentOptions()
    End Sub

    Private Sub txtYPos_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtYPos.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtYPos_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtYPos.Enter
        TextBoxGotFocusHandler(txtYPos)
    End Sub

    Private Sub txtYPos_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtYPos.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtYPos, eventArgs, True, True, True, False, True, False, False, False, False, True)
    End Sub

    Private Sub txtYPos_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtYPos.Leave
        UpdateCurrentOptions()
    End Sub

    Private Sub scrDataPointSelection_Scroll(eventSender As System.Object, eventArgs As System.Windows.Forms.ScrollEventArgs) Handles scrDataPointSelection.Scroll
        Select Case eventArgs.Type
            Case System.Windows.Forms.ScrollEventType.EndScroll
                SynchronizeDataPointNumberSelection(True)
                UpdateCurrentOptions()
            Case Else
                ' Don't do anything special
        End Select
    End Sub
End Class