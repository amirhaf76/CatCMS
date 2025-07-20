using CMSCore.Abstraction;

namespace CMSCore
{
    public class PageFactory : IPageFactory
    {
        public Page CreateADefaultTemplate()
        {
            var aPage = new Page(Guid.NewGuid(), new HtmlContentProvider(), new PageInfoDto
            {
                Name = "Default Page",
                Title = "Default Template Page",
                Path = string.Empty,
            });

            return aPage;
        }
    }

    public class ComponentBasedPageFactory : IPageFactory
    {
        private readonly IPageContentProvider _pageContentProvider;

        public ComponentBasedPageFactory(IPageContentProvider pageContentProvider)
        {
            _pageContentProvider = pageContentProvider;
        }

        public ComponentBasedPageFactory() : this(new PageContentProvider())
        {
        }

        public Page CreateADefaultTemplate()
        {
            var aPage = new Page(Guid.NewGuid(), _pageContentProvider, new PageInfoDto
            {
                Name = "Default Page",
                Title = "Default Template Page",
                Path = string.Empty,
            });

            return aPage;
        }
    }
}
