#tool nunit.consolerunner
#tool gitlink

var target = Argument("target", Argument("t", "package"));

Setup(x =>
{
    DeleteFiles("./*.nupkg");
    DeleteFiles("./output/*.*");

	if (!DirectoryExists("./output"))
		CreateDirectory("./output");
});

Task("build")
	.Does(() =>
{
	NuGetRestore("./src/Cerealizer.sln");
	DotNetBuild("./src/Cerealizer.sln", x => x
        .SetConfiguration("Release")
        .SetVerbosity(Verbosity.Minimal)
        .WithTarget("build")
        .WithProperty("TreatWarningsAsErrors", "false")
    );
});

Task("package")
	.IsDependentOn("build")
	.Does(() =>
{
    GitLink("./", new GitLinkSettings
    {
         RepositoryUrl = "https://github.com/aritchie/cerealizer",
         Branch = "master"
    });
	NuGetPack(new FilePath("./nuspec/Cerealizer.nuspec"), new NuGetPackSettings());
    NuGetPack(new FilePath("./nuspec/Cerealizer.BleExtensions.nuspec"), new NuGetPackSettings());
	MoveFiles("./*.nupkg", "./output");
});

Task("publish")
    .IsDependentOn("package")
    .Does(() =>
{
    // NuGetPush("./output/*.nupkg", new NuGetPushSettings
    // {
    //     Source = "http://www.nuget.org/api/v2/package",
    //     Verbosity = NuGetVerbosity.Detailed
    // });
    CopyFiles("./ouput/*.nupkg", "c:\\users\\allan.ritchie\\dropbox\\nuget");
});

RunTarget(target);