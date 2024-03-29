Option Strict On
Option Explicit On

' -------------------------------------------------------------------------------
' Written by Matthew Monroe for the Department of Energy (PNNL, Richland, WA)
' Program started October 17, 2003
' Copyright 2005, Battelle Memorial Institute.  All Rights Reserved.

' E-mail: matthew.monroe@pnl.gov or proteomics@pnnl.gov
' Website: https://github.com/PNNL-Comp-Mass-Spec/ or https://panomics.pnnl.gov/ or https://www.pnnl.gov/integrative-omics
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

Module modCWSpectrum

    Public Structure udtWindowPosType
        Dim PosTop As Integer           ' Position, in pixels
        Dim PosLeft As Integer
        Dim Height As Integer
        Dim Width As Integer
    End Structure

    Public Enum dmDataModeConstants
        dmDiscrete = 0
        dmContinuous = 1
    End Enum

    Public Structure udtAutoLabelPeaksOptionsInternalType
        Public DataMode As dmDataModeConstants
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

    ' Constants for Centering Windows
    Public Enum wpcWindowPosConstants As Integer
        ExactCenter = 0
        UpperThird = 1
        LowerThird = 2
        MiddleLeft = 3
        MiddleRight = 4
        TopCenter = 5
        BottomCenter = 6
        BottomRight = 7
        BottomLeft = 8
        TopRight = 9
        TopLeft = 10
    End Enum

    Private mAutoLabelOptions As udtAutoLabelPeaksOptionsInternalType

    Public objSpectrum As New Spectrum

    Public Sub AutoLabelOptionsRetrieve(ByRef udtAutoLabelOptionsToReturn As udtAutoLabelPeaksOptionsInternalType)

        With udtAutoLabelOptionsToReturn
            .DataMode = mAutoLabelOptions.DataMode
            .DisplayXPos = mAutoLabelOptions.DisplayXPos
            .DisplayYPos = mAutoLabelOptions.DisplayYPos
            .IncludeArrow = mAutoLabelOptions.IncludeArrow
            .HideInDenseRegions = mAutoLabelOptions.HideInDenseRegions
            .CaptionAngle = mAutoLabelOptions.CaptionAngle
            .IntensityThresholdMinimum = mAutoLabelOptions.IntensityThresholdMinimum
            .MinimumIntensityPercentageOfMaximum = mAutoLabelOptions.MinimumIntensityPercentageOfMaximum
            .PeakWidthMinimumPoints = mAutoLabelOptions.PeakWidthMinimumPoints
            .PeakLabelCountMaximum = mAutoLabelOptions.PeakLabelCountMaximum
        End With


    End Sub

    Public Sub AutoLabelOptionsStore(ByRef udtNewOptions As udtAutoLabelPeaksOptionsInternalType)
        With mAutoLabelOptions
            .DataMode = udtNewOptions.DataMode
            .DisplayXPos = udtNewOptions.DisplayXPos
            .DisplayYPos = udtNewOptions.DisplayYPos
            .IncludeArrow = udtNewOptions.IncludeArrow
            .HideInDenseRegions = udtNewOptions.HideInDenseRegions
            .CaptionAngle = udtNewOptions.CaptionAngle
            .IntensityThresholdMinimum = udtNewOptions.IntensityThresholdMinimum
            .MinimumIntensityPercentageOfMaximum = udtNewOptions.MinimumIntensityPercentageOfMaximum
            .PeakWidthMinimumPoints = udtNewOptions.PeakWidthMinimumPoints
            .PeakLabelCountMaximum = udtNewOptions.PeakLabelCountMaximum
        End With
    End Sub

    Public Function CBoolSafe(strValue As String) As Boolean
        Return PRISM.DataUtils.StringToValueUtils.CBoolSafe(strValue, False)
    End Function

    Public Function CShortSafe(strValue As String) As Short
        Return PRISM.DataUtils.StringToValueUtils.CShortSafe(strValue, 0)
    End Function

    Public Function FormatNumberAsString(dblNumber As Double, Optional ByVal intMaxLength As Integer = 10, Optional ByVal intMaxDigitsOfPrecision As Integer = 8, Optional ByVal blnUseScientificWhenTooLong As Boolean = True) As String

        Dim strNumberAsText As String
        Dim strZeroes As String

        If intMaxDigitsOfPrecision <= 1 Then
            strZeroes = "0"
        Else
            strZeroes = "0." & New String("0"c, intMaxDigitsOfPrecision - 1)
        End If

        dblNumber = CDbl(dblNumber.ToString(strZeroes & "E+0"))

        strNumberAsText = dblNumber.ToString

        If strNumberAsText.Length > intMaxLength Then
            If blnUseScientificWhenTooLong Then
                If intMaxLength < 5 Then intMaxLength = 5

                strZeroes = New String("0"c, intMaxLength - 5)
                strNumberAsText = dblNumber.ToString("0." & strZeroes & "E+0")
            Else
                If intMaxLength < 3 Then intMaxLength = 3
                strNumberAsText = System.Math.Round(dblNumber, intMaxLength - 2).ToString
            End If
        End If

        FormatNumberAsString = strNumberAsText

    End Function

    Private Function GetDesktopSize(ByRef lngHeight As Integer, ByRef lngWidth As Integer) As Integer
        ' Determines the height and width of the desktop, in pixels
        ' Returns the width

        'Dim rectTemp As System.Drawing.Rectangle = Screen.GetWorkingArea(rectTemp)

        ' Determine the size of the desktop, in pixels
        lngHeight = Screen.PrimaryScreen.Bounds.Height
        lngWidth = Screen.PrimaryScreen.Bounds.Width

        Return lngWidth
    End Function

    Public Sub SizeAndCenterWindow(ByRef frmThisForm As Form, Optional ByVal eCenterMode As wpcWindowPosConstants = wpcWindowPosConstants.ExactCenter, Optional ByVal lngWindowWidth As Integer = -1, Optional ByVal lngWindowHeight As Integer = -1, Optional ByVal blnSizeAndCenterOnlyOncePerProgramSession As Boolean = True, Optional ByVal intDualMonitorToUse As Short = -1)
        ' Sub revision 1.3

        ' This sub routine properly recognizes dual monitors, centering the form to just one monitor

        ' lngWindowWidth and lngWindowHeight are in pixels
        ' intDualMonitorToUse can be 0 or 1, signifying the first or second monitor
        ' blnSizeAndCenterOnlyOncePerProgramSession is useful when the SizeAndCenterWindow sub is called from the Form_Activate sub of a form
        '  Note: It is suggested that this be set to false if called from Form_Load in case the user closes the form (thus unloading it)

        Const MAX_RESIZE_FORMS_TO_REMEMBER As Short = 100

        Dim lngWindowAreaWidth, lngWindowAreaHeight As Integer
        Dim dblAspectRatio As Double
        Dim lngWorkingAreaWidth, lngWorkingAreaHeight As Integer
        Dim blnDualMonitor, blnHorizontalDual As Boolean
        Dim lngWindowTopToSet, lngWindowLeftToSet As Integer
        Static strFormsCentered(MAX_RESIZE_FORMS_TO_REMEMBER) As String ' 0-based array
        Static intFormsCenteredCount As Short
        Dim blnSubCalledPreviously As Boolean
        Dim intIndex As Short

        ' See if the form has already called this sub
        ' If not, add to strFormsCentered()
        blnSubCalledPreviously = False
        For intIndex = 0 To intFormsCenteredCount - 1S
            If strFormsCentered(intIndex) = frmThisForm.Name Then
                blnSubCalledPreviously = True
                Exit For
            End If
        Next intIndex

        If Not blnSubCalledPreviously Then
            ' First time sub called this sub
            ' Add to strFormsCentered()
            If intFormsCenteredCount < MAX_RESIZE_FORMS_TO_REMEMBER Then
                intFormsCenteredCount += 1S
                strFormsCentered(intFormsCenteredCount - 1) = frmThisForm.Name
            Else
                System.Diagnostics.Debug.Assert(False, "Too many unique forms have called 'SizeAndCenterWindow' in this application (Limit is " & MAX_RESIZE_FORMS_TO_REMEMBER.ToString & ")")
            End If
        End If

        ' If form called previously and blnSizeAndCenterOnlyOncePerProgramSession is true, then exit sub
        If blnSizeAndCenterOnlyOncePerProgramSession And blnSubCalledPreviously Then
            Exit Sub
        End If

        ' Resize Window
        With frmThisForm
            .WindowState = FormWindowState.Normal
            If lngWindowWidth > 0 Then .Width = lngWindowWidth
            If lngWindowHeight > 0 Then .Height = lngWindowHeight
        End With

        ' Assume the first form loaded is the main form
        ' May need to be customized if ported to other applications

        ' Find the desktop area (width and height)
        GetDesktopSize(lngWindowAreaHeight, lngWindowAreaWidth)

        ' Check the aspect ratio of WindowAreaWidth / WindowAreaHeight
        If lngWindowAreaHeight > 0 Then
            dblAspectRatio = lngWindowAreaWidth / lngWindowAreaHeight
        Else
            dblAspectRatio = 1.333
        End If

        ' Typical desktop areas and aspect ratios
        ' Normal Desktops have aspect ratios of 1.33 or 1.5
        ' HDTV desktops have an aspect ratio of 1.6 or 1.7
        ' Horizontal Dual Monitors have an aspect ratio of 2.66 or 2.5
        ' Vertical Dual Monitors have an aspect ratio of 0.67 or 0.62

        ' Determine if using dual monitors
        If dblAspectRatio < 1 Or dblAspectRatio > 2 Then
            blnDualMonitor = True
            If dblAspectRatio > 2 Then
                ' Aspect ratio greater than 2 - using horizontal dual monitors
                blnHorizontalDual = True
                lngWorkingAreaWidth = CInt(Screen.PrimaryScreen.Bounds.Width / 2)
                lngWorkingAreaHeight = Screen.PrimaryScreen.Bounds.Height

                If frmThisForm.Left > lngWorkingAreaWidth Then
                    ' Form window on second monitor
                    ' Set intDualMonitorToUse if not explicitly set
                    If intDualMonitorToUse < 0 Then
                        intDualMonitorToUse = 1
                    End If
                End If
            Else
                ' Aspect ratio must be less than 1 - using vertical dual monitors
                blnHorizontalDual = False
                lngWorkingAreaWidth = Screen.PrimaryScreen.Bounds.Width
                lngWorkingAreaHeight = CInt(Screen.PrimaryScreen.Bounds.Height / 2)

                If frmThisForm.Top > lngWorkingAreaHeight Then
                    ' Main app window on second monitor
                    ' Set intDualMonitorToUse if not explicitly set
                    If intDualMonitorToUse < 0 Then
                        intDualMonitorToUse = 1
                    End If
                End If
            End If
        Else
            ' Aspect ratio between 1 and 2
            ' Using a single monitor
            blnDualMonitor = False
            lngWorkingAreaWidth = Screen.PrimaryScreen.Bounds.Width
            lngWorkingAreaHeight = Screen.PrimaryScreen.Bounds.Height
        End If

        With frmThisForm
            ' Position window
            Select Case eCenterMode
                Case wpcWindowPosConstants.UpperThird
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) \ 3
                Case wpcWindowPosConstants.LowerThird
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) * 2 \ 3
                Case wpcWindowPosConstants.MiddleLeft
                    lngWindowLeftToSet = 0
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) \ 2
                Case wpcWindowPosConstants.MiddleRight
                    lngWindowLeftToSet = lngWorkingAreaWidth - .Width
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) \ 2
                Case wpcWindowPosConstants.TopCenter
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = 0
                Case wpcWindowPosConstants.BottomCenter
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = lngWorkingAreaHeight - .Height - 33
                Case wpcWindowPosConstants.BottomRight
                    lngWindowLeftToSet = lngWorkingAreaWidth - .Width
                    lngWindowTopToSet = lngWorkingAreaHeight - .Height - 33
                Case wpcWindowPosConstants.BottomLeft
                    lngWindowLeftToSet = 0
                    lngWindowTopToSet = lngWorkingAreaHeight - .Height - 33
                Case wpcWindowPosConstants.TopRight
                    lngWindowLeftToSet = lngWorkingAreaWidth - .Width
                    lngWindowTopToSet = 0
                Case wpcWindowPosConstants.TopLeft
                    lngWindowLeftToSet = 0
                    lngWindowTopToSet = 0
                Case Else ' Includes cWindowExactCenter = 0
                    lngWindowLeftToSet = (lngWorkingAreaWidth - .Width) \ 2
                    lngWindowTopToSet = (lngWorkingAreaHeight - .Height) \ 2
            End Select

            ' Move to second monitor if explicitly stated or if the main window is already on the second monitor
            If blnDualMonitor And intDualMonitorToUse > 0 Then
                ' Place window on second monitor
                If blnHorizontalDual Then
                    ' Horizontal dual - Shift to the right
                    lngWindowLeftToSet = lngWindowLeftToSet + lngWorkingAreaWidth
                Else
                    ' Vertical dual - Shift down
                    lngWindowTopToSet = lngWindowTopToSet + lngWorkingAreaHeight
                End If
            End If

            ' Actually position the window
            .SetBounds(lngWindowLeftToSet, lngWindowTopToSet, 0, 0, BoundsSpecified.Location)
        End With

    End Sub

    Public Sub TextBoxGotFocusHandler(ByRef txtThisTextBox As TextBox, Optional ByRef blnSelectAll As Boolean = True)
        ' Selects the text in the given TextBox if blnSelectAll = true

        If blnSelectAll Then
            txtThisTextBox.SelectionStart = 0
            txtThisTextBox.SelectionLength = Len(txtThisTextBox.Text)
        End If
    End Sub

    Public Sub VerifyValidWindowPos(ByRef frmThisForm As Form, Optional ByVal lngMinWidth As Integer = 33, Optional ByVal lngMinHeight As Integer = 33, Optional ByVal MinVisibleFormArea As Integer = 33)
        ' Make sure the window isn't too small and is visible on the desktop

        Dim lngScreenWidth, lngScreenHeight As Integer          ' In Pixels

        Dim returnValue = GetDesktopSize(lngScreenHeight, lngScreenWidth)

        If lngScreenHeight < Screen.PrimaryScreen.Bounds.Height Then
            lngScreenHeight = Screen.PrimaryScreen.Bounds.Height
        End If

        If lngScreenWidth < Screen.PrimaryScreen.Bounds.Width Then
            lngScreenWidth = Screen.PrimaryScreen.Bounds.Width
        End If

        Try
            With frmThisForm
                If .WindowState = FormWindowState.Minimized Then
                    .WindowState = FormWindowState.Normal
                End If

                If .Width < lngMinWidth Then .Width = lngMinWidth
                If .Height < lngMinHeight Then .Height = lngMinHeight

                If .Left > lngScreenWidth - MinVisibleFormArea Or .Top > lngScreenHeight - MinVisibleFormArea Or .Left < 0 Or .Top < 0 Then
                    SizeAndCenterWindow(frmThisForm, wpcWindowPosConstants.UpperThird, .Width, .Height, False, -1)
                End If
            End With
        Catch ex As Exception
            ' An error occured
            ' The form is probably minimized; we'll ignore it
            System.Diagnostics.Debug.WriteLine("Error occured in VerifyValidWindowPos: " & Err.Description)
        End Try

        Exit Sub

    End Sub

End Module