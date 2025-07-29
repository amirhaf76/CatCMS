using CMSCore.FileManagement;
using CMSCore.Generator;

namespace CMSCore
{
    public class CMSDirector : ICMSDirector
    {
        private readonly ICMSBuilder _cMSBuilder;
        public CMSDirector(ICMSBuilder cMSBuilder)
        {
            _cMSBuilder = cMSBuilder;
        }

        public void PrepareItAsDefault()
        {
            var fileGenerator = new FileGenerator();

            _cMSBuilder.SetHostRepository(new CMSHosts());
            _cMSBuilder.SetHostGenerator(new HostFileGenerator(fileGenerator));
            _cMSBuilder.SetPageFactory(new HtmlContentPageFactory());
            _cMSBuilder.SetHostFactory(new HostFactory());
        }
    }
}