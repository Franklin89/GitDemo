// Tools
#tool "nuget:https://www.nuget.org/api/v2?package=GitVersion.CommandLine&version=3.6.2"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

string version = null;
string nugetVersion = null;
string preReleaseTag = null;
string semVersion = null;

Task("Version")
    .Does(() =>
{
    GitVersion(new GitVersionSettings
    {
        UpdateAssemblyInfo = AppVeyor.IsRunningOnAppVeyor,
        LogFilePath = "console",
        OutputType = GitVersionOutput.BuildServer
    });

    GitVersion assertedVersions = GitVersion(new GitVersionSettings
    {
        OutputType = GitVersionOutput.Json
    });

    version = assertedVersions.MajorMinorPatch;
    nugetVersion = assertedVersions.NuGetVersion;
    preReleaseTag = assertedVersions.PreReleaseTag;
    semVersion = assertedVersions.LegacySemVerPadded;

    Information("MajorMinorPatch:" + assertedVersions.MajorMinorPatch);
    Information("NuGetVersion:" + assertedVersions.NuGetVersion);
    Information("preReleaseTag:" + assertedVersions.preReleaseTag);
    Information("semVersion:" + assertedVersions.semVersion);
});

Task("Default").IsDependentOn("Version");

RunTarget(target);