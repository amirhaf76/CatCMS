using CMSCore;
using CMSCore.AppStructure.Abstraction;
using UnitTest.Helpers;
using Xunit.Abstractions;

namespace UnitTest;


public class CMSCoreUnitTest
{
    private ITestOutputHelper _testOutput;

    public CMSCoreUnitTest(ITestOutputHelper testOutput)
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

}
