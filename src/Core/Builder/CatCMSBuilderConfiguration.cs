using CMSCore.Abstraction;
using CMSCore.Generator;

namespace CMSCore.Builder
{
    public class CatCMSBuilderConfiguration
    {
        public string Path { get; set; } = string.Empty;

        public string IP { get; set; } = string.Empty;

        public ICMSValidator Validator { get; set; } = new CMSValidator();

        public IHostGenerator Generator { get; set; } = new HostGenerator(new CodePageGenerator(), new FileGenerator());

    }
}