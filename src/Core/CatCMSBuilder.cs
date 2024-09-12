using Core.Abstraction;

namespace Core
{
    public class CatCMSBuilder : ICatCMSBuilder
    {

        public CatCMSBuilder()
        {
        }

        public IGenerator CreateGenerator()
        {
            return new WebGenerator(Path.Combine(Directory.GetCurrentDirectory(), "Generated.files"));
        }

        public ISiteBuilder CreateSite()
        {
            return new SiteBuilder(new Site());
        }
    }
}