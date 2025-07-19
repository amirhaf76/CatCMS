using CMSCore.Abstraction;

namespace CMSCore.FileManagement
{
    public class HostFileStructureGenerator : IHostGenerator
    {
        private readonly IFileStructureBuilder _structureGenerator;
        private readonly IPageGenerator _pageGenerator;



        public HostFileStructureGenerator(IPageGenerator pageGenerator, IFileStructureBuilder structureBuilder)
        {
            _pageGenerator = pageGenerator;
            _structureGenerator = structureBuilder;
        }



        public IEnumerable<FileSystemInfo> GenerateHostAsFiles(Host host)
        {
            var hostDto = host.ToDto();

            var fileSystemInfoes = _structureGenerator.Build().CreateStructure(GetHostDirectory(hostDto));

            throw new NotImplementedException();
        }

        public IDictionary<Host, IEnumerable<FileSystemInfo>> GenerateHostsAsFiles(IEnumerable<Host> hosts)
        {
            throw new NotImplementedException();
        }



        private static IEnumerable<PageDto> GetHostPages(HostDto hostDto)
        {
            return hostDto.Pages;
        }

        private static string GetHostDirectory(HostDto hostDto)
        {
            return hostDto.Configuration.GeneratedCodesDirectory;
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

    }
}