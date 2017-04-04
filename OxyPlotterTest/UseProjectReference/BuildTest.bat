@echo off
if exist bin (rmdir /s /q bin)
if exist obj (rmdir /s /q obj)

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /t:restore;build OxyPlotterTest.sln
rem "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /t:restore;build OxyPlotterTest.sln /v:detailed
