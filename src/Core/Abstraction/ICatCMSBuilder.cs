namespace Core.Abstraction
{
    public interface ICatCMSBuilder
    {
        ISiteBuilder CreateSite();

        IGenerator CreateGenerator();
    }
}