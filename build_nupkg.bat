nuget pack src\Utility.Logging\Utility.Logging.csproj -Build -Properties Configuration=Release
nuget pack src\Utility.Logging.NLog\Utility.Logging.NLog.csproj -Build -Properties Configuration=Release
nuget pack src\Utility.Logging.NLog.Ninject\Utility.Logging.NLog.Ninject.csproj -Build -Properties Configuration=Release
move /Y *.nupkg D:/NugetPackages
