Imports System.Collections.Generic
Imports System.IO
Imports System.Runtime.InteropServices
Imports OxyPlot
Imports OxyPlot.Annotations
Imports OxyPlot.Axes
Imports OxyPlot.Series
Imports OxyPlot.WindowsForms

Public Class ctlOxyPlotControl

#Region "Constants"
    Public Const MAX_SERIES_COUNT As Integer = 32
#End Region

#Region "Enums"

    Public Enum SeriesPlotMode
        Lines = 0                 ' LineSeries
        SticksToZero = 1          ' StemSeries
        Points = 2                ' LineSeries
        PointsAndLines = 3        ' LineSeries
    End Enum

    Public Enum CaptionOffsetDirection
        TopLeft = 0
        TopCenter = 1
        TopRight = 2
        BottomLeft = 3
        BottomCenter = 4
        BottomRight = 5
        MiddleLeft = 6
        MiddleRight = 7
    End Enum
#End Region

#Region "Structures"

    Public Structure udtGridlineStyle
        Public GridlineStyle As LineStyle
        Public GridlineColor As Color
        Public GridlineThickness As Double
    End Structure

    ''' <summary>
    ''' Describes a data point found by FindNearestDataPoint or LookupNearestPointNumber
    ''' </summary>
    Public Structure udtDataPointSearchResult
        ''' <summary>
        ''' DataPoint closest to coordinate SearchX, SearchY
        ''' </summary>
        Public MatchedDataPoint As DataPoint

        ''' <summary>
        ''' Series number for the data point
        ''' </summary>
        Public SeriesNumber As Integer

        ''' <summary>
        ''' Data point index
        ''' </summary>
        Public DataPointIndex As Integer

        ''' <summary>
        ''' Distance of the data point to coordinate SearchX,SearchY
        ''' </summary>
        Public DistanceFromSearchCoords As Double

        ''' <summary>
        ''' X value of the desired coordinate
        ''' </summary>
        Public SearchX As Double

        ''' <summary>
        ''' Y value of the desired coordinate
        ''' </summary>
        Public SearchY As Double

    End Structure
#End Region

#Region "Properties"

    Public Property AutoscaleXAxis As Boolean
        Get
            Return mAutoscaleXAxis
        End Get
        Set(value As Boolean)
            If mAutoscaleXAxis = False And value = True Then
                SetRangeX(Double.NaN, Double.NaN)
            End If

            mAutoscaleXAxis = value
        End Set
    End Property

    Public Property AutoscaleYAxis As Boolean
        Get
            Return mAutoscaleYAxis
        End Get
        Set(value As Boolean)
            If mAutoscaleYAxis = False And value = True Then
                SetRangeY(Double.NaN, Double.NaN)
            End If
            mAutoscaleYAxis = value
        End Set
    End Property

    Public Property LegendPlacement As LegendPlacement
        Get
            Return ctlOxyPlot.Model.LegendPlacement
        End Get
        Set(value As LegendPlacement)
            ctlOxyPlot.Model.LegendPlacement = value
        End Set
    End Property

    Public Property LegendPosition As LegendPosition
        Get
            Return ctlOxyPlot.Model.LegendPosition
        End Get
        Set(value As LegendPosition)
            ctlOxyPlot.Model.LegendPosition = value
        End Set
    End Property

    Public Property XAxisAbsoluteMinimum As Double
        Get
            Return mXAxis.AbsoluteMinimum
        End Get
        Set(value As Double)
            mXAxis.AbsoluteMinimum = value
        End Set
    End Property

    Public Property XAxisAbsoluteMaximum As Double
        Get
            Return mXAxis.AbsoluteMaximum
        End Get
        Set(value As Double)
            mXAxis.AbsoluteMaximum = value
        End Set
    End Property

    Public Property YAxisAbsoluteMinimum As Double
        Get
            Return mYAxis.AbsoluteMinimum
        End Get
        Set(value As Double)
            mYAxis.AbsoluteMinimum = value
        End Set
    End Property

    Public Property YAxisAbsoluteMaximum As Double
        Get
            Return mYAxis.AbsoluteMaximum
        End Get
        Set(value As Double)
            mYAxis.AbsoluteMaximum = value
        End Set
    End Property

    ''' <summary>
    ''' Padding fraction in the negative X direction; default 0.01
    ''' </summary>
    ''' <remarks>Larger values result in more whitespace to the left of the data</remarks>
    Public Property XAxisPaddingMinimum As Double
        Get
            Return mXAxis.MinimumPadding
        End Get
        Set(value As Double)
            mXAxis.MinimumPadding = value
        End Set
    End Property

    ''' <summary>
    ''' Padding fraction in the positive X direction; default 0.01
    ''' </summary>
    ''' <remarks>Larger values result in more whitespace to the right of the data</remarks>
    Public Property XAxisPaddingMaximum As Double
        Get
            Return mXAxis.MaximumPadding
        End Get
        Set(value As Double)
            mXAxis.MaximumPadding = value
        End Set
    End Property

    ''' <summary>
    ''' Padding fraction in the negative Y direction; default 0.01
    ''' </summary>
    ''' <remarks>Larger values result in more whitespace below the data</remarks>
    Public Property YAxisPaddingMinimum As Double
        Get
            Return mYAxis.MinimumPadding
        End Get
        Set(value As Double)
            mYAxis.MinimumPadding = value
        End Set
    End Property

    ''' <summary>
    ''' Padding fraction in the positive Y direction; default 0.01
    ''' </summary>
    ''' <remarks>Larger values result in more whitespace above the data</remarks>
    Public Property YAxisPaddingMaximum As Double
        Get
            Return mYAxis.MaximumPadding
        End Get
        Set(value As Double)
            mYAxis.MaximumPadding = value
        End Set
    End Property

#End Region

#Region "Member variables"

    ' 0-based array
    Private ReadOnly mSeriesPlotMode(MAX_SERIES_COUNT) As SeriesPlotMode

    Private ReadOnly mXAxis As Axis
    Private ReadOnly mYAxis As Axis

    Private ReadOnly mAnnotationsBySeries As Dictionary(Of Integer, List(Of Annotation))

    Private mAutoscaleXAxis As Boolean = True
    Private mAutoscaleYAxis As Boolean = True

#End Region

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim oNewModel = New PlotModel()
        ctlOxyPlot.Model = oNewModel

        mXAxis = New LinearAxis()

        mYAxis = New LinearAxis() With {
            .AbsoluteMinimum = 0,
            .MinimumPadding = 0.05,
            .MaximumPadding = 0.05
        }

        mAnnotationsBySeries = New Dictionary(Of Integer, List(Of Annotation))

        InitializePlotModel()

        lblMouseHints.Text = "Zoom using the scroll wheel near an axis or in the middle of the plot" + ControlChars.NewLine +
            "Alternatively, draw a rectangle with the middle mouse button or via Ctrl+Alt+LeftClick" + ControlChars.NewLine +
            "Zoom out by double clicking the middle mouse button or using Ctrl+Alt+LeftDoubleClick" + ControlChars.NewLine +
            "Pan by right clicking and drawing a rectangle"
    End Sub

    Private Sub AddSeriesAnnotationToCache(seriesNumber As Integer, oAnnotation As Annotation)
        Dim seriesAnnotations As List(Of Annotation) = Nothing

        If Not mAnnotationsBySeries.TryGetValue(seriesNumber, seriesAnnotations) Then
            seriesAnnotations = New List(Of Annotation)
            mAnnotationsBySeries.Add(seriesNumber, seriesAnnotations)
        End If

        seriesAnnotations.Add(oAnnotation)

    End Sub

    ''' <summary>
    ''' Validates that seriesNumber is a number between 1 and the number of series on the plot
    ''' </summary>
    ''' <param name="seriesNumber">Input/Output: series number</param>
    ''' <returns>Series index to use, i.e. seriesNumber - 1</returns>
    ''' <remarks>Auto-updates seriesNumber to "1" if out of range</remarks>
    Private Function AssureValidSeriesNumber(ByRef seriesNumber As Integer) As Integer
        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then seriesNumber = 1
        Return seriesNumber - 1
    End Function

    ''' <summary>
    ''' Reset the X axis zoom / panning
    ''' </summary>
    Public Sub AutoScaleXNow()
        mXAxis.Reset()
        ctlOxyPlot.InvalidatePlot(True)
    End Sub

    ''' <summary>
    ''' Reset the Y axis zoom / panning
    ''' </summary>
    Public Sub AutoScaleYNow()
        mYAxis.Reset()
        ctlOxyPlot.InvalidatePlot(True)
    End Sub

    ''' <summary>
    ''' Clear data on the specified series (but does not remove the series)
    ''' </summary>
    ''' <param name="seriesNumber">Series number (series 1 is the first series)</param>
    ''' <remarks>Use RemoveSeries to remove the series entirely</remarks>
    Public Sub ClearData(seriesNumber As Integer)

        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then Exit Sub

        Dim seriesIndex = AssureValidSeriesNumber(seriesNumber)

        ctlOxyPlot.Model.Series.RemoveAt(seriesIndex)
        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                oSeries.Points.Clear()

            Case SeriesPlotMode.Lines, SeriesPlotMode.Points, SeriesPlotMode.PointsAndLines
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                oSeries.Points.Clear()

            Case Else
                Throw New NotSupportedException("Unrecognized plot mode in ClearData")
        End Select

    End Sub

    Private Function ColorToOxyColor(eColor As Color) As OxyColor
        Return OxyColor.FromArgb(eColor.A, eColor.R, eColor.G, eColor.B)
    End Function

    ''' <summary>
    ''' Find the data point closest to locationX,locationY in series seriesIndex
    ''' </summary>
    ''' <param name="seriesIndex">Index of the series to search</param>
    ''' <param name="searchPosX">Target X</param>
    ''' <param name="searchPosY">Target Y</param>
    ''' <param name="xAxisOnly">When true, only compare locationX to X axis values in the data</param>
    ''' <returns>Structure describing the closest data point</returns>
    Private Function FindNearestDataPoint(
      seriesIndex As Integer,
      searchPosX As Double,
      searchPosY As Double,
      xAxisOnly As Boolean) As udtDataPointSearchResult

        Dim oSeries As LineSeries

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)

            Case SeriesPlotMode.Lines, SeriesPlotMode.Points, SeriesPlotMode.PointsAndLines
                oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)

            Case Else
                Throw New NotSupportedException("Unrecognized plot mode in FindNearestDataPoint")
        End Select

        Dim searchResult = New udtDataPointSearchResult() With {
            .SeriesNumber = seriesIndex + 1,
            .DistanceFromSearchCoords = Double.MaxValue,
            .SearchX = searchPosX,
            .SearchY = searchPosY
        }

        If oSeries.Points.Count = 0 Then
            Return searchResult
        End If

        Dim dataPointIndex = 0

        Dim minimumX As Double = Double.MaxValue
        Dim yScalingOffset As Double = 0
        Dim yScalingDivisor As Double = 1

        If Not xAxisOnly Then

            ' Determine the scaling factors that will be used to scale Y values to the same range as the X values
            Dim maximumX As Double = Double.MinValue

            Dim minimumY As Double = Double.MaxValue
            Dim maximumY As Double = Double.MinValue

            For Each dataPoint In oSeries.Points
                If dataPoint.X < minimumX Then minimumX = dataPoint.X
                If dataPoint.X > maximumX Then maximumX = dataPoint.X

                If dataPoint.Y < minimumY Then minimumY = dataPoint.Y
                If dataPoint.Y > maximumY Then maximumY = dataPoint.Y
            Next

            If minimumX < maximumX AndAlso minimumY < maximumY Then
                yScalingOffset = minimumY - minimumX
                yScalingDivisor = (maximumY - minimumY) / (maximumX - minimumX)

                If Math.Abs(yScalingDivisor) < Single.Epsilon Then
                    xAxisOnly = True
                End If
            Else
                ' X values and/or Y values are all the same; cannot scale
                xAxisOnly = True
            End If
        End If

        Dim scaledSearchPosX As Double
        Dim scaledSearchPosY As Double

        If xAxisOnly Then
            scaledSearchPosX = searchPosX
            scaledSearchPosY = searchPosY
        Else
            scaledSearchPosX = searchPosX - minimumX
            scaledSearchPosY = (searchPosY - yScalingOffset) / yScalingDivisor
        End If

        For Each dataPoint In oSeries.Points
            Dim distance As Double
            If xAxisOnly Then
                distance = Math.Abs(dataPoint.X - searchPosX)
            Else
                distance = Math.Sqrt(((dataPoint.X - minimumX) - scaledSearchPosX) ^ 2 +
                                     ((dataPoint.Y - yScalingOffset) / yScalingDivisor - scaledSearchPosY) ^ 2)
            End If

            If distance < searchResult.DistanceFromSearchCoords Then
                searchResult.MatchedDataPoint = dataPoint
                searchResult.DataPointIndex = dataPointIndex
                searchResult.DistanceFromSearchCoords = distance
            End If

            dataPointIndex += 1
        Next

        Return searchResult

    End Function

    Private Sub FormatSeries(seriesIndex As Integer)

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                With oSeries
                    If .LineStyle = LineStyle.None Then .LineStyle = LineStyle.Solid
                    .MarkerType = MarkerType.None
                End With

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)

                With oSeries
                    Select Case mSeriesPlotMode(seriesIndex)
                        Case SeriesPlotMode.Lines
                            If .LineStyle = LineStyle.None Then .LineStyle = LineStyle.Solid
                            .MarkerType = MarkerType.None
                        Case SeriesPlotMode.Points
                            .LineStyle = LineStyle.None
                            If .MarkerType = MarkerType.None Then .MarkerType = MarkerType.Square
                        Case SeriesPlotMode.PointsAndLines
                            If .LineStyle = LineStyle.None Then .LineStyle = LineStyle.Solid
                            If .MarkerType = MarkerType.None Then .MarkerType = MarkerType.Square
                    End Select
                End With
        End Select

    End Sub

    Public Sub GenerateSineWave(seriesNumber As Integer, blnXAxisLogBased As Boolean)

        Const DATA_COUNT As Short = 1021
        Dim dblDataX(DATA_COUNT - 1) As Double
        Dim dblDataY(DATA_COUNT - 1) As Double
        Dim index As Integer

        For index = 0 To DATA_COUNT - 1
            dblDataX(index) = Math.Log(index + 1)
            dblDataY(index) = Math.Sin(index / 25.0#) * 100
        Next index

        If blnXAxisLogBased Then
            SetDataXvsY(seriesNumber, dblDataX, dblDataY, DATA_COUNT, SeriesPlotMode.Lines, "Sine wave, log X")
        Else
            SetDataYOnly(seriesNumber, dblDataY, DATA_COUNT, SeriesPlotMode.Lines, 1, 0.02, "Sine wave")
        End If

    End Sub

    Public Function GetAnnotationByIndex(annotationIndex As Integer) As Annotation
        If annotationIndex >= 0 AndAlso annotationIndex < ctlOxyPlot.Model.Annotations.Count Then
            Return ctlOxyPlot.Model.Annotations(annotationIndex)
        End If

        Throw New ArgumentOutOfRangeException(NameOf(annotationIndex))
    End Function

    Public Function GetAnnotationCount() As Integer
        Return ctlOxyPlot.Model.Annotations.Count
    End Function

    Public Function GetDataCount(seriesNumber As Integer) As Integer

        Dim seriesIndex As Integer = seriesNumber - 1

        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then
            Return 0
        Else
            Select Case mSeriesPlotMode(seriesIndex)
                Case SeriesPlotMode.SticksToZero
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                    Return oSeries.Points.Count
                Case Else
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                    Return oSeries.Points.Count
            End Select
        End If

    End Function

    Public Function GetDataXvsY(seriesNumber As Integer) As List(Of DataPoint)

        If ctlOxyPlot.Model.Series.Count = 0 Then
            Return New List(Of DataPoint)
        End If

        Dim seriesIndex = AssureValidSeriesNumber(seriesNumber)

        Dim oSeries As LineSeries

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)

            Case SeriesPlotMode.Lines, SeriesPlotMode.Points, SeriesPlotMode.PointsAndLines
                oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)

            Case Else
                Throw New NotSupportedException("Unrecognized plot mode in GetDataXvsY")
        End Select

        Return oSeries.Points

    End Function

    Public Function GetDefaultSeriesColor(seriesNumber As Integer) As OxyColor
        Dim lstColors = ctlOxyPlot.Model.DefaultColors

        Do While seriesNumber > lstColors.Count
            seriesNumber -= lstColors.Count
        Loop

        If seriesNumber <= lstColors.Count Then
            Return lstColors(seriesNumber - 1)
        Else
            Return lstColors(0)
        End If

    End Function

    ''' <summary>
    ''' Creates a new line series
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <param name="lstData">Data points for the new series</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNewLineSeries(strTitle As String, lstData As IEnumerable(Of DataPoint)) As LineSeries

        Dim oSeries = New LineSeries() With {
            .Title = strTitle,
            .CanTrackerInterpolatePoints = False
        }

        For Each item In lstData
            oSeries.Points.Add(item)
        Next

        Return oSeries

    End Function

    ''' <summary>
    ''' Creates a new stem series
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <returns></returns>
    ''' <remarks>Will be an empty series without any data points</remarks>
    Private Function GetNewStemSeries(strTitle As String, lstData As IEnumerable(Of DataPoint)) As StemSeries

        Dim oSeries = New StemSeries() With {
            .Title = strTitle,
            .CanTrackerInterpolatePoints = False
        }

        For Each item In lstData
            oSeries.Points.Add(item)
        Next

        Return oSeries

    End Function

    ''' <summary>
    ''' Get a vector for placing an annotation at a position relative to a data point
    ''' </summary>
    ''' <param name="captionOffsetDirection"></param>
    ''' <param name="offsetPixels"></param>
    ''' <returns></returns>
    Private Function GetOffsetVector(
      captionOffsetDirection As CaptionOffsetDirection,
      offsetPixels As Integer) As ScreenVector

        Select Case captionOffsetDirection
            Case CaptionOffsetDirection.TopLeft
                Return New ScreenVector(offsetPixels, offsetPixels)

            Case CaptionOffsetDirection.TopCenter
                Return New ScreenVector(0, offsetPixels)

            Case CaptionOffsetDirection.TopRight
                Return New ScreenVector(-offsetPixels, offsetPixels)

            Case CaptionOffsetDirection.BottomLeft
                Return New ScreenVector(offsetPixels, -offsetPixels)

            Case CaptionOffsetDirection.BottomCenter
                Return New ScreenVector(0, -offsetPixels)

            Case CaptionOffsetDirection.BottomRight
                Return New ScreenVector(-offsetPixels, -offsetPixels)

            Case CaptionOffsetDirection.MiddleLeft
                Return New ScreenVector(offsetPixels, 0)

            Case CaptionOffsetDirection.MiddleRight
                Return New ScreenVector(-offsetPixels, 0)
            Case Else
                ' Same as CaptionOffsetDirection.TopLeft
                Return New ScreenVector(offsetPixels, offsetPixels)
        End Select

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
        If visibleDataOnly Then
            minimum = mXAxis.ActualMinimum
            maximum = mXAxis.ActualMaximum
        Else
            minimum = mXAxis.DataMinimum
            maximum = mXAxis.DataMaximum
        End If

        Return maximum - minimum
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
        If visibleDataOnly Then
            minimum = mYAxis.ActualMinimum
            maximum = mYAxis.ActualMaximum
        Else
            minimum = mYAxis.DataMinimum
            maximum = mYAxis.DataMaximum
        End If

        Return maximum - minimum
    End Function

    Public Function GetSeriesCount() As Integer
        Return ctlOxyPlot.Model.Series.Count
    End Function

    Public Function GetSeriesPointColor(seriesNumber As Integer) As Color
        Dim eColor = GetSeriesPointOxyColor(seriesNumber)
        Return eColor.ToColor()
    End Function

    Public Function GetSeriesPointOxyColor(seriesNumber As Integer) As OxyColor

        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(seriesNumber))
        End If

        Dim seriesIndex = seriesNumber - 1

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                Return oSeries.MarkerFill

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                Return oSeries.MarkerFill
        End Select

    End Function

    Public Function GetSeriesPointStyle(seriesNumber As Integer) As MarkerType

        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(seriesNumber))
        End If

        Dim seriesIndex = seriesNumber - 1

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                Return oSeries.MarkerType

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                Return oSeries.MarkerType
        End Select

    End Function

    Private Sub InitializePlotModel()

        mXAxis.Title = "X-axis"
        mXAxis.Position = AxisPosition.Bottom

        mYAxis.Title = "Y-axis"
        mYAxis.Position = AxisPosition.Left

        ctlOxyPlot.Model.Axes.Clear()
        ctlOxyPlot.Model.Axes.Add(mXAxis)
        ctlOxyPlot.Model.Axes.Add(mYAxis)

        ctlOxyPlot.Invalidate()
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

        Dim startSeriesNumber As Integer
        Dim endSeriesNumber As Integer

        If limitToGivenSeriesNumber Then
            AssureValidSeriesNumber(seriesNumber)
            startSeriesNumber = seriesNumber
            endSeriesNumber = seriesNumber
        Else
            startSeriesNumber = 1
            endSeriesNumber = ctlOxyPlot.Model.Series.Count
        End If

        Dim searchResult = New udtDataPointSearchResult() With {
            .SeriesNumber = 0,
            .DistanceFromSearchCoords = Double.MaxValue,
            .SearchX = searchPosX,
            .SearchY = searchPosY
        }

        For seriesNumberToCheck = startSeriesNumber To endSeriesNumber
            Dim seriesIndex = seriesNumberToCheck - 1

            Dim candidateResult = FindNearestDataPoint(seriesIndex, searchPosX, searchPosY, xAxisOnly)

            If candidateResult.DistanceFromSearchCoords < searchResult.DistanceFromSearchCoords Then

                searchResult.SeriesNumber = seriesNumberToCheck
                searchResult.DataPointIndex = candidateResult.DataPointIndex
                searchResult.DistanceFromSearchCoords = candidateResult.DistanceFromSearchCoords
                searchResult.MatchedDataPoint = candidateResult.MatchedDataPoint

            End If
        Next

        Return searchResult

    End Function

    ''' <summary>
    ''' Invalidate (redraw) the plot
    ''' </summary>
    Private Sub InvalidatePlot()
        ctlOxyPlot.Model.InvalidatePlot(True)
    End Sub

    Public Sub RemoveAllAnnotations()
        ctlOxyPlot.Model.Annotations.Clear()
        InvalidatePlot()
    End Sub

    Public Sub RemoveAnnotationByIndex(annotationIndex As Integer)
        If annotationIndex >= 0 AndAlso annotationIndex < ctlOxyPlot.Model.Annotations.Count Then
            ctlOxyPlot.Model.Annotations.RemoveAt(annotationIndex)
            InvalidatePlot()
        End If

        Throw New ArgumentOutOfRangeException(NameOf(annotationIndex))
    End Sub

    Public Sub RemoveAnnotationsForSeries(seriesNumber As Integer)
        Dim seriesAnnotations As List(Of Annotation) = Nothing

        If Not mAnnotationsBySeries.TryGetValue(seriesNumber, seriesAnnotations) Then
            Return
        End If

        Dim annotationsToRemove = New List(Of Annotation)

        For Each annotationToFind In seriesAnnotations
            annotationsToRemove.AddRange(From existingAnnotation In ctlOxyPlot.Model.Annotations Where existingAnnotation.Equals(annotationToFind))
        Next

        For Each item In annotationsToRemove
            ctlOxyPlot.Model.Annotations.Remove(item)
        Next

        InvalidatePlot()

    End Sub

    Public Sub RemoveSeries(seriesNumber As Integer)
        Dim seriesCount = GetSeriesCount()

        If seriesNumber < 1 Or seriesNumber > seriesCount Then
            Throw New ArgumentOutOfRangeException(NameOf(seriesNumber))
        End If

        Dim seriesIndex = seriesNumber - 1
        ctlOxyPlot.Model.Series.RemoveAt(seriesIndex)

        InvalidatePlot()

    End Sub

    Public Sub SavePlotAsPNG(filePath As String)

        Dim svgCode = ctlOxyPlot.Model.ToSvg(Me.Width, Me.Height, True)

        Dim tempFilePath = Path.GetTempFileName()

        Using writer = New StreamWriter(New FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            writer.WriteLine(svgCode)
        End Using

        Dim doc = Svg.SvgDocument.Open(tempFilePath)

        Dim bitmap = doc.Draw()
        bitmap.Save(filePath, Imaging.ImageFormat.Png)

        Try
            File.Delete(tempFilePath)
        Catch ex As Exception
            ' Ignore errors here
        End Try

    End Sub

    Public Sub SavePlotAsSvg(filePath As String)

        Dim svgCode = ctlOxyPlot.Model.ToSvg(Me.Width, Me.Height, True)

        Using writer = New StreamWriter(New FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            writer.WriteLine(svgCode)
        End Using

    End Sub

    ''' <summary>
    ''' Create an annotation for the given data point
    ''' </summary>
    ''' <param name="xyPoint"></param>
    ''' <param name="caption">Annotation text</param>
    ''' <param name="seriesNumber">Series number associated with targetDataPoint; 0 if not associated with a series</param>
    ''' <param name="captionOffsetDirection">Offset direction relative to X,Y</param>
    ''' <param name="offsetPixels">Offset distance</param>
    ''' <param name="includeArrow">True to include an arrow</param>
    ''' <param name="eLineStyle">Arrow line style if includeArrow is true; ignored if includeArrow is false</param>
    ''' <param name="lineWidth">Arrow line width if includeArrow is true, otherwise rectangle border width</param>
    ''' <param name="fontSize">Annotation text size</param>
    Public Sub SetAnnotation(
      xyPoint As DataPoint,
      caption As String,
      seriesNumber As Integer,
      captionOffsetDirection As CaptionOffsetDirection,
      offsetPixels As Integer,
      includeArrow As Boolean,
      eLineStyle As LineStyle,
      lineWidth As Integer,
      fontSize As Integer)

        If offsetPixels < 0 Then
            offsetPixels = 0
        End If

        Dim arrowDirection = GetOffsetVector(captionOffsetDirection, offsetPixels)

        Dim oAnnotation As Annotation

        If includeArrow Then
            oAnnotation = New ArrowAnnotation() With {
                .StartPoint = xyPoint,
                .EndPoint = xyPoint,
                .LineStyle = eLineStyle,
                .ArrowDirection = arrowDirection,
                .StrokeThickness = lineWidth,
                .Text = caption,
                .FontSize = fontSize
                }
        Else
            oAnnotation = New TextAnnotation() With {
                .TextPosition = xyPoint,
                .StrokeThickness = lineWidth,
                .Text = caption,
                .FontSize = fontSize
                }
        End If

        ctlOxyPlot.Model.Annotations.Add(oAnnotation)

        If seriesNumber > 0 Then
            AddSeriesAnnotationToCache(seriesNumber, oAnnotation)
        End If

    End Sub

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

        Dim xyPoint = New DataPoint(locationX, locationY)

        SetAnnotation(xyPoint, caption, 0, captionOffsetDirection, offsetPixels, includeArrow, eLineStyle, lineWidth, fontSize)

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

        Const xAxisOnly = False

        Dim searchResult As udtDataPointSearchResult

        If seriesNumber = 0 Then
            searchResult = LookupNearestPointNumber(locationX, locationY, xAxisOnly, seriesNumber, limitToGivenSeriesNumber:=False)
        Else
            Dim seriesIndex = AssureValidSeriesNumber(seriesNumber)
            searchResult = FindNearestDataPoint(seriesIndex, locationX, locationY, xAxisOnly)
        End If

        SetAnnotation(searchResult.MatchedDataPoint, caption, seriesNumber, captionOffsetDirection, offsetPixels, includeArrow, eLineStyle, lineWidth, fontSize)

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

    Private Sub SetAxisDisplayPrecision(oXaxis As Axis, precision As Short)

        ' formatString will be of the form {0:F2}
        Dim formatString As String = "{0:F" & precision & "}"

        oXaxis.LabelFormatter = Function(d) String.Format(formatString, d)
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

        If dataCount < 1 Then Exit Sub

        Dim lstData = New List(Of DataPoint)(dataCount)

        Dim minimumXValue As Double = Double.MaxValue
        Dim maximumXValue As Double = Double.MinValue

        Dim minimumYValue As Double = Double.MaxValue
        Dim maximumYValue As Double = Double.MinValue

        For index = 0 To dataCount - 1
            lstData.Add(New DataPoint(XDataZeroBased1DArray(index), YDataZeroBased1DArray(index)))

            ' Keep track of the minima and maxima
            If XDataZeroBased1DArray(index) < minimumXValue Then
                minimumXValue = XDataZeroBased1DArray(index)
            End If
            If XDataZeroBased1DArray(index) > maximumXValue Then
                maximumXValue = XDataZeroBased1DArray(index)
            End If

            If YDataZeroBased1DArray(index) < minimumYValue Then
                minimumYValue = YDataZeroBased1DArray(index)
            End If
            If YDataZeroBased1DArray(index) > maximumYValue Then
                maximumYValue = YDataZeroBased1DArray(index)
            End If
        Next

        Dim oSeries As Series
        Select Case ePlotMode
            Case SeriesPlotMode.SticksToZero
                oSeries = GetNewStemSeries(seriesTitle, lstData)
            Case SeriesPlotMode.Lines, SeriesPlotMode.Points, SeriesPlotMode.PointsAndLines
                oSeries = GetNewLineSeries(seriesTitle, lstData)
            Case Else
                Throw New NotSupportedException("Unrecognized plot mode in SetDataXvsY")
        End Select

        Dim seriesIndex As Integer

        If seriesNumber > ctlOxyPlot.Model.Series.Count Then
            ' Add a new series
            ctlOxyPlot.Model.Series.Add(oSeries)
            seriesNumber = ctlOxyPlot.Model.Series.Count
            seriesIndex = seriesNumber - 1
        Else
            ' Replace an existing data series
            seriesIndex = AssureValidSeriesNumber(seriesNumber)

            If ctlOxyPlot.Model.Annotations.Count > 0 Then
                RemoveAnnotationsForSeries(seriesNumber)
            End If

            ctlOxyPlot.Model.Series(seriesIndex) = oSeries
        End If

        mSeriesPlotMode(seriesIndex) = ePlotMode

        ' Determine the global minimum and maximum across all series
        For index = 0 To ctlOxyPlot.Model.Series.Count - 1
            ' Skip the current series since it has already been checked
            If index <> seriesIndex Then
                Dim seriesPoints = GetDataXvsY(index + 1)
                For Each dataItem In seriesPoints
                    If dataItem.X < minimumXValue Then
                        minimumXValue = dataItem.X
                    End If
                    If dataItem.X > maximumXValue Then
                        maximumXValue = dataItem.X
                    End If

                    If dataItem.Y < minimumYValue Then
                        minimumYValue = dataItem.Y
                    End If
                    If dataItem.Y > maximumYValue Then
                        maximumYValue = dataItem.Y
                    End If
                Next
            End If
        Next

        FormatSeries(seriesIndex)

        SetSeriesVisible(seriesNumber, True, False)

        ' Pad the absolute minima by 25% of the data range
        If maximumXValue > minimumXValue Then
            mXAxis.AbsoluteMinimum = minimumXValue - (maximumXValue - minimumXValue) * 0.25
            mXAxis.AbsoluteMaximum = maximumXValue + (maximumXValue - minimumXValue) * 0.25
        End If

        If maximumYValue > minimumYValue Then
            mYAxis.AbsoluteMinimum = minimumYValue - (maximumYValue - minimumYValue) * 0.25
            mYAxis.AbsoluteMaximum = maximumYValue + (maximumYValue - minimumYValue) * 0.25
        End If

        If AutoscaleXAxis Then
            mXAxis.Reset()
        End If

        If AutoscaleYAxis Then
            mYAxis.Reset()
        End If

        InvalidatePlot()

        ' ToDo: RecordZoomRange(True)

        ' ToDo: UpdateAllDynamicAnnotationCaptions()

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

        If YDataCount < 1 Then Exit Sub

        Dim XDataZeroBased1DArray() As Double
        ReDim XDataZeroBased1DArray(YDataCount - 1)

        For index = 0 To YDataCount - 1
            XDataZeroBased1DArray(index) = xFirst + xIncrement * index
        Next

        SetDataXvsY(seriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, YDataCount, ePlotMode, seriesTitle)

    End Sub

    Public Sub SetDisplayPrecisionX(precision As Short)
        SetAxisDisplayPrecision(mXAxis, precision)
    End Sub

    Public Sub SetDisplayPrecisionY(precision As Short)
        SetAxisDisplayPrecision(mYAxis, precision)
    End Sub

    Public Sub SetGridLinesStyleX(majorGridlineStyle As udtGridlineStyle)
        UpdateMajorGridlines(mXAxis, majorGridlineStyle)
    End Sub

    Public Sub SetGridLinesStyleX(majorGridlineStyle As udtGridlineStyle, minorGridlineStyle As udtGridlineStyle)
        UpdateMajorGridlines(mXAxis, majorGridlineStyle)
        UpdateMinorGridlines(mXAxis, majorGridlineStyle)
    End Sub

    Public Sub SetGridLinesStyleY(majorGridlineStyle As udtGridlineStyle)
        UpdateMajorGridlines(mYAxis, majorGridlineStyle)
    End Sub

    Public Sub SetGridLinesStyleY(majorGridlineStyle As udtGridlineStyle, minorGridlineStyle As udtGridlineStyle)
        UpdateMajorGridlines(mYAxis, majorGridlineStyle)
        UpdateMinorGridlines(mYAxis, majorGridlineStyle)
    End Sub

    Public Sub SetGridLinesVisibleX(showGridLines As Boolean, includeMinorGridLines As Boolean)
        UpdateGridlines(mXAxis, showGridLines, includeMinorGridLines)
    End Sub

    Public Sub SetGridLinesVisibleY(showGridLines As Boolean, includeMinorGridLines As Boolean)
        UpdateGridlines(mYAxis, showGridLines, includeMinorGridLines)
    End Sub

    Public Sub SetLabelXAxis(strAxisLabel As String)
        mXAxis.Title = strAxisLabel
    End Sub

    Public Sub SetLabelYAxis(strAxisLabel As String)
        mYAxis.Title = strAxisLabel
    End Sub

    Public Sub SetLabelTitle(strTitle As String)
        ctlOxyPlot.Model.Title = strTitle
    End Sub

    Public Sub SetLabelSubTitle(strSubTitle As String)
        ctlOxyPlot.Model.Subtitle = strSubTitle
    End Sub

    Public Sub SetLegendVisibility(isVisible As Boolean)
        ctlOxyPlot.Model.IsLegendVisible = isVisible
        InvalidatePlot()
    End Sub

    Public Sub SetPlotBackgroundColor(cNewColor As Color)
        ctlOxyPlot.Model.Background = ColorToOxyColor(cNewColor)
    End Sub

    ''' <summary>
    ''' Update the visible X axis range
    ''' </summary>
    ''' <param name="minimum"></param>
    ''' <param name="maximum"></param>
    Public Sub SetRangeX(minimum As Double, maximum As Double)
        mXAxis.Minimum = minimum
        mXAxis.Maximum = maximum
    End Sub

    ''' <summary>
    ''' Update the visible Y axis range
    ''' </summary>
    ''' <param name="minimum"></param>
    ''' <param name="maximum"></param>
    Public Sub SetRangeY(minimum As Double, maximum As Double)
        mYAxis.Minimum = minimum
        mYAxis.Maximum = maximum
    End Sub

    Public Sub SetSeriesColor(seriesNumber As Integer, cNewColor As Color)
        SetSeriesColor(seriesNumber, ColorToOxyColor(cNewColor))
    End Sub

    Public Sub SetSeriesColor(seriesNumber As Integer, newOxyColor As OxyColor)
        Dim seriesIndex = AssureValidSeriesNumber(seriesNumber)

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                oSeries.Color = newOxyColor
                oSeries.MarkerFill = newOxyColor
                oSeries.MarkerStroke = newOxyColor
            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                oSeries.Color = newOxyColor
                oSeries.MarkerFill = newOxyColor
                oSeries.MarkerStroke = newOxyColor
        End Select

    End Sub

    Public Sub SetSeriesLegendCaption(seriesNumber As Integer, strSeriesTitle As String)

        Dim seriesIndex = AssureValidSeriesNumber(seriesNumber)

        ctlOxyPlot.Model.Series(seriesIndex).Title = strSeriesTitle

    End Sub

    Public Sub SetSeriesLineColor(seriesNumber As Integer, cNewColor As Color)
        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(seriesNumber))
        End If

        Dim seriesIndex = seriesNumber - 1

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                oSeries.Color = ColorToOxyColor(cNewColor)

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                oSeries.Color = ColorToOxyColor(cNewColor)
        End Select

    End Sub

    Public Sub SetSeriesLineStyle(seriesNumber As Integer, eLineStyle As LineStyle)
        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(seriesNumber))
        End If

        Dim seriesIndex = seriesNumber - 1

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                oSeries.LineStyle = eLineStyle

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                oSeries.LineStyle = eLineStyle
        End Select

    End Sub

    Public Sub SetSeriesLineWidth(seriesNumber As Integer, lineWidth As Double)
        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(seriesNumber))
        End If

        Dim seriesIndex = seriesNumber - 1

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                oSeries.StrokeThickness = lineWidth

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                oSeries.StrokeThickness = lineWidth
        End Select

    End Sub

    Public Sub SetSeriesPointColor(seriesNumber As Integer, cNewColor As Color)

        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(seriesNumber))
        End If

        Dim seriesIndex = seriesNumber - 1

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                oSeries.MarkerFill = ColorToOxyColor(cNewColor)

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                oSeries.MarkerFill = ColorToOxyColor(cNewColor)
        End Select

    End Sub

    Public Sub SetSeriesPointSize(seriesNumber As Integer, pointSize As Double)

        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(seriesNumber))
        End If

        Dim seriesIndex = seriesNumber - 1

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                oSeries.MarkerSize = pointSize

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                oSeries.MarkerSize = pointSize
        End Select

    End Sub

    Public Sub SetSeriesPointStyle(seriesNumber As Integer, ePointStyle As MarkerType)

        If seriesNumber < 1 Or seriesNumber > ctlOxyPlot.Model.Series.Count Then
            Throw New ArgumentOutOfRangeException(NameOf(seriesNumber))
        End If

        Dim seriesIndex = seriesNumber - 1

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                oSeries.MarkerType = ePointStyle

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                oSeries.MarkerType = ePointStyle
        End Select

    End Sub

    <Obsolete("This method should typically not be needed. Instead use SetDataXvsY or SetDataYOnly with parameter ePlotMode")>
    Public Sub SetSeriesPlotMode(seriesNumber As Integer, ePlotMode As SeriesPlotMode)

        Dim seriesIndex = AssureValidSeriesNumber(seriesNumber)

        SetSeriesPlotModeWork(seriesIndex, ePlotMode)

    End Sub

    <Obsolete("This method can likely be deprecated")>
    Private Sub SetSeriesPlotModeWork(seriesIndex As Integer, eNewPlotMode As SeriesPlotMode)

        Dim eCurrentPlotMode As SeriesPlotMode

        If TypeOf (ctlOxyPlot.Model.Series(seriesIndex)) Is StemSeries Then
            eCurrentPlotMode = SeriesPlotMode.SticksToZero
        ElseIf TypeOf (ctlOxyPlot.Model.Series(seriesIndex)) Is LineSeries Then
            If mSeriesPlotMode(seriesIndex) = SeriesPlotMode.SticksToZero Then
                mSeriesPlotMode(seriesIndex) = SeriesPlotMode.Lines
            Else
                eCurrentPlotMode = mSeriesPlotMode(seriesIndex)
            End If
        End If

        If eCurrentPlotMode <> eNewPlotMode Then

            Dim lstData = New List(Of DataPoint)
            Dim strTitle As String

            Select Case eCurrentPlotMode
                Case SeriesPlotMode.SticksToZero
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                    strTitle = oSeries.Title
                    For Each item In oSeries.Points
                        lstData.Add(item)
                    Next

                Case Else
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                    strTitle = oSeries.Title
                    For Each item In oSeries.Points
                        lstData.Add(item)
                    Next
            End Select

            Select Case eNewPlotMode
                Case SeriesPlotMode.SticksToZero
                    ctlOxyPlot.Model.Series(seriesIndex) = GetNewStemSeries(strTitle, lstData)
                Case Else
                    ctlOxyPlot.Model.Series(seriesIndex) = GetNewLineSeries(strTitle, lstData)
            End Select

            mSeriesPlotMode(seriesIndex) = eNewPlotMode
        End If

        Select Case mSeriesPlotMode(seriesIndex)
            Case SeriesPlotMode.SticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                With oSeries
                    If .LineStyle = LineStyle.None Then .LineStyle = LineStyle.Solid
                    .MarkerType = MarkerType.None
                End With

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)

                With oSeries
                    Select Case mSeriesPlotMode(seriesIndex)
                        Case SeriesPlotMode.Lines
                            If .LineStyle = LineStyle.None Then .LineStyle = LineStyle.Solid
                            .MarkerType = MarkerType.None
                        Case SeriesPlotMode.Points
                            .LineStyle = LineStyle.None
                            If .MarkerType = MarkerType.None Then .MarkerType = MarkerType.Square
                        Case SeriesPlotMode.PointsAndLines
                            If .LineStyle = LineStyle.None Then .LineStyle = LineStyle.Solid
                            If .MarkerType = MarkerType.None Then .MarkerType = MarkerType.Square
                    End Select
                End With
        End Select

    End Sub

    Public Sub SetSeriesVisible(seriesNumber As Integer, blnShowSeries As Boolean, Optional redrawPlot As Boolean = True)
        Dim seriesIndex = AssureValidSeriesNumber(seriesNumber)

        ctlOxyPlot.Model.Series(seriesIndex).IsVisible = blnShowSeries

        If redrawPlot Then
            InvalidatePlot()
        End If
    End Sub

    Private Sub UpdateGridlines(oAxis As Axis, showGridLines As Boolean, includeMinorGridLines As Boolean)
        If showGridLines Then
            oAxis.MajorGridlineStyle = LineStyle.Automatic
            If includeMinorGridLines Then
                oAxis.MinorGridlineStyle = LineStyle.Automatic
            End If
        Else
            oAxis.MajorGridlineStyle = LineStyle.None
            oAxis.MinorGridlineStyle = LineStyle.None
        End If
    End Sub

    Private Sub UpdateMajorGridlines(oAxis As Axis, majorGridlineStyle As udtGridlineStyle)
        oAxis.MajorGridlineStyle = majorGridlineStyle.GridlineStyle
        oAxis.MajorGridlineColor = ColorToOxyColor(majorGridlineStyle.GridlineColor)

        If majorGridlineStyle.GridlineThickness > 0 Then
            oAxis.MajorGridlineThickness = majorGridlineStyle.GridlineThickness
        End If
    End Sub

    Private Sub UpdateMinorGridlines(oAxis As Axis, minorGridlineStyle As udtGridlineStyle)
        oAxis.MinorGridlineStyle = minorGridlineStyle.GridlineStyle
        oAxis.MinorGridlineColor = ColorToOxyColor(minorGridlineStyle.GridlineColor)

        If minorGridlineStyle.GridlineThickness > 0 Then
            oAxis.MinorGridlineThickness = minorGridlineStyle.GridlineThickness
        End If

    End Sub

    Public Sub ZoomOutFull()
        mXAxis.Reset()
        mYAxis.Reset()
        ctlOxyPlot.InvalidatePlot(True)
    End Sub

#Region "Control handlers"

    Private Sub cmdZoomOut_Click(sender As Object, e As EventArgs) Handles cmdZoomOut.Click
        ZoomOutFull()
    End Sub

    Private Sub ctlOxyPlotControl_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown, ctlOxyPlot.KeyDown
        If e.Control Then
            If e.KeyCode = Keys.A Then
                ZoomOutFull()
            End If
        End If
    End Sub

#End Region

End Class
