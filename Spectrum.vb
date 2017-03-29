Option Strict On
Option Explicit On

' -------------------------------------------------------------------------------
' Written by Matthew Monroe for the Department of Energy (PNNL, Richland, WA)
' Upgraded to VB.NET from VB6 in October 2003
' Copyright 2005, Battelle Memorial Institute.  All Rights Reserved.

' E-mail: matthew.monroe@pnl.gov or matt@alchemistmatt.com
' Website: http://ncrr.pnl.gov/ or http://www.sysbio.org/resources/staff/
' -------------------------------------------------------------------------------
'
' Licensed under the Apache License, Version 2.0; you may not use this file except
' in compliance with the License.  You may obtain a copy of the License at
' http://www.apache.org/licenses/LICENSE-2.0
'
' Notice: This computer software was prepared by Battelle Memorial Institute,
' hereinafter the Contractor, under Contract No. DE-AC05-76RL0 1830 with the
' Department of Energy (DOE).  All rights in the computer software are reserved
' by DOE on behalf of the United States Government and the Contractor as
' provided in the Contract.  NEITHER THE GOVERNMENT NOR THE CONTRACTOR MAKES ANY
' WARRANTY, EXPRESS OR IMPLIED, OR ASSUMES ANY LIABILITY FOR THE USE OF THIS
' SOFTWARE.  This notice including this sentence must appear on any copies of
' this computer software.

