namespace CMSCore
{
    public abstract class BaseStructureBuilder
    {
        protected readonly string _directory;

        public BaseStructureBuilder(string directory)
        {
            _directory = directory;
        }

        public abstract IEnumerable<FileSystemInfo> BuildV2();
    }
}