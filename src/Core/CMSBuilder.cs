using CMSCore.Abstraction;

namespace CMSCore
{
    public class CMSBuilder : ICMSBuilder
    {
        private IHostFactory? _hostFactory;
        private IPageFactory? _pageFactory;
        private IHostRepository? _hostRepository;
        private IHostGenerator? _hostGenerator;



        public CMSBuilder()
        {
        }



        public ICMS Build()
        {
            if (_hostRepository is null)
            {
                throw new InvalidOperationException("HostRepository was not configured.");
            }

            if (_hostGenerator is null)
            {
                throw new InvalidOperationException("HostGenerator was not configured.");
            }

            if (_hostFactory is null)
            {
                throw new InvalidOperationException("HostFactory was not configured.");
            }

            if (_pageFactory is null)
            {
                throw new InvalidOperationException("PageFactory was not configured.");
            }

            return new CatCMS(_hostRepository, _hostGenerator, _hostFactory, _pageFactory);
        }


        public void SetHostFactory(IHostFactory factory)
        {
            _hostFactory = factory;
        }

        public void SetHostGenerator(IHostGenerator generator)
        {
            _hostGenerator = generator;
        }

        public void SetHostRepository(IHostRepository repository)
        {
            _hostRepository = repository;
        }

        public void SetPageFactory(IPageFactory factory)
        {
            _pageFactory = factory;
        }

    }
}