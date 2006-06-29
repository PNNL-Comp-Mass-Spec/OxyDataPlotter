Option Strict Off
Option Explicit On 
'
' This class was found at http://www.dotnet247.com/247reference/msgs/23/118514.aspx
'
' Notes from the author:
' I'm currently writing a KB article to cover this. The problem is that the framework
' uses a new clipboard format for its metafiles - one that other apps, and even the OS,
' don't know about and therefore cannot translate into EMF.
'
' The workaround is to interoperate with Win32 clipboard APIs, per the following code:
'
' - John
' Microsoft Developer Support

' Example call
'   Dim mf As New Metafile("filename.emf")
'   ClipboardMetafileHelper.PutEnhMetafileOnClipboard(me.Handle,mf)

Imports System.Runtime.InteropServices

Public Class ClipboardMetaFileHelper

    <DllImport("user32.dll", EntryPoint:="OpenClipboard", _
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Friend Shared Function OpenClipboard(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="EmptyClipboard", _
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Friend Shared Function EmptyClipboard() As Boolean
    End Function

    <DllImport("user32.dll", EntryPoint:="SetClipboardData", _
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Friend Shared Function SetClipboardData(ByVal uFormat As Integer, ByVal hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", EntryPoint:="CloseClipboard", _
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Friend Shared Function CloseClipboard() As Boolean
    End Function

    <DllImport("gdi32.dll", EntryPoint:="CopyEnhMetaFileA", _
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Friend Shared Function CopyEnhMetaFile(ByVal hemfSrc As IntPtr, ByVal hNULL As IntPtr) As IntPtr
    End Function

    <DllImport("gdi32.dll", EntryPoint:="DeleteEnhMetaFile", _
    SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Friend Shared Function DeleteEnhMetaFile(ByVal hemfSrc As IntPtr) As Boolean
    End Function

    Public Shared Function PutEnhMetafileOnClipboard(ByVal hWnd As IntPtr, ByVal objImage As System.Drawing.Image) As Boolean
        Return PutMetafileOnClipboard(hWnd, objImage)
    End Function

    Public Shared Function PutEnhMetafileOnClipboard(ByVal hWnd As IntPtr, ByVal objMetafile As System.Drawing.imaging.Metafile) As Boolean
        Return PutMetafileOnClipboard(hWnd, objMetafile)
    End Function

    ' Metafile mf is set to an invalid state inside this function
    Private Shared Function PutMetafileOnClipboard(ByVal hWnd As IntPtr, ByVal mf As System.Drawing.Imaging.Metafile) As Boolean
        Dim bResult As New Boolean
        bResult = False

        Dim hEMF, hEMF2 As IntPtr
        hEMF = mf.GetHenhmetafile() ' invalidates mf

        If Not hEMF.Equals(New IntPtr(0)) Then
            hEMF2 = CopyEnhMetaFile(hEMF, New IntPtr(0))
            If Not hEMF2.Equals(New IntPtr(0)) Then
                If OpenClipboard(hWnd) Then
                    If EmptyClipboard() Then
                        Dim hRes As IntPtr
                        hRes = SetClipboardData(14, hEMF2) ' 14 == CF_ENHMETAFILE
                        bResult = hRes.Equals(hEMF2)
                        CloseClipboard()
                    End If
                End If
            End If
            DeleteEnhMetaFile(hEMF)
        End If
        Return bResult
    End Function

End Class
