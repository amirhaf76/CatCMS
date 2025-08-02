using CMSCore.Providers;

namespace CMSCore.Abstraction.Models
{
    public class Page
    {
        private readonly Guid _id;
        private readonly IPageContentProvider _contentProvider;
        private PageInfoDto _pageInfo;



        public Page(IPageContentProvider contentProvider) : this(Guid.NewGuid(), contentProvider, new PageInfoDto())
        {

        }

        public Page(IPageContentProvider contentProvider, PageInfoDto pageInfo) : this(Guid.NewGuid(), contentProvider, pageInfo)
        {

        }

        public Page(Guid id, IPageContentProvider contentProvider, PageInfoDto pageInfo)
        {
            _id = id;
            _pageInfo = pageInfo;
            _contentProvider = contentProvider;
        }



        public static Page Default { get; } = new Page(Guid.Empty, new HtmlContentProvider(), new PageInfoDto());

        public static bool IsDefault(Page page)
        {
            return page._id == Guid.Empty;
        }



        public void UpdatePageInfo(PageInfoDto pageInfo)
        {
            if (pageInfo is null)
            {
                throw new ArgumentNullException();
            }

            _pageInfo = pageInfo;
        }

        public PageDto ToDto()
        {
            return new PageDto
            {
                Id = _id,
                PageInfo = _pageInfo.Copy(),
                ContentProvider = _contentProvider,
            };
        }
    }
}