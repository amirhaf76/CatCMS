namespace Core.Abstraction
{
    public interface ICatCMSBuilder
    {
        ISiteBuilder CreateSite();

        ISiteGenerator CreateGenerator();
    }
}