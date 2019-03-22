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

Friend Class frmCWSpectrumOptions
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
	Public WithEvents txtNormalizationConstant As System.Windows.Forms.TextBox
	Public WithEvents chkNormalizeOnLoadOrPaste As System.Windows.Forms.CheckBox
	Public WithEvents cboAnnotationFontName As System.Windows.Forms.ComboBox
	Public WithEvents cboAnnotationFontSize As System.Windows.Forms.ComboBox
	Public WithEvents lblAnnotationColor As System.Windows.Forms.Label
	Public WithEvents lblAnnotationColorSelection As System.Windows.Forms.Label
	Public WithEvents lblAnnotationFontSize As System.Windows.Forms.Label
	Public WithEvents lblAnnotationFontName As System.Windows.Forms.Label
	Public WithEvents fraAnnotationOptions As System.Windows.Forms.GroupBox
	Public WithEvents cmdResetToDefaults As System.Windows.Forms.Button
	Public WithEvents cmdCopyToAllSeries As System.Windows.Forms.Button
	Public WithEvents chkShowGridlinesMinorY As System.Windows.Forms.CheckBox
	Public WithEvents chkShowGridlinesMajorY As System.Windows.Forms.CheckBox
	Public WithEvents chkShowGridlinesMinorX As System.Windows.Forms.CheckBox
	Public WithEvents chkShowGridlinesMajorX As System.Windows.Forms.CheckBox
	Public WithEvents cboLabelFontSize As System.Windows.Forms.ComboBox
	Public WithEvents cboLabelFontName As System.Windows.Forms.ComboBox
	Public WithEvents txtYAxisLabel As System.Windows.Forms.TextBox
	Public WithEvents txtXAxisLabel As System.Windows.Forms.TextBox
	Public WithEvents txtPlotSubTitle As System.Windows.Forms.TextBox
	Public WithEvents txtPlotTitle As System.Windows.Forms.TextBox
	Public WithEvents lblGridlinesMinor As System.Windows.Forms.Label
	Public WithEvents lblGridlinesMajor As System.Windows.Forms.Label
	Public WithEvents _lblColor_6 As System.Windows.Forms.Label
	Public WithEvents lblGridLinesMajorColorSelection As System.Windows.Forms.Label
	Public WithEvents lblGridLinesMinorColorSelection As System.Windows.Forms.Label
	Public WithEvents _lblColor_7 As System.Windows.Forms.Label
    Public WithEvents lblLabelFontColor As System.Windows.Forms.Label
	Public WithEvents lblLabelFontColorSelection As System.Windows.Forms.Label
	Public WithEvents lblLabelFontName As System.Windows.Forms.Label
	Public WithEvents lblLabelFontSize As System.Windows.Forms.Label
	Public WithEvents lblYAxisLabel As System.Windows.Forms.Label
	Public WithEvents lblXAxisLabel As System.Windows.Forms.Label
	Public WithEvents lblPlotSubTitle As System.Windows.Forms.Label
	Public WithEvents lblPlotTitle As System.Windows.Forms.Label
	Public WithEvents lblPlotBackgroundColorSelection As System.Windows.Forms.Label
	Public WithEvents _lblColor_4 As System.Windows.Forms.Label
	Public WithEvents fraPlotOptions As System.Windows.Forms.GroupBox
	Public WithEvents txtLegendCaption As System.Windows.Forms.TextBox
	Public WithEvents cboSeriesNumber As System.Windows.Forms.ComboBox
	Public WithEvents cboPlotMode As System.Windows.Forms.ComboBox
	Public WithEvents lblLegendCaption As System.Windows.Forms.Label
	Public WithEvents lblSeriesNumber As System.Windows.Forms.Label
	Public WithEvents lblPlotMode As System.Windows.Forms.Label
	Public WithEvents fraSeriesOptions As System.Windows.Forms.GroupBox
	Public WithEvents cmdStyleLoad As System.Windows.Forms.Button
	Public WithEvents cmdSaveStyle As System.Windows.Forms.Button
	Public WithEvents cmdApply As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents fraControls As System.Windows.Forms.Panel
	Public WithEvents chkLinkPointColorToLineColor As System.Windows.Forms.CheckBox
	Public WithEvents cboPointStyle As System.Windows.Forms.ComboBox
	Public WithEvents _lblStyle_1 As System.Windows.Forms.Label
	Public WithEvents _lblColor_3 As System.Windows.Forms.Label
	Public WithEvents lblPointColorSelection As System.Windows.Forms.Label
	Public WithEvents fraPointOptions As System.Windows.Forms.GroupBox
	Public WithEvents chkLinkLineColors As System.Windows.Forms.CheckBox
	Public WithEvents txtLineWidth As System.Windows.Forms.TextBox
	Public WithEvents cboLineStyle As System.Windows.Forms.ComboBox
	Public WithEvents lblBarFillColorSelection As System.Windows.Forms.Label
	Public WithEvents _lblColor_2 As System.Windows.Forms.Label
	Public WithEvents _lblColor_1 As System.Windows.Forms.Label
	Public WithEvents lblLineToBaseColorSelection As System.Windows.Forms.Label
	Public WithEvents lblLineColorSelection As System.Windows.Forms.Label
	Public WithEvents _lblColor_0 As System.Windows.Forms.Label
	Public WithEvents _lblWidth_0 As System.Windows.Forms.Label
	Public WithEvents _lblStyle_0 As System.Windows.Forms.Label
	Public WithEvents fraLineOptions As System.Windows.Forms.GroupBox
	Public WithEvents lblNormalizationConstant As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Public WithEvents lblCursor1ColorSelection As System.Windows.Forms.Label
    Public WithEvents lblCursor2ColorSelection As System.Windows.Forms.Label
    Public WithEvents chkFrameStyle3D As System.Windows.Forms.CheckBox
    Public WithEvents lblFrameBorderColorSelection As System.Windows.Forms.Label
    Public WithEvents lblCursor2Color As System.Windows.Forms.Label
    Public WithEvents lblFrameBorderColor As System.Windows.Forms.Label
    Public WithEvents lblCursor1Color As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblAnnotationColorSelection = New System.Windows.Forms.Label
        Me.lblGridLinesMajorColorSelection = New System.Windows.Forms.Label
        Me.lblGridLinesMinorColorSelection = New System.Windows.Forms.Label
        Me.lblCursor1ColorSelection = New System.Windows.Forms.Label
        Me.lblLabelFontColorSelection = New System.Windows.Forms.Label
        Me.lblPlotBackgroundColorSelection = New System.Windows.Forms.Label
        Me.lblPointColorSelection = New System.Windows.Forms.Label
        Me.lblBarFillColorSelection = New System.Windows.Forms.Label
        Me.lblLineToBaseColorSelection = New System.Windows.Forms.Label
        Me.lblLineColorSelection = New System.Windows.Forms.Label
        Me.lblCursor2ColorSelection = New System.Windows.Forms.Label
        Me.lblFrameBorderColorSelection = New System.Windows.Forms.Label
        Me.txtNormalizationConstant = New System.Windows.Forms.TextBox
        Me.chkNormalizeOnLoadOrPaste = New System.Windows.Forms.CheckBox
        Me.fraAnnotationOptions = New System.Windows.Forms.GroupBox
        Me.cboAnnotationFontName = New System.Windows.Forms.ComboBox
        Me.cboAnnotationFontSize = New System.Windows.Forms.ComboBox
        Me.lblAnnotationColor = New System.Windows.Forms.Label
        Me.lblAnnotationFontSize = New System.Windows.Forms.Label
        Me.lblAnnotationFontName = New System.Windows.Forms.Label
        Me.cmdResetToDefaults = New System.Windows.Forms.Button
        Me.cmdCopyToAllSeries = New System.Windows.Forms.Button
        Me.fraPlotOptions = New System.Windows.Forms.GroupBox
        Me.lblCursor2Color = New System.Windows.Forms.Label
        Me.lblFrameBorderColor = New System.Windows.Forms.Label
        Me.chkFrameStyle3D = New System.Windows.Forms.CheckBox
        Me.chkShowGridlinesMinorY = New System.Windows.Forms.CheckBox
        Me.chkShowGridlinesMajorY = New System.Windows.Forms.CheckBox
        Me.chkShowGridlinesMinorX = New System.Windows.Forms.CheckBox
        Me.chkShowGridlinesMajorX = New System.Windows.Forms.CheckBox
        Me.cboLabelFontSize = New System.Windows.Forms.ComboBox
        Me.cboLabelFontName = New System.Windows.Forms.ComboBox
        Me.txtYAxisLabel = New System.Windows.Forms.TextBox
        Me.txtXAxisLabel = New System.Windows.Forms.TextBox
        Me.txtPlotSubTitle = New System.Windows.Forms.TextBox
        Me.txtPlotTitle = New System.Windows.Forms.TextBox
        Me.lblGridlinesMinor = New System.Windows.Forms.Label
        Me.lblGridlinesMajor = New System.Windows.Forms.Label
        Me._lblColor_6 = New System.Windows.Forms.Label
        Me._lblColor_7 = New System.Windows.Forms.Label
        Me.lblCursor1Color = New System.Windows.Forms.Label
        Me.lblLabelFontColor = New System.Windows.Forms.Label
        Me.lblLabelFontName = New System.Windows.Forms.Label
        Me.lblLabelFontSize = New System.Windows.Forms.Label
        Me.lblYAxisLabel = New System.Windows.Forms.Label
        Me.lblXAxisLabel = New System.Windows.Forms.Label
        Me.lblPlotSubTitle = New System.Windows.Forms.Label
        Me.lblPlotTitle = New System.Windows.Forms.Label
        Me._lblColor_4 = New System.Windows.Forms.Label
        Me.fraSeriesOptions = New System.Windows.Forms.GroupBox
        Me.txtLegendCaption = New System.Windows.Forms.TextBox
        Me.cboSeriesNumber = New System.Windows.Forms.ComboBox
        Me.cboPlotMode = New System.Windows.Forms.ComboBox
        Me.lblLegendCaption = New System.Windows.Forms.Label
        Me.lblSeriesNumber = New System.Windows.Forms.Label
        Me.lblPlotMode = New System.Windows.Forms.Label
        Me.fraControls = New System.Windows.Forms.Panel
        Me.cmdStyleLoad = New System.Windows.Forms.Button
        Me.cmdSaveStyle = New System.Windows.Forms.Button
        Me.cmdApply = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.fraPointOptions = New System.Windows.Forms.GroupBox
        Me.chkLinkPointColorToLineColor = New System.Windows.Forms.CheckBox
        Me.cboPointStyle = New System.Windows.Forms.ComboBox
        Me._lblStyle_1 = New System.Windows.Forms.Label
        Me._lblColor_3 = New System.Windows.Forms.Label
        Me.fraLineOptions = New System.Windows.Forms.GroupBox
        Me.chkLinkLineColors = New System.Windows.Forms.CheckBox
        Me.txtLineWidth = New System.Windows.Forms.TextBox
        Me.cboLineStyle = New System.Windows.Forms.ComboBox
        Me._lblColor_2 = New System.Windows.Forms.Label
        Me._lblColor_1 = New System.Windows.Forms.Label
        Me._lblColor_0 = New System.Windows.Forms.Label
        Me._lblWidth_0 = New System.Windows.Forms.Label
        Me._lblStyle_0 = New System.Windows.Forms.Label
        Me.lblNormalizationConstant = New System.Windows.Forms.Label
        Me.dlgColor = New System.Windows.Forms.ColorDialog
        Me.fraAnnotationOptions.SuspendLayout()
        Me.fraPlotOptions.SuspendLayout()
        Me.fraSeriesOptions.SuspendLayout()
        Me.fraControls.SuspendLayout()
        Me.fraPointOptions.SuspendLayout()
        Me.fraLineOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblAnnotationColorSelection
        '
        Me.lblAnnotationColorSelection.BackColor = Color.Black
        Me.lblAnnotationColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAnnotationColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAnnotationColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnnotationColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAnnotationColorSelection.Location = New System.Drawing.Point(96, 66)
        Me.lblAnnotationColorSelection.Name = "lblAnnotationColorSelection"
        Me.lblAnnotationColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAnnotationColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblAnnotationColorSelection.TabIndex = 67
        Me.ToolTip1.SetToolTip(Me.lblAnnotationColorSelection, "Double click to change")
        '
        'lblGridLinesMajorColorSelection
        '
        Me.lblGridLinesMajorColorSelection.BackColor = Color.Black
        Me.lblGridLinesMajorColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGridLinesMajorColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGridLinesMajorColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGridLinesMajorColorSelection.ForeColor = Color.Black
        Me.lblGridLinesMajorColorSelection.Location = New System.Drawing.Point(376, 196)
        Me.lblGridLinesMajorColorSelection.Name = "lblGridLinesMajorColorSelection"
        Me.lblGridLinesMajorColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGridLinesMajorColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblGridLinesMajorColorSelection.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.lblGridLinesMajorColorSelection, "Double click to change")
        '
        'lblGridLinesMinorColorSelection
        '
        Me.lblGridLinesMinorColorSelection.BackColor = Color.Black
        Me.lblGridLinesMinorColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGridLinesMinorColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGridLinesMinorColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGridLinesMinorColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGridLinesMinorColorSelection.Location = New System.Drawing.Point(376, 216)
        Me.lblGridLinesMinorColorSelection.Name = "lblGridLinesMinorColorSelection"
        Me.lblGridLinesMinorColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGridLinesMinorColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblGridLinesMinorColorSelection.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.lblGridLinesMinorColorSelection, "Double click to change")
        '
        'lblCursor1ColorSelection
        '
        Me.lblCursor1ColorSelection.BackColor = Color.Black
        Me.lblCursor1ColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCursor1ColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCursor1ColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCursor1ColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCursor1ColorSelection.Location = New System.Drawing.Point(376, 144)
        Me.lblCursor1ColorSelection.Name = "lblCursor1ColorSelection"
        Me.lblCursor1ColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCursor1ColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblCursor1ColorSelection.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.lblCursor1ColorSelection, "Double click to change")
        '
        'lblLabelFontColorSelection
        '
        Me.lblLabelFontColorSelection.BackColor = Color.White
        Me.lblLabelFontColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLabelFontColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabelFontColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabelFontColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabelFontColorSelection.Location = New System.Drawing.Point(96, 168)
        Me.lblLabelFontColorSelection.Name = "lblLabelFontColorSelection"
        Me.lblLabelFontColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabelFontColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblLabelFontColorSelection.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.lblLabelFontColorSelection, "Double click to change")
        '
        'lblPlotBackgroundColorSelection
        '
        Me.lblPlotBackgroundColorSelection.BackColor = Color.White
        Me.lblPlotBackgroundColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPlotBackgroundColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlotBackgroundColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlotBackgroundColorSelection.ForeColor = Color.Black
        Me.lblPlotBackgroundColorSelection.Location = New System.Drawing.Point(240, 168)
        Me.lblPlotBackgroundColorSelection.Name = "lblPlotBackgroundColorSelection"
        Me.lblPlotBackgroundColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlotBackgroundColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblPlotBackgroundColorSelection.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.lblPlotBackgroundColorSelection, "Double click to change")
        '
        'lblPointColorSelection
        '
        Me.lblPointColorSelection.BackColor = Color.Red
        Me.lblPointColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPointColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPointColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPointColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPointColorSelection.Location = New System.Drawing.Point(112, 44)
        Me.lblPointColorSelection.Name = "lblPointColorSelection"
        Me.lblPointColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPointColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblPointColorSelection.TabIndex = 52
        Me.ToolTip1.SetToolTip(Me.lblPointColorSelection, "Double click to change")
        '
        'lblBarFillColorSelection
        '
        Me.lblBarFillColorSelection.BackColor = Color.Red
        Me.lblBarFillColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBarFillColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblBarFillColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarFillColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarFillColorSelection.Location = New System.Drawing.Point(112, 104)
        Me.lblBarFillColorSelection.Name = "lblBarFillColorSelection"
        Me.lblBarFillColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBarFillColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblBarFillColorSelection.TabIndex = 46
        Me.ToolTip1.SetToolTip(Me.lblBarFillColorSelection, "Double click to change")
        '
        'lblLineToBaseColorSelection
        '
        Me.lblLineToBaseColorSelection.BackColor = Color.Red
        Me.lblLineToBaseColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLineToBaseColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLineToBaseColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineToBaseColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLineToBaseColorSelection.Location = New System.Drawing.Point(112, 84)
        Me.lblLineToBaseColorSelection.Name = "lblLineToBaseColorSelection"
        Me.lblLineToBaseColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLineToBaseColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblLineToBaseColorSelection.TabIndex = 44
        Me.ToolTip1.SetToolTip(Me.lblLineToBaseColorSelection, "Double click to change")
        '
        'lblLineColorSelection
        '
        Me.lblLineColorSelection.BackColor = Color.Red
        Me.lblLineColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLineColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLineColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLineColorSelection.Location = New System.Drawing.Point(112, 64)
        Me.lblLineColorSelection.Name = "lblLineColorSelection"
        Me.lblLineColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLineColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblLineColorSelection.TabIndex = 42
        Me.ToolTip1.SetToolTip(Me.lblLineColorSelection, "Double click to change")
        '
        'lblCursor2ColorSelection
        '
        Me.lblCursor2ColorSelection.BackColor = Color.DimGray
        Me.lblCursor2ColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCursor2ColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCursor2ColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCursor2ColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCursor2ColorSelection.Location = New System.Drawing.Point(376, 168)
        Me.lblCursor2ColorSelection.Name = "lblCursor2ColorSelection"
        Me.lblCursor2ColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCursor2ColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblCursor2ColorSelection.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.lblCursor2ColorSelection, "Double click to change")
        '
        'lblFrameBorderColorSelection
        '
        Me.lblFrameBorderColorSelection.BackColor = Color.Black
        Me.lblFrameBorderColorSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFrameBorderColorSelection.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFrameBorderColorSelection.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrameBorderColorSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFrameBorderColorSelection.Location = New System.Drawing.Point(376, 240)
        Me.lblFrameBorderColorSelection.Name = "lblFrameBorderColorSelection"
        Me.lblFrameBorderColorSelection.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFrameBorderColorSelection.Size = New System.Drawing.Size(25, 17)
        Me.lblFrameBorderColorSelection.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.lblFrameBorderColorSelection, "Double click to change")
        '
        'txtNormalizationConstant
        '
        Me.txtNormalizationConstant.AcceptsReturn = True
        Me.txtNormalizationConstant.AutoSize = False
        Me.txtNormalizationConstant.BackColor = System.Drawing.SystemColors.Window
        Me.txtNormalizationConstant.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNormalizationConstant.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNormalizationConstant.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNormalizationConstant.Location = New System.Drawing.Point(520, 212)
        Me.txtNormalizationConstant.MaxLength = 0
        Me.txtNormalizationConstant.Name = "txtNormalizationConstant"
        Me.txtNormalizationConstant.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNormalizationConstant.Size = New System.Drawing.Size(57, 19)
        Me.txtNormalizationConstant.TabIndex = 70
        Me.txtNormalizationConstant.Text = "100"
        '
        'chkNormalizeOnLoadOrPaste
        '
        Me.chkNormalizeOnLoadOrPaste.BackColor = System.Drawing.SystemColors.Control
        Me.chkNormalizeOnLoadOrPaste.Checked = True
        Me.chkNormalizeOnLoadOrPaste.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNormalizeOnLoadOrPaste.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNormalizeOnLoadOrPaste.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNormalizeOnLoadOrPaste.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNormalizeOnLoadOrPaste.Location = New System.Drawing.Point(448, 160)
        Me.chkNormalizeOnLoadOrPaste.Name = "chkNormalizeOnLoadOrPaste"
        Me.chkNormalizeOnLoadOrPaste.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNormalizeOnLoadOrPaste.Size = New System.Drawing.Size(137, 41)
        Me.chkNormalizeOnLoadOrPaste.TabIndex = 69
        Me.chkNormalizeOnLoadOrPaste.Text = "Normalize Data when Loading from Disk or Pasting from Clipboard"
        '
        'fraAnnotationOptions
        '
        Me.fraAnnotationOptions.BackColor = System.Drawing.SystemColors.Control
        Me.fraAnnotationOptions.Controls.Add(Me.cboAnnotationFontName)
        Me.fraAnnotationOptions.Controls.Add(Me.cboAnnotationFontSize)
        Me.fraAnnotationOptions.Controls.Add(Me.lblAnnotationColor)
        Me.fraAnnotationOptions.Controls.Add(Me.lblAnnotationColorSelection)
        Me.fraAnnotationOptions.Controls.Add(Me.lblAnnotationFontSize)
        Me.fraAnnotationOptions.Controls.Add(Me.lblAnnotationFontName)
        Me.fraAnnotationOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraAnnotationOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAnnotationOptions.Location = New System.Drawing.Point(304, 432)
        Me.fraAnnotationOptions.Name = "fraAnnotationOptions"
        Me.fraAnnotationOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAnnotationOptions.Size = New System.Drawing.Size(289, 89)
        Me.fraAnnotationOptions.TabIndex = 62
        Me.fraAnnotationOptions.TabStop = False
        Me.fraAnnotationOptions.Text = "Annotation Options"
        '
        'cboAnnotationFontName
        '
        Me.cboAnnotationFontName.BackColor = System.Drawing.SystemColors.Window
        Me.cboAnnotationFontName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboAnnotationFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnnotationFontName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnnotationFontName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboAnnotationFontName.Location = New System.Drawing.Point(96, 16)
        Me.cboAnnotationFontName.Name = "cboAnnotationFontName"
        Me.cboAnnotationFontName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboAnnotationFontName.Size = New System.Drawing.Size(185, 22)
        Me.cboAnnotationFontName.Sorted = True
        Me.cboAnnotationFontName.TabIndex = 64
        '
        'cboAnnotationFontSize
        '
        Me.cboAnnotationFontSize.BackColor = System.Drawing.SystemColors.Window
        Me.cboAnnotationFontSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboAnnotationFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnnotationFontSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnnotationFontSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboAnnotationFontSize.Location = New System.Drawing.Point(96, 40)
        Me.cboAnnotationFontSize.Name = "cboAnnotationFontSize"
        Me.cboAnnotationFontSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboAnnotationFontSize.Size = New System.Drawing.Size(73, 22)
        Me.cboAnnotationFontSize.TabIndex = 63
        '
        'lblAnnotationColor
        '
        Me.lblAnnotationColor.BackColor = Color.Transparent
        Me.lblAnnotationColor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAnnotationColor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnnotationColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAnnotationColor.Location = New System.Drawing.Point(8, 66)
        Me.lblAnnotationColor.Name = "lblAnnotationColor"
        Me.lblAnnotationColor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAnnotationColor.Size = New System.Drawing.Size(73, 17)
        Me.lblAnnotationColor.TabIndex = 68
        Me.lblAnnotationColor.Text = "Font color"
        '
        'lblAnnotationFontSize
        '
        Me.lblAnnotationFontSize.BackColor = System.Drawing.SystemColors.Control
        Me.lblAnnotationFontSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAnnotationFontSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnnotationFontSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAnnotationFontSize.Location = New System.Drawing.Point(8, 42)
        Me.lblAnnotationFontSize.Name = "lblAnnotationFontSize"
        Me.lblAnnotationFontSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAnnotationFontSize.Size = New System.Drawing.Size(50, 17)
        Me.lblAnnotationFontSize.TabIndex = 66
        Me.lblAnnotationFontSize.Text = "Font size"
        '
        'lblAnnotationFontName
        '
        Me.lblAnnotationFontName.BackColor = System.Drawing.SystemColors.Control
        Me.lblAnnotationFontName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAnnotationFontName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnnotationFontName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAnnotationFontName.Location = New System.Drawing.Point(8, 18)
        Me.lblAnnotationFontName.Name = "lblAnnotationFontName"
        Me.lblAnnotationFontName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAnnotationFontName.Size = New System.Drawing.Size(50, 17)
        Me.lblAnnotationFontName.TabIndex = 65
        Me.lblAnnotationFontName.Text = "Font name"
        '
        'cmdResetToDefaults
        '
        Me.cmdResetToDefaults.BackColor = System.Drawing.SystemColors.Control
        Me.cmdResetToDefaults.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdResetToDefaults.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdResetToDefaults.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdResetToDefaults.Location = New System.Drawing.Point(408, 288)
        Me.cmdResetToDefaults.Name = "cmdResetToDefaults"
        Me.cmdResetToDefaults.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdResetToDefaults.Size = New System.Drawing.Size(73, 33)
        Me.cmdResetToDefaults.TabIndex = 61
        Me.cmdResetToDefaults.Text = "Reset to Defaults"
        '
        'cmdCopyToAllSeries
        '
        Me.cmdCopyToAllSeries.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCopyToAllSeries.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCopyToAllSeries.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopyToAllSeries.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCopyToAllSeries.Location = New System.Drawing.Point(312, 288)
        Me.cmdCopyToAllSeries.Name = "cmdCopyToAllSeries"
        Me.cmdCopyToAllSeries.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCopyToAllSeries.Size = New System.Drawing.Size(81, 33)
        Me.cmdCopyToAllSeries.TabIndex = 60
        Me.cmdCopyToAllSeries.Text = "Apply Current to All Series"
        '
        'fraPlotOptions
        '
        Me.fraPlotOptions.BackColor = System.Drawing.SystemColors.Control
        Me.fraPlotOptions.Controls.Add(Me.lblCursor2Color)
        Me.fraPlotOptions.Controls.Add(Me.lblFrameBorderColorSelection)
        Me.fraPlotOptions.Controls.Add(Me.lblFrameBorderColor)
        Me.fraPlotOptions.Controls.Add(Me.chkFrameStyle3D)
        Me.fraPlotOptions.Controls.Add(Me.lblCursor2ColorSelection)
        Me.fraPlotOptions.Controls.Add(Me.chkShowGridlinesMinorY)
        Me.fraPlotOptions.Controls.Add(Me.chkShowGridlinesMajorY)
        Me.fraPlotOptions.Controls.Add(Me.chkShowGridlinesMinorX)
        Me.fraPlotOptions.Controls.Add(Me.chkShowGridlinesMajorX)
        Me.fraPlotOptions.Controls.Add(Me.cboLabelFontSize)
        Me.fraPlotOptions.Controls.Add(Me.cboLabelFontName)
        Me.fraPlotOptions.Controls.Add(Me.txtYAxisLabel)
        Me.fraPlotOptions.Controls.Add(Me.txtXAxisLabel)
        Me.fraPlotOptions.Controls.Add(Me.txtPlotSubTitle)
        Me.fraPlotOptions.Controls.Add(Me.txtPlotTitle)
        Me.fraPlotOptions.Controls.Add(Me.lblGridlinesMinor)
        Me.fraPlotOptions.Controls.Add(Me.lblGridlinesMajor)
        Me.fraPlotOptions.Controls.Add(Me._lblColor_6)
        Me.fraPlotOptions.Controls.Add(Me.lblGridLinesMajorColorSelection)
        Me.fraPlotOptions.Controls.Add(Me.lblGridLinesMinorColorSelection)
        Me.fraPlotOptions.Controls.Add(Me._lblColor_7)
        Me.fraPlotOptions.Controls.Add(Me.lblCursor1Color)
        Me.fraPlotOptions.Controls.Add(Me.lblCursor1ColorSelection)
        Me.fraPlotOptions.Controls.Add(Me.lblLabelFontColor)
        Me.fraPlotOptions.Controls.Add(Me.lblLabelFontColorSelection)
        Me.fraPlotOptions.Controls.Add(Me.lblLabelFontName)
        Me.fraPlotOptions.Controls.Add(Me.lblLabelFontSize)
        Me.fraPlotOptions.Controls.Add(Me.lblYAxisLabel)
        Me.fraPlotOptions.Controls.Add(Me.lblXAxisLabel)
        Me.fraPlotOptions.Controls.Add(Me.lblPlotSubTitle)
        Me.fraPlotOptions.Controls.Add(Me.lblPlotTitle)
        Me.fraPlotOptions.Controls.Add(Me.lblPlotBackgroundColorSelection)
        Me.fraPlotOptions.Controls.Add(Me._lblColor_4)
        Me.fraPlotOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPlotOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPlotOptions.Location = New System.Drawing.Point(8, 8)
        Me.fraPlotOptions.Name = "fraPlotOptions"
        Me.fraPlotOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraPlotOptions.Size = New System.Drawing.Size(425, 264)
        Me.fraPlotOptions.TabIndex = 0
        Me.fraPlotOptions.TabStop = False
        Me.fraPlotOptions.Text = "Plot Options"
        '
        'lblCursor2Color
        '
        Me.lblCursor2Color.BackColor = Color.Transparent
        Me.lblCursor2Color.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCursor2Color.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCursor2Color.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCursor2Color.Location = New System.Drawing.Point(288, 168)
        Me.lblCursor2Color.Name = "lblCursor2Color"
        Me.lblCursor2Color.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCursor2Color.Size = New System.Drawing.Size(80, 17)
        Me.lblCursor2Color.TabIndex = 34
        Me.lblCursor2Color.Text = "Cursor 2 Color"
        '
        'lblFrameBorderColor
        '
        Me.lblFrameBorderColor.BackColor = Color.Transparent
        Me.lblFrameBorderColor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFrameBorderColor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFrameBorderColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFrameBorderColor.Location = New System.Drawing.Point(248, 240)
        Me.lblFrameBorderColor.Name = "lblFrameBorderColor"
        Me.lblFrameBorderColor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFrameBorderColor.Size = New System.Drawing.Size(121, 17)
        Me.lblFrameBorderColor.TabIndex = 32
        Me.lblFrameBorderColor.Text = "Frame Border Color"
        '
        'chkFrameStyle3D
        '
        Me.chkFrameStyle3D.BackColor = System.Drawing.SystemColors.Control
        Me.chkFrameStyle3D.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkFrameStyle3D.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFrameStyle3D.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFrameStyle3D.Location = New System.Drawing.Point(96, 240)
        Me.chkFrameStyle3D.Name = "chkFrameStyle3D"
        Me.chkFrameStyle3D.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFrameStyle3D.Size = New System.Drawing.Size(104, 17)
        Me.chkFrameStyle3D.TabIndex = 31
        Me.chkFrameStyle3D.Text = "3D Frame"
        '
        'chkShowGridlinesMinorY
        '
        Me.chkShowGridlinesMinorY.BackColor = System.Drawing.SystemColors.Control
        Me.chkShowGridlinesMinorY.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkShowGridlinesMinorY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowGridlinesMinorY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkShowGridlinesMinorY.Location = New System.Drawing.Point(160, 215)
        Me.chkShowGridlinesMinorY.Name = "chkShowGridlinesMinorY"
        Me.chkShowGridlinesMinorY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkShowGridlinesMinorY.Size = New System.Drawing.Size(57, 17)
        Me.chkShowGridlinesMinorY.TabIndex = 26
        Me.chkShowGridlinesMinorY.Text = "Y Axis"
        '
        'chkShowGridlinesMajorY
        '
        Me.chkShowGridlinesMajorY.BackColor = System.Drawing.SystemColors.Control
        Me.chkShowGridlinesMajorY.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkShowGridlinesMajorY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowGridlinesMajorY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkShowGridlinesMajorY.Location = New System.Drawing.Point(160, 195)
        Me.chkShowGridlinesMajorY.Name = "chkShowGridlinesMajorY"
        Me.chkShowGridlinesMajorY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkShowGridlinesMajorY.Size = New System.Drawing.Size(57, 17)
        Me.chkShowGridlinesMajorY.TabIndex = 21
        Me.chkShowGridlinesMajorY.Text = "Y Axis"
        '
        'chkShowGridlinesMinorX
        '
        Me.chkShowGridlinesMinorX.BackColor = System.Drawing.SystemColors.Control
        Me.chkShowGridlinesMinorX.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkShowGridlinesMinorX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowGridlinesMinorX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkShowGridlinesMinorX.Location = New System.Drawing.Point(96, 215)
        Me.chkShowGridlinesMinorX.Name = "chkShowGridlinesMinorX"
        Me.chkShowGridlinesMinorX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkShowGridlinesMinorX.Size = New System.Drawing.Size(56, 17)
        Me.chkShowGridlinesMinorX.TabIndex = 25
        Me.chkShowGridlinesMinorX.Text = "X Axis"
        '
        'chkShowGridlinesMajorX
        '
        Me.chkShowGridlinesMajorX.BackColor = System.Drawing.SystemColors.Control
        Me.chkShowGridlinesMajorX.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkShowGridlinesMajorX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowGridlinesMajorX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkShowGridlinesMajorX.Location = New System.Drawing.Point(96, 195)
        Me.chkShowGridlinesMajorX.Name = "chkShowGridlinesMajorX"
        Me.chkShowGridlinesMajorX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkShowGridlinesMajorX.Size = New System.Drawing.Size(57, 17)
        Me.chkShowGridlinesMajorX.TabIndex = 20
        Me.chkShowGridlinesMajorX.Text = "X Axis"
        '
        'cboLabelFontSize
        '
        Me.cboLabelFontSize.BackColor = System.Drawing.SystemColors.Window
        Me.cboLabelFontSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLabelFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLabelFontSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLabelFontSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLabelFontSize.Location = New System.Drawing.Point(96, 136)
        Me.cboLabelFontSize.Name = "cboLabelFontSize"
        Me.cboLabelFontSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLabelFontSize.Size = New System.Drawing.Size(73, 22)
        Me.cboLabelFontSize.TabIndex = 12
        '
        'cboLabelFontName
        '
        Me.cboLabelFontName.BackColor = System.Drawing.SystemColors.Window
        Me.cboLabelFontName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLabelFontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLabelFontName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLabelFontName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLabelFontName.Location = New System.Drawing.Point(96, 112)
        Me.cboLabelFontName.Name = "cboLabelFontName"
        Me.cboLabelFontName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLabelFontName.Size = New System.Drawing.Size(185, 22)
        Me.cboLabelFontName.Sorted = True
        Me.cboLabelFontName.TabIndex = 10
        '
        'txtYAxisLabel
        '
        Me.txtYAxisLabel.AcceptsReturn = True
        Me.txtYAxisLabel.AutoSize = False
        Me.txtYAxisLabel.BackColor = System.Drawing.SystemColors.Window
        Me.txtYAxisLabel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtYAxisLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYAxisLabel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtYAxisLabel.Location = New System.Drawing.Point(96, 88)
        Me.txtYAxisLabel.MaxLength = 0
        Me.txtYAxisLabel.Name = "txtYAxisLabel"
        Me.txtYAxisLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtYAxisLabel.Size = New System.Drawing.Size(305, 19)
        Me.txtYAxisLabel.TabIndex = 8
        Me.txtYAxisLabel.Text = ""
        '
        'txtXAxisLabel
        '
        Me.txtXAxisLabel.AcceptsReturn = True
        Me.txtXAxisLabel.AutoSize = False
        Me.txtXAxisLabel.BackColor = System.Drawing.SystemColors.Window
        Me.txtXAxisLabel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtXAxisLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXAxisLabel.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtXAxisLabel.Location = New System.Drawing.Point(96, 64)
        Me.txtXAxisLabel.MaxLength = 0
        Me.txtXAxisLabel.Name = "txtXAxisLabel"
        Me.txtXAxisLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtXAxisLabel.Size = New System.Drawing.Size(305, 19)
        Me.txtXAxisLabel.TabIndex = 6
        Me.txtXAxisLabel.Text = ""
        '
        'txtPlotSubTitle
        '
        Me.txtPlotSubTitle.AcceptsReturn = True
        Me.txtPlotSubTitle.AutoSize = False
        Me.txtPlotSubTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlotSubTitle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlotSubTitle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlotSubTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPlotSubTitle.Location = New System.Drawing.Point(96, 40)
        Me.txtPlotSubTitle.MaxLength = 0
        Me.txtPlotSubTitle.Name = "txtPlotSubTitle"
        Me.txtPlotSubTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPlotSubTitle.Size = New System.Drawing.Size(305, 19)
        Me.txtPlotSubTitle.TabIndex = 4
        Me.txtPlotSubTitle.Text = ""
        '
        'txtPlotTitle
        '
        Me.txtPlotTitle.AcceptsReturn = True
        Me.txtPlotTitle.AutoSize = False
        Me.txtPlotTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlotTitle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPlotTitle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlotTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPlotTitle.Location = New System.Drawing.Point(96, 16)
        Me.txtPlotTitle.MaxLength = 0
        Me.txtPlotTitle.Name = "txtPlotTitle"
        Me.txtPlotTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPlotTitle.Size = New System.Drawing.Size(305, 19)
        Me.txtPlotTitle.TabIndex = 2
        Me.txtPlotTitle.Text = ""
        '
        'lblGridlinesMinor
        '
        Me.lblGridlinesMinor.BackColor = System.Drawing.SystemColors.Control
        Me.lblGridlinesMinor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGridlinesMinor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGridlinesMinor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGridlinesMinor.Location = New System.Drawing.Point(8, 216)
        Me.lblGridlinesMinor.Name = "lblGridlinesMinor"
        Me.lblGridlinesMinor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGridlinesMinor.Size = New System.Drawing.Size(81, 17)
        Me.lblGridlinesMinor.TabIndex = 24
        Me.lblGridlinesMinor.Text = "Minor Gridlines"
        '
        'lblGridlinesMajor
        '
        Me.lblGridlinesMajor.BackColor = System.Drawing.SystemColors.Control
        Me.lblGridlinesMajor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGridlinesMajor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGridlinesMajor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGridlinesMajor.Location = New System.Drawing.Point(8, 196)
        Me.lblGridlinesMajor.Name = "lblGridlinesMajor"
        Me.lblGridlinesMajor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGridlinesMajor.Size = New System.Drawing.Size(81, 17)
        Me.lblGridlinesMajor.TabIndex = 19
        Me.lblGridlinesMajor.Text = "Major Gridlines"
        '
        '_lblColor_6
        '
        Me._lblColor_6.BackColor = Color.Transparent
        Me._lblColor_6.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblColor_6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblColor_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblColor_6.Location = New System.Drawing.Point(248, 196)
        Me._lblColor_6.Name = "_lblColor_6"
        Me._lblColor_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblColor_6.Size = New System.Drawing.Size(121, 17)
        Me._lblColor_6.TabIndex = 22
        Me._lblColor_6.Text = "Major Gridlines Color"
        '
        '_lblColor_7
        '
        Me._lblColor_7.BackColor = Color.Transparent
        Me._lblColor_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblColor_7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblColor_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblColor_7.Location = New System.Drawing.Point(248, 216)
        Me._lblColor_7.Name = "_lblColor_7"
        Me._lblColor_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblColor_7.Size = New System.Drawing.Size(121, 17)
        Me._lblColor_7.TabIndex = 27
        Me._lblColor_7.Text = "Minor Gridlines Color"
        '
        'lblCursor1Color
        '
        Me.lblCursor1Color.BackColor = Color.Transparent
        Me.lblCursor1Color.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblCursor1Color.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCursor1Color.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCursor1Color.Location = New System.Drawing.Point(288, 144)
        Me.lblCursor1Color.Name = "lblCursor1Color"
        Me.lblCursor1Color.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCursor1Color.Size = New System.Drawing.Size(80, 17)
        Me.lblCursor1Color.TabIndex = 17
        Me.lblCursor1Color.Text = "Cursor 1 Color"
        '
        'lblLabelFontColor
        '
        Me.lblLabelFontColor.BackColor = Color.Transparent
        Me.lblLabelFontColor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabelFontColor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabelFontColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabelFontColor.Location = New System.Drawing.Point(8, 168)
        Me.lblLabelFontColor.Name = "lblLabelFontColor"
        Me.lblLabelFontColor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabelFontColor.Size = New System.Drawing.Size(73, 17)
        Me.lblLabelFontColor.TabIndex = 13
        Me.lblLabelFontColor.Text = "Font color"
        '
        'lblLabelFontName
        '
        Me.lblLabelFontName.BackColor = System.Drawing.SystemColors.Control
        Me.lblLabelFontName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabelFontName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabelFontName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabelFontName.Location = New System.Drawing.Point(8, 114)
        Me.lblLabelFontName.Name = "lblLabelFontName"
        Me.lblLabelFontName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabelFontName.Size = New System.Drawing.Size(50, 17)
        Me.lblLabelFontName.TabIndex = 9
        Me.lblLabelFontName.Text = "Font name"
        '
        'lblLabelFontSize
        '
        Me.lblLabelFontSize.BackColor = System.Drawing.SystemColors.Control
        Me.lblLabelFontSize.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLabelFontSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabelFontSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLabelFontSize.Location = New System.Drawing.Point(8, 138)
        Me.lblLabelFontSize.Name = "lblLabelFontSize"
        Me.lblLabelFontSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLabelFontSize.Size = New System.Drawing.Size(50, 17)
        Me.lblLabelFontSize.TabIndex = 11
        Me.lblLabelFontSize.Text = "Font size"
        '
        'lblYAxisLabel
        '
        Me.lblYAxisLabel.BackColor = System.Drawing.SystemColors.Control
        Me.lblYAxisLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblYAxisLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYAxisLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblYAxisLabel.Location = New System.Drawing.Point(8, 89)
        Me.lblYAxisLabel.Name = "lblYAxisLabel"
        Me.lblYAxisLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblYAxisLabel.Size = New System.Drawing.Size(81, 17)
        Me.lblYAxisLabel.TabIndex = 7
        Me.lblYAxisLabel.Text = "&Y Axis Label"
        '
        'lblXAxisLabel
        '
        Me.lblXAxisLabel.BackColor = System.Drawing.SystemColors.Control
        Me.lblXAxisLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblXAxisLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXAxisLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblXAxisLabel.Location = New System.Drawing.Point(8, 64)
        Me.lblXAxisLabel.Name = "lblXAxisLabel"
        Me.lblXAxisLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblXAxisLabel.Size = New System.Drawing.Size(73, 17)
        Me.lblXAxisLabel.TabIndex = 5
        Me.lblXAxisLabel.Text = "&X Axis Label"
        '
        'lblPlotSubTitle
        '
        Me.lblPlotSubTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlotSubTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlotSubTitle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlotSubTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlotSubTitle.Location = New System.Drawing.Point(8, 41)
        Me.lblPlotSubTitle.Name = "lblPlotSubTitle"
        Me.lblPlotSubTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlotSubTitle.Size = New System.Drawing.Size(73, 17)
        Me.lblPlotSubTitle.TabIndex = 3
        Me.lblPlotSubTitle.Text = "Subtitle"
        '
        'lblPlotTitle
        '
        Me.lblPlotTitle.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlotTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlotTitle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlotTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlotTitle.Location = New System.Drawing.Point(8, 17)
        Me.lblPlotTitle.Name = "lblPlotTitle"
        Me.lblPlotTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlotTitle.Size = New System.Drawing.Size(57, 17)
        Me.lblPlotTitle.TabIndex = 1
        Me.lblPlotTitle.Text = "&Title"
        '
        '_lblColor_4
        '
        Me._lblColor_4.BackColor = Color.Transparent
        Me._lblColor_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblColor_4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblColor_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblColor_4.Location = New System.Drawing.Point(144, 164)
        Me._lblColor_4.Name = "_lblColor_4"
        Me._lblColor_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblColor_4.Size = New System.Drawing.Size(88, 24)
        Me._lblColor_4.TabIndex = 15
        Me._lblColor_4.Text = "Plot Background Color"
        '
        'fraSeriesOptions
        '
        Me.fraSeriesOptions.BackColor = System.Drawing.SystemColors.Control
        Me.fraSeriesOptions.Controls.Add(Me.txtLegendCaption)
        Me.fraSeriesOptions.Controls.Add(Me.cboSeriesNumber)
        Me.fraSeriesOptions.Controls.Add(Me.cboPlotMode)
        Me.fraSeriesOptions.Controls.Add(Me.lblLegendCaption)
        Me.fraSeriesOptions.Controls.Add(Me.lblSeriesNumber)
        Me.fraSeriesOptions.Controls.Add(Me.lblPlotMode)
        Me.fraSeriesOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraSeriesOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraSeriesOptions.Location = New System.Drawing.Point(8, 280)
        Me.fraSeriesOptions.Name = "fraSeriesOptions"
        Me.fraSeriesOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraSeriesOptions.Size = New System.Drawing.Size(289, 97)
        Me.fraSeriesOptions.TabIndex = 29
        Me.fraSeriesOptions.TabStop = False
        Me.fraSeriesOptions.Text = "Series Options"
        '
        'txtLegendCaption
        '
        Me.txtLegendCaption.AcceptsReturn = True
        Me.txtLegendCaption.AutoSize = False
        Me.txtLegendCaption.BackColor = System.Drawing.SystemColors.Window
        Me.txtLegendCaption.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLegendCaption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLegendCaption.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLegendCaption.Location = New System.Drawing.Point(112, 68)
        Me.txtLegendCaption.MaxLength = 0
        Me.txtLegendCaption.Name = "txtLegendCaption"
        Me.txtLegendCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLegendCaption.Size = New System.Drawing.Size(169, 19)
        Me.txtLegendCaption.TabIndex = 35
        Me.txtLegendCaption.Text = ""
        '
        'cboSeriesNumber
        '
        Me.cboSeriesNumber.BackColor = System.Drawing.SystemColors.Window
        Me.cboSeriesNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboSeriesNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSeriesNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSeriesNumber.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSeriesNumber.Location = New System.Drawing.Point(112, 16)
        Me.cboSeriesNumber.Name = "cboSeriesNumber"
        Me.cboSeriesNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboSeriesNumber.Size = New System.Drawing.Size(153, 22)
        Me.cboSeriesNumber.TabIndex = 31
        '
        'cboPlotMode
        '
        Me.cboPlotMode.BackColor = System.Drawing.SystemColors.Window
        Me.cboPlotMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboPlotMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlotMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPlotMode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPlotMode.Location = New System.Drawing.Point(112, 40)
        Me.cboPlotMode.Name = "cboPlotMode"
        Me.cboPlotMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPlotMode.Size = New System.Drawing.Size(153, 22)
        Me.cboPlotMode.TabIndex = 33
        '
        'lblLegendCaption
        '
        Me.lblLegendCaption.BackColor = System.Drawing.SystemColors.Control
        Me.lblLegendCaption.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLegendCaption.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLegendCaption.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLegendCaption.Location = New System.Drawing.Point(8, 68)
        Me.lblLegendCaption.Name = "lblLegendCaption"
        Me.lblLegendCaption.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLegendCaption.Size = New System.Drawing.Size(89, 17)
        Me.lblLegendCaption.TabIndex = 34
        Me.lblLegendCaption.Text = "Series Caption"
        '
        'lblSeriesNumber
        '
        Me.lblSeriesNumber.BackColor = System.Drawing.SystemColors.Control
        Me.lblSeriesNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSeriesNumber.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeriesNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeriesNumber.Location = New System.Drawing.Point(8, 19)
        Me.lblSeriesNumber.Name = "lblSeriesNumber"
        Me.lblSeriesNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSeriesNumber.Size = New System.Drawing.Size(89, 17)
        Me.lblSeriesNumber.TabIndex = 30
        Me.lblSeriesNumber.Text = "&Series Number"
        '
        'lblPlotMode
        '
        Me.lblPlotMode.BackColor = System.Drawing.SystemColors.Control
        Me.lblPlotMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPlotMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlotMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPlotMode.Location = New System.Drawing.Point(8, 42)
        Me.lblPlotMode.Name = "lblPlotMode"
        Me.lblPlotMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPlotMode.Size = New System.Drawing.Size(89, 17)
        Me.lblPlotMode.TabIndex = 32
        Me.lblPlotMode.Text = "Plot Mode"
        '
        'fraControls
        '
        Me.fraControls.BackColor = System.Drawing.SystemColors.Control
        Me.fraControls.Controls.Add(Me.cmdStyleLoad)
        Me.fraControls.Controls.Add(Me.cmdSaveStyle)
        Me.fraControls.Controls.Add(Me.cmdApply)
        Me.fraControls.Controls.Add(Me.cmdCancel)
        Me.fraControls.Controls.Add(Me.cmdOK)
        Me.fraControls.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraControls.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraControls.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraControls.Location = New System.Drawing.Point(448, 16)
        Me.fraControls.Name = "fraControls"
        Me.fraControls.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraControls.Size = New System.Drawing.Size(137, 129)
        Me.fraControls.TabIndex = 54
        '
        'cmdStyleLoad
        '
        Me.cmdStyleLoad.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStyleLoad.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStyleLoad.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStyleLoad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStyleLoad.Location = New System.Drawing.Point(32, 72)
        Me.cmdStyleLoad.Name = "cmdStyleLoad"
        Me.cmdStyleLoad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStyleLoad.Size = New System.Drawing.Size(73, 25)
        Me.cmdStyleLoad.TabIndex = 58
        Me.cmdStyleLoad.Text = "Load Style"
        '
        'cmdSaveStyle
        '
        Me.cmdSaveStyle.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSaveStyle.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSaveStyle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSaveStyle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSaveStyle.Location = New System.Drawing.Point(32, 104)
        Me.cmdSaveStyle.Name = "cmdSaveStyle"
        Me.cmdSaveStyle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSaveStyle.Size = New System.Drawing.Size(73, 25)
        Me.cmdSaveStyle.TabIndex = 59
        Me.cmdSaveStyle.Text = "Save Style"
        '
        'cmdApply
        '
        Me.cmdApply.BackColor = System.Drawing.SystemColors.Control
        Me.cmdApply.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdApply.Enabled = False
        Me.cmdApply.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdApply.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdApply.Location = New System.Drawing.Point(32, 0)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdApply.Size = New System.Drawing.Size(73, 25)
        Me.cmdApply.TabIndex = 55
        Me.cmdApply.Text = "&Apply"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(72, 32)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(65, 25)
        Me.cmdCancel.TabIndex = 57
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(0, 32)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(65, 25)
        Me.cmdOK.TabIndex = 56
        Me.cmdOK.Text = "&OK"
        '
        'fraPointOptions
        '
        Me.fraPointOptions.BackColor = System.Drawing.SystemColors.Control
        Me.fraPointOptions.Controls.Add(Me.chkLinkPointColorToLineColor)
        Me.fraPointOptions.Controls.Add(Me.cboPointStyle)
        Me.fraPointOptions.Controls.Add(Me._lblStyle_1)
        Me.fraPointOptions.Controls.Add(Me._lblColor_3)
        Me.fraPointOptions.Controls.Add(Me.lblPointColorSelection)
        Me.fraPointOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPointOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPointOptions.Location = New System.Drawing.Point(304, 360)
        Me.fraPointOptions.Name = "fraPointOptions"
        Me.fraPointOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraPointOptions.Size = New System.Drawing.Size(289, 69)
        Me.fraPointOptions.TabIndex = 48
        Me.fraPointOptions.TabStop = False
        Me.fraPointOptions.Text = "&Point Options"
        '
        'chkLinkPointColorToLineColor
        '
        Me.chkLinkPointColorToLineColor.BackColor = System.Drawing.SystemColors.Control
        Me.chkLinkPointColorToLineColor.Checked = True
        Me.chkLinkPointColorToLineColor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLinkPointColorToLineColor.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkLinkPointColorToLineColor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLinkPointColorToLineColor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkLinkPointColorToLineColor.Location = New System.Drawing.Point(168, 44)
        Me.chkLinkPointColorToLineColor.Name = "chkLinkPointColorToLineColor"
        Me.chkLinkPointColorToLineColor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkLinkPointColorToLineColor.Size = New System.Drawing.Size(113, 17)
        Me.chkLinkPointColorToLineColor.TabIndex = 53
        Me.chkLinkPointColorToLineColor.Text = "Link to Line Color"
        '
        'cboPointStyle
        '
        Me.cboPointStyle.BackColor = System.Drawing.SystemColors.Window
        Me.cboPointStyle.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboPointStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPointStyle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPointStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPointStyle.Location = New System.Drawing.Point(112, 16)
        Me.cboPointStyle.Name = "cboPointStyle"
        Me.cboPointStyle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboPointStyle.Size = New System.Drawing.Size(169, 22)
        Me.cboPointStyle.TabIndex = 50
        '
        '_lblStyle_1
        '
        Me._lblStyle_1.BackColor = System.Drawing.SystemColors.Control
        Me._lblStyle_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStyle_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStyle_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStyle_1.Location = New System.Drawing.Point(8, 17)
        Me._lblStyle_1.Name = "_lblStyle_1"
        Me._lblStyle_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStyle_1.Size = New System.Drawing.Size(80, 17)
        Me._lblStyle_1.TabIndex = 49
        Me._lblStyle_1.Text = "Style"
        '
        '_lblColor_3
        '
        Me._lblColor_3.BackColor = Color.Transparent
        Me._lblColor_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblColor_3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblColor_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblColor_3.Location = New System.Drawing.Point(8, 46)
        Me._lblColor_3.Name = "_lblColor_3"
        Me._lblColor_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblColor_3.Size = New System.Drawing.Size(80, 17)
        Me._lblColor_3.TabIndex = 51
        Me._lblColor_3.Text = "Point Color"
        '
        'fraLineOptions
        '
        Me.fraLineOptions.BackColor = System.Drawing.SystemColors.Control
        Me.fraLineOptions.Controls.Add(Me.chkLinkLineColors)
        Me.fraLineOptions.Controls.Add(Me.txtLineWidth)
        Me.fraLineOptions.Controls.Add(Me.cboLineStyle)
        Me.fraLineOptions.Controls.Add(Me.lblBarFillColorSelection)
        Me.fraLineOptions.Controls.Add(Me._lblColor_2)
        Me.fraLineOptions.Controls.Add(Me._lblColor_1)
        Me.fraLineOptions.Controls.Add(Me.lblLineToBaseColorSelection)
        Me.fraLineOptions.Controls.Add(Me.lblLineColorSelection)
        Me.fraLineOptions.Controls.Add(Me._lblColor_0)
        Me.fraLineOptions.Controls.Add(Me._lblWidth_0)
        Me.fraLineOptions.Controls.Add(Me._lblStyle_0)
        Me.fraLineOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraLineOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraLineOptions.Location = New System.Drawing.Point(8, 384)
        Me.fraLineOptions.Name = "fraLineOptions"
        Me.fraLineOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraLineOptions.Size = New System.Drawing.Size(289, 137)
        Me.fraLineOptions.TabIndex = 36
        Me.fraLineOptions.TabStop = False
        Me.fraLineOptions.Text = "&Line Options"
        '
        'chkLinkLineColors
        '
        Me.chkLinkLineColors.BackColor = System.Drawing.SystemColors.Control
        Me.chkLinkLineColors.Checked = True
        Me.chkLinkLineColors.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLinkLineColors.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkLinkLineColors.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLinkLineColors.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkLinkLineColors.Location = New System.Drawing.Point(184, 80)
        Me.chkLinkLineColors.Name = "chkLinkLineColors"
        Me.chkLinkLineColors.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkLinkLineColors.Size = New System.Drawing.Size(81, 25)
        Me.chkLinkLineColors.TabIndex = 47
        Me.chkLinkLineColors.Text = "Link Line Colors"
        '
        'txtLineWidth
        '
        Me.txtLineWidth.AcceptsReturn = True
        Me.txtLineWidth.AutoSize = False
        Me.txtLineWidth.BackColor = System.Drawing.SystemColors.Window
        Me.txtLineWidth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLineWidth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLineWidth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLineWidth.Location = New System.Drawing.Point(112, 40)
        Me.txtLineWidth.MaxLength = 0
        Me.txtLineWidth.Name = "txtLineWidth"
        Me.txtLineWidth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLineWidth.Size = New System.Drawing.Size(41, 19)
        Me.txtLineWidth.TabIndex = 40
        Me.txtLineWidth.Text = "1"
        '
        'cboLineStyle
        '
        Me.cboLineStyle.BackColor = System.Drawing.SystemColors.Window
        Me.cboLineStyle.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLineStyle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLineStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLineStyle.Location = New System.Drawing.Point(112, 16)
        Me.cboLineStyle.Name = "cboLineStyle"
        Me.cboLineStyle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboLineStyle.Size = New System.Drawing.Size(169, 22)
        Me.cboLineStyle.TabIndex = 38
        '
        '_lblColor_2
        '
        Me._lblColor_2.BackColor = Color.Transparent
        Me._lblColor_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblColor_2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblColor_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblColor_2.Location = New System.Drawing.Point(8, 104)
        Me._lblColor_2.Name = "_lblColor_2"
        Me._lblColor_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblColor_2.Size = New System.Drawing.Size(97, 17)
        Me._lblColor_2.TabIndex = 45
        Me._lblColor_2.Text = "Bar Fill Color"
        '
        '_lblColor_1
        '
        Me._lblColor_1.BackColor = Color.Transparent
        Me._lblColor_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblColor_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblColor_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblColor_1.Location = New System.Drawing.Point(8, 84)
        Me._lblColor_1.Name = "_lblColor_1"
        Me._lblColor_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblColor_1.Size = New System.Drawing.Size(97, 17)
        Me._lblColor_1.TabIndex = 43
        Me._lblColor_1.Text = "Line to Base Color"
        '
        '_lblColor_0
        '
        Me._lblColor_0.BackColor = Color.Transparent
        Me._lblColor_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblColor_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblColor_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblColor_0.Location = New System.Drawing.Point(8, 64)
        Me._lblColor_0.Name = "_lblColor_0"
        Me._lblColor_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblColor_0.Size = New System.Drawing.Size(73, 17)
        Me._lblColor_0.TabIndex = 41
        Me._lblColor_0.Text = "Line Color"
        '
        '_lblWidth_0
        '
        Me._lblWidth_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblWidth_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblWidth_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblWidth_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblWidth_0.Location = New System.Drawing.Point(8, 41)
        Me._lblWidth_0.Name = "_lblWidth_0"
        Me._lblWidth_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblWidth_0.Size = New System.Drawing.Size(57, 17)
        Me._lblWidth_0.TabIndex = 39
        Me._lblWidth_0.Text = "Width"
        '
        '_lblStyle_0
        '
        Me._lblStyle_0.BackColor = System.Drawing.SystemColors.Control
        Me._lblStyle_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblStyle_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblStyle_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblStyle_0.Location = New System.Drawing.Point(8, 17)
        Me._lblStyle_0.Name = "_lblStyle_0"
        Me._lblStyle_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblStyle_0.Size = New System.Drawing.Size(57, 17)
        Me._lblStyle_0.TabIndex = 37
        Me._lblStyle_0.Text = "Style"
        '
        'lblNormalizationConstant
        '
        Me.lblNormalizationConstant.BackColor = System.Drawing.SystemColors.Control
        Me.lblNormalizationConstant.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblNormalizationConstant.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNormalizationConstant.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNormalizationConstant.Location = New System.Drawing.Point(448, 208)
        Me.lblNormalizationConstant.Name = "lblNormalizationConstant"
        Me.lblNormalizationConstant.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNormalizationConstant.Size = New System.Drawing.Size(73, 29)
        Me.lblNormalizationConstant.TabIndex = 71
        Me.lblNormalizationConstant.Text = "Normalized Intensity"
        '
        'frmCWSpectrumOptions
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(601, 528)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtNormalizationConstant)
        Me.Controls.Add(Me.chkNormalizeOnLoadOrPaste)
        Me.Controls.Add(Me.fraAnnotationOptions)
        Me.Controls.Add(Me.cmdResetToDefaults)
        Me.Controls.Add(Me.cmdCopyToAllSeries)
        Me.Controls.Add(Me.fraPlotOptions)
        Me.Controls.Add(Me.fraSeriesOptions)
        Me.Controls.Add(Me.fraControls)
        Me.Controls.Add(Me.fraPointOptions)
        Me.Controls.Add(Me.fraLineOptions)
        Me.Controls.Add(Me.lblNormalizationConstant)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 24)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCWSpectrumOptions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.Text = "Spectrum Options"
        Me.fraAnnotationOptions.ResumeLayout(False)
        Me.fraPlotOptions.ResumeLayout(False)
        Me.fraSeriesOptions.ResumeLayout(False)
        Me.fraControls.ResumeLayout(False)
        Me.fraPointOptions.ResumeLayout(False)
        Me.fraLineOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Const MAX_SERIES_COUNT As Short = 32
    Private Const OK_BUTTON_CAPTION As String = "&OK"
    Private Const CLOSE_BUTTON_CAPTION As String = "Cl&ose"

    Private Const DEFAULT_FONT_NAME As String = "Arial"
    Private Const DEFAULT_FONT_SIZE As Short = 11
    Private Const DEFAULT_ANNOTATION_FONT_SIZE As Short = 10

    Private Structure udtGridlinesOptionsSavedType
        Dim ShowMajorX As Boolean
        Dim ShowMajorY As Boolean
        Dim ShowMinorX As Boolean
        Dim ShowMinorY As Boolean
        Dim GridlinesMajorColor As Color
        Dim GridlinesMinorColor As Color
    End Structure

    Private Structure udtPlotOptionsSavedType
        Dim Title As String
        Dim SubTitle As String
        Dim XAxisLabel As String
        Dim YAxisLabel As String
        Dim FontColor As Color
        Dim FontName As String
        Dim FontSize As Short
        Dim GridLines As udtGridlinesOptionsSavedType
        Dim Cursor1Color As Color
        Dim Cursor2Color As Color
        Dim BackgroundColor As Color
        Dim FrameBorderColor As Color
        Dim FrameStyle3D As Boolean
        Dim NormalizeOnLoadOrPaste As Boolean
        Dim NormalizationConstant As Double
    End Structure

    Private Structure udtSeriesOptionsSavedType
        Dim LegendCaption As String
        Dim PlotMode As CWGraphControl.pmPlotModeConstants
        Dim LineStyle As CWUIControlsLib.CWLineStyles
        Dim LineWidth As Short
        Dim LineColor As Color
        Dim LineToBaseColor As Color
        Dim BarFillColor As Color
        Dim PointStyle As CWUIControlsLib.CWPointStyles
        Dim PointColor As Color
        Dim AnnotationFontColor As Color
        Dim AnnotationFontName As String
        Dim AnnotationFontSize As Short
    End Structure

    Private Structure udtOptionsSavedType
        Dim PlotOptions As udtPlotOptionsSavedType
        Dim SeriesOptions() As udtSeriesOptionsSavedType ' 1-based array
        Dim SeriesCount As Short
    End Structure

    Private mFontNameList() As String
    Private mFontNameListInitialized As Boolean

    Private udtOptionsSaved As udtOptionsSavedType
    Private udtOptionsNew As udtOptionsSavedType

    Private mSpectrumForm As frmCWSpectrum

    Private mUpdatingControls As Boolean
    '

    Private Sub ApplyChanges()

        Dim intSeriesIndex As Short
        Dim intCurrentSeriesNumber As Short

        intCurrentSeriesNumber = cboSeriesNumber.SelectedIndex + 1

        On Error Resume Next
        With mSpectrumForm
            .SetNormalizeOnLoadOrPaste(udtOptionsNew.PlotOptions.NormalizeOnLoadOrPaste)
            .SetNormalizationConstant(udtOptionsNew.PlotOptions.NormalizationConstant)
        End With

        With mSpectrumForm.ctlCWGraph
            .SetLabelTitle(udtOptionsNew.PlotOptions.Title)
            .SetLabelSubTitle(udtOptionsNew.PlotOptions.SubTitle)
            .SetLabelXAxis(udtOptionsNew.PlotOptions.XAxisLabel)
            .SetLabelYAxis(udtOptionsNew.PlotOptions.YAxisLabel)

            .SetLabelFontColor(udtOptionsNew.PlotOptions.FontColor)
            .SetLabelFontName(udtOptionsNew.PlotOptions.FontName)
            .SetLabelFontSize(udtOptionsNew.PlotOptions.FontSize)

            .SetGridLinesXColor(udtOptionsNew.PlotOptions.GridLines.GridlinesMajorColor, True, True)
            .SetGridLinesXColor(udtOptionsNew.PlotOptions.GridLines.GridlinesMinorColor, False, True)

            .SetGridLinesXVisible(udtOptionsNew.PlotOptions.GridLines.ShowMajorX, True)
            .SetGridLinesXVisible(udtOptionsNew.PlotOptions.GridLines.ShowMinorX, False)

            .SetGridLinesYVisible(udtOptionsNew.PlotOptions.GridLines.ShowMajorY, True)
            .SetGridLinesYVisible(udtOptionsNew.PlotOptions.GridLines.ShowMinorY, False)

            .SetCursorColor(udtOptionsNew.PlotOptions.Cursor1Color, 1)
            .SetCursorColor(udtOptionsNew.PlotOptions.Cursor2Color, 2)
            .SetPlotBackgroundColor(udtOptionsNew.PlotOptions.BackgroundColor)

            .SetFrameColor(udtOptionsNew.PlotOptions.FrameBorderColor)
            .SetFrameStyle(udtOptionsNew.PlotOptions.FrameStyle3D)

            For intSeriesIndex = 1 To udtOptionsNew.SeriesCount
                .SetSeriesLegendCaption(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).LegendCaption)

                .SetSeriesLineStyle(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).LineStyle)
                .SetSeriesLineWidth(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).LineWidth)
                .SetSeriesLineColor(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).LineColor)
                .SetSeriesLineToBaseColor(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).LineToBaseColor)
                .SetSeriesBarFillColor(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).BarFillColor)
                .SetSeriesPointStyle(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).PointStyle)
                .SetSeriesPointColor(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).PointColor)

                ' Need to do this last since it may update some of the line and point styles
                .SetSeriesPlotMode(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).PlotMode)

                .SetAnnotationFontColor(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).AnnotationFontColor)
                .SetAnnotationFontName(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).AnnotationFontName)
                .SetAnnotationFontSize(intSeriesIndex, udtOptionsNew.SeriesOptions(intSeriesIndex).AnnotationFontSize)

                ' Re-update the current options, in case any of them got changed by the control due to an invalid value
                udtOptionsNew.SeriesOptions(intSeriesIndex).LineStyle = .GetSeriesLineStyle(intSeriesIndex)
                udtOptionsNew.SeriesOptions(intSeriesIndex).LineWidth = .GetSeriesLineWidth(intSeriesIndex)
                udtOptionsNew.SeriesOptions(intSeriesIndex).LineColor = .GetSeriesLineColor(intSeriesIndex)
                udtOptionsNew.SeriesOptions(intSeriesIndex).LineToBaseColor = .GetSeriesLineToBaseColor(intSeriesIndex)
                udtOptionsNew.SeriesOptions(intSeriesIndex).BarFillColor = .GetSeriesBarFillColor(intSeriesIndex)

                udtOptionsNew.SeriesOptions(intSeriesIndex).PointStyle = .GetSeriesPointStyle(intSeriesIndex)
                udtOptionsNew.SeriesOptions(intSeriesIndex).PointColor = .GetSeriesPointColor(intSeriesIndex)

                udtOptionsNew.SeriesOptions(intSeriesIndex).AnnotationFontColor = .GetAnnotationFontColor(intSeriesIndex)
                udtOptionsNew.SeriesOptions(intSeriesIndex).AnnotationFontName = .GetAnnotationFontName(intSeriesIndex)
                udtOptionsNew.SeriesOptions(intSeriesIndex).AnnotationFontSize = .GetAnnotationFontSize(intSeriesIndex)

            Next intSeriesIndex
        End With

        mSpectrumForm.SetCurrentSeriesNumber(intCurrentSeriesNumber)

        ShowOptionsForSeries(intCurrentSeriesNumber)
        SetOKButtonCaption(True)

    End Sub

    Private Sub CopyCurrentSettingsToAllSeries()
        Dim intSeriesIndex As Short
        Dim intCurrentSeriesNumber As Short

        If cboSeriesNumber.SelectedIndex < 0 Then Exit Sub

        intCurrentSeriesNumber = cboSeriesNumber.SelectedIndex + 1

        With udtOptionsNew
            For intSeriesIndex = 1 To .SeriesCount
                .SeriesOptions(intSeriesIndex) = .SeriesOptions(intCurrentSeriesNumber)
            Next intSeriesIndex
        End With

        SetOKButtonCaption(False)
    End Sub

    Private Sub EnableDisableStyleControls()

        Select Case cboPlotMode.SelectedIndex
            Case CWGraphControl.pmPlotModeConstants.pmLines
                cboLineStyle.Enabled = True
                cboPointStyle.Enabled = False
            Case CWGraphControl.pmPlotModeConstants.pmSticksToZero
                cboLineStyle.Enabled = False
                cboPointStyle.Enabled = False
            Case CWGraphControl.pmPlotModeConstants.pmBar
                cboLineStyle.Enabled = True
                cboPointStyle.Enabled = False
            Case CWGraphControl.pmPlotModeConstants.pmPoints
                cboLineStyle.Enabled = False
                cboPointStyle.Enabled = True
            Case CWGraphControl.pmPlotModeConstants.pmPointsAndLines
                cboLineStyle.Enabled = True
                cboPointStyle.Enabled = True
            Case Else
                cboLineStyle.Enabled = True
                cboPointStyle.Enabled = True
        End Select

    End Sub

    Private Sub InitializeCurrentSettings(Optional ByRef intCurrentSeriesNumber As Short = 1)
        Dim intSeriesIndex As Short

        If mSpectrumForm Is Nothing Then Exit Sub

        With mSpectrumForm
            udtOptionsSaved.PlotOptions.NormalizeOnLoadOrPaste = .GetNormalizeOnLoadOrPaste()
            udtOptionsSaved.PlotOptions.NormalizationConstant = .GetNormalizationConstant()
        End With

        ReDim udtOptionsSaved.SeriesOptions(MAX_SERIES_COUNT + 1)

        With mSpectrumForm.ctlCWGraph
            udtOptionsSaved.PlotOptions.Title = .GetLabelTitle()
            udtOptionsSaved.PlotOptions.SubTitle = .GetLabelSubtitle()
            udtOptionsSaved.PlotOptions.XAxisLabel = .GetLabelXAxis()
            udtOptionsSaved.PlotOptions.YAxisLabel = .GetLabelYAxis()
            udtOptionsSaved.PlotOptions.FontColor = .GetLabelFontColor()
            udtOptionsSaved.PlotOptions.FontName = .GetLabelFontName()
            udtOptionsSaved.PlotOptions.FontSize = .GetLabelFontSize()

            udtOptionsSaved.PlotOptions.GridLines.GridlinesMajorColor = .GetGridLinesXColor(True)
            udtOptionsSaved.PlotOptions.GridLines.GridlinesMinorColor = .GetGridLinesXColor(False)

            udtOptionsSaved.PlotOptions.GridLines.ShowMajorX = .GetGridLinesXVisible(True)
            udtOptionsSaved.PlotOptions.GridLines.ShowMinorX = .GetGridLinesXVisible(False)
            udtOptionsSaved.PlotOptions.GridLines.ShowMajorY = .GetGridlinesYVisible(True)
            udtOptionsSaved.PlotOptions.GridLines.ShowMinorY = .GetGridlinesYVisible(False)

            udtOptionsSaved.PlotOptions.Cursor1Color = .GetCursorColor(1)
            udtOptionsSaved.PlotOptions.Cursor2Color = .GetCursorColor(2)
            udtOptionsSaved.PlotOptions.BackgroundColor = .GetPlotBackgroundColor()

            udtOptionsSaved.PlotOptions.FrameBorderColor = .GetFrameColor()
            udtOptionsSaved.PlotOptions.FrameStyle3D = .GetFrameStyleIs3D()

            udtOptionsSaved.SeriesCount = .GetSeriesCount()
            If udtOptionsSaved.SeriesCount > MAX_SERIES_COUNT Then udtOptionsSaved.SeriesCount = MAX_SERIES_COUNT

            For intSeriesIndex = 1 To udtOptionsSaved.SeriesCount
                udtOptionsSaved.SeriesOptions(intSeriesIndex).LegendCaption = .GetSeriesLegendCaption(intSeriesIndex)
                udtOptionsSaved.SeriesOptions(intSeriesIndex).PlotMode = .GetSeriesPlotMode(intSeriesIndex)
                udtOptionsSaved.SeriesOptions(intSeriesIndex).LineStyle = .GetSeriesLineStyle(intSeriesIndex)
                udtOptionsSaved.SeriesOptions(intSeriesIndex).LineWidth = .GetSeriesLineWidth(intSeriesIndex)
                udtOptionsSaved.SeriesOptions(intSeriesIndex).LineColor = .GetSeriesLineColor(intSeriesIndex)
                udtOptionsSaved.SeriesOptions(intSeriesIndex).LineToBaseColor = .GetSeriesLineToBaseColor(intSeriesIndex)
                udtOptionsSaved.SeriesOptions(intSeriesIndex).BarFillColor = .GetSeriesBarFillColor(intSeriesIndex)

                udtOptionsSaved.SeriesOptions(intSeriesIndex).AnnotationFontColor = .GetAnnotationFontColor(intSeriesIndex)
                udtOptionsSaved.SeriesOptions(intSeriesIndex).AnnotationFontName = .GetAnnotationFontName(intSeriesIndex)
                udtOptionsSaved.SeriesOptions(intSeriesIndex).AnnotationFontSize = .GetAnnotationFontSize(intSeriesIndex)

                udtOptionsSaved.SeriesOptions(intSeriesIndex).PointStyle = .GetSeriesPointStyle(intSeriesIndex)
                udtOptionsSaved.SeriesOptions(intSeriesIndex).PointColor = .GetSeriesPointColor(intSeriesIndex)

            Next intSeriesIndex
        End With

        udtOptionsNew = udtOptionsSaved

        ShowOptionsForSeries(intCurrentSeriesNumber)

        SetOKButtonCaption(True)

    End Sub

    Public Sub InitializeForm(ByRef frmCallingForm As frmCWSpectrum, Optional ByRef intCurrentSeriesNumber As Short = 1, Optional ByRef blnInitializeCurrentSettings As Boolean = False)
        ' Note: Setting blnInitializeCurrentSettings to True is only needed if this form gets called programatically
        '       The reason for this, is that Form_Activate will get called via frmCWSpectrumOptions.Show

        If mSpectrumForm Is Nothing Then
            mSpectrumForm = frmCallingForm
        End If

        SetOKButtonCaption(True)

        PopulateComboBoxes()

        If blnInitializeCurrentSettings Then
            InitializeCurrentSettings(intCurrentSeriesNumber)
        End If

    End Sub

    Private Sub PopulateComboBoxes(Optional ByRef blnForceRepopulation As Boolean = False)
        Dim intSeriesNumber As Short
        Dim intFontIndex As Integer
        Dim intSize As Integer

        Dim ff As FontFamily

        If mUpdatingControls Then Exit Sub
        mUpdatingControls = True

        If cboPlotMode.Items.Count > 0 Then
            If Not blnForceRepopulation Then
                mUpdatingControls = False
                Exit Sub
            End If
        End If

        With cboAnnotationFontName
            .Items.Clear()
            cboLabelFontName.Items.Clear()

            If Not mFontNameListInitialized Then
                ReDim mFontNameList(0)
                intFontIndex = 0

                For Each ff In System.Drawing.FontFamily.Families
                    ReDim Preserve mFontNameList(intFontIndex)
                    mFontNameList(intFontIndex) = ff.Name
                    intFontIndex += 1
                Next

                mFontNameListInitialized = True
            End If

            On Error GoTo PopulateComboBoxesErrorHandler

            For intFontIndex = 0 To UBound(mFontNameList)
                .Items.Add(mFontNameList(intFontIndex))
                cboLabelFontName.Items.Add(mFontNameList(intFontIndex))
            Next intFontIndex

            ' Find and highlight the line with DEFAULT_FONT_NAME
            For intFontIndex = 0 To .Items.Count - 1

                If CStr(cboAnnotationFontName.Items(intFontIndex)).ToLower = DEFAULT_FONT_NAME.ToLower Then
                    .SelectedIndex = intFontIndex
                    cboLabelFontName.SelectedIndex = intFontIndex
                    Exit For
                End If
            Next intFontIndex
        End With

        With cboAnnotationFontSize
            .Items.Clear()
            For intSize = 6 To 12
                .Items.Add(intSize.ToString.Trim)
            Next intSize

            For intSize = 14 To 24 Step 2
                .Items.Add(intSize.ToString.Trim)
            Next intSize

            For intSize = 28 To 48 Step 4
                .Items.Add(intSize.ToString.Trim)
            Next intSize

            For intSize = 56 To 128 Step 8
                .Items.Add(intSize.ToString.Trim)
            Next intSize

            .SelectedIndex = 5
        End With

        With cboLabelFontSize
            .Items.Clear()
            For intSize = 0 To cboAnnotationFontSize.Items.Count - 1
                .Items.Add(cboAnnotationFontSize.Items(intSize))
            Next intSize
            .SelectedIndex = cboAnnotationFontSize.SelectedIndex
        End With

        With cboSeriesNumber
            .Items.Clear()
            For intSeriesNumber = 1 To mSpectrumForm.ctlCWGraph.GetSeriesCount()
                .Items.Add("Series " & intSeriesNumber.ToString.Trim)
                If intSeriesNumber >= MAX_SERIES_COUNT Then Exit For
            Next intSeriesNumber
        End With

        With cboPlotMode
            .Items.Clear()
            .Items.Add("Lines Between Points")
            .Items.Add("Stick To Zero")
            .Items.Add("Bars")
            .Items.Add("Points Only")
            .Items.Add("Lines and Points ")
        End With

        With cboLineStyle
            .Items.Clear()
            .Items.Add("No line") ' 0
            .Items.Add("Solid line") ' 1
            .Items.Add("Step XY line") ' 2
            .Items.Add("Step YX line") ' 3
            .Items.Add("Dashed line") ' 4
            .Items.Add("Dotted line") ' 5
            .Items.Add("Dash-dot line") ' 6
            .Items.Add("Dash-dot-dot line") ' 7
        End With

        With cboPointStyle
            .Items.Clear()
            .Items.Add("None") ' 0
            .Items.Add("Empty square") ' 1
            .Items.Add("Solid square") ' 2
            .Items.Add("Asterisk") ' 3
            .Items.Add("Dotted empty square") ' 4
            .Items.Add("Dotted solid square") ' 5
            .Items.Add("Solid diamond") ' 6
            .Items.Add("Empty square with X") ' 7
            .Items.Add("Empty square with cross") ' 8
            .Items.Add("Empty circle") ' 9
            .Items.Add("Solid circle") ' 10
            .Items.Add("Dotted empty circle") ' 11
            .Items.Add("Dotted solid circle") ' 12
            .Items.Add("X") ' 13
            .Items.Add("Bold X") ' 14
            .Items.Add("Small X") ' 15
            .Items.Add("Cross") ' 16
            .Items.Add("Bold cross") ' 17
            .Items.Add("Small cross") ' 18
            .Items.Add("Small empty square") ' 19
            .Items.Add("Small solid square") ' 20
            .Items.Add("Simple dot") ' 21
            .Items.Add("Empty diamond") ' 22
        End With

        mUpdatingControls = False

        Exit Sub

