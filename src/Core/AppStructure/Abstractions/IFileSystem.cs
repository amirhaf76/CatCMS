namespace CMSCore.AppStructure.Abstraction
{
    public interface IFileSystem
    {
        IEnumerable<string> GetFiles(string path);
        IEnumerable<string> GetFilesByName(string path, IEnumerable<string> names);
        IEnumerable<string> GetDirectories(string path, int maxRecursionDepth);
        string GetFileName(string path);
        string CombinePath(params string[] paths);
    }


}