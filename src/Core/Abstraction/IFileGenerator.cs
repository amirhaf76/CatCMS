using CMSCore.FileManagement;

namespace CMSCore.Abstraction
{
    public interface IFileGenerator
    {
        string GeneratedDirectory { get; set;  }

        FileInfo CreateFile(PageFile p);
        FileInfo CreateFile(PageFile p, string directory);

        List<FileInfo> CreateFiles(IEnumerable<PageFile> p);
        List<FileInfo> CreateFiles(IEnumerable<PageFile> p, string directory);
    }
}