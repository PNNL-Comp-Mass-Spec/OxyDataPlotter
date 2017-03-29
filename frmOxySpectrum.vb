Public Class frmOxySpectrum

#Region "Constants"

    Private Const DEFAULT_FONT_NAME As String = "Arial"
    Private Const DEFAULT_FONT_SIZE As Short = 11

    Private Const SPECTRUM_DLL_DATE As String = "July 6, 2013"

#End Region

#Region "Member Variables"
    Private mActiveSeriesNumber As Integer

    Private mNormalizeOnLoadOrPaste As Boolean
    Private mNormalizationConstant As Double
#End Region

#Region "Events"

#End Region

    Public Sub AddSampleData()

        Const DATA_COUNT As Short = 50
        Dim dblXVals() As Double
        Dim dblYVals() As Double
        Dim intIndex As Integer
        Dim dblOriginalMaximumValue As Double

        Dim objRandom As New Random

        DeleteDataForAllSeries(False)

        ctlOxyPlot.SetSeriesCount(3)

        ctlOxyPlot.GenerateSineWave(1, True)
        ctlOxyPlot.SetSeriesColor(1, ctlOxyPlot.GetDefaultSeriesColor(1))

        ctlOxyPlot.GenerateSineWave(2, False)
        ctlOxyPlot.SetSeriesColor(2, ctlOxyPlot.GetDefaultSeriesColor(2))

        ReDim dblXVals(DATA_COUNT - 1)
        ReDim dblYVals(DATA_COUNT - 1)

        For intIndex = 0 To DATA_COUNT - 1
            dblXVals(intIndex) = System.Math.Abs(22 - objRandom.Next(0, 15) * System.Math.Tan(intIndex / 100.0#) * 2)
            dblYVals(intIndex) = System.Math.Abs(objRandom.Next(0, 22) * System.Math.Sin(intIndex / 100.0#) * 15)
        Next intIndex

        FindMaximumAndNormalizeData(dblYVals, 0, DATA_COUNT - 1, mNormalizationConstant, mNormalizeOnLoadOrPaste, dblOriginalMaximumValue)

        ctlOxyPlot.SetDataXvsY(3, dblXVals, dblYVals, DATA_COUNT, "")
        ctlOxyPlot.SetSeriesPlotMode(3, ctlOxyPlotControl.pmPlotModeConstants.pmSticksToZero)
        ctlOxyPlot.SetSeriesColor(3, ctlOxyPlot.GetDefaultSeriesColor(3))

        SetCurrentSeriesNumber(3)

        ctlOxyPlot.ZoomOutFull(True)

    End Sub

    Public Sub DeleteDataActiveSeries(Optional ByRef blnConfirmDeletion As Boolean = True)
        Dim eResponse As Windows.Forms.DialogResult
        Dim intDataCount As Integer

        intDataCount = ctlOxyPlot.GetDataCount(mActiveSeriesNumber)

        If intDataCount > 0 And blnConfirmDeletion Then
            eResponse = Windows.Forms.MessageBox.Show("Are you sure you want to delete the data in series " & mActiveSeriesNumber & "?", "Delete Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If eResponse <> Windows.Forms.DialogResult.Yes Then Exit Sub
        End If

        ctlOxyPlot.ClearData(mActiveSeriesNumber)

        ShowHideSeriesNumberMenus()

    End Sub

    Public Sub DeleteDataForAllSeries(Optional ByVal blnConfirmDeletion As Boolean = True)
        Dim eResponse As Windows.Forms.DialogResult
        Dim intSeriesIndex As Integer

        If blnConfirmDeletion Then
            eResponse = Windows.Forms.MessageBox.Show("Are you sure you want to delete all the data in the graph?", "Delete Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

            If eResponse <> Windows.Forms.DialogResult.Yes Then Exit Sub
        End If

        For intSeriesIndex = ctlOxyPlot.GetSeriesCount() To 1 Step -1
            mActiveSeriesNumber = intSeriesIndex
            DeleteDataActiveSeries(False)
        Next intSeriesIndex

    End Sub

    Public ReadOnly Property DllDate() As String
        Get
            DllDate = SPECTRUM_DLL_DATE
        End Get
    End Property

    Public ReadOnly Property DllVersion() As String
        Get
            Return System.Reflection.Assembly.GetCallingAssembly.GetName.Version.ToString
        End Get
    End Property


    Public Function FindMaximumAndNormalizeData(ByRef dblArray() As Double, ByRef intLowIndex As Integer, ByRef intHighIndex As Integer, ByRef dblNormalizationConstant As Double, ByRef blnPerformNormalization As Boolean, ByRef dblOriginalMaximumValue As Double) As Boolean
        ' Normalizes dblArray() to range from 0 dblNormalizationConstant
        ' Treats negative data as if it were positive data when finding dblOriginalMaximumValue
        ' Returns True if the data was successfully normalized, or if dblOriginalMaximumValue = dblNormalizationConstant
        ' Returns False if an error, or if blnPerformNormalization = False

        Try

            Dim query = From item In dblArray.ToList() Select Math.Abs(item)

            dblOriginalMaximumValue = query.Max()

            If dblNormalizationConstant = 0 Then dblNormalizationConstant = 100
            dblNormalizationConstant = Math.Abs(dblNormalizationConstant)

            If blnPerformNormalization And dblOriginalMaximumValue > 0 Then
                If dblOriginalMaximumValue <> dblNormalizationConstant Then
                    For intIndex = intLowIndex To intHighIndex
                        dblArray(intIndex) = dblArray(intIndex) / dblOriginalMaximumValue * dblNormalizationConstant
                    Next intIndex
                Else
                    ' The data is already normalized
                End If
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ShowError("Error in FindMaximumAndNormalizeData: " & ex.Message)
            Return False
        End Try

    End Function

    Public Sub SetCurrentSeriesNumber(ByRef intSeriesNumber As Short)

        Try
            If intSeriesNumber < 1 Or intSeriesNumber > ctlOxyPlot.GetSeriesCount() Then
                intSeriesNumber = 1
            End If

            mActiveSeriesNumber = intSeriesNumber

            ' Make sure the correct series number menus are loaded and visible,
            '  and the mActiveSeriesNumber'th one is checked
            ShowHideSeriesNumberMenus()
        Catch ex As Exception
            ShowError("Error in SetCurrentSeriesNumber: " & ex.Message)
        End Try

    End Sub

    Protected Sub ShowError(strMessage As String)
        System.Windows.Forms.MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub

    Private Sub ShowHideSeriesNumberMenus()
        ' Dim intMenuNumber As Integer ' Note: the mnuEditCurrentSeriesSelected menus are 1-based

        Dim intSeriesCount = ctlOxyPlot.GetSeriesCount()

        ' Must have at least one mnuEditCurrentSeriesSelected() menu visible & checked
        If intSeriesCount < 1 Then intSeriesCount = 1
        If mActiveSeriesNumber < 1 Then mActiveSeriesNumber = 1

        ' ShowMessage("Not yet implemented: ShowHideSeriesNumberMenus")

        'Do While mSeriesNumberMenuLoadedCount < intSeriesCount
        '	mSeriesNumberMenuLoadedCount = mSeriesNumberMenuLoadedCount + 1S
        '	mnuEditCurrentSeriesSelected.Load(mSeriesNumberMenuLoadedCount)
        '	With mnuEditCurrentSeriesSelected(mSeriesNumberMenuLoadedCount)
        '		.Text = mSeriesNumberMenuLoadedCount.ToString.Trim
        '		If mSeriesNumberMenuLoadedCount < 10 Then
        '			.Text = .Text & vbTab & "Ctrl+" & mSeriesNumberMenuLoadedCount.ToString.Trim
        '		End If
        '	End With
        'Loop

        'For intMenuNumber = 1 To intSeriesCount
        '	mnuEditCurrentSeriesSelected(intMenuNumber).Visible = True
        '	If intMenuNumber = mActiveSeriesNumber Then
        '		mnuEditCurrentSeriesSelected(intMenuNumber).Checked = True
        '	Else
        '		mnuEditCurrentSeriesSelected(intMenuNumber).Checked = False
        '	End If
        'Next intMenuNumber

        'For intMenuNumber = intSeriesCount + 1S To mSeriesNumberMenuLoadedCount
        '	mnuEditCurrentSeriesSelected(intMenuNumber).Visible = False
        'Next intMenuNumber

    End Sub

    Protected Sub ShowAboutBox()
        Dim strMessage As String

        strMessage = String.Empty

        strMessage &= "Program written by Matthew Monroe for the Department of Energy (PNNL, Richland, WA) in 2003" & ControlChars.NewLine

        strMessage &= "This is version " & Me.DllVersion & " (" & Me.DllDate & ")" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "E-mail: matthew.monroe@pnnl.gov or matt@alchemistmatt.com" & ControlChars.NewLine
        strMessage &= "Website: http://panomics.pnl.gov/ or http://www.sysbio.org/resources/staff/" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "Licensed under the Apache License, Version 2.0; you may not use this file except in compliance with the License.  "
        strMessage &= "You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0" & ControlChars.NewLine & ControlChars.NewLine

        Windows.Forms.MessageBox.Show(strMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Protected Sub ShowMessage(strMessage As String, Optional ByVal strCaption As String = "Info")
        System.Windows.Forms.MessageBox.Show(strMessage, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#Region "Form Events"
    Private Sub frmOxySpectrum_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "Menus"
    Private Sub mnuFileExit_Click(sender As System.Object, e As System.EventArgs) Handles mnuFileExit.Click
        Me.Hide()
    End Sub

    Private Sub mnuEditAddSampleData_Click(sender As System.Object, e As System.EventArgs) Handles mnuEditAddSampleData.Click
        AddSampleData()
    End Sub

    Private Sub mnuAbout_Click(sender As System.Object, e As System.EventArgs) Handles mnuAbout.Click
        ShowAboutBox()
    End Sub
#End Region

End Class