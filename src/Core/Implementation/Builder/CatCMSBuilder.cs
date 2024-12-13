using Core.Abstraction;

namespace Core.Implementation.Builder
{
    public class CatCMSBuilder : ICatCMSBuilder
    {

        public CatCMSBuilder()
        {
        }

        public ISiteGenerator CreateGenerator()
        {
            // Todo: Remove Hard codeing.
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Generated.files");
            
            return new SiteGenerator(path, new CodePageGenerator());
        }

        public ISiteBuilder CreateSite()
        {
            // Todo: Removing dependency.
            return new SiteBuilder(new ComponentBuilder());
        }
    }
}