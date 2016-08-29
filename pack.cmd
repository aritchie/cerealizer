@echo off
del *.nupkg
nuget pack Cerealizer.nuspec
rem nuget pack Cerealizer.BleExtensions.nuspec
pause