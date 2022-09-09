Imports System.Collections.Generic
Imports System.IO
Imports System.Reflection
Imports OxyPlot
Imports OxyPlot.Legends

Public Class frmOxySpectrum

#Region "Constants"

    Private Const OXYPLOTTER_DATE As String = "September 8, 2022"

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


    Private Sub AddAnnotationAtMax(seriesNumber As Integer, dataPoints As IEnumerable(Of DataPoint))

        Dim xForMaxY As Double = 0
        Dim maximumY = Double.MinValue

        For Each dataPoint In dataPoints
            If dataPoint.Y > maximumY Then
                maximumY = dataPoint.Y
                xForMaxY = dataPoint.X
            End If
        Next

        ctlOxyPlot.SetAnnotationForDataPoint(xForMaxY, maximumY, "Max", seriesNumber, ctlOxyPlotControl.CaptionOffsetDirection.TopLeft, 25)
    End Sub

    Private Sub AddAnnotationAtMin(seriesNumber As Integer, dataPoints As IEnumerable(Of DataPoint))

        Dim xForMinY As Double = 0
        Dim minimumY = Double.MaxValue

        For Each dataPoint In dataPoints
            If dataPoint.Y < minimumY Then
                minimumY = dataPoint.Y
                xForMinY = dataPoint.X
            End If
        Next

        ctlOxyPlot.SetAnnotationForDataPoint(xForMinY, minimumY, "Min", seriesNumber, ctlOxyPlotControl.CaptionOffsetDirection.MiddleRight, 25)
    End Sub

    Private Sub AddAnnotationSearchAll(xPos As Double, yPos As Double, caption As String)
        ctlOxyPlot.SetTextAnnotationByDataPoint(xPos, yPos, caption, 0)
    End Sub

    Public Sub AddSampleData()

        Const DATA_COUNT As Short = 50
        Dim xVals() As Double
        Dim yVals() As Double
        Dim intIndex As Integer
        Dim originalMaximumValue As Double

        Dim objRandom As New Random

        DeleteDataForAllSeries(True)

        ctlOxyPlot.GenerateSineWave(1, True)
        ctlOxyPlot.SetSeriesColor(1, ctlOxyPlot.GetDefaultSeriesColor(1))

        ctlOxyPlot.GenerateSineWave(2, False)
        ctlOxyPlot.SetSeriesColor(2, ctlOxyPlot.GetDefaultSeriesColor(2))

        ReDim xVals(DATA_COUNT - 1)
        ReDim yVals(DATA_COUNT - 1)

        Dim maxValueIndex = 0
        Dim maxMzIntensity = Double.MinValue

        For intIndex = 0 To DATA_COUNT - 1
            xVals(intIndex) = Math.Abs(22 - objRandom.Next(0, 15) * Math.Tan(intIndex / 100.0#) * 2)
            yVals(intIndex) = Math.Abs(objRandom.Next(0, 22) * Math.Sin(intIndex / 100.0#) * 15)

            If yVals(intIndex) > maxMzIntensity Then
                maxValueIndex = intIndex
                maxMzIntensity = yVals(intIndex)
            End If
        Next intIndex

        FindMaximumAndNormalizeData(yVals, 0, DATA_COUNT - 1, mNormalizationConstant, mNormalizeOnLoadOrPaste, originalMaximumValue)

        ctlOxyPlot.SetDataXvsY(3, xVals, yVals, DATA_COUNT, ctlOxyPlotControl.SeriesPlotMode.SticksToZero, "Mass Spectrum")
        ctlOxyPlot.SetSeriesColor(3, ctlOxyPlot.GetDefaultSeriesColor(3))

        SetCurrentSeriesNumber(3)

        Dim sineWaveDataLogBased = ctlOxyPlot.GetDataXvsY(1)
        Dim sineWaveData = ctlOxyPlot.GetDataXvsY(2)
        Dim mzData = ctlOxyPlot.GetDataXvsY(3)

        AddAnnotationAtMax(1, sineWaveDataLogBased)

        AddAnnotationAtMin(2, sineWaveData)

        AddAnnotationSearchAll(xVals(maxValueIndex), yVals(maxValueIndex), "m/z " + xVals(maxValueIndex).ToString("0.00"))

        ctlOxyPlot.SetLabelXAxis("X")
        ctlOxyPlot.SetLabelYAxis("Y")

        ctlOxyPlot.XAxisPaddingMinimum = 0.01
        ctlOxyPlot.XAxisPaddingMaximum = 0.01

        ctlOxyPlot.YAxisPaddingMinimum = 0.01
        ctlOxyPlot.YAxisPaddingMaximum = 0.2

        ctlOxyPlot.LegendPlacement = LegendPlacement.Inside
        ctlOxyPlot.LegendPosition = LegendPosition.TopLeft

        ctlOxyPlot.AutoscaleXAxis = True
        ctlOxyPlot.AutoscaleYAxis = True

        ctlOxyPlot.ZoomOutFull()

    End Sub

    ''' <summary>
    ''' Displays dummy data using formatting used by MASIC Browser
    ''' </summary>
    Private Sub AddSampleMASICBrowserData()

        Dim dataCountSeries1, dataCountSeries2, dataCountSeries3, dataCountSeries4 As Integer
        Dim xDataSeries1(), yDataSeries1() As Double          ' Holds the scans and SIC data for data <=0 (data not part of the peak)
        Dim xDataSeries2(), yDataSeries2() As Double          ' Holds the scans and SIC data for data > 0 (data part of the peak)
        Dim xDataSeries3(), yDataSeries3() As Double          ' Holds the scan numbers at which the given m/z was chosen for fragmentation
        Dim xDataSeries4(), yDataSeries4() As Double          ' Holds the smoothed SIC data

        Try

            Me.Cursor = Cursors.WaitCursor

            DeleteDataForAllSeries(True)

            Const DATA_COUNT = 100

            Const X_MIN = 1000
            Const X_MAX = 2000

            Const MAX_VALUE = 10000000

            Const FRAG_SCAN_COUNT = 10

            dataCountSeries1 = 0
            dataCountSeries2 = 0
            dataCountSeries3 = FRAG_SCAN_COUNT
            dataCountSeries4 = 0

            ReDim xDataSeries1(DATA_COUNT - 1)
            ReDim yDataSeries1(DATA_COUNT - 1)
            ReDim xDataSeries2(DATA_COUNT - 1)
            ReDim yDataSeries2(DATA_COUNT - 1)

            ReDim xDataSeries3(FRAG_SCAN_COUNT - 1)
            ReDim yDataSeries3(FRAG_SCAN_COUNT - 1)

            ReDim xDataSeries4(DATA_COUNT)
            ReDim yDataSeries4(DATA_COUNT)

            For intIndex = 0 To DATA_COUNT - 1

                Dim xValue = X_MIN + (X_MAX - X_MIN) * (intIndex / (DATA_COUNT - 1))
                Dim yValue1 = Math.Sin(intIndex / 10) * MAX_VALUE
                Dim yValue2 = Math.Cos(intIndex / 10) * MAX_VALUE / 2 + MAX_VALUE / 10
                Dim yValue3 = Math.Tan(intIndex / 10) * MAX_VALUE / 2 + MAX_VALUE / 10

                If yValue3 > MAX_VALUE * 2 Then
                    yValue3 = MAX_VALUE * 2
                End If

                If yValue3 < -MAX_VALUE * 2 Then
                    yValue3 = -MAX_VALUE * 2
                End If


                xDataSeries1(dataCountSeries1) = xValue
                yDataSeries1(dataCountSeries1) = yValue1
                dataCountSeries1 += 1

                xDataSeries2(dataCountSeries2) = xValue
                yDataSeries2(dataCountSeries2) = yValue2
                dataCountSeries2 += 1

                xDataSeries4(dataCountSeries4) = xValue
                yDataSeries4(dataCountSeries4) = yValue3
                dataCountSeries4 += 1

            Next intIndex


            ' Populate Series 3 with the similar frag scan values
            For intIndex = 0 To FRAG_SCAN_COUNT - 1
                Dim sourceIndex = CInt(Math.Floor(dataCountSeries1 * (intIndex / (FRAG_SCAN_COUNT - 1))))
                If sourceIndex > 0 Then sourceIndex -= 1

                xDataSeries3(intIndex) = xDataSeries1(sourceIndex)
                yDataSeries3(intIndex) = yDataSeries1(sourceIndex)
            Next intIndex


            ' Shrink the data arrays
            ' SIC Data
            ReDim Preserve xDataSeries1(dataCountSeries1 - 1)
            ReDim Preserve yDataSeries1(dataCountSeries1 - 1)

            ' SIC Peak
            ReDim Preserve xDataSeries2(dataCountSeries2 - 1)
            ReDim Preserve yDataSeries2(dataCountSeries2 - 1)

            ' Smoothed Data
            ReDim Preserve xDataSeries4(dataCountSeries4 - 1)
            ReDim Preserve yDataSeries4(dataCountSeries4 - 1)

            ctlOxyPlot.SetDataXvsY(1, xDataSeries1, yDataSeries1, dataCountSeries1, ctlOxyPlotControl.SeriesPlotMode.PointsAndLines, "Series 1")
            ctlOxyPlot.SetDataXvsY(2, xDataSeries2, yDataSeries2, dataCountSeries2, ctlOxyPlotControl.SeriesPlotMode.PointsAndLines, "Series 2")
            ctlOxyPlot.SetDataXvsY(3, xDataSeries3, yDataSeries3, dataCountSeries3, ctlOxyPlotControl.SeriesPlotMode.Points, "Series 3")
            ctlOxyPlot.SetDataXvsY(4, xDataSeries4, yDataSeries4, dataCountSeries4, ctlOxyPlotControl.SeriesPlotMode.Lines, "Series 4")

            ctlOxyPlot.SetSeriesLineStyle(1, OxyPlot.LineStyle.Automatic)
            ctlOxyPlot.SetSeriesLineStyle(2, OxyPlot.LineStyle.Automatic)
            ctlOxyPlot.SetSeriesLineStyle(4, OxyPlot.LineStyle.Automatic)

            ctlOxyPlot.SetSeriesPointStyle(1, OxyPlot.MarkerType.Diamond)
            ctlOxyPlot.SetSeriesPointStyle(2, OxyPlot.MarkerType.Square)
            ctlOxyPlot.SetSeriesPointStyle(3, OxyPlot.MarkerType.Circle)
            ctlOxyPlot.SetSeriesPointStyle(4, OxyPlot.MarkerType.None)

            ctlOxyPlot.SetSeriesColor(1, System.Drawing.Color.Blue)
            ctlOxyPlot.SetSeriesColor(2, System.Drawing.Color.Red)
            ctlOxyPlot.SetSeriesColor(3, System.Drawing.Color.FromArgb(255, 20, 210, 20))
            ctlOxyPlot.SetSeriesColor(4, System.Drawing.Color.Purple)

            ctlOxyPlot.SetSeriesLineWidth(1, 1)
            ctlOxyPlot.SetSeriesLineWidth(2, 2)
            ctlOxyPlot.SetSeriesLineWidth(4, 2)

            ctlOxyPlot.SetSeriesPointSize(3, 7)

            Dim arrowLengthPixels = 15

            Dim oRand = New Random()
            Dim fragScanIndex = oRand.Next(0, xDataSeries3.Length)
            Dim fragScanObserved = xDataSeries3(fragScanIndex)
            Dim scanObservedIntensity = yDataSeries3(fragScanIndex)

            Dim captionOffsetDirection As ctlOxyPlotControl.CaptionOffsetDirection

            If scanObservedIntensity > 0 Then
                captionOffsetDirection = ctlOxyPlotControl.CaptionOffsetDirection.TopLeft
            Else
                captionOffsetDirection = ctlOxyPlotControl.CaptionOffsetDirection.BottomRight
            End If

            Const seriesToUse = 0
            ctlOxyPlot.SetAnnotationForDataPoint(fragScanObserved, scanObservedIntensity, "Data Point",
                                                seriesToUse, captionOffsetDirection, arrowLengthPixels, )

            ctlOxyPlot.SetLabelXAxis("Scan Number")
            ctlOxyPlot.SetLabelYAxis("Intensity")

            ' Update the axis padding
            ctlOxyPlot.XAxisPaddingMinimum = 0.05
            ctlOxyPlot.XAxisPaddingMaximum = 0.05

            ctlOxyPlot.YAxisPaddingMinimum = 0.02
            ctlOxyPlot.YAxisPaddingMaximum = 0.15

            ctlOxyPlot.LegendPlacement = LegendPlacement.Inside
            ctlOxyPlot.LegendPosition = LegendPosition.TopRight

            ctlOxyPlot.AutoscaleXAxis = False
            ctlOxyPlot.SetRangeX(X_MIN * 0.95, X_MAX * 1.05)

            ctlOxyPlot.AutoscaleYAxis = True

            ctlOxyPlot.ZoomOutFull()

        Catch ex As Exception
            MessageBox.Show("Error in PlotDataMasicBrowser: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub CopyAllDataToClipboard(Optional delimiter As String = vbTab)

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
                strExport(0) = "Series " & seriesNumber & delimiter
                strExport(1) = "X" & delimiter & "Y"
            Else
                strExport(0) &= delimiter & "Series " & seriesNumber & delimiter
                strExport(1) &= delimiter & "X" & delimiter & "Y"
            End If

            Dim rowIndex = 2

            For Each dataItem In seriesData
                If seriesNumber = 1 Then
                    strExport(rowIndex) = NumToString(dataItem.X) & delimiter & NumToString(dataItem.Y)
                Else
                    strExport(rowIndex) &= delimiter & NumToString(dataItem.X) & delimiter & NumToString(dataItem.Y)
                End If

                rowIndex += 1
            Next

            For extraRowIndex = seriesData.Count + 1 To maxDataCount
                If seriesNumber = 1 Then
                    strExport(rowIndex) = delimiter
                Else
                    strExport(rowIndex) &= delimiter
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

    Public Sub CopyOneSeriesClipboard(seriesNumber As Integer, Optional delimiter As String = vbTab)

        Me.Cursor = Cursors.WaitCursor

        Dim seriesData = ctlOxyPlot.GetDataXvsY(seriesNumber)

        Dim strExport As String()
        ReDim strExport(seriesData.Count + 1)

        strExport(0) = "Series " & seriesNumber
        strExport(1) = "X" & delimiter & "Y"

        Dim rowIndex = 2

        For Each dataItem In seriesData
            strExport(rowIndex) = NumToString(dataItem.X) & delimiter & NumToString(dataItem.Y)
            rowIndex += 1
        Next

        Try
            Clipboard.SetDataObject(String.Join(vbCrLf, strExport))
        Catch ex As Exception
            ShowMessage("Error copying text to clipboard in CopyDataPointsToClipboardOrToString: " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' Clear data for the active series, optionally removing the series entirely
    ''' </summary>
    ''' <param name="removeSeries">If false, removes the data points for the series, but does not remove the series</param>
    ''' <param name="confirmDeletion"></param>
    Public Sub DeleteDataActiveSeries(removeSeries As Boolean, Optional confirmDeletion As Boolean = False)

        Dim dataCount = ctlOxyPlot.GetDataCount(mActiveSeriesNumber)

        If dataCount > 0 And confirmDeletion Then
            Dim eResponse = MessageBox.Show("Are you sure you want to delete the data in series " & mActiveSeriesNumber & "?", "Delete Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
            If eResponse <> DialogResult.Yes Then Exit Sub
        End If

        If removeSeries Then
            ctlOxyPlot.RemoveSeries(mActiveSeriesNumber)
        Else
            ctlOxyPlot.ClearData(mActiveSeriesNumber)
        End If

        ShowHideSeriesNumberMenus()

    End Sub

    ''' <summary>
    ''' Clear data for all series, optionally removing the series entirely
    ''' </summary>
    ''' <param name="removeSeries">If false, removes the data points for the series, but does not remove the series</param>
    ''' <param name="confirmDeletion"></param>
    Public Sub DeleteDataForAllSeries(removeSeries As Boolean, Optional confirmDeletion As Boolean = False)

        If confirmDeletion Then
            Dim eResponse = MessageBox.Show("Are you sure you want to delete all the data in the graph?", "Delete Data", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

            If eResponse <> DialogResult.Yes Then Exit Sub
        End If

        For seriesNumber = ctlOxyPlot.GetSeriesCount() To 1 Step -1
            If removeSeries Then
                ctlOxyPlot.RemoveSeries(seriesNumber)
            Else
                ctlOxyPlot.ClearData(seriesNumber)
            End If
        Next

        ctlOxyPlot.RemoveAllAnnotations()

    End Sub

    Public ReadOnly Property DllDate() As String
        Get
            DllDate = OXYPLOTTER_DATE
        End Get
    End Property

    Public ReadOnly Property DllVersion() As String
        Get
            Return Assembly.GetCallingAssembly.GetName.Version.ToString()
        End Get
    End Property

    Public Function FindMaximumAndNormalizeData(ByRef dataArray() As Double, ByRef intLowIndex As Integer, ByRef intHighIndex As Integer, ByRef normalizationConstant As Double, ByRef blnPerformNormalization As Boolean, ByRef originalMaximumValue As Double) As Boolean
        ' Normalizes dataArray() to range from 0 normalizationConstant
        ' Treats negative data as if it were positive data when finding originalMaximumValue
        ' Returns True if the data was successfully normalized, or if originalMaximumValue = normalizationConstant
        ' Returns False if an error, or if blnPerformNormalization = False

        Try

            Dim query = From item In dataArray.ToList() Select Math.Abs(item)

            originalMaximumValue = query.Max()

            If Math.Abs(normalizationConstant) < Single.Epsilon Then normalizationConstant = 100
            normalizationConstant = Math.Abs(normalizationConstant)

            If blnPerformNormalization And originalMaximumValue > 0 Then
                If Math.Abs(originalMaximumValue - normalizationConstant) > Single.Epsilon Then
                    For intIndex = intLowIndex To intHighIndex
                        dataArray(intIndex) = dataArray(intIndex) / originalMaximumValue * normalizationConstant
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
            '  and the mActiveSeriesNumber one is checked
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
        '		.Text = mSeriesNumberMenuLoadedCount.ToString().Trim()
        '		If mSeriesNumberMenuLoadedCount < 10 Then
        '			.Text = .Text & vbTab & "Ctrl+" & mSeriesNumberMenuLoadedCount.ToString().Trim()
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

        strMessage &= "E-mail: matthew.monroe@pnnl.gov or proteomics@pnnl.gov" & ControlChars.NewLine
        strMessage &= "Website: https://github.com/PNNL-Comp-Mass-Spec/ or https://panomics.pnnl.gov/ or https://www.pnnl.gov/integrative-omics" & ControlChars.NewLine & ControlChars.NewLine

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

    Private Sub mnuAboutAddSampleData2_Click(sender As Object, e As EventArgs) Handles mnuAboutAddSampleData2.Click
        AddSampleMASICBrowserData()
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