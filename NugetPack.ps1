$srcRoot = '.\src'                     # relative to script directory
$versionFile = 'SharedAssemblyInfo.cs' # relative to $srcRoot
$outputPath = "$home\Dropbox\Packages"

Import-Module NugetUtilities

New-Path $outputPath

$version = Get-Version (Join-Path $srcRoot $versionFile)

Pack-Project Utility.Logging $srcRoot $version $outputPath
Pack-Project Utility.Logging.NLog $srcRoot $version $outputPath
Pack-ContentProject Utility.Logging.NLog.Autofac $srcRoot $version $outputPath
Pack-ContentProject Utility.Logging.NLog.Ninject $srcRoot $version $outputPath
