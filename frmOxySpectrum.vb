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

        ctlOxyPlot.SetSeriesCount(3)

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

        ctlOxyPlot.SetDataXvsY(3, dblXVals, dblYVals, DATA_COUNT, "")
        ctlOxyPlot.SetSeriesPlotMode(3, ctlOxyPlotControl.pmPlotModeConstants.pmSticksToZero)
        ctlOxyPlot.SetSeriesColor(3, ctlOxyPlot.GetDefaultSeriesColor(3))

        SetCurrentSeriesNumber(3)

        ctlOxyPlot.ZoomOutFull()

    End Sub

    Public Sub DeleteDataActiveSeries(Optional ByRef blnConfirmDeletion As Boolean = True)
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

    Public Sub DeleteDataForAllSeries(Optional ByVal blnConfirmDeletion As Boolean = True)
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

        strMessage &= "Program written by Matthew Monroe for the Department of Energy (PNNL, Richland, WA) in 2003" & ControlChars.NewLine

        strMessage &= "This is version " & Me.DllVersion & " (" & Me.DllDate & ")" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "E-mail: matthew.monroe@pnnl.gov or matt@alchemistmatt.com" & ControlChars.NewLine
        strMessage &= "Website: http://panomics.pnl.gov/ or http://www.sysbio.org/resources/staff/" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "Licensed under the Apache License, Version 2.0; you may not use this file except in compliance with the License.  "
        strMessage &= "You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0" & ControlChars.NewLine & ControlChars.NewLine

        MessageBox.Show(strMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Protected Sub ShowMessage(strMessage As String, Optional ByVal strCaption As String = "Info")
        MessageBox.Show(strMessage, strCaption, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub mnuEditAddSampleData_Click(sender As Object, e As EventArgs) Handles mnuEditAddSampleData.Click
        AddSampleData()
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        ShowAboutBox()
    Private Sub mnuFileSaveGraphAsSVG_Click(sender As Object, e As EventArgs) Handles mnuFileSaveGraphAsSVG.Click
        SavePlotAsSVG()
    End Sub

    Private Sub mnuFileSaveGraphAsPNG_Click(sender As Object, e As EventArgs) Handles mnuFileSaveGraphAsPNG.Click
        SavePlotAsPNG()
    End Sub
    End Sub

#End Region

End Class