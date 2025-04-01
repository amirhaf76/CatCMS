using CMSCore.Abstraction;

namespace CMSCore.Generator
{
    public class HostGenerator : IHostGenerator
    {
        private readonly IFileGenerator _fileGenerator;
        private readonly ICodePageGenerator _pageGenerator;

        public HostGenerator(ICodePageGenerator pageGenerator, IFileGenerator fileGenerator)
        {
            _fileGenerator = fileGenerator;
            _pageGenerator = pageGenerator;
        }

        public IEnumerable<FileInfo> GenerateHostAsFiles(Host host)
        {
            var titleAndCodes = GeneratePages(host.Pages);

            var files = titleAndCodes.Select(_fileGenerator.CreateFile);

            return files;
        }

        private IEnumerable<PageFile> GeneratePages(IEnumerable<Page> pages)
        {
            return pages.Select(page => new PageFile(page.Title, _pageGenerator.GenerateCodePage(page)));
        }


    }
}