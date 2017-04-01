<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestOxyPlot
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
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdShowPlot = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtInfo
        '
        Me.txtInfo.Location = New System.Drawing.Point(4, 12)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(272, 40)
        Me.txtInfo.TabIndex = 4
        Me.txtInfo.Text = "Hold down the control key, then click the Edit menu.  Now choose 'Add Sample Data" &
          "'"
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(152, 58)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(112, 24)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "E&xit"
        '
        'cmdShowPlot
        '
        Me.cmdShowPlot.Location = New System.Drawing.Point(12, 58)
        Me.cmdShowPlot.Name = "cmdShowPlot"
        Me.cmdShowPlot.Size = New System.Drawing.Size(112, 24)
        Me.cmdShowPlot.TabIndex = 5
        Me.cmdShowPlot.Text = "&Show Plot"
        '
        'frmTestOxyPlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(286, 98)
        Me.Controls.Add(Me.cmdShowPlot)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "frmTestOxyPlot"
        Me.Text = "frmTestOxyPlot"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdShowPlot As System.Windows.Forms.Button
End Class
