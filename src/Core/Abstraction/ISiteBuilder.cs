namespace Core.Abstraction
{
    public interface ISiteBuilder
    {
        IPageBuilder AddPage(string title);
        Site Build();
    }
}