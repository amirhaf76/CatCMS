namespace CMSCore.Abstraction
{
    public class Host
    {
        public string Title { get; set; } = string.Empty;

        public Guid Id { get; set; }

        public SiteConfiguration Configuration { get; set; } = new SiteConfiguration();

        public List<Page> Pages { get; set; } = new List<Page>();
        
    }
   
}