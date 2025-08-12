using CMSCore.Providers;

namespace CMSCore.Abstraction.Models
{
    public class Page
    {
        public string Title { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Path { get; set; } = string.Empty;

        public Guid Id { get; set; }

        public IPageContentProvider ContentProvider { get; set; }
    }
}