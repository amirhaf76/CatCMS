namespace Core.Abstraction
{
    public interface ISiteGenerator
    {
        IEnumerable<FileInfo> GenerateSite(Site Site);
    }
}
