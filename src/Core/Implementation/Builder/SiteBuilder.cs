using Core.Abstraction;

namespace Core.Implementation.Builder
{
    internal class SiteBuilder : ISiteBuilder
    {
        private readonly Site _site;
        private readonly IComponentBuilder _componentBuilder;

        public SiteBuilder(IComponentBuilder componentBuilder)
        {
            _site = new Site();
            _componentBuilder = componentBuilder;
        }

        public IPageBuilder AddPage(string title)
        {
            var thePage = CreateAndAddPageToSite(title);

            return new PageBuilder(thePage, _componentBuilder);
        }

        public Site Build()
        {
            return _site;
        }

        private Page CreateAndAddPageToSite(string title)
        {
            var aPage = new Page(title);

            _site.AddPage(aPage);

            return aPage;
        }
    }
}