@echo off
del *.nupkg
nuget pack Cerealizer.nuspec
nuget pack Cerealizer.BleExtensions.nuspec
pause