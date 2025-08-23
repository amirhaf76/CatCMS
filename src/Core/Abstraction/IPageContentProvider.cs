namespace CMSCore.Abstraction
{
    public interface IPageContentProvider
    {
        bool DoesItNeedLoading { get; }

        void Load();

        string GetContent();
    }

}