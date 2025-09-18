using CMSCore.Abstraction.Models;
using CMSCore.FileManagement;
using Infrastructure.DotNetCLI;
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
            GeneratedCodesDirectory = path,

        };
        var files = await generator.GenerateHostAsFilesAsync(host);
    }

}
