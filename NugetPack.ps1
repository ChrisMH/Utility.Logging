$srcRoot = '.\src'                     # relative to script directory
$versionFile = 'SharedAssemblyInfo.cs' # relative to $srcRoot
$outputPath = '.\build'                # relative to script directory
$scriptRoot = "$home\Dropbox\Scripts"

. "$scriptRoot\New-Path.ps1" $outputPath

$version = . "$scriptRoot\Get-Version.ps1" (Join-Path $srcRoot $versionFile -Resolve)

. "$scriptRoot\Pack-Project.ps1" Utility.Logging $srcRoot $version $outputPath
. "$scriptRoot\Pack-Project.ps1" Utility.Logging.NLog $srcRoot $version $outputPath
. "$scriptRoot\Pack-ContentProject.ps1" Utility.Logging.NLog.Autofac $srcRoot $version $outputPath
. "$scriptRoot\Pack-ContentProject.ps1" Utility.Logging.NLog.Ninject $srcRoot $version $outputPath

