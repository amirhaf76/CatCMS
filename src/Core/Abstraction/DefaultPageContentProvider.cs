namespace CMSCore.Abstraction
{
    public class DefaultPageContentProvider : IPageContentProvider
    {
        public string GetContent()
        {
            return "<DefaultPageContentProviderV2>";
        }
    }
}