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

function Pack-Project($packageName, $srcRoot, $version, $outputPath, $nugetCmd)
{
  $projectRoot = Join-Path $srcRoot $packageName -Resolve
  $packFile = Join-Path $projectRoot "$packageName.csproj" -Resolve
  &$nugetCmd pack $packFile -Version $version -Build -Properties Configuration=Release -OutputDirectory $outputPath
}

function Pack-ContentProject($packageName, $srcRoot, $version, $outputPath, $nugetCmd)
{
  $projectRoot = Join-Path $srcRoot $packageName -Resolve
  $packFile = Join-Path $projectRoot "$packageName.nuspec" -Resolve

  #Remove binary directories so that they don't get included in the nupkg.  This is a content-only package.
  $binPath = "$projectRoot\bin"
  if (Test-Path $binPath) { Remove-Item $binPath -Recurse -Force }
  $objPath = "$projectRoot\obj"
  if (Test-Path $objPath) { Remove-Item $objPat -Recurse -Force }

  &$nugetCmd pack $packFile -Version $version -OutputDirectory $outputPath
}

$outputPath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath($outputPath)
if((Test-Path $outputPath) -eq $False) { New-Item -Path $outputPath -ItemType directory }

$version = Get-Version $srcRoot $versionFile

Pack-Project "Utility.Logging" $srcRoot $version $outputPath $nugetCmd
Pack-project "Utility.Logging.NLog" $srcRoot $version $outputPath $nugetCmd
Pack-ContentProject "Utility.Logging.NLog.Autofac" $srcRoot $version $outputPath $nugetCmd
Pack-ContentProject "Utility.Logging.NLog.Ninject" $srcRoot $version $outputPath $nugetCmd
