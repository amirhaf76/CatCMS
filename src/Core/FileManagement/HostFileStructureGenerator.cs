using CMSCore.Abstraction;
using CMSCore.Abstraction.Models;
using CMSCore.AppStructure.Abstraction;

namespace CMSCore.FileManagement
{
    public class HostFileStructureGenerator : IHostGenerator
    {
        private readonly IFileStructureBuilder _structureGenerator;


        public HostFileStructureGenerator(IFileStructureBuilder structureBuilder) 
        {
            _structureGenerator = structureBuilder;
        }



        public IEnumerable<FileSystemInfo> GenerateHostAsFiles(Host host)
        {
            var _generatedCodesDirectory = GetHostDirectory(host);

            var doesDirectoryExist = _structureGenerator.TrySetWorkingDirectoryToFirstOccurrenceFromRoot(_generatedCodesDirectory);

            if (!doesDirectoryExist)
            {
                _structureGenerator
                    .SetWorkingDirectoryToRoot()
                    .AddDirectoryAndChangeWorkingDirectory(_generatedCodesDirectory);
            }
            foreach (var thePage in host.Pages)
            {
                _structureGenerator.AddFile(thePage.Name, GetPageContent(thePage));
            }

            var fileSystemInformation = _structureGenerator.Build().CreateStructure(GetHostDirectory(host));

            return fileSystemInformation;
        }

        public IDictionary<Host, IEnumerable<FileSystemInfo>> GenerateHostsAsFiles(IEnumerable<Host> hosts)
        {
            throw new NotImplementedException();
        }



        private static string GetPageContent(Page p)
        {
            if (p.ContentProvider.DoesItNeedLoading)
            {
                p.ContentProvider.Load();
            }

            return p.ContentProvider.GetContent();
        }

        private static string GetHostDirectory(Host host)
        {
            return host.Configuration.GeneratedCodesDirectory;
        }

        public Task<IEnumerable<FileSystemInfo>> GenerateHostAsFilesAsync(Host host)
        {
            return Task.FromResult(GenerateHostAsFiles(host));
        }
    }
}