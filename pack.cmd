@echo off
del *.nupkg
rem nuget pack Cerealizer.nuspec
nuget pack Cerealizer.BleExtensions.nuspec
pause