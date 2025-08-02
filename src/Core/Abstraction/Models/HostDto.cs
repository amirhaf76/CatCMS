namespace CMSCore.Abstraction.Models
{
    public class HostDto
    {
        public string Title { get; set; } = string.Empty;

        public Guid Id { get; set; }

        public HostConfiguration Configuration { get; set; } = new HostConfiguration();

        public IEnumerable<PageDto> Pages { get; set; } = Enumerable.Empty<PageDto>();

        public IEnumerable<Post> Posts { get; set; } = Enumerable.Empty<Post>();

    }

}