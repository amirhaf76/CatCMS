using CMSCore;
using CMSCore.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace UnitTest
{
    public class CMSUnitTest
    {
        private ITestOutputHelper _testOutput;

        public CMSUnitTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput;
        }

        [Fact]
        public void Test()
        {
            var cmsBuilder = new CMSBuilder();

            // cmsBuilder.SetConfig("<path>");


            var cms = cmsBuilder.Build();

            var host = Host.Default;

            cms = cms.CreateAndAddHost();

            var page = new Page();

            cms = cms.CreateAndAddPage(host.ToDto().Id);



        }

        private ICMS CreateCMS()
        {
            throw new NotImplementedException();
        }
    }
}
