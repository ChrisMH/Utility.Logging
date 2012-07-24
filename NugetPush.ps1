$srcRoot = '.\src'                     # relative to script directory
$versionFile = 'SharedAssemblyInfo.cs' # relative to $srcRoot
$outputPath = "$home\Dropbox\Packages"

Import-Module NugetUtilities

$version = Get-Version (Join-Path $srcRoot $versionFile)

Push-Project Utility.Logging $srcRoot $version $outputPath
Push-Project Utility.Logging.NLog $srcRoot $version $outputPath
Push-Project Utility.Logging.NLog.Autofac $srcRoot $version $outputPath
Push-Project Utility.Logging.NLog.Ninject $srcRoot $version $outputPath
