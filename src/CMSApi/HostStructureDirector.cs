using CMSCore.AppStructure.Abstraction;

namespace CMSApi
{
    public class HostStructureDirector
    {
        private readonly IFileStructureBuilder _builder;

        public HostStructureDirector(IFileStructureBuilder builder)
        {
            _builder = builder;
        }
    }
}
