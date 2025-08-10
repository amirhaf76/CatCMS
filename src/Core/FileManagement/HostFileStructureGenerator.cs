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
            var doesDirectoryExist = _structureGenerator.TrySetWorkingDirectoryToFirstOccurrenceFromRoot(_generatedPageFilesPath);

            if (!doesDirectoryExist)
            {
                _structureGenerator
                    .SetWorkingDirectoryToRoot()
                    .AddDirectoryAndChangeWorkingDirectory(_generatedPageFilesPath);
            }
            foreach (var thePage in host.Pages)
            {
                _structureGenerator.AddFile(thePage.Name, GetPageContent(thePage));
            }

            var fileSystemInfoes = _structureGenerator.Build().CreateStructure(GetHostDirectory(host));

            return fileSystemInfoes;
        }

        public IDictionary<Host, IEnumerable<FileSystemInfo>> GenerateHostsAsFiles(IEnumerable<Host> hosts)
        {
            throw new NotImplementedException();
        }



        private static string GetPageContent(Page p)
        {
            return p.ContentProvider.GetContent();
        }



        private static string GetHostDirectory(Host host)
        {
            return host.Configuration.GeneratedCodesDirectory;
        }

    }
}