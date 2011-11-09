$srcPath = ".\src\"
$buildPath = ".\build\"
$versionFile = $srcPath + "SharedAssemblyInfo.cs"
$nuget = ".\tools\nuget\nuget.exe"

if (test-path $buildPath) { remove-item -Recurse -Force $buildPath }
mkdir $buildPath | out-null

get-content $versionFile | where-object { $_ -match '^\[\s*assembly:\s*AssemblyVersion\s*\(\s*\"(?<version>[\d\.]*)\"\s*\)\s*\]' } | out-null

#Utility.Logging
$packageName = "Utility.Logging"
$packFile = $srcPath + $packageName + "\" + $packageName + ".csproj";
&$nuget pack $packFile -Version $matches.version -Build -Properties Configuration=Release -OutputDirectory $buildPath

#Utility.Logging.NLog
$packageName = "Utility.Logging.NLog"
$packFile = $srcPath + $packageName + "\" + $packageName + ".csproj";
&$nuget pack $packFile -Version $matches.version -Build -Properties Configuration=Release -OutputDirectory $buildPath

#Utility.Logging.NLog.Ninject
#Remove binary directories so that they don't get included in the nupkg.  This is a content-only package.
$packageName = "Utility.Logging.NLog.Ninject"
$packFile = $srcPath + $packageName + "\" + $packageName + ".nuspec";

$binPath = $srcPath + $packageName +"\bin"
if (test-path $binPath) { remove-item -Recurse -Force $binPath }
$objPath = $srcPath + $packageName +"\obj"
if (test-path $objPath) { remove-item -Recurse -Force $objPath }

&$nuget pack $packFile -Version $matches.version -OutputDirectory $buildPath
