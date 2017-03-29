Option Strict On
Option Explicit On

Imports OxyPlot.Series

Public Class ctlOxyPlotControl

#Region "Constants"
    Public Const MAX_SERIES_COUNT As Integer = 32
#End Region

#Region "Enums"

    Public Enum pmPlotModeConstants
        pmLines = 0                 ' LineSeries
        pmSticksToZero = 1          ' StemSeries
        pmBar = 2                   ' BarSeries
        pmPoints = 3                ' LineSeries
        pmPointsAndLines = 4        ' LineSeries
    End Enum
#End Region

#Region "Structures"

#End Region

#Region "Member variables"

    Protected mDefaultPlotMode As pmPlotModeConstants

    ' 0-based array
    Protected mSeriesPlotMode(MAX_SERIES_COUNT) As pmPlotModeConstants

#End Region

    ''' <summary>
    ''' Validates that intSeriesNumber is a number between 1 and the number of series on the plot
    ''' </summary>
    ''' <param name="intSeriesNumber"></param>
    ''' <remarks>Auto-updates intSeriesNumber to "1" if out of range</remarks>
    Private Sub AssureValidSeriesNumber(ByRef intSeriesNumber As Integer)
        If intSeriesNumber < 1 Or intSeriesNumber > ctlOxyPlot.Model.Series.Count Then intSeriesNumber = 1
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

    Public Sub GenerateSineWave(intSeriesNumber As Integer, blnXAxisLogBased As Boolean)

        Const DATA_COUNT As Short = 1021
        Dim dblDataX(DATA_COUNT - 1) As Double
        Dim dblDataY(DATA_COUNT - 1) As Double
        Dim intIndex As Integer

        SetSeriesPlotMode(intSeriesNumber, pmPlotModeConstants.pmLines)

        For intIndex = 0 To DATA_COUNT - 1
            dblDataX(intIndex) = System.Math.Log(intIndex + 1)
            dblDataY(intIndex) = System.Math.Sin(intIndex / 25.0#) * 100
        Next intIndex

        If blnXAxisLogBased Then
            SetDataXvsY(intSeriesNumber, dblDataX, dblDataY, DATA_COUNT, "Sine wave, log X")
        Else
            SetDataYOnly(intSeriesNumber, dblDataY, DATA_COUNT, 1, 0.02, "Sine wave")
        End If

    End Sub

    Public Function GetDataCount(intSeriesNumber As Integer) As Integer

        Dim intSeriesIndex As Integer = intSeriesNumber - 1

        If intSeriesNumber < 0 Or intSeriesNumber >= ctlOxyPlot.Model.Series.Count Then
            Return 0
        Else
            Select Case mSeriesPlotMode(intSeriesIndex)
                Case pmPlotModeConstants.pmBar
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.BarSeries)
                    Return oSeries.Items.Count
                Case pmPlotModeConstants.pmSticksToZero
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.StemSeries)
                    Return oSeries.Points.Count
                Case Else
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.LineSeries)
                    Return oSeries.Points.Count
            End Select
        End If

    End Function

    Public Function GetDefaultSeriesColor(intSeriesNumber As Integer) As OxyPlot.OxyColor
        Dim lstColors = ctlOxyPlot.Model.DefaultColors

        If intSeriesNumber <= lstColors.Count Then
            Return lstColors(intSeriesNumber - 1)
        Else
            Return lstColors(0)
        End If

    End Function

    ''' <summary>
    ''' Creates a new bar series (no data points)
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <returns></returns>
    ''' <remarks>Will be an empty series without any data points</remarks>
    Protected Function GetNewBarSeries(strTitle As String) As BarSeries

        Return GetNewBarSeries(strTitle, New Generic.List(Of OxyPlot.DataPoint))

    End Function

    ''' <summary>
    ''' Creates a new bar series
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <param name="lstData">Data points (only the Y values will be used for the bar heights)</param>
    ''' <returns></returns>
    ''' <remarks>Will be an empty series without any data points</remarks>
    Protected Function GetNewBarSeries(strTitle As String, lstData As Generic.List(Of OxyPlot.DataPoint)) As BarSeries

        Dim oSeries As BarSeries
        oSeries = New BarSeries()
        oSeries.Title = strTitle

        Dim lstSortedData = From item In lstData Order By item.X

        For Each item In lstSortedData
            oSeries.Items.Add(New OxyPlot.Series.BarItem(item.Y))
        Next

        Return oSeries

    End Function

    ''' <summary>
    ''' Creates a new line series (no data points)
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <returns></returns>
    ''' <remarks>Will be an empty series without any data points</remarks>
    Protected Function GetNewLineSeries(strTitle As String) As LineSeries
        Return GetNewLineSeries(strTitle, New Generic.List(Of OxyPlot.DataPoint))
    End Function

    ''' <summary>
    ''' Creates a new line series
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <param name="lstData">Data points for the new series</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function GetNewLineSeries(strTitle As String, lstData As Generic.List(Of OxyPlot.DataPoint)) As LineSeries

        Dim oSeries As LineSeries
        oSeries = New LineSeries()
        oSeries.Title = strTitle

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
    Protected Function GetNewStemSeries(strTitle As String) As StemSeries

        Return GetNewStemSeries(strTitle, New Generic.List(Of OxyPlot.DataPoint))

    End Function

    Public Function GetSeriesCount() As Integer
        Return ctlOxyPlot.Model.Series.Count
    End Function

    ''' <summary>
    ''' Creates a new stem series
    ''' </summary>
    ''' <param name="strTitle"></param>
    ''' <returns></returns>
    ''' <remarks>Will be an empty series without any data points</remarks>
    Protected Function GetNewStemSeries(strTitle As String, lstData As Generic.List(Of OxyPlot.DataPoint)) As StemSeries

        Dim oSeries As StemSeries
        oSeries = New StemSeries()
        oSeries.Title = strTitle

        For Each item In lstData
            oSeries.Points.Add(item)
        Next

        Return oSeries

    End Function

    Protected Sub InitializePlotModel()

        Dim oNewModel = New OxyPlot.PlotModel()

        Dim oXAxis As OxyPlot.Axes.Axis = New OxyPlot.Axes.LinearAxis()
        oXAxis.Position = OxyPlot.Axes.AxisPosition.Bottom
        oXAxis.Title = "X-axis"

        Dim oYAxis As OxyPlot.Axes.Axis = New OxyPlot.Axes.LinearAxis()
        oXAxis.Position = OxyPlot.Axes.AxisPosition.Left
        oXAxis.Title = "Y-axis"

        oNewModel.Axes.Add(oXAxis)
        oNewModel.Axes.Add(oYAxis)

        ctlOxyPlot.Model = oNewModel
    End Sub

    Public Sub SetDataXvsY(ByRef intSeriesNumber As Integer, ByRef XDataZeroBased1DArray() As Double, ByRef YDataZeroBased1DArray() As Double, DataCount As Integer, Optional ByVal strSeriesTitle As String = "")
        Dim intSeriesIndex As Integer

        If DataCount < 1 Then Exit Sub

        Dim lstData = New Generic.List(Of OxyPlot.DataPoint)(DataCount)

        For intIndex = 0 To DataCount - 1
            lstData.Add(New OxyPlot.DataPoint(XDataZeroBased1DArray(intIndex), YDataZeroBased1DArray(intIndex)))
        Next

        If intSeriesNumber > ctlOxyPlot.Model.Series.Count Then
            ' Add a new series
            ctlOxyPlot.Model.Series.Add(GetNewLineSeries(strSeriesTitle, lstData))
            intSeriesNumber = ctlOxyPlot.Model.Series.Count
        Else
            AssureValidSeriesNumber(intSeriesNumber)
            intSeriesIndex = intSeriesNumber - 1
            ctlOxyPlot.Model.Series(intSeriesIndex) = GetNewLineSeries(strSeriesTitle, lstData)
        End If

        SetSeriesVisible(intSeriesNumber, True)

        Select Case mSeriesPlotMode(intSeriesIndex)
            Case pmPlotModeConstants.pmBar
                mSeriesPlotMode(intSeriesIndex) = pmPlotModeConstants.pmLines
            Case pmPlotModeConstants.pmSticksToZero
                mSeriesPlotMode(intSeriesIndex) = pmPlotModeConstants.pmLines
            Case Else
                ' Leave the plot mode unchanged
        End Select

        ' ToDo: RecordZoomRange(True)

        ' ToDo: UpdateAllDynamicAnnotationCaptions()

    End Sub

    Public Sub SetDataYOnly(ByRef intSeriesNumber As Integer, ByRef YDataZeroBased1DArray() As Double, YDataCount As Integer, Optional ByVal dblXFirst As Double = 0, Optional ByVal dblIncrement As Double = 1, Optional ByVal strSeriesTitle As String = "")

        If YDataCount < 1 Then Exit Sub

        Dim XDataZeroBased1DArray() As Double
        ReDim XDataZeroBased1DArray(YDataCount - 1)

        For intIndex = 0 To YDataCount - 1
            XDataZeroBased1DArray(intIndex) = dblXFirst + dblIncrement * intIndex
        Next

        SetDataXvsY(intSeriesNumber, XDataZeroBased1DArray, YDataZeroBased1DArray, YDataCount, strSeriesTitle)

    End Sub

    Public Sub SetLabelXAxis(strAxisLabel As String)
        ctlOxyPlot.Model.Axes(0).Title = strAxisLabel
    End Sub

    Public Sub SetLabelYAxis(strAxisLabel As String)
        ctlOxyPlot.Model.Axes(1).Title = strAxisLabel
    End Sub

    Public Sub SetLabelTitle(strTitle As String)
        ctlOxyPlot.Model.Title = strTitle
    End Sub

    Public Sub SetLabelSubTitle(strSubTitle As String)
        ctlOxyPlot.Model.Subtitle = strSubTitle
    End Sub

    Public Sub SetSeriesColor(intSeriesNumber As Integer, cNewColor As Color)
        SetSeriesColor(intSeriesNumber, OxyPlot.OxyColor.FromArgb(cNewColor.A, cNewColor.R, cNewColor.G, cNewColor.B))
    End Sub

    Public Sub SetSeriesColor(intSeriesNumber As Integer, newOxyColor As OxyPlot.OxyColor)
        AssureValidSeriesNumber(intSeriesNumber)

        Dim intSeriesIndex As Integer = intSeriesNumber - 1

        Select Case mSeriesPlotMode(intSeriesIndex)
            Case pmPlotModeConstants.pmBar
                Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.BarSeries)
                oSeries.FillColor = newOxyColor
                oSeries.StrokeColor = newOxyColor
            Case pmPlotModeConstants.pmSticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.StemSeries)
                oSeries.Color = newOxyColor
                oSeries.MarkerFill = newOxyColor
                oSeries.MarkerStroke = newOxyColor
            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.LineSeries)
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
                Case pmPlotModeConstants.pmBar
                    ctlOxyPlot.Model.Series.Add(GetNewBarSeries(strSeriesTitle))
                Case Else
                    ctlOxyPlot.Model.Series.Add(GetNewLineSeries(strSeriesTitle))
            End Select
        Loop

    End Sub

    Public Sub SetSeriesLegendCaption(intSeriesNumber As Integer, strSeriesTitle As String)
        AssureValidSeriesNumber(intSeriesNumber)

        ctlOxyPlot.Model.Series(intSeriesNumber - 1).Title = strSeriesTitle

    End Sub

    Public Sub SetSeriesPlotMode(intSeriesNumber As Integer, ePlotMode As pmPlotModeConstants, Optional ByVal blnMakeDefault As Boolean = False)

        Dim intSeriesIndex As Integer

        AssureValidSeriesNumber(intSeriesNumber)

        SetSeriesPlotModeWork(intSeriesNumber - 1, ePlotMode)


        If blnMakeDefault Then
            mDefaultPlotMode = ePlotMode

            For intSeriesIndex = 1 To MAX_SERIES_COUNT
                If mSeriesPlotMode(intSeriesIndex) <> ePlotMode Then
                    SetSeriesPlotModeWork(intSeriesNumber - 1, ePlotMode)
                End If
            Next intSeriesIndex
        End If

    End Sub

    Private Sub SetSeriesPlotModeWork(intSeriesIndex As Integer, eNewPlotMode As pmPlotModeConstants)

        Dim eCurrentPlotMode As pmPlotModeConstants

        If TypeOf (ctlOxyPlot.Model.Series(intSeriesIndex)) Is OxyPlot.Series.BarSeries Then
            eCurrentPlotMode = pmPlotModeConstants.pmBar
        ElseIf TypeOf (ctlOxyPlot.Model.Series(intSeriesIndex)) Is OxyPlot.Series.StemSeries Then
            eCurrentPlotMode = pmPlotModeConstants.pmSticksToZero
        ElseIf TypeOf (ctlOxyPlot.Model.Series(intSeriesIndex)) Is OxyPlot.Series.LineSeries Then
            If mSeriesPlotMode(intSeriesIndex) = pmPlotModeConstants.pmBar OrElse mSeriesPlotMode(intSeriesIndex) = pmPlotModeConstants.pmSticksToZero Then
                mSeriesPlotMode(intSeriesIndex) = pmPlotModeConstants.pmLines
            Else
                eCurrentPlotMode = mSeriesPlotMode(intSeriesIndex)
            End If
        End If

        If eCurrentPlotMode <> eNewPlotMode Then

            Dim lstData = New Generic.List(Of OxyPlot.DataPoint)
            Dim strTitle As String

            Select Case eCurrentPlotMode
                Case pmPlotModeConstants.pmBar
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.BarSeries)
                    strTitle = oSeries.Title
                    For intIndex = 0 To oSeries.Items.Count - 1
                        lstData.Add(New OxyPlot.DataPoint(intIndex + 1, oSeries.Items(intIndex).Value))
                    Next
                Case pmPlotModeConstants.pmSticksToZero
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.StemSeries)
                    strTitle = oSeries.Title
                    For Each item In oSeries.Points
                        lstData.Add(CType(item, OxyPlot.DataPoint))
                    Next

                Case Else
                    Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.LineSeries)
                    strTitle = oSeries.Title
                    For Each item In oSeries.Points
                        lstData.Add(CType(item, OxyPlot.DataPoint))
                    Next
            End Select

            Select Case eNewPlotMode
                Case pmPlotModeConstants.pmBar
                    ctlOxyPlot.Model.Series(intSeriesIndex) = GetNewBarSeries(strTitle, lstData)
                Case pmPlotModeConstants.pmSticksToZero
                    ctlOxyPlot.Model.Series(intSeriesIndex) = GetNewStemSeries(strTitle, lstData)
                Case Else
                    ctlOxyPlot.Model.Series(intSeriesIndex) = GetNewLineSeries(strTitle, lstData)
            End Select

            mSeriesPlotMode(intSeriesIndex) = eNewPlotMode
        End If


        Select Case mSeriesPlotMode(intSeriesIndex)
            Case pmPlotModeConstants.pmBar
                Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.BarSeries)

                With oSeries
                    If .BarWidth < 1 Then .BarWidth = 1
                End With

            Case pmPlotModeConstants.pmSticksToZero
                Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.StemSeries)
                With oSeries
                    If .LineStyle = OxyPlot.LineStyle.None Then .LineStyle = OxyPlot.LineStyle.Solid
                    .MarkerType = OxyPlot.MarkerType.None
                End With

            Case Else
                Dim oSeries = CType(ctlOxyPlot.Model.Series(intSeriesIndex), OxyPlot.Series.LineSeries)

                With oSeries
                    Select Case mSeriesPlotMode(intSeriesIndex)
                        Case pmPlotModeConstants.pmLines
                            If .LineStyle = OxyPlot.LineStyle.None Then .LineStyle = OxyPlot.LineStyle.Solid
                            .MarkerType = OxyPlot.MarkerType.None
                        Case pmPlotModeConstants.pmPoints
                            .LineStyle = OxyPlot.LineStyle.None
                            If .MarkerType = OxyPlot.MarkerType.None Then .MarkerType = OxyPlot.MarkerType.Square
                        Case pmPlotModeConstants.pmPointsAndLines
                            If .LineStyle = OxyPlot.LineStyle.None Then .LineStyle = OxyPlot.LineStyle.Solid
                            If .MarkerType = OxyPlot.MarkerType.None Then .MarkerType = OxyPlot.MarkerType.Square
                    End Select
                End With
        End Select

    End Sub

    Public Sub SetSeriesVisible(intSeriesNumber As Integer, blnShowSeries As Boolean)
        AssureValidSeriesNumber(intSeriesNumber)

        ctlOxyPlot.Model.Series(intSeriesNumber - 1).IsVisible = blnShowSeries

    End Sub

    Protected Sub ShowMessage(strMessage As String, Optional ByVal strCaption As String = "Info")
        System.Windows.Forms.MessageBox.Show(strMessage, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub ZoomOutFull(Optional ByVal blnAddToZoomHistory As Boolean = True, Optional ByVal blnAllowFixMinimumYAtZero As Boolean = True)
        ctlOxyPlot.ActualModel.DefaultXAxis.Reset()
        ctlOxyPlot.ActualModel.DefaultYAxis.Reset()
        ctlOxyPlot.Invalidate()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InitializePlotModel()
    End Sub

    Private Sub cmdZoomOut_Click(sender As Object, e As EventArgs) Handles cmdZoomOut.Click
        ZoomOutFull()
    End Sub
End Class
