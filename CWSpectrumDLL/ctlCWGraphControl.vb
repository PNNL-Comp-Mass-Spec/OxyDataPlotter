Option Strict Off
Option Explicit On

Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports PRISM.DataUtils
Imports PRISMWin
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

<System.Runtime.InteropServices.ProgId("CWGraphControl_NET.CWGraphControl")> Public Class CWGraphControl
    Inherits System.Windows.Forms.UserControl
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        mControlComponentsInitialized = True
        InitializeGraphControl()

    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            UserControl_Terminate()
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents cmdRollUpShow As System.Windows.Forms.Button
    Friend WithEvents cmdRollUpHide As System.Windows.Forms.Button
    Friend WithEvents chkAnnotationDensityToleranceAutoAdjust As System.Windows.Forms.CheckBox
    Friend WithEvents chkAnnotationAutoHideCaptions As System.Windows.Forms.CheckBox
    Friend WithEvents txtAnnotationDensityToleranceY As System.Windows.Forms.TextBox
    Friend WithEvents txtAnnotationDensityToleranceX As System.Windows.Forms.TextBox
    Friend WithEvents lblAnnotationDensityToleranceY As System.Windows.Forms.Label
    Friend WithEvents lblAnnotationDensityToleranceX As System.Windows.Forms.Label
    Friend WithEvents fraAnnotationDensityOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkCursorSnapToData As System.Windows.Forms.CheckBox
    Friend WithEvents fraCursor As System.Windows.Forms.GroupBox
    Friend WithEvents cmdMove As System.Windows.Forms.Button
    Friend WithEvents chkAutoAdjustScalingToIncludeAnnotationCaptions As System.Windows.Forms.CheckBox
    Friend WithEvents chkFixMinimumYAtZero As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoScaleVisibleY As System.Windows.Forms.CheckBox
    Friend WithEvents fraScaling As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrecisionY As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecisionX As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecisionY As System.Windows.Forms.Label
    Friend WithEvents lblPrecisionX As System.Windows.Forms.Label
    Friend WithEvents fraPrecision As System.Windows.Forms.GroupBox
    Friend WithEvents fraOptions As System.Windows.Forms.GroupBox
    Friend WithEvents fraOptionsShadow As System.Windows.Forms.Panel
    Friend WithEvents fraControls As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents CWGraph As AxCWUIControlsLib.AxCWGraph
    Friend WithEvents fraLegend As System.Windows.Forms.GroupBox
    Friend WithEvents fraPosition As System.Windows.Forms.GroupBox
    Friend WithEvents lblDeltaPosFromCursorLabel As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents lblDeltaPosFromCursor As System.Windows.Forms.Label
    Friend WithEvents fraMouseAction As System.Windows.Forms.GroupBox
    Friend WithEvents cmdZoomOut As System.Windows.Forms.Button
    Friend WithEvents cboMouseAction As System.Windows.Forms.ComboBox
    Friend WithEvents lblSpaceInfo As System.Windows.Forms.Label
    Friend WithEvents linLegendSeriesColor2 As System.Windows.Forms.Label
    Friend WithEvents linLegendSeriesColor1 As System.Windows.Forms.Label
    Friend WithEvents lblOriginalMaximumIntensity2 As System.Windows.Forms.Label
    Friend WithEvents lblOriginalMaximumIntensity1 As System.Windows.Forms.Label
    Friend WithEvents lblLegendCaption2 As System.Windows.Forms.Label
    Friend WithEvents lblLegendCaption1 As System.Windows.Forms.Label
    Friend WithEvents cmdOptionsHide As System.Windows.Forms.Button
    Friend WithEvents cmdOptionsToggle As System.Windows.Forms.Button
    Friend WithEvents chkShowCursor1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowCursor2 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCenterCursors As System.Windows.Forms.Button
    Friend WithEvents chkXAxisDateMode As System.Windows.Forms.CheckBox
    Friend WithEvents chkXAxisDateModeShowTime As System.Windows.Forms.CheckBox
    Friend WithEvents fraXAxisDateMode As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CWGraphControl))
        Me.cmdRollUpShow = New System.Windows.Forms.Button
        Me.cmdRollUpHide = New System.Windows.Forms.Button
        Me.fraOptionsShadow = New System.Windows.Forms.Panel
        Me.fraOptions = New System.Windows.Forms.GroupBox
        Me.fraXAxisDateMode = New System.Windows.Forms.GroupBox
        Me.chkXAxisDateModeShowTime = New System.Windows.Forms.CheckBox
        Me.chkXAxisDateMode = New System.Windows.Forms.CheckBox
        Me.fraAnnotationDensityOptions = New System.Windows.Forms.GroupBox
        Me.chkAnnotationDensityToleranceAutoAdjust = New System.Windows.Forms.CheckBox
        Me.chkAnnotationAutoHideCaptions = New System.Windows.Forms.CheckBox
        Me.txtAnnotationDensityToleranceY = New System.Windows.Forms.TextBox
        Me.txtAnnotationDensityToleranceX = New System.Windows.Forms.TextBox
        Me.lblAnnotationDensityToleranceY = New System.Windows.Forms.Label
        Me.lblAnnotationDensityToleranceX = New System.Windows.Forms.Label
        Me.fraCursor = New System.Windows.Forms.GroupBox
        Me.chkShowCursor2 = New System.Windows.Forms.CheckBox
        Me.chkCursorSnapToData = New System.Windows.Forms.CheckBox
        Me.chkShowCursor1 = New System.Windows.Forms.CheckBox
        Me.cmdMove = New System.Windows.Forms.Button
        Me.fraScaling = New System.Windows.Forms.GroupBox
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions = New System.Windows.Forms.CheckBox
        Me.chkFixMinimumYAtZero = New System.Windows.Forms.CheckBox
        Me.chkAutoScaleVisibleY = New System.Windows.Forms.CheckBox
        Me.fraPrecision = New System.Windows.Forms.GroupBox
        Me.txtPrecisionY = New System.Windows.Forms.TextBox
        Me.txtPrecisionX = New System.Windows.Forms.TextBox
        Me.lblPrecisionY = New System.Windows.Forms.Label
        Me.lblPrecisionX = New System.Windows.Forms.Label
        Me.cmdOptionsHide = New System.Windows.Forms.Button
        Me.fraControls = New System.Windows.Forms.GroupBox
        Me.fraLegend = New System.Windows.Forms.GroupBox
        Me.lblLegendCaption1 = New System.Windows.Forms.Label
        Me.lblOriginalMaximumIntensity2 = New System.Windows.Forms.Label
        Me.lblOriginalMaximumIntensity1 = New System.Windows.Forms.Label
        Me.lblLegendCaption2 = New System.Windows.Forms.Label
        Me.linLegendSeriesColor2 = New System.Windows.Forms.Label
        Me.linLegendSeriesColor1 = New System.Windows.Forms.Label
        Me.fraPosition = New System.Windows.Forms.GroupBox
        Me.cmdOptionsToggle = New System.Windows.Forms.Button
        Me.cmdCenterCursors = New System.Windows.Forms.Button
        Me.lblDeltaPosFromCursorLabel = New System.Windows.Forms.Label
        Me.lblPosition = New System.Windows.Forms.Label
        Me.lblDeltaPosFromCursor = New System.Windows.Forms.Label
        Me.fraMouseAction = New System.Windows.Forms.GroupBox
        Me.cmdZoomOut = New System.Windows.Forms.Button
        Me.cboMouseAction = New System.Windows.Forms.ComboBox
        Me.lblSpaceInfo = New System.Windows.Forms.Label
        Me.CWGraph = New AxCWUIControlsLib.AxCWGraph
        Me.fraOptionsShadow.SuspendLayout()
        Me.fraOptions.SuspendLayout()
        Me.fraXAxisDateMode.SuspendLayout()
        Me.fraAnnotationDensityOptions.SuspendLayout()
        Me.fraCursor.SuspendLayout()
        Me.fraScaling.SuspendLayout()
        Me.fraPrecision.SuspendLayout()
        Me.fraControls.SuspendLayout()
        Me.fraLegend.SuspendLayout()
        Me.fraPosition.SuspendLayout()
        Me.fraMouseAction.SuspendLayout()
        CType(Me.CWGraph, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdRollUpShow
        '
        Me.cmdRollUpShow.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdRollUpShow.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRollUpShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRollUpShow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRollUpShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRollUpShow.Image = CType(resources.GetObject("cmdRollUpShow.Image"), System.Drawing.Image)
        Me.cmdRollUpShow.Location = New System.Drawing.Point(644, 420)
        Me.cmdRollUpShow.Name = "cmdRollUpShow"
        Me.cmdRollUpShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRollUpShow.Size = New System.Drawing.Size(16, 17)
        Me.cmdRollUpShow.TabIndex = 37
        Me.cmdRollUpShow.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdRollUpHide
        '
        Me.cmdRollUpHide.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdRollUpHide.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRollUpHide.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRollUpHide.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRollUpHide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRollUpHide.Image = CType(resources.GetObject("cmdRollUpHide.Image"), System.Drawing.Image)
        Me.cmdRollUpHide.Location = New System.Drawing.Point(644, 404)
        Me.cmdRollUpHide.Name = "cmdRollUpHide"
        Me.cmdRollUpHide.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRollUpHide.Size = New System.Drawing.Size(16, 17)
        Me.cmdRollUpHide.TabIndex = 36
        Me.cmdRollUpHide.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'fraOptionsShadow
        '
        Me.fraOptionsShadow.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.fraOptionsShadow.Controls.Add(Me.fraOptions)
        Me.fraOptionsShadow.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraOptionsShadow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraOptionsShadow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOptionsShadow.Location = New System.Drawing.Point(96, 16)
        Me.fraOptionsShadow.Name = "fraOptionsShadow"
        Me.fraOptionsShadow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOptionsShadow.Size = New System.Drawing.Size(448, 224)
        Me.fraOptionsShadow.TabIndex = 34
        Me.fraOptionsShadow.Visible = False
        '
        'fraOptions
        '
        Me.fraOptions.BackColor = System.Drawing.SystemColors.Control
        Me.fraOptions.Controls.Add(Me.fraXAxisDateMode)
        Me.fraOptions.Controls.Add(Me.fraAnnotationDensityOptions)
        Me.fraOptions.Controls.Add(Me.fraCursor)
        Me.fraOptions.Controls.Add(Me.cmdMove)
        Me.fraOptions.Controls.Add(Me.fraScaling)
        Me.fraOptions.Controls.Add(Me.fraPrecision)
        Me.fraOptions.Controls.Add(Me.cmdOptionsHide)
        Me.fraOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOptions.Location = New System.Drawing.Point(0, 0)
        Me.fraOptions.Name = "fraOptions"
        Me.fraOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOptions.Size = New System.Drawing.Size(440, 216)
        Me.fraOptions.TabIndex = 0
        Me.fraOptions.TabStop = False
        Me.fraOptions.Text = "Options"
        '
        'fraXAxisDateMode
        '
        Me.fraXAxisDateMode.Controls.Add(Me.chkXAxisDateModeShowTime)
        Me.fraXAxisDateMode.Controls.Add(Me.chkXAxisDateMode)
        Me.fraXAxisDateMode.Location = New System.Drawing.Point(84, 16)
        Me.fraXAxisDateMode.Name = "fraXAxisDateMode"
        Me.fraXAxisDateMode.Size = New System.Drawing.Size(104, 56)
        Me.fraXAxisDateMode.TabIndex = 1
        Me.fraXAxisDateMode.TabStop = False
        Me.fraXAxisDateMode.Text = "Date Mode"
        '
        'chkXAxisDateModeShowTime
        '
        Me.chkXAxisDateModeShowTime.BackColor = System.Drawing.SystemColors.Control
        Me.chkXAxisDateModeShowTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkXAxisDateModeShowTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkXAxisDateModeShowTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkXAxisDateModeShowTime.Location = New System.Drawing.Point(8, 32)
        Me.chkXAxisDateModeShowTime.Name = "chkXAxisDateModeShowTime"
        Me.chkXAxisDateModeShowTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkXAxisDateModeShowTime.Size = New System.Drawing.Size(88, 16)
        Me.chkXAxisDateModeShowTime.TabIndex = 1
        Me.chkXAxisDateModeShowTime.Text = "Include Time"
        '
        'chkXAxisDateMode
        '
        Me.chkXAxisDateMode.BackColor = System.Drawing.SystemColors.Control
        Me.chkXAxisDateMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkXAxisDateMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkXAxisDateMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkXAxisDateMode.Location = New System.Drawing.Point(8, 16)
        Me.chkXAxisDateMode.Name = "chkXAxisDateMode"
        Me.chkXAxisDateMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkXAxisDateMode.Size = New System.Drawing.Size(88, 16)
        Me.chkXAxisDateMode.TabIndex = 0
        Me.chkXAxisDateMode.Text = "X is Date"
        '
        'fraAnnotationDensityOptions
        '
        Me.fraAnnotationDensityOptions.BackColor = System.Drawing.SystemColors.Control
        Me.fraAnnotationDensityOptions.Controls.Add(Me.chkAnnotationDensityToleranceAutoAdjust)
        Me.fraAnnotationDensityOptions.Controls.Add(Me.chkAnnotationAutoHideCaptions)
        Me.fraAnnotationDensityOptions.Controls.Add(Me.txtAnnotationDensityToleranceY)
        Me.fraAnnotationDensityOptions.Controls.Add(Me.txtAnnotationDensityToleranceX)
        Me.fraAnnotationDensityOptions.Controls.Add(Me.lblAnnotationDensityToleranceY)
        Me.fraAnnotationDensityOptions.Controls.Add(Me.lblAnnotationDensityToleranceX)
        Me.fraAnnotationDensityOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraAnnotationDensityOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraAnnotationDensityOptions.Location = New System.Drawing.Point(8, 128)
        Me.fraAnnotationDensityOptions.Name = "fraAnnotationDensityOptions"
        Me.fraAnnotationDensityOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAnnotationDensityOptions.Size = New System.Drawing.Size(321, 81)
        Me.fraAnnotationDensityOptions.TabIndex = 4
        Me.fraAnnotationDensityOptions.TabStop = False
        Me.fraAnnotationDensityOptions.Text = "Annotation Density Options"
        '
        'chkAnnotationDensityToleranceAutoAdjust
        '
        Me.chkAnnotationDensityToleranceAutoAdjust.BackColor = System.Drawing.SystemColors.Control
        Me.chkAnnotationDensityToleranceAutoAdjust.Checked = True
        Me.chkAnnotationDensityToleranceAutoAdjust.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAnnotationDensityToleranceAutoAdjust.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAnnotationDensityToleranceAutoAdjust.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnnotationDensityToleranceAutoAdjust.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAnnotationDensityToleranceAutoAdjust.Location = New System.Drawing.Point(208, 16)
        Me.chkAnnotationDensityToleranceAutoAdjust.Name = "chkAnnotationDensityToleranceAutoAdjust"
        Me.chkAnnotationDensityToleranceAutoAdjust.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAnnotationDensityToleranceAutoAdjust.Size = New System.Drawing.Size(89, 25)
        Me.chkAnnotationDensityToleranceAutoAdjust.TabIndex = 4
        Me.chkAnnotationDensityToleranceAutoAdjust.Text = "Auto Adjust Tolerances"
        '
        'chkAnnotationAutoHideCaptions
        '
        Me.chkAnnotationAutoHideCaptions.BackColor = System.Drawing.SystemColors.Control
        Me.chkAnnotationAutoHideCaptions.Checked = True
        Me.chkAnnotationAutoHideCaptions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAnnotationAutoHideCaptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAnnotationAutoHideCaptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnnotationAutoHideCaptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAnnotationAutoHideCaptions.Location = New System.Drawing.Point(208, 48)
        Me.chkAnnotationAutoHideCaptions.Name = "chkAnnotationAutoHideCaptions"
        Me.chkAnnotationAutoHideCaptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAnnotationAutoHideCaptions.Size = New System.Drawing.Size(73, 25)
        Me.chkAnnotationAutoHideCaptions.TabIndex = 5
        Me.chkAnnotationAutoHideCaptions.Text = "&Auto Hide Captions"
        '
        'txtAnnotationDensityToleranceY
        '
        Me.txtAnnotationDensityToleranceY.AcceptsReturn = True
        Me.txtAnnotationDensityToleranceY.AutoSize = False
        Me.txtAnnotationDensityToleranceY.BackColor = System.Drawing.SystemColors.Window
        Me.txtAnnotationDensityToleranceY.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnnotationDensityToleranceY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnotationDensityToleranceY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAnnotationDensityToleranceY.Location = New System.Drawing.Point(120, 45)
        Me.txtAnnotationDensityToleranceY.MaxLength = 0
        Me.txtAnnotationDensityToleranceY.Name = "txtAnnotationDensityToleranceY"
        Me.txtAnnotationDensityToleranceY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAnnotationDensityToleranceY.Size = New System.Drawing.Size(73, 19)
        Me.txtAnnotationDensityToleranceY.TabIndex = 3
        Me.txtAnnotationDensityToleranceY.Text = "1"
        '
        'txtAnnotationDensityToleranceX
        '
        Me.txtAnnotationDensityToleranceX.AcceptsReturn = True
        Me.txtAnnotationDensityToleranceX.AutoSize = False
        Me.txtAnnotationDensityToleranceX.BackColor = System.Drawing.SystemColors.Window
        Me.txtAnnotationDensityToleranceX.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnnotationDensityToleranceX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnotationDensityToleranceX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAnnotationDensityToleranceX.Location = New System.Drawing.Point(120, 24)
        Me.txtAnnotationDensityToleranceX.MaxLength = 0
        Me.txtAnnotationDensityToleranceX.Name = "txtAnnotationDensityToleranceX"
        Me.txtAnnotationDensityToleranceX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAnnotationDensityToleranceX.Size = New System.Drawing.Size(73, 19)
        Me.txtAnnotationDensityToleranceX.TabIndex = 1
        Me.txtAnnotationDensityToleranceX.Text = "1"
        '
        'lblAnnotationDensityToleranceY
        '
        Me.lblAnnotationDensityToleranceY.BackColor = System.Drawing.SystemColors.Control
        Me.lblAnnotationDensityToleranceY.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAnnotationDensityToleranceY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnnotationDensityToleranceY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAnnotationDensityToleranceY.Location = New System.Drawing.Point(8, 47)
        Me.lblAnnotationDensityToleranceY.Name = "lblAnnotationDensityToleranceY"
        Me.lblAnnotationDensityToleranceY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAnnotationDensityToleranceY.Size = New System.Drawing.Size(105, 17)
        Me.lblAnnotationDensityToleranceY.TabIndex = 2
        Me.lblAnnotationDensityToleranceY.Text = "Density Tolerance Y"
        '
        'lblAnnotationDensityToleranceX
        '
        Me.lblAnnotationDensityToleranceX.BackColor = System.Drawing.SystemColors.Control
        Me.lblAnnotationDensityToleranceX.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAnnotationDensityToleranceX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnnotationDensityToleranceX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAnnotationDensityToleranceX.Location = New System.Drawing.Point(8, 25)
        Me.lblAnnotationDensityToleranceX.Name = "lblAnnotationDensityToleranceX"
        Me.lblAnnotationDensityToleranceX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAnnotationDensityToleranceX.Size = New System.Drawing.Size(105, 17)
        Me.lblAnnotationDensityToleranceX.TabIndex = 0
        Me.lblAnnotationDensityToleranceX.Text = "Density Tolerance X"
        '
        'fraCursor
        '
        Me.fraCursor.BackColor = System.Drawing.SystemColors.Control
        Me.fraCursor.Controls.Add(Me.chkShowCursor2)
        Me.fraCursor.Controls.Add(Me.chkCursorSnapToData)
        Me.fraCursor.Controls.Add(Me.chkShowCursor1)
        Me.fraCursor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraCursor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraCursor.Location = New System.Drawing.Point(8, 80)
        Me.fraCursor.Name = "fraCursor"
        Me.fraCursor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraCursor.Size = New System.Drawing.Size(321, 41)
        Me.fraCursor.TabIndex = 3
        Me.fraCursor.TabStop = False
        Me.fraCursor.Text = "Cursor"
        '
        'chkShowCursor2
        '
        Me.chkShowCursor2.BackColor = System.Drawing.SystemColors.Control
        Me.chkShowCursor2.Checked = True
        Me.chkShowCursor2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowCursor2.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkShowCursor2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowCursor2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkShowCursor2.Location = New System.Drawing.Point(112, 16)
        Me.chkShowCursor2.Name = "chkShowCursor2"
        Me.chkShowCursor2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkShowCursor2.Size = New System.Drawing.Size(104, 17)
        Me.chkShowCursor2.TabIndex = 1
        Me.chkShowCursor2.Text = "&Show Cursor 2"
        '
        'chkCursorSnapToData
        '
        Me.chkCursorSnapToData.BackColor = System.Drawing.SystemColors.Control
        Me.chkCursorSnapToData.Checked = True
        Me.chkCursorSnapToData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCursorSnapToData.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkCursorSnapToData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCursorSnapToData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCursorSnapToData.Location = New System.Drawing.Point(224, 16)
        Me.chkCursorSnapToData.Name = "chkCursorSnapToData"
        Me.chkCursorSnapToData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCursorSnapToData.Size = New System.Drawing.Size(88, 17)
        Me.chkCursorSnapToData.TabIndex = 2
        Me.chkCursorSnapToData.Text = "Snap to &Data"
        '
        'chkShowCursor1
        '
        Me.chkShowCursor1.BackColor = System.Drawing.SystemColors.Control
        Me.chkShowCursor1.Checked = True
        Me.chkShowCursor1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowCursor1.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkShowCursor1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowCursor1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkShowCursor1.Location = New System.Drawing.Point(8, 16)
        Me.chkShowCursor1.Name = "chkShowCursor1"
        Me.chkShowCursor1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkShowCursor1.Size = New System.Drawing.Size(104, 17)
        Me.chkShowCursor1.TabIndex = 0
        Me.chkShowCursor1.Text = "&Show Cursor 1"
        '
        'cmdMove
        '
        Me.cmdMove.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMove.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMove.Location = New System.Drawing.Point(344, 136)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMove.Size = New System.Drawing.Size(63, 24)
        Me.cmdMove.TabIndex = 5
        Me.cmdMove.Text = "&Move"
        '
        'fraScaling
        '
        Me.fraScaling.BackColor = System.Drawing.SystemColors.Control
        Me.fraScaling.Controls.Add(Me.chkAutoAdjustScalingToIncludeAnnotationCaptions)
        Me.fraScaling.Controls.Add(Me.chkFixMinimumYAtZero)
        Me.fraScaling.Controls.Add(Me.chkAutoScaleVisibleY)
        Me.fraScaling.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraScaling.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraScaling.Location = New System.Drawing.Point(192, 16)
        Me.fraScaling.Name = "fraScaling"
        Me.fraScaling.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraScaling.Size = New System.Drawing.Size(239, 57)
        Me.fraScaling.TabIndex = 2
        Me.fraScaling.TabStop = False
        Me.fraScaling.Text = "Scaling"
        '
        'chkAutoAdjustScalingToIncludeAnnotationCaptions
        '
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.BackColor = System.Drawing.SystemColors.Control
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Checked = True
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Location = New System.Drawing.Point(128, 12)
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Name = "chkAutoAdjustScalingToIncludeAnnotationCaptions"
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Size = New System.Drawing.Size(105, 41)
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.TabIndex = 2
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Text = "Auto Adjust Scaling to Include Captions"
        '
        'chkFixMinimumYAtZero
        '
        Me.chkFixMinimumYAtZero.BackColor = System.Drawing.SystemColors.Control
        Me.chkFixMinimumYAtZero.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkFixMinimumYAtZero.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFixMinimumYAtZero.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFixMinimumYAtZero.Location = New System.Drawing.Point(8, 32)
        Me.chkFixMinimumYAtZero.Name = "chkFixMinimumYAtZero"
        Me.chkFixMinimumYAtZero.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFixMinimumYAtZero.Size = New System.Drawing.Size(113, 17)
        Me.chkFixMinimumYAtZero.TabIndex = 1
        Me.chkFixMinimumYAtZero.Text = "Fix Min Y at Zero"
        '
        'chkAutoScaleVisibleY
        '
        Me.chkAutoScaleVisibleY.BackColor = System.Drawing.SystemColors.Control
        Me.chkAutoScaleVisibleY.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAutoScaleVisibleY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoScaleVisibleY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoScaleVisibleY.Location = New System.Drawing.Point(8, 16)
        Me.chkAutoScaleVisibleY.Name = "chkAutoScaleVisibleY"
        Me.chkAutoScaleVisibleY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAutoScaleVisibleY.Size = New System.Drawing.Size(113, 17)
        Me.chkAutoScaleVisibleY.TabIndex = 0
        Me.chkAutoScaleVisibleY.Text = "Autoscale Visible &Y"
        '
        'fraPrecision
        '
        Me.fraPrecision.BackColor = System.Drawing.SystemColors.Control
        Me.fraPrecision.Controls.Add(Me.txtPrecisionY)
        Me.fraPrecision.Controls.Add(Me.txtPrecisionX)
        Me.fraPrecision.Controls.Add(Me.lblPrecisionY)
        Me.fraPrecision.Controls.Add(Me.lblPrecisionX)
        Me.fraPrecision.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPrecision.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPrecision.Location = New System.Drawing.Point(8, 16)
        Me.fraPrecision.Name = "fraPrecision"
        Me.fraPrecision.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraPrecision.Size = New System.Drawing.Size(72, 57)
        Me.fraPrecision.TabIndex = 0
        Me.fraPrecision.TabStop = False
        Me.fraPrecision.Text = "Precision"
        '
        'txtPrecisionY
        '
        Me.txtPrecisionY.AcceptsReturn = True
        Me.txtPrecisionY.AutoSize = False
        Me.txtPrecisionY.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrecisionY.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrecisionY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecisionY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPrecisionY.Location = New System.Drawing.Point(24, 32)
        Me.txtPrecisionY.MaxLength = 0
        Me.txtPrecisionY.Name = "txtPrecisionY"
        Me.txtPrecisionY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPrecisionY.Size = New System.Drawing.Size(25, 19)
        Me.txtPrecisionY.TabIndex = 3
        Me.txtPrecisionY.Text = "1"
        '
        'txtPrecisionX
        '
        Me.txtPrecisionX.AcceptsReturn = True
        Me.txtPrecisionX.AutoSize = False
        Me.txtPrecisionX.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrecisionX.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrecisionX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecisionX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPrecisionX.Location = New System.Drawing.Point(24, 16)
        Me.txtPrecisionX.MaxLength = 0
        Me.txtPrecisionX.Name = "txtPrecisionX"
        Me.txtPrecisionX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPrecisionX.Size = New System.Drawing.Size(25, 19)
        Me.txtPrecisionX.TabIndex = 1
        Me.txtPrecisionX.Text = "2"
        '
        'lblPrecisionY
        '
        Me.lblPrecisionY.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrecisionY.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPrecisionY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecisionY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrecisionY.Location = New System.Drawing.Point(8, 34)
        Me.lblPrecisionY.Name = "lblPrecisionY"
        Me.lblPrecisionY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrecisionY.Size = New System.Drawing.Size(17, 17)
        Me.lblPrecisionY.TabIndex = 2
        Me.lblPrecisionY.Text = "y"
        '
        'lblPrecisionX
        '
        Me.lblPrecisionX.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrecisionX.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPrecisionX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecisionX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrecisionX.Location = New System.Drawing.Point(8, 18)
        Me.lblPrecisionX.Name = "lblPrecisionX"
        Me.lblPrecisionX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrecisionX.Size = New System.Drawing.Size(17, 17)
        Me.lblPrecisionX.TabIndex = 0
        Me.lblPrecisionX.Text = "x"
        '
        'cmdOptionsHide
        '
        Me.cmdOptionsHide.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOptionsHide.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOptionsHide.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOptionsHide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOptionsHide.Location = New System.Drawing.Point(344, 168)
        Me.cmdOptionsHide.Name = "cmdOptionsHide"
        Me.cmdOptionsHide.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOptionsHide.Size = New System.Drawing.Size(63, 24)
        Me.cmdOptionsHide.TabIndex = 6
        Me.cmdOptionsHide.Text = "&Hide"
        '
        'fraControls
        '
        Me.fraControls.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.fraControls.BackColor = System.Drawing.SystemColors.Control
        Me.fraControls.Controls.Add(Me.fraLegend)
        Me.fraControls.Controls.Add(Me.fraPosition)
        Me.fraControls.Controls.Add(Me.fraMouseAction)
        Me.fraControls.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraControls.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraControls.Location = New System.Drawing.Point(8, 336)
        Me.fraControls.Name = "fraControls"
        Me.fraControls.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraControls.Size = New System.Drawing.Size(626, 93)
        Me.fraControls.TabIndex = 22
        Me.fraControls.TabStop = False
        '
        'fraLegend
        '
        Me.fraLegend.BackColor = System.Drawing.SystemColors.Control
        Me.fraLegend.Controls.Add(Me.lblLegendCaption1)
        Me.fraLegend.Controls.Add(Me.lblOriginalMaximumIntensity2)
        Me.fraLegend.Controls.Add(Me.lblOriginalMaximumIntensity1)
        Me.fraLegend.Controls.Add(Me.lblLegendCaption2)
        Me.fraLegend.Controls.Add(Me.linLegendSeriesColor2)
        Me.fraLegend.Controls.Add(Me.linLegendSeriesColor1)
        Me.fraLegend.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraLegend.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraLegend.Location = New System.Drawing.Point(384, 0)
        Me.fraLegend.Name = "fraLegend"
        Me.fraLegend.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraLegend.Size = New System.Drawing.Size(241, 93)
        Me.fraLegend.TabIndex = 2
        Me.fraLegend.TabStop = False
        Me.fraLegend.Text = "Legend"
        '
        'lblLegendCaption1
        '
        Me.lblLegendCaption1.BackColor = System.Drawing.SystemColors.Control
        Me.lblLegendCaption1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLegendCaption1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLegendCaption1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLegendCaption1.Location = New System.Drawing.Point(40, 16)
        Me.lblLegendCaption1.Name = "lblLegendCaption1"
        Me.lblLegendCaption1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLegendCaption1.TabIndex = 1
        '
        'lblOriginalMaximumIntensity2
        '
        Me.lblOriginalMaximumIntensity2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOriginalMaximumIntensity2.BackColor = System.Drawing.SystemColors.Control
        Me.lblOriginalMaximumIntensity2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOriginalMaximumIntensity2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginalMaximumIntensity2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOriginalMaximumIntensity2.Location = New System.Drawing.Point(40, 72)
        Me.lblOriginalMaximumIntensity2.Name = "lblOriginalMaximumIntensity2"
        Me.lblOriginalMaximumIntensity2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOriginalMaximumIntensity2.Size = New System.Drawing.Size(193, 17)
        Me.lblOriginalMaximumIntensity2.TabIndex = 5
        '
        'lblOriginalMaximumIntensity1
        '
        Me.lblOriginalMaximumIntensity1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOriginalMaximumIntensity1.BackColor = System.Drawing.SystemColors.Control
        Me.lblOriginalMaximumIntensity1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblOriginalMaximumIntensity1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginalMaximumIntensity1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOriginalMaximumIntensity1.Location = New System.Drawing.Point(40, 32)
        Me.lblOriginalMaximumIntensity1.Name = "lblOriginalMaximumIntensity1"
        Me.lblOriginalMaximumIntensity1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOriginalMaximumIntensity1.Size = New System.Drawing.Size(193, 17)
        Me.lblOriginalMaximumIntensity1.TabIndex = 2
        '
        'lblLegendCaption2
        '
        Me.lblLegendCaption2.BackColor = System.Drawing.SystemColors.Control
        Me.lblLegendCaption2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLegendCaption2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLegendCaption2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLegendCaption2.Location = New System.Drawing.Point(40, 56)
        Me.lblLegendCaption2.Name = "lblLegendCaption2"
        Me.lblLegendCaption2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLegendCaption2.TabIndex = 4
        '
        'linLegendSeriesColor2
        '
        Me.linLegendSeriesColor2.BackColor = Color.Red
        Me.linLegendSeriesColor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linLegendSeriesColor2.Location = New System.Drawing.Point(8, 64)
        Me.linLegendSeriesColor2.Name = "linLegendSeriesColor2"
        Me.linLegendSeriesColor2.Size = New System.Drawing.Size(24, 1)
        Me.linLegendSeriesColor2.TabIndex = 3
        '
        'linLegendSeriesColor1
        '
        Me.linLegendSeriesColor1.BackColor = Color.Red
        Me.linLegendSeriesColor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linLegendSeriesColor1.Location = New System.Drawing.Point(8, 24)
        Me.linLegendSeriesColor1.Name = "linLegendSeriesColor1"
        Me.linLegendSeriesColor1.Size = New System.Drawing.Size(24, 1)
        Me.linLegendSeriesColor1.TabIndex = 0
        '
        'fraPosition
        '
        Me.fraPosition.BackColor = System.Drawing.SystemColors.Control
        Me.fraPosition.Controls.Add(Me.cmdOptionsToggle)
        Me.fraPosition.Controls.Add(Me.cmdCenterCursors)
        Me.fraPosition.Controls.Add(Me.lblDeltaPosFromCursorLabel)
        Me.fraPosition.Controls.Add(Me.lblPosition)
        Me.fraPosition.Controls.Add(Me.lblDeltaPosFromCursor)
        Me.fraPosition.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraPosition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraPosition.Location = New System.Drawing.Point(160, 0)
        Me.fraPosition.Name = "fraPosition"
        Me.fraPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraPosition.Size = New System.Drawing.Size(233, 93)
        Me.fraPosition.TabIndex = 1
        Me.fraPosition.TabStop = False
        Me.fraPosition.Text = "Position"
        '
        'cmdOptionsToggle
        '
        Me.cmdOptionsToggle.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOptionsToggle.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOptionsToggle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOptionsToggle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOptionsToggle.Location = New System.Drawing.Point(112, 64)
        Me.cmdOptionsToggle.Name = "cmdOptionsToggle"
        Me.cmdOptionsToggle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOptionsToggle.Size = New System.Drawing.Size(79, 20)
        Me.cmdOptionsToggle.TabIndex = 4
        Me.cmdOptionsToggle.Text = "&Options"
        '
        'cmdCenterCursors
        '
        Me.cmdCenterCursors.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCenterCursors.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCenterCursors.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCenterCursors.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCenterCursors.Location = New System.Drawing.Point(8, 64)
        Me.cmdCenterCursors.Name = "cmdCenterCursors"
        Me.cmdCenterCursors.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCenterCursors.Size = New System.Drawing.Size(88, 20)
        Me.cmdCenterCursors.TabIndex = 3
        Me.cmdCenterCursors.Text = "&Center Cursors"
        '
        'lblDeltaPosFromCursorLabel
        '
        Me.lblDeltaPosFromCursorLabel.BackColor = System.Drawing.SystemColors.Control
        Me.lblDeltaPosFromCursorLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDeltaPosFromCursorLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeltaPosFromCursorLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDeltaPosFromCursorLabel.Location = New System.Drawing.Point(8, 24)
        Me.lblDeltaPosFromCursorLabel.Name = "lblDeltaPosFromCursorLabel"
        Me.lblDeltaPosFromCursorLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDeltaPosFromCursorLabel.Size = New System.Drawing.Size(49, 25)
        Me.lblDeltaPosFromCursorLabel.TabIndex = 0
        '
        'lblPosition
        '
        Me.lblPosition.BackColor = System.Drawing.SystemColors.Control
        Me.lblPosition.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPosition.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPosition.Location = New System.Drawing.Point(72, 11)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPosition.Size = New System.Drawing.Size(153, 17)
        Me.lblPosition.TabIndex = 1
        '
        'lblDeltaPosFromCursor
        '
        Me.lblDeltaPosFromCursor.BackColor = System.Drawing.SystemColors.Control
        Me.lblDeltaPosFromCursor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDeltaPosFromCursor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeltaPosFromCursor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDeltaPosFromCursor.Location = New System.Drawing.Point(72, 32)
        Me.lblDeltaPosFromCursor.Name = "lblDeltaPosFromCursor"
        Me.lblDeltaPosFromCursor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDeltaPosFromCursor.Size = New System.Drawing.Size(153, 17)
        Me.lblDeltaPosFromCursor.TabIndex = 2
        '
        'fraMouseAction
        '
        Me.fraMouseAction.BackColor = System.Drawing.SystemColors.Control
        Me.fraMouseAction.Controls.Add(Me.cmdZoomOut)
        Me.fraMouseAction.Controls.Add(Me.cboMouseAction)
        Me.fraMouseAction.Controls.Add(Me.lblSpaceInfo)
        Me.fraMouseAction.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraMouseAction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraMouseAction.Location = New System.Drawing.Point(0, 0)
        Me.fraMouseAction.Name = "fraMouseAction"
        Me.fraMouseAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraMouseAction.Size = New System.Drawing.Size(164, 93)
        Me.fraMouseAction.TabIndex = 0
        Me.fraMouseAction.TabStop = False
        Me.fraMouseAction.Text = "Mouse Action"
        '
        'cmdZoomOut
        '
        Me.cmdZoomOut.BackColor = System.Drawing.SystemColors.Control
        Me.cmdZoomOut.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdZoomOut.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdZoomOut.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdZoomOut.Location = New System.Drawing.Point(16, 64)
        Me.cmdZoomOut.Name = "cmdZoomOut"
        Me.cmdZoomOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdZoomOut.Size = New System.Drawing.Size(111, 20)
        Me.cmdZoomOut.TabIndex = 2
        Me.cmdZoomOut.Text = "&Zoom Out (Ctrl+A)"
        '
        'cboMouseAction
        '
        Me.cboMouseAction.BackColor = System.Drawing.SystemColors.Window
        Me.cboMouseAction.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboMouseAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMouseAction.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMouseAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMouseAction.Location = New System.Drawing.Point(8, 16)
        Me.cboMouseAction.Name = "cboMouseAction"
        Me.cboMouseAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMouseAction.Size = New System.Drawing.Size(145, 22)
        Me.cboMouseAction.TabIndex = 0
        '
        'lblSpaceInfo
        '
        Me.lblSpaceInfo.BackColor = System.Drawing.SystemColors.Control
        Me.lblSpaceInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSpaceInfo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpaceInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSpaceInfo.Location = New System.Drawing.Point(8, 40)
        Me.lblSpaceInfo.Name = "lblSpaceInfo"
        Me.lblSpaceInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSpaceInfo.Size = New System.Drawing.Size(140, 15)
        Me.lblSpaceInfo.TabIndex = 1
        '
        'CWGraph
        '
        Me.CWGraph.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CWGraph.Location = New System.Drawing.Point(0, 0)
        Me.CWGraph.Name = "CWGraph"
        Me.CWGraph.OcxState = CType(resources.GetObject("CWGraph.OcxState"), System.Windows.Forms.AxHost.State)
        Me.CWGraph.Size = New System.Drawing.Size(658, 324)
        Me.CWGraph.TabIndex = 0
        '
        'CWGraphControl
        '
        Me.Controls.Add(Me.cmdRollUpShow)
        Me.Controls.Add(Me.cmdRollUpHide)
        Me.Controls.Add(Me.fraOptionsShadow)
        Me.Controls.Add(Me.fraControls)
        Me.Controls.Add(Me.CWGraph)
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CWGraphControl"
        Me.Size = New System.Drawing.Size(664, 440)
        Me.fraOptionsShadow.ResumeLayout(False)
        Me.fraOptions.ResumeLayout(False)
        Me.fraXAxisDateMode.ResumeLayout(False)
        Me.fraAnnotationDensityOptions.ResumeLayout(False)
        Me.fraCursor.ResumeLayout(False)
        Me.fraScaling.ResumeLayout(False)
        Me.fraPrecision.ResumeLayout(False)
        Me.fraControls.ResumeLayout(False)
        Me.fraLegend.ResumeLayout(False)
        Me.fraPosition.ResumeLayout(False)
        Me.fraMouseAction.ResumeLayout(False)
        CType(Me.CWGraph, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
    ' Customized version of the National Instruments CW Graph Control
    ' Written by Matthew Monroe at Pacific Northwest National Laboratory
    ' Richland, WA
    ' Started October 22, 2002
    ' Converted to VB.NET in October 2003

    Private Const CWGRAPH_APP_DATE As String = "January 24, 2006"
    Private Const CWGRAPH_APP_VERSION As String = "2.42"
    Private Const APP_NAME_IN_REGISTRY As String = "CustomizedCWGraphControl"
    Private Const DEFAULT_FONT_NAME As String = "Arial"
    Private Const DEFAULT_FONT_SIZE As Short = 11
    Private Const DEFAULT_ANNOTATION_FONT_SIZE As Short = 10

    Public Const MAX_SERIES_COUNT As Short = 32
    Private Const MAX_HISTORY_COUNT As Short = 30

    ' This is date that will be displayed for a value of 0 on the x axis
    Public Const DATE_MODE_START_DATE As System.DateTime = #12/30/1899#

    Private mControlComponentsInitialized As Boolean

    Public Enum pmPlotModeConstants
        pmLines = 0
        pmSticksToZero = 1
        pmBar = 2
        pmPoints = 3
        pmPointsAndLines = 4
    End Enum

    Private Enum cmZoomBoxCursorModeConstants
        cmZoomBox = 0
        cmZoomX = 1
        cmZoomY = 2
        cmPanAll = 3
        cmPanX = 4
        cmCursor = 5
        cmMoveAnnotations = 6
    End Enum

    Public Enum asmAnnotationSnapModeConstants
        asmFixedToAnyPoint = 0
        asmFixedToSingleDataPoint = 1
        asmFloating = 2
    End Enum

    Private Enum ofOptionsFrameLocationConstants
        ofTopLeft = 0
        ofTopRight = 1
        ofBottomLeft = 2
        ofBottomRight = 3
    End Enum

    Private Enum clClickLocationConstants
        clPlotArea = 0
        clPlotSeries = 1
        clAnnotation = 2
        clCursor = 3
        clOther = 4
    End Enum

    Public Enum mbMouseButtonConstants As Short
        NoButton = 0
        LeftButton = 1
        RightButton = 2
        MiddleButton = 4
    End Enum

    Private Structure udtZoomHistoryType
        Public XMinimum As Double
        Public XMaximum As Double
        Public YMinimum As Double
        Public YMaximum As Double
    End Structure

    ' Note: When using Annotations, the CWGraph control treats the data as ranging from 1 to DataCount rather than 0 to DataCount-1
    Private Structure udtDataSavedType
        Public DataCount As Integer
        Public XVals() As Double                    ' 0-based array, ranging from 0 to DataCount-1
        Public YVals() As Double                    ' 0-based array, ranging from 0 to DataCount-1
        Public OriginalMaximumIntensity As Double
        Public LegendCaption As String
        Public Initialized As Boolean
    End Structure

    Private Structure udtAnnotationStyleType
        Public FontName As String
        Public FontSize As Short
        Public FontColor As Color
    End Structure

    Private Structure udtAnnotationInfoType
        Public Hidden As Boolean
        Public CaptionText As String
        Public ShowsNearestPointX As Boolean        ' When true, then shows the XPos of the nearest point instead of the caption
        Public ShowsNearestPointY As Boolean        ' When true, then shows the YPos of the nearest point instead of the caption
        Public HideInDenseRegions As Boolean
        Public IncludeArrow As Boolean
    End Structure

    Private Structure udtLastMouseLocInfoType
        Public MouseButton As mbMouseButtonConstants
        Public MouseLoc As clClickLocationConstants
        Public AnnotationNumber As Integer
        Public CursorIndex As Integer
        Public SeriesIndex As Integer
        Public XPos As Double
        Public YPos As Double
    End Structure

    ' Values that the user can change via interface functions
    Private mPrecisionX As Short
    Private mPrecisionY As Short
    Private mAnnotationDensityToleranceX, mAnnotationDensityToleranceY As Double
    Private mAnnotationDensityAutoHideCaptions As Boolean
    Private mAnnotationDensityToleranceAutoAdjust As Boolean
    Private mAutoScaleVisibleY As Boolean
    Private mAutoAdjustScalingToIncludeCaptions As Boolean
    Private mPeakDetectIntensityThresholdCounts As Double
    Private mPeakDetectIntensityThresholdPercentageOfMaximum As Integer
    Private mPeakDetectWidthPointsMinimum As Integer
    Private mFixMinimumYAtZero As Boolean
    Private mTitle As String
    Private mSubTitle As String
    Private mAnnotationStyles(MAX_SERIES_COUNT) As udtAnnotationStyleType

    ' Values used internally
    Private mMouseModeTemp As Boolean
    Private mMouseModeSave As Short
    Private mLastMouseLocInfo As udtLastMouseLocInfoType
    Private mLastXPos As Double
    Private mLastYPos As Double

    Private mRecentAnnotationAngle As Integer
    Private mRecentAnnotationSnapMode As asmAnnotationSnapModeConstants
    Private mRecentAnnotationIncludeArrow As Boolean
    Private mRecentAnnotationShowsXPos As Boolean
    Private mRecentAnnotationShowsYPos As Boolean
    Private mRecentAnnotationHideInDenseRegions As Boolean

    Private mControlsFrameHidden As Boolean
    Private mControlsFrameLocation As ofOptionsFrameLocationConstants

    Private Const HUGE_POS_NUMBER_DOUBLE As Double = 1.0E+308
    Private Const HUGE_NEG_NUMBER_DOUBLE As Double = -1.0E+308

    ' Will remember the data for up MAX_SERIES_COUNT series
    ' It is necessary to keep a copy of the data in memory since there is no way to export it
    '  out of the graph after populating the graph
    Private mDataSaved(MAX_SERIES_COUNT) As udtDataSavedType        ' 1-based array

    Private mAnnotations() As udtAnnotationInfoType

    Private mSeriesPlotMode(MAX_SERIES_COUNT) As pmPlotModeConstants

    Private ZoomHistory(MAX_HISTORY_COUNT) As udtZoomHistoryType

    Private Sub AddOrUpdateAnnotationAtMouseLocation(Optional ByVal intAnnotationIndexForce As Integer = 0)
        ' Adds a new annotation, or updates an existing one if intAnnotationIndexForce > 0

        Dim intClosestSeriesNumber As Short
        Dim dblDistanceToClosestSeriesNumberDataPoint As Double
        Dim intClosestDataPoint As Integer
        Dim dblXPos, dblYPos As Double
        Dim strCaption As String

        If intAnnotationIndexForce < 1 Then
            dblDistanceToClosestSeriesNumberDataPoint = HUGE_POS_NUMBER_DOUBLE
            intClosestDataPoint = LookupNearestPointNumber(mLastXPos, mLastYPos, intClosestSeriesNumber, dblDistanceToClosestSeriesNumberDataPoint, False)

            If intClosestSeriesNumber < 1 Or intClosestSeriesNumber > CWGraph.Plots.Count Then
                intClosestSeriesNumber = 1
            End If

            dblXPos = mLastXPos
            dblYPos = mLastYPos
            strCaption = ""
            intAnnotationIndexForce = 0
        Else
            With CWGraph.Annotations.Item(intAnnotationIndexForce)
                dblXPos = .Caption.XCoordinate
                dblYPos = .Caption.YCoordinate
                strCaption = LookupCaptionForAnnotation(intAnnotationIndexForce)
                intClosestSeriesNumber = LookupSeriesNumberForPlotObject(.Plot)
                intClosestDataPoint = .PointIndex
            End With
        End If

        If mRecentAnnotationSnapMode < 0 Or mRecentAnnotationSnapMode > asmAnnotationSnapModeConstants.asmFloating Then
            System.Diagnostics.Debug.Assert(False, "")
            mRecentAnnotationSnapMode = asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint
        End If

        ' Note that the RecentAnnotation variables will be updated to the values the user chooses since they're being passed ByRef
        SetAnnotation(True, dblXPos, dblYPos, strCaption, mRecentAnnotationAngle, intClosestSeriesNumber, mRecentAnnotationSnapMode, intClosestDataPoint, mRecentAnnotationShowsXPos, mRecentAnnotationShowsYPos, mRecentAnnotationIncludeArrow, mRecentAnnotationHideInDenseRegions, intAnnotationIndexForce)

    End Sub

    Private Sub AdjustScalingToIncludeAnnotationCaptions()

        Dim intIndex As Integer
        Dim intSeriesNumber As Short
        Dim intPointNumberToBind As Integer

        Dim blnDataPointInView, blnCaptionInView As Boolean
        Dim dblRangeXMin, dblRangeXMax As Double
        Dim dblRangeYMin, dblRangeYMax As Double

        Dim dblXPos, dblYPos As Double
        Dim X1, Y1 As Double
        Dim X2, Y2 As Double

        Dim blnAdjustZoom As Boolean

        If Not mAutoAdjustScalingToIncludeCaptions Then Exit Sub

        On Error GoTo AdjustScalingToIncludeAnnotationCaptionsErrorHandler

        GetRangeX(dblRangeXMin, dblRangeXMax)
        GetRangeY(dblRangeYMin, dblRangeYMax)

        ' See if any of the captions are outside the current view window
        ' If they are, then zoom out even further
        For intIndex = 1 To CWGraph.Annotations.Count
            With CWGraph.Annotations.Item(intIndex)

                ' See if the data point for this caption is within the current zoom range
                intSeriesNumber = LookupSeriesNumberForPlotObject(.Plot)
                If .SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapFloating Then
                    intPointNumberToBind = -1
                Else
                    intPointNumberToBind = .PointIndex
                End If

                blnDataPointInView = False
                If intPointNumberToBind >= 0 And mDataSaved(intSeriesNumber).Initialized Then
                    If intPointNumberToBind < mDataSaved(intSeriesNumber).DataCount Then
                        dblXPos = mDataSaved(intSeriesNumber).XVals(intPointNumberToBind)
                        dblYPos = mDataSaved(intSeriesNumber).YVals(intPointNumberToBind)
                        If dblXPos >= dblRangeXMin And dblXPos <= dblRangeXMax And dblYPos >= dblRangeYMin And dblYPos <= dblRangeYMax Then
                            blnDataPointInView = True
                        End If
                    End If
                End If

                ' See if any portion of the caption is within the current zoom range
                ' The following function returns the coordinates of the corners of a rectangle that would surround the given caption
                ' Coordinate X1,Y1 is the bottom left corner of the surrounding rectangle
                ' Coordinate X2,Y2 is the top right corner of the surrounding rectangle
                ComputeExtentsRotatedRectangle(.Caption.XCoordinate, .Caption.YCoordinate, Len(.Caption.Text), 1, .Caption.Angle, mAnnotationDensityToleranceX / 4, mAnnotationDensityToleranceY / 2, X1, Y1, X2, Y2)

                ' Pad X1, Y1, X2, and Y2 based on mAnnotationDensityToleranceX and mAnnotationDensityToleranceY
                X1 = X1 - mAnnotationDensityToleranceX / 3
                X2 = X2 + mAnnotationDensityToleranceX / 3

                Y1 = Y1 - mAnnotationDensityToleranceY / 1
                Y2 = Y2 + mAnnotationDensityToleranceY / 3

                If ((X1 >= dblRangeXMin And X1 <= dblRangeXMax Or X2 >= dblRangeXMin And X2 <= dblRangeXMax) And (Y1 >= dblRangeYMin And Y1 <= dblRangeYMax Or Y2 >= dblRangeYMin And Y2 <= dblRangeYMax)) Then
                    blnCaptionInView = True
                Else
                    blnCaptionInView = False
                End If

                If (.SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapFloating And blnCaptionInView) Or blnDataPointInView Then
                    ' Either the data point for the caption is in view, or a portion of the caption is visible
                    ' Make sure all of the caption is visible

                    If X1 < dblRangeXMin Then
                        dblRangeXMin = X1
                        blnAdjustZoom = True
                    End If
                    If Y1 < dblRangeYMin Then
                        dblRangeYMin = Y1
                        blnAdjustZoom = True
                    End If

                    If X2 > dblRangeXMax Then
                        dblRangeXMax = X2
                        blnAdjustZoom = True
                    End If
                    If Y2 > dblRangeYMax Then
                        dblRangeYMax = Y2
                        blnAdjustZoom = True
                    End If

                End If
            End With
        Next intIndex

        If blnAdjustZoom Then
            SetRangeX(dblRangeXMin, dblRangeXMax, False)
            SetRangeY(dblRangeYMin, dblRangeYMax, False)
        End If

        Exit Sub

AdjustScalingToIncludeAnnotationCaptionsErrorHandler:
        MsgBox("Error in CWGraphControl.AdjustScalingToIncludeAnnotationCaptions: " & vbCrLf & Err.Description, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

    End Sub

    Private Sub AssureValidSeriesNumber(ByRef intSeriesNumber As Short)
        If intSeriesNumber < 1 Or intSeriesNumber > CWGraph.Plots.Count Then intSeriesNumber = 1
    End Sub

    Public Sub AutoLabelPeaks(intSeriesNumber As Short, ByRef blnShowXPos As Boolean, ByRef blnShowYPos As Boolean, Optional ByRef intCaptionAngle As Integer = 0, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = True, Optional ByRef intMaxPeakCount As Integer = 100, Optional ByRef blnForceAsContinuousData As Boolean = False, Optional ByRef blnForceAsDiscreteData As Boolean = False)

        Dim blnContinuousData As Boolean
        Dim blnAnnotationsRemoved As Boolean
        Dim blnAutoHideCaptionsSaved As Boolean

        Dim strGraphTitleSaved, strGraphSubTitleSaved As String
        Dim strProgressCaption As String

        Dim intIndex As Integer
        Dim intIndexStart As Integer
        Dim intAnnotationIndex As Integer
        Dim strCaptionText As String

        Dim dblMaximumIntensity, dblIntensityThreshold As Double

        Dim objDetectPeaks As New clsPeakDetection

        On Error GoTo AutoLabelPeaksErrorHandler

        If intSeriesNumber < 1 Or intSeriesNumber > CWGraph.Plots.Count Then Exit Sub

        strGraphTitleSaved = GetLabelTitle()
        strGraphSubTitleSaved = GetLabelSubtitle()

        strProgressCaption = "Auto-labeling peaks in series " & intSeriesNumber.ToString.Trim
        SetLabelTitle(strProgressCaption)
        SetLabelSubTitle("")
        Application.DoEvents()

        If blnForceAsContinuousData Or blnForceAsDiscreteData Then
            If blnForceAsContinuousData Then
                blnContinuousData = True
            Else
                blnContinuousData = False
            End If
        Else
            If mSeriesPlotMode(intSeriesNumber) = pmPlotModeConstants.pmLines Or mSeriesPlotMode(intSeriesNumber) = pmPlotModeConstants.pmPointsAndLines Then
                blnContinuousData = True
            Else
                blnContinuousData = False
            End If
        End If

        ' Temporarily disable Auto-hiding of captions since it isn't needed in the first call to ZoomOutFull
        blnAutoHideCaptionsSaved = GetAnnotationDensityAutoHideCaptions()
        If blnAutoHideCaptionsSaved Then SetAnnotationDensityAutoHideCaptions(False, False)

        ZoomOutFull(False)

        Dim detectedPeaks As List(Of clsPeakInfo)

        If blnContinuousData Then
            ' Use the Magnitude-Concativity method to find the peaks
            ' The threshold is mPeakDetectIntensityThresholdCounts

            With mDataSaved(intSeriesNumber)
                If .DataCount > 0 And .Initialized Then
                    SetLabelTitle(strProgressCaption & " - Detecting Peaks")
                    Application.DoEvents()
                    detectedPeaks = objDetectPeaks.DetectPeaks(.XVals, .YVals, mPeakDetectIntensityThresholdCounts, mPeakDetectWidthPointsMinimum, mPeakDetectIntensityThresholdPercentageOfMaximum)
                Else
                    detectedPeaks = New List(Of clsPeakInfo)
                End If
            End With
        Else
            ' Discrete Data; label every peak above mPeakDetectIntensityThresholdCounts

            With mDataSaved(intSeriesNumber)
                ' First need to find the maximum intensity
                dblMaximumIntensity = 0
                If .Initialized Then
                    For intIndex = 0 To .DataCount - 1
                        If .YVals(intIndex) > dblMaximumIntensity Then
                            dblMaximumIntensity = .YVals(intIndex)
                        End If
                    Next intIndex
                End If

                dblIntensityThreshold = dblMaximumIntensity * (mPeakDetectIntensityThresholdPercentageOfMaximum / 100.0#)
                If dblIntensityThreshold < mPeakDetectIntensityThresholdCounts Then
                    dblIntensityThreshold = mPeakDetectIntensityThresholdCounts
                End If

                detectedPeaks = New List(Of clsPeakInfo)

                ' Make a list of the data points within threshold
                For intIndex = 0 To .DataCount - 1
                    If .YVals(intIndex) >= dblIntensityThreshold Then
                        Dim newPeak = New clsPeakInfo(intIndex)
                        detectedPeaks.Add(newPeak)
                    End If
                Next intIndex
            End With
        End If

        If detectedPeaks.Count > 0 Then
            With mDataSaved(intSeriesNumber)
                ' Remove all existing annotations for the series
                RemoveAnnotationsForSeries(intSeriesNumber)
                blnAnnotationsRemoved = True

                Dim sortedPeaks = (From item In detectedPeaks Select item Order By item.PeakArea Ascending).ToList()

                If sortedPeaks.Count > intMaxPeakCount Then
                    intIndexStart = sortedPeaks.Count - intMaxPeakCount
                Else
                    intIndexStart = 0
                End If

                SetLabelTitle(strProgressCaption & " - Labeling Peaks: 0 / " & sortedPeaks.Count)
                Application.DoEvents()

                For intPeakIndex = intIndexStart To sortedPeaks.Count - 1

                    Dim dataPointIndex = sortedPeaks(intIndex).PeakLocation

                    If blnShowXPos Or blnShowYPos Then
                        strCaptionText = GenerateAnnotationUsingNearestPoint(.XVals(dataPointIndex),
                                                                             .YVals(dataPointIndex),
                                                                             intSeriesNumber, blnShowXPos, blnShowYPos,
                                                                             True, "",
                                                                             CInt(dataPointIndex))
                    Else
                        ' Show the data point number
                        strCaptionText = intIndex.ToString.Trim
                    End If

                    intAnnotationIndex = SetAnnotation(False, .XVals(dataPointIndex), .YVals(dataPointIndex),
                                                       strCaptionText, intCaptionAngle, intSeriesNumber,
                                                       asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint,
                                                       dataPointIndex, blnShowXPos, blnShowYPos, blnIncludeArrow, blnHideInDenseRegions, 0, True)
                    If intAnnotationIndex <= 0 Then
                        ' Addition failed
                        Exit For
                    End If

                    SetLabelTitle(strProgressCaption & " - Labeling Peaks: " & (intIndex + 1).ToString.Trim & " / " & sortedPeaks.Count)
                    Application.DoEvents()
                Next
            End With
        End If

        SetLabelTitle(strProgressCaption & " - Finishing up")
        Application.DoEvents()

        ZoomOutFull()

        ' Auto-hiding of captions was disabled above; re-enable if necessary
        SetAnnotationDensityAutoHideCaptions(blnAutoHideCaptionsSaved)

        SetLabelTitle(strGraphTitleSaved)
        SetLabelSubTitle(strGraphSubTitleSaved)
        Application.DoEvents()

        Exit Sub

AutoLabelPeaksErrorHandler:
        MsgBox("Error in CWGraphControl.AutoLabelPeaksError(): " & vbCrLf & Err.Description, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        SetLabelTitle(strGraphTitleSaved)
        SetLabelSubTitle(strGraphSubTitleSaved)

    End Sub

    Public Sub AutoScaleVisibleYNow()
        Dim intRangeIndex, intIndex As Integer

        Dim dblMinimumX, dblMaximumX As Double
        Dim dblMinimumY, dblMaximumY As Double
        Dim blnStartXFound As Boolean

        GetRangeX(dblMinimumX, dblMaximumX)

        dblMinimumY = HUGE_POS_NUMBER_DOUBLE
        dblMaximumY = HUGE_NEG_NUMBER_DOUBLE

        ' Step through mDataSaved() and find the minimum and maximum Y values for the loaded data
        For intRangeIndex = 1 To MAX_SERIES_COUNT
            With mDataSaved(intRangeIndex)
                If .Initialized Then
                    blnStartXFound = False
                    For intIndex = 0 To .DataCount - 1
                        If .XVals(intIndex) >= dblMinimumX And Not blnStartXFound Then
                            ' Starting X Value found
                            If intRangeIndex = 1 Or .YVals(intIndex) < dblMinimumY Then dblMinimumY = .YVals(intIndex)
                            If intRangeIndex = 1 Or .YVals(intIndex) > dblMaximumY Then dblMaximumY = .YVals(intIndex)
                            blnStartXFound = True
                        ElseIf blnStartXFound And .XVals(intIndex) <= dblMaximumX Then
                            ' Potential Ending X Value found
                            If .YVals(intIndex) < dblMinimumY Then dblMinimumY = .YVals(intIndex)
                            If .YVals(intIndex) > dblMaximumY Then dblMaximumY = .YVals(intIndex)
                        End If
                    Next intIndex
                    If Not blnStartXFound Then
                        If intRangeIndex = 1 Or .YVals(.DataCount - 1) < dblMinimumY Then dblMinimumY = .YVals(.DataCount - 1)
                        If intRangeIndex = 1 Or .YVals(.DataCount - 1) > dblMaximumY Then dblMaximumY = .YVals(.DataCount - 1)
                    End If
                End If
            End With
        Next intRangeIndex

        System.Diagnostics.Debug.Assert(dblMinimumY < HUGE_POS_NUMBER_DOUBLE, "")
        System.Diagnostics.Debug.Assert(dblMaximumY > HUGE_NEG_NUMBER_DOUBLE, "")

        If dblMinimumY = HUGE_POS_NUMBER_DOUBLE Then dblMinimumY = 0
        If mFixMinimumYAtZero Then dblMinimumY = 0
        If dblMaximumY < dblMinimumY Then dblMaximumY = dblMinimumY + 10

        SetRangeY(dblMinimumY, dblMaximumY, False)

        UpdateAnnotationDensityTolerances()
        AdjustScalingToIncludeAnnotationCaptions()

    End Sub

    Public Sub AutoScaleXNow()
        CWGraph.Axes.Item(1).AutoScaleNow()
        UpdateAnnotationDensityTolerances()
        AdjustScalingToIncludeAnnotationCaptions()
    End Sub

    Public Sub AutoScaleYNow()
        CWGraph.Axes.Item(2).AutoScaleNow()
        UpdateAnnotationDensityTolerances()
        AdjustScalingToIncludeAnnotationCaptions()
    End Sub

    Public Sub CenterCursor(Optional ByVal intCursorNumber As Integer = 1, Optional ByVal blnCenterAll As Boolean = False)

        Dim eSnapModeSaved As CWUIControlsLib.CWCursorSnapModes
        Dim intIndex, intStartIndex, intEndIndex As Integer

        intCursorNumber = ValidateCursorNumber(intCursorNumber)

        If blnCenterAll Then
            intStartIndex = 1
            intEndIndex = CWGraph.Cursors.Count
        Else
            intStartIndex = intCursorNumber
            intEndIndex = intCursorNumber
        End If

        For intIndex = intStartIndex To intEndIndex
            With CWGraph.Cursors.Item(intIndex)
                eSnapModeSaved = .SnapMode
                .SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapFloating
                .XPosition = (CWGraph.Axes.Item(1).Maximum + CWGraph.Axes.Item(1).Minimum) / 2.0#
                .YPosition = (CWGraph.Axes.Item(2).Maximum + CWGraph.Axes.Item(2).Minimum) / 2.0#
                .SnapMode = eSnapModeSaved
            End With
        Next intIndex
    End Sub

    Public Sub ClearData(intSeriesToClear As Short)

        If intSeriesToClear <= MAX_SERIES_COUNT Then
            With mDataSaved(intSeriesToClear)
                Erase .XVals
                Erase .YVals
                .DataCount = 0
                .Initialized = False
            End With
        End If

        If intSeriesToClear < 1 Or intSeriesToClear > CWGraph.Plots.Count Then Exit Sub

        CWGraph.Plots.Item(intSeriesToClear).ClearData()

        ' I've found that I have to call .ClearData twice for it to "stick"
        ' I'm not sure why, but it doesn't hurt anything
        CWGraph.Plots.Item(intSeriesToClear).ClearData()

    End Sub

    Private Sub ComboBoxSetAction()
        Select Case cboMouseAction.SelectedIndex
            Case cmZoomBoxCursorModeConstants.cmZoomBox
                EnableTrackModeZoom()
            Case cmZoomBoxCursorModeConstants.cmZoomX
                EnableTrackModeZoom(True, False)
            Case cmZoomBoxCursorModeConstants.cmZoomY
                EnableTrackModeZoom(False, True)
            Case cmZoomBoxCursorModeConstants.cmPanAll
                EnableTrackModePan()
            Case cmZoomBoxCursorModeConstants.cmPanX
                EnableTrackModePan(True, False)
            Case cmZoomBoxCursorModeConstants.cmCursor
                EnableTrackCursor()
            Case cmZoomBoxCursorModeConstants.cmMoveAnnotations
                EnableTrackAnnotationPlacement()
        End Select
    End Sub

    Private Sub ComputeExtentsRotatedRectangle(ByRef dblStartX As Double, ByRef dblStartY As Double, ByRef dblLength As Double, ByRef dblHeight As Double, dblAngle As Double, ByRef dblScalingX As Double, ByRef dblScalingY As Double, ByRef X1 As Double, ByRef Y1 As Double, ByRef X2 As Double, ByRef Y2 As Double)

        ' Given a rectangle starting at dblStartX and dblStartY, with length dblLength and height dblHeight, find
        '  the extents of a rectangle surrounding the given rectangle, no matter what angle the given rectangle is rotated to
        ' Coordinate X1,Y1 is the bottom left corner of the surrounding rectangle
        ' Coordinate X2,Y2 is the top right corner of the surrounding rectangle
        ' dblAngle should be in degrees, and may be positive or negative
        ' dblScalingX and dblScalingY are used to convert from the given length and height to plot sizes
        ' This conversion is dependent upon dblAngle
        '
        ' Using an x-y coordinate plane with standard directions:
        '                  y
        '                  ^
        '              QII | QI
        '                  |
        '              --------->X     angle of rotation is Counter Clockwise from the x axis
        '                  |
        '              QIII| QIV
        '
        '

        Const PI As Double = 3.14159265358979
        Dim dblAlpha As Double ' Adjusted angle, between 0 and 90 degrees, but converted to radians
        Dim dblLengthScaled, dblHeightScaled As Double

        ' Make sure dblAngle is between 0 and 360
        Do While dblAngle >= 360
            dblAngle = dblAngle - 360
        Loop

        Do While dblAngle <= -360
            dblAngle = dblAngle + 360
        Loop

        If dblAngle < 90 Then
            ' Quadrant I
            dblAlpha = dblAngle * PI / 180
            dblLengthScaled = dblLength * ((90 - dblAngle) / 90.0# * dblScalingX + dblAngle / 90.0# * dblScalingY)
            dblHeightScaled = dblHeight * ((90 - dblAngle) / 90.0# * dblScalingY + dblAngle / 90.0# * dblScalingX)
            X1 = -(dblHeightScaled * System.Math.Cos(PI / 2 - dblAlpha)) ' Note: PI / 2 = 90 degrees
            Y1 = 0
            X2 = dblLengthScaled * System.Math.Cos(dblAlpha)
            Y2 = dblLengthScaled * System.Math.Sin(dblAlpha) + dblHeightScaled * System.Math.Cos(dblAlpha)
        ElseIf dblAngle < 180 Then
            ' Quadrant II
            dblAlpha = (dblAngle - 90) * PI / 180
            dblLengthScaled = dblLength * ((dblAngle - 90) / 90.0# * dblScalingX + (180 - dblAngle) / 90.0# * dblScalingY)
            dblHeightScaled = dblHeight * ((dblAngle - 90) / 90.0# * dblScalingY + (180 - dblAngle) / 90.0# * dblScalingX)
            X1 = -(dblLengthScaled * System.Math.Sin(dblAlpha) + dblHeightScaled * System.Math.Cos(dblAlpha))
            Y1 = -(dblHeightScaled * System.Math.Cos(PI / 2 - dblAlpha)) ' Note: PI / 2 = 90 degrees
            X2 = 0
            Y2 = dblLengthScaled * System.Math.Cos(dblAlpha)
        ElseIf dblAngle < 270 Then
            ' Quadrant III
            dblAlpha = (dblAngle - 180) * PI / 180
            dblLengthScaled = dblLength * ((270 - dblAngle) / 90.0# * dblScalingX + (dblAngle - 180) / 90.0# * dblScalingY)
            dblHeightScaled = dblHeight * ((270 - dblAngle) / 90.0# * dblScalingY + (dblAngle - 180) / 90.0# * dblScalingX)
            X2 = dblHeightScaled * System.Math.Cos(PI / 2 - dblAlpha) ' Note: PI / 2 = 90 degrees
            Y2 = 0
            X1 = -(dblLengthScaled * System.Math.Cos(dblAlpha))
            Y1 = -(dblLengthScaled * System.Math.Sin(dblAlpha) + dblHeightScaled * System.Math.Cos(dblAlpha))
        Else
            ' Quadrant IV
            dblAlpha = (dblAngle - 270) * PI / 180
            dblLengthScaled = dblLength * ((dblAngle - 270) / 90.0# * dblScalingX + (360 - dblAngle) / 90.0# * dblScalingY)
            dblHeightScaled = dblHeight * ((dblAngle - 270) / 90.0# * dblScalingY + (360 - dblAngle) / 90.0# * dblScalingX)
            X2 = dblLengthScaled * System.Math.Sin(dblAlpha) + dblHeightScaled * System.Math.Cos(dblAlpha)
            Y2 = dblHeightScaled * System.Math.Cos(PI / 2 - dblAlpha) ' Note: PI / 2 = 90 degrees
            X1 = 0
            Y1 = -(dblLengthScaled * System.Math.Cos(dblAlpha))
        End If

        X1 = dblStartX + X1
        Y1 = dblStartY + Y1

        X2 = dblStartX + X2
        Y2 = dblStartY + Y2

    End Sub

    Private Function ConvertColorNameToColorObject(strColorName As String) As Color
        ' Removes "Color [" and "]" from strColorName

        Dim strCleanName As String
        Dim cNewColor As Color

        If Not strColorName Is Nothing Then
            strCleanName = strColorName
            If strCleanName.IndexOf("[") = 6 Then
                strCleanName = strCleanName.Remove(0, 7)
                strCleanName = strCleanName.Remove(strCleanName.Length - 1, 1)
            End If

            cNewColor = Color.FromName(strCleanName)

            Debug.Assert(cNewColor.ToString = strColorName)

            Return cNewColor
        Else
            Return Color.Black
        End If

    End Function

    Public Property DateModeXAxis() As Boolean
        Get
            Return chkXAxisDateMode.Checked
        End Get
        Set(Value As Boolean)
            ' Note that this will fire UpdateDisplayPrecision()
            chkXAxisDateMode.Checked = Value
        End Set
    End Property

    Public Property DateModeXAxisShowTime() As Boolean
        Get
            Return chkXAxisDateModeShowTime.Checked
        End Get
        Set(Value As Boolean)
            ' Note that this will fire UpdateDisplayPrecision()
            chkXAxisDateModeShowTime.Checked = Value
        End Set
    End Property

    Private Sub DisplayPosition(XPos As Double, YPos As Double)

        mLastXPos = XPos
        mLastYPos = YPos

        lblPosition.Text = FormatNumber(XPos, mPrecisionX) & ", " & FormatNumber(YPos, mPrecisionY)

        With CWGraph.Cursors.Item(1)
            lblDeltaPosFromCursor.Text = FormatNumber(XPos - .XPosition, mPrecisionX) & ", " & FormatNumber(YPos - .YPosition, mPrecisionY)
        End With

    End Sub

    Private Sub EnableDisableDynamicControls()
        chkFixMinimumYAtZero.Enabled = chkAutoScaleVisibleY.Checked
        chkXAxisDateModeShowTime.Enabled = chkXAxisDateMode.Checked
        txtPrecisionX.Enabled = Not chkXAxisDateMode.Checked
    End Sub

    Public Sub EnableTrackAnnotationPlacement()
        CWGraph.TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackDragAnnotation
    End Sub

    Public Sub EnableTrackCursor()
        CWGraph.TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackDragCursor
    End Sub

    Public Sub EnableTrackModeAllEvents()
        CWGraph.TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackAllEvents
    End Sub

    Public Sub EnableTrackModePan(Optional ByVal blnPanXOnly As Boolean = False, Optional ByVal blnPanYOnly As Boolean = False)
        If blnPanXOnly Then
            CWGraph.TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackPanPlotAreaX
        ElseIf blnPanYOnly Then
            CWGraph.TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackPanPlotAreaY
        Else
            CWGraph.TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackPanPlotAreaXY
        End If
    End Sub

    Public Sub EnableTrackModeZoom(Optional ByVal blnZoomXOnly As Boolean = False, Optional ByVal blnZoomYOnly As Boolean = False)
        If blnZoomXOnly Then
            CWGraph.TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackZoomRectX
        ElseIf blnZoomYOnly Then
            CWGraph.TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackZoomRectY
        Else
            CWGraph.TrackMode = CWUIControlsLib.CWGraphTrackModes.cwGTrackZoomRectXY
        End If
    End Sub

    Public Sub GenerateSineWave(intSeriesNumber As Short, blnXAxisLogBased As Boolean)

        Const DATA_COUNT As Short = 1021
        Dim dblDataX(DATA_COUNT - 1) As Double
        Dim dblDataY(DATA_COUNT - 1) As Double
        Dim intIndex As Integer

        SetSeriesPlotMode(intSeriesNumber, pmPlotModeConstants.pmLines)

        For intIndex = 0 To DATA_COUNT - 1
            dblDataX(intIndex) = System.Math.Log(intIndex + 1)
            dblDataY(intIndex) = System.Math.Sin(intIndex / 25.0#) * 100
        Next intIndex

        If blnXAxisLogBased Then
            SetDataXvsY(intSeriesNumber, dblDataX, dblDataY, DATA_COUNT, "Sine wave, log X", 100)
        Else
            SetDataYOnly(intSeriesNumber, dblDataY, DATA_COUNT, 1, 0.02, "Sine wave", 100)
        End If

    End Sub

    Public Function GetAnnotationFontColor(intSeriesIndex As Short) As Color
        AssureValidSeriesNumber(intSeriesIndex)

        Return mAnnotationStyles(intSeriesIndex).FontColor
    End Function

    Public Function GetAnnotationFontName(intSeriesIndex As Short) As String
        AssureValidSeriesNumber(intSeriesIndex)

        Return mAnnotationStyles(intSeriesIndex).FontName
    End Function

    Public Function GetAnnotationFontSize(intSeriesIndex As Short) As Short
        AssureValidSeriesNumber(intSeriesIndex)

        Return mAnnotationStyles(intSeriesIndex).FontSize
    End Function

    Public Function GetAnnotationDensityToleranceAutoAdjust() As Boolean
        Return mAnnotationDensityToleranceAutoAdjust
    End Function

    Public Function GetAnnotationDensityToleranceX() As Double
        Return mAnnotationDensityToleranceX
    End Function

    Public Function GetAnnotationDensityToleranceY() As Double
        Return mAnnotationDensityToleranceY
    End Function

    Public Function GetAnnotationCount() As Short
        Return CWGraph.Annotations.Count
    End Function

    Public Function GenerateAnnotationUsingNearestPoint(ByRef dblCaptionXPos As Double, ByRef dblCaptionYPos As Double, ByRef intSeriesNumber As Short, ByRef blnAnnotationShowsNearestPointX As Boolean, ByRef blnAnnotationShowsNearestPointY As Boolean, ByRef blnBindToPoint As Boolean, ByRef strCurrentCaption As String, Optional ByRef intPointNumberOverride As Integer = -1) As String
        ' If blnAnnotationShowsNearestPointX or blnAnnotationShowsNearestPointY = True, then returns a dynamic caption
        ' When blnBindToPoint = True, then returns the coordinates of the nearest point
        ' When blnBindToPoint = False, then returns the cooridnates of the caption itself

        Dim strCaption As String = String.Empty
        Dim dblDistance As Double
        Dim intPointNumber As Integer

        On Error GoTo GenerateAnnotationUsingNearestPointErrorHandler

        If blnBindToPoint Then
            If intPointNumberOverride < 0 Then
                intPointNumber = LookupNearestPointNumber(dblCaptionXPos, dblCaptionYPos, intSeriesNumber, dblDistance, True)
            Else
                intPointNumber = intPointNumberOverride
            End If

            If intPointNumber >= 0 And intSeriesNumber >= 1 Then
                With mDataSaved(intSeriesNumber)
                    If .Initialized And intPointNumber < .DataCount Then
                        If blnAnnotationShowsNearestPointX And blnAnnotationShowsNearestPointY Then
                            strCaption = FormatNumber(.XVals(intPointNumber), mPrecisionX) & ", " & FormatNumber(.YVals(intPointNumber), mPrecisionY)
                        ElseIf blnAnnotationShowsNearestPointX Then
                            strCaption = FormatNumber(.XVals(intPointNumber), mPrecisionX)
                        ElseIf blnAnnotationShowsNearestPointY Then
                            strCaption = FormatNumber(.YVals(intPointNumber), mPrecisionY)
                        Else
                            strCaption = strCurrentCaption
                        End If
                    Else
                        strCaption = strCurrentCaption
                    End If
                End With
            End If
        Else
            ' Simply display the coordinates of the caption itself
            If blnAnnotationShowsNearestPointX And blnAnnotationShowsNearestPointY Then
                strCaption = FormatNumberAsString(dblCaptionXPos) & ", " & FormatNumberAsString(dblCaptionYPos)
            ElseIf blnAnnotationShowsNearestPointX Then
                strCaption = FormatNumberAsString(dblCaptionXPos)
            ElseIf blnAnnotationShowsNearestPointY Then
                strCaption = FormatNumberAsString(dblCaptionYPos)
            Else
                strCaption = strCurrentCaption
            End If
        End If

        Return strCaption
        Exit Function

GenerateAnnotationUsingNearestPointErrorHandler:
        System.Diagnostics.Debug.WriteLine("Error occurred in CWGraphControl.GenerateAnnotationUsingNearestPoint(): " & Err.Description)
        Return String.Empty

    End Function

    Public Function GetAnnotationDensityAutoHideCaptions() As Boolean
        Return mAnnotationDensityAutoHideCaptions
    End Function

    Public Function GetAnnotationByIndex(intAnnotationIndex As Integer, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, ByRef strCaptionText As String, Optional ByRef intCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Short = 0, Optional ByRef eAnnotationSnapMode As asmAnnotationSnapModeConstants = asmAnnotationSnapModeConstants.asmFixedToAnyPoint, Optional ByRef intPointNumberToBind As Integer = 0, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = False, Optional ByRef strAnnotationNameReturn As String = "") As Boolean
        ' Returns True if a match was found, False if not found

        With CWGraph.Annotations
            If intAnnotationIndex < 1 Or intAnnotationIndex > .Count Then
                strCaptionText = String.Empty
                Return False
            Else
                With .Item(intAnnotationIndex)
                    CaptionXPos = .Caption.XCoordinate
                    CaptionYPos = .Caption.YCoordinate
                    strCaptionText = LookupCaptionForAnnotation(intAnnotationIndex)
                    intCaptionAngle = CInt(.Caption.Angle)
                    intSeriesNumber = LookupSeriesNumberForPlotObject(.Plot)

                    Select Case .SnapMode
                        Case CWUIControlsLib.CWCursorSnapModes.cwCSnapFloating
                            eAnnotationSnapMode = asmAnnotationSnapModeConstants.asmFloating
                        Case CWUIControlsLib.CWCursorSnapModes.cwCSnapAnchoredToPoint
                            eAnnotationSnapMode = asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint
                        Case Else
                            eAnnotationSnapMode = asmAnnotationSnapModeConstants.asmFixedToAnyPoint
                    End Select

                    If eAnnotationSnapMode = asmAnnotationSnapModeConstants.asmFloating Then
                        intPointNumberToBind = -1
                    Else
                        intPointNumberToBind = .PointIndex
                    End If

                    blnIncludeArrow = LookupArrowVisibilityForAnnotation(intAnnotationIndex)

                    blnAnnotationShowsNearestPointX = mAnnotations(intAnnotationIndex).ShowsNearestPointX
                    blnAnnotationShowsNearestPointY = mAnnotations(intAnnotationIndex).ShowsNearestPointY
                    blnHideInDenseRegions = mAnnotations(intAnnotationIndex).HideInDenseRegions

                    strAnnotationNameReturn = .Name

                    Return True
                End With
            End If
        End With

    End Function

    Public Function GetAnnotationByName(strAnnotationName As String, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, ByRef strCaptionText As String, Optional ByRef intCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Short = 0, Optional ByRef eAnnotationSnapMode As asmAnnotationSnapModeConstants = asmAnnotationSnapModeConstants.asmFixedToAnyPoint, Optional ByRef intPointNumberToBind As Integer = 0, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = False, Optional ByRef strAnnotationNameReturn As String = "", Optional ByRef blnCaseSensitive As Boolean = False) As Boolean
        ' Returns True if a match was found, False if not found

        Dim intIndex As Short
        Dim blnMatchFound As Boolean

        If Not blnCaseSensitive Then strAnnotationName = strAnnotationName.ToLower

        With CWGraph.Annotations
            For intIndex = 1 To .Count
                If blnCaseSensitive Then
                    If .Item(intIndex).Name = strAnnotationName Then blnMatchFound = True
                Else
                    If .Item(intIndex).Name.ToLower = strAnnotationName Then blnMatchFound = True
                End If

                If blnMatchFound Then
                    blnMatchFound = GetAnnotationByIndex(intIndex, CaptionXPos, CaptionYPos, strCaptionText, intCaptionAngle, intSeriesNumber, eAnnotationSnapMode, intPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, strAnnotationNameReturn)
                    Exit For
                End If
            Next
        End With

        Return blnMatchFound

    End Function

    Public Function GetAutoAdjustScalingToIncludeCaptions() As Boolean
        Return mAutoAdjustScalingToIncludeCaptions
    End Function

    Public Function GetAutoscaleVisibleY() As Boolean
        Return chkAutoScaleVisibleY.Checked
    End Function

    Public Function GetControlImage() As System.Drawing.Image
        ' Returns an image of the graph, in the form of a Windows MetaFile
        Return CWGraph.ControlImage()
    End Function

    Public Function GetCursorSnapToDataPointModeEnabled() As Boolean
        If CWGraph.Cursors.Item(1).SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapNearestPoint Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetCursorColor(Optional ByVal intCursorNumber As Integer = 1) As Color
        intCursorNumber = ValidateCursorNumber(intCursorNumber)
        Return ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Cursors.Item(intCursorNumber).Color))
    End Function

    Public Sub GetCursorPosition(ByRef XPos As Double, ByRef YPos As Double, Optional ByVal intCursorNumber As Integer = 1)

        intCursorNumber = ValidateCursorNumber(intCursorNumber)
        With CWGraph.Cursors.Item(intCursorNumber)
            ' Round to 7 digits of precision
            XPos = Val(FormatNumberAsString(.XPosition, 12, 7))
            YPos = Val(FormatNumberAsString(.YPosition, 12, 7))
        End With

    End Sub

    Public Function GetCursorVisibility(Optional ByVal intCursorNumber As Integer = 1) As Boolean
        intCursorNumber = ValidateCursorNumber(intCursorNumber)
        Return CWGraph.Cursors.Item(intCursorNumber).Visible
    End Function

    Public Function GetDataCount(intSeriesNumber As Short) As Integer

        If intSeriesNumber < 1 Or intSeriesNumber > CWGraph.Plots.Count Or intSeriesNumber > MAX_SERIES_COUNT Then
            Return 0
        Else
            If mDataSaved(intSeriesNumber).Initialized Then
                Return mDataSaved(intSeriesNumber).DataCount
            Else
                Return 0
            End If
        End If

    End Function

    Public Function GetDataXvsY(
      intSeriesNumber As Short,
      <Out()> ByRef XDataZeroBased1DArray() As Double,
      <Out()> ByRef YDataZeroBased1DArray() As Double, ByRef DataCount As Integer) As Boolean

        ' Returns True if success, or False if an error

        Try
            If intSeriesNumber < 1 Or intSeriesNumber > CWGraph.Plots.Count Or intSeriesNumber > MAX_SERIES_COUNT Then
                DataCount = 0
                ReDim XDataZeroBased1DArray(0)
                ReDim YDataZeroBased1DArray(0)
                Return False
            Else
                If mDataSaved(intSeriesNumber).Initialized Then
                    With mDataSaved(intSeriesNumber)
                        DataCount = .DataCount

                        ReDim XDataZeroBased1DArray(.DataCount - 1)
                        ReDim YDataZeroBased1DArray(.DataCount - 1)

                        If DataCount > 0 Then
                            Array.Copy(.XVals, XDataZeroBased1DArray, .DataCount)
                            Array.Copy(.YVals, YDataZeroBased1DArray, .DataCount)
                        End If

                    End With
                    Return True
                Else
                    DataCount = 0
                    ReDim XDataZeroBased1DArray(0)
                    ReDim YDataZeroBased1DArray(0)
                    Return False
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("Warning in GetDataXvsY; no data")
            DataCount = 0
            ReDim XDataZeroBased1DArray(0)
            ReDim YDataZeroBased1DArray(0)
            Return False
        End Try

    End Function

    Public Function GetDefaultSeriesColor(ByRef intSeriesNumber As Short) As Color
        Const COLOR_COUNT As Short = 8
        Dim cSuggestedColors(COLOR_COUNT - 1) As Color ' 0-based array

        cSuggestedColors(0) = Drawing.Color.Blue          ' RGB(0, 0, 255)
        cSuggestedColors(1) = Drawing.Color.Red           ' RGB(255, 0, 0)
        cSuggestedColors(2) = Drawing.Color.Green         ' RGB(0, 160, 0)
        cSuggestedColors(3) = Drawing.Color.Magenta       ' RGB(255, 0, 255)

        cSuggestedColors(4) = Drawing.Color.Purple        ' RGB(128, 128, 255)
        cSuggestedColors(5) = Drawing.Color.Salmon        ' RGB(255, 128, 128)
        cSuggestedColors(6) = Drawing.Color.LightGreen    ' RGB(128, 255, 128)
        cSuggestedColors(7) = Drawing.Color.Pink          ' RGB(255, 128, 255)

        Return cSuggestedColors(intSeriesNumber Mod COLOR_COUNT)
    End Function

    Public Function GetDisplayPrecisionX() As Double
        Return mPrecisionX
    End Function

    Public Function GetDisplayPrecisionY() As Double
        Return mPrecisionY
    End Function

    Public Function GetFixMinimumYAtZero() As Boolean
        Return chkFixMinimumYAtZero.Checked
    End Function

    Public Function GetGridLinesXVisible(Optional ByRef blnMajorGridLines As Boolean = True) As Boolean
        ' blnMajorGridLines = True means Major Grid Lines
        ' blnMajorGridLines = False means Minor Grid Lines

        If blnMajorGridLines Then
            Return CWGraph.Axes.Item(1).Ticks.MajorGrid
        Else
            Return CWGraph.Axes.Item(1).Ticks.MinorGrid
        End If
    End Function

    Public Function GetGridlinesYVisible(Optional ByRef blnMajorGridLines As Boolean = True) As Boolean
        ' blnMajorGridLines = True means Major Grid Lines
        ' blnMajorGridLines = False means Minor Grid Lines

        If blnMajorGridLines Then
            Return CWGraph.Axes.Item(2).Ticks.MajorGrid
        Else
            Return CWGraph.Axes.Item(2).Ticks.MinorGrid
        End If
    End Function

    Public Function GetFrameColor() As Color
        Return CWGraph.GraphFrameColor
    End Function

    Public Function GetFrameStyleIs3D() As Boolean
        If CWGraph.GraphFrameStyle = CWUIControlsLib.CWGraphFrameStyles.cwGraphFrame3D Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetGridLinesXColor(Optional ByRef blnMajorGridLines As Boolean = True) As Color
        ' blnMajorGridLines = True means Major Grid Lines
        ' blnMajorGridLines = False means Minor Grid Lines

        If blnMajorGridLines Then
            Return ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Axes.Item(1).Ticks.MajorGridColor))
        Else
            Return ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Axes.Item(1).Ticks.MinorGridColor))
        End If
    End Function

    Public Function GetGridLinesYColor(Optional ByRef blnMajorGridLines As Boolean = True) As Color
        ' blnMajorGridLines = True means Major Grid Lines
        ' blnMajorGridLines = False means Minor Grid Lines

        If blnMajorGridLines Then
            Return ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Axes.Item(2).Ticks.MajorGridColor))
        Else
            Return ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Axes.Item(2).Ticks.MinorGridColor))
        End If
    End Function

    Public Function GetLabelFontColor() As Color
        Return CWGraph.CaptionColor
    End Function

    Public Function GetLabelFontName() As String
        Return CWGraph.Font.Name
    End Function

    Public Function GetLabelFontSize() As Short
        Return CWGraph.Font.Size
    End Function

    Public Function GetLabelSubtitle() As String
        Return mSubTitle
    End Function

    Public Function GetLabelTitle() As String
        Return mTitle
    End Function

    Public Function GetLabelXAxis() As String
        Return CWGraph.Axes.Item(1).Caption
    End Function

    Public Function GetLabelYAxis() As String
        Return CWGraph.Axes.Item(2).Caption
    End Function

    Public Function GetPeakDetectIntensityThresholdCounts() As Double
        Return mPeakDetectIntensityThresholdCounts
    End Function

    Public Function GetPeakDetectIntensityThresholdPercentageOfMaximum() As Integer
        Return mPeakDetectIntensityThresholdPercentageOfMaximum
    End Function

    Public Function GetPeakDetectWidthPointsMinimum() As Integer
        Return mPeakDetectWidthPointsMinimum
    End Function

    Public Function GetPlotBackgroundColor() As Color
        Return CWGraph.PlotAreaColor
    End Function

    Public Function GetRangeX(Optional ByRef dblMinimum As Double = 0, Optional ByRef dblMaximum As Double = 0) As Double
        ' Returns Abs(dblMaximum - dblMinimum)
        With CWGraph.Axes.Item(1)
            dblMinimum = .Minimum
            dblMaximum = .Maximum
            Return System.Math.Abs(.Maximum - .Minimum)
        End With
    End Function

    Public Function GetRangeY(Optional ByRef dblMinimum As Double = 0, Optional ByRef dblMaximum As Double = 0) As Double
        ' Returns Abs(dblMaximum - dblMinimum)
        With CWGraph.Axes.Item(2)
            dblMinimum = .Minimum
            dblMaximum = .Maximum
            Return System.Math.Abs(.Maximum - .Minimum)
        End With
    End Function

    Public Function GetSeriesBarFillColor(intSeriesNumber As Short) As Color
        AssureValidSeriesNumber(intSeriesNumber)
        Return ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Plots.Item(intSeriesNumber).FillColor))
    End Function

    Public Function GetSeriesCount() As Short
        Return CWGraph.Plots.Count
    End Function

    Public Function GetSeriesLegendCaption(intSeriesNumber As Short) As String
        AssureValidSeriesNumber(intSeriesNumber)
        Return mDataSaved(intSeriesNumber).LegendCaption
    End Function

    Public Function GetSeriesLineColor(intSeriesNumber As Short) As Color
        AssureValidSeriesNumber(intSeriesNumber)
        Return ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Plots.Item(intSeriesNumber).LineColor))
    End Function

    Public Function GetSeriesLineToBaseColor(intSeriesNumber As Short) As Color
        AssureValidSeriesNumber(intSeriesNumber)
        Return ColorTranslator.FromOle(System.Convert.ToInt32((CWGraph.Plots.Item(intSeriesNumber).LineToBaseColor)))
    End Function

    Public Function GetSeriesLineStyle(intSeriesNumber As Short) As CWUIControlsLib.CWLineStyles
        AssureValidSeriesNumber(intSeriesNumber)
        Return CWGraph.Plots.Item(intSeriesNumber).LineStyle
    End Function

    Public Function GetSeriesLineWidth(intSeriesNumber As Short) As Short
        AssureValidSeriesNumber(intSeriesNumber)
        Return CWGraph.Plots.Item(intSeriesNumber).LineWidth
    End Function

    Public Function GetSeriesOriginalIntensityMaximum(intSeriesNumber As Short) As Double
        AssureValidSeriesNumber(intSeriesNumber)
        Return mDataSaved(intSeriesNumber).OriginalMaximumIntensity
    End Function

    Public Function GetSeriesPlotMode(intSeriesNumber As Short) As pmPlotModeConstants
        AssureValidSeriesNumber(intSeriesNumber)
        Return mSeriesPlotMode(intSeriesNumber)
    End Function

    Public Function GetSeriesPointColor(intSeriesNumber As Short) As Color
        AssureValidSeriesNumber(intSeriesNumber)
        Return ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Plots.Item(intSeriesNumber).PointColor))
    End Function

    Public Function GetSeriesPointStyle(intSeriesNumber As Short) As CWUIControlsLib.CWPointStyles
        AssureValidSeriesNumber(intSeriesNumber)
        Return CWGraph.Plots.Item(intSeriesNumber).PointStyle
    End Function

    Private Sub InitializeAnnotationInfoArray()
        ReDim mAnnotations(CWGraph.Annotations.Count)
    End Sub

    Private Sub InitializeGraphControl()

        Dim objToolTip As ToolTip

        ToggleOptionsFrameVisibility(True)

        SetSeriesCount(2)
        SetSeriesPlotMode(1, pmPlotModeConstants.pmSticksToZero)
        SetSeriesPlotMode(2, pmPlotModeConstants.pmSticksToZero)

        ' Populate the combo boxes
        PopulateComboBoxes()

        mControlsFrameHidden = False
        cmdRollUpHide.Visible = True
        cmdRollUpShow.Visible = False

        UpdateLegend()

        ' Read settings from registry
        ' If not present (or can't be read), then defaults are used
        RegistryReadSettings()

        EnableDisableDynamicControls()

        CenterCursor(1, True)

        ZoomOutFull(False)

        EnableTrackModeAllEvents()

        fraOptionsShadow.Top = 0
        fraOptionsShadow.Left = 0

        MyBase.Width = 33
        MyBase.Height = 20

        InitializeAnnotationInfoArray()
        mRecentAnnotationSnapMode = asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint
        mRecentAnnotationHideInDenseRegions = True

        UpdateAnnotationDensityTolerances()

        objToolTip = New ToolTip
        objToolTip.SetToolTip(txtAnnotationDensityToleranceX, "Minimum units between displayed annotations.")
        objToolTip.SetToolTip(txtAnnotationDensityToleranceY, objToolTip.GetToolTip(txtAnnotationDensityToleranceX))

        objToolTip.SetToolTip(cboMouseAction, "Use the A key to temporarily enable 'Move Annotation' mode, P to 'Pan' the graph, Z for the 'Zoom Box', and C to move the 'Cursor'")

        objToolTip = Nothing

        chkAutoAdjustScalingToIncludeAnnotationCaptions.Text = "&Auto Adjust Scaling to" & vbCrLf & "Include Captions"

    End Sub

    Private Function LookupSeriesNumberForPlotObject(ByRef objPlot As CWUIControlsLib.CWPlot) As Short
        ' Returns the series number if a match is found
        ' Otherwise, returns 0

        Dim intSeriesIndexCompare As Short
        Dim intMatchingSeriesNumber As Short

        intMatchingSeriesNumber = 0
        For intSeriesIndexCompare = 1 To CWGraph.Plots.Count
            If objPlot._Name = CWGraph.Plots.Item(intSeriesIndexCompare)._Name Then
                intMatchingSeriesNumber = intSeriesIndexCompare
                Exit For
            End If
        Next intSeriesIndexCompare

        If intMatchingSeriesNumber = 0 Then
            ' Match not found by comparing objects
            ' Try finding a match by comparing names
            intMatchingSeriesNumber = LookupSeriesNumberForPlotName((objPlot.Name))
        End If

        Return intMatchingSeriesNumber

    End Function

    Private Function Lookup2DArrayValueByName(ByRef str2DArray(,) As String, strNameToFind As String, Optional ByVal strTextToReturnIfNotFound As String = "") As String
        Dim intSettings As Short
        Dim strValue As String

        strNameToFind = strNameToFind.ToUpper

        strValue = strTextToReturnIfNotFound
        For intSettings = LBound(str2DArray, 1) To UBound(str2DArray, 1)
            If str2DArray(intSettings, 0).ToUpper = strNameToFind Then
                strValue = str2DArray(intSettings, 1)
                Exit For
            End If
        Next intSettings

        Return strValue

    End Function

    Private Function LookupCaptionForAnnotation(intAnnotationIndex As Integer) As String
        ' This function is needed since an annotation's "official" caption is changed to ""
        '  when the caption is hidden in dense areas; the original is stored in mAnnotations().CaptionText

        On Error GoTo LookupCaptionForAnnotationErrorHandler

        If intAnnotationIndex < 1 Or intAnnotationIndex > CWGraph.Annotations.Count Then
            Return String.Empty
        Else
            If mAnnotations(intAnnotationIndex).Hidden Then
                Return mAnnotations(intAnnotationIndex).CaptionText
            Else
                Return CWGraph.Annotations.Item(intAnnotationIndex).Caption.Text
            End If
        End If

        Exit Function

