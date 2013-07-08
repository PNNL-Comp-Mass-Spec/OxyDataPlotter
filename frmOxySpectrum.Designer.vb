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
		Me.ctlOxyPlot = New CWSpectrumDLLNET.ctlOxyPlotControl()
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
		Me.SaveGraphAsPictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
		Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuEditAddSampleData = New System.Windows.Forms.ToolStripMenuItem()
		Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
		Me.MenuStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'ctlOxyPlot
		'
		Me.ctlOxyPlot.Location = New System.Drawing.Point(21, 22)
		Me.ctlOxyPlot.Name = "ctlOxyPlot"
		Me.ctlOxyPlot.Size = New System.Drawing.Size(966, 556)
		Me.ctlOxyPlot.TabIndex = 0
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuHelp})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(1038, 24)
		Me.MenuStrip1.TabIndex = 1
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'mnuFile
		'
		Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveGraphAsPictureToolStripMenuItem, Me.ToolStripSeparator1, Me.mnuFileExit})
		Me.mnuFile.Name = "mnuFile"
		Me.mnuFile.Size = New System.Drawing.Size(37, 20)
		Me.mnuFile.Text = "&File"
		'
		'SaveGraphAsPictureToolStripMenuItem
		'
		Me.SaveGraphAsPictureToolStripMenuItem.Name = "SaveGraphAsPictureToolStripMenuItem"
		Me.SaveGraphAsPictureToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
		Me.SaveGraphAsPictureToolStripMenuItem.Text = "Save Graph as Picture ..."
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(196, 6)
		'
		'mnuFileExit
		'
		Me.mnuFileExit.Name = "mnuFileExit"
		Me.mnuFileExit.Size = New System.Drawing.Size(199, 22)
		Me.mnuFileExit.Text = "E&xit"
		'
		'mnuEdit
		'
		Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditAddSampleData})
		Me.mnuEdit.Name = "mnuEdit"
		Me.mnuEdit.Size = New System.Drawing.Size(39, 20)
		Me.mnuEdit.Text = "&Edit"
		'
		'mnuHelp
		'
		Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAbout})
		Me.mnuHelp.Name = "mnuHelp"
		Me.mnuHelp.Size = New System.Drawing.Size(44, 20)
		Me.mnuHelp.Text = "&Help"
		'
		'mnuEditAddSampleData
		'
		Me.mnuEditAddSampleData.Name = "mnuEditAddSampleData"
		Me.mnuEditAddSampleData.Size = New System.Drawing.Size(163, 22)
		Me.mnuEditAddSampleData.Text = "Add sample data"
		'
		'mnuAbout
		'
		Me.mnuAbout.Name = "mnuAbout"
		Me.mnuAbout.Size = New System.Drawing.Size(152, 22)
		Me.mnuAbout.Text = "&About"
		'
		'frmOxySpectrum
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(1038, 604)
		Me.Controls.Add(Me.ctlOxyPlot)
		Me.Controls.Add(Me.MenuStrip1)
		Me.MainMenuStrip = Me.MenuStrip1
		Me.Name = "frmOxySpectrum"
		Me.Text = "frmOxySpectrum"
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Public WithEvents ctlOxyPlot As CWSpectrumDLLNET.ctlOxyPlotControl
	Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
	Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents SaveGraphAsPictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents mnuEditAddSampleData As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
End Class
