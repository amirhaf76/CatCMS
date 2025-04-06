using CMSCore.Abstraction;
using CMSCore.Generator;

namespace CMSCore
{
    public static class CatCMSFactory
    {
        public static ICMS CreateCMS()
        {
            var generator = CreateHostGenerator();

            return new CatCMS(new CMSHosts(), generator);
        }

        private static HostFileGenerator CreateHostGenerator()
        {
            return new HostFileGenerator(new CodePageGenerator(), new FileGenerator());
        }
    }
}