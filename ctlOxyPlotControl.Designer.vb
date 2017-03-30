<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctlOxyPlotControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctlOxyPlotControl))
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.fraLegend = New System.Windows.Forms.GroupBox()
        Me.lblLegendCaption1 = New System.Windows.Forms.Label()
        Me.lblOriginalMaximumIntensity2 = New System.Windows.Forms.Label()
        Me.lblOriginalMaximumIntensity1 = New System.Windows.Forms.Label()
        Me.lblLegendCaption2 = New System.Windows.Forms.Label()
        Me.linLegendSeriesColor2 = New System.Windows.Forms.Label()
        Me.linLegendSeriesColor1 = New System.Windows.Forms.Label()
        Me.lblPrecisionY = New System.Windows.Forms.Label()
        Me.txtPrecisionX = New System.Windows.Forms.TextBox()
        Me.fraControls = New System.Windows.Forms.GroupBox()
        Me.fraPosition = New System.Windows.Forms.GroupBox()
        Me.cmdOptionsToggle = New System.Windows.Forms.Button()
        Me.cmdCenterCursors = New System.Windows.Forms.Button()
        Me.lblDeltaPosFromCursorLabel = New System.Windows.Forms.Label()
        Me.lblDeltaPosFromCursor = New System.Windows.Forms.Label()
        Me.fraMouseAction = New System.Windows.Forms.GroupBox()
        Me.cmdZoomOut = New System.Windows.Forms.Button()
        Me.cboMouseAction = New System.Windows.Forms.ComboBox()
        Me.lblSpaceInfo = New System.Windows.Forms.Label()
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions = New System.Windows.Forms.CheckBox()
        Me.cmdOptionsHide = New System.Windows.Forms.Button()
        Me.lblPrecisionX = New System.Windows.Forms.Label()
        Me.chkFixMinimumYAtZero = New System.Windows.Forms.CheckBox()
        Me.txtPrecisionY = New System.Windows.Forms.TextBox()
        Me.chkXAxisDateModeShowTime = New System.Windows.Forms.CheckBox()
        Me.chkAnnotationDensityToleranceAutoAdjust = New System.Windows.Forms.CheckBox()
        Me.fraXAxisDateMode = New System.Windows.Forms.GroupBox()
        Me.chkXAxisDateMode = New System.Windows.Forms.CheckBox()
        Me.fraOptions = New System.Windows.Forms.GroupBox()
        Me.fraAnnotationDensityOptions = New System.Windows.Forms.GroupBox()
        Me.chkAnnotationAutoHideCaptions = New System.Windows.Forms.CheckBox()
        Me.txtAnnotationDensityToleranceY = New System.Windows.Forms.TextBox()
        Me.txtAnnotationDensityToleranceX = New System.Windows.Forms.TextBox()
        Me.lblAnnotationDensityToleranceY = New System.Windows.Forms.Label()
        Me.lblAnnotationDensityToleranceX = New System.Windows.Forms.Label()
        Me.fraCursor = New System.Windows.Forms.GroupBox()
        Me.chkShowCursor2 = New System.Windows.Forms.CheckBox()
        Me.chkCursorSnapToData = New System.Windows.Forms.CheckBox()
        Me.chkShowCursor1 = New System.Windows.Forms.CheckBox()
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.fraScaling = New System.Windows.Forms.GroupBox()
        Me.chkAutoScaleVisibleY = New System.Windows.Forms.CheckBox()
        Me.fraPrecision = New System.Windows.Forms.GroupBox()
        Me.cmdRollUpShow = New System.Windows.Forms.Button()
        Me.cmdRollUpHide = New System.Windows.Forms.Button()
        Me.fraOptionsShadow = New System.Windows.Forms.Panel()
        Me.ctlOxyPlot = New OxyPlot.WindowsForms.PlotView()
        Me.lblMouseHints = New System.Windows.Forms.Label()
        Me.fraLegend.SuspendLayout()
        Me.fraControls.SuspendLayout()
        Me.fraPosition.SuspendLayout()
        Me.fraMouseAction.SuspendLayout()
        Me.fraXAxisDateMode.SuspendLayout()
        Me.fraOptions.SuspendLayout()
        Me.fraAnnotationDensityOptions.SuspendLayout()
        Me.fraCursor.SuspendLayout()
        Me.fraScaling.SuspendLayout()
        Me.fraPrecision.SuspendLayout()
        Me.fraOptionsShadow.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPosition
        '
        Me.lblPosition.BackColor = System.Drawing.SystemColors.Control
        Me.lblPosition.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPosition.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPosition.Location = New System.Drawing.Point(96, 14)
        Me.lblPosition.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPosition.Size = New System.Drawing.Size(204, 21)
        Me.lblPosition.TabIndex = 1
        '
        'fraLegend
        '
        Me.fraLegend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraLegend.BackColor = System.Drawing.SystemColors.Control
        Me.fraLegend.Controls.Add(Me.lblLegendCaption1)
        Me.fraLegend.Controls.Add(Me.lblOriginalMaximumIntensity2)
        Me.fraLegend.Controls.Add(Me.lblOriginalMaximumIntensity1)
        Me.fraLegend.Controls.Add(Me.lblLegendCaption2)
        Me.fraLegend.Controls.Add(Me.linLegendSeriesColor2)
        Me.fraLegend.Controls.Add(Me.linLegendSeriesColor1)
        Me.fraLegend.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraLegend.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraLegend.Location = New System.Drawing.Point(580, 24)
        Me.fraLegend.Margin = New System.Windows.Forms.Padding(4)
        Me.fraLegend.Name = "fraLegend"
        Me.fraLegend.Padding = New System.Windows.Forms.Padding(4)
        Me.fraLegend.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraLegend.Size = New System.Drawing.Size(240, 114)
        Me.fraLegend.TabIndex = 2
        Me.fraLegend.TabStop = False
        Me.fraLegend.Text = "Legend (Hidden)"
        Me.fraLegend.Visible = False
        '
        'lblLegendCaption1
        '
        Me.lblLegendCaption1.BackColor = System.Drawing.SystemColors.Control
        Me.lblLegendCaption1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLegendCaption1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLegendCaption1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLegendCaption1.Location = New System.Drawing.Point(53, 20)
        Me.lblLegendCaption1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLegendCaption1.Name = "lblLegendCaption1"
        Me.lblLegendCaption1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLegendCaption1.Size = New System.Drawing.Size(133, 28)
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
        Me.lblOriginalMaximumIntensity2.Location = New System.Drawing.Point(53, 89)
        Me.lblOriginalMaximumIntensity2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOriginalMaximumIntensity2.Name = "lblOriginalMaximumIntensity2"
        Me.lblOriginalMaximumIntensity2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOriginalMaximumIntensity2.Size = New System.Drawing.Size(176, 21)
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
        Me.lblOriginalMaximumIntensity1.Location = New System.Drawing.Point(53, 39)
        Me.lblOriginalMaximumIntensity1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOriginalMaximumIntensity1.Name = "lblOriginalMaximumIntensity1"
        Me.lblOriginalMaximumIntensity1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblOriginalMaximumIntensity1.Size = New System.Drawing.Size(176, 21)
        Me.lblOriginalMaximumIntensity1.TabIndex = 2
        '
        'lblLegendCaption2
        '
        Me.lblLegendCaption2.BackColor = System.Drawing.SystemColors.Control
        Me.lblLegendCaption2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblLegendCaption2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLegendCaption2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLegendCaption2.Location = New System.Drawing.Point(53, 69)
        Me.lblLegendCaption2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLegendCaption2.Name = "lblLegendCaption2"
        Me.lblLegendCaption2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLegendCaption2.Size = New System.Drawing.Size(133, 28)
        Me.lblLegendCaption2.TabIndex = 4
        '
        'linLegendSeriesColor2
        '
        Me.linLegendSeriesColor2.BackColor = System.Drawing.Color.Red
        Me.linLegendSeriesColor2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linLegendSeriesColor2.Location = New System.Drawing.Point(11, 79)
        Me.linLegendSeriesColor2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linLegendSeriesColor2.Name = "linLegendSeriesColor2"
        Me.linLegendSeriesColor2.Size = New System.Drawing.Size(32, 1)
        Me.linLegendSeriesColor2.TabIndex = 3
        '
        'linLegendSeriesColor1
        '
        Me.linLegendSeriesColor1.BackColor = System.Drawing.Color.Red
        Me.linLegendSeriesColor1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linLegendSeriesColor1.Location = New System.Drawing.Point(11, 30)
        Me.linLegendSeriesColor1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linLegendSeriesColor1.Name = "linLegendSeriesColor1"
        Me.linLegendSeriesColor1.Size = New System.Drawing.Size(32, 1)
        Me.linLegendSeriesColor1.TabIndex = 0
        '
        'lblPrecisionY
        '
        Me.lblPrecisionY.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrecisionY.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPrecisionY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecisionY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrecisionY.Location = New System.Drawing.Point(11, 42)
        Me.lblPrecisionY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPrecisionY.Name = "lblPrecisionY"
        Me.lblPrecisionY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrecisionY.Size = New System.Drawing.Size(23, 21)
        Me.lblPrecisionY.TabIndex = 2
        Me.lblPrecisionY.Text = "y"
        '
        'txtPrecisionX
        '
        Me.txtPrecisionX.AcceptsReturn = True
        Me.txtPrecisionX.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrecisionX.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrecisionX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecisionX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPrecisionX.Location = New System.Drawing.Point(32, 20)
        Me.txtPrecisionX.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPrecisionX.MaxLength = 0
        Me.txtPrecisionX.Name = "txtPrecisionX"
        Me.txtPrecisionX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPrecisionX.Size = New System.Drawing.Size(32, 23)
        Me.txtPrecisionX.TabIndex = 1
        Me.txtPrecisionX.Text = "2"
        '
        'fraControls
        '
        Me.fraControls.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraControls.BackColor = System.Drawing.SystemColors.Control
        Me.fraControls.Controls.Add(Me.fraLegend)
        Me.fraControls.Controls.Add(Me.fraPosition)
        Me.fraControls.Controls.Add(Me.fraMouseAction)
        Me.fraControls.Controls.Add(Me.lblMouseHints)
        Me.fraControls.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraControls.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraControls.Location = New System.Drawing.Point(11, 349)
        Me.fraControls.Margin = New System.Windows.Forms.Padding(4)
        Me.fraControls.Name = "fraControls"
        Me.fraControls.Padding = New System.Windows.Forms.Padding(4)
        Me.fraControls.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraControls.Size = New System.Drawing.Size(753, 114)
        Me.fraControls.TabIndex = 39
        Me.fraControls.TabStop = False
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
        Me.fraPosition.Location = New System.Drawing.Point(435, 59)
        Me.fraPosition.Margin = New System.Windows.Forms.Padding(4)
        Me.fraPosition.Name = "fraPosition"
        Me.fraPosition.Padding = New System.Windows.Forms.Padding(4)
        Me.fraPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraPosition.Size = New System.Drawing.Size(259, 114)
        Me.fraPosition.TabIndex = 1
        Me.fraPosition.TabStop = False
        Me.fraPosition.Text = "Position (Hidden)"
        Me.fraPosition.Visible = False
        '
        'cmdOptionsToggle
        '
        Me.cmdOptionsToggle.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOptionsToggle.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOptionsToggle.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOptionsToggle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOptionsToggle.Location = New System.Drawing.Point(149, 79)
        Me.cmdOptionsToggle.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOptionsToggle.Name = "cmdOptionsToggle"
        Me.cmdOptionsToggle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOptionsToggle.Size = New System.Drawing.Size(105, 25)
        Me.cmdOptionsToggle.TabIndex = 4
        Me.cmdOptionsToggle.Text = "&Options"
        Me.cmdOptionsToggle.UseVisualStyleBackColor = False
        '
        'cmdCenterCursors
        '
        Me.cmdCenterCursors.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCenterCursors.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCenterCursors.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCenterCursors.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCenterCursors.Location = New System.Drawing.Point(11, 79)
        Me.cmdCenterCursors.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCenterCursors.Name = "cmdCenterCursors"
        Me.cmdCenterCursors.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCenterCursors.Size = New System.Drawing.Size(117, 25)
        Me.cmdCenterCursors.TabIndex = 3
        Me.cmdCenterCursors.Text = "&Center Cursors"
        Me.cmdCenterCursors.UseVisualStyleBackColor = False
        '
        'lblDeltaPosFromCursorLabel
        '
        Me.lblDeltaPosFromCursorLabel.BackColor = System.Drawing.SystemColors.Control
        Me.lblDeltaPosFromCursorLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDeltaPosFromCursorLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeltaPosFromCursorLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDeltaPosFromCursorLabel.Location = New System.Drawing.Point(11, 30)
        Me.lblDeltaPosFromCursorLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeltaPosFromCursorLabel.Name = "lblDeltaPosFromCursorLabel"
        Me.lblDeltaPosFromCursorLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDeltaPosFromCursorLabel.Size = New System.Drawing.Size(65, 31)
        Me.lblDeltaPosFromCursorLabel.TabIndex = 0
        '
        'lblDeltaPosFromCursor
        '
        Me.lblDeltaPosFromCursor.BackColor = System.Drawing.SystemColors.Control
        Me.lblDeltaPosFromCursor.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblDeltaPosFromCursor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeltaPosFromCursor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDeltaPosFromCursor.Location = New System.Drawing.Point(96, 39)
        Me.lblDeltaPosFromCursor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDeltaPosFromCursor.Name = "lblDeltaPosFromCursor"
        Me.lblDeltaPosFromCursor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDeltaPosFromCursor.Size = New System.Drawing.Size(204, 21)
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
        Me.fraMouseAction.Margin = New System.Windows.Forms.Padding(4)
        Me.fraMouseAction.Name = "fraMouseAction"
        Me.fraMouseAction.Padding = New System.Windows.Forms.Padding(4)
        Me.fraMouseAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraMouseAction.Size = New System.Drawing.Size(219, 114)
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
        Me.cmdZoomOut.Location = New System.Drawing.Point(21, 79)
        Me.cmdZoomOut.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdZoomOut.Name = "cmdZoomOut"
        Me.cmdZoomOut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdZoomOut.Size = New System.Drawing.Size(148, 25)
        Me.cmdZoomOut.TabIndex = 2
        Me.cmdZoomOut.Text = "&Zoom Out (Ctrl+A)"
        Me.cmdZoomOut.UseVisualStyleBackColor = False
        '
        'cboMouseAction
        '
        Me.cboMouseAction.BackColor = System.Drawing.SystemColors.Window
        Me.cboMouseAction.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboMouseAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMouseAction.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMouseAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMouseAction.Location = New System.Drawing.Point(11, 20)
        Me.cboMouseAction.Margin = New System.Windows.Forms.Padding(4)
        Me.cboMouseAction.Name = "cboMouseAction"
        Me.cboMouseAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboMouseAction.Size = New System.Drawing.Size(192, 24)
        Me.cboMouseAction.TabIndex = 0
        '
        'lblSpaceInfo
        '
        Me.lblSpaceInfo.BackColor = System.Drawing.SystemColors.Control
        Me.lblSpaceInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSpaceInfo.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpaceInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSpaceInfo.Location = New System.Drawing.Point(11, 49)
        Me.lblSpaceInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSpaceInfo.Name = "lblSpaceInfo"
        Me.lblSpaceInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSpaceInfo.Size = New System.Drawing.Size(187, 18)
        Me.lblSpaceInfo.TabIndex = 1
        '
        'chkAutoAdjustScalingToIncludeAnnotationCaptions
        '
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.BackColor = System.Drawing.SystemColors.Control
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Checked = True
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Location = New System.Drawing.Point(171, 15)
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Name = "chkAutoAdjustScalingToIncludeAnnotationCaptions"
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Size = New System.Drawing.Size(140, 50)
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.TabIndex = 2
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.Text = "Auto Adjust Scaling to Include Captions"
        Me.chkAutoAdjustScalingToIncludeAnnotationCaptions.UseVisualStyleBackColor = False
        '
        'cmdOptionsHide
        '
        Me.cmdOptionsHide.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOptionsHide.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOptionsHide.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOptionsHide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOptionsHide.Location = New System.Drawing.Point(459, 207)
        Me.cmdOptionsHide.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdOptionsHide.Name = "cmdOptionsHide"
        Me.cmdOptionsHide.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOptionsHide.Size = New System.Drawing.Size(84, 30)
        Me.cmdOptionsHide.TabIndex = 6
        Me.cmdOptionsHide.Text = "&Hide"
        Me.cmdOptionsHide.UseVisualStyleBackColor = False
        '
        'lblPrecisionX
        '
        Me.lblPrecisionX.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrecisionX.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblPrecisionX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecisionX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrecisionX.Location = New System.Drawing.Point(11, 22)
        Me.lblPrecisionX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPrecisionX.Name = "lblPrecisionX"
        Me.lblPrecisionX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPrecisionX.Size = New System.Drawing.Size(23, 21)
        Me.lblPrecisionX.TabIndex = 0
        Me.lblPrecisionX.Text = "x"
        '
        'chkFixMinimumYAtZero
        '
        Me.chkFixMinimumYAtZero.BackColor = System.Drawing.SystemColors.Control
        Me.chkFixMinimumYAtZero.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkFixMinimumYAtZero.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFixMinimumYAtZero.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkFixMinimumYAtZero.Location = New System.Drawing.Point(11, 39)
        Me.chkFixMinimumYAtZero.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFixMinimumYAtZero.Name = "chkFixMinimumYAtZero"
        Me.chkFixMinimumYAtZero.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkFixMinimumYAtZero.Size = New System.Drawing.Size(151, 21)
        Me.chkFixMinimumYAtZero.TabIndex = 1
        Me.chkFixMinimumYAtZero.Text = "Fix Min Y at Zero"
        Me.chkFixMinimumYAtZero.UseVisualStyleBackColor = False
        '
        'txtPrecisionY
        '
        Me.txtPrecisionY.AcceptsReturn = True
        Me.txtPrecisionY.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrecisionY.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrecisionY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecisionY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPrecisionY.Location = New System.Drawing.Point(32, 39)
        Me.txtPrecisionY.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPrecisionY.MaxLength = 0
        Me.txtPrecisionY.Name = "txtPrecisionY"
        Me.txtPrecisionY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPrecisionY.Size = New System.Drawing.Size(32, 23)
        Me.txtPrecisionY.TabIndex = 3
        Me.txtPrecisionY.Text = "1"
        '
        'chkXAxisDateModeShowTime
        '
        Me.chkXAxisDateModeShowTime.BackColor = System.Drawing.SystemColors.Control
        Me.chkXAxisDateModeShowTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkXAxisDateModeShowTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkXAxisDateModeShowTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkXAxisDateModeShowTime.Location = New System.Drawing.Point(11, 39)
        Me.chkXAxisDateModeShowTime.Margin = New System.Windows.Forms.Padding(4)
        Me.chkXAxisDateModeShowTime.Name = "chkXAxisDateModeShowTime"
        Me.chkXAxisDateModeShowTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkXAxisDateModeShowTime.Size = New System.Drawing.Size(117, 20)
        Me.chkXAxisDateModeShowTime.TabIndex = 1
        Me.chkXAxisDateModeShowTime.Text = "Include Time"
        Me.chkXAxisDateModeShowTime.UseVisualStyleBackColor = False
        '
        'chkAnnotationDensityToleranceAutoAdjust
        '
        Me.chkAnnotationDensityToleranceAutoAdjust.BackColor = System.Drawing.SystemColors.Control
        Me.chkAnnotationDensityToleranceAutoAdjust.Checked = True
        Me.chkAnnotationDensityToleranceAutoAdjust.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAnnotationDensityToleranceAutoAdjust.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAnnotationDensityToleranceAutoAdjust.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnnotationDensityToleranceAutoAdjust.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAnnotationDensityToleranceAutoAdjust.Location = New System.Drawing.Point(277, 20)
        Me.chkAnnotationDensityToleranceAutoAdjust.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAnnotationDensityToleranceAutoAdjust.Name = "chkAnnotationDensityToleranceAutoAdjust"
        Me.chkAnnotationDensityToleranceAutoAdjust.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAnnotationDensityToleranceAutoAdjust.Size = New System.Drawing.Size(119, 31)
        Me.chkAnnotationDensityToleranceAutoAdjust.TabIndex = 4
        Me.chkAnnotationDensityToleranceAutoAdjust.Text = "Auto Adjust Tolerances"
        Me.chkAnnotationDensityToleranceAutoAdjust.UseVisualStyleBackColor = False
        '
        'fraXAxisDateMode
        '
        Me.fraXAxisDateMode.Controls.Add(Me.chkXAxisDateModeShowTime)
        Me.fraXAxisDateMode.Controls.Add(Me.chkXAxisDateMode)
        Me.fraXAxisDateMode.Location = New System.Drawing.Point(112, 20)
        Me.fraXAxisDateMode.Margin = New System.Windows.Forms.Padding(4)
        Me.fraXAxisDateMode.Name = "fraXAxisDateMode"
        Me.fraXAxisDateMode.Padding = New System.Windows.Forms.Padding(4)
        Me.fraXAxisDateMode.Size = New System.Drawing.Size(139, 69)
        Me.fraXAxisDateMode.TabIndex = 1
        Me.fraXAxisDateMode.TabStop = False
        Me.fraXAxisDateMode.Text = "Date Mode"
        '
        'chkXAxisDateMode
        '
        Me.chkXAxisDateMode.BackColor = System.Drawing.SystemColors.Control
        Me.chkXAxisDateMode.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkXAxisDateMode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkXAxisDateMode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkXAxisDateMode.Location = New System.Drawing.Point(11, 20)
        Me.chkXAxisDateMode.Margin = New System.Windows.Forms.Padding(4)
        Me.chkXAxisDateMode.Name = "chkXAxisDateMode"
        Me.chkXAxisDateMode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkXAxisDateMode.Size = New System.Drawing.Size(117, 20)
        Me.chkXAxisDateMode.TabIndex = 0
        Me.chkXAxisDateMode.Text = "X is Date"
        Me.chkXAxisDateMode.UseVisualStyleBackColor = False
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
        Me.fraOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.fraOptions.Name = "fraOptions"
        Me.fraOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.fraOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOptions.Size = New System.Drawing.Size(587, 266)
        Me.fraOptions.TabIndex = 0
        Me.fraOptions.TabStop = False
        Me.fraOptions.Text = "Options"
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
        Me.fraAnnotationDensityOptions.Location = New System.Drawing.Point(11, 158)
        Me.fraAnnotationDensityOptions.Margin = New System.Windows.Forms.Padding(4)
        Me.fraAnnotationDensityOptions.Name = "fraAnnotationDensityOptions"
        Me.fraAnnotationDensityOptions.Padding = New System.Windows.Forms.Padding(4)
        Me.fraAnnotationDensityOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraAnnotationDensityOptions.Size = New System.Drawing.Size(428, 100)
        Me.fraAnnotationDensityOptions.TabIndex = 4
        Me.fraAnnotationDensityOptions.TabStop = False
        Me.fraAnnotationDensityOptions.Text = "Annotation Density Options"
        '
        'chkAnnotationAutoHideCaptions
        '
        Me.chkAnnotationAutoHideCaptions.BackColor = System.Drawing.SystemColors.Control
        Me.chkAnnotationAutoHideCaptions.Checked = True
        Me.chkAnnotationAutoHideCaptions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAnnotationAutoHideCaptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAnnotationAutoHideCaptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnnotationAutoHideCaptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAnnotationAutoHideCaptions.Location = New System.Drawing.Point(277, 59)
        Me.chkAnnotationAutoHideCaptions.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAnnotationAutoHideCaptions.Name = "chkAnnotationAutoHideCaptions"
        Me.chkAnnotationAutoHideCaptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAnnotationAutoHideCaptions.Size = New System.Drawing.Size(97, 31)
        Me.chkAnnotationAutoHideCaptions.TabIndex = 5
        Me.chkAnnotationAutoHideCaptions.Text = "&Auto Hide Captions"
        Me.chkAnnotationAutoHideCaptions.UseVisualStyleBackColor = False
        '
        'txtAnnotationDensityToleranceY
        '
        Me.txtAnnotationDensityToleranceY.AcceptsReturn = True
        Me.txtAnnotationDensityToleranceY.BackColor = System.Drawing.SystemColors.Window
        Me.txtAnnotationDensityToleranceY.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnnotationDensityToleranceY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnotationDensityToleranceY.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAnnotationDensityToleranceY.Location = New System.Drawing.Point(160, 55)
        Me.txtAnnotationDensityToleranceY.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAnnotationDensityToleranceY.MaxLength = 0
        Me.txtAnnotationDensityToleranceY.Name = "txtAnnotationDensityToleranceY"
        Me.txtAnnotationDensityToleranceY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAnnotationDensityToleranceY.Size = New System.Drawing.Size(96, 23)
        Me.txtAnnotationDensityToleranceY.TabIndex = 3
        Me.txtAnnotationDensityToleranceY.Text = "1"
        '
        'txtAnnotationDensityToleranceX
        '
        Me.txtAnnotationDensityToleranceX.AcceptsReturn = True
        Me.txtAnnotationDensityToleranceX.BackColor = System.Drawing.SystemColors.Window
        Me.txtAnnotationDensityToleranceX.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnnotationDensityToleranceX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnnotationDensityToleranceX.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAnnotationDensityToleranceX.Location = New System.Drawing.Point(160, 30)
        Me.txtAnnotationDensityToleranceX.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAnnotationDensityToleranceX.MaxLength = 0
        Me.txtAnnotationDensityToleranceX.Name = "txtAnnotationDensityToleranceX"
        Me.txtAnnotationDensityToleranceX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAnnotationDensityToleranceX.Size = New System.Drawing.Size(96, 23)
        Me.txtAnnotationDensityToleranceX.TabIndex = 1
        Me.txtAnnotationDensityToleranceX.Text = "1"
        '
        'lblAnnotationDensityToleranceY
        '
        Me.lblAnnotationDensityToleranceY.BackColor = System.Drawing.SystemColors.Control
        Me.lblAnnotationDensityToleranceY.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAnnotationDensityToleranceY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnnotationDensityToleranceY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAnnotationDensityToleranceY.Location = New System.Drawing.Point(11, 58)
        Me.lblAnnotationDensityToleranceY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAnnotationDensityToleranceY.Name = "lblAnnotationDensityToleranceY"
        Me.lblAnnotationDensityToleranceY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAnnotationDensityToleranceY.Size = New System.Drawing.Size(140, 21)
        Me.lblAnnotationDensityToleranceY.TabIndex = 2
        Me.lblAnnotationDensityToleranceY.Text = "Density Tolerance Y"
        '
        'lblAnnotationDensityToleranceX
        '
        Me.lblAnnotationDensityToleranceX.BackColor = System.Drawing.SystemColors.Control
        Me.lblAnnotationDensityToleranceX.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAnnotationDensityToleranceX.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnnotationDensityToleranceX.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAnnotationDensityToleranceX.Location = New System.Drawing.Point(11, 31)
        Me.lblAnnotationDensityToleranceX.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAnnotationDensityToleranceX.Name = "lblAnnotationDensityToleranceX"
        Me.lblAnnotationDensityToleranceX.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAnnotationDensityToleranceX.Size = New System.Drawing.Size(140, 21)
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
        Me.fraCursor.Location = New System.Drawing.Point(11, 98)
        Me.fraCursor.Margin = New System.Windows.Forms.Padding(4)
        Me.fraCursor.Name = "fraCursor"
        Me.fraCursor.Padding = New System.Windows.Forms.Padding(4)
        Me.fraCursor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraCursor.Size = New System.Drawing.Size(428, 50)
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
        Me.chkShowCursor2.Location = New System.Drawing.Point(149, 20)
        Me.chkShowCursor2.Margin = New System.Windows.Forms.Padding(4)
        Me.chkShowCursor2.Name = "chkShowCursor2"
        Me.chkShowCursor2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkShowCursor2.Size = New System.Drawing.Size(139, 21)
        Me.chkShowCursor2.TabIndex = 1
        Me.chkShowCursor2.Text = "&Show Cursor 2"
        Me.chkShowCursor2.UseVisualStyleBackColor = False
        '
        'chkCursorSnapToData
        '
        Me.chkCursorSnapToData.BackColor = System.Drawing.SystemColors.Control
        Me.chkCursorSnapToData.Checked = True
        Me.chkCursorSnapToData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCursorSnapToData.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkCursorSnapToData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCursorSnapToData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCursorSnapToData.Location = New System.Drawing.Point(299, 20)
        Me.chkCursorSnapToData.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCursorSnapToData.Name = "chkCursorSnapToData"
        Me.chkCursorSnapToData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkCursorSnapToData.Size = New System.Drawing.Size(117, 21)
        Me.chkCursorSnapToData.TabIndex = 2
        Me.chkCursorSnapToData.Text = "Snap to &Data"
        Me.chkCursorSnapToData.UseVisualStyleBackColor = False
        '
        'chkShowCursor1
        '
        Me.chkShowCursor1.BackColor = System.Drawing.SystemColors.Control
        Me.chkShowCursor1.Checked = True
        Me.chkShowCursor1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowCursor1.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkShowCursor1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowCursor1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkShowCursor1.Location = New System.Drawing.Point(11, 20)
        Me.chkShowCursor1.Margin = New System.Windows.Forms.Padding(4)
        Me.chkShowCursor1.Name = "chkShowCursor1"
        Me.chkShowCursor1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkShowCursor1.Size = New System.Drawing.Size(139, 21)
        Me.chkShowCursor1.TabIndex = 0
        Me.chkShowCursor1.Text = "&Show Cursor 1"
        Me.chkShowCursor1.UseVisualStyleBackColor = False
        '
        'cmdMove
        '
        Me.cmdMove.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMove.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMove.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMove.Location = New System.Drawing.Point(459, 167)
        Me.cmdMove.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMove.Size = New System.Drawing.Size(84, 30)
        Me.cmdMove.TabIndex = 5
        Me.cmdMove.Text = "&Move"
        Me.cmdMove.UseVisualStyleBackColor = False
        '
        'fraScaling
        '
        Me.fraScaling.BackColor = System.Drawing.SystemColors.Control
        Me.fraScaling.Controls.Add(Me.chkAutoAdjustScalingToIncludeAnnotationCaptions)
        Me.fraScaling.Controls.Add(Me.chkFixMinimumYAtZero)
        Me.fraScaling.Controls.Add(Me.chkAutoScaleVisibleY)
        Me.fraScaling.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraScaling.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraScaling.Location = New System.Drawing.Point(256, 20)
        Me.fraScaling.Margin = New System.Windows.Forms.Padding(4)
        Me.fraScaling.Name = "fraScaling"
        Me.fraScaling.Padding = New System.Windows.Forms.Padding(4)
        Me.fraScaling.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraScaling.Size = New System.Drawing.Size(319, 70)
        Me.fraScaling.TabIndex = 2
        Me.fraScaling.TabStop = False
        Me.fraScaling.Text = "Scaling"
        '
        'chkAutoScaleVisibleY
        '
        Me.chkAutoScaleVisibleY.BackColor = System.Drawing.SystemColors.Control
        Me.chkAutoScaleVisibleY.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkAutoScaleVisibleY.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoScaleVisibleY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkAutoScaleVisibleY.Location = New System.Drawing.Point(11, 20)
        Me.chkAutoScaleVisibleY.Margin = New System.Windows.Forms.Padding(4)
        Me.chkAutoScaleVisibleY.Name = "chkAutoScaleVisibleY"
        Me.chkAutoScaleVisibleY.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkAutoScaleVisibleY.Size = New System.Drawing.Size(151, 21)
        Me.chkAutoScaleVisibleY.TabIndex = 0
        Me.chkAutoScaleVisibleY.Text = "Autoscale Visible &Y"
        Me.chkAutoScaleVisibleY.UseVisualStyleBackColor = False
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
        Me.fraPrecision.Location = New System.Drawing.Point(11, 20)
        Me.fraPrecision.Margin = New System.Windows.Forms.Padding(4)
        Me.fraPrecision.Name = "fraPrecision"
        Me.fraPrecision.Padding = New System.Windows.Forms.Padding(4)
        Me.fraPrecision.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraPrecision.Size = New System.Drawing.Size(96, 70)
        Me.fraPrecision.TabIndex = 0
        Me.fraPrecision.TabStop = False
        Me.fraPrecision.Text = "Precision"
        '
        'cmdRollUpShow
        '
        Me.cmdRollUpShow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRollUpShow.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRollUpShow.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRollUpShow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRollUpShow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRollUpShow.Image = CType(resources.GetObject("cmdRollUpShow.Image"), System.Drawing.Image)
        Me.cmdRollUpShow.Location = New System.Drawing.Point(777, 449)
        Me.cmdRollUpShow.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdRollUpShow.Name = "cmdRollUpShow"
        Me.cmdRollUpShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRollUpShow.Size = New System.Drawing.Size(21, 21)
        Me.cmdRollUpShow.TabIndex = 42
        Me.cmdRollUpShow.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdRollUpShow.UseVisualStyleBackColor = False
        '
        'cmdRollUpHide
        '
        Me.cmdRollUpHide.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRollUpHide.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRollUpHide.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRollUpHide.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRollUpHide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRollUpHide.Image = CType(resources.GetObject("cmdRollUpHide.Image"), System.Drawing.Image)
        Me.cmdRollUpHide.Location = New System.Drawing.Point(777, 429)
        Me.cmdRollUpHide.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdRollUpHide.Name = "cmdRollUpHide"
        Me.cmdRollUpHide.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRollUpHide.Size = New System.Drawing.Size(21, 21)
        Me.cmdRollUpHide.TabIndex = 41
        Me.cmdRollUpHide.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdRollUpHide.UseVisualStyleBackColor = False
        '
        'fraOptionsShadow
        '
        Me.fraOptionsShadow.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.fraOptionsShadow.Controls.Add(Me.fraOptions)
        Me.fraOptionsShadow.Cursor = System.Windows.Forms.Cursors.Default
        Me.fraOptionsShadow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraOptionsShadow.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fraOptionsShadow.Location = New System.Drawing.Point(132, 23)
        Me.fraOptionsShadow.Margin = New System.Windows.Forms.Padding(4)
        Me.fraOptionsShadow.Name = "fraOptionsShadow"
        Me.fraOptionsShadow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fraOptionsShadow.Size = New System.Drawing.Size(597, 276)
        Me.fraOptionsShadow.TabIndex = 40
        Me.fraOptionsShadow.Visible = False
        '
        'ctlOxyPlot
        '
        Me.ctlOxyPlot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ctlOxyPlot.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ctlOxyPlot.Location = New System.Drawing.Point(11, 10)
        Me.ctlOxyPlot.Margin = New System.Windows.Forms.Padding(4)
        Me.ctlOxyPlot.Name = "ctlOxyPlot"
        Me.ctlOxyPlot.PanCursor = System.Windows.Forms.Cursors.Hand
        Me.ctlOxyPlot.Size = New System.Drawing.Size(741, 324)
        Me.ctlOxyPlot.TabIndex = 43
        Me.ctlOxyPlot.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE
        Me.ctlOxyPlot.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE
        Me.ctlOxyPlot.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS
        '
        'lblMouseHints
        '
        Me.lblMouseHints.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMouseHints.Font = New System.Drawing.Font("Arial", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMouseHints.Location = New System.Drawing.Point(226, 20)
        Me.lblMouseHints.Name = "lblMouseHints"
        Me.lblMouseHints.Size = New System.Drawing.Size(509, 84)
        Me.lblMouseHints.TabIndex = 45
        Me.lblMouseHints.Text = "Mouse hints"
        '
        'ctlOxyPlotControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.fraControls)
        Me.Controls.Add(Me.cmdRollUpShow)
        Me.Controls.Add(Me.cmdRollUpHide)
        Me.Controls.Add(Me.fraOptionsShadow)
        Me.Controls.Add(Me.ctlOxyPlot)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ctlOxyPlotControl"
        Me.Size = New System.Drawing.Size(803, 472)
        Me.fraLegend.ResumeLayout(False)
        Me.fraControls.ResumeLayout(False)
        Me.fraPosition.ResumeLayout(False)
        Me.fraMouseAction.ResumeLayout(False)
        Me.fraXAxisDateMode.ResumeLayout(False)
        Me.fraOptions.ResumeLayout(False)
        Me.fraAnnotationDensityOptions.ResumeLayout(False)
        Me.fraAnnotationDensityOptions.PerformLayout()
        Me.fraCursor.ResumeLayout(False)
        Me.fraScaling.ResumeLayout(False)
        Me.fraPrecision.ResumeLayout(False)
        Me.fraPrecision.PerformLayout()
        Me.fraOptionsShadow.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents fraLegend As System.Windows.Forms.GroupBox
    Friend WithEvents lblLegendCaption1 As System.Windows.Forms.Label
    Friend WithEvents lblOriginalMaximumIntensity2 As System.Windows.Forms.Label
    Friend WithEvents lblOriginalMaximumIntensity1 As System.Windows.Forms.Label
    Friend WithEvents lblLegendCaption2 As System.Windows.Forms.Label
    Friend WithEvents linLegendSeriesColor2 As System.Windows.Forms.Label
    Friend WithEvents linLegendSeriesColor1 As System.Windows.Forms.Label
    Friend WithEvents lblPrecisionY As System.Windows.Forms.Label
    Friend WithEvents txtPrecisionX As System.Windows.Forms.TextBox
    Friend WithEvents fraControls As System.Windows.Forms.GroupBox
    Friend WithEvents fraPosition As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOptionsToggle As System.Windows.Forms.Button
    Friend WithEvents cmdCenterCursors As System.Windows.Forms.Button
    Friend WithEvents lblDeltaPosFromCursorLabel As System.Windows.Forms.Label
    Friend WithEvents lblDeltaPosFromCursor As System.Windows.Forms.Label
    Friend WithEvents fraMouseAction As System.Windows.Forms.GroupBox
    Friend WithEvents cmdZoomOut As System.Windows.Forms.Button
    Friend WithEvents cboMouseAction As System.Windows.Forms.ComboBox
    Friend WithEvents lblSpaceInfo As System.Windows.Forms.Label
    Friend WithEvents chkAutoAdjustScalingToIncludeAnnotationCaptions As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOptionsHide As System.Windows.Forms.Button
    Friend WithEvents lblPrecisionX As System.Windows.Forms.Label
    Friend WithEvents chkFixMinimumYAtZero As System.Windows.Forms.CheckBox
    Friend WithEvents txtPrecisionY As System.Windows.Forms.TextBox
    Friend WithEvents chkXAxisDateModeShowTime As System.Windows.Forms.CheckBox
    Friend WithEvents chkAnnotationDensityToleranceAutoAdjust As System.Windows.Forms.CheckBox
    Friend WithEvents fraXAxisDateMode As System.Windows.Forms.GroupBox
    Friend WithEvents chkXAxisDateMode As System.Windows.Forms.CheckBox
    Friend WithEvents fraOptions As System.Windows.Forms.GroupBox
    Friend WithEvents fraAnnotationDensityOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkAnnotationAutoHideCaptions As System.Windows.Forms.CheckBox
    Friend WithEvents txtAnnotationDensityToleranceY As System.Windows.Forms.TextBox
    Friend WithEvents txtAnnotationDensityToleranceX As System.Windows.Forms.TextBox
    Friend WithEvents lblAnnotationDensityToleranceY As System.Windows.Forms.Label
    Friend WithEvents lblAnnotationDensityToleranceX As System.Windows.Forms.Label
    Friend WithEvents fraCursor As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowCursor2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkCursorSnapToData As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowCursor1 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdMove As System.Windows.Forms.Button
    Friend WithEvents fraScaling As System.Windows.Forms.GroupBox
    Friend WithEvents chkAutoScaleVisibleY As System.Windows.Forms.CheckBox
    Friend WithEvents fraPrecision As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRollUpShow As System.Windows.Forms.Button
    Friend WithEvents cmdRollUpHide As System.Windows.Forms.Button
    Friend WithEvents fraOptionsShadow As System.Windows.Forms.Panel
    Friend WithEvents ctlOxyPlot As OxyPlot.WindowsForms.PlotView
    Friend WithEvents lblMouseHints As Label
End Class
