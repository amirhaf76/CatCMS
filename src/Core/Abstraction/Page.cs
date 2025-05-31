namespace CMSCore.Abstraction
{

	public class Page
    {
        public string Title { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public Guid Id { get; set; }

        public string Content { get; set; } = string.Empty;

        public IPageContentProvider? ContentProvider { get; set; }
	}
}