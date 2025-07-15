using CMSCore.Abstraction;

namespace CMSCore
{
    public class PageFactory : IPageFactory
    {
        public Page CreateADefaultTemplate()
        {
            var aPage = new Page(Guid.NewGuid(), new PageInfoDto
            {
                Name = "Default Page",
                Title = "Default Template Page",
                Path = string.Empty,
            });

            return aPage;
        }
    }
}
