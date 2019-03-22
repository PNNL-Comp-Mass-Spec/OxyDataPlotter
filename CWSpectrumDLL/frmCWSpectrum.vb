Option Strict On
Option Explicit On

Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports CWUIControlsLib
Imports PRISM
Imports PRISM.DataUtils
Imports ProgressFormNET
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

Friend Class frmCWSpectrum
    Inherits Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents mnuEditCurrentSeriesSelected As Microsoft.VisualBasic.Compatibility.VB6.MenuItemArray
    Public WithEvents mnuFileOpen As System.Windows.Forms.MenuItem
    Public WithEvents mnuFileSave As System.Windows.Forms.MenuItem
    Public WithEvents mnuFileSep1 As System.Windows.Forms.MenuItem
    Public WithEvents mnuFileSep2 As System.Windows.Forms.MenuItem
    Public WithEvents mnuFileClose As System.Windows.Forms.MenuItem
    Public WithEvents mnuFile As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditCopyAsPicture As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditSep1 As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditCopyCurrentData As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditPasteData As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditDeleteData As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditSep2 As System.Windows.Forms.MenuItem
    Public WithEvents _mnuEditCurrentSeriesSelected_1 As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditCurrentSeries As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditSetSeriesCount As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditSep3 As System.Windows.Forms.MenuItem
    Public WithEvents mnuSetZoomRange As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditAutoLabelPoints As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditSep4 As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditRemoveAnnotationsCurrentSeries As System.Windows.Forms.MenuItem
    Public WithEvents mnuRemoveAllAnnotations As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditRemoveAllData As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditSep5 As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditPlotStyles As System.Windows.Forms.MenuItem
    Public WithEvents mnuResetGraphToDefaults As System.Windows.Forms.MenuItem
    Public WithEvents mnuEditAddSampleData As System.Windows.Forms.MenuItem
    Public WithEvents mnuEdit As System.Windows.Forms.MenuItem
    Public WithEvents mnuAboutSoftware As System.Windows.Forms.MenuItem
    Public WithEvents mnuAbout As System.Windows.Forms.MenuItem
    Public MainMenu1 As System.Windows.Forms.MainMenu
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents ctlCWGraph As CWSpectrumDLLNET.CWGraphControl
    Public WithEvents mnuFileSaveToDiskAsPicture As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.mnuEditCurrentSeriesSelected = New Microsoft.VisualBasic.Compatibility.VB6.MenuItemArray(Me.components)
        Me._mnuEditCurrentSeriesSelected_1 = New System.Windows.Forms.MenuItem()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuFileOpen = New System.Windows.Forms.MenuItem()
        Me.mnuFileSave = New System.Windows.Forms.MenuItem()
        Me.mnuFileSep1 = New System.Windows.Forms.MenuItem()
        Me.mnuFileSaveToDiskAsPicture = New System.Windows.Forms.MenuItem()
        Me.mnuFileSep2 = New System.Windows.Forms.MenuItem()
        Me.mnuFileClose = New System.Windows.Forms.MenuItem()
        Me.mnuEdit = New System.Windows.Forms.MenuItem()
        Me.mnuEditCopyAsPicture = New System.Windows.Forms.MenuItem()
        Me.mnuEditSep1 = New System.Windows.Forms.MenuItem()
        Me.mnuEditCopyCurrentData = New System.Windows.Forms.MenuItem()
        Me.mnuEditPasteData = New System.Windows.Forms.MenuItem()
        Me.mnuEditDeleteData = New System.Windows.Forms.MenuItem()
        Me.mnuEditSep2 = New System.Windows.Forms.MenuItem()
        Me.mnuEditCurrentSeries = New System.Windows.Forms.MenuItem()
        Me.mnuEditSetSeriesCount = New System.Windows.Forms.MenuItem()
        Me.mnuEditSep3 = New System.Windows.Forms.MenuItem()
        Me.mnuSetZoomRange = New System.Windows.Forms.MenuItem()
        Me.mnuEditAutoLabelPoints = New System.Windows.Forms.MenuItem()
        Me.mnuEditSep4 = New System.Windows.Forms.MenuItem()
        Me.mnuEditRemoveAnnotationsCurrentSeries = New System.Windows.Forms.MenuItem()
        Me.mnuRemoveAllAnnotations = New System.Windows.Forms.MenuItem()
        Me.mnuEditRemoveAllData = New System.Windows.Forms.MenuItem()
        Me.mnuEditSep5 = New System.Windows.Forms.MenuItem()
        Me.mnuEditPlotStyles = New System.Windows.Forms.MenuItem()
        Me.mnuResetGraphToDefaults = New System.Windows.Forms.MenuItem()
        Me.mnuEditAddSampleData = New System.Windows.Forms.MenuItem()
        Me.mnuAbout = New System.Windows.Forms.MenuItem()
        Me.mnuAboutSoftware = New System.Windows.Forms.MenuItem()
        Me.ctlCWGraph = New CWSpectrumDLLNET.CWGraphControl()
        CType(Me.mnuEditCurrentSeriesSelected, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuEditCurrentSeriesSelected
        '
        '
        '_mnuEditCurrentSeriesSelected_1
        '
        Me._mnuEditCurrentSeriesSelected_1.Checked = True
        Me.mnuEditCurrentSeriesSelected.SetIndex(Me._mnuEditCurrentSeriesSelected_1, CType(1, Short))
        Me._mnuEditCurrentSeriesSelected_1.Index = 0
        Me._mnuEditCurrentSeriesSelected_1.Text = "1"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuEdit, Me.mnuAbout})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileOpen, Me.mnuFileSave, Me.mnuFileSep1, Me.mnuFileSaveToDiskAsPicture, Me.mnuFileSep2, Me.mnuFileClose})
        Me.mnuFile.Text = "&File"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Index = 0
        Me.mnuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuFileOpen.Text = "&Open Graph Data..."
        '
        'mnuFileSave
        '
        Me.mnuFileSave.Index = 1
        Me.mnuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuFileSave.Text = "&Save Graph Data As..."
        '
        'mnuFileSep1
        '
        Me.mnuFileSep1.Index = 2
        Me.mnuFileSep1.Text = "-"
        '
        'mnuFileSaveToDiskAsPicture
        '
        Me.mnuFileSaveToDiskAsPicture.Index = 3
        Me.mnuFileSaveToDiskAsPicture.Text = "Save Graph as Picture ..."
        '
        'mnuFileSep2
        '
        Me.mnuFileSep2.Index = 4
        Me.mnuFileSep2.Text = "-"
        '
        'mnuFileClose
        '
        Me.mnuFileClose.Index = 5
        Me.mnuFileClose.Text = "E&xit"
        '
        'mnuEdit
        '
        Me.mnuEdit.Index = 1
        Me.mnuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEditCopyAsPicture, Me.mnuEditSep1, Me.mnuEditCopyCurrentData, Me.mnuEditPasteData, Me.mnuEditDeleteData, Me.mnuEditSep2, Me.mnuEditCurrentSeries, Me.mnuEditSetSeriesCount, Me.mnuEditSep3, Me.mnuSetZoomRange, Me.mnuEditAutoLabelPoints, Me.mnuEditSep4, Me.mnuEditRemoveAnnotationsCurrentSeries, Me.mnuRemoveAllAnnotations, Me.mnuEditRemoveAllData, Me.mnuEditSep5, Me.mnuEditPlotStyles, Me.mnuResetGraphToDefaults, Me.mnuEditAddSampleData})
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuEditCopyAsPicture
        '
        Me.mnuEditCopyAsPicture.Index = 0
        Me.mnuEditCopyAsPicture.Text = "&Copy as WMF"
        '
        'mnuEditSep1
        '
        Me.mnuEditSep1.Index = 1
        Me.mnuEditSep1.Text = "-"
        '
        'mnuEditCopyCurrentData
        '
        Me.mnuEditCopyCurrentData.Index = 2
        Me.mnuEditCopyCurrentData.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mnuEditCopyCurrentData.Text = "Copy &Data Points"
        '
        'mnuEditPasteData
        '
        Me.mnuEditPasteData.Index = 3
        Me.mnuEditPasteData.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.mnuEditPasteData.Text = "&Paste Data Points..."
        '
        'mnuEditDeleteData
        '
        Me.mnuEditDeleteData.Index = 4
        Me.mnuEditDeleteData.Text = "Delete Data Points..."
        '
        'mnuEditSep2
        '
        Me.mnuEditSep2.Index = 5
        Me.mnuEditSep2.Text = "-"
        '
        'mnuEditCurrentSeries
        '
        Me.mnuEditCurrentSeries.Index = 6
        Me.mnuEditCurrentSeries.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._mnuEditCurrentSeriesSelected_1})
        Me.mnuEditCurrentSeries.Text = "Current &Series"
        '
        'mnuEditSetSeriesCount
        '
        Me.mnuEditSetSeriesCount.Index = 7
        Me.mnuEditSetSeriesCount.Text = "Set Series Count..."
        '
        'mnuEditSep3
        '
        Me.mnuEditSep3.Index = 8
        Me.mnuEditSep3.Text = "-"
        '
        'mnuSetZoomRange
        '
        Me.mnuSetZoomRange.Index = 9
        Me.mnuSetZoomRange.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
        Me.mnuSetZoomRange.Text = "Set &Zoom Range..."
        '
        'mnuEditAutoLabelPoints
        '
        Me.mnuEditAutoLabelPoints.Index = 10
        Me.mnuEditAutoLabelPoints.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.mnuEditAutoLabelPoints.Text = "Auto &Label Points..."
        '
        'mnuEditSep4
        '
        Me.mnuEditSep4.Index = 11
        Me.mnuEditSep4.Text = "-"
        '
        'mnuEditRemoveAnnotationsCurrentSeries
        '
        Me.mnuEditRemoveAnnotationsCurrentSeries.Index = 12
        Me.mnuEditRemoveAnnotationsCurrentSeries.Text = "Remove Annotations for Current Series..."
        '
        'mnuRemoveAllAnnotations
        '
        Me.mnuRemoveAllAnnotations.Index = 13
        Me.mnuRemoveAllAnnotations.Text = "&Remove Annotations for All Series..."
        '
        'mnuEditRemoveAllData
        '
        Me.mnuEditRemoveAllData.Index = 14
        Me.mnuEditRemoveAllData.Text = "Remove Data for &All Series..."
        '
        'mnuEditSep5
        '
        Me.mnuEditSep5.Index = 15
        Me.mnuEditSep5.Text = "-"
        '
        'mnuEditPlotStyles
        '
        Me.mnuEditPlotStyles.Index = 16
        Me.mnuEditPlotStyles.Shortcut = System.Windows.Forms.Shortcut.CtrlY
        Me.mnuEditPlotStyles.Text = "Edit Plot St&yles and Colors..."
        '
        'mnuResetGraphToDefaults
        '
        Me.mnuResetGraphToDefaults.Index = 17
        Me.mnuResetGraphToDefaults.Text = "Reset Graph to Defaults..."
        '
        'mnuEditAddSampleData
        '
        Me.mnuEditAddSampleData.Index = 18
        Me.mnuEditAddSampleData.Text = "Add Sample Data"
        Me.mnuEditAddSampleData.Visible = False
        '
        'mnuAbout
        '
        Me.mnuAbout.Index = 2
        Me.mnuAbout.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAboutSoftware})
        Me.mnuAbout.Text = "&Help"
        '
        'mnuAboutSoftware
        '
        Me.mnuAboutSoftware.Index = 0
        Me.mnuAboutSoftware.Text = "&About Software"
        '
        'ctlCWGraph
        '
        Me.ctlCWGraph.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ctlCWGraph.DateModeXAxis = False
        Me.ctlCWGraph.DateModeXAxisShowTime = False
        Me.ctlCWGraph.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctlCWGraph.Location = New System.Drawing.Point(10, 10)
        Me.ctlCWGraph.Name = "ctlCWGraph"
        Me.ctlCWGraph.Size = New System.Drawing.Size(715, 430)
        Me.ctlCWGraph.TabIndex = 0
        '
        'frmCWSpectrum
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(739, 444)
        Me.Controls.Add(Me.ctlCWGraph)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(11, 53)
        Me.Menu = Me.MainMenu1
        Me.Name = "frmCWSpectrum"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Spectrum"
        CType(Me.mnuEditCurrentSeriesSelected, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Public Event SpectrumFormRequestClose()

    Private Const DEFAULT_FONT_NAME As String = "Arial"
    Private Const DEFAULT_FONT_SIZE As Short = 11

    Private mAutoLabelPeaksForm As frmAutoLabelPeaks

    Private Enum pfmParsingFileModeConstants
        pfmNone = 0
        pfmData = 1
        pfmAnnotations = 2
        pfmOptions = 3
        pfmOther = 4
    End Enum

    Private mLastPath As String
    Private mLastFileName As String

    Private mActiveSeriesNumber As Short
    Private mSeriesNumberMenuLoadedCount As Short

    Private mResizing As Boolean
    Private mAutoLabelPeaksOptions As udtAutoLabelPeaksOptionsInternalType

    Private mNormalizeOnLoadOrPaste As Boolean
    Private mNormalizationConstant As Double

    Private mSpectrumWindowPos As udtWindowPosType

    Private Sub AddSampleData()

        Const DATA_COUNT As Short = 50
        Dim dblXVals() As Double
        Dim dblYVals() As Double
        Dim intIndex As Integer
        Dim dblOriginalMaximumValue As Double

        Dim objRandom As New Random

        DeleteDataForAllSeries(False)

        ctlCWGraph.SetSeriesCount(3)

        ctlCWGraph.GenerateSineWave(1, True)
        ctlCWGraph.SetSeriesColor(1, ctlCWGraph.GetDefaultSeriesColor(1))

        ctlCWGraph.GenerateSineWave(2, False)
        ctlCWGraph.SetSeriesColor(2, ctlCWGraph.GetDefaultSeriesColor(2))

        ReDim dblXVals(DATA_COUNT - 1)
        ReDim dblYVals(DATA_COUNT - 1)

        For intIndex = 0 To DATA_COUNT - 1
            dblXVals(intIndex) = Math.Abs(22 - objRandom.Next(0, 15) * Math.Tan(intIndex / 100.0#) * 2)
            dblYVals(intIndex) = Math.Abs(objRandom.Next(0, 22) * Math.Sin(intIndex / 100.0#) * 15)
        Next intIndex

        FindMaximumAndNormalizeData(dblYVals, 0, DATA_COUNT - 1, mNormalizationConstant, mNormalizeOnLoadOrPaste, dblOriginalMaximumValue)

        ctlCWGraph.SetDataXvsY(3, dblXVals, dblYVals, DATA_COUNT, "", dblOriginalMaximumValue)
        ctlCWGraph.SetSeriesPlotMode(3, CWGraphControl.pmPlotModeConstants.pmSticksToZero)
        ctlCWGraph.SetSeriesColor(3, ctlCWGraph.GetDefaultSeriesColor(3))

        SetCurrentSeriesNumber(3)

        ctlCWGraph.ZoomOutFull(True)

    End Sub

    Private Function ConvertColorNameToColorObject(strColorName As String) As Color
        ' Removes "Color [" and "]" from strColorName

        Dim strCleanName As String
        Dim cNewColor As Color

        If Not strColorName Is Nothing Then
            strCleanName = strColorName
            If strCleanName.IndexOf("[") = 6 Then
                strCleanName = strCleanName.Remove(0, 7)
                strCleanName = strCleanName.Remove(strCleanName.Length - 1, 1)
            End If

            cNewColor = Color.FromName(strCleanName)

            Debug.Assert(cNewColor.ToString = strColorName)

            ConvertColorNameToColorObject = cNewColor
        Else
            ConvertColorNameToColorObject = Color.Black
        End If

    End Function

    Public Sub CopyDataPointsToClipboardOrToString(ByRef intSeriesNumber As Short, Optional ByRef strDataToCopy As String = "", Optional ByVal strDelim As String = vbTab, Optional ByVal blnCopyToClipboard As Boolean = True)
        Dim dblXData() As Double
        Dim dblYData() As Double
        Dim intDataCount As Integer
        Dim intIndex As Integer

        Dim strExport() As String

        If ctlCWGraph.GetDataXvsY(intSeriesNumber, dblXData, dblYData, intDataCount) Then

            If intDataCount <= 0 Then Exit Sub

            ReDim strExport(intDataCount)

            Me.Cursor = Cursors.WaitCursor

            For intIndex = 0 To intDataCount - 1
                strExport(intIndex) = dblXData(intIndex) & strDelim & dblYData(intIndex)
            Next intIndex

            strDataToCopy = FlattenStringArray(strExport, intDataCount, vbCrLf)

            If blnCopyToClipboard Then
                Try
                    Clipboard.SetDataObject(strDataToCopy)
                Catch ex As Exception
                    Debug.Assert(False, "Error copying text to clipboard in CopyDataPointsToClipboardOrToString: " & ex.Message)
                End Try
            End If

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Public Sub CopyToClipboardAsPicture()
        'Dim objGraphPicture As CWUIControlsLib.IPictureDisp
        Dim objGraphPicture As Image

        Try
            objGraphPicture = ctlCWGraph.GetControlImage()

            Dim objClipboardMFHelper As New ClipboardMetaFileHelper
            ClipboardMetaFileHelper.PutEnhMetafileOnClipboard(Me.Handle, objGraphPicture)

            ' The following two .SetDataObject() calls do not work
            'Clipboard.SetDataObject(VB6.IPictureDispToImage(objGraphPicture))
            'Clipboard.SetDataObject(objGraphPicture)
        Catch ex As Exception
            MsgBox("Error copying picture to clipboard: " & ex.Message)
        End Try
    End Sub

    Public Sub DeleteDataActiveSeries(Optional ByRef blnConfirmDeletion As Boolean = True)
        Dim eResponse As MsgBoxResult
        Dim intDataCount As Integer

        intDataCount = ctlCWGraph.GetDataCount(mActiveSeriesNumber)
        If intDataCount > 0 And blnConfirmDeletion Then
            eResponse = MsgBox("Are you sure you want to delete the data in series " & mActiveSeriesNumber.ToString.Trim & "?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3, "Delete Data")
            If eResponse <> MsgBoxResult.Yes Then Exit Sub
        End If

        ctlCWGraph.RemoveAnnotationsForSeries(mActiveSeriesNumber)
        ctlCWGraph.ClearData(mActiveSeriesNumber)

        ShowHideSeriesNumberMenus()

    End Sub

    Public Sub DeleteDataForAllSeries(Optional ByRef blnConfirmDeletion As Boolean = True)
        Dim eResponse As MsgBoxResult
        Dim intSeriesIndex As Short

        If blnConfirmDeletion Then
            eResponse = MsgBox("Are you sure you want to delete all the data in the graph?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3, "Delete Data")
            If eResponse <> MsgBoxResult.Yes Then Exit Sub
        End If

        For intSeriesIndex = ctlCWGraph.GetSeriesCount() To 1 Step -1
            mActiveSeriesNumber = intSeriesIndex
            DeleteDataActiveSeries(False)
        Next intSeriesIndex

    End Sub

    Private Function DetermineDecimalPoint() As String
        Dim strTestNumber As String
        Dim sglConversionResult As Double

        ' Note that the Trim(Str(CDbl(...))) statement causes an error when the
        '  user's computer is configured for using , for decimal points but not . for the
        '  thousand's separator (instead, perhaps, using a space for thousands)

        Try
            ' Determine what locale we're in (. or , for decimal point)
            strTestNumber = "5,500"
            sglConversionResult = CDbl(strTestNumber)
            If sglConversionResult = 5.5 Then
                ' Use comma as Decimal point
                Return ","
            Else
                ' Use period as Decimal point
                Return "."
            End If

        Catch ex As Exception
            Return "."
        End Try

    End Function

    Private Sub EditPlotStyles()
        Dim objSpectrumOptionsForm As New frmCWSpectrumOptions

        objSpectrumOptionsForm.InitializeForm(Me, mActiveSeriesNumber, True)
        objSpectrumOptionsForm.ShowDialog()
        objSpectrumOptionsForm = Nothing

    End Sub

    Public Function FlattenStringArray(ByRef strArrayZeroBased() As String, ByRef intArrayCount As Integer, Optional ByRef strLineDelimeter As String = vbCrLf, Optional ByRef blnShowProgressFormOnLongOperation As Boolean = True, Optional ByRef blnIncludeDelimeterAfterFinalItem As Boolean = True) As String
        ' Flattens the entries in strArrayZeroBased() into a single string, separating each entry by strLineDelimeter
        ' Uses some recursive tricks to speed up this process vs. simply concatenating all the entries to a single string variable

        Const MIN_PROGRESS_COUNT As Short = 2500

        ' Note: The following must be evenly divisible by 10
        Const CUMULATIVE_CHUNK_SIZE As Short = 500

        Dim lngFillStringMaxIndex As Integer
        Dim lngSrcIndex As Integer
        Dim blnShowProgress As Boolean
        Dim FillStringArray() As String
        Dim FillStringCumulative As String = String.Empty

        Dim objProgress As frmProgress = Nothing

        Try
            lngFillStringMaxIndex = -1

            If intArrayCount > MIN_PROGRESS_COUNT And blnShowProgressFormOnLongOperation Then blnShowProgress = True

            If blnShowProgress Then
                objProgress = New frmProgress
                objProgress.InitializeProgressForm("Copying data to clipboard", 0, intArrayCount, False, False, False)
                Application.DoEvents()
            End If

            ReDim FillStringArray(CInt(intArrayCount / CUMULATIVE_CHUNK_SIZE) + 2)

            For lngSrcIndex = 0 To intArrayCount - 1
                If lngSrcIndex Mod CUMULATIVE_CHUNK_SIZE / 10 = 0 Then
                    If lngSrcIndex Mod CUMULATIVE_CHUNK_SIZE = 0 Then
                        lngFillStringMaxIndex = lngFillStringMaxIndex + 1
                    End If

                    If blnShowProgress Then
                        objProgress?.UpdateProgressBar(lngSrcIndex)
                        If objProgress?.KeyPressAbortProcess Then Exit For
                        Application.DoEvents()
                    End If
                End If

                FillStringArray(lngFillStringMaxIndex) &= strArrayZeroBased(lngSrcIndex) & strLineDelimeter

            Next lngSrcIndex

            If lngFillStringMaxIndex >= 0 And Not blnIncludeDelimeterAfterFinalItem Then
                FillStringArray(lngFillStringMaxIndex) = Microsoft.VisualBasic.Left(FillStringArray(lngFillStringMaxIndex), Len(FillStringArray(lngFillStringMaxIndex)) - Len(strLineDelimeter))
            End If

            For lngSrcIndex = 0 To lngFillStringMaxIndex
                FillStringCumulative &= FillStringArray(lngSrcIndex)
            Next lngSrcIndex


        Catch ex As Exception
            Debug.Assert(False, "Error in FlattenStringArray" & ex.Message)
            FillStringCumulative = FillStringCumulative
        Finally
            If blnShowProgress Then
                objProgress?.HideForm()
            End If
        End Try

        Return FillStringCumulative

    End Function

    Public Function GetActiveSeriesNumber() As Short
        Return mActiveSeriesNumber
    End Function

    Public Sub StoreAutoLabelPeaksOptionsInModule()
        AutoLabelOptionsStore(mAutoLabelPeaksOptions)
    End Sub

    Public Function GetNormalizeOnLoadOrPaste() As Boolean
        Return mNormalizeOnLoadOrPaste
    End Function

    Public Function GetNormalizationConstant() As Double
        Return mNormalizationConstant
    End Function

    Public Sub GetWindowPos(ByRef intTop As Integer, ByRef intLeft As Integer, ByRef intHeight As Integer, ByRef intWidth As Integer)
        With mSpectrumWindowPos
            intTop = .PosTop
            intLeft = .PosLeft
            intHeight = .Height
            intWidth = .Width
        End With
    End Sub

    Public Sub LoadDataFromDisk(Optional ByRef strInputFilePath As String = "", Optional ByRef blnShowMessages As Boolean = True, Optional ByRef blnLoadOptionsOnly As Boolean = False, Optional ByRef blnDelimeterComma As Boolean = True, Optional ByRef blnDelimeterTab As Boolean = True, Optional ByRef blnDelimeterSpace As Boolean = False, Optional ByRef blnLoadingDTAFile As Boolean = False)
        ' Loads data and graph options from disk
        ' If strInputFilePath is empty, then prompts the user for a path (unless blnShowMessages = False)
        ' Note: if blnDelimeterSpace = True, then no space can be present between the annotation options

        Const FILE_SIZE_KBYTES_TO_SHOW_PROGRESS_FORM As Short = 300
        Static intFilterIndexDefault As Short

        Dim intNewSeriesIndex, intSeriesIndex, intMaxSeriesIndex As Short
        Dim intSeriesOptionsSeriesIndex, intAnnotationSeriesIndex As Short
        Dim blnInputFilePathPassedToSub As Boolean
        Dim blnUserWarnedReplaceExistingData As Boolean
        Dim blnAutoHideCaptionsSaved As Boolean
        Dim blnSkippedParentIon As Boolean
        Dim strParentIonInfo As String = String.Empty

        Dim strLineIn As String
        Dim lngBytesLoaded, lngLinesRead As Integer
        Dim strDelimeterList As String
        Dim intParsedValsCount As Integer
        Dim strParsedVals() As String ' 0-based array
        Dim lngCharLoc As Integer
        Dim intIndex As Short

        Dim dblXData() As Double ' 0-based array
        Dim dblYData() As Double ' 0-based array
        Dim intDataCount, intDataCountDimmed As Integer

        Dim strKeyString, strKeyValue As String
        Dim blnFixMinimumYAtZero, blnAutoScaleVisibleY, blnUpdateAutoScaleOptions As Boolean
        Dim dblCursorPosX, dblCursorPosY As Double
        Dim blnUpdateCursorPosition As Boolean
        Dim blnAnnotationHideInDenseRegions As Boolean
        Dim blnAutoHideCaptions As Boolean

        Dim blnShowProgressForm As Boolean
        Dim lngInputFileLengthBytes As Long

        ' Note: Do not normalize data if loading from a .CSV file, or any file with a [] section
        ' Do normalize data if the file is a .Dta file or any file with only numbers
        ' Thus, since we initially don't know the file type, we'll initially set blnNormalizeData to mNormalizeOnLoadOrPaste (and thus, possibly, to True)
        ' If, at a later time, we find the file contains a [] section, then this is set to False
        Dim blnNormalizeData As Boolean

        Dim eParsingDataMode As pfmParsingFileModeConstants

        Dim strAnnotationOptions, strCaption, strSubString As String
        Dim dblCaptionXPos, dblCaptionYPos As Double
        Dim lngCaptionAngle As Integer
        Dim blnAnnotationIncludesArrow As Boolean
        Dim blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY As Boolean
        Dim eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants
        Dim lngAnnotationPointNumberToBind As Integer
        Dim intNumLength As Integer

        Dim blnMatched As Boolean

        Dim objProgress As frmProgress = Nothing

        Dim srInFile As StreamReader

        Try
            If strInputFilePath Is Nothing OrElse strInputFilePath.Length = 0 Then
                If blnShowMessages Then
                    If intFilterIndexDefault = 0 Then intFilterIndexDefault = 1
                    strInputFilePath = SelectFile("Enter file name to Load graph data from", mLastPath, False, mLastFileName, "CSV Files (*.csv)|*.csv|DTA Files (*.dta)|*.dta|All Files (*.*)|*.*", intFilterIndexDefault)
                End If
            Else
                blnInputFilePathPassedToSub = True
            End If

            If Len(strInputFilePath) = 0 Then Exit Sub

            mLastPath = Path.GetDirectoryName(strInputFilePath)
            mLastFileName = Path.GetFileName(strInputFilePath)

            If Path.GetExtension(strInputFilePath).ToLower = ".dta" Then
                ' User chose a .Dta file
                ' Turn on blnDelimeterSpace and ignore the first numeric line if it matches the format: 'Parent ion' 'Charge'
                blnDelimeterSpace = True
                blnLoadingDTAFile = True
                intFilterIndexDefault = 2
            Else
                intFilterIndexDefault = 1
            End If

            srInFile = New StreamReader(strInputFilePath)

            ' Initialize the delimeter list
            strDelimeterList = ""
            If blnDelimeterComma Then strDelimeterList = strDelimeterList & ","
            If blnDelimeterSpace Then strDelimeterList = strDelimeterList & " "
            If blnDelimeterTab Then strDelimeterList = strDelimeterList & vbTab

            If Len(strDelimeterList) = 0 Then strDelimeterList = ", " & vbTab

            If blnLoadingDTAFile Then
                intSeriesIndex = mActiveSeriesNumber
                DeleteDataActiveSeries(False)
            Else
                ' Default to use Series 1 until an alternative section header is found
                intSeriesIndex = 1
            End If

            intMaxSeriesIndex = 0
            intSeriesOptionsSeriesIndex = 1
            intAnnotationSeriesIndex = 1
            blnNormalizeData = mNormalizeOnLoadOrPaste

            eParsingDataMode = pfmParsingFileModeConstants.pfmData

            intDataCount = 0
            intDataCountDimmed = 100
            ReDim dblXData(intDataCountDimmed)
            ReDim dblYData(intDataCountDimmed)

            ' Need to lookup up the current status of the following two options in case they're not present in the data file
            blnAutoScaleVisibleY = ctlCWGraph.GetAutoscaleVisibleY()
            blnFixMinimumYAtZero = ctlCWGraph.GetFixMinimumYAtZero()
            ctlCWGraph.GetCursorPosition(dblCursorPosX, dblCursorPosY)

            lngInputFileLengthBytes = srInFile.BaseStream.Length
            If lngInputFileLengthBytes / 1024.0# >= FILE_SIZE_KBYTES_TO_SHOW_PROGRESS_FORM Then
                blnShowProgressForm = True
                objProgress = New frmProgress
                objProgress.InitializeProgressForm("Loading data", 0, lngInputFileLengthBytes, False, False, False)
                objProgress.ToggleAlwaysOnTop(True)
                objProgress.MoveToBottomCenter()
            End If

            ' Disble auto-hide captions while loading data
            blnAutoHideCaptionsSaved = ctlCWGraph.GetAnnotationDensityAutoHideCaptions()
            If blnAutoHideCaptionsSaved Then ctlCWGraph.SetAnnotationDensityAutoHideCaptions(False, False)

            Do While srInFile.Peek >= 0
                strLineIn = srInFile.ReadLine
                If strLineIn Is Nothing Then strLineIn = String.Empty

                lngBytesLoaded = lngBytesLoaded + Len(strLineIn) + 2
                lngLinesRead = lngLinesRead + 1
                If blnShowProgressForm And lngLinesRead Mod 50 = 0 Then
                    objProgress?.UpdateProgressBar(lngBytesLoaded)
                End If

                strLineIn = strLineIn.Trim
                If strLineIn.Length = 0 Then
                    ' Ignore it

                ElseIf strLineIn.StartsWith(";") Then
                    ' Comment, ignore it

                ElseIf strLineIn.StartsWith("[") Then

                    ' Section header, parse it
                    strLineIn = strLineIn.Substring(1).ToUpper

                    ' Remove the trailing ]
                    If strLineIn.EndsWith("]") Then strLineIn = strLineIn.Substring(0, strLineIn.Length - 1)

                    ' Look for _Series in strLineIn
                    lngCharLoc = InStr(strLineIn, "_SERIES")
                    intNewSeriesIndex = 0
                    If lngCharLoc > 0 Then
                        intNewSeriesIndex = CShortSafe(Mid(strLineIn, lngCharLoc + 7))
                    End If

                    ' Possibly update intMaxSeriesIndex, using intSeriesIndex if intDataCount > 0
                    '  or using intNewSeriesIndex
                    If intDataCount > 0 Then
                        If intSeriesIndex > intMaxSeriesIndex Then intMaxSeriesIndex = intSeriesIndex
                    End If
                    If intNewSeriesIndex > intMaxSeriesIndex Then intMaxSeriesIndex = intNewSeriesIndex

                    ' Since we found a [] section, set blnNormalizeData to False
                    blnNormalizeData = False

                    ' Copy data from dblXData() and dblYData() to the graph if not done yet
                    If Not LoadDataFromDiskUpdateSeries(intSeriesIndex, dblXData, dblYData, intDataCount, blnShowMessages, blnUserWarnedReplaceExistingData, blnNormalizeData) Then
                        ' User cancelled the update; stop parsing
                        Exit Try
                    End If

                    If intNewSeriesIndex > 0 Then
                        If intNewSeriesIndex > ctlCWGraph.GetSeriesCount() Then
                            ctlCWGraph.SetSeriesCount(intNewSeriesIndex)
                        End If
                    End If

                    If strLineIn.StartsWith("DATA") Then
                        If intNewSeriesIndex > 0 Then
                            intDataCount = 0
                            intDataCountDimmed = 100
                            ReDim dblXData(intDataCountDimmed)
                            ReDim dblYData(intDataCountDimmed)
                            intSeriesIndex = intNewSeriesIndex
                        End If
                        eParsingDataMode = pfmParsingFileModeConstants.pfmData
                        If blnShowProgressForm Then
                            objProgress?.UpdateCurrentSubTask("Loading data for series " & intSeriesIndex.ToString.Trim)
                        End If

                    ElseIf strLineIn.StartsWith("PLOTOPTIONS") Then
                        If intNewSeriesIndex > 0 Then
                            intSeriesOptionsSeriesIndex = intNewSeriesIndex
                        End If
                        eParsingDataMode = pfmParsingFileModeConstants.pfmOptions
                        If blnShowProgressForm Then
                            objProgress?.UpdateCurrentSubTask("Loading options for series " & intSeriesIndex.ToString.Trim)
                        End If

                    ElseIf strLineIn.StartsWith("ANNOTATIONS") Then
                        intAnnotationSeriesIndex = intNewSeriesIndex
                        ' Remove any existing annotations for this series
                        ctlCWGraph.RemoveAnnotationsForSeries(intAnnotationSeriesIndex)
                        eParsingDataMode = pfmParsingFileModeConstants.pfmAnnotations
                        If blnShowProgressForm Then
                            objProgress?.UpdateCurrentSubTask("Loading annotations for series " & intSeriesIndex.ToString.Trim)
                        End If

                    ElseIf strLineIn.StartsWith("GLOBALPLOTOPTIONS") Then
                        eParsingDataMode = pfmParsingFileModeConstants.pfmOptions
                    Else
                        ' Ignore it; the header doesn't really matter
                        ' Set eParsingDataMode to pfmNone
                        eParsingDataMode = pfmParsingFileModeConstants.pfmNone
                    End If

                ElseIf Char.IsNumber(strLineIn.Chars(0)) Then
                    ' The line starts with a number; it's probably data or annotation info

                    If blnLoadOptionsOnly Then
                        ' Ignore non-options lines
                    Else
                        strParsedVals = strLineIn.Split(strDelimeterList.ToCharArray, 10)
                        'intParsedValsCount = ParseString(strLineIn, strParsedVals, 10, strDelimeterList, "", False, True, False)
                        intParsedValsCount = strParsedVals.Length
                        If intParsedValsCount >= 2 Then
                            If eParsingDataMode = pfmParsingFileModeConstants.pfmData Then
                                ' Assume the entry is an x,y data point pair
                                If IsNumeric(strParsedVals(0)) And IsNumeric(strParsedVals(1)) Then
                                    dblXData(intDataCount) = CDbl(strParsedVals(0))
                                    dblYData(intDataCount) = CDbl(strParsedVals(1))

                                    intDataCount = intDataCount + 1
                                    If intDataCount >= intDataCountDimmed Then
                                        intDataCountDimmed = intDataCountDimmed + 100
                                        ReDim Preserve dblXData(intDataCountDimmed)
                                        ReDim Preserve dblYData(intDataCountDimmed)
                                    End If

                                    If blnLoadingDTAFile And Not blnSkippedParentIon Then
                                        ' Skip the first set of data since it is the parent ion (MH) and charge
                                        strParentIonInfo = strLineIn
                                        blnSkippedParentIon = True
                                        intDataCount = 0
                                    End If

                                End If
                            ElseIf eParsingDataMode = pfmParsingFileModeConstants.pfmAnnotations Then
                                ' Assume the entry is an annotation
                                ' Annotation format is either "x, y, annotation text"
                                '                      or     "x, y, angle, options, annotation text"
                                ' The second method is preferred; separate options using a space
                                ' Options are: \A   Shows Arrow
                                '              \FA0  The caption can be bound to any data point, and is initially bound to point 0
                                '              \FS0  The caption is bound to a single data point, point 0
                                '              \FL   The caption is floating, and thus not bound to any data points
                                '              \H   Hides caption in crowded regions
                                '              \X   Shows X of nearest Point
                                '              \Y   Shows Y of nearest Point

                                If intParsedValsCount >= 3 Then
                                    If IsNumeric(strParsedVals(0)) And IsNumeric(strParsedVals(1)) Then
                                        dblCaptionXPos = CDbl(strParsedVals(0))
                                        dblCaptionYPos = CDbl(strParsedVals(1))

                                        If intParsedValsCount >= 5 Then
                                            lngCaptionAngle = StringToValueUtils.CIntSafe(strParsedVals(2), 0)
                                            strAnnotationOptions = strParsedVals(3)
                                            strCaption = strParsedVals(4)

                                            ' The following is needed in case the user placed a comma in a caption
                                            For intIndex = 5 To CShort(UBound(strParsedVals))
                                                strCaption = strCaption & strParsedVals(intIndex)
                                            Next intIndex

                                            If Len(strCaption) = 0 And Len(strAnnotationOptions) > 0 Then
                                                ' The user may have edited the file and removed the annotation options
                                                ' If strAnnotationOptions doesn't start with a \, then copy it to strCaption
                                                If strAnnotationOptions.Chars(0) <> "\"c Then
                                                    strCaption = strAnnotationOptions
                                                    strAnnotationOptions = ""
                                                End If
                                            End If

                                        ElseIf intParsedValsCount >= 4 Then
                                            ' The user either left out the angle or left out the annotation options

                                            If IsNumeric(strParsedVals(2)) Then
                                                lngCaptionAngle = StringToValueUtils.CIntSafe(strParsedVals(2), 0)
                                                strAnnotationOptions = ""
                                            Else
                                                lngCaptionAngle = 0
                                                strAnnotationOptions = strParsedVals(2)
                                            End If

                                            strCaption = strParsedVals(3)

                                        Else
                                            ' Only 3 items; assume X pos, Y pos, and caption text
                                            lngCaptionAngle = 0
                                            strAnnotationOptions = ""
                                            strCaption = strParsedVals(2)
                                        End If

                                        strAnnotationOptions = strAnnotationOptions.ToUpper

                                        ' Parse strAnnotationOptions
                                        blnAnnotationIncludesArrow = (InStr(strAnnotationOptions, "\A") > 0)

                                        eAnnotationSnapMode = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint
                                        lngCharLoc = InStr(strAnnotationOptions, "\F")
                                        If lngCharLoc > 0 Then
                                            ' Look for a letter after \F
                                            strSubString = Mid(strAnnotationOptions, lngCharLoc + 2, 1)
                                            Select Case strSubString
                                                Case "A"
                                                    ' Fixed to any data point
                                                    eAnnotationSnapMode = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint
                                                    strSubString = Mid(strAnnotationOptions, lngCharLoc + 3)
                                                Case "S"
                                                    ' Fixed to a single data point
                                                    eAnnotationSnapMode = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint
                                                    strSubString = Mid(strAnnotationOptions, lngCharLoc + 3)
                                                Case "L"
                                                    ' Floating
                                                    eAnnotationSnapMode = CWGraphControl.asmAnnotationSnapModeConstants.asmFloating
                                                    strSubString = Mid(strAnnotationOptions, lngCharLoc + 3)
                                                Case Else
                                                    ' Assume Fixed to single data point
                                                    eAnnotationSnapMode = CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint
                                                    strSubString = Mid(strAnnotationOptions, lngCharLoc + 2)
                                            End Select

                                            StringToNumber(strSubString, intNumLength)

                                            If intNumLength > 0 Then
                                                lngAnnotationPointNumberToBind = StringToValueUtils.CIntSafe(strSubString.Substring(0, intNumLength), -1)
                                            Else
                                                lngAnnotationPointNumberToBind = -1
                                            End If
                                        End If

                                        blnAnnotationHideInDenseRegions = (InStr(strAnnotationOptions, "\H") > 0)
                                        blnAnnotationShowsNearestPointX = (InStr(strAnnotationOptions, "\X") > 0)
                                        blnAnnotationShowsNearestPointY = (InStr(strAnnotationOptions, "\Y") > 0)

                                        ctlCWGraph.SetAnnotation(False, dblCaptionXPos, dblCaptionYPos, strCaption, lngCaptionAngle, intAnnotationSeriesIndex, eAnnotationSnapMode, lngAnnotationPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnAnnotationIncludesArrow, blnAnnotationHideInDenseRegions)
                                    End If
                                End If
                            Else
                                ' Misplaced number
                                ' Ignore it
                                Debug.Assert(False, "")
                            End If

                        End If
                    End If
                ElseIf InStr(strLineIn, "=") > 0 Then
                    ' Options Setting, parse it (provided eParsingDataMode = pfmOptions)
                    ' The following options settings could be present in the GlobalPlotOptions section,
                    '  or in a section for a specific series

                    If eParsingDataMode = pfmParsingFileModeConstants.pfmOptions Then
                        lngCharLoc = InStr(strLineIn, "=")
                        strKeyString = strLineIn.Substring(0, lngCharLoc - 1)
                        strKeyValue = Mid(strLineIn, lngCharLoc + 1)

                        Try
                            blnMatched = True

                            ' Options that apply to the entire Plot
                            Select Case strKeyString.ToUpper
                                Case "TITLE"
                                    ctlCWGraph.SetLabelTitle(strKeyValue)
                                Case "SUBTITLE"
                                    ctlCWGraph.SetLabelSubTitle(strKeyValue)
                                Case "XAXIS"
                                    ctlCWGraph.SetLabelXAxis(strKeyValue)
                                Case "YAXIS"
                                    ctlCWGraph.SetLabelYAxis(strKeyValue)
                                Case "LABELFONTNAME"
                                    ctlCWGraph.SetLabelFontName(strKeyValue)
                                Case "LABELFONTSIZE"
                                    ctlCWGraph.SetLabelFontSize(CShortSafe(strKeyValue))
                                Case "LABELFONTCOLOR"
                                    ctlCWGraph.SetLabelFontColor(ConvertColorNameToColorObject(strKeyValue))

                                Case "GRIDLINESXCOLORMAJOR"
                                    ctlCWGraph.SetGridLinesXColor(ConvertColorNameToColorObject(strKeyValue), True)
                                Case "GRIDLINESXCOLORMINOR"
                                    ctlCWGraph.SetGridLinesXColor(ConvertColorNameToColorObject(strKeyValue), False)
                                Case "GRIDLINESYCOLORMAJOR"
                                    ctlCWGraph.SetGridLinesYColor(ConvertColorNameToColorObject(strKeyValue), True)
                                Case "GRIDLINESYCOLORMINOR"
                                    ctlCWGraph.SetGridLinesYColor(ConvertColorNameToColorObject(strKeyValue), False)

                                Case "GRIDLINESXVISIBLEMAJOR"
                                    ctlCWGraph.SetGridLinesXVisible(CBoolSafe(strKeyValue), True)
                                Case "GRIDLINESXVISIBLEMINOR"
                                    ctlCWGraph.SetGridLinesXVisible(CBoolSafe(strKeyValue), False)
                                Case "GRIDLINESYVISIBLEMAJOR"
                                    ctlCWGraph.SetGridLinesYVisible(CBoolSafe(strKeyValue), True)
                                Case "GRIDLINESYVISIBLEMINOR"
                                    ctlCWGraph.SetGridLinesYVisible(CBoolSafe(strKeyValue), False)

                                Case "PLOTBACKGROUNDCOLOR"
                                    ctlCWGraph.SetPlotBackgroundColor(ConvertColorNameToColorObject(strKeyValue))

                                Case "NORMALIZEONLOADORPASTE"
                                    SetNormalizeOnLoadOrPaste(CBoolSafe(strKeyValue))
                                Case "NORMALIZATIONCONSTANT"
                                    SetNormalizationConstant(StringToValueUtils.CDoubleSafe(strKeyValue, 100))

                                Case "ANNOTATIONDENSITYAUTOHIDECAPTIONS"
                                    blnAutoHideCaptions = CBoolSafe(strKeyValue)
                                Case "ANNOTATIONDENSITYTOLERANCEAUTOADJUST"
                                    ctlCWGraph.SetAnnotationDensityToleranceAutoAdjust(CBoolSafe(strKeyValue))
                                Case "ANNOTATIONDENSITYTOLERANCEX"
                                    ctlCWGraph.SetAnnotationDensityToleranceX(StringToValueUtils.CDoubleSafe(strKeyValue, 1))
                                Case "ANNOTATIONDENSITYTOLERANCEY"
                                    ctlCWGraph.SetAnnotationDensityToleranceY(StringToValueUtils.CDoubleSafe(strKeyValue, 1))

                                Case "AUTOSCALEVISIBLEY"
                                    blnAutoScaleVisibleY = CBoolSafe(strKeyValue)
                                    blnUpdateAutoScaleOptions = True
                                Case "FIXMINIMUMYATZERO"
                                    blnFixMinimumYAtZero = CBoolSafe(strKeyValue)
                                    blnUpdateAutoScaleOptions = True
                                Case "AUTOADJUSTSCALINGTOINCLUDECAPTIONS"
                                    ctlCWGraph.SetAutoAdjustScalingToIncludeCaptions(CBoolSafe(strKeyValue))
                                Case "PRECISIONX"
                                    ctlCWGraph.SetDisplayPrecisionX(CShortSafe(strKeyValue))
                                Case "PRECISIONY"
                                    ctlCWGraph.SetDisplayPrecisionY(CShortSafe(strKeyValue))

                                Case "CURSOR1VISIBLE"
                                    ctlCWGraph.SetCursorVisible(CBoolSafe(strKeyValue), 1)
                                Case "CURSOR2VISIBLE"
                                    ctlCWGraph.SetCursorVisible(CBoolSafe(strKeyValue), 2)
                                Case "CURSORSNAPTODATA"
                                    ctlCWGraph.SetCursorSnapMode(CBoolSafe(strKeyValue))
                                Case "CURSOR1COLOR"
                                    ctlCWGraph.SetCursorColor(ConvertColorNameToColorObject(strKeyValue), 1)
                                Case "CURSOR2COLOR"
                                    ctlCWGraph.SetCursorColor(ConvertColorNameToColorObject(strKeyValue), 2)
                                Case "CURSORPOSITIONX"
                                    dblCursorPosX = StringToValueUtils.CDoubleSafe(strKeyValue, 0)
                                    blnUpdateCursorPosition = True
                                Case "CURSORPOSITIONY"
                                    dblCursorPosY = StringToValueUtils.CDoubleSafe(strKeyValue, 0)
                                    blnUpdateCursorPosition = True

                                Case "AUTOLABELPEAKSDISPLAYXPOSITION"
                                    mAutoLabelPeaksOptions.DisplayXPos = CBoolSafe(strKeyValue)
                                Case "AUTOLABELPEAKSDISPLAYYPOSITION"
                                    mAutoLabelPeaksOptions.DisplayYPos = CBoolSafe(strKeyValue)
                                Case "AUTOLABELPEAKSINCLUDEARROW"
                                    mAutoLabelPeaksOptions.IncludeArrow = CBoolSafe(strKeyValue)
                                Case "AUTOLABELPEAKSHIDEINDENSEREGIONS"
                                    mAutoLabelPeaksOptions.HideInDenseRegions = CBoolSafe(strKeyValue)
                                Case "AUTOLABELPEAKSCAPTIONANGLE"
                                    mAutoLabelPeaksOptions.CaptionAngle = StringToValueUtils.CIntSafe(strKeyValue, 0)
                                Case "AUTOLABELPEAKSINTENSITYTHRESHOLDMINIMUM"
                                    mAutoLabelPeaksOptions.IntensityThresholdMinimum = StringToValueUtils.CIntSafe(strKeyValue, 10)
                                Case "AUTOLABELPEAKSMINIMUMINTENSITYPERCENTAGEOFMAXIMUM"
                                    mAutoLabelPeaksOptions.MinimumIntensityPercentageOfMaximum = StringToValueUtils.CIntSafe(strKeyValue, 10)
                                Case "AUTOLABELPEAKSPEAKWIDTHMINIMUMPOINTS"
                                    mAutoLabelPeaksOptions.PeakWidthMinimumPoints = StringToValueUtils.CIntSafe(strKeyValue, 5)
                                Case "AUTOLABELPEAKSLABELCOUNTMAXIMUM"
                                    mAutoLabelPeaksOptions.PeakLabelCountMaximum = StringToValueUtils.CIntSafe(strKeyValue, 100)

                                Case Else
                                    blnMatched = False
                            End Select

                            If Not blnMatched Then

                                blnMatched = True

                                ' Options that apply to a specific series
                                Select Case strKeyString.ToUpper
                                    Case "SERIESPLOTMODE"
                                        ctlCWGraph.SetSeriesPlotMode(intSeriesOptionsSeriesIndex, CType(strKeyValue, CWGraphControl.pmPlotModeConstants))
                                    Case "SERIESLINESTYLE"
                                        ctlCWGraph.SetSeriesLineStyle(intSeriesOptionsSeriesIndex, CType(strKeyValue, CWLineStyles))
                                    Case "SERIESLINEWIDTH"
                                        ctlCWGraph.SetSeriesLineWidth(intSeriesOptionsSeriesIndex, CShortSafe(strKeyValue))
                                    Case "SERIESLINECOLOR"
                                        ctlCWGraph.SetSeriesLineColor(intSeriesOptionsSeriesIndex, ConvertColorNameToColorObject(strKeyValue))
                                    Case "SERIESLINETOBASECOLOR"
                                        ctlCWGraph.SetSeriesLineToBaseColor(intSeriesOptionsSeriesIndex, ConvertColorNameToColorObject(strKeyValue))
                                    Case "SERIESBARFILLCOLOR"
                                        ctlCWGraph.SetSeriesBarFillColor(intSeriesOptionsSeriesIndex, ConvertColorNameToColorObject(strKeyValue))
                                    Case "SERIESPOINTSTYLE"
                                        ctlCWGraph.SetSeriesPointStyle(intSeriesOptionsSeriesIndex, CType(strKeyValue, CWPointStyles))
                                    Case "SERIESPOINTCOLOR"
                                        ctlCWGraph.SetSeriesPointColor(intSeriesOptionsSeriesIndex, ConvertColorNameToColorObject(strKeyValue))
                                    Case "SERIESLEGENDCAPTION"
                                        ctlCWGraph.SetSeriesLegendCaption(intSeriesOptionsSeriesIndex, strKeyValue)
                                    Case "SERIESORIGINALINTENSITYMAXIMUM"
                                        ctlCWGraph.SetSeriesOriginalIntensityMaximum(intSeriesOptionsSeriesIndex, StringToValueUtils.CDoubleSafe(strKeyValue, 0))
                                    Case "ANNOTATIONFONTNAME"
                                        ctlCWGraph.SetAnnotationFontName(intSeriesOptionsSeriesIndex, strKeyValue)
                                    Case "ANNOTATIONFONTSIZE"
                                        ctlCWGraph.SetAnnotationFontSize(intSeriesOptionsSeriesIndex, CShortSafe(strKeyValue))
                                    Case "ANNOTATIONFONTCOLOR"
                                        ctlCWGraph.SetAnnotationFontColor(intSeriesOptionsSeriesIndex, ConvertColorNameToColorObject(strKeyValue))
                                    Case Else
                                        blnMatched = False
                                End Select
                            End If

                            If Not blnMatched Then
                                Debug.WriteLine("Unknown KeyString in frmCWSpectrum->LoadDataFormDisk: " & strKeyString)
                            End If
                        Catch ex As Exception
                            ' Ignore the error
                            Debug.Assert(False, "Error parsing KeyString in frmCWSpectrum->LoadDataFromDisk")
                        End Try
                    Else
                        ' A line with an = was found, but eParsingDataMode is not equal to pfmOptions
                        ' Ignore it, but stop in the debugger
                        ' However, only stop if this function wasn't called by code from another file loading function
                        If Not blnInputFilePathPassedToSub Then
                            Debug.Assert(False, "")
                        End If
                    End If
                Else
                    ' Ignore all other lines
                End If
            Loop

            If blnShowProgressForm Then
                objProgress?.UpdateCurrentSubTask("Formatting graph")
            End If

            ' Copy data from dblXData() and dblYData() to the graph if not done yet
            If Not LoadDataFromDiskUpdateSeries(intSeriesIndex, dblXData, dblYData, intDataCount, blnShowMessages, blnUserWarnedReplaceExistingData, blnNormalizeData) Then
                ' User cancelled the update; stop parsing
                Exit Try
            End If

            If intMaxSeriesIndex > 0 And intMaxSeriesIndex < ctlCWGraph.GetSeriesCount() Then
                ctlCWGraph.SetSeriesCount(intMaxSeriesIndex)
            End If

            If blnUpdateAutoScaleOptions Then
                ctlCWGraph.SetAutoscaleVisibleY(blnAutoScaleVisibleY, blnFixMinimumYAtZero)
            End If

            If blnUpdateCursorPosition Then
                ctlCWGraph.SetCursorPosition(dblCursorPosX, dblCursorPosY)
            End If

            If blnLoadingDTAFile Then
                ctlCWGraph.SetSeriesPlotMode(mActiveSeriesNumber, CWGraphControl.pmPlotModeConstants.pmSticksToZero)
                ctlCWGraph.SetSeriesLegendCaption(mActiveSeriesNumber, PathUtils.CompactPathString(Path.GetFileName(strInputFilePath), 20) & ": " & strParentIonInfo)
            End If

            ctlCWGraph.ZoomOutFull()

        Catch ex As Exception
            If blnShowMessages Then
                MsgBox("Error saving data to disk:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Error")
            Else
                Debug.WriteLine("Error saving data to disk (frmCWSpectrum.LoadDataToDisk):" & ex.Message)
            End If
        Finally
            If Not srInFile Is Nothing Then
                srInFile.Close()
            End If
        End Try

        Try
            ShowHideSeriesNumberMenus()

            ' Auto-hiding of captions was disabled above; re-enable if blnAutoHideCaptions = True
            ctlCWGraph.SetAnnotationDensityAutoHideCaptions(blnAutoHideCaptions)

            If blnShowProgressForm Then
                objProgress?.HideForm()
                objProgress = Nothing
            End If

        Catch ex As Exception
            ' Ignore any errors in this section
        End Try

    End Sub

    Private Function LoadDataFromDiskUpdateSeries(ByRef intSeriesIndex As Short, ByRef dblXData() As Double, ByRef dblYData() As Double, ByRef intDataCount As Integer, ByRef blnShowMessages As Boolean, ByRef blnUserWarnedReplaceExistingData As Boolean, ByRef blnNormalizeData As Boolean) As Boolean
        ' Returns True if success, or False if cancelled
        ' However, returns True if intDataCount = 0 since that isn't an error

        Dim eResponse As MsgBoxResult
        Dim dblOriginalMaximumValue As Double

        If intDataCount <= 0 Then
            LoadDataFromDiskUpdateSeries = True
            Exit Function
        End If

        ' Need to copy existing data in dblXData() and dblYData() to the graph
        If ctlCWGraph.GetSeriesCount() < intSeriesIndex Then
            ctlCWGraph.SetSeriesCount(intSeriesIndex)
        Else
            If ctlCWGraph.GetDataCount(intSeriesIndex) > 0 And blnShowMessages And Not blnUserWarnedReplaceExistingData Then
                eResponse = MsgBox("Replace existing data?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3, "Replace Data")
                If eResponse <> MsgBoxResult.Yes Then
                    LoadDataFromDiskUpdateSeries = False
                    Exit Function
                End If
                blnUserWarnedReplaceExistingData = True
            End If
        End If

        FindMaximumAndNormalizeData(dblYData, 0, intDataCount - 1, mNormalizationConstant, blnNormalizeData, dblOriginalMaximumValue)

        ctlCWGraph.SetDataXvsY(intSeriesIndex, dblXData, dblYData, intDataCount, "", dblOriginalMaximumValue)
        ctlCWGraph.RemoveAnnotationsForSeries(intSeriesIndex)

        ' Set intDataCount to 0 to prevent it from getting updated again
        intDataCount = 0
        LoadDataFromDiskUpdateSeries = True

    End Function

    Public Function FindMaximumAndNormalizeData(ByRef dblArray() As Double, ByRef lngLowIndex As Integer, ByRef lngHighIndex As Integer, ByRef dblNormalizationConstant As Double, ByRef blnPerformNormalization As Boolean, ByRef dblOriginalMaximumValue As Double) As Boolean
        ' Normalizes dblArray() to range from 0 dblNormalizationConstant
        ' Treats negative data as if it were positive data when finding dblOriginalMaximumValue
        ' Returns True if the data was successfully normalized, or if dblOriginalMaximumValue = dblNormalizationConstant
        ' Returns False if an error, or if blnPerformNormalization = False

        Dim intIndex As Integer

        On Error GoTo FindMaximumAndNormalizeDataErrorHandler

        dblOriginalMaximumValue = Math.Abs(dblArray(lngLowIndex))
        For intIndex = lngLowIndex + 1 To lngHighIndex
            If Math.Abs(dblArray(intIndex)) > dblOriginalMaximumValue Then
                dblOriginalMaximumValue = Math.Abs(dblArray(intIndex))
            End If
        Next intIndex

        If dblNormalizationConstant = 0 Then dblNormalizationConstant = 100
        dblNormalizationConstant = Math.Abs(dblNormalizationConstant)

        If blnPerformNormalization And dblOriginalMaximumValue > 0 Then
            If dblOriginalMaximumValue <> dblNormalizationConstant Then
                For intIndex = lngLowIndex To lngHighIndex
                    dblArray(intIndex) = dblArray(intIndex) / dblOriginalMaximumValue * dblNormalizationConstant
                Next intIndex
            Else
                ' The data is already normalized
            End If
            FindMaximumAndNormalizeData = True
        Else
            FindMaximumAndNormalizeData = False
        End If

        Exit Function

FindMaximumAndNormalizeDataErrorHandler:
        Debug.Assert(False, "")
        Debug.WriteLine("Error occurred in FindMaximumAndNormalizeData: " & Err.Description)
        FindMaximumAndNormalizeData = False

    End Function

    Public Function ParseStringFindCrlfIndex(strWork As String, ByRef intDelimeterLength As Short) As Integer
        ' First looks for vbCrLf in strWork
        ' Returns index if found, setting intDelimeterLength to 2
        ' If not found, uses ParseStringFindNextDelimeter to search for just CR or just LF,
        '  returning location and setting intDelimeterLength to 1

        Dim lngCrLfLoc As Integer

        lngCrLfLoc = InStr(strWork, vbCrLf)
        If lngCrLfLoc = 0 Then
            ' CrLf not found; look for just Cr or just LF
            lngCrLfLoc = ParseStringFindNextDelimeter(strWork, vbCrLf, False)
            intDelimeterLength = 1
        Else
            intDelimeterLength = 2
        End If

        ParseStringFindCrlfIndex = lngCrLfLoc
    End Function

    Private Function ParseStringFindNextDelimeter(strWork As String, ByRef strFieldDelimeter As String, Optional ByRef boolMatchWholeDelimeter As Boolean = True, Optional ByRef boolCombineConsecutiveDelimeters As Boolean = False) As Integer
        ' Scans strWork, looking for next delimeter (token)
        ' strFieldDelimeter may be 1 or more characters long.  If multiple characters, use
        '   boolMatchWholeDelimeter = True to treat strFieldDelimeter as just one delimeter
        ' Use boolMatchWholeDelimeter = False to treat each of the characters in strFieldDelimeter as a delimeter (token)

        Dim intFieldDelimeterLength, intDelimeterIndex As Integer
        Dim lngMatchIndex, lngSmallestMatchIndex As Integer
        Dim blnDelimeterMatched As Boolean

        intFieldDelimeterLength = strFieldDelimeter.Length

        If intFieldDelimeterLength = 0 Then
            lngSmallestMatchIndex = 0
        Else
            If boolMatchWholeDelimeter Or intFieldDelimeterLength = 1 Then
                lngSmallestMatchIndex = InStr(strWork, strFieldDelimeter)
            Else
                ' Look for each of the characters in strFieldDelimeter, returning the smallest nonzero index found
                lngSmallestMatchIndex = 0
                For intDelimeterIndex = 1 To Len(strFieldDelimeter)
                    lngMatchIndex = InStr(strWork, Mid(strFieldDelimeter, intDelimeterIndex, 1))
                    If lngMatchIndex > 0 Then
                        If lngMatchIndex < lngSmallestMatchIndex Or lngSmallestMatchIndex = 0 Then
                            lngSmallestMatchIndex = lngMatchIndex
                        End If
                    End If
                Next intDelimeterIndex
            End If

            ' If boolCombineConsecutiveDelimeters is true, then examine adjacent text for more delimeters, returning location of final delimeter
            If boolCombineConsecutiveDelimeters Then
                lngMatchIndex = lngSmallestMatchIndex + 1
                Do While lngMatchIndex <= Len(strWork)
                    If boolMatchWholeDelimeter Or intFieldDelimeterLength = 1 Then
                        If Mid(strWork, lngMatchIndex, intFieldDelimeterLength) = strFieldDelimeter Then
                            lngMatchIndex = lngMatchIndex + intFieldDelimeterLength
                        Else
                            Exit Do
                        End If
                    Else
                        blnDelimeterMatched = False
                        For intDelimeterIndex = 1 To Len(strFieldDelimeter)
                            If Mid(strWork, lngMatchIndex, 1) = Mid(strFieldDelimeter, intDelimeterIndex, 1) Then
                                blnDelimeterMatched = True
                                Exit For
                            End If
                        Next intDelimeterIndex
                        If blnDelimeterMatched Then
                            lngMatchIndex = lngMatchIndex + 1
                        Else
                            Exit Do
                        End If
                    End If
                Loop
                lngSmallestMatchIndex = lngMatchIndex - 1
            End If

        End If

        ParseStringFindNextDelimeter = lngSmallestMatchIndex

    End Function

    Private Function ParseStringValuesDbl(strWork As String, intMaxValuesToReturn As Integer, chFieldDelimeters As Char()) As Double()

        Dim dblValues() As Double
        Dim strValues() As String

        Dim intIndex As Integer

        ReDim dblValues(-1)

        Try
            strValues = strWork.Split(chFieldDelimeters, intMaxValuesToReturn)

            If strValues.Length > 0 Then
                ReDim dblValues(strValues.Length - 1)
                For intIndex = 0 To strValues.Length - 1
                    If IsNumeric(strValues(intIndex)) Then
                        dblValues(intIndex) = CDbl(strValues(intIndex))
                    Else
                        dblValues(intIndex) = 0
                    End If
                Next
            End If
        Catch ex As Exception
            ' Ignore errors
        End Try

        Return dblValues

    End Function

    Public Sub PasteDataFromClipboard(Optional ByRef blnShowMessages As Boolean = True, Optional ByRef blnAllowCommaDelimeter As Boolean = True)

        Dim eResponse As MsgBoxResult
        Dim strDataList As String
        Dim intIndex As Integer
        Dim lngPointsLoaded As Integer
        Dim lngValuesToPopulate As Integer

        Dim dblOriginalMaximumValue As Double
        Dim blnNormalizationSuccess As Boolean

        Dim dblXVals() As Double
        Dim dblYVals() As Double
        Dim lngStartIndex, lngCrLfLoc As Integer
        Dim strDelimeter, strLineWork As String

        Dim strLeftChar, strDelimeterList As String
        Dim intDelimeterLength As Short
        Dim dblParsedVals() As Double ' 1-based array
        Dim intParseValCount As Integer

        Dim objProgress As frmProgress

        Dim ClipboardData As IDataObject = Clipboard.GetDataObject

        If ClipboardData.GetDataPresent(DataFormats.Text, True) Then
            strDataList = CStr(ClipboardData.GetData(DataFormats.Text, True))
        Else
            Exit Sub
        End If

        If Len(strDataList) = 0 Then Exit Sub

        If ctlCWGraph.GetDataCount(mActiveSeriesNumber) > 0 And blnShowMessages Then
            eResponse = MsgBox("Replace existing data?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3, "Replace Data")
            If eResponse <> MsgBoxResult.Yes Then Exit Sub
        End If

        ' Remove any existing data
        DeleteDataActiveSeries(False)

        ' Construct Delimeter List: Contains a space, Tab, and possibly comma
        strDelimeterList = " " & vbTab & vbCr & vbLf
        If blnAllowCommaDelimeter Then
            strDelimeterList = strDelimeterList & ","
        End If

        objProgress = New frmProgress

        objProgress.InitializeProgressForm("Pasting Data From Clipboard", 0, Len(strDataList))
        objProgress.UpdateCurrentSubTask("Determining number of data points")

        ' First Determine number of data points in strDataList
        ' This removes the need to ReDim Preserve while parsing the data

        ' First look for the first occurrence of a valid delimeter
        lngCrLfLoc = ParseStringFindCrlfIndex(strDataList, intDelimeterLength)

        If lngCrLfLoc = 0 And Len(strDataList) > 0 Then
            strDataList = strDataList & vbCrLf
            lngCrLfLoc = ParseStringFindCrlfIndex(strDataList, intDelimeterLength)
        End If

        If lngCrLfLoc > 0 Then
            ' Record the first character of the delimeter (if vbCrLf, then recording vbCr), otherwise, recording just vbCr or just vbLf)
            strDelimeter = Mid(strDataList, lngCrLfLoc, 1)

            ' Add the delimeter to the end of strDataList to account for the last line containing valid data but no CrLf
            If strDelimeter = vbCr Then
                strDataList = strDataList & vbCrLf
            Else
                strDataList = strDataList & strDelimeter
            End If

            ' Now determine the number of occurrences of the delimeter
            lngValuesToPopulate = 0
            For intIndex = 1 To Len(strDataList)
                If intIndex Mod 500 = 0 Then
                    objProgress?.UpdateProgressBar(intIndex)
                    If objProgress?.KeyPressAbortProcess Then Exit For
                End If

                If Mid(strDataList, intIndex, 1) = strDelimeter Then
                    lngValuesToPopulate = lngValuesToPopulate + 1
                End If
            Next intIndex

            If lngValuesToPopulate > 1 And Not objProgress?.KeyPressAbortProcess Then
                ' Update objProgress to use the correct progress bar size
                objProgress?.InitializeProgressForm("Pasting Data From Clipboard", 0, lngValuesToPopulate)
                objProgress?.UpdateCurrentSubTask("Parsing List")
            End If

            ' Initialize IonMatchList
            ReDim dblXVals(lngValuesToPopulate - 1)
            ReDim dblYVals(lngValuesToPopulate - 1)

            lngPointsLoaded = 0

            ' Actually parse the data
            ' I process the list using the Mid() function since this is the fastest method
            ' However, Mid() becomes slower when the index value reaches 1000 or more (roughly)
            '  so I discard already-parsed data from strDataList every 1000 characters (approx.)
            Do While Len(strDataList) > 0
                lngStartIndex = 1
                For intIndex = 1 To Len(strDataList)
                    If intIndex Mod 100 = 0 Then
                        objProgress?.UpdateProgressBar(lngPointsLoaded)
                        If objProgress?.KeyPressAbortProcess Then Exit For
                    End If

                    If Mid(strDataList, intIndex, 1) = strDelimeter Then
                        strLineWork = Mid(strDataList, lngStartIndex, intIndex - 1).Trim

                        If Len(strLineWork) > 0 Then
                            ' Only parse if the first letter is a number (may start with - or +)
                            strLeftChar = strLineWork.Chars(0)
                            If IsNumeric(strLeftChar) Or strLeftChar = "-" Or strLeftChar = "+" Then

                                dblParsedVals = ParseStringValuesDbl(strLineWork, 2, strDelimeterList.ToCharArray)
                                intParseValCount = dblParsedVals.Length
                                If intParseValCount >= 2 Then
                                    dblXVals(lngPointsLoaded) = dblParsedVals(0)
                                    dblYVals(lngPointsLoaded) = dblParsedVals(1)
                                    lngPointsLoaded = lngPointsLoaded + 1
                                    If lngPointsLoaded > lngValuesToPopulate Then
                                        ' This shouldn't happen
                                        Debug.Assert(False, "")
                                        Exit For
                                    End If
                                End If
                            End If
                        End If

                        lngStartIndex = intIndex + intDelimeterLength
                        intIndex = intIndex + intDelimeterLength - 1

                        If intIndex > 1000 Then
                            ' Reduce the size of strDataList since the Mid() function gets slower with longer strings
                            strDataList = Mid(strDataList, intIndex + 1)
                            intIndex = 1
                            Exit For
                        End If
                    End If
                Next intIndex
                If intIndex > Len(strDataList) Then Exit Do
            Loop

            If lngPointsLoaded > 0 Then
                blnNormalizationSuccess = FindMaximumAndNormalizeData(dblYVals, 0, lngPointsLoaded - 1, mNormalizationConstant, mNormalizeOnLoadOrPaste, dblOriginalMaximumValue)

                ctlCWGraph.SetDataXvsY(mActiveSeriesNumber, dblXVals, dblYVals, lngPointsLoaded, "", dblOriginalMaximumValue)

                ctlCWGraph.SetCursorPosition(dblXVals(0), 0)
            End If

        End If

        objProgress?.HideForm()
        objProgress = Nothing

        Exit Sub

PasteDataFromClipboardErrorHandler:
        If blnShowMessages Then
            MsgBox("Error occurred while pasting the data: " & vbCrLf & Err.Description, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Error")
        Else
            Debug.WriteLine("Error occurred in frmCWSpectrum.PasteDataFromClipboard(): " & Err.Description)
        End If
    End Sub

    Public Sub ResetGraphToDefaults()
        Dim eResponse As MsgBoxResult
        Dim blnClearAllData As Boolean

        eResponse = MsgBox("Are you sure you want to reset the graph to the default styles?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton1, "Reset Graph")
        If eResponse <> MsgBoxResult.Yes Then Exit Sub


        eResponse = MsgBox("Remove all existing data and annotations?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton2, "Remove Data")
        Select Case eResponse
            Case MsgBoxResult.Yes
                blnClearAllData = True
            Case MsgBoxResult.No
                blnClearAllData = False
            Case Else
                Exit Sub
        End Select

        ctlCWGraph.ResetOptionsToDefaults(blnClearAllData, blnClearAllData, 2, ctlCWGraph.GetSeriesPlotMode(mActiveSeriesNumber))
    End Sub

    Public Sub SaveDataToDisk(Optional ByRef strOutputFilePath As String = "", Optional ByRef blnOptionsOnly As Boolean = False, Optional ByRef strDelim As String = ",", Optional ByRef blnShowMessages As Boolean = True, Optional ByRef blnAppendOptionsToFile As Boolean = False)
        ' Saves data and graph options from disk
        ' If blnOptionsOnly = True, then only saves the graph options; will append the options to an existing file if blnAppendOptionsToFile = True
        ' Note that blnAppendOptionsToFile is ignored if blnOptionsOnly = False
        ' If strOutputFilePath is empty, then prompts the user for a path (unless blnShowMessages = False)
        ' Only shows the progress form if the total number of data points to save is >1000

        Const DATA_COUNT_THRESHOLD_TO_SHOW_PROGRESS_FORM As Short = 10000
        Dim intSeriesIndex As Short

        Dim dblXData() As Double = Nothing
        Dim dblYData() As Double = Nothing
        Dim intDataCount As Integer
        Dim intIndex As Integer
        Dim blnFirstAnnotationFound As Boolean

        Dim strCaption As String = String.Empty
        Dim intSeriesNumberForAnnotation As Short
        Dim dblXPos, dblYPos As Double
        Dim lngCaptionAngle As Integer
        Dim eAnnotationSnapMode As CWGraphControl.asmAnnotationSnapModeConstants
        Dim lngPointNumberToBind As Integer
        Dim blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY As Boolean
        Dim blnIncludeArrow, blnHideInDenseRegions As Boolean
        Dim strAnnotationOptionCodes As String
        Dim lngDataPointCountToSave As Integer
        Dim blnShowProgressForm As Boolean

        Dim objProgress As frmProgress = Nothing

        Try
            If ctlCWGraph.GetSeriesCount < 1 And blnShowMessages Then
                MsgBox("The graph does not contain any data.", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "Nothing to Copy")
                Exit Sub
            End If

            If Len(strOutputFilePath) = 0 And blnShowMessages Then
                strOutputFilePath = SelectFile("Enter file name to save graph data to", mLastPath, True, mLastFileName, "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*")

                If Len(strOutputFilePath) > 0 Then
                    If Not Path.HasExtension(strOutputFilePath) Then
                        strOutputFilePath = Path.ChangeExtension(strOutputFilePath, ".csv")
                    End If
                End If
            End If

            If strOutputFilePath.Length = 0 Then Exit Sub

            mLastPath = Path.GetDirectoryName(strOutputFilePath)
            mLastFileName = Path.GetFileName(strOutputFilePath)

            Dim appendToFile As Boolean
            If blnOptionsOnly And blnAppendOptionsToFile Then
                appendToFile = True
            Else
                appendToFile = False
            End If

            Using swOutFile = New StreamWriter(strOutputFilePath, appendToFile)

                If Not blnOptionsOnly Then
                    lngDataPointCountToSave = 0
                    For intSeriesIndex = 1 To ctlCWGraph.GetSeriesCount()
                        lngDataPointCountToSave = lngDataPointCountToSave + ctlCWGraph.GetDataCount(intSeriesIndex)
                    Next intSeriesIndex

                    If lngDataPointCountToSave > DATA_COUNT_THRESHOLD_TO_SHOW_PROGRESS_FORM Then
                        blnShowProgressForm = True
                    End If
                End If

                If blnShowProgressForm Then
                    objProgress = New frmProgress
                    objProgress.InitializeProgressForm("Saving data", 1, ctlCWGraph.GetSeriesCount(), False, True, True)
                    objProgress.ToggleAlwaysOnTop(True)
                    objProgress.MoveToBottomCenter()
                End If

                For intSeriesIndex = 1 To ctlCWGraph.GetSeriesCount()
                    If Not blnOptionsOnly Then
                        ' Write the data points for this series
                        If ctlCWGraph.GetDataXvsY(intSeriesIndex, dblXData, dblYData, intDataCount) Then
                            If blnShowProgressForm Then objProgress.InitializeSubtask("Series " & intSeriesIndex.ToString.Trim, 0, intDataCount)
                            swOutFile.WriteLine("[Data_Series" & intSeriesIndex.ToString.Trim & "]")
                            For intIndex = 0 To intDataCount - 1
                                swOutFile.WriteLine(dblXData(intIndex) & strDelim & dblYData(intIndex))
                                If blnShowProgressForm And intIndex Mod 500 = 0 Then
                                    objProgress?.UpdateSubtaskProgressBar(intIndex)
                                End If
                            Next intIndex
                        End If
                    End If

                    ' Write the options for this series
                    swOutFile.WriteLine("[PlotOptions_Series" & intSeriesIndex.ToString.Trim & "]")
                    swOutFile.WriteLine("SeriesPlotMode=" & ctlCWGraph.GetSeriesPlotMode(intSeriesIndex))
                    swOutFile.WriteLine("SeriesLineStyle=" & ctlCWGraph.GetSeriesLineStyle(intSeriesIndex))
                    swOutFile.WriteLine("SeriesLineWidth=" & ctlCWGraph.GetSeriesLineWidth(intSeriesIndex))
                    swOutFile.WriteLine("SeriesLineColor=" & ctlCWGraph.GetSeriesLineColor(intSeriesIndex).ToString)
                    swOutFile.WriteLine("SeriesLineToBaseColor=" & ctlCWGraph.GetSeriesLineToBaseColor(intSeriesIndex).ToString)
                    swOutFile.WriteLine("SeriesBarFillColor=" & ctlCWGraph.GetSeriesBarFillColor(intSeriesIndex).ToString)
                    swOutFile.WriteLine("SeriesPointStyle=" & ctlCWGraph.GetSeriesPointStyle(intSeriesIndex))
                    swOutFile.WriteLine("SeriesPointColor=" & ctlCWGraph.GetSeriesPointColor(intSeriesIndex).ToString)
                    swOutFile.WriteLine("AnnotationFontName=" & ctlCWGraph.GetAnnotationFontName(intSeriesIndex))
                    swOutFile.WriteLine("AnnotationFontSize=" & ctlCWGraph.GetAnnotationFontSize(intSeriesIndex))
                    swOutFile.WriteLine("AnnotationFontColor=" & ctlCWGraph.GetAnnotationFontColor(intSeriesIndex).ToString)

                    If Not blnOptionsOnly Then
                        ' Write the series caption and original maximum intensity
                        swOutFile.WriteLine("SeriesLegendCaption=" & ctlCWGraph.GetSeriesLegendCaption(intSeriesIndex))
                        swOutFile.WriteLine("SeriesOriginalIntensityMaximum=" & ctlCWGraph.GetSeriesOriginalIntensityMaximum(intSeriesIndex))

                        ' Write the annotations for this series
                        blnFirstAnnotationFound = False
                        For intIndex = 1 To ctlCWGraph.GetAnnotationCount
                            If ctlCWGraph.GetAnnotationByIndex(intIndex, dblXPos, dblYPos, strCaption, lngCaptionAngle, intSeriesNumberForAnnotation, eAnnotationSnapMode, lngPointNumberToBind, blnAnnotationShowsNearestPointX, blnAnnotationShowsNearestPointY, blnIncludeArrow, blnHideInDenseRegions) Then
                                If intSeriesNumberForAnnotation = intSeriesIndex Then
                                    If Not blnFirstAnnotationFound Then
                                        swOutFile.WriteLine("[Annotations_Series" & intSeriesIndex.ToString.Trim & "]")
                                        blnFirstAnnotationFound = True
                                    End If
                                    Select Case eAnnotationSnapMode
                                        Case CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToAnyPoint
                                            strAnnotationOptionCodes = "\FA" & lngPointNumberToBind.ToString.Trim
                                        Case CWGraphControl.asmAnnotationSnapModeConstants.asmFixedToSingleDataPoint
                                            strAnnotationOptionCodes = "\FS" & lngPointNumberToBind.ToString.Trim
                                        Case CWGraphControl.asmAnnotationSnapModeConstants.asmFloating
                                            strAnnotationOptionCodes = "\FL" & lngPointNumberToBind.ToString.Trim
                                        Case Else
                                            ' This shouldn't happen
                                            Debug.Assert(False, "")
                                            strAnnotationOptionCodes = ""
                                    End Select

                                    If blnAnnotationShowsNearestPointX Then strAnnotationOptionCodes = strAnnotationOptionCodes & "\X"
                                    If blnAnnotationShowsNearestPointY Then strAnnotationOptionCodes = strAnnotationOptionCodes & "\Y"
                                    If blnIncludeArrow Then strAnnotationOptionCodes = strAnnotationOptionCodes & "\A"
                                    If blnHideInDenseRegions Then strAnnotationOptionCodes = strAnnotationOptionCodes & "\H"

                                    swOutFile.WriteLine(dblXPos.ToString.Trim & strDelim & dblYPos.ToString.Trim & strDelim & lngCaptionAngle.ToString.Trim & strDelim & strAnnotationOptionCodes & strDelim & strCaption)
                                End If
                            End If
                        Next intIndex
                    End If
                    If blnShowProgressForm Then objProgress?.UpdateProgressBar(intSeriesIndex)
                Next intSeriesIndex

                ' Write the general plot options
                swOutFile.WriteLine("[GlobalPlotOptions]")
                swOutFile.WriteLine("Title=" & ctlCWGraph.GetLabelTitle())
                swOutFile.WriteLine("Subtitle=" & ctlCWGraph.GetLabelSubtitle())
                swOutFile.WriteLine("XAxis=" & ctlCWGraph.GetLabelXAxis())
                swOutFile.WriteLine("YAxis=" & ctlCWGraph.GetLabelYAxis())
                swOutFile.WriteLine("LabelFontName=" & ctlCWGraph.GetLabelFontName())
                swOutFile.WriteLine("LabelFontSize=" & ctlCWGraph.GetLabelFontName())
                swOutFile.WriteLine("LabelFontColor=" & ctlCWGraph.GetLabelFontColor().ToString)
                swOutFile.WriteLine("PlotBackgroundColor=" & ctlCWGraph.GetPlotBackgroundColor().ToString)
                swOutFile.WriteLine("NormalizeOnLoadOrPaste=" & GetNormalizeOnLoadOrPaste())
                swOutFile.WriteLine("NormalizationConstant=" & GetNormalizationConstant())

                swOutFile.WriteLine("GridLinesXColorMajor=" & ctlCWGraph.GetGridLinesXColor(True).ToString)
                swOutFile.WriteLine("GridLinesXColorMinor=" & ctlCWGraph.GetGridLinesXColor(False).ToString)
                swOutFile.WriteLine("GridLinesYColorMajor=" & ctlCWGraph.GetGridLinesYColor(True).ToString)
                swOutFile.WriteLine("GridLinesYColorMinor=" & ctlCWGraph.GetGridLinesYColor(False).ToString)

                swOutFile.WriteLine("GridLinesXVisibleMajor=" & ctlCWGraph.GetGridLinesXVisible(True))
                swOutFile.WriteLine("GridLinesXVisibleMinor=" & ctlCWGraph.GetGridLinesXVisible(False))
                swOutFile.WriteLine("GridLinesYVisibleMajor=" & ctlCWGraph.GetGridlinesYVisible(True))
                swOutFile.WriteLine("GridLinesYVisibleMinor=" & ctlCWGraph.GetGridlinesYVisible(False))

                swOutFile.WriteLine("AnnotationDensityAutoHideCaptions=" & ctlCWGraph.GetAnnotationDensityAutoHideCaptions())
                swOutFile.WriteLine("AnnotationDensityToleranceAutoAdjust=" & ctlCWGraph.GetAnnotationDensityToleranceAutoAdjust())
                swOutFile.WriteLine("AnnotationDensityToleranceX=" & ctlCWGraph.GetAnnotationDensityToleranceX())
                swOutFile.WriteLine("AnnotationDensityToleranceY=" & ctlCWGraph.GetAnnotationDensityToleranceY())

                swOutFile.WriteLine("AutoScaleVisibleY=" & ctlCWGraph.GetAutoscaleVisibleY())
                swOutFile.WriteLine("FixMinimumYAtZero=" & ctlCWGraph.GetFixMinimumYAtZero())
                swOutFile.WriteLine("AutoAdjustScalingToIncludeCaptions=" & ctlCWGraph.GetAutoAdjustScalingToIncludeCaptions())
                swOutFile.WriteLine("PrecisionX=" & ctlCWGraph.GetDisplayPrecisionX())
                swOutFile.WriteLine("PrecisionY=" & ctlCWGraph.GetDisplayPrecisionY())

                swOutFile.WriteLine("Cursor1Visible=" & ctlCWGraph.GetCursorVisibility(1))
                swOutFile.WriteLine("Cursor2Visible=" & ctlCWGraph.GetCursorVisibility(2))
                swOutFile.WriteLine("CursorSnapToData=" & ctlCWGraph.GetCursorSnapToDataPointModeEnabled())
                swOutFile.WriteLine("Cursor1Color=" & ctlCWGraph.GetCursorColor(1).ToString)
                swOutFile.WriteLine("Cursor2Color=" & ctlCWGraph.GetCursorColor(2).ToString)
                ctlCWGraph.GetCursorPosition(dblXPos, dblYPos, 1)
                swOutFile.WriteLine("CursorPositionX=" & dblXPos.ToString.Trim)
                swOutFile.WriteLine("CursorPositionY=" & dblYPos.ToString.Trim)

                swOutFile.WriteLine("AutoLabelPeaksDisplayXPosition=" & mAutoLabelPeaksOptions.DisplayXPos)
                swOutFile.WriteLine("AutoLabelPeaksDisplayYPosition=" & mAutoLabelPeaksOptions.DisplayYPos)
                swOutFile.WriteLine("AutoLabelPeaksIncludeArrow=" & mAutoLabelPeaksOptions.IncludeArrow)
                swOutFile.WriteLine("AutoLabelPeaksHideInDenseRegions=" & mAutoLabelPeaksOptions.HideInDenseRegions)
                swOutFile.WriteLine("AutoLabelPeaksCaptionAngle=" & mAutoLabelPeaksOptions.CaptionAngle)
                swOutFile.WriteLine("AutoLabelPeaksIntensityThresholdMinimum=" & mAutoLabelPeaksOptions.IntensityThresholdMinimum)
                swOutFile.WriteLine("AutoLabelPeaksMinimumIntensityPercentageOfMaximum=" & mAutoLabelPeaksOptions.MinimumIntensityPercentageOfMaximum)
                swOutFile.WriteLine("AutoLabelPeaksPeakWidthMinimumPoints=" & mAutoLabelPeaksOptions.PeakWidthMinimumPoints)
                swOutFile.WriteLine("AutoLabelPeaksLabelCountMaximum=" & mAutoLabelPeaksOptions.PeakLabelCountMaximum)

            End Using

        Catch ex As Exception
            If blnShowMessages Then
                MsgBox("Error saving data to disk:" & vbCrLf & Err.Description, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Error")
            Else
                Debug.WriteLine("Error saving data to disk (frmCWSpectrum.SaveDataToDisk):" & Err.Description)
            End If

        End Try

SaveDataToDiskExitSub:

        If blnShowProgressForm Then
            objProgress?.HideForm()
            objProgress = Nothing
        End If

    End Sub

    Public Sub SaveToDiskAsPicture(Optional ByRef strOutputFilePath As String = "", Optional ByRef blnShowMessages As Boolean = True)

        Dim objGraphPicture As Image
        Dim intFilterIndex As Short
        Dim eImageFormat As ImageFormat

        Try
            objGraphPicture = ctlCWGraph.GetControlImage()

            If Len(strOutputFilePath) = 0 And blnShowMessages Then
                intFilterIndex = 1
                strOutputFilePath = SelectFile("Save Spectrum", "", True, "spectrum.wmf", "WMF Files (*.wmf)|*.wmf|Gif Files (*.gif)|*.gif|Png files (*.png)|*.png|All Files (*.*)|*.*", intFilterIndex)
            End If

            If Len(strOutputFilePath) > 0 Then
                eImageFormat = ImageFormat.Wmf
                Select Case intFilterIndex
                    Case 1
                        ' WMF
                        eImageFormat = ImageFormat.Wmf
                    Case 2
                        ' GIF
                        eImageFormat = ImageFormat.Gif
                    Case 3
                        ' PNG
                        eImageFormat = ImageFormat.Png
                    Case Else
                        ' Default to WMF
                End Select

                ' Make sure strOutputFilePath ends in the correct extension
                Select Case eImageFormat.ToString
                    Case ImageFormat.Wmf.ToString
                        strOutputFilePath = Path.ChangeExtension(strOutputFilePath, ".wmf")
                    Case ImageFormat.Gif.ToString
                        strOutputFilePath = Path.ChangeExtension(strOutputFilePath, ".gif")
                    Case ImageFormat.Png.ToString
                        strOutputFilePath = Path.ChangeExtension(strOutputFilePath, ".png")
                    Case Else
                        ' Don't check anything
                        Debug.Assert(False, "This code shouldn't be reached (SaveToDiskAsPicture)")
                End Select

                objGraphPicture.Save(strOutputFilePath, eImageFormat)
            End If

        Catch ex As Exception
            If blnShowMessages Then
                MsgBox("Error while trying to save:" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Error")
            Else
                Debug.WriteLine("Error occurred in frmCWSpectrum.SaveToDiskAsPicture:" & ex.Message)
            End If
        End Try

    End Sub

    Public Sub RetrieveAutoLabelPeaksOptionsFromModule()
        AutoLabelOptionsRetrieve(mAutoLabelPeaksOptions)
    End Sub

    Private Function SelectFile(strDialogCaption As String, Optional ByRef strStartPath As String = "", Optional ByRef blnSaveFile As Boolean = False, Optional ByRef strDefaultFileName As String = "", Optional ByVal strFileFilterCodes As String = "All Files (*.*)|*.*|Text Files (*.txt)|*.txt", Optional ByRef intFilterIndexDefault As Short = 1, Optional ByRef blnFileMustExistOnOpen As Boolean = True) As String

        Dim dlgSelectFile As FileDialog

        If blnSaveFile Then
            dlgSelectFile = New SaveFileDialog
        Else
            dlgSelectFile = New OpenFileDialog
        End If

        With dlgSelectFile
            .Filter = strFileFilterCodes
            .FilterIndex = intFilterIndexDefault
            If Len(strStartPath) > 0 Then
                Try
                    .InitialDirectory = strStartPath
                Catch
                    .InitialDirectory = Application.StartupPath
                End Try
            Else
                .InitialDirectory = Application.StartupPath
            End If

            .Title = strDialogCaption
            .FileName = strDefaultFileName
            If Not blnSaveFile Then
                .CheckFileExists = blnFileMustExistOnOpen
            End If

            .ShowDialog()
            If .FileName.Length > 0 Then
                Return .FileName
            Else
                Return String.Empty
            End If
        End With

    End Function

    Public Sub SetCurrentSeriesNumber(ByRef intSeriesNumber As Short)

        On Error GoTo SetCurrentSeriesNumberErrorHandler

        If intSeriesNumber < 1 Or intSeriesNumber > ctlCWGraph.GetSeriesCount() Then
            intSeriesNumber = 1
        End If

        mActiveSeriesNumber = intSeriesNumber

        ' Make sure the correct series number menus are loaded and visible,
        '  and the mActiveSeriesNumber'th one is checked
        ShowHideSeriesNumberMenus()

        Exit Sub

SetCurrentSeriesNumberErrorHandler:
        Debug.Assert(False, "")

    End Sub

    Public Sub SetNormalizeOnLoadOrPaste(ByRef blnEnable As Boolean)
        mNormalizeOnLoadOrPaste = blnEnable
    End Sub

    Public Sub SetNormalizationConstant(ByRef dblNewNormalizationConstant As Double)
        mNormalizationConstant = dblNewNormalizationConstant
    End Sub

    Public Sub SetWindowPos(ByRef intTop As Integer, ByRef intLeft As Integer, ByRef intHeight As Integer, ByRef intWidth As Integer)
        With mSpectrumWindowPos
            .PosTop = intTop
            .PosLeft = intLeft
            .Height = intHeight
            .Width = intWidth
        End With

        mResizing = True
        With Me
            .Top = mSpectrumWindowPos.PosTop
            .Height = mSpectrumWindowPos.Height
            .Left = mSpectrumWindowPos.PosLeft
            .Width = mSpectrumWindowPos.Width
        End With
        mResizing = False

        VerifyValidWindowPos(Me, 460, 200)

    End Sub

    Public Sub SetWindowCaption(strCaption As String)
        Me.Text = strCaption
    End Sub

    Private Sub ShowAboutBox()
        Dim strMessage As String

        strMessage = String.Empty

        strMessage &= "Program written by Matthew Monroe for the Department of Energy (PNNL, Richland, WA) in 2003" & ControlChars.NewLine
        strMessage &= "Copyright 2005, Battelle Memorial Institute.  All Rights Reserved." & ControlChars.NewLine
        strMessage &= "Graph component uses the 2D Graph Control from Measurement Studio 6.0, copyright National Instruments" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "This is version " & objSpectrum.DllVersion & " (" & objSpectrum.AppDate & ")" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "E-mail: matthew.monroe@pnl.gov or matt@alchemistmatt.com" & ControlChars.NewLine
        strMessage &= "Website: http://ncrr.pnl.gov/ or http://www.sysbio.org/resources/staff/" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "Licensed under the Apache License, Version 2.0; you may not use this file except in compliance with the License.  "
        strMessage &= "You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0" & ControlChars.NewLine & ControlChars.NewLine

        strMessage &= "Notice: This computer software was prepared by Battelle Memorial Institute, "
        strMessage &= "hereinafter the Contractor, under Contract No. DE-AC05-76RL0 1830 with the "
        strMessage &= "Department of Energy (DOE).  All rights in the computer software are reserved "
        strMessage &= "by DOE on behalf of the United States Government and the Contractor as "
        strMessage &= "provided in the Contract.  NEITHER THE GOVERNMENT NOR THE CONTRACTOR MAKES ANY "
        strMessage &= "WARRANTY, EXPRESS OR IMPLIED, OR ASSUMES ANY LIABILITY FOR THE USE OF THIS "
        strMessage &= "SOFTWARE.  This notice including this sentence must appear on any copies of "
        strMessage &= "this computer software." & ControlChars.NewLine

        MessageBox.Show(strMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Public Sub ShowAutoLabelPeaksDialog(Optional ByRef blnShowModal As Boolean = True)
        Dim blnSuccess As Boolean

        On Error GoTo ShowAutoLabelPeaksDialogErrorHandler

        If mAutoLabelPeaksForm Is Nothing Then
            mAutoLabelPeaksForm = New frmAutoLabelPeaks
        End If

        With mAutoLabelPeaksForm
            AutoLabelOptionsStore(mAutoLabelPeaksOptions)
            blnSuccess = .InitializeForm(ctlCWGraph, mActiveSeriesNumber)

            If blnSuccess Then
                If blnShowModal Then
                    .ShowDialog()
                Else
                    .Show()
                End If

                ' The following bit of code is needed because VB6 refuses to allow a form to return a udt in a function,
                '  even though the udt is defined as public in a public object module
                .StoreAutoLabelSettingsInModule()
                AutoLabelOptionsRetrieve(mAutoLabelPeaksOptions)

            End If
        End With
        If blnShowModal Then
            mAutoLabelPeaksForm.Close()
            mAutoLabelPeaksForm = Nothing
        End If

        Exit Sub

ShowAutoLabelPeaksDialogErrorHandler:
        MsgBox("Error displaying the Auto Label Peaks Dialog: " & vbCrLf & Err.Description & vbCrLf & "(Sub ShowAutoLabelPeaksDialog, #" & Err.Number.ToString.Trim & ")")

    End Sub

    Private Sub ShowHideSeriesNumberMenus()
        Dim intSeriesCount As Short
        Dim intMenuNumber As Short ' Note: the mnuEditCurrentSeriesSelected menus are 1-based

        intSeriesCount = ctlCWGraph.GetSeriesCount()

        ' Must have at least one mnuEditCurrentSeriesSelected() menu visible & checked
        If intSeriesCount < 1 Then intSeriesCount = 1
        If mActiveSeriesNumber < 1 Then mActiveSeriesNumber = 1

        Do While mSeriesNumberMenuLoadedCount < intSeriesCount
            mSeriesNumberMenuLoadedCount = mSeriesNumberMenuLoadedCount + 1S
            mnuEditCurrentSeriesSelected.Load(mSeriesNumberMenuLoadedCount)
            With mnuEditCurrentSeriesSelected(mSeriesNumberMenuLoadedCount)
                .Text = mSeriesNumberMenuLoadedCount.ToString.Trim
                If mSeriesNumberMenuLoadedCount < 10 Then
                    .Text = .Text & vbTab & "Ctrl+" & mSeriesNumberMenuLoadedCount.ToString.Trim
                End If
            End With
        Loop

        For intMenuNumber = 1 To intSeriesCount
            mnuEditCurrentSeriesSelected(intMenuNumber).Visible = True
            If intMenuNumber = mActiveSeriesNumber Then
                mnuEditCurrentSeriesSelected(intMenuNumber).Checked = True
            Else
                mnuEditCurrentSeriesSelected(intMenuNumber).Checked = False
            End If
        Next intMenuNumber

        For intMenuNumber = intSeriesCount + 1S To mSeriesNumberMenuLoadedCount
            mnuEditCurrentSeriesSelected(intMenuNumber).Visible = False
        Next intMenuNumber

    End Sub

    Public Sub ShowZoomRangeDialog()
        ' Show the user a dialog to set the X range and Y range

        Dim dblXStart, dblXEnd As Double
        Dim dblYStart, dblYEnd As Double

        Dim objSetZoomRangeForm As New frmSetZoomRange

        With objSetZoomRangeForm

            ctlCWGraph.GetRangeX(dblXStart, dblXEnd)
            ctlCWGraph.GetRangeY(dblYStart, dblYEnd)

            .SetValues(dblXStart, dblXEnd, dblYStart, dblYEnd)
            .ShowDialog()

            If .DialogResult = DialogResult.OK Then
                ' Grab the values from frmSetZoomRange
                .ReturnValues(dblXStart, dblXEnd, dblYStart, dblYEnd)

                ctlCWGraph.SetRangeX(dblXStart, dblXEnd)
                ctlCWGraph.SetRangeY(dblYStart, dblYEnd)
            End If
        End With
        objSetZoomRangeForm.Close()

    End Sub

    Private Function StringToNumber(strWork As String, Optional ByRef intNumLength As Integer = 0, Optional ByRef intErrorCode As Short = 0, Optional ByRef blnAllowMinusSign As Boolean = False, Optional ByRef blnAllowPlusSign As Boolean = False, Optional ByRef blnAllowESymbol As Boolean = False, Optional ByRef blnMultipleDecimalPointIsError As Boolean = True, Optional ByVal strDecimalPointSymbol As String = ".") As Double
        ' Looks for a number at the start of strWork and returns it if found
        ' strWork can contain non-numeric characters after the number; only the number will be returned
        ' intNumLength returns the length of the number, including the decimal point and any negative sign or E symbol
        ' When blnAllowESymbol = True, then looks for exponential numbers, like 3.23E+04 or 2.48E-084
        ' If an error is found or no number is present, then 0 is returned and intNumLength is set to 0, and intErrorCode is assigned the error code:
        '   0 = No Error
        '  -1 = No number
        '  -3 = No number at all or (more likely) no number after decimal point
        '  -4 = More than one decimal point

        ' Examples:
        '  23Text           Returns 23 and intNumLength = 2
        '  23.432Text       Returns 23.432 and intNumLength = 6
        '  .3Text           Returns 0.3 and intNumLength = 2
        '  0.3Text          Returns 0.3 and intNumLength = 3
        '  3Text            Returns 3 and intNumLength = 1
        '  3.Text           Returns 3 and intNumLength = 2
        '  Text             Returns 0 and intNumLength = 0 and intErrorCode = -3
        '  .Text            Returns 0 and intNumLength = 0 and intErrorCode = -3
        '  4.23.Text        Returns 0 and intNumLength = 0 and intErrorCode = -4  (must have blnMultipleDecimalPointIsError = True)
        '  -43Text          Returns -43 and intNumLength = 2            (must have blnAllowMinusSign = True)
        '  32E+48Text       Returns 32E+48 and intNumLength = 6         (must have blnAllowESymbol = True)

        Dim strTestChar As String
        Dim strFoundNum As String = String.Empty
        Dim intIndex, intDecPtCount As Integer
        Dim blnNumberFound, blnESymbolFound As Boolean

        If strDecimalPointSymbol = "" Then
            strDecimalPointSymbol = DetermineDecimalPoint()
        End If

        ' Set intNumLength to -1 for now
        ' If it doesn't get set to 0 (due to an error), it will get set to the
        '   length of the matched number before exiting the sub
        intNumLength = -1

        If strWork Is Nothing Then strWork = String.Empty

        blnNumberFound = False
        If strWork.Length > 0 Then
            strFoundNum = strWork.Substring(0)
            If IsNumeric(strFoundNum) Then
                blnNumberFound = True
            ElseIf strFoundNum = strDecimalPointSymbol Then
                blnNumberFound = True
                intDecPtCount += 1
            ElseIf (strFoundNum = "-" And blnAllowMinusSign) Then
                blnNumberFound = True
            ElseIf (strFoundNum = "+" And blnAllowPlusSign) Then
                blnNumberFound = True
            End If
        End If

        If blnNumberFound Then
            ' Start of string is a number or a decimal point, or (if allowed) a negative or plus sign
            ' Continue looking

            intIndex = 2
            Do While intIndex <= Len(strWork)
                strTestChar = Mid(strWork, intIndex, 1)
                If IsNumeric(strTestChar) Then
                    strFoundNum &= strTestChar
                ElseIf strTestChar = strDecimalPointSymbol Then
                    intDecPtCount = intDecPtCount + 1
                    If intDecPtCount = 1 Then
                        strFoundNum = strFoundNum & strTestChar
                    Else
                        Exit Do
                    End If
                ElseIf (strTestChar.ToUpper = "E" And blnAllowESymbol) Then
                    ' E symbol found; only add to strFoundNum if followed by a + and a number,
                    '                                                        a - and a number, or another number
                    strTestChar = Mid(strWork, intIndex + 1, 1)
                    If IsNumeric(strTestChar) Then
                        strFoundNum = strFoundNum & "E" & strTestChar
                        intIndex = intIndex + 2
                        blnESymbolFound = True
                    ElseIf strTestChar = "+" Or strTestChar = "-" Then
                        If IsNumeric(Mid(strWork, intIndex + 2, 1)) Then
                            strFoundNum = strFoundNum & "E" & strTestChar & Mid(strWork, intIndex + 2, 1)
                            intIndex = intIndex + 3
                            blnESymbolFound = True
                        End If
                    End If

                    If blnESymbolFound Then
                        ' Continue looking for numbers after the E symbol
                        ' However, only allow pure numbers; not + or - or .

                        Do While intIndex <= Len(strWork)
                            strTestChar = Mid(strWork, intIndex, 1)
                            If IsNumeric(strTestChar) Then
                                strFoundNum = strFoundNum & strTestChar
                            ElseIf strTestChar = strDecimalPointSymbol Then
                                If blnMultipleDecimalPointIsError Then
                                    ' Set this to 2 to force the multiple decimal point error to appear
                                    intDecPtCount = 2
                                End If
                                Exit Do
                            Else
                                Exit Do
                            End If
                            intIndex = intIndex + 1
                        Loop
                    End If

                    Exit Do
                Else
                    Exit Do
                End If
                intIndex = intIndex + 1
            Loop

            If intDecPtCount > 1 And blnMultipleDecimalPointIsError Then
                ' Too many decimal points
                intNumLength = 0 ' No number found
                intErrorCode = -4
                Return 0
            ElseIf Len(strFoundNum) = 0 Or strFoundNum = strDecimalPointSymbol Then
                ' No number at all or (more likely) no number after decimal point
                intNumLength = 0 ' No number found
                intErrorCode = -3
                Return 0
            Else
                ' All is fine
                intNumLength = strFoundNum.Length
                intErrorCode = 0
                Return StringToValueUtils.CDoubleSafe(strFoundNum, 0)
            End If
        Else
            intNumLength = 0 ' No number found
            intErrorCode = -1
            Return 0
        End If

    End Function

    Private Sub frmCWSpectrum_Deactivate(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Deactivate
        With mSpectrumWindowPos
            .PosTop = Me.Top
            .Height = Me.Height
            .PosLeft = Me.Left
            .Width = Me.Width
        End With
    End Sub

    ''' <summary>
    ''' Handles shortcuts where the user has pressed the Control key
    ''' Note that menu item "Add Sample Data" will appear in the Edit menu when you press the control key
    ''' </summary>
    ''' <param name="eventSender"></param>
    ''' <param name="eventArgs"></param>
    ''' <remarks></remarks>
    Private Sub frmCWSpectrum_KeyDown(eventSender As Object, eventArgs As KeyEventArgs) Handles MyBase.KeyDown
        Dim intSeriesNumber As Short

        If eventArgs.Modifiers = Keys.Control Then
            If eventArgs.KeyCode >= Keys.D1 And eventArgs.KeyCode <= Keys.D9 Then
                ' User pressed Ctrl+1 ... Ctrl+9
                intSeriesNumber = CShort(eventArgs.KeyCode - 48)
                If intSeriesNumber <= mSeriesNumberMenuLoadedCount Then
                    If mnuEditCurrentSeriesSelected(intSeriesNumber).Visible Then
                        SetCurrentSeriesNumber(intSeriesNumber)
                    End If
                End If
            ElseIf eventArgs.KeyCode = Keys.A Then
                ' Ctrl+A
                ' Zoom out
                ctlCWGraph.ZoomOutFull()
            End If
            mnuEditAddSampleData.Visible = True
        End If
    End Sub

    Private Sub frmCWSpectrum_KeyUp(eventSender As Object, eventArgs As KeyEventArgs) Handles MyBase.KeyUp
        If eventArgs.Modifiers = Keys.Control Then
            mnuEditAddSampleData.Visible = False
        End If
    End Sub

    Private Sub frmCWSpectrum_Load(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Load

        mSeriesNumberMenuLoadedCount = 1
        mActiveSeriesNumber = 1

        With mAutoLabelPeaksOptions
            .DataMode = dmDataModeConstants.dmDiscrete
            .DisplayXPos = True
            .DisplayXPos = False
            .CaptionAngle = 90
            .IncludeArrow = False
            .HideInDenseRegions = True
            .IntensityThresholdMinimum = 10
            .PeakLabelCountMaximum = 100
            .PeakWidthMinimumPoints = 5
        End With

        mNormalizeOnLoadOrPaste = True
        mNormalizationConstant = 100

        ctlCWGraph.Top = 4
        ctlCWGraph.Left = 4
        ctlCWGraph.Width = Me.ClientSize.Width - 8
        ctlCWGraph.Height = Me.ClientSize.Height - 8

        VerifyValidWindowPos(Me, 650, 500)

        DeleteDataForAllSeries(False)

        mnuEditCurrentSeriesSelected(1).Text = "1" & vbTab & "Ctrl+1"
        ShowHideSeriesNumberMenus()

    End Sub

    Private Sub frmCWSpectrum_Closing(eventSender As Object, eventArgs As CancelEventArgs) Handles MyBase.Closing
        If Not mAutoLabelPeaksForm Is Nothing Then
            mAutoLabelPeaksForm.Close()
        End If
    End Sub

    Public Sub mnuAboutSoftware_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuAboutSoftware.Click
        ShowAboutBox()
    End Sub

    Public Sub mnuEdit_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEdit.Click
        ShowHideSeriesNumberMenus()
    End Sub

    Public Sub mnuEditAddSampleData_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditAddSampleData.Click
        AddSampleData()
    End Sub

    Public Sub mnuEditAutoLabelPoints_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditAutoLabelPoints.Click
        ShowAutoLabelPeaksDialog()
    End Sub

    Public Sub mnuEditCopyAsPicture_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditCopyAsPicture.Click
        CopyToClipboardAsPicture()
    End Sub

    Public Sub mnuEditCopyCurrentData_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditCopyCurrentData.Click
        CopyDataPointsToClipboardOrToString(mActiveSeriesNumber)
    End Sub

    Public Sub mnuEditCurrentSeriesSelected_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditCurrentSeriesSelected.Click
        Dim Index As Short = mnuEditCurrentSeriesSelected.GetIndex(CType(eventSender, MenuItem))
        SetCurrentSeriesNumber(Index)
    End Sub

    Public Sub mnuEditDeleteData_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditDeleteData.Click
        DeleteDataActiveSeries(True)
    End Sub

    Public Sub mnuEditPasteData_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditPasteData.Click
        PasteDataFromClipboard()
    End Sub

    Public Sub mnuEditPlotStyles_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditPlotStyles.Click
        EditPlotStyles()
    End Sub

    Public Sub mnuEditRemoveAllData_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditRemoveAllData.Click
        DeleteDataForAllSeries(True)
    End Sub

    Public Sub mnuEditRemoveAnnotationsCurrentSeries_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditRemoveAnnotationsCurrentSeries.Click
        Dim eResponse As MsgBoxResult

        eResponse = MsgBox("Do you really want to remove the annotations for series " & mActiveSeriesNumber.ToString.Trim & "?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3, "Remove Annotations")
        If eResponse = MsgBoxResult.Yes Then
            ctlCWGraph.RemoveAnnotationsForSeries(mActiveSeriesNumber)
        End If
    End Sub

    Public Sub mnuEditSetSeriesCount_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuEditSetSeriesCount.Click
        Dim strNewSeriesCount As String
        Dim intNewSeriesCount As Short

        strNewSeriesCount = InputBox("Please enter the new series count (1 to 32):", "Set Series Count", ctlCWGraph.GetSeriesCount().ToString.Trim)

        intNewSeriesCount = CShortSafe(strNewSeriesCount)
        If intNewSeriesCount >= 1 And intNewSeriesCount <= 32 Then
            ctlCWGraph.SetSeriesCount(intNewSeriesCount)
        End If

    End Sub

    Public Sub mnuFileClose_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuFileClose.Click
        ' Raising this event will prompt the SpectrumInitiator to raise a SpectrumFormRequestCloseEvent
        RaiseEvent SpectrumFormRequestClose()
    End Sub

    Public Sub mnuFileOpen_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuFileOpen.Click
        LoadDataFromDisk()
    End Sub

    Public Sub mnuFileSave_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuFileSave.Click
        SaveDataToDisk()
    End Sub

    Public Sub mnuFileSaveToDiskAsPicture_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuFileSaveToDiskAsPicture.Click
        SaveToDiskAsPicture()
    End Sub

    Public Sub mnuRemoveAllAnnotations_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuRemoveAllAnnotations.Click
        Dim eResponse As MsgBoxResult

        eResponse = MsgBox("Do you really want to remove all of the annotations (for all series)?", MsgBoxStyle.Question Or MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3, "Remove Annotations")
        If eResponse = MsgBoxResult.Yes Then
            ctlCWGraph.RemoveAllAnnotations()
        End If
    End Sub

    Public Sub mnuResetGraphToDefaults_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuResetGraphToDefaults.Click
        ResetGraphToDefaults()
    End Sub

    Public Sub mnuSetZoomRange_Click(eventSender As Object, eventArgs As EventArgs) Handles mnuSetZoomRange.Click
        ShowZoomRangeDialog()
    End Sub

    ' The following is used to capture when the user clicks the X in the upper right of the window
    Protected Overrides Sub WndProc(ByRef m As Message)

        Const SC_CLOSE As Long = &HF060
        If m.WParam.ToString = SC_CLOSE.ToString Then 'clicked ControlBox
            m.Result = New IntPtr(0) 'cancel close before raising Closing event
            RaiseEvent SpectrumFormRequestClose()
        Else
            MyBase.WndProc(m)
        End If
    End Sub
End Class