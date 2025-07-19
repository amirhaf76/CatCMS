using CMSCore;
using CMSCore.Abstraction;
using CMSCore.Component;
using CMSCore.FileManagement;
using CMSCore.Generator;
using System.Formats.Tar;
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
        public void APageWithAComponent_GenerateCode_ShouldNotBeEmpty()
        {
            // Arrangement
            var theCodePageGenerator = (IPageGenerator)new CodePageGenerator();
            var aPage = new PageFactory().CreateADefaultTemplate();

            var aComponent = new DefaultComponent();

            aPage.ContentProvider?.GetComponents().Add(aComponent);

            // Action
            var generatedCode = theCodePageGenerator.GenerateCodePage(aPage.ContentProvider);

            // Assertion
            generatedCode.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void PageFileWithoutSpecifiedDirectory_CreateFile_FileWithItsContentMustBeCreated()
        {
            // Arrangement
            var theFileGenerator = (IFileGenerator)new FileGenerator();
            var pageName = "page.name";
            var code = "<Some.Codes>";

            var aPageFile = new PageFile(pageName, code);

            // Action
            var theFile = theFileGenerator.CreateFile(aPageFile);

            // Assertion
            try
            {
                File.Exists(theFile.FullName).Should().BeTrue();

                theFile.Name.Should().Be(pageName);

                using (var stream = theFile.OpenText())
                {
                    var fileContent = stream.ReadToEnd();

                    fileContent.Should().Be(code);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (File.Exists(theFile.FullName))
                {
                    File.Delete(theFile.FullName);
                }
            }
        }

        [Fact]
        public void PageFileWithSpecifiedDirectory_CreateFile_FileWithItsContentMustBeCreated()
        {
            // Arrangement
            var theFileGenerator = (IFileGenerator)new FileGenerator();
            var pageName = "page.name.2";
            var code = "<Some.Codes>";
            var aDirectory = "Test.Directory";

            var aPageFile = new PageFile(pageName, code);

            // Action
            var theFile = theFileGenerator.CreateFile(aPageFile, aDirectory);

            // Assertion
            try
            {
                File.Exists(theFile.FullName).Should().BeTrue();

                theFile.Name.Should().Be(pageName);

                var theDirctory = Directory.GetParent(theFile.FullName);
                theDirctory.Should().NotBeNull();
                theDirctory?.Name.Should().Be(aDirectory);

                using (var stream = theFile.OpenText())
                {
                    var fileContent = stream.ReadToEnd();

                    fileContent.Should().Be(code);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (File.Exists(theFile.FullName))
                {
                    File.Delete(theFile.FullName);
                }

                if (theFile.Directory is not null)
                {
                    Directory.Delete(theFile.Directory.FullName);
                }
            }
        }

        [Fact]
        public void PageFilesWithSpecifiedDirectory_CreateFiles_FilesWithTheirContentMustBeCreated()
        {
            // Arrangement
            var theFileGenerator = (IFileGenerator)new FileGenerator();
            var pageNames = new List<string>
            {
                "page.name.1",
                "page.name.2",
                "page.name.3",
            };
            var codes = new List<string>
            {
                "<Some.Codes.1>",
                "<Some.Codes.2>",
                "<Some.Codes.3>",
            };
            var aDirectory = "Test.Directory";

            var pageFiles = new List<PageFile>
            {
                new PageFile(pageNames[0], codes[0]),
                new PageFile(pageNames[1], codes[1]),
                new PageFile(pageNames[2], codes[2]),
            };

            // Action
            var theFiles = theFileGenerator.CreateFiles(pageFiles, aDirectory);

            // Assertion
            var pairedFiles = theFiles.Zip(pageFiles);
            try
            {
                foreach (var (file, pageFile) in pairedFiles)
                {
                    File.Exists(file.FullName).Should().BeTrue();

                    file.Name.Should().Be(pageFile.Name);

                    var theDirctory = Directory.GetParent(file.FullName);
                    theDirctory.Should().NotBeNull();
                    theDirctory?.Name.Should().Be(aDirectory);

                    using (var stream = file.OpenText())
                    {
                        var fileContent = stream.ReadToEnd();

                        fileContent.Should().Be(pageFile.Code);
                    }
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                foreach (var file in theFiles)
                {
                    if (File.Exists(file.FullName))
                    {
                        File.Delete(file.FullName);
                    }
                }

                Directory.Delete(aDirectory);
            }
        }

        [Fact]
        public void ACmsObject_WorkFlow_GeneratesFiles()
        {
            // Arrangement
            //      First Part: Simple Abstraction
            var theHostFactory = (IHostFactory)new HostFactory();
            var thePageFactory = (IPageFactory)new PageFactory();
            var theComponentFactory = (IComponentFactory)new ComponentFactory();

            var theCodePageGenerator = (IPageGenerator)new CodePageGenerator();
            var theFileGenerator = (IFileGenerator)new FileGenerator();

            var theHostRepository = (IHostRepository)new CMSHosts();

            //      Second Part: Complexe Abstraction
            var theHostFileGenerator = (IHostGenerator)new HostFileGenerator(theCodePageGenerator, theFileGenerator);

            //      Third Part: Main Abstraction
            var theCms = (ICMS)new CatCMS(theHostRepository, theHostFileGenerator, theHostFactory, thePageFactory);

            //      Desiging Part
            var theHost = theHostFactory.CreateADefaultTemplate();
            var thePage = thePageFactory.CreateADefaultTemplate();

            theCms.AddHost(theHost);

            theHost.AddPage(thePage);

            thePage.ContentProvider?.GetComponents().Add(theComponentFactory.CreateDefaultComponent());
            thePage.ContentProvider?.GetComponents().Add(theComponentFactory.CreateDefaultComponent());
            thePage.ContentProvider?.GetComponents().Add(theComponentFactory.CreateDefaultComponent());


            // Action
            var theResult = theHostFileGenerator.GenerateHostAsFiles(theHost);


            // Assertion
            theResult.Should().AllSatisfy(file =>
            {
                _testOutput.WriteLine($"file path: {file.FullName ?? "<Unknown File Directory>"}");

                File.Exists(file.FullName).Should().BeTrue();

                using (var openedFile = File.OpenText(file.FullName!))
                {
                    _testOutput.WriteLine(openedFile.ReadToEnd());
                }

                File.Delete(file.FullName!);
            });
        }

        [Fact]
        public void ACmsObjectWithValidatedHostGenerator_WorkFlow_GeneratesFiles()
        {
            // Arrangement
            //      First Part: Simple Abstraction
            var theHostFactory = (IHostFactory)new HostFactory();
            var thePageFactory = (IPageFactory)new PageFactory();
            var theComponentFactory = (IComponentFactory)new ComponentFactory();

            var thePageGenerator = (IPageGenerator)new CodePageGenerator();
            var theFileGenerator = (IFileGenerator)new FileGenerator();
            var theHostRepository = (IHostRepository)new CMSHosts();

            var theHostsValidator = (IHostValidator)new HostValidator();

            //      Second Part: Complexe Abstraction
            var theHostGenerator = (IHostGenerator)new HostFileGenerator(thePageGenerator, theFileGenerator);

            theHostGenerator = new ValidatedHostFileGenerator(theHostGenerator, theHostsValidator);

            //      Third Part: Main Abstraction
            var theCms = (ICMS)new CatCMS(theHostRepository, theHostGenerator, theHostFactory, thePageFactory);

            //      Forth Part: Designing Part
            var theHost = theHostFactory.CreateADefaultTemplate();
            var thePage = thePageFactory.CreateADefaultTemplate();

            theCms.AddHost(theHost);

            theHost.AddPage(thePage);

            thePage.ContentProvider?.GetComponents().Add(theComponentFactory.CreateDefaultComponent());
            thePage.ContentProvider?.GetComponents().Add(theComponentFactory.CreateDefaultComponent());
            thePage.ContentProvider?.GetComponents().Add(theComponentFactory.CreateDefaultComponent());


            // Action
            var theResult = theHostGenerator.GenerateHostAsFiles(theHost);


            // Assertion
            theResult.Should().AllSatisfy(file =>
            {
                _testOutput.WriteLine($"file path: {file.FullName ?? "<Unknown File Directory>"}");

                File.Exists(file.FullName).Should().BeTrue();

                using (var openedFile = File.OpenText(file.FullName!))
                {
                    _testOutput.WriteLine(openedFile.ReadToEnd());
                }

                File.Delete(file.FullName!);
            });
        }


        [Fact]
        public async Task ACmsObject_WithBuilder_GeneratesFilesAsync()
        {
            // Arrangement
            //      Builder
            var theCmsBuilder = new CMSBuilder().DefaultConfig();
            var theCms = theCmsBuilder.Build();

            //      Designing Part
            var theHost = theCms.CreateAndAddHost();
            var thePage = theCms.CreateAndAddPage(theHost.Id);

            await theCms.UpdatePageContentAsync(new PageUpdateDto
            {
                HostId = theHost.Id,
                PageId = thePage.Id,
                Content = "<Content>",
            });

            // Action
            var theResult = theCms.GenerateHost(theHost.Id);


            // Assertion
            theResult.Should().AllSatisfy(file =>
            {
                _testOutput.WriteLine($"file path: {file.FullName ?? "<Unknown File Directory>"}");

                File.Exists(file.FullName).Should().BeTrue();

                using (var openedFile = File.OpenText(file.FullName!))
                {
                    _testOutput.WriteLine(openedFile.ReadToEnd());
                }

                File.Delete(file.FullName!);
            });
        }
    }
}
