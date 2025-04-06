namespace CMSCore.Abstraction
{
    public class Host
    {
        public string Title { get; set; } = string.Empty;

        public Guid Id { get; set; }

        public HostConfiguration Configuration { get; set; } = new HostConfiguration();

        public List<Page> Pages { get; set; } = new List<Page>();
        
    }
   
}