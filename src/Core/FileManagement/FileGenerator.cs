using CMSCore.Abstraction;

namespace CMSCore.FileManagement
{
    public class FileGenerator : IFileGenerator
    {
        public string GeneratedDirectory { get; set; }



        public FileGenerator()
        {
            GeneratedDirectory = string.Empty;
        }

        public FileGenerator(string directory)
        {
            GeneratedDirectory = string.IsNullOrWhiteSpace(directory) ? string.Empty : directory;
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

        public List<FileInfo> CreateFiles(IEnumerable<PageFile> pageFiles)
        {
            return pageFiles.Select(pageFile => CreateFile(pageFile)).ToList();
        }


        public void ChangeGeneratedDirectory(string newDirectory)
        {
            if (string.IsNullOrWhiteSpace(newDirectory))
                throw new ArgumentException("Directory path cannot be null, empty or whitespace.", nameof(newDirectory));

            GeneratedDirectory = newDirectory;
        }



        private static string GetOrCreatePath(PageFile p, string directory)
        {
            var path = Path.Combine(directory, p.Name);

            if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return path;
        }

    }
}