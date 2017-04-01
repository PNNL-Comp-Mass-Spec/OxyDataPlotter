Option Strict On
Option Explicit On

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

    Public Enum pmPlotModeConstants
        pmLines = 0                 ' LineSeries
        pmSticksToZero = 1          ' StemSeries
        pmPoints = 2                ' LineSeries
        pmPointsAndLines = 3        ' LineSeries
    End Enum

    Public Enum eCaptionOffsetDirection
        TopLeft = 0
        TopCenter = 1
        TopRight = 2
        BottomLeft = 3
        BottomCenter = 4
        BottomRight = 5
    End Enum
#End Region

#Region "Structures"

    Public Structure udtGridlineStyle
        Public GridlineStyle As LineStyle
        Public GridlineColor As Color
        Public GridlineThickness As Double
    End Structure

#End Region

#Region "Properties"
    Public Property AutoscaleXAxis As Boolean = True

    Public Property AutoscaleYAxis As Boolean = True

    Public Property SetXAxisAbsoluteMinimum As Double
        Get
            Return mXAxis.AbsoluteMinimum
        End Get
        Set(value As Double)
            mXAxis.AbsoluteMinimum = value
        End Set
    End Property

    Public Property SetXAxisAbsoluteMaximum As Double
        Get
            Return mXAxis.AbsoluteMaximum
        End Get
        Set(value As Double)
            mXAxis.AbsoluteMaximum = value
        End Set
    End Property

    Public Property SetYAxisAbsoluteMinimum As Double
        Get
            Return mYAxis.AbsoluteMinimum
        End Get
        Set(value As Double)
            mYAxis.AbsoluteMinimum = value
        End Set
    End Property

    Public Property SetYAxisAbsoluteMaximum As Double
        Get
            Return mYAxis.AbsoluteMaximum
        End Get
        Set(value As Double)
            mYAxis.AbsoluteMaximum = value
        End Set
    End Property


    Public Property SetXAxisPaddingMinimum As Double
        Get
            Return mXAxis.MinimumPadding
        End Get
        Set(value As Double)
            mXAxis.MinimumPadding = value
        End Set
    End Property

    Public Property SetXAxisPaddingMaximum As Double
        Get
            Return mXAxis.MaximumPadding
        End Get
        Set(value As Double)
            mXAxis.MaximumPadding = value
        End Set
    End Property

    Public Property SetYAxisPaddingMinimum As Double
        Get
            Return mYAxis.MinimumPadding
        End Get
        Set(value As Double)
            mYAxis.MinimumPadding = value
        End Set
    End Property

    Public Property SetYAxisPaddingMaximum As Double
        Get
            Return mYAxis.MaximumPadding
        End Get
        Set(value As Double)
            mYAxis.MaximumPadding = value
        End Set
    End Property

#End Region

