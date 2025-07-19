using CMSCore.Abstraction;

namespace CMSCore.FileManagement
{
    public class HostFileGenerator : IHostGenerator
    {
        private readonly IFileGenerator _fileGenerator;
        private readonly IPageGenerator _pageGenerator;



        public HostFileGenerator(IPageGenerator pageGenerator, IFileGenerator fileGenerator)
        {
            _fileGenerator = fileGenerator;
            _pageGenerator = pageGenerator;
        }



        public IEnumerable<FileSystemInfo> GenerateHostAsFiles(Host host)
        {
            var hostDto = host.ToDto();

            var pageFiles = GeneratePageCodes(GetHostPages(hostDto));

            var files = _fileGenerator.CreateFiles(pageFiles, GetHostDirectory(hostDto));

            return files;
        }

        public IDictionary<Host, IEnumerable<FileSystemInfo>> GenerateHostsAsFiles(IEnumerable<Host> hosts)
        {
            var hostsAndFiles = new Dictionary<Host, IEnumerable<FileSystemInfo>>(hosts.Count());

            foreach (var host in hosts)
            {
                hostsAndFiles.Add(host, GenerateHostAsFiles(host));
            }

            return hostsAndFiles;
        }


        private IEnumerable<PageFile> GeneratePageCodes(IEnumerable<PageDto> pages)
        {
            return pages.Select(page =>
            {
                return new PageFile(GetPageTitle(page), _pageGenerator.GenerateCodePage(new PageContentProvider()));
            });
        }

        private static string GetPageTitle(PageDto page)
        {
            return page.PageInfo.Title;
        }

        private static IEnumerable<PageDto> GetHostPages(HostDto hostDto)
        {
            return hostDto.Pages;
        }

        private static string GetHostDirectory(HostDto hostDto)
        {
            return hostDto.Configuration.GeneratedCodesDirectory;
        }

    }
}