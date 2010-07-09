Option Explicit On 
Option Strict On

Public Class frmTestCWSpectrum
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitializeCWSpectrum()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtInfo = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(12, 58)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(112, 24)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "E&xit"
        '
        'txtInfo
        '
        Me.txtInfo.Location = New System.Drawing.Point(12, 12)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(272, 40)
        Me.txtInfo.TabIndex = 2
        Me.txtInfo.Text = "Hold down the control key, then click the Edit menu.  Now choose 'Add Sample Data" & _
            "'"
        '
        'frmTestCWSpectrum
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 94)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "frmTestCWSpectrum"
        Me.Text = "Test CW Spectrum Dll"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents objCWSpectrum As CWSpectrumDLLNET.Spectrum

    Private Sub cmdShowSpectrum_Click()
        objCWSpectrum.ShowSpectrum()
    End Sub

    Private Sub objCWSpectrum_SpectrumFormClosed()
        ' If we need to do something now that the form has closed, we can do it here
    End Sub

    Private Sub InitializeCWSpectrum()

     
        Try
            objCWSpectrum = New CWSpectrumDLLNET.Spectrum

            objCWSpectrum.SetSpectrumFormWindowCaption("Test Plot")

            objCWSpectrum.ShowSpectrum()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Error initializing CWSpectrumDLLNET.Spectrum: " & ex.Message)
        End Try
    End Sub

    Private Sub frmTestCWSpectrum_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        objCWSpectrum = Nothing
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Exception in cmdExit_Click: " & ex.Message)
        End Try
    End Sub
End Class
