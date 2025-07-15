using HtmlAgilityPack;

namespace CMSCore
{
    public class PageUpdateDto
    {
        public Guid PageId {get; set; }  = Guid.Empty;
        public Guid HostId {get; set; }  = Guid.Empty;
        public string Content { get; set; } = string.Empty;

        public Action<HtmlDocument>? ModifyPageHtmlDocument;
    }
}
