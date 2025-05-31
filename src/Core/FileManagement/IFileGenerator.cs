using CMSCore.Abstraction;

namespace CMSCore.FileManagement
{
    public interface IFileGenerator
    {
        FileInfo CreateFile(PageFile p);
        FileInfo CreateFile(PageFile p, string directory);

        List<FileInfo> CreateFiles(IEnumerable<PageFile> p);
        List<FileInfo> CreateFiles(IEnumerable<PageFile> p, string directory);
    }
}