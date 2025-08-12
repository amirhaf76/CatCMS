using CMSCore.Abstraction;

namespace CMSCore.Generator
{
    public class DefaultPageContentProvider : IPageContentProvider
    {
        public string GetContent()
        {
            return "<DefaultPageContentProviderV2>";
        }
    }
}