Public Class Spectrum

    Private Const SPECTRUM_DLL_DATE As String = "March 29, 2017"

    ''Public Enum pmPlotModeConstants
    ''	pmLines = 0
    ''	pmStickToZero = 1
    ''	pmBar = 2
    ''	pmPoints = 3
    ''	pmPointsAndLines = 4
    ''End Enum

    ''Public Enum asmAnnotationSnapModeConstants
    ''	asmFixedToAnyPoint = 0
    ''	asmFixedToSingleDataPoint = 1
    ''	asmFloating = 2
    ''End Enum

    Public Structure udtAutoLabelPeaksOptionsType
        Public IsContinuousData As Boolean ' When False, means Is Discrete Data
        Public DisplayXPos As Boolean
        Public DisplayYPos As Boolean
        Public IncludeArrow As Boolean
        Public HideInDenseRegions As Boolean
        Public CaptionAngle As Integer
        Public IntensityThresholdMinimum As Double
        Public MinimumIntensityPercentageOfMaximum As Integer
        Public PeakWidthMinimumPoints As Integer
        Public PeakLabelCountMaximum As Integer
    End Structure

    ' Actual spectrum form
    Private WithEvents SpectrumForm As frmOxySpectrum
    Private mSpectrumLoaded As Boolean
    '

    Public Sub AutoLabelPeaks(intSeriesNumber As Short, blnShowXPos As Boolean, blnShowYPos As Boolean, Optional ByVal lngCaptionAngle As Integer = 0, Optional ByVal blnIncludeArrow As Boolean = False, Optional ByVal blnHideInDenseRegions As Boolean = True, Optional ByVal lngMaxPeakCount As Integer = 100, Optional ByVal blnForceAsContinuousData As Boolean = False, Optional ByVal blnForceAsDiscreteData As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.AutoLabelPeaks(intSeriesNumber, blnShowXPos, blnShowYPos, lngCaptionAngle, blnIncludeArrow, blnHideInDenseRegions, lngMaxPeakCount, blnForceAsContinuousData, blnForceAsDiscreteData)
    End Sub

    Public Sub AutoScaleVisibleYNow()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.AutoScaleVisibleYNow()
    End Sub

    Public Sub AutoScaleXNow()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.AutoScaleXNow()
    End Sub

    Public Sub AutoScaleYNow()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.AutoScaleYNow()
    End Sub

    Public Sub CenterCursors(Optional ByVal intCursorNumber As Integer = 1, Optional ByVal blncenterAll As Boolean = True)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.CenterCursor(intCursorNumber, blncenterAll)
    End Sub

    Public Sub ClearData(intSeriesToClear As Short)
        ' This does not prompt the user
        SpectrumForm.ctlOxyPlot.ClearData(intSeriesToClear)
    End Sub

    Public Sub ClearDataAllSeries()
        ' This does not prompt the user
        SpectrumForm.DeleteDataForAllSeries(False)
    End Sub

    Public Sub CopyDataPointsToClipboardOrToString(intSeriesNumber As Short, Optional ByRef strDataToCopy As String = "", Optional ByVal strDelim As String = vbTab, Optional ByVal blnCopyToClipboard As Boolean = True)
        ' If blnCopyToClipboard = False, then simply populates strDataToCopy

        Throw New NotImplementedException
        ' ToDo: SpectrumForm.CopyDataPointsToClipboardOrToString(intSeriesNumber, strDataToCopy, strDelim, blnCopyToClipboard)
    End Sub

    Public Sub CopyToClipboardAsPicture()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.CopyToClipboardAsPicture()
    End Sub

    Public Property DateModeXAxis() As Boolean
        Get
            Throw New NotImplementedException
            ' ToDo: Return SpectrumForm.ctlOxyPlot.DateModeXAxis
        End Get
        Set(Value As Boolean)
            Throw New NotImplementedException
            ' ToDo: SpectrumForm.ctlOxyPlot.DateModeXAxis = Value
        End Set
    End Property

    Public Property DateModeXAxisShowTime() As Boolean
        Get
            Throw New NotImplementedException
            ' ToDo: Return SpectrumForm.ctlOxyPlot.DateModeXAxisShowTime
        End Get
        Set(Value As Boolean)
            Throw New NotImplementedException
            ' ToDo: SpectrumForm.ctlOxyPlot.DateModeXAxisShowTime = Value
        End Set
    End Property

    Public Sub DeleteDataActiveSeries(Optional ByVal blnConfirmDeletion As Boolean = True)
        SpectrumForm.DeleteDataActiveSeries(blnConfirmDeletion)
    End Sub

    Public Sub DeleteDataForAllSeries(Optional ByVal blnConfirmDeletion As Boolean = True)
        SpectrumForm.DeleteDataForAllSeries(blnConfirmDeletion)
    End Sub

    Public Sub EnableTrackAnnotationPlacement()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackAnnotationPlacement()
    End Sub

    Public Sub EnableTrackCursor()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackCursor()
    End Sub

    Public Sub EnableTrackModeAllEvents()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackModeAllEvents()
    End Sub

    Public Sub EnableTrackModePan(Optional ByVal blnPanXOnly As Boolean = False, Optional ByVal blnPanYOnly As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackModePan(blnPanXOnly, blnPanYOnly)
    End Sub

    Public Sub EnableTrackModeZoom(Optional ByVal blnZoomXOnly As Boolean = False, Optional ByVal blnZoomYOnly As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackModeZoom(blnZoomXOnly, blnZoomYOnly)
    End Sub

    Public Sub GenerateSineWave(intSeriesNumber As Short, blnXAxisLogBased As Boolean)
        SpectrumForm.ctlOxyPlot.GenerateSineWave(intSeriesNumber, blnXAxisLogBased)
    End Sub

    Public Function GetAnnotationFontColor(intSeriesIndex As Short) As Color
        Throw New NotImplementedException
        ' ToDo: GetAnnotationFontColor = SpectrumForm.ctlOxyPlot.GetAnnotationFontColor(intSeriesIndex)
    End Function

    Public Function GetAnnotationFontName(intSeriesIndex As Short) As String
        Throw New NotImplementedException
        ' ToDo: GetAnnotationFontName = SpectrumForm.ctlOxyPlot.GetAnnotationFontName(intSeriesIndex)
    End Function

    Public Function GetAnnotationFontSize(intSeriesIndex As Short) As Short
        Throw New NotImplementedException
        ' ToDo: GetAnnotationFontSize = SpectrumForm.ctlOxyPlot.GetAnnotationFontSize(intSeriesIndex)
    End Function

    Public Function GetAnnotationDensityToleranceAutoAdjust() As Boolean
        Throw New NotImplementedException
        ' ToDo: GetAnnotationDensityToleranceAutoAdjust = SpectrumForm.ctlOxyPlot.GetAnnotationDensityToleranceAutoAdjust()
    End Function

    Public Function GetAnnotationDensityToleranceX() As Double
        Throw New NotImplementedException
        ' ToDo: GetAnnotationDensityToleranceX = SpectrumForm.ctlOxyPlot.GetAnnotationDensityToleranceX()
    End Function

    Public Function GetAnnotationDensityToleranceY() As Double
        Throw New NotImplementedException
        ' ToDo: GetAnnotationDensityToleranceY = SpectrumForm.ctlOxyPlot.GetAnnotationDensityToleranceY()
    End Function

    Public Function GetAnnotationCount() As Short
        Throw New NotImplementedException
        ' ToDo: GetAnnotationCount = SpectrumForm.ctlOxyPlot.GetAnnotationCount()
    End Function

    Public Function GenerateAnnotationUsingNearestPoint(ByRef dblCaptionXPos As Double, ByRef dblCaptionYPos As Double, ByRef intSeriesNumber As Short, ByRef blnAnnotationShowsNearestPointX As Boolean, ByRef blnAnnotationShowsNearestPointY As Boolean, ByRef blnBindToPoint As Boolean, ByRef strCurrentCaption As String, Optional ByRef lngPointNumberOverride As Integer = -1) As String
        Throw New NotImplementedException
        ' ToDo: GenerateAnnotationUsingNearestPoint = SpectrumForm.ctlOxyPlot.GenerateAnnotationUsingNearestPoint(dblCaptionXPos, dblCaptionYPos, intSeriesNumber, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnBindToPoint, strCurrentCaption, lngPointNumberOverride)
    End Function

    Public Function GetAnnotationDensityAutoHideCaptions() As Boolean
        Throw New NotImplementedException
        ' ToDo: GetAnnotationDensityAutoHideCaptions = SpectrumForm.ctlOxyPlot.GetAnnotationDensityAutoHideCaptions()
    End Function

    'Public Function GetAnnotationByIndex(lngAnnotationIndex As Integer, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, ByRef strCaptionText As String, Optional ByRef lngCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Short = 0, Optional ByRef eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint, Optional ByRef lngPointNumberToBind As Integer = 0, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = False, Optional ByRef strAnnotationNameReturn As String = "") As Boolean
    '    Throw New NotImplementedException
    '    ' ToDo: GetAnnotationByIndex = SpectrumForm.ctlOxyPlot.GetAnnotationByIndex(lngAnnotationIndex, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, strAnnotationNameReturn)
    'End Function

    'Public Function GetAnnotationByName(strAnnotationName As String, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, ByRef strCaptionText As String, Optional ByRef lngCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Short = 0, Optional ByRef eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint, Optional ByRef lngPointNumberToBind As Integer = 0, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = False, Optional ByRef strAnnotationNameReturn As String = "", Optional ByRef blnCaseSensitive As Boolean = False) As Boolean
    '    Throw New NotImplementedException
    '    ' ToDo: GetAnnotationByName = SpectrumForm.ctlOxyPlot.GetAnnotationByName(strAnnotationName, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, strAnnotationNameReturn, blnCaseSensitive)
    'End Function

    Public Function GetAutoAdjustScalingToIncludeCaptions() As Boolean
        Throw New NotImplementedException
        ' ToDo: GetAutoAdjustScalingToIncludeCaptions = SpectrumForm.ctlOxyPlot.GetAutoAdjustScalingToIncludeCaptions()
    End Function

    Public Sub GetAutoLabelPeaksOptions(ByRef udtAutoLabelPeaksOptions As udtAutoLabelPeaksOptionsType)

        Dim udtAutoLabelPeaksOptionsInternal As udtAutoLabelPeaksOptionsInternalType

        Throw New NotImplementedException
        ' ToDo: SpectrumForm.StoreAutoLabelPeaksOptionsInModule()

        AutoLabelOptionsRetrieve(udtAutoLabelPeaksOptionsInternal)

        With udtAutoLabelPeaksOptionsInternal
            udtAutoLabelPeaksOptions.CaptionAngle = .CaptionAngle
            udtAutoLabelPeaksOptions.DisplayXPos = .DisplayXPos
            udtAutoLabelPeaksOptions.DisplayYPos = .DisplayYPos
            udtAutoLabelPeaksOptions.HideInDenseRegions = .HideInDenseRegions
            udtAutoLabelPeaksOptions.IncludeArrow = .IncludeArrow
            udtAutoLabelPeaksOptions.IntensityThresholdMinimum = .IntensityThresholdMinimum
            If .DataMode = modCWSpectrum.dmDataModeConstants.dmContinuous Then
                udtAutoLabelPeaksOptions.IsContinuousData = True
            Else
                udtAutoLabelPeaksOptions.IsContinuousData = False
            End If
            udtAutoLabelPeaksOptions.MinimumIntensityPercentageOfMaximum = .MinimumIntensityPercentageOfMaximum
            udtAutoLabelPeaksOptions.PeakLabelCountMaximum = .PeakLabelCountMaximum
            udtAutoLabelPeaksOptions.PeakWidthMinimumPoints = .PeakWidthMinimumPoints
        End With

    End Sub

    Public Function GetAutoscaleVisibleY() As Boolean
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetAutoscaleVisibleY()
    End Function

    Public Function GetControlImage() As System.Drawing.Image
        ' Returns an image of the graph, in the form of a Windows MetaFile
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetControlImage()
    End Function

    Public Function GetCursorSnapToDataPointModeEnabled() As Boolean
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetCursorSnapToDataPointModeEnabled()
    End Function

    Public Function GetCursorColor(Optional ByVal intCursorNumber As Integer = 1) As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetCursorColor(intCursorNumber)
    End Function

    Public Sub GetCursorPosition(ByRef XPos As Double, ByRef YPos As Double, Optional ByVal intCursorNumber As Integer = 1)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.GetCursorPosition(XPos, YPos, intCursorNumber)
    End Sub

    Public Function GetCursorVisibility(Optional ByVal intCursorNumber As Integer = 1) As Boolean
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetCursorVisibility(intCursorNumber)
    End Function

    Public Function GetDataCount(intSeriesNumber As Short) As Integer
        GetDataCount = SpectrumForm.ctlOxyPlot.GetDataCount(intSeriesNumber)
    End Function

    Public Function GetDataXvsY(intSeriesNumber As Short, ByRef XDataZeroBased1DArray() As Double, ByRef YDataZeroBased1DArray() As Double, ByRef DataCount As Integer) As Boolean
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetDataXvsY(intSeriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, DataCount)
    End Function

    Public Function GetDefaultSeriesColor(intSeriesNumber As Short) As Color
        Throw New NotImplementedException
        ' ToDo: Return  SpectrumForm.ctlOxyPlot.GetDefaultSeriesColor(intSeriesNumber)
    End Function

    Public Function GetDisplayPrecisionX() As Double
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetDisplayPrecisionX()
    End Function

    Public Function GetDisplayPrecisionY() As Double
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetDisplayPrecisionY()
    End Function

    Public Function GetFixMinimumYAtZero() As Boolean
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetFixMinimumYAtZero()
    End Function

    Public Function GetLabelFontColor() As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelFontColor()
    End Function

    Public Function GetLabelFontName() As String
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelFontName()
    End Function

    Public Function GetLabelFontSize() As Short
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelFontSize()
    End Function

    Public Function GetGridLinesXVisible(Optional ByVal blnMajorGridLines As Boolean = True) As Boolean
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetGridLinesXVisible(blnMajorGridLines)
    End Function

    Public Function GetGridlinesYVisible(Optional ByVal blnMajorGridLines As Boolean = True) As Boolean
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetGridlinesYVisible(blnMajorGridLines)
    End Function

    Public Function GetGridLinesXColor(Optional ByVal blnMajorGridLines As Boolean = True) As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetGridLinesXColor(blnMajorGridLines)
    End Function

    Public Function GetGridLinesYColor(Optional ByVal blnMajorGridLines As Boolean = True) As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetGridLinesYColor(blnMajorGridLines)
    End Function

    Public Function GetLabelSubtitle() As String
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelSubtitle()
    End Function

    Public Function GetLabelTitle() As String
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelTitle()
    End Function

    Public Function GetLabelXAxis() As String
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelXAxis()
    End Function

    Public Function GetLabelYAxis() As String
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelYAxis()
    End Function

    Public Function GetPlotBackgroundColor() As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetPlotBackgroundColor()
    End Function

    Public Function GetRangeX(Optional ByRef dblMinimum As Double = 0, Optional ByRef dblMaximum As Double = 0) As Double
        ' Returns Abs(dblMaximum - dblMinimum)
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetRangeX(dblMinimum, dblMaximum)
    End Function

    Public Function GetRangeY(Optional ByRef dblMinimum As Double = 0, Optional ByRef dblMaximum As Double = 0) As Double
        ' Returns Abs(dblMaximum - dblMinimum)
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetRangeY(dblMinimum, dblMaximum)
    End Function

    Public Function GetSeriesBarFillColor(intSeriesNumber As Short) As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesBarFillColor(intSeriesNumber)
    End Function

    Public Function GetSeriesCount() As Integer
        GetSeriesCount = SpectrumForm.ctlOxyPlot.GetSeriesCount()
    End Function

    Public Function GetSeriesLegendCaption(intSeriesNumber As Short) As String
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLegendCaption(intSeriesNumber)
    End Function

    Public Function GetSeriesLineColor(intSeriesNumber As Short) As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineColor(intSeriesNumber)
    End Function

    Public Function GetSeriesLineToBaseColor(intSeriesNumber As Short) As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineToBaseColor(intSeriesNumber)
    End Function

    Public Function GetSeriesLineStyle(intSeriesNumber As Short) As OxyPlot.LineStyle
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineStyle(intSeriesNumber)
    End Function

    Public Function GetSeriesLineWidth(intSeriesNumber As Short) As Short
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineWidth(intSeriesNumber)
    End Function

    Public Function GetSeriesOriginalIntensityMaximum(intSeriesNumber As Short) As Double
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesOriginalIntensityMaximum(intSeriesNumber)
    End Function

    Public Function GetSeriesPlotMode(intSeriesNumber As Short) As ctlOxyPlotControl.pmPlotModeConstants
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesPlotMode(intSeriesNumber)
    End Function

    Public Function GetSeriesPointColor(intSeriesNumber As Integer) As Color
        Return SpectrumForm.ctlOxyPlot.GetSeriesPointColor(intSeriesNumber)
    End Function

    Public Function GetSeriesPointStyle(intSeriesNumber As Integer) As OxyPlot.MarkerType
        Return SpectrumForm.ctlOxyPlot.GetSeriesPointStyle(intSeriesNumber)
    End Function

    Public Function GetSpectrumFormActiveSeriesNumber() As Short
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.GetActiveSeriesNumber()
    End Function

    Public Function GetSpectrumFormNormalizeOnLoadOrPaste() As Boolean
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.GetNormalizeOnLoadOrPaste()
    End Function

    Public Function GetSpectrumFormNormalizationConstant() As Double
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.GetNormalizationConstant()
    End Function

    Public Sub GetSpectrumFormWindowPos(ByRef Top As Integer, ByRef intLeft As Integer, ByRef Height As Integer, ByRef Width As Integer)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.GetWindowPos(Top, intLeft, Height, Width)
    End Sub

    Public Sub LoadDataFromDisk(Optional ByVal strInputFilePath As String = "", Optional ByVal blnShowMessages As Boolean = True, Optional ByVal blnLoadOptionsOnly As Boolean = False, Optional ByVal blnDelimeterComma As Boolean = True, Optional ByVal blnDelimeterTab As Boolean = True, Optional ByVal blnDelimeterSpace As Boolean = False, Optional ByVal blnLoadingDTAFile As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.LoadDataFromDisk(strInputFilePath, blnShowMessages, blnLoadOptionsOnly, blnDelimeterComma, blnDelimeterTab, blnDelimeterSpace, blnLoadingDTAFile)
    End Sub

    Public Function LookupNearestPointNumber(dblXPosSearch As Double, dblYPosSearch As Double, ByRef intSeriesNumber As Short, Optional ByRef dblDistanceToClosestSeriesNumberDataPoint As Double = 0, Optional ByVal blnLimitToGivenSeriesNumber As Boolean = False) As Integer
        Throw New NotImplementedException
        ' ToDo: LookupNearestPointNumber = SpectrumForm.ctlOxyPlot.LookupNearestPointNumber(dblXPosSearch, dblYPosSearch, intSeriesNumber, dblDistanceToClosestSeriesNumberDataPoint, blnLimitToGivenSeriesNumber)
    End Function

    Public Sub PasteDataFromClipboard(Optional ByVal blnShowMessages As Boolean = True, Optional ByVal blnAllowCommaDelimeter As Boolean = True)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.PasteDataFromClipboard(blnShowMessages, blnAllowCommaDelimeter)
    End Sub

    Public Function RemoveAnnotationByCaption(strAnnotationText As String, Optional ByVal blnCaseSensitive As Boolean = False) As Boolean
        Throw New NotImplementedException
        ' ToDo: RemoveAnnotationByCaption = SpectrumForm.ctlOxyPlot.RemoveAnnotationByCaption(strAnnotationText, blnCaseSensitive)
    End Function

    Public Function RemoveAnnotationByIndex(lngAnnotationIndex As Integer) As Boolean
        Throw New NotImplementedException
        ' ToDo: RemoveAnnotationByIndex = SpectrumForm.ctlOxyPlot.RemoveAnnotationByCaption(CStr(lngAnnotationIndex))
    End Function

    Public Sub RemoveAllAnnotations(Optional ByVal blnConfirmRemoval As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.RemoveAllAnnotations((blnConfirmRemoval))
    End Sub

    Public Sub RemoveAnnotationsForSeries(intSeriesNumber As Short)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.RemoveAnnotationsForSeries(intSeriesNumber)
    End Sub

    Public Sub ResetOptionsToDefaults(Optional ByVal blnClearAllData As Boolean = False, Optional ByVal blnResetSeriesCount As Boolean = False, Optional ByVal intNewSeriesCount As Short = 2, Optional ByVal eDefaultPlotMode As ctlOxyPlotControl.pmPlotModeConstants = ctlOxyPlotControl.pmPlotModeConstants.pmLines)
        ' This does not prompt the user
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.ResetOptionsToDefaults(blnClearAllData, blnResetSeriesCount, intNewSeriesCount, eDefaultPlotMode)
    End Sub

    Public Sub SaveDataToDisk(Optional ByVal strOutputFilePath As String = "", Optional ByVal blnOptionsOnly As Boolean = False, Optional ByVal strDelim As String = ",", Optional ByVal blnShowMessages As Boolean = True, Optional ByVal blnAppendOptionsToFile As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.SaveDataToDisk(strOutputFilePath, blnOptionsOnly, strDelim, blnShowMessages, blnAppendOptionsToFile)
    End Sub

    Public Sub SaveToDiskAsWMF(Optional ByVal strOutputFilePath As String = "", Optional ByVal blnShowMessages As Boolean = True)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.SaveToDiskAsPicture(strOutputFilePath, blnShowMessages)
    End Sub

    'Public Function SetAnnotation(blnPromptForText As Boolean, CaptionXPos As Double, CaptionYPos As Double, Optional ByVal strCaptionText As String = "", Optional ByVal lngCaptionAngle As Integer = 0, Optional ByVal intSeriesNumber As Short = 1, Optional ByVal eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional ByVal lngPointNumberToBind As Integer = -1, Optional ByVal blnAnnotationShowsNearestPointX As Boolean = False, Optional ByVal blnAnnotationShowsNearestPointY As Boolean = False, Optional ByVal blnIncludeArrow As Boolean = False, Optional ByVal blnHideInDenseRegions As Boolean = True, Optional ByVal lngAnnotationIndexForce As Integer = 0, Optional ByVal blnAutomaticCaptionPlacement As Boolean = False) As Integer
    '    ' Adds a new annotation
    '    '  or updates an existing one of lngAnnotationIndexForce is > 0
    '    ' Returns the index of the annotation (.Annotations is 1-based)
    '    ' Returns 0 if an annotation is removed or the change is cancelled
    '    ' Use lngAnnotationIndexForce to force editing of an existing annotation

    '    Throw New NotImplementedException
    '    ' ToDo: SetAnnotation = SpectrumForm.ctlOxyPlot.SetAnnotation(blnPromptForText, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, lngAnnotationIndexForce, blnAutomaticCaptionPlacement)
    'End Function

    'Public Function SetAnnotationByIndex(lngAnnotationIndex As Integer, CaptionXPos As Double, CaptionYPos As Double, Optional ByVal strCaptionText As String = "", Optional ByVal lngCaptionAngle As Integer = 0, Optional ByVal intSeriesNumber As Short = 1, Optional ByVal eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional ByVal lngPointNumberToBind As Integer = 0, Optional ByVal blnAnnotationShowsNearestPointX As Boolean = False, Optional ByVal blnAnnotationShowsNearestPointY As Boolean = False, Optional ByVal blnIncludeArrow As Boolean = False, Optional ByVal blnHideInDenseRegions As Boolean = True, Optional ByVal blnAutomaticCaptionPlacement As Boolean = False, Optional ByVal strReturnAnnotationName As String = "") As Boolean
    '    Throw New NotImplementedException
    '    ' ToDo: SetAnnotationByIndex = SpectrumForm.ctlOxyPlot.SetAnnotationByIndex(lngAnnotationIndex, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, blnAutomaticCaptionPlacement, strReturnAnnotationName)
    'End Function

    Public Sub SetAnnotationFontColor(intSeriesNumber As Short, cNewColor As Color, blnMakeDefaultForAll As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationFontColor(intSeriesNumber, cNewColor, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationFontName(intSeriesNumber As Short, strNewFontName As String, blnMakeDefaultForAll As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationFontName(intSeriesNumber, strNewFontName, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationFontSize(intSeriesNumber As Short, intNewSize As Short, blnMakeDefaultForAll As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationFontSize(intSeriesNumber, intNewSize, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationDensityAutoHideCaptions(blnEnableAutoHide As Boolean, Optional ByVal blnShowHiddenCaptionsIfDisabled As Boolean = True)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationDensityAutoHideCaptions(blnEnableAutoHide, blnShowHiddenCaptionsIfDisabled)
    End Sub

    Public Sub SetAnnotationDensityToleranceX(dblNewThreshold As Double)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationDensityToleranceX(dblNewThreshold)
    End Sub

    Public Sub SetAnnotationDensityToleranceY(dblNewThreshold As Double)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationDensityToleranceY(dblNewThreshold)
    End Sub

    Public Sub SetAnnotationDensityToleranceAutoAdjust(blnEnableAutoAdjust As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationDensityToleranceAutoAdjust(blnEnableAutoAdjust)
    End Sub

    Public Sub SetAutoscaleXAxis(blnEnableAutoscale As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAutoscaleXAxis(blnEnableAutoscale)
    End Sub

    Public Sub SetAutoscaleYAxis(blnEnableAutoscale As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAutoscaleYAxis(blnEnableAutoscale)
    End Sub

    Public Sub SetAutoAdjustScalingToIncludeCaptions(blnEnable As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAutoAdjustScalingToIncludeCaptions(blnEnable)
    End Sub

    Public Sub SetAutoLabelPeaksOptions(udtNewAutoLabelOptions As udtAutoLabelPeaksOptionsType)
        Dim udtAutoLabelPeaksOptionsInternal As udtAutoLabelPeaksOptionsInternalType

        With udtNewAutoLabelOptions
            udtAutoLabelPeaksOptionsInternal.CaptionAngle = .CaptionAngle
            udtAutoLabelPeaksOptionsInternal.DisplayXPos = .DisplayXPos
            udtAutoLabelPeaksOptionsInternal.DisplayYPos = .DisplayYPos
            udtAutoLabelPeaksOptionsInternal.HideInDenseRegions = .HideInDenseRegions
            udtAutoLabelPeaksOptionsInternal.IncludeArrow = .IncludeArrow
            udtAutoLabelPeaksOptionsInternal.IntensityThresholdMinimum = .IntensityThresholdMinimum
            If .IsContinuousData Then
                udtAutoLabelPeaksOptionsInternal.DataMode = modCWSpectrum.dmDataModeConstants.dmContinuous
            Else
                udtAutoLabelPeaksOptionsInternal.DataMode = modCWSpectrum.dmDataModeConstants.dmDiscrete
            End If
            udtAutoLabelPeaksOptionsInternal.MinimumIntensityPercentageOfMaximum = .MinimumIntensityPercentageOfMaximum
            udtAutoLabelPeaksOptionsInternal.PeakLabelCountMaximum = .PeakLabelCountMaximum
            udtAutoLabelPeaksOptionsInternal.PeakWidthMinimumPoints = .PeakWidthMinimumPoints
        End With

        AutoLabelOptionsStore(udtAutoLabelPeaksOptionsInternal)

        ' ToDo: SpectrumForm.RetrieveAutoLabelPeaksOptionsFromModule()

    End Sub

    Public Sub SetAutoscaleVisibleY(blnEnableAutoscale As Boolean, blnFixMinimumYAtZero As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAutoscaleVisibleY(blnEnableAutoscale, blnFixMinimumYAtZero)
    End Sub

    Public Sub SetCursorColor(cNewColor As Color, Optional ByVal intCursorNumber As Integer = 1)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetCursorColor(cNewColor, intCursorNumber)
    End Sub

    Public Sub SetCursorPosition(XPos As Double, YPos As Double, Optional ByVal intCursorNumber As Integer = 1)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetCursorPosition(XPos, YPos, intCursorNumber)
    End Sub

    Public Sub SetCursorSnapMode(blnSnapToData As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetCursorSnapMode(blnSnapToData)
    End Sub

    Public Sub SetCursorVisible(blnShowCursor As Boolean, Optional ByVal intCursorNumber As Integer = 1)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetCursorVisible(blnShowCursor, intCursorNumber)
    End Sub

    Public Sub SetDataXvsY(intSeriesNumber As Integer, ByRef XDataZeroBased1DArray() As Double, ByRef YDataZeroBased1DArray() As Double, DataCount As Integer, Optional ByVal strSeriesTitle As String = "", Optional ByVal dblOriginalMaximumIntensity As Double = 0)
        SpectrumForm.ctlOxyPlot.SetDataXvsY(intSeriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, DataCount, strSeriesTitle)
    End Sub

    Public Sub SetDataYOnly(intSeriesNumber As Integer, ByRef YDataZeroBased1DArray() As Double, YDataCount As Integer, Optional ByVal dblXFirst As Double = 0, Optional ByVal dblIncrement As Double = 1, Optional ByVal strSeriesTitle As String = "", Optional ByVal dblOriginalMaximumIntensity As Double = 0)
        SpectrumForm.ctlOxyPlot.SetDataYOnly(intSeriesNumber, YDataZeroBased1DArray, YDataCount, dblXFirst, dblIncrement, strSeriesTitle)
    End Sub

    Public Sub SetDisplayPrecisionX(intPrecision As Short)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetDisplayPrecisionX(intPrecision)
    End Sub

    Public Sub SetDisplayPrecisionY(intPrecision As Short)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetDisplayPrecisionY(intPrecision)
    End Sub

    Public Sub SetGridLinesXColor(cNewColor As Color, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False, Optional ByVal blnUpdateTickColors As Boolean = True)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetGridLinesXColor(cNewColor, blnMajorGridLines, blnApplyToAllAxes, blnUpdateTickColors)
    End Sub

    Public Sub SetGridLinesYColor(cNewColor As Color, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False, Optional ByVal blnUpdateTickColors As Boolean = True)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetGridLinesYColor(cNewColor, blnMajorGridLines, blnApplyToAllAxes, blnUpdateTickColors)
    End Sub

    Public Sub SetGridLinesXVisible(blnShowGridLines As Boolean, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetGridLinesXVisible(blnShowGridLines, blnMajorGridLines, blnApplyToAllAxes)
    End Sub

    Public Sub SetGridLinesYVisible(blnShowGridLines As Boolean, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetGridLinesYVisible(blnShowGridLines, blnMajorGridLines, blnApplyToAllAxes)
    End Sub

    Public Sub SetLabelFontColor(cNewColor As Color)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetLabelFontColor(cNewColor)
    End Sub

    Public Sub SetLabelFontName(strFontName As String)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetLabelFontName(strFontName)
    End Sub

    Public Sub SetLabelFontSize(intNewSize As Short)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetLabelFontSize(intNewSize)
    End Sub

    Public Sub SetLabelXAxis(strAxisLabel As String)
        SpectrumForm.ctlOxyPlot.SetLabelXAxis(strAxisLabel)
    End Sub

    Public Sub SetLabelYAxis(strAxisLabel As String)
        SpectrumForm.ctlOxyPlot.SetLabelYAxis(strAxisLabel)
    End Sub

    Public Sub SetLabelTitle(strTitle As String)
        SpectrumForm.ctlOxyPlot.SetLabelTitle(strTitle)
    End Sub

    Public Sub SetLabelSubTitle(strSubTitle As String)
        SpectrumForm.ctlOxyPlot.SetLabelSubTitle(strSubTitle)
    End Sub

    Public Sub SetPlotBackgroundColor(cNewColor As Color)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetPlotBackgroundColor(cNewColor)
    End Sub

    Public Sub SetRangeX(dblMinimum As Double, dblMaximum As Double, Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnReturnAnnotationVisibilityChecked As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetRangeX(dblMinimum, dblMaximum, blnAddToZoomHistory, blnReturnAnnotationVisibilityChecked)
    End Sub

    Public Sub SetRangeY(dblMinimum As Double, dblMaximum As Double, Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnReturnAnnotationVisibilityChecked As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetRangeY(dblMinimum, dblMaximum, blnAddToZoomHistory, blnReturnAnnotationVisibilityChecked)
    End Sub

    Public Sub SetSeriesBarFillColor(intSeriesNumber As Short, cNewColor As Color)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesBarFillColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesColor(intSeriesNumber As Short, cNewColor As Color)
        SpectrumForm.ctlOxyPlot.SetSeriesColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesCount(intCount As Short)
        SpectrumForm.ctlOxyPlot.SetSeriesCount(intCount)
    End Sub

    Public Sub SetSeriesLegendCaption(intSeriesNumber As Short, strNewCaption As String)
        SpectrumForm.ctlOxyPlot.SetSeriesLegendCaption(intSeriesNumber, strNewCaption)
    End Sub

    Public Sub SetSeriesLineColor(intSeriesNumber As Short, cNewColor As Color)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesLineColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesLineToBaseColor(intSeriesNumber As Short, cNewColor As Color)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesLineToBaseColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesLineStyle(intSeriesNumber As Short, eLineStyle As OxyPlot.LineStyle)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesLineStyle(intSeriesNumber, eLineStyle)
    End Sub

    Public Sub SetSeriesLineWidth(intSeriesNumber As Short, intWidth As Short)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesLineWidth(intSeriesNumber, intWidth)
    End Sub

    Public Sub SetSeriesOriginalIntensityMaximum(intSeriesNumber As Short, dblNewOriginalMaximumIntensity As Double)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesOriginalIntensityMaximum(intSeriesNumber, dblNewOriginalMaximumIntensity)
    End Sub

    Public Sub SetSeriesPlotMode(intSeriesNumber As Short, ePlotMode As ctlOxyPlotControl.pmPlotModeConstants, blnMakeDefault As Boolean)
        SpectrumForm.ctlOxyPlot.SetSeriesPlotMode(intSeriesNumber, ePlotMode, blnMakeDefault)
    End Sub

    Public Sub SetSeriesPointColor(intSeriesNumber As Integer, cNewColor As Color)
        SpectrumForm.ctlOxyPlot.SetSeriesPointColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesPointStyle(intSeriesNumber As Integer, ePointStyle As OxyPlot.MarkerType)
        SpectrumForm.ctlOxyPlot.SetSeriesPointStyle(intSeriesNumber, ePointStyle)
    End Sub

    Public Sub SetSeriesStartAndIncrement(intSeriesNumber As Short, dblXFirst As Double, dblIncrement As Double)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesStartAndIncrement(intSeriesNumber, dblXFirst, dblIncrement)
    End Sub

    Public Sub SetSeriesVisible(intSeriesNumber As Short, blnShowSeries As Boolean)
        SpectrumForm.ctlOxyPlot.SetSeriesVisible(intSeriesNumber, blnShowSeries)
    End Sub

    Public Sub SetSpectrumFormCurrentSeriesNumber(intSeriesNumber As Short)
        SpectrumForm.SetCurrentSeriesNumber(intSeriesNumber)
    End Sub

    Public Sub SetSpectrumFormNormalizeOnLoadOrPaste(blnEnable As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.SetNormalizeOnLoadOrPaste(blnEnable)
    End Sub

    Public Sub SetSpectrumFormNormalizationConstant(dblNewNormalizationConstant As Double)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.SetNormalizationConstant(dblNewNormalizationConstant)
    End Sub

    Public Sub SetSpectrumFormWindowPos(Top As Integer, intLeft As Integer, Height As Integer, Width As Integer)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.SetWindowPos(Top, intLeft, Height, Width)
    End Sub

    Public Sub SetSpectrumFormWindowCaption(strTitle As String)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.SetWindowCaption(strTitle)
    End Sub
    Public Sub ShowAutoLabelPeaksDialog(Optional ByVal blnShowModal As Boolean = True)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ShowAutoLabelPeaksDialog(blnShowModal)
    End Sub

    Public Sub ShowZoomRangeDialog()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ShowZoomRangeDialog()
    End Sub

    Public Sub ShowHideControls(blnHideControlsFrame As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.ShowHideControls(blnHideControlsFrame)
    End Sub

    Public Sub ShowHideAnnotations(Optional ByVal blnForceOperation As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.ShowHideAnnotations(blnForceOperation)
    End Sub

    Public Sub InitializeSpectrum()
        ' Initialize SpectrumForm, if necessary
        If Not mSpectrumLoaded Then
            SpectrumForm = New frmOxySpectrum()
            mSpectrumLoaded = True
        End If
    End Sub
    Public Sub ShowSpectrum()

        ' Make sure SpectrumForm is initialized
        InitializeSpectrum()

        ' Show ShowSpectrum
        SpectrumForm.Show()
    End Sub

    Public Sub UnloadSpectrum()
        ' Close SpectrumForm and unload it

        On Error Resume Next
        If mSpectrumLoaded Then
            SpectrumForm.Close()
            SpectrumForm = Nothing
            mSpectrumLoaded = False
        End If

    End Sub

    Public Sub UpdateAllDynamicAnnotationCaptions()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.UpdateAllDynamicAnnotationCaptions()
    End Sub

    Public Sub ZoomOutFull(Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnAllowFixMinimumYAtZero As Boolean = True)
        SpectrumForm.ctlOxyPlot.ZoomOutFull(blnAddToZoomHistory, blnAllowFixMinimumYAtZero)
    End Sub

    Public Sub ZoomToPrevious()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.ZoomToPrevious()
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

    Public ReadOnly Property AppDate() As String
        Get
            AppDate = SPECTRUM_DLL_DATE
        End Get
    End Property

    Public ReadOnly Property AppVersion() As String
        Get
            AppVersion = System.Windows.Forms.Application.ProductVersion
        End Get
    End Property

    Public Sub New()
        MyBase.New()
        InitializeSpectrum()
    End Sub

    Protected Overrides Sub Finalize()
        UnloadSpectrum()
        MyBase.Finalize()
    End Sub

End Class