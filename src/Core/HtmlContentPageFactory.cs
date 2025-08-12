using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;
using CMSCore.Providers;

namespace CMSCore
{
    public class HtmlContentPageFactory : IPageFactory
    {
        public Page CreateADefaultTemplate()
        {
            return new Page()
            {
                Id = Guid.NewGuid(),
                ContentProvider = new HtmlContentProvider(),
                Name = "Default Page",
                Title = "Default Template Page",
                Path = string.Empty,
            };
        }
    }
}
