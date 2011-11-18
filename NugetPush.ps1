$srcRoot = '.\src'                     # relative to script directory
$versionFile = 'SharedAssemblyInfo.cs' # relative to $srcRoot
$outputPath = "$home\Dropbox\Packages"
$scriptRoot = "$home\Dropbox\Scripts"

$version = . "$scriptRoot\Get-Version.ps1" (Join-Path $srcRoot $versionFile -Resolve)

. "$scriptRoot\Push-Project.ps1" Utility.Logging $srcRoot $version $outputPath
. "$scriptRoot\Push-Project.ps1" Utility.Logging.NLog $srcRoot $version $outputPath
. "$scriptRoot\Push-Project.ps1" Utility.Logging.NLog.Autofac $srcRoot $version $outputPath
. "$scriptRoot\Push-Project.ps1" Utility.Logging.NLog.Ninject $srcRoot $version $outputPath
