using Core.Abstraction;
using Core.Exceptions;
using System.Security.Cryptography.X509Certificates;

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

        public void AddPage(Page page)
        {
            _pages.Add(page);
        }
    }
}