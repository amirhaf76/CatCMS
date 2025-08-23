using CMSCore.Abstraction;
using HtmlAgilityPack;

namespace CMSCore.Providers
{
    public class HtmlContentProvider : IPageContentProvider
    {
        private HtmlDocument? _document;



        public HtmlContentProvider(string path)
        {
            Path = path;
        }

        public HtmlContentProvider()
        {
        }



        public string Path { get; private set; } = string.Empty;

        public bool DoesItNeedLoading => true;



        public string GetContent()
        {
            if (!IsPageContentLoadedFromFile())
            {
                if (string.IsNullOrEmpty(Path))
                {
                    ThrowExceptionDueNotToLoadContent();
                }

                LoadPageContentFromFile(Path);
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
            Path = path;

            var doc = new HtmlDocument();
            // todo: path !!!!
            doc.DetectEncodingAndLoad(path);

            _document = doc;
        }

        public void LoadPageContent(string content)
        {
            var doc = new HtmlDocument();
            // todo: path !!!!
            doc.LoadHtml(content);

            _document = doc;
        }

        public void Load()
        {
            LoadPageContentFromFile(Path);
        }


        private static void ThrowExceptionDueNotToLoadContent()
        {
            throw new InvalidOperationException("The page content is not loaded or, for a new page, there is no content!");
        }

    }
}