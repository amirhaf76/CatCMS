using Core.Abstraction;

namespace Core
{
    internal class SiteBuilder : ISiteBuilder
    {
        private readonly Site _site;

        public SiteBuilder(Site site)
        {
            _site = site;
        }

        public IPageBuilder AddPage(string title)
        {
            var thePage = _site.CreatePage(title);

            return new PageBuilder(thePage, new ComponentBuilder());
        }

        public Site Build()
        {
            return _site;
        }
    }
}