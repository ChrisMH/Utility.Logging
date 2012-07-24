[string[]] $buildFiles = '.\src\Utility.Logging\Utility.Logging.csproj', 
                         '.\src\Utility.Logging\Utility.LoggingSL5.csproj',
                         '.\src\Utility.Logging.NLog\Utility.Logging.NLog.csproj',
                         '.\src\Utility.Logging.NLog\Utility.Logging.NLogSL5.csproj',
                         '.\src\Utility.Logging.NLog.Autofac\Utility.Logging.NLog.Autofac.csproj',
                         '.\src\Utility.Logging.NLog.Autofac\Utility.Logging.NLog.AutofacSL5.csproj',
                         '.\src\Utility.Logging.NLog.Autofac\Utility.Logging.NLog.Ninject.csproj'
[string[]] $nuspecFiles = '.\nuspec\Utility.Logging.nuspec',
                          '.\nuspec\Utility.Logging.NLog.nuspec',
                          '.\nuspec\Utility.Logging.NLog.Autofac.nuspec',
                          '.\nuspec\Utility.Logging.NLog.Ninject.nuspec'
$versionFile = '.\src\SharedAssemblyInfo.cs'

$buildConfiguration = 'Release'
$outputPath = "$home\Dropbox\Packages"

Import-Module BuildUtilities

$version = Get-Version (Resolve-Path $versionFile)
  
New-Path $outputPath


#foreach($buildFile in $buildFiles)
#{
#  Invoke-Build (Resolve-Path $buildFile) $buildConfiguration
#}

foreach($nuspecFile in $nuspecFiles)
{
  New-Package (Resolve-Path $nuspecFile) $version $outputPath
}

Remove-Module BuildUtilities

