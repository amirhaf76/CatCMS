using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;
using CMSCore.Providers;

namespace CMSCore
{
    public class HtmlContentPageFactory : IPageFactory
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
}
