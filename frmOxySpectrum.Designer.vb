<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOxySpectrum
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
        Me.ctlOxyPlot = New OxyDataPlotter.ctlOxyPlotControl()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSaveGraphAsSVG = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSaveGraphAsPNG = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditCopyAllData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditCopyOneSeries = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditLegendIsVisible = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAboutAddSampleData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAboutAddSampleData2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctlOxyPlot
        '
        Me.ctlOxyPlot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ctlOxyPlot.AutoscaleXAxis = True
        Me.ctlOxyPlot.AutoscaleYAxis = True
        Me.ctlOxyPlot.LegendPlacement = OxyPlot.LegendPlacement.Inside
        Me.ctlOxyPlot.LegendPosition = OxyPlot.LegendPosition.RightTop
        Me.ctlOxyPlot.Location = New System.Drawing.Point(0, 33)
        Me.ctlOxyPlot.Margin = New System.Windows.Forms.Padding(5)
        Me.ctlOxyPlot.Name = "ctlOxyPlot"
        Me.ctlOxyPlot.Size = New System.Drawing.Size(1201, 603)
        Me.ctlOxyPlot.TabIndex = 0
        Me.ctlOxyPlot.XAxisAbsoluteMaximum = 1.7976931348623157E+308R
        Me.ctlOxyPlot.XAxisAbsoluteMinimum = -1.7976931348623157E+308R
        Me.ctlOxyPlot.XAxisPaddingMaximum = 0.01R
        Me.ctlOxyPlot.XAxisPaddingMinimum = 0.01R
        Me.ctlOxyPlot.YAxisAbsoluteMaximum = 1.7976931348623157E+308R
        Me.ctlOxyPlot.YAxisAbsoluteMinimum = 0R
        Me.ctlOxyPlot.YAxisPaddingMaximum = 0.05R
        Me.ctlOxyPlot.YAxisPaddingMinimum = 0.05R
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1215, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileSaveGraphAsSVG, Me.mnuFileSaveGraphAsPNG, Me.ToolStripSeparator1, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(44, 24)
        Me.mnuFile.Text = "&File"
        '
        'mnuFileSaveGraphAsSVG
        '
        Me.mnuFileSaveGraphAsSVG.Name = "mnuFileSaveGraphAsSVG"
        Me.mnuFileSaveGraphAsSVG.Size = New System.Drawing.Size(223, 26)
        Me.mnuFileSaveGraphAsSVG.Text = "Save Graph as &SVG ..."
        '
        'mnuFileSaveGraphAsPNG
        '
        Me.mnuFileSaveGraphAsPNG.Name = "mnuFileSaveGraphAsPNG"
        Me.mnuFileSaveGraphAsPNG.Size = New System.Drawing.Size(223, 26)
        Me.mnuFileSaveGraphAsPNG.Text = "Save Graph as &PNG ..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(220, 6)
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        Me.mnuFileExit.Size = New System.Drawing.Size(223, 26)
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditCopyAllData, Me.mnuEditCopyOneSeries, Me.ToolStripSeparator2, Me.mnuEditLegendIsVisible})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(47, 24)
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuEditCopyAllData
        '
        Me.mnuEditCopyAllData.Name = "mnuEditCopyAllData"
        Me.mnuEditCopyAllData.Size = New System.Drawing.Size(315, 26)
        Me.mnuEditCopyAllData.Text = "Copy &all data to clipboard (as text)"
        '
        'mnuEditCopyOneSeries
        '
        Me.mnuEditCopyOneSeries.Name = "mnuEditCopyOneSeries"
        Me.mnuEditCopyOneSeries.Size = New System.Drawing.Size(315, 26)
        Me.mnuEditCopyOneSeries.Text = "Copy &single series to clipboard"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(312, 6)
        '
        'mnuEditLegendIsVisible
        '
        Me.mnuEditLegendIsVisible.Checked = True
        Me.mnuEditLegendIsVisible.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuEditLegendIsVisible.Name = "mnuEditLegendIsVisible"
        Me.mnuEditLegendIsVisible.Size = New System.Drawing.Size(315, 26)
        Me.mnuEditLegendIsVisible.Text = "Show &Legend"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbout, Me.mnuAboutAddSampleData, Me.mnuAboutAddSampleData2})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(53, 24)
        Me.mnuHelp.Text = "&Help"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(210, 26)
        Me.mnuAbout.Text = "&About"
        '
        'mnuAboutAddSampleData
        '
        Me.mnuAboutAddSampleData.Name = "mnuAboutAddSampleData"
        Me.mnuAboutAddSampleData.Size = New System.Drawing.Size(210, 26)
        Me.mnuAboutAddSampleData.Text = "Add &sample data 1"
        '
        'mnuAboutAddSampleData2
        '
        Me.mnuAboutAddSampleData2.Name = "mnuAboutAddSampleData2"
        Me.mnuAboutAddSampleData2.Size = New System.Drawing.Size(210, 26)
        Me.mnuAboutAddSampleData2.Text = "Add sample &data 2"
        '
        'frmOxySpectrum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1215, 650)
        Me.Controls.Add(Me.ctlOxyPlot)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmOxySpectrum"
        Me.Text = "frmOxySpectrum"
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Public WithEvents ctlOxyPlot As ctlOxyPlotControl
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileSaveGraphAsSVG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditCopyAllData As ToolStripMenuItem
    Friend WithEvents mnuAboutAddSampleData As ToolStripMenuItem
    Friend WithEvents mnuEditCopyOneSeries As ToolStripMenuItem
    Friend WithEvents mnuFileSaveGraphAsPNG As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents mnuEditLegendIsVisible As ToolStripMenuItem
    Friend WithEvents mnuAboutAddSampleData2 As ToolStripMenuItem
End Class
