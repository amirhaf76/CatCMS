using CMSCore;
using CMSCore.Abstraction;
using CMSCore.Builder;
using Xunit.Abstractions;

namespace UnitTest
{
    public class SecondScenario
    {
        private ITestOutputHelper _testOutput;

        public SecondScenario(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void Test1()
        {
            var theCmsBuilderType = typeof(CatCMSBuilder);

            theCmsBuilderType.Should().HaveDefaultConstructor();
            theCmsBuilderType.Should().HaveConstructor(new[] { typeof(CatCMSBuilderConfiguration) });
        }

        [Fact]
        public void Test3()
        {
            var theICMSBuilderType = typeof(ICMSBuilder);

            theICMSBuilderType
                .Should()
                .HaveMethod("Build", Array.Empty<Type>())
                .Which
                .Should()
                .Return<ICMS>();
        }

        [Fact]
        public void Test2()
        {
            var cmsBuilder = new CatCMSBuilder() as ICMSBuilder;

            var cms = cmsBuilder.Build();



        }

        [Fact]
        public void Test4()
        {
            var aSite = new Host();
            var secondSite = new Host();

            aSite.IsDefault().Should().BeTrue();
            aSite.Should().BeEquivalentTo(new Host
            {
                Title = string.Empty,
                Configuration = new SiteConfiguration(),
                Id = Guid.Empty,
                Pages = new List<Page>(),
            });

            secondSite.IsDefault().Should().BeTrue();
        }

        [Fact]
        public void Test5()
        {
            _testOutput.WriteLine(default(string)?.ToString() ?? "null !");
            _testOutput.WriteLine(default(int).ToString());
            _testOutput.WriteLine(default(IEnumerable<int>)?.ToString() ?? "null !");
            _testOutput.WriteLine(default(Guid).ToString());
            _testOutput.WriteLine(default(bool).ToString());
        }



    }
}
