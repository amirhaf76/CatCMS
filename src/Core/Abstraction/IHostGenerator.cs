namespace CMSCore.Abstraction
{
    public interface IHostGenerator
    {
        IEnumerable<FileInfo> GenerateHostAsFiles(Host Site);
    }
}
