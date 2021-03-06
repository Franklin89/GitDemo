// Tools
#tool "nuget:https://www.nuget.org/api/v2?package=GitVersion.CommandLine&prerelease"

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

string version = "";
string nugetVersion = "";
string preReleaseTag = "";
string semVersion = "";

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

    Information("MajorMinorPatch: " + assertedVersions.MajorMinorPatch);
    Information("NuGetVersion: " + assertedVersions.NuGetVersion);
    Information("PreReleaseTag: " + assertedVersions.PreReleaseTag);
    Information("LegacySemVerPadded: " + assertedVersions.LegacySemVerPadded);
});

Task("Default").IsDependentOn("Version");

RunTarget(target);