#Region "Member variables"

    Private mDefaultPlotMode As pmPlotModeConstants

    ' 0-based array
    Private ReadOnly mSeriesPlotMode(MAX_SERIES_COUNT) As pmPlotModeConstants

    Private ReadOnly mXAxis As Axis
    Private ReadOnly mYAxis As Axis

    Private ReadOnly mAnnotationsBySeries As Dictionary(Of Integer, List(Of Annotation))

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
    ''' Clear data on the specified series
    ''' </summary>
    ''' <param name="intSeriesToClear">Series number (series 1 is the first series)</param>
    ''' <remarks></remarks>
    Public Sub ClearData(intSeriesToClear As Integer)

        If intSeriesToClear < 1 Or intSeriesToClear > ctlOxyPlot.Model.Series.Count Then Exit Sub

        CType(ctlOxyPlot.Model.Series(intSeriesToClear - 1), LineSeries).Points.Clear()

    End Sub

    Private Function ColorToOxyColor(eColor As Color) As OxyColor
        Return OxyColor.FromArgb(eColor.A, eColor.R, eColor.G, eColor.B)
    End Function

    ''' <summary>
    ''' Find the data point closest to locationX,locationY in series seriesIndex
    ''' </summary>
    ''' <param name="seriesIndex">Index of the series to search</param>
    ''' <param name="locationX">Target X</param>
    ''' <param name="locationY">Target Y</param>
    ''' <param name="xAxisOnly">When true, only compare locationX to X axis values in the data</param>
    ''' <param name="closesetDataPointIndex">Output: index of the closest data point</param>
    ''' <param name="closestDistance">Output: euclidean distance to the closest data point</param>
    ''' <returns>The closest data point</returns>
    ''' <remarks>Set xAxisOnly to only find the data point whose x-axis value is closest to locationX</remarks>
    Private Function FindNearestDataPoint(
      seriesIndex As Integer,
      locationX As Double,
      locationY As Double,
      xAxisOnly As Boolean,
      <Out()> ByRef closesetDataPointIndex As Integer,
      <Out()> ByRef closestDistance As Double) As DataPoint

        Dim oSeries As LineSeries

        Select Case mSeriesPlotMode(seriesIndex)
            Case pmPlotModeConstants.pmSticksToZero
                oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)

            Case pmPlotModeConstants.pmLines, pmPlotModeConstants.pmPoints, pmPlotModeConstants.pmPointsAndLines
                oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)

            Case Else
                Throw New NotSupportedException("Unrecognized plot mode in FindNearestDataPoint")
        End Select

        Dim closesetDataPoint As DataPoint = Nothing
        closestDistance = Double.MaxValue
        closesetDataPointIndex = 0

        Dim dataPointIndex = 0

        For Each dataPoint In oSeries.Points
            Dim distance As Double
            If xAxisOnly Then
                distance = Math.Abs(dataPoint.X - locationX)
            Else
                distance = Math.Sqrt((dataPoint.X - locationX) ^ 2 + (dataPoint.Y - locationY) ^ 2)
            End If

            If distance < closestDistance Then
                closesetDataPoint = dataPoint
                closesetDataPointIndex = dataPointIndex
                closestDistance = distance
            End If

            dataPointIndex += 1
        Next

        Return closesetDataPoint

    End Function

    Public Sub GenerateSineWave(seriesNumber As Integer, blnXAxisLogBased As Boolean)

        Const DATA_COUNT As Short = 1021
        Dim dblDataX(DATA_COUNT - 1) As Double
        Dim dblDataY(DATA_COUNT - 1) As Double
        Dim index As Integer

        SetSeriesPlotMode(seriesNumber, pmPlotModeConstants.pmLines)

        For index = 0 To DATA_COUNT - 1
            dblDataX(index) = Math.Log(index + 1)
            dblDataY(index) = Math.Sin(index / 25.0#) * 100
        Next index

        If blnXAxisLogBased Then
            SetDataXvsY(seriesNumber, dblDataX, dblDataY, DATA_COUNT, "Sine wave, log X")
        Else
            SetDataYOnly(seriesNumber, dblDataY, DATA_COUNT, 1, 0.02, "Sine wave")
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
                Case pmPlotModeConstants.pmSticksToZero
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
            Case pmPlotModeConstants.pmSticksToZero
                oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)

            Case pmPlotModeConstants.pmLines, pmPlotModeConstants.pmPoints, pmPlotModeConstants.pmPointsAndLines
                oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)

            Case Else
                Throw New NotSupportedException("Unrecognized plot mode in GetDataXvsY")
        End Select

        Return oSeries.Points

    End Function

    Public Function GetDefaultSeriesColor(seriesNumber As Integer) As OxyColor
        Dim lstColors = ctlOxyPlot.Model.DefaultColors

        If seriesNumber <= lstColors.Count Then
            Return lstColors(seriesNumber - 1)
        Else
            Return lstColors(0)
        End If

    End Function

    ''' <summary>
    ''' Creates a new line series (no data points)
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <returns></returns>
    ''' <remarks>Will be an empty series without any data points</remarks>
    Private Function GetNewLineSeries(strTitle As String) As LineSeries
        Return GetNewLineSeries(strTitle, New List(Of DataPoint))
    End Function

    ''' <summary>
    ''' Creates a new line series
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <param name="lstData">Data points for the new series</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNewLineSeries(strTitle As String, lstData As List(Of DataPoint)) As LineSeries

        Dim oSeries As LineSeries
        oSeries = New LineSeries()
        oSeries.Title = strTitle
        oSeries.CanTrackerInterpolatePoints = False

        For Each item In lstData
            oSeries.Points.Add(item)
        Next

        Return oSeries

    End Function

    ''' <summary>
    ''' Creates a new stem series (no data points)
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <returns></returns>
    ''' <remarks>Will be an empty series without any data points</remarks>
    Private Function GetNewStemSeries(strTitle As String) As StemSeries

        Return GetNewStemSeries(strTitle, New List(Of DataPoint))

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
            Case pmPlotModeConstants.pmSticksToZero
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
            Case pmPlotModeConstants.pmSticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                Return oSeries.MarkerType

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                Return oSeries.MarkerType
        End Select

    End Function

    ''' <summary>
    ''' Creates a new stem series
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <returns></returns>
    ''' <remarks>Will be an empty series without any data points</remarks>
    Private Function GetNewStemSeries(strTitle As String, lstData As List(Of DataPoint)) As StemSeries

        Dim oSeries As StemSeries
        oSeries = New StemSeries()
        oSeries.Title = strTitle

        For Each item In lstData
            oSeries.Points.Add(item)
        Next

        Return oSeries

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
    ''' Find the data point closes to searchPosX,searchPosY
    ''' </summary>
    ''' <param name="searchPosX"></param>
    ''' <param name="searchPosY"></param>
    ''' <param name="xAxisOnly">When true, only compare locationX to X axis values in the data</param>
    ''' <param name="seriesNumber">Either the series to search if limitToGivenSeriesNumber is true, or the matched series number of limitToGivenSeriesNumber is false</param>
    ''' <param name="distanceToClosestSeriesNumberDataPoint">Output: distance from the search point to the matched point</param>
    ''' <param name="limitToGivenSeriesNumber">When true, only examine data for series seriesNumber</param>
    ''' <returns>Data point index in series seriesNumber</returns>
    ''' <remarks>
    ''' Data for the series is accessible via GetDataXvsY
    ''' Set xAxisOnly to only find the data point whose x-axis value is closest to locationX
    ''' </remarks>
    Public Function LookupNearestPointNumber(
      searchPosX As Double,
      searchPosY As Double,
      xAxisOnly As Boolean,
      ByRef seriesNumber As Integer,
      <Out()> ByRef distanceToClosestSeriesNumberDataPoint As Double,
      limitToGivenSeriesNumber As Boolean) As Integer

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

        Dim closestSeriesNumber = 1
        Dim closesetDataPointIndex = 0
        distanceToClosestSeriesNumberDataPoint = Double.MaxValue

        For seriesNumberToCheck = startSeriesNumber To endSeriesNumber
            Dim seriesIndex = seriesNumberToCheck - 1

            Dim candidateDataPointIndex As Integer
            Dim candidateDistance As Double
            Dim matchedDataPoint = FindNearestDataPoint(seriesIndex, searchPosX, searchPosY, xAxisOnly, candidateDataPointIndex, candidateDistance)

            If candidateDistance < distanceToClosestSeriesNumberDataPoint Then
                closestSeriesNumber = seriesNumberToCheck
                closesetDataPointIndex = candidateDataPointIndex
                distanceToClosestSeriesNumberDataPoint = candidateDistance
            End If
        Next

        seriesNumber = closestSeriesNumber

        Return closesetDataPointIndex

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

    Public Sub SavePlotAsPNG(filePath As String)

        Dim svgCode = ctlOxyPlot.Model.ToSvg(Me.Width, Me.Height, True)

        Dim tempFilePath = Path.GetTempFileName()

        Using writer = New StreamWriter(New FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            writer.WriteLine(svgCode)
        End Using

        Dim doc = Svg.SvgDocument.Open(tempFilePath)

        Dim bitmap = doc.Draw()
        bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png)

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

    Public Sub SetAnnotationByXY(
      locationX As Double, locationY As Double, caption As String,
      Optional captionOffsetDirection As eCaptionOffsetDirection = eCaptionOffsetDirection.TopLeft,
      Optional arrowLengthPixels As Integer = 15,
      Optional eLineStyle As LineStyle = LineStyle.Automatic,
      Optional lineWidth As Integer = 1,
      Optional fontSize As Integer = 12)

        Dim xyPoint = New DataPoint(locationX, locationY)

        If arrowLengthPixels < 0 Then
            arrowLengthPixels = 0
        End If

        Dim arrowDirection As ScreenVector = GetArrowVector(captionOffsetDirection, arrowLengthPixels)

        Dim oAnnotation = New ArrowAnnotation() With {
            .StartPoint = xyPoint,
            .EndPoint = xyPoint,
            .LineStyle = eLineStyle,
            .ArrowDirection = arrowDirection,
            .StrokeThickness = lineWidth,
            .Text = caption,
            .FontSize = fontSize
        }

        ctlOxyPlot.Model.Annotations.Add(oAnnotation)

    End Sub

    ''' <summary>
    ''' Get a vector for placing an annotation at a position relative to a data point
    ''' </summary>
    ''' <param name="captionOffsetDirection"></param>
    ''' <param name="arrowLengthPixels"></param>
    ''' <returns></returns>
    Private Function GetArrowVector(captionOffsetDirection As eCaptionOffsetDirection, arrowLengthPixels As Integer) As ScreenVector
        Select Case captionOffsetDirection
            Case eCaptionOffsetDirection.TopLeft
                Return New ScreenVector(arrowLengthPixels, arrowLengthPixels)

            Case eCaptionOffsetDirection.TopCenter
                Return New ScreenVector(0, arrowLengthPixels)

            Case eCaptionOffsetDirection.TopRight
                Return New ScreenVector(-arrowLengthPixels, arrowLengthPixels)

            Case eCaptionOffsetDirection.BottomLeft
                Return New ScreenVector(arrowLengthPixels, -arrowLengthPixels)

            Case eCaptionOffsetDirection.BottomCenter
                Return New ScreenVector(0, -arrowLengthPixels)

            Case eCaptionOffsetDirection.BottomRight
                Return New ScreenVector(-arrowLengthPixels, -arrowLengthPixels)

            Case Else
                ' Same as eCaptionOffsetDirection.TopLeft
                Return New ScreenVector(arrowLengthPixels, arrowLengthPixels)
        End Select

    End Function

    Public Sub SetAnnotationForDataPoint(
      seriesNumber As Integer, locationX As Double, locationY As Double, caption As String,
      Optional captionOffsetDirection As eCaptionOffsetDirection = eCaptionOffsetDirection.TopLeft,
      Optional arrowLengthPixels As Integer = 15,
      Optional eLineStyle As LineStyle = LineStyle.Automatic,
      Optional lineWidth As Integer = 1,
      Optional fontSize As Integer = 12)

        Dim seriesIndex = AssureValidSeriesNumber(seriesNumber)

        Dim closesetDataPointIndex As Integer
        Dim closestDistance As Double

        Const xAxisOnly = True

        Dim nearestPoint As DataPoint = FindNearestDataPoint(seriesIndex, locationX, locationY, xAxisOnly, closesetDataPointIndex, closestDistance)

        If arrowLengthPixels < 0 Then
            arrowLengthPixels = 0
        End If

        Dim arrowDirection = GetArrowVector(captionOffsetDirection, arrowLengthPixels)

        Dim oAnnotation = New ArrowAnnotation() With {
            .StartPoint = nearestPoint,
            .EndPoint = nearestPoint,
            .LineStyle = eLineStyle,
            .ArrowDirection = arrowDirection,
            .StrokeThickness = lineWidth,
            .Text = caption,
            .FontSize = fontSize
        }

        ctlOxyPlot.Model.Annotations.Add(oAnnotation)

        AddSeriesAnnotationToCache(seriesNumber, oAnnotation)

    End Sub

    Private Sub SetAxisDisplayPrecision(oXaxis As Axis, precision As Short)

        ' formatString will be of the form {0:F2}
        Dim formatString As String = "{0:F" & precision & "}"

        oXaxis.LabelFormatter = Function(d) String.Format(formatString, d)
    End Sub

    ''' <summary>
    ''' Add new X/Y Data, either replacing an existing series, or adding as a new series
    ''' </summary>
    ''' <param name="seriesNumber">Series number to replace; set to higher than GetSeriesCount() to add a new series</param>
    ''' <param name="XDataZeroBased1DArray"></param>
    ''' <param name="YDataZeroBased1DArray"></param>
    ''' <param name="dataCount"></param>
    ''' <param name="strSeriesTitle"></param>
    Public Sub SetDataXvsY(
      seriesNumber As Integer,
      XDataZeroBased1DArray() As Double,
      YDataZeroBased1DArray() As Double,
      dataCount As Integer,
      Optional ByVal strSeriesTitle As String = "")

        Dim seriesIndex As Integer

        If dataCount < 1 Then Exit Sub

        Dim lstData = New List(Of DataPoint)(dataCount)

        Dim minimumXValue As Double = Double.MaxValue
        Dim maximumXValue As Double = Double.MinValue

        Dim minimumYValue As Double = Double.MaxValue
        Dim maximumYValue As Double = Double.MinValue

        For index = 0 To dataCount - 1
            lstData.Add(New DataPoint(XDataZeroBased1DArray(index), YDataZeroBased1DArray(index)))
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

        If seriesNumber > ctlOxyPlot.Model.Series.Count Then
            ' Add a new series
            ctlOxyPlot.Model.Series.Add(GetNewLineSeries(strSeriesTitle, lstData))
            seriesNumber = ctlOxyPlot.Model.Series.Count
            seriesIndex = seriesNumber - 1
        Else
            ' Replace an existing data series
            seriesIndex = AssureValidSeriesNumber(seriesNumber)

            If ctlOxyPlot.Model.Annotations.Count > 0 Then
                RemoveAnnotationsForSeries(seriesNumber)
            End If

            ctlOxyPlot.Model.Series(seriesIndex) = GetNewLineSeries(strSeriesTitle, lstData)
        End If

        For index = 0 To ctlOxyPlot.Model.Series.Count - 1
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

        SetSeriesVisible(seriesNumber, True, False)

        Select Case mSeriesPlotMode(seriesIndex)
            Case pmPlotModeConstants.pmSticksToZero
                mSeriesPlotMode(seriesIndex) = pmPlotModeConstants.pmLines
            Case Else
                ' Leave the plot mode unchanged
        End Select

        mXAxis.AbsoluteMinimum = minimumXValue - (maximumXValue - minimumXValue) * 0.25
        mXAxis.AbsoluteMaximum = maximumXValue + (maximumXValue - minimumXValue) * 0.25

        mYAxis.AbsoluteMinimum = minimumYValue - (maximumYValue - minimumYValue) * 0.25
        mYAxis.AbsoluteMaximum = maximumYValue + (maximumYValue - minimumYValue) * 0.25

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

    Public Sub SetDataYOnly(ByRef seriesNumber As Integer, ByRef YDataZeroBased1DArray() As Double, YDataCount As Integer, Optional ByVal dblXFirst As Double = 0, Optional ByVal dblIncrement As Double = 1, Optional ByVal strSeriesTitle As String = "")

        If YDataCount < 1 Then Exit Sub

        Dim XDataZeroBased1DArray() As Double
        ReDim XDataZeroBased1DArray(YDataCount - 1)

        For index = 0 To YDataCount - 1
            XDataZeroBased1DArray(index) = dblXFirst + dblIncrement * index
        Next

        SetDataXvsY(seriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, YDataCount, strSeriesTitle)

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
            Case pmPlotModeConstants.pmSticksToZero
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

    Public Sub SetSeriesCount(intCount As Integer)

        If intCount < 1 Then intCount = 1
        If intCount > MAX_SERIES_COUNT Then intCount = MAX_SERIES_COUNT

        Do While intCount < ctlOxyPlot.Model.Series.Count
            ctlOxyPlot.Model.Series.RemoveAt(ctlOxyPlot.Model.Series.Count - 1)
        Loop

        Do While intCount > ctlOxyPlot.Model.Series.Count
            Dim strSeriesTitle As String = "Series " & ctlOxyPlot.Model.Series.Count + 1

            Select Case mDefaultPlotMode
                Case pmPlotModeConstants.pmSticksToZero
                    ctlOxyPlot.Model.Series.Add(GetNewStemSeries(strSeriesTitle))
                Case Else
                    ctlOxyPlot.Model.Series.Add(GetNewLineSeries(strSeriesTitle))
            End Select
        Loop

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
            Case pmPlotModeConstants.pmSticksToZero
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
            Case pmPlotModeConstants.pmSticksToZero
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
            Case pmPlotModeConstants.pmSticksToZero
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
            Case pmPlotModeConstants.pmSticksToZero
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
            Case pmPlotModeConstants.pmSticksToZero
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
            Case pmPlotModeConstants.pmSticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                oSeries.MarkerType = ePointStyle

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)
                oSeries.MarkerType = ePointStyle

        End Select

    End Sub

    Public Sub SetSeriesPlotMode(seriesNumber As Integer, ePlotMode As pmPlotModeConstants, Optional ByVal blnMakeDefault As Boolean = False)

        Dim seriesIndex = AssureValidSeriesNumber(seriesNumber)

        SetSeriesPlotModeWork(seriesIndex, ePlotMode)

        If blnMakeDefault Then
            mDefaultPlotMode = ePlotMode

            For seriesToCheck = 1 To MAX_SERIES_COUNT
                If seriesToCheck >= ctlOxyPlot.Model.Series.Count Then
                    Exit For
                End If

                If seriesNumber = seriesToCheck Then Continue For

                Dim seriesIndexToCheck = seriesToCheck - 1

                If mSeriesPlotMode(seriesIndexToCheck) <> ePlotMode Then
                    SetSeriesPlotModeWork(seriesIndexToCheck, ePlotMode)
                End If
            Next
        End If

    End Sub

    Private Sub SetSeriesPlotModeWork(seriesIndex As Integer, eNewPlotMode As pmPlotModeConstants)

        Dim eCurrentPlotMode As pmPlotModeConstants

        If TypeOf (ctlOxyPlot.Model.Series(seriesIndex)) Is StemSeries Then
            eCurrentPlotMode = pmPlotModeConstants.pmSticksToZero
        ElseIf TypeOf (ctlOxyPlot.Model.Series(seriesIndex)) Is LineSeries Then
            If mSeriesPlotMode(seriesIndex) = pmPlotModeConstants.pmSticksToZero Then
                mSeriesPlotMode(seriesIndex) = pmPlotModeConstants.pmLines
            Else
                eCurrentPlotMode = mSeriesPlotMode(seriesIndex)
            End If
        End If

        If eCurrentPlotMode <> eNewPlotMode Then

            Dim lstData = New List(Of DataPoint)
            Dim strTitle As String

            Select Case eCurrentPlotMode
                Case pmPlotModeConstants.pmSticksToZero
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
                Case pmPlotModeConstants.pmSticksToZero
                    ctlOxyPlot.Model.Series(seriesIndex) = GetNewStemSeries(strTitle, lstData)
                Case Else
                    ctlOxyPlot.Model.Series(seriesIndex) = GetNewLineSeries(strTitle, lstData)
            End Select

            mSeriesPlotMode(seriesIndex) = eNewPlotMode
        End If

        Select Case mSeriesPlotMode(seriesIndex)
            Case pmPlotModeConstants.pmSticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), StemSeries)
                With oSeries
                    If .LineStyle = LineStyle.None Then .LineStyle = LineStyle.Solid
                    .MarkerType = MarkerType.None
                End With

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(seriesIndex), LineSeries)

                With oSeries
                    Select Case mSeriesPlotMode(seriesIndex)
                        Case pmPlotModeConstants.pmLines
                            If .LineStyle = LineStyle.None Then .LineStyle = LineStyle.Solid
                            .MarkerType = MarkerType.None
                        Case pmPlotModeConstants.pmPoints
                            .LineStyle = LineStyle.None
                            If .MarkerType = MarkerType.None Then .MarkerType = MarkerType.Square
                        Case pmPlotModeConstants.pmPointsAndLines
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

    Private Sub ShowMessage(strMessage As String, Optional ByVal strCaption As String = "Info")
        MessageBox.Show(strMessage, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
