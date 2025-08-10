using CMSCore.Abstraction;
using CMSCore.FileManagement;

namespace CMSCore
{
    public class CMSDirector : ICMSDirector
    {
        public CMSDirector(ICMSBuilder cMSBuilder)
        {
            Builder = cMSBuilder;
        }

        public void Prepare()
        {
            var fileGenerator = new FileGenerator();

            Builder.SetHostRepository(new CMSHostRepository());
            Builder.SetHostGenerator(new HostFileGenerator(fileGenerator));
            Builder.SetPageFactory(new HtmlContentPageFactory());
            Builder.SetHostFactory(new HostFactory());
        }

        public ICMSBuilder Builder { get; private set; }
    }
}