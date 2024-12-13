using System.Runtime.InteropServices;

namespace Core
{
    public class FileGenerator 
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
            var path = Path.Combine(GeneratedDirectory, p.Name);

            if (!Directory.Exists(GeneratedDirectory))
            {
                Directory.CreateDirectory(GeneratedDirectory);
            }

            using var streamWriter = File.CreateText(path);

            streamWriter.Write(p.Code);

            streamWriter.Flush();

            return new FileInfo(path);
        }
    }
}