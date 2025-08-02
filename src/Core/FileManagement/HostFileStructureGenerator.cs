using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;
using CMSCore.AppStructure.Abstraction;

namespace CMSCore.FileManagement
{
    public class HostFileStructureGenerator : IHostGenerator
    {
        private readonly IFileStructureBuilder _structureGenerator;
        private string _generatedPageFilesPath;


        public HostFileStructureGenerator(
            IFileStructureBuilder structureBuilder,
            string generatedPageFilesPath)
        {
            _structureGenerator = structureBuilder;
            _generatedPageFilesPath = generatedPageFilesPath;
        }



        public IEnumerable<FileSystemInfo> GenerateHostAsFiles(Host host)
        {
            var hostDto = host.ToDto();
            
            var doesDirectoryExist = _structureGenerator.TrySetWorkingDirectoryToFirstOccurrenceFromRoot(_generatedPageFilesPath);
            
            if (!doesDirectoryExist)
            {
                _structureGenerator
                    .SetWorkingDirectoryToRoot()
                    .AddDirectoryAndChangeWorkingDirectory(_generatedPageFilesPath);
            }
            foreach (var thePage in GetHostPages(hostDto))
            {
                _structureGenerator.AddFile(GetPageName(thePage), GetPageContent(thePage));
            }

            var fileSystemInfoes = _structureGenerator.Build().CreateStructure(GetHostDirectory(hostDto));

            return fileSystemInfoes;
        }

        private static string GetPageContent(PageDto p)
        {
            return p.ContentProvider.GetContent();
        }

        private static string GetPageName(PageDto p)
        {
            return p.PageInfo.Name;
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


        private static string GetPageTitle(PageDto page)
        {
            return page.PageInfo.Title;
        }

    }
}