$srcRoot = '.\src'                     # relative to script directory
$versionFile = 'SharedAssemblyInfo.cs' # relative to $srcRoot
$outputPath = '.\build'                # relative to script directory
$nugetCmd = '.\tools\nuget\nuget.exe'  # relative to script directory

function Get-Version($srcRoot, $versionFile)
{
  $versionFile = Join-Path $srcRoot $versionFile -Resolve
  Get-Content $versionFile | Where-Object { $_ -match '^\[\s*assembly:\s*AssemblyVersion\s*\(\s*\"(?<version>[\d\.]*)\"\s*\)\s*\]' } | out-null
  return $matches.version
}

function Push-Project($packageName, $srcRoot, $version, $outputPath, $nugetCmd)
{
  "`nPushing Package : $packageName"
  $pushFile = Join-Path $outputPath "$packageName.$version.nupkg" -Resolve
  &$nugetCmd delete $packageName $version -NoPrompt
  &$nugetCmd push $pushFile
}


$version = Get-Version $srcRoot $versionFile

Push-Project "Utility.Logging" $srcRoot $version $outputPath $nugetCmd
Push-Project "Utility.Logging.NLog" $srcRoot $version $outputPath $nugetCmd
Push-Project "Utility.Logging.NLog.Autofac" $srcRoot $version $outputPath $nugetCmd
Push-Project "Utility.Logging.NLog.Ninject" $srcRoot $version $outputPath $nugetCmd
