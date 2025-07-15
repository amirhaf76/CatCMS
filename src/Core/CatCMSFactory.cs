using CMSCore.Abstraction;
using CMSCore.FileManagement;
using CMSCore.Generator;

namespace CMSCore
{
    public static class CatCMSFactory
    {
        public static ICMS CreateCMS()
        {
            var generator = CreateHostGenerator();

            return new CatCMS(new CMSHosts(), generator, new HostFactory(), new PageFactory());
        }

        private static HostFileGenerator CreateHostGenerator()
        {
            return new HostFileGenerator(new CodePageGenerator(), new FileGenerator());
        }
    }
}