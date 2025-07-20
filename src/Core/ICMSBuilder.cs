using CMSCore.Abstraction;
using CMSCore.FileManagement;

namespace CMSCore
{
    public interface ICMSBuilder
    {
        void SetHostFactory(IHostFactory factory);
        void SetHostRepository(IHostRepository repository);
        void SetHostGenerator(IHostGenerator generator);
        void SetPageFactory(IPageFactory factory);

        public ICMS Build();
    }
}