Imports OxyDataPlotter

Public Class frmTestOxyPlot

    Private WithEvents mOxyPlot As frmOxySpectrum

    Private Sub InitializeOxySpectrum()

        Try
            mOxyPlot = New frmOxySpectrum

            mOxyPlot.Text = "Test Plot"

            mOxyPlot.Show()

        Catch ex As Exception
            MessageBox.Show("Error initializing CWSpectrumDLLNET.frmOxySpectrum: " & ex.Message)
        End Try
    End Sub

    Private Sub frmTestCWSpectrum_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        mOxyPlot = Nothing
    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Exception in cmdExit_Click: " & ex.Message)
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitializeOxySpectrum()
    End Sub

    Private Sub cmdShowPlot_Click(sender As System.Object, e As EventArgs) Handles cmdShowPlot.Click
        If mOxyPlot Is Nothing Then
            InitializeOxySpectrum()
        Else
            mOxyPlot.Show()
        End If

    End Sub
End Class