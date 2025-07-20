namespace CMSCore.Abstraction
{
    public class Host
    {
        private readonly string _title;
        private readonly Guid _id;
        private readonly HostConfiguration _configuration;
        private readonly List<Page> _pages;
        private readonly List<Post> _posts;



        public Host(string title, HostConfiguration configuration)
            : this(Guid.NewGuid(), title, configuration)
        {

        }

        public Host(Guid id, string title, HostConfiguration configuration)
        {
            _id = id;
            _title = title;
            _configuration = configuration;

            _pages = new List<Page>();
            _posts = new List<Post>();
        }



        public static Host Default { get; } = new Host(Guid.Empty, string.Empty, new HostConfiguration());

        public static bool IsDefault(Host host)
        {
            return host._id == Guid.Empty;
        }



        public Page GetPageById(Guid pageId)
        {
            return _pages.FirstOrDefault(p => GetPageId(p.ToDto()) == pageId) ?? throw new PageNotFoundException();
        }

        public Page GetPageByIdOrDefault(Guid pageId)
        {
            return _pages.FirstOrDefault(p => GetPageId(p.ToDto()) == pageId) ?? Page.Default;
        }


        public void AddPage(Page page)
        {
            _pages.Add(page);
        }


        public void Remove(Guid pageId)
        {
            var thePage = GetPageById(pageId);

            _pages.Remove(thePage);
        }

        public void Remove(Page page)
        {
            _pages.Remove(page);
        }


        public HostDto ToDto()
        {
            return new HostDto
            {
                Title = _title,
                Id = _id,
                Configuration = _configuration.Copy(),
                Pages = _pages.Select(p => p.ToDto()),
                Posts = _posts.AsEnumerable(),
            };
        }



        private static Guid GetPageId(PageDto p)
        {
            return p.Id;
        }

    }

}