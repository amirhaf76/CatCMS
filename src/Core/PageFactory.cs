using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;

namespace CMSCore
{
    public class PageFactory : IPageFactory
    {
        private readonly IPageContentProvider _pageContentProvider;

        public PageFactory(IPageContentProvider pageContentProvider)
        {
            _pageContentProvider = pageContentProvider;
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
