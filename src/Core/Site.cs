using Core.Abstraction;
using Core.Exceptions;

namespace Core
{


    public class Site 
    {
        private readonly List<Page> _pages;

        public string Title { get; private set; }

        public Guid Id { get; }

        public  SiteConfiguration Configuration { get; private set; }

        public IEnumerable<Page> Pages { get => _pages; }


        public Site(string title, Guid id)
        {
            Title = title;
            Id = id;
            Configuration = new SiteConfiguration();
            _pages = new List<Page>();
        }

        public Site(string title) : this(title, Guid.NewGuid())
        {

        }

        public Site() : this(string.Empty, Guid.NewGuid())
        {

        }


        public IEnumerable<Page> GetPages()
        {
            throw new NotImplementedException();
        }

        public Site EditTitle(string newTitle)
        {
            Title = newTitle ?? throw new NullTitleException();

            return this;
        }

        public Site SetSiteConfiguration(SiteConfiguration newConfig)
        {
            Configuration = newConfig ?? throw new NullSiteConfigurationException();

            return this;
        }

        public Page CreatePage(string title)
        {
            var aPage = new Page(title);

            _pages.Add(aPage);

            return aPage;
        }

        public IEnumerable<(string name, string code)> GeneratePages()
        {
            var generator = new PageGenerator();

            return _pages.Select(page => (page.Title,  generator.Generate(page)));
        }
    }
}