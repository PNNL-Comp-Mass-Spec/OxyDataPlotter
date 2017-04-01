Imports System.IO
Imports System.Reflection

Public Class frmOxySpectrum

#Region "Constants"

    Private Const DEFAULT_FONT_NAME As String = "Arial"
    Private Const DEFAULT_FONT_SIZE As Short = 11

    Private Const SPECTRUM_DLL_DATE As String = "March 29, 2017"

#End Region
#Region "Enums"

    Private Enum eImageFormats
        SVG = 0
        PNG = 1
    End Enum

#End Region

#Region "Member Variables"
    Private mActiveSeriesNumber As Integer

    Private mNormalizeOnLoadOrPaste As Boolean
    Private mNormalizationConstant As Double

    Private mMostRecentDirectory As String = String.Empty

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

        ctlOxyPlot.GenerateSineWave(1, True)
        ctlOxyPlot.SetSeriesColor(1, ctlOxyPlot.GetDefaultSeriesColor(1))

        ctlOxyPlot.GenerateSineWave(2, False)
        ctlOxyPlot.SetSeriesColor(2, ctlOxyPlot.GetDefaultSeriesColor(2))

        ReDim dblXVals(DATA_COUNT - 1)
        ReDim dblYVals(DATA_COUNT - 1)

        For intIndex = 0 To DATA_COUNT - 1
            dblXVals(intIndex) = Math.Abs(22 - objRandom.Next(0, 15) * Math.Tan(intIndex / 100.0#) * 2)
            dblYVals(intIndex) = Math.Abs(objRandom.Next(0, 22) * Math.Sin(intIndex / 100.0#) * 15)
        Next intIndex

        FindMaximumAndNormalizeData(dblYVals, 0, DATA_COUNT - 1, mNormalizationConstant, mNormalizeOnLoadOrPaste, dblOriginalMaximumValue)

        ctlOxyPlot.SetDataXvsY(3, dblXVals, dblYVals, DATA_COUNT, ctlOxyPlotControl.SeriesPlotMode.SticksToZero, "")
        ctlOxyPlot.SetSeriesColor(3, ctlOxyPlot.GetDefaultSeriesColor(3))

        SetCurrentSeriesNumber(3)

        ctlOxyPlot.ZoomOutFull()

    End Sub

    Public Sub CopyAllDataToClipboard(Optional strDelim As String = vbTab)

        Dim seriesCount = ctlOxyPlot.GetSeriesCount()

        If seriesCount = 0 Then
            MessageBox.Show("The plot is empty; nothing to copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim maxDataCount = 0

        Me.Cursor = Cursors.WaitCursor

        For seriesNumber = 1 To seriesCount
            Dim dataCount = ctlOxyPlot.GetDataCount(seriesNumber)

            If dataCount > maxDataCount Then maxDataCount = dataCount
        Next

        Dim strExport As String()
        ReDim strExport(maxDataCount + 1)

        For seriesNumber = 1 To seriesCount
            Dim seriesData = ctlOxyPlot.GetDataXvsY(seriesNumber)

            If seriesNumber = 1 Then
                strExport(0) = "Series " & seriesNumber & strDelim
                strExport(1) = "X" & strDelim & "Y"
            Else
                strExport(0) &= strDelim & "Series " & seriesNumber & strDelim
                strExport(1) &= strDelim & "X" & strDelim & "Y"
            End If

            Dim rowIndex = 2

            For Each dataItem In seriesData
                If seriesNumber = 1 Then
                    strExport(rowIndex) = NumToString(dataItem.X) & strDelim & NumToString(dataItem.Y)
                Else
                    strExport(rowIndex) &= strDelim & NumToString(dataItem.X) & strDelim & NumToString(dataItem.Y)
                End If

                rowIndex += 1
            Next

            For extraRowIndex = seriesData.Count + 1 To maxDataCount
                If seriesNumber = 1 Then
                    strExport(rowIndex) = strDelim
                Else
                    strExport(rowIndex) &= strDelim
                End If
                rowIndex += 1
            Next

        Next

        If String.IsNullOrWhiteSpace(strExport(0)) Then
            strExport(0) = "No data to copy"
        End If

        Try
            Clipboard.SetDataObject(String.Join(vbCrLf, strExport))
        Catch ex As Exception
            ShowMessage("Error copying text to clipboard in CopyDataPointsToClipboardOrToString: " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CopyOneSeriesClipboard()

        Dim seriesCount = ctlOxyPlot.GetSeriesCount()

        If seriesCount = 0 Then
            MessageBox.Show("The plot is empty; nothing to copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Dim seriesNumber As Integer

        If seriesCount > 1 Then
            Dim result = InputBox("Series number to export (between 1 and " & seriesCount & ")", "Select Series", "1")

            If String.IsNullOrWhiteSpace(result) Then Return

            If Not Integer.TryParse(result, seriesNumber) Then
                MessageBox.Show("Invalid series number: " & result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If seriesNumber > seriesCount Then
                seriesNumber = seriesCount
            End If

        Else
            seriesNumber = 1
        End If

        CopyOneSeriesClipboard(seriesNumber, vbTab)

    End Sub

    Public Sub CopyOneSeriesClipboard(seriesNumber As Integer, Optional strDelim As String = vbTab)

        Me.Cursor = Cursors.WaitCursor

        Dim seriesData = ctlOxyPlot.GetDataXvsY(seriesNumber)

        Dim strExport As String()
        ReDim strExport(seriesData.Count + 1)

        strExport(0) = "Series " & seriesNumber
        strExport(1) = "X" & strDelim & "Y"

        Dim rowIndex = 2

        For Each dataItem In seriesData
            strExport(rowIndex) = NumToString(dataItem.X) & strDelim & NumToString(dataItem.Y)
            rowIndex += 1
        Next

        Try
            Clipboard.SetDataObject(String.Join(vbCrLf, strExport))
        Catch ex As Exception
            ShowMessage("Error copying text to clipboard in CopyDataPointsToClipboardOrToString: " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Public Sub DeleteDataActiveSeries(Optional blnConfirmDeletion As Boolean = True)
        Dim eResponse As DialogResult
        Dim intDataCount As Integer

        intDataCount = ctlOxyPlot.GetDataCount(mActiveSeriesNumber)

        If intDataCount > 0 And blnConfirmDeletion Then
            eResponse = MessageBox.Show("Are you sure you want to delete the data in series " & mActiveSeriesNumber & "?", "Delete Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If eResponse <> DialogResult.Yes Then Exit Sub
        End If

        ctlOxyPlot.ClearData(mActiveSeriesNumber)

        ShowHideSeriesNumberMenus()

    End Sub

    Public Sub DeleteDataForAllSeries(Optional blnConfirmDeletion As Boolean = True)
        Dim eResponse As DialogResult
        Dim intSeriesIndex As Integer

        If blnConfirmDeletion Then
            eResponse = MessageBox.Show("Are you sure you want to delete all the data in the graph?", "Delete Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

            If eResponse <> DialogResult.Yes Then Exit Sub
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
            Return Assembly.GetCallingAssembly.GetName.Version.ToString
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

            If Math.Abs(dblNormalizationConstant) < Single.Epsilon Then dblNormalizationConstant = 100
            dblNormalizationConstant = Math.Abs(dblNormalizationConstant)

            If blnPerformNormalization And dblOriginalMaximumValue > 0 Then
                If Math.Abs(dblOriginalMaximumValue - dblNormalizationConstant) > Single.Epsilon Then
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

    Private Function NumToString(value As Double) As String
        Dim posValue = Math.Abs(value)

        If posValue < Single.Epsilon Then
            Return "0"
        End If

        If posValue < 0.01 Then
            Return value.ToString("E2")
        End If

        If posValue < 10 Then
            Return value.ToString("0.00")
        End If

        If posValue < 1000 Then
            Return value.ToString("0.0")
        End If

        Return value.ToString("0")

    End Function

    Private Sub SavePlotAsPNG()
        Try
            Dim outputFile As FileInfo = GetFileInfoForOutputImage(eImageFormats.PNG)
            If outputFile Is Nothing Then Return

            ctlOxyPlot.SavePlotAsPNG(outputFile.FullName)

            MessageBox.Show("Saved plot as " & outputFile.FullName, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ShowError("Error saving the plot to disk: " & ex.Message)
        End Try

    End Sub

    Private Sub SavePlotAsSVG()
        Try
            Dim outputFile As FileInfo = GetFileInfoForOutputImage(eImageFormats.SVG)
            If outputFile Is Nothing Then Return

            ctlOxyPlot.SavePlotAsSvg(outputFile.FullName)

            MessageBox.Show("Saved plot as " & outputFile.FullName, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ShowError("Error saving the plot to disk: " & ex.Message)
        End Try

    End Sub

    Private Function GetFileInfoForOutputImage(imageFormat As eImageFormats) As FileInfo

        Dim fileType As String

        Select Case imageFormat
            Case eImageFormats.SVG
                fileType = "svg"
            Case eImageFormats.PNG
                fileType = "png"
            Case Else
                Return Nothing
        End Select

        Dim oDialog = New SaveFileDialog() With {
            .Title = "Save as " & fileType.ToUpper(),
            .DefaultExt = fileType,
            .OverwritePrompt = True,
            .AddExtension = True,
            .FileName = "Spectrum." & fileType
        }

        If Not String.IsNullOrWhiteSpace(mMostRecentDirectory) Then
            oDialog.InitialDirectory = mMostRecentDirectory
        End If

        Dim result = oDialog.ShowDialog()

        If result <> DialogResult.OK Then
            Return Nothing
        End If

        Dim filePath = oDialog.FileName
        If String.IsNullOrWhiteSpace(filePath) Then
            Return Nothing
        End If

        Dim outputFile = New FileInfo(filePath)

        mMostRecentDirectory = outputFile.DirectoryName

        Return outputFile

    End Function

    Public Sub SetCurrentSeriesNumber(ByRef seriesNumber As Integer)

        Try
            If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.GetSeriesCount() Then
                seriesNumber = 1
            End If

            mActiveSeriesNumber = seriesNumber

            ' Make sure the correct series number menus are loaded and visible,
            '  and the mActiveSeriesNumber'th one is checked
            ShowHideSeriesNumberMenus()
        Catch ex As Exception
            ShowError("Error in SetCurrentSeriesNumber: " & ex.Message)
        End Try

    End Sub

    Public Sub SetWindowCaption(strTitle As String)
        Me.Text = strTitle
    End Sub

    Public Sub SetWindowPos(topLeftX As Integer, topLeftY As Integer)
        SetWindowPos(topLeftX, topLeftY, Me.Height, Me.Width)
    End Sub

    Public Sub SetWindowPos(topLeftX As Integer, topLeftY As Integer, windowHeight As Integer, windowWidth As Integer)
        Dim topLeft = New Point(topLeftX, topLeftY)
        Me.Location = topLeft
        Me.Width = windowWidth
        Me.Height = windowHeight
    End Sub

    Protected Sub ShowError(strMessage As String)
        MessageBox.Show(strMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        strMessage &= "Program written by Matthew Monroe for the Department of Energy (PNNL, Richland, WA) in 2017" & ControlChars.NewLine

        strMessage &= "This is version " & Me.DllVersion & " (" & Me.DllDate & ")" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "E-mail: matthew.monroe@pnnl.gov or matt@alchemistmatt.com" & ControlChars.NewLine
        strMessage &= "Website: http://panomics.pnl.gov/ or http://www.sysbio.org/resources/staff/" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "Licensed under the Apache License, Version 2.0; you may not use this file except in compliance with the License.  "
        strMessage &= "You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0" & ControlChars.NewLine & ControlChars.NewLine

        MessageBox.Show(strMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Protected Sub ShowMessage(strMessage As String, Optional strCaption As String = "Info")
        MessageBox.Show(strMessage, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub UpdateLegendVisibility()
        Dim isVisible = mnuEditLegendIsVisible.Checked
        ctlOxyPlot.SetLegendVisibility(isVisible)
    End Sub

#Region "Form Events"

    Private Sub frmOxySpectrum_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Me.Hide()
            e.Cancel = True
        End If
    End Sub

#End Region

#Region "Menus"
    Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        Me.Hide()
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        ShowAboutBox()
    End Sub

    Private Sub mnuAboutAddSampleData_Click_1(sender As Object, e As EventArgs) Handles mnuAboutAddSampleData.Click
        AddSampleData()
    End Sub

    Private Sub mnuFileSaveGraphAsSVG_Click(sender As Object, e As EventArgs) Handles mnuFileSaveGraphAsSVG.Click
        SavePlotAsSVG()
    End Sub

    Private Sub mnuFileSaveGraphAsPNG_Click(sender As Object, e As EventArgs) Handles mnuFileSaveGraphAsPNG.Click
        SavePlotAsPNG()
    End Sub

    Private Sub mnuEditCopyAllData_Click(sender As Object, e As EventArgs) Handles mnuEditCopyAllData.Click
        CopyAllDataToClipboard()
    End Sub

    Private Sub mnuEditCopyOneSeries_Click(sender As Object, e As EventArgs) Handles mnuEditCopyOneSeries.Click
        CopyOneSeriesClipboard()
    End Sub

    Private Sub mnuEditLegendIsVisible_Click(sender As Object, e As EventArgs) Handles mnuEditLegendIsVisible.Click
        mnuEditLegendIsVisible.Checked = Not mnuEditLegendIsVisible.Checked
        UpdateLegendVisibility()
    End Sub

#End Region

End Class