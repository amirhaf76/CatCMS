namespace CMSCore
{
	public interface IFileSystem
	{
		IEnumerable<string> GetFiles(string directory);
		IEnumerable<string> GetFilesByName(string directory, IEnumerable<string> names);
		string GetFileName(string path);
		string CombinePath(params string[] paths);
	}


}