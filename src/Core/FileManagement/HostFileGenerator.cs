using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;

namespace CMSCore.FileManagement
{
    public class HostFileGenerator : IHostGenerator
    {
        private readonly IFileGenerator _fileGenerator;


        public HostFileGenerator(IFileGenerator fileGenerator)
        {
            _fileGenerator = fileGenerator;
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


        private static IEnumerable<PageFile> GeneratePageCodes(IEnumerable<PageDto> pages)
        {
            return pages.Select(page =>
            {
                return new PageFile(GetPageTitle(page), GetPageContent(page));
            });
        }

        private static string GetPageContent(PageDto page)
        {
            return page.ContentProvider.GetContent();
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