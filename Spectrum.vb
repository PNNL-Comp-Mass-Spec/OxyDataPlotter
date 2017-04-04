Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports OxyDataPlotter.ctlOxyPlotControl
Imports OxyPlot

' -------------------------------------------------------------------------------
' Written by Matthew Monroe for the Department of Energy (PNNL, Richland, WA)
' Upgraded to VB.NET from VB6 in October 2003
' Converted to use OxyPlot in 2017
' Copyright 2005, Battelle Memorial Institute.  All Rights Reserved.

' E-mail: matthew.monroe@pnnl.gov or matt@alchemistmatt.com
' Website: http://panomics.pnl.gov/ or http://www.sysbio.org/resources/staff/
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

#Region "Structures"

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

#End Region


#Region "Properties"
    Public Property AutoscaleXAxis As Boolean
        Get
            Return SpectrumForm.ctlOxyPlot.AutoscaleXAxis
        End Get
        Set(value As Boolean)
            SpectrumForm.ctlOxyPlot.AutoscaleXAxis = value
        End Set
    End Property

    Public Property AutoscaleYAxis As Boolean
        Get
            Return SpectrumForm.ctlOxyPlot.AutoscaleYAxis
        End Get
        Set(value As Boolean)
            SpectrumForm.ctlOxyPlot.AutoscaleYAxis = value
        End Set
    End Property

    Public Property XAxisAbsoluteMinimum As Double
        Get
            Return SpectrumForm.ctlOxyPlot.XAxisAbsoluteMinimum
        End Get
        Set(value As Double)
            SpectrumForm.ctlOxyPlot.XAxisAbsoluteMinimum = value
        End Set
    End Property

    Public Property XAxisAbsoluteMaximum As Double
        Get
            Return SpectrumForm.ctlOxyPlot.XAxisAbsoluteMaximum
        End Get
        Set(value As Double)
            SpectrumForm.ctlOxyPlot.XAxisAbsoluteMaximum = value
        End Set
    End Property

    Public Property YAxisAbsoluteMinimum As Double
        Get
            Return SpectrumForm.ctlOxyPlot.YAxisAbsoluteMinimum
        End Get
        Set(value As Double)
            SpectrumForm.ctlOxyPlot.YAxisAbsoluteMinimum = value
        End Set
    End Property

    Public Property YAxisAbsoluteMaximum As Double
        Get
            Return SpectrumForm.ctlOxyPlot.YAxisAbsoluteMaximum
        End Get
        Set(value As Double)
            SpectrumForm.ctlOxyPlot.YAxisAbsoluteMaximum = value
        End Set
    End Property

    Public Property XAxisPaddingMinimum As Double
        Get
            Return SpectrumForm.ctlOxyPlot.XAxisPaddingMinimum
        End Get
        Set(value As Double)
            SpectrumForm.ctlOxyPlot.XAxisPaddingMinimum = value
        End Set
    End Property

    Public Property XAxisPaddingMaximum As Double
        Get
            Return SpectrumForm.ctlOxyPlot.XAxisPaddingMaximum
        End Get
        Set(value As Double)
            SpectrumForm.ctlOxyPlot.XAxisPaddingMaximum = value
        End Set
    End Property

    Public Property YAxisPaddingMinimum As Double
        Get
            Return SpectrumForm.ctlOxyPlot.YAxisPaddingMinimum
        End Get
        Set(value As Double)
            SpectrumForm.ctlOxyPlot.YAxisPaddingMinimum = value
        End Set
    End Property

    Public Property YAxisPaddingMaximum As Double
        Get
            Return SpectrumForm.ctlOxyPlot.YAxisPaddingMaximum
        End Get
        Set(value As Double)
            SpectrumForm.ctlOxyPlot.YAxisPaddingMaximum = value
        End Set
    End Property

#End Region

#Region "Member variables"
    ' Actual spectrum form
    Private WithEvents SpectrumForm As frmOxySpectrum
    Private mSpectrumLoaded As Boolean

