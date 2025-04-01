using CMSCore;
using CMSCore.Abstraction;
using CMSCore.Builder;
using CMSCore.Component;
using System.Reflection;
using Xunit.Abstractions;

namespace UnitTest
{
    public class UnitTest1
    {
        private ITestOutputHelper _testOutput;

        public UnitTest1(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void AStorableObject_Store_GettingJsonFormatData()
        {
            var aStorableObject = new CarouselCatComponent() as IStorable;

            aStorableObject.Store().ValueKind.Should().NotBe(null);
        }

        [Fact]
        public void Test()
        {


            //var pageV2 = new PageV2();

            //pageV2.Layout.Should().NotBeNull();

        }

        [Fact]
        public void GettingTypes_CoreProjectModels_ItMustHaveSomeTypes()
        {
            var coreAssembly = Assembly.GetAssembly(typeof(CatCMSBuilder));

            coreAssembly?.GetTypes()
                .Should()
                .ContainEquivalentOf(new
                {
                    Name = "Post"
                })
                .And
                .ContainEquivalentOf(new
                {
                    Name = "Link"
                });

        }

       
        [Fact]
        public void RunAnCatCmsCore_AnInstanceOfCoreApplication_RunSuccessfuly()
        {

        }


        [Fact]
        public void Publish_ASampleOfRazorPageWebAppWithGeneratedSitesAndPages_SuccessfulMovingFiles()
        {
            var rootDirectory = "Published_host";
            var projectDirectory = "Generated.files";


            var sourceFilePath = "Generated.files\\Page_1";
            var destinationFileDirectory = "Published_host";
            var dir = Path.GetDirectoryName(sourceFilePath);
            var fileName = Path.GetFileName(sourceFilePath);

            if (dir is not null)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                if (fileName is not null && fileName != string.Empty)
                {
                    File.Copy(sourceFilePath, Path.Combine(destinationFileDirectory, fileName));
                }
            }



            _testOutput.WriteLine(string.Join(", ", Directory.GetFiles(destinationFileDirectory)));
        }

        private void MoveFileTo(string sourcePath, string destinationPath)
        {

        }

        private ICMSBuilder CreateCMSBuilder()
        {
            return new CatCMSBuilder();
        }

    }
}