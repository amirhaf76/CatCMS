using Core.Abstraction;

namespace Core
{
    public class SiteGenerator : ISiteGenerator
    {
        private readonly FileGenerator _fileGenerator;
        private readonly ICodePageGenerator _pageGenerator;

        public SiteGenerator(string directory, ICodePageGenerator pageGenerator)
        {
            _fileGenerator = new FileGenerator(directory);
            _pageGenerator = pageGenerator;
        }

        public IEnumerable<FileInfo> GenerateSite(Site site)
        {
            var titleAndCodes = GeneratePages(site.Pages);

            var files = titleAndCodes.Select(_fileGenerator.CreateFile);

            return files;
        }

        private IEnumerable<PageFile> GeneratePages(IEnumerable<Page> pages)
        {
            return pages.Select(page => new PageFile(page.Title, _pageGenerator.GenerateCodePage(page)));
        }

        
    }
}