using CMSCore.Abstraction;
using HtmlAgilityPack;

namespace CMSCore.Providers
{
    public class HtmlContentProvider : IPageContentProvider
    {
        private HtmlDocument? _document;



        public HtmlContentProvider()
        {
        }



        public string GetContent()
        {
            if (!IsPageContentLoadedFromFile())
            {
                ThrowExceptionDueNotToLoadContent();
            }

            return _document?.DocumentNode.OuterHtml ?? string.Empty;
        }

        public bool IsPageContentLoadedFromFile()
        {
            return _document != null;
        }

        public void ModifyContent(Action<HtmlDocument> modifyHtmlDoc)
        {
            if (!IsPageContentLoadedFromFile())
            {
                ThrowExceptionDueNotToLoadContent();
            }

            if (modifyHtmlDoc is null)
            {
                throw new ArgumentNullException();
            }

            modifyHtmlDoc(_document!);
        }

        public void LoadPageContentFromFile(string path)
        {
            var doc = new HtmlDocument();
            // todo: path !!!!
            doc.DetectEncodingAndLoad(path);

            _document = doc;
        }



        private static void ThrowExceptionDueNotToLoadContent()
        {
            throw new InvalidOperationException("The page content is not loaded or, for a new page, there is no content!");
        }
    }
}