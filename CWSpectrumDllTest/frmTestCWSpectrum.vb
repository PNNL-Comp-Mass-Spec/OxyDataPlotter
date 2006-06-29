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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdExit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(16, 32)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(112, 24)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "E&xit"
        '
        'frmTestCWSpectrum
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(296, 94)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "frmTestCWSpectrum"
        Me.Text = "Test CW Spectrum Dll"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents objCWSpectrum As CWSpectrumDLLNET.Spectrum

    Private Sub cmdShowSpectrum_Click()
        objCWSpectrum.ShowSpectrum()
    End Sub

    Private Sub objCWSpectrum_SpectrumFormClosed()
        ' If we need to do something now that the form has closed, we can do it here
    End Sub

    Private Sub frmTestCWSpectrum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objCWSpectrum = New CWSpectrumDLLNET.Spectrum

        objCWSpectrum.SetSpectrumFormWindowCaption("Test Plot")
        objCWSpectrum.ShowSpectrum()
    End Sub

    Private Sub frmTestCWSpectrum_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        objCWSpectrum = Nothing
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class
