namespace CMSCore.Abstraction.Models
{
    public class DefaultPageContentProvider : IPageContentProvider
    {
        public bool DoesItNeedLoading => false;

        public string GetContent()
        {
            return "<DefaultPageContentProviderV2>";
        }

        public void Load()
        {
        }
    }
}