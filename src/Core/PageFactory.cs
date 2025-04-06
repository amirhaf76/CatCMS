using CMSCore.Abstraction;

namespace CMSCore
{
    public class PageFactory : IPageFactory
    {
        public Page CreateADefaultTemplate()
        {
            return new Page
            {
                Id = Guid.NewGuid(),
                Title = "Default Template Page",
            };
        }
    }
}