LookupCaptionForAnnotationErrorHandler:
        System.Diagnostics.Debug.WriteLine("Error occurred in CWGraphControl.LookupCaptionForAnnotation(): " & Err.Description)
        Return String.Empty

    End Function

    Private Function LookupArrowVisibilityForAnnotation(intAnnotationIndex As Integer) As Boolean
        ' This function is needed since an annotation's arrow is hidden when the caption is hidden
        '  when the caption is hidden in dense areas; mAnnotations().IncludeArrow will report whether or not an arrow really should be present

        On Error GoTo LookupArrowVisibilityForAnnotationErrorHandler

        If intAnnotationIndex < 1 Or intAnnotationIndex > CWGraph.Annotations.Count Then
            Return False
        Else
            If mAnnotations(intAnnotationIndex).Hidden Then
                Return mAnnotations(intAnnotationIndex).IncludeArrow
            Else
                Return CWGraph.Annotations.Item(intAnnotationIndex).Arrow.Visible
            End If
        End If

        Exit Function

LookupArrowVisibilityForAnnotationErrorHandler:
        System.Diagnostics.Debug.WriteLine("Error occurred in CWGraphControl.LookupArrowVisibilityForAnnotation(): " & Err.Description)
        Return False

    End Function

    Public Function LookupNearestPointNumber(dblXPosSearch As Double, dblYPosSearch As Double, ByRef intSeriesNumber As Short, Optional ByRef dblDistanceToClosestSeriesNumberDataPoint As Double = 0, Optional ByVal blnLimitToGivenSeriesNumber As Boolean = False) As Integer
        ' Looks for the point nearest to dblXPosSearch and dblYPosSearch
        ' If found, then returns the point number; otherwise returns -1
        ' Returns the distance from the search points to the target point ByRef in dblDistanceToClosestSeriesNumberDataPoint
        ' Updates intSeriesNumber with the series number of the point
        ' However, if blnLimitToGivenSeriesNumber then will only return points for the given series number

        Dim intRangeIndex, intIndex As Integer
        Dim intClosestSeriesNumber As Short
        Dim intClosestDataPoint As Integer
        Dim dblYDistance, dblXDistance, dblDistance As Double

        dblDistanceToClosestSeriesNumberDataPoint = HUGE_POS_NUMBER_DOUBLE
        intClosestSeriesNumber = -1

        ' Determine the series number closest to the click location
        ' Step through mDataSaved() to find the series that is closest to the mouse click
        For intRangeIndex = 1 To MAX_SERIES_COUNT
            If Not blnLimitToGivenSeriesNumber Or (blnLimitToGivenSeriesNumber And intRangeIndex = intSeriesNumber) Then
                With mDataSaved(intRangeIndex)
                    If .Initialized Then
                        For intIndex = 0 To .DataCount - 1
                            dblXDistance = System.Math.Abs(.XVals(intIndex) - dblXPosSearch)
                            dblYDistance = System.Math.Abs(.YVals(intIndex) - dblYPosSearch)

                            dblDistance = System.Math.Sqrt(dblXDistance ^ 2 + dblYDistance ^ 2)
                            If dblDistance < dblDistanceToClosestSeriesNumberDataPoint Then
                                dblDistanceToClosestSeriesNumberDataPoint = dblDistance
                                intClosestSeriesNumber = intRangeIndex
                                intClosestDataPoint = intIndex
                            End If
                        Next intIndex
                    End If
                End With

            End If
        Next intRangeIndex

        If intClosestSeriesNumber >= 1 Then
            If blnLimitToGivenSeriesNumber Then System.Diagnostics.Debug.Assert(intSeriesNumber = intClosestSeriesNumber, "")
            intSeriesNumber = intClosestSeriesNumber
            Return intClosestDataPoint
        Else
            dblDistanceToClosestSeriesNumberDataPoint = 0
            Return -1
        End If

    End Function

    Private Function LookupSeriesNumberForPlotName(strPlotName As String) As Short
        ' Returns the series number if a match is found
        ' Otherwise, returns 0

        Dim intSeriesIndexCompare As Short
        Dim intMatchingSeriesNumber As Short

        intMatchingSeriesNumber = 0
        For intSeriesIndexCompare = 1 To CWGraph.Plots.Count
            If strPlotName = CWGraph.Plots.Item(intSeriesIndexCompare).Name Then
                intMatchingSeriesNumber = intSeriesIndexCompare
                Exit For
            End If
        Next intSeriesIndexCompare

        Return intMatchingSeriesNumber

    End Function

    Private Sub MoveOptionsFrame()
        mControlsFrameLocation = mControlsFrameLocation + 1
        If mControlsFrameLocation > ofOptionsFrameLocationConstants.ofBottomRight Then
            mControlsFrameLocation = ofOptionsFrameLocationConstants.ofTopLeft
        End If

        PositionControls()
    End Sub

    Private Sub PopulateComboBoxes()

        With cboMouseAction
            .Items.Clear()
            .Items.Add("Zoom Box")
            .Items.Add("Zoom X")
            .Items.Add("Zoom Y")
            .Items.Add("Pan graph")
            .Items.Add("Pan along X")
            .Items.Add("Cursor")
            .Items.Add("Move Annotation")
            .SelectedIndex = cmZoomBoxCursorModeConstants.cmZoomX
        End With

    End Sub

    Private Sub PositionControls()
        Dim intDesiredValue, intCompareValue As Integer
        Dim intOptionsTopWhenAtBottom As Integer
        Dim intOptionsLeftWhenAtRight As Integer

        ' lblPosition is auto-sized, based on mPrecisionX and mPrecisionY
        With lblPosition
            .Width = 100 + mPrecisionX * 6.6 + mPrecisionY * 6.6
            lblDeltaPosFromCursor.Width = .Width
            intDesiredValue = .Left + .Width + 4
            If intDesiredValue < 187 Then intDesiredValue = 187
            fraPosition.Width = intDesiredValue
        End With

        ' fraLegend grows when the window gets larger
        ' However, the minimum width is 240
        With fraLegend
            .Left = fraPosition.Left + fraPosition.Width
            intDesiredValue = ClientRectangle.Width - fraControls.Left - .Left - cmdRollUpHide.Width - 4
            If intDesiredValue < 240 Then intDesiredValue = 240
            .Width = intDesiredValue
        End With

        ' fraControls is sized to encompass all of the other frames
        With fraControls
            .Width = fraLegend.Left + fraLegend.Width
            .Left = 8
        End With

        ' cmdRollUpHide and cmdRollUpShow are placed in the bottom right corner of the form
        ' However, they must be to the right of fraControls if it is visible
        ' If fraControls is hidden, then the bottom right corner of the form is used
        intDesiredValue = ClientRectangle.Height - cmdRollUpHide.Height
        If intDesiredValue < cmdRollUpHide.Height Then intDesiredValue = cmdRollUpHide.Height

        cmdRollUpHide.Top = intDesiredValue
        intDesiredValue = ClientRectangle.Width - cmdRollUpHide.Width - 4
        If mControlsFrameHidden Then
            intCompareValue = ClientRectangle.Width / 2
        Else
            intCompareValue = fraControls.Left + fraControls.Width + 4
        End If

        If intDesiredValue < intCompareValue Then
            intDesiredValue = intCompareValue
        End If

        cmdRollUpHide.Left = intDesiredValue
        cmdRollUpShow.Top = cmdRollUpHide.Top
        cmdRollUpShow.Left = cmdRollUpHide.Left

        intDesiredValue = cmdRollUpHide.Top + cmdRollUpHide.Height
        With fraControls
            If Not mControlsFrameHidden Then
                intDesiredValue = intDesiredValue - fraControls.Height
            End If

            If intDesiredValue < 0 Then intDesiredValue = 0

            .Top = intDesiredValue
        End With

        intDesiredValue = fraControls.Top - CWGraph.Top - 4
        If intDesiredValue < 1 Then intDesiredValue = 1
        CWGraph.Height = intDesiredValue

        ' Position the Options Controls frame
        intOptionsLeftWhenAtRight = ClientRectangle.Width - fraOptions.Width - (fraOptionsShadow.Width - fraOptions.Width)
        If intOptionsLeftWhenAtRight < 0 Then intOptionsLeftWhenAtRight = 0

        intOptionsTopWhenAtBottom = CWGraph.Top + CWGraph.Height - fraOptions.Height - (fraOptionsShadow.Height - fraOptions.Height)
        If intOptionsTopWhenAtBottom < 0 Then intOptionsTopWhenAtBottom = 0

        With fraOptionsShadow
            Select Case mControlsFrameLocation
                Case ofOptionsFrameLocationConstants.ofTopLeft
                    .SetBounds(0, 0, 0, 0, BoundsSpecified.Location)
                Case ofOptionsFrameLocationConstants.ofTopRight
                    .SetBounds(intOptionsLeftWhenAtRight, 0, 0, 0, BoundsSpecified.Location)
                Case ofOptionsFrameLocationConstants.ofBottomLeft
                    .SetBounds(0, intOptionsTopWhenAtBottom, 0, 0, BoundsSpecified.Location)
                Case ofOptionsFrameLocationConstants.ofBottomRight
                    .SetBounds(intOptionsLeftWhenAtRight, intOptionsTopWhenAtBottom, 0, 0, BoundsSpecified.Location)
                Case Else
                    ' Programming error
                    System.Diagnostics.Debug.Assert(False, "")
            End Select
        End With

        UpdateAnnotationDensityTolerances()

    End Sub

    Private Sub RecordZoomRange(blnZoomingOutFull As Boolean, Optional ByRef blnReturnAnnotationVisibilityChecked As Boolean = False)
        Dim blnProceed As Boolean
        Dim intIndex As Short

        ' Make sure the new range isn't the same as the saved one
        ' If it is, then no need to record it
        blnProceed = True
        With ZoomHistory(0)
            If Math.Abs(.XMinimum - CWGraph.Axes.Item(1).Minimum) < Single.Epsilon And
               Math.Abs(.XMaximum - CWGraph.Axes.Item(1).Maximum) < Single.Epsilon And
               Math.Abs(.YMinimum - CWGraph.Axes.Item(2).Minimum) < Single.Epsilon And
               Math.Abs(.YMaximum - CWGraph.Axes.Item(2).Maximum) < Single.Epsilon Then
                blnProceed = False
            End If
        End With

        If Not blnProceed Then
            blnReturnAnnotationVisibilityChecked = False
            Exit Sub
        End If

        ' If Autoscaling based on visible y, then need to update the y-axis limits now
        If mAutoScaleVisibleY And Not blnZoomingOutFull Then
            AutoScaleVisibleYNow()
        End If

        ' Shift the history values up by one
        For intIndex = MAX_HISTORY_COUNT - 1 To 1 Step -1
            ZoomHistory(intIndex) = ZoomHistory(intIndex - 1)
        Next intIndex

        ' Add the current range to the 0th position
        With ZoomHistory(0)
            .XMinimum = CWGraph.Axes.Item(1).Minimum
            .XMaximum = CWGraph.Axes.Item(1).Maximum
            .YMinimum = CWGraph.Axes.Item(2).Minimum
            .YMaximum = CWGraph.Axes.Item(2).Maximum
        End With

        UpdateAnnotationDensityTolerances()
        blnReturnAnnotationVisibilityChecked = True

    End Sub

    Public Function RemoveAnnotationByCaption(strAnnotationText As String, Optional ByVal blnCaseSensitive As Boolean = False) As Boolean
        ' Looks for an annotation containing strAnnotationText
        ' If found, removes it and returns True
        ' Otherwise, returns false
        Dim intIndex As Integer
        Dim blnFound As Boolean

        If Not blnCaseSensitive Then strAnnotationText = strAnnotationText.ToLower

        blnFound = False
        With CWGraph
            For intIndex = 1 To .Annotations.Count
                If blnCaseSensitive Then
                    If LookupCaptionForAnnotation(intIndex) = strAnnotationText Then blnFound = True
                Else
                    If LookupCaptionForAnnotation(intIndex).ToLower = strAnnotationText Then blnFound = True
                End If
                If blnFound Then
                    blnFound = RemoveAnnotationByIndex(intIndex)
                    Exit For
                End If
            Next intIndex
        End With

        Return blnFound
    End Function

    Public Function RemoveAnnotationByIndex(intAnnotationIndex As Integer) As Boolean
        ' Removes annotation given by intAnnotationIndex
        ' Returns true if success, false if not found or error

        Dim intInfoIndex As Integer

        If intAnnotationIndex >= 1 And intAnnotationIndex <= CWGraph.Annotations.Count Then
            For intInfoIndex = intAnnotationIndex To CWGraph.Annotations.Count - 1
                mAnnotations(intInfoIndex) = mAnnotations(intInfoIndex + 1)
            Next intInfoIndex

            CWGraph.Annotations.Remove(intAnnotationIndex)

            ReDim Preserve mAnnotations(CWGraph.Annotations.Count)

            Return True
        Else
            Return False
        End If

    End Function

    Private Sub RegistryReadSettings()

        Dim strGraphOptions(,) As String        ' 2D array, KeyNames are in (x, 0); KeyValues are in (x, 1)

        Dim intSeriesIndex As Short
        Dim strValue, strValue2 As String
        Dim cDefaultFrameBorderColor As Color
        Dim cFrameBorderColor As Color

        Try
            strGraphOptions = GetAllSettings(APP_NAME_IN_REGISTRY, "Options")

            If Not IsArray(strGraphOptions) Then
                ReDim strGraphOptions(0, 2)
            End If

            ' Read the Label font settings (plot title and axis labels)
            strValue = Lookup2DArrayValueByName(strGraphOptions, "LabelFontName", DEFAULT_FONT_NAME)
            If Len(strValue) = 0 Then strValue = DEFAULT_FONT_NAME
            SetLabelFontName(strValue)

            strValue = Lookup2DArrayValueByName(strGraphOptions, "LabelFontSize", DEFAULT_FONT_SIZE.ToString)
            If Len(strValue) = 0 Then strValue = DEFAULT_FONT_SIZE.ToString().Trim()
            SetLabelFontSize(StringToValueUtils.CIntSafe(strValue, DEFAULT_FONT_SIZE))

            Try
                strValue = Lookup2DArrayValueByName(strGraphOptions, "LabelFontColor", Color.Black.ToString)
                If IsNumeric(strValue) Then
                    strValue = Color.Black.ToString
                End If
                SetLabelFontColor(ConvertColorNameToColorObject(strValue))
            Catch ex As Exception
                ' Ignore the error
            End Try

            Try
                strValue = Lookup2DArrayValueByName(strGraphOptions, "PlotBackgroundColor", Color.White.ToString)
                If IsNumeric(strValue) Then
                    strValue = Color.White.ToString
                End If
                SetPlotBackgroundColor(ConvertColorNameToColorObject(strValue))
            Catch ex As Exception
                ' Ignore the error
            End Try

            Try

                cDefaultFrameBorderColor = Color.FromArgb(255, 236, 233, 216)
                strValue = Lookup2DArrayValueByName(strGraphOptions, "FrameBorderColor", cDefaultFrameBorderColor.ToString)
                If IsNumeric(strValue) Then
                    strValue = cDefaultFrameBorderColor.ToString
                End If
                cFrameBorderColor = ConvertColorNameToColorObject(strValue)
                If cFrameBorderColor.ToArgb = 0 Then cFrameBorderColor = cDefaultFrameBorderColor

                SetFrameColor(cFrameBorderColor)
            Catch ex As Exception
                ' Ignore the error
            End Try

            strValue = Lookup2DArrayValueByName(strGraphOptions, "FrameStyleIs3D", "True")
            SetFrameStyle(CBoolSafe(strValue))

            strValue = Lookup2DArrayValueByName(strGraphOptions, "AnnotationDensityAutoHideCaptions", "True")
            SetAnnotationDensityAutoHideCaptions(CBoolSafe(strValue))

            strValue = Lookup2DArrayValueByName(strGraphOptions, "AnnotationDensityToleranceAutoAdjust", "True")
            SetAnnotationDensityToleranceAutoAdjust(CBoolSafe(strValue))

            If GetAnnotationDensityToleranceAutoAdjust() Then
                UpdateAnnotationDensityTolerances()
            Else
                strValue = Lookup2DArrayValueByName(strGraphOptions, "AnnotationDensityToleranceX")
                If Not IsNumeric(strValue) Then
                    strValue = "0.1"
                ElseIf Val(strValue) <= 0 Then
                    strValue = "0.1"
                End If
                SetAnnotationDensityToleranceX(Val(strValue))

                strValue = Lookup2DArrayValueByName(strGraphOptions, "AnnotationDensityToleranceY")
                If Not IsNumeric(strValue) Then
                    strValue = "0.1"
                ElseIf Val(strValue) <= 0 Then
                    strValue = "0.1"
                End If
                SetAnnotationDensityToleranceY(Val(strValue))
            End If

            strValue = Lookup2DArrayValueByName(strGraphOptions, "PeakDetectIntensityThresholdCounts", "10")
            SetPeakDetectIntensityThresholdCounts(StringToValueUtils.CDoubleSafe(strValue, 10))

            strValue = Lookup2DArrayValueByName(strGraphOptions, "PeakDetectIntensityThresholdPercentageOfMaximum", "0")
            SetPeakDetectIntensityThresholdPercentageOfMaximum(StringToValueUtils.CIntSafe(strValue, 0))

            strValue = Lookup2DArrayValueByName(strGraphOptions, "PeakDetectWidthPointsMinimum", "5")
            SetPeakDetectWidthPointsMinimum(StringToValueUtils.CIntSafe(strValue, 5))

            strValue = Lookup2DArrayValueByName(strGraphOptions, "AutoScaleVisibleY", "False")
            strValue2 = Lookup2DArrayValueByName(strGraphOptions, "FixMinimumYAtZero", "False")
            SetAutoscaleVisibleY(CBoolSafe(strValue), CBoolSafe(strValue2))

            strValue = Lookup2DArrayValueByName(strGraphOptions, "AutoAdjustScalingToIncludeCaptions", "True")
            SetAutoAdjustScalingToIncludeCaptions(CBoolSafe(strValue))

            strValue = Lookup2DArrayValueByName(strGraphOptions, "PrecisionX", "2")
            SetDisplayPrecisionX(StringToValueUtils.CIntSafe(strValue, 2))

            strValue = Lookup2DArrayValueByName(strGraphOptions, "PrecisionY", "1")
            SetDisplayPrecisionY(StringToValueUtils.CIntSafe(strValue, 1))

            strValue = Lookup2DArrayValueByName(strGraphOptions, "Cursor1Visible", "True")
            SetCursorVisible(CBoolSafe(strValue), 1)

            strValue = Lookup2DArrayValueByName(strGraphOptions, "Cursor2Visible", "False")
            SetCursorVisible(CBoolSafe(strValue), 2)

            strValue = Lookup2DArrayValueByName(strGraphOptions, "CursorSnapToData", "False")
            SetCursorSnapMode(CBoolSafe(strValue))

            Try
                strValue = Lookup2DArrayValueByName(strGraphOptions, "Cursor1Color", Color.Black.ToString)
                If IsNumeric(strValue) Then
                    strValue = Color.Black.ToString
                End If
                SetCursorColor(ConvertColorNameToColorObject(strValue), 1)
            Catch ex As Exception
                ' Ignore the error
            End Try

            Try
                strValue = Lookup2DArrayValueByName(strGraphOptions, "Cursor2Color", Color.DimGray.ToString)
                If IsNumeric(strValue) Then
                    strValue = Color.DimGray.ToString
                End If
                SetCursorColor(ConvertColorNameToColorObject(strValue), 2)
            Catch ex As Exception
                ' Ignore the error
            End Try

            ' Populate mAnnotationStyles()
            For intSeriesIndex = 1 To MAX_SERIES_COUNT
                strValue = Lookup2DArrayValueByName(strGraphOptions, "AnnotationFontName" & intSeriesIndex.ToString.Trim, DEFAULT_FONT_NAME)
                If Len(strValue) = 0 Then strValue = DEFAULT_FONT_NAME
                SetAnnotationFontName(intSeriesIndex, strValue)

                strValue = Lookup2DArrayValueByName(strGraphOptions, "AnnotationFontSize" & intSeriesIndex.ToString.Trim, DEFAULT_ANNOTATION_FONT_SIZE.ToString.Trim)
                If Len(strValue) = 0 Then strValue = DEFAULT_ANNOTATION_FONT_SIZE.ToString.Trim
                SetAnnotationFontSize(intSeriesIndex, StringToValueUtils.CIntSafe(strValue, DEFAULT_ANNOTATION_FONT_SIZE))

                Try
                    strValue = Lookup2DArrayValueByName(strGraphOptions, "AnnotationFontColor", Color.White.ToString)
                    If IsNumeric(strValue) Then
                        strValue = Color.White.ToString
                    End If

                    If ConvertColorNameToColorObject(strValue).Equals(CWGraph.PlotAreaColor) Then
                        ' We won't be able to see the labels since the color is the same as the background color
                        If CWGraph.PlotAreaColor.Equals(Color.Black) Then
                            strValue = Color.White.ToString
                        Else
                            strValue = Color.Black.ToString
                        End If
                    End If
                    SetAnnotationFontColor(intSeriesIndex, ConvertColorNameToColorObject(strValue))

                Catch ex As Exception
                    ' Ignore the error
                End Try

            Next intSeriesIndex

        Catch ex As Exception
            Debug.WriteLine("Error in RegistryReadSettings: " & ex.Message)
        End Try


    End Sub

    Private Sub RegistrySaveSettings()

        Dim intSeriesIndex As Short

        ' Use Resume Next error handling in case the user doesn't have access to writing the registry
        On Error Resume Next

        SaveSetting(APP_NAME_IN_REGISTRY, "About", "About", "Settings for a customized version of the National Instruments CWGraph control.")
        SaveSetting(APP_NAME_IN_REGISTRY, "About", "Author", "Software written by Matthew Monroe for Pacific Northwest National Laboratory in Richland, WA")
        SaveSetting(APP_NAME_IN_REGISTRY, "About", "Contact", "Contact via http://www.alchemistmatt.com")
        SaveSetting(APP_NAME_IN_REGISTRY, "About", "Date", CWGRAPH_APP_DATE)
        SaveSetting(APP_NAME_IN_REGISTRY, "About", "Version", CWGRAPH_APP_VERSION)

        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "LabelFontName", GetLabelFontName())
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "LabelFontSize", GetLabelFontSize().ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "LabelFontColor", GetLabelFontColor().ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "PlotBackgroundColor", GetPlotBackgroundColor().ToString.Trim)

        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "AnnotationDensityAutoHideCaptions", mAnnotationDensityAutoHideCaptions.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "AnnotationDensityToleranceAutoAdjust", mAnnotationDensityToleranceAutoAdjust.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "AnnotationDensityToleranceX", mAnnotationDensityToleranceX.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "AnnotationDensityToleranceY", mAnnotationDensityToleranceY.ToString.Trim)

        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "PeakDetectIntensityThresholdCounts", mPeakDetectIntensityThresholdCounts.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "PeakDetectIntensityThresholdPercentageOfMaximum", mPeakDetectIntensityThresholdPercentageOfMaximum.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "PeakDetectWidthPointsMinimum", mPeakDetectWidthPointsMinimum.ToString.Trim)

        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "AutoScaleVisibleY", mAutoScaleVisibleY.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "FixMinimumYAtZero", mFixMinimumYAtZero.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "AutoAdjustScalingToIncludeCaptions", mAutoAdjustScalingToIncludeCaptions.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "PrecisionX", mPrecisionX.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "PrecisionY", mPrecisionY.ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "Cursor1Visible", GetCursorVisibility(1.ToString.Trim))
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "Cursor2Visible", GetCursorVisibility(2.ToString.Trim))
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "CursorSnapToData", GetCursorSnapToDataPointModeEnabled().ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "Cursor1Color", GetCursorColor(1).ToString.Trim)
        SaveSetting(APP_NAME_IN_REGISTRY, "Options", "Cursor2Color", GetCursorColor(2).ToString.Trim)

        For intSeriesIndex = 1 To MAX_SERIES_COUNT
            SaveSetting(APP_NAME_IN_REGISTRY, "Options", "AnnotationFontName" & intSeriesIndex.ToString.Trim, mAnnotationStyles(intSeriesIndex).FontName)
            SaveSetting(APP_NAME_IN_REGISTRY, "Options", "AnnotationFontSize" & intSeriesIndex.ToString.Trim, mAnnotationStyles(intSeriesIndex).FontSize.ToString.Trim)
            SaveSetting(APP_NAME_IN_REGISTRY, "Options", "AnnotationFontColor" & intSeriesIndex.ToString.Trim, mAnnotationStyles(intSeriesIndex).FontColor.ToString.Trim)
        Next intSeriesIndex

    End Sub

    Public Sub RemoveAllAnnotations(Optional ByVal blnConfirmRemoval As Boolean = False)
        Dim eResponse As MsgBoxResult

        If CWGraph.Annotations.Count = 0 Then Exit Sub

        If blnConfirmRemoval Then
            eResponse = MsgBox("Do you really want to remove all the annotations?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "Remove Annotations")
            If eResponse <> MsgBoxResult.Yes Then Exit Sub
        End If

        CWGraph.Annotations.RemoveAll()

        InitializeAnnotationInfoArray()
    End Sub

    Public Sub RemoveAnnotationsForSeries(intSeriesNumber As Short)

        Dim intIndex As Short
        Dim intInfoIndex As Integer

        If CWGraph.Annotations.Count = 0 Then Exit Sub
        If intSeriesNumber < 1 Or intSeriesNumber > CWGraph.Plots.Count Then Exit Sub

        intIndex = 1
        Do While intIndex <= CWGraph.Annotations.Count
            If LookupSeriesNumberForPlotObject((CWGraph.Annotations.Item(intIndex).Plot)) = intSeriesNumber Then
                For intInfoIndex = 1 To CWGraph.Annotations.Count - 1
                    mAnnotations(intInfoIndex) = mAnnotations(intInfoIndex + 1)
                Next intInfoIndex

                CWGraph.Annotations.Remove(intIndex)
            Else
                intIndex = intIndex + 1
            End If
        Loop

        ReDim Preserve mAnnotations(CWGraph.Annotations.Count)

    End Sub

    Private Sub ReportCursorLocation(Optional ByVal intCursorNumber As Integer = 1)

        intCursorNumber = ValidateCursorNumber(intCursorNumber)
        With CWGraph.Cursors.Item(intCursorNumber)
            lblPosition.Text = FormatNumber(.XPosition, mPrecisionX) & ", " & FormatNumber(.YPosition, mPrecisionY)
        End With

    End Sub

    Public Sub ResetOptionsToDefaults(Optional ByVal blnClearAllData As Boolean = False, Optional ByVal blnResetSeriesCount As Boolean = False, Optional ByRef intNewSeriesCount As Short = 2, Optional ByVal eDefaultPlotMode As pmPlotModeConstants = pmPlotModeConstants.pmLines)
        Dim intSeriesIndex As Short

        If blnClearAllData Then
            For intSeriesIndex = 1 To CWGraph.Plots.Count
                RemoveAnnotationsForSeries(intSeriesIndex)
                ClearData(intSeriesIndex)
            Next intSeriesIndex
        End If

        If blnResetSeriesCount Then
            AssureValidSeriesNumber(intNewSeriesCount)
            SetSeriesCount(intNewSeriesCount)
        End If

        SetAnnotationDensityAutoHideCaptions(True)
        SetAnnotationDensityToleranceAutoAdjust(True)
        SetAnnotationFontName(1, DEFAULT_FONT_NAME, True)
        SetAnnotationFontSize(1, DEFAULT_ANNOTATION_FONT_SIZE, True)
        SetAnnotationFontColor(1, Color.Black, True)

        SetAutoAdjustScalingToIncludeCaptions(True)
        SetAutoscaleVisibleY(False, False)

        SetCursorVisible(True, 1)
        SetCursorVisible(False, 2)
        SetCursorSnapMode(False)
        SetCursorPosition(0, 0, 1)
        SetCursorPosition(0, 0, 2)
        SetCursorColor(Color.Black, 1)
        SetCursorColor(Color.DimGray, 2)
        SetDisplayPrecisionX(2)
        SetDisplayPrecisionY(1)

        SetGridLinesXColor(Color.Black, True, True)
        SetGridLinesYColor(Color.Black, True, True)
        SetGridLinesXColor(Color.DimGray, False, True)
        SetGridLinesYColor(Color.DimGray, False, True)

        SetGridLinesXVisible(False, True, True)
        SetGridLinesYVisible(False, True, True)
        SetGridLinesXVisible(False, False, True)
        SetGridLinesYVisible(False, False, True)

        SetLabelFontName(DEFAULT_FONT_NAME)
        SetLabelFontSize(DEFAULT_FONT_SIZE)
        SetLabelFontColor(Color.Black)

        SetLabelSubTitle("")
        SetLabelTitle("")
        SetLabelXAxis("")
        SetLabelYAxis("")

        SetPeakDetectIntensityThresholdCounts(10)
        SetPeakDetectIntensityThresholdPercentageOfMaximum(0)
        SetPeakDetectWidthPointsMinimum(5)

        SetPlotBackgroundColor(Color.White)

        For intSeriesIndex = 1 To CWGraph.Plots.Count
            SetSeriesColor(intSeriesIndex, GetDefaultSeriesColor(intSeriesIndex))
            SetSeriesLineStyle(intSeriesIndex, CWUIControlsLib.CWLineStyles.cwLineSolid)
            SetSeriesLineWidth(intSeriesIndex, 1)
            SetSeriesPlotMode(intSeriesIndex, eDefaultPlotMode)
        Next intSeriesIndex

    End Sub

    Public Function SetAnnotation(blnPromptForText As Boolean, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, Optional ByRef strCaptionText As String = "", Optional ByRef intCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Short = 1, Optional ByRef eAnnotationSnapMode As asmAnnotationSnapModeConstants = asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional ByRef intPointNumberToBind As Integer = -1, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = True, Optional ByRef intAnnotationIndexForce As Integer = 0, Optional ByRef blnAutomaticCaptionPlacement As Boolean = False) As Integer
        ' Adds a new annotation
        '  or updates an existing one of intAnnotationIndexForce is > 0
        ' Returns the index of the annotation (.Annotations is 1-based)
        ' Returns 0 if an annotation is removed or the change is cancelled
        ' Use intAnnotationIndexForce to force editing of an existing annotation

        Dim intAnnotationIndex As Integer
        Dim blnExistingAnnotationFound As Boolean
        Dim blnSuccess As Boolean
        Dim eClickStatus As Windows.Forms.DialogResult

        Dim objFormEditAnnotation As frmEditAnnotation

        Try
            AssureValidSeriesNumber(intSeriesNumber)

            If intAnnotationIndexForce < 1 Or intAnnotationIndexForce > CWGraph.Annotations.Count Then
                ' Round to 7 digits of precision
                CaptionXPos = Val(FormatNumberAsString(CaptionXPos, 15, 7))
                CaptionYPos = Val(FormatNumberAsString(CaptionYPos, 15, 7))
            Else
                intAnnotationIndex = intAnnotationIndexForce
                blnExistingAnnotationFound = True
            End If

            If blnPromptForText Then
                eClickStatus = DialogResult.None
                objFormEditAnnotation = New frmEditAnnotation

                With objFormEditAnnotation
                    .DialogResult = DialogResult.None
                    blnSuccess = .InitializeForm(Me, intAnnotationIndex, CaptionXPos, CaptionYPos, strCaptionText, intCaptionAngle, intSeriesNumber, eAnnotationSnapMode, intPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions)

                    If blnSuccess Then
                        .ShowDialog()
                    End If

                    eClickStatus = .DialogResult
                    If eClickStatus = DialogResult.None Then eClickStatus = DialogResult.Cancel

                    If eClickStatus <> DialogResult.Cancel Then
                        ' Grab the values from frmEditAnnotation
                        .ReturnCurrentSettings(CaptionXPos, CaptionYPos, strCaptionText, intCaptionAngle, intSeriesNumber, eAnnotationSnapMode, intPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions)
                    End If
                End With

                objFormEditAnnotation.Close()
                objFormEditAnnotation = Nothing

                If eClickStatus = DialogResult.Cancel Then
                    Return 0
                End If
            End If

            If Len(strCaptionText) = 0 And blnIncludeArrow Then
                strCaptionText = "."
            End If

            ' We're using .Retry to signify "Remove annotation"
            If eClickStatus = DialogResult.Retry Or Len(strCaptionText) = 0 Then
                If blnExistingAnnotationFound Then RemoveAnnotationByIndex(intAnnotationIndex)
                Return 0
            End If

            With CWGraph
                If Not blnExistingAnnotationFound Then
                    CWGraph.Annotations.Add()
                    intAnnotationIndex = .Annotations.Count

                    ReDim Preserve mAnnotations(.Annotations.Count)
                End If

                SetAnnotationByIndex(intAnnotationIndex, CaptionXPos, CaptionYPos, strCaptionText, intCaptionAngle, intSeriesNumber, eAnnotationSnapMode, intPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, blnAutomaticCaptionPlacement)
            End With

        Catch ex As Exception
            MsgBox("Unable to add annotation: " & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Error")
            intAnnotationIndex = 0
        End Try

        Return intAnnotationIndex

    End Function

    Public Function SetAnnotationByIndex(intAnnotationIndex As Integer, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, Optional ByRef strCaptionText As String = "", Optional ByRef intCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Short = 1, Optional ByRef eAnnotationSnapMode As asmAnnotationSnapModeConstants = asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional ByRef intPointNumberToBind As Integer = -1, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = True, Optional ByRef blnAutomaticCaptionPlacement As Boolean = False, Optional ByRef strReturnAnnotationName As String = "") As Boolean
        ' Returns True if success, false if failure
        ' This function only updates the given annotation's settings and does not display the Set Annotation dialog

        Dim objFont As System.Drawing.Font = System.Windows.Forms.Control.DefaultFont.Clone()
        Dim lngDataCountForSeries As Integer

        Try
            If intAnnotationIndex >= 1 And intAnnotationIndex <= CWGraph.Annotations.Count Then

                AssureValidSeriesNumber(intSeriesNumber)

                lngDataCountForSeries = GetDataCount(intSeriesNumber)

                With CWGraph.Annotations.Item(intAnnotationIndex)
                    .Plot = CWGraph.Plots.Item(intSeriesNumber)
                    .Enabled = True

                    ' Note: if blnAnnotationShowsNearestPointX = True or blnAnnotationShowsNearestPointY = True, then this will get updated on the next call to UpdateDynamicAnnotationCaptions
                    If mAnnotations(intAnnotationIndex).Hidden Then
                        mAnnotations(intAnnotationIndex).CaptionText = strCaptionText
                        mAnnotations(intAnnotationIndex).IncludeArrow = blnIncludeArrow
                    Else
                        .Caption.Text = strCaptionText
                        .Arrow.Visible = blnIncludeArrow
                    End If

                    If blnAutomaticCaptionPlacement Then
                        If .Arrow.Visible Then
                            If CaptionXPos > 0 Then
                                .Caption.XCoordinate = CaptionXPos + mAnnotationDensityToleranceX / 4
                            Else
                                .Caption.XCoordinate = CaptionXPos - mAnnotationDensityToleranceX / 4
                            End If
                        Else
                            .Caption.XCoordinate = CaptionXPos
                        End If

                        If CaptionYPos > 0 Then
                            .Caption.YCoordinate = CaptionYPos + mAnnotationDensityToleranceY / 2
                        Else
                            .Caption.YCoordinate = CaptionYPos - mAnnotationDensityToleranceY / 2
                        End If
                    Else
                        .Caption.XCoordinate = CaptionXPos
                        .Caption.YCoordinate = CaptionYPos
                    End If

                    .Caption.Angle = CDbl(intCaptionAngle)
                    If mAnnotationStyles(intSeriesNumber).FontName = "" Or mAnnotationStyles(intSeriesNumber).FontSize = 0 Then
                        mAnnotationStyles(intSeriesNumber).FontName = DEFAULT_FONT_NAME
                        mAnnotationStyles(intSeriesNumber).FontSize = DEFAULT_ANNOTATION_FONT_SIZE
                        mAnnotationStyles(intSeriesNumber).FontColor = Color.Black
                    End If

                    'objFont = New System.drawing.Font(mAnnotationStyles(intSeriesNumber).FontName, mAnnotationStyles(intSeriesNumber).FontSize)
                    objFont = Microsoft.VisualBasic.Compatibility.VB6.FontChangeName(objFont, mAnnotationStyles(intSeriesNumber).FontName)
                    objFont = Microsoft.VisualBasic.Compatibility.VB6.FontChangeSize(objFont, mAnnotationStyles(intSeriesNumber).FontSize)
                    Try
                        ' This is failing
                        .Caption.Font = objFont
                    Catch ex As Exception
                        ' Ignore the error
                    End Try
                    .Caption.Color = System.Convert.ToUInt32(ColorTranslator.ToOle(mAnnotationStyles(intSeriesNumber).FontColor))
                    .Arrow.Color = .Caption.Color

                    If intPointNumberToBind >= lngDataCountForSeries Then
                        System.Diagnostics.Debug.Assert(False, "")
                        intPointNumberToBind = lngDataCountForSeries - 1
                    End If

                    Select Case eAnnotationSnapMode
                        Case asmAnnotationSnapModeConstants.asmFixedToAnyPoint
                            .SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapPointsOnPlot
                            .PointIndex = intPointNumberToBind
                        Case asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint
                            .SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapAnchoredToPoint
                            .PointIndex = intPointNumberToBind
                        Case Else
                            .SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapFloating
                    End Select

                    .Name = Replace(strCaptionText, " ", "_")
                    strReturnAnnotationName = .Name
                End With

                With mAnnotations(intAnnotationIndex)
                    .ShowsNearestPointX = blnAnnotationShowsNearestPointX
                    .ShowsNearestPointY = blnAnnotationShowsNearestPointY
                    .HideInDenseRegions = blnHideInDenseRegions
                End With
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error occurred in CWGraphControl.SetAnnotationByIndex(): " & Err.Description)
            Return False
        Finally
            objFont = Nothing
        End Try

    End Function

    Public Sub SetAnnotationFontColor(intSeriesNumber As Short, cNewColor As Color, Optional ByVal blnMakeDefaultForAll As Boolean = False)

        AssureValidSeriesNumber(intSeriesNumber)
        If blnMakeDefaultForAll Then intSeriesNumber = 1

        mAnnotationStyles(intSeriesNumber).FontColor = cNewColor
        UpdateAnnotationFonts(intSeriesNumber, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationFontName(intSeriesNumber As Short, strNewFontName As String, Optional ByVal blnMakeDefaultForAll As Boolean = False)
        If Len(strNewFontName) = 0 Then Exit Sub

        AssureValidSeriesNumber(intSeriesNumber)
        If blnMakeDefaultForAll Then intSeriesNumber = 1

        mAnnotationStyles(intSeriesNumber).FontName = strNewFontName
        UpdateAnnotationFonts(intSeriesNumber, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationFontSize(intSeriesNumber As Short, intNewSize As Short, Optional ByVal blnMakeDefaultForAll As Boolean = False)
        If intNewSize < 6 Then intNewSize = DEFAULT_ANNOTATION_FONT_SIZE
        If intNewSize > 128 Then intNewSize = DEFAULT_ANNOTATION_FONT_SIZE

        AssureValidSeriesNumber(intSeriesNumber)
        If blnMakeDefaultForAll Then intSeriesNumber = 1

        mAnnotationStyles(intSeriesNumber).FontSize = intNewSize
        UpdateAnnotationFonts(intSeriesNumber, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationDensityAutoHideCaptions(blnEnableAutoHide As Boolean, Optional ByVal blnShowHiddenCaptionsIfDisabled As Boolean = True)
        Static blnUpdating As Boolean

        If blnUpdating Or Not mControlComponentsInitialized Then Exit Sub
        blnUpdating = True

        mAnnotationDensityAutoHideCaptions = blnEnableAutoHide
        ShowHideAnnotations(False, blnShowHiddenCaptionsIfDisabled)
        SynchronizeCheckboxesWithSettings()

        blnUpdating = False
    End Sub

    Public Sub SetAnnotationDensityToleranceX(dblNewThreshold As Double)
        If dblNewThreshold < 0 Then dblNewThreshold = 0.1

        mAnnotationDensityToleranceX = dblNewThreshold
        If Val(CStr(mAnnotationDensityToleranceX)) <> Val(txtAnnotationDensityToleranceX.Text) Then
            txtAnnotationDensityToleranceX.Text = FormatNumberAsString(mAnnotationDensityToleranceX)
        End If
    End Sub

    Public Sub SetAnnotationDensityToleranceY(dblNewThreshold As Double)
        If dblNewThreshold < 0 Then dblNewThreshold = 0.1

        mAnnotationDensityToleranceY = dblNewThreshold
        If Val(CStr(mAnnotationDensityToleranceY)) <> Val(txtAnnotationDensityToleranceY.Text) Then
            txtAnnotationDensityToleranceY.Text = FormatNumberAsString(mAnnotationDensityToleranceY)
        End If
    End Sub

    Public Sub SetAnnotationDensityToleranceAutoAdjust(blnEnableAutoAdjust As Boolean)
        mAnnotationDensityToleranceAutoAdjust = blnEnableAutoAdjust
        SynchronizeCheckboxesWithSettings()
    End Sub

    Public Sub SetAutoscaleXAxis(blnEnableAutoscale As Boolean)
        CWGraph.Axes.Item(1).AutoScale = blnEnableAutoscale
        If blnEnableAutoscale Then
            AutoScaleXNow()
        End If
    End Sub

    Public Sub SetAutoscaleYAxis(blnEnableAutoscale As Boolean)
        CWGraph.Axes.Item(2).AutoScale = blnEnableAutoscale
        If blnEnableAutoscale Then
            AutoScaleYNow()
        End If
    End Sub

    Public Sub SetAutoAdjustScalingToIncludeCaptions(blnEnable As Boolean)
        mAutoAdjustScalingToIncludeCaptions = blnEnable
        SynchronizeCheckboxesWithSettings()
    End Sub

    Public Sub SetAutoscaleVisibleY(blnEnableAutoscale As Boolean, blnFixMinimumYAtZero As Boolean)
        mAutoScaleVisibleY = blnEnableAutoscale
        mFixMinimumYAtZero = blnFixMinimumYAtZero

        SynchronizeCheckboxesWithSettings()

    End Sub

    Public Sub SetCursorColor(cNewColor As Color, Optional ByVal intCursorNumber As Integer = 1)
        intCursorNumber = ValidateCursorNumber(intCursorNumber)
        CWGraph.Cursors.Item(intCursorNumber).Color = System.Convert.ToUInt32(ColorTranslator.ToOle(cNewColor))
    End Sub

    Public Sub SetCursorPosition(XPos As Double, YPos As Double, Optional ByVal intCursorNumber As Integer = 1)

        intCursorNumber = ValidateCursorNumber(intCursorNumber)
        With CWGraph.Cursors.Item(intCursorNumber)
            .XPosition = XPos
            .YPosition = YPos
        End With

    End Sub

    Public Sub SetCursorSnapMode(blnSnapToData As Boolean)

        Static blnUpdating As Boolean

        If blnUpdating Or Not mControlComponentsInitialized Then Exit Sub

        blnUpdating = True

        chkCursorSnapToData.Checked = blnSnapToData

        With CWGraph.Cursors.Item(1)
            If blnSnapToData Then
                .SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapNearestPoint
            Else
                .SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapFloating
            End If
        End With

        CWGraph.Cursors.Item(2).SnapMode = CWGraph.Cursors.Item(1).SnapMode

        blnUpdating = False

    End Sub

    Public Sub SetCursorVisible(blnShowCursor As Boolean, Optional ByVal intCursorNumber As Integer = 1)
        Static blnUpdating As Boolean

        If blnUpdating Or Not mControlComponentsInitialized Then Exit Sub
        blnUpdating = True

        intCursorNumber = ValidateCursorNumber(intCursorNumber)
        CWGraph.Cursors.Item(intCursorNumber).Visible = blnShowCursor
        SynchronizeCheckboxesWithSettings()

        blnUpdating = False
    End Sub

    Public Sub SetCustomTicksXAxis(dblMajorUnitsBase As Double, dblMajorUnitsInterval As Double, Optional ByVal blnResetToDefaultTicks As Boolean = False)

        If blnResetToDefaultTicks Then
            CWGraph.Axes.Item(1).Ticks.AutoDivisions = True
        Else
            With CWGraph.Axes.Item(1).Ticks
                .AutoDivisions = False
                .MajorDivisions = 0
                .MajorUnitsInterval = dblMajorUnitsInterval
                .MajorUnitsBase = dblMajorUnitsBase
            End With
        End If

    End Sub

    Public Sub SetCustomTicksYAxis(dblMajorUnitsBase As Double, dblMajorUnitsInterval As Double, Optional ByVal blnResetToDefaultTicks As Boolean = False)

        If blnResetToDefaultTicks Then
            CWGraph.Axes.Item(2).Ticks.AutoDivisions = True
        Else
            With CWGraph.Axes.Item(2).Ticks
                .AutoDivisions = False
                .MajorDivisions = 0
                .MajorUnitsInterval = dblMajorUnitsInterval
                .MajorUnitsBase = dblMajorUnitsBase
            End With
        End If

    End Sub

    Public Sub SetDataXvsY(ByRef intSeriesNumber As Short, ByRef XDataZeroBased1DArray() As Double, ByRef YDataZeroBased1DArray() As Double, DataCount As Integer, Optional ByVal strLegendCaption As String = "", Optional ByVal dblOriginalMaximumIntensity As Double = 0)
        Dim DataToPlot2d(,) As Double
        Dim intIndex As Integer

        If DataCount < 1 Then Exit Sub
        AssureValidSeriesNumber(intSeriesNumber)

        ReDim DataToPlot2d(DataCount - 1, 1)

        For intIndex = 0 To DataCount - 1
            DataToPlot2d(intIndex, 0) = XDataZeroBased1DArray(intIndex)
            DataToPlot2d(intIndex, 1) = YDataZeroBased1DArray(intIndex)
        Next intIndex

        CWGraph.Plots.Item(intSeriesNumber).PlotXY(DataToPlot2d, False)
        SetSeriesVisible(intSeriesNumber, True)

        RecordZoomRange(True)

        UpdateDataSavedArray(intSeriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, DataCount)
        UpdateAllDynamicAnnotationCaptions()

        SetSeriesLegendCaption(intSeriesNumber, strLegendCaption)
        SetSeriesOriginalIntensityMaximum(intSeriesNumber, dblOriginalMaximumIntensity)

    End Sub

    Public Sub SetDataYOnly(ByRef intSeriesNumber As Short, ByRef YDataZeroBased1DArray() As Double, YDataCount As Integer, Optional ByVal dblXFirst As Double = 0, Optional ByVal dblIncrement As Double = 1, Optional ByVal strLegendCaption As String = "", Optional ByVal dblOriginalMaximumIntensity As Double = 0)

        ''Dim DataToPlot As Object
        ''Dim intIndex As Integer

        ''If YDataCount < 1 Then Exit Sub
        ''AssureValidSeriesNumber(intSeriesNumber)

        ''ReDim DataToPlot(YDataCount - 1)

        ''For intIndex = 0 To YDataCount - 1
        ''    'UPGRADE_WARNING: Couldn't resolve default property of object DataToPlot(). Click for more: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
        ''    DataToPlot(intIndex) = YDataZeroBased1DArray(intIndex)
        ''Next intIndex

        Dim DataToPlot() As Double
        Dim intIndex As Integer

        If YDataCount < 1 Then Exit Sub
        AssureValidSeriesNumber(intSeriesNumber)

        ReDim DataToPlot(YDataCount - 1)

        For intIndex = 0 To YDataCount - 1
            DataToPlot(intIndex) = YDataZeroBased1DArray(intIndex)
        Next intIndex

        SetSeriesStartAndIncrement(intSeriesNumber, dblXFirst, dblIncrement)
        CWGraph.Plots.Item(intSeriesNumber).PlotY(DataToPlot, dblXFirst, dblIncrement)
        SetSeriesVisible(intSeriesNumber, True)

        RecordZoomRange(True)

        ' Need to generate fake X data for updating mDataSaved()
        Dim XDataZeroBased1DArray() As Double
        ReDim XDataZeroBased1DArray(YDataCount)
        For intIndex = 0 To YDataCount - 1
            XDataZeroBased1DArray(intIndex) = dblXFirst + dblIncrement * intIndex
        Next intIndex

        UpdateDataSavedArray(intSeriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, YDataCount)
        UpdateAllDynamicAnnotationCaptions()

        SetSeriesLegendCaption(intSeriesNumber, strLegendCaption)
        SetSeriesOriginalIntensityMaximum(intSeriesNumber, dblOriginalMaximumIntensity)

    End Sub

    Public Sub SetDisplayPrecisionX(intPrecision As Short)
        mPrecisionX = intPrecision
        UpdateDisplayPrecision()
    End Sub

    Public Sub SetDisplayPrecisionY(intPrecision As Short)
        mPrecisionY = intPrecision
        UpdateDisplayPrecision()
    End Sub

    Private Sub SetFocusToGraph()
        ' Need error handling since the .SetFocus command fails if the form isn't visible
        On Error Resume Next
        CWGraph.Focus()
    End Sub

    Public Sub SetFrameColor(cNewColor As Color)
        CWGraph.GraphFrameColor = cNewColor
    End Sub

    Public Sub SetFrameStyle(blnEnable3D As Boolean)
        If blnEnable3D Then
            CWGraph.GraphFrameStyle = CWUIControlsLib.CWGraphFrameStyles.cwGraphFrame3D
        Else
            CWGraph.GraphFrameStyle = CWUIControlsLib.CWGraphFrameStyles.cwGraphFrameClassic
        End If
    End Sub

    Public Sub SetGridLinesXColor(cNewColor As Color, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False, Optional ByVal blnUpdateTickColors As Boolean = True)

        ' blnMajorGridLines = True means Major Grid Lines
        ' blnMajorGridLines = False means Minor Grid Lines

        Dim intIndex As Short
        Dim uintNewColor As UInt32

        uintNewColor = System.Convert.ToUInt32(ColorTranslator.ToOle(cNewColor))

        If blnApplyToAllAxes Then
            For intIndex = 1 To CWGraph.Axes.Count
                If blnMajorGridLines Then
                    CWGraph.Axes.Item(intIndex).Ticks.MajorGridColor = uintNewColor
                    If blnUpdateTickColors Then CWGraph.Axes.Item(intIndex).Ticks.MajorTickColor = uintNewColor
                Else
                    CWGraph.Axes.Item(intIndex).Ticks.MinorGridColor = uintNewColor
                    If blnUpdateTickColors Then CWGraph.Axes.Item(intIndex).Ticks.MinorTickColor = uintNewColor
                End If
            Next intIndex
        Else
            If blnMajorGridLines Then
                CWGraph.Axes.Item(1).Ticks.MajorGridColor = uintNewColor
                If blnUpdateTickColors Then CWGraph.Axes.Item(1).Ticks.MajorTickColor = uintNewColor
            Else
                CWGraph.Axes.Item(1).Ticks.MinorGridColor = uintNewColor
                If blnUpdateTickColors Then CWGraph.Axes.Item(1).Ticks.MinorTickColor = uintNewColor
            End If
        End If
    End Sub

    Public Sub SetGridLinesYColor(cNewColor As Color, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False, Optional ByVal blnUpdateTickColors As Boolean = True)
        ' blnMajorGridLines = True means Major Grid Lines
        ' blnMajorGridLines = False means Minor Grid Lines

        Dim uintNewColor As UInt32

        If blnApplyToAllAxes Then
            SetGridLinesXColor(cNewColor, blnMajorGridLines, True, blnUpdateTickColors)
        Else
            uintNewColor = System.Convert.ToUInt32(ColorTranslator.ToOle(cNewColor))
            If blnMajorGridLines Then
                CWGraph.Axes.Item(2).Ticks.MajorGridColor = uintNewColor
                If blnUpdateTickColors Then CWGraph.Axes.Item(2).Ticks.MajorTickColor = uintNewColor
            Else
                CWGraph.Axes.Item(2).Ticks.MinorGridColor = uintNewColor
                If blnUpdateTickColors Then CWGraph.Axes.Item(2).Ticks.MinorTickColor = uintNewColor
            End If
        End If
    End Sub

    Public Sub SetGridLinesXVisible(blnShowGridLines As Boolean, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False)
        ' blnMajorGridLines = True means Major Grid Lines
        ' blnMajorGridLines = False means Minor Grid Lines

        Dim intIndex As Short

        If blnApplyToAllAxes Then
            For intIndex = 1 To CWGraph.Axes.Count
                If blnMajorGridLines Then
                    CWGraph.Axes.Item(intIndex).Ticks.MajorGrid = blnShowGridLines
                Else
                    CWGraph.Axes.Item(intIndex).Ticks.MinorGrid = blnShowGridLines
                End If
            Next intIndex
        Else
            If blnMajorGridLines Then
                CWGraph.Axes.Item(1).Ticks.MajorGrid = blnShowGridLines
            Else
                CWGraph.Axes.Item(1).Ticks.MinorGrid = blnShowGridLines
            End If
        End If

    End Sub

    Public Sub SetGridLinesYVisible(blnShowGridLines As Boolean, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False)
        ' blnMajorGridLines = True means Major Grid Lines
        ' blnMajorGridLines = False means Minor Grid Lines

        If blnApplyToAllAxes Then
            SetGridLinesXVisible(blnShowGridLines, blnMajorGridLines, True)
        Else
            If blnMajorGridLines Then
                CWGraph.Axes.Item(2).Ticks.MajorGrid = blnShowGridLines
            Else
                CWGraph.Axes.Item(2).Ticks.MinorGrid = blnShowGridLines
            End If
        End If

    End Sub

    Public Sub SetLabelFontColor(cNewColor As Color)
        Dim uintNewColor As UInt32
        uintNewColor = System.Convert.ToUInt32(ColorTranslator.ToOle(cNewColor))

        CWGraph.CaptionColor = cNewColor
        CWGraph.Axes.Item(1).CaptionColor = uintNewColor
        CWGraph.Axes.Item(2).CaptionColor = uintNewColor

        ' Also upate the Tick-mark labels on both axes
        CWGraph.Axes.Item(1).Labels.Color = uintNewColor
        CWGraph.Axes.Item(2).Labels.Color = uintNewColor
    End Sub

    Public Sub SetLabelFontName(strFontName As String)
        On Error Resume Next

        Dim objFont As System.Drawing.Font = CWGraph.Font.Clone()
        objFont = Microsoft.VisualBasic.Compatibility.VB6.FontChangeName(objFont, strFontName)

        CWGraph.Font = objFont
    End Sub

    Public Sub SetLabelFontSize(intNewSize As Short)
        If intNewSize < 6 Then intNewSize = DEFAULT_FONT_SIZE
        If intNewSize > 128 Then intNewSize = DEFAULT_FONT_SIZE

        Dim objFont As System.Drawing.Font = CWGraph.Font.Clone()
        objFont = Microsoft.VisualBasic.Compatibility.VB6.FontChangeSize(objFont, intNewSize)

        CWGraph.Font = objFont

    End Sub

    Public Sub SetLabelXAxis(strAxisLabel As String)
        CWGraph.Axes.Item(1).Caption = strAxisLabel
    End Sub

    Public Sub SetLabelYAxis(strAxisLabel As String)
        CWGraph.Axes.Item(2).Caption = strAxisLabel
    End Sub

    Public Sub SetLabelTitle(strTitle As String)
        mTitle = strTitle
        If Len(mSubTitle) > 0 Then
            CWGraph.Text = mTitle & " " & mSubTitle
        Else
            CWGraph.Text = mTitle
        End If
    End Sub

    Public Sub SetLabelSubTitle(strSubTitle As String)
        mSubTitle = strSubTitle
        SetLabelTitle(mTitle)
    End Sub

    Public Sub SetPeakDetectIntensityThresholdCounts(dblNewThreshold As Double)
        mPeakDetectIntensityThresholdCounts = dblNewThreshold
    End Sub

    Public Sub SetPeakDetectIntensityThresholdPercentageOfMaximum(lngNewPercentage As Integer)
        mPeakDetectIntensityThresholdPercentageOfMaximum = lngNewPercentage
    End Sub

    Public Sub SetPeakDetectWidthPointsMinimum(lngMinimumWidthInPoints As Integer)
        mPeakDetectWidthPointsMinimum = lngMinimumWidthInPoints
    End Sub

    Public Sub SetPlotBackgroundColor(cNewColor As Color)
        CWGraph.PlotAreaColor = cNewColor
    End Sub

    Public Sub SetRangeX(dblMinimum As Double, dblMaximum As Double, Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnReturnAnnotationVisibilityChecked As Boolean = False)
        With CWGraph.Axes.Item(1)
            .Minimum = dblMinimum
            .Maximum = dblMaximum
        End With
        If blnAddToZoomHistory Then
            RecordZoomRange(False, blnReturnAnnotationVisibilityChecked)
        Else
            UpdateAnnotationDensityTolerances()
            blnReturnAnnotationVisibilityChecked = True
        End If
    End Sub

    Public Sub SetRangeY(dblMinimum As Double, dblMaximum As Double, Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnReturnAnnotationVisibilityChecked As Boolean = False)
        With CWGraph.Axes.Item(2)
            .Minimum = dblMinimum
            .Maximum = dblMaximum
        End With
        If blnAddToZoomHistory Then
            RecordZoomRange(False, blnReturnAnnotationVisibilityChecked)
        Else
            UpdateAnnotationDensityTolerances()
            blnReturnAnnotationVisibilityChecked = True
        End If
    End Sub

    Public Sub SetSeriesBarFillColor(intSeriesNumber As Short, cNewColor As Color)
        AssureValidSeriesNumber(intSeriesNumber)
        CWGraph.Plots.Item(intSeriesNumber).FillColor = System.Convert.ToUInt32(ColorTranslator.ToOle(cNewColor))
    End Sub

    Public Sub SetSeriesColor(intSeriesNumber As Short, cNewColor As Color)
        AssureValidSeriesNumber(intSeriesNumber)

        SetSeriesLineColor(intSeriesNumber, cNewColor)
        SetSeriesLineToBaseColor(intSeriesNumber, cNewColor)
        SetSeriesBarFillColor(intSeriesNumber, cNewColor)
        SetSeriesPointColor(intSeriesNumber, cNewColor)

    End Sub

    Public Sub SetSeriesCount(intCount As Short)
        Dim intSeriesNumber As Short

        If intCount < 1 Then intCount = 1
        If intCount > MAX_SERIES_COUNT Then intCount = MAX_SERIES_COUNT

        Do While intCount < CWGraph.Plots.Count
            CWGraph.Plots.Remove((CWGraph.Plots.Count))
        Loop

        Do While intCount > CWGraph.Plots.Count
            CWGraph.Plots.Add()
        Loop

        For intSeriesNumber = intCount + 1 To mDataSaved.Length - 1
            If mDataSaved(intSeriesNumber).Initialized Then
                ClearData(intSeriesNumber)
            End If
        Next intSeriesNumber
    End Sub

    Public Sub SetSeriesLineColor(intSeriesNumber As Short, cNewColor As Color)
        AssureValidSeriesNumber(intSeriesNumber)
        CWGraph.Plots.Item(intSeriesNumber).LineColor = System.Convert.ToUInt32(ColorTranslator.ToOle(cNewColor))
    End Sub

    Public Sub SetSeriesLineToBaseColor(intSeriesNumber As Short, cNewColor As Color)
        AssureValidSeriesNumber(intSeriesNumber)
        CWGraph.Plots.Item(intSeriesNumber).LineToBaseColor = System.Convert.ToUInt32(ColorTranslator.ToOle(cNewColor))
    End Sub

    Public Sub SetSeriesLineStyle(intSeriesNumber As Short, eLineStyle As CWUIControlsLib.CWLineStyles)
        AssureValidSeriesNumber(intSeriesNumber)

        On Error Resume Next
        CWGraph.Plots.Item(intSeriesNumber).LineStyle = eLineStyle
    End Sub

    Public Sub SetSeriesLineWidth(intSeriesNumber As Short, intWidth As Short)
        AssureValidSeriesNumber(intSeriesNumber)

        If intWidth < 0 Then intWidth = 0
        If intWidth > 5 Then intWidth = 5 ' Note: the maximum for intWidth is hard-coded by 5 by National Instruments

        CWGraph.Plots.Item(intSeriesNumber).LineWidth = intWidth
    End Sub

    Public Sub SetSeriesLegendCaption(intSeriesNumber As Short, strNewCaption As String)
        AssureValidSeriesNumber(intSeriesNumber)
        mDataSaved(intSeriesNumber).LegendCaption = strNewCaption
        UpdateLegend()
    End Sub

    Public Sub SetSeriesPointColor(intSeriesNumber As Short, cNewColor As Color)
        AssureValidSeriesNumber(intSeriesNumber)
        CWGraph.Plots.Item(intSeriesNumber).PointColor = System.Convert.ToUInt32(ColorTranslator.ToOle(cNewColor))
    End Sub

    Public Sub SetSeriesOriginalIntensityMaximum(intSeriesNumber As Short, dblNewOriginalMaximumIntensity As Double)
        AssureValidSeriesNumber(intSeriesNumber)
        mDataSaved(intSeriesNumber).OriginalMaximumIntensity = dblNewOriginalMaximumIntensity
        UpdateLegend()
    End Sub

    Public Sub SetSeriesPlotMode(intSeriesNumber As Short, ePlotMode As pmPlotModeConstants, Optional ByVal blnMakeDefault As Boolean = False)

        Dim intSeriesIndex As Short

        AssureValidSeriesNumber(intSeriesNumber)

        SetSeriesPlotModeWork(CWGraph.Plots.Item(intSeriesNumber), ePlotMode)

        mSeriesPlotMode(intSeriesNumber) = ePlotMode

        If blnMakeDefault Then
            SetSeriesPlotModeWork((CWGraph.PlotTemplate), ePlotMode)

            For intSeriesIndex = 1 To MAX_SERIES_COUNT
                mSeriesPlotMode(intSeriesIndex) = ePlotMode
            Next intSeriesIndex
        End If

    End Sub

    Private Sub SetSeriesPlotModeWork(pltThisPlot As CWUIControlsLib.CWPlot, ePlotMode As pmPlotModeConstants)

        With pltThisPlot
            Select Case ePlotMode
                Case pmPlotModeConstants.pmLines
                    If .LineStyle = CWUIControlsLib.CWLineStyles.cwLineNone Then .LineStyle = CWUIControlsLib.CWLineStyles.cwLineSolid
                    .LineToBase = False
                    .FillToBase = False
                    .PointStyle = CWUIControlsLib.CWPointStyles.cwPointNone
                Case pmPlotModeConstants.pmSticksToZero
                    .LineStyle = CWUIControlsLib.CWLineStyles.cwLineNone
                    .LineToBase = True
                    .FillToBase = False
                    .PointStyle = CWUIControlsLib.CWPointStyles.cwPointNone
                Case pmPlotModeConstants.pmBar
                    .LineStyle = CWUIControlsLib.CWLineStyles.cwLineStepXY
                    .LineToBase = True
                    .FillToBase = True
                    .PointStyle = CWUIControlsLib.CWPointStyles.cwPointNone
                Case pmPlotModeConstants.pmPoints
                    .LineStyle = CWUIControlsLib.CWLineStyles.cwLineNone
                    .LineToBase = False
                    .FillToBase = False
                    If .PointStyle = CWUIControlsLib.CWPointStyles.cwPointNone Then .PointStyle = CWUIControlsLib.CWPointStyles.cwPointSolidSquare
                Case pmPlotModeConstants.pmPointsAndLines
                    If .LineStyle = CWUIControlsLib.CWLineStyles.cwLineNone Then .LineStyle = CWUIControlsLib.CWLineStyles.cwLineSolid
                    .LineToBase = False
                    .FillToBase = False
                    If .PointStyle = CWUIControlsLib.CWPointStyles.cwPointNone Then .PointStyle = CWUIControlsLib.CWPointStyles.cwPointSolidSquare
            End Select
        End With

    End Sub

    Public Sub SetSeriesPointStyle(intSeriesNumber As Short, ePointStyle As CWUIControlsLib.CWPointStyles)
        AssureValidSeriesNumber(intSeriesNumber)

        On Error Resume Next
        CWGraph.Plots.Item(intSeriesNumber).PointStyle = ePointStyle
    End Sub

    Public Sub SetSeriesStartAndIncrement(intSeriesNumber As Short, dblXFirst As Double, dblIncrement As Double)
        AssureValidSeriesNumber(intSeriesNumber)

        With CWGraph.Plots.Item(intSeriesNumber)
            .DefaultxFirst = dblXFirst
            .DefaultxInc = dblIncrement
        End With
    End Sub

    Public Sub SetSeriesVisible(intSeriesNumber As Short, blnShowSeries As Boolean)
        AssureValidSeriesNumber(intSeriesNumber)

        CWGraph.Plots.Item(intSeriesNumber).Visible = blnShowSeries
    End Sub

    Public Sub ShowHideAnnotations(Optional ByVal blnForceOperation As Boolean = False, Optional ByVal blnShowHiddenCaptionsIfDisabled As Boolean = True)
        ' If mAnnotationDensityAutoHideCaptions = True then show or hide
        ' annotations that are too close together (as defined by mAnnotationDensityToleranceX and mAnnotationDensityToleranceY)

        Dim objMouseCursorSaved As System.Windows.Forms.Cursor
        Dim intAnnotationIndex As Integer
        Dim lngIndexCompare As Integer

        Dim lngIndexOfNearestPoint As Integer
        Dim intSeriesNumberOfNearestPoint As Short

        Dim dblMinimumIntensity, dblIntensityCompare As Double
        Dim lngIndexOfMinIntensity As Integer

        Dim lngAnnotationsInToleranceCount, lngHideableAnnotationsCount As Integer
        Dim blnAnnotationVisible() As Boolean

        Dim dblBaseAnnotationXVal, dblBaseAnnotationYVal As Double

        If Not mControlComponentsInitialized Then Exit Sub

        If CWGraph.Annotations.Count <= 0 Then Exit Sub

        If Not mAnnotationDensityAutoHideCaptions And Not blnShowHiddenCaptionsIfDisabled Then
            ' Auto-hide of annotations is disabled, but blnShowHiddenCaptionsIfDisabled = True
            ' Thus, do not update anything (i.e. do not unhide the hidden annotations
            Exit Sub
        End If

        Try
            objMouseCursorSaved = MyBase.Cursor

            MyBase.Cursor = System.Windows.Forms.Cursors.WaitCursor

            ReDim blnAnnotationVisible(CWGraph.Annotations.Count + 1)

            ' Initialize blnAnnotationVisible
            For intAnnotationIndex = 1 To CWGraph.Annotations.Count
                blnAnnotationVisible(intAnnotationIndex) = True
            Next intAnnotationIndex

            If mAnnotationDensityAutoHideCaptions Or blnForceOperation Then
                intAnnotationIndex = 1
                Do While intAnnotationIndex <= CWGraph.Annotations.Count

                    If blnAnnotationVisible(intAnnotationIndex) Then

                        Do
                            lngAnnotationsInToleranceCount = 0
                            lngHideableAnnotationsCount = 0
                            dblMinimumIntensity = HUGE_POS_NUMBER_DOUBLE
                            lngIndexOfMinIntensity = -1

                            dblBaseAnnotationXVal = CWGraph.Annotations.Item(intAnnotationIndex).Caption.XCoordinate
                            dblBaseAnnotationYVal = CWGraph.Annotations.Item(intAnnotationIndex).Caption.YCoordinate

                            ' Find all annotations within dblMinXVal and dblMaxXVal
                            ' Increment lngAnnotationsInToleranceCount for each found
                            ' Find the intensity for each and update lngIndexOfMinIntensity of necessary
                            For lngIndexCompare = 1 To CWGraph.Annotations.Count
                                If blnAnnotationVisible(lngIndexCompare) Then
                                    With CWGraph.Annotations.Item(lngIndexCompare)
                                        If lngIndexCompare = intAnnotationIndex Or ((System.Math.Abs(dblBaseAnnotationXVal - .Caption.XCoordinate) <= mAnnotationDensityToleranceX) And (System.Math.Abs(dblBaseAnnotationYVal - .Caption.YCoordinate) <= mAnnotationDensityToleranceY)) Then
                                            lngAnnotationsInToleranceCount = lngAnnotationsInToleranceCount + 1

                                            If mAnnotations(lngIndexCompare).HideInDenseRegions Then
                                                lngHideableAnnotationsCount = lngHideableAnnotationsCount + 1

                                                ' Determine the intensity of the point bound to the comparison annotation (or the nearest data point, if .SnapMode = FreelyFloating)
                                                If .SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapFloating Then
                                                    lngIndexOfNearestPoint = LookupNearestPointNumber(.Caption.XCoordinate, .Caption.YCoordinate, intSeriesNumberOfNearestPoint, 0, False)
                                                    If lngIndexOfNearestPoint >= 0 And mDataSaved(intSeriesNumberOfNearestPoint).Initialized Then
                                                        dblIntensityCompare = mDataSaved(intSeriesNumberOfNearestPoint).YVals(lngIndexOfNearestPoint)
                                                    Else
                                                        dblIntensityCompare = 0
                                                    End If
                                                Else
                                                    intSeriesNumberOfNearestPoint = LookupSeriesNumberForPlotObject(.Plot)
                                                    If .PointIndex >= 0 And mDataSaved(intSeriesNumberOfNearestPoint).Initialized Then
                                                        dblIntensityCompare = mDataSaved(intSeriesNumberOfNearestPoint).YVals(.PointIndex)
                                                    Else
                                                        dblIntensityCompare = 0
                                                    End If
                                                End If

                                                If dblIntensityCompare < dblMinimumIntensity Then
                                                    dblMinimumIntensity = dblIntensityCompare
                                                    lngIndexOfMinIntensity = lngIndexCompare
                                                End If
                                            End If
                                        End If
                                    End With
                                End If
                            Next lngIndexCompare

                            If lngAnnotationsInToleranceCount > 1 Then
                                If lngIndexOfMinIntensity < 0 Then
                                    ' No hideable annotations found; don't change anything
                                Else
                                    blnAnnotationVisible(lngIndexOfMinIntensity) = False
                                End If
                            End If

                        Loop While lngHideableAnnotationsCount > 1 And blnAnnotationVisible(intAnnotationIndex)

                    End If

                    intAnnotationIndex = intAnnotationIndex + 1
                Loop
            End If

            ' Show/hide the annotations
            For intAnnotationIndex = 1 To CWGraph.Annotations.Count
                If blnAnnotationVisible(intAnnotationIndex) And mAnnotations(intAnnotationIndex).Hidden Then
                    ' Annotation was just un-hidden; update the caption
                    CWGraph.Annotations.Item(intAnnotationIndex).Caption.Text = mAnnotations(intAnnotationIndex).CaptionText
                    CWGraph.Annotations.Item(intAnnotationIndex).Arrow.Visible = mAnnotations(intAnnotationIndex).IncludeArrow
                ElseIf Not blnAnnotationVisible(intAnnotationIndex) And Not mAnnotations(intAnnotationIndex).Hidden Then
                    mAnnotations(intAnnotationIndex).CaptionText = CWGraph.Annotations.Item(intAnnotationIndex).Caption.Text
                    mAnnotations(intAnnotationIndex).IncludeArrow = CWGraph.Annotations.Item(intAnnotationIndex).Arrow.Visible
                    CWGraph.Annotations.Item(intAnnotationIndex).Caption.Text = ""
                    CWGraph.Annotations.Item(intAnnotationIndex).Arrow.Visible = False
                End If
                mAnnotations(intAnnotationIndex).Hidden = Not blnAnnotationVisible(intAnnotationIndex)
            Next intAnnotationIndex

            MyBase.Cursor = objMouseCursorSaved

        Catch ex As Exception
            MsgBox("Error in CWGraphControl.ShowHideAnnotations(): " & vbCrLf & ex.Message, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            MyBase.Cursor = objMouseCursorSaved

        End Try
    End Sub

    Public Sub ShowHideControls(blnHideControlsFrame As Boolean)
        mControlsFrameHidden = blnHideControlsFrame

        cmdRollUpHide.Visible = Not mControlsFrameHidden
        cmdRollUpShow.Visible = mControlsFrameHidden

        PositionControls()

    End Sub

    Private Sub SynchronizeCheckboxesWithSettings()
        ' Makes sure that each of the checkboxes and textboxes agrees with its corresponding internal setting

        Static blnUpdating As Boolean

        If blnUpdating Or Not mControlComponentsInitialized Then Exit Sub

        blnUpdating = True

        chkAutoScaleVisibleY.Checked = mAutoScaleVisibleY
        chkFixMinimumYAtZero.Checked = mFixMinimumYAtZero
        chkAutoAdjustScalingToIncludeAnnotationCaptions.Checked = mAutoAdjustScalingToIncludeCaptions
        chkShowCursor1.Checked = GetCursorVisibility(1)
        chkShowCursor2.Checked = GetCursorVisibility(2)
        chkAnnotationDensityToleranceAutoAdjust.Checked = mAnnotationDensityToleranceAutoAdjust
        chkAnnotationAutoHideCaptions.Checked = mAnnotationDensityAutoHideCaptions

        blnUpdating = False

    End Sub

    Private Sub ToggleOptionsFrameVisibility(Optional ByVal blnForceHide As Boolean = False)
        If blnForceHide Then
            fraOptionsShadow.Visible = False
        Else
            fraOptionsShadow.Visible = Not fraOptionsShadow.Visible
        End If

        ' Need on error resume next in case form is hidden

        On Error Resume Next
        If fraOptionsShadow.Visible Then
            txtPrecisionX.Focus()
        Else
            CWGraph.Focus()
        End If


    End Sub

    Private Sub ToggleTemporaryMouseMode(blnEnable As Boolean, Optional ByVal eModeToEnable As cmZoomBoxCursorModeConstants = cmZoomBoxCursorModeConstants.cmZoomX)
        If blnEnable Then
            If Not mMouseModeTemp Then
                ' Turn on temporary cursor mode
                mMouseModeTemp = True
                mMouseModeSave = cboMouseAction.SelectedIndex
                cboMouseAction.SelectedIndex = eModeToEnable
            End If
        Else
            mMouseModeTemp = False
            If cboMouseAction.SelectedIndex = cmZoomBoxCursorModeConstants.cmMoveAnnotations Then ShowHideAnnotations()
            cboMouseAction.SelectedIndex = mMouseModeSave
            EnableTrackModeAllEvents()
        End If
    End Sub

    Public Sub UpdateAllDynamicAnnotationCaptions()
        UpdateDynamicAnnotationCaptions()
    End Sub

    Private Sub UpdateAnnotationFonts(intSeriesNumber As Short, Optional ByVal blnMakeDefaultForAll As Boolean = False)
        ' Updates the font, size, and color of all of the annotations for a given series
        ' To all update all series, use intSeriesNumber <= 0

        Dim intIndex As Integer
        Dim intAnnotationSeriesNumber As Short
        Dim objFont As System.Drawing.Font = System.Windows.Forms.Control.DefaultFont.Clone()

        On Error Resume Next

        If blnMakeDefaultForAll Then
            For intAnnotationSeriesNumber = 1 To MAX_SERIES_COUNT
                mAnnotationStyles(intAnnotationSeriesNumber) = mAnnotationStyles(intSeriesNumber)
            Next intAnnotationSeriesNumber
        End If

        ' Make sure each of the annotations has the correct size and font
        For intIndex = 1 To CWGraph.Annotations.Count
            With CWGraph.Annotations.Item(intIndex)
                intAnnotationSeriesNumber = LookupSeriesNumberForPlotObject(.Plot)

                If intAnnotationSeriesNumber = intSeriesNumber Or intSeriesNumber <= 0 Then
                    objFont = Microsoft.VisualBasic.Compatibility.VB6.FontChangeName(objFont, mAnnotationStyles(intAnnotationSeriesNumber).FontName)
                    objFont = Microsoft.VisualBasic.Compatibility.VB6.FontChangeSize(objFont, mAnnotationStyles(intAnnotationSeriesNumber).FontSize)
                    .Caption.Font = objFont
                    .Caption.Color = System.Convert.ToUInt32(ColorTranslator.ToOle(mAnnotationStyles(intSeriesNumber).FontColor))
                    .Arrow.Color = .Caption.Color
                End If
            End With

        Next intIndex

        objFont = Nothing

    End Sub

    Private Sub UpdateAnnotationDensityTolerances()

        Const DEFAULT_DIVISION_COUNT As Short = 15
        Const STANDARD_CONTROL_WIDTH As Short = 533       ' Pixels
        Const STANDARD_CONTROL_HEIGHT As Short = 266      ' Pixels

        Dim dblXTolerance, dblYTolerance As Double

        On Error GoTo UpdateAnnotationDensityTolerancesErrorHandler

        If Not mControlComponentsInitialized Then Exit Sub

        If mAnnotationDensityToleranceAutoAdjust Then

            dblXTolerance = GetRangeX() / DEFAULT_DIVISION_COUNT
            dblYTolerance = GetRangeY() / DEFAULT_DIVISION_COUNT

            If CWGraph.Width > 0 Then
                dblXTolerance = dblXTolerance * STANDARD_CONTROL_WIDTH / CWGraph.Width
            End If
            If CWGraph.Height > 0 Then
                dblYTolerance = dblYTolerance * STANDARD_CONTROL_HEIGHT / CWGraph.Height
            End If

            SetAnnotationDensityToleranceX(dblXTolerance)
            SetAnnotationDensityToleranceY(dblYTolerance)
        End If

        ShowHideAnnotations()

        Exit Sub

UpdateAnnotationDensityTolerancesErrorHandler:
        MsgBox("Error in CWGraphControl.UpdateAnnotationDensityTolerances: " & vbCrLf & Err.Description, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

    End Sub

    Private Sub UpdateDisplayPrecision()
        ' This sub updates the precision of the labels on the X and Y axes
        ' If date mode is enabled, then it updates the X axis format string to display dates

        Dim strFormatString As String
        Dim strFormatStringZeroes As String

        If Not mControlComponentsInitialized Then Exit Sub

        If chkXAxisDateMode.Checked Then
            If chkXAxisDateModeShowTime.Checked Then
                strFormatString = "mm/dd/yyyy hh:nn"
            Else
                strFormatString = "mm/dd/yyyy"
            End If
        Else
            If mPrecisionX < 0 Or mPrecisionX > 10 Then mPrecisionX = 3
            If mPrecisionX > 0 Then
                strFormatStringZeroes = "." & New String("0", mPrecisionX)
            Else
                strFormatStringZeroes = ""
            End If
            strFormatString = "#0" & strFormatStringZeroes
        End If
        CWGraph.Axes.Item(1).FormatString = strFormatString


        If Val(txtPrecisionX.Text) <> mPrecisionX Then
            txtPrecisionX.Text = mPrecisionX.ToString.Trim
        End If

        If mPrecisionY < 0 Or mPrecisionY > 10 Then mPrecisionY = 3
        If mPrecisionY > 0 Then
            strFormatStringZeroes = "." & New String("0", mPrecisionY)
        Else
            strFormatStringZeroes = ""
        End If
        CWGraph.Axes.Item(2).FormatString = "#0" & strFormatStringZeroes

        If Val(txtPrecisionY.Text) <> mPrecisionY Then
            txtPrecisionY.Text = mPrecisionY.ToString.Trim
        End If

        ReportCursorLocation()
        PositionControls()

    End Sub

    Private Sub UpdateDynamicAnnotationCaptions(Optional ByVal lngIndividualAnnotationIndexToUpdate As Integer = 0)
        Dim lngStartIndex, lngEndIndex As Integer
        Dim intIndex As Integer
        Dim intSeriesNumber As Short
        Dim blnBindToNearest As Boolean
        Dim strNewCaption As String

        If lngIndividualAnnotationIndexToUpdate >= 1 And lngIndividualAnnotationIndexToUpdate <= CWGraph.Annotations.Count Then
            lngStartIndex = lngIndividualAnnotationIndexToUpdate
            lngEndIndex = lngIndividualAnnotationIndexToUpdate
        Else
            lngStartIndex = 1
            lngEndIndex = CWGraph.Annotations.Count
        End If

        For intIndex = lngStartIndex To lngEndIndex
            If mAnnotations(intIndex).ShowsNearestPointX Or mAnnotations(intIndex).ShowsNearestPointY Then
                With CWGraph.Annotations.Item(intIndex)
                    If .SnapMode = CWUIControlsLib.CWCursorSnapModes.cwCSnapFloating Then
                        blnBindToNearest = False
                    Else
                        blnBindToNearest = True
                    End If

                    intSeriesNumber = LookupSeriesNumberForPlotObject(.Plot)

                    strNewCaption = GenerateAnnotationUsingNearestPoint(.Caption.XCoordinate, .Caption.YCoordinate, intSeriesNumber, mAnnotations(intIndex).ShowsNearestPointX, mAnnotations(intIndex).ShowsNearestPointY, blnBindToNearest, LookupCaptionForAnnotation(intIndex), .PointIndex)
                    If mAnnotations(intIndex).Hidden Then
                        mAnnotations(intIndex).CaptionText = strNewCaption
                    Else
                        .Caption.Text = strNewCaption
                    End If

                End With
            End If
        Next intIndex

    End Sub

    Private Sub UpdateDataSavedArray(intSeriesNumber As Short, ByRef XDataZeroBased1DArray() As Double, ByRef YDataZeroBased1DArray() As Double, DataCount As Integer)

        ' Update the saved data range
        ' This procedure assumes that the data is in increasing x order, though not necessarily evenly spaced
        If intSeriesNumber > MAX_SERIES_COUNT Then Exit Sub

        With mDataSaved(intSeriesNumber)
            .DataCount = DataCount
            If .DataCount > 0 Then
                ReDim .XVals(.DataCount - 1)
                ReDim .YVals(.DataCount - 1)

                Array.Copy(XDataZeroBased1DArray, .XVals, DataCount)
                Array.Copy(YDataZeroBased1DArray, .YVals, DataCount)

                .Initialized = True
            Else
                ReDim .XVals(-1)
                ReDim .YVals(-1)

                .DataCount = 0
                .Initialized = False
            End If

        End With

    End Sub

    Private Sub UpdateLegend()

        Dim intSeriesIndex As Short
        Dim intLegendIndex As Short

        Dim objLegendColor As System.Windows.Forms.Label
        Dim objLegendCaption As System.Windows.Forms.Label
        Dim objOriginalMaximumIntensity As System.Windows.Forms.Label

        intLegendIndex = 1
        objLegendColor = linLegendSeriesColor1
        objLegendCaption = lblLegendCaption1
        objOriginalMaximumIntensity = lblOriginalMaximumIntensity1

        For intSeriesIndex = 1 To MAX_SERIES_COUNT
            If mDataSaved(intSeriesIndex).Initialized Then
                Select Case mSeriesPlotMode(intSeriesIndex)
                    Case pmPlotModeConstants.pmBar
                        objLegendColor.BackColor = ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Plots.Item(intSeriesIndex).FillColor))
                    Case pmPlotModeConstants.pmPoints
                        objLegendColor.BackColor = ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Plots.Item(intSeriesIndex).PointColor))
                    Case pmPlotModeConstants.pmSticksToZero
                        objLegendColor.BackColor = ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Plots.Item(intSeriesIndex).LineToBaseColor))
                    Case Else
                        objLegendColor.BackColor = ColorTranslator.FromOle(System.Convert.ToInt32(CWGraph.Plots.Item(intSeriesIndex).LineColor))
                End Select
                objLegendColor.Visible = True
                objLegendCaption.AutoSize = True

                With mDataSaved(intSeriesIndex)
                    If Len(.LegendCaption) > 0 Then
                        objLegendCaption.Text = intSeriesIndex.ToString.Trim & ": " & .LegendCaption
                    Else
                        objLegendCaption.Text = "Series " & intSeriesIndex.ToString.Trim
                    End If

                    If .OriginalMaximumIntensity > 0 Then
                        objOriginalMaximumIntensity.Text = "Original Max Intensity: " & FormatNumberAsString(.OriginalMaximumIntensity, 8, 4)
                    Else
                        objOriginalMaximumIntensity.Text = ""
                    End If
                End With

                intLegendIndex += 1
                If intLegendIndex = 2 Then
                    objLegendColor = linLegendSeriesColor2
                    objLegendCaption = lblLegendCaption2
                    objOriginalMaximumIntensity = lblOriginalMaximumIntensity2
                Else
                    Exit For
                End If
            End If
        Next intSeriesIndex

        ' Clear the legend entries for series not present
        If intLegendIndex <= 1 Then
            linLegendSeriesColor1.Visible = False
            lblLegendCaption1.Text = ""
            lblOriginalMaximumIntensity1.Text = ""
        End If

        If intLegendIndex <= 2 Then
            linLegendSeriesColor2.Visible = False
            lblLegendCaption2.Text = ""
            lblOriginalMaximumIntensity2.Text = ""
        End If


    End Sub

    Private Function ValidateCursorNumber(intCursorNumber As Integer) As Integer
        If intCursorNumber >= 1 And intCursorNumber <= CWGraph.Cursors.Count Then
            Return intCursorNumber
        Else
            Return 1
        End If
    End Function

    Private Function WithinTolerance(ThisNumber As Double, CompareNumber As Double, ThisTolerance As Double) As Boolean
        If ThisNumber <= CompareNumber + ThisTolerance And ThisNumber >= CompareNumber - ThisTolerance Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ZoomOutFull(Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnAllowFixMinimumYAtZero As Boolean = True)

        Dim blnAutoHideCaptionsSaved As Boolean

        CWGraph.Axes.Item(1).AutoScaleNow()
        CWGraph.Axes.Item(2).AutoScaleNow()

        blnAutoHideCaptionsSaved = GetAnnotationDensityAutoHideCaptions()
        If blnAutoHideCaptionsSaved Then SetAnnotationDensityAutoHideCaptions(False, False)

        If blnAllowFixMinimumYAtZero And mAutoScaleVisibleY And mFixMinimumYAtZero Then
            CWGraph.Axes.Item(2).Minimum = 0
        End If

        UpdateAnnotationDensityTolerances()
        AdjustScalingToIncludeAnnotationCaptions()

        If blnAddToZoomHistory Then
            RecordZoomRange(True)
        End If

        ' Auto-hiding of captions was disabled above; re-enable if necessary
        SetAnnotationDensityAutoHideCaptions(blnAutoHideCaptionsSaved)

    End Sub

    Public Sub ZoomToPrevious()
        Dim blnProceed As Boolean
        Dim intIndex As Short

        ' Make sure the most recent zoom range isn't all zeroes

        blnProceed = True
        With ZoomHistory(1)
            If .XMinimum = 0 And .XMaximum = 0 And .YMinimum = 0 And .YMaximum = 0 Then
                blnProceed = False
            End If
        End With

        If Not blnProceed Then Exit Sub

        ' Add the current range to the 0th position
        With ZoomHistory(1)
            CWGraph.Axes.Item(1).Minimum = .XMinimum
            CWGraph.Axes.Item(1).Maximum = .XMaximum
            CWGraph.Axes.Item(2).Minimum = .YMinimum
            CWGraph.Axes.Item(2).Maximum = .YMaximum
        End With
        CWGraph.Refresh()

        ' Shift the history values down by one
        For intIndex = 0 To MAX_HISTORY_COUNT - 2
            ZoomHistory(intIndex) = ZoomHistory(intIndex + 1)
        Next intIndex

        UpdateAnnotationDensityTolerances()
    End Sub

    Private Sub cboMouseAction_SelectedIndexChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles cboMouseAction.SelectedIndexChanged
        ComboBoxSetAction()
        SetFocusToGraph()
    End Sub

    Private Sub chkAnnotationAutoHideCaptions_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkAnnotationAutoHideCaptions.CheckedChanged
        SetAnnotationDensityAutoHideCaptions(chkAnnotationAutoHideCaptions.Checked)
        SetFocusToGraph()
    End Sub

    Private Sub chkAnnotationDensityToleranceAutoAdjust_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkAnnotationDensityToleranceAutoAdjust.CheckedChanged
        SetAnnotationDensityToleranceAutoAdjust(chkAnnotationDensityToleranceAutoAdjust.Checked)
        SetFocusToGraph()
    End Sub

    Private Sub chkAutoAdjustScalingToIncludeAnnotationCaptions_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkAutoAdjustScalingToIncludeAnnotationCaptions.CheckedChanged
        SetAutoAdjustScalingToIncludeCaptions(chkAutoAdjustScalingToIncludeAnnotationCaptions.Checked)
        SetFocusToGraph()
    End Sub

    Private Sub chkAutoScaleVisibleY_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkAutoScaleVisibleY.CheckedChanged
        SetAutoscaleVisibleY(chkAutoScaleVisibleY.Checked, chkFixMinimumYAtZero.Checked)
        EnableDisableDynamicControls()
        SetFocusToGraph()
    End Sub

    Private Sub chkCursorSnapToData_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkCursorSnapToData.CheckedChanged
        SetCursorSnapMode(chkCursorSnapToData.Checked)
        SetFocusToGraph()
    End Sub

    Private Sub chkFixMinimumYAtZero_CheckedChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles chkFixMinimumYAtZero.CheckedChanged
        SetAutoscaleVisibleY(chkAutoScaleVisibleY.Checked, chkFixMinimumYAtZero.Checked)
        SetFocusToGraph()
    End Sub

    Private Sub chkShowCursor1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowCursor1.CheckedChanged
        SetCursorVisible(chkShowCursor1.Checked, 1)
        SetFocusToGraph()
    End Sub

    Private Sub chkShowCursor2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowCursor2.CheckedChanged
        SetCursorVisible(chkShowCursor2.Checked, 2)
        SetFocusToGraph()
    End Sub

    Private Sub chkXAxisDateMode_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkXAxisDateMode.CheckedChanged
        EnableDisableDynamicControls()
        UpdateDisplayPrecision()
    End Sub

    Private Sub chkXAxisDateModeShowTime_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkXAxisDateModeShowTime.CheckedChanged
        UpdateDisplayPrecision()
    End Sub

    Private Sub cmdCenterCursors_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdCenterCursors.Click
        CenterCursor(1, True)
        SetFocusToGraph()
    End Sub

    Private Sub cmdMove_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdMove.Click
        MoveOptionsFrame()
    End Sub

    Private Sub cmdOptions_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdOptionsHide.Click, cmdOptionsToggle.Click
        ToggleOptionsFrameVisibility()
    End Sub

    Private Sub cmdRollUpHide_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdRollUpHide.Click
        ShowHideControls(True)
    End Sub

    Private Sub cmdRollUpShow_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdRollUpShow.Click
        ShowHideControls(False)
    End Sub

    Private Sub cmdZoomOut_Click(eventSender As System.Object, eventArgs As System.EventArgs) Handles cmdZoomOut.Click
        ZoomOutFull()
        SetFocusToGraph()
    End Sub

    Private Sub CWGraph_AnnotationMouseDown(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_AnnotationMouseDownEvent) Handles CWGraph.AnnotationMouseDown
        ' This event will never fire since CWGraph_MouseDown disables .TrackMode = cwGTrackAllEvents
        '  in order to allow proper zooming to occur
    End Sub

    Private Sub CWGraph_AnnotationMouseMove(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_AnnotationMouseMoveEvent) Handles CWGraph.AnnotationMouseMove
        ' This code gets called when the mouse is moved over an annotation, regardless of whether or not a button is pushed
        With mLastMouseLocInfo
            .XPos = eventArgs.xPos
            .YPos = eventArgs.yPos
            .MouseLoc = clClickLocationConstants.clAnnotation
            .AnnotationNumber = eventArgs.annotationIndex + 1
        End With

        DisplayPosition(eventArgs.xPos, eventArgs.yPos)

        If cboMouseAction.SelectedIndex = cmZoomBoxCursorModeConstants.cmMoveAnnotations Then
            UpdateDynamicAnnotationCaptions(eventArgs.annotationIndex + 1)
        End If

    End Sub

    Private Sub CWGraph_CursorChange(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_CursorChangeEvent) Handles CWGraph.CursorChange
        ReportCursorLocation(1)
    End Sub

    Private Sub CWGraph_CursorMouseDown(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_CursorMouseDownEvent) Handles CWGraph.CursorMouseDown
        ' This event will never fire since CWGraph_MouseDown disables .TrackMode = cwGTrackAllEvents
        '  in order to allow proper zooming to occur
    End Sub

    Private Sub CWGraph_CursorMouseMove(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_CursorMouseMoveEvent) Handles CWGraph.CursorMouseMove
        ' This code gets called when the mouse moves over a cursor
        With mLastMouseLocInfo
            .XPos = eventArgs.xPos
            .YPos = eventArgs.yPos
            .MouseLoc = clClickLocationConstants.clCursor
            .CursorIndex = eventArgs.cursorIndex
        End With
    End Sub

    Private Sub CWGraph_DblClick(eventSender As System.Object, eventArgs As System.EventArgs) Handles CWGraph.DblClick
        If mLastMouseLocInfo.MouseButton = mbMouseButtonConstants.LeftButton Then
            If mLastMouseLocInfo.MouseLoc = clClickLocationConstants.clAnnotation And mLastMouseLocInfo.AnnotationNumber > 0 Then
                ' Edit the given annotation
                AddOrUpdateAnnotationAtMouseLocation(mLastMouseLocInfo.AnnotationNumber)
            Else
                ' Add a new annotation
                AddOrUpdateAnnotationAtMouseLocation(0)
            End If
        End If
    End Sub

    Private Sub CWGraph_MouseDownEvent(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_MouseDownEvent) Handles CWGraph.MouseDownEvent
        mLastMouseLocInfo.MouseButton = eventArgs.button
        ComboBoxSetAction()
    End Sub

    Private Sub CWGraph_MouseUpEvent(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_MouseUpEvent) Handles CWGraph.MouseUpEvent
        If eventArgs.button = mbMouseButtonConstants.LeftButton And cboMouseAction.SelectedIndex <= cmZoomBoxCursorModeConstants.cmZoomY Then
            ' Record new zoom settings
            RecordZoomRange(False)
        ElseIf eventArgs.button = mbMouseButtonConstants.RightButton Then
            ' Zoom out to previous
            ZoomToPrevious()
        End If

        If cboMouseAction.SelectedIndex = cmZoomBoxCursorModeConstants.cmMoveAnnotations Then ShowHideAnnotations()
        EnableTrackModeAllEvents()
    End Sub

    Private Sub CWGraph_PlotAreaMouseDown(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_PlotAreaMouseDownEvent) Handles CWGraph.PlotAreaMouseDown
        ' This event will never fire since CWGraph_MouseDown disables .TrackMode = cwGTrackAllEvents
        '  in order to allow proper zooming to occur
    End Sub

    Private Sub CWGraph_PlotAreaMouseMove(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_PlotAreaMouseMoveEvent) Handles CWGraph.PlotAreaMouseMove
        ' This code gets called when the mouse is moved on the plot area (i.e. in between plots and annotations)
        With mLastMouseLocInfo
            .XPos = eventArgs.xPos
            .YPos = eventArgs.yPos
            .MouseLoc = clClickLocationConstants.clPlotArea
        End With
        DisplayPosition(eventArgs.xPos, eventArgs.yPos)

    End Sub

    Private Sub CWGraph_PlotMouseDown(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_PlotMouseDownEvent) Handles CWGraph.PlotMouseDown
        ' This event will never fire since CWGraph_MouseDown disables .TrackMode = cwGTrackAllEvents
        '  in order to allow proper zooming to occur
    End Sub

    Private Sub CWGraph_PlotMouseMove(eventSender As System.Object, eventArgs As AxCWUIControlsLib._DCWGraphEvents_PlotMouseMoveEvent) Handles CWGraph.PlotMouseMove
        ' This code returns the value of the nearest data point, but only gets updated when the user is moving over a given plot's data (line or data point)
        ' Thus, the lblPosition control also gets updated by _PlotAreaMouseMove()
        With mLastMouseLocInfo
            .XPos = CDbl(eventArgs.xData)
            .YPos = CDbl(eventArgs.yData)
            .MouseLoc = clClickLocationConstants.clPlotSeries
            .SeriesIndex = eventArgs.plotIndex
        End With

        DisplayPosition(eventArgs.xData, eventArgs.yData)
    End Sub

    Private Sub txtAnnotationDensityToleranceX_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtAnnotationDensityToleranceX.TextChanged
        SetAnnotationDensityToleranceX(Val(txtAnnotationDensityToleranceX.Text))
    End Sub

    Private Sub txtAnnotationDensityToleranceX_KeyDown(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtAnnotationDensityToleranceX.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then ToggleOptionsFrameVisibility(True)
    End Sub

    Private Sub txtAnnotationDensityToleranceX_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtAnnotationDensityToleranceX.KeyPress
        TextBoxUtils.TextBoxKeyPressHandler(txtAnnotationDensityToleranceX, eventArgs, True, True)
    End Sub

    Private Sub txtAnnotationDensityToleranceX_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtAnnotationDensityToleranceX.Leave
        If Not IsNumeric(txtAnnotationDensityToleranceX.Text) Then
            txtAnnotationDensityToleranceX.Text = "0.5"
        End If
    End Sub

    Private Sub txtAnnotationDensityToleranceY_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtAnnotationDensityToleranceY.TextChanged
        SetAnnotationDensityToleranceY(Val(txtAnnotationDensityToleranceY.Text))
    End Sub

    Private Sub txtAnnotationDensityToleranceY_KeyDown(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtAnnotationDensityToleranceY.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then ToggleOptionsFrameVisibility(True)
    End Sub

    Private Sub txtAnnotationDensityToleranceY_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtAnnotationDensityToleranceY.KeyPress
        TextBoxUtils.TextBoxKeyPressHandler(txtAnnotationDensityToleranceY, eventArgs, True, True)
    End Sub

    Private Sub txtAnnotationDensityToleranceY_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtAnnotationDensityToleranceY.Leave
        If Not IsNumeric(txtAnnotationDensityToleranceY.Text) Then
            txtAnnotationDensityToleranceY.Text = "0.5"
        End If
    End Sub

    Private Sub txtPrecisionX_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPrecisionX.TextChanged
        SetDisplayPrecisionX(Val(txtPrecisionX.Text))
    End Sub

    Private Sub txtPrecisionX_KeyDown(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPrecisionX.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then ToggleOptionsFrameVisibility(True)
    End Sub

    Private Sub txtPrecisionX_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecisionX.KeyPress
        TextBoxUtils.TextBoxKeyPressHandler(txtPrecisionX, eventArgs, True, False)
    End Sub

    Private Sub txtPrecisionX_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPrecisionX.Leave
        If Not IsNumeric(txtPrecisionX.Text) Then
            txtPrecisionX.Text = "3"
        End If
    End Sub

    Private Sub txtPrecisionY_TextChanged(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPrecisionY.TextChanged
        SetDisplayPrecisionY(Val(txtPrecisionY.Text))
    End Sub

    Private Sub txtPrecisionY_KeyDown(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPrecisionY.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then ToggleOptionsFrameVisibility(True)
    End Sub

    Private Sub txtPrecisionY_KeyPress(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecisionY.KeyPress
        TextBoxUtils.TextBoxKeyPressHandler(txtPrecisionY, eventArgs, True, False)
    End Sub

    Private Sub txtPrecisionY_Leave(eventSender As System.Object, eventArgs As System.EventArgs) Handles txtPrecisionY.Leave
        If Not IsNumeric(txtPrecisionY.Text) Then
            txtPrecisionY.Text = "3"
        End If
    End Sub

    Private Sub CWGraphControl_KeyDown(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.A And (Shift = 2) Then
            ' User pressed Ctrl+A, zoom out full
            ZoomOutFull()
        ElseIf Shift = 0 Then
            Select Case KeyCode
                Case System.Windows.Forms.Keys.C
                    ToggleTemporaryMouseMode(True, cmZoomBoxCursorModeConstants.cmCursor)
                Case System.Windows.Forms.Keys.A
                    ToggleTemporaryMouseMode(True, cmZoomBoxCursorModeConstants.cmMoveAnnotations)
                Case System.Windows.Forms.Keys.P
                    ToggleTemporaryMouseMode(True, cmZoomBoxCursorModeConstants.cmPanAll)
                Case System.Windows.Forms.Keys.Z
                    ToggleTemporaryMouseMode(True, cmZoomBoxCursorModeConstants.cmZoomBox)
            End Select
        End If
    End Sub

    Private Sub CWGraphControl_KeyUp(eventSender As System.Object, eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If mMouseModeTemp Then
            Select Case KeyCode
                Case System.Windows.Forms.Keys.C, System.Windows.Forms.Keys.A, System.Windows.Forms.Keys.P, System.Windows.Forms.Keys.Z
                    ToggleTemporaryMouseMode(False)
            End Select
        End If
    End Sub

    Private Sub CWGraphControl_Resize(eventSender As System.Object, eventArgs As System.EventArgs) Handles MyBase.Resize
        PositionControls()
    End Sub

    Private Sub UserControl_Terminate()
        ' Attempt to save the current settings to the Registry
        RegistrySaveSettings()
    End Sub

End Class