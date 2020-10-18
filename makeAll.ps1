
$console = $host.ui.rawui

$oldColor = $console.foregroundcolor
$console.foregroundcolor = "green"
"Build MvvmNext[Net48]"
$console.foregroundcolor = $oldColor
dotnet build MvvmNext[Net48].sln --verbosity quiet

$console.foregroundcolor = "green"
"Build MvvmNext[NetCore31]"
$console.foregroundcolor = $oldColor
dotnet build MvvmNext[NetCore31].sln --verbosity quiet

$console.foregroundcolor = "green"
"Build MvvmNext[Net50preview4]"
$console.foregroundcolor = $oldColor
dotnet build MvvmNext[Net50rc1].sln --verbosity quiet

$console.foregroundcolor = "green"
"Create package"
"MVVMNext for Net48"
$console.foregroundcolor = $oldColor
dotnet pack MvvmNext[Net48].sln --output ./packages/Net48 --verbosity quiet

$console.foregroundcolor = "green"
"MVVMNext for NetCore31"
$console.foregroundcolor = $oldColor
dotnet pack MvvmNext[NetCore31].sln --output ./packages/NetCore31 --verbosity quiet

$console.foregroundcolor = "green"
"MVVMNext for Net50preview4"
$console.foregroundcolor = $oldColor
dotnet pack MvvmNext[Net50rc1].sln --output ./packages/Net50 --verbosity quiet
