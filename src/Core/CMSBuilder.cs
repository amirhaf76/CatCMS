using CMSCore.Abstraction;
using CMSCore.FileManagement;
using CMSCore.Generator;
using System.ComponentModel;
using System.Dynamic;

namespace CMSCore
{
    public class CMSBuilder : ICMSBuilder
    {
        private IHostFactory? _hostFactory;
        private IHostRepository? _hostRepository;
        private IHostGenerator? _hostGenerator;
        private IPageFactory? _pageFactory;
        private IPageGenerator? _pageGenerator;
        private IFileGenerator? _fileGenerator;

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

        public void SetFileGenerator(IFileGenerator generator)
        {
            _fileGenerator = generator;
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

        public void SetPageGenerator(IPageGenerator generator)
        {
            _pageGenerator = generator;
        }

    }

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
            var pageGenerator = new CodePageGenerator();

            _cMSBuilder.SetFileGenerator(new FileGenerator());
            _cMSBuilder.SetPageGenerator(new CodePageGenerator());
            _cMSBuilder.SetHostRepository(new CMSHosts());
            _cMSBuilder.SetHostGenerator(new HostFileGenerator(pageGenerator, fileGenerator));
            _cMSBuilder.SetPageFactory(new PageFactory());
            _cMSBuilder.SetHostFactory(new HostFactory());
        }
    }

    public interface ICMSDirector
    {
        void PrepareItAsDefault();
    }

    public static class ICMSBuilderExtension
    {
        public static ICMSBuilder Config<T>(this ICMSBuilder cmsBuilder) where T: ICMSDirector
        {
            var director = Activator.CreateInstance(typeof(T), cmsBuilder);

            if (director is not null)
            {
                ((T)director).PrepareItAsDefault();
            }

            return cmsBuilder;
        }

        public static ICMSBuilder DefaultConfig(this ICMSBuilder cmsBuilder)
        {
            return cmsBuilder.Config<CMSDirector>();
        }
    }
}