namespace CMSCore
{
    public class AppFileStructure
    {
        private readonly DirectoryStructure _rootDirectory;

        public AppFileStructure(DirectoryStructure rootDirectory)
        {
            _rootDirectory = rootDirectory;
        }

        public IEnumerable<FileSystemInfo> CreateStructure(string path)
        {
            return new DirectoryStructureBuilder(path, _rootDirectory).Build();
        }
    }

}