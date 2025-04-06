using CMSCore.Abstraction;

namespace CMSCore.Generator
{
    public class FileGenerator : IFileGenerator
    {
        public const string DEFAULT_GENERATED_FILE = "Default_generated_files";

        public string GeneratedDirectory { get; private set; }

        public FileGenerator()
        {
            GeneratedDirectory = GetDefaultDirectory();
        }

        public FileGenerator(string directory)
        {
            GeneratedDirectory = string.IsNullOrEmpty(directory) ? GetDefaultDirectory() : directory;
        }


        public string SetDirectory(string directory)
        {
            GeneratedDirectory = directory ?? throw new NullReferenceException();

            return GeneratedDirectory;
        }


        public static string GetDefaultDirectory()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), DEFAULT_GENERATED_FILE);
        }

        public FileInfo CreateFile(PageFile p)
        {
            return CreateFile(p, GeneratedDirectory);
        }

        public FileInfo CreateFile(PageFile p, string directory)
        {
            string path = GetOrCreatePath(p, directory);

            using var streamWriter = File.CreateText(path);

            streamWriter.Write(p.Code);

            streamWriter.Flush();

            return new FileInfo(path);
        }

        public List<FileInfo> CreateFiles(IEnumerable<PageFile> pageFiles, string directory)
        {
            return pageFiles.Select(pageFile => CreateFile(pageFile, directory)).ToList();
        }


        private static string GetOrCreatePath(PageFile p, string directory)
        {
            var path = Path.Combine(directory, p.Name);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return path;
        }

    }
}