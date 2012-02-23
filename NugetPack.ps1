# relative to script directory
$srcRoot = '.\src'                       

# relative to $srcRoot
[string[]] $buildFiles = 'Utility.Logging\Utility.Logging.csproj', 
                         'Utility.Logging\Utility.LoggingSL5.csproj',
                         'Utility.Logging.NLog\Utility.Logging.NLog.csproj',
                         'Utility.Logging.NLog\Utility.Logging.NLogSL5.csproj',
                         'Utility.Logging.NLog.Autofac\Utility.Logging.NLog.Autofac.csproj',
                         'Utility.Logging.NLog.Autofac\Utility.Logging.NLog.AutofacSL5.csproj'
[string[]] $nuspecFiles = 'Utility.Logging\Utility.Logging.nuspec',
                          'Utility.Logging.NLog\Utility.Logging.NLog.nuspec',
                          'Utility.Logging.NLog.Autofac\Utility.Logging.NLog.Autofac.nuspec'
$versionFile = 'SharedAssemblyInfo.cs'

$buildConfiguration = 'Release'
$outputPath = "$home\Dropbox\Packages"

Import-Module BuildUtilities

$versionFile = Resolve-Path(Join-Path $srcRoot $versionFile)

$version = Get-Version $versionFile
  
New-Path $outputPath


#foreach($buildFile in $buildFiles)
#{
#  Invoke-Build (Resolve-Path(Join-Path $srcRoot $buildFile)) $buildConfiguration
#}

foreach($nuspecFile in $nuspecFiles)
{
  New-Package (Resolve-Path(Join-Path $srcRoot $nuspecFile)) $version $outputPath
}

Remove-Module BuildUtilities

