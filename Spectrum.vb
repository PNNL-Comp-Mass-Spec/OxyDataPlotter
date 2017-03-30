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

    Public Sub AutoLabelPeaks(intSeriesNumber As Integer, blnShowXPos As Boolean, blnShowYPos As Boolean, Optional ByVal lngCaptionAngle As Integer = 0, Optional ByVal blnIncludeArrow As Boolean = False, Optional ByVal blnHideInDenseRegions As Boolean = True, Optional ByVal lngMaxPeakCount As Integer = 100, Optional ByVal blnForceAsContinuousData As Boolean = False, Optional ByVal blnForceAsDiscreteData As Boolean = False)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.AutoLabelPeaks(intSeriesNumber, blnShowXPos, blnShowYPos, lngCaptionAngle, blnIncludeArrow, blnHideInDenseRegions, lngMaxPeakCount, blnForceAsContinuousData, blnForceAsDiscreteData)

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
        MyBase.New()
        InitializeSpectrum()
    End Sub

    End Sub

    Public Sub AutoScaleVisibleYNow()
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.AutoScaleVisibleYNow()
    End Sub

    ''' <summary>
    ''' Reset the X axis zoom / panning
    ''' </summary>
    Public Sub AutoScaleXNow()
        SpectrumForm.ctlOxyPlot.AutoScaleXNow()
    End Sub

    ''' <summary>
    ''' Reset the Y axis zoom / panning
    ''' </summary>
    Public Sub AutoScaleYNow()
        SpectrumForm.ctlOxyPlot.AutoScaleYNow()
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

    Public Sub CopyDataPointsToClipboardOrToString(seriesNumber As Integer, Optional ByRef strDataToCopy As String = "", Optional ByVal strDelim As String = vbTab, Optional ByVal blnCopyToClipboard As Boolean = True)
        ' If blnCopyToClipboard = False, then simply populates strDataToCopy

        Throw New NotImplementedException("Not implemented: CopyDataPointsToClipboardOrToString")
        ' ToDo: SpectrumForm.CopyDataPointsToClipboardOrToString(seriesNumber, strDataToCopy, strDelim, blnCopyToClipboard)
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

    Public Sub GenerateSineWave(seriesNumber As Integer, blnXAxisLogBased As Boolean)
        SpectrumForm.ctlOxyPlot.GenerateSineWave(seriesNumber, blnXAxisLogBased)
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

    Public Function GetAnnotationCount() As Integer
        Return SpectrumForm.ctlOxyPlot.GetAnnotationCount()
    End Function

    <Obsolete("Use SetAnnotation")>
    Public Function GenerateAnnotationUsingNearestPoint(ByRef dblCaptionXPos As Double, ByRef dblCaptionYPos As Double, ByRef seriesNumber As Integer, ByRef blnAnnotationShowsNearestPointX As Boolean, ByRef blnAnnotationShowsNearestPointY As Boolean, ByRef blnBindToPoint As Boolean, ByRef strCurrentCaption As String, Optional ByRef lngPointNumberOverride As Integer = -1) As String
        Throw New NotImplementedException("Not implemented: GenerateAnnotationUsingNearestPoint")
        ' ToDo: GenerateAnnotationUsingNearestPoint = SpectrumForm.ctlOxyPlot.GenerateAnnotationUsingNearestPoint(dblCaptionXPos, dblCaptionYPos, seriesNumber, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnBindToPoint, strCurrentCaption, lngPointNumberOverride)
    End Function

    Public Function GetAnnotationDensityAutoHideCaptions() As Boolean
        Throw New NotImplementedException("Not implemented: GetAnnotationDensityAutoHideCaptions")
        ' ToDo: GetAnnotationDensityAutoHideCaptions = SpectrumForm.ctlOxyPlot.GetAnnotationDensityAutoHideCaptions()
    End Function

    Public Function GetAnnotationByIndex(annotationIndex As Integer) As Annotations.Annotation
        Return SpectrumForm.ctlOxyPlot.GetAnnotationByIndex(annotationIndex)
    End Function

    'Public Function GetAnnotationByName(strAnnotationName As String, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, ByRef strCaptionText As String, Optional ByRef lngCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Integer = 0, Optional ByRef eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint, Optional ByRef lngPointNumberToBind As Integer = 0, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = False, Optional ByRef strAnnotationNameReturn As String = "", Optional ByRef blnCaseSensitive As Boolean = False) As Boolean
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

    Public Function GetDataCount(seriesNumber As Integer) As Integer
        GetDataCount = SpectrumForm.ctlOxyPlot.GetDataCount(seriesNumber)
    End Function

    Public Function GetDataXvsY(seriesNumber As Integer) As List(Of DataPoint)
        Return SpectrumForm.ctlOxyPlot.GetDataXvsY(seriesNumber)
    End Function

    Public Function GetDefaultSeriesColor(intSeriesNumber As Integer) As Color
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

    ''' <summary>
    ''' Update minimum and maximum with the range of the X axis
    ''' </summary>
    ''' <param name="visibleDataOnly">
    ''' When true, return the range of visible data based on the current zoom level
    ''' When false, return the range of all data on the plot
    ''' </param>
    ''' <param name="minimum"></param>
    ''' <param name="maximum"></param>
    ''' <returns>Returns maximum minus minimum</returns>
    Public Function GetRangeX(visibleDataOnly As Boolean, <Out()> ByRef minimum As Double, <Out()> ByRef maximum As Double) As Double
        Return SpectrumForm.ctlOxyPlot.GetRangeX(visibleDataOnly, minimum, maximum)
    End Function

    ''' <summary>
    ''' Update minimum and maximum with the range of the Y axis
    ''' </summary>
    ''' <param name="visibleDataOnly">
    ''' When true, return the range of visible data based on the current zoom level
    ''' When false, return the range of all data on the plot
    ''' </param>
    ''' <param name="minimum"></param>
    ''' <param name="maximum"></param>
    ''' <returns>Returns maximum minus minimum</returns>
    Public Function GetRangeY(visibleDataOnly As Boolean, <Out()> ByRef minimum As Double, <Out()> ByRef maximum As Double) As Double
        Return SpectrumForm.ctlOxyPlot.GetRangeY(visibleDataOnly, minimum, maximum)
    End Function

    Public Function GetSeriesCount() As Integer
        GetSeriesCount = SpectrumForm.ctlOxyPlot.GetSeriesCount()
    End Function

    Public Function GetSeriesLegendCaption(intSeriesNumber As Integer) As String
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLegendCaption(intSeriesNumber)
    End Function

    Public Function GetSeriesLineColor(intSeriesNumber As Integer) As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineColor(intSeriesNumber)
    End Function

    Public Function GetSeriesLineToBaseColor(intSeriesNumber As Integer) As Color
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineToBaseColor(intSeriesNumber)
    End Function

    Public Function GetSeriesLineStyle(intSeriesNumber As Integer) As OxyPlot.LineStyle
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineStyle(intSeriesNumber)
    End Function

    Public Function GetSeriesLineWidth(intSeriesNumber As Integer) As Short
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineWidth(intSeriesNumber)
    End Function

    Public Function GetSeriesOriginalIntensityMaximum(intSeriesNumber As Integer) As Double
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesOriginalIntensityMaximum(intSeriesNumber)
    End Function

    Public Function GetSeriesPlotMode(intSeriesNumber As Integer) As ctlOxyPlotControl.pmPlotModeConstants
        Throw New NotImplementedException
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesPlotMode(intSeriesNumber)
    End Function

    Public Function GetSeriesPointColor(seriesNumber As Integer) As Color
        Return SpectrumForm.ctlOxyPlot.GetSeriesPointColor(seriesNumber)
    End Function

    Public Function GetSeriesPointStyle(seriesNumber As Integer) As OxyPlot.MarkerType
        Return SpectrumForm.ctlOxyPlot.GetSeriesPointStyle(seriesNumber)
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

    ''' <summary>
    ''' Find the data point closes to searchPosX,searchPosY
    ''' </summary>
    ''' <param name="searchPosX"></param>
    ''' <param name="searchPosY"></param>
    ''' <param name="seriesNumber">Either the series to search if limitToGivenSeriesNumber is true, or the matched series number of limitToGivenSeriesNumber is false</param>
    ''' <param name="distanceToClosestSeriesNumberDataPoint">Output: distance from the search point to the matched point</param>
    ''' <param name="limitToGivenSeriesNumber">When true, only examine data for series seriesNumber</param>
    ''' <returns>Data point index in series seriesNumber</returns>
    ''' <remarks>Data for the series is accessible via GetDataXvsY</remarks>
    Public Function LookupNearestPointNumber(searchPosX As Double, searchPosY As Double, ByRef seriesNumber As Integer, <Out()> ByRef distanceToClosestSeriesNumberDataPoint As Double, Optional limitToGivenSeriesNumber As Boolean = False) As Integer
        Return SpectrumForm.ctlOxyPlot.LookupNearestPointNumber(searchPosX, searchPosY, seriesNumber, distanceToClosestSeriesNumberDataPoint, limitToGivenSeriesNumber)
    End Function

    Public Sub PasteDataFromClipboard(Optional ByVal blnShowMessages As Boolean = True, Optional ByVal blnAllowCommaDelimeter As Boolean = True)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.PasteDataFromClipboard(blnShowMessages, blnAllowCommaDelimeter)
    End Sub

    Public Function RemoveAnnotationByCaption(strAnnotationText As String, Optional ByVal blnCaseSensitive As Boolean = False) As Boolean
        Throw New NotImplementedException
        ' ToDo: RemoveAnnotationByCaption = SpectrumForm.ctlOxyPlot.RemoveAnnotationByCaption(strAnnotationText, blnCaseSensitive)
    End Function

    Public Sub RemoveAnnotationByIndex(annotationIndex As Integer)
        SpectrumForm.ctlOxyPlot.RemoveAnnotationByIndex(annotationIndex)
    End Sub

    Public Sub RemoveAllAnnotations()
        SpectrumForm.ctlOxyPlot.RemoveAllAnnotations()
    End Sub

    Public Sub RemoveAnnotationsForSeries(seriesNumber As Integer)
        SpectrumForm.ctlOxyPlot.RemoveAnnotationsForSeries(seriesNumber)
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

    'Public Function SetAnnotation(blnPromptForText As Boolean, CaptionXPos As Double, CaptionYPos As Double, Optional ByVal strCaptionText As String = "", Optional ByVal lngCaptionAngle As Integer = 0, Optional ByVal intSeriesNumber As Integer = 1, Optional ByVal eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional ByVal lngPointNumberToBind As Integer = -1, Optional ByVal blnAnnotationShowsNearestPointX As Boolean = False, Optional ByVal blnAnnotationShowsNearestPointY As Boolean = False, Optional ByVal blnIncludeArrow As Boolean = False, Optional ByVal blnHideInDenseRegions As Boolean = True, Optional ByVal lngAnnotationIndexForce As Integer = 0, Optional ByVal blnAutomaticCaptionPlacement As Boolean = False) As Integer
    '    ' Adds a new annotation
    '    '  or updates an existing one of lngAnnotationIndexForce is > 0
    '    ' Returns the index of the annotation (.Annotations is 1-based)
    '    ' Returns 0 if an annotation is removed or the change is cancelled
    '    ' Use lngAnnotationIndexForce to force editing of an existing annotation

    '    Throw New NotImplementedException
    '    ' ToDo: SetAnnotation = SpectrumForm.ctlOxyPlot.SetAnnotation(blnPromptForText, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, lngAnnotationIndexForce, blnAutomaticCaptionPlacement)
    'End Function

    'Public Function SetAnnotationByIndex(lngAnnotationIndex As Integer, CaptionXPos As Double, CaptionYPos As Double, Optional ByVal strCaptionText As String = "", Optional ByVal lngCaptionAngle As Integer = 0, Optional ByVal intSeriesNumber As Integer = 1, Optional ByVal eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional ByVal lngPointNumberToBind As Integer = 0, Optional ByVal blnAnnotationShowsNearestPointX As Boolean = False, Optional ByVal blnAnnotationShowsNearestPointY As Boolean = False, Optional ByVal blnIncludeArrow As Boolean = False, Optional ByVal blnHideInDenseRegions As Boolean = True, Optional ByVal blnAutomaticCaptionPlacement As Boolean = False, Optional ByVal strReturnAnnotationName As String = "") As Boolean
    '    Throw New NotImplementedException
    '    ' ToDo: SetAnnotationByIndex = SpectrumForm.ctlOxyPlot.SetAnnotationByIndex(lngAnnotationIndex, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, blnAutomaticCaptionPlacement, strReturnAnnotationName)
    'End Function

    ''' <summary>
    ''' Add an annotation at the given X,Y coordinate
    ''' </summary>
    ''' <param name="locationX"></param>
    ''' <param name="locationY"></param>
    ''' <param name="caption"></param>
    ''' <param name="eLineStyle"></param>
    ''' <param name="lineWidth"></param>
    ''' <param name="fontSize"></param>
    Public Sub SetAnnotationByXY(
      locationX As Double, locationY As Double, caption As String,
      Optional eLineStyle As LineStyle = LineStyle.Automatic,
      Optional lineWidth As Integer = 32,
      Optional fontSize As Integer = 12)

        SpectrumForm.ctlOxyPlot.SetAnnotationByXY(locationX, locationY, caption, eLineStyle, lineWidth, fontSize)
    End Sub

    ''' <summary>
    ''' Add an annotation the closest data point on the given series
    ''' </summary>
    ''' <param name="seriesNumber"></param>
    ''' <param name="locationX"></param>
    ''' <param name="locationY"></param>
    ''' <param name="caption"></param>
    ''' <param name="eLineStyle"></param>
    ''' <param name="lineWidth"></param>
    ''' <param name="fontSize"></param>
    Public Sub SetAnnotationForDataPoint(
      seriesNumber As Integer, locationX As Double, locationY As Double, caption As String,
      Optional eLineStyle As LineStyle = LineStyle.Automatic,
      Optional lineWidth As Integer = 32,
      Optional fontSize As Integer = 12)

        SpectrumForm.ctlOxyPlot.SetAnnotationForDataPoint(seriesNumber, locationX, locationY, caption, eLineStyle, lineWidth, fontSize)
    End Sub

    Public Sub SetAnnotationFontSize(intSeriesNumber As Integer, intNewSize As Short, blnMakeDefaultForAll As Boolean)
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

    Public Sub SetDataXvsY(seriesNumber As Integer, ByRef XDataZeroBased1DArray() As Double, ByRef YDataZeroBased1DArray() As Double, DataCount As Integer, Optional ByVal strSeriesTitle As String = "", Optional ByVal dblOriginalMaximumIntensity As Double = 0)
        SpectrumForm.ctlOxyPlot.SetDataXvsY(seriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, DataCount, strSeriesTitle)
    End Sub

    Public Sub SetDataYOnly(seriesNumber As Integer, ByRef YDataZeroBased1DArray() As Double, YDataCount As Integer, Optional ByVal dblXFirst As Double = 0, Optional ByVal dblIncrement As Double = 1, Optional ByVal strSeriesTitle As String = "", Optional ByVal dblOriginalMaximumIntensity As Double = 0)
        SpectrumForm.ctlOxyPlot.SetDataYOnly(seriesNumber, YDataZeroBased1DArray, YDataCount, dblXFirst, dblIncrement, strSeriesTitle)
    End Sub

    Public Sub SetDisplayPrecisionX(intPrecision As Short)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetDisplayPrecisionX(intPrecision)
    End Sub

    Public Sub SetDisplayPrecisionY(intPrecision As Short)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.ctlOxyPlot.SetDisplayPrecisionY(intPrecision)
    End Sub

    Public Sub SetGridLinesStyleX(majorGridlineStyle As ctlOxyPlotControl.udtGridlineStyle)
        SpectrumForm.ctlOxyPlot.SetGridLinesStyleX(majorGridlineStyle)
    End Sub

    Public Sub SetGridLinesStyleX(majorGridlineStyle As ctlOxyPlotControl.udtGridlineStyle, minorGridlineStyle As ctlOxyPlotControl.udtGridlineStyle)
        SpectrumForm.ctlOxyPlot.SetGridLinesStyleX(majorGridlineStyle, minorGridlineStyle)
    End Sub

    Public Sub SetGridLinesStyleY(majorGridlineStyle As ctlOxyPlotControl.udtGridlineStyle)
        SpectrumForm.ctlOxyPlot.SetGridLinesStyleY(majorGridlineStyle)
    End Sub

    Public Sub SetGridLinesStyleY(majorGridlineStyle As ctlOxyPlotControl.udtGridlineStyle, minorGridlineStyle As ctlOxyPlotControl.udtGridlineStyle)
        SpectrumForm.ctlOxyPlot.SetGridLinesStyleY(majorGridlineStyle, minorGridlineStyle)
    End Sub

    Public Sub SetGridLinesXVisible(showGridLines As Boolean, includeMinorGridLines As Boolean)
        SpectrumForm.ctlOxyPlot.SetGridLinesVisibleX(showGridLines, includeMinorGridLines)
    End Sub

    Public Sub SetGridLinesYVisible(showGridLines As Boolean, includeMinorGridLines As Boolean)
        SpectrumForm.ctlOxyPlot.SetGridLinesVisibleY(showGridLines, includeMinorGridLines)
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
        SpectrumForm.ctlOxyPlot.SetPlotBackgroundColor(cNewColor)
    End Sub

    ''' <summary>
    ''' Update the visible X axis range
    ''' </summary>
    ''' <param name="minimum"></param>
    ''' <param name="maximum"></param>
    Public Sub SetRangeX(minimum As Double, maximum As Double)
        SpectrumForm.ctlOxyPlot.SetRangeX(minimum, maximum)
    End Sub

    ''' <summary>
    ''' Update the visible Y axis range
    ''' </summary>
    ''' <param name="minimum"></param>
    ''' <param name="maximum"></param>
    Public Sub SetRangeY(minimum As Double, maximum As Double)
        SpectrumForm.ctlOxyPlot.SetRangeY(minimum, maximum)
    End Sub

    Public Sub SetSeriesColor(seriesNumber As Integer, cNewColor As Color)
        SpectrumForm.ctlOxyPlot.SetSeriesColor(seriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesCount(intCount As Short)
        SpectrumForm.ctlOxyPlot.SetSeriesCount(intCount)
    End Sub

    Public Sub SetSeriesLegendCaption(seriesNumber As Integer, strNewCaption As String)
        SpectrumForm.ctlOxyPlot.SetSeriesLegendCaption(seriesNumber, strNewCaption)
    End Sub

    Public Sub SetSeriesLineColor(seriesNumber As Integer, cNewColor As Color)
        SpectrumForm.ctlOxyPlot.SetSeriesLineColor(seriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesLineToBaseColor(seriesNumber As Integer, cNewColor As Color)
        Throw New NotImplementedException("Not implemented: SetSpectrumFormNormalizeOnLoadOrPaste")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesLineToBaseColor(seriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesLineStyle(seriesNumber As Integer, eLineStyle As OxyPlot.LineStyle)
        SpectrumForm.ctlOxyPlot.SetSeriesLineStyle(seriesNumber, eLineStyle)
    End Sub

    Public Sub SetSeriesLineWidth(seriesNumber As Integer, lineWidth As Double)
        SpectrumForm.ctlOxyPlot.SetSeriesLineWidth(seriesNumber, lineWidth)
    End Sub

    Public Sub SetSeriesOriginalIntensityMaximum(seriesNumber As Integer, dblNewOriginalMaximumIntensity As Double)
        Throw New NotImplementedException("Not implemented: SetSeriesOriginalIntensityMaximum")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesOriginalIntensityMaximum(seriesNumber, dblNewOriginalMaximumIntensity)
    End Sub

    Public Sub SetSeriesPlotMode(seriesNumber As Integer, ePlotMode As ctlOxyPlotControl.pmPlotModeConstants, blnMakeDefault As Boolean)
        SpectrumForm.ctlOxyPlot.SetSeriesPlotMode(seriesNumber, ePlotMode, blnMakeDefault)
    End Sub

    Public Sub SetSeriesPointColor(seriesNumber As Integer, cNewColor As Color)
        SpectrumForm.ctlOxyPlot.SetSeriesPointColor(seriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesPointStyle(seriesNumber As Integer, ePointStyle As OxyPlot.MarkerType)
        SpectrumForm.ctlOxyPlot.SetSeriesPointStyle(seriesNumber, ePointStyle)
    End Sub

    Public Sub SetSeriesStartAndIncrement(seriesNumber As Integer, dblXFirst As Double, dblIncrement As Double)
        Throw New NotImplementedException("Not implemented: SetSeriesStartAndIncrement")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetSeriesStartAndIncrement(seriesNumber, dblXFirst, dblIncrement)
    End Sub

    Public Sub SetSeriesVisible(seriesNumber As Integer, blnShowSeries As Boolean)
        SpectrumForm.ctlOxyPlot.SetSeriesVisible(seriesNumber, blnShowSeries)
    End Sub

    Public Sub SetSpectrumFormCurrentSeriesNumber(seriesNumber As Integer)
        SpectrumForm.SetCurrentSeriesNumber(seriesNumber)
    End Sub

    Public Sub SetSpectrumFormNormalizeOnLoadOrPaste(blnEnable As Boolean)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.SetNormalizeOnLoadOrPaste(blnEnable)
    End Sub

    Public Sub SetSpectrumFormNormalizationConstant(dblNewNormalizationConstant As Double)
        Throw New NotImplementedException
        ' ToDo: SpectrumForm.SetNormalizationConstant(dblNewNormalizationConstant)
    End Sub

    Public Sub SetSpectrumFormWindowCaption(strTitle As String)
        SpectrumForm.SetWindowCaption(strTitle)
    End Sub

    Public Sub SetSpectrumFormWindowPos(topLeftX As Integer, topLeftY As Integer, windowHeight As Integer, windowWidth As Integer)
        SpectrumForm.SetWindowPos(topLeftX, topLeftY, windowHeight, windowWidth)
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

    Protected Overrides Sub Finalize()
        UnloadSpectrum()
        MyBase.Finalize()
    End Sub

End Class