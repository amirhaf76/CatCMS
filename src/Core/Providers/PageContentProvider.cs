using CMSCore.Abstraction;
using CMSCore.Component;

namespace CMSCore.Providers
{
    public class PageContentProvider : IPageContentProvider
    {
        public List<ICMSComponent> Components { get; set; } = new List<ICMSComponent>();

        public bool DoesItNeedLoading => false;

        public List<ICMSComponent> GetComponents()
        {
            return Components;
        }

        public string GetContent()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
        }
    }
}