#End Region

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
        MyBase.New()
        InitializeSpectrum()
    End Sub

    Public Sub AutoLabelPeaks(seriesNumber As Integer, blnShowXPos As Boolean, blnShowYPos As Boolean, Optional lngCaptionAngle As Integer = 0, Optional blnIncludeArrow As Boolean = False, Optional blnHideInDenseRegions As Boolean = True, Optional lngMaxPeakCount As Integer = 100, Optional blnForceAsContinuousData As Boolean = False, Optional blnForceAsDiscreteData As Boolean = False)
        Throw New NotImplementedException("Not implemented: AutoLabelPeaks")
        ' ToDo: SpectrumForm.ctlOxyPlot.AutoLabelPeaks(seriesNumber, blnShowXPos, blnShowYPos, lngCaptionAngle, blnIncludeArrow, blnHideInDenseRegions, lngMaxPeakCount, blnForceAsContinuousData, blnForceAsDiscreteData)
    End Sub

    Public Sub AutoScaleVisibleYNow()
        Throw New NotImplementedException("Not implemented: AutoScaleVisibleYNow")
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

    Public Sub CenterCursors(Optional intCursorNumber As Integer = 1, Optional blncenterAll As Boolean = True)
        Throw New NotImplementedException("Not implemented: CenterCursors")
        ' ToDo: SpectrumForm.ctlOxyPlot.CenterCursor(intCursorNumber, blncenterAll)
    End Sub

    Public Sub ClearData(intSeriesToClear As Short)
        ' This does not prompt the user
        SpectrumForm.ctlOxyPlot.ClearData(intSeriesToClear)
    End Sub

    Public Sub ClearDataAllSeries()
        ' This does not prompt the user
        SpectrumForm.DeleteDataForAllSeries(True, False)
    End Sub

    Public Sub CopyDataPointsToClipboardOrToString(seriesNumber As Integer, Optional ByRef strDataToCopy As String = "", Optional strDelim As String = vbTab, Optional blnCopyToClipboard As Boolean = True)
        ' If blnCopyToClipboard = False, then simply populates strDataToCopy

        Throw New NotImplementedException("Not implemented: CopyDataPointsToClipboardOrToString")
        ' ToDo: SpectrumForm.CopyDataPointsToClipboardOrToString(seriesNumber, strDataToCopy, strDelim, blnCopyToClipboard)
    End Sub

    Public Sub CopyToClipboardAsPicture()
        Throw New NotImplementedException("Not implemented: CopyToClipboardAsPicture")
        ' ToDo: SpectrumForm.CopyToClipboardAsPicture()
    End Sub

    Public Property DateModeXAxis() As Boolean
        Get
            Throw New NotImplementedException("Not implemented: DateModeXAxis")
            ' ToDo: Return SpectrumForm.ctlOxyPlot.DateModeXAxis
        End Get
        Set(Value As Boolean)
            Throw New NotImplementedException("Not implemented: DateModeXAxis")
            ' ToDo: SpectrumForm.ctlOxyPlot.DateModeXAxis = Value
        End Set
    End Property

    Public Property DateModeXAxisShowTime() As Boolean
        Get
            Throw New NotImplementedException("Not implemented: DateModeXAxisShowTime")
            ' ToDo: Return SpectrumForm.ctlOxyPlot.DateModeXAxisShowTime
        End Get
        Set(Value As Boolean)
            Throw New NotImplementedException("Not implemented: DateModeXAxisShowTime")
            ' ToDo: SpectrumForm.ctlOxyPlot.DateModeXAxisShowTime = Value
        End Set
    End Property

    ''' <summary>
    ''' Clear data for the active series, optionally removing the series entirely
    ''' </summary>
    ''' <param name="removeSeries">If false, removes the data points for the series, but does not remove the series</param>
    ''' <param name="confirmDeletion"></param>
    Public Sub DeleteDataActiveSeries(removeSeries As Boolean, Optional confirmDeletion As Boolean = False)
        SpectrumForm.DeleteDataActiveSeries(removeSeries, confirmDeletion)
    End Sub

    ''' <summary>
    ''' Clear data for all series, optionally removing the series entirely
    ''' </summary>
    ''' <param name="removeSeries">If false, removes the data points for the series, but does not remove the series</param>
    ''' <param name="confirmDeletion"></param>
    Public Sub DeleteDataForAllSeries(removeSeries As Boolean, Optional confirmDeletion As Boolean = False)
        SpectrumForm.DeleteDataForAllSeries(removeSeries, confirmDeletion)
    End Sub

    Public Sub EnableTrackAnnotationPlacement()
        Throw New NotImplementedException("Not implemented: EnableTrackAnnotationPlacement")
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackAnnotationPlacement()
    End Sub

    Public Sub EnableTrackCursor()
        Throw New NotImplementedException("Not implemented: EnableTrackCursor")
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackCursor()
    End Sub

    Public Sub EnableTrackModeAllEvents()
        Throw New NotImplementedException("Not implemented: EnableTrackModeAllEvents")
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackModeAllEvents()
    End Sub

    Public Sub EnableTrackModePan(Optional blnPanXOnly As Boolean = False, Optional blnPanYOnly As Boolean = False)
        Throw New NotImplementedException("Not implemented: EnableTrackModePan")
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackModePan(blnPanXOnly, blnPanYOnly)
    End Sub

    Public Sub EnableTrackModeZoom(Optional blnZoomXOnly As Boolean = False, Optional blnZoomYOnly As Boolean = False)
        Throw New NotImplementedException("Not implemented: EnableTrackModeZoom")
        ' ToDo: SpectrumForm.ctlOxyPlot.EnableTrackModeZoom(blnZoomXOnly, blnZoomYOnly)
    End Sub

    Public Sub GenerateSineWave(seriesNumber As Integer, blnXAxisLogBased As Boolean)
        SpectrumForm.ctlOxyPlot.GenerateSineWave(seriesNumber, blnXAxisLogBased)
    End Sub

    Public Function GetAnnotationFontColor(intSeriesIndex As Short) As Color
        Throw New NotImplementedException("Not implemented: GetAnnotationFontColor")
        ' ToDo: GetAnnotationFontColor = SpectrumForm.ctlOxyPlot.GetAnnotationFontColor(intSeriesIndex)
    End Function

    Public Function GetAnnotationFontName(intSeriesIndex As Short) As String
        Throw New NotImplementedException("Not implemented: GetAnnotationFontName")
        ' ToDo: GetAnnotationFontName = SpectrumForm.ctlOxyPlot.GetAnnotationFontName(intSeriesIndex)
    End Function

    Public Function GetAnnotationFontSize(intSeriesIndex As Short) As Short
        Throw New NotImplementedException("Not implemented: GetAnnotationFontSize")
        ' ToDo: GetAnnotationFontSize = SpectrumForm.ctlOxyPlot.GetAnnotationFontSize(intSeriesIndex)
    End Function

    Public Function GetAnnotationDensityToleranceAutoAdjust() As Boolean
        Throw New NotImplementedException("Not implemented: GetAnnotationDensityToleranceAutoAdjust")
        ' ToDo: GetAnnotationDensityToleranceAutoAdjust = SpectrumForm.ctlOxyPlot.GetAnnotationDensityToleranceAutoAdjust()
    End Function

    Public Function GetAnnotationDensityToleranceX() As Double
        Throw New NotImplementedException("Not implemented: GetAnnotationDensityToleranceX")
        ' ToDo: GetAnnotationDensityToleranceX = SpectrumForm.ctlOxyPlot.GetAnnotationDensityToleranceX()
    End Function

    Public Function GetAnnotationDensityToleranceY() As Double
        Throw New NotImplementedException("Not implemented: GetAnnotationDensityToleranceY")
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

    'Public Function GetAnnotationByName(strAnnotationName As String, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, ByRef strCaptionText As String, Optional ByRef lngCaptionAngle As Integer = 0, Optional ByRef seriesNumber As Integer = 0, Optional ByRef eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint, Optional ByRef lngPointNumberToBind As Integer = 0, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = False, Optional ByRef strAnnotationNameReturn As String = "", Optional ByRef blnCaseSensitive As Boolean = False) As Boolean
    '    Throw New NotImplementedException("Not implemented: GetAnnotationByName")
    '    ' ToDo: GetAnnotationByName = SpectrumForm.ctlOxyPlot.GetAnnotationByName(strAnnotationName, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, seriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, strAnnotationNameReturn, blnCaseSensitive)
    'End Function

    Public Function GetAutoAdjustScalingToIncludeCaptions() As Boolean
        Throw New NotImplementedException("Not implemented: GetAutoAdjustScalingToIncludeCaptions")
        ' ToDo: GetAutoAdjustScalingToIncludeCaptions = SpectrumForm.ctlOxyPlot.GetAutoAdjustScalingToIncludeCaptions()
    End Function

    Public Sub GetAutoLabelPeaksOptions(ByRef udtAutoLabelPeaksOptions As udtAutoLabelPeaksOptionsType)
        Throw New NotImplementedException("Not implemented: GetAutoLabelPeaksOptions")

        'Dim udtAutoLabelPeaksOptionsInternal As udtAutoLabelPeaksOptionsInternalType

        'Throw New NotImplementedException("Not implemented: GetAutoLabelPeaksOptions")
        '' ToDo: SpectrumForm.StoreAutoLabelPeaksOptionsInModule()

        'AutoLabelOptionsRetrieve(udtAutoLabelPeaksOptionsInternal)

        'With udtAutoLabelPeaksOptionsInternal
        '    udtAutoLabelPeaksOptions.CaptionAngle = .CaptionAngle
        '    udtAutoLabelPeaksOptions.DisplayXPos = .DisplayXPos
        '    udtAutoLabelPeaksOptions.DisplayYPos = .DisplayYPos
        '    udtAutoLabelPeaksOptions.HideInDenseRegions = .HideInDenseRegions
        '    udtAutoLabelPeaksOptions.IncludeArrow = .IncludeArrow
        '    udtAutoLabelPeaksOptions.IntensityThresholdMinimum = .IntensityThresholdMinimum
        '    If .DataMode = modCWSpectrum.dmDataModeConstants.dmContinuous Then
        '        udtAutoLabelPeaksOptions.IsContinuousData = True
        '    Else
        '        udtAutoLabelPeaksOptions.IsContinuousData = False
        '    End If
        '    udtAutoLabelPeaksOptions.MinimumIntensityPercentageOfMaximum = .MinimumIntensityPercentageOfMaximum
        '    udtAutoLabelPeaksOptions.PeakLabelCountMaximum = .PeakLabelCountMaximum
        '    udtAutoLabelPeaksOptions.PeakWidthMinimumPoints = .PeakWidthMinimumPoints
        'End With

    End Sub

    Public Function GetAutoscaleVisibleY() As Boolean
        Throw New NotImplementedException("Not implemented: GetAutoscaleVisibleY")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetAutoscaleVisibleY()
    End Function

    Public Function GetControlImage() As System.Drawing.Image
        ' Returns an image of the graph, in the form of a Windows MetaFile
        Throw New NotImplementedException("Not implemented: GetControlImage")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetControlImage()
    End Function

    Public Function GetCursorSnapToDataPointModeEnabled() As Boolean
        Throw New NotImplementedException("Not implemented: GetCursorSnapToDataPointModeEnabled")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetCursorSnapToDataPointModeEnabled()
    End Function

    Public Function GetCursorColor(Optional intCursorNumber As Integer = 1) As Color
        Throw New NotImplementedException("Not implemented: GetCursorColor")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetCursorColor(intCursorNumber)
    End Function

    Public Sub GetCursorPosition(ByRef XPos As Double, ByRef YPos As Double, Optional intCursorNumber As Integer = 1)
        Throw New NotImplementedException("Not implemented: GetCursorPosition")
        ' ToDo: SpectrumForm.ctlOxyPlot.GetCursorPosition(XPos, YPos, intCursorNumber)
    End Sub

    Public Function GetCursorVisibility(Optional intCursorNumber As Integer = 1) As Boolean
        Throw New NotImplementedException("Not implemented: GetCursorVisibility")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetCursorVisibility(intCursorNumber)
    End Function

    Public Function GetDataCount(seriesNumber As Integer) As Integer
        GetDataCount = SpectrumForm.ctlOxyPlot.GetDataCount(seriesNumber)
    End Function

    Public Function GetDataXvsY(seriesNumber As Integer) As List(Of DataPoint)
        Return SpectrumForm.ctlOxyPlot.GetDataXvsY(seriesNumber)
    End Function

    Public Function GetDefaultSeriesColor(seriesNumber As Integer) As Color
        Throw New NotImplementedException("Not implemented: GetDefaultSeriesColor")
        ' ToDo: Return  SpectrumForm.ctlOxyPlot.GetDefaultSeriesColor(seriesNumber)
    End Function

    Public Function GetDisplayPrecisionX() As Double
        Throw New NotImplementedException("Not implemented: GetDisplayPrecisionX")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetDisplayPrecisionX()
    End Function

    Public Function GetDisplayPrecisionY() As Double
        Throw New NotImplementedException("Not implemented: GetDisplayPrecisionY")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetDisplayPrecisionY()
    End Function

    Public Function GetFixMinimumYAtZero() As Boolean
        Throw New NotImplementedException("Not implemented: GetFixMinimumYAtZero")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetFixMinimumYAtZero()
    End Function

    Public Function GetLabelFontColor() As Color
        Throw New NotImplementedException("Not implemented: GetLabelFontColor")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelFontColor()
    End Function

    Public Function GetLabelFontName() As String
        Throw New NotImplementedException("Not implemented: GetLabelFontName")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelFontName()
    End Function

    Public Function GetLabelFontSize() As Short
        Throw New NotImplementedException("Not implemented: GetLabelFontSize")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelFontSize()
    End Function

    Public Function GetGridLinesXVisible(Optional blnMajorGridLines As Boolean = True) As Boolean
        Throw New NotImplementedException("Not implemented: GetGridLinesXVisible")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetGridLinesXVisible(blnMajorGridLines)
    End Function

    Public Function GetGridlinesYVisible(Optional blnMajorGridLines As Boolean = True) As Boolean
        Throw New NotImplementedException("Not implemented: GetGridlinesYVisible")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetGridlinesYVisible(blnMajorGridLines)
    End Function

    Public Function GetGridLinesXColor(Optional blnMajorGridLines As Boolean = True) As Color
        Throw New NotImplementedException("Not implemented: GetGridLinesXColor")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetGridLinesXColor(blnMajorGridLines)
    End Function

    Public Function GetGridLinesYColor(Optional blnMajorGridLines As Boolean = True) As Color
        Throw New NotImplementedException("Not implemented: GetGridLinesYColor")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetGridLinesYColor(blnMajorGridLines)
    End Function

    Public Function GetLabelSubtitle() As String
        Throw New NotImplementedException("Not implemented: GetLabelSubtitle")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelSubtitle()
    End Function

    Public Function GetLabelTitle() As String
        Throw New NotImplementedException("Not implemented: GetLabelTitle")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelTitle()
    End Function

    Public Function GetLabelXAxis() As String
        Throw New NotImplementedException("Not implemented: GetLabelXAxis")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelXAxis()
    End Function

    Public Function GetLabelYAxis() As String
        Throw New NotImplementedException("Not implemented: GetLabelYAxis")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetLabelYAxis()
    End Function

    Public Function GetPlotBackgroundColor() As Color
        Throw New NotImplementedException("Not implemented: GetPlotBackgroundColor")
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

    Public Function GetSeriesLegendCaption(seriesNumber As Integer) As String
        Throw New NotImplementedException("Not implemented: GetSeriesLegendCaption")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLegendCaption(seriesNumber)
    End Function

    Public Function GetSeriesLineColor(seriesNumber As Integer) As Color
        Throw New NotImplementedException("Not implemented: GetSeriesLineColor")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineColor(seriesNumber)
    End Function

    Public Function GetSeriesLineToBaseColor(seriesNumber As Integer) As Color
        Throw New NotImplementedException("Not implemented: GetSeriesLineToBaseColor")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineToBaseColor(seriesNumber)
    End Function

    Public Function GetSeriesLineStyle(seriesNumber As Integer) As OxyPlot.LineStyle
        Throw New NotImplementedException("Not implemented: GetSeriesLineStyle")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineStyle(seriesNumber)
    End Function

    Public Function GetSeriesLineWidth(seriesNumber As Integer) As Short
        Throw New NotImplementedException("Not implemented: GetSeriesLineWidth")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesLineWidth(seriesNumber)
    End Function

    Public Function GetSeriesOriginalIntensityMaximum(seriesNumber As Integer) As Double
        Throw New NotImplementedException("Not implemented: GetSeriesOriginalIntensityMaximum")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesOriginalIntensityMaximum(seriesNumber)
    End Function

    Public Function GetSeriesPlotMode(seriesNumber As Integer) As SeriesPlotMode
        Throw New NotImplementedException("Not implemented: GetSeriesPlotMode")
        ' ToDo: Return SpectrumForm.ctlOxyPlot.GetSeriesPlotMode(seriesNumber)
    End Function

    Public Function GetSeriesPointColor(seriesNumber As Integer) As Color
        Return SpectrumForm.ctlOxyPlot.GetSeriesPointColor(seriesNumber)
    End Function

    Public Function GetSeriesPointStyle(seriesNumber As Integer) As OxyPlot.MarkerType
        Return SpectrumForm.ctlOxyPlot.GetSeriesPointStyle(seriesNumber)
    End Function

    Public Function GetSpectrumFormActiveSeriesNumber() As Short
        Throw New NotImplementedException("Not implemented: GetSpectrumFormActiveSeriesNumber")
        ' ToDo: Return SpectrumForm.GetActiveSeriesNumber()
    End Function

    Public Function GetSpectrumFormNormalizeOnLoadOrPaste() As Boolean
        Throw New NotImplementedException("Not implemented: GetSpectrumFormNormalizeOnLoadOrPaste")
        ' ToDo: Return SpectrumForm.GetNormalizeOnLoadOrPaste()
    End Function

    Public Function GetSpectrumFormNormalizationConstant() As Double
        Throw New NotImplementedException("Not implemented: GetSpectrumFormNormalizationConstant")
        ' ToDo: Return SpectrumForm.GetNormalizationConstant()
    End Function

    Public Sub GetSpectrumFormWindowPos(ByRef Top As Integer, ByRef intLeft As Integer, ByRef Height As Integer, ByRef Width As Integer)
        Throw New NotImplementedException("Not implemented: GetSpectrumFormWindowPos")
        ' ToDo: SpectrumForm.GetWindowPos(Top, intLeft, Height, Width)
    End Sub

    Public Sub LoadDataFromDisk(Optional strInputFilePath As String = "", Optional blnShowMessages As Boolean = True, Optional blnLoadOptionsOnly As Boolean = False, Optional blnDelimeterComma As Boolean = True, Optional blnDelimeterTab As Boolean = True, Optional blnDelimeterSpace As Boolean = False, Optional blnLoadingDTAFile As Boolean = False)
        Throw New NotImplementedException("Not implemented: LoadDataFromDisk")
        ' ToDo: SpectrumForm.LoadDataFromDisk(strInputFilePath, blnShowMessages, blnLoadOptionsOnly, blnDelimeterComma, blnDelimeterTab, blnDelimeterSpace, blnLoadingDTAFile)
    End Sub

    ''' <summary>
    ''' Find the data point closest to searchPosX,searchPosY
    ''' Set limitToGivenSeriesNumber to true to only search series seriesNumber
    ''' Set limitToGivenSeriesNumber to false to search all series
    ''' </summary>
    ''' <param name="searchPosX"></param>
    ''' <param name="searchPosY"></param>
    ''' <param name="xAxisOnly">When true, only compare locationX to X axis values in the data</param>
    ''' <param name="seriesNumber">The series to search if limitToGivenSeriesNumber is true, otherwise ignored</param>
    ''' <param name="limitToGivenSeriesNumber">When true, only examine data for series seriesNumber</param>
    ''' <returns>Structure describing the closest data point</returns>
    Public Function LookupNearestPointNumber(
      searchPosX As Double,
      searchPosY As Double,
      xAxisOnly As Boolean,
      seriesNumber As Integer,
      limitToGivenSeriesNumber As Boolean) As udtDataPointSearchResult

        Return SpectrumForm.ctlOxyPlot.LookupNearestPointNumber(searchPosX, searchPosY, xAxisOnly, seriesNumber, limitToGivenSeriesNumber)

    End Function

    Public Sub PasteDataFromClipboard(Optional blnShowMessages As Boolean = True, Optional blnAllowCommaDelimeter As Boolean = True)
        Throw New NotImplementedException("Not implemented: PasteDataFromClipboard")
        ' ToDo: SpectrumForm.PasteDataFromClipboard(blnShowMessages, blnAllowCommaDelimeter)
    End Sub

    Public Function RemoveAnnotationByCaption(strAnnotationText As String, Optional blnCaseSensitive As Boolean = False) As Boolean
        Throw New NotImplementedException("Not implemented: RemoveAnnotationByCaption")
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

    Public Sub ResetOptionsToDefaults(Optional blnClearAllData As Boolean = False, Optional blnResetSeriesCount As Boolean = False, Optional intNewSeriesCount As Short = 2, Optional eDefaultPlotMode As SeriesPlotMode = SeriesPlotMode.Lines)
        ' This does not prompt the user
        Throw New NotImplementedException("Not implemented: ResetOptionsToDefaults")
        ' ToDo: SpectrumForm.ctlOxyPlot.ResetOptionsToDefaults(blnClearAllData, blnResetSeriesCount, intNewSeriesCount, eDefaultPlotMode)
    End Sub

    Public Sub RemoveSeries(seriesNumber As Integer)
        SpectrumForm.ctlOxyPlot.RemoveSeries(seriesNumber)
    End Sub

    Public Sub SaveDataToDisk(Optional strOutputFilePath As String = "", Optional blnOptionsOnly As Boolean = False, Optional strDelim As String = ",", Optional blnShowMessages As Boolean = True, Optional blnAppendOptionsToFile As Boolean = False)
        Throw New NotImplementedException("Not implemented: SaveDataToDisk")
        ' ToDo: SpectrumForm.SaveDataToDisk(strOutputFilePath, blnOptionsOnly, strDelim, blnShowMessages, blnAppendOptionsToFile)
    End Sub

    Public Sub SaveToDiskAsWMF(Optional strOutputFilePath As String = "", Optional blnShowMessages As Boolean = True)
        Throw New NotImplementedException("Not implemented: SaveToDiskAsWMF")
        ' ToDo: SpectrumForm.SaveToDiskAsPicture(strOutputFilePath, blnShowMessages)
    End Sub

    'Public Function SetAnnotation(blnPromptForText As Boolean, CaptionXPos As Double, CaptionYPos As Double, Optional strCaptionText As String = "", Optional lngCaptionAngle As Integer = 0, Optional seriesNumber As Integer = 1, Optional eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional lngPointNumberToBind As Integer = -1, Optional blnAnnotationShowsNearestPointX As Boolean = False, Optional blnAnnotationShowsNearestPointY As Boolean = False, Optional blnIncludeArrow As Boolean = False, Optional blnHideInDenseRegions As Boolean = True, Optional annotationIndexForce As Integer = 0, Optional blnAutomaticCaptionPlacement As Boolean = False) As Integer
    '    ' Adds a new annotation
    '    '  or updates an existing one of annotationIndexForce is > 0
    '    ' Returns the index of the annotation (.Annotations is 1-based)
    '    ' Returns 0 if an annotation is removed or the change is cancelled
    '    ' Use annotationIndexForce to force editing of an existing annotation

    '    Throw New NotImplementedException("Not implemented: SetAnnotation")
    '    ' ToDo: SetAnnotation = SpectrumForm.ctlOxyPlot.SetAnnotation(blnPromptForText, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, seriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, annotationIndexForce, blnAutomaticCaptionPlacement)
    'End Function

    'Public Function SetAnnotationByIndex(annotationIndex As Integer, CaptionXPos As Double, CaptionYPos As Double, Optional strCaptionText As String = "", Optional lngCaptionAngle As Integer = 0, Optional seriesNumber As Integer = 1, Optional eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional lngPointNumberToBind As Integer = 0, Optional blnAnnotationShowsNearestPointX As Boolean = False, Optional blnAnnotationShowsNearestPointY As Boolean = False, Optional blnIncludeArrow As Boolean = False, Optional blnHideInDenseRegions As Boolean = True, Optional blnAutomaticCaptionPlacement As Boolean = False, Optional strReturnAnnotationName As String = "") As Boolean
    '    Throw New NotImplementedException("Not implemented: SetAnnotationByIndex")
    '    ' ToDo: SetAnnotationByIndex = SpectrumForm.ctlOxyPlot.SetAnnotationByIndex(annotationIndex, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, seriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, blnAutomaticCaptionPlacement, strReturnAnnotationName)
    'End Function

    ''' <summary>
    ''' Add an annotation at a specific position on the plot, optionally including an arrow
    ''' </summary>
    ''' <param name="locationX">X location of the coordinate to label</param>
    ''' <param name="locationY">Y location of the coordinate to label</param>
    ''' <param name="caption">Annotation text</param>
    ''' <param name="captionOffsetDirection">Offset direction relative to X,Y</param>
    ''' <param name="offsetPixels">Offset distance</param>
    ''' <param name="includeArrow">True to include an arrow</param>
    ''' <param name="eLineStyle">Arrow line style if includeArrow is true; ignored if includeArrow is false</param>
    ''' <param name="lineWidth">Arrow line width if includeArrow is true, otherwise rectangle border width</param>
    ''' <param name="fontSize">Annotation text size</param>
    ''' <remarks>Searches all series to find the closest matching point</remarks>
    Public Sub SetAnnotationByXY(
      locationX As Double,
      locationY As Double,
      caption As String,
      Optional captionOffsetDirection As CaptionOffsetDirection = CaptionOffsetDirection.TopLeft,
      Optional offsetPixels As Integer = 15,
      Optional includeArrow As Boolean = True,
      Optional eLineStyle As LineStyle = LineStyle.Automatic,
      Optional lineWidth As Integer = 1,
      Optional fontSize As Integer = 12)

        SpectrumForm.ctlOxyPlot.SetAnnotationByXY(locationX, locationY, caption, captionOffsetDirection, offsetPixels, includeArrow, eLineStyle, lineWidth, fontSize)
    End Sub

    ''' <summary>
    ''' Add an annotation for a data point, optionally including an arrow
    ''' </summary>
    ''' <param name="locationX">X location of the coordinate to label</param>
    ''' <param name="locationY">Y location of the coordinate to label</param>
    ''' <param name="caption">Annotation text</param>
    ''' <param name="seriesNumber">Series whose data should be searched; use 0 to search all series and use the closest matching point</param>
    ''' <param name="captionOffsetDirection">Offset direction relative to X,Y</param>
    ''' <param name="offsetPixels">Offset distance</param>
    ''' <param name="includeArrow">True to include an arrow</param>
    ''' <param name="eLineStyle">Arrow line style if includeArrow is true; ignored if includeArrow is false</param>
    ''' <param name="lineWidth">Arrow line width if includeArrow is true, otherwise rectangle border width</param>
    ''' <param name="fontSize">Annotation text size</param>
    Public Sub SetAnnotationForDataPoint(
      locationX As Double,
      locationY As Double,
      caption As String,
      Optional seriesNumber As Integer = 0,
      Optional captionOffsetDirection As CaptionOffsetDirection = CaptionOffsetDirection.TopLeft,
      Optional offsetPixels As Integer = 15,
      Optional includeArrow As Boolean = True,
      Optional eLineStyle As LineStyle = LineStyle.Automatic,
      Optional lineWidth As Integer = 1,
      Optional fontSize As Integer = 12)

        SpectrumForm.ctlOxyPlot.SetAnnotationForDataPoint(locationX, locationY, caption, seriesNumber,
                                                          captionOffsetDirection, offsetPixels, includeArrow, eLineStyle, lineWidth, fontSize)

    End Sub

    ''' <summary>
    ''' Add an annotation for a data point (no arrow)
    ''' </summary>
    ''' <param name="locationX">X location of the coordinate to label</param>
    ''' <param name="locationY">Y location of the coordinate to label</param>
    ''' <param name="caption">Annotation text</param>
    ''' <param name="seriesNumber">Series whose data should be searched; use 0 to search all series and use the closest matching point</param>
    ''' <param name="captionOffsetDirection">Offset direction relative to X,Y</param>
    ''' <param name="offsetPixels">Offset distance</param>
    ''' <param name="fontSize">Annotation text size</param>
    ''' <param name="lineWidth">Rectangle border width</param>
    Public Sub SetTextAnnotationByDataPoint(
      locationX As Double,
      locationY As Double,
      caption As String,
      seriesNumber As Integer,
      Optional captionOffsetDirection As CaptionOffsetDirection = CaptionOffsetDirection.TopLeft,
      Optional offsetPixels As Integer = 15,
      Optional fontSize As Integer = 12,
      Optional lineWidth As Integer = 1)
        SetAnnotationForDataPoint(locationX, locationY, caption, seriesNumber, captionOffsetDirection, offsetPixels, False, LineStyle.None, lineWidth, fontSize)
    End Sub

    ''' <summary>
    ''' Add an annotation at a specific position on the plot (no arrow)
    ''' </summary>
    ''' <param name="locationX">X location of the coordinate to label</param>
    ''' <param name="locationY">Y location of the coordinate to label</param>
    ''' <param name="caption">Annotation text</param>
    ''' <param name="captionOffsetDirection">Offset direction relative to X,Y</param>
    ''' <param name="offsetPixels">Offset distance</param>
    ''' <param name="fontSize">Annotation text size</param>
    ''' <param name="lineWidth">Rectangle border width</param>
    Public Sub SetTextAnnotationByXY(
      locationX As Double,
      locationY As Double,
      caption As String,
      Optional captionOffsetDirection As CaptionOffsetDirection = CaptionOffsetDirection.TopLeft,
      Optional offsetPixels As Integer = 15,
      Optional fontSize As Integer = 12,
      Optional lineWidth As Integer = 1)
        SetAnnotationByXY(locationX, locationY, caption, captionOffsetDirection, offsetPixels, False, LineStyle.None, lineWidth, fontSize)
    End Sub

    Public Sub SetAnnotationFontColor(seriesNumber As Integer, cNewColor As Color, blnMakeDefaultForAll As Boolean)
        Throw New NotImplementedException("Not implemented: SetAnnotationFontColor")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationFontColor(seriesNumber, cNewColor, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationFontName(seriesNumber As Integer, strNewFontName As String, blnMakeDefaultForAll As Boolean)
        Throw New NotImplementedException("Not implemented: SetAnnotationFontName")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationFontName(seriesNumber, strNewFontName, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationFontSize(seriesNumber As Integer, intNewSize As Short, blnMakeDefaultForAll As Boolean)
        Throw New NotImplementedException("Not implemented: SetAnnotationFontSize")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationFontSize(seriesNumber, intNewSize, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationDensityAutoHideCaptions(blnEnableAutoHide As Boolean, Optional blnShowHiddenCaptionsIfDisabled As Boolean = True)
        Throw New NotImplementedException("Not implemented: SetAnnotationDensityAutoHideCaptions")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationDensityAutoHideCaptions(blnEnableAutoHide, blnShowHiddenCaptionsIfDisabled)
    End Sub

    Public Sub SetAnnotationDensityToleranceX(dblNewThreshold As Double)
        Throw New NotImplementedException("Not implemented: SetAnnotationDensityToleranceX")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationDensityToleranceX(dblNewThreshold)
    End Sub

    Public Sub SetAnnotationDensityToleranceY(dblNewThreshold As Double)
        Throw New NotImplementedException("Not implemented: SetAnnotationDensityToleranceY")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationDensityToleranceY(dblNewThreshold)
    End Sub

    Public Sub SetAnnotationDensityToleranceAutoAdjust(blnEnableAutoAdjust As Boolean)
        Throw New NotImplementedException("Not implemented: SetAnnotationDensityToleranceAutoAdjust")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAnnotationDensityToleranceAutoAdjust(blnEnableAutoAdjust)
    End Sub

    Public Sub SetAutoscaleXAxis(enableAutoscale As Boolean)
        SpectrumForm.ctlOxyPlot.AutoscaleXAxis = enableAutoscale
    End Sub

    Public Sub SetAutoscaleYAxis(enableAutoscale As Boolean)
        SpectrumForm.ctlOxyPlot.AutoscaleYAxis = enableAutoscale
    End Sub

    Public Sub SetAutoAdjustScalingToIncludeCaptions(blnEnable As Boolean)
        Throw New NotImplementedException("Not implemented: SetAutoAdjustScalingToIncludeCaptions")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAutoAdjustScalingToIncludeCaptions(blnEnable)
    End Sub

    Public Sub SetAutoLabelPeaksOptions(udtNewAutoLabelOptions As udtAutoLabelPeaksOptionsType)
        Throw New NotImplementedException("Not implemented: SetAutoLabelPeaksOptions")

        'Dim udtAutoLabelPeaksOptionsInternal As udtAutoLabelPeaksOptionsInternalType

        'With udtNewAutoLabelOptions
        '    udtAutoLabelPeaksOptionsInternal.CaptionAngle = .CaptionAngle
        '    udtAutoLabelPeaksOptionsInternal.DisplayXPos = .DisplayXPos
        '    udtAutoLabelPeaksOptionsInternal.DisplayYPos = .DisplayYPos
        '    udtAutoLabelPeaksOptionsInternal.HideInDenseRegions = .HideInDenseRegions
        '    udtAutoLabelPeaksOptionsInternal.IncludeArrow = .IncludeArrow
        '    udtAutoLabelPeaksOptionsInternal.IntensityThresholdMinimum = .IntensityThresholdMinimum
        '    If .IsContinuousData Then
        '        udtAutoLabelPeaksOptionsInternal.DataMode = modCWSpectrum.dmDataModeConstants.dmContinuous
        '    Else
        '        udtAutoLabelPeaksOptionsInternal.DataMode = modCWSpectrum.dmDataModeConstants.dmDiscrete
        '    End If
        '    udtAutoLabelPeaksOptionsInternal.MinimumIntensityPercentageOfMaximum = .MinimumIntensityPercentageOfMaximum
        '    udtAutoLabelPeaksOptionsInternal.PeakLabelCountMaximum = .PeakLabelCountMaximum
        '    udtAutoLabelPeaksOptionsInternal.PeakWidthMinimumPoints = .PeakWidthMinimumPoints
        'End With

        'AutoLabelOptionsStore(udtAutoLabelPeaksOptionsInternal)

        ' ToDo: SpectrumForm.RetrieveAutoLabelPeaksOptionsFromModule()

    End Sub

    Public Sub SetAutoscaleVisibleY(blnEnableAutoscale As Boolean, blnFixMinimumYAtZero As Boolean)
        Throw New NotImplementedException("Not implemented: SetAutoscaleVisibleY")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetAutoscaleVisibleY(blnEnableAutoscale, blnFixMinimumYAtZero)
    End Sub

    Public Sub SetCursorColor(cNewColor As Color, Optional intCursorNumber As Integer = 1)
        Throw New NotImplementedException("Not implemented: SetCursorColor")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetCursorColor(cNewColor, intCursorNumber)
    End Sub

    Public Sub SetCursorPosition(XPos As Double, YPos As Double, Optional intCursorNumber As Integer = 1)
        Throw New NotImplementedException("Not implemented: SetCursorPosition")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetCursorPosition(XPos, YPos, intCursorNumber)
    End Sub

    Public Sub SetCursorSnapMode(blnSnapToData As Boolean)
        Throw New NotImplementedException("Not implemented: SetCursorSnapMode")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetCursorSnapMode(blnSnapToData)
    End Sub

    Public Sub SetCursorVisible(blnShowCursor As Boolean, Optional intCursorNumber As Integer = 1)
        Throw New NotImplementedException("Not implemented: SetCursorVisible")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetCursorVisible(blnShowCursor, intCursorNumber)
    End Sub

    ''' <summary>
    ''' Add new X/Y Data, either replacing an existing series, or adding as a new series
    ''' </summary>
    ''' <param name="seriesNumber">
    ''' Series number to use/replace (starting with 1)
    ''' Set to higher than GetSeriesCount() to add a new series
    ''' </param>
    ''' <param name="XDataZeroBased1DArray"></param>
    ''' <param name="YDataZeroBased1DArray"></param>
    ''' <param name="dataCount"></param>
    ''' <param name="ePlotMode">Plot mode for the series</param>
    ''' <param name="seriesTitle">Title (for legend)</param>
    Public Sub SetDataXvsY(
      seriesNumber As Integer,
      XDataZeroBased1DArray() As Double,
      YDataZeroBased1DArray() As Double,
      dataCount As Integer,
      Optional ePlotMode As SeriesPlotMode = SeriesPlotMode.PointsAndLines,
      Optional seriesTitle As String = "")
        SpectrumForm.ctlOxyPlot.SetDataXvsY(seriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, dataCount, ePlotMode, seriesTitle)
    End Sub

    ''' <summary>
    ''' Add new data with auto generated X values based on xFirst and xIncrement, either replacing an existing series, or adding as a new series
    ''' </summary>
    ''' <param name="seriesNumber">
    ''' Series number to use/replace (starting with 1)
    ''' Set to higher than GetSeriesCount() to add a new series
    ''' </param>
    ''' <param name="YDataZeroBased1DArray"></param>
    ''' <param name="YDataCount"></param>
    ''' <param name="ePlotMode">Plot mode for the series</param>
    ''' <param name="xFirst">Starting X value</param>
    ''' <param name="xIncrement">Distance in X between each data point</param>
    ''' <param name="seriesTitle">Title (for legend)</param>
    Public Sub SetDataYOnly(
      ByRef seriesNumber As Integer,
      ByRef YDataZeroBased1DArray() As Double,
      YDataCount As Integer,
      Optional ePlotMode As SeriesPlotMode = SeriesPlotMode.PointsAndLines,
      Optional xFirst As Double = 0,
      Optional xIncrement As Double = 1,
      Optional seriesTitle As String = "")
        SpectrumForm.ctlOxyPlot.SetDataYOnly(seriesNumber, YDataZeroBased1DArray, YDataCount, ePlotMode, xFirst, xIncrement, seriesTitle)
    End Sub

    ''' <summary>
    ''' Define the number of digits to show after the decimal point for tick mark labels on the X axis
    ''' </summary>
    ''' <param name="precision"></param>
    Public Sub SetDisplayPrecisionX(precision As Short)
        SpectrumForm.ctlOxyPlot.SetDisplayPrecisionX(precision)
    End Sub

    ''' <summary>
    ''' Define the number of digits to show after the decimal point for tick mark labels on the Y axis
    ''' </summary>
    ''' <param name="precision"></param>
    Public Sub SetDisplayPrecisionY(precision As Short)
        SpectrumForm.ctlOxyPlot.SetDisplayPrecisionY(precision)
    End Sub

    Public Sub SetGridLinesStyleX(majorGridlineStyle As udtGridlineStyle)
        SpectrumForm.ctlOxyPlot.SetGridLinesStyleX(majorGridlineStyle)
    End Sub

    Public Sub SetGridLinesStyleX(majorGridlineStyle As udtGridlineStyle, minorGridlineStyle As udtGridlineStyle)
        SpectrumForm.ctlOxyPlot.SetGridLinesStyleX(majorGridlineStyle, minorGridlineStyle)
    End Sub

    Public Sub SetGridLinesStyleY(majorGridlineStyle As udtGridlineStyle)
        SpectrumForm.ctlOxyPlot.SetGridLinesStyleY(majorGridlineStyle)
    End Sub

    Public Sub SetGridLinesStyleY(majorGridlineStyle As udtGridlineStyle, minorGridlineStyle As udtGridlineStyle)
        SpectrumForm.ctlOxyPlot.SetGridLinesStyleY(majorGridlineStyle, minorGridlineStyle)
    End Sub

    Public Sub SetGridLinesXVisible(showGridLines As Boolean, includeMinorGridLines As Boolean)
        SpectrumForm.ctlOxyPlot.SetGridLinesVisibleX(showGridLines, includeMinorGridLines)
    End Sub

    Public Sub SetGridLinesYVisible(showGridLines As Boolean, includeMinorGridLines As Boolean)
        SpectrumForm.ctlOxyPlot.SetGridLinesVisibleY(showGridLines, includeMinorGridLines)
    End Sub

    Public Sub SetLabelFontColor(cNewColor As Color)
        Throw New NotImplementedException("Not implemented: SetLabelFontColor")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetLabelFontColor(cNewColor)
    End Sub

    Public Sub SetLabelFontName(strFontName As String)
        Throw New NotImplementedException("Not implemented: SetLabelFontName")
        ' ToDo: SpectrumForm.ctlOxyPlot.SetLabelFontName(strFontName)
    End Sub

    Public Sub SetLabelFontSize(intNewSize As Short)
        Throw New NotImplementedException("Not implemented: SetLabelFontSize")
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

    <Obsolete("This method should typically not be needed. Instead use SetDataXvsY or SetDataYOnly with parameter ePlotMode")>
    Public Sub SetSeriesPlotMode(seriesNumber As Integer, ePlotMode As SeriesPlotMode)
        SpectrumForm.ctlOxyPlot.SetSeriesPlotMode(seriesNumber, ePlotMode)
    End Sub

    Public Sub SetSeriesPointColor(seriesNumber As Integer, cNewColor As Color)
        SpectrumForm.ctlOxyPlot.SetSeriesPointColor(seriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesPointSize(seriesNumber As Integer, pointSize As Double)
        SpectrumForm.ctlOxyPlot.SetSeriesPointSize(seriesNumber, pointSize)
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
        Throw New NotImplementedException("Not implemented: SetSpectrumFormNormalizeOnLoadOrPaste")
        ' ToDo: SpectrumForm.SetNormalizeOnLoadOrPaste(blnEnable)
    End Sub

    Public Sub SetSpectrumFormNormalizationConstant(dblNewNormalizationConstant As Double)
        Throw New NotImplementedException("Not implemented: SetSpectrumFormNormalizationConstant")
        ' ToDo: SpectrumForm.SetNormalizationConstant(dblNewNormalizationConstant)
    End Sub

    Public Sub SetSpectrumFormWindowCaption(strTitle As String)
        SpectrumForm.SetWindowCaption(strTitle)
    End Sub

    Public Sub SetSpectrumFormWindowPos(topLeftX As Integer, topLeftY As Integer, windowHeight As Integer, windowWidth As Integer)
        SpectrumForm.SetWindowPos(topLeftX, topLeftY, windowHeight, windowWidth)
    End Sub

    Public Sub ShowAutoLabelPeaksDialog(Optional blnShowModal As Boolean = True)
        Throw New NotImplementedException("Not implemented: ShowAutoLabelPeaksDialog")
        ' ToDo: SpectrumForm.ShowAutoLabelPeaksDialog(blnShowModal)
    End Sub

    Public Sub ShowZoomRangeDialog()
        Throw New NotImplementedException("Not implemented: ShowZoomRangeDialog")
        ' ToDo: SpectrumForm.ShowZoomRangeDialog()
    End Sub

    Public Sub ShowHideControls(blnHideControlsFrame As Boolean)
        Throw New NotImplementedException("Not implemented: ShowHideControls")
        ' ToDo: SpectrumForm.ctlOxyPlot.ShowHideControls(blnHideControlsFrame)
    End Sub

    Public Sub ShowHideAnnotations(Optional blnForceOperation As Boolean = False)
        Throw New NotImplementedException("Not implemented: ShowHideAnnotations")
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
        Throw New NotImplementedException("Not implemented: UpdateAllDynamicAnnotationCaptions")
        ' ToDo: SpectrumForm.ctlOxyPlot.UpdateAllDynamicAnnotationCaptions()
    End Sub

    Public Sub ZoomOutFull()
        SpectrumForm.ctlOxyPlot.ZoomOutFull()
    End Sub

    Public Sub ZoomToPrevious()
        Throw New NotImplementedException("Not implemented: ZoomToPrevious")
        ' ToDo: SpectrumForm.ctlOxyPlot.ZoomToPrevious()
    End Sub

    Public ReadOnly Property DllDate() As String
        Get
            DllDate = SpectrumForm.DllDate()
        End Get
    End Property

    Public ReadOnly Property DllVersion() As String
        Get
            Return SpectrumForm.DllVersion()
        End Get
    End Property

    Public ReadOnly Property AppDate() As String
        Get
            AppDate = SpectrumForm.DllDate()
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