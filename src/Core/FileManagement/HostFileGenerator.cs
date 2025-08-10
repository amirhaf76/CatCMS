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
            var pageFiles = GeneratePageCodes(GetHostPages(host));

            var files = _fileGenerator.CreateFiles(pageFiles, GetHostDirectory(host));

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



        private static IEnumerable<PageFile> GeneratePageCodes(IEnumerable<Page> pages)
        {
            return pages.Select(page =>
            {
                return new PageFile(page.Title, GetPageContent(page));
            });
        }

        private static string GetPageContent(Page page)
        {
            return page.ContentProvider.GetContent();
        }

        private static IEnumerable<Page> GetHostPages(Host host)
        {
            return host.Pages;
        }

        private static string GetHostDirectory(Host host)
        {
            return host.Configuration.GeneratedCodesDirectory;
        }

    }
}