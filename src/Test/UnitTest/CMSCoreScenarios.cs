using CMSCore.FileManagement;
using CMS.Infrastructure.DotNetCLI;
using UnitTest.Helpers;
using Xunit.Abstractions;
using CMS.Application.Services;
using CMS.Domain.Entities;
using CMS.Domain.ValueObjects;

namespace UnitTest;


public class CMSCoreScenarios
{
    private readonly ITestOutputHelper _testOutput;

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
        var host = Host.Create(UserId.Empty, "test.host");

        host.UpdateGeneratedCodesDirectory(path);

        await generator.GenerateHostAsFilesAsync(host);
    }

}
