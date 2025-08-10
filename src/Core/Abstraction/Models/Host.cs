using CMSCore.Exceptions;

namespace CMSCore.Abstraction.Models
{
    public class Host
    {
        public string Title { get; set; } = string.Empty;
        public Guid Id { get; set; }
        public List<Page> Pages { get; set; } = new List<Page>();
        public List<Post> Posts { get; set; } = new List<Post>();
        public HostConfiguration Configuration { get; set; } = new HostConfiguration();

    }

}