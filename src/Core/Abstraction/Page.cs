using HtmlAgilityPack;

namespace CMSCore.Abstraction
{

	public class Page
    {
        private readonly Guid _id;
        private PageInfoDto _pageInfo;
        private HtmlDocument? _document;


        public Page() : this(Guid.NewGuid(), new PageInfoDto())
        {
            
        }
        public Page(PageInfoDto pageInfo) : this(Guid.NewGuid(), pageInfo)
        {

        }
        public Page(Guid id, PageInfoDto pageInfo)
        {
            _id = id;
            _pageInfo = pageInfo;
        }


        public static Page Default { get; } = new Page(Guid.Empty, new PageInfoDto());

        public static bool IsDefault(Page page)
        {
            return page._id == Guid.Empty;
        }

        public static bool IsPageContentLoadedFromFile(Page page)
        {
            return page._document != null;
        }

        public PageDto ToDto()
        {
            return new PageDto
            {
                Id = _id,
                PageInfo = _pageInfo.Copy()
            };
        }

        public void UpdatePageInfo(PageInfoDto pageInfo)
        {
            if (pageInfo is null)
            {
                throw new ArgumentNullException();
            }

            _pageInfo = pageInfo;
        }

        public void ModifyContent(Action<HtmlDocument> modifyHtmlDoc)
        {
            if (_document is null)
            {
                throw new InvalidOperationException("Html page content is not loaded!");
            }

            if (modifyHtmlDoc is null)
            {
                throw new ArgumentNullException();
            }

            modifyHtmlDoc(_document);
        }
        public void LoadPageContentFromFile()
        {
            var doc = new HtmlDocument();
            
            doc.DetectEncodingAndLoad(_pageInfo.Path);

            _document = doc;
        }

        public IPageContentProvider? ContentProvider { get; set; }
	}
}