using System.Runtime.InteropServices;
using Core.Abstraction;

namespace Core
{
    public class WebGenerator : IGenerator
    {
        public const string DEFAULT_GENERATED_FILE = "Default_generated_files";

        public string GeneratedDirectory { get; private set; }


        public WebGenerator(string directory)
        {
            GeneratedDirectory = directory ?? GetDefaultDirectory();
        }


        public string SetDirectory(string directory)
        {
            GeneratedDirectory = directory ?? throw new NullReferenceException();

            return GeneratedDirectory;
        }

        public IEnumerable<FileInfo> GenerateSite(Site Site)
        {
            var titleAndCodes = Site.GeneratePages();

            var files = titleAndCodes.Select(p => CreateFile(p, GeneratedDirectory));

            return files;
        }

        private static string GetDefaultDirectory()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), DEFAULT_GENERATED_FILE);
        }

        private static FileInfo CreateFile((string name, string code) p, string directory)
        {
            var path = Path.Combine(directory, p.name);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using var streamWriter = File.CreateText(path);

            streamWriter.Write(p.code);

            streamWriter.Flush();

            return new FileInfo(path);
        }
    }
}