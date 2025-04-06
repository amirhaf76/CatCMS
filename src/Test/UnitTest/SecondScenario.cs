using CMSCore;
using CMSCore.Abstraction;
using CMSCore.Component;
using CMSCore.Generator;
using System.Reflection.Emit;
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
        public void ACmsObject_WorkFlow_GeneratesFiles()
        {
            // Arrangement
            //      First Part: Simple Abstraction
            var theHostFactory = (IHostFactory) new HostFactory();
            var thePageFactory = (IPageFactory) new PageFactory();
            var theComponentFactory = (IComponentFactory) new ComponentFactory();

            var theCodePageGenerator = (ICodePageGenerator) new CodePageGenerator();
            var theFileGenerator = (IFileGenerator) new FileGenerator();
            var theHostsValidator = (IHostValidator) new HostValidator();

            var theHostRepository = (IHostRepository) new CMSHosts();

            //      Second Part: Complexe Abstraction
            var theHostFileGenerator = (IHostFileGenerator) new HostFileGenerator(theCodePageGenerator, theFileGenerator);

            //      Third Part: Main Abstraction
            var theCms = (ICMS) new CatCMS(theHostRepository, theHostFileGenerator);

            //      Desiging Part
            var theHost = theHostFactory.CreateADefaultTemplate();
            var thePage = thePageFactory.CreateADefaultTemplate();

            theCms.AddHost(theHost);

            theHost.Pages.Add(thePage);

            thePage.Components.Add(theComponentFactory.CreateDefaultComponent());
            thePage.Components.Add(theComponentFactory.CreateDefaultComponent());
            thePage.Components.Add(theComponentFactory.CreateDefaultComponent());


            // Action
            var theResult = theCms.BuildHost(theHost.Id);
            

            // Assertion
            theResult.Should().AllSatisfy(file =>
            {
                _testOutput.WriteLine($"file path: {file.FullName ?? "<Unknown File Directory>"}");
                Directory.Exists(file.FullName ?? "<Unknown File Directory>");

                using (var openedFile = File.OpenText(file.FullName!))
                {
                    _testOutput.WriteLine(openedFile.ReadToEnd());
                }

                File.Delete(file.FullName!);
            });
        }

   
    }
}