PopulateComboBoxesErrorHandler:
        System.Diagnostics.Debug.WriteLine("Error in frmCWSpectrumOptions.PopulateComboBoxes(): " & Err.Description)
        Exit Sub

    End Sub

    Private Sub SetOKButtonCaption(ByRef blnShowClose As Boolean)
        If blnShowClose Then
            cmdOK.Text = CLOSE_BUTTON_CAPTION
            Me.CancelButton = cmdOK
            cmdApply.Enabled = False
        Else
            cmdOK.Text = OK_BUTTON_CAPTION
            Me.CancelButton = Nothing
            cmdApply.Enabled = True
        End If

        Me.AcceptButton = cmdOK

    End Sub

    Private Sub ResetToDefaults()
        Dim intSeriesIndex As Short

        With udtOptionsNew
            With .PlotOptions
                .FontColor = Color.Black
                .FontName = DEFAULT_FONT_NAME
                .FontSize = DEFAULT_FONT_SIZE
                With .GridLines
                    .GridlinesMajorColor = Color.Black
                    .GridlinesMinorColor = Color.DimGray
                    .ShowMajorX = False
                    .ShowMajorY = False
                    .ShowMinorX = False
                    .ShowMinorY = False
                End With
                .Cursor1Color = Color.Black
                .Cursor2Color = Color.DimGray
                .BackgroundColor = Color.White

                .FrameBorderColor = Color.FromArgb(236, 233, 216)       ' This is a very light gray color
                .FrameStyle3D = True

                .NormalizeOnLoadOrPaste = True
                .NormalizationConstant = 100
            End With

            ReDim Preserve .SeriesOptions(MAX_SERIES_COUNT + 1)

            With .SeriesOptions(1)
                .LegendCaption = ""
                .PlotMode = CWGraphControl.pmPlotModeConstants.pmLines
                .LineStyle = CWUIControlsLib.CWLineStyles.cwLineSolid
                .LineWidth = 1
                .LineColor = mSpectrumForm.ctlCWGraph.GetDefaultSeriesColor(1)
                .LineToBaseColor = .LineColor
                .BarFillColor = .LineColor
                .PointStyle = CWUIControlsLib.CWPointStyles.cwPointNone
                .PointColor = .LineColor
                .AnnotationFontColor = Color.Black
                .AnnotationFontName = DEFAULT_FONT_NAME
                .AnnotationFontSize = DEFAULT_ANNOTATION_FONT_SIZE
            End With

            For intSeriesIndex = 2 To .SeriesCount
                .SeriesOptions(intSeriesIndex) = .SeriesOptions(1)
                .SeriesOptions(intSeriesIndex).LineColor = mSpectrumForm.ctlCWGraph.GetDefaultSeriesColor(intSeriesIndex)
                .SeriesOptions(intSeriesIndex).LineToBaseColor = .SeriesOptions(intSeriesIndex).LineColor
                .SeriesOptions(intSeriesIndex).BarFillColor = .SeriesOptions(intSeriesIndex).LineColor
                .SeriesOptions(intSeriesIndex).PointColor = .SeriesOptions(intSeriesIndex).LineColor
            Next
        End With

        If cboSeriesNumber.SelectedIndex >= 0 Then
            ShowOptionsForSeries(cboSeriesNumber.SelectedIndex + 1)
        End If

        SetOKButtonCaption(False)

    End Sub

    Private Sub SelectCustomColor(ByRef lblThisLabel As System.Windows.Forms.Label)

        With dlgColor
            .Color = lblThisLabel.BackColor
            .SolidColorOnly = False

            If .ShowDialog() = DialogResult.OK Then
                lblThisLabel.BackColor = .Color
            End If
        End With

    End Sub

    Private Sub ShowOptionsForSeries(ByRef intSeriesNumber As Short)

        On Error GoTo ShowOptionsForSeriesErrorHandler

        If intSeriesNumber < 1 Or intSeriesNumber > cboSeriesNumber.Items.Count Then
            System.Diagnostics.Debug.Assert(False, "Invalid series number in frmCWSpectrumOptions.ShowOptionsForSeries")
            Exit Sub
        End If

        If mUpdatingControls Then Exit Sub
        mUpdatingControls = True

        With udtOptionsNew.PlotOptions
            txtPlotTitle.Text = .Title
            txtPlotSubTitle.Text = .SubTitle
            txtXAxisLabel.Text = .XAxisLabel
            txtYAxisLabel.Text = .YAxisLabel

            lblLabelFontColorSelection.BackColor = .FontColor
            cboLabelFontName.Text = .FontName
            cboLabelFontSize.Text = CStr(.FontSize)

            With .GridLines
                lblGridLinesMajorColorSelection.BackColor = .GridlinesMajorColor
                lblGridLinesMinorColorSelection.BackColor = .GridlinesMinorColor

                chkShowGridlinesMajorX.Checked = .ShowMajorX
                chkShowGridlinesMinorX.Checked = .ShowMinorX
                chkShowGridlinesMajorY.Checked = .ShowMajorY
                chkShowGridlinesMinorY.Checked = .ShowMinorY
            End With

            lblCursor1ColorSelection.BackColor = .Cursor1Color
            lblCursor2ColorSelection.BackColor = .Cursor2Color
            lblPlotBackgroundColorSelection.BackColor = .BackgroundColor

            lblFrameBorderColorSelection.BackColor = .FrameBorderColor
            chkFrameStyle3D.Checked = .FrameStyle3D

            txtNormalizationConstant.Text = CStr(.NormalizationConstant)
            chkNormalizeOnLoadOrPaste.Checked = .NormalizeOnLoadOrPaste
        End With

        With udtOptionsNew.SeriesOptions(intSeriesNumber)

            cboSeriesNumber.SelectedIndex = intSeriesNumber - 1

            txtLegendCaption.Text = .LegendCaption

            cboPlotMode.SelectedIndex = .PlotMode

            cboLineStyle.SelectedIndex = .LineStyle
            txtLineWidth.Text = CStr(.LineWidth)

            lblLineColorSelection.BackColor = .LineColor
            lblLineToBaseColorSelection.BackColor = .LineToBaseColor
            lblBarFillColorSelection.BackColor = .BarFillColor

            cboPointStyle.SelectedIndex = .PointStyle
            lblPointColorSelection.BackColor = .PointColor

            If lblLineColorSelection.BackColor.Equals(lblLineToBaseColorSelection.BackColor) And lblLineColorSelection.BackColor.Equals(lblBarFillColorSelection.BackColor) Then
                chkLinkLineColors.Checked = True
            Else
                chkLinkLineColors.Checked = False
            End If

            If lblPointColorSelection.BackColor.Equals(lblLineColorSelection.BackColor) Then
                chkLinkPointColorToLineColor.Checked = True
            Else
                chkLinkPointColorToLineColor.Checked = False
            End If

            lblAnnotationColorSelection.BackColor = .AnnotationFontColor
            If Len(.AnnotationFontName) > 0 Then
                cboAnnotationFontName.Text = .AnnotationFontName
            Else
                cboAnnotationFontName.Text = DEFAULT_FONT_NAME
            End If

            If .AnnotationFontSize > 0 Then
                cboAnnotationFontSize.Text = CStr(.AnnotationFontSize)
            Else
                cboAnnotationFontSize.Text = CStr(DEFAULT_ANNOTATION_FONT_SIZE)
            End If

        End With

        mUpdatingControls = False
        Exit Sub

