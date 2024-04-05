using Core.Abstract;

namespace Core
{
    public class Page : IPage
    {
        public string Title { get; set; }

        public Guid Id { get;  }

        public Page(string title, Guid id)
        {
            Id = id;
            Title = title;
        }

        public Page(string title) : this(title, Guid.NewGuid())
        {

        }

        public Page() : this(string.Empty, Guid.NewGuid())
        {

        }
    }
}