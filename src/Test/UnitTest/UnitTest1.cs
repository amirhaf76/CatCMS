using Core;
using Core.Abstraction;
using Core.Enums;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Diagnostics;
using System.Net.WebSockets;
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
        public void ANormalSite_GiveNullValueToTitleProperty_RaisingException()
        {
            var aSite = new Core.Site();

            var editSiteTitle = () =>
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                aSite = aSite.EditTitle(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            };

            editSiteTitle.Should().Throw<NullTitleException>();
        }

        [Fact]
        public void ANormalSite_GiveNullValueToConfigProperty_RaisingException()
        {
            var aSite = new Core.Site();

            var editSiteTitle = () =>
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                aSite = aSite.SetSiteConfiguration(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            };

            editSiteTitle.Should().Throw<NullSiteConfigurationException>();
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
        public void Defining_Behavior_GeneratedFile()
        {
            var cmsBuilder = CreateCMSBuilder();

            var siteBuilder = cmsBuilder.CreateSite();

            siteBuilder
                .AddPage("Page_1")
                .AddComponent(CatCMSComponentType.CarouselCatComponent)
                .AddComponent(CatCMSComponentType.CarouselCatComponent)
                .AddComponent(CatCMSComponentType.CarouselCatComponent)
                .AddLayout(new StackLayout());

            var site = siteBuilder.Build();

            var files = cmsBuilder
                .CreateGenerator()
                .GenerateSite(site)
                .ToList();

            files.Should().AllSatisfy(file =>
            {
                File.Exists(file.FullName).Should().BeTrue();
            });
        }

        [Fact]
        public void RunAnCatCmsCore_AnInstanceOfCoreApplication_RunSuccessfuly()
        {

        }

        [Fact]
        public void Publish_ASampleOfRazorPageWebAppWithGeneratedSitesAndPages_SuccessfulMovingFiles()
        {
            var rootDirectory = "Published_site";
            var projectDirectory = "Generated.files";

            
            var sourceFilePath = "Generated.files\\Page_1";
            var destinationFileDirectory = "Published_site";
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

        private ICatCMSBuilder CreateCMSBuilder()
        {
            return new CatCMSBuilder();
        }

    }
}