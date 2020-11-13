
$console = $host.ui.rawui

$oldColor = $console.foregroundcolor
$console.foregroundcolor = "green"
"Build MvvmNext"
$console.foregroundcolor = $oldColor
dotnet build MvvmNext.sln --verbosity quiet

$console.foregroundcolor = "green"
"MVVMNext for Net50preview4"
$console.foregroundcolor = $oldColor
dotnet pack MvvmNext.sln --output ./packages/Net50 --verbosity quiet

#dotnet nuget delete MVVMNext 1.0.0 --source github
dotnet nuget push "packages/Net50/MVVMNext.1.0.0.nupkg" --source "github"
