namespace Core.Abstract
{
    public interface ISite
    {
        public string Title { get; set; }

        public Guid Id { get; }

        public SiteConfiguration Configuration { get; }

        public IEnumerable<IPage> GetPages();

    }
}