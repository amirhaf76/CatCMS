using Core.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Core
{
    public class Site : ISite
    {
        public string Title { get; set; }

        public Guid Id { get; }


        public Site(string title, Guid id)
        {
            Title = title;
            Id = id;
            Configuration = new SiteConfiguration();
        }

        public Site(string title) : this(title, Guid.NewGuid())
        {

        }

        public Site() : this(string.Empty, Guid.NewGuid())
        {
           
        }


        public SiteConfiguration Configuration { get; }


        public IEnumerable<IPage> GetPages()
        {
            throw new NotImplementedException();
        }
    }
}