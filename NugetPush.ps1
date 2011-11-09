$srcPath = ".\src\"
$buildPath = ".\build\"
$versionFile = $srcPath + "SharedAssemblyInfo.cs"
$nuget = ".\tools\nuget\nuget.exe"

get-content $versionFile | where-object { $_ -match '^\[\s*assembly:\s*AssemblyVersion\s*\(\s*\"(?<version>[\d\.]*)\"\s*\)\s*\]' } | out-null

#Utility.Logging
$packageName = "Utility.Logging"
$pushFile = $buildPath + $packageName + "." + $matches.version + ".nupkg"
&$nuget delete $packageName $matches.version -NoPrompt
&$nuget push $pushFile

#Utility.Logging.NLog
$packageName = "Utility.Logging.NLog"
$pushFile = $buildPath + $packageName + "." + $matches.version + ".nupkg"
&$nuget delete $packageName $matches.version -NoPrompt
&$nuget push $pushFile

#Utility.Logging.NLog.Ninject
$packageName = "Utility.Logging.NLog.Ninject"
$pushFile = $buildPath + $packageName + "." + $matches.version + ".nupkg"
&$nuget delete $packageName $matches.version -NoPrompt
&$nuget push $pushFile
