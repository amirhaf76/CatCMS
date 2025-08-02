using CMSCore.Generator;

namespace CMSCore.Abstraction.Models
{
    public class PageDto
    {
        public Guid Id { get; set; } = Guid.Empty;

        public PageInfoDto PageInfo { get; set; } = new PageInfoDto();

        public IPageContentProvider ContentProvider { get; set; } = new DefaultPageContentProvider();

    }

}