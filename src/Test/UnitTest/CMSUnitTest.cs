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

   

        private ICMS CreateCMS()
        {
            throw new NotImplementedException();
        }
    }
}
