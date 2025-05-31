namespace CMSCore.Abstraction
{
    public interface IPageGenerator
    {
        public string GenerateCodePage(IPageContentProvider? contentProvider);
    }
}