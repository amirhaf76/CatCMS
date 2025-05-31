using CMSCore.Abstraction;

namespace CMSCore.FileManagement
{
    public class HostFileGenerator : IHostFileGenerator
    {
        private readonly IFileGenerator _fileGenerator;
        private readonly IPageGenerator _pageGenerator;

        public HostFileGenerator(IPageGenerator pageGenerator, IFileGenerator fileGenerator)
        {
            _fileGenerator = fileGenerator;
            _pageGenerator = pageGenerator;
        }


        public IEnumerable<FileInfo> GenerateHostAsFiles(Host host, HostConfiguration hostConfig)
        {
            var pageFiles = GeneratePageCodes(host.Pages);

            var files = _fileGenerator.CreateFiles(pageFiles, hostConfig.GeneratedCodesDirectory);

            return files;
        }

        public IDictionary<Host, IEnumerable<FileInfo>> GenerateHostsAsFiles(IEnumerable<Tuple<Host, HostConfiguration>> hostsAndConfigs)
        {
            var hostsAndFiles = new Dictionary<Host, IEnumerable<FileInfo>>(hostsAndConfigs.Count());

            foreach (var (host, config) in hostsAndConfigs)
            {
                hostsAndFiles.Add(host, GenerateHostAsFiles(host, config));
            }

            return hostsAndFiles;
        }


        private IEnumerable<PageFile> GeneratePageCodes(IEnumerable<Page> pages)
        {
            return pages.Select(page =>
            {
                return new PageFile(page.Title, _pageGenerator.GenerateCodePage(page.ContentProvider));
            });
        }
    }
}