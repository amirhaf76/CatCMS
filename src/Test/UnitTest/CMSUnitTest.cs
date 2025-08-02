using CMSCore.Abstraction;
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
