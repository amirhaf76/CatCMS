using CMSCore;
using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;
using CMSCore.AppStructure.Abstraction;
using CMSCore.AppStructure.Extensions;
using CMSCore.FileManagement;
using Infrastructure.DotNetCLI;
using System.Threading.Tasks;
using UnitTest.Helpers;
using Xunit.Abstractions;

namespace UnitTest;


public class CMSCoreScenarios
{
    private ITestOutputHelper _testOutput;

    public CMSCoreScenarios(ITestOutputHelper testOutput)
    {
        _testOutput = testOutput;
    }

    [Fact]
    public void Test()
    {
        var aFileSystem = new FileSystem();
        var theTestResultPath = TestHelper.GetResultAddress();
        var theFakeDataPath = TestHelper.GetFakeDataAddress();

        IFileStructureBuilder aFileStructuredBuilder = new AppFileStructureBuilder("CMSCore", aFileSystem);

        aFileStructuredBuilder.AddFilesLike(theFakeDataPath);

        var systemInfoes =  aFileStructuredBuilder.Build().CreateStructure(theTestResultPath);

        systemInfoes.Should().NotBeEmpty().And.Satisfy(
            x => x.Name == "CMSCore",
            x => x.Name == FakeData.FileNum1
            );

        var theTestResultFileSystems = TestHelper.GetTestResultFilesSystemEntryAndDelete();

        foreach (var file in theTestResultFileSystems)
        {
            _testOutput.WriteLine(file);
        }
    }

    [Fact]
    public void AppFileStructureBuilder_BuildSomeDirectoriesAndFiles_MustBeExist()
    {
        var structureDirectoryName = "MyApp1";
        var theTestResultPath = Path.Combine(TestHelper.GetAbsoluteResultAddress(), structureDirectoryName);

        var appStruct = new AppFileStructureBuilder(structureDirectoryName, new FileSystem());

        appStruct
            .AddDirectoryAndChangeWorkingDirectory("txtFolder")
            .AddFile("hello.World.txt", "Hello World number 1")
            .AddFile("hello.World.2.txt", "Hello World number 2")
            .SetWorkingDirectoryToRoot()
            .AddDirectory("directory_1")
            .AddDirectory("directory_2")
            .AddDirectory("directory_3")
            .AddDirectoryAndChangeWorkingDirectory("directory_level_1")
            .AddDirectoryAndChangeWorkingDirectory("directory_level_2")
            .AddDirectoryAndChangeWorkingDirectory("directory_level_3")
            .SetWorkingDirectoryToRoot();

        // Action
        _testOutput.WriteLine(appStruct.GetStructureView());

        appStruct.Build().CreateStructure(TestHelper.GetAbsoluteResultAddress());


        // Assertion
        Directory.EnumerateFileSystemEntries(theTestResultPath).Should()
            .Contain(x => x.Contains("txtFolder"))
            .And.Contain(x => x.Contains("directory_1"))
            .And.Contain(x => x.Contains("directory_2"))
            .And.Contain(x => x.Contains("directory_3"))
            .And.Contain(x => x.Contains("directory_level_1"));


        Directory.EnumerateFileSystemEntries(Path.Combine(theTestResultPath, "txtFolder")).Should()
            .Contain(x => x.Contains("hello.World.txt"))
            .And.Contain(x => x.Contains("hello.World.2.txt"));


        Directory.EnumerateFileSystemEntries(Path.Combine(theTestResultPath, "directory_level_1"))
            .Should().Contain(x => x.Contains("directory_level_2"));


        Directory.EnumerateFileSystemEntries(Path.Combine(theTestResultPath, "directory_level_1", "directory_level_2"))
            .Should().Contain(x => x.Contains("directory_level_3"));

        var results = TestHelper.GetTestResultFilesSystemEntryAndDelete();

        foreach (var file in results)
        {
            _testOutput.WriteLine(file);
        }
    }

    [Fact]
    public void AppFileStructureCopy_SomeDirectoriesAndFiles_MustBeExist()
    {
        var theStructure = new DirectoryStructure("MyApp1");

        var theStructures = new List<BaseStructure>
            {
                new DirectoryStructure("Directory_1"),
                new DirectoryStructure("Directory_2"),
                new FileStructure("File.txt", "Test content"),
            };

        theStructure.AddChildren(theStructures);

        // Action
        var copiedStructure = theStructure.Copy();

        // Assertion
        copiedStructure.Should()
            .NotBeNull()
            .And.BeOfType<DirectoryStructure>()
            .And.NotBeSameAs(theStructure);

        copiedStructure.As<DirectoryStructure>().ForEachChild(c =>
        {
            theStructures.Should().NotContain(c);
        });
    }

    [Fact]
    public async Task Test2()
    {
        var dotnetClit = new DotnetCli();

        var generator = new DotnetHostGenerator(dotnetClit, new DotnetHostGenDto
        {
            Template = "cms-host-template",
            Nuget = "CMS.Utility.Templates",
            Version = "9.0"
        });
        var path = Path.Combine(TestHelper.GetAbsoluteResultAddress(), "test.host");
        var host = new Host()
        {
            Title = "test.host",
            Configuration = new HostConfiguration
            {
                GeneratedCodesDirectory = path,
            }
            
        };
        var files = await generator.GenerateHostAsFilesAsync(host);
    }

}