ShowOptionsForSeriesErrorHandler:
        MsgBox("Error in sub frmCWSpectrumOptions.ShowOptionsForSeries:" & vbCrLf & Err.Description, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        mUpdatingControls = False

    End Sub

    Private Sub SynchronizeLineColors(cNewColor As Color)
        Static blnSynchronizing As Boolean

        If blnSynchronizing Then Exit Sub
        blnSynchronizing = True

        If chkLinkLineColors.Checked Then
            lblLineColorSelection.BackColor = cNewColor
            lblLineToBaseColorSelection.BackColor = cNewColor
            lblBarFillColorSelection.BackColor = cNewColor
        End If

        SynchronizePointColorWithLineColor(cNewColor)

        blnSynchronizing = False

        UpdateCurrentOptions()
    End Sub

    Private Sub SynchronizePointColorWithLineColor(ByRef cNewColor As Color)
        Static blnSynchronizing As Boolean

        If blnSynchronizing Then Exit Sub
        blnSynchronizing = True

        If chkLinkPointColorToLineColor.Checked Then
            lblLineColorSelection.BackColor = cNewColor
            lblPointColorSelection.BackColor = cNewColor
        End If

        blnSynchronizing = False

        UpdateCurrentOptions()
    End Sub

    Private Sub UpdateCurrentOptions()
        Static UpdatingOptions As Boolean

        If mUpdatingControls OrElse UpdatingOptions OrElse cboSeriesNumber.SelectedIndex < 0 Then Exit Sub

        UpdatingOptions = True

        With udtOptionsNew.PlotOptions
            .Title = txtPlotTitle.Text
            .SubTitle = txtPlotSubTitle.Text
            .XAxisLabel = txtXAxisLabel.Text
            .YAxisLabel = txtYAxisLabel.Text

            .FontColor = lblLabelFontColorSelection.BackColor
            .FontName = cboLabelFontName.Text
            .FontSize = CShort(cboLabelFontSize.Text)

            With .GridLines
                .ShowMajorX = chkShowGridlinesMajorX.Checked
                .ShowMajorY = chkShowGridlinesMajorY.Checked

                .ShowMinorX = chkShowGridlinesMinorX.Checked
                .ShowMinorY = chkShowGridlinesMinorY.Checked

                .GridlinesMajorColor = lblGridLinesMajorColorSelection.BackColor
                .GridlinesMinorColor = lblGridLinesMinorColorSelection.BackColor
            End With

            .Cursor1Color = lblCursor1ColorSelection.BackColor
            .Cursor2Color = lblCursor2ColorSelection.BackColor
            .BackgroundColor = lblPlotBackgroundColorSelection.BackColor

            .FrameBorderColor = lblFrameBorderColorSelection.BackColor
            .FrameStyle3D = chkFrameStyle3D.Checked

            .NormalizeOnLoadOrPaste = chkNormalizeOnLoadOrPaste.Checked
            .NormalizationConstant = SharedVBNetRoutines.VBNetRoutines.CDblSafe(txtNormalizationConstant.Text)
        End With

        With udtOptionsNew.SeriesOptions(cboSeriesNumber.SelectedIndex + 1)

            If .PlotMode <> cboPlotMode.SelectedIndex Then
                .PlotMode = cboPlotMode.SelectedIndex

                Select Case .PlotMode
                    Case CWGraphControl.pmPlotModeConstants.pmLines
                        If cboLineStyle.SelectedIndex = CWUIControlsLib.CWLineStyles.cwLineNone Then cboLineStyle.SelectedIndex = CWUIControlsLib.CWLineStyles.cwLineSolid
                        If cboPointStyle.SelectedIndex <> CWUIControlsLib.CWPointStyles.cwPointNone Then cboPointStyle.SelectedIndex = CWUIControlsLib.CWPointStyles.cwPointNone
                    Case CWGraphControl.pmPlotModeConstants.pmSticksToZero
                        If cboLineStyle.SelectedIndex <> CWUIControlsLib.CWLineStyles.cwLineNone Then cboLineStyle.SelectedIndex = CWUIControlsLib.CWLineStyles.cwLineNone
                        If cboPointStyle.SelectedIndex <> CWUIControlsLib.CWPointStyles.cwPointNone Then cboPointStyle.SelectedIndex = CWUIControlsLib.CWPointStyles.cwPointNone
                        If lblLineToBaseColorSelection.BackColor.Equals(Color.Black) Then lblLineToBaseColorSelection.BackColor = Color.White
                    Case CWGraphControl.pmPlotModeConstants.pmBar
                        If cboLineStyle.SelectedIndex <> CWUIControlsLib.CWLineStyles.cwLineStepXY Then cboLineStyle.SelectedIndex = CWUIControlsLib.CWLineStyles.cwLineStepXY
                        If cboPointStyle.SelectedIndex <> CWUIControlsLib.CWPointStyles.cwPointNone Then cboPointStyle.SelectedIndex = CWUIControlsLib.CWPointStyles.cwPointNone
                        If lblLineToBaseColorSelection.BackColor.Equals(Color.Black) Then lblLineToBaseColorSelection.BackColor = Color.White
                        If lblBarFillColorSelection.BackColor.Equals(Color.Black) Then lblBarFillColorSelection.BackColor = Color.White
                    Case CWGraphControl.pmPlotModeConstants.pmPoints
                        If cboLineStyle.SelectedIndex <> CWUIControlsLib.CWLineStyles.cwLineNone Then cboLineStyle.SelectedIndex = CWUIControlsLib.CWLineStyles.cwLineNone
                        If cboPointStyle.SelectedIndex = CWUIControlsLib.CWPointStyles.cwPointNone Then cboPointStyle.SelectedIndex = CWUIControlsLib.CWPointStyles.cwPointSolidSquare
                    Case CWGraphControl.pmPlotModeConstants.pmPointsAndLines
                        If cboLineStyle.SelectedIndex = CWUIControlsLib.CWLineStyles.cwLineNone Then cboLineStyle.SelectedIndex = CWUIControlsLib.CWLineStyles.cwLineSolid
                        If cboPointStyle.SelectedIndex = CWUIControlsLib.CWPointStyles.cwPointNone Then cboPointStyle.SelectedIndex = CWUIControlsLib.CWPointStyles.cwPointSolidSquare
                End Select

            End If

            .LegendCaption = txtLegendCaption.Text

            .LineStyle = cboLineStyle.SelectedIndex
            .LineWidth = SharedVBNetRoutines.VBNetRoutines.CIntSafe(txtLineWidth.Text)
            .LineColor = lblLineColorSelection.BackColor
            .LineToBaseColor = lblLineToBaseColorSelection.BackColor
            .BarFillColor = lblBarFillColorSelection.BackColor

            .PointStyle = cboPointStyle.SelectedIndex
            .PointColor = lblPointColorSelection.BackColor

            .AnnotationFontColor = lblAnnotationColorSelection.BackColor
            .AnnotationFontName = cboAnnotationFontName.Text
            .AnnotationFontSize = CShort(cboAnnotationFontSize.Text)
        End With

        SetOKButtonCaption(False)

        UpdatingOptions = False

    End Sub

    Private Sub cboAnnotationFontName_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboAnnotationFontName.SelectedIndexChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub cboAnnotationFontSize_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboAnnotationFontSize.SelectedIndexChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub cboLabelFontName_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboLabelFontName.SelectedIndexChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub cboLabelFontSize_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboLabelFontSize.SelectedIndexChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub cboLineStyle_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboLineStyle.SelectedIndexChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub cboPlotMode_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboPlotMode.SelectedIndexChanged
        UpdateCurrentOptions()
        EnableDisableStyleControls()
    End Sub

    Private Sub cboPointStyle_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboPointStyle.SelectedIndexChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub cboSeriesNumber_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboSeriesNumber.SelectedIndexChanged
        ShowOptionsForSeries(cboSeriesNumber.SelectedIndex + 1)
    End Sub

    Private Sub chkFrameStyle3D_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFrameStyle3D.CheckedChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub chkLinkLineColors_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkLinkLineColors.CheckedChanged
        If chkLinkLineColors.Checked Then
            SynchronizeLineColors(lblLineColorSelection.BackColor)
        End If
    End Sub

    Private Sub chkLinkPointColorToLineColor_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkLinkPointColorToLineColor.CheckedChanged
        If chkLinkPointColorToLineColor.Checked Then
            SynchronizePointColorWithLineColor(lblLineColorSelection.BackColor)
        End If
    End Sub

    Private Sub chkNormalizeOnLoadOrPaste_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkNormalizeOnLoadOrPaste.CheckedChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub chkShowGridlinesMajorX_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkShowGridlinesMajorX.CheckedChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub chkShowGridlinesMajorY_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkShowGridlinesMajorY.CheckedChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub chkShowGridlinesMinorX_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkShowGridlinesMinorX.CheckedChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub chkShowGridlinesMinorY_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkShowGridlinesMinorY.CheckedChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub cmdApply_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdApply.Click
        ApplyChanges()
    End Sub

    Private Sub cmdCancel_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdCancel.Click

        ' Restore the saved options, then call ApplyChanges
        udtOptionsNew = udtOptionsSaved

        ApplyChanges()

        Me.Close()
    End Sub

    Private Sub cmdCopyToAllSeries_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdCopyToAllSeries.Click
        CopyCurrentSettingsToAllSeries()
    End Sub

    Private Sub cmdOK_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdOK.Click
        If cmdOK.Text = OK_BUTTON_CAPTION Then
            ApplyChanges()
        End If
        Me.Close()
    End Sub

    Private Sub cmdResetToDefaults_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdResetToDefaults.Click
        ResetToDefaults()
    End Sub

    Private Sub cmdSaveStyle_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdSaveStyle.Click
        MsgBox("Not yet enabled")
    End Sub

    Private Sub cmdStyleLoad_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdStyleLoad.Click
        MsgBox("Not yet enabled")
    End Sub

    Private Sub frmCWSpectrumOptions_Activated(eventSender As System.Object, eventArgs As System.EventArgs) Handles MyBase.Activated

        ' Only update with the current settings if the user hasn't made any changes
        If cmdOK.Text = CLOSE_BUTTON_CAPTION Then
            If cboSeriesNumber.SelectedIndex >= 0 Then
                InitializeCurrentSettings(cboSeriesNumber.SelectedIndex + 1)
            Else
                InitializeCurrentSettings()
            End If
        End If

    End Sub

    Private Sub frmCWSpectrumOptions_Load(eventSender As System.Object, eventArgs As System.EventArgs) Handles MyBase.Load
        SizeAndCenterWindow(Me, modCWSpectrum.wpcWindowPosConstants.UpperThird, 607, 560)

        PopulateComboBoxes()
    End Sub

    Private Sub frmCWSpectrumOptions_Closed(eventSender As System.Object, eventArgs As System.EventArgs) Handles MyBase.Closed
        mSpectrumForm = Nothing
    End Sub

    Private Sub lblAnnotationColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblAnnotationColorSelection.Click
        SelectCustomColor(lblAnnotationColorSelection)

        UpdateCurrentOptions()
    End Sub

    Private Sub lblBarFillColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblBarFillColorSelection.Click
        SelectCustomColor(lblBarFillColorSelection)
        SynchronizeLineColors(lblBarFillColorSelection.BackColor)
    End Sub

    Private Sub lblCursor1ColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblCursor1ColorSelection.Click
        SelectCustomColor(lblCursor1ColorSelection)
        UpdateCurrentOptions()
    End Sub

    Private Sub lblCursor2ColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblCursor2ColorSelection.Click
        SelectCustomColor(lblCursor2ColorSelection)
        UpdateCurrentOptions()
    End Sub

    Private Sub lblFrameBorderColorSelection_Click(sender As System.Object, e As System.EventArgs) Handles lblFrameBorderColorSelection.Click
        SelectCustomColor(lblFrameBorderColorSelection)
        UpdateCurrentOptions()
    End Sub

    Private Sub lblGridLinesMajorColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblGridLinesMajorColorSelection.Click
        SelectCustomColor(lblGridLinesMajorColorSelection)
        UpdateCurrentOptions()
    End Sub

    Private Sub lblGridLinesMinorColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblGridLinesMinorColorSelection.Click
        SelectCustomColor(lblGridLinesMinorColorSelection)
        UpdateCurrentOptions()
    End Sub

    Private Sub lblLabelFontColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblLabelFontColorSelection.Click
        SelectCustomColor(lblLabelFontColorSelection)
        UpdateCurrentOptions()
    End Sub

    Private Sub lblLineColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblLineColorSelection.Click
        SelectCustomColor(lblLineColorSelection)
        SynchronizeLineColors(lblLineColorSelection.BackColor)
    End Sub

    Private Sub lblLineToBaseColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblLineToBaseColorSelection.Click
        SelectCustomColor(lblLineToBaseColorSelection)
        SynchronizeLineColors(lblLineToBaseColorSelection.BackColor)
    End Sub

    Private Sub lblPlotBackgroundColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblPlotBackgroundColorSelection.Click
        SelectCustomColor(lblPlotBackgroundColorSelection)
        UpdateCurrentOptions()
    End Sub

    Private Sub lblPointColorSelection_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles lblPointColorSelection.Click
        SelectCustomColor(lblPointColorSelection)

        If chkLinkPointColorToLineColor.Checked Then
            SynchronizePointColorWithLineColor(lblPointColorSelection.BackColor)
            If chkLinkLineColors.Checked Then
                SynchronizeLineColors(lblPointColorSelection.BackColor)
            End If
        Else
            UpdateCurrentOptions()
        End If
    End Sub

    Private Sub txtLegendCaption_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtLegendCaption.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtLegendCaption_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtLegendCaption.Enter
        TextBoxGotFocusHandler(txtLegendCaption)
    End Sub

    Private Sub txtLineWidth_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtLineWidth.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtLineWidth_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLineWidth.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtLineWidth, eventArgs, True, False)
    End Sub

    Private Sub txtLineWidth_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtLineWidth.Leave
        SharedVBNetRoutines.VBNetRoutines.ValidateTextboxInt(txtLineWidth, 0, 5, 2)
        UpdateCurrentOptions()
    End Sub

    Private Sub txtNormalizationConstant_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtNormalizationConstant.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtNormalizationConstant_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtNormalizationConstant.Enter
        TextBoxGotFocusHandler(txtNormalizationConstant)
    End Sub

    Private Sub txtNormalizationConstant_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNormalizationConstant.KeyPress
        SharedVBNetRoutines.VBNetRoutines.TextBoxKeyPressHandler(txtNormalizationConstant, eventArgs, True, True, True, False, True, False, False, False, False, True)
    End Sub

    Private Sub txtPlotSubTitle_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPlotSubTitle.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtPlotSubTitle_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPlotSubTitle.Enter
        TextBoxGotFocusHandler(txtPlotSubTitle)
    End Sub

    Private Sub txtPlotSubTitle_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPlotSubTitle.Leave
        UpdateCurrentOptions()
    End Sub

    Private Sub txtPlotTitle_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPlotTitle.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtPlotTitle_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPlotTitle.Enter
        TextBoxGotFocusHandler(txtPlotTitle)
    End Sub

    Private Sub txtXAxisLabel_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtXAxisLabel.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtXAxisLabel_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtXAxisLabel.Enter
        TextBoxGotFocusHandler(txtXAxisLabel)
    End Sub

    Private Sub txtYAxisLabel_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtYAxisLabel.TextChanged
        UpdateCurrentOptions()
    End Sub

    Private Sub txtYAxisLabel_Enter(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtYAxisLabel.Enter
        TextBoxGotFocusHandler(txtYAxisLabel)
    End Sub

End Class