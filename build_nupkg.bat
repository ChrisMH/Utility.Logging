nuget pack Utility.Logging\Utility.Logging.csproj -Build -Properties Configuration=Release
nuget pack Utility.Logging.NLog\Utility.Logging.NLog.csproj -Build -Properties Configuration=Release
move /Y *.nupkg D:/NugetPackages
