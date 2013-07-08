Public Class frmTestOxyPlot

	Private WithEvents mOxyPlot As CWSpectrumDLLNET.frmOxySpectrum

	Private Sub cmdShowSpectrum_Click()
		mOxyPlot.Show()
	End Sub

	Private Sub objCWSpectrum_SpectrumFormClosed()
		' If we need to do something now that the form has closed, we can do it here
	End Sub

	Private Sub InitializeOxySpectrum()

		Try
			mOxyPlot = New CWSpectrumDLLNET.frmOxySpectrum

			mOxyPlot.Text = "Test Plot"

			mOxyPlot.Show()

		Catch ex As Exception
			System.Windows.Forms.MessageBox.Show("Error initializing CWSpectrumDLLNET.frmOxySpectrum: " & ex.Message)
		End Try
	End Sub

	Private Sub frmTestCWSpectrum_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
		mOxyPlot = Nothing
	End Sub

	Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
		Try
			Me.Close()
		Catch ex As Exception
			System.Windows.Forms.MessageBox.Show("Exception in cmdExit_Click: " & ex.Message)
		End Try
	End Sub

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		InitializeOxySpectrum()
	End Sub

	Private Sub cmdShowPlot_Click(sender As System.Object, e As System.EventArgs) Handles cmdShowPlot.Click
		If mOxyPlot Is Nothing Then
			InitializeOxySpectrum()
		Else
			mOxyPlot.Show()
		End If

	End Sub
End Class