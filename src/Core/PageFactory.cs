using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;
using CMSCore.Providers;

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
            return new Page()
            {
                Id = Guid.NewGuid(),
                ContentProvider = _pageContentProvider,
                Name = "Default Page",
                Title = "Default Template Page",
                Path = string.Empty,
            };
        }
    }
}
