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

<System.Runtime.InteropServices.ProgId("Spectrum_NET.Spectrum")> Public Class Spectrum

    Private Const SPECTRUM_DLL_DATE As String = "January 24, 2006"

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

    ' Client notification event
    Public Event SpectrumFormRequestClose()

    ' Actual spectrum form
    Private WithEvents SpectrumForm As frmCWSpectrum
    Private mSpectrumLoaded As Boolean
    '

    Public Sub AutoLabelPeaks(ByVal intSeriesNumber As Short, ByVal blnShowXPos As Boolean, ByVal blnShowYPos As Boolean, Optional ByVal lngCaptionAngle As Integer = 0, Optional ByVal blnIncludeArrow As Boolean = False, Optional ByVal blnHideInDenseRegions As Boolean = True, Optional ByVal lngMaxPeakCount As Integer = 100, Optional ByVal blnForceAsContinuousData As Boolean = False, Optional ByVal blnForceAsDiscreteData As Boolean = False)
        SpectrumForm.ctlCWGraph.AutoLabelPeaks(intSeriesNumber, blnShowXPos, blnShowYPos, lngCaptionAngle, blnIncludeArrow, blnHideInDenseRegions, lngMaxPeakCount, blnForceAsContinuousData, blnForceAsDiscreteData)
    End Sub

    Public Sub AutoScaleVisibleYNow()
        SpectrumForm.ctlCWGraph.AutoScaleVisibleYNow()
    End Sub

    Public Sub AutoScaleXNow()
        SpectrumForm.ctlCWGraph.AutoScaleXNow()
    End Sub

    Public Sub AutoScaleYNow()
        SpectrumForm.ctlCWGraph.AutoScaleYNow()
    End Sub

    Public Sub CenterCursors(Optional ByVal intCursorNumber As Integer = 1, Optional ByVal blncenterAll As Boolean = True)
        SpectrumForm.ctlCWGraph.CenterCursor(intCursorNumber, blncenterAll)
    End Sub

    Public Sub ClearData(ByVal intSeriesToClear As Short)
        ' This does not prompt the user
        SpectrumForm.ctlCWGraph.ClearData(intSeriesToClear)
    End Sub

    Public Sub ClearDataAllSeries()
        ' This does not prompt the user
        SpectrumForm.DeleteDataForAllSeries(False)
    End Sub

    Public Sub CopyDataPointsToClipboardOrToString(ByVal intSeriesNumber As Short, Optional ByRef strDataToCopy As String = "", Optional ByVal strDelim As String = vbTab, Optional ByVal blnCopyToClipboard As Boolean = True)
        ' If blnCopyToClipboard = False, then simply populates strDataToCopy

        SpectrumForm.CopyDataPointsToClipboardOrToString(intSeriesNumber, strDataToCopy, strDelim, blnCopyToClipboard)
    End Sub

    Public Sub CopyToClipboardAsPicture()
        SpectrumForm.CopyToClipboardAsPicture()
    End Sub

    Public Property DateModeXAxis() As Boolean
        Get
            Return SpectrumForm.ctlCWGraph.DateModeXAxis
        End Get
        Set(ByVal Value As Boolean)
            SpectrumForm.ctlCWGraph.DateModeXAxis = Value
        End Set
    End Property

    Public Property DateModeXAxisShowTime() As Boolean
        Get
            Return SpectrumForm.ctlCWGraph.DateModeXAxisShowTime
        End Get
        Set(ByVal Value As Boolean)
            SpectrumForm.ctlCWGraph.DateModeXAxisShowTime = Value
        End Set
    End Property

    Public Sub DeleteDataActiveSeries(Optional ByVal blnConfirmDeletion As Boolean = True)
        SpectrumForm.DeleteDataActiveSeries(blnConfirmDeletion)
    End Sub

    Public Sub DeleteDataForAllSeries(Optional ByVal blnConfirmDeletion As Boolean = True)
        SpectrumForm.DeleteDataForAllSeries(blnConfirmDeletion)
    End Sub

    Public Sub EnableTrackAnnotationPlacement()
        SpectrumForm.ctlCWGraph.EnableTrackAnnotationPlacement()
    End Sub

    Public Sub EnableTrackCursor()
        SpectrumForm.ctlCWGraph.EnableTrackCursor()
    End Sub

    Public Sub EnableTrackModeAllEvents()
        SpectrumForm.ctlCWGraph.EnableTrackModeAllEvents()
    End Sub

    Public Sub EnableTrackModePan(Optional ByVal blnPanXOnly As Boolean = False, Optional ByVal blnPanYOnly As Boolean = False)
        SpectrumForm.ctlCWGraph.EnableTrackModePan(blnPanXOnly, blnPanYOnly)
    End Sub

    Public Sub EnableTrackModeZoom(Optional ByVal blnZoomXOnly As Boolean = False, Optional ByVal blnZoomYOnly As Boolean = False)
        SpectrumForm.ctlCWGraph.EnableTrackModeZoom(blnZoomXOnly, blnZoomYOnly)
    End Sub

    Public Sub GenerateSineWave(ByVal intSeriesNumber As Short, ByVal blnXAxisLogBased As Boolean)
        SpectrumForm.ctlCWGraph.GenerateSineWave(intSeriesNumber, blnXAxisLogBased)
    End Sub

    Public Function GetAnnotationFontColor(ByVal intSeriesIndex As Short) As System.Drawing.Color
        GetAnnotationFontColor = SpectrumForm.ctlCWGraph.GetAnnotationFontColor(intSeriesIndex)
    End Function

    Public Function GetAnnotationFontName(ByVal intSeriesIndex As Short) As String
        GetAnnotationFontName = SpectrumForm.ctlCWGraph.GetAnnotationFontName(intSeriesIndex)
    End Function

    Public Function GetAnnotationFontSize(ByVal intSeriesIndex As Short) As Short
        GetAnnotationFontSize = SpectrumForm.ctlCWGraph.GetAnnotationFontSize(intSeriesIndex)
    End Function

    Public Function GetAnnotationDensityToleranceAutoAdjust() As Boolean
        GetAnnotationDensityToleranceAutoAdjust = SpectrumForm.ctlCWGraph.GetAnnotationDensityToleranceAutoAdjust()
    End Function

    Public Function GetAnnotationDensityToleranceX() As Double
        GetAnnotationDensityToleranceX = SpectrumForm.ctlCWGraph.GetAnnotationDensityToleranceX()
    End Function

    Public Function GetAnnotationDensityToleranceY() As Double
        GetAnnotationDensityToleranceY = SpectrumForm.ctlCWGraph.GetAnnotationDensityToleranceY()
    End Function

    Public Function GetAnnotationCount() As Short
        GetAnnotationCount = SpectrumForm.ctlCWGraph.GetAnnotationCount()
    End Function

    Public Function GenerateAnnotationUsingNearestPoint(ByRef dblCaptionXPos As Double, ByRef dblCaptionYPos As Double, ByRef intSeriesNumber As Short, ByRef blnAnnotationShowsNearestPointX As Boolean, ByRef blnAnnotationShowsNearestPointY As Boolean, ByRef blnBindToPoint As Boolean, ByRef strCurrentCaption As String, Optional ByRef lngPointNumberOverride As Integer = -1) As String
        GenerateAnnotationUsingNearestPoint = SpectrumForm.ctlCWGraph.GenerateAnnotationUsingNearestPoint(dblCaptionXPos, dblCaptionYPos, intSeriesNumber, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnBindToPoint, strCurrentCaption, lngPointNumberOverride)
    End Function

    Public Function GetAnnotationDensityAutoHideCaptions() As Boolean
        GetAnnotationDensityAutoHideCaptions = SpectrumForm.ctlCWGraph.GetAnnotationDensityAutoHideCaptions()
    End Function


    Public Function GetAnnotationByIndex(ByVal lngAnnotationIndex As Integer, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, ByRef strCaptionText As String, Optional ByRef lngCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Short = 0, Optional ByRef eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint, Optional ByRef lngPointNumberToBind As Integer = 0, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = False, Optional ByRef strAnnotationNameReturn As String = "") As Boolean
        GetAnnotationByIndex = SpectrumForm.ctlCWGraph.GetAnnotationByIndex(lngAnnotationIndex, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, strAnnotationNameReturn)
    End Function

    Public Function GetAnnotationByName(ByVal strAnnotationName As String, ByRef CaptionXPos As Double, ByRef CaptionYPos As Double, ByRef strCaptionText As String, Optional ByRef lngCaptionAngle As Integer = 0, Optional ByRef intSeriesNumber As Short = 0, Optional ByRef eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint, Optional ByRef lngPointNumberToBind As Integer = 0, Optional ByRef blnAnnotationShowsNearestPointX As Boolean = False, Optional ByRef blnAnnotationShowsNearestPointY As Boolean = False, Optional ByRef blnIncludeArrow As Boolean = False, Optional ByRef blnHideInDenseRegions As Boolean = False, Optional ByRef strAnnotationNameReturn As String = "", Optional ByRef blnCaseSensitive As Boolean = False) As Boolean
        GetAnnotationByName = SpectrumForm.ctlCWGraph.GetAnnotationByName(strAnnotationName, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, strAnnotationNameReturn, blnCaseSensitive)
    End Function

    Public Function GetAutoAdjustScalingToIncludeCaptions() As Boolean
        GetAutoAdjustScalingToIncludeCaptions = SpectrumForm.ctlCWGraph.GetAutoAdjustScalingToIncludeCaptions()
    End Function

    Public Sub GetAutoLabelPeaksOptions(ByRef udtAutoLabelPeaksOptions As udtAutoLabelPeaksOptionsType)

        Dim udtAutoLabelPeaksOptionsInternal As udtAutoLabelPeaksOptionsInternalType

        SpectrumForm.StoreAutoLabelPeaksOptionsInModule()
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
        GetAutoscaleVisibleY = SpectrumForm.ctlCWGraph.GetAutoscaleVisibleY()
    End Function

    Public Function GetControlImage() As System.Drawing.Image
        ' Returns an image of the graph, in the form of a Windows MetaFile
        GetControlImage = SpectrumForm.ctlCWGraph.GetControlImage()
    End Function

    Public Function GetCursorSnapToDataPointModeEnabled() As Boolean
        GetCursorSnapToDataPointModeEnabled = SpectrumForm.ctlCWGraph.GetCursorSnapToDataPointModeEnabled()
    End Function

    Public Function GetCursorColor(Optional ByVal intCursorNumber As Integer = 1) As System.Drawing.Color
        GetCursorColor = SpectrumForm.ctlCWGraph.GetCursorColor(intCursorNumber)
    End Function

    Public Sub GetCursorPosition(ByRef XPos As Double, ByRef YPos As Double, Optional ByVal intCursorNumber As Integer = 1)
        SpectrumForm.ctlCWGraph.GetCursorPosition(XPos, YPos, intCursorNumber)
    End Sub

    Public Function GetCursorVisibility(Optional ByVal intCursorNumber As Integer = 1) As Boolean
        GetCursorVisibility = SpectrumForm.ctlCWGraph.GetCursorVisibility(intCursorNumber)
    End Function

    Public Function GetDataCount(ByVal intSeriesNumber As Short) As Integer
        GetDataCount = SpectrumForm.ctlCWGraph.GetDataCount(intSeriesNumber)
    End Function

    Public Function GetDataXvsY(ByVal intSeriesNumber As Short, ByRef XDataZeroBased1DArray() As Double, ByRef YDataZeroBased1DArray() As Double, ByRef DataCount As Integer) As Boolean
        GetDataXvsY = SpectrumForm.ctlCWGraph.GetDataXvsY(intSeriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, DataCount)
    End Function

    Public Function GetDefaulSeriesColor(ByVal intSeriesNumber As Short) As System.Drawing.Color
        GetDefaulSeriesColor = SpectrumForm.ctlCWGraph.GetDefaulSeriesColor(intSeriesNumber)
    End Function

    Public Function GetDisplayPrecisionX() As Double
        GetDisplayPrecisionX = SpectrumForm.ctlCWGraph.GetDisplayPrecisionX()
    End Function

    Public Function GetDisplayPrecisionY() As Double
        GetDisplayPrecisionY = SpectrumForm.ctlCWGraph.GetDisplayPrecisionY()
    End Function

    Public Function GetFixMinimumYAtZero() As Boolean
        GetFixMinimumYAtZero = SpectrumForm.ctlCWGraph.GetFixMinimumYAtZero()
    End Function

    Public Function GetLabelFontColor() As System.Drawing.Color
        GetLabelFontColor = SpectrumForm.ctlCWGraph.GetLabelFontColor()
    End Function

    Public Function GetLabelFontName() As String
        GetLabelFontName = SpectrumForm.ctlCWGraph.GetLabelFontName()
    End Function

    Public Function GetLabelFontSize() As Short
        GetLabelFontSize = SpectrumForm.ctlCWGraph.GetLabelFontSize()
    End Function

    Public Function GetGridLinesXVisible(Optional ByVal blnMajorGridLines As Boolean = True) As Boolean
        GetGridLinesXVisible = SpectrumForm.ctlCWGraph.GetGridLinesXVisible(blnMajorGridLines)
    End Function

    Public Function GetGridlinesYVisible(Optional ByVal blnMajorGridLines As Boolean = True) As Boolean
        GetGridlinesYVisible = SpectrumForm.ctlCWGraph.GetGridlinesYVisible(blnMajorGridLines)
    End Function

    Public Function GetGridLinesXColor(Optional ByVal blnMajorGridLines As Boolean = True) As System.Drawing.Color
        GetGridLinesXColor = SpectrumForm.ctlCWGraph.GetGridLinesXColor(blnMajorGridLines)
    End Function

    Public Function GetGridLinesYColor(Optional ByVal blnMajorGridLines As Boolean = True) As System.Drawing.Color
        GetGridLinesYColor = SpectrumForm.ctlCWGraph.GetGridLinesYColor(blnMajorGridLines)
    End Function

    Public Function GetLabelSubtitle() As String
        GetLabelSubtitle = SpectrumForm.ctlCWGraph.GetLabelSubtitle()
    End Function

    Public Function GetLabelTitle() As String
        GetLabelTitle = SpectrumForm.ctlCWGraph.GetLabelTitle()
    End Function

    Public Function GetLabelXAxis() As String
        GetLabelXAxis = SpectrumForm.ctlCWGraph.GetLabelXAxis()
    End Function

    Public Function GetLabelYAxis() As String
        GetLabelYAxis = SpectrumForm.ctlCWGraph.GetLabelYAxis()
    End Function

    Public Function GetPlotBackgroundColor() As System.Drawing.Color
        GetPlotBackgroundColor = SpectrumForm.ctlCWGraph.GetPlotBackgroundColor()
    End Function

    Public Function GetRangeX(Optional ByRef dblMinimum As Double = 0, Optional ByRef dblMaximum As Double = 0) As Double
        ' Returns Abs(dblMaximum - dblMinimum)
        GetRangeX = SpectrumForm.ctlCWGraph.GetRangeX(dblMinimum, dblMaximum)
    End Function

    Public Function GetRangeY(Optional ByRef dblMinimum As Double = 0, Optional ByRef dblMaximum As Double = 0) As Double
        ' Returns Abs(dblMaximum - dblMinimum)
        GetRangeY = SpectrumForm.ctlCWGraph.GetRangeY(dblMinimum, dblMaximum)
    End Function

    Public Function GetSeriesBarFillColor(ByVal intSeriesNumber As Short) As System.Drawing.Color
        GetSeriesBarFillColor = SpectrumForm.ctlCWGraph.GetSeriesBarFillColor(intSeriesNumber)
    End Function

    Public Function GetSeriesCount() As Integer
        GetSeriesCount = SpectrumForm.ctlCWGraph.GetSeriesCount()
    End Function

    Public Function GetSeriesLegendCaption(ByVal intSeriesNumber As Short) As String
        GetSeriesLegendCaption = SpectrumForm.ctlCWGraph.GetSeriesLegendCaption(intSeriesNumber)
    End Function

    Public Function GetSeriesLineColor(ByVal intSeriesNumber As Short) As System.Drawing.Color
        GetSeriesLineColor = SpectrumForm.ctlCWGraph.GetSeriesLineColor(intSeriesNumber)
    End Function

    Public Function GetSeriesLineToBaseColor(ByVal intSeriesNumber As Short) As System.Drawing.Color
        GetSeriesLineToBaseColor = SpectrumForm.ctlCWGraph.GetSeriesLineToBaseColor(intSeriesNumber)
    End Function

    Public Function GetSeriesLineStyle(ByVal intSeriesNumber As Short) As CWUIControlsLib.CWLineStyles
        GetSeriesLineStyle = SpectrumForm.ctlCWGraph.GetSeriesLineStyle(intSeriesNumber)
    End Function

    Public Function GetSeriesLineWidth(ByVal intSeriesNumber As Short) As Short
        GetSeriesLineWidth = SpectrumForm.ctlCWGraph.GetSeriesLineWidth(intSeriesNumber)
    End Function

    Public Function GetSeriesOriginalIntensityMaximum(ByVal intSeriesNumber As Short) As Double
        GetSeriesOriginalIntensityMaximum = SpectrumForm.ctlCWGraph.GetSeriesOriginalIntensityMaximum(intSeriesNumber)
    End Function

    Public Function GetSeriesPlotMode(ByVal intSeriesNumber As Short) As CWGraphControl.pmPlotModeConstants
        GetSeriesPlotMode = SpectrumForm.ctlCWGraph.GetSeriesPlotMode(intSeriesNumber)
    End Function

    Public Function GetSeriesPointColor(ByVal intSeriesNumber As Short) As System.Drawing.Color
        GetSeriesPointColor = SpectrumForm.ctlCWGraph.GetSeriesPointColor(intSeriesNumber)
    End Function

    Public Function GetSeriesPointStyle(ByVal intSeriesNumber As Short) As CWUIControlsLib.CWPointStyles
        GetSeriesPointStyle = SpectrumForm.ctlCWGraph.GetSeriesPointStyle(intSeriesNumber)
    End Function

    Public Function GetSpectrumFormActiveSeriesNumber() As Short
        GetSpectrumFormActiveSeriesNumber = SpectrumForm.GetActiveSeriesNumber()
    End Function

    Public Function GetSpectrumFormNormalizeOnLoadOrPaste() As Boolean
        GetSpectrumFormNormalizeOnLoadOrPaste = SpectrumForm.GetNormalizeOnLoadOrPaste()
    End Function

    Public Function GetSpectrumFormNormalizationConstant() As Double
        GetSpectrumFormNormalizationConstant = SpectrumForm.GetNormalizationConstant()
    End Function

    Public Sub GetSpectrumFormWindowPos(ByRef Top As Integer, ByRef intLeft As Integer, ByRef Height As Integer, ByRef Width As Integer)
        SpectrumForm.GetWindowPos(Top, intLeft, Height, Width)
    End Sub

    Public Sub LoadDataFromDisk(Optional ByVal strInputFilePath As String = "", Optional ByVal blnShowMessages As Boolean = True, Optional ByVal blnLoadOptionsOnly As Boolean = False, Optional ByVal blnDelimeterComma As Boolean = True, Optional ByVal blnDelimeterTab As Boolean = True, Optional ByVal blnDelimeterSpace As Boolean = False, Optional ByVal blnLoadingDTAFile As Boolean = False)
        SpectrumForm.LoadDataFromDisk(strInputFilePath, blnShowMessages, blnLoadOptionsOnly, blnDelimeterComma, blnDelimeterTab, blnDelimeterSpace, blnLoadingDTAFile)
    End Sub

    Public Function LookupNearestPointNumber(ByVal dblXPosSearch As Double, ByVal dblYPosSearch As Double, ByRef intSeriesNumber As Short, Optional ByRef dblDistanceToClosestSeriesNumberDataPoint As Double = 0, Optional ByVal blnLimitToGivenSeriesNumber As Boolean = False) As Integer
        LookupNearestPointNumber = SpectrumForm.ctlCWGraph.LookupNearestPointNumber(dblXPosSearch, dblYPosSearch, intSeriesNumber, dblDistanceToClosestSeriesNumberDataPoint, blnLimitToGivenSeriesNumber)
    End Function

    Public Sub PasteDataFromClipboard(Optional ByVal blnShowMessages As Boolean = True, Optional ByVal blnAllowCommaDelimeter As Boolean = True)
        SpectrumForm.PasteDataFromClipboard(blnShowMessages, blnAllowCommaDelimeter)
    End Sub

    Public Function RemoveAnnotationByCaption(ByVal strAnnotationText As String, Optional ByVal blnCaseSensitive As Boolean = False) As Boolean
        RemoveAnnotationByCaption = SpectrumForm.ctlCWGraph.RemoveAnnotationByCaption(strAnnotationText, blnCaseSensitive)
    End Function

    Public Function RemoveAnnotationByIndex(ByVal lngAnnotationIndex As Integer) As Boolean
        RemoveAnnotationByIndex = SpectrumForm.ctlCWGraph.RemoveAnnotationByCaption(CStr(lngAnnotationIndex))
    End Function

    Public Sub RemoveAllAnnotations(Optional ByVal blnConfirmRemoval As Boolean = False)
        SpectrumForm.ctlCWGraph.RemoveAllAnnotations((blnConfirmRemoval))
    End Sub

    Public Sub RemoveAnnotationsForSeries(ByVal intSeriesNumber As Short)
        SpectrumForm.ctlCWGraph.RemoveAnnotationsForSeries(intSeriesNumber)
    End Sub

    Public Sub ResetOptionsToDefaults(Optional ByVal blnClearAllData As Boolean = False, Optional ByVal blnResetSeriesCount As Boolean = False, Optional ByVal intNewSeriesCount As Short = 2, Optional ByVal eDefaultPlotMode As CWGraphControl.pmPlotModeConstants = CWGraphControl.pmPlotModeConstants.pmLines)
        ' This does not prompt the user
        SpectrumForm.ctlCWGraph.ResetOptionsToDefaults(blnClearAllData, blnResetSeriesCount, intNewSeriesCount, eDefaultPlotMode)
    End Sub

    Public Sub SaveDataToDisk(Optional ByVal strOutputFilePath As String = "", Optional ByVal blnOptionsOnly As Boolean = False, Optional ByVal strDelim As String = ",", Optional ByVal blnShowMessages As Boolean = True, Optional ByVal blnAppendOptionsToFile As Boolean = False)
        SpectrumForm.SaveDataToDisk(strOutputFilePath, blnOptionsOnly, strDelim, blnShowMessages, blnAppendOptionsToFile)
    End Sub

    Public Sub SaveToDiskAsWMF(Optional ByVal strOutputFilePath As String = "", Optional ByVal blnShowMessages As Boolean = True)
        SpectrumForm.SaveToDiskAsPicture(strOutputFilePath, blnShowMessages)
    End Sub

    Public Function SetAnnotation(ByVal blnPromptForText As Boolean, ByVal CaptionXPos As Double, ByVal CaptionYPos As Double, Optional ByVal strCaptionText As String = "", Optional ByVal lngCaptionAngle As Integer = 0, Optional ByVal intSeriesNumber As Short = 1, Optional ByVal eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional ByVal lngPointNumberToBind As Integer = -1, Optional ByVal blnAnnotationShowsNearestPointX As Boolean = False, Optional ByVal blnAnnotationShowsNearestPointY As Boolean = False, Optional ByVal blnIncludeArrow As Boolean = False, Optional ByVal blnHideInDenseRegions As Boolean = True, Optional ByVal lngAnnotationIndexForce As Integer = 0, Optional ByVal blnAutomaticCaptionPlacement As Boolean = False) As Integer
        ' Adds a new annotation
        '  or updates an existing one of lngAnnotationIndexForce is > 0
        ' Returns the index of the annotation (.Annotations is 1-based)
        ' Returns 0 if an annotation is removed or the change is cancelled
        ' Use lngAnnotationIndexForce to force editing of an existing annotation

        SetAnnotation = SpectrumForm.ctlCWGraph.SetAnnotation(blnPromptForText, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, lngAnnotationIndexForce, blnAutomaticCaptionPlacement)
    End Function

    Public Function SetAnnotationByIndex(ByVal lngAnnotationIndex As Integer, ByVal CaptionXPos As Double, ByVal CaptionYPos As Double, Optional ByVal strCaptionText As String = "", Optional ByVal lngCaptionAngle As Integer = 0, Optional ByVal intSeriesNumber As Short = 1, Optional ByVal eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint, Optional ByVal lngPointNumberToBind As Integer = 0, Optional ByVal blnAnnotationShowsNearestPointX As Boolean = False, Optional ByVal blnAnnotationShowsNearestPointY As Boolean = False, Optional ByVal blnIncludeArrow As Boolean = False, Optional ByVal blnHideInDenseRegions As Boolean = True, Optional ByVal blnAutomaticCaptionPlacement As Boolean = False, Optional ByVal strReturnAnnotationName As String = "") As Boolean
        SetAnnotationByIndex = SpectrumForm.ctlCWGraph.SetAnnotationByIndex(lngAnnotationIndex, CaptionXPos, CaptionYPos, strCaptionText, lngCaptionAngle, intSeriesNumber, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions, blnAutomaticCaptionPlacement, strReturnAnnotationName)
    End Function

    Public Sub SetAnnotationFontColor(ByVal intSeriesNumber As Short, ByVal cNewColor As System.Drawing.Color, ByVal blnMakeDefaultForAll As Boolean)
        SpectrumForm.ctlCWGraph.SetAnnotationFontColor(intSeriesNumber, cNewColor, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationFontName(ByVal intSeriesNumber As Short, ByVal strNewFontName As String, ByVal blnMakeDefaultForAll As Boolean)
        SpectrumForm.ctlCWGraph.SetAnnotationFontName(intSeriesNumber, strNewFontName, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationFontSize(ByVal intSeriesNumber As Short, ByVal intNewSize As Short, ByVal blnMakeDefaultForAll As Boolean)
        SpectrumForm.ctlCWGraph.SetAnnotationFontSize(intSeriesNumber, intNewSize, blnMakeDefaultForAll)
    End Sub

    Public Sub SetAnnotationDensityAutoHideCaptions(ByVal blnEnableAutoHide As Boolean, Optional ByVal blnShowHiddenCaptionsIfDisabled As Boolean = True)
        SpectrumForm.ctlCWGraph.SetAnnotationDensityAutoHideCaptions(blnEnableAutoHide, blnShowHiddenCaptionsIfDisabled)
    End Sub

    Public Sub SetAnnotationDensityToleranceX(ByVal dblNewThreshold As Double)
        SpectrumForm.ctlCWGraph.SetAnnotationDensityToleranceX(dblNewThreshold)
    End Sub

    Public Sub SetAnnotationDensityToleranceY(ByVal dblNewThreshold As Double)
        SpectrumForm.ctlCWGraph.SetAnnotationDensityToleranceY(dblNewThreshold)
    End Sub

    Public Sub SetAnnotationDensityToleranceAutoAdjust(ByVal blnEnableAutoAdjust As Boolean)
        SpectrumForm.ctlCWGraph.SetAnnotationDensityToleranceAutoAdjust(blnEnableAutoAdjust)
    End Sub

    Public Sub SetAutoscaleXAxis(ByVal blnEnableAutoscale As Boolean)
        SpectrumForm.ctlCWGraph.SetAutoscaleXAxis(blnEnableAutoscale)
    End Sub

    Public Sub SetAutoscaleYAxis(ByVal blnEnableAutoscale As Boolean)
        SpectrumForm.ctlCWGraph.SetAutoscaleYAxis(blnEnableAutoscale)
    End Sub

    Public Sub SetAutoAdjustScalingToIncludeCaptions(ByVal blnEnable As Boolean)
        SpectrumForm.ctlCWGraph.SetAutoAdjustScalingToIncludeCaptions(blnEnable)
    End Sub

    Public Sub SetAutoLabelPeaksOptions(ByVal udtNewAutoLabelOptions As udtAutoLabelPeaksOptionsType)
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
        SpectrumForm.RetrieveAutoLabelPeaksOptionsFromModule()

    End Sub

    Public Sub SetAutoscaleVisibleY(ByVal blnEnableAutoscale As Boolean, ByVal blnFixMinimumYAtZero As Boolean)
        SpectrumForm.ctlCWGraph.SetAutoscaleVisibleY(blnEnableAutoscale, blnFixMinimumYAtZero)
    End Sub

    Public Sub SetCursorColor(ByVal cNewColor As System.Drawing.Color, Optional ByVal intCursorNumber As Integer = 1)
        SpectrumForm.ctlCWGraph.SetCursorColor(cNewColor, intCursorNumber)
    End Sub

    Public Sub SetCursorPosition(ByVal XPos As Double, ByVal YPos As Double, Optional ByVal intCursorNumber As Integer = 1)
        SpectrumForm.ctlCWGraph.SetCursorPosition(XPos, YPos, intCursorNumber)
    End Sub

    Public Sub SetCursorSnapMode(ByVal blnSnapToData As Boolean)
        SpectrumForm.ctlCWGraph.SetCursorSnapMode(blnSnapToData)
    End Sub

    Public Sub SetCursorVisible(ByVal blnShowCursor As Boolean, Optional ByVal intCursorNumber As Integer = 1)
        SpectrumForm.ctlCWGraph.SetCursorVisible(blnShowCursor, intCursorNumber)
    End Sub

    Public Sub SetDataXvsY(ByVal intSeriesNumber As Short, ByRef XDataZeroBased1DArray() As Double, ByRef YDataZeroBased1DArray() As Double, ByVal DataCount As Integer, Optional ByVal strLegendCaption As String = "", Optional ByVal dblOriginalMaximumIntensity As Double = 0)
        SpectrumForm.ctlCWGraph.SetDataXvsY(intSeriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, DataCount, strLegendCaption, dblOriginalMaximumIntensity)
    End Sub

    Public Sub SetDataYOnly(ByVal intSeriesNumber As Short, ByRef YDataZeroBased1DArray() As Double, ByVal YDataCount As Integer, Optional ByVal dblXFirst As Double = 0, Optional ByVal dblIncrement As Double = 1, Optional ByVal strLegendCaption As String = "", Optional ByVal dblOriginalMaximumIntensity As Double = 0)
        SpectrumForm.ctlCWGraph.SetDataYOnly(intSeriesNumber, YDataZeroBased1DArray, YDataCount, dblXFirst, dblIncrement, strLegendCaption, dblOriginalMaximumIntensity)
    End Sub

    Public Sub SetDisplayPrecisionX(ByVal intPrecision As Short)
        SpectrumForm.ctlCWGraph.SetDisplayPrecisionX(intPrecision)
    End Sub

    Public Sub SetDisplayPrecisionY(ByVal intPrecision As Short)
        SpectrumForm.ctlCWGraph.SetDisplayPrecisionY(intPrecision)
    End Sub

    Public Sub SetGridLinesXColor(ByVal cNewColor As System.Drawing.Color, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False, Optional ByVal blnUpdateTickColors As Boolean = True)
        SpectrumForm.ctlCWGraph.SetGridLinesXColor(cNewColor, blnMajorGridLines, blnApplyToAllAxes, blnUpdateTickColors)
    End Sub

    Public Sub SetGridLinesYColor(ByVal cNewColor As System.Drawing.Color, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False, Optional ByVal blnUpdateTickColors As Boolean = True)
        SpectrumForm.ctlCWGraph.SetGridLinesYColor(cNewColor, blnMajorGridLines, blnApplyToAllAxes, blnUpdateTickColors)
    End Sub

    Public Sub SetGridLinesXVisible(ByVal blnShowGridLines As Boolean, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False)
        SpectrumForm.ctlCWGraph.SetGridLinesXVisible(blnShowGridLines, blnMajorGridLines, blnApplyToAllAxes)
    End Sub

    Public Sub SetGridLinesYVisible(ByVal blnShowGridLines As Boolean, Optional ByVal blnMajorGridLines As Boolean = True, Optional ByVal blnApplyToAllAxes As Boolean = False)
        SpectrumForm.ctlCWGraph.SetGridLinesYVisible(blnShowGridLines, blnMajorGridLines, blnApplyToAllAxes)
    End Sub

    Public Sub SetLabelFontColor(ByVal cNewColor As System.Drawing.Color)
        SpectrumForm.ctlCWGraph.SetLabelFontColor(cNewColor)
    End Sub

    Public Sub SetLabelFontName(ByVal strFontName As String)
        SpectrumForm.ctlCWGraph.SetLabelFontName(strFontName)
    End Sub

    Public Sub SetLabelFontSize(ByVal intNewSize As Short)
        SpectrumForm.ctlCWGraph.SetLabelFontSize(intNewSize)
    End Sub

    Public Sub SetLabelXAxis(ByVal strAxisLabel As String)
        SpectrumForm.ctlCWGraph.SetLabelXAxis(strAxisLabel)
    End Sub

    Public Sub SetLabelYAxis(ByVal strAxisLabel As String)
        SpectrumForm.ctlCWGraph.SetLabelYAxis(strAxisLabel)
    End Sub

    Public Sub SetLabelTitle(ByVal strTitle As String)
        SpectrumForm.ctlCWGraph.SetLabelTitle(strTitle)
    End Sub

    Public Sub SetLabelSubTitle(ByVal strSubTitle As String)
        SpectrumForm.ctlCWGraph.SetLabelSubTitle(strSubTitle)
    End Sub

    Public Sub SetPlotBackgroundColor(ByVal cNewColor As System.Drawing.Color)
        SpectrumForm.ctlCWGraph.SetPlotBackgroundColor(cNewColor)
    End Sub

    Public Sub SetRangeX(ByVal dblMinimum As Double, ByVal dblMaximum As Double, Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnReturnAnnotationVisibilityChecked As Boolean = False)
        SpectrumForm.ctlCWGraph.SetRangeX(dblMinimum, dblMaximum, blnAddToZoomHistory, blnReturnAnnotationVisibilityChecked)
    End Sub

    Public Sub SetRangeY(ByVal dblMinimum As Double, ByVal dblMaximum As Double, Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnReturnAnnotationVisibilityChecked As Boolean = False)
        SpectrumForm.ctlCWGraph.SetRangeY(dblMinimum, dblMaximum, blnAddToZoomHistory, blnReturnAnnotationVisibilityChecked)
    End Sub

    Public Sub SetSeriesBarFillColor(ByVal intSeriesNumber As Short, ByVal cNewColor As System.Drawing.Color)
        SpectrumForm.ctlCWGraph.SetSeriesBarFillColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesColor(ByVal intSeriesNumber As Short, ByVal cNewColor As System.Drawing.Color)
        SpectrumForm.ctlCWGraph.SetSeriesColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesCount(ByVal intCount As Short)
        SpectrumForm.ctlCWGraph.SetSeriesCount(intCount)
    End Sub

    Public Sub SetSeriesLegendCaption(ByVal intSeriesNumber As Short, ByVal strNewCaption As String)
        SpectrumForm.ctlCWGraph.SetSeriesLegendCaption(intSeriesNumber, strNewCaption)
    End Sub

    Public Sub SetSeriesLineColor(ByVal intSeriesNumber As Short, ByVal cNewColor As System.Drawing.Color)
        SpectrumForm.ctlCWGraph.SetSeriesLineColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesLineToBaseColor(ByVal intSeriesNumber As Short, ByVal cNewColor As System.Drawing.Color)
        SpectrumForm.ctlCWGraph.SetSeriesLineToBaseColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesLineStyle(ByVal intSeriesNumber As Short, ByVal eLineStyle As CWUIControlsLib.CWLineStyles)
        SpectrumForm.ctlCWGraph.SetSeriesLineStyle(intSeriesNumber, eLineStyle)
    End Sub

    Public Sub SetSeriesLineWidth(ByVal intSeriesNumber As Short, ByVal intWidth As Short)
        SpectrumForm.ctlCWGraph.SetSeriesLineWidth(intSeriesNumber, intWidth)
    End Sub

    Public Sub SetSeriesOriginalIntensityMaximum(ByVal intSeriesNumber As Short, ByVal dblNewOriginalMaximumIntensity As Double)
        SpectrumForm.ctlCWGraph.SetSeriesOriginalIntensityMaximum(intSeriesNumber, dblNewOriginalMaximumIntensity)
    End Sub

    Public Sub SetSeriesPlotMode(ByVal intSeriesNumber As Short, ByVal ePlotMode As CWGraphControl.pmPlotModeConstants, ByVal blnMakeDefault As Boolean)
        SpectrumForm.ctlCWGraph.SetSeriesPlotMode(intSeriesNumber, ePlotMode, blnMakeDefault)
    End Sub

    Public Sub SetSeriesPointColor(ByVal intSeriesNumber As Short, ByVal cNewColor As System.Drawing.Color)
        SpectrumForm.ctlCWGraph.SetSeriesPointColor(intSeriesNumber, cNewColor)
    End Sub

    Public Sub SetSeriesPointStyle(ByVal intSeriesNumber As Short, ByVal ePointStyle As CWUIControlsLib.CWPointStyles)
        SpectrumForm.ctlCWGraph.SetSeriesPointStyle(intSeriesNumber, ePointStyle)
    End Sub

    Public Sub SetSeriesStartAndIncrement(ByVal intSeriesNumber As Short, ByVal dblXFirst As Double, ByVal dblIncrement As Double)
        SpectrumForm.ctlCWGraph.SetSeriesStartAndIncrement(intSeriesNumber, dblXFirst, dblIncrement)
    End Sub

    Public Sub SetSeriesVisible(ByVal intSeriesNumber As Short, ByVal blnShowSeries As Boolean)
        SpectrumForm.ctlCWGraph.SetSeriesVisible(intSeriesNumber, blnShowSeries)
    End Sub

    Public Sub SetSpectrumFormCurrentSeriesNumber(ByVal intSeriesNumber As Short)
        SpectrumForm.SetCurrentSeriesNumber(intSeriesNumber)
    End Sub

    Public Sub SetSpectrumFormNormalizeOnLoadOrPaste(ByVal blnEnable As Boolean)
        SpectrumForm.SetNormalizeOnLoadOrPaste(blnEnable)
    End Sub

    Public Sub SetSpectrumFormNormalizationConstant(ByVal dblNewNormalizationConstant As Double)
        SpectrumForm.SetNormalizationConstant(dblNewNormalizationConstant)
    End Sub

    Public Sub SetSpectrumFormWindowPos(ByVal Top As Integer, ByVal intLeft As Integer, ByVal Height As Integer, ByVal Width As Integer)
        SpectrumForm.SetWindowPos(Top, intLeft, Height, Width)
    End Sub

    Public Sub SetSpectrumFormWindowCaption(ByVal strTitle As String)
        SpectrumForm.SetWindowCaption(strTitle)
    End Sub
    Public Sub ShowAutoLabelPeaksDialog(Optional ByVal blnShowModal As Boolean = True)
        SpectrumForm.ShowAutoLabelPeaksDialog(blnShowModal)
    End Sub

    Public Sub ShowZoomRangeDialog()
        SpectrumForm.ShowZoomRangeDialog()
    End Sub

    Public Sub ShowHideControls(ByVal blnHideControlsFrame As Boolean)
        SpectrumForm.ctlCWGraph.ShowHideControls(blnHideControlsFrame)
    End Sub

    Public Sub ShowHideAnnotations(Optional ByVal blnForceOperation As Boolean = False)
        SpectrumForm.ctlCWGraph.ShowHideAnnotations(blnForceOperation)
    End Sub

    Public Sub InitializeSpectrum()
        ' Initialize SpectrumForm, if necessary
        If Not mSpectrumLoaded Then
            SpectrumForm = New frmCWSpectrum
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
        SpectrumForm.ctlCWGraph.UpdateAllDynamicAnnotationCaptions()
    End Sub

    Public Sub ZoomOutFull(Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnAllowFixMinimumYAtZero As Boolean = True)
        SpectrumForm.ctlCWGraph.ZoomOutFull(blnAddToZoomHistory, blnAllowFixMinimumYAtZero)
    End Sub

    Public Sub ZoomToPrevious()
        SpectrumForm.ctlCWGraph.ZoomToPrevious()
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

    Private Sub SpectrumForm_SpectrumFormRequestClose() Handles SpectrumForm.SpectrumFormRequestClose
        RaiseEvent SpectrumFormRequestClose()
        If mSpectrumLoaded Then
            SpectrumForm.Hide()
        End If
    End Sub
End Class